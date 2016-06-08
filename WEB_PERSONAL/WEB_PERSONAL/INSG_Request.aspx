<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Request.aspx.cs" Inherits="WEB_PERSONAL.INSG_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .TMZ {
            font-family: tahoma;
            text-align: left;
            color: #9999ff;
            font-weight: 900;
        }

        .ui-datepicker {
            font-family: tahoma;
            text-align: center;
            color: dodgerblue;
        }

        fieldset {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: black;
            font-size: 90%;
            text-align: left;
        }

        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: left;
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 220px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }

        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .ps-button {
            display: inline-block;
            font-family: RB-Regular, Tahoma;
            font-weight: normal;
            font-size: 12px;
            text-decoration: none;
            padding: 3px 15px;
            border-radius: 4px;
            cursor: pointer;
            transition: color ease 0.25s, background-color ease 0.25s, border-color ease 0.25s;
            text-align: left;
            color: #000000;
            background-color: #ffffff;
            border: 1px solid #c0c0c0;
            border-top: 1px solid #d0d0d0;
            border-bottom: 1px solid #b0b0b0;
            padding: 3px 15px;
            border-collapse: collapse;
        }
        .center1 { 
            text-align:center; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/medal.png" />ขอเครื่องราช
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div>
                    รายชื่อเครื่องราชอิสริยาภรณ์
                    <asp:DropDownList ID="ddlInsg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInsg_SelectedIndexChanged" CssClass="ps-dropdown"></asp:DropDownList>
                </div>
                <div class="ps-separator"></div>
                <div id="srd" runat="server">
                </div>
                <div style="height: 20px;"></div>
                <asp:LinkButton ID="lbuWant" runat="server" CssClass="ps-button" Visible="false" OnClick="lbuWant_Click"><img src="Image/Small/medal.png" class="icon_left"/>ขอเครื่องราช</asp:LinkButton>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend class="TMZ">ข้อมูลการขอเครื่องราชอิสริยาภรณ์</legend>
                    <div style="display: inline-block; margin-right: 20px;" class="ps-ms-main-hd-left">
                        <table>
                            <tr>
                                <td class="col1">เลขประจำตัวประชาชน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbCitizen" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbCitizen" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbCitizen" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbName" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbName" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbName" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วัน/เดือน/ปีที่เริ่มรับราชการ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbDateInwork" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbDateInwork" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbDateInwork" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อตำแหน่งปัจจุบัน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbPositionCurrent" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbPositionCurrent" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbPositionCurrent" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินเดือนป้จจุบัน</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSalaryCurrent" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbSalaryCurrent" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbSalaryCurrent" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block; margin-right: 50px;">
                        <table>
                            <tr>
                                <td class="col1">ยศ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbRank" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbRank" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbRank" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbLastName" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbLastName" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbLastName" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งเริ่มรับราชกาาร</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbPosition" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbPosition" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbPosition" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภท</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbType" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbType" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbType" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินประจำตำแหน่ง</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbSalaryPosition" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbSalaryPosition" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbSalaryPosition" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left; display: inline-block;">
                        <table>
                            <tr>
                                <td class="col1">คำนำหน้าชื่อ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbTitleName" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbTitleName" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbTitleName" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วัน/เดือน/ปีเกิด</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbBirthDate" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbBirthDate" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbBirthDate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับที่เริ่มรับราชกาาร</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbBirthDate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับ</td>
                                <td class="col2">
                                    <asp:UpdatePanel ID="UpdatetbDegree" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="tbDegree" runat="server" CssClass="tb5"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="tbDegree" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both;" class="center1">
                            <asp:LinkButton ID="lbuCancleView2" runat="server" CssClass="ps-button" OnClick="lbuCancleView2_Click"><img src="Image/Small/delete.png" class="icon_left"/>ยกเลิก</asp:LinkButton>
                            <asp:LinkButton ID="lbuSubmitView2" runat="server" CssClass="ps-button" OnClick="lbuSubmitView2_Click"><img src="Image/Small/correct.png" class="icon_left"/>ยืนยันการขอเครื่องราชอิสริยาภรณ์</asp:LinkButton>
                        </div>
                </fieldset>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
