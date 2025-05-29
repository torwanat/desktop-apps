<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailForm.aspx.cs" Inherits="MailForm.MailForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbFrom" runat="server" Text="From"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="tbFrom" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lbTo" runat="server" Text="To"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbTo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbSubject" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbText" runat="server" Text="Text"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbText" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbServer" runat="server" Text="Server SMTP"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbServer" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RadioButtonList ID="rblModes" runat="server" OnSelectedIndexChanged="rblMeasurementSystem_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Text="Local SMTP" Value="local" />
                            <asp:ListItem Text="Auth. SMTP" Value="auth" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbPort" runat="server" Text="Port"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbPort" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbUser" runat="server" Text="User"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbUser" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="tbPassword" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btSend" runat="server" Text="Send" OnClick="btSend_Click" Enabled="False" />
                        <br />
                        <asp:Label ID="lbInfo1" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lbAttachments" runat="server" Text="Attachments"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:FileUpload ID="fuUpload" runat="server" />
                        <br />
                        <br />
                        <asp:ListBox ID="lxAttachments" runat="server" Width="300px"></asp:ListBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lbInfo2" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
