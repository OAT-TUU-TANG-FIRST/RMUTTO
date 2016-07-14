<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonReport.aspx.cs" Inherits="WEB_PERSONAL.PersonReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbBirthdayDateFrom, #ContentPlaceHolder1_tbBirthdayDateTo").datepicker($.datepicker.regional["th"]);
        });
        function toggle(source, type) {
            var checkboxes = document.getElementsByName(type);
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].firstChild.checked = source.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <div class="ps-div-title-red">เลือกไอเทม</div>
            <div style="text-align: center;">
                <input type="checkbox" onclick="toggle(this, 'item');"/> <b>เลือกทั้งหมด</b> 
                <asp:CheckBox ID="cbPsID" runat="server" name="item"/> ลำดับ
                <asp:CheckBox ID="cbCitizenID" runat="server" name="item"/> เลขบัตรประชาชน
                <asp:CheckBox ID="cbPsName" runat="server" name="item" /> ชื่อ
                <asp:CheckBox ID="cbGender" runat="server" name="item" /> เพศ
                <asp:CheckBox ID="cbAge" runat="server" name="item" /> อายุ
                <asp:CheckBox ID="cbCampus" runat="server" name="item" /> วิทยาเขต
                <asp:CheckBox ID="cbBirthdayDate" runat="server" name="item" /> วันเกิด
            </div>
            <div class="ps-div-title-red" style="margin-top: 10px;">เลือกเงื่อนไช</div>
            <div style="text-align: center;">
                <div>
                    <input type="checkbox" onclick="toggle(this, 'condition');"/> <b>เลือกทั้งหมด</b> 
                </div>
                <div>
                    <asp:CheckBox ID="cbGenderCondition" runat="server" name="condition" /> เพศ
                    <asp:RadioButton ID="rbMale" runat="server" GroupName="gGender" Checked="true"/> ชาย
                    <asp:RadioButton ID="rbFemale" runat="server" GroupName="gGender"/> หญิง
                </div>
                <div>
                    <asp:CheckBox ID="cbAgeCondition" runat="server" name="condition" /> อายุ
                    <asp:TextBox ID="tbAgeConditionFrom" runat="server" Width="50"></asp:TextBox> <span style="color: #808080;">ถึง</span>
                    <asp:TextBox ID="tbAgeConditionTo" runat="server" Width="50"></asp:TextBox>
                </div>
                <div>
                    <asp:CheckBox ID="cbCampusCondition" runat="server" name="condition" /> วิทยาเขต
                    <asp:DropDownList ID="ddlCampus" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:CheckBox ID="cbBirthdayDateCondition" runat="server" name="condition" /> วันเกิด
                    <asp:TextBox ID="tbBirthdayDateFrom" runat="server"></asp:TextBox> <span style="color: #808080;">ถึง</span>
                    <asp:TextBox ID="tbBirthdayDateTo" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="text-align: center; margin-top: 10px;">
                <asp:LinkButton ID="lbuSearch" runat="server" CssClass="ps-button" OnClick="lbuSearch_Click">ค้นหา</asp:LinkButton>
            </div>
            <div class="ps-separator"></div>
        </div>
        <div>
            <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>Export</asp:LinkButton>
        </div>
        <div>
            <asp:Table ID="tb" runat="server" CssClass="ps-table-1" style="margin-top: 10px;"></asp:Table>
        </div>
        
    </div>
</asp:Content>
