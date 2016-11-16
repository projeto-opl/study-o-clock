<%@ Page Title="" Language="C#" MasterPageFile="~/nav.master" AutoEventWireup="true" CodeFile="userGroups.aspx.cs" Inherits="userGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type='text/css' rel='stylesheet' href='style/userFriends.css' />
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
<article>
	<div class="tituloamigos">
		<h5>Grupos que <%=CurUser["name"]%> participa (<%=FriendsQtd%>)</h5>
		<hr />
	</div>
	<div class="friends" id='friends_facename' runat='server'>
	</div>
</article>
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
</asp:Content>
