<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_PERSONAL.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" />
    <style>
        .col1 {
            color: #808080;
            padding-right: 10px;
            text-align: right;
        }
        .col2 {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="default_page_style">

        <div style="margin: 20px 0px; font-size: 16px;">ยินดีต้อนรับสู่ระบบบุคลากร</div>
        <div>
            <table>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2"><asp:Label ID="lbName" runat="server" Text="-"></asp:Label></td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2"><asp:Label ID="lbPosition" runat="server" Text="-"></asp:Label></td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2"><asp:Label ID="lbPositionRank" runat="server" Text="-"></asp:Label></td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2"><asp:Label ID="lbDepartment" runat="server" Text="-"></asp:Label></td>
                </tr>
            </table>
            
        </div>
        <div style="border-bottom: 1px solid #c0c0c0; margin: 20px 0;"></div>

        <div class="default_header"><img src="Image/Small/yellow_alert.png" />การแจ้งเตือน</div>
        <div id="notification_area" runat="server"></div>

        <div style="border-bottom: 1px solid #c0c0c0; margin: 20px 0;"></div>

    </div>
</asp:Content>
