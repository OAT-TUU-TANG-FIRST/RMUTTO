<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB_PERSONAL.CSS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 141px;
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        .c2 {
            text-align: center;
        }

        .auto-style7 {
            width: 98%;
        }

        .login_pan {
            margin: 0 auto;

            
            text-align: left;
            /*border-radius: 32px;*/
            background-color: #c8c8c8;
            background-image: url("Image/ef333.jpg");
            background-size: cover;
            background-repeat: no-repeat;
            /*background-attachment:fixed;*/
            width: 600px;
            width: 100%;
        }
        .fade {
            background-color: rgba(0,0,0,0.3);
            text-align: left;
            /*border-radius: 32px;*/
            padding: 20px 100px;
        }
        .bb {
            margin: 0 auto;
            padding: 20px;
            /*background-color: #c8c8c8;
            background-image: url("Image/DORAEMON.jpg");
            background-size: cover;
            background-repeat: no-repeat;*/
        }

        .c10 {
            color: #ffffff;
            text-shadow: 1px 1px 1px #000000;
        }
        .cerror {
            color: #ffb55e;
            text-shadow: 1px 1px 1px #000000;
        }

        .div_sec {
            margin: 50px 0;
            margin-top: 0;
            box-shadow: #808080 0px 5px 5px;
        }
        .div_sec_header {
            background-color: rgba(128,128,128,0.8);
            padding: 20px 25px;
            font-weight: bold;
        }
        .div_sec_header span {
            color: #FFFFFF;
            text-shadow: 1px 1px 1px #000000;
        }
        .div_sec_in {
            background-color: rgba(128,128,128,0.6);
            padding: 20px 0px;
        }
        #sec1 {
            background-image: url("Image/log-keyboard.jpg");
            background-size: cover;
            background-repeat: no-repeat;
        }
        

        .auto-style9 {
            width: 146px;
            height: 29px;
        }

        .auto-style15 {
            width: 141px;
            text-align: right;
        }
        .auto-style17 {
            width: 146px;
        }
    </style>
    <asp:Panel ID="Panel8" runat="server" CssClass="bb">
        <div class="master_default_page_header">
            <asp:Label ID="Label1" runat="server" Text="เข้าสู่ระบบ" Font-Size="32"></asp:Label>
        </div>
        <div class="master_default_div_sec" id="sec1">
            <div class="master_default_div_sec_header">
                <asp:Label ID="Label2" runat="server" Text="เข้าสู่ระบบ"></asp:Label>
            </div>
            <div class="master_default_div_sec_in" style="height:400px;">
                <table class="auto-style7">
                    <tr>
                        <td class="auto-style5"></td>
                        <td class="auto-style9">
                            <asp:Label ID="Label9" runat="server" CssClass="cerror"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="Label7" runat="server" Text="รหัสบัตรประชาชน" CssClass="c10"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="master_default_textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="Label8" runat="server" Text="รหัสผ่าน" CssClass="c10"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="master_default_textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="Label10" runat="server" CssClass="c10" Text="คงอยู่ในระบบ"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="master_default_dropdown">
                                <asp:ListItem Value="300">5 นาที</asp:ListItem>
                                <asp:ListItem Value="1800">30 นาที</asp:ListItem>
                                <asp:ListItem Value="3600">1 ชั่วโมง</asp:ListItem>
                                <asp:ListItem Value="999999999">จนกว่าจะปิดเบราเซอร์</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style17">

                            <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click" CssClass="master_default_button">เข้าสู่ระบบ</asp:LinkButton>


                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
