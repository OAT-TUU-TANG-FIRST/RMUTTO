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
            $("#ContentPlaceHolder1_tbS1FromDate, #ContentPlaceHolder1_tbS1ToDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbS1GBDate, #ContentPlaceHolder1_tbS1OrdainDate").datepicker($.datepicker.regional["th"]);
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
                    <span class="ps-lb-progress-unsel">3) เสร็จสิ้น</span>
                </div>
                <table class="ps-table">
                    <tr>
                        <td colspan="2" class="head">
                            <asp:Label ID="lbLeaveTypeName" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trS1WifeFirstName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/person2.png" class="icon_left" />ชื่อภริยา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1WifeFirstName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1WifeLastName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/person2.png" class="icon_left" />
                            นามสกุลภริยา</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1WifeLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1GBDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            คลอดบุตรวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1GBDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1Ordained" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left" />
                            การอุปสมบท</td>
                        <td class="col2">
                            <asp:RadioButton ID="rbS1OrdainedT" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="เคย" />
                            <asp:RadioButton ID="rbS1OrdainedF" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="ไม่เคย" />
                        </td>
                    </tr>
                    <tr id="trS1TempleName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/bell.png" class="icon_left" />
                            ชื่อวัด</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1TempleName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1TempleLocation" runat="server">
                        <td class="col1">
                            <img src="Image/Small/location.png" class="icon_left" />
                            สถานที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1TempleLocation" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1OrdainDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            อุปสมบทวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1OrdainDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1Hujed" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left" />
                            การไปประกอบพิธฮัจย์</td>
                        <td class="col2">
                            <asp:RadioButton ID="rbS1HujedT" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="เคย" />
                            <asp:RadioButton ID="rbS1HujedF" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="ไม่เคย" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            จากวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />ถึงวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1Reason" runat="server">
                        <td class="col1">
                            <img src="Image/Small/a.png" class="icon_left" />เหตุผล</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1Reason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1Contact" runat="server">
                        <td class="col1">
                            <img src="Image/Small/a.png" class="icon_left" />ติดต่อได้ที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1Phone" runat="server">
                        <td class="col1">
                            <img src="Image/Small/phone.png" class="icon_left" />เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:TextBox ID="tbS1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trS1DrCer" runat="server">
                        <td class="col1">
                            <img src="Image/Small/clip.png" class="icon_left" />ใบรับรองแพทย์</td>
                        <td class="col2">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="ps-table-bottom" colspan="2">
                            <asp:LinkButton ID="lbuS1Check" runat="server" CssClass="ps-button" OnClick="lbuS1Check_Click">ต่อไป<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
                        </td>
                    </tr>

                </table>

            </asp:View>
            <asp:View ID="VX1_2" runat="server">
                <div class="ps-lb-progress-contain">
                    <span class="ps-lb-progress-unsel">1) กรอกข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-sel">2) ยืนยันข้อมูล</span>
                    <span class="ps-lb-progress-cen"></span>
                    <span class="ps-lb-progress-unsel">3) เสร็จสิ้น</span>
                </div>
                <table class="ps-table">
                    <tr>
                        <td colspan="2" class="head">
                            <asp:Label ID="lbLeaveTypeName2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทการลา</td>
                        <td class="col2">
                            <asp:Label ID="lbS2LeaveTypeName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">
                            <img src="Image/Small/person2.png" class="icon_left" />ชื่อ</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSName" runat="server"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSPos" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ระดับ</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSAPos" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สังกัด</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSDept" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2BirthDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            เกิดวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSBirthDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2WorkInDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            เข้ารับราชการเมื่อวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2PSWorkInDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2RestSave" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />วันลาพักผ่อนสะสม</td>
                        <td class="col2">
                            <asp:Label ID="lbS2RestSave" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2RestLeft" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            มีสิทธิลาประจำปีนี้อีก</td>
                        <td class="col2">
                            <asp:Label ID="lbS2RestLeft" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2RestTotal" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            รวม</td>
                        <td class="col2">
                            <asp:Label ID="lbS2RestTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2WifeName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/person2.png" class="icon_left" />
                            ชื่อภริยา</td>
                        <td class="col2">
                            <asp:Label ID="lbS2WifeName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2GBDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            คลอดบุตรวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2GBDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Ordained" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left" />
                            การอุปสมบท</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Ordained" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2TempleName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/bell.png" class="icon_left" />
                            ชื่อวัด</td>
                        <td class="col2">
                            <asp:Label ID="lbS2TempleName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2TempleLocation" runat="server">
                        <td class="col1">
                            <img src="Image/Small/location.png" class="icon_left" />
                            สถานที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2TempleLocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2OrdainDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            อุปสมบทวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2OrdainDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Hujed" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left" />
                            การไปประกอบพิธีฮัจย์</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Hujed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2LastFTTDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            ลาล่าสุด</td>
                        <td class="col2">
                            <asp:Label ID="lbS2LastFTTDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />วันที่ลา</td>
                        <td class="col2">
                            <asp:Label ID="lbS2FTTDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Statistic" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />สถิติการลา</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Statistic" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Reason" runat="server">
                        <td class="col1">
                            <img src="Image/Small/a.png" class="icon_left" />เหตุผล</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Reason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Contact" runat="server">
                        <td class="col1">
                            <img src="Image/Small/a.png" class="icon_left" />ติดต่อได้ที่</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Contact" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2Phone" runat="server">
                        <td class="col1">
                            <img src="Image/Small/phone.png" class="icon_left" />เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:Label ID="lbS2Phone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trS2DrCer" runat="server">
                        <td class="col1">
                            <img src="Image/Small/clip.png" class="icon_left" />ใบรับรองแพทย์</td>
                        <td class="col2">
                            <asp:Label ID="lbS2DrCer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ps-table-bottom" colspan="2">
                            <asp:LinkButton ID="lbuS2Back" runat="server" CssClass="ps-button" OnClick="lbuS2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                            <asp:LinkButton ID="lbuS2Finish" runat="server" CssClass="ps-button" OnClick="lbuS2Finish_Click"><img src="Image/Small/document-create.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="VX_F" runat="server">
                <div>
                    <asp:LinkButton ID="lbuBackMain" runat="server" CssClass="ps-button" OnClick="lbuBackMain_Click"><img class="icon_left" src="Image/Small/back.png" />กลับหน้าหลัก</asp:LinkButton>
                    <asp:LinkButton ID="lbuHistory" runat="server" CssClass="ps-button" OnClick="lbuHistory_Click"><img class="icon_left" src="Image/Small/back.png" />ไปหน้าสถานะและประวัติ</asp:LinkButton>
                </div>
            </asp:View>

        </asp:MultiView>

    </div>

    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfSql2" runat="server" />
    <asp:HiddenField ID="hfFileUploadName" runat="server" />

</asp:Content>
