<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Report-Custom-Person.aspx.cs" Inherits="WEB_PERSONAL.Report_Custom_Person" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div>
            <fieldset>
                <legend>Test</legend>
                <table>
                    <tr>
                        <td>

                            CITIZEN_ID
                            <asp:TextBox ID="txt1" runat="server"> </asp:TextBox>
                            <asp:Button ID="btnShowReport" Text="Show Report" runat="server" onclick="btnShowReport_Click"> </asp:Button>
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="1202px" ReportSourceID="CrystalReportSource1" ToolPanelWidth="200px" Width="1104px" OnInit="CrystalReportViewer1_Init" ToolPanelView="None" />
                       
                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                <Report FileName="CrystalReport1.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                       
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </asp:Panel>


</asp:Content>
