<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson-Edit.aspx.cs" Inherits="WEB_PERSONAL.AddPerson_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .TMZ {
            font-family: tahoma;
            text-align: left;
            color: #9999ff;
            font-weight: 900;
        }
        .ui-datepicker {
            font-family: tahoma;
            text-align: center;
            color: dodgerblue;
        }
        fieldset {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: black;
            text-align: left;
        }
        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: left;
        }
        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 300px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
        .col1 {
            text-align: right;
        }
        .col2 {
            text-align: left;
        }
        .ps-button {
            display: inline-block;
            font-family: RB-Regular, Tahoma;
            font-weight: normal;
            font-size: 12px;
            text-decoration: none;
            padding: 3px 15px;
            border-radius: 4px;
            cursor: pointer;
            transition: color ease 0.25s, background-color ease 0.25s, border-color ease 0.25s;
            text-align: left;
            color: #000000;
            background-color: #ffffff;
            border: 1px solid #c0c0c0;
            border-top: 1px solid #d0d0d0;
            border-bottom: 1px solid #b0b0b0;
            padding: 3px 15px;
            border-collapse: collapse;
        }
        .textred{
            color:red;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbUseDate11,#ContentPlaceHolder1_tbDate14").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbDateInwork").datepicker($.datepicker.regional["th"]);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:HiddenField ID="hfpsID" runat="server" />

    <div>

        <div class="ps-header"><img src="Image/Small/person2.png" />แก้ไขข้อมูลบุคลากร</div>

        <div id="divTab" runat="server" class="ps-tab-container">
            <asp:LinkButton ID="lbuTab1" runat="server" OnClick="lbuTab1_Click" CssClass="ps-tab-unselected">ข้อมูลพื้นฐาน</asp:LinkButton>
            <asp:LinkButton ID="lbuTab2" runat="server" OnClick="lbuTab2_Click" CssClass="ps-tab-unselected">ที่อยู่</asp:LinkButton>
            <asp:LinkButton ID="lbuTab3" runat="server" OnClick="lbuTab3_Click" CssClass="ps-tab-unselected">ข้อมูลการทำงาน</asp:LinkButton>
            <asp:LinkButton ID="lbuTab4" runat="server" OnClick="lbuTab4_Click" CssClass="ps-tab-unselected">ตำแหน่งข้าราชการ</asp:LinkButton>
            <asp:LinkButton ID="lbuTab5" runat="server" OnClick="lbuTab5_Click" CssClass="ps-tab-unselected">ประวัติการศึกษา</asp:LinkButton>
        </div>


        <div id="notification" runat="server"></div>

        <div id="divState1" runat="server">
            <asp:Panel ID="pPerson" runat="server"></asp:Panel>
        </div>

        <div id="divTab1" runat="server" style="text-align: center;">
                    <div style="display: inline-block; margin-right: 20px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">บัตรประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ยศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlRank" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คำนำหน้า</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbNameTH" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastNameTH" runat="server" CssClass="ps-textbox"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันเกิด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthday" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="display: inline-block; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">อีเมล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="ps-textbox"></asp:TextBox>
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
                    <div style="margin-top: 10px;">
                        <asp:LinkButton ID="lbuTab1Save" runat="server" OnClick="lbuTab1Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                    </div>
            <div class="ps-separator"></div>

        </div>
        <div id="divTab2" runat="server" style="text-align: center;">

                    <div style="display: inline-block; margin-right: 20px;">
                        <table class="ps-table-1">
                            <tr>
                                <th colspan="2">
                                    <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ตามทะเบียนบ้าน
                                </th>
                            </tr>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSoi" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMoo" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRoad" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAmphur" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbZipcode" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbState" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="display: inline-block;">
                        <table class="ps-table-1">
                            <tr>
                                <th colspan="2">
                                    <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ที่ติดต่อได้
                                </th>
                            </tr>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbHomeAdd2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSoi2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMoo2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRoad2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlProvince2" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAmphur2" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDistrict2" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbZipcode2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbState2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:LinkButton ID="lbuTab2Save" runat="server" OnClick="lbuTab2Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                    </div>
            <div class="ps-separator"></div>
        </div>

        <div id="divTab3" runat="server" style="text-align: center;">
          
    
                    <div style="display: inline-block; margin-right: 20px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">วิทยาเขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCampus" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สำนัก / สถาบัน / คณะ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">งาน / ฝ่าย</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทบุคลากร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทเงินจ้าง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlBudget" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่บรรจุ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbDateInwork" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินเดือน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินประจำตำแหน่ง</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPositionSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td class="col1">สถานะบุคลากร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTab10StatusWork" runat="server" CssClass="ps-dropdown" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="display: inline-block; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">ตำแหน่งประเภท</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTpyePosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่ง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งบริหาร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งในสายงาน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPositionWork" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งทางวิชาการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAcademic" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td class="col1">ความเชี่ยวชาญในสายงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSpecialWork" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กลุ่มสาขาวิชาที่สอน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับตำแหน่งประเภท</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigGover" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งระดับ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigDegree" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งกลุ่มพนักงานราชการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigEMP" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:LinkButton ID="lbuTab3Save" runat="server" OnClick="lbuTab3Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                    </div>
            <div class="ps-separator"></div>
        </div>

        <div id="divTab4" runat="server">
            <div style="text-align: center;">
                 <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; vertical-align: top;">
                     <tr>
                         <th colspan="2">ตำแหน่ง</th>
                     </tr>
                     <tr>
                         <td>ตำแหน่งในสายงาน</td>
                         <td>
                             <asp:DropDownList ID="ddlTab4PositionWork" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                         </td>
                     </tr>
                     <tr>
                         <td>ตำแหน่งทางบริหาร</td>
                         <td>
                             <asp:DropDownList ID="ddlTab4AdminPositionDegree" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                         </td>
                     </tr>
                 </table>
                <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; vertical-align: top;" id="tbGover" runat="server">
                    <tr>
                        <th colspan="2">ตำแหน่งข้าราชการ</th>
                    </tr>
                   <tr>
                            <td class="col1">ตำแหน่งประเภทบริหาร</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlTab4AdminPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภทอำนวยการ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlTab4DirectPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภทวิชาการ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlTab4AcadPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภททั่วไป</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlTab4GeneralPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                            </td>
                        </tr>
                </table>
                <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; vertical-align: top;" id="tbOfficeGover" runat="server">
                    <tr>
                        <th colspan="2">ตำแหน่งพนักงานราชการ</th>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งพนักงานราชการ</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuTab4Save" runat="server" OnClick="lbuTab4Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                </div>
            </div>
            <div class="ps-separator"></div>
        </div>

        <div id="divTab5" runat="server" style="text-align: center;">
            <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ประวัติการศึกษา
                    </div>
                    <table>
                        <tr>
                            <td class="col1">ระดับการศึกษา</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlDegree10" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สถานศึกษา</td>
                            <td class="col2">
                                <asp:TextBox ID="tbUnivName10" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlMonth10From" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear10From" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth10To" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear10To" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">วุฒิ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbQualification10" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สาขาวิชาเอก</td>
                            <td class="col2">
                                <asp:TextBox ID="tbMajor10" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเทศที่จบ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlCountrySuccess10" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuTab5Save" runat="server" OnClick="lbuTab5Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewStudy" runat="server" Width="100%" Visible="false"></asp:GridView>
                    <asp:GridView ID="GridViewStudyShow" runat="server" Width="100%"></asp:GridView>
                  
        </div>

    </div>
</asp:Content>
