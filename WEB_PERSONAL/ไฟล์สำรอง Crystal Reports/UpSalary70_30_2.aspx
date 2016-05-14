<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary70_30_2.aspx.cs" Inherits="WEB_PERSONAL.UpSalary70_30_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #right {
            text-align: right;
        }

        #cen {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div style="text-align: right;">
            (แบบที่ 2)
        </div>
        <div style="font-weight: bold; text-align: center; font-size: 16px; margin-bottom: 20px;">
            ข้อตกลงการประเมินพฤติกรรมการปฏิบัติราชการ (สมรรถนะ) ของข้าราชการพลเรือนในสถาบันอุดมศึกษา หรือพนักงานในสถาบันอุดมศึกษา มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก ผู้ดำรงตำแหน่งประเภทวิชาการ (ไม่บริหาร) เช่น อาจารย์ ผู้ช่วยศาสตราจารย์ รองศาสตราจารย์ ศาสตราจารย์ (องค์ประกอบที่ 2 พฤติกรรมการปฏิบัติราชการ 30%)
        </div>
        <div>
            <span style="color: #808080;">รอบการประเมิน</span>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <table>
            <tr>
                <td style="color: #808080;">ชื่อผู้รับการประเมิน</td>
                <td>
                    <asp:Label ID="lbA1" runat="server" Text="Label"></asp:Label></td>
                <td style="color: #808080;">ตำแหน่ง</td>
                <td>
                    <asp:Label ID="lbA2" runat="server" Text="Label"></asp:Label></td>
                <td style="color: #808080;">สังกัด</td>
                <td>
                    <asp:Label ID="lbA3" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="color: #808080;">ชื่อผู้รับการประเมิน</td>
                <td>
                    <asp:Label ID="lbB1" runat="server" Text="Label"></asp:Label></td>
                <td style="color: #808080;">ตำแหน่ง</td>
                <td>
                    <asp:Label ID="lbB2" runat="server" Text="Label"></asp:Label></td>
                <td style="color: #808080;">สังกัด</td>
                <td>
                    <asp:Label ID="lbB3" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <div>
            <table class="ps-sal-table">
                <tr>
                    <th>สมรรถนะหลักที่กำหนด</th>
                    <th>(1) ระดับสมรรถนะที่คาดหวัง</th>
                    <th>(2) จำนวนตัวบ่งชี้ที่ประเมิน</th>
                    <th>(3) จำนวนตัวบ่งชี้ที่ผ่านการประเมิน</th>
                    <th>(4) คะแนนที่ได้รับ 100 X (3) / (2)</th>
                    <th>(5) คะแนนที่ได้ 30X (4) / 100</th>
                </tr>
                <tr>
                    <td><b>1. การมุ่งผลสัมฤทธิ์</b></td>
                    <td><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>2. การบริการที่ดี</b></td>
                    <td><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>3. การสั่งสมความเชี่ยวชาญ ในงานอาชีพ</b></td>
                    <td><asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label20" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>4. จริยธรรม</b></td>
                    <td><asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label22" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label23" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label28" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label29" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>5. ความร่วมแรงร่วมใจ</b></td>
                    <td><asp:Label ID="Label30" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label31" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label32" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label33" runat="server" Text="Label"></asp:Label></td>
                    <td><asp:Label ID="Label34" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: right;"><b>(6) คะแนนที่ได้รับ = ผลรวม(4)/(5) =</b></td>
                    <td><asp:Label ID="Label35" runat="server" Text="Label"></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: right;"><b>(7) ค่าคะแนนที่ได้ = ผลรวม(5)/5) =</b></td>
                    <td><asp:Label ID="Label36" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: right;"><b>สรุป คะแนนสมรรถนะ (8) =</b></td>
                    <td><asp:Label ID="Label37" runat="server" Text="Label"></asp:Label></td>
                </tr>

            </table>

            <div class="ps-sal-signature-main">
                <div style="text-align: left; padding: 5px; font-weight: bold;">
                    2. ผู้ประเมินและผู้รับการประเมินได้ตกลงร่วมกันและเห็นพ้องกันแล้ว จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อจัดทำข้อตกลง) 
                </div>

                <div class="ps-sal-signature">
                    <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label><br />
                    <span style="color: #808080;">ผู้ประเมิน</span>
                    <div style="margin: 10px 0;"></div>
                    วันที่
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label><br />

                </div>

                <div class="ps-sal-signature">
                    <asp:Label ID="Label24" runat="server" Text="อัชจู นูจรา"></asp:Label><br />
                    <span style="color: #808080;">ผู้รับการประเมิน</span>
                    <div style="margin: 10px 0;"></div>
                    <asp:Label ID="Label25" runat="server" Text="29 เมษายน 2559"></asp:Label><br />

                </div>
            </div>

            <div>
                <div style="text-align: left; padding: 5px;  font-weight: bold;">
                    3. ความเห็นเพิ่มเติมของผู้ประเมิน (ระบุข้อมูลเมื่อสิ้นรอบการประเมิน) 
                </div>
                <table style="margin-left: 50px;">
                    <tr>
                        <td style="vertical-align: top;">1) จุดเด่น และ/หรือ สิ่งที่ควรปรับปรุงแก้ไข</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">2) ข้อเสนอแนะเกี่ยวกับวิธีส่งเสริมและพัฒนา</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ps-sal-signature-main">
                <div style="text-align: left; padding: 5px;  font-weight: bold;">
                    4. ผู้ประเมินและผู้รับการประเมินได้เห็นชอบผลการประเมินแล้ว จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อสิ้นรอบการประเมิน)
                </div>

                <div class="ps-sal-signature">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
                    <span style="color: #808080;">ผู้ประเมิน</span>
                    <div style="margin: 10px 0;"></div>
                    วันที่
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />

                </div>

                <div class="ps-sal-signature">
                    <asp:Label ID="Label4" runat="server" Text="อัชจู นูจรา"></asp:Label><br />
                    <span style="color: #808080;">ผู้รับการประเมิน</span>
                    <div style="margin: 10px 0;"></div>
                    <asp:Label ID="Label5" runat="server" Text="29 เมษายน 2559"></asp:Label><br />

                </div>
            </div>


            <div class="ps-sal-table-under">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="ps-button">ส่งเรื่อง<img src="Image/Small/correct.png" class="icon_right"/></asp:LinkButton>
            </div>

        </div>
    </div>
    
</asp:Content>
