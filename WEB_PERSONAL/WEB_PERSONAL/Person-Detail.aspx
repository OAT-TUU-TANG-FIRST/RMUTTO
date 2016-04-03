<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Person-Detail.aspx.cs" Inherits="WEB_PERSONAL.Person_Detail" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Person-Detail.css" rel="stylesheet" />
    <script>
        function foggleOff() {
            for (var i = 1; i < 12; ++i) {
                var j = document.getElementById('sp' + i);
                j.style.display = 'none';
            }
            for (var i = 1; i < 12; ++i) {
                var j = document.getElementById('st' + i);
                j.className = 'master_light_toggle_button';
            }
        }
        function foggle(target) {
            foggleOff();
            $('#sp' + target).slideDown(250);
            document.getElementById('st' + target).className = 'master_light_toggle_button_selected';

        }
    </script>
    <div class="mp">
        <div class="sec1">

            <table class="master_light_table_div_sec">
                <tr>
                    <td class="master_light_table_div_sec_td_left">
                        <div class="master_light_toggle_div_sec">
                            <img id="profile_pic" runat="server" src="Image/no_image.png" />
                            <div class="master_light_toggle_button" id="st11" onclick="foggle('11')">ค้นหาบุคลากร</div>
                            <div class="master_light_toggle_button" id="st1" onclick="foggle('1')">ข้อมูลส่วนตัว</div>
                            <div class="master_light_toggle_button" id="st2" onclick="foggle('2')">ที่อยู่</div>
                            <div class="master_light_toggle_button" id="st3" onclick="foggle('3')">การงาน</div>
                            <div class="master_light_toggle_button" id="st4" onclick="foggle('4')">การศึกษา</div>
                            <div class="master_light_toggle_button" id="st5" onclick="foggle('5')">ประวัติการศึกษา</div>
                            <div class="master_light_toggle_button" id="st6" onclick="foggle('6')">ใบอนุญาตประกอบวิชาชีพ</div>
                            <div class="master_light_toggle_button" id="st7" onclick="foggle('7')">ประวัติการฝึกอบรม</div>
                            <div class="master_light_toggle_button" id="st8" onclick="foggle('8')">การได้รับโทษทางวินัยและการนิรโทษกรรม</div>
                            <div class="master_light_toggle_button" id="st9" onclick="foggle('9')">ตำแหน่งและเงินเดือน</div>
                            <div class="master_light_toggle_button" id="st10" onclick="foggle('10')">รูปภาพ</div>
                        </div>
                    </td>
                    <td class="master_light_table_div_sec_td_right">
                        <div>

                            <div class="master_light_div_sec" id="sp1">
                                <div class="master_light_div_sec_title">
                                    ข้อมูลส่วนตัว
                                </div>
                                <div class="master_light_div_sec_in">
                                    <table class="auto-style3">
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label12" runat="server" Text="รหัสบัตรประชาชน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label31" runat="server" Text="คำนำหน้า"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label88" runat="server" Text="ยศ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label90" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label13" runat="server" Text="ชื่อ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label16" runat="server" Text="นามสกุล"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label45" runat="server" Text="เพศ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label46" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label47" runat="server" Text="สัญชาติ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label48" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label25" runat="server" Text="วันเกิด"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">
                                                <asp:Label ID="Label63" runat="server" Text="เบอร์โทรศัพท์"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label64" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label35" runat="server" Text="ชื่อบิดา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label36" runat="server" Text="ชื่อมารดา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label37" runat="server" Text="ชื่อคู่ครอง"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td class="auto-style8">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="master_light_div_sec" id="sp2">
                                <div class="master_light_div_sec_title">
                                    ที่อยู่
                                </div>
                                <div class="master_light_div_sec_in">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label49" runat="server" Text="บ้านเลขที่"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label52" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label50" runat="server" Text="หมู่"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label53" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label51" runat="server" Text="ถนน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label54" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label55" runat="server" Text="ตำบล"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label59" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label56" runat="server" Text="อำเภอ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label60" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label57" runat="server" Text="จังหวัด"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label61" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label58" runat="server" Text="รหัสไปรษณีย์"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label62" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="master_light_div_sec" id="sp3">
                                <div class="master_light_div_sec_title">
                                    การงาน
                                </div>
                                <div class="master_light_div_sec_in">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label21" runat="server" Text="สถานะ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label29" runat="server" Text="ประเภท"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label23" runat="server" Text="ตำแหน่ง"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label91" runat="server" Text="คณะ"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label93" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label87" runat="server" Text="Branch"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label89" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label41" runat="server" Text="กระทรวง"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label42" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label43" runat="server" Text="แผนก"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label65" runat="server" Text="สัญญาจ้าง"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label67" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label66" runat="server" Text="ทุน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label69" runat="server" Text="Sub Staff Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label71" runat="server" Text="Special name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label73" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label72" runat="server" Text="กลุ่มวิชาที่สอน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label74" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label92" runat="server" Text="ตำแหน่งทางการงานที่เริ่มเข้าทำงาน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label94" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label27" runat="server" Text="เริ่มเข้าทำงาน"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label33" runat="server" Text="วันที่เลิก"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="master_light_div_sec" id="sp4">
                                <div class="master_light_div_sec_title">
                                    การศึกษา
                                </div>
                                <div class="master_light_div_sec_in">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label75" runat="server" Text="ระดับที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label76" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label79" runat="server" Text="กลุ่มวิชาที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label80" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label81" runat="server" Text="สาขาวิชาที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label82" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label83" runat="server" Text="มหาวิทยาลัยที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label84" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label85" runat="server" Text="ประเทศที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label86" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label77" runat="server" Text="หลักสูตรที่จบการศึกษา"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label78" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="info_div" id="sp5">
                                <div>
                                    <asp:Label ID="Label7" runat="server" Text="ประวัติการศึกษา" CssClass="info_div_title"></asp:Label>
                                </div>
                                <div class="info_div_in" id="study_history_div" runat="server">
                                </div>
                            </div>

                            <div class="info_div" id="sp6">
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text="ใบอนุญาตประกอบวิชาชีพ" CssClass="info_div_title"></asp:Label>
                                </div>
                                <div class="info_div_in" id="job_license_div" runat="server">
                                </div>
                            </div>

                            <div class="info_div" id="sp7">
                                <div>
                                    <asp:Label ID="Label4" runat="server" Text="ประวัติการฝึกอบรม" CssClass="info_div_title"></asp:Label>
                                </div>
                                <div class="info_div_in" id="training_history_div" runat="server">
                                </div>
                            </div>

                            <div class="info_div" id="sp8">
                                <div>
                                    <asp:Label ID="Label5" runat="server" Text="การได้รับโทษทางวินัยและการนิรโทษกรรม" CssClass="info_div_title"></asp:Label>
                                </div>
                                <div class="info_div_in" id="disciplinary_and_amnesty" runat="server">
                                </div>
                            </div>

                            <div class="info_div" id="sp9">
                                <div>
                                    <asp:Label ID="Label6" runat="server" Text="ตำแหน่งและเงินเดือน" CssClass="info_div_title"></asp:Label>
                                </div>
                                <div class="info_div_in" id="position_and_salary_div" runat="server">
                                </div>
                            </div>

                            <div class="master_light_div_sec" id="sp10">
                                <div class="master_light_div_sec_title">
                                    รูปภาพ
                                </div>
                                <div class="master_light_div_sec_in">
                                    <div class="profile_image_header">
                                    </div>

                                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                                </div>

                            </div>

                            <div class="master_light_div_sec" id="sp11">
                                <div class="master_light_div_sec_title">
                                    รายชื่อบุคลากร
                                </div>
                                <div class="master_light_div_sec_in">
                                    <div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 120px;">
                                                    <asp:Label ID="Label95" runat="server" Text="ค้นหาบุคลากร"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" placeHolder="รหัสประชาชน" CssClass="master_light_textbox" MaxLength="13"></asp:TextBox>
                                                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="master_light_button" OnClick="LinkButton11_Click1">ค้นหา</asp:LinkButton>
                                                </td>
                                            </tr>
                                            </table>
                                    </div>
                                    <div>
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CITIZEN_ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                                <asp:BoundField DataField="CITIZEN_ID" HeaderText="CITIZEN_ID" ReadOnly="True" SortExpression="CITIZEN_ID" />
                                                <asp:BoundField DataField="TITLE_ID" HeaderText="TITLE_ID" SortExpression="TITLE_ID" />
                                                <asp:BoundField DataField="PERSON_NAME" HeaderText="PERSON_NAME" SortExpression="PERSON_NAME" />
                                                <asp:BoundField DataField="PERSON_LASTNAME" HeaderText="PERSON_LASTNAME" SortExpression="PERSON_LASTNAME" />
                                                <asp:BoundField DataField="BIRTHDATE" HeaderText="BIRTHDATE" SortExpression="BIRTHDATE" />
                                                <asp:BoundField DataField="BIRTHDATE_LONG" HeaderText="BIRTHDATE_LONG" SortExpression="BIRTHDATE_LONG" />
                                                <asp:BoundField DataField="RETIRE_DATE" HeaderText="RETIRE_DATE" SortExpression="RETIRE_DATE" />
                                                <asp:BoundField DataField="RETIRE_DATE_LONG" HeaderText="RETIRE_DATE_LONG" SortExpression="RETIRE_DATE_LONG" />
                                                <asp:BoundField DataField="INWORK_DATE" HeaderText="INWORK_DATE" SortExpression="INWORK_DATE" />
                                                <asp:BoundField DataField="STAFFTYPE_ID" HeaderText="STAFFTYPE_ID" SortExpression="STAFFTYPE_ID" />
                                                <asp:BoundField DataField="FATHER_NAME" HeaderText="FATHER_NAME" SortExpression="FATHER_NAME" />
                                                <asp:BoundField DataField="FATHER_LASTNAME" HeaderText="FATHER_LASTNAME" SortExpression="FATHER_LASTNAME" />
                                                <asp:BoundField DataField="MOTHER_NAME" HeaderText="MOTHER_NAME" SortExpression="MOTHER_NAME" />
                                                <asp:BoundField DataField="MOTHER_LASTNAME" HeaderText="MOTHER_LASTNAME" SortExpression="MOTHER_LASTNAME" />
                                                <asp:BoundField DataField="MOTHER_OLD_LASTNAME" HeaderText="MOTHER_OLD_LASTNAME" SortExpression="MOTHER_OLD_LASTNAME" />
                                                <asp:BoundField DataField="COUPLE_NAME" HeaderText="COUPLE_NAME" SortExpression="COUPLE_NAME" />
                                                <asp:BoundField DataField="COUPLE_LASTNAME" HeaderText="COUPLE_LASTNAME" SortExpression="COUPLE_LASTNAME" />
                                                <asp:BoundField DataField="COUPLE_OLD_LASTNAME" HeaderText="COUPLE_OLD_LASTNAME" SortExpression="COUPLE_OLD_LASTNAME" />
                                                <asp:BoundField DataField="MINISTRY_ID" HeaderText="MINISTRY_ID" SortExpression="MINISTRY_ID" />
                                                <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT_NAME" SortExpression="DEPARTMENT_NAME" />
                                                <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" />
                                                <asp:BoundField DataField="SYSTEM_STATUS_ID" HeaderText="SYSTEM_STATUS_ID" SortExpression="SYSTEM_STATUS_ID" />
                                                <asp:BoundField DataField="GENDER_ID" HeaderText="GENDER_ID" SortExpression="GENDER_ID" />
                                                <asp:BoundField DataField="NATION_ID" HeaderText="NATION_ID" SortExpression="NATION_ID" />
                                                <asp:BoundField DataField="HOMEADD" HeaderText="HOMEADD" SortExpression="HOMEADD" />
                                                <asp:BoundField DataField="MOO" HeaderText="MOO" SortExpression="MOO" />
                                                <asp:BoundField DataField="STREET" HeaderText="STREET" SortExpression="STREET" />
                                                <asp:BoundField DataField="DISTRICT_ID" HeaderText="DISTRICT_ID" SortExpression="DISTRICT_ID" />
                                                <asp:BoundField DataField="AMPHUR_ID" HeaderText="AMPHUR_ID" SortExpression="AMPHUR_ID" />
                                                <asp:BoundField DataField="PROVINCE_ID" HeaderText="PROVINCE_ID" SortExpression="PROVINCE_ID" />
                                                <asp:BoundField DataField="ZIPCODE_ID" HeaderText="ZIPCODE_ID" SortExpression="ZIPCODE_ID" />
                                                <asp:BoundField DataField="TELEPHONE" HeaderText="TELEPHONE" SortExpression="TELEPHONE" />
                                                <asp:BoundField DataField="TIME_CONTACT_ID" HeaderText="TIME_CONTACT_ID" SortExpression="TIME_CONTACT_ID" />
                                                <asp:BoundField DataField="BUDGET_ID" HeaderText="BUDGET_ID" SortExpression="BUDGET_ID" />
                                                <asp:BoundField DataField="SUBSTAFFTYPE_ID" HeaderText="SUBSTAFFTYPE_ID" SortExpression="SUBSTAFFTYPE_ID" />
                                                <asp:BoundField DataField="ADMIN_POSITION_ID" HeaderText="ADMIN_POSITION_ID" SortExpression="ADMIN_POSITION_ID" />
                                                <asp:BoundField DataField="POSITION_WORK_ID" HeaderText="POSITION_WORK_ID" SortExpression="POSITION_WORK_ID" />
                                                <asp:BoundField DataField="SPECIAL_NAME" HeaderText="SPECIAL_NAME" SortExpression="SPECIAL_NAME" />
                                                <asp:BoundField DataField="TEACH_ISCED_ID" HeaderText="TEACH_ISCED_ID" SortExpression="TEACH_ISCED_ID" />
                                                <asp:BoundField DataField="GRAD_LEV_ID" HeaderText="GRAD_LEV_ID" SortExpression="GRAD_LEV_ID" />
                                                <asp:BoundField DataField="GRAD_CURR" HeaderText="GRAD_CURR" SortExpression="GRAD_CURR" />
                                                <asp:BoundField DataField="GRAD_ISCED_ID" HeaderText="GRAD_ISCED_ID" SortExpression="GRAD_ISCED_ID" />
                                                <asp:BoundField DataField="GRAD_PROG_ID" HeaderText="GRAD_PROG_ID" SortExpression="GRAD_PROG_ID" />
                                                <asp:BoundField DataField="GRAD_UNIV" HeaderText="GRAD_UNIV" SortExpression="GRAD_UNIV" />
                                                <asp:BoundField DataField="GRAD_COUNTRY_ID" HeaderText="GRAD_COUNTRY_ID" SortExpression="GRAD_COUNTRY_ID" />
                                                <asp:BoundField DataField="BRANCH_ID" HeaderText="BRANCH_ID" SortExpression="BRANCH_ID" />
                                                <asp:BoundField DataField="RANK_ID" HeaderText="RANK_ID" SortExpression="RANK_ID" />
                                                <asp:BoundField DataField="GOT_ID" HeaderText="GOT_ID" SortExpression="GOT_ID" />
                                                <asp:BoundField DataField="GET_ID" HeaderText="GET_ID" SortExpression="GET_ID" />
                                                <asp:BoundField DataField="FACULTY_ID" HeaderText="FACULTY_ID" SortExpression="FACULTY_ID" />
                                                <asp:BoundField DataField="START_POSITION_WORK_ID" HeaderText="START_POSITION_WORK_ID" SortExpression="START_POSITION_WORK_ID" />
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_PERSON&quot;"></asp:SqlDataSource>
                                    </div>
                                </div>

                            </div>


                        </div>
                    </td>

                </tr>
            </table>


        </div>





    </div>

</asp:Content>
