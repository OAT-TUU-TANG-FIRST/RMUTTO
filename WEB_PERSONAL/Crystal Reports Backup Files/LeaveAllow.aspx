<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveAllow.aspx.cs" Inherits="WEB_PERSONAL.LeaveAllow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/correct.png" />อนุมัติการลา</div>
        <div id="error_area" runat="server"></div>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview"></asp:GridView>
                <div class="ps-separator"></div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                    <td class="col1">รหัสการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1LeaveID" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ผู้ลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1LeaverName" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่ง</td>
                    <td class="col2">
                        <asp:Label ID="lbF1PersonPosition" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ระดับ</td>
                    <td class="col2">
                        <asp:Label ID="lbF1PersonRank" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">สังกัด</td>
                    <td class="col2">
                        <asp:Label ID="lbF1PersonDepartment" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">วันที่ยื่นเรื่อง</td>
                    <td class="col2">
                        <asp:Label ID="lbF1ReqDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ประเภทการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1LeaveTypeName" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ลาครั้งล่าสุด</td>
                    <td class="col2">
                        <asp:Label ID="lbF1LastFTTDate" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="col1">ลาครั้งนี้</td>
                    <td class="col2">
                        <asp:Label ID="lbF1FTTDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">สถิติการลา</td>
                    <td class="col2">
                        <asp:Label ID="lbF1Statistic" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">เหตุผล</td>
                    <td class="col2">
                        <asp:Label ID="lbF1Reason" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ติดต่อได้ที่</td>
                    <td class="col2">
                        <asp:Label ID="lbF1Contact" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">เบอร์โทรศัพท์</td>
                    <td class="col2">
                        <asp:Label ID="lbF1Phone" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                    <tr>
                    <td class="col1">เอกสารแนบ</td>
                    <td class="col2">
                        <div id="divDrCer" runat="server"></div></td>
                    <td>&nbsp;</td>
                </tr>
                    <tr>
                    <td class="col1">ความเห็นจากผู้บังคับบัญชาระดับต่ำ</td>
                    <td class="col2">
                        <asp:Label ID="lbF1CLComment" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                    <tr>
                    <td class="col1">วันที่ลงความเห็น</td>
                    <td class="col2">
                        <asp:Label ID="lbF1CLDate" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                    <tr>
                        <td class="col1">ความเห็น</td>
                        <td class="col2">
                            <asp:TextBox ID="tbF1Comment" runat="server" Height="50px" Width="300px" TextMode="MultiLine" CssClass="ps-textbox"></asp:TextBox>
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
                </table>
                <div class="ps-separator"></div>
                <asp:LinkButton ID="lbuBack" runat="server" CssClass="ps-button" OnClick="lbuBack_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                            <asp:LinkButton ID="lbuAddComment" runat="server" CssClass="ps-button" OnClick="lbuAddComment_Click">ยืนยันการอนุมัติ<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:LinkButton ID="lbu1" runat="server" CssClass="ps-button" OnClick="lbu1_Click"><img src="Image/Small/back.png" class="icon_left"/>กลับหน้าหลัก</asp:LinkButton>
                <asp:LinkButton ID="lbu2" runat="server" CssClass="ps-button" OnClick="lbu2_Click">อนุมัติการลาต่อ<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
            </asp:View>
        </asp:MultiView>











    </div>
</asp:Content>
