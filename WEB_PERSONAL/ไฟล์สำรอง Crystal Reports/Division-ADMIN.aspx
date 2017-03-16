<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Division-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Division_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }

        .center1 {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" DefaultButton="lbuSearch">
        <div>
            <div class="ps-header">
                <img src="Image/Small/search.png" />ค้นหาข้อมูล
            </div>
            <div>
                ชื่อกอง / สำนักงานเลขา / ภาควิชา :&nbsp<asp:TextBox ID="txtSearchDivisionName" runat="server" CssClass="ps-textbox" Width="150px" MaxLength="100"></asp:TextBox>
                วิทยาเขต :&nbsp<asp:DropDownList ID="ddlSearchCampus" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList>
                สำนัก / สถาบัน / คณะ :&nbsp<asp:DropDownList ID="ddlSearchFaculty" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList>
                <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" DefaultButton="lbuSubmit">
        <div>
            <div class="ps-header">
                <img src="Image/Small/Add.png" />เพิ่มข้อมูล
            </div>
            <div>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกอง / สำนักงานเลขา / ภาควิชา :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertDivisionName" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">วิทยาเขต :</td>
                        <td style="text-align: left; width: 40px;">
                            <asp:DropDownList ID="ddlInsertCampus" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">สำนัก / สถาบัน / คณะ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertFaculty" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuSubmit" runat="server" OnClick="lbuSubmit_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>ตกลง</asp:LinkButton></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuCancel" runat="server" OnClick="lbuCancel_Click" CssClass="ps-button"><img src="Image/Small/cancel.png" class="icon_left"/>ยกเลิก</asp:LinkButton></td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <div class="ps-header">
                <img src="Image/Small/list.png" />ข้อมูล
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="DIVISION_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewDivision_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสกอง / สำนักงานเลขา / ภาควิชา" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblDivisionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อกอง / สำนักงานเลขา / ภาควิชา" ControlStyle-Width="380">
                                <ItemTemplate>
                                    <asp:Label ID="lblDivisionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDivisionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วิทยาเขต" ControlStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="lblCampusIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CAMPUS_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCampusIDEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สำนัก / สถาบัน / คณะ" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblFacultyIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FACULTY_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlFacultyIDEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" />
                            <asp:TemplateField HeaderText="ลบ">
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
        </div>
    </asp:Panel>
</asp:Content>