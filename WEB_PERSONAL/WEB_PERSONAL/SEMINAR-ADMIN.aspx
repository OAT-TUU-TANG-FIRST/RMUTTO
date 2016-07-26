﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtDateFrom,#ContentPlaceHolder1_txtDateTO").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        };
    </script>
    <style type="text/css">
        .divpan {
            text-align: center;
        }

        .textred {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" DefaultButton="lbuSearch">
        <div class="ps-header">
            <img src="Image/Small/list.png" />ค้นหา ข้อมูลการฝึกอบรม/สัมมนา/ดูงาน
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <div id="notification" runat="server"></div>
            <div>
                เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchSeminarCitizen" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="13"></asp:TextBox>
                <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
            </div>

            <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="SEMINAR_ID"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewSeminar_PageIndexChanging" PageSize="10" CssClass="ps-table-1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <Columns>
                    <asp:TemplateField Visible="false" HeaderText="SEMENAR_ID" ControlStyle-Width="180">
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

    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" DefaultButton="lbuSubmit">
        <div class="ps-header">
            <img src="Image/Small/list.png" />ข้อมูลการฝึกอบรม/สัมมนา/ดูงาน
        </div>
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div style="text-align: center;">
                        <table class="ps-table-1" style="display: inline-block; text-align: left;">
                            <tr>
                                <td>ชื่อ</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Width="200px" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>นามสกุล</td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" Width="200px" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>ตำแหน่ง</td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server" Width="200px" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>ระดับ</td>
                                <td>
                                    <asp:TextBox ID="txtDegree" runat="server" Width="200px" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>สังกัด</td>
                                <td>
                                    <asp:TextBox ID="txtCampus" runat="server" Width="600px" CssClass="ps-textbox" Placeholder="สังกัด"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtNameOfProject" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>สถานที่ฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtPlace" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="สถานที่ฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>ตั้งแต่วันที่
                                    <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" MaxLength="12" CssClass="ps-textbox" OnTextChanged="txtDateFrom_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    ถึงวันที่
                                    <asp:TextBox ID="txtDateTO" runat="server" MaxLength="12" Width="180px" OnTextChanged="txtDateTO_TextChanged" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>รวมเวลา</td>
                                <td>
                                    <asp:TextBox ID="txtDay" runat="server" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                    วัน
                                    <asp:TextBox ID="txtMonth" runat="server" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                    เดือน
                                    <asp:TextBox ID="txtYear" runat="server" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                    ปี
                                </td>
                            </tr>
                            <tr>
                                <td>ค่าใช้จ่ายตลอดโครงการ</td>
                                <td>
                                    <asp:TextBox ID="txtBudget" runat="server" Width="300px" CssClass="ps-textbox" Placeholder="ค่าใช้จ่ายตลอดโครงการ"></asp:TextBox>
                                    บาท
                                </td>
                            </tr>
                            <tr>
                                <td>แหล่งงบประมาณที่ได้รับการสนับสนุน</td>
                                <td>
                                    <asp:TextBox ID="txtSupportBudget" runat="server" Width="460px" CssClass="ps-textbox" Placeholder="แหล่งงบประมาณที่ได้รับการสนับสนุน"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>ประกาศนียบัตรที่ได้รับ</td>
                                <td>
                                    <asp:CheckBox ID="chkBox" runat="server" Text="ถ้ามี" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
                                    <asp:TextBox ID="txtCertificate" runat="server" Width="420px" Enabled="False" Text="ไม่มี" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>สรุปผลการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtAbstract" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtResult" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                            </tr>
                            <tr>
                                <td>ด้านการเรียนการสอน</td>
                                <td>
                                    <asp:TextBox ID="txtShow1" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการเรียนการสอน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านการวิจัย</td>
                                <td>
                                    <asp:TextBox ID="txtShow2" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการวิจัย"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านการบริการวิชาการ</td>
                                <td>
                                    <asp:TextBox ID="txtShow3" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการบริการวิชาการ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านอื่นๆ</td>
                                <td>
                                    <asp:TextBox ID="txtShow4" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านอื่นๆ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtProblem" runat="server" Height="50px" Width="600px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ความคิดเห็น/ข้อเสนอแนะอื่นๆ</td>
                                <td>
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
                        <div class="ps-div-title-red">การเพิ่มข้อมูลพัฒนาบุคลากรสำเร็จ</div>
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