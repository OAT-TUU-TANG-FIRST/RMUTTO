<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListPerson-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.ListPerson_ADMIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
            color: blue;
        }

        div {
            color: #003380;
        }

        .panin {
            border: 1px solid black;
            margin: 20px;
            background-color: rgba(255,255,255,0.6);
            border-radius: 5px;
        }

        body {
            background-color: white;
        }

        .tb5 {
            background-repeat: repeat-x;
            border: 1px solid #ff9900;
            width: 300px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }

        .center1 {
            display: inline-block;
        }

        legend {
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
            text-align: center;
            font-size: medium;
            color: royalblue;
        }

        fieldset {
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
                    คำค้นหา :&nbsp<asp:TextBox ID="txtSearchName" runat="server" CssClass="tb5"></asp:TextBox>
                    <asp:Button ID="btnSearchListPerson" Text="Search" runat="server" CssClass="master_OAT_button" />
                    <asp:Button ID="btnSearchRefresh" Text="Refresh" runat="server" CssClass="master_OAT_button" />
                </div>
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua">
        <div>
            <fieldset>
                <legend>ข้อมูล</legend>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PS_CITIZEN_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" Width="982px" PageSize="50" CssClass="tb5">
                        <Columns>
                            <asp:BoundField DataField="PS_ID" HeaderText="ลำดับที่" SortExpression="PS_ID" />
                            <asp:BoundField DataField="PS_FN_TH" HeaderText="ชื่อ" SortExpression="PS_FN_TH" />
                            <asp:BoundField DataField="PS_LN_TH" HeaderText="นามสกุล" SortExpression="PS_LN_TH" />
                            <asp:HyperLinkField DataNavigateUrlFields="PS_CITIZEN_ID" DataNavigateUrlFormatString="CitizenDetails.aspx?CID={0}" DataTextField="PS_CITIZEN_ID" HeaderText="รหัสบัตรประชาชน" SortExpression="PS_CITIZEN_ID" />
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT &quot;PS_ID&quot;, &quot;PS_CITIZEN_ID&quot;, &quot;PS_FN_TH&quot;, &quot;PS_LN_TH&quot; FROM &quot;PS_PERSON&quot;"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT &quot;PS_ID&quot;, &quot;PS_FN_TH&quot;, &quot;PS_LN_TH&quot;, &quot;PS_CITIZEN_ID&quot; FROM &quot;PS_PERSON&quot; WHERE (&quot;PS_CITIZEN_ID&quot; = :PS_CITIZEN_ID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtSearchName" Name="PS_CITIZEN_ID" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
