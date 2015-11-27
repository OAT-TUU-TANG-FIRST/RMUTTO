﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminPosition-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.AdminPosition_ADMIN" %>
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
<asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchAdminPosition">
    <div>
        <fieldset>
            <legend>Search</legend>
            <div>
                รหัสตำแหน่งทางบริหาร :&nbsp<asp:TextBox ID="txtSearchAdminPositionID" runat="server" CssClass="tb5" Width="230px" MaxLength="4"></asp:TextBox>
                ชื่อตำแหน่งทางบริหาร :&nbsp<asp:TextBox ID="txtSearchAdminPositionName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                <asp:Button ID="btnSearchAdminPosition" Text="Search" runat="server" CssClass="master_OAT_button" OnClick="btnSearchAdminPosition_Click" />
                <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
            </div>
        </fieldset>
    </div>
    </asp:Panel>
<asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSubmitAdminPosition">
    <div>
        <fieldset>
            <legend>Insert</legend>
            <div>
                <table>
                    <tr>
                        <td style="text-align: left; width:25px"></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสตำแหน่งทางบริหาร :</td>
                        <td style="text-align: left; width: 120px;"><asp:TextBox ID="txtInsertAdminPositionID" runat="server" CssClass="tb5" MaxLength="4"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อตำแหน่งทางบริหาร :</td>
                        <td style="text-align: left; width: 120px;"><asp:TextBox ID="txtInsertAdminPositionName" runat="server" CssClass="tb5" MaxLength="100"></asp:TextBox></td>
                        <td style="text-align: left;"><asp:Button ID="btnSubmitAdminPosition" Text="OK" runat="server" CssClass="master_OAT_button" OnClick = "btnSubmitAdminPosition_Click" /></td>
                        <td style="text-align: left;"><asp:Button ID="btnCancelAdminPosition" Text="Cancel" runat="server" CssClass="master_OAT_button" OnClick = "btnCancelAdminPosition_Click" /></td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <div>
        <fieldset >
            <legend>Data</legend>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
				<ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" style="margin-left: auto; margin-right: auto; text-align: center; width:100%"
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="ADMIN_POSITION_ID"
                OnRowEditing="modEditCommand"
                OnRowCancelingEdit="modCancelCommand"
                OnRowUpdating="modUpdateCommand"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridViewAdminPosition_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999">
                <Columns>
                    <asp:TemplateField HeaderText="รหัสตำแหน่งทางบริหาร" ControlStyle-Width="230" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblAdminPositionIDEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ADMIN_POSITION_ID") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtAdminPositionIDEdit" MaxLength="4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ADMIN_POSITION_ID") %>' Enabled="False"></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ชื่อตำแหน่งทางบริหาร" ControlStyle-Width="600" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lblAdminPositionNameEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ADMIN_POSITION_NAME") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txtAdminPositionNameEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ADMIN_POSITION_NAME") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua"/>
                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                         <ItemTemplate>
                         <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" ></asp:LinkButton>                
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
