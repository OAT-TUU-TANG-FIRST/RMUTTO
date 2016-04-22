<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Staff-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Staff_ADMIN" %>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchStaff">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    รหัสตำแหน่งประเภท :&nbsp<asp:TextBox ID="txtSearchStaffID" runat="server" CssClass="tb5" Width="230px" MaxLength="4"></asp:TextBox>
                    ชื่อตำแหน่งประเภท :&nbsp<asp:TextBox ID="txtSearchStaffName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchStaff" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchStaff_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitStaff">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 55px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสตำแหน่งประเภท :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertStaffID" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำแหน่งประเภท :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertStaffName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitStaff" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitStaff_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelStaff" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelStaff_Click" /></td>
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
                            DataKeyNames="ST_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewSTAFF_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสตำแหน่งประเภท" ControlStyle-Width="230" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtStaffIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อตำแหน่งประเภท" ControlStyle-Width="600" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                      <ItemTemplate>
                                        <asp:Label ID="lblStaffNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtStaffNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_NAME") %>'></asp:TextBox>
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
