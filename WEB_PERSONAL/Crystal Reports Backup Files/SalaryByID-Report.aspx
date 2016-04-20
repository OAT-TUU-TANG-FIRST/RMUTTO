<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryByID-Report.aspx.cs" Inherits="WEB_PERSONAL.SalaryByID_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .button{
            border-radius:5px;
            color:black;
            background-color:#ffaaeb;
            padding:10px;
        }
        .button:hover{
            color:white;
            background-color:green;
        }
        @font-face {
            font-family: THS;
            src: url("Font/THSarabun.ttf");
        }
        .mGrid td,mGrid th{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" SelectCommand="SELECT TB_PERSON.ID, TB_PERSON.CITIZEN_ID,TB_PERSON.TITLE_ID || '    ' || TB_PERSON.PERSON_NAME || '    ' || TB_PERSON.PERSON_LASTNAME as PERSON_NAME, TB_POSITION.NAME, TB_SALARY_UP.DETAIL_SALARY, TB_SALARY_UP.DETAIL_MAXSALARY, TB_SALARY_UP.DETAIL_BASEMONEY, TB_SALARY_UP.DETAIL_PERCENT_RATE, TB_SALARY_UP.DETAIL_MONEYNOTROUND, TB_SALARY_UP.DETAIL_MONEYROUND, TB_SALARY_UP.DETAIL_MONEYUP, TB_SALARY_UP.DETAIL_MONEYBONUS, TB_SALARY_UP.DETAIL_SUM_MONEY, TB_SALARY_UP.DETAIL_NEW_SALARY, TB_SALARY_UP.DETAIL_SCORE_TEST, TB_SALARY_UP.DETAIL_LEVEL_TEST, TB_SALARY_UP.ADMIN_RATESUM, TB_SALARY_UP.ADMIN_RATE, TB_SALARY_UP.ADMIN_MONEY_ADD, TB_SALARY_UP.SUM_PERCENT_RATE2, TB_SALARY_UP.SUM_MONEYNOTROUND, TB_SALARY_UP.SUM_MONEYROUND, TB_SALARY_UP.SUM_MONEYUP, TB_SALARY_UP.SUM_MONEYBONUS, TB_SALARY_UP.SUM_MONEYUPTOTAL, TB_SALARY_UP.SUM_NEWSALARY, TB_SALARY_UP.&quot;COMMENT&quot; FROM TB_PERSON, TB_POSITION_AND_SALARY, TB_SALARY_UP, TB_POSITION WHERE TB_PERSON.ID = TB_POSITION_AND_SALARY.ID AND TB_PERSON.ID = TB_SALARY_UP.ID AND TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" UpdateCommand="UPDATE TB_SALARY_UP SET DETAIL_SALARY = :DETAIL_SALARY, DETAIL_MAXSALARY = :DETAIL_MAXSALARY, DETAIL_BASEMONEY = :DETAIL_BASEMONEY, DETAIL_PERCENT_RATE = :DETAIL_PERCENT_RATE, DETAIL_MONEYNOTROUND = :DETAIL_MONEYNOTROUND, DETAIL_MONEYROUND = :DETAIL_MONEYROUND, DETAIL_MONEYUP = :DETAIL_MONEYUP, DETAIL_MONEYBONUS = :DETAIL_MONEYBONUS, DETAIL_SUM_MONEY = :DETAIL_SUM_MONEY, DETAIL_NEW_SALARY = :DETAIL_NEW_SALARY, DETAIL_SCORE_TEST = :DETAIL_SCORE_TEST, DETAIL_LEVEL_TEST = :DETAIL_LEVEL_TEST, ADMIN_RATESUM = :ADMIN_RATESUM, ADMIN_RATE = :ADMIN_RATE, ADMIN_MONEY_ADD = :ADMIN_MONEY_ADD, SUM_PERCENT_RATE2 = :SUM_PERCENT_RATE2, SUM_MONEYNOTROUND = :SUM_MONEYNOTROUND, SUM_MONEYROUND = :SUM_MONEYROUND, SUM_MONEYUP = :SUM_MONEYUP, SUM_MONEYBONUS = :SUM_MONEYBONUS, SUM_MONEYUPTOTAL = :SUM_MONEYUPTOTAL, SUM_NEWSALARY = :SUM_NEWSALARY, &quot;COMMENT&quot; = :COMMENT">
                <UpdateParameters>
                    <asp:Parameter Name="DETAIL_SALARY" />
                    <asp:Parameter Name="DETAIL_MAXSALARY" />
                    <asp:Parameter Name="DETAIL_BASEMONEY" />
                    <asp:Parameter Name="DETAIL_PERCENT_RATE" />
                    <asp:Parameter Name="DETAIL_MONEYNOTROUND" />
                    <asp:Parameter Name="DETAIL_MONEYROUND" />
                    <asp:Parameter Name="DETAIL_MONEYUP" />
                    <asp:Parameter Name="DETAIL_MONEYBONUS" />
                    <asp:Parameter Name="DETAIL_SUM_MONEY" />
                    <asp:Parameter Name="DETAIL_NEW_SALARY" />
                    <asp:Parameter Name="DETAIL_SCORE_TEST" />
                    <asp:Parameter Name="DETAIL_LEVEL_TEST" />
                    <asp:Parameter Name="ADMIN_RATESUM" />
                    <asp:Parameter Name="ADMIN_RATE" />
                    <asp:Parameter Name="ADMIN_MONEY_ADD" />
                    <asp:Parameter Name="SUM_PERCENT_RATE2" />
                    <asp:Parameter Name="SUM_MONEYNOTROUND" />
                    <asp:Parameter Name="SUM_MONEYROUND" />
                    <asp:Parameter Name="SUM_MONEYUP" />
                    <asp:Parameter Name="SUM_MONEYBONUS" />
                    <asp:Parameter Name="SUM_MONEYUPTOTAL" />
                    <asp:Parameter Name="SUM_NEWSALARY" />
                    <asp:Parameter Name="COMMENT" />
                </UpdateParameters>
            </asp:SqlDataSource>
                <br />
        </asp:Panel>
               <asp:Panel ID="Header" runat="server" Width="100%" HorizontalAlign="Center">
            <asp:Label ID="Headertext" runat="server" Text="รายละเอียดการเลื่อนเงินเดือนข้าราชการพลเรือนในสถาบันอุดมศึกษา ครั้งที่ 1 วันที่ 1 เมษายน 2558 มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"></asp:Label>
        </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Width="1024px" ScrollBars="Horizontal">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Font-Names="THS" Width="3000px" OnRowCreated="GridView1_RowCreated" DataKeyNames="ID" CssClass="mGrid" ShowHeaderWhenEmpty="True" EmptyDataText="ไม่พบข้อมูลในระบบ" EmptyDataRowStyle-HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ลำดับที่" SortExpression="ID" ReadOnly="True" />
                        <asp:BoundField DataField="CITIZEN_ID" HeaderText="รหัสบัตรประจำตัวประชาชน" SortExpression="CITIZEN_ID" />
                        <asp:BoundField DataField="PERSON_NAME" HeaderText="ชื่อ - นามสกุล" SortExpression="PERSON_NAME" >
                        </asp:BoundField>
                         <asp:BoundField DataField="CITIZEN_NUM" HeaderText="เลขที่ตำแหน่ง" SortExpression="CITIZEN_NUM" >
                        </asp:BoundField>
                        <asp:BoundField DataField="NAME" HeaderText="ชื่อตำแหน่งในสายงาน" SortExpression="NAME" >
                        </asp:BoundField>
                        <asp:BoundField DataField="Level_position" HeaderText="ระดับตำแหน่ง" SortExpression="Level_position" >
                        </asp:BoundField>
                        <asp:BoundField DataField="ADMIN_POSITION" HeaderText="ชื่อตำแหน่งในการบริหาร" SortExpression="ADMIN_POSITION" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_SALARY" HeaderText="เงินเดือนก่อนเลื่อน (ณ 1 มี.ค.58)" SortExpression="DETAIL_SALARY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_MAXSALARY" HeaderText="เงินเดือนสูงสุดของแต่ละประเภท" SortExpression="DETAIL_MAXSALARY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_BASEMONEY" HeaderText="ฐานในการคำนวณ" SortExpression="DETAIL_BASEMONEY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_PERCENT_RATE" HeaderText="ร้อยละที่ได้เลื่อน" SortExpression="DETAIL_PERCENT_RATE" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_MONEYNOTROUND" HeaderText="จำนวนเงินที่คำนวณได้(ไม่ปัดเศษ)" SortExpression="DETAIL_MONEYNOTROUND" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_MONEYROUND" HeaderText="จำนวนเงินที่คำนวณได้(ปัดเศษ)" SortExpression="DETAIL_MONEYROUND" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_MONEYUP" HeaderText="จำนวนเงินที่ได้เลื่อน" SortExpression="DETAIL_MONEYUP" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_MONEYBONUS" HeaderText="เงินตอบแทนพิเศษ" SortExpression="DETAIL_MONEYBONUS" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_SUM_MONEY" HeaderText="รวมใช้เลื่อน" SortExpression="DETAIL_SUM_MONEY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_NEW_SALARY" HeaderText="เงินเดือนใหม่" SortExpression="DETAIL_NEW_SALARY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_SCORE_TEST" HeaderText="คะแนนการประเมินผล" SortExpression="DETAIL_SCORE_TEST" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DETAIL_LEVEL_TEST" HeaderText="ระดับการประเมินผล" SortExpression="DETAIL_LEVEL_TEST" >
                        </asp:BoundField>
                        <asp:BoundField DataField="ADMIN_RATESUM" HeaderText="ร้อยละที่ได้เลื่อน(ตามสัดส่วน)" SortExpression="ADMIN_RATESUM" >
                        </asp:BoundField>
                        <asp:BoundField DataField="ADMIN_RATE" HeaderText="ร้อยละที่ได้เลื่อน(อธิการบดีเพิ่ม)" SortExpression="ADMIN_RATE" >
                        </asp:BoundField>
                        <asp:BoundField DataField="ADMIN_MONEY_ADD" HeaderText="จำนวนเงินที่ได้เพิ่ม" SortExpression="ADMIN_MONEY_ADD" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_PERCENT_RATE2" HeaderText="ร้อยละที่ได้เลื่อน" SortExpression="SUM_PERCENT_RATE2" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_MONEYNOTROUND" HeaderText="จำนวนเงินที่คำนวณได้(ไม่ปัดเศษ)" SortExpression="SUM_MONEYNOTROUND" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_MONEYROUND" HeaderText="จำนวนเงินที่คำนวณได้(ปัดเศษ)" SortExpression="SUM_MONEYROUND" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_MONEYUP" HeaderText="จำนวนเงินที่ได้เลื่อน" SortExpression="SUM_MONEYUP" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_MONEYBONUS" HeaderText="เงินตอบแทนพิเศษ" SortExpression="SUM_MONEYBONUS" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_MONEYUPTOTAL" HeaderText="รวมใช้เลื่อน" SortExpression="SUM_MONEYUPTOTAL" >
                        </asp:BoundField>
                        <asp:BoundField DataField="SUM_NEWSALARY" HeaderText="เงินเดือนใหม่" SortExpression="SUM_NEWSALARY" >
                        </asp:BoundField>
                        <asp:BoundField DataField="COMMENT" HeaderText="หมายเหตุ" SortExpression="COMMENT" >
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle HorizontalAlign="Center" />
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
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export To Excel" CssClass="button" />
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
