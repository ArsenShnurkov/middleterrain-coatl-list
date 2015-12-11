<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import namespace="middleterraincoatllist"  %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Create snake</title>
</head>
<body>
	<div>
	<% var url= Request.ApplyUrlModifier("/Snakes/Create"); %>
	<form action="<% =url %>" method="POST" >
	<input type="text" id="tbName" Text="Name" />
	<br />
	<input type="text" id="tbUrl" Text="URL" />
	<br />
	<input type="text" id="tbDescription" Text="Description" TextMode="multiline" />
	<br />
	<input type="submit" id="id" text="Create" />
	</form>
	</div>
</body>
