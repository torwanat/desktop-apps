<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibraryApp.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Add</title>
    <link rel="stylesheet" href="index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <asp:Label ID="lbAuthor" runat="server" Text="Author:"></asp:Label>
                <asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbTitle" runat="server" Text="Title:"></asp:Label>
                <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbRelease" runat="server" Text="Release date:"></asp:Label>
                <asp:TextBox ID="tbRelease" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbISBN" runat="server" Text="ISBN:"></asp:Label>
                <asp:TextBox ID="tbISBN" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbFormat" runat="server" Text="Format:"></asp:Label>
                <asp:TextBox ID="tbFormat" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbPages" runat="server" Text="Pages:"></asp:Label>
                <asp:TextBox ID="tbPages" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lbDescription" runat="server" Text="Description:"></asp:Label>
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="container">
            <p>
                <asp:Label ID="lbStatus" runat="server"></asp:Label>
            </p>
            <div>
                <asp:Button CssClass="button" ID="btAdd" runat="server" OnClick="btConnect_Click" Text="Add" />
                <asp:Button CssClass="button" runat="server" Text="Back" ID="btBack" OnClick="btBack_Click"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
