<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INSG_Qualified_Detail-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.INSG_Qualified_Detail_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .TMZ {
            font-family: tahoma;
            text-align: left;
            color: #9999ff;
            font-weight: 900;
        }

        .ui-datepicker {
            font-family: tahoma;
            text-align: center;
            color: dodgerblue;
        }

        fieldset {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: black;
            text-align: left;
        }

        legend {
            padding: 0.2em 0.5em;
            border: 3px solid #99e6ff;
            color: #99e6ff;
            font-size: 120%;
            text-align: left;
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 300px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
    </style>
        <script>
        function pageLoad(sender, args) {
            $('document').ready(function () {
                $(".date").datepicker($.datepicker.regional["th"]);
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel0" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato" DefaultButton="btnSearchPerson">
        <div>
            <fieldset>
                <legend class="TMZ">ค้นหา</legend>
                <div style="text-align: center">
                    เลขบัตรประจำตัวประชาชน 13 หลัก :&nbsp<asp:TextBox ID="txtSearchPersonID" runat="server" CssClass="tb5" Width="230px" MaxLength="13"></asp:TextBox>
                    <asp:Button ID="btnSearchPerson" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPerson_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="tomato">
        <div>
            <fieldset>
                <legend class="TMZ">ข้อมูล</legend>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="IUG_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewQDA_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="ID" ControlStyle-Width="1" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQDAIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสบัตรประชาชน" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCitizenEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_CITIZEN_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชั้นเครื่องราช" ControlStyle-Width="150" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNameInsigEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_INSIG_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlNameInsigEdit" runat="server" Width="150px"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่ได้รับเครื่องราช" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateGetInsigEdit" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "IUG_INSIG_DATE_GET")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDateGetInsigEdit" MaxLength="100" runat="server" CssClass="date" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "IUG_INSIG_DATE_GET")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")) %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="สถานะ" ControlStyle-Width="1" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPositionEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_POSITION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPositionEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เงินเดือน" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalaryEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_SALARY") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSalaryEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_SALARY") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เอกสารอ้างอิง" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_REF") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRefEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IUG_REF") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato" />
                                <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
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
            </fieldset>
        </div>
    </asp:Panel>

</asp:Content>
