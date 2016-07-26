<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TeachISCED-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.TeachISCED_ADMIN" %>
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
                <table class="center1">
                    <tr>
                        <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอน :&nbsp;</td>
                        <td style="text-align: left; width: 120px;">
                            <asp:TextBox ID="txtSearchISCED_ID" runat="server" CssClass="ps-textbox" MaxLength="8"></asp:TextBox>
                        </td>
                        <td style="text-align: left; width: 30px;"></td>
                        <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอนเก่า :&nbsp;</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtSearchISCED_ID_OLD" runat="server" CssClass="ps-textbox" MaxLength="4"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย :&nbsp;</td>
                        <td style="text-align: left; width: 120px;">
                            <asp:TextBox ID="txtSearchISCED_NAME_TH" runat="server" CssClass="ps-textbox" MaxLength="250"></asp:TextBox>
                        </td>
                        <td style="text-align: left; width: 10px;"></td>
                        <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ :&nbsp;</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtSearchISCED_NAME_ENG" runat="server" CssClass="ps-textbox" MaxLength="250"></asp:TextBox></td>
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
                        <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอน :&nbsp;</td>
                        <td style="text-align: left; width: 120px;">
                            <asp:TextBox ID="txtInsertISCED_ID" runat="server" CssClass="ps-textbox" MaxLength="8"></asp:TextBox>
                        </td>
                        <td style="text-align: left; width: 30px;"></td>
                        <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอนเก่า :&nbsp;</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtInsertISCED_ID_OLD" runat="server" CssClass="ps-textbox" MaxLength="4"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย :&nbsp;</td>
                        <td style="text-align: left; width: 120px;">
                            <asp:TextBox ID="txtInsertISCED_NAME_TH" runat="server" CssClass="ps-textbox" MaxLength="250"></asp:TextBox>
                        </td>
                        <td style="text-align: left; width: 10px;"></td>
                        <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ :&nbsp;</td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtInsertISCED_NAME_ENG" runat="server" CssClass="ps-textbox" MaxLength="250"></asp:TextBox></td>
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
                        DataKeyNames="ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewTeachISCED_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachISCEDseqEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="รหัสกลุ่มสาขาวิชาที่สอน" ControlStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachISCEDIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTeachISCEDIDEdit" MaxLength="8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="รหัสกลุ่มสาขาวิชาที่สอนเก่า" ControlStyle-Width="40">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachISCEDidOldEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID_OLD") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTeachISCEDidOldEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID_OLD") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย" ControlStyle-Width="400">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachISCEDThaiEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_TH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTeachISCEDThaiEdit" MaxLength="250" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_TH") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ" ControlStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachISCEDEnglishEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_ENG") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTeachISCEDEnglishEdit" MaxLength="250" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_ENG") %>'></asp:TextBox>
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