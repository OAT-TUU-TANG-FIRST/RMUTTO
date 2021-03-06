﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="National-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.National_ADMIN" %>
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
                อักษรย่อสัญชาติ/เชื้อชาติ 2 ตัวอักษร:&nbsp<asp:TextBox ID="txtSearchNationID" runat="server" CssClass="ps-textbox" Width="50px" MaxLength="2"></asp:TextBox>
                ชื่อสัญชาติ/เชื้อชาติภาษาอังกฤษ :&nbsp<asp:TextBox ID="txtSearchNationENG" runat="server" CssClass="ps-textbox" Width="150px" MaxLength="100"></asp:TextBox>
                ชื่อสัญชาติ/เชื้อชาติภาษาไทย :&nbsp<asp:TextBox ID="txtSearchNationTHA" runat="server" CssClass="ps-textbox" Width="150px" MaxLength="100"></asp:TextBox>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">อักษรย่อสัญชาติ/เชื้อชาติ 2 ตัวอักษร :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertNationID" runat="server" CssClass="ps-textbox" MaxLength="2" Width="50px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อสัญชาติ/เชื้อชาติภาษาอังกฤษ :</td>
                        <td style="text-align: left; width: 90px;">
                            <asp:TextBox ID="txtInsertNationENG" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อสัญชาติ/เชื้อชาติภาษาไทย :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtInsertNationTHA" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
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
                        DataKeyNames="NATION_SEQ"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewNATIONAL_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblNationSEQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_SEQ") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อักษรย่อสัญชาติ/เชื้อชาติ 2 ตัวอักษร" ControlStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="lblNationIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNationIDEdit" MaxLength="2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อสัญชาติ/เชื้อชาติภาษาอังกฤษ" ControlStyle-Width="380">
                                <ItemTemplate>
                                    <asp:Label ID="lblNationENGEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ENG") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNationENGEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ENG") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อสัญชาติ/เชื้อชาติภาษาไทย" ControlStyle-Width="380">
                                <ItemTemplate>
                                    <asp:Label ID="lblNationTHAEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_THA") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNationTHAEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_THA") %>'></asp:TextBox>
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