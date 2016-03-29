<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_PERSONAL.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="CSS/Default.css" rel="stylesheet" />
    <script>
        (function ($) {
            $(window).load(function () {
                $(".div_sec_in").mCustomScrollbar({
                    axis: "x",
                    theme: "white-thin",
                    //theme: "minimal-dark",
                    autoExpandScrollbar: true,
                    advanced: { autoExpandHorizontalScroll: true }
                });
            });
        })(jQuery);
    </script>

    

    <script>
        /*$(".div_sec_in2").ready(function () {
            alert('dsd');
            var container_width = SINGLE_IMAGE_WIDTH * $(".div_sec_in2 img").length;
            
            alert(container_width);
            $(".div_sec_in2").css("width", container_width);
        });*/

    </script>

    <div class="mp">

            <!--div style="height: 50px;"></!--div-->

            <!--div class="div_sec" id="sec1">
                <div class="div_sec_in">
                    <div class="div_sec_in2">
                        <img src="Image/i1.jpg" />
                        <img src="Image/i2.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                        <img src="Image/i3.jpg" />
                    </div>

                </div>
            </!--div-->

        <div class="master_light_page_header">
                    <asp:Label ID="Label2" runat="server" Text="ระบบบุคลากร (Personnel System)"></asp:Label>
                </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="c1">
                <!--img src="Image/i1.jpg" />
                <img src="Image/i2.jpg" />
                <img src="Image/i3.jpg" /-->

                <div class="master_header_under_div_left">
                                <div class="master_header_under_main">
                                    <span class="master_header_under_header">เมนูหลัก</span>
                                    <a href="Default.aspx">หน้าหลัก</a>
                                    <a href="About.aspx">เกี่ยวกับ</a>
                                </div>
                                <div class="master_header_under_person">
                                    <span class="master_header_under_header">บุคลากร</span>
                                    <a href="Person-GENERAL.aspx">เพิ่มบุคลากร</a>
                                    <a href="Person-ADMIN.aspx">แก้ไขบุคลากร</a>
                                    <a href="ListPerson-ADMIN.aspx">รายชื่อบุคลากร</a>
                                    <a href="SEMINAR-GENERAL.aspx">การเพิ่มพัฒนาบุคลากร</a>
                                    <a href="SEMINAR-ADMIN.aspx">การแก้ไขพัฒนาบุคลากร</a>
                                    <a href="SearchForLinkPrint.aspx">ออกรายงานบุคลากร</a>
                                    <a href="SearchForLinkPrint.aspx">ออกรายงานพัฒนาบุคลากร</a>
                                </div>
                                <div class="master_header_under_salary">
                                    <span class="master_header_under_header">การขึ้นเงินเดือน</span>
                                    <a href="Salary.aspx">DPIS</a>
                                    <a href="SalarybyID.aspx">การขึ้นเงินเดือนรายบุคคล</a>
                                </div>
                                <div class="master_header_under_leave">
                                    <span class="master_header_under_header">การลา | มาสาย | ศึกษาต่อ</span>
                                    <a href="Leave.aspx">การลา</a>
                                    <a href="Late.aspx">การเข้างาน (มาสาย)</a>
                                    <a href="Study-IN.aspx">ศึกษาต่อ</a>
                                    <a href="Leave-Report1.aspx">ออกรายงานการลา</a>
                                    <a href="Study-Report1.aspx">ออกรายงานการลาศึกษาต่อ</a>
                                </div>

                                  <div class="master_header_under_insig">
                                    <span class="master_header_under_header">เครื่องราชอิสริยาภรณ์</span>
                                    <a href="INS_Request_admin.aspx">ค้นหาผู้มีสิทธิ์รับครื่องราชอิสริยาภรณ์ (แอดมิน)</a>
                                    <a href="INS_Request.aspx">บันทึกรายชื่อผู้ขอพระราชทานเครื่องราชอิสริยาภรณ์</a>
                                    <a href="INS_borrow.aspx">แบบคำขอยืมเครื่องราชอิสริยาภรณ์</a>
                                    <a href="INS_ReturnandPay.aspx">หลักฐานการส่งคืน/ชดใช้ราคาเครื่องราชอิสริยาภรณ์</a>
                                </div>

                    <div class="master_header_under_admin">
                                    <span class="master_header_under_header">สำหรับผู้ดูแลระบบ</span>
                                    <a href="DataManager.aspx">จัดการข้อมูล Drop-down List</a>
      
                                </div>

                            </div>
                
            </asp:Panel>

            <div class="para_group">
                
                

                <div class="dpl_7c" style="height: 1px; margin: 20px 100px;">

                </div>
                    
            </div>


            <div style="height: 50px"></div>

    </div>
</asp:Content>
