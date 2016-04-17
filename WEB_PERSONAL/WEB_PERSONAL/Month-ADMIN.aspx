<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Month-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Month_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
            background-image: url("Image/444.png");
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
            width: 230px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchMonth">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    รหัสเดือน :&nbsp<asp:TextBox ID="txtSearchMonthID" runat="server" CssClass="tb5" Width="80px" MaxLength="4"></asp:TextBox>
                    ชื่อเดือนย่อ :&nbsp<asp:TextBox ID="txtSearchMonthNameSmall" runat="server" CssClass="tb5" Width="100px" MaxLength="10"></asp:TextBox>
                    ชื่อเดือนเต็ม :&nbsp<asp:TextBox ID="txtSearchMonthNameFull" runat="server" CssClass="tb5" Width="200px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchMonth" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchMonth_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" ScrollBars="Horizontal" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitMonth">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสเดือน :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertMonthID" runat="server" CssClass="tb5" MaxLength="4" Width="80px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อเดือนย่อ :</td>
                            <td style="text-align: left; width: 100px;">
                                <asp:TextBox ID="txtInsertMonthNameSmall" runat="server" CssClass="tb5" MaxLength="10" Width="100px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อเดือนเต็ม :</td>
                            <td style="text-align: left; width: 100px;">
                                <asp:TextBox ID="txtInsertMonthNameFull" runat="server" CssClass="tb5" MaxLength="100" Width="200px"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitMonth" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitMonth_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelMonth" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelMonth_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>ข้อมูล</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="MONTH_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewMonth_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสศาสนา" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMonthIDEdit" Enabled="false" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อเดือนย่อ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthNameSmallEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_SHORT") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMonthNameSmallEdit" MaxLength="10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_SHORT") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อเดือนเต็ม" ControlStyle-Width="500" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthNameFullEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_LONG") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMonthNameFullEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MONTH_LONG") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                    </Triggers>
                </asp:UpdatePanel>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
