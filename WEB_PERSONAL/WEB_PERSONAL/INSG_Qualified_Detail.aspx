<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Qualified_Detail.aspx.cs" Inherits="WEB_PERSONAL.INSG_Qualififed_Detail" %>
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
    <div>
        <fieldset>
            <legend class="TMZ">ประวัติการรับเครื่องราชอิสริยาภรณ์</legend>
            <div class="default_header">
                <img src="Image/Small/table.png" class="icon_left" />ข้อมูลรายละเอียด
            </div>
            <table class="center1">
                <tr>
                    <td class="col1">ชื่อ - สกุล</td>
                    <td class="col2">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ประเภทบุคลากร</td>
                    <td class="col2">
                        <asp:Label ID="lblStafftype" runat="server" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สังกัด/หน่วยงาน</td>
                    <td class="col2">
                        <asp:Label ID="lblUniversity" runat="server">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก > </asp:Label>
                        <asp:Label ID="lblCampus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">ตำแหน่งงาน</td>
                    <td class="col2">
                        <asp:Label ID="lblPosition" runat="server" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col1">สถานะ</td>
                    <td class="col2">
                        <asp:Label ID="lblStatusPersonWork" runat="server" Width="100px"></asp:Label>
                    </td>
                </tr>
            </table>
            <div>
                <asp:Table ID="Table1" runat="server" CssClass="ps-ins-table"></asp:Table>
                <div class="ps-separator"></div>
            </div>
        </fieldset>
    </div>
</asp:Content>
