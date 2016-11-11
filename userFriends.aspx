<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userFriends.aspx.cs" Inherits="userFriends" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title><%=CurUser["name"]%></title>
		<meta charset="UTF-8">
		<link type='text/javascript' rel='stylesheet' href='style/main.css' />
		<link type='text/javascript' rel='stylesheet' href='style/inputs.css' />
		<link type='text/javascript' rel='stylesheet' href='style/userFriends.css' />
		<script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
	</head>
	<body>
		<form runat='server'>
			<nav>
				<div ><img id="hue" class="navegador2" src="_imagens/hue.png"height="45"/></div>
				<div id="logo" class="navegador"></div>
				<div id="pesquisa" class="navegador"><input placeholder="Procure alguém..." type="text" id="searchbox"/></div>
				<div id="carinha"><img src="_imagens/perfil.png"height="45"/></div>
				<div id="msg"><img src="_imagens/noti.png"height="45"/></div>
			</nav>
			<div id="corpo">
				<!--notificacao-->
				<div class="abanotificacao">
					<!--<div class="notificacaopic">-->
						<!--<p class="usernoti">Brédi Piti</p>-->
						<!--<p class="conteudonoti">Compartilhou uma imagem</p>-->
					<!--</div>-->
				</div>
				<!--parte comum-->
				<div class="fotenha">
					<a href="index.html"><img src="_imagens/pppp.jpg" height="140px"/></a>
				</div>
				<div class="nseionome">
					<input id="alterar" type='button' value='Alterar Info' />
					<div class="gambiarra"> <!-- Esta div existe pq os botoes estavam bugando -->
						<input id="amigos" type='button' value='Amigos' />
					</div>
				</div>
				<div class="username">
					<a href="index.html" style="color:#FFFFFF; text-decoration:none;">Fábio Lucas</a>
				</div>
				<!-- parte 'unica': amigos -->
				<div class="tituloamigos">
					<h5>Amigos de <%=CurUser["name"]%> (<%=FriendsQtd%>)</h5>
				</div>
				<div class="friends" id='friends_facename' runat='server'>
				</div>
				<!--fim da div 'corpo'-->
			</div>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
