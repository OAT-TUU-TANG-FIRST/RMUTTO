<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_RequestList.aspx.cs" Inherits="WEB_PERSONAL.INSG_RequestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/medal.png" />รายชื่อการขอเครื่องราช</div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview"></asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="ps-table">
                    <tr>
                        <td class="head" colspan="2">ข้อมูลการขอเครื่องราช</td>
                    </tr>
                    <tr>
                        <td class="col1">ขอวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbReqDate" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อผู้ขอ</td>
                        <td class="col2">
                            <asp:Label ID="lbCitizenName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เครื่องราช</td>
                        <td class="col2">
                            <asp:Label ID="lbInsignia" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สถานะ</td>
                        <td class="col2">
                            <asp:Label ID="lbState" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="ps-separator"></div>
                <div>
                    <asp:LinkButton ID="lbuBack" runat="server" CssClass="ps-button" OnClick="lbuBack_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuPrint" runat="server" CssClass="ps-button"><img src="Image/Small/printer.png" class="icon_left"/>พิมพ์</asp:LinkButton>
                    <asp:LinkButton ID="lbuAccept" runat="server" CssClass="ps-button"><img src="Image/Small/correct.png" class="icon_left"/>รับเรื่อง</asp:LinkButton>
                </div>
            </asp:View>
        </asp:MultiView>
        
        <div class="ps-separator"></div>
        
    </div>
</asp:Content>
