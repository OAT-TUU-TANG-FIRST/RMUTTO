<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Late.aspx.cs" Inherits="WEB_PERSONAL.Late" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_TextBox11,#ContentPlaceHolder1_TextBox1").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        });
        function foggleOff() {
            for (var i = 1; i < 5; ++i) {
                var j = document.getElementById('sp' + i);
                j.style.display = 'none';
            }
            for (var i = 1; i < 5; ++i) {
                var j = document.getElementById('st' + i);
                j.className = 'master_light_toggle_button';
            }
        }
        function foggle(target) {
            foggleOff();
            $('#sp' + target).fadeIn(250);
            document.getElementById('st' + target).className = 'master_light_toggle_button_selected';
        }
    </script>

    <link href="CSS/Late.css" rel="stylesheet" />

    <div class="mp">
       

        <table class="master_light_table_div_sec">
            <tr>
                <td class="master_light_table_div_sec_td_left">
                    <div class="master_light_toggle_div_sec">
                        <div class="master_light_toggle_div_sec_title">เมนูการเข้างาน</div>
                        <div class="master_light_toggle_button" id="st1" onclick="foggle('1')">เพิ่มการเข้างาน</div>
                        <div class="master_light_toggle_button" id="st2" onclick="foggle('2')">แก้ไขการเข้างาน</div>
                        <div class="master_light_toggle_button" id="st3" onclick="foggle('3')">ข้อมูลการเข้างาน</div>
                        <div class="master_light_toggle_button" id="st4" onclick="foggle('4')">ข้อมูลการมาสาย</div>
                    </div>
                </td>
                <td class="master_light_table_div_sec_td_right">
                    <div class="master_clean_div_sec" id="sp1">
            <div class="master_clean_div_sec_title">
                เพิ่มเวลาเข้างาน
            </div>
            <div class="master_clean_div_sec_pre_in">
                <div class="master_clean_div_sec_in">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style83">
                                <asp:Label ID="Label41" runat="server" Text="วันที่"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style83">
                                <asp:Label ID="Label44" runat="server" Text="รหัสพนักงาน"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox21" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสประชาชน" MaxLength="13"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton20" runat="server" CssClass="master_clean_button" OnClick="LinkButton20_Click">ตรวจสอบ</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style83">
                                <asp:Label ID="Label47" runat="server" Text="ชื่อพนักงาน"></asp:Label>

                            </td>
                            <td class="auto-style67">
                                <asp:Label ID="Label45" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style83">
                                <asp:Label ID="Label39" runat="server" Text="เวลาเข้า"></asp:Label>
                            </td>
                            <td class="auto-style64">
                                <asp:TextBox ID="TextBox22" runat="server" Width="50px" placeholder="ชั่วโมง" CssClass="master_clean_textbox"></asp:TextBox>
                                <asp:TextBox ID="TextBox23" runat="server" Width="50px" placeholder="นาที" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style83">
                                <asp:Label ID="Label40" runat="server" Text="เวลาออก"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox24" runat="server" placeholder="ชั่วโมง" Width="50px" CssClass="master_clean_textbox"></asp:TextBox>
                                <asp:TextBox ID="TextBox25" runat="server" placeholder="นาที" Width="50px" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style81"></td>
                            <td class="auto-style64">
                                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="master_clean_button" OnClick="LinkButton11_Click">เพิ่ม</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style83">&nbsp;</td>
                            <td class="auto-style67">&nbsp;</td>
                        </tr>
                    </table>

                </div>
            </div>


        </div>


        <div class="master_clean_div_sec" id="sp2">
            <div class="master_clean_div_sec_title">
                แก้ไขเวลาเข้างาน
            </div>
            <div class="master_clean_div_sec_pre_in">
                <div class="master_clean_div_sec_in">

                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style85">&nbsp;</td>
                            <td class="auto-style67">
                                <asp:Label ID="Label50" runat="server" CssClass="error_text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label49" runat="server" Text="ค้นหารหัสเอกสาร"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox27" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton21" runat="server" CssClass="master_clean_button" OnClick="LinkButton21_Click">ค้นหา</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label48" runat="server" Text="รหัสเอกสาร"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox26" runat="server" CssClass="master_clean_textbox" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label2" runat="server" Text="วันที่"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label3" runat="server" Text="รหัสพนักงาน"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสประชาชน" MaxLength="13"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="master_clean_button" OnClick="LinkButton1_Click">ตรวจสอบ</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label4" runat="server" Text="ชื่อพนักงาน"></asp:Label>

                            </td>
                            <td class="auto-style67">
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label6" runat="server" Text="เวลาเข้า"></asp:Label>
                            </td>
                            <td class="auto-style64">
                                <asp:TextBox ID="TextBox3" runat="server" Width="50px" placeholder="ชั่วโมง" CssClass="master_clean_textbox"></asp:TextBox>
                                <asp:TextBox ID="TextBox4" runat="server" Width="50px" placeholder="นาที" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">
                                <asp:Label ID="Label7" runat="server" Text="เวลาออก"></asp:Label>
                            </td>
                            <td class="auto-style67">
                                <asp:TextBox ID="TextBox5" runat="server" placeholder="ชั่วโมง" Width="50px" CssClass="master_clean_textbox"></asp:TextBox>
                                <asp:TextBox ID="TextBox6" runat="server" placeholder="นาที" Width="50px" CssClass="master_clean_textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style84"></td>
                            <td class="auto-style64">
                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="master_clean_button" OnClick="LinkButton2_Click">แก้ไข</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style85">&nbsp;</td>
                            <td class="auto-style67">&nbsp;</td>
                        </tr>
                    </table>

                </div>
            </div>

        </div>

        <div class="master_clean_div_sec" id="sp3">
            <div class="master_clean_div_sec_title">
                รายชื่อการเข้างาน
            </div>
            <div class="master_clean_div_sec_pre_in">


                <div class="master_clean_div_sec_in">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnPageIndexChanged="GridView1_PageIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowDeleted="GridView1_RowDeleted">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="รหัส" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วันที่" SortExpression="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                            <asp:BoundField DataField="CITIZEN_ID" HeaderText="รหัสพนักงาน" SortExpression="CITIZEN_ID" />
                            <asp:BoundField DataField="PERSON_NAME||''||PERSON_LASTNAME" HeaderText="ชื่อพนักงาน" SortExpression="PERSON_NAME||''||PERSON_LASTNAME" />
                            <asp:BoundField DataField="HOUR_IN||':'||MINUTE_IN" HeaderText="เวลาเข้า" SortExpression="HOUR_IN||':'||MINUTE_IN" />
                            <asp:BoundField DataField="HOUR_OUT||':'||MINUTE_OUT" HeaderText="เวลาออก" SortExpression="HOUR_OUT||':'||MINUTE_OUT" />
                            <asp:CommandField ShowDeleteButton="true" DeleteText="ลบ" HeaderText="ลบ" ControlStyle-CssClass="master_clean_button" >
<ControlStyle CssClass="master_clean_button"></ControlStyle>
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT TB_WORK_CHECK_IN.ID, TO_CHAR(DDATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), TB_WORK_CHECK_IN.CITIZEN_ID, PERSON_NAME || ' ' || PERSON_LASTNAME, HOUR_IN || ':' || MINUTE_IN, HOUR_OUT || ':' || MINUTE_OUT FROM TB_WORK_CHECK_IN, TB_PERSON WHERE TB_WORK_CHECK_IN.CITIZEN_ID = TB_PERSON.CITIZEN_ID ORDER BY TB_WORK_CHECK_IN.ID DESC" DeleteCommand="DELETE TB_WORK_CHECK_IN WHERE ID = :ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" />
                        </DeleteParameters>
                    </asp:SqlDataSource>



                </div>
            </div>
        </div>

        <div class="master_clean_div_sec" id="sp4">
            <div class="master_clean_div_sec_title">
                รายชื่อการมาสาย
            </div>
            <div class="master_clean_div_sec_pre_in">
                <div class="master_clean_div_sec_in">

                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="รหัส" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วันที่" SortExpression="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                            <asp:BoundField DataField="CITIZEN_ID" HeaderText="รหัสพนักงาน" SortExpression="CITIZEN_ID" />
                            <asp:BoundField DataField="PERSON_NAME||''||PERSON_LASTNAME" HeaderText="ชื่อพนักงาน" SortExpression="PERSON_NAME||''||PERSON_LASTNAME" />
                            <asp:BoundField DataField="HOUR_IN||':'||MINUTE_IN" HeaderText="เวลาเข้า" SortExpression="HOUR_IN||':'||MINUTE_IN" />
                            <asp:BoundField DataField="HOUR_OUT||':'||MINUTE_OUT" HeaderText="เวลาออก" SortExpression="HOUR_OUT||':'||MINUTE_OUT" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT TB_WORK_CHECK_IN.ID, TO_CHAR(DDATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), TB_WORK_CHECK_IN.CITIZEN_ID, PERSON_NAME || ' ' || PERSON_LASTNAME, HOUR_IN || ':' || MINUTE_IN, HOUR_OUT || ':' || MINUTE_OUT FROM TB_WORK_CHECK_IN, TB_PERSON WHERE TB_WORK_CHECK_IN.CITIZEN_ID = TB_PERSON.CITIZEN_ID AND tb_work_check_in.hour_in*60 + tb_work_check_in.minute_in > 510 ORDER BY TB_WORK_CHECK_IN.ID DESC">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" />
                        </DeleteParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
        </div>
                </td>
            </tr>
        </table>

        

    </div>
</asp:Content>
