<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="LibraryApp.View" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Library</title>
    <link rel="stylesheet" href="index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div id="controls">
                <asp:Button ID="btAddBook" runat="server" OnClick="btAddBook_Click" Text="Add" CssClass="button" />
                <asp:Button runat="server" Text="Search" ID="btSearch" OnClick="btSearch_Click" CssClass="button" ></asp:Button>
                <asp:Button runat="server" Text="Show all" ID="btShowAll" OnClick="btShowAll_Click" CssClass="button" ></asp:Button>
                <asp:Button runat="server" Text="Log out" ID="btLogout" CssClass="button" OnClick="btLogout_Click"></asp:Button>
            </div>
            <asp:GridView ID="gvBooks" runat="server" CssClass="table">
                <Columns >
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button CssClass="button" ID="btDelete" runat="server" Text="Delete" CausesValidation="false" CommandName="deleteBook" OnCommand="deleteBook" CommandArgument='<%# Eval("Id") %>' />
                            <asp:Button CssClass="button" ID="btEdit" runat="server" Text="Edit" CausesValidation="false" CommandName="editBook" OnCommand="editBook" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lbInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
