<%@ Page Language="C#" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="config" %>

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
			<asp:Button id='btnLogout' runat='server' text='logout' Onclick='logout' />

			<div id='config_container'>
				<div class='profile_img_wrapper wrapper_size'>
					<img id='profile_img' runat='server' src='images/userProfile/profile-picture-placeholder.png' />
				</div>
				<asp:FileUpload ID="picture_change" accept='image/*' OnChange="readURL(this, '#profile_img');" runat="server" />
				<input id='profile_change_view' type='button' value='Carregar Imagem' Onclick='document.getElementById("picture_change").click();' />

				<div class='controlBox'>
					<br />
					<asp:Button id='btnSave' runat='server' text='Salvar' onclick='btnSave_Click'/>
					<input type='button' value='Cancelar' onclick='window.location="<%=FileName.Profile%>"' />
				</div>
			</div>
			<script src='script/UpdadeImgOnUpload.js' type='text/javascript'></script>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
