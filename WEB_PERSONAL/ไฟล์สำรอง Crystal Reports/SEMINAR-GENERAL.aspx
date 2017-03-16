<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-GENERAL.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_GENERAL" MaintainScrollPositionOnPostback="true" %>
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
    <asp:Panel ID="Panel0" runat="server" DefaultButton="lbuSubmit">
        <div class="ps-header"><img src="Image/Small/add.png" />เพิ่มข้อมูลการพัฒนาบุคลากร</div>
    </asp:Panel>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="notification" runat="server"></div>
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
                        <div class="ps-div-title-red">การเพิ่มข้อมูลพัฒนาบุคลากรสำเร็จ</div>
                        <div style="color: #808080; margin-top: 10px; text-align: center;">
                            ระบบได้ทำการบันทึกข้อมูลสำเร็จเรียบร้อย
                        </div>
                        <div style="text-align: center; margin-top: 10px;">
                            <a href="Default.aspx" class="ps-button"><img src="Image/Small/home3.png" class="icon_left"/>กลับหน้าหลัก</a>
                        </div>
                    </div>
                </asp:View>

            </asp:MultiView>
        </div>
    
</asp:Content>