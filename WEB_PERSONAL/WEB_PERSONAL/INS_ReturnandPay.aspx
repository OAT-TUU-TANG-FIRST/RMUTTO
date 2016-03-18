<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_ReturnandPay.aspx.cs" Inherits="WEB_PERSONAL.INS_ReturnandPay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 84px;
        }
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style3 {
            width: 84px;
            height: 28px;
        }
        .auto-style4 {
            height: 28px;
        }
        .auto-style11 {
            width: 120px;
        }
        .auto-style12 {
            width: 120px;
            height: 28px;
        }
        .auto-style13 {
            width: 120px;
            text-align: right;
        }
        .auto-style16 {
            width: 270px;
        }
        .auto-style17 {
            width: 271px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="1800px">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="master_header_under_div_left" colspan="4"><strong>
                    <asp:Label ID="Label10" runat="server" CssClass="auto-style2" Text="หลักฐานการส่งคืน/ชดใช้ราคาเครื่องราชอิสริยาภรณ์"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style12"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4" colspan="4">
                    <asp:Button ID="insert0" runat="server" Height="30px" Text="เพิ่ม" Width="93px" />
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="update0" runat="server" Height="30px" Text="แก้ไข" Width="93px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="delete0" runat="server" Height="30px" Text="ลบ" Width="93px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Send" runat="server" Height="35px" Text="ส่ง" Width="103px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style13">
                    <asp:Label ID="Label11" runat="server" Text="วัน/เดือน/ปี"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style13">
                    <asp:Label ID="Label12" runat="server" Text="ชื่อ-สกุล"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style13">
                    <asp:Label ID="Label13" runat="server" Text="ตำแหน่ง"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style13">
                    <asp:Label ID="Label14" runat="server" Text="สังกัด/กอง/คณะ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    <asp:Label ID="Label15" runat="server" Text="ขอส่งคืน/ชดใช้ราคาเครื่องราชอิสริยาภรณ์ เนื่องจาก"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="ได้รับชั้นสูงกว่า" />
                    &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="ถึงแก่กรรม" />
                    &nbsp;
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="อื่น ๆ" />
                    &nbsp;<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label16" runat="server" Text="ดังนี้"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    &nbsp;&nbsp;&nbsp;<asp:Panel ID="Panel2" runat="server" Height="170px">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="Label17" runat="server" Text="ชั้นเครื่องราชอิสริยาภรณ์"></asp:Label>
                                </td>
                                <td class="auto-style17">
                                    <asp:Label ID="Label18" runat="server" Text="ส่งคืนเครื่องราชอิวริยาภรณ์"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="ชดใช้ราคาแทน"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style17">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style17">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
