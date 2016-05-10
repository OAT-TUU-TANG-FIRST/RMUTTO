<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary70_30_Evaluation_v2.aspx.cs" Inherits="WEB_PERSONAL.UpSalary70_30_Evaluation_v2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True">pls</asp:ListItem>
        <asp:ListItem>1. การเรียนการสอน</asp:ListItem>
        <asp:ListItem>orther</asp:ListItem>
    </asp:DropDownList>
        
        -->

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table class="ps-sal-table">
                <tr>
                    <th rowspan="2">กิจกรรม / โครงการ / งาน</th>
                    <th rowspan="2">ค่าน้ำหนัก</th>
                    <th rowspan="2">คำอธิบายตัวชี้วัดโดยย่อ</th>
                    <th rowspan="2">ค่าเป้าหมาย</th>
                    <th rowspan="2">ข้อมูลพื้นฐานในรอบการประเมินที่ผ่านมา</th>
                    <th colspan="5">ระดับค่าเป้าหมาย</th>
                    <th rowspan="2">ผลดำเนินงาน</th>
                    <th rowspan="2">ต่าคะแนนที่ได้</th>
                    <th rowspan="2">ค่าคะแนนถ่วงน้ำหนัก</th>
                    <th rowspan="2">รายการหลักฐาน</th>
                    <th rowspan="2">การพิจารณา</th>
                </tr>
                <tr>
                    <th>1</th>
                    <th>2</th>
                    <th>3</th>
                    <th>4</th>
                    <th>5</th>
                </tr>
                <tr>
                    <td colspan="15">
                        <asp:DropDownList runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
        </asp:View>
        <br />
    </asp:MultiView>
</asp:Content>
