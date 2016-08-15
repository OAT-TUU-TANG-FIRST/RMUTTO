<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Person-Quit.aspx.cs" Inherits="WEB_PERSONAL.Report_Person_Quit" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .col1 {
            text-align: right;
        }
        .col2 {
            text-align: left;
        }
        .textred{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/report.png" />ออกรายงานการลาออกบุคลากร
        </div>
        <div id="notification" runat="server"></div>

        <div style="text-align: center">
            <div class="ps-div-title-red" style="margin-top: 10px;">เลือกเงื่อนไข การออกรายงาน</div>
            <div style="text-align: left; display: inline-block">
                <table class="ps-table-1">
                    <tr>
                        <td class="col1">เดือน</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ปี</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="margin-top:12px">
                    <asp:LinkButton ID="lbuSearchAll" runat="server" OnClick="lbuSearchAll_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาทั้งหมด</asp:LinkButton>
                    <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                </div>

            </div>
            <div class="ps-separator"></div>
        </div>
        <div>
            <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>ออกรายงาน Excel</asp:LinkButton>
        </div>
        <div style="overflow-x:auto; width:auto">
            <asp:Table ID="tb" runat="server" CssClass="ps-table-1" Style="margin-top: 10px;"></asp:Table>
        </div>

    </div>
</asp:Content>
