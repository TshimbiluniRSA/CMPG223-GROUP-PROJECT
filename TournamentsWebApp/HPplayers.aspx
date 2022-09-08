<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HPplayers.aspx.cs" Inherits="Group_14_Project.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-image: url('Img/Player.png'); background-repeat: no-repeat; background-position: center top; background-color: #000000;">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 212px;
            text-align: center;
        }
        .auto-style5 {
            width: 667px;
            text-align: right;
        }
        .auto-style6 {
            width: 667px;
            height: 55px;
        }
        .auto-style8 {
            height: 55px;
        }
        .auto-style9 {
            font-weight: bold;
        }
        .auto-style10 {
            width: 212px;
            text-align: left;
        }
        .auto-style11 {
            width: 212px;
            height: 55px;
        }
        .auto-style12 {
            color: #FFFFFF;
        }
        .auto-style14 {
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style17 {
            text-align: center;
            height: 1005px;
            width: 1504px;
        }
        .auto-style19 {
            width: 296px;
        }
        .auto-style20 {
            width: 793px;
        }
        .auto-style21 {
            width: 1111px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style17" style="background-image: url('PC EXCLUSIVES4.png'); background-repeat: no-repeat;">
            <strong>
            <br />
            <br />
            <br />
            <br />
            <br />
            </strong>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style21">
                        <br />
            <strong>
                        <br />
                    <asp:Button ID="btnJoin" runat="server" CssClass="auto-style9" Text="Join Team" BackColor="Red" BorderColor="White" BorderStyle="Double" ForeColor="White" Height="47px" OnClick="btnJoin_Click" Width="207px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEdit" runat="server" CssClass="auto-style9" Text="Edit Info" BackColor="Red" BorderColor="White" BorderStyle="Double" ForeColor="White" Height="48px" OnClick="btnEdit_Click" Width="206px" />
            </strong></td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style21">
                        <br />
                        <br />
                        <br />
            <strong>
                    <asp:Button ID="btnLogOut" runat="server" CssClass="auto-style9" Text="Log Out" BackColor="White" BorderColor="White" BorderStyle="Double" ForeColor="Black" Height="40px" OnClick="btnLogOut_Click" Width="222px" />
            </strong>
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                </tr>
            </table>
        </div>
        <p class="auto-style2">
            <br />
        </p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">
                </td>
                <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <span class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"></td>
                <td class="auto-style11"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style3"> &nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp; </td>
            </tr>
        </table>
    <p class="auto-style14">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p class="auto-style14">
            &nbsp;</p>
    </form>
    </body>
</html>
