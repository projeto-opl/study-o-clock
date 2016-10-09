<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginTest.aspx.cs" Inherits="loginTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/reg.css'>
		<link type='text/css' rel='stylesheet' href='style/main.css'>
		<link type='text/css' rel='stylesheet' href='style/inputs.css'>
	</head>
	<body>
		<form id="form1" runat="server">
			<nav id="navegador">
				<span></span>
			</nav>
			<div></div>
			<div id='top-regbox'>
				<span class="logo">Insira aqui seu logo</span><br />
				<span class="subtitulo">Sesdfdafdf</span>
			</div>
			<div id='regbox' style="height:440px;">
				<span class='title'>
					<h4>Loginin-se!</h4>
				</span>
				<span id='regp1' class='regPage'>
					<asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox><br />
					<asp:TextBox type="password" ID="txtPass" runat="server" placeholder="Senha"></asp:TextBox><br />
					<asp:button id='btnLogin' runat='server' text='login' onclick='login' />
				</span>
				<div class="controlBox">
					<input style='display:inline; width:49.5%; float:right;' type='button' value='Continuar' onclick='nextRegPage(2)' />
					<input style='display:inline; width:49.5%; float:left;' type='button' value='Voltar' onclick='prevRegPage(2)' />
					<span class='voltar'>
						<h5>Voltar para inicio</h5>
					</span>
				</div>
				<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
				</asp:SqlDataSource>
			</div>
			<script type='text/javascript' src="script/cadUser.js"></script>
		</form>
	</body>
</html>
