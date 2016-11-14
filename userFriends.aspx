<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userFriends.aspx.cs" Inherits="userFriends" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<title><%=CurUser["name"]%></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/inputs.css' />
		<link type='text/css' rel='stylesheet' href='style/userFriends.css' />
		<script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
	</head>
	<body>
		<form runat='server'>
			<nav>
				<asp:Button id='btnLogout' runat='server' text='logout' onclick='logout' usesubmitbehavior='false' />
				<input type='button' value='config' onclick='window.location="<%=FileName.Config%>"' />
				<br />

				<div id='pesquisa' class='navegador'>
					<asp:TextBox id='txtSearchBox' runat='server' placeholder='pesquisar'></asp:TextBox>
				</div>
				<asp:Button style='display:none;' text='🔎' id='btnPesq' runat='server' onclick='btnPesq_Click' UseSubmitBehavior='true' /><br />
			</nav>
			<article id="corpo">
				<div class="tituloamigos">
					<h5>Amigos de <%=CurUser["name"]%> (<%=FriendsQtd%>)</h5>
				</div>
				<div class="friends" id='friends_facename' runat='server'>
				</div>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
