using System;
using System.Text;
using System.Globalization;
using System.Web;
using System.Security.Cryptography;
using System.Configuration;
using System.Web.Configuration;

namespace middleterraincoatllist
{
	public static class SessionUtils 
	{
		public static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

		public static bool StartsWith (string str1, string str2)
		{
			return StartsWith (str1, str2, false);
		}

		public static bool StartsWith (string str1, string str2, bool ignore_case)
		{
			int l2 = str2.Length;
			if (l2 == 0)
				return true;

			int l1 = str1.Length;
			if (l2 > l1)
				return false;

			return (0 == String.Compare (str1, 0, str2, 0, l2, ignore_case, InvariantCulture));
		}

		public static bool EndsWith (string str1, string str2)
		{
			return EndsWith (str1, str2, false);
		}

		public static bool EndsWith (string str1, string str2, bool ignore_case)
		{
			int l2 = str2.Length;
			if (l2 == 0)
				return true;

			int l1 = str1.Length;
			if (l2 > l1)
				return false;

			return (0 == String.Compare (str1, l1 - l2, str2, 0, l2, ignore_case, InvariantCulture));
		}

		public static string EscapeQuotesAndBackslashes (string attributeValue)
		{
			StringBuilder sb = null;
			for (int i = 0; i < attributeValue.Length; i++) {
				char ch = attributeValue [i];
				if (ch == '\'' || ch == '"' || ch == '\\') {
					if (sb == null) {
						sb = new StringBuilder ();
						sb.Append (attributeValue.Substring (0, i));
					}
					sb.Append ('\\');
					sb.Append (ch);
				}
				else {
					if (sb != null)
						sb.Append (ch);
				}
			}
			if (sb != null)
				return sb.ToString ();
			return attributeValue;
		}

		public static bool IsNullOrEmpty (string value)
		{
			return String.IsNullOrEmpty (value);
		}

		public static string [] SplitRemoveEmptyEntries (string value, char [] separator)
		{
			return value.Split (separator, StringSplitOptions.RemoveEmptyEntries);
		}

		static public string GetHexString (byte [] bytes)
		{
			StringBuilder sb = new StringBuilder (bytes.Length * 2);
			int letterPart = 55;
			const int numberPart = 48;
			for (int i = 0; i < bytes.Length; i++) {
				int tmp = (int) bytes [i];
				int second = tmp & 15;
				int first = (tmp >> 4) & 15;
				sb.Append ((char) (first > 9 ? letterPart + first : numberPart + first));
				sb.Append ((char) (second > 9 ? letterPart + second : numberPart + second));
			}
			return sb.ToString ();
		}
		// appRoot + SessionID + vpath
		public static string InsertSessionId (string id, string path)
		{
			string dir = GetDirectory (path);
			if (!dir.EndsWith ("/"))
				dir += "/";

			string appvpath = HttpRuntime.AppDomainAppVirtualPath;
			if (!appvpath.EndsWith ("/"))
				appvpath += "/";

			if (path.StartsWith (appvpath))
				path = path.Substring (appvpath.Length);

			if (path.StartsWith("/"))
				path = path.Length > 1 ? path.Substring (1) : "";

			return Canonic (appvpath + SessionId.Prefix + id + SessionId.Postfix + "/" + path);
		}

		public static bool HasSessionId (string path)
		{
			if (path == null || path.Length < 5)
				return false;

			return (StartsWith (path, "/(") && path.IndexOf (")/") > 2);
		}

		public static string RemoveSessionId (string base_path, string file_path)
		{
			// Caller did a GetSessionId first
			int idx = base_path.IndexOf ("/(");
			string dir = base_path.Substring (0, idx + 1);
			if (!dir.EndsWith ("/"))
				dir += "/";

			idx = base_path.IndexOf (")/");
			if (idx != -1 && base_path.Length > idx + 2) {
				string dir2 = base_path.Substring (idx + 2);
				if (!dir2.EndsWith ("/"))
					dir2 += "/";

				dir += dir2;
			}

			return Canonic (dir + GetFile (file_path));
		}

		public static string Combine (string basePath, string relPath)
		{
			if (relPath == null)
				throw new ArgumentNullException ("relPath");

			int rlength = relPath.Length;
			if (rlength == 0)
				return "";

			relPath = relPath.Replace ('\\', '/');
			if (IsRooted (relPath))
				return Canonic (relPath);

			char first = relPath [0];
			if (rlength < 3 || first == '~' || first == '/' || first == '\\') {
				if (basePath == null || (basePath.Length == 1 && basePath [0] == '/'))
					basePath = String.Empty;

				string slash = (first == '/') ? "" : "/";
				if (first == '~') {
					if (rlength == 1) {
						relPath = "";
					} else if (rlength > 1 && relPath [1] == '/') {
						relPath = relPath.Substring (2);
						slash = "/";
					}

					string appvpath = HttpRuntime.AppDomainAppVirtualPath;
					if (appvpath.EndsWith ("/"))
						slash = "";

					return Canonic (appvpath + slash + relPath);
				}

				return Canonic (basePath + slash + relPath);
			}

			if (basePath == null || basePath.Length == 0 || basePath [0] == '~')
				basePath = HttpRuntime.AppDomainAppVirtualPath;

			if (basePath.Length <= 1)
				basePath = String.Empty;

			return Canonic (basePath + "/" + relPath);
		}

		static char [] path_sep = {'\\', '/'};

		public static string Canonic (string path)
		{
			bool isRooted = IsRooted(path);
			bool endsWithSlash = path.EndsWith("/");
			string [] parts = path.Split (path_sep);
			int end = parts.Length;

			int dest = 0;

			for (int i = 0; i < end; i++) {
				string current = parts [i];

				if (current.Length == 0)
					continue;

				if (current == "." )
					continue;

				if (current == "..") {
					dest --;
					continue;
				}
				if (dest < 0)
				if (!isRooted)
					throw new HttpException ("Invalid path.");
				else
					dest = 0;

				parts [dest++] = current;
			}
			if (dest < 0)
				throw new HttpException ("Invalid path.");

			if (dest == 0)
				return "/";

			string str = String.Join ("/", parts, 0, dest);
			str = RemoveDoubleSlashes (str);
			if (isRooted)
				str = "/" + str;
			if (endsWithSlash)
				str = str + "/";

			return str;
		}

		public static string GetDirectory (string url)
		{
			url = url.Replace('\\','/');
			int last = url.LastIndexOf ('/');

			if (last > 0) {
				if (last < url.Length)
					last++;
				return RemoveDoubleSlashes (url.Substring (0, last));
			}

			return "/";
		}

		public static string RemoveDoubleSlashes (string input)
		{
			// MS VirtualPathUtility removes duplicate '/'

			int index = -1;
			for (int i = 1; i < input.Length; i++)
				if (input [i] == '/' && input [i - 1] == '/') {
					index = i - 1;
					break;
				}

			if (index == -1) // common case optimization
				return input;

			StringBuilder sb = new StringBuilder (input.Length);
			sb.Append (input, 0, index);

			for (int i = index; i < input.Length; i++) {
				if (input [i] == '/') {
					int next = i + 1;
					if (next < input.Length && input [next] == '/')
						continue;
					sb.Append ('/');
				}
				else {
					sb.Append (input [i]);
				}
			}

			return sb.ToString ();
		}

		public static string GetFile (string url)
		{
			url = url.Replace('\\','/');
			int last = url.LastIndexOf ('/');
			if (last >= 0) {
				if (url.Length == 1) // Empty file name instead of ArgumentOutOfRange
					return "";
				return url.Substring (last+1);
			}

			throw new ArgumentException (String.Format ("GetFile: `{0}' does not contain a /", url));
		}

		public static bool IsRooted (string path)
		{
			if (path == null || path.Length == 0)
				return true;

			char c = path [0];
			if (c == '/' || c == '\\')
				return true;

			return false;
		}

		public static bool IsRelativeUrl (string path)
		{
			return (path [0] != '/' && path.IndexOf (':') == -1);
		}

		public static string ResolveVirtualPathFromAppAbsolute (string path)
		{
			if (path [0] != '~') return path;

			if (path.Length == 1)
				return HttpRuntime.AppDomainAppVirtualPath;

			if (path [1] == '/' || path [1] == '\\') {
				string appPath = HttpRuntime.AppDomainAppVirtualPath;
				if (appPath.Length > 1) 
					return appPath + "/" + path.Substring (2);
				return "/" + path.Substring (2);
			}
			return path;    
		}

		public static string ResolvePhysicalPathFromAppAbsolute (string path) 
		{
			if (path [0] != '~') return path;

			if (path.Length == 1)
				return HttpRuntime.AppDomainAppPath;

			if (path [1] == '/' || path [1] == '\\') {
				string appPath = HttpRuntime.AppDomainAppPath;
				if (appPath.Length > 1)
					return appPath + "/" + path.Substring (2);
				return "/" + path.Substring (2);
			}
			return path;
		}

		static private string GetMd5Sum(string s)
		{
			Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
			byte[] text = new byte[s.Length * 2];
			enc.GetBytes(s.ToCharArray(), 0, s.Length, text, 0, true);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = md5.ComputeHash(text);
			StringBuilder sb = new StringBuilder();
			for (int i=0; i<result.Length; i++)
			{
				sb.Append(result[i].ToString("X2"));
			}
			return sb.ToString();
		}

		public static string GetUnqiueFingerprint(this HttpRequest Request)
		{
			string source=
				string.Join(",", Request.AcceptTypes)+";"+
				string.Join(",", Request.UserLanguages)+";"+
				Request.UserHostAddress+";"+
				Request.UserAgent;
			return GetMd5Sum(source);
		}

		public static string ApplyUrlModifier(this HttpRequest req, string url)
		{
			return ApplyUrlModifier(url, req.RequestContext.HttpContext.Session.SessionID);
		}

		public static string ApplyUrlModifier(this HttpRequestBase req, string url)
		{
			return ApplyUrlModifier(url, req.RequestContext.HttpContext.Session.SessionID);
		}

		public static string ApplyUrlModifier(this HttpRequest req, string url, string id)
		{
			return ApplyUrlModifier (url, id);
		}

		public static string ApplyUrlModifier(this HttpRequestBase req, string url, string id)
		{
			return ApplyUrlModifier (url, id);
		}

		public static string ApplyUrlModifier(string url, string id)
		{
			if (string.IsNullOrEmpty (id)) {
				return url;
			}
			Configuration cfg =
				WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
			var pConfig = (SessionStateSection)cfg.GetSection("system.web/sessionState");
			if (pConfig.Cookieless != HttpCookieMode.UseUri) {
				return url;
			}
			UriBuilder newUri = new UriBuilder (url);
			var query = HttpUtility.ParseQueryString(newUri.Query);
			query.Add ("SessionID", id);
			newUri.Query = query.ToString();
			return newUri.Uri.PathAndQuery;
		}
	}
}

