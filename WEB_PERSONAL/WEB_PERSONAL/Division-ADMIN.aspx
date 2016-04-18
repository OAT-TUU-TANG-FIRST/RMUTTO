<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Division-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Division_ADMIN" %>
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
        .center1 { 
               display:inline-block; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchDivision">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    รหัสกอง / สำนักงานเลขา / ภาควิชา :&nbsp<asp:TextBox ID="txtSearchDivisionID" runat="server" CssClass="tb5" Width="50px" MaxLength="4"></asp:TextBox>
                    ชื่อกอง / สำนักงานเลขา / ภาควิชา :&nbsp<asp:TextBox ID="txtSearchDivisionName" runat="server" CssClass="tb5" Width="150px" MaxLength="100"></asp:TextBox>
                    รหัสวิทยาเขต :&nbsp<asp:TextBox ID="txtSearchCampusID" runat="server" CssClass="tb5" Width="50px" MaxLength="2"></asp:TextBox>
                    รหัสสำนัก / สถาบัน / คณะ :&nbsp<asp:TextBox ID="txtSearchFacultyID" runat="server" CssClass="tb5" Width="50px" MaxLength="4"></asp:TextBox>
                    <asp:Button ID="btnSearchDivision" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchDivision_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitDivision">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสกอง / สำนักงานเลขา / ภาควิชา :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertDivisionID" runat="server" CssClass="tb5" MaxLength="4" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกอง / สำนักงานเลขา / ภาควิชา :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertDivisionName" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสวิทยาเขต :</td>
                            <td style="text-align: left; width: 40px;">
                                <asp:TextBox ID="txtInsertCampusID" runat="server" CssClass="tb5" MaxLength="2" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสสำนัก / สถาบัน / คณะ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertFacultyID" runat="server" CssClass="tb5" MaxLength="4" Width="50px"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitDivision" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitDivision_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelDivision" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelDivision_Click" /></td>
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
                            DataKeyNames="DIVISION_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewDivision_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสกอง / สำนักงานเลขา / ภาควิชา" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivisionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDivisionIDEdit" Enabled="false" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกอง / สำนักงานเลขา / ภาควิชา" ControlStyle-Width="380" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivisionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDivisionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสวิทยาเขต" ControlStyle-Width="120" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCampusIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CAMPUS_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCampusIDEdit" MaxLength="2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CAMPUS_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสสำนัก / สถาบัน / คณะ" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFacultyIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FACULTY_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFacultyIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FACULTY_ID") %>'></asp:TextBox>
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