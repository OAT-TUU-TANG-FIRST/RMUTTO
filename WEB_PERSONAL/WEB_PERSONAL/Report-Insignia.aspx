<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Insignia.aspx.cs" Inherits="WEB_PERSONAL.Report_Insignia" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
            <img src="Image/Small/medal.png" />ออกรายงานเครื่องราชฯ
        </div>
    </div>
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" ToolPanelView="None" />
    </div>
</asp:Content>
