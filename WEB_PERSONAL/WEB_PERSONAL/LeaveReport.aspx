<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveReport.aspx.cs" Inherits="WEB_PERSONAL.LeaveReport1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-div-title-red">
            สรุปข้อมูลการลาหยุดราชการ ขาดราชการ มาสาย ประจำปีงบประมาณ
        </div>
        <div>
            <table>
                <tr>
                    <td>การแสดงผล</td>
                    <td>
                        <asp:DropDownList ID="ddlView" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>ปีงบประมาณ</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" CssClass="ps-dropdown"></asp:DropDownList>
                    </td>
                </tr>
            </table>
             
            
        </div>
        <div class="ps-separator"></div>
        <div>
            <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>Export</asp:LinkButton>
        </div>
        <div style="margin-top: 10px;">
            <asp:Table ID="tb" runat="server" CssClass="ps-gridview"></asp:Table>
            <div class="div_no_data">
                <asp:Label ID="Label4" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
            </div>
        </div>
    </div>
    
   
</asp:Content>
