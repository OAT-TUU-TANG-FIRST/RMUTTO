<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson-Edit.aspx.cs" Inherits="WEB_PERSONAL.AddPerson_Edit" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }
        .textred{
            color:red;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbUseDate11,#ContentPlaceHolder1_tbDate14").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbDateGetPositionGoverTab4,#ContentPlaceHolder1_tbDateGetPositionEMPTab4").datepicker($.datepicker.regional["th"]);
            $('document').ready(function () {
                $(".date").datepicker($.datepicker.regional["th"]);
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:HiddenField ID="hfpsID" runat="server" />

    <div>

        <div class="ps-header"><img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร</div>

        <div id="divTab" runat="server" class="ps-tab-container">
            <asp:LinkButton ID="lbuTab1" runat="server" OnClick="lbuTab1_Click" CssClass="ps-tab-unselected">ข้อมูลพื้นฐาน</asp:LinkButton>
            <asp:LinkButton ID="lbuTab2" runat="server" OnClick="lbuTab2_Click" CssClass="ps-tab-unselected">ที่อยู่</asp:LinkButton>
            <asp:LinkButton ID="lbuTab3" runat="server" OnClick="lbuTab3_Click" CssClass="ps-tab-unselected">ข้อมูลการทำงาน</asp:LinkButton>
            <asp:LinkButton ID="lbuTab4" runat="server" OnClick="lbuTab4_Click" CssClass="ps-tab-unselected">ตำแหน่ง</asp:LinkButton>
            <asp:LinkButton ID="lbuTab5" runat="server" OnClick="lbuTab5_Click" CssClass="ps-tab-unselected">ประวัติการศึกษา</asp:LinkButton>
            <asp:LinkButton ID="lbuTab6" runat="server" OnClick="lbuTab6_Click" CssClass="ps-tab-unselected">ใบอนุญาตประกอบวิชาชีพ</asp:LinkButton>
            <asp:LinkButton ID="lbuTab7" runat="server" OnClick="lbuTab7_Click" CssClass="ps-tab-unselected">ประวัติการฝึกอบรม</asp:LinkButton>
            <asp:LinkButton ID="lbuTab8" runat="server" OnClick="lbuTab8_Click" CssClass="ps-tab-unselected">โทษทางวินัย</asp:LinkButton>
            <asp:LinkButton ID="lbuTab9" runat="server" OnClick="lbuTab9_Click" CssClass="ps-tab-unselected">ตำแหน่งและเงินเดือน</asp:LinkButton>
        </div>

        <div id="notification" runat="server"></div>

        <div id="divState1" runat="server">
            <asp:Panel ID="pPerson" runat="server"></asp:Panel>
        </div>

        <div id="divTab1" runat="server" style="text-align: center;">
            <div class="ps-div-title-red">ข้อมูลพื้นฐาน</div>
            <div style="display: inline-block; margin-right: 20px; vertical-align: top;">
                <table class="ps-table-1">
                    <tr>
                        <td class="col1">บัตรประชาชน</td>
                        <td class="col2">
                            <asp:Label ID="labelCitizenID" runat="server"></asp:Label>
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
                            <asp:TextBox ID="tbNameEN" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุล อังกฤษ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbLastNameEN" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
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
                            <asp:TextBox ID="tbBirthday" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="display: inline-block; margin-right: 20px; vertical-align: top;">
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

            <div style="display: inline-block; vertical-align: top;">
                <table class="ps-table-1">
                    <tr>
                        <td class="col1">ชื่อบิดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลบิดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อมารดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดาเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherOldLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลเดิมคู่สมรสเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleOldLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
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
            <div class="ps-div-title-red">ข้อมูลที่อยู่</div>
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
                 &nbsp;&nbsp;
                <asp:LinkButton ID="lbCopyAddress" runat="server" CssClass="ps-button" OnClick="lbCopyAddress_Click"><img src="Image/Small/copy.png" class="icon_left"/>คัดลอกข้อมูลที่อยู่ตามทะเบียนบ้าน</asp:LinkButton>
            </div>
            <div class="ps-separator"></div>
        </div>

        <div id="divTab3" runat="server" style="text-align: center;">
            <div class="ps-div-title-red">ข้อมูลการทำงาน</div>
            <div style="display: inline-block; margin-right: 20px; vertical-align: top;">
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
                    <tr>
                        <td class="col1">งาน / ฝ่าย</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทบุคลากร</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทเงินจ้าง</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlBudget" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="display: inline-block; vertical-align: top;">
                <table class="ps-table-1">
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
                        <td class="col1">วันที่บรรจุ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbDateInwork" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
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
            <div style="margin-top: 10px;">
                <asp:LinkButton ID="lbuTab3Save" runat="server" OnClick="lbuTab3Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
            </div>
            <div class="ps-separator"></div>
        </div>

        <div id="divTab4" runat="server" style="text-align: center;">
            <div class="ps-div-title-red">ข้อมูลตำแหน่ง</div>
            <div style="display: inline-block;">
                <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top; text-align:left;" id="idPositionShowAll" runat="server">
                    <tr>
                        <th colspan="2">ตำแหน่ง</th>
                    </tr>
                    <tr>
                        <td>ตำแหน่งในสายงาน</td>
                        <td>
                            <asp:DropDownList ID="ddlTab4PositionWorkRow1" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                            <asp:CheckBox ID="chkBoxWorkPosition" runat="server" Text="กรณีเป็นเลือกตำแหน่งในสายงานครั้งแรก"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ตำแหน่งทางบริหาร</td>
                        <td>
                            <asp:DropDownList ID="ddlTab4AdminPositionRow1" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                            <asp:CheckBox ID="chkBoxAdminPosition" runat="server" Text="กรณีเป็นเลือกตำแหน่งทางบริหารครั้งแรก"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ตำแหน่งทางวิชาการ</td>
                        <td>
                            <asp:DropDownList ID="ddlTab4AcadPositionRow1" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                        </td>
                    </tr>
                </table>
                <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top; text-align:left;" id="idPositionShowGover" runat="server">
                    <tr>
                        <th colspan="2">ตำแหน่งข้าราชการ</th>
                    </tr>
                    <tr>
                        <td class="col1">วันที่ได้รับตำแหน่ง</td>
                        <td>
                            <asp:TextBox ID="tbDateGetPositionGoverTab4" runat="server" CssClass="ps-textbox" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งประเภทบริหาร</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTab4AdminPositionDegreeRow2" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งประเภทอำนวยการ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTab4DirectPositionDegreeRow2" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งประเภทวิชาการ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTab4AcadPositionDegreeRow2" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งประเภททั่วไป</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTab4GeneralPositionDegreeRow2" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; vertical-align: top; text-align:left;" id="idPositionShowOfficeEmp" runat="server">
                    <tr>
                        <th colspan="2">ตำแหน่งพนักงานราชการ</th>
                    </tr>
                    <tr>
                        <td class="col1">วันที่ได้รับตำแหน่ง</td>
                        <td>
                            <asp:TextBox ID="tbDateGetPositionEMPTab4" runat="server" CssClass="ps-textbox" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งพนักงานราชการ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTab4EmpPositionRow3" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuTab4Save" runat="server" OnClick="lbuTab4Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridviewPDHgover" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PDH_ID"
                    OnRowEditing="modEditCommandGover"
                    OnRowCancelingEdit="modCancelCommandGover"
                    OnRowUpdating="modUpdateCommandGover"
                    OnRowDeleting="modDeleteCommandGover"
                    OnRowDataBound="GridViewGover_RowDataBound"
                    OnPageIndexChanging="myGridViewGover_PageIndexChanging" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PDH_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPDHid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PDH_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PDH_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPDHcitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PDH_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่ได้รับตำแหน่ง" ControlStyle-Width="100" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHdate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PDH_DATE_START")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPDHdate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PDH_DATE_START")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งประเภทบริหาร" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHposiAdmin" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSI_ADMIN") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPDHposiAdmin" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งประเภทอำนวยการ" ControlStyle-Width="180" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHposiDirect" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSI_DIRECT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPDHposiDirect" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งประเภทวิชาการ" ControlStyle-Width="180" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHposiAcad" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSI_ACAD") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPDHposiAcad" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งประเภททั่วไป" ControlStyle-Width="180" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHposiGeneral" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSI_GENERAL") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPDHposiGeneral" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

                <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridviewPDHemp" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PDH_ID"
                    OnRowEditing="modEditCommandEmp"
                    OnRowCancelingEdit="modCancelCommandEmp"
                    OnRowUpdating="modUpdateCommandEmp"
                    OnRowDeleting="modDeleteCommandEmp"
                    OnRowDataBound="GridViewEmp_RowDataBound"
                    OnPageIndexChanging="myGridViewEmp_PageIndexChanging" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PDH_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPDHid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PDH_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PDH_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPDHcitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PDH_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่ได้รับตำแหน่งประเภท" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHdate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PDH_DATE_START")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPDHdate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PDH_DATE_START")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งพนักงานราชการ" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPDHempGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSI_EMP_GROUP") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPDHempGroup" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                <!-- END GRID VIEW-->
            </div>
            <div class="ps-separator"></div>
        </div>
    </div>

    <div id="divTab5" runat="server" style="text-align: center;">
        <div class="ps-div-title-red">ข้อมูลประวัติการศึกษา</div>
        <div style="text-align: center;">
            <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top;">
                <tr>
                    <td class="col1">ระดับการศึกษา</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlDegree10" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สถานศึกษา</td>
                    <td class="col2">
                        <asp:TextBox ID="tbUnivName10" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตั้งแต่ - ถึง (เดือน ปี)</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlMonth10From" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYear10From" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth10To" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYear10To" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">วุฒิ</td>
                    <td class="col2">
                        <asp:TextBox ID="tbQualification10" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สาขาวิชาเอก</td>
                    <td class="col2">
                        <asp:TextBox ID="tbMajor10" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเทศที่จบการศึกษา</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlCountrySuccess10" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align: center; margin-top: 10px;">
            <asp:LinkButton ID="lbuTab5Save" runat="server" OnClick="lbuTab5Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
        </div>
        <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
            <asp:GridView ID="GridViewStudy" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="PS_STUDY_ID"
                OnRowEditing="modEditCommand1"
                OnRowCancelingEdit="modCancelCommand1"
                OnRowUpdating="modUpdateCommand1"
                OnRowDeleting="modDeleteCommand1"
                OnRowDataBound="GridViewStudy_RowDataBound1"
                OnPageIndexChanging="myGridViewStudy_PageIndexChanging1" PageSize="15" CssClass="ps-table-1">
                <Columns>
                    <asp:TemplateField HeaderText="PS_STUDY_ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_STUDY_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PS_CITIZEN_ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_CITIZEN_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ระดับการศึกษา">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyDegreeID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEGREE_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyDegreeID" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สถานศึกษา">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyUnivName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_UNIV_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPersonStudyUnivName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_UNIV_NAME") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ตั้งแต่(เดือน)">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyFromMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_MONTH") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyFromMonth" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ตั้งแต่(ปี)">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyFromYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_YEAR") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyFromYear" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ถึง(เดือน)">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyToMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_MONTH") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyToMonth" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ถึง(ปี)">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyToYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_YEAR") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyToYear" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วุฒิ">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyQualification" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_QUALIFICATION") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPersonStudyQualification" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_QUALIFICATION") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สาขาวิชาเอก">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyMajor" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_MAJOR") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPersonStudyMajor" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_MAJOR") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ประเทศที่จบการศึกษา">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonStudyCountryID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COUNTRY_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersonStudyCountryID" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" />
                    <asp:TemplateField HeaderText="ลบ">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="ps-separator"></div>
    </div>

    <div id="divTab6" runat="server" style="text-align: center;">
        <div class="ps-div-title-red">ข้อมูลใบอนุญาตประกอบวิชาชีพ</div>
        <div style="text-align: center;">
            <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top;">
                <tr>
                    <td class="col1">ชื่อใบอนุญาต</td>
                    <td class="col2">
                        <asp:TextBox ID="tbLicenseName11" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">หน่วยงาน</td>
                    <td class="col2">
                        <asp:TextBox ID="tbDepartment11" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เลขที่ใบอนุญาต</td>
                    <td class="col2">
                        <asp:TextBox ID="tbLicenseNo11" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">วันที่มีผลบังคับใช้ (วัน เดือน ปี)</td>
                    <td class="col2">
                        <asp:TextBox ID="tbUseDate11" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuTab6Save" runat="server" OnClick="lbuTab6Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
            </div>
            <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridViewLicense" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PS_PL_ID"
                    OnRowEditing="modEditCommand2"
                    OnRowCancelingEdit="modCancelCommand2"
                    OnRowUpdating="modUpdateCommand2"
                    OnRowDeleting="modDeleteCommand2"
                    OnRowDataBound="GridViewLicense_RowDataBound2"
                    OnPageIndexChanging="myGridViewLicense_PageIndexChanging2" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PS_PL_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_PL_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PS_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อใบอนุญาต" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonLicenseName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หน่วยงาน" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonLicenseDepartment" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่ใบอนุญาต" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NO") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonLicenseNo" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NO") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่มีผลบังคับใช้ (วัน เดือน ปี)" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonLicenseDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_USE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonLicenseDate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_USE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="ps-separator"></div>
        </div>
    </div>    

    <div id="divTab7" runat="server" style="text-align: center;">
        <div class="ps-div-title-red">ข้อมูลประวัติการฝึกอบรม</div>
        <div style="text-align: center;">
            <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top;">
                <tr>
                    <td class="col1">หลักสูตรฝึกอบรม</td>
                    <td class="col2">
                        <asp:TextBox ID="tbCourse" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตั้งแต่ - ถึง (เดือน ปี)</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlMonth12From" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYear12From" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlMonth12To" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYear12To" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">หน่วยงานที่จัดฝึกอบรม</td>
                    <td class="col2">
                        <asp:TextBox ID="tbDepartment" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuTab7Save" runat="server" OnClick="lbuTab7Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
            </div>
            <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridViewTraining" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PS_TRAINING_ID"
                    OnRowEditing="modEditCommand3"
                    OnRowCancelingEdit="modCancelCommand3"
                    OnRowUpdating="modUpdateCommand3"
                    OnRowDeleting="modDeleteCommand3"
                    OnRowDataBound="GridViewTraining_RowDataBound3"
                    OnPageIndexChanging="myGridViewTraining_PageIndexChanging3" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PS_TRAINING_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TRAINING_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PS_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หลักสูตรฝึกอบรม" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingCourse" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COURSE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonTrainingCourse" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COURSE") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingFromMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_MONTH") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonTrainingFromMonth" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingFromYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_YEAR") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonTrainingFromYear" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingToMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_MONTH") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonTrainingToMonth" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingToYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_YEAR") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonTrainingToYear" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หน่วยงานที่จัดฝึกอบรม" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonTrainingDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonTrainingDepartment" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="ps-separator"></div>
        </div>
    </div>  

    <div id="divTab8" runat="server" style="text-align: center;">
        <div class="ps-div-title-red">ข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม</div>
        <div style="text-align: center;">
            <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top;">
                <tr>
                    <td class="col1">พ.ศ.</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlYear13" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รายการ</td>
                    <td class="col2">
                        <asp:TextBox ID="tbName13" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เอกสารอ้างอิง</td>
                    <td class="col2">
                        <asp:TextBox ID="tbREF13" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuTab8Save" runat="server" OnClick="lbuTab8Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
            </div>
            <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridViewDAA" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PS_DAA_ID"
                    OnRowEditing="modEditCommand4"
                    OnRowCancelingEdit="modCancelCommand4"
                    OnRowUpdating="modUpdateCommand4"
                    OnRowDeleting="modDeleteCommand4"
                    OnRowDataBound="GridViewDAA_RowDataBound4"
                    OnPageIndexChanging="myGridViewDAA_PageIndexChanging4" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PS_DAA_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonDAAID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DAA_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PS_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonDAACitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="พ.ศ." ControlStyle-Width="60" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonDAAYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_YEAR") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonDAAYear" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รายการ" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonDAAName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DAA_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonDAAName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DAA_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="200" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonDAARef" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonDAARef" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="ps-separator"></div>
        </div>
    </div>   

    <div id="divTab9" runat="server" style="text-align: center;">
        <div class="ps-div-title-red">ข้อมูลตำแหน่งและเงินเดือน</div>
        <div style="text-align: center;">
            <table class="ps-table-1" style="margin-bottom: 20px; display: inline-block; margin-right: 20px; vertical-align: top;">
                <tr>
                    <td class="col1">วัน เดือน ปี</td>
                    <td class="col2">
                        <asp:TextBox ID="tbDate14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:TextBox ID="tbPosition14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เลขที่ตำแหน่ง</td>
                    <td class="col2">
                        <asp:TextBox ID="tbPositionNo14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่งประเภท</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlPositionType14" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlPositionType14_SelectedIndexChanged"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlPositionDegree14" runat="server" CssClass="ps-dropdown" AutoPostBack="True"></asp:DropDownList><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เงินเดือน</td>
                    <td class="col2">
                        <asp:TextBox ID="tbSalary14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เงินประจำตำแหน่ง</td>
                    <td class="col2">
                        <asp:TextBox ID="tbSalaryPosition14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เอกสารอ้างอิง</td>
                    <td class="col2">
                        <asp:TextBox ID="tbRef14" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuTab9Save" runat="server" OnClick="lbuTab9Save_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
            </div>
            <div style="margin-top: 10px; overflow-x: auto; width: 1200px">
                <asp:GridView ID="GridViewPAS" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; "
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    DataKeyNames="PS_PAS_ID"
                    OnRowEditing="modEditCommand5"
                    OnRowCancelingEdit="modCancelCommand5"
                    OnRowUpdating="modUpdateCommand5"
                    OnRowDeleting="modDeleteCommand5"
                    OnRowDataBound="GridViewPAS_RowDataBound5"
                    OnPageIndexChanging="myGridViewPAS_PageIndexChanging5" PageSize="15" CssClass="ps-table-1" >
                    <Columns>
                        <asp:TemplateField HeaderText="PS_PAS_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_PAS_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PS_CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วัน เดือน ปี" ControlStyle-Width="80" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASDate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="150" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASPOsitionName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASPOsitionName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่ตำแหน่ง" ControlStyle-Width="40" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASPositionNO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_NO") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASPositionNO" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_NO") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="100" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASPositionType" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonPASPositionType" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ระดับ" ControlStyle-Width="100" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASDegree" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_DEGREE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPersonPASDegree" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เงินเดือน" ControlStyle-Width="70" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASSalary" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASSalary" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เงินประจำตำแหน่ง" ControlStyle-Width="70" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASSalaryPosition" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY_POSITION") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASSalaryPosition" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY_POSITION") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="130" >
                            <ItemTemplate>
                                <asp:Label ID="lblPersonPASRef" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPersonPASRef" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข"  />
                        <asp:TemplateField HeaderText="ลบ" >
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="ps-separator"></div>
        </div>
    </div>
    
</asp:Content>