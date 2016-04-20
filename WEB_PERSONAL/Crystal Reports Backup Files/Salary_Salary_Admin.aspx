<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salary_Salary_Admin.aspx.cs" Inherits="WEB_PERSONAL.Salary_Salary_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Linkbtn {
            border-radius: 5px;
            padding: 10px;
            background-color: #5971ff;
            text-decoration: none;
            color: white;
        }

        .mGrid {
            width: 100%;
            background-color: #666;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .mGrid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: #fff;
            }

            .mGrid th {
                padding: 4px 2px;
                color: #fff;
                background: #00BFFF;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            .mGrid .alt {
                background: #fcfcfc;
            }

            .mGrid .pgr {
                background: #424242;
            }

                .mGrid .pgr table {
                    margin: 5px 0;
                }

                .mGrid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .mGrid .pgr a {
                    color: #666;
                    text-decoration: none;
                }

                    .mGrid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }

        .button_ui {
            border-radius: 2px;
            padding: 2px 8px;
            background-color: #00d8ff;
            border-color: black;
            color: black;
            font: bold;
            text-decoration: none;
            margin-left: 10px;
            line-height: 40px;
            transition: ease 0.25s;
        }

            .button_ui:hover {
                border-radius: 2px;
                padding: 2px 8px;
                background-color: #ff64a2;
                border-color: black;
                color: white;
                font: bold;
                text-decoration: none;
                line-height: 40px;
                margin-left: 10px;
            }

        @font-face {
            font-family: 'WDB_BANGNA';
            src: url('../Font/WDB_Bangna.ttf') format('truetype');
        }

        .bigtuu {
            font-family: WDB_BANGNA;
        }

        .bgtest {
            padding: 20px 25px;
            font-weight: bold;
            background-color: #00BFFF;
        }

        .homemenu {
            width: 100%;
            height: 40px;
            position: fixed;
            z-index: 999;
            background-color: #FFFFFF;
        }

        .hidBtn {
            display: none;
        }

        #eiei {
            background-image: url("/Image/btx1.jpg");
            background-size: 100%;
        }
    </style>
    <link href="CSS/Master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="homemenu">
            <asp:Table ID="Table3" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="button_ui">กลับเมนูหลัก</asp:LinkButton>
                    </asp:TableCell>
                    <asp:TableCell>
                         <iframe width="100%" height="20" scrolling="no" frameborder="no" src="https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/53827689&amp;color=00cc11&amp;auto_play=true&amp;hide_related=false&amp;show_comments=true&amp;show_user=true&amp;show_reposts=false"></iframe>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>


        </div>
        <div style="height: 20px"></div>
        <div class="bigtuu">
            <asp:Panel ID="Panel3" runat="server">
                <div class="master_default_div_sec" id="eiei">
                    <div class="bgtest">
                        <asp:Label ID="Label2" runat="server" Text="ระบบจัดการเงินเดือน"></asp:Label>
                    </div>
                    <div class="master_default_div_sec_in">
                                    <asp:Panel ID="Panel1" runat="server" DefaultButton="LinkButton2">
                                        <div class="master_default_div_sec_header">
                                            <asp:Label ID="Label1" runat="server" Text="จัดการเงินเดือน"></asp:Label>
                                        </div>
                                        <div class="master_default_div_sec_in">
                                            <asp:Table ID="Table1" runat="server" Height="300px">
                                                <asp:TableRow>
                                                    <asp:TableCell runat="server" Width="200px" HorizontalAlign="Left">
                                                        <asp:Label ID="Label4" runat="server" Text="ชื่อ"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                                        <asp:Label ID="Label5" runat="server" Text="นามสกุล"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell runat="server" Width="200px" HorizontalAlign="Left">
                                                        <asp:Label ID="Label6" runat="server" Text="ตำแหน่ง"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell runat="server" Width="200px" HorizontalAlign="Left">
                                                        <asp:Label ID="Label7" runat="server" Text="เงินเดือน"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableFooterRow>
                                                    <asp:TableCell runat="server" Width="250px" ColumnSpan="2">
                                                        <br />
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="Linkbtn" OnClick="LinkButton2_Click">เพิ่มข้อมูลเงินเดือน</asp:LinkButton>
                                                        <br />
                                                    </asp:TableCell>
                                                </asp:TableFooterRow>
                                            </asp:Table>
                                        </div>
                                    </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
