<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="District-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.District_ADMIN" %>
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
            width: 130px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchDistrict">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 150px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสตำบล :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtSearchDistrictID" runat="server" CssClass="tb5" MaxLength="4" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                            <td style="text-align: left; width: 90px;">
                                <asp:TextBox ID="txtSearchDistrictTH" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtSearchDistrictEN" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 100px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสอำเภอ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtSearchAmphurID" runat="server" CssClass="tb5" MaxLength="3" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสจังหวัด :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtSearchProvinceID" runat="server" CssClass="tb5" MaxLength="2" Width="50px"></asp:TextBox></td>
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
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitDistrict">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 150px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสตำบล :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertDistrictID" runat="server" CssClass="tb5" MaxLength="4" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาไทย :</td>
                            <td style="text-align: left; width: 90px;">
                                <asp:TextBox ID="txtInsertDistrictTH" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำบลภาษาอังกฤษ :</td>
                            <td style="text-align: left; width: 80px;">
                                <asp:TextBox ID="txtInsertDistrictEN" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                            
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 100px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสอำเภอ :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertAmphurID" runat="server" CssClass="tb5" MaxLength="3" Width="50px"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสจังหวัด :</td>
                            <td style="text-align: left; width: 50px;">
                                <asp:TextBox ID="txtInsertProvinceID" runat="server" CssClass="tb5" MaxLength="2" Width="50px"></asp:TextBox></td>
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
                                <asp:TemplateField HeaderText="รหัสตำบล" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDistrictIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อตำบลภาษาไทย" ControlStyle-Width="200" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictTHEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDistrictTHEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_TH") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อตำบลภาษาอังกฤษ" ControlStyle-Width="200" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrictENEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDistrictENEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DISTRICT_EN") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสอำเภอ" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmphurIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAmphurIDEdit" MaxLength="3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMPHUR_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสจังหวัด" ControlStyle-Width="50" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProvinceIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PROVINCE_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProvinceIDEdit" MaxLength="2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PROVINCE_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสไปรษณีย์" ControlStyle-Width="70" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostCodeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPostCodeEdit" MaxLength="5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POST_CODE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="บันทึกข้อความ" ControlStyle-Width="200" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoteEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNoteEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTE") %>'></asp:TextBox>
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
