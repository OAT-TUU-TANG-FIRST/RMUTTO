<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insignia_print.aspx.cs" Inherits="WEB_PERSONAL.insignia_print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="ประวัติการรับเครื่องราชอิสริยาภรณ์" Font-Size="20pt"></asp:Label>
        </div>
        <div>

        </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </div>
    </form>
</body>
</html>
