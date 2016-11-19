<%@ Page Language="C#" MasterPageFile='~/nav.master' AutoEventWireup="true" CodeFile="pesq.aspx.cs" Inherits="pesq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Resultado da Pesquisa</title>
<link type='text/css' rel='stylesheet' href='style/pesq.css' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
<article>
	<div id='results_container' runat='server'>
	</div>
</article>
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
</asp:Content>
