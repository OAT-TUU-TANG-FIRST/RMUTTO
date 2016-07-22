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

        <div class="ps-header"><img src="Image/Small/person2.png" />เพิ่มข้อมูลบุคลากร</div>

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div style="text-align: center;">
                    <div class="ps-div-title-red">ข้อมูลพื้นฐาน</div>
                    <div style="display: inline-block; margin-right: 50px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">บัตรประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox>
                                    <asp:LinkButton ID="lbCheckUseCitizen" runat="server" CssClass="ps-button" OnClick="lbCheckUseCitizen_Click">ตรวจสอบรหัสบัตรประชาชน</asp:LinkButton>
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
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbSubmit" runat="server" CssClass="ps-button" OnClick="lbSubmit_Click"><img src="Image/Small/save.png" class="icon_left"/>เพิ่มข้อมูลบุคลากร</asp:LinkButton>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                สำเร็จ
            </asp:View>
        </asp:MultiView>
        
        <div class="ps-separator"></div>
    </div>
</asp:Content>
