<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="GuestBook.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inscriptions</title>
    <link rel="stylesheet" href="view.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="table">
            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/book.xml" TransformSource="~/book.xslt"></asp:Xml>
        </div>
        <div class="back">
            <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="~/GuestForm.aspx">Powrót</asp:HyperLink>
        </div>
    </form>
</body>
</html>
