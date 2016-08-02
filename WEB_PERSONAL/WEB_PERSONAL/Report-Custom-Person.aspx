<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Custom-Person.aspx.cs" Inherits="WEB_PERSONAL.Report_Custom_Person" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
            .auto-style1 {
                border-collapse: collapse;
                box-shadow: rgba(0,0,0,0.2) 0px 1px 4px;
                width: 348px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
         <div id="div1" runat="server" style="text-align: center;">
            <div class="ps-div-title-red">ออกรายงานบุคลากร</div>
            <div style="display: inline-block; margin-right: 20px;">
                <table class="auto-style1" style="text-align:center">
                    <tr>
                        <td><asp:ImageButton ID="ImgPdf32" Height="50px" ImageUrl="Image/x32/PDF32.png" runat="server" onclick="ImgPdf32_Click" ></asp:ImageButton></td>
                        <td><asp:ImageButton ID="ImgExcel32" Height="50px" ImageUrl="Image/x32/Excel32.png" runat="server" onclick="ImgExcel32_Click" ></asp:ImageButton></td>
                        <td><asp:ImageButton ID="ImgWord32" Height="50px" ImageUrl="Image/x32/Word32.png" runat="server" onclick="ImgWord32_Click" ></asp:ImageButton></td>
                    </tr>
                    
                </table>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </div>
            <div class="ps-separator"></div>
        </div>
    </asp:Panel>
</asp:Content>
