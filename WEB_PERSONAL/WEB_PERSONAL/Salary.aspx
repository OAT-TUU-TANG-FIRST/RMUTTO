<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="WEB_PERSONAL.Salary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            text-align: left;
        }

        .auto-style31 {
            width: 239px;
            text-align: left;
        }

        .auto-style38 {
            width: 239px;
            text-align: left;
            height: 26px;
        }

        </style>
    <script type="text/javascript">
function validate()
{
	    var pattern = /^-?[0-9]+(.[0-9]{1,2})?$/;
            var text = document.getElementById('TextBox22').value;
            if (text.match(pattern)==null)
            {
		alert('the format is wrong');
            }
	    else
	    {
		alert('OK');
	    }


}


</script>
    <link href="CSS/Salary.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        @font-face {
            font-family: ths;
            src: url("Font/THSarabun.ttf");
            font-family: thsb;
            src: url("Font/THSarabun Bold.ttf");
            font-family: thsbi;
            src: url("Font/THSarabun BoldItalic.ttf");
            font-family: thsi;
            src: url("Font/THSarabun Italic.ttf");
        }
        .divpan{
            background-image: url("Image/green_button.jpg");
            text-align: center;
        }
        .textmode {
            font-size: 16px;
        }

        .textmodeb {
            font-size: 24px;
            padding: 20px;
        }

        .textmodebi {
            font-size: 20px;
        }

        .textmodei {
            font-size: 20px;
        }

        .pancen {
            text-align: center;
        }
        .panin{
            border:1px solid black;
            margin: 20px;
            padding: 10px;
            background-color:rgba(255,255,255,0.6);
            border-radius: 5px;
        }
        .button_ui{
            background: #939393;
            padding: 5px 10px;
            border-radius: 0px 0px 10px 10px;
            text-decoration:none;
            color:white;
            border-color: black;
            border: 1px solid black;
            }
        .button_ui2{
            background: #6ed046;
            padding: 5px 10px;
            border-radius: 5px;
            text-decoration:none;
            color:black;
            border-color: black;
            border: 1px solid black;
            }
        .auto-style40 {
            width: 215px;
            text-align: left;
            text-decoration: none;
        }
        .auto-style41 {
            width: 215px;
            text-align: left;
            height: 26px;
        }
        </style>

    <div>
        <asp:Panel ID="Panel1" runat="server" CssClass="divpan">

            <asp:Label ID="Label2" runat="server" Text="Salary System" CssClass="textmode" Font-Size="40pt"></asp:Label><br />
            <br />
            <div class="Salary_div_header">
                <asp:Label ID="Label1" runat="server" CssClass="textmodeb" Text="รายละเอียดการเลื่อนเงินเดือนข้าราชการพลเรือนในสถาบันอุคมศึกษา"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" CssClass="textmodeb" Text="ครั้งที่ 1 วันที่ 1 เมษายน 2558"></asp:Label><br />
            <asp:Label ID="Label21" runat="server" CssClass="textmodeb" Text="มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label><br />
            </div>
            <asp:Panel ID="Panel2" runat="server" CssClass="panin">
                <table style="width: 100%;" border="0">

                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3" colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label4" runat="server" CssClass="textmode" Text="หน่วยงาน"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="BRANCH_NAME" DataValueField="BRANCH_ID">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" SelectCommand="SELECT * FROM &quot;TB_BRANCH&quot;" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label5" runat="server" Text="จำนวนคน ณ 1 มี.ค. 58" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="TextBox31" runat="server" Width="75px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3" colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style41">
                            <asp:Label ID="Label6" runat="server" Text="อัตราเงินเดือนรวม ณ 1 มี.ค. 58" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style38">
                            <asp:TextBox ID="TextBox32" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style41">&nbsp;</td>
                        <td class="auto-style38">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label7" runat="server" Text="วงเงิน 2.9 % ของเงินเดือนรวม" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label15" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label8" runat="server" CssClass="textmode" Text="เงินที่ใช้เลื่อน ณ 1 เม.ย. 58"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="TextBox25" runat="server" Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label9" runat="server" Text="วงเงินที่เหลือ" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label17" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label10" runat="server" Text="วงเงิน 0.1 % ของเงินเดือนรวม ณ 1 มี.ค. 58" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label16" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label11" runat="server" CssClass="textmode" Text="จำนวนเงินที่อธิการบดีเพิ่มให้"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="TextBox22" runat="server" Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label12" runat="server" Text="วงเงินที่ใช้เลื่อนทั้งสิ้น (3%)" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label18" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label13" runat="server" Text="เงินที่ใช้เลื่อน ณ 1 เม.ย. 58&nbsp;ทั้งสิ้น" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label19" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label14" runat="server" Text="วงเงินคงเหลือทั้งสิ้น" CssClass="textmode"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="Label20" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="Label22" runat="server" Text="Comment"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="TextBox18" runat="server" Height="50px" TextMode="MultiLine" Width="500px" style = "resize:none" ></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">
                            <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" CssClass="button_ui2">คำนวณเงิน</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40">&nbsp;</td>
                        <td class="auto-style31">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" CssClass="panin">
        <table style="width: 100%;">
            <tr>
                <td class="pancen">
                    <asp:LinkButton ID="LinkButton1" runat="server" Width="140px" CssClass="button_ui" OnClick="LinkButton1_Click">บันทึก</asp:LinkButton>
                </td>
                <td class="pancen">
                    <asp:LinkButton ID="LinkButton2" runat="server" Width="140px" CssClass="button_ui" OnClick="LinkButton2_Click">ยกเลิก</asp:LinkButton>
                </td>
                <td class="pancen">
                    <asp:LinkButton ID="LinkButton3" runat="server" Width="140px" CssClass="button_ui" OnClick="LinkButton3_Click">ออกรายงาน</asp:LinkButton>
                </td>
            </tr>
        </table>
        </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
