using System;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using Eto.Parse;
using Eto.Parse.Grammars;
using db_code_test;

partial class Globals
{
	public static void Main (string[] args)
	{
		var grammar_def = Globals.LoadFromResource("db_code_test", "Resources", "lang_ws.ebnf");
		using (var s = new FileStream ("definition.dbt", FileMode.Open)) {
			var code_to_compile = Globals.LoadFromStream (s);
			Trace.WriteLine (code_to_compile);
			var match = Globals.Process(grammar_def, code_to_compile);

			var schema = Compile (match);

			var transformation3 = new DatabaseModelToPostgreSQL ();
			var dbScript = transformation3.DoTransform (schema);

			using (var o = new FileStream("../../example_of_output.sql", FileMode.Create))
			{
				using (var tv = new StreamWriter(o, Encoding.UTF8))
				{
					dbScript.Generate(tv);
				}
			}
		}

		//F1 ();
		//F2();
	}

	public static Schema Compile(GrammarMatch node)
	{
		// build model from AST (model is more compact and navigable in debugger)
		var transformation1 = new EtoParseToAbstractModel();
		var abstractModel = transformation1.DoTransform (node);
		var transformation2 = new SyntaxModelToDatabaseModel();
		var dbModel = transformation2.DoTransform (abstractModel);
		return dbModel;
	}
	public struct record
	{
		public int id;
		public string str;
		public string url;
	}

	public static void F2 ()
	{
		try {
			using (IDbConnection conn = GetConnection ()) {
				IDbCommand cmd = conn.CreateCommand ();
				var reqWithRowNum = "SELECT ROWNUM() AS N, MyId FROM TABLE_TEST1";
				var reqRestrictedByRowNum = string.Format("SELECT N, MyId FROM ({0}) WHERE N >= 10 AND N < 10+5", reqWithRowNum);
				var reqRestrictedMyId = string.Format("SELECT MyId FROM ({0})", reqRestrictedByRowNum);
				var reqRestrictedAll = string.Format("SELECT * FROM TABLE_TEST1 WHERE MyId IN ({0})", reqRestrictedMyId);
				//cmd.CommandText = "SELECT * FROM (SELECT ROWNUM() AS N, * FROM TABLE_TEST1 ) WHERE N >= 10 AND N < 10+5;";
				cmd.CommandText = reqRestrictedAll;
				cmd.CommandType = CommandType.Text;
				using (IDataReader reader = cmd.ExecuteReader ()) {
					while (reader.Read ()) {
						var line = new StringBuilder();
						for (int i = 0; i < reader.FieldCount; ++i)
						{
							var fn = reader.GetName(i);
							var f = reader [i].ToString ();
							if ( i > 0 )
							{
								line.Append(", ");
							}
							line.AppendFormat("{0}:{1}", fn, f);
						}
						Console.WriteLine (line.ToString());
					}
				}
			}
		} catch (Exception ex) {
			var output = ex.ToString ();
			Trace.WriteLine (output);
		}
	}

	public static void F1 ()
	{
		try {
			using (IDbConnection conn = GetConnection ()) {
				IDbCommand cmd = conn.CreateCommand ();
				cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES;";
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
				cmd.CommandText = "CREATE TABLE TABLE_TEST1 (MyId  INTEGER, name VARCHAR, url VARCHAR)";
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
			using (IDbCommand cmd = conn.CreateCommand ()) {
				cmd.CommandText = "DROP TABLE TABLE_TEST1";
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

	public static void InsertRecord (IDbConnection conn, IDbTransaction tran, record r)
	{
		try {
			using (IDbCommand cmd = conn.CreateCommand ()) {
				cmd.CommandText = "INSERT INTO TABLE_TEST1 (MyId, name, url) VALUES ({pMyId}, $pName, ?pUrl)";
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
	public static void ReadRecords(IDbConnection conn, IDbTransaction tran)
	{
		IDbCommand cmd = conn.CreateCommand ();
		cmd.CommandText = "SELECT * FROM TABLE_TEST1";
		cmd.CommandType = CommandType.Text;
		int tableCount = 0;
		using (IDataReader reader = cmd.ExecuteReader ()) {
			while (reader.Read ()) {
				tableCount++;
				for (int fn = 0; fn < reader.FieldCount; ++fn) {
					var fieldname = reader.GetName (fn);
					var field = reader [fn].ToString ();
					Console.Write ("{0}:{1}\t", fieldname, field);
				}
				Console.WriteLine();
			}
		}
	}
	public static void ReadRecordInterval(IDbConnection conn, IDbTransaction tran, string SortingField, string sort, int start, int length)
	{
		var q = new StringBuilder ();
		q.AppendFormat ("SELECT * FROM (SELECT * FROM TABLE_TEST1 WHERE {0} < {2} + {3} ORDER BY {0} {4}) WHERE {0} >= {2} ORDER BY {0} {1}",
			SortingField, sort, start, length, ReverseSort(sort));
		IDbCommand cmd = conn.CreateCommand ();
		cmd.CommandText = q.ToString();
		cmd.CommandType = CommandType.Text;
		int tableCount = 0;
		using (IDataReader reader = cmd.ExecuteReader ()) {
			while (reader.Read ()) {
				tableCount++;
				for (int fn = 0; fn < reader.FieldCount; ++fn) {
					var fieldname = reader.GetName (fn);
					var field = reader [fn].ToString ();
					Console.Write ("{0}:{1}\t", fieldname, field);
				}
				Console.WriteLine();
			}
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
}
