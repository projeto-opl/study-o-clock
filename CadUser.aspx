<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadUser.aspx.cs" Inherits="CadUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Nome:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        Senha:<asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        <br />
        Senha Cofirmar:<asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
        <br />
        Escola:<asp:DropDownList ID="ddlSchool" runat="server">
        </asp:DropDownList>
        <br />
        Serie:<asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
        <br />
        Cidade:<asp:DropDownList ID="ddlCity" runat="server" Height="40px">
        </asp:DropDownList>
        <br />
        Telefone Celular:
        <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
        <br />
        Aniversario:<asp:DropDownList ID="ddlDay" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlMonth" runat="server">
            <asp:ListItem>Janeiro</asp:ListItem>
            <asp:ListItem>Fevereiro</asp:ListItem>
            <asp:ListItem>Março</asp:ListItem>
            <asp:ListItem>Abril</asp:ListItem>
            <asp:ListItem>Maio</asp:ListItem>
            <asp:ListItem>Junho</asp:ListItem>
            <asp:ListItem>Julho</asp:ListItem>
            <asp:ListItem>Agosto</asp:ListItem>
            <asp:ListItem>Setembro</asp:ListItem>
            <asp:ListItem>Outubro</asp:ListItem>
            <asp:ListItem>Novembro</asp:ListItem>
            <asp:ListItem>Dezembro </asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlYear" runat="server">
            <asp:ListItem>2016</asp:ListItem>
            <asp:ListItem>2015</asp:ListItem>
            <asp:ListItem>2014</asp:ListItem>
            <asp:ListItem>2013</asp:ListItem>
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2011</asp:ListItem>
            <asp:ListItem>2010</asp:ListItem>
            <asp:ListItem>2009</asp:ListItem>
            <asp:ListItem>2008</asp:ListItem>
            <asp:ListItem>2007</asp:ListItem>
            <asp:ListItem>2006</asp:ListItem>
            <asp:ListItem>2005</asp:ListItem>
            <asp:ListItem>2004</asp:ListItem>
            <asp:ListItem>2003</asp:ListItem>
            <asp:ListItem>2002</asp:ListItem>
            <asp:ListItem>2001</asp:ListItem>
            <asp:ListItem>2000</asp:ListItem>
            <asp:ListItem>1999</asp:ListItem>
            <asp:ListItem>1998</asp:ListItem>
            <asp:ListItem>1997</asp:ListItem>
            <asp:ListItem>1996</asp:ListItem>
            <asp:ListItem>1995</asp:ListItem>
            <asp:ListItem>1994</asp:ListItem>
            <asp:ListItem>1993</asp:ListItem>
            <asp:ListItem>1992</asp:ListItem>
            <asp:ListItem>1991</asp:ListItem>
            <asp:ListItem>1990</asp:ListItem>
            <asp:ListItem>1989</asp:ListItem>
            <asp:ListItem>1988</asp:ListItem>
            <asp:ListItem>1987</asp:ListItem>
            <asp:ListItem>1986</asp:ListItem>
            <asp:ListItem>1985</asp:ListItem>
            <asp:ListItem>1984</asp:ListItem>
            <asp:ListItem>1983</asp:ListItem>
            <asp:ListItem>1982</asp:ListItem>
            <asp:ListItem>1981</asp:ListItem>
            <asp:ListItem>1980</asp:ListItem>
            <asp:ListItem>1979</asp:ListItem>
            <asp:ListItem>1978</asp:ListItem>
            <asp:ListItem>1977</asp:ListItem>
            <asp:ListItem>1976</asp:ListItem>
            <asp:ListItem>1975</asp:ListItem>
            <asp:ListItem>1974</asp:ListItem>
            <asp:ListItem>1973</asp:ListItem>
            <asp:ListItem>1972</asp:ListItem>
            <asp:ListItem>1971</asp:ListItem>
            <asp:ListItem>1970</asp:ListItem>
            <asp:ListItem>1969</asp:ListItem>
            <asp:ListItem>1968</asp:ListItem>
            <asp:ListItem>1967</asp:ListItem>
            <asp:ListItem>1966</asp:ListItem>
            <asp:ListItem>1965</asp:ListItem>
            <asp:ListItem>1964</asp:ListItem>
            <asp:ListItem>1963</asp:ListItem>
            <asp:ListItem>1962</asp:ListItem>
            <asp:ListItem>1961</asp:ListItem>
            <asp:ListItem>1960</asp:ListItem>
            <asp:ListItem>1959</asp:ListItem>
            <asp:ListItem>1958</asp:ListItem>
            <asp:ListItem>1957</asp:ListItem>
            <asp:ListItem>1956</asp:ListItem>
            <asp:ListItem>1955</asp:ListItem>
            <asp:ListItem>1954</asp:ListItem>
            <asp:ListItem>1953</asp:ListItem>
            <asp:ListItem>1952</asp:ListItem>
            <asp:ListItem>1951</asp:ListItem>
            <asp:ListItem>1950</asp:ListItem>
            <asp:ListItem>1949</asp:ListItem>
            <asp:ListItem>1948</asp:ListItem>
            <asp:ListItem>1947</asp:ListItem>
            <asp:ListItem>1946</asp:ListItem>
            <asp:ListItem>1945</asp:ListItem>
            <asp:ListItem>1944</asp:ListItem>
            <asp:ListItem>1943</asp:ListItem>
            <asp:ListItem>1942</asp:ListItem>
            <asp:ListItem>1941</asp:ListItem>
            <asp:ListItem>1940</asp:ListItem>
            <asp:ListItem>1939</asp:ListItem>
            <asp:ListItem>1938</asp:ListItem>
            <asp:ListItem>1937</asp:ListItem>
            <asp:ListItem>1936</asp:ListItem>
            <asp:ListItem>1935</asp:ListItem>
            <asp:ListItem>1934</asp:ListItem>
            <asp:ListItem>1933</asp:ListItem>
            <asp:ListItem>1932</asp:ListItem>
            <asp:ListItem>1931</asp:ListItem>
            <asp:ListItem>1930</asp:ListItem>
            <asp:ListItem>1929</asp:ListItem>
            <asp:ListItem>1928</asp:ListItem>
            <asp:ListItem>1927</asp:ListItem>
            <asp:ListItem>1926</asp:ListItem>
            <asp:ListItem>1925</asp:ListItem>
            <asp:ListItem>1924</asp:ListItem>
            <asp:ListItem>1923</asp:ListItem>
            <asp:ListItem>1922</asp:ListItem>
            <asp:ListItem>1921</asp:ListItem>
            <asp:ListItem>1920</asp:ListItem>
            <asp:ListItem>1919</asp:ListItem>
            <asp:ListItem>1918</asp:ListItem>
            <asp:ListItem>1917</asp:ListItem>
            <asp:ListItem>1916</asp:ListItem>
            <asp:ListItem>1915</asp:ListItem>
            <asp:ListItem>1914</asp:ListItem>
            <asp:ListItem>1913</asp:ListItem>
            <asp:ListItem>1912</asp:ListItem>
            <asp:ListItem>1911</asp:ListItem>
            <asp:ListItem>1910</asp:ListItem>
            <asp:ListItem>1909</asp:ListItem>
            <asp:ListItem>1908</asp:ListItem>
            <asp:ListItem>1907</asp:ListItem>
            <asp:ListItem>1906</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnCad" runat="server" OnClick="btnCad_Click" Text="Button" Width="115px" Height="26px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    </form>
    <p>

        &nbsp;
    </p>
</body>
</html>
