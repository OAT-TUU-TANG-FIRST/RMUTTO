<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Permanent-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Permanent_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }

        .panin {
            border: 1px solid black;
            margin: 20px;
            background-color: rgba(255,255,255,0.6);
            border-radius: 5px;
        }

        body {
            background-image: url("Image/444.png");
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
            width: 100px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchPermaPosition">
        <div>
            <fieldset>
                <legend>Search</legend>
                <div>
                    รหัสระดับลูกจ้างประจำ  :&nbsp<asp:TextBox ID="txtSearchPermaPositionID" runat="server" CssClass="tb5" Width="100px" MaxLength="4"></asp:TextBox>
                    ชื่อระดับลูกจ้างประจำ   :&nbsp<asp:TextBox ID="txtSearchPermaPositionName" runat="server" CssClass="tb5" Width="170px" MaxLength="100"></asp:TextBox>
                    รหัสตำแหน่งประเภท  :&nbsp<asp:TextBox ID="txtSearchSubStaffID" runat="server" CssClass="tb5" Width="100px" MaxLength="4"></asp:TextBox>
                    <asp:Button ID="btnSearchPermaPosition" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPermaPosition_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitPermaPosition">
        <div>
            <fieldset>
                <legend>Insert</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสระดับลูกจ้างประจำ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtInsertPermaPositionID" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อระดับลูกจ้างประจำ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtInsertPermaPositionName" Width="170px" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสตำแหน่งประเภท :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtInsertSubStaffID" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitPermaPosition" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitPermaPosition_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelPermaPosition" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelPermaPosition_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>Data</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewPermaPosition_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสระดับลูกจ้างประจำ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPermaPositionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPermaPositionIDEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อระดับลูกจ้างประจำ" ControlStyle-Width="500" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPermaPositionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPermaPositionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสตำแหน่งประเภท" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubStaffIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSubStaffIDEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ST_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua" />
                                <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
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
