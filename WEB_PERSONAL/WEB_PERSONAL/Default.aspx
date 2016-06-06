<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB_PERSONAL.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .complete_center {
            font-size: 16px;
        }

        /*.ps-box-il-ms {
            margin-right: 20px;
            margin-bottom: 20px;
            vertical-align: top;
        }*/
        .c1 {
            font-size: 64px;
            text-align: center;
            color: #a0a0a0;
            margin-top: 50px;
        }
        .c2 {
            font-size: 23px;
            color: #808080;
            margin-top: 50px;
            text-align: center;
        }
        .c2_2 {
            display: inline-block;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="c1">
            ยินดีต้อนรับสู่ระบบบุคลากร
        </div>
        <div class="c2">
            <div class="c2_2">
                <div>
                กดปุ่ม <img src="Image/x32/menu.png" /> เพื่อเลือกเมนูการใช้งาน
            </div>
            <div>
                กดปุ่ม <img src="Image/x32/notification.png" /> เพื่อดูสถานะการแจ้งเตือน
            </div>
            </div>
            
        </div>
        <div class="ps-separator" style="margin-top: 50px;"></div>
    </div>
</asp:Content>
