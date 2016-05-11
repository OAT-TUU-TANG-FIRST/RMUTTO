<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="WEB_PERSONAL.Leave" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


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
        <div class="ps-header">
            <img src="Image/Small/document-create.png" />ทำการลา
                    </div>

        <div class="sectionSelectLeaveType">
            เลือกประเภทการลา&nbsp;
            <asp:DropDownList ID="ddlLeaveType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged" CssClass="ps-dropdown">
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

        <div class="ps-separator"></div>

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VX1_1" runat="server">
                <div class="ps-lb-progress-contain">
                    <span class="ps-lb-progress-sel">1) กรอกข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-unsel">2) ยืนยันข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-unsel">3) สำเร็จ</span>
                </div>
                <table class="ps-table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลาป่วย</td>
                   </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>เหตุผล</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Reason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1"><img src="Image/Small/phone.png" class="icon_left"/>เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1S1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/clip.png" class="icon_left"/>ใบรับรองแพทย์</td>
                    <td class="col2">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                    <tr>
                        <td class="ps-table-bottom" colspan="2">
                            <asp:LinkButton ID="lbuF1S1Check" runat="server" CssClass="ps-button" OnClick="lbuF1S1Check_Click">ต่อไป<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
                        </td>
                    </tr>
                              
            </table>
                <div class="ps-separator"></div>
                
            </asp:View>  
            <asp:View ID="VX1_2" runat="server">
                <div class="ps-lb-progress-contain">
                    <span class="ps-lb-progress-unsel">1) กรอกข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-sel">2) ยืนยันข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-unsel">3) สำเร็จ</span>
                </div>
                <table class="ps-table">
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
                    <td class="col1"><img src="Image/Small/person2.png" class="icon_left"/>ชื่อ</td>
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
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>ลาล่าสุด</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2LastFTTDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>วันที่ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2FTTDate" runat="server"></asp:Label>
                                        </td>
                </tr>
                    <tr>
                        <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>สถิติการลา</td>
                        <td class="col2">
                            <asp:Label ID="lbF1S2Statistic" runat="server"></asp:Label>
                        </td>
                    </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>เหตุผล</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Reason" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Contact" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/phone.png" class="icon_left"/>เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2Phone" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                    <td class="col1"><img src="Image/Small/clip.png" class="icon_left"/>ใบรับรองแพทย์</td>
                    <td class="col2">
                        <asp:Label ID="lbF1S2DrCer" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td class="ps-table-bottom" colspan="2">
                            <asp:LinkButton ID="lbuF1S2Back" runat="server" CssClass="ps-button" OnClick="lbuF1S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF1S2Add" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click"><img src="Image/Small/document-create.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
                        </td>
                    </tr>
                                </table>
                <div class="ps-separator"></div>
            </asp:View>

            <asp:View ID="VX2_1" runat="server">
                <table class="ps-table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลากิจ</td>
                   </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Reason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:TextBox ID="tbVX21Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                                    
            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuVX21Next" runat="server" CssClass="ps-button" OnClick="lbuVX21Next_Click">ต่อไป<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX2_2" runat="server">
                <table class="ps-table">
                    <tr>
                       <td colspan="2" class="head">ข้อมูลการลากิจ</td>
                   </tr>
                                    <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22LeaveTypeName" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ชื่อ</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22PersonName" runat="server"></asp:Label>
                        &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22PersonPosition" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22PersonPosRank" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22PersonDept" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ลาล่าสุด</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22LastFTTDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">วันที่ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22FTTDate" runat="server"></asp:Label>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Reason" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Contact" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:Label ID="lbVX22Phone" runat="server"></asp:Label>
                    </td>
                </tr>
                                </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuVX22Back" runat="server" CssClass="ps-button" OnClick="lbuVX22Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuVX22Finish" runat="server" CssClass="ps-button" OnClick="lbuVX22Finish_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX3_1" runat="server">
                <table class="ps-table">
                   <tr>
                       <td colspan="2" class="head">ข้อมูลการลาคลอดบุตร</td>
                   </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox59" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox60" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                <tr>
                    <td class="col1">เหตุผล : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox61" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox62" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="TextBox63" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                                   
            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="LinkButton10" runat="server" CssClass="ps-button" OnClick="lbuF1S1Check_Click">ต่อไป<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>

            </asp:View>
            <asp:View ID="VX3_2" runat="server">
                <table class="ps-table">
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
                <div class="ps-separator"></div>
                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="ps-button" OnClick="lbuF1S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton12" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX4_1" runat="server">
                <table class="ps-table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาพักผ่อน</td>
                    </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF3S1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF3S1Check" runat="server" CssClass="ps-button" OnClick="lbuF3S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX4_2" runat="server">
                <table class="ps-table">
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
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF3S2Back" runat="server" CssClass="ps-button" OnClick="lbuF3S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF3S2Add" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>

            <asp:View ID="VX5_1" runat="server">
                <table class="ps-table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลาไปช่วยเหลือภริยาที่คลอดบุตร</td>
                    </tr>
                <tr>
                    <td class="col1">ชื่อภริยา : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1WifeName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">นามสกุลภริยา : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1WifeLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">คลอดบุตรวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1GiveBirthDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์ : </td>
                    <td class="col2">
                        <asp:TextBox ID="tbF2S1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF2S1Check" runat="server" CssClass="ps-button" OnClick="lbuF2S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX5_2" runat="server">
                 <table class="ps-table">
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
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF2S2Back" runat="server" CssClass="ps-button" OnClick="lbuF2S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF2S2Add" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>
            
            <asp:View ID="VX6_1" runat="server">
                <table class="ps-table">
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
                        <asp:TextBox ID="tbF4S1TempleName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">สถานที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1TempleLocation" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">อุปสมบทวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1OrdainDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF4S1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                        </td>
                </tr>

            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF4S1Check" runat="server" CssClass="ps-button" OnClick="lbuF4S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX6_2" runat="server">
                <table class="ps-table">
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
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF4S2Back" runat="server" CssClass="ps-button" OnClick="lbuF4S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF4S2Confirm" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>

            </asp:View>
            <asp:View ID="VX7_1" runat="server">
                <table class="ps-table">
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
                        <asp:TextBox ID="tbF5S1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF5S1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF5S1Check" runat="server" CssClass="ps-button" OnClick="lbuF5S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="VX7_2" runat="server">
                <table class="ps-table">
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
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuF5S2Back" runat="server" CssClass="ps-button" OnClick="lbuF5S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click">ยืนคำขอลา</asp:LinkButton>
            </asp:View>
            <asp:View ID="VX_F" runat="server">
                <div>
                <asp:LinkButton ID="lbuBackMain" runat="server" CssClass="ps-button" OnClick="lbuBackMain_Click"><img class="icon_left" src="Image/Small/back.png" />กลับหน้าหลัก</asp:LinkButton>
            </div>
            </asp:View>
        </asp:MultiView>

    </div>

    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfSql2" runat="server" />
    <asp:HiddenField ID="hfFileUploadName" runat="server" />

</asp:Content>
