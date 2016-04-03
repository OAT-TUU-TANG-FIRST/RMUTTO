<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Person-FormatPrint - new.aspx.cs" Inherits="WEB_PERSONAL.Person_FormatPrint_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
    </style>
    <asp:Panel runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend</legend>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">กระทรวง</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">กรม</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="425px" CssClass="tb5"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtDepart" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">คำนำหน้านาม</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">เลขบัตรประจำตัวประชาชน</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                               <asp:TextBox ID="TextBox2" runat="server" Width="425px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtCitizen" runat="server" MaxLength="13" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ชื่อ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ชื่อบิดา</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุล</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุลบิดา</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtFatherLastName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">วัน เดือน ปีเกิด (dd-mm-yyyy)</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ชื่อมารดา</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 435px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtBirthDayNumber" runat="server" MaxLength="12" Width="425px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtBirthDayNumber" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 1px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMotherName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">วัน เดือน ปีเกิด (ตัวบรรจง เต็มบรรทัด)</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุลมารดา</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtBirthDayChar" runat="server" MaxLength="100" Width="425px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMotherLastName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">วันที่บรรจุ (dd-mm-yyyy)</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุลมารดาเดิม</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 435px;">
                                <asp:TextBox ID="txtDateInWork" runat="server" MaxLength="12" Width="425px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMotherLastNameOld" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ประเภทข้าราชการ</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ชื่อคู่สมรส</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="TextBox3" runat="server" Width="425px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMarriedName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">วันครบเกษียณอายุ (dd-mm-yyyy)</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุลคู่สมรส</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 435px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAge60Number" runat="server" MaxLength="12" Width="425px" CssClass="tb5" AutoPostBack="True" CausesValidation="False"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtAge60Number" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMarriedLastName" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">วันครบเกษียณอายุ (ตัวบรรจง เต็มบรรทัด)</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">นามสกุลเดิมคู่สมรสเดิม</td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAge60Char" runat="server" MaxLength="100" Width="425px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtMarriedLastNameOld" runat="server" MaxLength="100" Width="425px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>๑๐. ประวัติการศึกษา</legend>
                <div>
                    <!-- FOR TABLE 3 ROW -->

                    <asp:UpdatePanel ID="UpdateGridView1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                DataKeyNames="ID"
                                PageSize="5" BackColor="White" BorderColor="#999999" ShowHeaderWhenEmpty="True" EmptyDataText="ไม่พบข้อมูล" DataSourceID="SQL_STUDY">
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
                                        <ControlStyle Width="290px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMonthFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_101" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryYearFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_102" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMonthTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_103" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryYearTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_104" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วุฒิ(สาขาวิชาเอก)" ControlStyle-Width="255" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonStudyHistoryMajorEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MAJOR") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonStudyHistoryMajorEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MAJOR") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="255px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SQL_STUDY" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM tb_study_history where citizen_id=1234"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>๑๑. ใบอนุญาตประกอบวิชาชีพ</legend>
                <div>

                    <asp:UpdatePanel ID="UpdateGridView2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                DataKeyNames="ID"
                                PageSize="5" BackColor="White" BorderColor="#999999"  ShowHeaderWhenEmpty="true" EmptyDataText="ไม่พบข้อมูล" DataSourceID="SqlDataSource1">
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
                                        <ControlStyle Width="280px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หน่วยงาน" ControlStyle-Width="170" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceBranchEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceBranchEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="170px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่ใบอนุญาติ" ControlStyle-Width="160" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceLicenseNOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceLicenseNOEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENCE_NO") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="160px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="วันที่มีผลบังคับใช้   (วัน เดือน ปี)" ItemStyle-Width="120" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonJobLisenceDDATEEdit" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonJobLisenceDDATEEdit" CssClass="date" MaxLength="120" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                        <ItemStyle Width="120px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM tb_job_LICENSE where citizen_id=1234"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView2" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>๑๒. ประวัติการฝึกอบรม</legend>
                <div>
                    <!-- FOR TABLE 3 ROW -->

                    <asp:UpdatePanel ID="UpdateGridView3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView3" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                DataKeyNames="ID"
                                PageSize="5" BackColor="White" BorderColor="#999999"  ShowHeaderWhenEmpty="true" EmptyDataText="ไม่พบข้อมูล" DataSourceID="SqlDataSource2">
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
                                        <ControlStyle Width="290px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingMonthFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_301" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตั้งแต่(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingYearFromEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_FROM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_302" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(เดือน)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingMonthTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_303" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ถึง(ปี)" ControlStyle-Width="60" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingYearTOEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_TO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_304" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="60px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="หน่วยงานที่จัดฝึกอบรม" ControlStyle-Width="255" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonTrainingBranchEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH_TRAINING") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonTrainingBranchEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BRANCH_TRAINING") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="255px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM TB_TRAINING_HISTORY where citizen_id=1234"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView3" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>๑๓. การได้รับโทษทางวินัยและการนิรโทษกรรม</legend>
                <div>
                    <!-- FOR TABLE 3 ROW -->

                    <asp:UpdatePanel ID="UpdateGridView4" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView4" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                DataKeyNames="ID"
                                PageSize="5" BackColor="White" BorderColor="#999999" ShowHeaderWhenEmpty="true" EmptyDataText="ไม่พบข้อมูล" DataSourceID="SqlDataSource3">
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
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="รายการ" ControlStyle-Width="505" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYListEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MENU") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonDISCIPLINARYListEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MENU") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="505px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="210" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonDISCIPLINARYRefEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonDISCIPLINARYRefEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="210px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM TB_DISCIPLINARY_AND_AMNESTY where citizen_id=1234"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView4" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel6" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>๑๔. ตำแหน่งและเงินเดือน</legend>
                <div>

                    <asp:UpdatePanel ID="UpdateGridView5" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView5" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                DataKeyNames="ID"
                                PageSize="5" BackColor="White" BorderColor="#999999" ShowHeaderWhenEmpty="true" EmptyDataText="ไม่พบข้อมูล" DataSourceID="SqlDataSource4">
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
                                        <ControlStyle Width="100px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                        <ItemStyle Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="300" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryPositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryPositionEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="300px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เลขที่ตำแหน่ง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryNoPositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PERSON_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryNoPositionEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PERSON_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryTypePositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddl_501" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ระดับ" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryDegreeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryDegreeEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เงินเดือน" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalarySALARYEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalarySALARYEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เงินประจำตำแหน่ง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryPositionSALARYEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryPositionSALARYEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonPosiSalaryRefEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REFERENCE_DOCUMENT") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPersonPosiSalaryRefEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REFERENCE_DOCUMENT") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM TB_POSITION_AND_SALARY where citizen_id=1234"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView5" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <table>
                        <tr>
                            <td style="text-align: left; width: 350px; height: 50px;"></td>
                            <td style="text-align: left; width: 50px;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 50px;"></td>
                            <td style="text-align: right; margin-right: 5px;">
                                &nbsp;</td>
                        </tr>
                    </table>

                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
