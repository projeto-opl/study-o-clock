<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userFriends.aspx.cs" Inherits="userFriends" %>

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
				<div id='friends_facename' runat='server'>
					<!--<div class='friends-entry'>-->
						<!--<img class='friend-pic'/>-->
						<!--<span class='friend-name'></span>-->
					<!--</div>-->
				</div>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
