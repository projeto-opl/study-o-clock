<%@ Page Title="" Language="C#" MasterPageFile="~/nav.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
<article id='post_container' runat='server'>
	<h5>
		<asp:label id='post_title' runat='server'></asp:label>
	</h5>
	<p id='post_content' runat='server'></p>
	<hr />
	<div class='multiline-submit'>
		<asp:TextBox id='txtComment_content' runat='server' TextMode="MultiLine" rows='3' placeholder='O que vc quer dizer?'></asp:TextBox><br />
		<asp:button id='btnComment' runat='server' text='postar' onclick='btnComment_click'></asp:button>
	</div>
</article>
<div id='comments_container' runat='server'>
</div>
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
</asp:Content>

