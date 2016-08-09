<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Seminar.aspx.cs" Inherits="WEB_PERSONAL.Report_Seminar" %>
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
            <img src="Image/Small/report.png" />ออกรายงานพัฒนาบุคลากร
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server">
                <div>
                    <div class="ps-div-title-red">คุณไม่สามารถออกรายงานพัฒนาบุคลากรได้</div>
                    <div style="color: #808080; margin-top: 10px; text-align: center;">
                        โปรดลองใหม่ในภายหลัง เมื่อได้ทำการเพิ่มรายงานพัฒนาบุคลากร
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <a href="Default.aspx" class="ps-button">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </asp:View>

            <asp:View ID="View1" runat="server">
                <div style="text-align: center;">
                    <asp:Table ID="Table1" runat="server" CssClass="ps-table-1" style="display: inline-block;"></asp:Table>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" ToolPanelView="None" />
                </div>
            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>