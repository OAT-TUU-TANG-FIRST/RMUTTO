<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonReport.aspx.cs" Inherits="WEB_PERSONAL.PersonReport" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            
            $("#ContentPlaceHolder1_tbBirthdayDateFrom, #ContentPlaceHolder1_tbBirthdayDateTo").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbInworkDateFrom, #ContentPlaceHolder1_tbInworkDateTo").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbRetireDateFrom, #ContentPlaceHolder1_tbRetireDateTo").datepicker($.datepicker.regional["th"]);
        });
        function toggle(source, type) {
            var checkboxes = document.getElementsByName(type);
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].firstChild.checked = source.checked;
            }
        }
        function match(source, id) {
            var checkbox1 = document.getElementById(id);
            var checkbox2 = document.getElementById(source);
            checkbox1.checked = checkbox2.checked;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/report.png" />ออกรายงานบุคลากร
        </div>
        <div id="notification" runat="server"></div>
        <div>
            <div class="ps-div-title-red">เลือกข้อมูลที่ต้องการออกรายงาน</div>
            <div style="text-align: center;">
                <input type="checkbox" onclick="toggle(this, 'item');" />
                <b>เลือกทั้งหมด</b>

                <div style="display: inline-block; margin-right: 20px; vertical-align: top; text-align: left">
                    <table>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbPsID" runat="server" name="item" />
                                ลำดับ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbCitizenID" runat="server" name="item" />
                                เลขบัตรประชาชน</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbRank" runat="server" name="item" />
                                ยศ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNameTH" runat="server" name="item" />
                                ชื่อภาษาไทย</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNameEN" runat="server" name="item" />
                                ชื่อภาษาอังกฤษ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbGender" runat="server" name="item" />
                                เพศ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbBirthdayDate" runat="server" name="item" />
                                วันเกิด</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbRace" runat="server" name="item" />
                                เชื้อชาติ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNation" runat="server" name="item" />
                                สัญชาติ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbBlood" runat="server" name="item" />
                                กรุ๊ปเลือด</td>
                        </tr>
                    </table>
                </div>
                <div style="display: inline-block; margin-right: 20px; vertical-align: top; text-align: left">
                    <table>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbEmail" runat="server" name="item" />
                                อีเมล</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbPhone" runat="server" name="item" />
                                เบอร์โทรศัพท์ส่วนตัว</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbPhoneWork" runat="server" name="item" />
                                เบอร์โทรศัพท์ที่ทำงาน</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbReligion" runat="server" name="item" />
                                ศาสนา</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbStatus" runat="server" name="item" />
                                สถานภาพ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNameFather" runat="server" name="item" />
                                ชื่อบิดา</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNameMother" runat="server" name="item" />
                                ชื่อมารดา</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbNameCouple" runat="server" name="item" />
                                ชื่อคู่สมรส</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbAddress" runat="server" name="item" />
                                ที่อยู่ตามทะเบียนบ้าน</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbAddressNow" runat="server" name="item" />
                                ที่อยู่ปัจจุบัน</td>
                        </tr>
                    </table>
                </div>

                <div style="display: inline-block; margin-right: 20px; vertical-align: top; text-align: left">
                    <table>
                        
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbCampus" runat="server" name="item" />
                                วิทยาเขต</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbFaculty" runat="server" name="item" />
                                สำนัก / สถาบัน / คณะ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbDivision" runat="server" name="item" />
                                กอง / สำนักงานเลขา / ภาควิชา</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbWorkDivision" runat="server" name="item" />
                                งาน / ฝ่าย</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbStafftype" runat="server" name="item" />
                                ประเภทบุคลากร</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbBudget" runat="server" name="item" />
                                ประเภทเงินจ้าง</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbDateInwork" runat="server" name="item" />
                                วันที่เข้าทำงาน</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbDateRetire" runat="server" name="item" />
                                วันที่เกษียณ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbAge" runat="server" name="item" />
                                อายุ</td>
                        </tr>
                        <tr>
                            <td class="col2">
                                <asp:CheckBox ID="cbStatusWork" runat="server" name="item" />
                                สถานะการทำงาน</td>
                        </tr>
                    </table>
                </div>
            </div>

            <div style="text-align: center">
                <div class="ps-div-title-red" style="margin-top: 10px;">เลือกเงื่อนไข การออกรายงาน</div>
                <div style="text-align: left; display: inline-block">
                    <div>
                        <input type="checkbox" onclick="toggle(this, 'condition');" />
                        <b>เลือกทั้งหมด</b>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbCitizenIDCondition" runat="server" name="condition" />&nbsp;เลขบัตรประชาชน
                        <asp:textbox ID="tbCitizenIDCondition" runat="server" MaxLength="13" CssClass="ps-textbox" placeholder="เลขบัตรประชาชน"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbRankCondition" runat="server" name="condition" />&nbsp;ยศ
                        <asp:DropDownList ID="ddlRank" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNameTHCondition" runat="server" name="condition" />&nbsp;ชื่อภาษาไทย
                        <asp:textbox ID="tbNameFNTHCondition" runat="server" CssClass="ps-textbox" placeholder="ชื่อ ภาษาไทย"></asp:textbox>
                        <asp:textbox ID="tbNameLNTHCondition" runat="server" CssClass="ps-textbox" placeholder="นามสกุล ภาษาไทย"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNameENCondition" runat="server" name="condition" />&nbsp;ชื่อภาษาอังกฤษ
                        <asp:textbox ID="tbNameFNENCondition" runat="server" CssClass="ps-textbox" placeholder="ชื่อภาษาอังกฤษ"></asp:textbox>
                        <asp:textbox ID="tbNameLNENCondition" runat="server" CssClass="ps-textbox" placeholder="นามสกุล ภาษาอังกฤษ"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbGenderCondition" runat="server" name="condition" />&nbsp;เพศ
                        <asp:RadioButton ID="rbMale" runat="server" GroupName="gGender" Checked="true" />&nbsp;ชาย
                        <asp:RadioButton ID="rbFemale" runat="server" GroupName="gGender" />&nbsp;หญิง
                    </div>
                    <div>
                        <asp:CheckBox ID="cbBirthdayDateCondition" runat="server" name="condition" />&nbsp;วันเกิด
                        <asp:TextBox ID="tbBirthdayDateFrom" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                        <span style="color: #808080;">ถึง</span>
                        <asp:TextBox ID="tbBirthdayDateTo" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbRaceCondition" runat="server" name="condition" />&nbsp;เชื้อชาติ
                        <asp:DropDownList ID="ddlRaceCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNationCondition" runat="server" name="condition" />&nbsp;สัญชาติ
                        <asp:DropDownList ID="ddlNationCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbBloodCondition" runat="server" name="condition" />&nbsp;กรุ๊ปเลือด
                        <asp:DropDownList ID="ddlBloodCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>

                    <div class="ps-separator-black"></div>

                    <div>
                        <asp:CheckBox ID="cbEmailCondition" runat="server" name="condition" />&nbsp;อีเมล
                        <asp:textbox ID="tbEmailCondition" runat="server" CssClass="ps-textbox" placeholder="abcd1234@gmail.com"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbPhoneCondition" runat="server" name="condition" />&nbsp;เบอร์โทรศัพท์ส่วนตัว
                        <asp:textbox ID="tbPhoneCondition" runat="server" CssClass="ps-textbox" placeholder="081-234-5678"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbPhoneWorkCondition" runat="server" name="condition" />&nbsp;เบอร์โทรศัพท์ที่ทำงาน
                        <asp:textbox ID="tbPhoneWorkCondition" runat="server" CssClass="ps-textbox" placeholder="02-1234567"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbReligionCondition" runat="server" name="condition" />&nbsp;ศาสนา
                        <asp:DropDownList ID="ddlReligionCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbStatusCondition" runat="server" name="condition" />&nbsp;สถานภาพ
                        <asp:RadioButton ID="rbSingle" runat="server" GroupName="gStatus" Checked="true" />&nbsp;โสด
                        <asp:RadioButton ID="rbMarried" runat="server" GroupName="gStatus" />&nbsp;สมรส
                        <asp:RadioButton ID="rbLeftAlone" runat="server" GroupName="gStatus" />&nbsp;หม้าย
                        <asp:RadioButton ID="rbDivorced" runat="server" GroupName="gStatus" />&nbsp;หย่าร้าง
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNameFatherCondition" runat="server" name="condition" />&nbsp;ชื่อบิดา
                        <asp:textbox ID="tbFNFatherCondition" runat="server" CssClass="ps-textbox" placeholder="ชื่อบิดา"></asp:textbox>
                        <asp:textbox ID="tbLNFatherCondition" runat="server" CssClass="ps-textbox" placeholder="นามสกุลบิดา"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNameMotherCondition" runat="server" name="condition" />&nbsp;ชื่อมารดา
                        <asp:textbox ID="tbFNMotherCondition" runat="server" CssClass="ps-textbox" placeholder="ชื่อมารดา"></asp:textbox>
                        <asp:textbox ID="tbLNMotherCondition" runat="server" CssClass="ps-textbox" placeholder="นามสกุลมารดา"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbNameCoupleCondition" runat="server" name="condition" />&nbsp;ชื่อคู่สมรส
                        <asp:textbox ID="tbFNCoupleCondition" runat="server" CssClass="ps-textbox" placeholder="ชื่อคู่สมรส"></asp:textbox>
                        <asp:textbox ID="tbLNCoupleCondition" runat="server" CssClass="ps-textbox" placeholder="นามสกุลคู่สมรส"></asp:textbox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbAddressCondition" runat="server" name="condition" />&nbsp;ที่อยู่ตามทะเบียนบ้าน
                        <asp:CheckBox ID="cbAddressCondition2" runat="server" name="condition" />&nbsp;ที่อยู่ปัจจุบัน
                        <asp:DropDownList ID="ddlAddressProvinceCondition" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="ddlAddressAmphurCondition" runat="server" CssClass="ps-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="ddlAddressDistrictCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    
                    <div class="ps-separator-black"></div>

                    <div>
                        <asp:CheckBox ID="cbCampusCondition" runat="server" name="condition" />&nbsp;วิทยาเขต
                        <asp:DropDownList ID="ddlCampus" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlDivision" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbStafftypeCondition" runat="server" name="condition" />&nbsp;ประเภทบุคลากร
                        <asp:DropDownList ID="ddlStafftypeCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbBudgetCondition" runat="server" name="condition" />&nbsp;ประเภทเงินจ้าง
                        <asp:DropDownList ID="ddlBudgetCondition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbInworkDateCondition" runat="server" name="condition" />&nbsp;วันที่เข้าทำงาน
                        <asp:TextBox ID="tbInworkDateFrom" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                        <span style="color: #808080;">ถึง</span>
                        <asp:TextBox ID="tbInworkDateTo" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbRetireDateCondition" runat="server" name="condition" />&nbsp;วันที่เกษียณ
                        <asp:TextBox ID="tbRetireDateFrom" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                        <span style="color: #808080;">ถึง</span>
                        <asp:TextBox ID="tbRetireDateTo" runat="server" CssClass="ps-textbox" placeholder="01 ม.ค. 25xx"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbAgeCondition" runat="server" name="condition" />&nbsp;อายุ
                        <asp:TextBox ID="tbAgeConditionFrom" runat="server" Width="50" CssClass="ps-textbox" MaxLength="3" placeholder="20"></asp:TextBox>
                        <span style="color: #808080;">ถึง</span>
                        <asp:TextBox ID="tbAgeConditionTo" runat="server" Width="50" CssClass="ps-textbox" MaxLength="3" placeholder="30"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbStatusWorkCondition" runat="server" name="condition" />&nbsp;สถานะการทำงาน
                        <asp:DropDownList ID="ddlStatusWork" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
            </div>
            <div class="ps-separator"></div>
        </div>
        <div>
            <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>Export</asp:LinkButton>
        </div>
        <div style="overflow-x:auto; width:4600px">
            <asp:Table ID="tb" runat="server" CssClass="ps-table-1" Style="margin-top: 10px;"></asp:Table>
        </div>
    </div>
</asp:Content>
