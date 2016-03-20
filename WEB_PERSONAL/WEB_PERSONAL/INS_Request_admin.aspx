<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_Request_admin.aspx.cs" Inherits="WEB_PERSONAL.INS_Request_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="592px">
        <fieldset>
            <legend> <font size="20"><B>คำนวณเครื่องราชอิสริยาภรณ์</B></font></legend>
            <div>
                <tr></tr>
                <p><label>ปี:</label>
                <asp:DropDownList ID="DDLyear" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="YEAR_ID" DataValueField="YEAR_ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT &quot;YEAR_ID&quot; FROM &quot;INS_YEAR&quot;"></asp:SqlDataSource>

                </p>
               
                 <p><label>ประเภทบุคลากร:</label>
                <asp:DropDownList ID="DDLstafftype" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="STAFFTYPE_NAME" DataValueField="STAFFTYPE_ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT &quot;STAFFTYPE_ID&quot;, &quot;STAFFTYPE_NAME&quot; FROM &quot;TB_STAFFTYPE&quot;"></asp:SqlDataSource>
                 </p>
                
                <p><label>วิทยาเขต:</label>
                    <asp:DropDownList ID="ddlcampus" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="CAMPUS_NAME" DataValueField="CAMPUS_ID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_CAMPUS&quot;"></asp:SqlDataSource>
                </p>
                
                <p><label>สำนัก/สถาบัน/คณะ:</label>
                <asp:DropDownList ID="ddlfacuty" runat="server" DataSourceID="SqlDataSource4" DataTextField="FACULTY_NAME" DataValueField="FACULTY_ID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RMUTTOORCL %>" ProviderName="<%$ ConnectionStrings:RMUTTOORCL.ProviderName %>" SelectCommand="SELECT &quot;FACULTY_ID&quot;, &quot;FACULTY_NAME&quot;, &quot;CAMPUS_ID&quot; FROM &quot;TB_FACULTY&quot;"></asp:SqlDataSource>
                </p>

                <tr></tr>

                <asp:Button ID="file1" runat="server" Text="ค้นหา" />
             </div>
            </fieldset>
        <marquee>หมายเหตุ: อยู่ระหว่างการปรับปรุง</marquee>
    </asp:Panel>
</asp:Content>
