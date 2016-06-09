<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveReport.aspx.cs" Inherits="WEB_PERSONAL.LeaveReport1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-box">
        <div class="ps-box-i0">
            <div class="ps-box-ct10">
                <asp:Label ID="Label3" runat="server" Text="สรุปข้อมูลการลาหยุดราชการ ขาดราชการ มาสาย ประจำปีงบประมาณ"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:Label ID="Label1" runat="server" Text="(1 ตุลาคม 2557 - 30 กันยายน 2558)"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label>
            </div>
            <div class="ps-box-i0">
                <div class="ps-box-hd10">
                    <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>Export</asp:LinkButton>
                </div>
                <div class="ps-box-ct10">
                     <asp:Table ID="tb" runat="server" CssClass="ps-gridview"></asp:Table>
                    <div class="div_no_data">
                        <asp:Label ID="Label4" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </div>

    
   
</asp:Content>
