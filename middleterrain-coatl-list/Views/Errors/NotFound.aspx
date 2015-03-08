<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>404</title>
</head>
<body>
	<h1>404</h1>
	<% =Request["aspxerrorpath"] %>
</body>
</html>
