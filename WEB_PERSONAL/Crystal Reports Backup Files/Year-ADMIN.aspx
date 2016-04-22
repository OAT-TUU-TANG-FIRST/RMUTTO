<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Year-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Year_ADMIN" %>

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
            background-image: url("Image/444.jpg");
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchYear">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    ปีพุทธศักราช :&nbsp;<asp:TextBox ID="txtSearchTH" runat="server" CssClass="tb5" Width="230px" MaxLength="4"></asp:TextBox>
                    <asp:Button ID="btnSearchYear" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchYear_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitYEAR">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 260px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ปีพุทธศักราช :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtYearName" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitYEAR" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitYEAR_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelYEAR" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelYEAR_Click" /></td>
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
                            DataKeyNames="YEAR_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewYEAR_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="ปีพุทธศักราช" ControlStyle-Width="820" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYearNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtYearNameEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="False" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText=" " HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
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
