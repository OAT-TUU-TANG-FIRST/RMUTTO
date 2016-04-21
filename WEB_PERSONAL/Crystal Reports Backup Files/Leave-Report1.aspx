<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave-Report1.aspx.cs" Inherits="WEB_PERSONAL.Leave_Report1" MaintainScrollPositionOnPostback="true"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @font-face {
            font-family: THS;
            src: url("Font/THSarabun.ttf");
        }
        body {
            font-family: THS;
            font-size: 26px;
        }
        .g1 th {
            text-align: center;
        }
        .ds1 {
            
        }
        .div_no_data {
            text-align: center;
        }
        #Label4 {
            font-size: 64px;
            font-family: 'WDB Bangna';
        }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="ds1">
            <asp:Label ID="Label3" runat="server" Text="สรุปข้อมูลการลาหยุดราชการ ขาดราชการ มาสาย ประจำปีงบประมาณ"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="(1 ตุลาคม 2557 - 30 กันยายน 2558)"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="g1">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div class="div_no_data">
            <asp:Label ID="Label4" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
        </div>
        
    </form>
</body>
</html>
