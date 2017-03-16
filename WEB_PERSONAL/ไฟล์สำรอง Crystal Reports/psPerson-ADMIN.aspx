<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="psPerson-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.psPerson_ADMIN" %>
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
                ชื่อระดับ :&nbsp<asp:TextBox ID="txtSearchDegree" runat="server" CssClass="ps-textbox"></asp:TextBox>
                กลุ่มระดับ :&nbsp<asp:DropDownList ID="ddlSearchGroup" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                ตำแหน่งประเภท :&nbsp<asp:DropDownList ID="ddlSearchNameGroup" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                ประเภทของตำแหน่ง :&nbsp<asp:DropDownList ID="ddlSearchTypeName" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
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
                ชื่อระดับ :&nbsp<asp:TextBox ID="txtInsertDegree" runat="server" CssClass="ps-textbox"></asp:TextBox>
                กลุ่มระดับ :&nbsp<asp:DropDownList ID="ddlInsertGroup" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                ตำแหน่งประเภท :&nbsp<asp:DropDownList ID="ddlInsertNameGroup" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                ประเภทของตำแหน่ง :&nbsp<asp:DropDownList ID="ddlInsertTypeName" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                <asp:LinkButton ID="lbuSubmit" runat="server" OnClick="lbuSubmit_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>ตกลง</asp:LinkButton>
                <asp:LinkButton ID="lbuCancel" runat="server" OnClick="lbuCancel_Click" CssClass="ps-button"><img src="Image/Small/cancel.png" class="icon_left"/>ยกเลิก</asp:LinkButton>
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
                        OnPageIndexChanging="myGridViewpsPerson_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField Visible="false" HeaderText="รหัสpsPerson" ControlStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblpsPersonIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อระดับ" ControlStyle-Width="200">
                                <ItemTemplate>
                                    <asp:Label ID="lblpsPersonDegreeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtpsPersonDegreeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="กลุ่มระดับ" ControlStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="lblpsPersonGroupEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_GROUP") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlpsPersonGroupEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่งประเภท" ControlStyle-Width="200">
                                <ItemTemplate>
                                    <asp:Label ID="lblpsPersonNameGroupEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_NAMEGROUP") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlpsPersonNameGroupEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ประเภทของตำแหน่ง" ControlStyle-Width="200">
                                <ItemTemplate>
                                    <asp:Label ID="lblpsPersonTypeNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_TYPENAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlpsPersonTypeNameEdit" runat="server"></asp:DropDownList>
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