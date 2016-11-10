<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/inputs.css' />
		<link type='text/css' rel='stylesheet' href='style/login.css' />
	</head>
	<body>
		<form id="form1" runat="server">
			<div></div>
			<div id='top-regbox'>
				<span class="logo">Study o'Clock</span><br />
			</div>
			<div id='regbox'>
				<span class='title'>
					<h4>Cadastre-se</h4>
				</span>
				<span id='regp1' class='regPage'>
					<asp:TextBox ID="txtName" runat="server" placeholder='Nome'></asp:TextBox>
					<asp:TextBox ID="txtEmail" runat="server" placeholder='Email'></asp:TextBox>
					<asp:TextBox ID="txtConf" runat="server" placeholder='Confirmar email'></asp:TextBox>
					<asp:TextBox ID="txtPass" type='password' runat="server" placeholder='Senha'></asp:TextBox>
					<asp:TextBox ID="txtConfPass" type='password' runat="server" placeholder='Confirmar senha'></asp:TextBox>

					<div class='controlBox'>
						<asp:Label ID="lblDif" runat="server" ForeColor="Red"></asp:Label><br />
						<asp:Button ID="btnReg" runat="server" Text="Cadastrar" OnClick="btnReg_Click" />
						<asp:Button ID="btnBack" runat="server" Text="Voltar" UseSubmitBehavior='false' />
					</div>
				</span>
				<span id='regp2' class='regPage'>
					<p>Insira o Código de confirmação abaixo:</p>
					<asp:TextBox id='txtConfCode' runat='server' placeholder='Código de ativação'></asp:TextBox>
					<asp:Button id='btnLogin' runat='server' Text='Confirmar' />
				</span>
				<asp:SqlDataSource ID="SqlRinf" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" InsertCommand="INSERT INTO users(name, pass, email) VALUES (@Name, @Pass, @Email)" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>" SelectCommand="SELECT * FROM users">
				<InsertParameters>
				<asp:ControlParameter ControlID="txtName" Name="Name" PropertyName="Text" />
				<asp:ControlParameter ControlID="txtPass" Name="Pass" PropertyName="Text" />
				<asp:ControlParameter ControlID="txtEmail" Name="Email" PropertyName="Text" />
				</InsertParameters>
				</asp:SqlDataSource>
			</div>
			<script src='script/cadUser.js' type='text/javascript'></script>
		</form>
	</body>
</html>
