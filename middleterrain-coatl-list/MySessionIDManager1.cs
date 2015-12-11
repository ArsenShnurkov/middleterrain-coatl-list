using System;
using System.Configuration;
using System.Web;
//using System.Web.Util;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Diagnostics;

namespace middleterraincoatllist
{

	public class MySessionIDManager1 : /*IHttpModule,*/ ISessionIDManager
	{
		internal const string HeaderName = "AspFilterSessionId";

		private SessionStateSection pConfig = null;

		private SessionStateSection Config { get { 
				if (pConfig == null)
				{
					Configuration cfg =
						WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
					pConfig = (SessionStateSection)cfg.GetSection("system.web/sessionState");
				}
				return pConfig;
			} }

		public static int SessionIDMaxLength {
			get { return 80; }
		}

		/*void IHttpModule.Init(HttpApplication app)
		{
			// Obtain session-state configuration settings.

		}

		void IHttpModule.Dispose()
		{
		}*/

		void ISessionIDManager.Initialize()
		{
			Trace.Assert(Config != null);
		}

		string ISessionIDManager.CreateSessionID(HttpContext context)
		{
			return "1234";
			//return SessionId.Create();
			//return context.Request.GetUnqiueFingerprint();
			//return Guid.NewGuid().ToString();
		}

		bool ISessionIDManager.Validate(string id)
		{
			if (string.Compare(id, "1234", true) == 0)
			{
				return true;
			}
			/*
			try
			{
				Guid testGuid = new Guid(id);

				if (id == testGuid.ToString())
					return true;
			}
			catch
			{
			}
			*/
			if (id != null && id.Length > SessionIDMaxLength) {
				throw new HttpException ("The length of the session-identifier value retrieved from the HTTP request exceeds the SessionIDMaxLength value.");
			}

			return false;
		}

		bool ISessionIDManager.InitializeRequest(HttpContext context, 
			bool suppressAutoDetectRedirect, 
			out bool supportSessionIDReissue)
		{
			var mode = Config.Cookieless;
			if (mode == HttpCookieMode.UseCookies)
			{
				supportSessionIDReissue = false;
				return false;
			}
			else
			{
				supportSessionIDReissue = true;
				return context.Response.IsRequestBeingRedirected;
			}
		}

		string ISessionIDManager.GetSessionID(HttpContext context)
		{
			string id = null;

			if (pConfig.Cookieless == HttpCookieMode.UseUri)
			{
				//throw new NotImplementedException();

				// Retrieve the SessionID from the URI.
				string tmp = context.Request.Url.PathAndQuery;
				//string tmp = context.Request.Headers [HeaderName];
				id = ExtractSessionId(tmp);
				if (id != null)
				{
					id = HttpUtility.UrlDecode (id);
				}

				Trace.WriteLine (id);
			}
			else
			{
				id = context.Request.Cookies[pConfig.CookieName].Value;
			}      

			// Verify that the retrieved SessionID is valid. If not, return null.

			if (!((ISessionIDManager)this).Validate(id))
				id = null;

			return id;
		}

		void ISessionIDManager.RemoveSessionID(HttpContext context)
		{
			if (pConfig.Cookieless == HttpCookieMode.UseUri) {
				throw new NotImplementedException ();
			} else {
				context.Response.Cookies.Remove (pConfig.CookieName);
			}
		}

		void ISessionIDManager.SaveSessionID(HttpContext context, string id, out bool redirected, out bool cookieAdded)
		{
			if (!((ISessionIDManager)this).Validate(id)) {
				throw new HttpException ("Invalid session ID");
			}
			
			redirected = false;
			cookieAdded = false;

			HttpRequest request = context.Request;

			if (pConfig.Cookieless == HttpCookieMode.UseUri)
			{
				// Add the SessionID to the URI. Set the redirected variable as appropriate.
				//request.SetHeader (HeaderName, id);
				cookieAdded = false;
				redirected = true;
				UriBuilder newUri = new UriBuilder (request.Url);
				newUri.Path = SessionUtils.InsertSessionId (id, request.FilePath);
				context.Response.Redirect (newUri.Uri.PathAndQuery, false);

				return;
			}
			else
			{
				context.Response.Cookies.Add(new HttpCookie(pConfig.CookieName, id));
				cookieAdded = true;
			}
		}

		static string ExtractSessionId (string path)
		{
			#if TARGET_DOTNET
			return null;
			#else
			if (path == null)
				return null;

			string appvpath = HttpRuntime.AppDomainAppVirtualPath;
			int appvpathlen = appvpath.Length;

			if (path.Length <= appvpathlen)
				return null;

			path = path.Substring (appvpathlen);

			int len = path.Length;
			if (len == 0 || path [0] != '/') {
				path = '/' + path;
				len++;
			}

			int posPrefix = path.IndexOf(SessionId.Prefix);
			if (posPrefix < 0) return null;

			int posPostfix = path.IndexOf(SessionId.Postfix, posPrefix);
			if (posPostfix < 0) return null;

			posPrefix += SessionId.Prefix.Length;
			return path.Substring (posPrefix, posPostfix - posPrefix);
			#endif
		}
	}
}
