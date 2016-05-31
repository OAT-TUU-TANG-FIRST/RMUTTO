<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CitizenDetails.aspx.cs" Inherits="WEB_PERSONAL.CitizenDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="CITIZEN_ID" DataSourceID="SqlDataSource1" Height="100%" Width="100%">
        <Fields>
            <asp:BoundField DataField="PS_ID" HeaderText="ลำดับที่" SortExpression="ID" />
            <asp:BoundField DataField="PS_CITIZEN_ID" HeaderText="รหัสบัตรประชาชน" ReadOnly="True" SortExpression="PS_CITIZEN_ID" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT PS_ID,PS_CITIZEN_ID FROM &quot;PS_PERSON&quot; WHERE (&quot;PS_CITIZEN_ID&quot; = :PS_CITIZEN_ID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="PS_CITIZEN_ID" QueryStringField="CID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
