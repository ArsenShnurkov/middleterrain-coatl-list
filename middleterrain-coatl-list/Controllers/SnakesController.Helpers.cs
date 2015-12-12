using System;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace middleterraincoatllist.Controllers
{
	public partial class SnakesController
	{
		private static IDbConnection GetConnection()
		{
			try
			{
				string providerName = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ProviderName; 

				string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString; 


				DbProviderFactory factory = null;
				try
				{
					factory = DbProviderFactories.GetFactory (providerName);
				}
				catch (System.Configuration.ConfigurationErrorsException ex)
				{
					Trace.WriteLine (ex.ToString ());
					DataTable table_DbProviderFactories = DbProviderFactories.GetFactoryClasses ();
					foreach (DataRow row in table_DbProviderFactories.Rows)
					{
						Trace.WriteLine (row ["InvariantName"].ToString());
					}
				}
				IDbConnection conn = factory.CreateConnection ();
				conn.ConnectionString = connectionString;
				conn.Open ();
				return conn;
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error while connecting to database", ex);
			}
		}

		public static List<CompanyInfo> ReadRecordInterval(IDbConnection conn, IDbTransaction tran, string SortingField, string sort, int start, int length)
		{
			if (string.IsNullOrEmpty(sort))
			{
				sort = "ASC";
			}
			var sortingDirect = string.Format (" ORDER BY {0} {1}", SortingField, sort);
			var sortingReverse = string.Format (" ORDER BY {0} {1}", SortingField, ReverseSort (sort));
			var q = new StringBuilder ();
			q.AppendFormat ("SELECT * FROM (SELECT * FROM MY_PRODUCTS WHERE {0} < {2} + {3}{4}) WHERE {0} >= {2}{1}",
				SortingField, sortingDirect, start, length, sortingReverse);
			IDbCommand cmd = conn.CreateCommand ();
			cmd.CommandText = q.ToString();
			cmd.CommandType = CommandType.Text;
			using (IDataReader reader = cmd.ExecuteReader ()) {
				var res = new List<CompanyInfo> ();
				while (reader.Read ()) {
					var c = new CompanyInfo ();
					c.Id = (int)reader ["MyId".ToUpper()];
					c.Name = (string)reader ["name".ToUpper()];
					c.Url = (string)reader ["url".ToUpper()];
					res.Add (c);
				}
				return res;
			}
		}

		public static string ReverseSort(string sort)
		{
			if (sort.CompareTo ("ASC") == 0) {
				return "DESC";
			}
			if (sort.CompareTo ("DESC") == 0) {
				return "ASC";
			}
			throw new ApplicationException ("Wrong sorting directive");
		}
		public struct record
		{
			public int id;
			public string str;
			public string url;
		}

		public static void F1 ()
		{
			try {
				using (IDbConnection conn = GetConnection()) {
					IDbCommand cmd = conn.CreateCommand ();
					cmd.CommandText = "SHOW TABLES;";
					cmd.CommandType = CommandType.Text;
					int tableCount = 0;
					using (IDataReader reader = cmd.ExecuteReader ()) {
						while (reader.Read ()) {
							tableCount++;
							var tableName = reader [0].ToString ();
							Trace.WriteLine (tableName);
						}
					}
					if (tableCount != 0) {
						DatabaseDeleteStructure (conn, null);
						DatabaseCreateStructure (conn, null);
					}
					if (tableCount == 0) {
						DatabaseCreateStructure (conn, null);
					}
					for (int i = 0; i < 1000; ++i)
					{
						var r = new record ();
						r.id = i;
						r.str = "google" + i.ToString();
						r.url = "www.gooogle.com/"+ i.ToString();
						InsertRecord (conn, null, r);
					}
				}
				using (IDbConnection conn = GetConnection()) {
					//ReadRecords(conn, null);
					ReadRecordInterval(conn, null, "MyId", "ASC", 500, 15);
				}
			} catch (Exception ex) {
				var output = ex.ToString ();
				Trace.WriteLine (output);
			}
		}

		public static void DatabaseCreateStructure (IDbConnection conn, IDbTransaction tran)
		{
			try {
				using (IDbCommand cmd = conn.CreateCommand ()) {
					cmd.CommandText = "CREATE TABLE MY_PRODUCTS (MyId  INTEGER, name VARCHAR, url VARCHAR)";
					int res = cmd.ExecuteNonQuery ();
					Trace.WriteLine (res);
				}
			} catch (Exception ex) {
				var output = ex.ToString ();
				Trace.WriteLine (output);
				Console.WriteLine (output);
				throw;
			}
		}

		public static void DatabaseDeleteStructure (IDbConnection conn, IDbTransaction tran)
		{
			try {
				var tablenames = new List<string>();
				using (IDbCommand cmd = conn.CreateCommand ()) {
					cmd.CommandText = "SHOW TABLES;";
					cmd.CommandType = CommandType.Text;
					using (IDataReader reader = cmd.ExecuteReader ()) {
						while (reader.Read ()) {
							var tableName = reader [0].ToString ();
							tablenames.Add(tableName);
						}
					}				
				}
				foreach (var t in tablenames)
				{
					using (IDbCommand cmd = conn.CreateCommand ()) {
						cmd.CommandText = string.Format("DROP TABLE {0}", t);;
						int res = cmd.ExecuteNonQuery ();
						Trace.WriteLine (res);
					}
				}
			} catch (Exception ex) {
				var output = ex.ToString ();
				Trace.WriteLine (output);
				Console.WriteLine (output);
				throw;
			}
		}

		public static void InsertRecord (IDbConnection conn, IDbTransaction tran, record r)
		{
			try {
				using (IDbCommand cmd = conn.CreateCommand ()) {
					cmd.CommandText = "INSERT INTO MY_PRODUCTS (MyId, name, url) VALUES ({pMyId}, $pName, ?pUrl)";
					// MyId
					var pMyId = cmd.CreateParameter ();
					pMyId.Direction = ParameterDirection.Input;
					pMyId.ParameterName = "pMyId";
					pMyId.DbType = DbType.Int32;
					pMyId.Value = r.id;
					cmd.Parameters.Add (pMyId);
					// Name
					var name = cmd.CreateParameter ();
					name.Direction = ParameterDirection.Input;
					name.ParameterName = "pName";
					name.DbType = DbType.Int32;
					name.Value = r.str;
					cmd.Parameters.Add (name);
					// Url
					var url = cmd.CreateParameter ();
					url.Direction = ParameterDirection.Input;
					url.ParameterName = "pUrl";
					url.DbType = DbType.Int32;
					url.Value = r.url;
					cmd.Parameters.Add (url);
					// run it
					int res = cmd.ExecuteNonQuery ();
					Trace.WriteLine (res);
				}
			} catch (Exception ex) {
				var output = ex.ToString ();
				Trace.WriteLine (output);
				Console.WriteLine (output);
				throw;
			}
		}
	}
}

