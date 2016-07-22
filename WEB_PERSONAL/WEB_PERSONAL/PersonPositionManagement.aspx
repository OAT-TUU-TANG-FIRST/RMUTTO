<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonPositionManagement.aspx.cs" Inherits="WEB_PERSONAL.PersonPositionManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Small/person2.png" />จัดการแต่งตั้งหัวหน้า
        </div>

        <div id="divState1" runat="server">
            <asp:Panel ID="pPerson" runat="server"></asp:Panel>
        </div>
        
        <div id="divTab" runat="server" class="ps-tab-container-center">
            <asp:LinkButton ID="lbuTab1" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab1_Click">แต่งตั้งอธิการบดี</asp:LinkButton>
            <asp:LinkButton ID="lbuTab2" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab2_Click">แต่งตั้งรองอธิการบดี</asp:LinkButton>
            <asp:LinkButton ID="lbuTab3" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab3_Click">แต่งตั้งคณะบดี</asp:LinkButton>
            <asp:LinkButton ID="lbuTab4" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab4_Click">แต่งตั้งรองคณะบดี</asp:LinkButton>
            <asp:LinkButton ID="lbuTab5" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab5_Click">แต่งตั้งหัวหน้าภาควิชา</asp:LinkButton>
            <asp:LinkButton ID="lbuTab6" runat="server" CssClass="ps-tab-unselected" OnClick="lbuTab6_Click">แต่งตั้งหัวหน้าฝ่าย</asp:LinkButton>
        </div>
       

        <div id="divState2" runat="server">

            <div id="divState2Tab4" runat="server">
                <div class="ps-div-title-red">แต่งตั้งรองคณะบดี</div>
            </div>

            <div id="divState2Tab5" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าภาควิชา</div>
            </div>

            <div id="divState2Tab6" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าฝ่าย</div>
                <table class="ps-table-1" style="margin: 0 auto; margin-bottom: 20px;">
                    <tr>
                        <td class="col1">วิทยาเขต</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlCampus" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlCampus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สำนัก / สถาบัน / คณะ</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlFaculty" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlFaculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">กอง / สำนักงานเลขา / ภาควิชา</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlDivision" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trWorkDivision" runat="server">
                        <td class="col1">งาน / ฝ่าย</td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlWorkDivision" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right;">
                            <asp:LinkButton ID="lbuState2Back" runat="server" CssClass="ps-button" OnClick="lbuState2Back_Click">ย้อนกลับ</asp:LinkButton>
                            <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>เลือกสังกัด</asp:LinkButton>
                        </td>

                    </tr>
                </table>
            </div>




        </div>
        
        <div id="divState3" runat="server">

            <div id="divState3Tab1" runat="server">
                <div class="ps-div-title-red">แต่งตั้งอธิการบดี</div>
                <div style="text-align: center">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">อธิการบดีเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldAtikan" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbuOldAtikan" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">อธิการบดีใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewAtikan" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbuNewAtikan" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab1Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab1Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuAtikanSave" runat="server" CssClass="ps-button" OnClick="lbuAtikanSave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งอธิการบดีใหม่</asp:LinkButton>
                </div>
            </div>

            <div id="divState3Tab2" runat="server">
                <div class="ps-div-title-red">แต่งตั้งรองอธิการบดี <asp:Label ID="lbState3Tab2Campus" runat="server" Text="?"></asp:Label></div>
                <div style="text-align: center">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">รองอธิการบดีเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldRongAtikan" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbuOldRongAtikan" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">รองอธิการบดีใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewRongAtikan" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbuNewRongAtikan" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab2Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab2Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuRongAtikanSave" runat="server" CssClass="ps-button" OnClick="lbuRongAtikanSave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งรองอธิการบดีใหม่</asp:LinkButton>
                </div>
            </div>

            <div id="divState3Tab3" runat="server">
                <div class="ps-div-title-red">แต่งตั้งคณะบดี <asp:Label ID="lbState3Tab3Faculty" runat="server" Text="?"></asp:Label></div>
                <div style="text-align: center">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">คณบดีเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldFac" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbOldFac" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">คณบดีใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewFac" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbNewFac" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab3Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab3Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuFacSave" runat="server" CssClass="ps-button" OnClick="lbuFacSave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งคณบดีใหม่</asp:LinkButton>
                </div>
            </div>

            <div id="divState3Tab4" runat="server">
                <div class="ps-div-title-red">แต่งตั้งรองคณะบดี <asp:Label ID="lbState3Tab4Faculty" runat="server" Text="?"></asp:Label></div>
                <div style="text-align: center;">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">รองคณะบดีเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldRongFaculty" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbOldRongFaculty" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>

                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">รองคณะบดีใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewRongFaculty" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbNewRongFaculty" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>
   
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab4Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab4Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuRongFacultySave" runat="server" CssClass="ps-button" OnClick="lbuRongFacultySave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งรองคณะบดีใหม่</asp:LinkButton>
                </div>
            </div>

            <div id="divState3Tab5" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าภาควิชา <asp:Label ID="lbState3Tab5Division" runat="server" Text="?"></asp:Label></div>
                <div style="text-align: center;">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">หัวหน้าภาควิชาเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldDivision" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbOldDivision" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>

                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">หัวหน้าภาควิชาใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewDivision" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbNewDivision" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>
   
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab5Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab5Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuDivisionSave" runat="server" CssClass="ps-button" OnClick="lbuDivisionSave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งหัวหน้าภาควิชาใหม่</asp:LinkButton>
                </div>
            </div>

            <div id="divState3Tab6" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าฝ่าย <asp:Label ID="lbState3Tab6Work" runat="server" Text="?"></asp:Label></div>
                <div style="text-align: center;">
                    <div style="display: inline-block; margin-right: 10px;">
                        <div class="ps-lb-red-b">หัวหน้าฝ่ายเก่า</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgOldWork" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbOldWork" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>

                    <div style="display: inline-block">
                        <div class="ps-lb-blue-b">หัวหน้าฝ่ายใหม่</div>
                        <div style="text-align: center;">
                            <img src="~/Image/no_image.png" id="imgNewWork" runat="server" class="ps-ms-main-drop-profile-pic" />
                            <br />
                            <asp:Label ID="lbNewWork" runat="server" Text="-"></asp:Label>
                        </div>

                    </div>
   
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:LinkButton ID="lbuState3Tab6Back" runat="server" CssClass="ps-button" OnClick="lbuState3Tab6Back_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                    <asp:LinkButton ID="lbuWorkDivisionSave" runat="server" CssClass="ps-button" OnClick="lbuWorkDivisionSave_Click"><img src="Image/Small/save.png" class="icon_left"/>ยืนยันการแต่งตั้งหัวหน้าฝ่ายใหม่</asp:LinkButton>
                </div>
            </div>
        </div>

        <div id="divState4" runat="server">
            <div id="divState4Tab1" runat="server">
                <div class="ps-div-title-red">แต่งตั้งอธิการบดีใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab1OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab1OK_Click"></asp:LinkButton>
                </div>
            </div>
            <div id="divState4Tab2" runat="server">
                <div class="ps-div-title-red">แต่งตั้งรองอธิการบดีใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab2OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab2OK_Click"></asp:LinkButton>
                </div>
            </div>
            <div id="divState4Tab3" runat="server">
                <div class="ps-div-title-red">แต่งตั้งคณะบดีใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab3OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab3OK_Click"></asp:LinkButton>
                </div>
            </div>
            <div id="divState4Tab4" runat="server">
                <div class="ps-div-title-red">แต่งตั้งรองคณะบดีใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab4OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab4OK_Click"></asp:LinkButton>
                </div>
            </div>
            <div id="divState4Tab5" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าภาควิชาใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab5OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab5OK_Click"></asp:LinkButton>
                </div>
            </div>
            <div id="divState4Tab6" runat="server">
                <div class="ps-div-title-red">แต่งตั้งหัวหน้าฝ่ายใหม่เรียบร้อยแล้ว</div>
                <div style="text-align: center;">
                    <asp:LinkButton ID="lbuState4Tab6OK" runat="server" Text="ตกลง" CssClass="ps-button" OnClick="lbuState4Tab6OK_Click"></asp:LinkButton>
                </div>
            </div>
            
        </div>

            <div class="ps-separator"></div>

    </div>
</asp:Content>
