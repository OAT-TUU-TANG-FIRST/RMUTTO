<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintLeaveForm.aspx.cs" Inherits="WEB_PERSONAL.PrintLeaveForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Print.css" rel="stylesheet" />
    <script>
        function CallPrint(strid) {
            document.getElementById('control-area').style.display = "none";
            window.print();
            document.getElementById('control-area').style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="control-area">
                <asp:LinkButton ID="lbuPrint" runat="server" OnClientClick="CallPrint('print-area');"><img src="Image/Small/printer.png" />ปริ้น</asp:LinkButton>
            </div>
        <div id="print-area">

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="center"><u>แบบใบลาป่วย ลาคลอดบุตร ลากิจส่วนตัว</u></div>
                    <div class="right">เขียนที่ มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</div>
                    <div class="right">
                        <asp:Label ID="lbReqDate" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="left">
                        <asp:Label ID="lbTitle" runat="server" Text="เรื่อง การลาป่วย"></asp:Label>
                    </div>
                    <div class="left">
                        <asp:Label ID="lbStartWord" runat="server" Text="เรียน กกก"></asp:Label>
                    </div>
                    <div class="para">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ข้าพเจ้า <asp:Label ID="Label1" runat="server" Text="ข้าพเจ้า"></asp:Label>
                        ตำแหน่ง <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        ระดับ <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        สังกัด <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        ขอลา <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        เนื่องจาก <asp:Label ID="lbReason" runat="server" Text="Label"></asp:Label>
                        ตั้งแต่วันที่ <asp:Label ID="lbFromDateDay" runat="server" Text="Label"></asp:Label>
                        เดือน <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        พ.ศ. <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        ถึงวันที่ <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                        เดือน <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                        พ.ศ. <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                        มีกำหนด <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        วัน ข้าพเข้าได้ลา <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        ครั้งสุดท้ายตั้งแต่วันที่ <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                        เดือน <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                        พ.ศ. <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                        ถึงวันที่ <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                        เดือน <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                        พ.ศ. <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                        มีกำหนด <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                        ในระหว่างลาจะติดต่อข้าพเจ้าได้ที่ <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                        หมายเลขโทรศัพท์ <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="right">
                        ( <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label> )
                    </div>
                    <div class="left">
                        <u>สถิติการลาในปีงบประมาณนี้</u>
                    </div>
                    <table class="table">
                        <tr>
                            <td>ประเภทลา</td>
                            <td>ลามาแล้ว</td>
                            <td>ลาครั้งนี้</td>
                            <td>รวมเป็น</td>
                        </tr>
                        <tr>
                            <td>ป่วย</td>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>กิจส่วนตัว</td>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>คลอดบุตร</td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="left" style="float: left; margin-left: 100px;">
                        <div><u>ความเห็นผู้บังคับบัญชา</u></div>
                        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                        <br />
                        ( <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label> )
                        <br />
                        <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="left" style="float: right; margin-right: 100px;">
                        <div><u>คำสั่ง</u></div>
                        <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
                        <br />
                        ( <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label> )
                        <br />
                        <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div style="clear: both;"></div>

            <table class="ps-table" style="display: inline-block; vertical-align: top;">
                <tr>
                    <td class="head" colspan="2">
                        &nbsp;ข้อมูลการลา</td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;รหัสการลา
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;สถานะการลา </td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveStatusID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ประเภทการลา
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;วันที่ข้อมูล
                    </td>
                    <td class="col2">
                        
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ชื่อผู้ลา
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSAPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSDept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trPSBirthDate" runat="server">
                    <td class="col1">
                        &nbsp;เกิดวันที่
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSBirthDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trPSWorkInDate" runat="server">
                    <td class="col1">
                        &nbsp;เข้ารับราชการวันที่
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPSWorkInDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestSave" runat="server">
                    <td class="col1">
                        &nbsp;วันลาพักผ่อนสะสม</td>
                    <td class="col2">
                        <asp:Label ID="lbRestSave" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestLeft" runat="server">
                    <td class="col1">
                        &nbsp;มีสิทธิลาประจำปีนี้อีก</td>
                    <td class="col2">
                        <asp:Label ID="lbRestLeft" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestTotal" runat="server">
                    <td class="col1">
                        &nbsp;รวม</td>
                    <td class="col2">
                        <asp:Label ID="lbRestTotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trWifeName" runat="server">
                    <td class="col1">
                        &nbsp;ชื่อภริยา</td>
                    <td class="col2">
                        <asp:Label ID="lbWifeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trGBDate" runat="server">
                    <td class="col1">
                        &nbsp;คลอดบุตรวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbGBDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trOrdained" runat="server">
                    <td class="col1">
                        &nbsp;การอุปสมบท</td>
                    <td class="col2">
                        <asp:Label ID="lbOrdained" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trTempleName" runat="server">
                    <td class="col1">
                        &nbsp;ชื่อวัด</td>
                    <td class="col2">
                        <asp:Label ID="lbTempleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trTempleLocation" runat="server">
                    <td class="col1">
                        &nbsp;สถานที่</td>
                    <td class="col2">
                        <asp:Label ID="lbTempleLocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trOrdainDate" runat="server">
                    <td class="col1">
                        &nbsp;อุปสมบทวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbOrdainDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trHujed" runat="server">
                    <td class="col1">
                        &nbsp;การไปประกอบพิธีฮัจย์</td>
                    <td class="col2">
                        <asp:Label ID="lbHujed" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trLastFTTDate" runat="server">
                    <td class="col1">
                        &nbsp;วันที่ลาล่าสุด
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbLastFTTDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trFTTDate" runat="server">
                    <td class="col1">
                        &nbsp;วันที่ลา
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbFTTDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trStatistic" runat="server">
                    <td class="col1">
                        &nbsp;สถิติการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbStatistic" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trReason" runat="server">
                    <td class="col1">
                        &nbsp;เหตุผล
                    </td>
                    <td class="col2">
                        
                    </td>
                </tr>
                <tr id="trCancelReason" runat="server">
                    <td class="col1">
                        &nbsp;เหตุผลที่ยกเลิก </td>
                    <td class="col2">
                        <asp:Label ID="lbCancelReason" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trContact" runat="server">
                    <td class="col1">
                        &nbsp;ติดต่อได้ที่
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbContact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trPhone" runat="server">
                    <td class="col1">
                        &nbsp;เบอร์โทรศัพท์
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbPhone" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>
            <table class="ps-table" style="display: inline-block; vertical-align: top;">
                <tr>
                    <td class="head" colspan="2">
                        &nbsp;ผู้บังคับบัญชาระดับต่ำ</td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ชื่อ
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCLName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCLPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ความเห็น
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCLCom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;วันที่
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCLDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trCLCancelComment" runat="server">
                    <td class="col1">
                        &nbsp;ความเห็นการยกเลิก
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCL_C_Com" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trCLCancelDate" runat="server">
                    <td class="col1">
                        &nbsp;วันที่การยกเลิก
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCL_C_Date" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="ps-table" style="display: inline-block; vertical-align: top;">
                <tr>
                    <td class="head" colspan="2">
                        &nbsp;ผู้บังคับบัญชาระดับสูง</td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ชื่อผู้อนุมัติ
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCHName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCHPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;ความเห็น
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCHCom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;วันที่
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCHDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        &nbsp;การอนุมัติ
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCHAllow" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trCHCancelComment" runat="server">
                    <td class="col1">
                        &nbsp;ความเห็นการยกเลิก
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCH_C_Com" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trCHCancelDate" runat="server">
                    <td class="col1">
                        &nbsp;วันที่การยกเลิก
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCH_C_Date" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trCHCancelAllow" runat="server">
                    <td class="col1">
                        &nbsp;การอนุมัติการยกเลิก
                    </td>
                    <td class="col2">
                        <asp:Label ID="lbCH_C_Allow" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
                </asp:View>
            </asp:MultiView>

            
        </div>
            </div>
    </form>
</body>
</html>
