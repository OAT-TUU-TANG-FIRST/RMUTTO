<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPersonGP7-Edit.aspx.cs" Inherits="WEB_PERSONAL.AddPersonGP7_Edit" %>

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
    </style>
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbUseDate11,#ContentPlaceHolder1_tbDate14").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbDateInwork").datepicker($.datepicker.regional["th"]);
            $('document').ready(function () {
                $(".date").datepicker($.datepicker.regional["th"]);
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato" DefaultButton="btnSearchPerson">
        <div>
            <fieldset>
                <legend class="TMZ">ข้อมูลที่ค้นหา</legend>
                <div style="text-align: center">
                    ดึงข้อมูล :&nbsp<asp:TextBox ID="tbCitizenIDSearch" runat="server" CssClass="tb5" MaxLength="13" placeholder="เลขบัตรประจำตัวประชาชน"></asp:TextBox>
                    <asp:Button ID="btnSearchPerson" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPerson_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <table>
                            <tr>
                                <td class="col1">กระทรวง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlMinistry" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คำนำหน้านาม</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="tb5"></asp:DropDownList>
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
                                <td class="col1">วัน เดือน ปีเกิด (dd-mm-yyyy)</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthdayDate" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วัน เดือน ปีเกิด (ตัวบรรจง เต็มบรรทัด)</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthdayLong" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่บรรจุ (dd-mm-yyyy)</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbInworkDate" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันครบเกษียณอายุ (dd-mm-yyyy)</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRetireDate" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันครบเกษียณอายุ (ตัวบรรจง เต็มบรรทัด)</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbRetireLong" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทข้าราชการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStaffType" runat="server" CssClass="tb5"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                            <td class="col1"></td>
                            <td class="col2">
                                <asp:LinkButton ID="lbSubmitEdit" runat="server" CssClass="ps-button" OnClick="lbSubmitEdit_Click">แก้ไขข้อมูลทะเบียนประวัติบุคลากร(ก.พ.7)</asp:LinkButton></td>
                        </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block;">
                        <table>
                            <tr>
                                <td class="col1">กรม</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbGrom" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เลขบัตรประจำตัวประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="tb5" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อบิดา</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbFatherName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุลบิดา</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbFatherLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อมารดา</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMotherName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุลมารดา</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMotherLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุลมารดาเดิม</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMotherOldLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อคู่สมรส</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCoupleName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุลคู่สมรส</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCoupleLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุลเดิมคู่สมรสเดิม</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCoupleOldLastName" runat="server" CssClass="tb5"></asp:TextBox>
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

                    <asp:GridView ID="GridViewStudy" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PS_STUDY_ID"
                        OnRowEditing="modEditCommand1"
                        OnRowCancelingEdit="modCancelCommand1"
                        OnRowUpdating="modUpdateCommand1"
                        OnRowDeleting="modDeleteCommand1"
                        OnRowDataBound="GridViewStudy_RowDataBound1"
                        OnPageIndexChanging="myGridViewStudy_PageIndexChanging1" PageSize="15" BackColor="White" BorderColor="#999999">
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
                            <asp:TemplateField HeaderText="ระดับการศึกษา" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyDegreeID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEGREE_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyDegreeID" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานศึกษา" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyUnivName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_UNIV_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonStudyUnivName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_UNIV_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyFromMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_MONTH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyFromMonth" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyFromYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_YEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyFromYear" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyToMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_MONTH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyToMonth" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyToYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_YEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyToYear" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วุฒิ" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyQualification" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_QUALIFICATION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonStudyQualification" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_QUALIFICATION") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สาขาวิชาเอก" ControlStyle-Width="170" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyMajor" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_MAJOR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonStudyMajor" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_MAJOR") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ประเทศที่จบ" ControlStyle-Width="120" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonStudyCountryID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COUNTRY_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonStudyCountryID" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato" />
                            <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

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
                    <asp:GridView ID="GridViewLicense" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PS_PL_ID"
                        OnRowEditing="modEditCommand2"
                        OnRowCancelingEdit="modCancelCommand2"
                        OnRowUpdating="modUpdateCommand2"
                        OnRowDeleting="modDeleteCommand2"
                        OnRowDataBound="GridViewLicense_RowDataBound2"
                        OnPageIndexChanging="myGridViewLicense_PageIndexChanging2" PageSize="15" BackColor="White" BorderColor="#999999">
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
                            <asp:TemplateField HeaderText="ชื่อใบอนุญาต" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonLicenseName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonLicenseName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หน่วยงาน" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonLicenseDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonLicenseDepartment" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่ใบอนุญาต" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonLicenseNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NO") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonLicenseNo" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_LICENSE_NO") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่มีผลบังคับใช้ (วัน เดือน ปี)" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonLicenseDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_USE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonLicenseDate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_USE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato" />
                            <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

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
                    <asp:GridView ID="GridViewTraining" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PS_TRAINING_ID"
                        OnRowEditing="modEditCommand3"
                        OnRowCancelingEdit="modCancelCommand3"
                        OnRowUpdating="modUpdateCommand3"
                        OnRowDeleting="modDeleteCommand3"
                        OnRowDataBound="GridViewTraining_RowDataBound3"
                        OnPageIndexChanging="myGridViewTraining_PageIndexChanging3" PageSize="15" BackColor="White" BorderColor="#999999">
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
                            <asp:TemplateField HeaderText="หลักสูตรฝึกอบรม" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingCourse" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COURSE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonTrainingCourse" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_COURSE") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingFromMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_MONTH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonTrainingFromMonth" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingFromYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_FROM_YEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonTrainingFromYear" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingToMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_MONTH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonTrainingToMonth" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingToYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_TO_YEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonTrainingToYear" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หน่วยงานที่จัดฝึกอบรม" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonTrainingDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonTrainingDepartment" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DEPARTMENT") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato" />
                            <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                    <asp:GridView ID="GridViewDAA" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PS_DAA_ID"
                        OnRowEditing="modEditCommand4"
                        OnRowCancelingEdit="modCancelCommand4"
                        OnRowUpdating="modUpdateCommand4"
                        OnRowDeleting="modDeleteCommand4"
                        OnRowDataBound="GridViewDAA_RowDataBound4"
                        OnPageIndexChanging="myGridViewDAA_PageIndexChanging4" PageSize="15" BackColor="White" BorderColor="#999999">
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
                            <asp:TemplateField HeaderText="พ.ศ." ControlStyle-Width="60" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonDAAYear" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_YEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonDAAYear" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รายการ" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonDAAName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DAA_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonDAAName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_DAA_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonDAARef" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonDAARef" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato" />
                            <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                    <asp:GridView ID="GridViewPAS" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PS_PAS_ID"
                        OnRowEditing="modEditCommand5"
                        OnRowCancelingEdit="modCancelCommand5"
                        OnRowUpdating="modUpdateCommand5"
                        OnRowDeleting="modDeleteCommand5"
                        OnRowDataBound="GridViewPAS_RowDataBound5"
                        OnPageIndexChanging="myGridViewPAS_PageIndexChanging5" PageSize="15" BackColor="White" BorderColor="#999999">
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
                            <asp:TemplateField HeaderText="วัน เดือน ปี" ControlStyle-Width="80" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASDate" MaxLength="12" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "PS_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="150" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASPOsitionName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASPOsitionName" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่ตำแหน่ง" ControlStyle-Width="40" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASPositionNO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_NO") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASPositionNO" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_NO") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASPositionType" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonPASPositionType" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ระดับ" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASDegree" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_POSITION_DEGREE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPersonPASDegree" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินเดือน" ControlStyle-Width="70" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASSalary" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASSalary" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินประจำตำแหน่ง" ControlStyle-Width="70" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASSalaryPosition" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY_POSITION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASSalaryPosition" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_SALARY_POSITION") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="130" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonPASRef" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPersonPASRef" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PS_REF") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato" />
                            <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="tomato">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:LinkButton ID="lbuV5Back" runat="server" CssClass="ps-button" OnClick="lbuV5Back_Click">ย้อนกลับ</asp:LinkButton>
                    </div>
                </fieldset>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
