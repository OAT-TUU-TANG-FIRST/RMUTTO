<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WEB_PERSONAL.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header">เปลี่ยนรหัสผ่าน</div>
        <table class="default_table">
            <tr>
                <td class="col1">รหัสผ่านเก่า</td>
                <td class="col2">
                    <asp:TextBox ID="tbOld" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col1">รหัสผ่านใหม่</td>
                <td class="col2">
                    <asp:TextBox ID="tbNew" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col1">ยืนยันรหัสผ่านใหม่</td>
                <td class="col2">
                    <asp:TextBox ID="tbNew2" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="col1"></td>
                <td class="col2">
                    <asp:LinkButton ID="lbuFinish" runat="server" CssClass="button button_default" OnClick="lbuFinish_Click">เปลี่ยนรหัสผ่าน</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
