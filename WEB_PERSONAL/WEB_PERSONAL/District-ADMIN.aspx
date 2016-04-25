<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="District-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.District_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
            color: blue;
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSearchDistrict">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                            <td style="text-align: left; width: 90px;">
                                <asp:TextBox ID="txtSearchDistrictTH" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtSearchDistrictEN" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td> 
                        </tr>
                    </table>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">อำเภอ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:DropDownList ID="ddlSearchAmphur" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">จังหวัด :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:DropDownList ID="ddlSearchProvince" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสไปรษณีย์ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtSearchPostCode" runat="server" CssClass="tb5" MaxLength="5" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">บันทึกข้อความ :</td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox ID="txtSearchNote" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>

                            <td style="text-align: left;">
                                <asp:Button ID="btnSearchDistrict" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchDistrict_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSubmitDistrict">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                            <td style="text-align: left; width: 90px;">
                                <asp:TextBox ID="txtInsertDistrictTH" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtInsertDistrictEN" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            
                        </tr>
                    </table>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">อำเภอ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:DropDownList ID="ddlInsertAmphur" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">จังหวัด :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:DropDownList ID="ddlInsertProvince" runat="server" CssClass="tb5" Width="150px"></asp:DropDownList></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสไปรษณีย์ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertPostCode" runat="server" CssClass="tb5" MaxLength="5" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">บันทึกข้อความ :</td>
                            <td style="text-align: left; width: 150px;">
                                <asp:TextBox ID="txtInsertNote" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>

                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitDistrict" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitDistrict_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelDistrict" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelDistrict_Click" /></td>
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
                            DataKeyNames="DISTRICT_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewDistrict_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="รหัสตำบล" ControlStyle-Width="50" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อตำบลภาษาไทย" ControlStyle-Width="130" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictTHEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDistrictTHEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อตำบลภาษาอังกฤษ" ControlStyle-Width="130" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictENEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDistrictENEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="อำเภอ" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmphurIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlAmphurIDEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="จังหวัด" ControlStyle-Width="100" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProvinceIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PROVINCE_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlProvinceIDEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสไปรษณีย์" ControlStyle-Width="50" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostCodeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPostCodeEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="บันทึกข้อความ" ControlStyle-Width="150" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoteEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNoteEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:TextBox>
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
