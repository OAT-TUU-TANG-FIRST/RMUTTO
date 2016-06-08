﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPerson-Edit.aspx.cs" Inherits="WEB_PERSONAL.AddPerson_Edit" %>

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

        <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato" DefaultButton="btnSearchPerson">
            <div>
                <fieldset>
                    <legend class="TMZ">ค้นหา</legend>
                    <div style="text-align: center">
                        เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchPersonID" runat="server" CssClass="tb5" Width="230px" MaxLength="13"></asp:TextBox>
                        <asp:Button ID="btnSearchPerson" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPerson_Click" />
                    </div>
                </fieldset>
            </div>
        </asp:Panel>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend class="TMZ">(1/3)</legend>
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ข้อมูลส่วนตัว
                    </div>
                    <table>
                        <tr>
                            <td class="col1">บัตรประชาชน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCitizenID" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbCitizenID" runat="server" CssClass="tb5" Enabled="false" MaxLength="13"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbCitizenID" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">อีเมล</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbEmail" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbEmail" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbEmail" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">คำนำหน้า</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlTitle" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlTitle" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">โทรศัพท์มือถือ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbPhone" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbPhone" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbPhone" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbNameTH" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbNameTH" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbNameTH" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">โทรศัพท์ที่ทำงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbTelephone" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbTelephone" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbTelephone" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุล</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbLastNameTH" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbLastNameTH" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbLastNameTH" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">ชื่อบิดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbFatherName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbFatherName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbFatherName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อ อังกฤษ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbNameEN" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbNameEN" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbNameEN" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">นามสกุลบิดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbFatherLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbFatherLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbFatherLastName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุล อังกฤษ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbLastNameEN" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbLastNameEN" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbLastNameEN" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">ชื่อมารดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbMotherName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbMotherName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เพศ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlGender" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlGender" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">นามสกุลมารดา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbMotherLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbMotherLastName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">วันเกิด</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbBirthday" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbBirthday" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbBirthday" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">นามสกุลมารดาเดิม</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbMotherOldLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbMotherOldLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbMotherOldLastName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เชื้อชาติ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlRace" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlRace" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlRace" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">ชื่อคู่สมรส</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbCoupleName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbCoupleName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สัญชาติ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlNation" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNation" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlNation" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">นามสกุลคู่สมรส</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbCoupleLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbCoupleLastName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">กรุ๊ปเลือด</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlBlood" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBlood" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlBlood" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 20px"></td>
                            <td class="col1">นามสกุลคู่สมรสเดิม</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbCoupleOldLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbCoupleOldLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbCoupleOldLastName" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                            <td class="col1">ศาสนา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlReligion" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlReligion" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สถานภาพ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlStatus" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlStatus" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton ID="lbuV1Next" runat="server" OnClick="lbuV1Next_Click" CssClass="ps-button">ถัดไป</asp:LinkButton>
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
                                    <asp:UpdatePanel ID="UpdatetbHomeAdd" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbHomeAdd" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSoi" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbSoi" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbSoi" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbMoo" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbMoo" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbMoo" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbRoad" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbRoad" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbRoad" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlProvince" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlProvince" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlAmphur" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlAmphur" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAmphur" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlDistrict" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbZipcode" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbZipcode" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbZipcode" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlCountry" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="tb5"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlCountry" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbState" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbState" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbState" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                                    <asp:UpdatePanel ID="UpdatetbHomeAdd2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbHomeAdd2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbHomeAdd2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ซอย</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSoi2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbSoi2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbSoi2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbMoo2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbMoo2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbMoo2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbRoad2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbRoad2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbRoad2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlProvince2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlProvince2" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlProvince2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ / เขต</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlAmphur2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlAmphur2" runat="server" CssClass="tb5" AutoPostBack="True" OnSelectedIndexChanged="ddlAmphur2_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAmphur2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล / แขวง</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlDistrict2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDistrict2" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDistrict2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรณีย์</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbZipcode2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbZipcode2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbZipcode2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdateddlCountry2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlCountry2" runat="server" CssClass="tb5"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlCountry2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รัฐ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbState2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbState2" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbState2" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                    <div class="default_header">
                        <img src="Image/Small/table.png" class="icon_left" />ข้อมูลการทำงาน
                    </div>
                    <table>
                        <tr>
                            <td class="col1">วิทยาเขต</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlCampus" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCampus" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCampus" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สำนัก / สถาบัน / คณะ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlFaculty" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlFaculty" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlDivision" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDivision" runat="server" CssClass="tb5" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlDivision" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">งาน / ฝ่าย</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlWorkDivision" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlWorkDivision" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเภทบุคลากร</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlStaffType" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlStaffType" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเภทเงินจ้าง</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlBudget" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBudget" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlBudget" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งบริหาร</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlAdminPosition" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlAdminPosition" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งในสายงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlPositionWork" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPositionWork" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlPositionWork" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งทางวิชาการ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlAcademic" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAcademic" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlAcademic" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">วันที่บรรจุ</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbDateInwork" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbDateInwork" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbDateInwork" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ความเชี่ยวชาญในสายงาน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdatetbSpecialWork" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="tbSpecialWork" runat="server" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tbSpecialWork" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">กลุ่มสาขาวิชาที่สอน</td>
                            <td class="col2">
                                <asp:UpdatePanel ID="UpdateddlTeachISCED" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlTeachISCED" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:LinkButton ID="lbuV3Back" runat="server" CssClass="ps-button" OnClick="lbuV3Back_Click1">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbSubmit" runat="server" CssClass="ps-button" OnClick="lbSubmit_Click">อัพเดทข้อมูลบุคลากร</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>

        </asp:MultiView>
    </div>
</asp:Content>
