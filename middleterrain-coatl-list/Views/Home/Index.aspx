<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title></title>
</head>
<body>
	<h2>Welcome to ASP.NET MVC <%: ViewData["Version"] %> on <%: ViewData["Runtime"] %>!</h2>
	<a href="/Snakes/Create">Create a new snake</a>
	<a href="/Snakes/">All snakes</a>
</body>
</html>
