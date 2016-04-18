<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UploadList.aspx.cs" Inherits="WEB_PERSONAL.UploadList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header">Upload Files</div>
        <asp:Panel ID="PanelImage" runat="server"></asp:Panel>
        <div style="display: block; margin: 20px 0; border-bottom: 1px solid #c0c0c0;"></div>
        <asp:Panel ID="PanelFile" runat="server"></asp:Panel>
    </div>
</asp:Content>
