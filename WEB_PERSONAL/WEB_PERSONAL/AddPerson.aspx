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

        .TMZ {
            font-family: tahoma;
            text-align: left;
            color: #9999ff;
            font-weight: 900;
        }

        fieldset {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: black;
            font-size: 90%;
            text-align: left;
        }

        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: left;
        }
    </style>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbUseDate11,#ContentPlaceHolder1_tbDate14").datepicker($.datepicker.regional["th"]);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend class="TMZ">(1/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ข้อมูลส่วนตัว
                    </div>
                    <table>
                        <tr>
                            <td class="col1">บัตรประชาชน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCitizenID" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbCitizenID" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbCitizenID" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">คำนำหน้า</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlTitle" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlTitle" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlTitle" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">ชื่อ</td>
                            <td class="auto-style2">
                                <asp:UpdatePanel ID="UpdatetbNameTH" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbNameTH" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbNameTH" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุล</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbLastNameTH" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbLastNameTH" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbLastNameTH" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อ อังกฤษ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbNameEN" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbNameEN" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbNameEN" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุล อังกฤษ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbLastNameEN" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbLastNameEN" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbLastNameEN" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">เพศ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlGender" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlGender" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">วันเกิด</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbBirthday" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbBirthday" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbBirthday" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">เชื้อชาติ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlRace" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlRace" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlRace" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">สัญชาติ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlNation" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlNation" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlNation" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">กรุ๊ปเลือด</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlBlood" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlBlood" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlBlood" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">อีเมล</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbEmail" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbEmail" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">โทรศัพท์มือถือ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbPhone" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbPhone" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">โทรศัพท์ที่ทำงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbTelephone" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbTelephone" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbTelephone" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ศาสนา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlReligion" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlReligion" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlReligion" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">สถานภาพ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlStatus" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlStatus" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อบิดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbFatherName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbFatherName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbFatherName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุลบิดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbFatherLastName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbFatherLastName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbFatherLastName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อมารดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbMotherName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMotherName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุลมารดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherLastName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbMotherLastName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMotherLastName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุลมารดาเดิม</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherOldLastName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbMotherOldLastName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMotherOldLastName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อคู่สมรส</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbCoupleName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbCoupleName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุลคู่สมรส</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleLastName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbCoupleLastName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbCoupleLastName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุลคู่สมรสเดิม</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleOldLastName" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbCoupleOldLastName" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbCoupleOldLastName" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                    </table>
                    <asp:LinkButton ID="lbuV1Next" runat="server" OnClick="lbuV1Next_Click" CssClass="button button_default">ถัดไป</asp:LinkButton>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend class="TMZ">(2/8)</legend>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <div class="default_header">
                            <img src="Image/Small/table.png" class="icon_left" />ที่อยู่ตามทะเบียนบ้าน
                        </div>
                        <table>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbHomeAdd" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbHomeAdd" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbHomeAdd" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSoi" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbSoi" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbSoi" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbMoo" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbMoo" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMoo" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbRoad" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbRoad" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbRoad" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlProvince" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlProvince" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlAmphur" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlAmphur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlAmphur" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlDistrict" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlDistrict" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbZipcode" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbZipcode" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbZipcode" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlCountry" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlCountry" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbState" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbState" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbState" /></Triggers></asp:UpdatePanel></td>
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
                                    <asp:UpdatePanel ID="UpdatetbHomeAdd2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbHomeAdd2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbHomeAdd2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSoi2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbSoi2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbSoi2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbMoo2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbMoo2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMoo2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbRoad2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbRoad2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbRoad2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlProvince2" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlProvince2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlProvince2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlAmphur2" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlAmphur2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur2_SelectedIndexChanged"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlAmphur2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlDistrict2" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlDistrict2" runat="server" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlDistrict2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbZipcode2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbZipcode2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbZipcode2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlCountry2" runat="server"><ContentTemplate>
                                    <asp:DropDownList ID="ddlCountry2" runat="server"></asp:DropDownList>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlCountry2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbState2" runat="server"><ContentTemplate>
                                    <asp:TextBox ID="tbState2" runat="server"></asp:TextBox>
                                    </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbState2" /></Triggers></asp:UpdatePanel></td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both;">
                        <asp:LinkButton ID="lbuV2Back" runat="server" OnClick="lbuV2Back_Click" CssClass="button button_default">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV2Next" runat="server" CssClass="button button_default" OnClick="lbuV2Next_Click">ถัดไป</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbuAddressFetch" runat="server" CssClass="button button_default" OnClick="lbuAddressFetch_Click">ดึงข้อมูลที่อยู่ตามทะเบียนบ้าน</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <fieldset>
                    <legend class="TMZ">(3/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ประวัติการศึกษา
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">ระดับการศึกษา</td>
                            <td style="text-align: center; margin-right: 5px;">สถานศึกษา</td>
                            <td style="text-align: center; margin-right: 5px; width: 300px">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td style="text-align: center; margin-right: 5px;">วุฒิ</td>
                            <td style="text-align: center; margin-right: 5px;">สาขาวิชาเอก</td>
                            <td style="text-align: center; margin-right: 5px;">ประเทศที่จบ</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateddlDegree10" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlDegree10" runat="server" Width="200"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlDegree10" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbUnivName10" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbUnivName10" runat="server" Width="180px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbUnivName10" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdateddlMonth10From" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlMonth10From" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear10From" runat="server" CssClass="tb5" Width="65"></asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth10To" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear10To" runat="server" CssClass="tb5" Width="65px"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlMonth10From" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbQualification10" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbQualification10" runat="server" Width="180px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbQualification10" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbMajor10" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbMajor10" runat="server" Width="180px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbMajor10" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbddlCountrySuccess10" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlCountrySuccess10" runat="server" Width="180px"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlCountrySuccess10" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: right; margin-right: 5px;">
                                
                                <asp:LinkButton ID="lbuV3Add" runat="server" OnClick="lbuV3Add_Click" CssClass="button button_default">+</asp:LinkButton></td>
                                
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridViewStudy" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewStudy" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewStudy" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div>
                        <asp:LinkButton ID="lbuV3Back" runat="server" CssClass="button button_default" OnClick="lbuV3Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV3Next" runat="server" CssClass="button button_default" OnClick="lbuV3Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <fieldset>
                    <legend class="TMZ">(4/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ข้อมูลการทำงาน
                    </div>
                    <table>
                        <tr>
                            <td class="col1">วิทยาเขต</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlCampus" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlCampus" runat="server" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlCampus" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">สำนัก / สถาบัน / คณะ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlFaculty" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlFaculty" runat="server" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlFaculty" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlDivision" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlDivision" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlDivision" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">งาน / ฝ่าย</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlWorkDivision" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlWorkDivision" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlWorkDivision" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ประเภทบุคลากร</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlStaffType" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlStaffType" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlStaffType" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ประเภทเงินจ้าง</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlBudget" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlBudget" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlBudget" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งบริหาร</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlAdminPosition" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlAdminPosition" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlAdminPosition" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งในสายงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlPositionWork" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlPositionWork" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlPositionWork" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งทางวิชาการ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlAcademic" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlAcademic" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlAcademic" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">วันที่เริ่มบรรจุ / เริ่มงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbDateInwork" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbDateInwork" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbDateInwork" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">ความเชี่ยวชาญในสายงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbSpecialWork" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbSpecialWork" runat="server"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbSpecialWork" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                        <tr>
                            <td class="col1">กลุ่มสาขาวิชาที่สอน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlTeachISCED" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlTeachISCED" runat="server"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlTeachISCED" /></Triggers></asp:UpdatePanel></td>
                        </tr>
                    </table>
                    <div>
                        <asp:LinkButton ID="lbuV4Back" runat="server" CssClass="button button_default" OnClick="lbuV4Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV4Next" runat="server" CssClass="button button_default" OnClick="lbuV4Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <fieldset>
                    <legend class="TMZ">(5/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ใบอนุญาตประกอบวิชาชีพ
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">ชื่อใบอนุญาต</td>
                            <td style="text-align: center; margin-right: 5px;">หน่วยงาน</td>
                            <td style="text-align: center; margin-right: 5px;">เลขที่ใบอนุญาต</td>
                            <td style="text-align: center; margin-right: 5px;">วันที่มีผลบังคับใช้ (วัน เดือน ปี)</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbLicenseName11" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbLicenseName11" runat="server" Width="200px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbLicenseName11" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbDepartment11" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbDepartment11" runat="server" Width="200px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbDepartment11" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbLicenseNo11" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbLicenseNo11" runat="server" Width="200px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbLicenseNo11" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetbUseDate11" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbUseDate11" runat="server" Width="200px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbUseDate11" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: right; margin-right: 5px;">
                                
                                <asp:LinkButton ID="lbuV5Add" runat="server" OnClick="lbuV5Add_Click" CssClass="button button_default">+</asp:LinkButton></td>
                                
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridViewLicense" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewLicense" runat="server" Width="70%"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewLicense" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div>
                        <asp:LinkButton ID="lbuV5Back" runat="server" CssClass="button button_default" OnClick="lbuV5Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV5Next" runat="server" CssClass="button button_default" OnClick="lbuV5Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <fieldset>
                    <legend class="TMZ">(6/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ประวัติการฝึกอบรม
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">หลักสูตรฝึกอบรม</td>
                            <td style="text-align: center; margin-right: 5px; width: 300px">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td style="text-align: center; margin-right: 5px;">หน่วยงานที่จัดฝึกอบรม</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbCourse" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbCourse" runat="server" Width="200px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbCourse" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="Updatel2" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlMonth12From" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear12From" runat="server" CssClass="tb5" Width="65"></asp:DropDownList>
                                <asp:DropDownList ID="ddlMonth12To" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                <asp:DropDownList ID="ddlYear12To" runat="server" CssClass="tb5" Width="65px"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlMonth12From" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbDepartment" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbDepartment" runat="server" Width="290px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbDepartment" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: right; margin-right: 5px;">
                                
                                <asp:LinkButton ID="lbuV6Add" runat="server" OnClick="lbuV6Add_Click" CssClass="button button_default">+</asp:LinkButton></td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridViewTraining" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewTraining" runat="server" Width="70%"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewTraining" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div>
                        <asp:LinkButton ID="lbuV6Back" runat="server" CssClass="button button_default" OnClick="lbuV6Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV6Next" runat="server" CssClass="button button_default" OnClick="lbuV6Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View7" runat="server">
                <fieldset>
                    <legend class="TMZ">(7/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />การได้รับโทษทางวินัยและการนิรโทษกรรม
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">พ.ศ.</td>
                            <td style="text-align: center; margin-right: 5px; width: 500px">รายการ</td>
                            <td style="text-align: center; margin-right: 5px;">เอกสารอ้างอิง</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 100px;">
                                <asp:UpdatePanel ID="UpdateddlYear13" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlYear13" runat="server" CssClass="tb5" Width="100px"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlYear13" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdatetbName13" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbName13" runat="server" Width="575px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbName13" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetbREF13" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbREF13" runat="server" Width="220px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbREF13" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: right; margin-right: 5px;">

                                <asp:LinkButton ID="lbuV7Add" runat="server" OnClick="lbuV7Add_Click" CssClass="button button_default">+</asp:LinkButton></td>

                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridViewDDA" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewDDA" runat="server" Width="70%"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewDDA" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div>
                        <asp:LinkButton ID="lbuV7Back" runat="server" CssClass="button button_default" OnClick="lbuV7Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuV7Next" runat="server" CssClass="button button_default" OnClick="lbuV7Next_Click">ถัดไป</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
            <asp:View ID="View8" runat="server">
                <fieldset>
                    <legend class="TMZ">(8/8)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ตำแหน่งและเงินเดือน
                    </div>

                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">วัน เดือน ปี</td>
                            <td style="text-align: center; margin-right: 5px;">ตำแหน่ง</td>
                            <td style="text-align: center; margin-right: 5px;">เลขที่ตำแหน่ง</td>
                            <td style="text-align: center; margin-right: 5px;">ตำแหน่งประเภท</td>
                            <td style="text-align: center; margin-right: 5px;">ระดับ</td>
                            <td style="text-align: center; margin-right: 5px;">เงินเดือน</td>
                            <td style="text-align: center; margin-right: 5px;">เงินประจำตำแหน่ง</td>
                            <td style="text-align: center; margin-right: 5px;">เอกสารอ้างอิง</td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdatetbDate14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbDate14" runat="server" Width="120px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbDate14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetbPosition14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbPosition14" runat="server" Width="280" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbPosition14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetbPositionNo14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbPositionNo14" runat="server" Width="80px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbPositionNo14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdateddlPositionType14" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlPositionType14" runat="server" CssClass="tb5" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlPositionType14_SelectedIndexChanged"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlPositionType14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdateddlPositionDegree14" runat="server"><ContentTemplate>
                                <asp:DropDownList ID="ddlPositionDegree14" runat="server" CssClass="tb5" Width="150px" AutoPostBack="True"></asp:DropDownList>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="ddlPositionDegree14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetbSalary14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbSalary14" runat="server" Width="80px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbSalary14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetbSalaryPosition14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbSalaryPosition14" runat="server" Width="80px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbSalaryPosition14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetbRef14" runat="server"><ContentTemplate>
                                <asp:TextBox ID="tbRef14" runat="server" Width="210px" CssClass="tb5"></asp:TextBox>
                                </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="tbRef14" /></Triggers></asp:UpdatePanel></td>
                            <td style="text-align: right; margin-right: 5px;"> 

                                <asp:LinkButton ID="lbuV8Add" runat="server" OnClick="lbuV8Add_Click" CssClass="button button_default">+</asp:LinkButton></td>

                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridViewPAS" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewPAS" runat="server" Width="100%"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewPAS" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div>
                        <asp:LinkButton ID="lbuV8Back" runat="server" CssClass="button button_default" OnClick="lbuV8Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbSubmit" runat="server" CssClass="button button_default" OnClick="lbSubmit_Click">ยืนยันการเพิ่มข้อมูลบุคลากร</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
