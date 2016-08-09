<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Custom-Person.aspx.cs" Inherits="WEB_PERSONAL.Report_Custom_Person" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .divpan {
            text-align: center;
        }

        .textred {
            color: red;
        }

        .auto-style1 {
            border-collapse: collapse;
            box-shadow: rgba(0,0,0,0.2) 0px 1px 4px;
            width: 348px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/report.png" />ออกรายงาน ก.พ.7
        </div>
        <div id="notification" runat="server"></div>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div id="div1" runat="server" style="text-align: center;">
            <div class="ps-div-title-red">
                <img src="Image/Small/search.png" style="margin-right:10px" />ค้นหาข้อมูล
            </div>
            <div class="ps-separator"></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" DefaultButton="lbuSearch">
        <div id="div2" runat="server" style="text-align: center;">
            <div style="display: inline-block; margin-right: 20px;">
                <table>
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสบัตรประชาชน 13 หลัก :</td>
                        <td style="text-align: left; width: 120px;">
                            <asp:TextBox ID="txtSearchCitizenID" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="13"></asp:TextBox></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ps-separator"></div>
    </asp:Panel>
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" ToolPanelView="None" />
    </div>
</asp:Content>