<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CitizenDetails.aspx.cs" Inherits="WEB_PERSONAL.CitizenDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="CITIZEN_ID" DataSourceID="SqlDataSource1" Height="100%" Width="100%">
        <Fields>
            <asp:BoundField DataField="ID" HeaderText="ลำดับที่" SortExpression="ID" />
            <asp:BoundField DataField="CITIZEN_ID" HeaderText="รหัสบัตรประชาชน" ReadOnly="True" SortExpression="CITIZEN_ID" />
            <asp:BoundField DataField="TITLE_ID" HeaderText="รหัสคำนำหน้า" SortExpression="TITLE_ID" />
            <asp:BoundField DataField="PERSON_NAME" HeaderText="ชื่อ" SortExpression="PERSON_NAME" />
            <asp:BoundField DataField="PERSON_LASTNAME" HeaderText="นามสกุล" SortExpression="PERSON_LASTNAME" />
            <asp:BoundField DataField="BIRTHDATE" HeaderText="วันเกิด" SortExpression="BIRTHDATE" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="BIRTHDATE_LONG" HeaderText="วันเกิด(ตัวอักษร)" SortExpression="BIRTHDATE_LONG" />
            <asp:BoundField DataField="RETIRE_DATE" HeaderText="วันครบเกษียณอายุ" SortExpression="RETIRE_DATE" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="RETIRE_DATE_LONG" HeaderText="วันครบเกษียณอายุ(ตัวอักษร)" SortExpression="RETIRE_DATE_LONG" />
            <asp:BoundField DataField="INWORK_DATE" HeaderText="วันที่บรรจุ" SortExpression="INWORK_DATE" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="STAFFTYPE_ID" HeaderText="รหัสประเภทบุคลากร" SortExpression="STAFFTYPE_ID" />
            <asp:BoundField DataField="FATHER_NAME" HeaderText="ชื่อบิดา" SortExpression="FATHER_NAME" />
            <asp:BoundField DataField="FATHER_LASTNAME" HeaderText="นามสกุลบิดา" SortExpression="FATHER_LASTNAME" />
            <asp:BoundField DataField="MOTHER_NAME" HeaderText="ชื่อมารดา" SortExpression="MOTHER_NAME" />
            <asp:BoundField DataField="MOTHER_LASTNAME" HeaderText="นามสกุลมารดา" SortExpression="MOTHER_LASTNAME" />
            <asp:BoundField DataField="MOTHER_OLD_LASTNAME" HeaderText="นามสกุลมารดา(เดิม)" SortExpression="MOTHER_OLD_LASTNAME" />
            <asp:BoundField DataField="COUPLE_NAME" HeaderText="ชื่อคู่สมรส" SortExpression="COUPLE_NAME" />
            <asp:BoundField DataField="COUPLE_LASTNAME" HeaderText="นามสกุลคู่สมรส" SortExpression="COUPLE_LASTNAME" />
            <asp:BoundField DataField="COUPLE_OLD_LASTNAME" HeaderText="นามสกุลคู่สมรส(เดิม)" SortExpression="COUPLE_OLD_LASTNAME" />
            <asp:BoundField DataField="MINISTRY_ID" HeaderText="รหัสกระทรวง" SortExpression="MINISTRY_ID" />
            <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="ชื่อกรม" SortExpression="DEPARTMENT_NAME" />
            <asp:BoundField DataField="PASSWORD" HeaderText="รหัสผ่าน" SortExpression="PASSWORD" />
            <asp:BoundField DataField="SYSTEM_STATUS_ID" HeaderText="รหัสสถานะ" SortExpression="SYSTEM_STATUS_ID" />
            <asp:BoundField DataField="GENDER_ID" HeaderText="รหัสเพศ" SortExpression="GENDER_ID" />
            <asp:BoundField DataField="NATION_ID" HeaderText="รหัสสัญชาติ" SortExpression="NATION_ID" />
            <asp:BoundField DataField="HOMEADD" HeaderText="ที่อยู่" SortExpression="HOMEADD" />
            <asp:BoundField DataField="MOO" HeaderText="หมู่" SortExpression="MOO" />
            <asp:BoundField DataField="STREET" HeaderText="ถนน" SortExpression="STREET" />
            <asp:BoundField DataField="DISTRICT_ID" HeaderText="รหัสตำบล" SortExpression="DISTRICT_ID" />
            <asp:BoundField DataField="AMPHUR_ID" HeaderText="รหัสอำเภอ" SortExpression="AMPHUR_ID" />
            <asp:BoundField DataField="PROVINCE_ID" HeaderText="รหัสจังหวัด" SortExpression="PROVINCE_ID" />
            <asp:BoundField DataField="ZIPCODE_ID" HeaderText="รหัสไปรษณีย์" SortExpression="ZIPCODE_ID" />
            <asp:BoundField DataField="TELEPHONE" HeaderText="เบอร์โทรศัพท์" SortExpression="TELEPHONE" />
            <asp:BoundField DataField="TIME_CONTACT_ID" HeaderText="รหัสระยะเวลาจ้าง" SortExpression="TIME_CONTACT_ID" />
            <asp:BoundField DataField="BUDGET_ID" HeaderText="รหัสประเภทเงินจ้าง" SortExpression="BUDGET_ID" />
            <asp:BoundField DataField="SUBSTAFFTYPE_ID" HeaderText="รหัสประเภทบุคลากรย่อย" SortExpression="SUBSTAFFTYPE_ID" />
            <asp:BoundField DataField="ADMIN_POSITION_ID" HeaderText="รหัสตำแหน่งบริหาร" SortExpression="ADMIN_POSITION_ID" />
            <asp:BoundField DataField="POSITION_WORK_ID" HeaderText="รหัสตำแหน่งในสายงาน" SortExpression="POSITION_WORK_ID" />
            <asp:BoundField DataField="SPECIAL_NAME" HeaderText="ความเชี่ยวชาญในสายงาน" SortExpression="SPECIAL_NAME" />
            <asp:BoundField DataField="TEACH_ISCED_ID" HeaderText="รหัสกลุ่มสาขาวิชาที่สอน" SortExpression="TEACH_ISCED_ID" />
            <asp:BoundField DataField="GRAD_ISCED_ID" HeaderText="รหัสกลุ่มสาขาวิชาที่จบสูงสุด" SortExpression="GRAD_ISCED_ID" />
            <asp:BoundField DataField="GRAD_PROG_ID" HeaderText="รหัสสาขาที่จบการศึกษาสูงสุด" SortExpression="GRAD_PROG_ID" />
            <asp:BoundField DataField="GRAD_UNIV" HeaderText="ชื่อสถาบันที่จบการศึกษาสูงสุด" SortExpression="GRAD_UNIV" />
            <asp:BoundField DataField="GRAD_COUNTRY_ID" HeaderText="รหัสประเทศที่จบการศึกษาสูงสุด" SortExpression="GRAD_COUNTRY_ID" />
            <asp:BoundField DataField="BRANCH_ID" HeaderText="รหัสหน่วยงานในมหาวิทยาลัย" SortExpression="BRANCH_ID" />
            <asp:BoundField DataField="RANK_ID" HeaderText="รหัสยศ" SortExpression="RANK_ID" />
            <asp:BoundField DataField="GOT_ID" HeaderText="รหัสข้าราชการ" SortExpression="GOT_ID" />
            <asp:BoundField DataField="GET_ID" HeaderText="รหัสลูกจ้างพนักงาน" SortExpression="GET_ID" />
            <asp:BoundField DataField="FACULTY_ID" HeaderText="รหัสคณะ" SortExpression="FACULTY_ID" />
            <asp:BoundField DataField="START_POSITION_WORK_ID" HeaderText="รหัสตำแหน่งที่บรรจุ" SortExpression="START_POSITION_WORK_ID" />
            <asp:BoundField DataField="CAMPUS_ID" HeaderText="รหัสวิทยาเขต" SortExpression="CAMPUS_ID" />
            <asp:BoundField DataField="STATUS_ID" HeaderText="รหัสสถานะการทำงาน" SortExpression="STATUS_ID" />
            <asp:BoundField DataField="RELIGION_ID" HeaderText="รหัสศาสนา" SortExpression="RELIGION_ID" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_PERSON&quot; WHERE (&quot;CITIZEN_ID&quot; = :CITIZEN_ID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CITIZEN_ID" QueryStringField="CID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
