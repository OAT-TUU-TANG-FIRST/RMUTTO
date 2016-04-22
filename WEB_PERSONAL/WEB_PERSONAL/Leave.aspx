<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="WEB_PERSONAL.Leave" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .auto-style1 {
            text-align: right;
            vertical-align: top;
            padding-right: 10px;
            color: #808080;
            height: 28px; 
        }
        .section {
            background-size: auto 400px;
            background-position: top right;
            background-repeat: no-repeat;
            min-height: 450px;
        }
        #ContentPlaceHolder1_sectionF3S1, #ContentPlaceHolder1_sectionF3S2 {
            background-image: url(Image/sea.jpg);
        }
        #ContentPlaceHolder1_sectionF4S1, #ContentPlaceHolder1_sectionF4S2 {
            background-image: url(Image/temple.jpg);
        }
        #ContentPlaceHolder1_sectionF5S1, #ContentPlaceHolder1_sectionF5S2 {
            background-image: url(Image/huj.jpg);
        }
        #ContentPlaceHolder1_sectionF6S1, #ContentPlaceHolder1_sectionF6S2 {
            background-image: url(Image/soldier.jpg);
        }
        #ContentPlaceHolder1_sectionF7S1, #ContentPlaceHolder1_sectionF7S2 {
            background-image: url(Image/training.jpg);
        }
        #ContentPlaceHolder1_sectionF8S1, #ContentPlaceHolder1_sectionF8S2 {
            background-image: url(Image/work_national.jpg);
        }
        #ContentPlaceHolder1_sectionF7S1 .col1 {
            width: 100px;
        }

        .auto-style3 {
            text-align: right;
            vertical-align: top;
            padding-right: 10px;
            color: #808080;
            height: 36px;
        }
        .auto-style4 {
            font-weight: bold;
            height: 36px;
        }
        </style>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbF1S1FromDate, #ContentPlaceHolder1_tbF1S1ToDate, #ContentPlaceHolder1_tbF2S1GiveBirthDate, #ContentPlaceHolder1_tbF2S1FromDate, #ContentPlaceHolder1_tbF2S1ToDate, #ContentPlaceHolder1_tbF3S1FromDate, #ContentPlaceHolder1_tbF3S1ToDate, #ContentPlaceHolder1_tbF4S1OrdainDate, #ContentPlaceHolder1_tbF4S1FromDate, #ContentPlaceHolder1_tbF4S1ToDate, #ContentPlaceHolder1_tbF5S1FromDate, #ContentPlaceHolder1_tbF5S1ToDate, #ContentPlaceHolder1_tbF6S1GotDate, #ContentPlaceHolder1_tbF6S1FromDate, #ContentPlaceHolder1_tbF6S1ToDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbVX21FromDate, #ContentPlaceHolder1_tbVX21ToDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbF7S1FromDate, #ContentPlaceHolder1_tbF7S1ToDate").datepicker($.datepicker.regional["th"]);
        });
    </script>
    <link href="CSS/Leave.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">
        <div class="default_header">
            <img src="Image/Small/table.png" />ทำการลา
                    </div>

        <div class="sectionSelectLeaveType">
            เลือกประเภทการลา&nbsp;
            <asp:DropDownList ID="ddlLeaveType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged" CssClass="dropdown dropdown_default">
                <asp:ListItem Value="0" Text="-- กรุณาเลือกประเภทการลา --"></asp:ListItem>
                <asp:ListItem Value="1" Text="ลาป่วย"></asp:ListItem>
                <asp:ListItem Value="2" Text="ลากิจ"></asp:ListItem>
                <asp:ListItem Value="3" Text="ลาคลอดบุตร"></asp:ListItem>
                <asp:ListItem Value="4" Text="ลาพักผ่อน"></asp:ListItem>
                <asp:ListItem Value="5" Text="ลาไปช่วยเหลือภริยาที่คลอดบุตร"></asp:ListItem>
                <asp:ListItem Value="6" Text="ลาอุปสมบท"></asp:ListItem>
                <asp:ListItem Value="7" Text="ลาไปประกอบพิธีฮัจย์"></asp:ListItem>
            </asp:DropDownList>
                        </div>

        <div class="default_separator"></div>

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VX1_1" runat="server">
                <table class="default_table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลาป่วย</td>
                   </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Reason" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Contact" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Phone" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ใบรับรองแพทย์</td>
                    <td class="col2">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                              
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF1S1Check" runat="server" CssClass="button button_default" OnClick="lbuF1S1Check_Click">ต่อไป<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            
            <asp:View ID="VX1_2" runat="server">
                <table class="default_table">
                    <tr>
                       <td colspan="2" class="head">ข้อมูลการลาป่วย</td>
                   </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2LeaveTypeName" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2PersonPosition" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2PersonRank" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2PersonDepartment" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ลาล่าสุด</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2LastFTTDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">วันที่ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2FTTDate" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Reason" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Contact" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Phone" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="col1">ใบรับรองแพทย์</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2DrCer" runat="server"></asp:Label>
                    </td>
                </tr>
                                </table>
                <div class="default_separator"></div>
                <div>
                    <asp:LinkButton ID="lbuF1S2Back" runat="server" CssClass="button button_default" OnClick="lbuF1S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF1S2Add" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
                </div>
            </asp:View>

            <asp:View ID="VX2_1" runat="server">
                <table class="default_table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลากิจ</td>
                   </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เหตุผล : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Reason" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Contact" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Phone" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                                    
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuVX21Next" runat="server" CssClass="button button_default" OnClick="lbuVX21Next_Click">ต่อไป<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX2_2" runat="server">
                <table class="default_table">
                    <tr>
                       <td colspan="2" class="head">ข้อมูลการลากิจ</td>
                   </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22LeaveType" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Name" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Position" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Rank" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Dept" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ลาล่าสุด : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22LastDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">วันที่ลา : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Date" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Reason" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Contact" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Phone" runat="server"></asp:Label>
                    </td>
                </tr>
              
                                </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuVX22Back" runat="server" CssClass="button button_default" OnClick="lbuVX22Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuVX22Finish" runat="server" CssClass="button button_default" OnClick="lbuVX22Finish_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX3_1" runat="server">
                <table class="default_table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลาคลอดบุตร</td>
                   </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox59" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox60" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เหตุผล : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox61" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox62" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox63" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                                   
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="LinkButton10" runat="server" CssClass="button button_default" OnClick="lbuF1S1Check_Click">ต่อไป<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>

            </asp:View>
            <asp:View ID="VX3_2" runat="server">
                <table class="default_table">
                    <tr>
                       <td colspan="2" class="head">ข้อมูลการลาคลอดบุตร</td>
                   </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา : </td>
                    <td class="col2">
                        <asp:Label ID="Label57" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ : </td>
                    <td class="col2">
                        <asp:Label ID="Label58" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง : </td>
                    <td class="col2">
                        <asp:Label ID="Label59" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ : </td>
                    <td class="col2">
                        <asp:Label ID="Label60" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด : </td>
                    <td class="col2">
                        <asp:Label ID="Label61" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ลาล่าสุด : </td>
                    <td class="col2">
                        <asp:Label ID="Label62" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">วันที่ลา : </td>
                    <td class="col2">
                        <asp:Label ID="Label63" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล : </td>
                    <td class="col2">
                        <asp:Label ID="Label64" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:Label ID="Label65" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:Label ID="Label66" runat="server"></asp:Label>
                    </td>
                </tr>
                                </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="button button_default" OnClick="lbuF1S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton12" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX4_1" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาพักผ่อน</td>
                    </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1Contact" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1Phone" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF3S1Check" runat="server" CssClass="button button_default" OnClick="lbuF3S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX4_2" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาพักผ่อน</td>
                    </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2LeaveTypeName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2PersonPosition" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2PersonRank" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2PersonDepartment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">วันลาพักผ่อนสะสม</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2SaveDay" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">มีสิทธิลาประจำปีนี้อีก</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2LeftDay" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">รวม</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2LeftTotalDay" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2FromDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2ToDate" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2TotalDay" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1" style="vertical-align: top;">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2Contact" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1" style="vertical-align: top;">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:Label ID="lbF3S2Phone" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF3S2Back" runat="server" CssClass="button button_default" OnClick="lbuF3S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF3S2Add" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX5_1" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปช่วยเหลือภริยาที่คลอดบุตร</td>
                    </tr>
                <tr>
                    <td class="col1">ชื่อภริยา : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1WifeName" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">นามสกุลภริยา : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1WifeLastName" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">คลอดบุตรวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1GiveBirthDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1Contact" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1Phone" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF2S1Check" runat="server" CssClass="button button_default" OnClick="lbuF2S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX5_2" runat="server">
                 <table class="default_table">
                     <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปช่วยเหลือภริยาที่คลอดบุตร</td>
                    </tr>
                <tr>
                    <td class="col1">ประเภทการลา : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2LeaveTypeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2PersonPosition" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2PersonRank" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2PersonDepartment" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อภริยา : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2WifeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">นามสกุลภริยา : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2WifeLastName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">คลอดบุตรวันที่ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2GiveBirthDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2FromDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2ToDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2TotalDay" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1" style="vertical-align: top;">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2Contact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1" style="vertical-align: top;">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:Label ID="lbF2S2Phone" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF2S2Back" runat="server" CssClass="button button_default" OnClick="lbuF2S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF2S2Add" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>
            
            <asp:View ID="VX6_1" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปอุปสมบท</td>
                    </tr>
                <tr>
                    <td class="col1">การอุปสมบท</td>
                    <td class="col2">
                        <asp:RadioButton ID="rbOrdainedTrue" runat="server" GroupName="ordained" Text="เคย" CssClass="radio_button radio_button_default" />
                        <asp:RadioButton ID="rbOrdainedFalse" runat="server" GroupName="ordained" Text="ไม่เคย" CssClass="radio_button radio_button_default" />
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ชื่อวัด</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1TempleName" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">สถานที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1TempleLocation" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">อุปสมบทวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1OrdainDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                        </td>
                </tr>

            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF4S1Check" runat="server" CssClass="button button_default" OnClick="lbuF4S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX6_2" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปอุปสมบท</td>
                    </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2LeaveTypeName" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonPosition" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonRank" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonDepartment" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">เกิดวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonBirthDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เข้ารับราชการเมื่อวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonWorkInDate" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">การอุปสมบท</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2PersonOrdained" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ชื่อวัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2TempleName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">สถานที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2TempleLocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">อุปสมบทวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2OrdainDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2FromDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2ToDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="lbF4S2TotalDay" runat="server"></asp:Label>
                    </td>
                </tr>
                                </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF4S2Back" runat="server" CssClass="button button_default" OnClick="lbuF4S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF4S2Confirm" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>

            </asp:View>
            <asp:View ID="VX7_1" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปประกอบพิธีฮัจย์</td>
                    </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        วันที่ขอลา</td>
                </tr>
                <tr>
                    <td class="col1">การไปประกอบพิธีฮัจย์</td>
                    <td class="col2">
                        <asp:RadioButton ID="rbHujedTrue" runat="server" GroupName="hujed" Text="เคย" CssClass="radio_button radio_button_default" />
                        <asp:RadioButton ID="rbHujedFalse" runat="server" GroupName="hujed" Text="ไม่เคย" CssClass="radio_button radio_button_default" />
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF5S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF5S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF5S1Check" runat="server" CssClass="button button_default" OnClick="lbuF5S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX7_2" runat="server">
                <table class="default_table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปประกอบพิธีฮัจย์</td>
                    </tr>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2LeaveTypeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonPosition" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonRank" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonDepartment" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">เข้ารับราชการเมื่อวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonWorkInDate" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">การไปประกอบพิธีฮัจย์</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2PersonHujed" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2FromDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2ToDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="lbF5S2TotalDay" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
                <div class="default_separator"></div>
                <asp:LinkButton ID="lbuF5S2Back" runat="server" CssClass="button button_default" OnClick="lbuF5S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>
            <asp:View ID="View11" runat="server">
                <table>
                <tr>
                    <td class="col1">ได้รับหมายเรียกของ</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1GotFrom" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1GotAt" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ลงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1GotDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ให้เข้ารับการ</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1ToDo" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1ToDoAt" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตั้งแต่วันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1FromDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF6S1ToDate" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuF6S1Check" runat="server" CssClass="button button_default" OnClick="lbuF6S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View12" runat="server">
                <table>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2LeaveTypeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2PersonName" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2PersonPosition" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2PersonRank" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2PersonDepartment" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ได้รับหมายเรียกของ</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2GotFrom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2GotAt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ลงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2GotDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ให้เข้ารับการ</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2ToDo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2ToDoAt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2FromDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2ToDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="lbF6S2TotalDay" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        <asp:LinkButton ID="lbuF6S2Back" runat="server" CssClass="button button_default" OnClick="lbuF6S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View13" runat="server">
                <table>
                <tr>
                    <td class="col1">ประเภท</td>
                    <td class="col2">
                        <asp:RadioButton ID="rbF7S1T1" runat="server" GroupName="F7S1T" Text="ศึกษาวิชา" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T1_CheckedChanged" />
                        <asp:RadioButton ID="rbF7S1T2" runat="server" GroupName="F7S1T" Text="ฝึกอบรม" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T2_CheckedChanged" />
                        <asp:RadioButton ID="rbF7S1T3" runat="server" GroupName="F7S1T" Text="ปฏิบัติการวิจัย" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T3_CheckedChanged" />
                        <asp:RadioButton ID="rbF7S1T4" runat="server" GroupName="F7S1T" Text="ดูงาน" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T4_CheckedChanged" />
                    </td>
                </tr>
            </table>

            <table id="F7S1Table1" runat="server">
                <tr>
                    <td class="col1">ขั้นปริญญา</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ สถานศึกษา</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเทศ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ด้วยทุน</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table id="F7S1Table2" runat="server">
                <tr>
                    <td class="col1">หลักสูตร</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเทษ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ด้วยทุน</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table>

                <tr>
                    <td class="col1">ตั้งแต่วันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF7S1FromDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF7S1ToDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">โทรศัพท์</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuF7S1Check" runat="server" CssClass="button button_default" OnClick="lbuF7S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View14" runat="server">
                <table>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ได้รับหมายเรียกของ</td>
                    <td class="col2">
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ที่</td>
                    <td class="col2">
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ลงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ให้เข้ารับการ</td>
                    <td class="col2">
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ ที่</td>
                    <td class="col2">
                        <asp:Label ID="Label10" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label11" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label12" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="Label13" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        <asp:LinkButton ID="lbuF7S2Back" runat="server" CssClass="button button_default" OnClick="lbuF7S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View15" runat="server">
                <table>
                                    <tr>
                    <td class="col1">ประเภท</td>
                    <td class="col2">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="F7S1T" Text="ศึกษาวิชา" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T1_CheckedChanged" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="F7S1T" Text="ฝึกอบรม" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T2_CheckedChanged" />
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="F7S1T" Text="ปฏิบัติการวิจัย" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T3_CheckedChanged" />
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="F7S1T" Text="ดูงาน" CssClass="radio_button radio_button_default" AutoPostBack="True" OnCheckedChanged="rbF7S1T4_CheckedChanged" />
                                        </td>
                </tr>
            </table>

            <table id="Table1" runat="server">
                <tr>
                    <td class="col1">ขั้นปริญญา</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ สถานศึกษา</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเทศ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ด้วยทุน</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                                        </td>
                </tr>
            </table>

            <table id="Table2" runat="server">
                <tr>
                    <td class="col1">หลักสูตร</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเทษ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ด้วยทุน</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                                        </td>
                </tr>
            </table>

            <table>

                <tr>
                    <td class="col1">ตั้งแต่วันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                                    </tr>

                <tr>
                    <td class="col1">ไปปฏิบัติงานให้กับ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">ณ ประเทศ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>

                <tr>
                    <td class="col1">ตำแหน่งที่จะไปปฏิบัติงาน</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">หน้าที่ที่จะไปปฏิบัติงาน (โดยย่อ)</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox29" runat="server" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">กำหนดออกเดินทางประมานวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">ค่าตอบแทนที่ได้รับ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">เงินเดือน อัตราเดือน/ปีละ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">ค่าที่พัก</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">ค่าพาหนะในการเดินทาง</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">อื่นๆ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">สถานที่ติดต่อ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">หมายเลขโทรศัพท์</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <asp:LinkButton ID="lbuF8S1Check" runat="server" CssClass="button button_default" OnClick="lbuF8S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View16" runat="server">
                <table>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="Label14" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="Label15" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="Label16" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="Label17" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="Label18" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ได้รับหมายเรียกของ</td>
                    <td class="col2">
                        <asp:Label ID="Label19" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ที่</td>
                    <td class="col2">
                        <asp:Label ID="Label20" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ลงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label21" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ให้เข้ารับการ</td>
                    <td class="col2">
                        <asp:Label ID="Label22" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ณ ที่</td>
                    <td class="col2">
                        <asp:Label ID="Label23" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label24" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label25" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="Label26" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        <asp:LinkButton ID="lbuF8S2Back" runat="server" CssClass="button button_default" OnClick="lbuF8S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton6" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
            </asp:View>
            <asp:View ID="View17" runat="server">
                <table>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        วันที่ขอลา</td>
                </tr>
                <tr>
                    <td class="col1">คู่สมรสชื่อ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox39" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ซึ่งไปปฏิบัติราชการ/ปฏิบัติงาน ณ ประเทศ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">มีกำหนด</td>
                    <td class="col2">
                        ปี<asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
                        เดือน<asp:TextBox ID="TextBox44" runat="server"></asp:TextBox>
                        วัน<asp:TextBox ID="TextBox45" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuF9S1Check" runat="server" CssClass="button button_default" OnClick="lbuF9S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View18" runat="server">
                <table>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="Label27" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="Label28" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="Label29" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="Label30" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="Label31" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">เข้ารับราชการเมื่อวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label32" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">การไปประกอบพิธีฮัจย์</td>
                    <td class="col2">
                        <asp:Label ID="Label33" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label34" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label35" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="Label36" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        <asp:LinkButton ID="lbuF9S2Back" runat="server" CssClass="button button_default" OnClick="lbuF9S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton9" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
                                        </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View19" runat="server">
                <table>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        วันที่ขอลา</td>
                </tr>
                <tr>
                    <td class="col1">คู่สมรสชื่อ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox46" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox47" runat="server"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox48" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox49" runat="server"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ซึ่งไปปฏิบัติราชการ/ปฏิบัติงาน ณ ประเทศ</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox50" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">มีกำหนด</td>
                    <td class="col2">
                        ปี<asp:TextBox ID="TextBox51" runat="server"></asp:TextBox>
                        เดือน<asp:TextBox ID="TextBox52" runat="server"></asp:TextBox>
                        วัน<asp:TextBox ID="TextBox53" runat="server"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox54" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuF10S1Check" runat="server" CssClass="button button_default" OnClick="lbuF10S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
            </asp:View>
            <asp:View ID="View20" runat="server">
                <table>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="Label37" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="Label38" runat="server"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="Label39" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="Label40" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="Label41" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">เข้ารับราชการเมื่อวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label42" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">การไปประกอบพิธีฮัจย์</td>
                    <td class="col2">
                        <asp:Label ID="Label43" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label44" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="Label45" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="Label46" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col_res">
                        <asp:LinkButton ID="lbuF10S2Back" runat="server" CssClass="button button_default" OnClick="lbuF10S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="button button_default" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
                </td>
            </tr>
        </table>
            </asp:View>
            <asp:View ID="View21" runat="server">
                <div>
                <asp:LinkButton ID="lbuBackMain" runat="server" CssClass="button button_default" OnClick="lbuBackMain_Click"><img class="icon_left" src="Image/Small/back.png" />กลับหน้าหลัก</asp:LinkButton>
            </div>
            </asp:View>
        </asp:MultiView>

    </div>

    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfSql2" runat="server" />
    <asp:HiddenField ID="hfFileUploadName" runat="server" />

</asp:Content>
