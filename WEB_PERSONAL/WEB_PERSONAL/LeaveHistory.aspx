<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="WEB_PERSONAL.LeaveHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่อยู่ระหว่างการดำเนินงาน</div>
    <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview"></asp:GridView>

    <div class="ps-separator"></div>

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่เสร็จ</div>
    <asp:GridView ID="GridView3" runat="server" CssClass="ps-gridview"></asp:GridView>

    <div class="ps-separator"></div>

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่ผ่าน / ไม่ผ่านการอนุมัติ</div>
    <asp:GridView ID="GridView2" runat="server" CssClass="ps-gridview"></asp:GridView>

    <div class="ps-separator"></div>
    
</asp:Content>
