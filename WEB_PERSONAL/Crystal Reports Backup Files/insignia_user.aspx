<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="insignia_user.aspx.cs" Inherits="WEB_PERSONAL.insignia_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            height: 367px;
        }
        .auto-style3 {
            width: 687px;
            height: 221px;
        }
        .auto-style4 {
            width: 147px;
        }
        .auto-style6 {
            width: 147px;
            height: 58px;
        }
        .auto-style7 {
            width: 100%;
            height: 210px;
        }
        .auto-style8 {
            width: 109px;
        }
        .auto-style9 {
            width: 109px;
            height: 57px;
        }
        .auto-style10 {
            height: 57px;
        }
        .auto-style11 {
            height: 58px;
        }
        .auto-style12 {
            width: 109px;
            height: 45px;
        }
        .auto-style13 {
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel8" runat="server" Height="984px">
        <table class="auto-style2">
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style6"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td><fieldset style="300px" class="auto-style3">
                    <legend><b>สำหรับผู้ใช้งานทั่วไป</b></legend>
                    <table class="auto-style7">
                        <tr>
                            <td class="auto-style12"></td>
                            <td class="auto-style13"></td>
                            <td class="auto-style13"></td>
                        </tr>
                        <tr>
                            <td class="auto-style9"></td>
                            <td class="auto-style10">
                                <asp:Button ID="Button1" runat="server" Height="46px" Text="1. ใบบันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์" Width="443px" CommandName="ทดสอบๆ" OnClick="Button1_Click" />
                            </td>
                            <td class="auto-style10"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Height="46px" Text="2. ใบบันทึกประวัติการรับเครื่องราชอิสริยาภรณ์" Width="443px" OnClick="Button2_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
