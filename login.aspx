<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css'>
		<link type='text/css' rel='stylesheet' href='style/inputs.css'>
		<link type='text/css' rel='stylesheet' href='style/login.css'>
	</head>
	<body>
		<form id="form1" runat="server">
			<div></div>
			<div id='top-regbox'>
				<span class="logo">Study o'Clock</span><br />
			</div>
			<div id='regbox'>
				<span class='title'>
					<h4>Loginin-se!</h4>
				</span>
				<span id='regp1' class='regPage'>
					<asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox><br />
					<asp:TextBox type="password" ID="txtPass" runat="server" placeholder="Senha"></asp:TextBox><br />
				</span>
				<div class='controlBox'>
					<asp:Label id='lblError' class='errorMsg' runat='server'></asp:Label>
					<asp:button id='btnLogin' runat='server' text='login' onclick='makeLogin' />
				</div>
				<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
				</asp:SqlDataSource>
			</div>
		</form>
	</body>
</html>
