<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_RequestList.aspx.cs" Inherits="WEB_PERSONAL.INSG_RequestList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="ps-header">
                    <img src="Image/Small/medal.png" />แจ้งผลการขอเครื่องราชฯ
                </div>
                <asp:Table ID="Table1" runat="server" CssClass="ps-ins-table"></asp:Table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="ps-box-il">
                    <div class="ps-box-i0"> 
                        <div class="ps-box-hd10">แจ้งผลการขอเครืองราชฯ
                             </div>
                    </div>
                    <div class="ps-box-i0">
                        
                        <div class="ps-box-ct10">
                            <div>
                                <asp:RadioButton ID="rbGet" runat="server" Text="ได้รับเครื่องราชฯ" />
                            <asp:RadioButton ID="rbNotGet" runat="server" Text="ไม่ได้รับเครื่องราชฯ" />
                            </div>
                            <div>
                                เอกสารอ้างอิง<asp:TextBox ID="tbRef" runat="server" Width="150px"></asp:TextBox>
                            </div>
                            <div>
                                
                            </div>
                            
                        </div>
                    </div>
                    <div class="ps-box-i0">
                        <div class="ps-box-ct10">
                        <asp:LinkButton ID="lbBack" runat="server" CssClass="ps-button" OnClick="lbBack_Click"><img src="Image/Small/back.png" class="icon_left"/>กลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuResult" runat="server" CssClass="ps-button" ><img src="Image/Small/correct.png" class="icon_left"/>แจ้งผล</asp:LinkButton>
                    </div>
                    </div>
                </div>
           </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
