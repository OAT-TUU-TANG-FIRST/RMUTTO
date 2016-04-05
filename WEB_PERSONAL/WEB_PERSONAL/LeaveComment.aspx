<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveComment.aspx.cs" Inherits="WEB_PERSONAL.LeaveComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="default_header"><img src="Image/Small/pencil_y.png" />ลงความเห็นการลา</div>

        

        <div id="error_area" runat="server"></div>

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <div id="i1" runat="server"></div> 
        <div id="i2" runat="server">
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
                    <td class="col1">&nbsp;</td>
                    <td class="col2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="col1">ความเห็น</td>
                    <td class="col2">
                        <asp:TextBox ID="tbF1Comment" runat="server" Height="50px" Width="300px" TextMode="MultiLine" CssClass="textbox textbox_default"></asp:TextBox>
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
                        <asp:LinkButton ID="lbuF1Back" runat="server" CssClass="button button_default" OnClick="lbuF1Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuF1Add" runat="server" CssClass="button button_default" OnClick="lbuF1Add_Click">ยืนยันการลงความเห็น<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="i3" runat="server">
            <asp:LinkButton ID="lbu1" runat="server" CssClass="button button_default" OnClick="lbu1_Click"><img src="Image/Small/back.png" class="icon_left"/>กลับหน้าหลัก</asp:LinkButton>
            <asp:LinkButton ID="lbu2" runat="server" CssClass="button button_default" OnClick="lbu2_Click">ลงความเห็นต่อ<img src="Image/Small/forward.png" class="icon_right"/></asp:LinkButton>
        </div>
    </div>
</asp:Content>
