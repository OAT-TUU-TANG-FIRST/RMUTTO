<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WEB_PERSONAL.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/About.css" rel="stylesheet" />
    <div class="mp">
        
        <div class="c1">
            <div class="c3">
                เกี่ยวกับ
            </div>
                <asp:label id="Label1" runat="server" text="กองบริหารงานบุคคล สำนักงานอธิการบดี มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก วิทยาเขตบางพระ"></asp:label>
                <br />
                <asp:label id="Label5" runat="server" text="43  หมู่ 6   ตำบลบางพระ  อำเภอศรีราชา  จังหวัดชลบุรี  20110"></asp:label>
                <br />
                <asp:label id="Label6" runat="server" text="โทรศัพท์ <strong>0-3835-8137, 0-3835-8201</strong> โทรสาร <strong>0-3834-1808-9</strong>"></asp:label>
                <br />
                <asp:label id="Label8" runat="server" text="เว็บไซต์ "></asp:label>
                <a href="http://www.rmutto.ac.th">www.rmutto.ac.th</a>
        </div>
        <div class="c2">
            <asp:label id="LabelCounter" runat="server"></asp:label>
        </div>
        <div style="border-bottom: 1px solid #c0c0c0; margin: 20px 0px;"></div>
    </div>
</asp:Content>
