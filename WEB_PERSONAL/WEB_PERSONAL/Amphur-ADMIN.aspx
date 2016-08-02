<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Amphur-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Amphur_ADMIN" %>
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
                ชื่ออำเภอภาษาไทย :&nbsp<asp:TextBox ID="txtSearchAmphurTH" runat="server" CssClass="ps-textbox" Width="150px" MaxLength="100"></asp:TextBox>
                ชื่ออำเภอภาษาอังกฤษ :&nbsp<asp:TextBox ID="txtSearchAmphurEN" runat="server" CssClass="ps-textbox" Width="150px" MaxLength="100"></asp:TextBox>
                จังหวัด :&nbsp<asp:DropDownList ID="ddlSearchProvince" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่ออำเภอภาษาไทย :</td>
                        <td style="text-align: left; width: 90px;">
                            <asp:TextBox ID="txtInsertAmphurTH" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่ออำเภอภาษาอังกฤษ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtInsertAmphurEN" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">จังหวัด :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertProvince" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
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
                        DataKeyNames="AMPHUR_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewAmphur_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสอำเภอ" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmphurIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่ออำเภอภาษาไทย" ControlStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmphurTHEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_TH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmphurTHEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_TH") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่ออำเภอภาษาอังกฤษ" ControlStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmphurENEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_EN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmphurENEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_EN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="จังหวัด" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblProvinceIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PROVINCE_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlProvinceIDEdit" runat="server"></asp:DropDownList>
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