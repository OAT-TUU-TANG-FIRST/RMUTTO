<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UploadList.aspx.cs" Inherits="WEB_PERSONAL.UploadList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/upload.png" />Upload Files</div>
        <asp:Panel ID="PanelImage" runat="server"></asp:Panel>
        <div class="ps-separator"></div>
        <asp:Panel ID="PanelFile" runat="server"></asp:Panel>
        <div class="ps-separator"></div>
        <asp:Panel ID="PanelDrCer" runat="server"></asp:Panel>
    </div>
</asp:Content>
