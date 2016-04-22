<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalaryByID.aspx.cs" Inherits="WEB_PERSONAL.SalaryByID" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ระบบเพิ่มเงินเดือนรายบุคคล</title>
    <style type="text/css">
        
        .auto-style4 {
            width: 228px;
        }

        .auto-style6 {
            width: 250px;
            text-align: left;
        }

        .auto-style7 {
            width: 240px;
            text-align: left;
        }

        .auto-style9 {
            width: 228px;
            height: 24px;
            text-align: left;
        }

        .auto-style10 {
            width: 250px;
            height: 24px;
            text-align: left;
        }

        .auto-style11 {
            width: 240px;
            height: 24px;
            text-align: left;
        }

        .auto-style12 {
            height: 24px;
            text-align: left;
        }

        .button_ui {
            background: #939393;
            padding: 5px 10px;
            border-radius: 10px;
            text-decoration: none;
            color: white;
            border-color: black;
            border: 1px solid black;
            font-size: 16px;
        }

        .button_ui_admin {
            background: #ff0000;
            padding: 5px 10px;
            text-decoration: none;
            color: white;
            border-color: black;
            border: 1px solid black;
            font-size: 16px;
            transition: background-color ease 0.5s;
        }

            .button_ui_admin:hover {
                background: #ff6a00;
                padding: 5px 10px;
                text-decoration: none;
                color: black;
                border-color: black;
                border: 1px solid black;
                font-size: 16px;
            }

        .button_ui_edit {
            background: rgb(79, 255, 169);
            padding: 5px 10px;
            border-radius: 10px;
            text-decoration: none;
            color: Black;
            border-color: yellow;
            border: 1px solid black;
        }

        .panin {
            background-color: white;
            border-radius: 5px;
            border: 2px solid black;
            padding: 5px;
        }

        .panout {
            padding: 20px;
            text-align: center;
            border-radius: 5px;
            border: 5px solid black;
            background-color: rgba(204, 204, 204,0.5);
        }

        body {
            background-image: url("Image/ef333.jpg");
        }

        .auto-style14 {
            text-align: left;
        }

        .auto-style15 {
            width: 507px;
            text-align: center;
        }

        .auto-style18 {
            width: 490px;
            text-align: center;
        }

        .auto-style20 {
            width: 228px;
            text-align: left;
        }

        .header-text {
            padding: 10px;
            background-color: rgb(0, 113, 23);
            border-radius: 4px;
        }
    </style>
    <script language="javascript" type="text/javascript">
<!--
    /****************************************************
         Author: Eric King
         Url: http://redrival.com/eak/index.shtml
         This script is free to use as long as this info is left in
         Featured on Dynamic Drive script library (http://www.dynamicdrive.com)
    ****************************************************/
    var win = null;
    function Popup(mypage, myname, w, h, scroll, pos) {
        if (pos == "random") { LeftPosition = (screen.width) ? Math.floor(Math.random() * (screen.width - w)) : 100; TopPosition = (screen.height) ? Math.floor(Math.random() * ((screen.height - h) - 75)) : 100; }
        if (pos == "center") { LeftPosition = (screen.width) ? (screen.width - w) / 2 : 100; TopPosition = (screen.height) ? (screen.height - h) / 2 : 100; }
        else if ((pos != "center" && pos != "random") || pos == null) { LeftPosition = 0; TopPosition = 20 }
        settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=yes,menubar=no,toolbar=no,resizable=no';
        win = window.open(mypage, myname, settings);
    }
        // -->
    function minlength(){
        var textbox1 = document.getElementById("TextBox1");
        if (textbox1.value.length == 13) {
        }
        else {
            alert("อนุญาตสำหรับรหัสบัตรประชาชนเท่านั้น")
        }
    }
    </script>
    <link href="CSS/Salary.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel6" runat="server" CssClass="panout">

        <asp:Panel ID="Panel1" runat="server" CssClass="panin">
            <asp:Panel ID="Panel_Citizen_id" runat="server" DefaultButton="LinkButton3">
                <div class="Salary_div">
                    <div class="Salary_div_header">
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="การขึ้นเงินเดือนรายบุคคล" Font-Bold="True" Font-Size="20pt" CssClass="header-text"></asp:Label><br />
                        <br />
                    </div>
                    <div class="Salary_div_in">
                        <asp:Table ID="Table1" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3">
                        <hr /><br />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label8" runat="server" Text="กรุณาป้อนรหัสบัตรประชาชน"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="master_default_textbox" Height="24px" MaxLength="13" Width="100px"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button_ui_edit" OnClick="Button1_Click">ค้นหา</asp:LinkButton>
                                    <a href="SalaryByID-Report.aspx" class="button_ui_edit">ออกรายงาน</a>
                                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="button_ui_admin" OnClick="LinkButton7_Click" >จัดการเงินเดือน [Admin]</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="button_ui_admin" OnClick="LinkButton11_Click">จัดการฐานเงินเดือน [Admin]</asp:LinkButton><br />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3">
                        <br />
                        <hr />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Panel_Government_Officer" runat="server"  Visible="false">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style20">ชื่อ - นามสกุล :</td>
                        <td class="auto-style6">
                            <asp:Label ID="Label11" runat="server" Text="NAME"></asp:Label>
                            &nbsp;<asp:Label ID="Label13" runat="server" Text="LASTNAME"></asp:Label>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label14" runat="server" Text="ชื่อตำแหน่งในสายงาน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label15" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label16" runat="server" Text="ระดับตำแหน่ง"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label17" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label18" runat="server" Text="ชื่อตำแหน่งในการบริหาร"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label19" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label60" runat="server" Text="ประเภท"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label61" runat="server" Text="ประเภท"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style14">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style14">
                            <asp:Label ID="Label55" runat="server" Text="รายละเอียดการบริหารวงเงินร้อยละ"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label20" runat="server" Text="เงินเดือนก่อนเลื่อน (ณ 1 มี.ค. 58)"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="master_default_textbox" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label21" runat="server" Text="เงินเดือนสูงสุดแต่ละประเภท"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label22" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label23" runat="server" Text="ฐานในการคำนวณ"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label24" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label25" runat="server" Text="ร้อยละที่ได้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="master_default_textbox" placeHolder="ระบุเป็นตัวเลข"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Label ID="Label59" runat="server" Text="จำนวนเงินที่คำนวณได้"></asp:Label>
                        </td>
                        <td class="auto-style10">
                            <asp:Label ID="Label26" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style12">
                            <asp:Label ID="Label27" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label28" runat="server" Text="จำนวนเงินที่ได้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label29" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label30" runat="server" Text="เงินตอบแทนพิเศษ"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label31" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label32" runat="server" Text="รวมได้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label33" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label34" runat="server" Text="เงินเดือนใหม่"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label35" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label36" runat="server" Text="คะแนนผลประเมิน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="master_default_textbox" placeHolder="ระบุเป็นตัวเลข"></asp:TextBox>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label37" runat="server" Text="ระดับการประเมิน"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="master_default_textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style14">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style14">
                            <asp:Label ID="Label56" runat="server" Text="อธิการบดีเพิ่มให้"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label38" runat="server" Text="ร้อยละได้เลื่อน (ตามสัดส่วน)"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="master_default_textbox" placeHolder="ระบุเป็นตัวเลข"></asp:TextBox>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label39" runat="server" Text="ร้อยละที่ได้เลื่อน (อธิการบดีเพิ่มให้)"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="master_default_textbox" placeHolder="ระบุเป็นตัวเลข" Visible="False"></asp:TextBox>
                            <asp:DropDownList ID="DropDownList4" runat="server" Width="150px" CssClass="master_default_dropdown">
                                <asp:ListItem>0.1</asp:ListItem>
                                <asp:ListItem>0.2</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label40" runat="server" Text="จำนวนเงินที่ได้เพิ่ม"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label58" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style20">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" class="auto-style14">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label57" runat="server" Text="รวมได้เลื่อนทั้งสิ้น"></asp:Label>
                        </td>
                        <td class="auto-style6">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label41" runat="server" Text="ร้อยละที่ได้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label42" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label43" runat="server" Text="จำนวนเงินที่คำนวณได้"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label44" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label45" runat="server" Text="จำนวนเงินที่คำนวณได้(ปัดเศษ)"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label46" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label47" runat="server" Text="จำนวนเงินที่ได้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label48" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label49" runat="server" Text="เงินตอบแทนพิเศษ"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label50" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="Label51" runat="server" Text="รวมใช้เลื่อน"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label52" runat="server" Text="-"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="Label53" runat="server" Text="เงินเดือนใหม่"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="Label54" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">หมายเหตุ</td>
                        <td colspan="2">
                            <asp:TextBox ID="TextBox9" runat="server" Height="50px" TextMode="Multiline" Width="500px" Font-Size="14pt" Style="resize: none" CssClass="master_default_textbox_multi_line"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button_ui" OnClick="LinkButton1_Click">คำนวณเงินเดือน</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td colspan="2">
                            
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        
        <br />
        <asp:Panel ID="Panel_Permanent_Emp" runat="server" Visible="false">
            <asp:Table ID="Table2" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="10">
                        <br />
                        <hr />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="ชื่อ - นามสกุล"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label><span>    </span>
                        <asp:Label ID="Label4" runat="server" Text="LastName"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label5" runat="server" Text="ประเภท"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server" Text="Label_ประเภท"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label9" runat="server" Text="ตำแหน่ง"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="Label10" runat="server" Text="Label_ตำแหน่ง"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="10">
                        <hr />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:RadioButton ID="RadioButton1" GroupName="Cal_Permanent_Emp" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" />
                        <asp:Label ID="Label1" runat="server" Text="คำนวณรายชั่วโมง"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton ID="RadioButton2" GroupName="Cal_Permanent_Emp" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" />
                        <asp:Label ID="Label12" runat="server" Text="คำนวณรายวัน"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton ID="RadioButton3" GroupName="Cal_Permanent_Emp" runat="server" OnCheckedChanged="RadioButton3_CheckedChanged" AutoPostBack="true" />
                        <asp:Label ID="Label62" runat="server" Text="คำนวณรายเดือน"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="10">
                        <hr />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Panel ID="Panel_Permanent_Emp_Hour" runat="server" Visible="false">
                <asp:Table ID="Table3" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label63" runat="server" Text="เงินเดือน"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label64" runat="server" Text="Label"></asp:Label>
                            
                        </asp:TableCell>         
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:RadioButton ID="Radio_Per_Hour_1" runat="server" GroupName="Hour_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Hour_1_CheckedChanged" Text="กลุ่มบัญชี 1" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Hour_2" runat="server" GroupName="Hour_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Hour_2_CheckedChanged" Text="กลุ่มบัญชี 2" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Hour_3" runat="server" GroupName="Hour_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Hour_3_CheckedChanged" Text="กลุ่มบัญชี 3" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Hour_4" runat="server" GroupName="Hour_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Hour_4_CheckedChanged" Text="กลุ่มบัญชี 4" /><span></span>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnDataBound="DropDownList1_DataBound" >
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label69" runat="server" Visible="false"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label72" runat="server" Text="ทำงานรวม"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label73" runat="server" Text="ชั่วโมง"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="cal_linkbutton" OnClick="LinkButton6_Click">คำนวณเงิน</asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label78" runat="server" Text="ผลลัพธ์" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label79" runat="server" Text="" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label86" runat="server" Text="บาท" Visible="false"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <asp:Panel ID="Panel_Permanent_Emp_Day" runat="server" Visible="false">
                <asp:Table ID="Table4" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label65" runat="server" Text="เงินเดือน"></asp:Label>
                            
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label66" runat="server" Text="Label"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>
                            <asp:RadioButton ID="Radio_Per_Day_1" runat="server" GroupName="Day_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Day_1_CheckedChanged" Text="กลุ่มบัญชี 1" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Day_2" runat="server" GroupName="Day_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Day_2_CheckedChanged" Text="กลุ่มบัญชี 2" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Day_3" runat="server" GroupName="Day_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Day_3_CheckedChanged" Text="กลุ่มบัญชี 3" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Day_4" runat="server" GroupName="Day_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Day_4_CheckedChanged" Text="กลุ่มบัญชี 4" /><span></span>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label70" runat="server" Visible="false"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label74" runat="server" Text="ทำงานรวม"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label75" runat="server" Text="วัน"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="cal_linkbutton" OnClick="LinkButton5_Click">คำนวณเงิน</asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label81" runat="server" Text="ผลลัพธ์" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label80" runat="server" Text="Label" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label84" runat="server" Text="บาท" Visible="false"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <asp:Panel ID="Panel_Permanent_Emp_Month" runat="server" Visible="false">
                <asp:Table ID="Table5" runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label67" runat="server" Text="เงินเดือน"></asp:Label>
                            
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>
                            <asp:RadioButton ID="Radio_Per_Month_1" runat="server" GroupName="Month_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Month_1_CheckedChanged" Text="กลุ่มบัญชี 1" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Month_2" runat="server" GroupName="Month_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Month_2_CheckedChanged" Text="กลุ่มบัญชี 2" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Month_3" runat="server" GroupName="Month_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Month_3_CheckedChanged" Text="กลุ่มบัญชี 3" /><span></span>
                            <asp:RadioButton ID="Radio_Per_Month_4" runat="server" GroupName="Month_Permanent_Emp" AutoPostBack="True" OnCheckedChanged="Radio_Per_Month_4_CheckedChanged" Text="กลุ่มบัญชี 4" /><span></span>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" OnDataBound="DropDownList3_DataBound"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label71" runat="server" Visible="false"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label76" runat="server" Text="ทำงานรวม"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label77" runat="server" Text="เดือน"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="cal_linkbutton" OnClick="LinkButton4_Click">คำนวณเงิน</asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label82" runat="server" Text="ผลลัพธ์" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label83" runat="server" Text="Label" Visible="false"></asp:Label><span>     </span>
                            <asp:Label ID="Label85" runat="server" Text="บาท" Visible="false"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
        </asp:Panel>

        </asp:Panel>
        <asp:Panel ID="Panel_Oracle_Control" runat="server" Visible="false">
        <table style="width: 100%;" class="panin">
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button_ui" OnClick="LinkButton2_Click" Font-Size="14px">บันทึก</asp:LinkButton>
                </td>
                <td class="auto-style15">
                    <!--SalarybyID-Edit.aspx-->
                    <a id="Edit_page" runat="server" href="https://www.google.co.th" onclick="Popup(this.href,'แก้ไขข้อมูลบุคคล','860','600','yes','center');return false" onfocus="this.blur()" class="button_ui">แก้ไขข้อมูล</a>
                </td>
                <tr>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                </tr>
            </tr>
        </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

