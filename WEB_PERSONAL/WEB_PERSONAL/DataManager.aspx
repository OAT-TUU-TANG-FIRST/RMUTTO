<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="WEB_PERSONAL.DataManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .link_list a {
            text-decoration: none;
            color: #000000;
            display: table;
            padding: 3px 0px;
            margin: 5px;
        
        }
        .link_list a:hover {
            color: #00a2e8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header"><img src="Image/Small/table.png" />จัดการข้อมูล Drop-down List</div>
        <div class="link_list">
            <a href="Ministry-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลกระทรวง </a>
            <a href="TitleName-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลคำนำหน้านาม </a>
            <a href="StaffType-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลประเภทข้าราชการ </a>
            <a href="Month-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลเดือน </a>
            <a href="Year-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลปี </a>
            <a href="Staff-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลตำแหน่งประเภท </a>
            <a href="Gender-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลเพศ </a>
            <a href="Province-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลจังหวัด </a>
            <a href="Amphur-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลอำเภอ </a>
            <a href="District-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลตำบล </a>
            <a href="National-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลสัญชาติ </a>
            <a href="TimeContact-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลระยะเวลาจ้าง </a>
            <a href="Budget-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลประเภทเงินจ้าง </a>
            <a href="SubStaffType-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลประเภทบุคลากรย่อย </a>
            <a href="AdminPosition-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลตำแหน่งบริหาร </a>
            <a href="PositionWork-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลตำแหน่งในสายงาน </a>
            <a href="TeachISCED-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลกลุ่มสาขาวิชาที่สอน </a>
            <a href="GradLev-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลระดับการศึกษาที่จบการศึกษาสูงสุด </a>
            <a href="GradISCED-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลกลุ่มสาขาวิชาที่จบสูงสุด </a>
            <a href="GradProgram-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลสาขาวิชาที่จบการศึกษาสูงสุด </a>
            <a href="GradCountry-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลประเทศที่จบการศึกษาสูงสุด </a>
            <a href="Campus-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลวิทยาเขต </a>
            <a href="Faculty-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลคณะ </a>
            <a href="StatusWork-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลสถานะการทำงาน </a>
            <a href="Religion-ADMIN.aspx"><img src="Image/Small/wrench.png" class="icon_left"/>จัดการข้อมูลศาสนา </a>
            </div>
        

    </div>
</asp:Content>
