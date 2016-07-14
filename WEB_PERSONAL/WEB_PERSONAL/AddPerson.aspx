<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="WEB_PERSONAL.AddPerson" %>

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

        .textred {
            color: red;
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
    <div class="default_page_style">
        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend class="TMZ">(1/3)</legend>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ข้อมูลส่วนตัว
                        </div>
                        <table>
                            <tr>
                                <td class="col1">บัตรประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="tb5" MaxLength="13"></asp:TextBox>
                                    <asp:LinkButton ID="lbCheckUseCitizen" runat="server" CssClass="ps-button" OnClick="lbCheckUseCitizen_Click">ตรวจสอบรหัสบัตรประชาชน</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ยศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlRank" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คำนำหน้า</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbNameTH" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastNameTH" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ อังกฤษ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbNameEN" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล อังกฤษ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastNameEN" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เพศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันเกิด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthday" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ข้อมูลส่วนตัว
                        
                        </div>
                        <table>
                            <tr>
                                <td class="col1">อีเมล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">โทรศัพท์มือถือ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPhone" runat="server" CssClass="tb5" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">โทรศัพท์ที่ทำงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbTelephone" runat="server" CssClass="tb5" MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เชื้อชาติ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlRace" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สัญชาติ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlNation" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กรุ๊ปเลือด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlBlood" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ศาสนา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สถานภาพ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both;">
                        <asp:LinkButton ID="lbuV1Next" runat="server" OnClick="lbuV1Next_Click" CssClass="ps-button">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend class="TMZ">(2/3)</legend>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ตามทะเบียนบ้าน
                        </div>
                        <table>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSoi" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMoo" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRoad" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAmphur" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbZipcode" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbState" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ที่ติดต่อได้
                        
                        </div>
                        <table>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbHomeAdd2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSoi2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMoo2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRoad2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlProvince2" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAmphur2" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDistrict2" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbZipcode2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry2_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbState2" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both;">
                        <asp:LinkButton ID="lbuV2Back" runat="server" OnClick="lbuV2Back_Click" CssClass="ps-button">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV2Next" runat="server" CssClass="ps-button" OnClick="lbuV2Next_Click">ถัดไป</asp:LinkButton>
                        <asp:LinkButton ID="lbuAddressFetch" runat="server" CssClass="ps-button" OnClick="lbuAddressFetch_Click">ดึงข้อมูลที่อยู่ตามทะเบียนบ้าน</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>

            <asp:View ID="View3" runat="server">
                <fieldset>
                    <legend class="TMZ">(3/3)</legend>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ข้อมูลการทำงาน
                        </div>
                        <table>
                            <tr>
                                <td class="col1">วิทยาเขต</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlCampus" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สำนัก / สถาบัน / คณะ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">งาน / ฝ่าย</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทบุคลากร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทเงินจ้าง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlBudget" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่บรรจุ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbDateInwork" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินเดือน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSalary" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินประจำตำแหน่ง</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPositionSalary" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สถานะการทำงาน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStatusWork" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ข้อมูลการทำงาน
                        
                        </div>
                        <table>
                            <tr>
                                <td class="col1">ตำแหน่งประเภท</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTpyePosition" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่ง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งบริหาร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งในสายงาน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPositionWork" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งทางวิชาการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAcademic" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td class="col1">ความเชี่ยวชาญในสายงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSpecialWork" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กลุ่มสาขาวิชาที่สอน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับตำแหน่งประเภท</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigGover" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งระดับ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigDegree" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งกลุ่มพนักงานราชการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosiInsigEMP" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both;">
                        <asp:LinkButton ID="lbuV3Back" runat="server" CssClass="ps-button" OnClick="lbuV3Back_Click1">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbSubmit" runat="server" CssClass="ps-button" OnClick="lbSubmit_Click">เพิ่มข้อมูลบุคลากร</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>

        </asp:MultiView>
    </div>
</asp:Content>
