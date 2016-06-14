<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPersonGP7.aspx.cs" Inherits="WEB_PERSONAL.AddPersonGP7" %>

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

        .col3 {
            padding: 3px 5px;
            text-align: right;
            background-color: #f8f8f8;
            color: #404040;
        }

        .col4 {
            padding: 3px 5px;
            background-color: #ffffff;
            border-bottom: 1px solid #f0f0f0;
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

        .auto-style1 {
            display: inline-block;
            font-family: RB-Regular, Tahoma;
            font-weight: normal;
            font-size: 12px;
            text-decoration: none;
            border-radius: 4px;
            cursor: pointer;
            transition: color ease 0.25s, background-color ease 0.25s, border-color ease 0.25s;
            color: #000000;
            text-align: left;
            border-collapse: collapse;
            border-left: 1px solid #c0c0c0;
            border-right: 1px solid #c0c0c0;
            border-top: 1px solid #d0d0d0;
            border-bottom: 1px solid #b0b0b0;
            padding: 3px 15px;
            background-color: #ffffff;
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
    <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato" DefaultButton="btnSearchPerson">
        <div>
            <fieldset>
                <legend class="TMZ">ข้อมูลที่ค้นหา</legend>
                <div style="text-align: center">
                    รหัสบัตรประชาชนของผู้ที่จะเพิ่มข้อมูล :&nbsp<asp:TextBox ID="tbCitizenID" runat="server" CssClass="tb5" MaxLength="13"></asp:TextBox>
                    <asp:Button ID="btnSearchPerson" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPerson_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
                <div>
                    <table class="center1">
                        <tr>
                            <td class="col3">รหัสบัตรประชาชน</td>
                            <td class="col4">
                                <asp:Label ID="lblCitizenID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col3">ชื่อ - สกุล</td>
                            <td class="col4">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col3">ประเภทบุคลากร</td>
                            <td class="col4">
                                <asp:Label ID="lblStafftype" runat="server" Width="100px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col3">สังกัด/หน่วยงาน</td>
                            <td class="col4">
                                <asp:Label ID="lblUniversity" runat="server">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก > </asp:Label>
                                <asp:Label ID="lblCampus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col3">ตำแหน่งงาน</td>
                            <td class="col4">
                                <asp:Label ID="lblPosition" runat="server" Width="100px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col3">สถานะ</td>
                            <td class="col4">
                                <asp:Label ID="lblStatusPersonWork" runat="server" Width="100px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>

    <div class="default_page_style">
        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend class="TMZ">(1/5)</legend>
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
                                <asp:LinkButton ID="lbuV1Add" runat="server" OnClick="lbuV1Add_Click" CssClass="ps-button">เพิ่มข้อมูลประวัติการศึกษา</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewStudy" runat="server" Width="100%" Visible="false"></asp:GridView>
                    <asp:GridView ID="GridViewStudyShow" runat="server" Width="100%"></asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV1Next" runat="server" CssClass="ps-button" OnClick="lbuV1Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend class="TMZ">(2/5)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ใบอนุญาตประกอบวิชาชีพ
                    </div>
                    <table>
                        <tr>
                            <td class="col1">ชื่อใบอนุญาต</td>
                            <td class="col2">
                                <asp:TextBox ID="tbLicenseName11" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">หน่วยงาน</td>
                            <td class="col2">
                                <asp:TextBox ID="tbDepartment11" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เลขที่ใบอนุญาต</td>
                            <td class="col2">
                                <asp:TextBox ID="tbLicenseNo11" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">วันที่มีผลบังคับใช้ (วัน เดือน ปี)</td>
                            <td class="col2">
                                <asp:TextBox ID="tbUseDate11" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuV2Add" runat="server" OnClick="lbuV2Add_Click" CssClass="ps-button">เพิ่มข้อมูลใบอนุญาตประกอบวิชาชีพ</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewLicense" runat="server" Width="70%"></asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV2Back" runat="server" CssClass="ps-button" OnClick="lbuV2Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV2Next" runat="server" CssClass="ps-button" OnClick="lbuV2Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <fieldset>
                    <legend class="TMZ">(3/5)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ประวัติการฝึกอบรม
                    </div>
                    <table>
                        <tr>
                            <td class="col1">หลักสูตรฝึกอบรม</td>
                            <td class="col2">
                                <asp:TextBox ID="tbCourse" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlMonth12From" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear12From" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth12To" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear12To" runat="server" CssClass="tb5" Width="70px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">หน่วยงานที่จัดฝึกอบรม</td>
                            <td class="col2">
                                <asp:TextBox ID="tbDepartment" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuV3Add" runat="server" OnClick="lbuV3Add_Click" CssClass="ps-button">เพิ่มข้อมูลประวัติการฝึกอบรม</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewTraining" runat="server" Width="70%" Visible="false"></asp:GridView>
                    <asp:GridView ID="GridViewTrainingShow" runat="server" Width="70%"></asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV3Back" runat="server" CssClass="ps-button" OnClick="lbuV3Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV3Next" runat="server" CssClass="ps-button" OnClick="lbuV3Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <fieldset>
                    <legend class="TMZ">(4/5)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />การได้รับโทษทางวินัยและการนิรโทษกรรม
                    </div>
                    <table>
                        <tr>
                            <td class="col1">พ.ศ.</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlYear13" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รายการ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbName13" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เอกสารอ้างอิง</td>
                            <td class="col2">
                                <asp:TextBox ID="tbREF13" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuV4Add" runat="server" OnClick="lbuV4Add_Click" CssClass="ps-button">เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewDDA" runat="server" Width="70%"></asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV4Back" runat="server" CssClass="ps-button" OnClick="lbuV4Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV4Next" runat="server" CssClass="ps-button" OnClick="lbuV4Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <fieldset>
                    <legend class="TMZ">(5/5)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ตำแหน่งและเงินเดือน
                    </div>
                    <table>
                        <tr>
                            <td class="col1">วัน เดือน ปี</td>
                            <td class="col2">
                                <asp:TextBox ID="tbDate14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่ง</td>
                            <td class="col2">
                                <asp:TextBox ID="tbPosition14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เลขที่ตำแหน่ง</td>
                            <td class="col2">
                                <asp:TextBox ID="tbPositionNo14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภท</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlPositionType14" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlPositionType14_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ระดับ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlPositionDegree14" runat="server" CssClass="tb5" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เงินเดือน</td>
                            <td class="col2">
                                <asp:TextBox ID="tbSalary14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เงินประจำตำแหน่ง</td>
                            <td class="col2">
                                <asp:TextBox ID="tbSalaryPosition14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รายการ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbRef14" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuV5Add" runat="server" OnClick="lbuV5Add_Click" CssClass="ps-button">เพิ่มข้อมูลตำแหน่งและเงินเดือน</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewPAS" runat="server" Width="100%" Visible="false"></asp:GridView>
                    <asp:GridView ID="GridViewPASShow" runat="server" Width="100%"></asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV5Back" runat="server" CssClass="ps-button" OnClick="lbuV5Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbSubmit" runat="server" CssClass="auto-style1" OnClick="lbSubmit_Click">เพิ่มข้อมูลทะเบียนประวัติบุคลากร(ก.พ.7)</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
