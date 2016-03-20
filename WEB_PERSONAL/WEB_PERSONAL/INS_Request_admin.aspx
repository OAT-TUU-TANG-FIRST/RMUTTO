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
        <marquee>หมายเหตุ: อยู่ระหว่างการปรับปรุง</marquee>
    </asp:Panel>
</asp:Content>
