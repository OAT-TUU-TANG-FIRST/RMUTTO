<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GradeInsignia-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.GradeInsignia_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }
        div{
            color:#003380;
        }
        .panin {
            border: 1px solid black;
            margin: 20px;
            background-color: rgba(255,255,255,0.6);
            border-radius: 5px;
        }

        body {
            background-color : white;
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 150px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
            
        }
        .center1 { 
               display:inline-block; 
        }
        legend{
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
            text-align: center;
            font-size:medium;
            color:royalblue;
        }
        fieldset{
            border: 3px solid #99e6ff;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSearchGradeInsig">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    ชื่อเครื่องราชฯ :&nbsp<asp:TextBox ID="txtSearchGradeInsigName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                    ชื่อย่อเครื่องราชฯ :&nbsp<asp:TextBox ID="txtSearchGradeInsigNameSmall" runat="server" CssClass="tb5" Width="100px" MaxLength="10"></asp:TextBox>
                    ชื่อกลุ่มเครื่องราชฯ :&nbsp<asp:DropDownList ID="ddlSearchClanInsig" runat="server" CssClass="tb5" Width="250px"></asp:DropDownList>
                    <asp:Button ID="btnSearchGradeInsig" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchGradeInsig_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSubmitGradeInsig">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อเครื่องราชฯ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertGradeInsigName" runat="server" CssClass="tb5" MaxLength="100" Width="230px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อย่อเครื่องราชฯ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertGradeInsigNameSmall" runat="server" CssClass="tb5" MaxLength="10" Width="100px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกลุ่มเครื่องราชฯ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:DropDownList ID="ddlInsertClanInsig" runat="server" CssClass="tb5" Width="250px"></asp:DropDownList></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitGradeInsig" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitGradeInsig_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelGradeInsig" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelGradeInsig_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>ข้อมูล</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="ID_GRADEINSIGNIA"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewGradeInsig_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="รหัส" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGradeInsigIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID_GRADEINSIGNIA") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อเครื่องราชฯ" ControlStyle-Width="380" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGradeInsigNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME_GRADEINSIGNIA_THA") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGradeInsigNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME_GRADEINSIGNIA_THA") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อย่อเครื่องราชฯ" ControlStyle-Width="150" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGradeInsigNameSmallEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ABBREVIATIONS_THA") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGradeInsigNameSmallEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ABBREVIATIONS_THA") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกลุ่มเครื่องราชฯ" ControlStyle-Width="120" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClanInsigIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID_CLANINSIGNIA") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlClanInsigIDEdit" runat="server" Width="250px"></asp:DropDownList>
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