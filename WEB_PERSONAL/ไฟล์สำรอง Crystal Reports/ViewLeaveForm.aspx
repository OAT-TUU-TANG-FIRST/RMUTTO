<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewLeaveForm.aspx.cs" Inherits="WEB_PERSONAL.ViewLeaveForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            padding-right: 10px;
            text-align: right;
            color: #808080;
            height: 18px;
        }

        .auto-style2 {
            color: #000000;
            height: 18px;
        }

        .c1 {
            border-bottom: 1px solid #c0c0c0;
            margin: 20px 0px;
            padding-bottom: 20px;
        }

            .c1 table {
                vertical-align: top;
                display: inline-block;
                margin-right: 20px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="c1">
                <table>
                    <tr>
                        <td class="col1">รหัสการลา
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbLeaveID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่ลงข้อมูล
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbReqDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อผู้ลา
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbPosition" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ระดับ
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbRank" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สังกัด
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </div>


            <div class="c1">
                <table>
                    <tr>
                        <td class="col1">ประเภทการลา
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbLeaveType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">จากวันที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbFromDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ถึงวันที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbToDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รวม
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbTotalDay" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เหตุผล
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ติดต่อได้ที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbContact" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เบอร์โทรศัพท์
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="col1">วันที่ลาล่าสุด
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbLastFromDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ถึงวันที่ลาล่าสุด
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbLastToDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รวม
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbLastTotalDay" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="c1">
                <table>
                    <tr>
                        <td class="col1">ชื่อผู้บังคับบัญชา
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdLowName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdLowPosition" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ความเห็น
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdLowComment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdLowDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="col1">ชื่อผู้อนุมัติ
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdHighName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdHighPosition" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ความเห็น
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdHighComment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdHighDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">การอนุมัติ
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbCmdHighAllow" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="col1">ชื่อผู้ตรวจสอบ
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbStaffName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbStaffPosition" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่
                        </td>
                        <td class="col2">
                            <asp:Label ID="lbStaffDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
    </asp:MultiView>
    <div>
        <asp:LinkButton ID="lbuPrint" runat="server" CssClass="button button_default"><img src="Image/Small/printer.png" class="icon_left" />พิมพ์</asp:LinkButton>
    </div>
</asp:Content>
