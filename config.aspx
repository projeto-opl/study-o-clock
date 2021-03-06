﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="config" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Configurações</title>
		<link href='style/main.css' type='text/css' rel='stylesheet' />
		<link href='style/inputs.css' type='text/css' rel='stylesheet' />
		<link href='style/configPage.css' type='text/css' rel='stylesheet' />

		<script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
	</head>
	<body>
		<form id="form1" runat="server">
			<nav><!--{{{-->
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
			</nav><!--}}}-->

			<div class='content'>
				<article id='config_container'>
					<!--edit img-->
					<div id='img-config'>
						<div class='profile_img_wrapper wrapper_size'>
							<img id='profile_img' runat='server' src='images/userProfile/profile-picture-placeholder.png' />
						</div>
						<asp:FileUpload ID="picture_change" accept='image/*' OnChange="readURL(this, '#profile_img');" runat="server" />
						<input id='profile_change_view' type='button' value='Carregar Imagem' Onclick='document.getElementById("picture_change").click();' />
						<br />
					</div>

					<div id='text-config'>
						<!--edit name-->
						<span class='config_title'>Trocar de nome:</span>
						<asp:textbox id='txtName' runat='server' placeholder='Insira um nome' /><br />

						<!--edit password-->
						<div id='password-setting'>
							<span class='config_title'>Troca de senha:</span>
							<asp:textbox id='txtPass1' type='password' runat='server' placeholder='Insira um senha' /><br />
							<asp:textbox id='txtPass2' type='password' runat='server' placeholder='Confirme sua senha' /><br />
							<asp:label id='lblPassError' runat='server'></asp:label>
						</div>
					</div>

					<div id='bio-config'>
						<!--edit bio-->
						<span class='config_title'>Trocar bio:</span>
						<asp:textbox id='txtBio' runat='server' rows='5' placeholder='Seu texto de apresentação' Textmode='multiline' /><br />
					</div>

					<!--controlbox-->
					<hr />
					<div class='controlBox'>
						<asp:Button id='btnSave' runat='server' text='Salvar' onclick='btnSave_Click'/>
						<input type='button' value='Cancelar' onclick='window.location="<%=FileName.Profile%>"' />
					</div>
				</article>
			</div>
			<script src='script/UpdadeImgOnUpload.js' type='text/javascript'></script>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
