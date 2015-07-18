using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace middleterraincoatllist.Controllers
{
    public class SnakesController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
				using (DbConnection conn = factory.CreateConnection ())
				{
					conn.ConnectionString = connectionString;
					conn.Open ();
					DbCommand cmd = conn.CreateCommand ();
					cmd.CommandText = "SHOW TABLES;";
					cmd.CommandType = CommandType.Text;
					int tableCount = 0;
					using (DbDataReader reader = cmd.ExecuteReader ())
					{
						while (reader.Read ())
						{
							tableCount++;
							Trace.WriteLine (reader [0].ToString ());
						}
					}
					if (tableCount == 0)
					{
						CreateDatabaseStructure (conn, null);
					}
				}


                string tbName = Convert.ToString(collection["tbName"]);
                string tbUrl = Convert.ToString(collection["tbUrl"]);
                string tbDescription = Convert.ToString(collection["tbDescription"]);
                return RedirectToAction ("Index");
            }
            catch
            {
                return View ();
            }
        }

		public void CreateDatabaseStructure (IDbConnection conn, IDbTransaction tran)
		{
			using (IDbCommand cmd = conn.CreateCommand ()) {
				cmd.CommandText = "CREATE TABLE test (MyId  int )";
				int res = cmd.ExecuteNonQuery ();
				Trace.WriteLine (res);
			}
		}
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
    }
}