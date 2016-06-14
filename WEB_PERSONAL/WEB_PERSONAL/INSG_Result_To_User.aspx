<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Result_To_User.aspx.cs" Inherits="WEB_PERSONAL.INSG_Result_To_User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .TMZ {
            font-family: tahoma;
            text-align: left;
            color: #9999ff;
            font-weight: 900;
        }
        .divpan {
            text-align: center;
        }
        .panin {
            border: 1px solid black;
            margin: 20px;
            background-color: rgba(255,255,255,0.6);
            border-radius: 5px;
        }
        body {
            background-color: white;
        }
        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 150px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
        .center1 {
            display: inline-block;
        }
        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: left;
        }
        fieldset {
            border: 3px solid #99e6ff;
            color: black;
        }
        .col1 {
            padding: 3px 5px;
            text-align: right;
            background-color: #f8f8f8;
            color: #404040;
        }
        .col2 {
            padding: 3px 5px;
            background-color: #ffffff;
            border-bottom: 1px solid #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/medal.png" />การแจ้งผลผู้ที่ได้รับเครื่องราชอิสริยาภรณ์</div>
        <asp:Table ID="Table1" runat="server" CssClass="ps-ins-table"></asp:Table>
                <div class="ps-separator"></div>
                <div>
                    <asp:LinkButton ID="lblGet" runat="server" CssClass="ps-button" OnClick="lblGet_Click"><img src="Image/Small/correct.png" class="icon_left"/>ได้รับเครื่องราชฯ</asp:LinkButton>
                    <asp:LinkButton ID="lblNotGet" runat="server" CssClass="ps-button" ><img src="Image/Small/delete.png" class="icon_left"/>ไม่ได้รับเครื่องราชฯ</asp:LinkButton>
                </div>   
        <div class="ps-separator"></div>
    </div>
</asp:Content>
