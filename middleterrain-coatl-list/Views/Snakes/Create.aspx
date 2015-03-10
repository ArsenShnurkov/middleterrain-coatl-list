<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Create snake</title>
</head>
<body>
	<div>
	<form runat="server">
	<asp:TextBox id="tbName" Text="Name" runat="server" />
	<br />
	<asp:TextBox id="tbUrl" Text="URL" runat="server" />
	<br />
	<asp:TextBox id="tbDescription" Text="Description" runat="server" TextMode="multiline" />
	<br />
	<asp:Button id="id" text="Create" runat="server" />
	</form>
	</div>
</body>
