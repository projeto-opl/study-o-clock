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
				<div class='left'>
					<img id="logo" src="images/O.png" alt="study" height="90" />
				</div>

				<div class='right vertical-center'>
					<a id="carinha" href='<%=FileName.Profile%>'>
						<img src="images/perfil.png" height='45'/>
					</a>
					<a id="forum" href='#naotemainda'>
						<img src="images/forum.png" height='45'/>
					</a>
					<a id='config' href='<%=FileName.Config%>'>
						<img src="images/config.png" height='45'/>
					</a>
					<asp:Button id='btnLogout' runat='server' text='logout' Onclick='logout' UseSubmitBehavior='false' />
				</div>

				<div class='content'>
					<asp:TextBox id='txtSearchBox' runat='server' placeholder='pesquisar'></asp:TextBox>
					<asp:Button style='display:none;' text='🔎' id='btnPesq' runat='server' onclick='btnPesq_Click' UseSubmitBehavior='true' />
				</div>
			</nav>
			<div class='content'>
				<div><!--'header' com img, nome, e etc do perfil {{{-->
					<div id='main-profile-pic' class='profile_img_wrapper'>
						<asp:Image id='imgProfilePicture' runat='server'/>
					</div>
					<div id='face_card'>
						<div id='card'>
							<h1><asp:Label id='lblName' runat='server'></asp:Label></h1>
							<br />
							<asp:label id='lblBio' runat='server'></asp:label>
							<br />
							<div id='profile-controls'>
								<asp:button id='btnShowFriends' runat='server' text='Amigos dessa pessoa' UseSubmitBehavior='false' onclick='showFriends' />
								<asp:button id='btnShowGroups' runat='server' text='Grupos que participa' UseSubmitBehavior='false' onclick='showGroups' />
								<asp:button id='btnAddFriend' runat='server' onclick='friendRequest' UseSubmitBehavior='false' visible='false'/>
							</div>
						</div>
					</div>
				</div><!--}}}-->
				<article>
					<div class="tituloamigos">
						<h5>Amigos de <%=CurUser["name"]%> (<%=FriendsQtd%>)</h5>
						<hr />
					</div>
					<div class="friends" id='friends_facename' runat='server'>
					</div>
				</article>
			</div>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
