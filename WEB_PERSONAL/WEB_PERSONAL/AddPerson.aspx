<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson.aspx.cs" Inherits="WEB_PERSONAL.AddPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            padding-right: 10px;
            vertical-align: top;
            text-align: right;
            color: #808080;
            height: 10px;
        }

        .auto-style2 {
            color: #000000;
            height: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ข้อมูลส่วนตัว
                </div>
                <table>
                    <tr>
                        <td class="col1">บัตรประชาชน</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCitizenID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="col1">คำนำหน้า</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTitle" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">ชื่อ</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="tbNameTH" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุล</td>
                        <td class="col2">
                            <asp:TextBox ID="tbLastNameTH" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อ อังกฤษ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbNameEN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุล อังกฤษ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbLastNameEN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เพศ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlGender" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันเกิด</td>
                        <td class="col2">
                            <asp:TextBox ID="tbBirthday" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เชื้อชาติ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlRace" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สัญชาติ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlNation" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กรุ๊ปเลือด</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTitle3" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">อีเมล</td>
                        <td class="col2">
                            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">โทรศัพท์มือถือ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">โทรศัพท์ที่ทำงาน</td>
                        <td class="col2">
                            <asp:TextBox ID="tbTelephone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ศาสนา</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlReligion" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สถานภาพ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlTitle5" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อบิดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลบิดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อมารดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดาเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherOldLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลคู่สมรสเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleOldLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:LinkButton ID="lbuV1Next" runat="server" OnClick="lbuV1Next_Click" CssClass="button button_default">ถัดไป</asp:LinkButton>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="float: left; display: inline-block; margin-right: 50px;">
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ตามทะเบียนบ้าน
                    </div>
                    <table>
                        <tr>
                            <td class="col1">บ้านเลขที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbHomeAdd" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ซอย</td>
                            <td class="col2">
                                <asp:TextBox ID="tbSoi" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">หมู่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbMoo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ถนน</td>
                            <td class="col2">
                                <asp:TextBox ID="tbRoad" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">จังหวัด</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">อำเภอ / เขต</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlAmphur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำบล / แขวง</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlDistrict" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รหัสไปรณีย์</td>
                            <td class="col2">
                                <asp:TextBox ID="tbZipcode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเทศ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlCountry" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รัฐ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbState" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left; display: inline-block;">
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ที่ติดต่อได้
                        
                    </div>

                    <asp:LinkButton ID="lbuAddressFetch" runat="server" CssClass="button button_default" OnClick="lbuAddressFetch_Click">ดึงข้อมูลข้างบน</asp:LinkButton>

                    <table>
                        <tr>
                            <td class="col1">บ้านเลขที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbHomeAdd2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ซอย</td>
                            <td class="col2">
                                <asp:TextBox ID="tbSoi2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">หมู่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbMoo2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ถนน</td>
                            <td class="col2">
                                <asp:TextBox ID="tbRoad2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">จังหวัด</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlProvince2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">อำเภอ / เขต</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlAmphur2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำบล / แขวง</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlDistrict2" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รหัสไปรณีย์</td>
                            <td class="col2">
                                <asp:TextBox ID="tbZipcode2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเทศ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlCountry2" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">รัฐ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbState2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="clear: both;">
                    <asp:LinkButton ID="lbuV2Back" runat="server" OnClick="lbuV2Back_Click" CssClass="button button_default">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV2Next" runat="server" CssClass="button button_default" OnClick="lbuV2Next_Click">ถัดไป</asp:LinkButton>
                </div>


            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ประวัติการศึกษา
                </div>

                <div style="display: inline-block;">ระดับการศึกษา<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ปีที่สำเร็จการศึกษา<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">คณะ<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ชื่อสถานศึกษา<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ชื่อประเทศที่จบ<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></div>
                <div style="display: inline-block;">ตั้งแต่เดือน<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ตั้งแต่ปี<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">จนถึงเดือน<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">จนถึงปี<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">วุฒิ<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">สาขาวิชาเอก<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></div>
                <asp:LinkButton ID="lbuV3Add" runat="server" OnClick="lbuV3Add_Click" CssClass="button button_default">+</asp:LinkButton>

                <div>
                    <asp:LinkButton ID="lbuV3Back" runat="server" CssClass="button button_default" OnClick="lbuV3Back_Click">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV3Next" runat="server" CssClass="button button_default" OnClick="lbuV3Next_Click">ถัดไป</asp:LinkButton>
                </div>

            </asp:View>
            <asp:View ID="View4" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ข้อมูลการทำงาน
                </div>
                <table>
                    <tr>
                        <td class="col1">วิทยาเขต</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สำนัก / สถาบัน / คณะ</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList4" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList5" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">งาน / ฝ่าย</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList8" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทบุคลากร</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList6" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทเงินจ้าง</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList7" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งบริหาร</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList9" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งในสายงาน</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList10" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งทางวิชาการ</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList11" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่เริ่มบรรจุ / เริ่มงาน</td>
                        <td class="col2">
                            <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ความเชี่ยวชาญในสายงาน</td>
                        <td class="col2">
                            <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กลุ่มสาขาวิชาที่สอน</td>
                        <td class="col2">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:LinkButton ID="lbuV4Back" runat="server" CssClass="button button_default" OnClick="lbuV4Back_Click">ย้อนกลับย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV4Next" runat="server" CssClass="button button_default" OnClick="lbuV4Next_Click">ถัดไป</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ใบอนุญาตประกอบวิชาชีพ
                </div>

                <div style="display: inline-block;">ชื่อใบอนุญาต<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">หน่วยงาน<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เลขที่ใบอนุญาต<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">วันที่มีผลบังคับใช้<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></div>
                <asp:LinkButton ID="lbuV5Add" runat="server" OnClick="lbuV5Add_Click" CssClass="button button_default">+</asp:LinkButton>

                <div>
                    <asp:LinkButton ID="lbuV5Back" runat="server" CssClass="button button_default" OnClick="lbuV5Back_Click">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV5Next" runat="server" CssClass="button button_default" OnClick="lbuV5Next_Click">ถัดไป</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ประวัติการฝึกอบรม
                </div>

                <div style="display: inline-block;">หลักสูตรฝึกอบรม<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ตั้งแต่<asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ถึง<asp:TextBox ID="TextBox18" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">หน่วยงานที่จัดฝึกอบรม<asp:TextBox ID="TextBox17" runat="server"></asp:TextBox></div>
                <asp:LinkButton ID="lbuV6Add" runat="server" OnClick="lbuV6Add_Click" CssClass="button button_default">+</asp:LinkButton>

                <div>
                    <asp:LinkButton ID="lbuV6Back" runat="server" CssClass="button button_default" OnClick="lbuV6Back_Click">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV6Next" runat="server" CssClass="button button_default" OnClick="lbuV6Next_Click">ถัดไป</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View7" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />การได้รับโทษทางวินัยและการนิรโทษกรรม
                </div>

                <div style="display: inline-block;">พ.ศ.<asp:TextBox ID="TextBox19" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">รายการ<asp:TextBox ID="TextBox22" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เอกสารอ้างอิง<asp:TextBox ID="TextBox23" runat="server"></asp:TextBox></div>
                <asp:LinkButton ID="lbuV7Add" runat="server" OnClick="lbuV7Add_Click" CssClass="button button_default">+</asp:LinkButton>

                <div>
                    <asp:LinkButton ID="lbuV7Back" runat="server" CssClass="button button_default" OnClick="lbuV7Back_Click">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV7Next" runat="server" CssClass="button button_default" OnClick="lbuV7Next_Click">ถัดไป</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View8" runat="server">
                <div class="default_header">
                    <img src="Image/Small/table.png" class="icon_left" />ตำแหน่งและเงินเดือน
                </div>

                <div style="display: inline-block;">วัน/เดือน/ปี<asp:TextBox ID="TextBox24" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ตำแหน่ง<asp:TextBox ID="TextBox25" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เลขที่ตำแหน่ง<asp:TextBox ID="TextBox26" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ตำแหน่งประเภท<asp:TextBox ID="TextBox27" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">ระดับ<asp:TextBox ID="TextBox28" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เงินเดือน<asp:TextBox ID="TextBox29" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เงินประจำตำแหน่ง<asp:TextBox ID="TextBox30" runat="server"></asp:TextBox></div>
                <div style="display: inline-block;">เอกสารอ้างอิง<asp:TextBox ID="TextBox31" runat="server"></asp:TextBox></div>
                <asp:LinkButton ID="lbuV8Add" runat="server" OnClick="lbuV8Add_Click" CssClass="button button_default">+</asp:LinkButton>

                <div>
                    <asp:LinkButton ID="lbuV8Back" runat="server" CssClass="button button_default" OnClick="lbuV8Back_Click">ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuV8Next" runat="server" CssClass="button button_default" OnClick="lbuV8Next_Click">ถัดไป</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View9" runat="server">

            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
