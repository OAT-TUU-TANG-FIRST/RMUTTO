<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WEB_PERSONAL.Profile" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c1 {
            background-color: #202020;
            min-height: 200px;
            padding: 5px;
        }

            .c1 a {
                border: 1px solid transparent;
                display: inline-block;
                margin: 2px;
            }

                .c1 a:hover {
                    border: 1px solid #ffffff;
        
                }

            .c1 img {
                max-height: 190px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/person2.png" />ข้อมูลผู้ใช้งาน</div>

        <div class="ps-vs-main">
            <asp:LinkButton ID="lbuSec1" runat="server" CssClass="ps-vs-sel" OnClick="lbuSec1_Click">ข้อมูลพื้นฐาน</asp:LinkButton>
            <asp:LinkButton ID="lbuSec2" runat="server" CssClass="ps-vs" OnClick="lbuSec2_Click">ข้อมูลการงาน</asp:LinkButton>
            <asp:LinkButton ID="lbuSec3" runat="server" CssClass="ps-vs" OnClick="lbuSec3_Click">ที่อยู่</asp:LinkButton>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div style="background-color: #404040; color: #ffffff; padding: 5px 10px;">
                    รูปภาพ
            <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:LinkButton ID="lbuUploadPicture" runat="server" CssClass="ps-button" OnClick="lbuUploadPicture_Click"><img src="Image/Small/upload.png" class="icon_left"/>อัพโหลด</asp:LinkButton>
                </div>
                <div class="c1" id="profile_images" runat="server">
                </div>
                <table class="ps-table" style="display: inline-block; vertical-align: top;">
                    <tr>
                        <td class="head" colspan="2">ข้อมูลพื้นฐาน</td>
                    </tr>
                    <tr>
                        <td class="col1">รหัสประชาชน</td>
                        <td class="col2">
                            <asp:Label ID="lbCitizenID" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อจริง</td>
                        <td class="col2">
                            <asp:Label ID="lbFirstName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุล</td>
                        <td class="col2">
                            <asp:Label ID="lbLastName" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เพศ</td>
                        <td class="col2">
                            <asp:Label ID="lbGender" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันเกิด</td>
                        <td class="col2">
                            <asp:Label ID="lbBirthday" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เชื้อชาติ</td>
                        <td class="col2">
                            <asp:Label ID="lbRace" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สัญชาติ</td>
                        <td class="col2">
                            <asp:Label ID="lbNation" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กรุ๊ปเลือด</td>
                        <td class="col2">
                            <asp:Label ID="lbBlood" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">อีเมล</td>
                        <td class="col2">
                            <asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เบอร์โทรศัพท์</td>
                        <td class="col2">
                            <asp:Label ID="lbPhone" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เบอร์โทรศัพท์ที่ทำงาน</td>
                        <td class="col2">
                            <asp:Label ID="lbWorkPhone" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ศาสนา</td>
                        <td class="col2">
                            <asp:Label ID="lbReligion" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สถานภาพ</td>
                        <td class="col2">
                            <asp:Label ID="lbStatus" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อบิดา</td>
                        <td class="col2">
                            <asp:Label ID="lbFather" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อมารดา</td>
                        <td class="col2">
                            <asp:Label ID="lbMother" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อคู่ครอง</td>
                        <td class="col2">
                            <asp:Label ID="lbCouple" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table class="ps-table" style="display: inline-block; vertical-align: top;">
                    <tr>
                        <td class="head" colspan="2">ข้อมูลทางการงาน</td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่เริ่มเข้ารับราชการ</td>
                        <td class="col2">
                            <asp:Label ID="lbInWorkDay" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง</td>
                        <td class="col2">
                            <asp:Label ID="lbPosition" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ระดับ</td>
                        <td class="col2">
                            <asp:Label ID="lbAdminPosition" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">แผนก</td>
                        <td class="col2">
                            <asp:Label ID="lbDept" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">คณะ</td>
                        <td class="col2">
                            <asp:Label ID="lbFaculty" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วิทยาเขต</td>
                        <td class="col2">
                            <asp:Label ID="lbCampus" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กระทรวง</td>
                        <td class="col2">
                            <asp:Label ID="lbMinistry" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กรม</td>
                        <td class="col2">
                            <asp:Label ID="lbGrom" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table class="ps-table" style="display: inline-block; vertical-align: top;">
                    <tr>
                        <td class="head" colspan="2">ที่อยู่</td>
                    </tr>
                    <tr>
                        <td class="col1">บ้านเลขที่</td>
                        <td class="col2">
                            <asp:Label ID="lbHomeAdd" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ซอย</td>
                        <td class="col2">
                            <asp:Label ID="lbSoi" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">หมู่</td>
                        <td class="col2">
                            <asp:Label ID="lbMoo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ถนน</td>
                        <td class="col2">
                            <asp:Label ID="lbStreet" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">จังหวัด</td>
                        <td class="col2">
                            <asp:Label ID="lbProvince" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">อำเภอ</td>
                        <td class="col2">
                            <asp:Label ID="lbAmphur" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำบล</td>
                        <td class="col2">
                            <asp:Label ID="lbDistrict" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รหัสไปรษณีย์</td>
                        <td class="col2">
                            <asp:Label ID="lbZipcode" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเทศ</td>
                        <td class="col2">
                            <asp:Label ID="lbCountry" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รัฐ</td>
                        <td class="col2">
                            <asp:Label ID="lbState" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="ps-table" style="display: inline-block; vertical-align: top;">
                    <tr>
                        <td class="head" colspan="2">ที่อยู่ปัจจุบัน</td>
                    </tr>
                    <tr>
                        <td class="col1">บ้านเลขที่</td>
                        <td class="col2">
                            <asp:Label ID="lbHomeAddNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ซอย</td>
                        <td class="col2">
                            <asp:Label ID="lbSoiNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">หมู่</td>
                        <td class="col2">
                            <asp:Label ID="lbMooNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ถนน</td>
                        <td class="col2">
                            <asp:Label ID="lbStreetNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">จังหวัด</td>
                        <td class="col2">
                            <asp:Label ID="lbProvinceNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">อำเภอ</td>
                        <td class="col2">
                            <asp:Label ID="lbAmphurNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำบล</td>
                        <td class="col2">
                            <asp:Label ID="lbDistrictNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รหัสไปรษณีย์</td>
                        <td class="col2">
                            <asp:Label ID="lbZipcodeNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเทศ</td>
                        <td class="col2">
                            <asp:Label ID="lbCountryNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รัฐ</td>
                        <td class="col2">
                            <asp:Label ID="lbStateNow" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>



        <div class="ps-separator"></div>
    </div>

</asp:Content>
