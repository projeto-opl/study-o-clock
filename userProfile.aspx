<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userProfile.aspx.cs" Inherits="userProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/userProfile.css' />
	</head>
	<body>
		<form runat='server'>
			<article>
				<asp:Image id='imgProfilePicture' runat='server' /><br />
				<asp:Label id='lblName' runat='server'></asp:Label><br />
				<asp:button id='btnFollow' runat='server' onclick='addFeed' /><br />
				<asp:button id='btnAddFriend' runat='server' onclick='friendRequest' /><br />
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
