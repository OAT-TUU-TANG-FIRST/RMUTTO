<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkingTimeHistory.aspx.cs" Inherits="WEB_PERSONAL.WorkingTimeHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbDate").datepicker($.datepicker.regional["th"]);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/table.png" />ประวัติเวลาปฏิบัติงาน</div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbuShowAll" runat="server" CssClass="ps-button" OnClick="lbuShowAll_Click"><img src="Image/Small/search.png" class="icon_left"/>แสดงทั้งหมด</asp:LinkButton>
                        <asp:LinkButton ID="lbuShowLateIn" runat="server" CssClass="ps-button" OnClick="lbuShowLateIn_Click"><img src="Image/Small/search.png" class="icon_left"/>แสดงสาย</asp:LinkButton>
                        <asp:LinkButton ID="lbuShowLateOut" runat="server" CssClass="ps-button" OnClick="lbuShowLateOut_Click"><img src="Image/Small/search.png" class="icon_left"/>แสดงออกก่อน</asp:LinkButton>
                        <asp:LinkButton ID="lbuShowAbsent" runat="server" CssClass="ps-button" OnClick="lbuShowAbsent_Click"><img src="Image/Small/search.png" class="icon_left"/>แสดงขาด</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" placeHolder="รหัสพนักงาน"></asp:TextBox>
                        <asp:LinkButton ID="lbuSearchCitizenID" runat="server" CssClass="ps-button" OnClick="lbuSearchCitizenID_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาตามรหัสพนักงาน</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlKa" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:LinkButton ID="lbuSearchKa" runat="server" CssClass="ps-button" OnClick="lbuSearchKa_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาตามกะ</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbDate" runat="server" CssClass="ps-textbox" placeHolder="วันที่"></asp:TextBox>
                        <asp:LinkButton ID="lbuSearchDate" runat="server" CssClass="ps-button" OnClick="lbuSearchDate_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาตามวัน</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="default_separator"></div>
        <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview"></asp:GridView>
        <div class="default_separator"></div>
    </div>
</asp:Content>
