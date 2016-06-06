<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveControl.aspx.cs" Inherits="WEB_PERSONAL.LeaveControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c1 div {
            display: block;
            margin-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header"><img src="Image/Small/wrench.png" />จัดการสิทธิใช้งานการลา</div>
        <div class="ps-box">
            <div class="ps-box-i0">
                <div class="ps-box-hd10">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuSearch">
                        <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" placeHolder="รหัสประชาชน"></asp:TextBox>
                        <asp:LinkButton ID="lbuSearch" runat="server" CssClass="ps-button" OnClick="lbuSearch_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                    </asp:Panel>
                    
                </div>
            </div>
            <div class="ps-box-i0" id="d1" runat="server" style="display: none;">
                <div class="ps-box-hd10">
                    กำหนดสิทธิการใช้งานการลาให้
                    <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                </div>
                <div class="ps-box-ct10">
                    <div class="c1">
                        <div>
                            <asp:CheckBox ID="cb1" runat="server" Text="จัดการวันปฏิบัติราชการ"/>
                        </div>
                        <div>
                            <asp:CheckBox ID="cb2" runat="server" Text="ออกรายงานการลา"/>
                        </div>
                        <div>
                            <asp:LinkButton ID="lbuSave" runat="server" CssClass="ps-button" OnClick="lbuSave_Click"><img src="Image/Small/save.png" class="icon_left"/>บันทึก</asp:LinkButton>
                            <asp:Label ID="lbSaveComplete" runat="server" Text="บันทึกสำเร็จ" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ps-box-i0" id="d2" runat="server" style="display: none; font-size: 18px;">
                <div class="ps-box-ct10" style="color: #808080;">
                    ไม่พบผู้ใช้
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hfCitizenID" runat="server" />
    </div>
</asp:Content>
