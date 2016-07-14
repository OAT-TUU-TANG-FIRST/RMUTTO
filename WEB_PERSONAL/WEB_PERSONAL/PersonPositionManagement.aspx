<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonPositionManagement.aspx.cs" Inherits="WEB_PERSONAL.PersonPositionManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Small/person2.png" />จัดการตำแหน่งบุคลากร
        </div>
        <div id="divState2" runat="server">
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

        <div id="divState1" runat="server">
            <div class="ps-div-title-red">รายชื่อบุคลากร</div>
            <asp:Table ID="tbPerson" runat="server" CssClass="ps-table-1" style="margin: 0 auto;"></asp:Table>
        </div>

        <div id="divState3" runat="server">
            <div style="text-align: center;">
                <asp:Panel ID="pOldBoss" runat="server" style="display: inline-block">
                <div class="ps-div-title-red">หัวหน้าเก่า</div>
                <div style="text-align: center;">
                    <img src="~/Image/no_image.png" id="imgOldBoss" runat="server" class="ps-ms-main-drop-profile-pic"/>
                    <br />
                <asp:Label ID="lbuOldBossName" runat="server" Text="-"></asp:Label>
                </div>
                
            </asp:Panel>
                <div style="width: 50px; display: inline-block;"></div>
            <asp:Panel ID="pNewBoss" runat="server" style="display: inline-block">
                <div class="ps-div-title-red" style="margin-top: 20px;">หัวหน้าใหม่</div>
                <div style="text-align: center;">
                    <img src="~/Image/no-image.png" id="imgNewBoss" runat="server" class="ps-ms-main-drop-profile-pic"/>
                    <br />
                <asp:Label ID="lbuNewBossName" runat="server" Text="-"></asp:Label>
                </div>
                
            </asp:Panel>
            </div>
            
            <div class="ps-div-title-red" style="margin-top: 20px;">ยืนยันการแต่งตั้งหัวหน้าใหม่</div>
            <div style="text-align: center;" id="pConfirm" runat="server">

            </div>
        </div>

    </div>
</asp:Content>
