<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListPerson-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.ListPerson_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-div-title-red"><img src="Image/Small/search.png" class="icon_left"/>ค้นหารายชื่อ</div>
        <div style="text-align: center;">
            รหัสบัตรประชาชน :&nbsp;<asp:TextBox ID="txtSearchCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox>
            <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
            <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
        </div>
        
    </div>
    <div class="ps-separator"></div>
    <div>
        <div class="ps-div-title-red"><img src="Image/Small/person2.png" class="icon_left"/>รายชื่อ</div>

        <asp:GridView ID="GridView1" runat="server" EnableViewState="True" AutoGenerateColumns="False" DataKeyNames="PS_CITIZEN_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="50" Width="1220px" CssClass="ps-table-1">
            <Columns>
                <asp:BoundField DataField="PS_ID" HeaderText="ลำดับที่" SortExpression="PS_ID" />
                <asp:HyperLinkField DataNavigateUrlFields="PS_CITIZEN_ID" DataNavigateUrlFormatString="Profile.aspx?psID={0}" DataTextField="PS_CITIZEN_ID" HeaderText="รหัสบัตรประชาชน" SortExpression="PS_CITIZEN_ID" />
                <asp:BoundField DataField="PS_FN_TH" HeaderText="ชื่อ" SortExpression="PS_FN_TH" />
                <asp:BoundField DataField="PS_LN_TH" HeaderText="นามสกุล" SortExpression="PS_LN_TH" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT &quot;PS_ID&quot;, &quot;PS_CITIZEN_ID&quot;, &quot;PS_FN_TH&quot;, &quot;PS_LN_TH&quot; FROM &quot;PS_PERSON&quot;"></asp:SqlDataSource>

    </div>

</asp:Content>
