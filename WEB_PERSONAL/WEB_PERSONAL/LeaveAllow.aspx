﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveAllow.aspx.cs" Inherits="WEB_PERSONAL.LeaveAllow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            padding: 3px 5px;
            background-color: #ffffff;
            color: #0000ff;
            color: #0040ff;
            border-bottom: 1px solid #f0f0f0;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/correct.png" />อนุมัติการลา</div>
        <div id="error_area" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div>
                    <div class="ps-div-title-red">กรุณาเลือกรายการที่ต้องการอนุมัติการลา</div>
                    <asp:GridView ID="GridView1" runat="server" CssClass="ps-table-1" style="margin: 0 auto; margin-bottom: 20px;"></asp:GridView>
                    <div style="text-align: center; margin-top: 10px;">
                        <asp:Label ID="lbNoData" runat="server" Text="ขณะนี้ไม่มีรายการที่ท่านต้องอนุมัติ" style="color: #808080;"></asp:Label>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div>
                    <div class="ps-div-title-red">ข้อมูลการลา</div>
                    <table class="ps-table-1" style="margin: 0 auto; margin-bottom: 10px;">
                    <tr>
                    <td class="col1">
                        <img src="Image/Small/ID.png" class="icon_left" />
                        รหัสการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1"><img src="Image/Small/list.png" class="icon_left"/>ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveTypeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        <img src="Image/Small/calendar.png" class="icon_left"/>
                        วันที่ข้อมูล</td>
                    <td class="col2">
                        <asp:Label ID="lbReqDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">
                        <img src="Image/Small/person2.png" class="icon_left" />
                        ผู้ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbPSName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbPSPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbPSAPos" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbPSDept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trPSBirthDate" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>เกิดวันที่ </td>
                    <td class="col2">
                        <asp:Label ID="lbPSBirthDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trPSWorkInDate" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>เข้ารับราชการวันที่ </td>
                    <td class="col2">
                        <asp:Label ID="lbPSWorkInDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestSave" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>วันลาพักผ่อนสะสม</td>
                    <td class="col2">
                        <asp:Label ID="lbRestSave" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestLeft" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>มีสิทธิลาประจำปีนี้อีก</td>
                    <td class="col2">
                        <asp:Label ID="lbRestLeft" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trRestTotal" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>รวม</td>
                    <td class="col2">
                        <asp:Label ID="lbRestTotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trWifeName" runat="server">
                    <td class="col1"><img src="Image/Small/person2.png" class="icon_left"/>ชื่อภริยา</td>
                    <td class="col2">
                        <asp:Label ID="lbWifeName" runat="server"></asp:Label>
                    </td>
                </tr>
                    <tr id="trGBDate" runat="server">
                    <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>คลอดบุตรวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbGBDate" runat="server"></asp:Label>
                        </td>
                </tr>
                    <tr id="trOrdained" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left"/>
                            การอุปสมบท</td>
                        <td class="col2">
                            <asp:Label ID="lbOrdained" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trTempleName" runat="server">
                        <td class="col1">
                            <img src="Image/Small/bell.png" class="icon_left"/>
                            ชื่อวัด</td>
                        <td class="col2">
                            <asp:Label ID="lbTempleName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trTempleLocation" runat="server">
                        <td class="col1">
                            <img src="Image/Small/location.png" class="icon_left" />
                            สถานที่</td>
                        <td class="col2">
                            <asp:Label ID="lbTempleLocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trOrdainDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            อุปสมบทวันที่</td>
                        <td class="col2">
                            <asp:Label ID="lbOrdainDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHujed" runat="server">
                        <td class="col1">
                            <img src="Image/Small/question.png" class="icon_left" />
                            การไปประกอบพิธีฮัจย์</td>
                        <td class="col2">
                            <asp:Label ID="lbHujed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trLastFTTDate" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            วันที่ลาล่าสุด </td>
                        <td class="col2">
                            <asp:Label ID="lbLastFTTDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            วันที่ลา </td>
                        <td class="col2">
                            <asp:Label ID="lbFTTDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trStatistic" runat="server">
                        <td class="col1">
                            <img src="Image/Small/calendar.png" class="icon_left" />
                            สถิติการลา</td>
                        <td class="col2">
                            <asp:Label ID="lbStatistic" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trReason" runat="server">
                        <td class="col1">
                            <img src="Image/Small/comment.png" class="icon_left" />
                            เหตุผล</td>
                        <td class="col2">
                            <asp:Label ID="lbReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trContact" runat="server">
                        <td class="col1">
                            <img src="Image/Small/a.png" class="icon_left" />
                            ติดต่อได้ที่</td>
                        <td class="col2">
                            <asp:Label ID="lbContact" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trPhone" runat="server">
                        <td class="col1">
                            <img src="Image/Small/phone.png" class="icon_left" />
                            เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:Label ID="lbPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trDrCer" runat="server">
                        <td class="col1">
                            <img src="Image/Small/clip.png" class="icon_left" />
                            เอกสารแนบ</td>
                        <td class="col2">
                            <div id="divDrCer" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr id="trCancelReason" runat="server">
                        <td class="col1">
                            <img src="Image/Small/comment.png" class="icon_left" />
                            เหตุผลที่ยกเลิก</td>
                        <td class="col2">
                            <asp:Label ID="lbCancelReason" runat="server"></asp:Label>
                        </td>
                    </tr>

                    
                </table>

                    <div class="ps-separator"></div>

                    <div class="ps-div-title-red">ผู้อนุมัติการลา</div>
                    <div style="text-align: center;">
                        <asp:Table ID="tbBoss" runat="server" Style="text-align: center; display: inline-block;"></asp:Table>
                    </div>

                    <div class="ps-separator"></div>

                    <div class="ps-div-title-red">อนุมัติการลา</div>
                    <table class="ps-table-1" style="margin: 0 auto; margin-bottom: 10px;">
                        <tr>
                            <td class="col1"><img src="Image/Small/comment.png" class="icon_left"/>ความเห็น</td>
                            <td class="col2">
                                <asp:TextBox ID="tbF1Comment" runat="server" Height="50px" Width="300px" TextMode="MultiLine" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1"><img src="Image/Small/correct.png" class="icon_left"/>การอนุมัติ</td>
                            <td class="col2">
                                <asp:RadioButton ID="rbAllow" runat="server" GroupName="allow" Text="อนุญาต" />
                                <asp:RadioButton ID="rbNotAllow" runat="server" GroupName="allow" Text="ไม่อนุญาต" />
                            </td>
                        </tr>
                    </table>

                    <div style="text-align: center; margin-bottom: 10px;">
                        <asp:LinkButton ID="lbuBack" runat="server" CssClass="ps-button" OnClick="lbuBack_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuAddComment" runat="server" CssClass="ps-button" OnClick="lbuAddComment_Click">ยืนยันการอนุมัติ<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
                    </div>
                </div>

                
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="ps-div-title-red"><img src="Image/Small/correct.png" class="icon_left;"/>อนุมัติการลาสำเร็จ</div>
                <div style="text-align: center; margin-bottom: 10px;">
                    <asp:LinkButton ID="lbu1" runat="server" CssClass="ps-button" OnClick="lbu1_Click"><img src="Image/Small/back.png" class="icon_left"/>กลับหน้าหลัก</asp:LinkButton>
                    <asp:LinkButton ID="lbu2" runat="server" CssClass="ps-button" OnClick="lbu2_Click">อนุมัติการลาต่อ<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
                </div>
            </asp:View>
        </asp:MultiView>
        
        <div class="ps-separator"></div>









    </div>
</asp:Content>
