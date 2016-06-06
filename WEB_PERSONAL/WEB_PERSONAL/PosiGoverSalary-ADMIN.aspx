<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PosiGoverSalary-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.PosiGoverSalary_ADMIN" %>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSearchPosiGoverSalary">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    ตำแหน่งกลุ่ม :&nbsp<asp:DropDownList ID="ddlSearchPosiGroup" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList>
                    ตำแหน่ง :&nbsp<asp:DropDownList ID="ddlSearchPosi" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList>
                    เงินเดือนขั้นต่ำ :&nbsp<asp:TextBox ID="txtSearchSalMin" runat="server" CssClass="tb5" Width="150px"></asp:TextBox>
                    เงินเดือนขั้นสูง :&nbsp<asp:TextBox ID="txtSearchSalMax" runat="server" CssClass="tb5" Width="150px"></asp:TextBox>
                    เงินเดือนขั้นต่ำชั่วคราว :&nbsp<asp:TextBox ID="txtSearchSalMinTemp" runat="server" CssClass="tb5" Width="150px"></asp:TextBox>
                    <asp:Button ID="btnSearchPosiGoverSalary" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchPosiGoverSalary_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSubmitPosiGoverSalary">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ตำแหน่งกลุ่ม :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:DropDownList ID="ddlInsertPosiGroup" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ตำแหน่ง :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:DropDownList ID="ddlInsertPosi" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertSalMin" runat="server" CssClass="tb5" Width="150px"></asp:TextBox></td>
                             <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำสูง :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertSalMax" runat="server" CssClass="tb5" Width="150px"></asp:TextBox></td>
                             <td style="margin-left: auto; margin-right: auto; text-align: center">เงินเดือนขั้นต่ำชั่่วคราว :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertSalMinTemp" runat="server" CssClass="tb5" Width="150px"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitPosiGoverSalary" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitPosiGoverSalary_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelPosiGoverSalary" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelPosiGoverSalary_Click" /></td>
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
                            DataKeyNames="P_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewPosiGoverSalary_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="ID" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ตำแหน่งกลุ่ม" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryGroupEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_POS_GOVER_ACADEMIC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPosiGoverSalaryGroupEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_POS_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPosiGoverSalaryEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เงินเดือนขั้นต่ำ" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryMinEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPosiGoverSalaryMinEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เงินเดือนขั้นสูง" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryMaxEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MAX") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPosiGoverSalaryMaxEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MAX") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="เงินเดือนขั้นต่ำชั่วคราว" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosiGoverSalaryMinTempEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN_TEMP") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPosiGoverSalaryMinTempEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.P_SAL_MIN_TEMP") %>'></asp:TextBox>
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