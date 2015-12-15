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
	<form action="<% =url %>" method="post" enctype="application/x-www-form-urlencoded" >
	<input type="text" id="tbName" name="tbName" Text="Name" value="v1" />
	<br />
	<input type="text" id="tbUrl" name="tbUrl" Text="URL" / value="v2" >
	<br />
	<input type="text" id="tbDescription" name="tbDescription" Text="Description" TextMode="multiline" value="v3" />
	<br />
	<input type="submit" id="id" text="Create" />
	</form>
	</div>
</body>
