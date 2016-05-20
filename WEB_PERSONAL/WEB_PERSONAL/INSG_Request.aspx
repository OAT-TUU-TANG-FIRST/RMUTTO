<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Request.aspx.cs" Inherits="WEB_PERSONAL.INSG_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/medal.png" />ขอเครื่องราช</div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div>
                    รายชื่อเครื่องราช
                    <asp:DropDownList ID="ddlInsg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInsg_SelectedIndexChanged" CssClass="ps-dropdown"></asp:DropDownList>
                </div>
                <div class="ps-separator"></div>
                <div id="srd" runat="server">
                </div>
                <div style="height: 20px;"></div>
                <asp:LinkButton ID="lbuWant" runat="server" CssClass="ps-button" Visible="false" OnClick="lbuWant_Click"><img src="Image/Small/medal.png" class="icon_left"/>ขอเครื่องราช</asp:LinkButton>
            </asp:View>
            <asp:View ID="View2" runat="server">

            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>
