<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveAllow.aspx.cs" Inherits="WEB_PERSONAL.LeaveAllow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header"><img src="Image/Small/correct.png" />อนุมัติการลา</div>
        <div id="error_area" runat="server"></div>

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <div id="i1" runat="server"></div> 
        <div id="i2" runat="server">
            <table>
                <tr>
                    <td class="col1">รหัสการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveID" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ผู้ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbLeaverName" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbPosition" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">วันที่ยื่นเรื่อง</td>
                    <td class="col2">
                        <asp:Label ID="lbReqDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbLeaveTypeName" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">จากวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbFromDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ถึงวันที่</td>
                    <td class="col2">
                        <asp:Label ID="lbToDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">รวมวัน</td>
                    <td class="col2">
                        <asp:Label ID="lbTotalDay" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:Label ID="lbReason" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ความเห็น</td>
                    <td class="col2">
                        <asp:TextBox ID="tbComment" runat="server" Height="50px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="col1">การอนุมัติ</td>
                    <td class="col2">
                        <asp:RadioButton ID="rbAllow" runat="server" GroupName="allow" Text="อนุญาต" />
                        <asp:RadioButton ID="rbNotAllow" runat="server" GroupName="allow" Text="ไม่อนุญาต" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuBack" runat="server" CssClass="button button_default" OnClick="lbuBack_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuAddComment" runat="server" CssClass="button button_default" OnClick="lbuAddComment_Click">ยืนยันการอนุมัติ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="i3" runat="server">
            <asp:LinkButton ID="lbu1" runat="server" CssClass="hm_button_primary" OnClick="lbu1_Click">กลับหน้าหลัก</asp:LinkButton>
            <asp:LinkButton ID="lbu2" runat="server" CssClass="hm_button_primary" OnClick="lbu2_Click">อนุมัติการลาต่อ</asp:LinkButton>
        </div>





    </div>
</asp:Content>
