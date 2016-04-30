<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListPerson-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.ListPerson_ADMIN" %>
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
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSearchListPerson">
        <div>
            <fieldset>
                <legend>ค้นหาข้อมูล</legend>
                <div>
                    ชื่อบุคลากร :&nbsp<asp:TextBox ID="txtSearchName" runat="server" CssClass="tb5" Width="230px" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btnSearchListPerson" Text="Search" runat="server" CssClass="master_OAT_button"  />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button"  />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>ข้อมูล</legend>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CITIZEN_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" Width="982px" PageSize="20">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ลำดับที่" SortExpression="ID" />
                        <asp:BoundField DataField="PERSON_NAME" HeaderText="ชื่อ" SortExpression="PERSON_NAME" />
                        <asp:BoundField DataField="PERSON_LASTNAME" HeaderText="นามสกุล" SortExpression="PERSON_LASTNAME" />
                        <asp:HyperLinkField DataNavigateUrlFields="Citizen_ID" DataNavigateUrlFormatString="CitizenDetails.aspx?CID={0}" DataTextField="Citizen_ID" HeaderText="รหัสบัตรประชาชน" SortExpression="CITIZEN_ID"/>
                    </Columns>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT &quot;ID&quot;, &quot;CITIZEN_ID&quot;, &quot;PERSON_NAME&quot;, &quot;PERSON_LASTNAME&quot; FROM &quot;TB_PERSON&quot;"></asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT &quot;ID&quot;, &quot;PERSON_NAME&quot;, &quot;PERSON_LASTNAME&quot;, &quot;CITIZEN_ID&quot; FROM &quot;TB_PERSON&quot; WHERE (&quot;CITIZEN_ID&quot; = :CITIZEN_ID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtSearchName" Name="CITIZEN_ID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
