﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="National-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.National_ADMIN" %>
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
	        width: 130px;
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
<asp:Panel ID="Panel1" runat="server" Height="70px" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchNATIONAL">
    <div>
        <fieldset>
            <legend>Search</legend>
            <div>
                รหัสสัญชาติ :&nbsp<asp:TextBox ID="txtSearchNationID" runat="server" CssClass="tb5" Width="50px" MaxLength="2"></asp:TextBox>
                ชื่อสัญชาติภาษาอังกฤษ :&nbsp<asp:TextBox ID="txtSearchNationENG" runat="server" CssClass="tb5" Width="150px" MaxLength="100"></asp:TextBox>
                ชื่อสัญชาติภาษาไทย :&nbsp<asp:TextBox ID="txtSearchNationTHA" runat="server" CssClass="tb5" Width="150px" MaxLength="100"></asp:TextBox>
                <asp:Button ID="btnSearchNATIONAL" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchNATIONAL_Click" />
                <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
            </div>
        </fieldset>
    </div>
      </asp:Panel>
<asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Height="600px" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitNATIONAL">
    <div>
        <fieldset>
            <legend>Insert</legend>
            <div>
                <table>
                    <tr>
                        <td style="text-align: left; width:25px"></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสสัญชาติ :</td>
                        <td style="text-align: left; width: 50px;"><asp:TextBox ID="txtInsertNationID" runat="server" CssClass="tb5" MaxLength="2" Width="50px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อสัญชาติภาษาอังกฤษ :</td>
                        <td style="text-align: left; width: 90px;"><asp:TextBox ID="txtInsertNationENG" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อสัญชาติภาษาไทย :</td>
                        <td style="text-align: left; width: 80px;"><asp:TextBox ID="txtInsertNationTHA" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left;"><asp:Button ID="btnSubmitNATIONAL" Text="OK" runat="server" CssClass="master_OAT_button" OnClick = "btnSubmitNATIONAL_Click" /></td>
                        <td style="text-align: left;"><asp:Button ID="btnCancelNATIONAL" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick = "btnCancelNATIONAL_Click" /></td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <div>
        <fieldset >
            <legend>Data</legend>
            <asp:GridView ID="GridView1" runat="server" style="margin-left: auto; margin-right: auto; text-align: left;"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="NATION_SEQ"
                OnRowEditing="modEditCommand"
                OnRowCancelingEdit="modCancelCommand"
                OnRowUpdating="modUpdateCommand"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewNATIONAL_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblNationSEQ" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_SEQ") %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="รหัสสัญชาติ" ControlStyle-Width="80" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblNationIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ID") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtNationIDEdit" MaxLength="2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ID") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ชื่อสัญชาติภาษาอังกฤษ" ControlStyle-Width="380" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblNationENGEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ENG") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtNationENGEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_ENG") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ชื่อสัญชาติภาษาไทย" ControlStyle-Width="380" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblNationTHAEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_THA") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtNationTHAEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NATION_THA") %>'></asp:TextBox>
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
