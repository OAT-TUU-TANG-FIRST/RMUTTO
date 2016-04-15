<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UNIVERSITY-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.UNIV_ADMIN" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchUniv">
        <div>
            <fieldset>
                <legend>Search</legend>
                <div>
                    รหัสมหาวิทยาลัย :&nbsp<asp:TextBox ID="txtSearchUnivID" runat="server" CssClass="tb5" Width="230px" MaxLength="5"></asp:TextBox>
                    ชื่อมหาวิทยาลัย :&nbsp<asp:TextBox ID="txtSearchUnivName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchUniv" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchUniv_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitUNIVERSITY">
        <div>
            <fieldset>
                <legend>Insert</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 80px;"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสมหาวิทยาลัย :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertUnivID" runat="server" CssClass="tb5" MaxLength="5"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อมหาวิทยาลัย :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertUnivName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitUNIVERSITY" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitUNIVERSITY_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelUNIVERSITY" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelUNIVERSITY_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>Data</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="True"
                            DataKeyNames="UNIV_SEQ"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewUNIVERSITY_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnivSEQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_SEQ") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสมหาวิทยาลัย" ControlStyle-Width="223" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnivIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUnivIDEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ControlStyle Width="223px" />
                                    <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อมหาวิทยาลัย" ControlStyle-Width="600" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnivNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUnivNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ControlStyle Width="600px" />
                                    <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
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
