<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pesq.aspx.cs" Inherits="pesq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Resultado da Pesquisa</title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
		<link type='text/css' rel='stylesheet' href='style/inputs.css' />
		<link type='text/css' rel='stylesheet' href='style/pesq.css' />
	</head>
	<body>
		<form id="form1" runat="server">
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

			<article>
				<div id='results_container' runat='server'>
					<!--<div class='result_entry'>-->
						<!--<a href='' class='profile_img_wrapper'><img src='images/userProfile/profile-picture-placeholder.png' /></a>-->
						<!--<div class='res_text'>-->
							<!--<a href=''><h5 class='res_title'>Aqui vai o nome</h5></a>-->
							<!--<span class='res_bio'>Aqui vai aquele textinho</span>-->
						<!--</div>-->
					<!--</div>-->
				</div>
			</article>
			<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
			</asp:SqlDataSource>
		</form>
	</body>
</html>
