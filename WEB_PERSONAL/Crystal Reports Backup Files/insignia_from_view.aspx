<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="insignia_from_view.aspx.cs" Inherits="WEB_PERSONAL.insignia_from_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }

        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            height: 23px;
            text-align: center;
        }

        .auto-style4 {
            font-size: xx-large;
        }

        .auto-style5 {
            font-size: large;
        }

        .auto-style8 {
            width: 253px;
        }

        .auto-style9 {
            width: 287px;
        }

        .auto-style10 {
            width: 253px;
            height: 23px;
        }

        .auto-style11 {
            width: 287px;
            height: 23px;
        }

        .auto-style14 {
            width: 276px;
            height: 29px;
        }

        .auto-style15 {
            width: 124px;
            height: 29px;
        }

        .auto-style16 {
            height: 29px;
        }

        .auto-style18 {
            height: 29px;
            width: 179px;
        }

        .auto-style21 {
            width: 53px;
            height: 29px;
        }

        .auto-style22 {
            width: 92px;
        }

        .auto-style23 {
            width: 303px;
        }

        .auto-style27 {
            height: 25px;
        }

        .auto-style30 {
            width: 189px;
            height: 25px;
        }

        .auto-style33 {
            height: 23px;
        }

        .auto-style34 {
            height: 23px;
            width: 9px;
        }

        .auto-style35 {
            width: 9px;
        }

        .auto-style36 {
            height: 23px;
            width: 58px;
        }

        .auto-style37 {
            width: 58px;
        }

        .auto-style38 {
            width: 283px;
            height: 23px;
        }

        .auto-style39 {
            width: 283px;
        }

        .auto-style40 {
            height: 23px;
            width: 111px;
        }

        .auto-style41 {
            width: 111px;
        }

        .auto-style44 {
            width: 71px;
        }

        .auto-style45 {
            width: 244px;
            height: 26px;
        }

        .auto-style46 {
            height: 26px;
        }

        .auto-style47 {
            height: 26px;
            width: 280px;
        }

        .auto-style51 {
            height: 26px;
            width: 274px;
        }

        .auto-style53 {
            height: 26px;
            width: 75px;
        }

        .auto-style55 {
            width: 129px;
        }

        .auto-style56 {
            width: 123px;
        }

        .auto-style57 {
            width: 121px;
        }

        .auto-style58 {
            width: 120px;
        }

        .auto-style59 {
            height: 23px;
            width: 124px;
        }

        .auto-style60 {
            width: 124px;
        }

        .auto-style61 {
            width: 253px;
            height: 29px;
        }

        .auto-style62 {
            width: 92px;
            height: 26px;
        }

        .auto-style63 {
            width: 303px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
        <style>
            /*#TextBox3[enabled = false] {
                background-color: #FF0000;
            }*/

            /*เปลี่ยนรูป กรอบหัวข้อ และ เนื้อหา*/
            #TUUbg {
                background-image: url("Image/TUUbg1.jpg");
            }
            #TUUbg2 {
                background-image: url("Image/TUUbg4.jpg");
            }
            #TUUbg3 {
                background-image: url("Image/TUUbg5.jpg");
            }
        </style>
        <asp:Panel ID="Panel6" runat="server">


            <!-- กรอบหัวข้อ และ เนื้อหา ส่วนที่ 1-->
            <div class="master_default_div_sec" id="TUUbg">
                <div class="master_default_div_sec_header">
                </div>
                <div class="master_default_div_sec_in">
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">
                                <asp:Label ID="Label7" runat="server" CssClass="auto-style4" Text="บันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">
                                <asp:Label ID="Label8" runat="server" CssClass="auto-style5" Text="สังกัด มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style2">
                                <asp:Label ID="Label9" runat="server" Text="ประเภท  "></asp:Label>
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="ข้าราชการ    " GroupName="sel" Enabled="False" />
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="พนักงานในสถาบันฯ    " GroupName="cal" Enabled="False" />
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="พนักงานราชการ    " GroupName="cal" Enabled="False" />
                                <asp:RadioButton ID="RadioButton4" runat="server" Text="ลูกจ้างประจำ    " GroupName="cal" Enabled="False" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td class="auto-style3">
                                <asp:Label ID="Label10" runat="server" Text="________________________________________________________________________"></asp:Label>
                            </td>
                            <td class="auto-style1"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label11" runat="server" Text="ชื่อหน่วยงานที่ขอพระราชทาน"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox32" runat="server" CssClass="master_default_textbox" Enabled="False" Width="269px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label12" runat="server" Text="มาช่วยราชการจากที่ใด (ถ้ามี)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox33" runat="server" CssClass="master_default_textbox" Enabled="False" Width="269px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style61">
                                <asp:Label ID="Label13" runat="server" Text="เครื่องราชฯ ที่ขอพระราชทาน ประจำปี"></asp:Label>
                            </td>
                            <td class="auto-style16">
                                <asp:TextBox ID="TextBox34" runat="server" CssClass="master_default_textbox" Enabled="False" Width="269px"></asp:TextBox>
                            </td>
                            <td class="auto-style16"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label14" runat="server" Text="คือชั้น"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox35" runat="server" CssClass="master_default_textbox" Enabled="False" EnableTheming="True" Width="269px"></asp:TextBox>

                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label15" runat="server" Text="ชั้นนี้เป็นการขอพระราชทาน"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioButton5" runat="server" Text="ไม่ซ้ำ" Checked="True" />
                                &nbsp;<asp:RadioButton ID="RadioButton6" runat="server" Text="ซ้ำ กับปีที่แล้วมา" Enabled="False" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label17" runat="server" Text="ยศ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox36" runat="server" CssClass="master_default_textbox" Enabled="False" Width="269px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label18" runat="server" Text="คำนำหน้าชื่อ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label19" runat="server" Text="ชื่อ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox4" runat="server" Width="269px" Enabled="False" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label20" runat="server" Text="นามสกุล"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label21" runat="server" Text="เพศ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox6" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label22" runat="server" Text="วัน/เดือน/ปีเกิด"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox7" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label23" runat="server" Text="เลขประจำตัวประชาชน"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label24" runat="server" Text="วัน/เดือน/ปีที่เริ่มรับราชการ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox9" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label25" runat="server" Text="ตำแหน่งและระดับที่เริ่มรับราชการ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox10" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label26" runat="server" Text="ชื่อตำแหน่งปัจจุบัน"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox11" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label27" runat="server" Text="ประเภท"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox12" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label28" runat="server" Text="ระดับ"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox13" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                <asp:Label ID="Label29" runat="server" Text="เงินเดือนปัจจุบัน"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="TextBox14" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="Label30" runat="server" Text="บาท"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label33" runat="server" Text="เงินประจำตำแหน่ง"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox15" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label31" runat="server" Text="บาท"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style14">เงินเดือนย้อนหลัง 5 ปี (ณ วันที่ 1 เมษายน</td>
                            <td class="auto-style15">
                                <asp:TextBox ID="TextBox16" runat="server" Enabled="False" Width="63px" CssClass="master_default_textbox"></asp:TextBox>
                                <asp:Label ID="Label34" runat="server" Text=")"></asp:Label>
                            </td>
                            <td class="auto-style18">
                                <asp:TextBox ID="TextBox17" runat="server" Enabled="False" Width="159px" CssClass="master_default_textbox"></asp:TextBox>
                            </td>
                            <td class="auto-style21">
                                <asp:Label ID="Label35" runat="server" Text="บาท"></asp:Label>
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </div>

            <asp:CheckBox ID="CheckBox6" runat="server" Text="กรณีขอครั้งแรก / เปลี่ยนชื่อ" AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged" />
            <div id="Other" runat="server">
                 <!-- กรอบหวะข้อ และ เนื้อหา ส่วนที่ 2-->
            <div class="master_default_div_sec" id="TUUbg2">
                <div class="master_default_div_sec_header">
                    <asp:Label ID="Label1" runat="server" Text="หากมีการเปลี่ยนแปลงคำนำหน้าชื่อ/ชื่อ/นามสกุล ให้ระบุคำนำหน้าชื่อ/ชื่อ/นามสกุล เดิมด้วย"></asp:Label>
                </div>
                <div class="master_default_div_sec_in">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="Label2" runat="server" Text="คำนำหน้าชื่อ"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="master_default_textbox" Enabled="False" Width="269px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style62">
                        <asp:Label ID="Label3" runat="server" Text="ชื่อ"></asp:Label>
                    </td>
                    <td class="auto-style63">
                        <asp:TextBox ID="TextBox2" runat="server" Width="269px" CssClass="master_default_textbox" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style46"></td>
                    <td class="auto-style46"></td>
                    <td class="auto-style46"></td>
                    <td class="auto-style46"></td>
                    <td class="auto-style46"></td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="Label4" runat="server" Text="นามสกุล"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:TextBox ID="TextBox18" runat="server" Width="269px" CssClass="master_default_textbox" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

                </div>
            </div>

            <!-- กรอบหวะข้อ และ เนื้อหา ส่วนที่ 3-->
            <div class ="master_default_div_sec" id ="TUUbg3">
                <div class ="master_default_div_sec_header">

                </div>
                <div class ="master_default_div_sec_in">
                    <table style="width: 100%;">
                <tr>
                    <td class="auto-style30">
                        <asp:Label ID="Label42" runat="server" Text="กรณีขอเป็นครั้งแรก บรรจุเมื่อ"></asp:Label>
                    </td>
                    <td class="auto-style27">
                        <asp:TextBox ID="TextBox21" runat="server" Width="269px" CssClass="master_default_textbox" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label43" runat="server" Text="- ประวัติการเลื่อนระดับตามที่ ก.พ.อ. กำหนดเดิม (ข้าราชการ) ให้กรอกข้อมูลย้อนหลังก่อนวันที่ 21 กันยายน 2554"></asp:Label>
                        <br />
                        <asp:Label ID="Label44" runat="server" Text="จำนวน 2 ระดับ "></asp:Label>
                        <asp:Label ID="Label45" runat="server" Text="(เช่น ระดับ 7 เมื่อวันที่ 14ธีนวาคม 2553 และระดับ 6 เมื่อวันที่ 1 ตุลาคม 2550)"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style34"></td>
                                <td class="auto-style36">
                                    <asp:Label ID="Label46" runat="server" Text="1. ระดับ"></asp:Label>
                                </td>
                                <td class="auto-style38">
                                    <asp:TextBox ID="TextBox38" runat="server" CssClass="master_default_textbox" Width="269px" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="auto-style40">
                                    <asp:Label ID="Label50" runat="server" Text="เมื่อ วัน/เดือน/ปี"></asp:Label>
                                </td>
                                <td class="auto-style33">
                                    <asp:TextBox ID="TextBox25" runat="server" Width="269px" CssClass="master_default_textbox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style35">&nbsp;</td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label49" runat="server" Text="2. ระดับ"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="TextBox39" runat="server" CssClass="master_default_textbox" Width="269px" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="auto-style41">
                                    <asp:Label ID="Label55" runat="server" Text="เมื่อ วัน/เดือน/ปี"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox26" runat="server" Width="269px" CssClass="master_default_textbox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label51" runat="server" Text="- ประวัติตำแหน่งตามระบบเดิมหมวดฝีมือ (ลูกจ้างประจำ) และตามระบบใหม่ตั้งแต่วันที่ 1 เมษายน 2553"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style34"></td>
                    <td class="auto-style59">
                        <asp:Label ID="Label52" runat="server" Text="1. ชื่อตำแหน่งเดิม"></asp:Label>
                    </td>
                    <td class="auto-style38">
                        <asp:TextBox ID="TextBox40" runat="server" CssClass="master_default_textbox" Width="269px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style40">&nbsp;</td>
                    <td class="auto-style33">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style35">&nbsp;</td>
                    <td class="auto-style60">
                        <asp:Label ID="Label54" runat="server" Text="2. ชื่อตำแหน่งใหม่"></asp:Label>
                    </td>
                    <td class="auto-style39">
                        <asp:TextBox ID="TextBox41" runat="server" CssClass="master_default_textbox" Width="269px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style41">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="กลุ่มงานสนับสนุน" Enabled="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="กลุ่มงานช่าง" ValidationGroup="rr" Enabled="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label56" runat="server" Text="- พนักงานราชการ ให้ระบุชื่อกลุ่มงานด้วย"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="กลุ่มงานบริการ" Enabled="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="กลุ่มงานเทคนิค" Enabled="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="กลุ่มงานบริหารทั่วไป" Enabled="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style45">
                        <asp:Label ID="Label57" runat="server" Text="เครื่องราชอิสริยาภรณ์ชั้นล่าสุดที่ได้รับ"></asp:Label>
                    </td>
                    <td class="auto-style47">
                        <asp:TextBox ID="TextBox30" runat="server" Enabled="False" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                    </td>
                    <td class="auto-style51">
                        <asp:Label ID="Label58" runat="server" Text="ได้รับเครื่องราชฯ ชั้นล่าสุดวันที่ 5 ธันวาคม"></asp:Label>
                    </td>
                    <td class="auto-style53">
                        <asp:TextBox ID="TextBox31" runat="server" Enabled="False" Width="63px" CssClass="master_default_textbox"></asp:TextBox>
                    </td>
                    <td class="auto-style46"></td>
                </tr>
            </table>
                </div>
            </div>

            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style55">
                        <asp:Button ID="Button1" runat="server" CssClass="master_default_textbox" Text="ยกเลิก" Width="110px" />
                    </td>
                    <td class="auto-style56">
                        <asp:Button ID="Button2" runat="server" CssClass="master_default_textbox" OnClick="Button2_Click" Text="แก้ไข" Width="110px" />
                    </td>
                    <td class="auto-style57">
                        <asp:Button ID="Button3" runat="server" CssClass="master_default_textbox" Text="พิมพ์" Width="110px" />
                    </td>
                    <td class="auto-style58">
                        <asp:Button ID="Button4" runat="server" Text="บันทึก" Width="110px" CssClass="master_default_textbox" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </div>

           
        </asp:Panel>
    </asp:Panel>
</asp:Content>
