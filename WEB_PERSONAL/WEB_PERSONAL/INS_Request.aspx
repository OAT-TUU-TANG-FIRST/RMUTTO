<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_Request.aspx.cs" Inherits="WEB_PERSONAL.INS_Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            font-size: medium;
        }
        .auto-style6 {
            text-align: center;
            width: 100px;
        }
        .auto-style7 {
            width: 100px;
        }
        .auto-style13 {
            width: 100px;
            height: 28px;
        }
        .auto-style15 {
            height: 28px;
        }
        .auto-style22 {
            height: 28px;
            width: 210px;
        }
        .auto-style24 {
            width: 210px;
        }
        .auto-style25 {
            height: 28px;
            width: 25px;
        }
        .auto-style26 {
            width: 25px;
        }
        .auto-style27 {
            font-size: xx-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="802px">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="master_header_under_div_left" colspan="3"><strong>
                    <asp:Label ID="Label10" runat="server" Text="บันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์" CssClass="auto-style27"></asp:Label>
                    <asp:Label ID="Label31" runat="server" CssClass="auto-style3" Text="สังกัด มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style22">
                    &nbsp;</td>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style15" colspan="3">
                    <asp:Button ID="Insert" runat="server" Height="35px" Text="เพิ่ม" Width="103px" OnClick="Insert_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Update" runat="server" Height="35px" Text="แก้ไข" Width="103px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Delete" runat="server" Height="35px" Text="ลบ" Width="103px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Send" runat="server" Height="35px" Text="ส่ง" Width="103px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style22">
                    <asp:Label ID="Label11" runat="server" Text="ประเภท:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:UpdatePanel ID="Updateddl1" runat="server">
                                    <ContentTemplate>
                    <asp:DropDownList ID="ddl1" runat="server">
                    </asp:DropDownList>
                                         </ContentTemplate>
                                </asp:UpdatePanel>
                </td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label12" runat="server" Text="ชื่อหน่วนงานที่ขอพระราชทาน:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl2" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label13" runat="server" Text="มาช่วยราชการจากที่ใด(ถ้ามี):"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl3" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label15" runat="server" Text="ชั้นเครื่องราชฯ:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:DropDownList ID="ddl4" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label16" runat="server" Text="ยศ:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl5" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label17" runat="server" Text="คำนำหน้าชื่อ:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl6" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label18" runat="server" Text="ชื่อ:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label19" runat="server" Text="นามสกุล:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label20" runat="server" Text="เพศ:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl7" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label21" runat="server" Text="วัน/เดือน/ปีเกิด:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label22" runat="server" Text="เลขประจำตัวประชาชน:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt4" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label23" runat="server" Text="วัน/เดือน/ปีที่เริ่มรับราชการ:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label24" runat="server" Text="ตำแหน่งและระดับที่เริ่มรับราชการ:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl8" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label25" runat="server" Text="ชื่อตำแหน่งปัจจุบัน:"></asp:Label>
                </td>
                <td class="auto-style24">
                    <asp:DropDownList ID="ddl9" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    <asp:Label ID="Label28" runat="server" Text="เงินเดือนปัจจุบัน:"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txt6" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">
                    &nbsp;</td>
                <td class="auto-style26">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style24">&nbsp; &nbsp;</td>
                <td class="auto-style26">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
