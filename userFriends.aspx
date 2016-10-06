<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userFriends.aspx.cs" Inherits="userFriends" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/userFriends.css' />
	</head>
	<body>
		<form runat='server'>
			<article>
				<div id='friends_facename' runat='server'>
					<!--<div class='friends_entry'>-->
						<!--<img class='friend_pic'/>-->
						<!--<span class='friend_name'></span>-->
					<!--</div>-->
				</div>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
