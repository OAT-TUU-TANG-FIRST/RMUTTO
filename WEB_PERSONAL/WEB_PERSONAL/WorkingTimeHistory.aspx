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
                    <td>วันที่</td>
                    <td>
                        <asp:TextBox ID="tbDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbuSearch" runat="server" CssClass="ps-button" OnClick="lbuSearch_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                    </td>
                </tr>
            </table>
             
            
            
        </div>
        <div class="ps-separator"></div>
        <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview"></asp:GridView>
        <div class="ps-separator"></div>
    </div>
</asp:Content>
