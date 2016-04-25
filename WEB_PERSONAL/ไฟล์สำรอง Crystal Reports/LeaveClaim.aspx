<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveClaim.aspx.cs" Inherits="WEB_PERSONAL.LeaveClaim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header"><img src="Image/Small/table.png" />สิทธิในการลา</div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <table>
            <tr>
                <td class="col1">
                    ลากิจส่วนตัว
                </td>
                <td class="col2">
                    <asp:Label ID="lbKij" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="col1">
                    ลาพักผ่อน
                </td>
                <td class="col2">
                    <asp:Label ID="lbRest" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="col1">
                    ลาอุปสมบท / พิธีฮัจย์
                </td>
                <td class="col2">
                    <asp:Label ID="lbOrdain" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
