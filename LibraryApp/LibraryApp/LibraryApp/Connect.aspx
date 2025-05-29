<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connect.aspx.cs" Inherits="LibraryApp.Connect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Connect</title>
    <link rel="stylesheet" href="index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <asp:Label ID="lbServer" runat="server" Text="Server:"></asp:Label>
                <asp:TextBox ID="tbServer" runat="server">127.0.0.1</asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbDatabase" runat="server" Text="Database:"></asp:Label>
                <asp:TextBox ID="tbDatabase" runat="server">mnlibrary</asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbUser" runat="server" Text="User:"></asp:Label>
                <asp:TextBox ID="tbUser" runat="server">root</asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="container">
            <p>
                <asp:Label ID="lbStatus" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btConnect" runat="server" OnClick="btConnect_Click" CssClass="button" Text="Connect" />
            </p>
        </div>
    </form>
</body>
</html>
