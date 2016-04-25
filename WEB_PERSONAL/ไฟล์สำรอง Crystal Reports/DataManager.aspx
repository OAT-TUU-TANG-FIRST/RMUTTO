﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="WEB_PERSONAL.DataManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }
        .center1 { 
               display:inline-block; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" Width="100%">
        <div>
            <fieldset>
                <legend>จัดการข้อมูล Drop-down List</legend>
                <div>
                    <table>
                        <tr>
                            <td class="col1">คำนำหน้า :</td>
                            <td class="col2"><a href="TitleName-ADMIN.aspx" class="button button_default" style="width: 120px">คำนำหน้า</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">วิทยาเขต :</td>
                            <td><a href="Campus-ADMIN.aspx" class="button button_default" style="width: 160px">วิทยาเขต</a></td>

                        </tr>
                        <tr>
                            <td class="col1">เพศ :</td>
                            <td class="col2"><a href="Gender-ADMIN.aspx" class="button button_default" style="width: 120px">เพศ</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">สำนัก / สถาบัน / คณะ :</td>
                            <td><a href="Faculty-ADMIN.aspx" class="button button_default" style="width: 160px">สำนัก / สถาบัน / คณะ</a></td>
                        </tr>
                        <tr>
                            <td class="col1">เชื้อชาติ / สัญชาติ :</td>
                            <td><a href="National-ADMIN.aspx" class="button button_default" style="width: 120px">เชื้อชาติ / สัญชาติ</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">กอง / สำนักงานเลขา / ภาควิชา :</td>
                            <td><a href="Division-ADMIN.aspx" class="button button_default" style="width: 160px">กอง / สำนักงานเลขา / ภาควิชา</a></td>
                        </tr>
                        <tr>
                            <td class="col1">กรุ๊ปเลือด :</td>
                            <td><a href="Blood-ADMIN.aspx" class="button button_default" style="width: 120px">กรุ๊ปเลือด</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">งาน / ฝ่าย :</td>
                            <td><a href="WorkDivision-ADMIN.aspx" class="button button_default" style="width: 160px">งาน / ฝ่าย</a></td>
                        </tr>
                        <tr>
                            <td class="col1">ศาสนา :</td>
                            <td><a href="Religion-ADMIN.aspx" class="button button_default" style="width: 120px">ศาสนา</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ประเภทบุคลากร :</td>
                            <td><a href="StaffType-ADMIN.aspx" class="button button_default" style="width: 160px">ประเภทบุคลากร</a></td>
                        </tr>
                        <tr>
                            <td class="col1">สถานภาพ :</td>
                            <td><a href="StatusPerson-ADMIN.aspx" class="button button_default" style="width: 120px">สถานภาพ</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ประเภทเงินจ้าง :</td>
                            <td><a href="Budget-ADMIN.aspx" class="button button_default" style="width: 160px">ประเภทเงินจ้าง</a></td>
                        </tr>
                        <tr>
                            <td class="col1">จังหวัด :</td>
                            <td><a href="Province-ADMIN.aspx" class="button button_default" style="width: 120px">จังหวัด</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ตำแหน่งบริหาร :</td>
                            <td><a href="AdminPosition-ADMIN.aspx" class="button button_default" style="width: 160px">ตำแหน่งบริหาร</a></td>
                        </tr>
                        <tr>
                            <td class="col1">อำเภอ :</td>
                            <td><a href="Amphur-ADMIN.aspx" class="button button_default" style="width: 120px">อำเภอ</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ตำแหน่งในสายงาน :</td>
                            <td><a href="PositionWork-ADMIN.aspx" class="button button_default" style="width: 160px">ตำแหน่งในสายงาน</a></td>
                        </tr>
                        <tr>
                            <td class="col1">ตำบล :</td>
                            <td><a href="District-ADMIN.aspx" class="button button_default" style="width: 120px">ตำบล</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ตำแหน่งทางวิชาการ :</td>
                            <td><a href="AcademicPosition-ADMIN.aspx" class="button button_default" style="width: 160px">ตำแหน่งทางวิชาการ</a></td>
                        </tr>
                        <tr>
                            <td class="col1">ประเทศ :</td>
                            <td><a href="GradCountry-ADMIN.aspx" class="button button_default" style="width: 120px">ประเทศ</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">กลุ่มสาขาวิชาที่สอน :</td>
                            <td><a href="TeachISCED-ADMIN.aspx" class="button button_default" style="width: 160px">กลุ่มสาขาวิชาที่สอน</a></td>
                        </tr>
                        <tr>
                            <td class="col1">ระดับการศึกษา :</td>
                            <td><a href="GradLev-ADMIN.aspx" class="button button_default" style="width: 120px">ระดับการศึกษา</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ตำแหน่งประเภท :</td>
                            <td><a href="Staff-ADMIN.aspx" class="button button_default" style="width: 160px">ตำแหน่งประเภท</a></td>
                        </tr>
                        <tr>
                            <td class="col1">เดือน :</td>
                            <td><a href="Month-ADMIN.aspx" class="button button_default" style="width: 120px">เดือน</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ระดับข้าราชการ :</td>
                            <td><a href="GoverPosition-ADMIN.aspx" class="button button_default" style="width: 160px">ระดับข้าราชการ</a></td>
                        </tr>
                        <tr>
                            <td class="col1">ปี :</td>
                            <td><a href="Year-ADMIN.aspx" class="button button_default" style="width: 120px">ปี</a></td>
                            <td class="col1" style="width:10px"></td>
                            <td class="col1">ระดับลูกจ้างประจำ :</td>
                            <td><a href="Permanent-ADMIN.aspx" class="button button_default" style="width: 160px">ระดับลูกจ้างประจำ</a></td>
                        </tr>
                        
                        </table>
            
                    </div>
            </fieldset>
    </div>
    </asp:Panel>
</asp:Content>
