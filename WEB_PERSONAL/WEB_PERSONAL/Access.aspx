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

</head>
<body>
    <form id="form1" runat="server">
        <div class="login_popup">
            <div class="login_popup_in">
                <div class="login_popup_in2">
                    <div class="login_popup_div_sec" id="locsec1">
                    <div class="login_popup_div_sec_header">
                        <img class="login_logo" src="Image/RMUTTO.png" />
                
                                              
                    </div>
                    <div class="login_popup_div_sec_in">
                        <div class="t1">ระบบบุคลากร</div>
                        <div class="t2">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</div>  
                        <div style="margin: 10px 0;"></div>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuLogin">
                            <asp:TextBox ID="tbUsername" runat="server" CssClass="login_default_textbox" MaxLength="13" placeHolder="รหัสประชาชน"></asp:TextBox>
                            <div style="margin: 5px 0;"></div>
                            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="login_default_textbox" placeHolder="รหัสผ่าน"></asp:TextBox>
                            <div style="margin: 5px 0;"></div>
                            <asp:LinkButton ID="lbuLogin" runat="server" OnClick="lbuLogin_Click" CssClass="login_button">เข้าสู่ระบบ</asp:LinkButton>
                            <div style="margin: 5px 0;"></div>
                            <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>

                        </asp:Panel>

                    </div>
                </div>
                </div>
                


            </div>




        </div>


    </form>
</body>
</html>
