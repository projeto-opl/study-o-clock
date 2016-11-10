<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userFriends.aspx.cs" Inherits="userFriends" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title>Fabio Lucas</title>
		<meta charset="UTF-8">
		<link type="text/css" rel="stylesheet" href="_css/estilo.css" />
		<link href="_css/style.css" rel="stylesheet">
		<link href="_css/friendsstyle.css" rel="stylesheet">
		<script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
		<script src="_js/script.js"></script>
		<!--<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
		<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
		<script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>-->
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
					<div class="notificacaopic">
						<p class="usernoti">Brédi Piti</p>
						<p class="conteudonoti">Compartilhou uma imagem</p>
					</div>
					<div class="notificacaostatus">
						<p class="usernoti">Brédi Piti</p>
						<p class="conteudonoti">Adicionou um novo status</p>
					</div>
				</div>
				<!--parte comum-->
				<div class="fotenha">
					<a href="index.html"><img src="_imagens/pppp.jpg" height="140px"/></a>
				</div>
				<div class="nseionome">
					<input id="alterar" type='button' value='Alterar Info' />
					<div class="gambiarra"> <!-- Esta div existe pq os botoes estavam bugando -->
						<a href="friends.html"><input id="amigos" type='button' value='Amigos'></a>
					</div>
				</div>
				<div class="username">
					<a href="index.html" style="color:#FFFFFF; text-decoration:none;">Fábio Lucas</a>
				</div>
				<!-- parte 'unica': amigos -->
				<div class="friends" id='friends_facename' runat='server'>
					<div class="tituloamigos">
						<h5>Amigos de <%=CurUser["name"]%> (<%=FriendsQtd%>)</h5>
					</div>
				</div>
				<!--fim da div 'corpo'-->
			</div>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
<!--<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/userFriends.css' />
	</head>
	<body>
		<form runat='server'>
			<article>
				<div id='friends_facename' runat='server'>
					<div class='friends_entry'>
						<img class='friend_pic'/>
						<span class='friend_name'></span>
					</div>
				</div>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>-->
