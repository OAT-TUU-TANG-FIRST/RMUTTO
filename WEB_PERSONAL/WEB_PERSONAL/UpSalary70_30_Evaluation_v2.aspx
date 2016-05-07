<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary70_30_Evaluation_v2.aspx.cs" Inherits="WEB_PERSONAL.UpSalary70_30_Evaluation_v2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True">pls</asp:ListItem>
        <asp:ListItem>1. การเรียนการสอน</asp:ListItem>
        <asp:ListItem>orther</asp:ListItem>
    </asp:DropDownList>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID_HUS_US1" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="DETAIL_HUS_US1" HeaderText="DETAIL_HUS_US1" SortExpression="DETAIL_HUS_US1"></asp:BoundField>
                    <asp:BoundField DataField="MAX_HUS_US1" HeaderText="MAX_HUS_US1" SortExpression="MAX_HUS_US1"></asp:BoundField>
                    <asp:BoundField DataField="MIN_HUS_US1" HeaderText="MIN_HUS_US1" SortExpression="MIN_HUS_US1"></asp:BoundField>
                    <asp:BoundField DataField="NAME_HUS_US1" HeaderText="NAME_HUS_US1" SortExpression="NAME_HUS_US1"></asp:BoundField>
                    <asp:BoundField DataField="ID_HUS_US1" HeaderText="ID_HUS_US1" ReadOnly="True" SortExpression="ID_HUS_US1"></asp:BoundField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <sortedascendingcellstyle backcolor="#F1F1F1" />
                <sortedascendingheaderstyle backcolor="#007DBB" />
                <sorteddescendingcellstyle backcolor="#CAC9C9" />
                <sorteddescendingheaderstyle backcolor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rmutto_joy %>" ProviderName="<%$ ConnectionStrings:rmutto_joy.ProviderName %>" SelectCommand="SELECT &quot;DETAIL_HUS_US1&quot;, &quot;MAX_HUS_US1&quot;, &quot;MIN_HUS_US1&quot;, &quot;NAME_HUS_US1&quot;, &quot;ID_HUS_US1&quot; FROM &quot;TB_HEADER_UPSALARY_US1&quot; WHERE (&quot;NAME_HUS_US1&quot; = :NAME_HUS_US1)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="NAME_HUS_US1" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="View2" runat="server">
        </asp:View>
        <br />
    </asp:MultiView>
</asp:Content>
