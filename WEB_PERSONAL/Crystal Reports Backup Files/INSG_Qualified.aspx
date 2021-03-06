﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Qualified.aspx.cs" Inherits="WEB_PERSONAL.INSG_Qualified" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/medal.png" />รายชื่อผู้มีสิทธิได้รับเครื่องราชฯ</div>
        <div>
            <table class="ps-table">
                <tr>
                    <td class="col1">ปี</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเภทบุคลากร</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlStaffType" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="col1">วิทยาเขต</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlCampus" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สำนัก / สถาบัน / คณะ</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="col1"></td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuSearch" runat="server" CssClass="ps-button" OnClick="lbuSearch_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ps-separator"></div>
        <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview"></asp:GridView>

    </div>
</asp:Content>
