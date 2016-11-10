<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userProfile.aspx.cs" Inherits="userProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<meta charset='utf-8'>
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/userProfile.css' />
	</head>
	<body>
		<form runat='server'>
			<article>
				<asp:Button id='btnLogout' runat='server' text='logout' onclick='logout'/><br />
				<asp:Image id='imgProfilePicture' runat='server'/><br />
				<asp:Label id='lblName' runat='server'></asp:Label><br />
				<asp:label id='lblBio' runat='server'></asp:label><br />
				<asp:button id='btnShowFriends' runat='server' text='Amigos dessa pessoa' onclick='showFriends'/>
				<asp:button id='btnFollow' runat='server' onclick='addFeed' visible='false'/>
				<asp:button id='btnAddFriend' runat='server' onclick='friendRequest' visible='false'/>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
