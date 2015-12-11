using System;
using System.Configuration;
using System.Web;
//using System.Web.Util;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Diagnostics;

namespace middleterraincoatllist
{
	public class MySessionIDManager0: SessionIDManager, ISessionIDManager
	{  
		void ISessionIDManager.SaveSessionID( HttpContext context, string id, out bool redirected, out bool cookieAdded )
		{
			throw new NotImplementedException ();
		}
	}
}
