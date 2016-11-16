<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupMarc.aspx.cs" Inherits="Group" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>

				Nome do grupo:
				<asp:Label ID="lblGroup" runat="server"></asp:Label>
				&nbsp;<asp:TextBox ID="txtEdit" runat="server" Visible="False"></asp:TextBox>
				<br />
				<asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Editar" />
				<br />
				Membros do grupo:
				<asp:Button ID="btnMembros" runat="server" OnClick="btnMembros_Click" />

				<br />
				<asp:SqlDataSource ID="sqlds1" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [groups]">
				</asp:SqlDataSource>

			</div>
		</form>
	</body>
</html>
