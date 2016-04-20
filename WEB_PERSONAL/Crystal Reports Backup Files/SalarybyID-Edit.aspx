<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalarybyID-Edit.aspx.cs" Inherits="WEB_PERSONAL.SalarybyID_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .button_ui {
            background: #c4c4c4;
            padding: 5px 10px;
            text-decoration: none;
            color: black;
            border-color: black;
            border: 1px solid black;
        }
        .button_ui2 {
            background: #77ced4;
            padding: 5px 10px;
            border-radius: 10px;
            text-decoration: none;
            color: black;
            border-color: black;
            border: 1px solid black;
        }
        .panin {
            background-color: rgba(255,255,255,0.8);
            border-radius: 5px;
            border: 2px solid black;
        }

        .panout {
            padding: 20px;

        }
        body{
           /*background-image: url("Image/bgbyid.jpg");
            background-size:contain;*/
        }

        .auto-style1 {
            width: 200px;
        }

        .auto-style2 {
            width: 180px;
        }

        .auto-style3 {
            width: 300px;
        }

        .auto-style4 {
            width: 664px;
        }

        .auto-style5 {
            width: 555px;
        }

        .auto-style6 {
            width: 128px;
        }

        .auto-style7 {
            width: 240px;
        }
        .auto-style8 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" CssClass="panout" Height="900px" Width="800px">
                <asp:Panel ID="Panel2" runat="server" CssClass="panin" Height="100%">
                    <table class="auto-style4" style="width: 100%;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label62" runat="server" Text="รหัสเอกสาร"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="Label63" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label8" runat="server" Text="รหัสบัตรประชาชน"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="Label61" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">ชื่อ - นามสกุล :</td>
                            <td class="auto-style1">
                                <asp:Label ID="Label11" runat="server" Text="-"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label14" runat="server" Text="ชื่อตำแหน่งในสายงาน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label15" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label16" runat="server" Text="ระดับตำแหน่ง"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label17" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label18" runat="server" Text="ชื่อตำแหน่งในการบริหาร"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label19" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="Label55" runat="server" Text="รายละเอียดการบริหารวงเงินร้อยละ"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label20" runat="server" Width="250"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBox2" runat="server" Width="150"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label21" runat="server" Text="เงินเดือนสูงสุดแต่ละประเภท"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label22" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label23" runat="server" Text="ฐานในการคำนวณ"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label24" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label25" runat="server" Text="ร้อยละที่ได้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label59" runat="server" Text="จำนวนเงินที่คำนวณได้"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label26" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label60" runat="server" Text="จำนวนเงินที่คำนวณได้(ปัดเศษ)"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label27" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label28" runat="server" Text="จำนวนเงินที่ได้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label29" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label30" runat="server" Text="เงินตอบแทนพิเศษ"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label31" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label32" runat="server" Text="รวมได้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label33" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label34" runat="server" Text="เงินเดือนใหม่"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label35" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label36" runat="server" Text="คะแนนผลประเมิน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label37" runat="server" Text="ระดับการประเมิน"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="Label56" runat="server" Text="อธิการบดีเพิ่มให้"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label38" runat="server" Text="ร้อยละได้เลื่อน (ตามสัดส่วน)"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label39" runat="server" Text="ร้อยละที่ได้เลื่อน (อธิการบดีเพิ่มให้)"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label40" runat="server" Text="จำนวนเงินที่ได้เพิ่ม"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label58" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label57" runat="server" Text="รวมได้เลื่อนทั้งสิ้น"></asp:Label>
                            </td>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label41" runat="server" Text="ร้อยละที่ได้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label42" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label43" runat="server" Text="จำนวนเงินที่คำนวณได้"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label44" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label45" runat="server" Text="จำนวนเงินที่คำนวณได้(ปัดเศษ)"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label46" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label47" runat="server" Text="จำนวนเงินที่ได้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label48" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label49" runat="server" Text="เงินตอบแทนพิเศษ"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label50" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label51" runat="server" Text="รวมใช้เลื่อน"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label52" runat="server" Text="-"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="Label53" runat="server" Text="เงินเดือนใหม่"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Label ID="Label54" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>

                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">หมายเหตุ</td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" Font-Size="14pt" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                            </td>
                            <td class="auto-style7">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button_ui2" OnClick="LinkButton1_Click" CausesValidation="False">คำนวณเงินเดือน</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td class="auto-style6">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" CssClass="panin">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8"><asp:LinkButton ID="LinkButton2" runat="server" CssClass="button_ui" OnClick="LinkButton2_Click">บันทึก</asp:LinkButton></td>
                            <td class="auto-style8">
                                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="button_ui" OnClick="LinkButton4_Click">ลบ</asp:LinkButton>
                            </td>
                            <td class="auto-style8"><asp:LinkButton ID="LinkButton3" runat="server" CssClass="button_ui" OnClick="LinkButton3_Click">ยกเลิก</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
