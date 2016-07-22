﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-GENERAL.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_GENERAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtDateFrom,#ContentPlaceHolder1_txtDateTO").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Small/list.png" />ข้อมูลการฝึกอบรม/สัมมนา/ดูงาน
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">

                    <div style="text-align: center;">
                        <table class="ps-table-1" style="display: inline-block; text-align: left;">
                            <tr>
                                <td>ชื่อ</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="148px" CssClass="ps-textbox" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>นามสกุล</td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" Width="148px" CssClass="ps-textbox" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ตำแหน่ง</td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server" MaxLength="100" Width="148px" CssClass="ps-textbox" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ระดับ</td>
                                <td>
                                    <asp:TextBox ID="txtDegree" runat="server" MaxLength="100" Width="153px" CssClass="ps-textbox" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>สังกัด</td>
                                <td>
                                    <asp:TextBox ID="txtCampus" runat="server" MaxLength="100" Width="625px" CssClass="ps-textbox" Placeholder="สังกัด" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtNameOfProject" runat="server" MaxLength="100" Width="691px" CssClass="ps-textbox" Placeholder="ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>สถานที่ฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtPlace" runat="server" MaxLength="100" Width="713px" CssClass="ps-textbox" Placeholder="สถานที่ฝึกอบรม/สัมมนา/ดูงาน" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    ตั้งแต่วันที่ <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" MaxLength="12" CssClass="ps-textbox" OnTextChanged="txtDateFrom_TextChanged" AutoPostBack="True" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                    ถึงวันที่ <asp:TextBox ID="txtDateTO" runat="server" MaxLength="12" Width="180px" OnTextChanged="txtDateTO_TextChanged" CssClass="ps-textbox" AutoPostBack="True" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>รวมเวลา</td>
                                <td>
                                    <asp:TextBox ID="txtDay" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox> วัน
                                    <asp:TextBox ID="txtMonth" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox> เดือน
                                    <asp:TextBox ID="txtYear" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox> ปี
                                </td>
                            </tr>
                            <tr>
                                <td>ค่าใช้จ่ายตลอดโครงการ</td>
                                <td>
                                    <asp:TextBox ID="txtBudget" runat="server" MaxLength="100" Width="360px" CssClass="ps-textbox" Placeholder="ค่าใช้จ่ายตลอดโครงการ" required="กรุณากรอกช่องนี้"></asp:TextBox> บาท
                                </td>
                            </tr>
                            <tr>
                                <td>แหล่งงบประมาณที่ได้รับการสนับสนุน</td>
                                <td>
                                    <asp:TextBox ID="txtSupportBudget" runat="server" MaxLength="100" Width="718px" CssClass="ps-textbox" Placeholder="แหล่งงบประมาณที่ได้รับการสนับสนุน" required="กรุณากรอกช่องนี้"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ประกาศนียบัตรที่ได้รับ</td>
                                <td>
                                    <asp:CheckBox ID="chkBox" runat="server" Text="ถ้ามี" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
                                    <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" Width="735px" Enabled="False" Text="ไม่มี" CssClass="ps-textbox" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>สรุปผลการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtAbstract" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtResult" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</td>
                            </tr>
                            <tr>
                                <td>ด้านการเรียนการสอน</td>
                                <td>
                                    <asp:TextBox ID="txtShow1" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการเรียนการสอน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านการวิจัย</td>
                                <td>
                                    <asp:TextBox ID="txtShow2" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการวิจัย"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านการบริการวิชาการ</td>
                                <td>
                                    <asp:TextBox ID="txtShow3" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านการบริการวิชาการ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ด้านอื่นๆ</td>
                                <td>
                                    <asp:TextBox ID="txtShow4" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ด้านอื่นๆ"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน</td>
                                <td>
                                    <asp:TextBox ID="txtProblem" runat="server" MaxLength="1000" Height="50px" Width="900px" TextMode="MultiLine" CssClass="ps-textbox" Placeholder="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ความคิดเห็น/ข้อเสนอแนะอื่นๆ</td>
                                <td>
                                    <asp:TextBox ID="txtComment" runat="server" MaxLength="1000" TextMode="MultiLine" Height="50px" Width="900px" CssClass="ps-textbox" Placeholder="ความคิดเห็น/ข้อเสนอแนะอื่นๆ"></asp:TextBox>
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
                        <div class="ps-div-title-red">กรอกข้อมูลการพะะะัะะสำเร็จ</div>
                        <div style="color: #808080; margin-top: 10px; text-align: center;">
                            ระบบจะมีการแจ้งเตือนอีกครั้งเมื่อเจ้าหน้าที่ดำเนินเรื่องการขอเครื่องราชฯสำเร็จเรียบร้อย
                        </div>
                        <div style="text-align: center; margin-top: 10px;">
                            <a href="Default.aspx" class="ps-button"><img src="Image/Small/home3.png" class="icon_left"/>กลับหน้าหลัก</a>
                        </div>
                    </div>
                </asp:View>

            </asp:MultiView>
        </div>
    </div>
</asp:Content>