﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Position-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.nent_ADMIN" %>
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
                รหัสระดับ   :&nbsp<asp:TextBox ID="txtSearchPositionID" runat="server" CssClass="ps-textbox" Width="130px" MaxLength="5"></asp:TextBox>
                ชื่อระดับ   :&nbsp<asp:TextBox ID="txtSearchPositionName" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="100"></asp:TextBox>
                ตำแหน่งประเภท  :&nbsp<asp:DropDownList ID="ddlSearchPositionSTID" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสระดับ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtInsertPositionID" Width="130px" runat="server" CssClass="ps-textbox" MaxLength="5"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อระดับ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtInsertPositionName" Width="230px" runat="server" CssClass="ps-textbox" MaxLength="100"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ตำแหน่งประเภท :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="ddlInsertPositionSTID" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
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
            <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="ID"
                OnRowEditing="modEditCommand"
                OnRowCancelingEdit="modCancelCommand"
                OnRowUpdating="modUpdateCommand"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewPosition_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                <Columns>
                    <asp:TemplateField HeaderText="รหัสระดับ" ControlStyle-Width="130">
                        <ItemTemplate>
                            <asp:Label ID="lblPositionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPositionIDEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อระดับ" ControlStyle-Width="500">
                        <ItemTemplate>
                            <asp:Label ID="lblPositionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPositionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblSubStaffIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlSTIDEdit" runat="server"></asp:DropDownList>
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
        </div>
    </asp:Panel>
</asp:Content>