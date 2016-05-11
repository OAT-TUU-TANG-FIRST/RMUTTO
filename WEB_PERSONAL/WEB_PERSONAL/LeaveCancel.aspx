<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveCancel.aspx.cs" Inherits="WEB_PERSONAL.LeaveCancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/document-delete.png" />ยกเลิกการลา</div>

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <table class="ps-table">
                    <tr>
                        <td class="head" colspan="2">ข้อมูลการยกเลิกการลา</td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col2">วันที่ขอลา</td>
                    </tr>
                    <tr>
                        <td class="col1">จากวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1S1FromDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ถึงวันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1S1ToDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="col1">เหตุผล</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1S1Reason" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ติดต่อได้ที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1S1Contact" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1S1Phone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col2">
                            <asp:LinkButton ID="lbuF1S1Check" runat="server" CssClass="ps-button" OnClick="lbuF1S1Check_Click">ตรวจสอบ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                        <td class="col1">ประเภทการลา</td>
                        <td class="col2">
                            <asp:Label ID="lbF1S2LeaveTypeName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style98">ชื่อ</td>
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
                        <td class="col1">&nbsp;</td>
                        <td class="col2">&nbsp;</td>
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
                        <td class="col1">&nbsp;</td>
                        <td class="col2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="col1" style="vertical-align: top;">เหตุผล</td>
                        <td class="col2">
                            <asp:Label ID="lbF1S2Reason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1" style="vertical-align: top;">ติดต่อได้ที่</td>
                        <td class="col2">
                            <asp:Label ID="lbF1S2Contact" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1" style="vertical-align: top;">เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:Label ID="lbF1S2Phone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col_res">
                            <asp:TextBox ID="TextBox56" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">&nbsp;</td>
                        <td class="col_res">
                            <asp:LinkButton ID="lbuF1S2Back" runat="server" CssClass="ps-button" OnClick="lbuF1S2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                            <asp:LinkButton ID="lbuF1S2Add" runat="server" CssClass="ps-button" OnClick="lbuF1S2Add_Click"><img src="Image/Small/add.png" class="icon_left"/>ยืนคำขอลา</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div>
                    <asp:LinkButton ID="lbuBackMain" runat="server" CssClass="button button_default" OnClick="lbuBackMain_Click"><img class="icon_left" src="Image/Small/back.png" />กลับหน้าหลัก</asp:LinkButton>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
