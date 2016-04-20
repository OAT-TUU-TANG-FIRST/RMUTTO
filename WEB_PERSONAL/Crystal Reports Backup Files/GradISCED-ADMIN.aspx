<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GradISCED-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.GradISCED_ADMIN" %>
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
            width: 230px;
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchGradISCED">
        <div>
            <fieldset> 
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    รหัสกลุ่มสาขาวิชาที่จบสูงสุด :&nbsp;<asp:TextBox ID="txtSearchGradISCEDID" runat="server" CssClass="tb5" Width="50px" MaxLength="4"></asp:TextBox>
                    ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(TH) :&nbsp;<asp:TextBox ID="txtSearchGradISCEDNameTh" runat="server" CssClass="tb5" Width="115px" MaxLength="100"></asp:TextBox>
                    ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(ENG) :&nbsp;<asp:TextBox ID="txtSearchGradISCEDNameEng" runat="server" CssClass="tb5" Width="115px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchGradISCED" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchGradISCED_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitGradISCED">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div> 
                    <table>
                        <tr>
                            <td style="text-align: left; width: 33px"></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสกลุ่มสาขาวิชาที่จบสูงสุด :</td>
                            <td style="text-align: left; width: 20px;">
                                <asp:TextBox ID="txtInsertGradISCEDID" Width="50px" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(TH) :</td>
                            <td style="text-align: left; width: 20px;">
                                <asp:TextBox ID="txtInsertGradISCEDNameTh" Width="115px" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(ENG) :</td>
                            <td style="text-align: left; width: 20px;">
                                <asp:TextBox ID="txtInsertGradISCEDNameEng" Width="115px" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitGradISCED" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitGradISCED_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelGradISCED" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelGradISCED_Click" /></td>
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
                            DataKeyNames="GRAD_ISCED_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewGradISCED_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField HeaderText="รหัสกลุ่มสาขาวิชาที่จบสูงสุด" ControlStyle-Width="100" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGradISCEDIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGradISCEDIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_ID") %>' Enabled="False"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(TH)" ControlStyle-Width="350" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                      <ItemTemplate>
                                        <asp:Label ID="lblGradISCEDNameThEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_NAME_THAI") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGradISCEDNameThEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_NAME_THAI") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกลุ่มสาขาวิชาที่จบสูงสุด(ENG)" ControlStyle-Width="350" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                                      <ItemTemplate>
                                        <asp:Label ID="lblGradISCEDNameEngEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_NAME_ENG") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGradISCEDNameEngEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRAD_ISCED_NAME_ENG") %>'></asp:TextBox>
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
