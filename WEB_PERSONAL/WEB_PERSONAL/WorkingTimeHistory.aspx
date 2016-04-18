<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkingTimeHistory.aspx.cs" Inherits="WEB_PERSONAL.WorkingTimeHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header"><img src="Image/Small/table.png" />ประวัติเวลาปฏิบัติงาน</div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>
