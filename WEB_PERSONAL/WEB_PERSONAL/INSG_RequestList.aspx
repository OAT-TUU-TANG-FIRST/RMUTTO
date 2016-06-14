<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_RequestList.aspx.cs" Inherits="WEB_PERSONAL.INSG_RequestList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/medal.png" />รายชื่อ บุคลากรที่ขอเครื่องราชฯ</div>
        <asp:Table ID="Table1" runat="server" CssClass="ps-ins-table"></asp:Table>
                <div class="ps-separator"></div>
                <div>
                    <asp:LinkButton ID="lbuPrint" runat="server" CssClass="ps-button" OnClick="lbuPrint_Click"><img src="Image/Small/printer.png" class="icon_left"/>พิมพ์</asp:LinkButton>
                    <asp:LinkButton ID="lbuAccept" runat="server" CssClass="ps-button" OnClick="lbuAccept_Click"><img src="Image/Small/correct.png" class="icon_left"/>รับเรื่อง</asp:LinkButton>
                </div>   
        <div class="ps-separator"></div>
        
    </div>
</asp:Content>
