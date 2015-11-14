﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ministry-GENERAL.aspx.cs" Inherits="WEB_PERSONAL.Ministry_GENERAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .divpan {
         
            text-align: center;
        }
        .panin{
            border:1px solid black;
            margin: 20px;
            background-color:rgba(255,255,255,0.6);
            border-radius: 5px;
        }
         body {
            background-image: url("Image/444.png");
        }
         .tb5 {
	        background-repeat:repeat-x;
	        border:1px solid #d1c7ac;
	        width: 230px;
	        color:#333333;
	        padding:3px;
	        margin-right:4px;
	        margin-bottom:8px;
	        font-family:tahoma, arial, sans-serif;
            border-radius:10px;
            resize:none;
              }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server" Height="70px" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchMinistry">
    <div> 
        <fieldset>
            <legend>Search</legend>
            <div>
                รหัสกระทรวง :&nbsp<asp:TextBox ID="txtSearchMinistryID" runat="server" CssClass="tb5" Width="230px" MaxLength="4"></asp:TextBox>
                ชื่อกระทรวง :&nbsp<asp:TextBox ID="txtSearchMinistryName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                <asp:Button ID="btnSearchMinistry" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchMinistry_Click" />
                <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
            </div>
        </fieldset>
    </div>
    </asp:Panel>
<asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Height="600px" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitMinistry">
    <div>
        <fieldset>
            <legend>Insert</legend>
            <div>
                <table>
                    <tr>
                        <td style="text-align: left; width:85px"></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสกระทรวง :</td>
                        <td style="text-align: left; width: 120px;"><asp:TextBox ID="txtInsertMinistryID" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อกระทรวง :</td>
                        <td style="text-align: left; width: 120px;"><asp:TextBox ID="txtInsertMinistryName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                        <td style="text-align: left;"><asp:Button ID="btnSubmitMinistry" Text="OK" runat="server" CssClass="master_OAT_button" OnClick = "btnSubmitMinistry_Click" /></td>
                        <td style="text-align: left;"><asp:Button ID="btnCancelMinistry" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick = "btnCancelMinistry_Click" /></td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <div>
        <fieldset >
            <legend>Data</legend>
            <asp:GridView ID="GridView1" runat="server" style="margin-left: auto; margin-right: auto; text-align: center;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="MINISTRY_ID"
                OnRowEditing="modEditCommand"
                OnRowCancelingEdit="modCancelCommand"
                OnRowUpdating="modUpdateCommand"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewMinistry_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                <Columns>     
                    <asp:TemplateField HeaderText="รหัสกระทรวง" ControlStyle-Width="230" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblMinistryIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MINISTRY_ID") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtMinistryIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MINISTRY_ID") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อกระทรวง" ControlStyle-Width="600" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblMinistryNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MINISTRY_NAME") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtMinistryNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MINISTRY_NAME") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua"/>
                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                         <ItemTemplate>
                         <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Image/x.png" CommandName="Delete" OnClientClick="return confirm('คุณต้องการที่จะลบจริงๆใช่ไหม ?');" AlternateText="Delete" />               
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </fieldset>
    </div>
  </asp:Panel>
</asp:Content>
