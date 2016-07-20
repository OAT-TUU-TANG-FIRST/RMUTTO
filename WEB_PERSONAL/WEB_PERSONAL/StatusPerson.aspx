<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StatusPerson.aspx.cs" Inherits="WEB_PERSONAL.StatusPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Small/person2.png" />ปรับเปลี่ยนสถานะการทำงาน
    </div>

    <div class="ps-div-title-red">
        <div class="ps-div-title-red">
            <img src="Image/Small/search.png" class="icon_left" />ค้นหารายชื่อพนักงาน
        </div>
        รหัสบัตรประชาชน :&nbsp;<asp:TextBox ID="txtSearchCitizenID" runat="server" CssClass="ps-div-title-red" Width="230px" MaxLength="13"></asp:TextBox>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
        <asp:LinkButton ID="lbuRefresh" runat="server" CssClass="ps-button" OnClick="lbuRefresh_Click"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
    </div>

    <div id="divState1" runat="server">
        <div class="ps-div-title-red">รายชื่อบุคลากร</div>
        <asp:Table ID="tbPerson" runat="server" CssClass="ps-table-1" Style="margin: 0 auto;"></asp:Table>
    </div>
    <div>

        <div id="divState2" runat="server">
            <table class="ps-table-1" style="margin: 0 auto; margin-bottom: 20px;">
                <tr>
                    <td class="col1">สถานะบุคลากร</td>
                    <td class="col2">
                        <asp:DropDownList ID="ddlStatusWork" runat="server" CssClass="ps-dropdown" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;">
                        <asp:LinkButton ID="lbuState2Back" runat="server" CssClass="ps-button" OnClick="lbuState2Back_Click">ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuSubmit" runat="server" OnClick="lbuSubmit_Click" CssClass="ps-button"><img src="Image/Small/Add.png" class="icon_left"/>ตกลง</asp:LinkButton>
                    </td>

                </tr>
            </table>
        </div>
    </div>
</asp:Content>
