﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="insignia_from_add.aspx.cs" Inherits="WEB_PERSONAL.insignia_from_add" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .back_T{
            color:#000000;
            font-size: 32px;
        }
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

        .auto-style8 {
            width: 320px;
            font-size: 28px;
            color:#FFFFFF;
        }

        .auto-style9 {
            width: 287px;
        }

        .auto-style16 {
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

        .auto-style59 {
            height: 23px;
            width: 124px;
        }

        .auto-style60 {
            width: 124px;
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
    <asp:Panel ID="Panel1" runat="server">
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
                                <asp:Label ID="Label7" runat="server" CssClass="auto-style4" Text="บันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์" Font-Size="24pt"></asp:Label>
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
                                &nbsp;</td>
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
                                รหัสผู้ขอเครื่องราชฯ</td>
                            <td>
                                <asp:TextBox ID="TextBox42" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
                                &nbsp;<asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click" CssClass="master_tuu_button">ตรวจสอบ</asp:LinkButton>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                ชื่อหน่วยงานที่ขอพระราชทาน
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="master_default_textbox" DataSourceID="SqlDataSource1" DataTextField="FACULTY_NAME" DataValueField="FACULTY_ID" OnDataBound="DropDownList1_DataBound" Width="269px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="select * from tb_faculty"></asp:SqlDataSource>
                                <asp:Label ID="Label59" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                มาช่วยราชการจากที่ใด (ถ้ามี)
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="master_default_textbox" DataSourceID="SqlDataSource2" DataTextField="NAME_COMM" DataValueField="ID_COMM" OnDataBound="DropDownList2_DataBound" Width="269px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;AA_COMMAND&quot;"></asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                เครื่องราชฯ ที่ขอพระราชทาน ประจำปี
                            </td>
                            <td class="auto-style16">
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="master_default_textbox" DataSourceID="SqlDataSource3" DataTextField="YEAR_ID" DataValueField="YEAR_ID" OnDataBound="DropDownList3_DataBound" Width="269px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_DATE_YEAR&quot;"></asp:SqlDataSource>
                                <asp:Label ID="Label61" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td class="auto-style16"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                คือชั้น
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="master_default_textbox" DataSourceID="SqlDataSource4" DataTextField="NAME_GRADEINSIGNIA_THA" DataValueField="ID_GRADEINSIGNIA" OnDataBound="DropDownList4_DataBound" Width="269px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_GRADEINSIGNIA&quot;"></asp:SqlDataSource>

                                <asp:Label ID="Label62" runat="server" ForeColor="Red"></asp:Label>

                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                ชั้นนี้เป็นการขอพระราชทาน
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
                            <td class="auto-style64">
                                &nbsp;</td>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    
                    <asp:CheckBox ID="CheckBox6" runat="server" Text="กรณีขอครั้งแรก / เปลี่ยนชื่อ" AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged" CssClass="back_T" />
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
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox2" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox18" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
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

            <!-- กรอบหัวข้อ และ เนื้อหา ส่วนที่ 3-->
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
                        <asp:TextBox ID="TextBox21" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
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
                                    <asp:TextBox ID="TextBox38" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
                                </td>
                                <td class="auto-style40">
                                    <asp:Label ID="Label50" runat="server" Text="เมื่อ วัน/เดือน/ปี"></asp:Label>
                                </td>
                                <td class="auto-style33">
                                    <asp:TextBox ID="TextBox25" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style35">&nbsp;</td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label49" runat="server" Text="2. ระดับ"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="TextBox39" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
                                </td>
                                <td class="auto-style41">
                                    <asp:Label ID="Label55" runat="server" Text="เมื่อ วัน/เดือน/ปี"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox26" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox40" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox41" runat="server" CssClass="master_default_textbox" Width="269px"></asp:TextBox>
                    </td>
                    <td class="auto-style41">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="กลุ่มงานสนับสนุน" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="กลุ่มงานช่าง" ValidationGroup="rr" />
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
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="กลุ่มงานบริการ" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="กลุ่มงานเทคนิค" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style44">&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="กลุ่มงานบริหารทั่วไป" />
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
                        <asp:TextBox ID="TextBox30" runat="server" Width="269px" CssClass="master_default_textbox"></asp:TextBox>
                    </td>
                    <td class="auto-style51">
                        <asp:Label ID="Label58" runat="server" Text="ได้รับเครื่องราชฯ ชั้นล่าสุดวันที่ 5 ธันวาคม"></asp:Label>
                    </td>
                    <td class="auto-style53">
                        <asp:TextBox ID="TextBox31" runat="server" Width="63px" CssClass="master_default_textbox"></asp:TextBox>
                    </td>
                    <td class="auto-style46"></td>
                </tr>
            </table>
                </div>
            </div>

            </div>
                </div>
            </div>

            

            <div class="dpl_7c"></div>

            <div style="text-align:center">
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="master_tuu_button" OnClick="LinkButton3_Click" >ยกเลิก</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="master_tuu_button" OnClick="Button4_Click">บันทึก</asp:LinkButton>
            </div>

           
        </asp:Panel>
    </asp:Panel>
</asp:Content>
