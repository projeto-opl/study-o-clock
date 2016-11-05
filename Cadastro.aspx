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
					<asp:Label ID="lblName" runat="server" ForeColor="Red"></asp:Label><br />

					<asp:TextBox ID="txtEmail" runat="server" placeholder='Email'></asp:TextBox>
					<asp:Label ID="lblMail" runat="server" ForeColor="Red"></asp:Label><br />

					<asp:TextBox ID="txtConf" runat="server" placeholder='Confirmar email'></asp:TextBox>
					<asp:Label ID="lblConfMail" runat="server" ForeColor="Red"></asp:Label><br />

					<asp:TextBox ID="txtPass" type='password' runat="server" placeholder='Senha'></asp:TextBox>
					<asp:Label ID="lblPass" runat="server" ForeColor="Red"></asp:Label><br />

					<asp:TextBox ID="txtConfPass" type='password' runat="server" placeholder='Confirmar senha'></asp:TextBox>
					<asp:Label ID="lblConfPass" runat="server" ForeColor="Red"></asp:Label><br />
				</span>
				<div class='controlBox'>
					<asp:Label ID="lblDif" runat="server" ForeColor="Red"></asp:Label>
					<asp:Button ID="btnReg" runat="server" Text="Cadastrar" OnClick="btnReg_Click" />
					<asp:Button ID="btnBack" runat="server" Text="Voltar" />
				</div>
				<asp:SqlDataSource ID="SqlRinf" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" InsertCommand="INSERT INTO users(name, pass, email) VALUES (@Name, @Pass, @Email)" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>" SelectCommand="SELECT * FROM users">
					<InsertParameters>
						<asp:ControlParameter ControlID="txtName" Name="Name" PropertyName="Text" />
						<asp:ControlParameter ControlID="txtPass" Name="Pass" PropertyName="Text" />
						<asp:ControlParameter ControlID="txtEmail" Name="Email" PropertyName="Text" />
					</InsertParameters>
				</asp:SqlDataSource>
			</div>
		</form>
	</body>
</html>
