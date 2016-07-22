<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WorkDivision-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.WorkDivision_ADMIN" %>
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
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่องาน / ฝ่าย :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtSearchWorkDivisionName" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">วิทยาเขต :</td>
                        <td style="text-align: left; width: 40px;">
                            <asp:DropDownList ID="ddlSearchCampus" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">สำนัก / สถาบัน / คณะ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlSearchFaculty" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">กอง / สำนักงานเลขา / ภาควิชา :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlSearchDivision" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton></td>
                    </tr>
                </table>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่องาน / ฝ่าย :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertWorkDivisionName" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">วิทยาเขต :</td>
                        <td style="text-align: left; width: 40px;">
                            <asp:DropDownList ID="ddlInsertCampus" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">สำนัก / สถาบัน / คณะ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertFaculty" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">กอง / สำนักงานเลขา / ภาควิชา :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertDivision" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
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
                        DataKeyNames="WORK_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewWorkDivision_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสงาน / ฝ่าย" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkDivisionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WORK_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่องาน / ฝ่าย" ControlStyle-Width="380">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkDivisionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WORK_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWorkDivisionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WORK_NAME") %>'></asp:TextBox>
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
                            <asp:TemplateField HeaderText="กอง / สำนักงานเลขา / ภาควิชา" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblDivisionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DIVISION_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDivisionIDEdit" runat="server"></asp:DropDownList>
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