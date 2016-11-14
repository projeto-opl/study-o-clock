﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pesq.aspx.cs" Inherits="pesq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Resultado da Pesquisa</title>
		<link type='text/css' rel='stylesheet' href='style/main.css' />
	</head>
	<body>
		<form id="form1" runat="server">
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
