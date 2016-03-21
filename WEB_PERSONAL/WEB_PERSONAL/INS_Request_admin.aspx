<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_Request_admin.aspx.cs" Inherits="WEB_PERSONAL.INS_Request_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="592px">
        
        <label><center><font size="16">ค้นหาผู้มีสิทธิ์รับครื่องราชอิสริยาภรณ์</font></center></label>
        <label><center>กองพัฒนาบุคลากร มหาวิทลัยเทคโนโลยีราชมงคลตะวันออก</center></label>
        <fieldset>
            <legend><font ><B>กรุณาเลือกเงื่อนไขที่ท่านต้องการ</B></legend>
            <div>
                <tr></tr>
                <p><label>ปี:</label>
                <asp:DropDownList ID="DDLyear" runat="server" AutoPostBack="True" ></asp:DropDownList>

                </p>
               
                 <p><label>ประเภทบุคลากร:</label>
                <asp:DropDownList ID="DDLstafftype" runat="server" AutoPostBack="True" ></asp:DropDownList>
                 </p>
                
                <p><label>วิทยาเขต:</label>
                    <asp:DropDownList ID="DropDownCampus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownCampus_SelectedIndexChanged" ></asp:DropDownList>
                </p>
                
                <p><label>สำนัก/สถาบัน/คณะ:</label>
                <asp:DropDownList ID="DropDownFaculty" runat="server" AutoPostBack="True" ></asp:DropDownList>
                </p>

                <tr></tr>

                <asp:Button ID="file1" runat="server" Text="ค้นหา" />
             </div>
            </fieldset>

        <fieldset>
         <legend> <B>รายชื่อผู้ที่เข้าเกณฑ์การรับเครื่องราชอิสริยาภรณ์</B></legend>
            <div>   
        <asp:GridView ID="GridView1" runat="server"></asp:GridView> 
            </div>
        </fieldset>  
    </asp:Panel>
</asp:Content>
