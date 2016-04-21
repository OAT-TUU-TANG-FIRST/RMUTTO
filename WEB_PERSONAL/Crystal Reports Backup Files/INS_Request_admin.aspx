<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="INS_Request_admin.aspx.cs" Inherits="WEB_PERSONAL.INS_Request_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function CheckAllEmp(Checkbox) {
            var GridView1 = document.getElementById("<%=GridView1.ClientID %>");
            for (i = 1; i < GridView1.rows.length; i++) {
                GridView1.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
    </script>
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

                <p>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ค้นหา" />
                </p>

                <tr></tr>

             </div>
            </font>
            </fieldset>

        <fieldset>
         <legend> <B>รายชื่อผู้ที่เข้าเกณฑ์การรับเครื่องราชอิสริยาภรณ์</B></legend>

            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                 <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1">
                     <Columns>
                         <asp:TemplateField>
                             <EditItemTemplate>
                                 <asp:CheckBox ID="CheckBox1" runat="server" />
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="CheckBox1" runat="server" />
                             </ItemTemplate>
                             <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEmp" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                    </Triggers>
                </asp:UpdatePanel>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" ></asp:SqlDataSource>

            </div>
        </fieldset>  
    </asp:Panel>
</asp:Content>
