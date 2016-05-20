﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewLeaveForm.aspx.cs" Inherits="WEB_PERSONAL.ViewLeaveForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .c1 table {
            vertical-align: top;
            display: inline-block;
            margin-right: 20px;
        }

        #ContentPlaceHolder1_div_dr_cer img {
            width: 200px;
            height: auto;
        }

        .dr_cer {
            border: 1px solid #808080;
        }

            .dr_cer:hover {
                border: 1px solid #00a2e8;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="all">
    <div class="ps-header">
        <img src="Image/Small/table.png" />ข้อมูลการลา</div>

    <table class="ps-table" style="display: inline-block; vertical-align: top;">
        <tr>
            <td class="head" colspan="2">
                <img src="Image/Small/document.png" class="icon_left" />
                ข้อมูลการลา</td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/ID.png" class="icon_left" />
                รหัสการลา
            </td>
            <td class="col2">
                <asp:Label ID="lbLeaveID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/list.png" class="icon_left" />
                สถานะการลา </td>
            <td class="col2">
                <asp:Label ID="lbLeaveStatusID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/list.png" class="icon_left" />
                ประเภทการลา
            </td>
            <td class="col2">
                <asp:Label ID="lbLeaveType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่ข้อมูล
            </td>
            <td class="col2">
                <asp:Label ID="lbReqDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/person2.png" class="icon_left" />
                ชื่อผู้ลา
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
            <td class="col1">&nbsp;ระดับ
            </td>
            <td class="col2">
                <asp:Label ID="lbPSAPos" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">&nbsp;สังกัด
            </td>
            <td class="col2">
                <asp:Label ID="lbPSDept" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trPSBirthDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                เกิดวันที่
            </td>
            <td class="col2">
                <asp:Label ID="lbPSBirthDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trPSWorkInDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                เข้ารับราชการวันที่
            </td>
            <td class="col2">
                <asp:Label ID="lbPSWorkInDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trRestSave" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันลาพักผ่อนสะสม</td>
            <td class="col2">
                <asp:Label ID="lbRestSave" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trRestLeft" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                มีสิทธิลาประจำปีนี้อีก</td>
            <td class="col2">
                <asp:Label ID="lbRestLeft" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trRestTotal" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                รวม</td>
            <td class="col2">
                <asp:Label ID="lbRestTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trWifeName" runat="server">
            <td class="col1">
                <img src="Image/Small/person2.png" class="icon_left" />
                ชื่อภริยา</td>
            <td class="col2">
                <asp:Label ID="lbWifeName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trGBDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                คลอดบุตรวันที่</td>
            <td class="col2">
                <asp:Label ID="lbGBDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trOrdained" runat="server">
            <td class="col1">
                <img src="Image/Small/question.png" class="icon_left" />
                การอุปสมบท</td>
            <td class="col2">
                <asp:Label ID="lbOrdained" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trTempleName" runat="server">
            <td class="col1">
                <img src="Image/Small/bell.png" class="icon_left" />
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
                วันที่ลาล่าสุด
            </td>
            <td class="col2">
                <asp:Label ID="lbLastFTTDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trFTTDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่ลา
            </td>
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
                เหตุผล
            </td>
            <td class="col2">
                <asp:Label ID="lbReason" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCancelReason" runat="server">
            <td class="col1">
                <img src="Image/Small/comment.png" class="icon_left" />
                เหตุผลที่ยกเลิก </td>
            <td class="col2">
                <asp:Label ID="lbCancelReason" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trContact" runat="server">
            <td class="col1">
                <img src="Image/Small/a.png" class="icon_left" />
                ติดต่อได้ที่
            </td>
            <td class="col2">
                <asp:Label ID="lbContact" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trPhone" runat="server">
            <td class="col1">
                <img src="Image/Small/phone.png" class="icon_left" />
                เบอร์โทรศัพท์
            </td>
            <td class="col2">
                <asp:Label ID="lbPhone" runat="server"></asp:Label>
            </td>
        </tr>

    </table>

    <div id="div_dr_cer" class="dr_cer" runat="server" style="display: inline-block; vertical-align: top;"></div>

    <div class="ps-separator"></div>

    <table class="ps-table" style="display: inline-block; vertical-align: top;">
        <tr>
            <td class="head" colspan="2">
                <img src="Image/Small/person2.png" class="icon_left" />
                ผู้บังคับบัญชาระดับต่ำ</td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/person2.png" class="icon_left" />
                ชื่อ
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
                <img src="Image/Small/comment.png" class="icon_left" />
                ความเห็น
            </td>
            <td class="col2">
                <asp:Label ID="lbCLCom" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่
            </td>
            <td class="col2">
                <asp:Label ID="lbCLDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCLCancelComment" runat="server">
            <td class="col1">
                <img src="Image/Small/comment.png" class="icon_left" />
                ความเห็นการยกเลิก
            </td>
            <td class="col2">
                <asp:Label ID="lbCL_C_Com" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCLCancelDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่การยกเลิก
            </td>
            <td class="col2">
                <asp:Label ID="lbCL_C_Date" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="ps-table" style="display: inline-block; vertical-align: top;">
        <tr>
            <td class="head" colspan="2">
                <img src="Image/Small/person2.png" class="icon_left" />
                ผู้บังคับบัญชาระดับสูง</td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/person2.png" class="icon_left" />
                ชื่อผู้อนุมัติ
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
                <img src="Image/Small/comment.png" class="icon_left" />
                ความเห็น
            </td>
            <td class="col2">
                <asp:Label ID="lbCHCom" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่
            </td>
            <td class="col2">
                <asp:Label ID="lbCHDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col1">
                <img src="Image/Small/correct.png" class="icon_left" />
                การอนุมัติ
            </td>
            <td class="col2">
                <asp:Label ID="lbCHAllow" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCHCancelComment" runat="server">
            <td class="col1">
                <img src="Image/Small/comment.png" class="icon_left" />
                ความเห็นการยกเลิก
            </td>
            <td class="col2">
                <asp:Label ID="lbCH_C_Com" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCHCancelDate" runat="server">
            <td class="col1">
                <img src="Image/Small/calendar.png" class="icon_left" />
                วันที่การยกเลิก
            </td>
            <td class="col2">
                <asp:Label ID="lbCH_C_Date" runat="server"></asp:Label>
            </td>
        </tr>
        <tr id="trCHCancelAllow" runat="server">
            <td class="col1">
                <img src="Image/Small/correct.png" class="icon_left" />
                การอนุมัติการยกเลิก
            </td>
            <td class="col2">
                <asp:Label ID="lbCH_C_Allow" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div class="ps-separator"></div>

    <div>
        <asp:LinkButton ID="lbuPrint" runat="server" CssClass="ps-button" OnClick="lbuPrint_Click"><img src="Image/Small/printer.png" class="icon_left" />พิมพ์</asp:LinkButton>
    </div>
        </div>
</asp:Content>
