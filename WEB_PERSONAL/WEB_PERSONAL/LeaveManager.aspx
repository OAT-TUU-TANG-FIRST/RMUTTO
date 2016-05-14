<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveManager.aspx.cs" Inherits="WEB_PERSONAL.LeaveManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbVX1FromDate, #ContentPlaceHolder1_tbVX1ToDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbPuyAddCLDate, #ContentPlaceHolder1_tbPuyAddCHDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbPuyEditFromDate, #ContentPlaceHolder1_tbPuyEditToDate").datepicker($.datepicker.regional["th"]);
            $("#ContentPlaceHolder1_tbPuyEditCLDate, #ContentPlaceHolder1_tbPuyEditCHDate").datepicker($.datepicker.regional["th"]);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/wrench.png" />จัดการข้อมูลการลา
        </div>
        <div class="ps-vs-main">
            <asp:LinkButton ID="lbuLF1Select" runat="server" OnClick="lbuLF1Select_Click" CssClass="ps-vs-sel">การลาป่วย</asp:LinkButton>
            <asp:LinkButton ID="lbuLF2Select" runat="server" OnClick="lbuLF2Select_Click" CssClass="ps-vs">การลากิจ</asp:LinkButton>
            <asp:LinkButton ID="lbuLF3Select" runat="server" OnClick="lbuLF3Select_Click" CssClass="ps-vs">การลาพักผ่อน</asp:LinkButton>
            <asp:LinkButton ID="lbuLF4Select" runat="server" OnClick="lbuLF4Select_Click" CssClass="ps-vs">การลาคลอดบุตร</asp:LinkButton>
            <asp:LinkButton ID="lbuLF5Select" runat="server" OnClick="lbuLF5Select_Click" CssClass="ps-vs">การไปช่วยเหลือภริยาที่คลอดบุตร</asp:LinkButton>
            <asp:LinkButton ID="lbuLF6Select" runat="server" OnClick="lbuLF6Select_Click" CssClass="ps-vs">ลาไปอุมสมบท</asp:LinkButton>
            <asp:LinkButton ID="lbuLF7Select" runat="server" OnClick="lbuLF7Select_Click" CssClass="ps-vs">ลาไปประกอบพิธีฮัจย์</asp:LinkButton>
        </div>
        <asp:MultiView ID="MV1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:MultiView ID="MV1_1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View8" runat="server">
                        <table class="ps-table">
                            <tr>
                                <td colspan="2" class="head"><img src="Image/Small/document-create.png" class="icon_left"/>เพิ่มข้อมูลการลาป่วย</td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/person2.png" class="icon_left"/>รหัสผู้ลา
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1CitizenID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>จากวันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>ถึงวันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>เหตุผล
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1Reason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/a.png" class="icon_left"/>ติดต่อได้ที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/phone.png" class="icon_left"/>เบอร์โทรศัพท์
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/clip.png" class="icon_left"/>เอกสารแนบ
                                </td>
                                <td class="col2">
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/person2.png" class="icon_left"/>รหัสผู้บังคับบัญชาระดับต่ำ
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1CLID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/comment.png" class="icon_left"/>ความเห็น
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyAddCLCom" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>วันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyAddCLDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/person2.png" class="icon_left"/>รหัสผู้บังคับบัญชาระดับสูง
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbVX1CHID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/comment.png" class="icon_left"/>ความเห็น
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyAddCHCom" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/calendar.png" class="icon_left"/>วันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyAddCHDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/correct.png" class="icon_left"/>การอนุมัติ
                                </td>
                                <td class="col2">
                                    <asp:RadioButton ID="rbPuyAddCHAllowOK" runat="server" Text="อนุญาต" GroupName="rbPuyAddCHAllowGroup" Checked="true"/>
                                    <asp:RadioButton ID="rbPuyAddCHAllowKO" runat="server" Text="ไม่อนุญาต" GroupName="rbPuyAddCHAllowGroup"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="ps-table-bottom" colspan="2">
                                    <asp:LinkButton ID="lbuVX1AddLeave" runat="server" CssClass="ps-button"><img src="Image/Small/document-create.png" class="icon_left"/>เพิ่มข้อมูล</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <div class="ps-separator"></div>
                        <div class="ps-gridview-manager-top">
                            <asp:LinkButton ID="lbuVX1DeleteSelected" runat="server" CssClass="ps-button"><img src="Image/Small/bin.png" class="icon_left"/>ลบที่เลือก</asp:LinkButton>
                        </div>
                        <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                    </asp:View>
                    <asp:View ID="View9" runat="server">
                        <table class="ps-table">
                            <tr>
                                <td colspan="2" class="head"><img src="Image/Small/document-edit.png" class="icon_left" />แก้ไขข้อมูลการลาป่วย</td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสการลา
                                </td>
                                <td class="col2">
                                    <asp:Label ID="lbPuyEditLeaveID" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสผู้ลา
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCitizenID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จากวันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditFromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถึงวันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เหตุผล
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditReason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ติดต่อได้ที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditContact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เบอร์โทรศัพท์
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditPhone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เอกสารแนบ
                                </td>
                                <td class="col2">
                                    <div id="divPuyEditDrCer" runat="server"></div>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสผู้บังคับบัญชาระดับต่ำ
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCL" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ความเห็น
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCLCom" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCLDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสผู้บังคับบัญชาระดับสูง
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCH" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ความเห็น
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCHCom" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่
                                </td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPuyEditCHDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1"><img src="Image/Small/correct.png" class="icon_left"/>การอนุมัติ
                                </td>
                                <td class="col2">
                                    <asp:RadioButton ID="rbPuyEditCHAllowOK" runat="server" Text="อนุญาต" GroupName="rbPuyEditCHAllowGroup"/>
                                    <asp:RadioButton ID="rbPuyEditCHAllowKO" runat="server" Text="ไม่อนุญาต" GroupName="rbPuyEditCHAllowGroup"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="ps-table-bottom" colspan="2">
                                    <asp:LinkButton ID="lbuPuyEditBack" runat="server" CssClass="ps-button" OnClick="lbuPuyEditBack_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                                    <asp:LinkButton ID="lbuPuyEditFinish" runat="server" CssClass="ps-button"><img src="Image/Small/document-edit.png" class="icon_left"/>แก้ไขข้อมูล</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>

            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:GridView ID="gv2" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:GridView ID="gv3" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <asp:GridView ID="GridView2" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <asp:GridView ID="GridView3" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
            <asp:View ID="View7" runat="server">
                <asp:GridView ID="GridView4" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
            </asp:View>
        </asp:MultiView>
    </div>

</asp:Content>
