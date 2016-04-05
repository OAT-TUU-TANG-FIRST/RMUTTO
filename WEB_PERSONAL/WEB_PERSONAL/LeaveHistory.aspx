<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="WEB_PERSONAL.LeaveHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_header"><img src="Image/Small/table.png" />รายการที่รอ</div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    <div class="default_header"><img src="Image/Small/table.png" />รายการที่เสร็จ</div>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    
    <div class="default_header"><img src="Image/Small/table.png" />รายการทั้งหมด</div>
    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
    
</asp:Content>
