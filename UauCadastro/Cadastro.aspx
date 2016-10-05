<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <center> Nome:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
           <asp:Label ID="lblName" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        E-mail:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
           <asp:Label ID="lblMail" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Confirmar e-mail:
        <asp:TextBox ID="txtConf" runat="server"></asp:TextBox>
           <asp:Label ID="lblConfMail" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Senha:
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
           <asp:Label ID="lblPass" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Confirmar senha:
        <asp:TextBox ID="txtConfPass" runat="server"></asp:TextBox>
           <asp:Label ID="lblConfPass" runat="server" ForeColor="Red"></asp:Label>
           <br />
           <asp:SqlDataSource ID="SqlRinf" runat="server" ConnectionString="<%$ ConnectionStrings:rinfConnectionString %>" InsertCommand="INSERT INTO users(name, pass, email) VALUES (@Name, @Pass, @Email)" ProviderName="<%$ ConnectionStrings:rinfConnectionString.ProviderName %>" SelectCommand="SELECT * FROM users">
               <InsertParameters>
                   <asp:ControlParameter ControlID="txtName" Name="Name" PropertyName="Text" />
                   <asp:ControlParameter ControlID="txtPass" Name="Pass" PropertyName="Text" />
                   <asp:ControlParameter ControlID="txtEmail" Name="Email" PropertyName="Text" />
               </InsertParameters>
           </asp:SqlDataSource>
        <br />
           <asp:Label ID="lblDif" runat="server" ForeColor="Red"></asp:Label>
           <br />
        <br />
        <asp:Button ID="btnReg" runat="server" Text="Cadastrar" OnClick="btnReg_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Voltar" /></center>
    
    </div>
    </form>
</body>
</html>
