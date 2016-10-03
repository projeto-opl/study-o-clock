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
			<nav>
				<div ><img id="hue" class="navegador2" src="_imagem/hue.png"height="45"/></div>
				<div id="logo" class="navegador"></div>
				<div id="pesquisa" class="navegador"><input placeholder="Procure alguem..." type="text" id="searchbox"/></div>
				<div id="carinha"><img src="imagem/perfil.png"height="45"/></div>
				<div id="msg"><img src="imagem/msg.png"height="45"/></div>
			</nav>
			<article>
				<div id="corpo">
					<div class="fotenha"><img src="imagem/pppp.jpg" height="140px"/></div>
					<div class="nseionome">
						<input id="alterar" type='button' value='Alterar Info'>
					</div>
					<div class="nseionome2">
						<input id="amigos" type='button' value='Amigos'>
					</div>
					<div class="username"><asp:label id='lblName' runat='server'></asp:label></div>
				</div>
				<section style='display:none;'>
					<h5>Amiguinhos</h5>
					<asp:GridView id='gdFriends' runat='server'>
					</asp:gridview>
				</section>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
