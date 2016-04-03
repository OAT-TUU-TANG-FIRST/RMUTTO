<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="WEB_PERSONAL.Access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="icon" href="Image/favicon.ico" />
    <title>ระบบบุคลากร - มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก วิทยาเขตบางพระ</title>
    <link rel="stylesheet" type="text/css" href="CSS/Master.css" />
    <link href="CSS/Access.css" rel="stylesheet" />
    <script src="jQueryCalendarThai/jquery-ui-1.10.3.custom.js"></script>
    <script src="jQueryCalendarThai/jquery-1.9.0.min.js"></script>
    <script>
        function goPage(target) {
            /*setTimeout(function () { fa(target); }, 1000);
            var v = document.getElementsByClassName('all_div')[0];
            v.style.opacity = '0';*/

        }
        function fa(target) {
            //document.location.href = target;
        }
        $(document).ready(function () {
            setTimeout(op1, 300);
        });
        function op1() {
            $(".all_div").css('opacity', '1');
        }
        function f1() {
            $('#locsec1').fadeOut(250);
            $('#locsec2').fadeIn(250);
        }
        function f2() {
            $('#locsec1').fadeIn(250);
            $('#locsec2').fadeOut(250);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">

                <div class="all_div">


                    <div class="login_popup">



                        <div class="login_popup_in">
                            <div class="login_popup_div_sec" id="locsec1">
                                <div class="login_popup_div_sec_header">
                                    <img src="Image/RMUTTO.png" style="height: 128px" />
                                    <br />
                                    <asp:Label ID="Label11" runat="server" Text="เข้าสู่ระบบ บุคลากร"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก วิทยาเขตบางพระ"></asp:Label>
                                </div>
                                <div class="login_popup_div_sec_in">
                                    <asp:Panel ID="Panel1" runat="server" DefaultButton="LinkButton1X">
                                        <table>
                                            <tr>
                                                <td class="login_column0">
                                                    <asp:Label ID="Label13X" runat="server" Text="รหัสบัตรประชาชน"></asp:Label>
                                                </td>
                                                <td class="login_column1">
                                                    <asp:TextBox ID="TextBox1X" runat="server" CssClass="login_default_textbox" MaxLength="13"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="login_column0">
                                                    <asp:Label ID="Label14X" runat="server" Text="รหัสผ่าน" CssClass="c10"></asp:Label>
                                                </td>
                                                <td class="login_column1">
                                                    <asp:TextBox ID="TextBox2X" runat="server" TextMode="Password" CssClass="login_default_textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="login_column0">
                                                    <asp:Label ID="Label15X" runat="server" CssClass="c10" Text="คงอยู่ในระบบ"></asp:Label>
                                                </td>
                                                <td class="login_column1">
                                                    <asp:DropDownList ID="DropDownList1X" runat="server" CssClass="login_default_dropdown">
                                                        <asp:ListItem Value="300">5 นาที</asp:ListItem>
                                                        <asp:ListItem Value="1800">30 นาที</asp:ListItem>
                                                        <asp:ListItem Value="3600">1 ชั่วโมง</asp:ListItem>
                                                        <asp:ListItem Value="999999999">จนกว่าจะปิดเบราเซอร์</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="login_column0"></td>
                                                <td class="login_column1">
                                                    <asp:LinkButton ID="LinkButton1X" runat="server" OnClick="LinkButton1X_Click" CssClass="login_button" OnClientClick="f1()">เข้าสู่ระบบ</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="login_column0">&nbsp;</td>
                                                <td class="login_column1">

                                                    <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>

                                                </td>
                                            </tr>
                                        </table>

                                    </asp:Panel>

                                </div>
                            </div>

                            <div class="login_popup_div_sec" id="locsec2">
                                <div class="login_popup_div_sec_header" style="text-align: center;">
                                    
                                </div>
                                <div class="login_popup_div_sec_in" style="text-align: center; font-size: 48px; margin-top: 80px">
                                    กำลังเชื่อมต่อ
                                    <br />
                                    <img src="Image/loading_spinner.gif"/>
                                </div>
                            </div>

                        </div>




                    </div>
                </div>

    </form>
</body>
</html>
