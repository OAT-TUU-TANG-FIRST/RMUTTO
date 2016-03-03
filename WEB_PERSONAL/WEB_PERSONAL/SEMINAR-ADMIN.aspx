<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SEMINAR-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.SEMINAR_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtDateFrom,#ContentPlaceHolder1_txtDateTO").datepicker($.datepicker.regional["th"]);
        };
    </script>
    <style type="text/CSS">
        .multext {
            resize: none;
        }

        .a1 {
            border-radius: 20px;
            padding: 5px 10px;
            background-color: #00ff21;
            text-decoration: none;
            color: black;
            text-align: center;
        }

        .divpan {
            text-align: center;
        }

        body {
            background-image: url("Image/444.png");
        }

        .tb5 {
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
    </style>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchSeminar">
       <div>
            <fieldset>
                <legend>ค้นหา</legend>
                  <div>
                            เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchSeminarCitizen" runat="server" CssClass="tb5" Width="230px" MaxLength="13"></asp:TextBox>
                            <asp:Button ID="btnSearchSeminar" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchSeminar_Click" />     
                            <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick = "btnSearchRefresh_Click" />
                </div>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อ:&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtSearchSeminarName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: right; margin-right: 5px;">นามสกุล :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSearchSeminarLastName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน :&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtSearchSeminarNameOfProject" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">สถานที่ฝึกอบรม/สัมมนา/ดูงาน :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSearchSeminarPlace" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Pane_grid" runat="server" BackColor="WhiteSmoke" Width="100%" ScrollBars="Both" Height="200px">
         <asp:GridView ID="GridView1" runat="server" EmptyDataText="Record not found!" ShowHeaderWhenEmpty="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="SEMINAR_ID" DataSourceID="Oracel_TB_Training" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:CommandField ShowDeleteButton="True" HeaderText="ลบ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;เลือก" ShowSelectButton="True" />
                 <asp:TemplateField HeaderText="SEMINAR_ID" SortExpression="SEMINAR_ID" Visible="false">
                     <EditItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("SEMINAR_ID") %>'></asp:Label>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("SEMINAR_ID") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField ControlStyle-Width="250px" DataField="SEMINAR_NAME" HeaderStyle-Width="250px" HeaderText="ชื่อ" ItemStyle-Width="250px" SortExpression="SEMINAR_NAME">
                 <ControlStyle Width="250px" />
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_LASTNAME" HeaderStyle-Width="250px" HeaderText="นามสกุล" ItemStyle-Width="250px" SortExpression="SEMINAR_LASTNAME">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_POSITION" HeaderStyle-Width="250px" HeaderText="ตำแหน่ง" ItemStyle-Width="250px" SortExpression="SEMINAR_POSITION" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_DEGREE" HeaderStyle-Width="250px" HeaderText="ระดับ" ItemStyle-Width="250px" SortExpression="SEMINAR_DEGREE" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_CAMPUS" HeaderStyle-Width="250px" HeaderText="สังกัด" ItemStyle-Width="250px" SortExpression="SEMINAR_CAMPUS" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_NAMEOFPROJECT" HeaderStyle-Width="250px" HeaderText="ชื่อโครงการฝึกอบรบ/สัมมนา/ดูงาน" ItemStyle-Width="250px" SortExpression="SEMINAR_NAMEOFPROJECT">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_PLACE" HeaderStyle-Width="250px" HeaderText="สถานที่ฝึกอบรบ/สัมมนา/ดูงาน" ItemStyle-Width="250px" SortExpression="SEMINAR_PLACE">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_DATETIME_FROM" HeaderStyle-Width="250px" HeaderText="ตั้งแต่วันที่" ItemStyle-Width="250px" SortExpression="SEMINAR_DATETIME_FROM" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_DATETIME_TO" HeaderStyle-Width="250px" HeaderText="ถึงวันที่" ItemStyle-Width="250px" SortExpression="SEMINAR_DATETIME_TO" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_DAY" HeaderStyle-Width="250px" HeaderText="วัน" ItemStyle-Width="250px" SortExpression="SEMINAR_DAY" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_MONTH" HeaderStyle-Width="250px" HeaderText="เดือน" ItemStyle-Width="250px" SortExpression="SEMINAR_MONTH" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_YEAR" HeaderStyle-Width="250px" HeaderText="ปี" ItemStyle-Width="250px" SortExpression="SEMINAR_YEAR" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_BUDGET" HeaderStyle-Width="250px" HeaderText="ค่าใช้จ่ายตลอดโครงการ" ItemStyle-Width="250px" SortExpression="SEMINAR_BUDGET" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SUPPORT_BUDGET" HeaderStyle-Width="250px" HeaderText="แหล่งงประมาณที่ได้รับการสนับสนุน" ItemStyle-Width="250px" SortExpression="SEMINAR_SUPPORT_BUDGET" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_CERTIFICATE" HeaderStyle-Width="250px" HeaderText="ประกาศณียบัตรที่ได้รับ (ถ้ามี)" ItemStyle-Width="250px" SortExpression="SEMINAR_CERTIFICATE" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_ABSTRACT" HeaderStyle-Width="250px" HeaderText="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน" ItemStyle-Width="250px" SortExpression="SEMINAR_ABSTRACT" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_RESULT" HeaderStyle-Width="250px" HeaderText="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน" ItemStyle-Width="250px" SortExpression="SEMINAR_RESULT" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SHOW_1" HeaderStyle-Width="250px" HeaderText="ด้านการเรียนการสอน" ItemStyle-Width="250px" SortExpression="SEMINAR_SHOW_1" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SHOW_2" HeaderStyle-Width="250px" HeaderText="ด้านการวิจัย" ItemStyle-Width="250px" SortExpression="SEMINAR_SHOW_2" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SHOW_3" HeaderStyle-Width="250px" HeaderText="ด้านการบริการวิชาการ" ItemStyle-Width="250px" SortExpression="SEMINAR_SHOW_3" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SHOW_4" HeaderStyle-Width="250px" HeaderText="ด้านอื่นๆ" ItemStyle-Width="250px" SortExpression="SEMINAR_SHOW_4" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_PROBLEM" HeaderStyle-Width="250px" HeaderText="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน" ItemStyle-Width="250px" SortExpression="SEMINAR_PROBLEM" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_COMMENT" HeaderStyle-Width="250px" HeaderText="ความคิดเห็นข้อเสนอแนะอื่นๆ" ItemStyle-Width="250px" SortExpression="SEMINAR_COMMENT" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="SEMINAR_SIGNED_DATETIME" HeaderStyle-Width="250px" HeaderText="เวลาบันทึก" ItemStyle-Width="250px" SortExpression="SEMINAR_SIGNED_DATETIME" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
                 <asp:BoundField DataField="CITIZEN_ID" HeaderStyle-Width="250px" HeaderText="CITIZEN_ID" ItemStyle-Width="250px" SortExpression="CITIZEN_ID" Visible="false">
                 <HeaderStyle Width="250px" />
                 <ItemStyle Width="250px" />
                 </asp:BoundField>
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
    

    <asp:SqlDataSource ID="Oracel_TB_Training" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" DeleteCommand="DELETE FROM &quot;TB_SEMINAR&quot; WHERE &quot;SEMINAR_ID&quot; = :SEMINAR_ID" InsertCommand="INSERT INTO &quot;TB_SEMINAR&quot; (&quot;SEMINAR_ID&quot;, &quot;SEMINAR_NAME&quot;, &quot;SEMINAR_LASTNAME&quot;, &quot;SEMINAR_POSITION&quot;, &quot;SEMINAR_DEGREE&quot;, &quot;SEMINAR_CAMPUS&quot;, &quot;SEMINAR_NAMEOFPROJECT&quot;, &quot;SEMINAR_PLACE&quot;, &quot;SEMINAR_DATETIME_FROM&quot;, &quot;SEMINAR_DATETIME_TO&quot;, &quot;SEMINAR_DAY&quot;, &quot;SEMINAR_MONTH&quot;, &quot;SEMINAR_YEAR&quot;, &quot;SEMINAR_BUDGET&quot;, &quot;SEMINAR_SUPPORT_BUDGET&quot;, &quot;SEMINAR_CERTIFICATE&quot;, &quot;SEMINAR_ABSTRACT&quot;, &quot;SEMINAR_RESULT&quot;, &quot;SEMINAR_SHOW_1&quot;, &quot;SEMINAR_SHOW_2&quot;, &quot;SEMINAR_SHOW_3&quot;, &quot;SEMINAR_SHOW_4&quot;, &quot;SEMINAR_PROBLEM&quot;, &quot;SEMINAR_COMMENT&quot;, &quot;SEMINAR_SIGNED_DATETIME&quot;, &quot;CITIZEN_ID&quot;) VALUES (:SEMINAR_ID, :SEMINAR_NAME, :SEMINAR_LASTNAME, :SEMINAR_POSITION, :SEMINAR_DEGREE, :SEMINAR_CAMPUS, :SEMINAR_NAMEOFPROJECT, :SEMINAR_PLACE, :SEMINAR_DATETIME_FROM, :SEMINAR_DATETIME_TO, :SEMINAR_DAY, :SEMINAR_MONTH, :SEMINAR_YEAR, :SEMINAR_BUDGET, :SEMINAR_SUPPORT_BUDGET, :SEMINAR_CERTIFICATE, :SEMINAR_ABSTRACT, :SEMINAR_RESULT, :SEMINAR_SHOW_1, :SEMINAR_SHOW_2, :SEMINAR_SHOW_3, :SEMINAR_SHOW_4, :SEMINAR_PROBLEM, :SEMINAR_COMMENT, :SEMINAR_SIGNED_DATETIME, :CITIZEN_ID)" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_SEMINAR&quot;" UpdateCommand="UPDATE &quot;TB_SEMINAR&quot; SET &quot;SEMINAR_NAME&quot; = :SEMINAR_NAME, &quot;SEMINAR_LASTNAME&quot; = :SEMINAR_LASTNAME, &quot;SEMINAR_POSITION&quot; = :SEMINAR_POSITION, &quot;SEMINAR_DEGREE&quot; = :SEMINAR_DEGREE, &quot;SEMINAR_CAMPUS&quot; = :SEMINAR_CAMPUS, &quot;SEMINAR_NAMEOFPROJECT&quot; = :SEMINAR_NAMEOFPROJECT, &quot;SEMINAR_PLACE&quot; = :SEMINAR_PLACE, &quot;SEMINAR_DATETIME_FROM&quot; = :SEMINAR_DATETIME_FROM, &quot;SEMINAR_DATETIME_TO&quot; = :SEMINAR_DATETIME_TO, &quot;SEMINAR_DAY&quot; = :SEMINAR_DAY, &quot;SEMINAR_MONTH&quot; = :SEMINAR_MONTH, &quot;SEMINAR_YEAR&quot; = :SEMINAR_YEAR, &quot;SEMINAR_BUDGET&quot; = :SEMINAR_BUDGET, &quot;SEMINAR_SUPPORT_BUDGET&quot; = :SEMINAR_SUPPORT_BUDGET, &quot;SEMINAR_CERTIFICATE&quot; = :SEMINAR_CERTIFICATE, &quot;SEMINAR_ABSTRACT&quot; = :SEMINAR_ABSTRACT, &quot;SEMINAR_RESULT&quot; = :SEMINAR_RESULT, &quot;SEMINAR_SHOW_1&quot; = :SEMINAR_SHOW_1, &quot;SEMINAR_SHOW_2&quot; = :SEMINAR_SHOW_2, &quot;SEMINAR_SHOW_3&quot; = :SEMINAR_SHOW_3, &quot;SEMINAR_SHOW_4&quot; = :SEMINAR_SHOW_4, &quot;SEMINAR_PROBLEM&quot; = :SEMINAR_PROBLEM, &quot;SEMINAR_COMMENT&quot; = :SEMINAR_COMMENT, &quot;SEMINAR_SIGNED_DATETIME&quot; = :SEMINAR_SIGNED_DATETIME, &quot;CITIZEN_ID&quot; = :CITIZEN_ID WHERE &quot;SEMINAR_ID&quot; = :SEMINAR_ID">
        <DeleteParameters>
            <asp:Parameter Name="SEMINAR_ID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SEMINAR_ID" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_NAME" Type="String" />
            <asp:Parameter Name="SEMINAR_LASTNAME" Type="String" />
            <asp:Parameter Name="SEMINAR_POSITION" Type="String" />
            <asp:Parameter Name="SEMINAR_DEGREE" Type="String" />
            <asp:Parameter Name="SEMINAR_CAMPUS" Type="String" />
            <asp:Parameter Name="SEMINAR_NAMEOFPROJECT" Type="String" />
            <asp:Parameter Name="SEMINAR_PLACE" Type="String" />
            <asp:Parameter Name="SEMINAR_DATETIME_FROM" Type="DateTime" />
            <asp:Parameter Name="SEMINAR_DATETIME_TO" Type="DateTime" />
            <asp:Parameter Name="SEMINAR_DAY" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_MONTH" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_YEAR" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_BUDGET" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_SUPPORT_BUDGET" Type="String" />
            <asp:Parameter Name="SEMINAR_CERTIFICATE" Type="String" />
            <asp:Parameter Name="SEMINAR_ABSTRACT" Type="String" />
            <asp:Parameter Name="SEMINAR_RESULT" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_1" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_2" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_3" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_4" Type="String" />
            <asp:Parameter Name="SEMINAR_PROBLEM" Type="String" />
            <asp:Parameter Name="SEMINAR_COMMENT" Type="String" />
            <asp:Parameter Name="SEMINAR_SIGNED_DATETIME" Type="DateTime" />
            <asp:Parameter Name="CITIZEN_ID" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="SEMINAR_NAME" Type="String" />
            <asp:Parameter Name="SEMINAR_LASTNAME" Type="String" />
            <asp:Parameter Name="SEMINAR_POSITION" Type="String" />
            <asp:Parameter Name="SEMINAR_DEGREE" Type="String" />
            <asp:Parameter Name="SEMINAR_CAMPUS" Type="String" />
            <asp:Parameter Name="SEMINAR_NAMEOFPROJECT" Type="String" />
            <asp:Parameter Name="SEMINAR_PLACE" Type="String" />
            <asp:Parameter Name="SEMINAR_DATETIME_FROM" Type="DateTime" />
            <asp:Parameter Name="SEMINAR_DATETIME_TO" Type="DateTime" />
            <asp:Parameter Name="SEMINAR_DAY" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_MONTH" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_YEAR" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_BUDGET" Type="Decimal" />
            <asp:Parameter Name="SEMINAR_SUPPORT_BUDGET" Type="String" />
            <asp:Parameter Name="SEMINAR_CERTIFICATE" Type="String" />
            <asp:Parameter Name="SEMINAR_ABSTRACT" Type="String" />
            <asp:Parameter Name="SEMINAR_RESULT" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_1" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_2" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_3" Type="String" />
            <asp:Parameter Name="SEMINAR_SHOW_4" Type="String" />
            <asp:Parameter Name="SEMINAR_PROBLEM" Type="String" />
            <asp:Parameter Name="SEMINAR_COMMENT" Type="String" />
            <asp:Parameter Name="SEMINAR_SIGNED_DATETIME" Type="DateTime" />
            <asp:Parameter Name="CITIZEN_ID" Type="String" />
            <asp:Parameter Name="SEMINAR_ID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSaveSeminar">
        <div>
            <fieldset>
                <legend>แก้ไขข้อมูลการฝึกอบรม/สัมมนา/ดูงาน</legend>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">1. </td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อ<span class="textred">*</span> :&nbsp;</td>
                            <td style="text-align: left; width: 50px;">
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
                                <asp:TextBox ID="txtPlace" runat="server" MaxLength="100" Width="718px" CssClass="tb5" Placeholder="สถานที่ฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ตั้งแต่วันที่<span class="textred">*</span> </td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetxtDateFrom" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" CssClass="tb5" OnTextChanged="txtDateFrom_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDateFrom" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ถึงวันที่<span class="textred">*</span></td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetxtDateTO" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateTO" runat="server" Width="180px" OnTextChanged="txtDateTO_TextChanged" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
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
                                <asp:UpdatePanel ID="UpdatetxtDay" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDay" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                            <td style="text-align: left; margin-right: 5px;">วัน</td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtMonth" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMonth" runat="server" MaxLength="100" Width="50px" Enabled="False" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; margin-right: 5px;">เดือน</td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtYear" runat="server">
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
                                        <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" Width="753px" Enabled="False" Text="ไม่มี" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
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
                            <td style="text-align: left; margin-right: 10px;">5. สรุปผลการฝึกอบรม/สัมมนา/ดูงาน </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtAbstract" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="สรุปผลการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">6. ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน </td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtResult" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
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
                                <asp:TextBox ID="txtShow1" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการเรียนการสอน"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.2 ด้านการวิจัย </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow2" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการวิจัย"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.3 ด้านการบริการวิชาการ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow3" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านการบริการวิชาการ"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.4 ด้านอื่นๆ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow4" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ด้านอื่นๆ"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">8. ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtProblem" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5" Placeholder="ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">9. ความคิดเห็น/ข้อเสนอแนะอื่นๆ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtComment" runat="server" MaxLength="1000" TextMode="MultiLine" Height="100px" Width="955px" CssClass="tb5" Placeholder="ความคิดเห็น/ข้อเสนอแนะอื่นๆ"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:Button ID="btnCancelSeminar" Text="Cancel" runat="server" OnClick="btnCancelSeminar_Click" Width="140px" CssClass="master_OAT_button" /></td>
                            <td style="text-align: left; width: 50px;"></td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:Button ID="btnSaveSeminar" Text="OK" runat="server" OnClick="btnSubmitSeminar_Click" Width="140px" CssClass="master_OAT_button" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>