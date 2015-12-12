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
    public partial class SnakesController : Controller
    {

        public ActionResult Index()
        {
			using (IDbConnection conn = GetConnection ())
			{
				var list = ReadRecordInterval (conn, null, "MyId", "ASC", 0, 10);
				this.ViewData ["Products"] = list;
			}
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
				using (IDbConnection conn = GetConnection ())
				{
					int tableCount = 0;
					using (IDbCommand cmd = conn.CreateCommand ())
					{
						cmd.CommandText = "SHOW TABLES;";
						cmd.CommandType = CommandType.Text;
						using (IDataReader reader = cmd.ExecuteReader ())
						{
							while (reader.Read ())
							{
								tableCount++;
								var tableName = reader [0].ToString ();
								Trace.WriteLine (tableName);
							}
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
				// it will be good to redirect to Details(id) instead of index
            }
			catch (Exception ex)
            {
				var output = ex.ToString ();
				Trace.WriteLine (output);
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