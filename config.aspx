<%@ Page Language="C#" MasterPageFile="~/nav.master" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Configurações</title>
<link href='style/configPage.css' type='text/css' rel='stylesheet' />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
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
<script src='script/UpdadeImgOnUpload.js' type='text/javascript'></script>
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
</asp:Content>
