<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_borrow.aspx.cs" Inherits="WEB_PERSONAL.INS_borrow" %>
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
        .auto-style6 {
            width: 150px;
            height: 28px;
        }
        .auto-style7 {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="1800px">
         <fieldset>
            <legend><font ><B>บันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์</B></font></legend>

        <table style="width:100%;">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="master_header_under_div_left" colspan="4"><strong>
                    <asp:Label ID="Label10" runat="server" CssClass="auto-style2" Text="แบบคำขอยืมเครื่องราชอิสริยาภรณ์"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style6"></td>
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
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label11" runat="server" Text="วัน/เดือน/ปีที่ขอยืม"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style7">
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
                <td class="auto-style7">
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
                <td class="auto-style7">
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
                    <asp:Label ID="Label15" runat="server" Text="ชั้น"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="บุรุษ" />
                    &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="สตรี" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label30" runat="server" Text="จำนวน"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label31" runat="server" Text="สำรับ"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label33" runat="server" Text="ดวง"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label16" runat="server" Text="เพื่อ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Height="93px" TextMode="MultiLine" Width="202px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    <asp:Label ID="Label18" runat="server" Text="รวมระยะเวลา"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label35" runat="server" Text="วัน"></asp:Label>
                    &nbsp;<asp:Label ID="Label36" runat="server" Text="และเมื่อใช้เสร็จจะนำมาส่งคืนภายในวันที่"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label19" runat="server" Text="(รวมระยะเวลไม่เกิน 7 วัน)"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
             </fieldset>
    </asp:Panel>
</asp:Content>
