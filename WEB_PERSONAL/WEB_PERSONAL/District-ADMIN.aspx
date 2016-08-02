<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="District-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.District_ADMIN" %>
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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                        <td style="text-align: left; width: 90px;">
                            <asp:TextBox ID="txtSearchDistrictTH" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtSearchDistrictEN" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">อำเภอ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlSearchAmphur" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">จังหวัด :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlSearchProvince" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสไปรษณีย์ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtSearchPostCode" runat="server" CssClass="ps-textbox" MaxLength="5" Width="50px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">บันทึกข้อความ :</td>
                        <td style="text-align: left; width: 150px;">
                            <asp:TextBox ID="txtSearchNote" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>

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
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                        <td style="text-align: left; width: 90px;">
                            <asp:TextBox ID="txtInsertDistrictTH" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtInsertDistrictEN" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>

                    </tr>
                </table>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">อำเภอ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertAmphur" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">จังหวัด :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:DropDownList ID="ddlInsertProvince" runat="server" CssClass="ps-dropdown" Width="150px"></asp:DropDownList></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสไปรษณีย์ :</td>
                        <td style="text-align: left; width: 50px;">
                            <asp:TextBox ID="txtInsertPostCode" runat="server" CssClass="ps-textbox" MaxLength="5" Width="50px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">บันทึกข้อความ :</td>
                        <td style="text-align: left; width: 150px;">
                            <asp:TextBox ID="txtInsertNote" runat="server" CssClass="ps-textbox" MaxLength="100" Width="150px"></asp:TextBox></td>

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
                        DataKeyNames="DISTRICT_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewDistrict_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสตำบล" ControlStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrictIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อตำบลภาษาไทย" ControlStyle-Width="130">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrictTHEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDistrictTHEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อตำบลภาษาอังกฤษ" ControlStyle-Width="130">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrictENEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDistrictENEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="อำเภอ" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmphurIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlAmphurIDEdit" runat="server"></asp:DropDownList>
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
                            <asp:TemplateField HeaderText="รหัสไปรษณีย์" ControlStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="lblPostCodeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPostCodeEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="บันทึกข้อความ" ControlStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoteEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNoteEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:TextBox>
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