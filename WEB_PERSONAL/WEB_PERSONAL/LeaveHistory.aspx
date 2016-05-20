<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="WEB_PERSONAL.LeaveHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c2 {
        }

        .c1 {
            display: inline-block;
            text-decoration: none;
            padding: 3px 20px;
            background-color: #ffffff;
            color: #000000;
            border: 1px solid #c0c0c0;
        }

            .c1:hover {
                background-color: #f0f0f0;
            }

        .sec {
            background-color: #ffffff;
            margin-bottom: 1px;
        }

        .sec2 {
            padding: 20px;
            padding-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ps-header">
        <img src="Image/Small/clock-history.png" />ประวัติการลา
    </div>

    <div class="ps-vs-main">
        <asp:LinkButton ID="lbuVS1" runat="server" CssClass="ps-vs-sel" OnClick="lbuVS1_Click">รายการที่ลา</asp:LinkButton>
        <asp:LinkButton ID="lbuVS2" runat="server" CssClass="ps-vs" OnClick="lbuVS2_Click">รายการที่มีส่วนเกี่ยวข้อง</asp:LinkButton>
        <asp:LinkButton ID="lbuVS3" runat="server" CssClass="ps-vs" OnClick="lbuVS3_Click">สถิติการลา</asp:LinkButton>
    </div>

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="sec">
                <div class="ps-header-mini">
                    <img src="Image/Small/correct.png" />รายการที่เสร็จสิ้น
                </div>
                <div class="sec2">

                    <asp:GridView ID="gvFinish" runat="server" CssClass="ps-gridview"></asp:GridView>
                    <asp:Label ID="lbFinish" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                </div>
            </div>

            <div class="sec">
                <div class="ps-header-mini">
                    <img src="Image/Small/progress.png" />รายการที่อยู่ระหว่างการดำเนินการ
                </div>
                <div class="sec2">

                    <asp:GridView ID="gvProgressing" runat="server" CssClass="ps-gridview"></asp:GridView>
                    <asp:Label ID="lbProgressing" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                </div>
            </div>

            <div class="sec">

                <div class="ps-header-mini">
                    <img src="Image/Small/table.png" />ประวัติการลา
                </div>
                <div class="sec2">

                    <asp:GridView ID="gvHistory" runat="server" CssClass="ps-gridview"></asp:GridView>
                    <asp:Label ID="lbHistory" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                </div>
            </div>


            <div class="ps-separator"></div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="sec">
                <div class="ps-header-mini">
                    <img src="Image/Small/pencil_y.png" />ประวัติการลาที่เป็นผู้ลงความเห็น
                </div>
                <div class="sec2">

                    <asp:GridView ID="gvCL" runat="server" CssClass="ps-gridview"></asp:GridView>
                    <asp:Label ID="lbCL" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                </div>
            </div>
            <div class="sec">
                <div class="ps-header-mini">
                    <img src="Image/Small/correct.png" />ประวัติการลาที่เป็นผู้อนุมัติ
                </div>
                <div class="sec2">
                    <asp:GridView ID="gvCH" runat="server" CssClass="ps-gridview"></asp:GridView>
                    <asp:Label ID="lbCH" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
                </div>
            </div>
            <div class="ps-separator"></div>
        </asp:View>
        <asp:View ID="View3" runat="server">

            <p style="margin: 10px 0; color: #808080;">
                จำนวนวันที่ลา
            </p>

            <asp:Table ID="Table1" runat="server" CssClass="ps-gridview">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลาป่วย</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลากิจ</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลาคลอดบุตร</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลาไปช่วยเหลือภริยาที่คลอดบุตร</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="3">ลาพักผ่อน</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลาไปอุปสมบท</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">ลาไปประกอบพิธีฮัจย์</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ปี</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>สูงสุด</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วัน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รวมขอ</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
            <div class="ps-separator"></div>

        </asp:View>
    </asp:MultiView>


</asp:Content>
