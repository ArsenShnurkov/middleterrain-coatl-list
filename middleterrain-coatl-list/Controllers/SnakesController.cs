using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Specialized;

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
		/*
		https://msdn.microsoft.com/en-us/library/ms525985%28v=vs.90%29.aspx
		Form input is contained in headers. 
		http://stackoverflow.com/questions/30313401/request-form-empty
        Request.Form is NameValueCollection,
        which returns null if specified key is not found,
        returns value (which is an empty string) otherwise.
        If you want to post stuff (i.e populate Request.Form) you need to provide
        all the data to be posted
        as setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
        http://stackoverflow.com/questions/4007969/application-x-www-form-urlencoded-or-multipart-form-data
        For application/x-www-form-urlencoded, the body of the HTTP message sent to the server 
        is essentially one giant query string -- name/value pairs are separated by the ampersand (&),
        and names are separated from values by the equals symbol (=).
        The Form property is populated when the HTTP request Content-Type value
        is either "application/x-www-form-urlencoded" or "multipart/form-data".
        https://msdn.microsoft.com/en-us/library/system.web.httprequest.form%28v=vs.110%29.aspx
		*/
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
				// Obtain values from form
				var ci = new CompanyInfo();
				//ci.Name = Convert.ToString(collection["tbName"]);
				//ci.Url = Convert.ToString(collection["tbUrl"]);
				//ci.Description = Convert.ToString(collection["tbDescription"]);
				NameValueCollection nvc = Request.Form;
				ci.Id = 3;
				ci.Name = Convert.ToString(nvc["tbName"]);
				ci.Url = Convert.ToString(nvc["tbUrl"]);
				ci.Description = Convert.ToString(nvc["tbDescription"]);

				using (IDbConnection conn = GetConnection ())
				{
					using (IDbTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable))
					{
						using (IDbCommand cmd = conn.CreateCommand ())
						{
							InsertRecord(conn, tran, ci);
						}
						tran.Commit();
					}
				}
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