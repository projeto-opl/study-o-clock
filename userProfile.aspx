<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userProfile.aspx.cs" Inherits="userProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat='server'>
		<meta charset='utf-8'>
		<title><%=CurUser["name"]%></title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/inputs.css' />
		<link type='text/css' rel='stylesheet' href='style/userProfile.css' />
	</head>
	<body>
		<form runat='server'>
			<nav>
				<asp:Button id='btnLogout' runat='server' text='logout' Onclick='logout' UseSubmitBehavior='false' />
				<input type='button' value='config' onclick='window.location="<%=FileName.Config%>"' />
				<input type='button' value='profile' onclick='window.location="<%=FileName.Profile%>"' />

				<div class='content'>
					<asp:TextBox id='txtSearchBox' runat='server' placeholder='pesquisar'></asp:TextBox>
					<asp:Button style='display:none;' text='🔎' id='btnPesq' runat='server' onclick='btnPesq_Click' UseSubmitBehavior='true' />
				</div>
			</nav>

			<div class='content'>
				<article>
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
								<asp:button id='btnAddFriend' runat='server' onclick='friendRequest' UseSubmitBehavior='false' visible='false'/>
							</div>
						</div>
					</div>
				</article>
				<article id='posts_container'>
					<div id='post_control' runat='server' visible='false'>
						<asp:TextBox id='txtPost_content' runat='server' TextMode="MultiLine" rows='3' placeholder='O que vc quer dizer?'></asp:TextBox><br />
						<asp:button id='btnPost' runat='server' text='postar' onclick='btnPost_Click'></asp:button>
					</div>
					<div id='posts_wrapper' runat='server'>
						<!--<div class='post'>-->
						<!--<h4>'alguem' postou em 'data' 'hora'</h4>-->
						<!--<p>'corpo do post'</p>-->
						<!--<div class='comments_wrapper'>-->
						<!--<div class='comments_container'>-->
						<!--<img />-->
						<!--<h6></h6>-->
						<!--<p></p>-->
						<!--</div>-->
						<!--</div>-->
						<!--<a href='post.aspx?p=post_id'>Ver o post inteiro</a>-->
						<!--<hr />-->
						<!--</div>-->
					</div>
					<asp:button id='btnShowMore' runat='server' style='display:none' onclick='ShowMore'></asp:button>
				</article>
			</div>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
			<!--<script type='text/javascript' src='script/autoShowMore.js'></script> [>not working as expected<]-->
		</form>
	</body>
</html>
