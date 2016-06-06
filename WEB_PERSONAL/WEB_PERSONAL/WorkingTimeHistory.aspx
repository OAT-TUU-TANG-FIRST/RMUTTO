<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkingTimeHistory.aspx.cs" Inherits="WEB_PERSONAL.WorkingTimeHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbDate").datepicker($.datepicker.regional["th"]);
        });
    </script>
    <style>
        .calendar {
            
        }
        .calendar_info {
            margin-top: 20px;
        }
        .calendar_info_item {
            display: inline-block;
            border: 1px solid #f0f0f0;
            padding: 5px 20px;
        }
        .calendar_info_item2 {
            display: inline-block;
            width: 55px;
            height: 50px;
            line-height: 50px;
            font-size: 20px;
            text-decoration: none;
            text-align: center;
        }
        .d_table {
            border-collapse: collapse;
            display: inline-table;
            margin-right: 50px;
        }
        .d_table td {
            margin: 0px;
            padding: 0px;
            display: inline-block;
        }
        .d_txt {
            text-align: center;
            font-size: 20px;
        }
        .d_blank {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 50px;
            font-size: 12px;
            background-color: #ffffff;
            text-decoration: none;
            text-align: center;
        }
        .d_break span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 20px;
            font-size: 12px;
            color: #ffffff;
            background-color: #ff478b;
            text-decoration: none;
            text-align: center;
        }
        .d_ss span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 50px;
            font-size: 12px;
            color: #ffffff;
            background-color: #ff005e;
            text-decoration: none;
            text-align: center;
        }


        .d_normal span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 20px;
            font-size: 12px;
            color: #000000;
            background-color: #f0f0f0;
            text-decoration: none;
            text-align: center;
        }
        .d_late span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 20px;
            font-size: 12px;
            color: #ffffff;
            background-color: #ff7d00;
            text-decoration: none;
            text-align: center;
        }
        .d_absent span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 20px;
            font-size: 12px;
            color: #ffffff;
            background-color: red;
            text-decoration: none;
            text-align: center;
        }
        .d_no_data span {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 20px;
            font-size: 12px;
            color: #808080;
            background-color: #202020;
            text-decoration: none;
            text-align: center;
        }
        .d_day_head {
            display: inline-block;
            width: 75px;
            height: 50px;
            line-height: 50px;
            font-size: 14px;
            color: #ffffff;
            background-color: #404040;
            text-decoration: none;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/table.png" />ประวัติเวลาปฏิบัติงาน</div>
        <div class="ps-box" style="margin-top: 10px;">
            <div class="ps-box-i0">
                <div class="ps-box-hd10">
                    <asp:TextBox ID="tbYear" runat="server" CssClass="ps-textbox" placeHolder="ปี พ.ศ." style="width: 50px;"></asp:TextBox>
                    <asp:LinkButton ID="lbuSearchV2" runat="server" OnClick="lbuSearchV2_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                </div>
                <div class="ps-box-ct10">
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
