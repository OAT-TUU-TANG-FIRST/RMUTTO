<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchForLinkPrint.aspx.cs" Inherits="WEB_PERSONAL.SearchForLinkPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panin {
            background-image: url("Image/bg5.jpg");
            border-radius:5px;
            background-size: contain;
            background-repeat:no-repeat;
        }
       
        .center{
            text-align:center
        }
        .auto-style3 {
            text-align: center;
        }
        .button{
            border-color:orange;
            border-radius:5px;
            padding:5px 20px;
            background-color:#808080;
            text-decoration:none;
            color:white;
            transition: color 0.75s ease, background-color 0.75s ease;
            display:inline;
        }
        .button:hover {
    color: #00ffff;
    background-color: #808080;
}
        .auto-style9 {
            font-size: 32px;
            color: #ffffff;
            text-shadow: 1px 1px 1px #000000;
        }
        .auto-style10 {
            text-align: right;
        }
        .auto-style11 {
            text-align: left;
        }
        .auto-style13 {
            width: 500px;
            height: 183px;
        }
        .auto-style15 {
            width: 280px;
            height: 183px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel8" runat="server" Height="1077px" CssClass="panin">
        <div style="height:100px"></div>
        <div class="p2">
            
            <table style="width:100%;">
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style13">
                    <asp:Panel ID="Panel9" runat="server" Height="173px" Width="536px" BorderWidth="0px">
                        
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style3" colspan="2">
                                    <asp:Label ID="Label9" runat="server" CssClass="auto-style9" Text="กรอกรหัสบัตรประจำตัวประชาชน 13 หลัก"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="auto-style3">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="340px" Height="32px" MaxLength="13" ToolTip="กรอกเลขประจำตัวประชาชน 13 หลัก" CssClass="master_default_textbox" style="text-align:center"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    &nbsp;</td>
                                <td class="auto-style3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style10">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" >Cancel</asp:LinkButton>
                                </td>
                                <td class="auto-style11">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" Width="40px" >&nbsp;&nbsp;OK</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        
                    </asp:Panel>
                </td>
                <td class="auto-style15"></td>
            </tr>
        </table>
        </div>
            
        
    </asp:Panel>
</asp:Content>
