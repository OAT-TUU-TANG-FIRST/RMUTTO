<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GradeInsignia-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.GradeInsignia_ADMIN" %>
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
                ชื่อเครื่องราชฯ :&nbsp<asp:TextBox ID="txtSearchGradeInsigName" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="100"></asp:TextBox>
                ชื่อย่อเครื่องราชฯ :&nbsp<asp:TextBox ID="txtSearchGradeInsigNameSmall" runat="server" CssClass="ps-textbox" Width="100px" MaxLength="10"></asp:TextBox>
                ชื่อกลุ่มเครื่องราชฯ :&nbsp<asp:DropDownList ID="ddlSearchClanInsig" runat="server" CssClass="ps-dropdown" Width="250px"></asp:DropDownList>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อเครื่องราชฯ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertGradeInsigName" runat="server" CssClass="ps-textbox" MaxLength="100" Width="230px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อย่อเครื่องราชฯ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertGradeInsigNameSmall" runat="server" CssClass="ps-textbox" MaxLength="10" Width="100px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกลุ่มเครื่องราชฯ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="ddlInsertClanInsig" runat="server" CssClass="ps-dropdown" Width="250px"></asp:DropDownList></td>
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
                        DataKeyNames="ID_GRADEINSIGNIA"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewGradeInsig_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัส" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblGradeInsigIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID_GRADEINSIGNIA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อเครื่องราชฯ" ControlStyle-Width="380">
                                <ItemTemplate>
                                    <asp:Label ID="lblGradeInsigNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME_GRADEINSIGNIA_THA") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGradeInsigNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME_GRADEINSIGNIA_THA") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อย่อเครื่องราชฯ" ControlStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblGradeInsigNameSmallEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ABBREVIATIONS_THA") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGradeInsigNameSmallEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ABBREVIATIONS_THA") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อกลุ่มเครื่องราชฯ" ControlStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="lblClanInsigIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID_CLANINSIGNIA") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlClanInsigIDEdit" runat="server" Width="250px"></asp:DropDownList>
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