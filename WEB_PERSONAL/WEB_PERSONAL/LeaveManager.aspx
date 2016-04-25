<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveManager.aspx.cs" Inherits="WEB_PERSONAL.LeaveManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/wrench.png" />จัดการข้อมูลการลา</div>
        <div>
            <asp:LinkButton ID="lbuLF1Select" runat="server" OnClick="lbuLF1Select_Click" CssClass="ps-vs-sel">การลาป่วย</asp:LinkButton>
            <asp:LinkButton ID="lbuLF2Select" runat="server" OnClick="lbuLF2Select_Click" CssClass="ps-vs">การลากิจ</asp:LinkButton>
            <asp:LinkButton ID="lbuLF3Select" runat="server" OnClick="lbuLF3Select_Click" CssClass="ps-vs">การลาพักผ่อน</asp:LinkButton>
        </div>
        <div style="border-top: 1px solid #00a2e8; padding-top: 10px;">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="gv2" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:GridView ID="gv3" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
                </asp:View>
             </asp:MultiView>
        </div>
        
    </div>
</asp:Content>
