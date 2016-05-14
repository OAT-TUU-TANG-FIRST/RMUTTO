<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_PERSONAL.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="default_page_style">

        <div class="ps-header"><img src="Image/Small/home3.png"/>ยินดีต้อนรับสู่ระบบบุคลากร</div>
        <div>
            <table class="ps-table">
                <tr>
                    <td class="head" colspan="2">ข้อมูลผู้ใช้</td>
                </tr>
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
        <div class="ps-separator"></div>

        <div class="ps-header"><img src="Image/Small/yellow_alert.png" />การแจ้งเตือน</div>
        <div id="notification_area" runat="server"></div>

        <div class="ps-separator"></div>

    </div>
</asp:Content>
