<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TeachISCED-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.TeachISCED_ADMIN" %>

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
            width: 150px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }

        .tb6 {
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchTeachISCED">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 70px;"></td>
                            <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอน :&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtSearchISCED_ID" runat="server" CssClass="tb5" MaxLength="8"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอนเก่า :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSearchISCED_ID_OLD" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="text-align: left;">
                            <asp:Button ID="btnSearchTeachISCED" Text="Search" runat="server" CssClass="master_OAT_button" OnClick = "btnSearchTeachISCED_Click" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย :&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtSearchISCED_NAME_TH" runat="server" CssClass="tb5" MaxLength="250"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSearchISCED_NAME_ENG" runat="server" CssClass="tb5" MaxLength="250"></asp:TextBox></td>
                            <td style="text-align: left;">
                            <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick = "btnSearchRefresh_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitTeachISCED">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table>
                        <tr>
                            <td style="text-align: left; width: 70px;"></td>
                            <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอน :&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertISCED_ID" runat="server" CssClass="tb5" MaxLength="8"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 30px;"></td>
                            <td style="text-align: right; margin-right: 5px;">รหัสกลุ่มสาขาวิชาที่สอนเก่า :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtInsertISCED_ID_OLD" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                             <td style="text-align: left;">
                             <asp:Button ID="btnSubmitTeachISCED" Text="OK" runat="server" CssClass="master_OAT_button" OnClick = "btnSubmitTeachISCED_Click" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย :&nbsp;</td>
                            <td style="text-align: left; width: 120px;">
                                <asp:TextBox ID="txtInsertISCED_NAME_TH" runat="server" CssClass="tb5" MaxLength="250"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 10px;"></td>
                            <td style="text-align: right; margin-right: 5px;">ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ :&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtInsertISCED_NAME_ENG" runat="server" CssClass="tb5" MaxLength="250"></asp:TextBox></td>
                            <td style="text-align: left;">
                             <asp:Button ID="btnCancelTeachISCED" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick = "btnCancelTeachISCED_Click" /></td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div>
            <fieldset>
                <legend>ข้อมูล</legend>
                
                        <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center; width: 100%"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewTeachISCED_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeachISCEDseqEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="รหัสกลุ่มสาขาวิชาที่สอน" ControlStyle-Width="70" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeachISCEDIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTeachISCEDIDEdit" MaxLength="8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="รหัสกลุ่มสาขาวิชาที่สอนเก่า" ControlStyle-Width="40" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeachISCEDidOldEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID_OLD") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTeachISCEDidOldEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_ID_OLD") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย" ControlStyle-Width="400" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeachISCEDThaiEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_TH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTeachISCEDThaiEdit" MaxLength="250" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_TH") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ" ControlStyle-Width="300" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeachISCEDEnglishEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_ENG") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtTeachISCEDEnglishEdit" MaxLength="250" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TEACH_ISCED_NAME_ENG") %>'></asp:TextBox>
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
                    
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
