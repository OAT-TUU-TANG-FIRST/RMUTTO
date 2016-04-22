<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="WEB_PERSONAL.Developer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Col1</asp:TableHeaderCell>
                <asp:TableHeaderCell>Col2</asp:TableHeaderCell>
            </asp:TableHeaderRow>

        </asp:Table>

        <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click"/>

        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    v1
                </asp:View>
                <asp:View ID="View2" runat="server">
                    v2
                </asp:View>
            </asp:MultiView>
            <asp:Button ID="Button1" runat="server" Text="View AAA" OnClick="Button1_Click" />
        </div>

        <div>
            <asp:BulletedList ID="BulletedList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
            </asp:BulletedList>
        </div>

        <div>
            
        </div>




        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuSQL">
            <asp:TextBox ID="tbSQL" runat="server" CssClass="textbox textbox_default" placeHolder="Select ..."></asp:TextBox>
            <asp:LinkButton ID="lbuSQL" runat="server" CssClass="button button_default" OnClick="lbuSQL_Click">View Select SQL</asp:LinkButton>
        </asp:Panel>

        <div>
            <asp:TextBox ID="tbSqlUpdate" runat="server" placeHolder="Sql Update Here"></asp:TextBox>
            <asp:Button ID="btnSqlUpdate" runat="server" Text="Execute SQL Update" OnClick="btnSqlUpdate_Click"/>
        </div>

        <div>

            <asp:ListBox ID="ListBox1" runat="server" Height="300"></asp:ListBox>
            <br />
            <asp:LinkButton ID="lbuTableSQL" runat="server" CssClass="button button_default" OnClick="lbuTableSQL_Click">View Table</asp:LinkButton>

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        </div>
        <div style="clear: both;"></div>



    </div>


</asp:Content>
