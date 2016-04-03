<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="WEB_PERSONAL.Leave" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style98 {
            width: 100px;
            text-align: right;
            margin-right: 10px;
            display: inline-block;
        }

        .auto-style99 {
            width: 150px;
            text-align: right;
            vertical-align: top;
            margin-right: 10px;
            display: inline-block;
        }

        .auto-style100 {
            width: 150px;
            text-align: right;
            height: 29px;
            margin-right: 10px;
            display: inline-block;
        }
        .auto-style101 {
            text-decoration: none;
            color: #000000;
            background-color: #e0e0e0;
            padding-bottom: 1px;
/*border-radius: 24px;*/color: #FFFFFF;
            background-color: #00a2e8;
            display: inline-block;
            text-align: center;
            transition: background-color ease 0.25s;
            cursor: pointer;
            padding-left: 20px;
            padding-right: 20px;
            padding-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_TextBox2,#ContentPlaceHolder1_TextBox5,#ContentPlaceHolder1_TextBox6,#ContentPlaceHolder1_TextBox9,#ContentPlaceHolder1_TextBox17,#ContentPlaceHolder1_TextBox18").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
        });
        function foggleOff() {
            for (var i = 1; i < 6; ++i) {
                var j = document.getElementById('sp' + i);
                j.style.display = 'none';
            }
            for (var i = 1; i < 6; ++i) {
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

    <link href="CSS/Leave.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="mp">


        <table class="master_light_table_div_sec">
            <tr>
                <td class="master_light_table_div_sec_td_left">
                    <div class="master_light_toggle_div_sec">
                        <div class="master_light_toggle_div_sec_title">เมนูการลา</div>
                        <div class="master_light_toggle_button" id="st1" onclick="foggle('1')">เพิ่มข้อมูลการลา</div>
                        <div class="master_light_toggle_button" id="st2" onclick="foggle('2')">แก้ไขข้อมูลการลา</div>
                        <div class="master_light_toggle_button" id="st3" onclick="foggle('3')">จัดการประเภทการลา</div>
                        <div class="master_light_toggle_button" id="st4" onclick="foggle('4')">กราฟ</div>
                        <div class="master_light_toggle_button" id="st5" onclick="foggle('5')">ข้อมูลการลา</div>
                    </div>
                </td>
                <td class="master_light_table_div_sec_td_right">

                    <div class="master_clean_div_sec" id="sp1">
                        <div class="master_clean_div_sec_title">
                            เพิ่มเอกสารการลา
                        </div>
                        <div class="master_clean_div_sec_pre_in">


                            <div class="master_clean_div_sec_in">

                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label23" runat="server" Text="รหัสผู้ลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:Panel ID="Panel5" runat="server" DefaultButton="LinkButton17">
                                                <asp:TextBox ID="TextBox16" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสประชาชน" MaxLength="13"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton17" runat="server" CssClass="master_clean_button" OnClick="Button1_Click2">ตรวจสอบ</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label46" runat="server" Text="ชื่อผู้ลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:Label ID="Label24" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label25" runat="server" Text="ประเภทการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style64">
                                            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource3" DataTextField="LEAVE_TYPE_NAME" DataValueField="LEAVE_TYPE_ID" CssClass="master_clean_dropdown" OnDataBound="DropDownList5_DataBound">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label26" runat="server" Text="สถานะการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource1" DataTextField="LEAVE_STATUS_NAME" DataValueField="LEAVE_STATUS_ID" CssClass="master_clean_dropdown" OnDataBound="DropDownList6_DataBound">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label27" runat="server" Text="จากวันที่"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:TextBox ID="TextBox17" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label28" runat="server" Text="ถึงวันที่"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:TextBox ID="TextBox18" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">
                                            <asp:Label ID="Label29" runat="server" Text="เหตุผล"></asp:Label>
                                        </td>
                                        <td class="auto-style69">
                                            <asp:TextBox ID="TextBox19" runat="server" Height="85px" TextMode="MultiLine" Width="298px" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style98">&nbsp;</td>
                                        <td class="auto-style67">
                                            <asp:LinkButton ID="LinkButton16" runat="server" CssClass="master_clean_button" OnClick="LinkButton16_Click">เพิ่ม</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </div>

                    <div class="master_clean_div_sec" id="sp2">
                        <div class="master_clean_div_sec_title">
                            แก้ไขเอกสารการลา
                        </div>
                        <div class="master_clean_div_sec_pre_in">


                            <div class="master_clean_div_sec_in">

                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style99">&nbsp;</td>
                                        <td class="auto-style77">
                                            <asp:Label ID="Label20" runat="server" CssClass="error_text"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label21" runat="server" Text="ค้นหาตามรหัสเอกสาร"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LinkButton18">
                                                <asp:TextBox ID="TextBox15" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton18" runat="server" CssClass="master_clean_button" OnClick="LinkButton18_Click">ค้นหา</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label7" runat="server" Text="รหัสเอกสาร"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Label ID="Label33" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style100">
                                            <asp:Label ID="Label8" runat="server" Text="วันที่เอกสาร"></asp:Label>
                                        </td>
                                        <td class="auto-style79">
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label9" runat="server" Text="รหัสผู้ลา"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Panel ID="Panel3" runat="server" DefaultButton="LinkButton14">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสประชาชน" MaxLength="13"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton14" runat="server" CssClass="master_clean_button" OnClick="LinkButton14_Click">ตรวจสอบ</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label17" runat="server" Text="ชื่อผู้ลา"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Label ID="Label31" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label14" runat="server" Text="รหัสผู้อนุมัติ"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Panel ID="Panel4" runat="server" DefaultButton="LinkButton15">
                                                <asp:TextBox ID="TextBox8" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสประชาชน" MaxLength="13"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton15" runat="server" CssClass="master_clean_button" OnClick="LinkButton15_Click">ตรวจสอบ</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label19" runat="server" Text="ชื่อผู้อนุมัติ"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:Label ID="Label32" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label15" runat="server" Text="วันที่อนุมัติ"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label10" runat="server" Text="ประเภทการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="LEAVE_TYPE_NAME" DataValueField="LEAVE_TYPE_ID" CssClass="master_clean_dropdown" OnDataBound="DropDownList1_DataBound">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label13" runat="server" Text="สถานะการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="LEAVE_STATUS_NAME" DataValueField="LEAVE_STATUS_ID" CssClass="master_clean_dropdown" OnDataBound="DropDownList2_DataBound">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label11" runat="server" Text="จากวันที่"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label12" runat="server" Text="ถึงวันที่"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">
                                            <asp:Label ID="Label16" runat="server" Text="เหตุผลที่ลา"></asp:Label>
                                        </td>
                                        <td class="auto-style77">
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="master_clean_textbox" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style99">&nbsp;</td>
                                        <td class="auto-style77">
                                            <asp:LinkButton ID="LinkButton13" runat="server" CssClass="master_clean_button" OnClick="LinkButton13_Click">แก้ไข</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_LEAVE_STATUS&quot;"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_LEAVE_TYPE&quot;"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_LEAVE&quot;"></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>




                    <div class="master_clean_div_sec" id="sp3">
                        <div class="master_clean_div_sec_title">
                            จัดการประเภทการลา
                        </div>
                        <div class="master_clean_div_sec_pre_in">


                            <div class="master_clean_div_sec_in">

                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style95">
                                            <asp:Label ID="Label22" runat="server" Text="เพิ่มประเภทการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:Panel ID="Panel2" runat="server" DefaultButton="LinkButton2">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="master_clean_textbox" placeHolder="ชื่อ"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="master_clean_button" OnClick="LinkButton2_Click">เพิ่ม</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style95">
                                            <asp:Label ID="Label47" runat="server" Text="แก้ไขประเภทการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="SqlDataSource3" DataTextField="LEAVE_TYPE_NAME" DataValueField="LEAVE_TYPE_ID" CssClass="master_clean_dropdown" OnDataBound="DropDownList8_DataBound" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:Panel ID="Panel7" runat="server" DefaultButton="LinkButton19">
                                                <asp:TextBox ID="TextBox20" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton19" runat="server" CssClass="master_clean_button" OnClick="LinkButton19_Click">แก้ไข</asp:LinkButton>
                                            </asp:Panel>


                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style95">
                                            <asp:Label ID="Label30" runat="server" Text="ลบประเภทการลา"></asp:Label>
                                        </td>
                                        <td class="auto-style67">
                                            <asp:Panel ID="Panel6" runat="server" DefaultButton="LinkButton1">
                                                <asp:TextBox ID="TextBox11" runat="server" CssClass="master_clean_textbox" placeHolder="รหัส"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="master_clean_button" OnClick="LinkButton1_Click1">ลบ</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style95">&nbsp;</td>
                                        <td class="auto-style67">&nbsp;</td>
                                    </tr>
                                </table>

                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="LEAVE_TYPE_ID" DataSourceID="SqlDataSource5" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="LEAVE_TYPE_ID" HeaderText="รหัสประเภทการลา" ReadOnly="True" SortExpression="LEAVE_TYPE_ID" />
                                        <asp:BoundField DataField="LEAVE_TYPE_NAME" HeaderText="ชื่อประเภทการลา" SortExpression="LEAVE_TYPE_NAME" />
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

                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM TB_LEAVE_TYPE">
                                    <UpdateParameters>
                                        <asp:Parameter Name="LEAVE_TYPE_NAME" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>

                            </div>
                        </div>
                    </div>

                    <div id="sp4">
                        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource6" Style="font-family: 'WDB Bangna';" Height="600px" Width="800px">
                            <Series>
                                <asp:Series Name="Series1" XValueMember="LEAVE_TYPE_NAME" YValueMembers="COUNT(TB_LEAVE.LEAVE_TYPE_ID)"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>

                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="select leave_type_name, count(tb_leave.leave_type_id) from tb_leave, tb_leave_type where tb_leave.leave_type_id = tb_leave_type.leave_type_id group by leave_type_name"></asp:SqlDataSource>
                    </div>

                    <div class="master_clean_div_sec" id="sp5">
                        <div class="master_clean_div_sec_title">
                            ข้อมูลเอกสารการลา
                        </div>
                        <div class="master_clean_div_sec_pre_in">


                            <div class="master_clean_div_sec_in">





                                <table>
                                    <tr>
                                        <td class="auto-style58">&nbsp;</td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="master_clean_button">ทั้งหมด</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style96">
                                            <asp:Label ID="Label2" runat="server" Text="ค้นหาตามสถานะ"></asp:Label>
                                        </td>
                                        <td class="auto-style97">
                                            <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" CssClass="master_clean_dropdown" DataSourceID="SqlDataSource1" DataTextField="LEAVE_STATUS_NAME" DataValueField="LEAVE_STATUS_ID" OnDataBound="DropDownList7_DataBound" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label18" runat="server" Text="ค้นหาตามประเภท"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="LEAVE_TYPE_NAME" DataValueField="LEAVE_TYPE_ID" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" CssClass="master_clean_dropdown" OnDataBound="DropDownList4_DataBound"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>

                                <table>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label3" runat="server" Text="ค้นหาตามรหัสผู้ลา"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel8" runat="server" DefaultButton="LinkButton7">
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="master_clean_textbox" MaxLength="13"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton7" runat="server" CssClass="master_clean_button" OnClick="LinkButton7_Click">ค้นหา</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label5" runat="server" Text="ค้นหาตามชื่อผู้ลา"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel9" runat="server" DefaultButton="LinkButton9">
                                                <asp:TextBox ID="TextBox12" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton9" runat="server" CssClass="master_clean_button" OnClick="LinkButton9_Click">ค้นหา</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label4" runat="server" Text="ค้นหาตามรหัสผู้อนุมัติ"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel10" runat="server" DefaultButton="LinkButton8">
                                                <asp:TextBox ID="TextBox7" runat="server" CssClass="master_clean_textbox" MaxLength="13"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton8" runat="server" CssClass="master_clean_button" OnClick="LinkButton8_Click">ค้นหา</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label6" runat="server" Text="ค้นหาตามชื่อผู้อนุมัติ"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel11" runat="server">
                                                <asp:TextBox ID="TextBox14" runat="server" CssClass="master_clean_textbox"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton10" runat="server" CssClass="master_clean_button" OnClick="LinkButton10_Click">ค้นหา</asp:LinkButton>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style58">
                                            <asp:Label ID="Label48" runat="server" Text="ลบข้อมูล"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Panel ID="Panel12" runat="server" DefaultButton="LinkButton20">
                                                <asp:TextBox ID="TextBox21" runat="server" CssClass="master_clean_textbox" placeHolder="รหัสเอกสาร"></asp:TextBox>
                                                <asp:LinkButton ID="LinkButton20" runat="server" CssClass="master_clean_button" OnClick="LinkButton20_Click">ลบ</asp:LinkButton>
                                            </asp:Panel>
                                                

                                        </td>
                                    </tr>
                                </table>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton3" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton7" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton8" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton9" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton10" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="LinkButton20" EventName="click" />
                                        <asp:AsyncPostBackTrigger ControlID="DropDownList7" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="DropDownList4" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="LEAVE_ID" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource2">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>

                                                <asp:BoundField DataField="LEAVE_ID" HeaderText="รหัสเอกสาร" ReadOnly="True" SortExpression="LEAVE_ID" />
                                                <asp:BoundField DataField="TO_CHAR(TB_LEAVE.PAPER_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วันที่เอกสาร" SortExpression="TO_CHAR(TB_LEAVE.PAPER_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                                                <asp:BoundField DataField="CITIZEN_ID" HeaderText="รหัสผู้ลา" SortExpression="CITIZEN_ID" />
                                                <asp:BoundField DataField="A.PERSON_NAME||''||A.PERSON_LASTNAME" HeaderText="ชื่อผู้ลา" SortExpression="A.PERSON_NAME||''||A.PERSON_LASTNAME" />
                                                <asp:BoundField DataField="LEAVE_TYPE_NAME" HeaderText="ประเภทการลา" SortExpression="LEAVE_TYPE_NAME" />
                                                <asp:BoundField DataField="TO_CHAR(TB_LEAVE.LEAVE_FROM_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="จากวันที่" SortExpression="TO_CHAR(TB_LEAVE.LEAVE_FROM_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                                                <asp:BoundField DataField="TO_CHAR(TB_LEAVE.LEAVE_TO_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="ถึงวันที่" SortExpression="TO_CHAR(TB_LEAVE.LEAVE_TO_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                                                <asp:BoundField DataField="LEAVE_STATUS_NAME" HeaderText="สถานะ" SortExpression="LEAVE_STATUS_NAME" />
                                                <asp:BoundField DataField="APPROVER_ID" HeaderText="รหัสผู้อนุมัติ" SortExpression="APPROVER_ID" />
                                                <asp:BoundField DataField="B.PERSON_NAME||''||B.PERSON_LASTNAME" HeaderText="ชื่อผู้อนุมัติ" SortExpression="B.PERSON_NAME||''||B.PERSON_LASTNAME" />
                                                <asp:BoundField DataField="TO_CHAR(TB_LEAVE.APPROVE_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วันที่อนุมัติ" SortExpression="TO_CHAR(TB_LEAVE.APPROVE_DATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                                                <asp:BoundField DataField="REASON" HeaderText="เหตุผล" SortExpression="REASON" />
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
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="select tb_leave.LEAVE_ID, TO_CHAR(tb_leave.PAPER_DATE, 'dd MON yyyy', 'NLS_DATE_LANGUAGE = THAI'), tb_leave.CITIZEN_ID, a.PERSON_NAME || ' ' || a.PERSON_LASTNAME, tb_leave_type.LEAVE_TYPE_NAME, TO_CHAR(tb_leave.LEAVE_FROM_DATE, 'dd MON yyyy', 'NLS_DATE_LANGUAGE = THAI'), TO_CHAR(tb_leave.LEAVE_TO_DATE, 'dd MON yyyy', 'NLS_DATE_LANGUAGE = THAI'), TB_LEAVE_STATUS.LEAVE_STATUS_NAME, TB_LEAVE.APPROVER_ID, b.PERSON_NAME || ' ' || b.PERSON_LASTNAME, TO_CHAR(tb_leave.APPROVE_DATE, 'dd MON yyyy', 'NLS_DATE_LANGUAGE = THAI'), TB_LEAVE.REASON from tb_person a,tb_person b,tb_leave,tb_leave_type,TB_LEAVE_STATUS where tb_leave.LEAVE_TYPE_ID = TB_LEAVE_TYPE.LEAVE_TYPE_ID AND TB_LEAVE.LEAVE_STATUS_ID = TB_LEAVE_STATUS.LEAVE_STATUS_ID AND a.CITIZEN_ID = tb_leave.CITIZEN_ID AND b.CITIZEN_ID = tb_leave.APPROVER_ID order by tb_leave.LEAVE_ID desc" DeleteCommand="DELETE TB_LEAVE WHERE LEAVE_ID = :LEAVE_ID">
                                            <DeleteParameters>
                                                <asp:Parameter Name="LEAVE_ID" />
                                            </DeleteParameters>
                                        </asp:SqlDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                            </div>
                        </div>
                    </div>

                    
                </td>
            </tr>
        </table>




    </div>
</asp:Content>
