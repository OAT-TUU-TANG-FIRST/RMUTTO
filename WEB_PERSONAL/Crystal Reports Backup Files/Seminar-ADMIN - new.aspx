<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Seminar-ADMIN - new.aspx.cs" Inherits="WEB_PERSONAL.Seminar_ADMIN___new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    

    <asp:SqlDataSource ID="Oracel_TB_Training" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" DeleteCommand="DELETE FROM &quot;TB_SEMINAR&quot; WHERE &quot;SEMINAR_ID&quot; = :SEMINAR_ID" InsertCommand="INSERT INTO &quot;TB_SEMINAR&quot; (&quot;SEMINAR_ID&quot;, &quot;SEMINAR_NAME&quot;, &quot;SEMINAR_LASTNAME&quot;, &quot;SEMINAR_POSITION&quot;, &quot;SEMINAR_DEGREE&quot;, &quot;SEMINAR_CAMPUS&quot;, &quot;SEMINAR_NAMEOFPROJECT&quot;, &quot;SEMINAR_PLACE&quot;, &quot;SEMINAR_DATETIME_FROM&quot;, &quot;SEMINAR_DATETIME_TO&quot;, &quot;SEMINAR_DAY&quot;, &quot;SEMINAR_MONTH&quot;, &quot;SEMINAR_YEAR&quot;, &quot;SEMINAR_BUDGET&quot;, &quot;SEMINAR_SUPPORT_BUDGET&quot;, &quot;SEMINAR_CERTIFICATE&quot;, &quot;SEMINAR_ABSTRACT&quot;, &quot;SEMINAR_RESULT&quot;, &quot;SEMINAR_SHOW_1&quot;, &quot;SEMINAR_SHOW_2&quot;, &quot;SEMINAR_SHOW_3&quot;, &quot;SEMINAR_SHOW_4&quot;, &quot;SEMINAR_PROBLEM&quot;, &quot;SEMINAR_COMMENT&quot;, &quot;SEMINAR_SIGNED_DATETIME&quot;, &quot;CITIZEN_ID&quot;) VALUES (:SEMINAR_ID, :SEMINAR_NAME, :SEMINAR_LASTNAME, :SEMINAR_POSITION, :SEMINAR_DEGREE, :SEMINAR_CAMPUS, :SEMINAR_NAMEOFPROJECT, :SEMINAR_PLACE, :SEMINAR_DATETIME_FROM, :SEMINAR_DATETIME_TO, :SEMINAR_DAY, :SEMINAR_MONTH, :SEMINAR_YEAR, :SEMINAR_BUDGET, :SEMINAR_SUPPORT_BUDGET, :SEMINAR_CERTIFICATE, :SEMINAR_ABSTRACT, :SEMINAR_RESULT, :SEMINAR_SHOW_1, :SEMINAR_SHOW_2, :SEMINAR_SHOW_3, :SEMINAR_SHOW_4, :SEMINAR_PROBLEM, :SEMINAR_COMMENT, :SEMINAR_SIGNED_DATETIME, :CITIZEN_ID)" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_SEMINAR&quot;" UpdateCommand="UPDATE &quot;TB_SEMINAR&quot; SET &quot;SEMINAR_NAME&quot; = :SEMINAR_NAME, &quot;SEMINAR_LASTNAME&quot; = :SEMINAR_LASTNAME, &quot;SEMINAR_POSITION&quot; = :SEMINAR_POSITION, &quot;SEMINAR_DEGREE&quot; = :SEMINAR_DEGREE, &quot;SEMINAR_CAMPUS&quot; = :SEMINAR_CAMPUS, &quot;SEMINAR_NAMEOFPROJECT&quot; = :SEMINAR_NAMEOFPROJECT, &quot;SEMINAR_PLACE&quot; = :SEMINAR_PLACE, &quot;SEMINAR_DATETIME_FROM&quot; = :SEMINAR_DATETIME_FROM, &quot;SEMINAR_DATETIME_TO&quot; = :SEMINAR_DATETIME_TO, &quot;SEMINAR_DAY&quot; = :SEMINAR_DAY, &quot;SEMINAR_MONTH&quot; = :SEMINAR_MONTH, &quot;SEMINAR_YEAR&quot; = :SEMINAR_YEAR, &quot;SEMINAR_BUDGET&quot; = :SEMINAR_BUDGET, &quot;SEMINAR_SUPPORT_BUDGET&quot; = :SEMINAR_SUPPORT_BUDGET, &quot;SEMINAR_CERTIFICATE&quot; = :SEMINAR_CERTIFICATE, &quot;SEMINAR_ABSTRACT&quot; = :SEMINAR_ABSTRACT, &quot;SEMINAR_RESULT&quot; = :SEMINAR_RESULT, &quot;SEMINAR_SHOW_1&quot; = :SEMINAR_SHOW_1, &quot;SEMINAR_SHOW_2&quot; = :SEMINAR_SHOW_2, &quot;SEMINAR_SHOW_3&quot; = :SEMINAR_SHOW_3, &quot;SEMINAR_SHOW_4&quot; = :SEMINAR_SHOW_4, &quot;SEMINAR_PROBLEM&quot; = :SEMINAR_PROBLEM, &quot;SEMINAR_COMMENT&quot; = :SEMINAR_COMMENT, &quot;SEMINAR_SIGNED_DATETIME&quot; = :SEMINAR_SIGNED_DATETIME, &quot;CITIZEN_ID&quot; = :CITIZEN_ID WHERE &quot;SEMINAR_ID&quot; = :SEMINAR_ID">
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSaveSeminar">
        <div>
            <fieldset>
                <legend>แบบรายงานการฝึกอบรม/สัมมนา/ดูงาน มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</legend>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">1.</td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อ :&nbsp;</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">นามสกุล :&nbsp;</td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: right; margin-right: 5px;">ตำแหน่ง :&nbsp;</td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtPosition" runat="server" MaxLength="100" Width="148px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: right; margin-right: 5px;">ระดับ :&nbsp;</td>
                            <td style="text-align: left; width: 170px;">
                                <asp:TextBox ID="txtDegree" runat="server" MaxLength="100" Width="153px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">สังกัด :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCampus" runat="server" MaxLength="100" Width="625px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">มหาวิทยาลัยเทคโนยีราชมงคลตะวันออก</td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">2. </td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtNameOfProject" runat="server" MaxLength="100" Width="691px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">3. </td>
                            <td style="text-align: right; margin-right: 5px;">สถานที่ฝึกอบรม/สัมมนา/ดูงาน :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPlace" runat="server" MaxLength="100" Width="718px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน</td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ตั้งแต่วันที่ </td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetxtDateFrom" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateFrom" runat="server" Width="180px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtDateFrom" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; margin-right: 5px;">ถึงวันที่</td>
                            <td style="text-align: left; width: 220px;">
                                <asp:UpdatePanel ID="UpdatetxtDateTO" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDateTO" runat="server" Width="180px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
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
                                        <asp:TextBox ID="txtDay" runat="server" MaxLength="100" Width="50px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                            <td style="text-align: left; margin-right: 5px;">วัน</td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtMonth" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMonth" runat="server" MaxLength="100" Width="50px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; margin-right: 5px;">เดือน</td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtYear" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtYear" runat="server" MaxLength="100" Width="50px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: left; margin-right: 10px;">ปี</td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ค่าใช้จ่ายตลอดโครงการ :&nbsp;</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtBudget" runat="server" MaxLength="100" Width="360px" CssClass="tb5"></asp:TextBox></td>
                            <td style="text-align: right; margin-right: 5px;">บาท </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">แหล่งงบประมาณที่ได้รับการสนับสนุน</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtSupportBudget" runat="server" MaxLength="100" Width="718px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; margin-right: 5px;">4. ประกาศนียบัตรที่ได้รับ (ถ้ามี) </td>


                            <td style="text-align: left; width: 50px;">
                                <asp:UpdatePanel ID="UpdatetxtCertificate" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCertificate" runat="server" MaxLength="100" Width="753px" CssClass="tb5" AutoPostBack="True"></asp:TextBox>
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
                                <asp:TextBox ID="txtAbstract" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">6. ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน </td>

                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtResult" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
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
                                <asp:TextBox ID="txtShow1" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.2 ด้านการวิจัย </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow2" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.3 ด้านการบริการวิชาการ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow3" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">7.4 ด้านอื่นๆ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtShow4" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">8. ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtProblem" runat="server" MaxLength="1000" Height="100px" Width="955px" TextMode="MultiLine" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; margin-right: 5px;">9. ความคิดเห็น/ข้อเสนอแนะอื่นๆ </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtComment" runat="server" MaxLength="1000" TextMode="MultiLine" Height="100px" Width="955px" CssClass="tb5"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 50px;">
                                <asp:Button ID="btnCancelSeminar" Text="Cancel" Visible="false" runat="server" OnClick="btnCancelSeminar_Click" Width="140px" CssClass="master_OAT_button" /></td>
                            <td style="text-align: left; width: 50px;"></td>
                            <td style="text-align: right; margin-right: 5px;">
                                <asp:Button ID="btnSaveSeminar" Text="OK" Visible="false" runat="server" OnClick="btnSubmitSeminar_Click" Width="140px" CssClass="master_OAT_button" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>