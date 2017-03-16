<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="WEB_PERSONAL.Access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="icon" href="Image/favicon.ico" />
    <title>ระบบบุคลากร - มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</title>
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

                    <div class="ps-box-il" style="width: 400px;">
                        <div class="ps-box-i0">
                            <div class="ps-box-ct10-cen">
                                <img class="login_logo" src="Image/RMUTTO.png" />
                                <div class="t1">ระบบบุคลากร</div>
                                <div class="t2">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</div>
                            </div>
                        </div>
                        <div class="ps-box-i0">
                            <div class="ps-box-ct10-cen">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuLogin">
                                    <div>
                                        <asp:TextBox ID="tbUsername" runat="server" CssClass="login_default_textbox" MaxLength="13" placeHolder="รหัสประชาชน"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="login_default_textbox" placeHolder="รหัสผ่าน"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="lbuLogin" runat="server" OnClick="lbuLogin_Click" CssClass="ps-button" Style="font-size: 16px; margin-top: 2px;"><img src="Image/Small/key.png" class="icon_left"/>เข้าสู่ระบบ</asp:LinkButton>
                                    </div>
                                    <div>
                                        <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
                                    </div>
                                    
                                    
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="ps-box-i0">
                            <div class="ps-box-hd10-cen"><img src="Image/Small/web.png" class="icon_left"/>เว็บไซต์ในสถาบัน</div>
                            <div class="ps-box-ct10-cen">
                                <div class="web-link">
                                    <a href="http://www.rmutto.ac.th">บางพระ</a>
                                    <a href="http://www.chan.rmutto.ac.th">จันทบุรี</a>
                                    <a href="http://www.cpc.rmutto.ac.th">จักรพงษภูวนารถ</a>
                                    <a href="http://www.uthen.rmutto.ac.th">อุเทนถวาย</a>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>


            </div>




        </div>


    </form>
</body>
</html>
