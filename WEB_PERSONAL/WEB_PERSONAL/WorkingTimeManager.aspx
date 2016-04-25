<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkingTimeManager.aspx.cs" Inherits="WEB_PERSONAL.WorkingTimeManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/wrench.png" />จัดการข้อมูลเวลาปฏิบัติงาน</div>
        
        <table class="ps-table">
                    <tr>
                        <td colspan="2" class="head">ข้อมูลการลงเวลาปฏิบัติงาน</td>
                    </tr>
                    <tr>
                        <td class="col1">รหัสพนักงาน</td>
                        <td class="col2">
                            <asp:TextBox ID="tbVX1CitizenID" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            <asp:Label ID="lbVX1CitizenIDVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbVX1Date" runat="server" CssClass="ps-textbox"></asp:TextBox>
                            <asp:Label ID="lbVX1DateVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทกะงาน</td>
                        <td class="col2">
                            <div style="margin: 3px 0;">
                                <asp:DropDownList ID="ddlVX1WorktimeSec" runat="server" CssClass="dropdown dropdown_default" OnSelectedIndexChanged="ddlVX1WorktimeSec_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:Label ID="lbVX1KaVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </div>
                            <div style="margin: 3px 0;">
                                <asp:Label ID="lbVX1WorkTimeTime" runat="server"></asp:Label>
                            </div>
                            <div style="margin: 3px 0;">
                                <asp:Label ID="lbVX1WorkTimeDes" runat="server"></asp:Label>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เวลาที่มาปฏิบัติงาน</td>
                        <td class="col2">
                            <div style="margin: 3px 0;">
                                <asp:CheckBox ID="cbVX1Late" runat="server" text="ขาด" OnClick="f1();"/>
                            </div>
                            <div>
                                <div style="margin: 3px 0;">
                                    เข้าเวลา
                                    <asp:TextBox ID="tbVX1HourIn" runat="server" placeHolder="ชั่วโมง" Width="50" CssClass="ps-textbox"></asp:TextBox>
                                    
                                    <asp:Label ID="lbVX1HourInVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                    
                                    <asp:TextBox ID="tbVX1MinuteIn" runat="server" placeHolder="นาที" Width="51px" CssClass="ps-textbox"></asp:TextBox>
                                    <asp:Label ID="lbVX1MinuteInVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                </div>
                                <div style="margin: 3px 0;">
                                    เลิกเวลา
                                    <asp:TextBox ID="tbVX1HourOut" runat="server" placeHolder="ชั่วโมง" Width="50" CssClass="ps-textbox"></asp:TextBox>
                                    <asp:Label ID="lbVX1HourOutVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                    <asp:TextBox ID="tbVX1MinuteOut" runat="server" placeHolder="นาที" Width="50" CssClass="ps-textbox"></asp:TextBox>
                                    <asp:Label ID="lbVX1MinuteOutVD" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                </div>
                                
                                
                            </div>
                            
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">หมายเหตุ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbVX1Comment" runat="server" CssClass="ps-textbox"></asp:TextBox>
                        </td>
                    </tr>
            <tr>
                <td class="col1"></td>
                <td class="col2">
                    <asp:LinkButton ID="lbuAdd" runat="server" CssClass="ps-button" OnClick="lbuAdd_Click"><img src="Image/Small/add.png" class="icon_left"/>เพิ่ม</asp:LinkButton>
                </td>
            </tr>
                </table>
        <div class="ps-separator"></div>
        <div class="ps-gridview-manager-top">
            <asp:LinkButton ID="lbuVX1DeleteSelected" runat="server" CssClass="ps-button"><img src="Image/Small/bin.png" class="icon_left"/>ลบที่เลือก</asp:LinkButton>
        </div>
        <asp:GridView ID="gv1" runat="server" CssClass="ps-gridview" EmptyDataText="ไม่มีข้อมูล"></asp:GridView>
        
        <asp:HiddenField ID="hfHI" runat="server" />
        <asp:HiddenField ID="hfMI" runat="server" />
        <asp:HiddenField ID="hfHO" runat="server" />
        <asp:HiddenField ID="hfMO" runat="server" />
        <asp:HiddenField ID="hfSql" runat="server" />

    </div>
</asp:Content>
