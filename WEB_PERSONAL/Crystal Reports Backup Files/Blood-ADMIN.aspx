﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Blood-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.Blood_ADMIN" %>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSearchBlood">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    ชื่อกรุ๊ปเลือด :&nbsp<asp:TextBox ID="txtSearchBloodName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchBlood" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchBlood_Click" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Tomato" DefaultButton="btnSubmitBlood">
        <div>
            <fieldset>
                <legend>เพิ่มข้อมูล</legend>
                <div>
                    <table class="center1">
                        <tr>
                            <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกรุ๊ปเลือด :</td>
                            <td style="text-align: left; width: 230px;">
                                <asp:TextBox ID="txtInsertBloodName" runat="server" CssClass="tb5" MaxLength="100" Width="230px"></asp:TextBox></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSubmitBlood" Text="OK" runat="server" CssClass="master_OAT_button" OnClick="btnSubmitBlood_Click" /></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnCancelBlood" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick="btnCancelBlood_Click" /></td>
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
                            DataKeyNames="BLOOD_ID"
                            OnRowEditing="modEditCommand"
                            OnRowCancelingEdit="modCancelCommand"
                            OnRowUpdating="modUpdateCommand"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="myGridViewBlood_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="รหัสกรุ๊ปเลือด" ControlStyle-Width="180" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBloodIDEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BLOOD_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกรุ๊ปเลือด" ControlStyle-Width="640" HeaderStyle-BackColor="#F7F6F3" HeaderStyle-ForeColor="Tomato">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBloodNameEDIT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BLOOD_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBloodNameEDIT" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BLOOD_NAME") %>'></asp:TextBox>
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
