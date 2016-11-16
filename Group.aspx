<%@ Page Title="" Language="C#" MasterPageFile="~/nav.master" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
<div><!--'header' com img, nome, e etc do perfil {{{-->
	<div id='main-profile-pic' class='profile_img_wrapper'>
		<asp:Image id='imgProfilePicture' runat='server'/>
	</div>
	<div id='face_card'>
		<div id='card'>
			<h1>
				<asp:Label id='lblGroup' runat='server'></asp:Label>
				<asp:TextBox ID="txtEdit" runat="server" Visible="False"></asp:TextBox>
			</h1>
			<br />
			<div id='profile-controls'>
				<asp:Button ID="btnMembros" runat="server" text='Membros' OnClick="btnMembros_Click" />
				<asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Editar" Visible='false'/>
			</div>
		</div>
	</div>
</div><!--}}}-->
<asp:SqlDataSource ID="Sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>">
</asp:SqlDataSource>
</asp:Content>

