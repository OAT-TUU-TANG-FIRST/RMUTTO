<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_ADMIN" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtDateFrom,#ContentPlaceHolder1_txtDateTO").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        };
    </script>
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }
        .textred{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel2" runat="server" DefaultButton="lbuSearch">
        <div class="ps-header"><img src="Image/Small/search.png" />ค้นหาข้อมูลการพัฒนาบุคลากร</div>
        <div>  
            <div style="margin-bottom: 20px; text-align:center">
                <div class="ps-div-title-red"><img src="Image/Small/search.png" class="icon_left"/>ค้นหารายชื่อ</div>
                เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchSeminarCitizen" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="13"></asp:TextBox>
                <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
            </div>
            <asp:GridView ID="GridView1" runat="server" style="margin-bottom: 20px; margin-right: 20px; vertical-align: top; text-align: center;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="SEMINAR_ID"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewSeminar_PageIndexChanging" PageSize="10" CssClass="ps-table-1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <Columns>
                    <asp:TemplateField Visible="false" HeaderText="SEMENAR_ID">
                        <ItemTemplate>
                            <asp:Label ID="lblSEidEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รหัสบัตรประชาชน" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblSECitizenIDEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อ" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblSEnameEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="นามสกุล" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblSElastnameEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_LASTNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อโครงการ" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblSEnameofprojectEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_NAMEOFPROJECT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="สถานที่" ControlStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblSEplaceEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_PLACE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_POSITION">
                        <ItemTemplate>
                            <asp:Label ID="lblSEpositionEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_POSITION") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_DEGREE">
                        <ItemTemplate>
                            <asp:Label ID="lblSEdegreeEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_DEGREE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_CAMPUS">
                        <ItemTemplate>
                            <asp:Label ID="lblSEcampusEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_CAMPUS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_DATETIME_FROM">
                        <ItemTemplate>
                                <asp:Label ID="lblSEdatetimefromEDIT" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "SEMINAR_DATETIME_FROM")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_DATETIME_TO">
                        <ItemTemplate>
                                <asp:Label ID="lblSEdatetimetoEDIT" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "SEMINAR_DATETIME_TO")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_DAY">
                        <ItemTemplate>
                            <asp:Label ID="lblSEdayEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_DAY") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_MONTH">
                        <ItemTemplate>
                            <asp:Label ID="lblSEmonthEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_MONTH") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_YEAR">
                        <ItemTemplate>
                            <asp:Label ID="lblSEyearEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_YEAR") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_BUDGET">
                        <ItemTemplate>
                            <asp:Label ID="lblSEbudgetEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_BUDGET") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SUPPORT_BUDGET">
                        <ItemTemplate>
                            <asp:Label ID="lblSEsupportbudgetEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SUPPORT_BUDGET") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_CERTIFICATE">
                        <ItemTemplate>
                            <asp:Label ID="lblSEcertificateEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_CERTIFICATE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_ABSTRACT">
                        <ItemTemplate>
                            <asp:Label ID="lblSEabstractEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_ABSTRACT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_RESULT">
                        <ItemTemplate>
                            <asp:Label ID="lblSEresultEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_RESULT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SHOW_1">
                        <ItemTemplate>
                            <asp:Label ID="lblSEshow1EDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SHOW_1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SHOW_2">
                        <ItemTemplate>
                            <asp:Label ID="lblSEshow2EDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SHOW_2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SHOW_3">
                        <ItemTemplate>
                            <asp:Label ID="lblSEshow3EDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SHOW_3") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SHOW_4">
                        <ItemTemplate>
                            <asp:Label ID="lblSEshow4EDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SHOW_4") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_PROBLEM">
                        <ItemTemplate>
                            <asp:Label ID="lblSEproblemEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_PROBLEM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_COMMENT">
                        <ItemTemplate>
                            <asp:Label ID="lblSEcommentEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_COMMENT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="SEMINAR_SIGNED_DATETIME">
                        <ItemTemplate>
                            <asp:Label ID="lblSEsigneddatetimeEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_SIGNED_DATETIME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField DeleteText="Delete" ShowSelectButton="true" ControlStyle-ForeColor="Red" SelectText="Select" HeaderText="เลือก" />
                    <asp:TemplateField HeaderText="ลบ">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" CssClass="divpan" DefaultButton="lbuSubmit">
        <div class="ps-header">
            <img src="Image/Small/edit.png" />แก้ไขข้อมูลการพัฒนาบุคลากร
        </div>
    </asp:Panel>
    <div id="notification" runat="server"></div>
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" DefaultButton="lbuSubmit">
        
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div style="text-align: center;">
                        <table class="ps-table-1" style="display: inline-block; text-align: left;">
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่ง</td>
                                <td class="col2">
                                    <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับ</td>
                                <td class="col2">
                                    <asp:Label ID="lblDegree" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สังกัด</td>
                                <td class="col2">
                                    <asp:Label ID="lblCampus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtNameOfProject" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน" ></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สถานที่ฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtPlace" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="สถานที่ฝึกอบรม/สัมมนา/ดูงาน" ></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    ตั้งแต่วันที่ <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" MaxLength="12" CssClass="ps-textbox" AutoPostBack="True" OnTextChanged="txtDateFrom_TextChanged"></asp:TextBox>
                                    ถึงวันที่ <asp:TextBox ID="txtDateTO" runat="server" MaxLength="12" Width="180px" OnTextChanged="txtDateTO_TextChanged" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รวมเวลา</td>
                                <td class="col2">
                                    <asp:Label ID="lblDay" runat="server">0</asp:Label> วัน &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMonth" runat="server">0</asp:Label> เดือน&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblYear" runat="server">0</asp:Label> ปี
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ค่าใช้จ่ายตลอดโครงการ</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtBudget" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="ค่าใช้จ่ายตลอดโครงการ" ></asp:TextBox> บาท
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">แหล่งงบประมาณที่ได้รับการสนับสนุน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtSupportBudget" runat="server" Width="460px" CssClass="ps-textbox" Placeholder="แหล่งงบประมาณที่ได้รับการสนับสนุน" ></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประกาศนียบัตรที่ได้รับ</td>
                                <td class="col2">
                                    <asp:CheckBox ID="chkBox" runat="server" Text="ถ้ามี" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
                                    <asp:TextBox ID="txtCertificate" runat="server" Width="420px" Enabled="False" Text="ไม่มี" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สรุปผลการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtAbstract" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtResult" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                            </tr>
                            <tr>
                                <td class="col1">ด้านการเรียนการสอน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtShow1" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการเรียนการสอน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ด้านการวิจัย</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtShow2" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการวิจัย"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ด้านการบริการวิชาการ</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtShow3" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการบริการวิชาการ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ด้านอื่นๆ</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtShow4" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านอื่นๆ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtProblem" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ความคิดเห็น/ข้อเสนอแนะอื่นๆ</td>
                                <td class="col2">
                                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="50px" Width="600px" CssClass="ps-textbox" Placeholder="ความคิดเห็น/ข้อเสนอแนะอื่นๆ"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <asp:LinkButton ID="lbuSubmit" runat="server" OnClick="lbuSubmit_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>ตกลง</asp:LinkButton>
                    </div>

                </asp:View>

                <asp:View ID="View2" runat="server">

                    <div>
                        <div class="ps-div-title-red">การแก้ไขข้อมูลพัฒนาบุคลากรสำเร็จ</div>
                        <div style="color: #808080; margin-top: 10px; text-align: center;">
                            ระบบได้ทำการบันทึกข้อมูลสำเร็จเรียบร้อย
                        </div>
                        <div style="text-align: center; margin-top: 10px;">
                            <a href="Default.aspx" class="ps-button">
                                <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                        </div>
                    </div>

                </asp:View>
            </asp:MultiView>
        </div>
    </asp:Panel>
</asp:Content>