<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="WEB_PERSONAL.DataManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }
        .panin {
            border: 1px solid black;
            margin: 20px;
            background-color: rgba(255,255,255,0.6);
            border-radius: 5px;
        }
        body {
            background-color: white;
        }
        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 150px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
        .center1 {
            display: inline-block;
        }
        legend {
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
            text-align: center;
            font-size: medium;
            color: royalblue;
        }
        fieldset {
            border: 3px solid #99e6ff;
            color: black;
        }

        .col1 {
            padding: 3px 5px;
            text-align: right;
            background-color: #f8f8f8;
            color: #404040;
        }

        .col2 {
            padding: 3px 5px;
            background-color: #ffffff;
            border-bottom: 1px solid #f0f0f0;
        }
        .ps-button {
            display: inline-block;
            font-family: RB-Regular, Tahoma;
            font-weight: normal;
            font-size: 12px;
            text-decoration: none;
            padding: 3px 15px;
            border-radius: 4px;
            cursor: pointer;
            transition: color ease 0.25s, background-color ease 0.25s, border-color ease 0.25s;
            text-align: left;
            color: #000000;
            background-color: #ffffff;
            border: 1px solid #c0c0c0;
            border-top: 1px solid #d0d0d0;
            border-bottom: 1px solid #b0b0b0;
            padding: 3px 15px;
            border-collapse: collapse;
        }
        .auto-style1 {
            padding: 3px 5px;
            text-align: right;
            background-color: #f8f8f8;
            color: #404040;
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            padding: 3px 5px;
            text-align: right;
            background-color: #f8f8f8;
            color: #404040;
            width: 10px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato">
        <div> 
                <div style="text-align: center">
                    <asp:Button ID="btnView1Personnel" Text="จัดการข้อมูลบุคลากร" runat="server" CssClass="ps-button" OnClick="btnView1Personnel_Click"></asp:Button>
                    <asp:Button ID="btnView2Insignia" Text="จัดการข้อมูลเครื่องราชอิสริยาภรณ์" runat="server" CssClass="ps-button" OnClick="btnView2Insignia_Click" />
                </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" Width="100%">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <fieldset>
                        <legend>จัดการข้อมูลบุคลากร</legend>
                        <div>
                            <table class="center1">
                                <tr>
                                    <td class="col1">คำนำหน้า :</td>
                                    <td class="col2"><a href="TitleName-ADMIN.aspx" class="ps-button" style="width: 120px">คำนำหน้า</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">วิทยาเขต :</td>
                                    <td><a href="Campus-ADMIN.aspx" class="ps-button" style="width: 160px">วิทยาเขต</a></td>

                                </tr>
                                <tr>
                                    <td class="col1">เพศ :</td>
                                    <td class="col2"><a href="Gender-ADMIN.aspx" class="ps-button" style="width: 120px">เพศ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">สำนัก / สถาบัน / คณะ :</td>
                                    <td><a href="Faculty-ADMIN.aspx" class="ps-button" style="width: 160px">สำนัก / สถาบัน / คณะ</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">เชื้อชาติ / สัญชาติ :</td>
                                    <td><a href="National-ADMIN.aspx" class="ps-button" style="width: 120px">เชื้อชาติ / สัญชาติ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">กอง / สำนักงานเลขา / ภาควิชา :</td>
                                    <td><a href="Division-ADMIN.aspx" class="ps-button" style="width: 160px">กอง / สำนักงานเลขา / ภาควิชา</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">กรุ๊ปเลือด :</td>
                                    <td><a href="Blood-ADMIN.aspx" class="ps-button" style="width: 120px">กรุ๊ปเลือด</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">งาน / ฝ่าย :</td>
                                    <td><a href="WorkDivision-ADMIN.aspx" class="ps-button" style="width: 160px">งาน / ฝ่าย</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ศาสนา :</td>
                                    <td><a href="Religion-ADMIN.aspx" class="ps-button" style="width: 120px">ศาสนา</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ประเภทบุคลากร :</td>
                                    <td><a href="StaffType-ADMIN.aspx" class="ps-button" style="width: 160px">ประเภทบุคลากร</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">สถานภาพ :</td>
                                    <td><a href="StatusPerson-ADMIN.aspx" class="ps-button" style="width: 120px">สถานภาพ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ประเภทเงินจ้าง :</td>
                                    <td><a href="Budget-ADMIN.aspx" class="ps-button" style="width: 160px">ประเภทเงินจ้าง</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">จังหวัด :</td>
                                    <td><a href="Province-ADMIN.aspx" class="ps-button" style="width: 120px">จังหวัด</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่ง :</td>
                                    <td><a href="Position-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่ง</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">อำเภอ :</td>
                                    <td><a href="Amphur-ADMIN.aspx" class="ps-button" style="width: 120px">อำเภอ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่งบริหาร :</td>
                                    <td><a href="AdminPosition-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งบริหาร</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำบล :</td>
                                    <td><a href="District-ADMIN.aspx" class="ps-button" style="width: 120px">ตำบล</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่งในสายงาน :</td>
                                    <td><a href="PositionWork-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งในสายงาน</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเทศ :</td>
                                    <td><a href="GradCountry-ADMIN.aspx" class="ps-button" style="width: 120px">ประเทศ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่งทางวิชาการ :</td>
                                    <td><a href="AcademicPosition-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งทางวิชาการ</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับการศึกษา :</td>
                                    <td><a href="GradLev-ADMIN.aspx" class="ps-button" style="width: 120px">ระดับการศึกษา</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน :</td>
                                    <td><a href="TeachISCED-ADMIN.aspx" class="ps-button" style="width: 160px">กลุ่มสาขาวิชาที่สอน</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">เดือน :</td>
                                    <td><a href="Month-ADMIN.aspx" class="ps-button" style="width: 120px">เดือน</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่งประเภท :</td>
                                    <td><a href="Staff-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งประเภท</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ปี :</td>
                                    <td><a href="Year-ADMIN.aspx" class="ps-button" style="width: 120px">ปี</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ยศ :</td>
                                    <td><a href="Rank-ADMIN.aspx" class="ps-button" style="width: 160px">ยศ</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">สถานะการทำงาน :</td>
                                    <td><a href="StatusWork-ADMIN.aspx" class="ps-button" style="width: 120px">สถานะการทำงาน</a></td>

                                </tr>

                            </table>
                        </div>
                    </fieldset>
                </asp:View>

                <asp:View ID="View2" runat="server">
                    <fieldset>
                        <legend>จัดการข้อมูลเครื่องราชอิสริยาภรณ์</legend>
                        <div>
                            <table class="center1">
                                <tr>
                                    <td class="auto-style1">กลุ่มเครื่องราชฯ :</td>
                                    <td class="auto-style2"><a href="Claninsignia-ADMIN.aspx" class="ps-button" style="width: 160px">กลุ่มเครื่องราชฯ</a></td>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style1">เครื่องราชฯ :</td>
                                    <td class="auto-style2"><a href="GradeInsignia-ADMIN.aspx" class="ps-button" style="width: 120px">เครื่่องราชฯ</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งประเภท :</td>
                                    <td><a href="PosiGoverAcad-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งประเภท</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ขั้นเงินเดือนตำแหน่ง :</td>
                                    <td><a href="PosiGoverSalary-ADMIN.aspx" class="ps-button" style="width: 120px">ขั้นเงินเดือนตำแหน่ง</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับตำแหน่งประเภท :</td>
                                    <td><a href="PosiInsigGover-ADMIN.aspx" class="ps-button" style="width: 160px">ระดับตำแหน่งประเภท</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                    <td class="col1">ตำแหน่งระดับ :</td>
                                    <td><a href="PosiInsigDegree-ADMIN.aspx" class="ps-button" style="width: 120px">ตำแหน่งระดับ</a></td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งกลุ่มพนักงานราชการ :</td>
                                    <td><a href="PosiInsigEMP-ADMIN.aspx" class="ps-button" style="width: 160px">ตำแหน่งกลุ่มพนักงานราชการ</a></td>
                                    <td class="col1" style="width: 10px"></td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </asp:View>
            </asp:MultiView>
        </div>
    </asp:Panel>
</asp:Content>
