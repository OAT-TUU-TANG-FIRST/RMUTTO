<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_ADMIN" %>

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
            text-align: center;
        }

        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: center;
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 200px;
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
            text-align: left;
            color: blue;
        }

        .center1 {
            display: inline-block;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtDateFrom,#ContentPlaceHolder1_txtDateTO").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchSeminar">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <fieldset>
                <legend>ค้นหา</legend>
                <div>
                    เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchSeminarCitizen" runat="server" CssClass="tb5" Width="230px" MaxLength="13"></asp:TextBox>
                    <asp:Button ID="btnSearchSeminar" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchSeminar_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
                <asp:UpdatePanel ID="UpdateGridview1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="Gridview1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="SEMINAR_ID"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewSeminar_PageIndexChanging" PageSize="10" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="SEMENAR_ID" ControlStyle-Width="180" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSEidEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสบัตรประชาชน" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSECitizenIDEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อ" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSEnameEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="นามสกุล" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSElastnameEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_LASTNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อโครงการ" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSEnameofprojectEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_NAMEOFPROJECT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="สถานที่" ControlStyle-Width="200" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSEplaceEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SEMINAR_PLACE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" DeleteText="Delete" EditText="Select" HeaderText="เลือก" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato" />
                                <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                    </Triggers>
                </asp:UpdatePanel>
            </fieldset>
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSaveSeminar">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="ps-lb-progress-contain">
                        <span class="ps-lb-progress-sel">1) ข้อมูลการฝึกอบรม/สัมมนา/ดูงาน</span>
                        <span class="ps-lb-progress-cen"></span>
                        <span class="ps-lb-progress-unsel">2) สรุปผลการฝึกอบรม/สัมมนา/ดูงาน</span>
                    </div>
                    <fieldset>
                        <legend class="TMZ">(1/2)</legend>

                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">1. </td>
                                <td style="text-align: right; margin-right: 5px;">ชื่อ<span class="textred">*</span> :&nbsp;</td>
                                <td class="col1">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox>
                                </td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: right; margin-right: 5px;">นามสกุล<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left; width: 170px;">
                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox></td>
                                <td style="text-align: right; margin-right: 5px;">ตำแหน่ง<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left; width: 170px;">
                                    <asp:TextBox ID="txtPosition" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox></td>
                                <td style="text-align: right; margin-right: 5px;">ระดับ<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left; width: 170px;">
                                    <asp:TextBox ID="txtDegree" runat="server" MaxLength="100" Width="153px" CssClass="tb5"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">สังกัด<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtCampus" runat="server" MaxLength="100" Width="625px" CssClass="tb5" Placeholder="สังกัด"></asp:TextBox></td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: right; margin-right: 5px;">มหาวิทยาลัยเทคโนยีราชมงคลตะวันออก</td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">2. </td>
                                <td style="text-align: right; margin-right: 5px;">ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtNameOfProject" runat="server" MaxLength="100" Width="691px" CssClass="tb5" Placeholder="ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">3. </td>
                                <td style="text-align: right; margin-right: 5px;">สถานที่ฝึกอบรม/สัมมนา/ดูงาน<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtPlace" runat="server" MaxLength="100" Width="713px" CssClass="tb5" Placeholder="สถานที่ฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td style="text-align: left; width: 30px;"></td>
                                <td style="text-align: left; margin-right: 5px;">ตั้งแต่วันที่<span class="textred">*</span> </td>
                                <td style="text-align: left; width: 220px;">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" MaxLength="12" CssClass="tb5" OnTextChanged="txtDateFrom_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtDateFrom" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: left; margin-right: 5px;">ถึงวันที่<span class="textred">*</span></td>
                                <td style="text-align: left; width: 220px;">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtDateTO" runat="server" MaxLength="12" Width="180px" OnTextChanged="txtDateTO_TextChanged" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtDateFrom" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">รวมเวลา :&nbsp;</td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtDay" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                                <td style="text-align: left; margin-right: 5px;">วัน</td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtMonth" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="text-align: left; margin-right: 5px;">เดือน</td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtYear" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="text-align: left; margin-right: 10px;">ปี</td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: right; margin-right: 5px;">ค่าใช้จ่ายตลอดโครงการ<span class="textred">*</span> :&nbsp;</td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtBudget" runat="server" MaxLength="100" Width="360px" CssClass="tb5" Placeholder="ค่าใช้จ่ายตลอดโครงการ"></asp:TextBox></td>
                                <td style="text-align: right; margin-right: 5px;">บาท </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">แหล่งงบประมาณที่ได้รับการสนับสนุน<span class="textred">*</span></td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtSupportBudget" runat="server" MaxLength="100" Width="718px" CssClass="tb5" Placeholder="แหล่งงบประมาณที่ได้รับการสนับสนุน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: right; margin-right: 5px;">4. ประกาศนียบัตรที่ได้รับ </td>
                                <td style="text-align: left; width: 40px;">
                                    <asp:UpdatePanel ID="UpdatechkBox" runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="chkBox" runat="server" Text="ถ้ามี" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="chkBox" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td style="text-align: left; width: 50px;">
                                    <asp:UpdatePanel ID="UpdatetxtCertificate" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" Width="735px" Enabled="False" Text="ไม่มี" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtCertificate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:Button ID="lblNextV1" Text="ถัดไป" runat="server" CssClass="ps-button" OnClick="lblNextV1_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:View>

                <asp:View ID="View2" runat="server">
                    <div class="ps-lb-progress-contain">
                        <span class="ps-lb-progress-unsel">1) ข้อมูลการฝึกอบรม/สัมมนา/ดูงาน</span>
                        <span class="ps-lb-progress-cen"></span>
                        <span class="ps-lb-progress-sel">2) สรุปผลการฝึกอบรม/สัมมนา/ดูงาน</span>
                    </div>
                    <fieldset>
                        <legend class="TMZ">(2/2)</legend>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 10px;">5. สรุปผลการฝึกอบรม/สัมมนา/ดูงาน </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtAbstract" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">6. ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน </td>

                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtResult" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">7. การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">7.1 ด้านการเรียนการสอน </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtShow1" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการเรียนการสอน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">7.2 ด้านการวิจัย </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtShow2" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการวิจัย"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">7.3 ด้านการบริการวิชาการ </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtShow3" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการบริการวิชาการ"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">7.4 ด้านอื่นๆ </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtShow4" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านอื่นๆ"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">8. ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtProblem" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="tb5" Placeholder="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; margin-right: 5px;">9. ความคิดเห็น/ข้อเสนอแนะอื่นๆ </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:TextBox ID="txtComment" runat="server" MaxLength="1000" TextMode="MultiLine" Height="50px" Width="900px" CssClass="tb5" Placeholder="ความคิดเห็น/ข้อเสนอแนะอื่นๆ"></asp:TextBox></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="text-align: left; width: 50px;">
                                    <asp:Button ID="btnCancelSeminar" Text="ย้อนกลับ" runat="server" OnClick="btnCancelSeminar_Click" CssClass="ps-button" /></td>
                                <td style="text-align: left; width: 10px;"></td>
                                <td style="text-align: right; margin-right: 5px;">
                                    <asp:Button ID="btnSaveSeminar" Text="แก้ไขข้อมูลพัฒนาบุคลากร" runat="server" OnClick="btnSubmitSeminar_Click" CssClass="ps-button" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:View>
            </asp:MultiView>
        </div>
    </asp:Panel>
</asp:Content>
