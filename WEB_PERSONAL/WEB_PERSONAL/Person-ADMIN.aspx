<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Person-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Person_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtBirthDayNumber,#ContentPlaceHolder1_txtDateInWork,#ContentPlaceHolder1_txtAge60Number,#ContentPlaceHolder1_txtDateEnable11,#ContentPlaceHolder1_txtDate14").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
            $('document').ready(function () {
                $(".date").datepicker($.datepicker.regional["th"]);
            });
        };
    </script>
    <style type="text/CSS">
        .ui-datepicker {
            font-family: tahoma;
            text-align: center;
            color: dodgerblue;
        }

        .multext {
            resize: none;
        }

        .a1 {
            border-radius: 20px;
            padding: 5px 10px;
            background-color: #00ff21;
            text-decoration: none;
            color: black;
        }

        body {
            background-image: url("Image/444.png");
        }

        .tb5 {
            background-image: url(images/form_bg.jpg);
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
            width: 230px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }

        .textred {
            color: red;
        }

        .divpan {
            text-align: center;
        }
    </style>
    <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchPerson">
        <div>
            <fieldset>
                <legend>ค้นหา</legend>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                   
                            เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchPersonID" runat="server" CssClass="tb5" Width="230px" MaxLength="13"></asp:TextBox>
                            <asp:Button ID="btnSearchPerson" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPerson_Click" />
                        
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1_1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend style="margin-left: auto; margin-right: auto; text-align: center;">ข้อมูลส่วนตัว</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">เลขบัตรประจำตัวประชาชน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">บ้านเลขที่</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ชื่อบิดา</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtCitizen" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCitizen" runat="server" MaxLength="13" Width="275px" CssClass="tb5" placeholder="รหัสประจำตัวประชาชน 13 หลัก"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtHOMEADD" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtHOMEADD" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="บ้านเลขที่"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtFatherName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFatherName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ชื่อบิดา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">วิทยาเขต</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">หมู่</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุลบิดา</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownCampus" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownCampus" runat="server" AutoPostBack="True" CssClass="tb5" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMOO" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMOO" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="หมู่"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtFatherLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFatherLastName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุลบิดา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">คณะ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ถนน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ชื่อมารดา</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownFaculty" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownFaculty" AutoPostBack="True" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtSTREET" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSTREET" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ถนน"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMotherName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMotherName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ชื่อมารดา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">กระทรวง</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">จังหวัด</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุลมารดา</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownMinistry" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownMinistry" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateddlPROVINCE" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPROVINCE" runat="server" AutoPostBack="True" CssClass="tb5" OnSelectedIndexChanged="ddlPROVINCE_SelectedIndexChanged" Width="283px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlPROVINCE" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMotherLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMotherLastName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุลมารดา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">กรม</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">อำเภอ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุลมารดาเดิม</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtDepart" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDepart" runat="server" MaxLength="100" Width="275px" CssClass="tb5">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateddlAMPHUR" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAMPHUR" runat="server" AutoPostBack="True" CssClass="tb5" OnSelectedIndexChanged="ddlAMPHUR_SelectedIndexChanged" Width="283px">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlAMPHUR" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMotherLastNameOld" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMotherLastNameOld" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุลมารดาเดิม"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">คำนำหน้านาม</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ตำบล</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ชื่อคู่สมรส</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownTitle" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownTitle" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateddlDISTRICT" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDISTRICT" runat="server" OnSelectedIndexChanged="ddlDISTRICT_SelectedIndexChanged" Width="283px" AutoPostBack="True" CssClass="tb5"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlDISTRICT" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMarriedName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMarriedName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ชื่อคู่สมรส"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ชื่อ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">รหัสไปรษณีย์</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุลคู่สมรส</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ชื่อ"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtZIPCODE" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtZIPCODE" runat="server" MaxLength="5" Width="275px" CssClass="tb5" AutoPostBack="True" placeholder="รหัสไปรษณีย์"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMarriedLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMarriedLastName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุลคู่สมรส"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุล</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">หมายเลขโทรศัพท์ที่ทำงาน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">นามสกุลเดิมคู่สมรสเดิม</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtLastName" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุล"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtTELEPHONE" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtTELEPHONE" runat="server" MaxLength="20" Width="275px" CssClass="tb5" AutoPostBack="True" placeholder="ตัวอย่าง(0-2456-5789) ต่อ 2240"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMarriedLastNameOld" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMarriedLastNameOld" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="นามสกุลคู่สมรสเดิม"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">วันที่บรรจุ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">เพศ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">สัญชาติ</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 290px;">
                                <asp:UpdatePanel ID="UpdatetxtDateInWork" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateInWork" runat="server" MaxLength="12" Width="240px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownGENDER" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownGENDER" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList></td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownNATION" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownNATION" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList></td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">วัน เดือน ปีเกิด</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">วันครบเกษียณอายุ</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 290px;">
                                <asp:UpdatePanel ID="UpdateUpdatetxtBirthDayNumber" runat="server">
                                    <ContentTemplate>
                                        <asp:UpdatePanel ID="UpdatetxtBirthDayNumber" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtBirthDayNumber" runat="server" AutoPostBack="True" CssClass="tb5" MaxLength="12" OnTextChanged="txtBirthDayNumber_TextChanged" Width="240px"></asp:TextBox>
                                                <asp:TextBox ID="txtBirthDayChar" runat="server" CssClass="tb5" MaxLength="100" Width="300px"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtBirthDayNumber" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 6px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtAge60Number" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAge60Number" runat="server" MaxLength="12" Width="240px" CssClass="tb5" OnTextChanged="txtAge60Number_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        <asp:TextBox ID="txtAge60Char" runat="server" MaxLength="13" Width="300px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtAge60Number" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>


                </div>
            </fieldset>
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel1_2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend style="margin-left: auto; margin-right: auto; text-align: center;">ข้อมูลการงาน</legend>
                <div>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ประเภทข้าราชการ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ตำแหน่งบริหาร</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">กลุ่มสาขาวิชาที่จบสูงสุด</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownStaffType" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownStaffType" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownADMIN_POSITION" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownADMIN_POSITION" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownGRAD_ISCED" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownGRAD_ISCED" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ระยะเวลาจ้าง</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ตำแหน่งในสายงาน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">สาขาวิชาที่จบสูงสุด</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownTIME_CONTACT" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownTIME_CONTACT" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList></td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownPOSITION_WORK" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownPOSITION_WORK" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownGRAD_PROG" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownGRAD_PROG" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ประเภทเงินจ้าง</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">สาขางานที่เชี่ยวชาญ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownBUDGET" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownBUDGET" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList></td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtSPECIAL_NAME" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSPECIAL_NAME" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ตัวอย่าง ความปลอดภัยและประสิทธิภาพของยา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtGRAD_UNIVDown" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtGRAD_UNIVDown" runat="server" MaxLength="100" Width="275px" CssClass="tb5" placeholder="ชื่อสถาบันที่จบการศึกษาสูงสุด"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ประเภทบุคลากรย่อย</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">กลุ่มสาขาวิชาที่สอน(ISCED) </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 220px">ประเทศที่จบการศึกษาสูงสุด</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownSUBSTAFFTYPE" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownSUBSTAFFTYPE" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownTEACH_ISCED" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownTEACH_ISCED" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdateDropDownGRAD_COUNTRY" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownGRAD_COUNTRY" runat="server" CssClass="tb5" Width="283px"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px; width: 285px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ระดับการศึกษาที่จบสูงสุด&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; หลักสูตรที่จบการศึกษาสูงสุด</td>

                        </tr>

                        <tr>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 1030px;">
                                <asp:UpdatePanel ID="UpdateDropDownGRAD_LEV" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownGRAD_LEV" runat="server" CssClass="tb5" Width="440px"></asp:DropDownList>
                                        <asp:TextBox ID="txtGRAD_CURR" runat="server" MaxLength="100" Width="440px" CssClass="tb5" placeholder="ชื่อหลักสูตร/ชื่อสาขา"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlusLEV" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlusLEV" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlusLEV_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlusLEV" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <table>

                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 890px;">
                                <asp:UpdatePanel ID="UpdateGridView6" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView6" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                            AutoGenerateColumns="false"
                                            AllowPaging="true"
                                            DataKeyNames="STUDY_GRADUATE_TOP_ID"
                                            OnRowEditing="modEditCommand6"
                                            OnRowCancelingEdit="modCancelCommand6"
                                            OnRowUpdating="modUpdateCommand6"
                                            OnRowDeleting="modDeleteCommand6"
                                            OnRowDataBound="GridView6_RowDataBound6"
                                            OnPageIndexChanging="myGridViewPersonStudyTop_PageIndexChanging6" PageSize="10" BackColor="White" BorderColor="#999999">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPersonStudyTopID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.STUDY_GRADUATE_TOP_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPersonStudyTopCitizen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ระดับการศึกษาที่จบสูงสุด" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPersonStudyTopLevEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_LEV_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddl_Lev" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="หลักสูตรที่จบการศึกษาสูงสุด" ControlStyle-Width="505" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPersonStudyTopGradCurrEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_CURR") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPersonStudyTopGradCurrEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_CURR") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                                <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteButton6" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView6" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend>ประวัติการศึกษา</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">สถานศึกษา</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px; width: 500px">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px;">วุฒิ(สาขาวิชาเอก)</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtGrad_Univ" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtGrad_Univ" runat="server" MaxLength="100" Width="290px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtGrad_Univ" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdateDropDownMonth10From" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownMonth10From" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownYear10From" runat="server" CssClass="tb5" Width="65"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownMonth10To" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownYear10To" runat="server" CssClass="tb5" Width="65px"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownMonth10From" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtMajor" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMajor" runat="server" MaxLength="100" Width="290px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtMajor" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlus10" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlus10" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlus10_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlus10" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridView1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                DataKeyNames="ID"
                                OnRowEditing="modEditCommand1"
                                OnRowCancelingEdit="modCancelCommand1"
                                OnRowUpdating="modUpdateCommand1"
                                OnRowDeleting="modDeleteCommand1"
                                OnRowDataBound="GridView1_RowDataBound1"
                                OnPageIndexChanging="myGridViewPersonStudyHistory_PageIndexChanging1" PageSize="10" BackColor="White" BorderColor="#999999">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="สถานศึกษา" ControlStyle-Width="290" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryGradUNIVEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_UNIV") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonStudyHistoryGradUNIVEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_UNIV") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMonthFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_101" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryYearFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_102" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMonthTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_103" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryYearTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_104" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วุฒิ(สาขาวิชาเอก)" ControlStyle-Width="255" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMajorEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MAJOR") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonStudyHistoryMajorEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MAJOR") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend>ใบอนุญาตประกอบวิชาชีพ</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">สถานศึกษา</td>
                            <td style="text-align: center; margin-right: 5px;">หน่วยงาน</td>
                            <td style="text-align: center; margin-right: 5px;">เลขที่ใบอนุญาต</td>
                            <td style="text-align: center; margin-right: 5px;">วันที่มีผลบังคับใช้ (วัน เดือน ปี)</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtGrad_Univ11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtGrad_Univ11" runat="server" MaxLength="100" Width="290px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtGrad_Univ11" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtDepart11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDepart11" runat="server" MaxLength="100" Width="250px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDepart11" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtNolicense11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtNolicense11" runat="server" MaxLength="100" Width="155px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtNolicense11" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetxtDateEnable11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateEnable11" runat="server" MaxLength="100" Width="160" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDateEnable11" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlus11" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlus11" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlus11_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlus11" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridView2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                DataKeyNames="ID"
                                OnRowEditing="modEditCommand2"
                                OnRowCancelingEdit="modCancelCommand2"
                                OnRowUpdating="modUpdateCommand2"
                                OnRowDeleting="modDeleteCommand2"
                                OnRowDataBound="GridView2_RowDataBound2"
                                OnPageIndexChanging="myGridViewPersonJobLisence_PageIndexChanging2" PageSize="10" BackColor="White" BorderColor="#999999">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="สถานศึกษา" ControlStyle-Width="280" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หน่วยงาน" ControlStyle-Width="170" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceBranchEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceBranchEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่ใบอนุญาติ" ControlStyle-Width="160" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceLicenseNOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceLicenseNOEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NO") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วันที่มีผลบังคับใช้ (วัน เดือน ปี)" ItemStyle-Width="120" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceDDATEEdit" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceDDATEEdit" CssClass="date" MaxLength="120" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton2" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView2" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend>ประวัติการฝึกอบรม</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">หลักสูตรฝึกอบรม</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px; width: 500px">ตั้งแต่ - ถึง (เดือน ปี)</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px;">หน่วยงานที่จัดฝึกอบรม</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtCourse" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCourse" runat="server" MaxLength="100" Width="290px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtCourse" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdateDropDownMonth11From" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownMonth12From" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownYear12From" runat="server" CssClass="tb5" Width="65"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownMonth12To" runat="server" CssClass="tb5" Width="80px"></asp:DropDownList>
                                        <asp:DropDownList ID="DropDownYear12To" runat="server" CssClass="tb5" Width="65px"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownMonth12From" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtBranchTrainning" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtBranchTrainning" runat="server" MaxLength="100" Width="290px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtBranchTrainning" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlus12" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlus12" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlus12_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlus12" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridView3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView3" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                DataKeyNames="ID"
                                OnRowEditing="modEditCommand3"
                                OnRowCancelingEdit="modCancelCommand3"
                                OnRowUpdating="modUpdateCommand3"
                                OnRowDeleting="modDeleteCommand3"
                                OnRowDataBound="GridView3_RowDataBound3"
                                OnPageIndexChanging="myGridViewPersonTraining_PageIndexChanging3" PageSize="10" BackColor="White" BorderColor="#999999">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หลักสูตรฝึกอบรม" ControlStyle-Width="290" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingCourseEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COURSE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonTrainingCourseEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COURSE") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingMonthFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_301" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingYearFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_302" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingMonthTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_303" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingYearTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_304" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หน่วยงานที่จัดฝึกอบรม" ControlStyle-Width="255" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingBranchEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH_TRAINING") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonTrainingBranchEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH_TRAINING") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton3" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView3" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend>การได้รับโทษทางวินัยและการนิรโทษกรรม</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: center; margin-right: 5px;">พ.ศ.</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px; width: 500px">รายการ</td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: center; margin-right: 5px;">เอกสารอ้างอิง</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 100px;">
                                <asp:UpdatePanel ID="UpdateDropDownYear13" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownYear13" runat="server" CssClass="tb5" Width="100px"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownYear13" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left;">
                                <asp:UpdatePanel ID="UpdatetxtList13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtList13" runat="server" MaxLength="100" Width="575px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtList13" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatetxtRefDoc13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRefDoc13" runat="server" MaxLength="100" Width="220px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtRefDoc13" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlus13" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlus13" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlus13_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlus13" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridView4" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView4" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                DataKeyNames="ID"
                                OnRowEditing="modEditCommand4"
                                OnRowCancelingEdit="modCancelCommand4"
                                OnRowUpdating="modUpdateCommand4"
                                OnRowDeleting="modDeleteCommand4"
                                OnRowDataBound="GridView4_RowDataBound4"
                                OnPageIndexChanging="myGridViewPersonDISCIPLINARY_PageIndexChanging4" PageSize="10" BackColor="White" BorderColor="#999999">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="พ.ศ." ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYYearEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_401" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รายการ" ControlStyle-Width="505" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYListEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MENU") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonDISCIPLINARYListEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MENU") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="210" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYRefEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonDISCIPLINARYRefEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton4" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView4" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel6" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPerson">
        <div>
            <fieldset>
                <legend>ตำแหน่งและเงินเดือน</legend>
                <div>
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
                                <asp:UpdatePanel ID="UpdatetxtDate14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDate14" runat="server" MaxLength="50" Width="90px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDate14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtPosition14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPosition14" runat="server" MaxLength="100" Width="280" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtPosition14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtNo_Position14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtNo_Position14" runat="server" MaxLength="100" Width="52px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtNo_Position14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdateDropDownType_Position14" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownType_Position14" runat="server" CssClass="tb5" Width="57px" AutoPostBack="True"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownType_Position14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtDegree14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDegree14" runat="server" MaxLength="100" Width="52px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDegree14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtSalary14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSalary14" runat="server" MaxLength="100" Width="52px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtSalary14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtSalaryForPosition14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtSalaryForPosition14" runat="server" MaxLength="100" Width="52px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtSalaryForPosition14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtRefDoc14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRefDoc14" runat="server" MaxLength="100" Width="170px" CssClass="tb5"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtRefDoc14" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:UpdatePanel ID="UpdateButtonPlus14" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="ButtonPlus14" Text="+" runat="server" Width="36px" CssClass="master_OAT_button" OnClick="ButtonPlus14_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ButtonPlus14" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </td>
                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdateGridView5" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView5" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                DataKeyNames="ID"
                                OnRowEditing="modEditCommand5"
                                OnRowCancelingEdit="modCancelCommand5"
                                OnRowUpdating="modUpdateCommand5"
                                OnRowDeleting="modDeleteCommand5"
                                OnRowDataBound="GridView5_RowDataBound5"
                                OnPageIndexChanging="myGridViewPersonPosiSalary_PageIndexChanging5" PageSize="10" BackColor="White" BorderColor="#999999">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryCitizenID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วัน เดือน ปี" ItemStyle-Width="120" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryDateEdit" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryDateEdit" MaxLength="100" CssClass="date" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="300" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryPositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryPositionEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่ตำแหน่ง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryNoPositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PERSON_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryNoPositionEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PERSON_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryTypePositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_501" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ระดับ" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryDegreeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryDegreeEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เงินเดือน" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalarySALARYEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalarySALARYEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เงินประจำตำแหน่ง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryPositionSALARYEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryPositionSALARYEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryRefEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REFERENCE_DOCUMENT") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryRefEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REFERENCE_DOCUMENT") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton5" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView5" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 350px; height: 50px;"></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:Button ID="btnCancelPerson" Text="Cancel" runat="server" OnClick="btnCancelPerson_Click" Width="140px" CssClass="master_OAT_button" /></td>
                            <td style="text-align: left; width: 50px;"></td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:Button ID="btnSubmitPerson" Text="OK" runat="server" OnClick="btnSubmitPerson_Click" Width="140px" CssClass="master_OAT_button" /></td>
                        </tr>
                    </table>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
