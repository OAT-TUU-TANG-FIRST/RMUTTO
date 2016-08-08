<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="WEB_PERSONAL.AddPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .textred {
            color: red;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork").datepicker($.datepicker.regional["th"]);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">

        <div class="ps-header"><img src="Image/Small/add.png" />เพิ่มข้อมูลบุคลากร</div>

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div style="text-align: center;">
                    <div class="ps-div-title-red">ข้อมูลพื้นฐาน</div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">บัตรประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คำนำหน้า</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbNameTH" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastNameTH" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ อังกฤษ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbNameEN" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล อังกฤษ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastNameEN" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เพศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันเกิด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthday" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx" MaxLength="12"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">อีเมล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">โทรศัพท์มือถือ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="ps-textbox" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">โทรศัพท์ที่ทำงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbTelephone" runat="server" CssClass="ps-textbox" MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เชื้อชาติ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlRace" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สัญชาติ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlNation" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กรุ๊ปเลือด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlBlood" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ศาสนา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สถานภาพ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">วิทยาเขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCampus" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สำนัก / สถาบัน / คณะ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr id="trWorkDivision" runat="server">
                                <td class="col1">งาน / ฝ่าย</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทบุคลากร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่บรรจุ</td>
                                <td class="col2">
                                <asp:TextBox ID="tbDateInwork" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx" MaxLength="12"></asp:TextBox><span class="textred">*</span>
                                </td>
                             </tr>
                        </table>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbSubmit" runat="server" CssClass="ps-button" OnClick="lbSubmit_Click"><img src="Image/Small/save.png" class="icon_left"/>เพิ่มข้อมูลบุคลากร</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div>
                    <div class="ps-div-title-red">ทำการเพิ่มข้อมูลบุคลากรสำเร็จ</div>
                    <div style="color: #808080; margin-top: 10px; text-align: center;">
                        ระบบจะมีการส่งแจ้งเตือนรหัสผ่านสำหรับบุคลากรใหม่ โดยสามารถเข้าไปตรวจสอบได้ที่อีเมลของตัวเอง เพื่อไว้สำหรับเข้าสู่ระบบในเว็บไซต์นี้
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <a href="Default.aspx" class="ps-button">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>

        <div class="ps-separator"></div>
    </div>
</asp:Content>