<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Department-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Department_ADMIN" %>

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
            width: 130px;
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchDepartment">
        <div>
            <fieldset>
                <legend>Search</legend>
                <div>
                    รหัสคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า :&nbsp<asp:TextBox ID="txtSearchDepartmentID" runat="server" CssClass="tb5" Width="130px" MaxLength="5"></asp:TextBox>
                    ชื่อคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า :&nbsp<asp:TextBox ID="txtSearchDepartmentName" runat="server" CssClass="tb5" Width="130px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchDepartment" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchDepartment_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitDepartment">
        <div>
            <fieldset>
                <legend>Insert</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 20px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertDepartmentID" runat="server" CssClass="tb5" MaxLength="5"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า :</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertDepartmentName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitDepartment" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitDepartment_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelDepartment" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelDepartment_Click" /></td>
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
                            AllowPaging="true"
                            DataKeyNames="DEPARTMENT_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewDepartment_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า" ControlStyle-Width="230" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartmentIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDepartmentIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT_ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ControlStyle Width="230px" />
                                    <HeaderStyle BackColor="#0099FF" ForeColor="Aqua" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อคณะ/หน่วยงานที่สังกัด หรือเทียบเท่า" ControlStyle-Width="600" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartmentNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDepartmentNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT_NAME") %>'></asp:TextBox>
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
