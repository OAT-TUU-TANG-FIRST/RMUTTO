<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="insignia_recordnote2.aspx.cs" Inherits="WEB_PERSONAL.insignia_recordnote_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .GridPanel
       {
            overflow:scroll;
        }
       .wrapper{
           width:auto;
       }
 </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:Panel ID="Panel2" runat="server" CssClass="GridPanel">

        <div style="margin:20px">
            <asp:Label ID="Label1" runat="server" Text="ใส่รหัสบัตรประจำตัวประชาชน"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="164px" MaxLength="13" ToolTip="รหัสบัตรประจำตัวประชาชน" style="text-align:center"></asp:TextBox> 
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">ค้นหา</asp:LinkButton>
        </div>
        <div style="margin:20px">
            <asp:Label ID="Label2" runat="server" Text="ตรวจสอบชื่อ"></asp:Label><asp:TextBox ID="TextBox2" runat="server" Enabled="False" style="text-align:center"></asp:TextBox>
        </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วัน เดือน ปี" SortExpression="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                <asp:BoundField DataField="POSITION_WORK_NAME" HeaderText="ตำแหน่ง" SortExpression="POSITION_WORK_NAME" />
                <asp:BoundField DataField="POSITION_NAME" HeaderText="ระดับ" SortExpression="POSITION_NAME" />
                <asp:BoundField DataField="GRADEINSIGNIA_NAME" HeaderText="ได้รับ ชั้น/รายการ" SortExpression="GRADEINSIGNIA_NAME" />
                <asp:BoundField DataField="GAZETTE_LAM" HeaderText="เล่ม" SortExpression="GAZETTE_LAM" />
                <asp:BoundField DataField="GAZETTE_TON" HeaderText="ตอน" SortExpression="GAZETTE_TON" />
                <asp:BoundField DataField="GAZETTE_NA" HeaderText="หน้า" SortExpression="GAZETTE_NA" />
                <asp:BoundField DataField="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" HeaderText="วัน เดือน ปี" SortExpression="TO_CHAR(DDATE,'DDMONYYYY','NLS_DATE_LANGUAGE=THAI')" />
                <asp:BoundField DataField="INVOICE" HeaderText="ใบกำกับ" SortExpression="INVOICE" >
                </asp:BoundField>
                <asp:BoundField DataField="DECORATION" HeaderText="เหรียญตราฯ" SortExpression="DECORATION" />
                <asp:BoundField DataField="NOTES" HeaderText="หมายเหตุ" SortExpression="NOTES" />
            </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <div>

        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="สั่งพิมพ์รายงาน" OnClick="Button1_Click1" />
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="select tb_recordnote1.id, tb_recordnote1.citizen_id, person_name || ' ' || person_lastname, to_char(DDATE,'DD MON YYYY','NLS_DATE_LANGUAGE = THAI'), POSITION_WORK_NAME, POSITION_NAME, GRADEINSIGNIA_NAME, GAZETTE_LAM, GAZETTE_TON, GAZETTE_NA, GAZETTE_DATE, INVOICE, DECORATION, NOTES from tb_recordnote1, tb_person where tb_recordnote1.citizen_id = tb_person.citizen_id"></asp:SqlDataSource>
        
    </asp:Panel>
</asp:Content>

