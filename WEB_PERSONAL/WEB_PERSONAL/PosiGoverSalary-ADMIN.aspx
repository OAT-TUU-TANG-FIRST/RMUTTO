<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PosiGoverSalary-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.PosiGoverSalary_ADMIN" %>
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
                ตำแหน่งประเภท :&nbsp<asp:DropDownList ID="ddlSearchPosiGroup" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList>
                ตำแหน่ง :&nbsp<asp:DropDownList ID="ddlSearchPosi" runat="server" CssClass="ps-textbox" Width="150px"></asp:DropDownList>
                เงินเดือนขั้นต่ำ :&nbsp<asp:TextBox ID="txtSearchSalMin" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox>
                เงินเดือนขั้นสูง :&nbsp<asp:TextBox ID="txtSearchSalMax" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox>
                เงินเดือนขั้นต่ำชั่วคราว :&nbsp<asp:TextBox ID="txtSearchSalMinTemp" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ตำแหน่งประเภท :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="ddlInsertPosiGroup" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ตำแหน่ง :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="ddlInsertPosi" runat="server" CssClass="ps-textbox" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertSalMin" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำสูง :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertSalMax" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำชั่่วคราว :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertSalMinTemp" runat="server" CssClass="ps-textbox" Width="150px"></asp:TextBox></td>
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
                        DataKeyNames="P_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewPosiGoverSalary_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="ID" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่งกลุ่ม" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryGroupEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_POS_GOVER_ACADEMIC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPosiGoverSalaryGroupEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_POS_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPosiGoverSalaryEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินเดือนขั้นต่ำ" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryMinEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPosiGoverSalaryMinEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินเดือนขั้นสูง" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryMaxEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MAX") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPosiGoverSalaryMaxEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MAX") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินเดือนขั้นต่ำชั่วคราว" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiGoverSalaryMinTempEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN_TEMP") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPosiGoverSalaryMinTempEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN_TEMP") %>'></asp:TextBox>
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