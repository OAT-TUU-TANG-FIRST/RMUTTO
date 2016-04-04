<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="WEB_PERSONAL.Developer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuSQL">
            <asp:TextBox ID="tbSQL" runat="server" CssClass="textbox textbox_default" placeHolder="Select ..."></asp:TextBox>
            <asp:LinkButton ID="lbuSQL" runat="server" CssClass="button button_default" OnClick="lbuSQL_Click">View Select SQL</asp:LinkButton>
        </asp:Panel>
        <div>
       
                <asp:ListBox ID="ListBox1" runat="server" Height="300"></asp:ListBox>
                <br />
                <asp:LinkButton ID="lbuTableSQL" runat="server" CssClass="button button_default" OnClick="lbuTableSQL_Click">View Table</asp:LinkButton>
  
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    
        </div>
        <div style="clear: both;"></div>
        

        
    </div>


</asp:Content>
