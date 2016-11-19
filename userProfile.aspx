<%@ Page Language="C#" MasterPageFile='~/nav.master' AutoEventWireup="true" CodeFile="userProfile.aspx.cs" Inherits="userProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title><%=CurUser["name"]%></title>
<link type='text/css' rel='stylesheet' href='style/userProfile.css' />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
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
<div id='posts_container'>
	<div id='post_control' runat='server' visible='false'>
		<asp:TextBox id='txtPost_content' runat='server' TextMode="MultiLine" rows='3' placeholder='O que vc quer dizer?'></asp:TextBox><br />
		<asp:button id='btnPost' runat='server' text='postar' onclick='btnPost_Click'></asp:button>
	</div>
	<div id='posts_wrapper' runat='server'>
	</div>
	<asp:button id='btnShowMore' runat='server' style='display:none' onclick='ShowMore'></asp:button>
</div>
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
<!--<script type='text/javascript' src='script/autoShowMore.js'></script> [>not working as expected<]-->
</asp:Content>
