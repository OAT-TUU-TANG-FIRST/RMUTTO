<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="WEB_PERSONAL.DataManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .wrapper {
            width: 1024px;
        }

        .main {
            padding: 20px;
        }
        .link_list {
            padding: 20px;
            border: 1px solid #e0e0e0;
        }
        .link_list span {
            display: inline-block;
            color: #000000;
            font-size: 24px;
            font-weight: bold;
        }
        .link_list a {
            text-decoration: none;
            color: #000000;
            display: inline-block;
            padding: 0 20px;
            height: 50px;
            line-height: 50px;
            margin: 5px;
            background-color: #e0e0e0;
        }
        .link_list a:hover {
            background-color: #c0c0c0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="link_list">
            <span>จัดการข้อมูล Drop-down List</span>
            <div style="height: 20px;"></div>
            <a href="Ministry-ADMIN.aspx">จัดการข้อมูลกระทรวง </a>
            <a href="TitleName-ADMIN.aspx">จัดการข้อมูลคำนำหน้านาม </a>
            <a href="StaffType-ADMIN.aspx">จัดการข้อมูลประเภทข้าราชการ </a>
            <a href="Month-ADMIN.aspx">จัดการข้อมูลเดือน </a>
            <a href="Year-ADMIN.aspx">จัดการข้อมูลปี </a>
            <a href="Staff-ADMIN.aspx">จัดการข้อมูลตำแหน่งประเภท </a>
            <a href="Gender-ADMIN.aspx">จัดการข้อมูลเพศ </a>
            <a href="Province-ADMIN.aspx">จัดการข้อมูลจังหวัด </a>
            <a href="Amphur-ADMIN.aspx">จัดการข้อมูลอำเภอ </a>
            <a href="District-ADMIN.aspx">จัดการข้อมูลตำบล </a>
            <a href="National-ADMIN.aspx">จัดการข้อมูลสัญชาติ </a>
            <a href="TimeContact-ADMIN.aspx">จัดการข้อมูลระยะเวลาจ้าง </a>
            <a href="Budget-ADMIN.aspx">จัดการข้อมูลประเภทเงินจ้าง </a>
            <a href="SubStaffType-ADMIN.aspx">จัดการข้อมูลประเภทบุคลากรย่อย </a>
            <a href="AdminPosition-ADMIN.aspx">จัดการข้อมูลตำแหน่งบริหาร </a>
            <a href="PositionWork-ADMIN.aspx">จัดการข้อมูลตำแหน่งในสายงาน </a>
            <a href="TeachISCED-ADMIN.aspx">จัดการข้อมูลกลุ่มสาขาวิชาที่สอน </a>
            <a href="GradLev-ADMIN.aspx">จัดการข้อมูลระดับการศึกษาที่จบการศึกษาสูงสุด </a>
            <a href="GradISCED-ADMIN.aspx">จัดการข้อมูลกลุ่มสาขาวิชาที่จบสูงสุด </a>
            <a href="GradProgram-ADMIN.aspx">จัดการข้อมูลสาขาวิชาที่จบการศึกษาสูงสุด </a>
            <a href="GradCountry-ADMIN.aspx">จัดการข้อมูลประเทศที่จบการศึกษาสูงสุด </a>
            <a href="Campus-ADMIN.aspx">จัดการข้อมูลวิทยาเขต </a>
            <a href="Faculty-ADMIN.aspx">จัดการข้อมูลคณะ </a>
            <a href="StatusWork-ADMIN.aspx">จัดการข้อมูลสถานะการทำงาน </a>
            <a href="Religion-ADMIN.aspx">จัดการข้อมูลศาสนา </a>
            
        </div>

    </div>
</asp:Content>
