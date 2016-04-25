<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveManager.aspx.cs" Inherits="WEB_PERSONAL.LeaveManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbVX1FromDate, #ContentPlaceHolder1_tbVX1ToDate").datepicker($.datepicker.regional["th"]);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/wrench.png" />จัดการข้อมูลการลา</div>
        <div>
            <asp:LinkButton ID="lbuLF1Select" runat="server" OnClick="lbuLF1Select_Click" CssClass="ps-vs-sel">การลาป่วย</asp:LinkButton>
            <asp:LinkButton ID="lbuLF2Select" runat="server" OnClick="lbuLF2Select_Click" CssClass="ps-vs">การลากิจ</asp:LinkButton>
            <asp:LinkButton ID="lbuLF3Select" runat="server" OnClick="lbuLF3Select_Click" CssClass="ps-vs">การลาพักผ่อน</asp:LinkButton>
        </div>
        <div style="border-top: 1px solid #00a2e8; padding-top: 10px;">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table class="ps-table">
                        <tr>
                            <td colspan="2" class="head">เพิ่มข้อมูลการลา</td>
                        </tr>
                        <tr>
                            <td class="col1">
                                รหัสผู้ลา
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1CitizenID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                จากวันที่
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1FromDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                ถึงวันที่
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1ToDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                เหตุผล
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1Reason" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                ติดต่อได้ที่
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1Contact" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                เบอร์โทรศัพท์
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1Phone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                รหัสผู้บังคับบัญชาระดับต่ำ
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1CLID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                รหัสผู้บังคับบัญชาระดับต่ำ
                            </td>
                            <td class="col2">
                                <asp:TextBox ID="tbVX1CHID" runat="server" placeHolder="รหัสประชาชน" CssClass="ps-textbox"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="ps-separator"></div>
                    <asp:LinkButton ID="lbuVX1AddLeave" runat="server" CssClass="ps-button"><img src="Image/Small/add.png" class="icon_left"/>เพิ่มข้อมูลการลา</asp:LinkButton>
                    <div class="ps-separator"></div>
                    <div class="ps-gridview-manager-top">
                        <asp:LinkButton ID="lbuVX1DeleteSelected" runat="server" CssClass="ps-button"><img src="Image/Small/bin.png" class="icon_left"/>ลบที่เลือก</asp:LinkButton>
                    </div>
                    <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="gv2" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:GridView ID="gv3" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
             </asp:MultiView>
        </div>
        
    </div>
</asp:Content>
