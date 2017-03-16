<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Rank-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Rank_ADMIN" %>
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
                ชื่อยศเต็ม :&nbsp<asp:TextBox ID="txtSearchRankNameFull" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="100"></asp:TextBox>
                ชื่อย่อ :&nbsp<asp:TextBox ID="txtSearchRankNameSmall" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="20"></asp:TextBox>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อยศเต็ม :</td>
                        <td style="text-align: left; width: 100px;">
                            <asp:TextBox ID="txtInsertRankNameFull" runat="server" CssClass="ps-textbox" MaxLength="10" Width="230px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อยศย่อ :</td>
                        <td style="text-align: left; width: 100px;">
                            <asp:TextBox ID="txtInsertRankNameSmall" runat="server" CssClass="ps-textbox" MaxLength="100" Width="230px"></asp:TextBox></td>
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
                        DataKeyNames="RANK_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewRank_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสยศ" ControlStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblRankIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RANK_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อยศเต็ม" ControlStyle-Width="350">
                                <ItemTemplate>
                                    <asp:Label ID="lblRankNameFullEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RANK_NAME_TH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRankNameFullEdit" MaxLength="10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RANK_NAME_TH") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อยศย่อ" ControlStyle-Width="350">
                                <ItemTemplate>
                                    <asp:Label ID="lblRankNameSmallEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RANK_NAME_TH_MIN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRankNameSmallEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RANK_NAME_TH_MIN") %>'></asp:TextBox>
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