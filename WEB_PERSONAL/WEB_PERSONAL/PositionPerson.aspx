<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PositionPerson.aspx.cs" Inherits="WEB_PERSONAL.PositionPerson" %>
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
    <div class="default_page_style">
        <div id="notification" runat="server"></div>

        <div class="ps-header">
            <img src="Image/Small/person2.png" />จัดการตำแหน่งบุคลากร
        </div>

        <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato" DefaultButton="btnSearchPerson">
        <div>
            <fieldset>
                <legend class="TMZ">ค้นหาข้อมูล</legend>
                <div style="text-align: center">
                    รหัสบัตรประชาชน 13 หลัก :&nbsp<asp:TextBox ID="tbCitizenID" runat="server" CssClass="tb5" MaxLength="13"></asp:TextBox>
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

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend class="TMZ">การจัดการตำแหน่ง</legend>
                    <table>
                        <tr>
                            <td class="col1">ตำแหน่งประเภทบริหาร</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภทอำนวยการ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlDirectPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภทวิชาการ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlAcadPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่งประเภททั่วไป</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlGeneralPosition" runat="server" CssClass="tb5"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbuAddPosition" runat="server" OnClick="lbuAddPosition_Click" CssClass="ps-button">เพิ่มข้อมูลตำแหน่ง</asp:LinkButton></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewPosition" runat="server" Width="70%"></asp:GridView>
                </fieldset>
            </asp:View>

        </asp:MultiView>
    </div>
</asp:Content>
