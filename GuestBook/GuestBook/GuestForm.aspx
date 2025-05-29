<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestForm.aspx.cs" Inherits="GuestBook.GuestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GuestForm</title>
    <link rel="stylesheet" href="index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="form-container">
                <div>
                    <asp:Label ID="lbName" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbName" ErrorMessage="Nazwa jest wymagana!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lbEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Nieprawidłowy mail!" ForeColor="#CC0000" ValidationExpression="(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*|&quot;(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*&quot;)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"></asp:RegularExpressionValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email jest wymagany!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lbInscription" runat="server" Text="Inscription:"></asp:Label>
                    <asp:TextBox ID="tbInscription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvInscirption" runat="server" ControlToValidate="tbInscription" ErrorMessage="Treść jest wymagana!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div class="summary">
                    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" />
                </div>
            </div>
            <div>
                <asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="#CC0000" />
            </div>
            <div class="users">
                <div>
                    <asp:Label ID="lbInfoUsersOnline" runat="server" Text="Użytkownicy online: "></asp:Label>
                    <asp:Label ID="lbUsersOnline" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lbInfoAllUsers" runat="server" Text="Wszyscy użytkownicy:"></asp:Label>
                    <asp:Label ID="lbUsersAll" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
