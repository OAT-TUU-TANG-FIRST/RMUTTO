<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Seminar-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Report_Seminar_ADMIN" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .textred {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfSEID" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/report.png" />ออกรายงานพัฒนาบุคลากร(เฉพาะเจ้าหน้าที่)
        </div>
        <div id="notification" runat="server"></div>
        <div style="margin-bottom: 20px; text-align: center">
            <div class="ps-div-title-red">
                <img src="Image/Small/search.png" class="icon_left" />ค้นหารายชื่อ</div>         
            เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchSeminarCitizen" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="13"></asp:TextBox>
            <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
            <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
        </div>
        <div style="text-align: center;">
            <asp:Table ID="Table1" runat="server" CssClass="ps-table-1" Style="display: inline-block;"></asp:Table>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" ToolPanelView="None" />
        </div>
    </div>
</asp:Content>