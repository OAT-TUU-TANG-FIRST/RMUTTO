<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="WEB_PERSONAL.LeaveHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่อยู่ระหว่างการดำเนินงาน</div>
    <div>
        <asp:Linkbutton ID="lbuShow1" runat="server" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>แสดงทั้งหมด</asp:Linkbutton>
        <asp:GridView ID="GridView1" runat="server" CssClass="ps-gridview"></asp:GridView>
        <asp:Label ID="lbGS1" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
    </div>
    

    <div class="ps-separator"></div>

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่เสร็จ</div>
    <div>
        <asp:Linkbutton ID="lbuShow3" runat="server" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>แสดงทั้งหมด</asp:Linkbutton>
        <asp:GridView ID="GridView3" runat="server" CssClass="ps-gridview"></asp:GridView>
        <asp:Label ID="lbGS3" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
    </div>
    

    <div class="ps-separator"></div>

    <div class="ps-header"><img src="Image/Small/table.png" />รายการที่ผ่าน / ไม่ผ่านการอนุมัติ</div>
    <div>
        <asp:Linkbutton ID="lbuShow2" runat="server" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>แสดงทั้งหมด</asp:Linkbutton>
        <asp:GridView ID="GridView2" runat="server" CssClass="ps-gridview"></asp:GridView>
        <asp:Label ID="lbGS2" runat="server" Text="ไม่มีข้อมูล"></asp:Label>
    </div>
    

    <div class="ps-separator"></div>
    
</asp:Content>
