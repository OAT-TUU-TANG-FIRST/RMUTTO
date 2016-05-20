<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeavePermission.aspx.cs" Inherits="WEB_PERSONAL.LeavePermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c1 {
            margin: 10px 0px;
            color: #808080;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header"><img src="Image/Small/info.png" />สิทธิการอนุญาตการลา</div>
        <p class="c1">
            การลาของข้าราชการพลเรือนในสถาบันอุดมศึกษา ตามระเบียบสำนักนายกรัฐมนตรีว่าด้วยการลาของข้าราชการ พ.ศ. ๒๕๕๕
        </p>
        <asp:Table ID="Table1" runat="server" CssClass="ps-gridview">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="2">วันอนุญาตครั้งหนึ่งไม่เกิน</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="4"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ระดับ</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลาป่วย</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลากิจ</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลาคลอดบุตร</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลาไปช่วยเหลือภริยาที่คลอดบุตร</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลาพักผ่อน</asp:TableHeaderCell>
                <asp:TableHeaderCell>ลาไปอุปสมบทหรือประกอบพิธีฮัจย์</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        
        <div class="ps-separator"></div>
    </div>
</asp:Content>
