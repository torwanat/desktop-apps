<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
    <link rel="stylesheet" href="index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div>
                    <asp:Label ID="lbLogin" runat="server" Text="Login:"></asp:Label>
                    <asp:TextBox ID="tbLogin" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lbEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="tbEmail" TextMode="Email" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label>
                    <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="container">

                <asp:Button ID="btRegister" runat="server" Text="Register" OnClick="btRegister_Click" CssClass="button" />
                <br />
                <asp:Button ID="btBack" runat="server" Text="Back" CssClass="button" OnClick="btBack_Click" />
                <asp:Label ID="lbInfo" runat="server"></asp:Label>

            </div>
        </div>
    </form>
</body>
</html>
