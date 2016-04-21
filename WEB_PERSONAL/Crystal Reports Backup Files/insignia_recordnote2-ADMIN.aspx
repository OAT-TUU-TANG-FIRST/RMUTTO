<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="insignia_recordnote2-ADMIN.aspx.cs" Inherits="WEB_PERSONAL.insignia_recordnote2_ADMIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad(sender , args) {
            $("#ContentPlaceHolder1_txtt0,#ContentPlaceHolder1_txtt7").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
            $('document').ready(function () {
                $(".date").datepicker($.datepicker.regional["th"]); // Set ภาษาที่เรานิยามไว้ด้านบน
            });
        };
    </script>
<style type="text/css">
        .divpan {

            text-align: center;
        }
        .panin{
            border:1px solid black;
            margin: 20px;
            background-color:rgba(255,255,255,0.6);
            border-radius: 5px;
        }
         body {
            background-image: url("Image/444.png");
        }
         .tb5 {
	        background-repeat:repeat-x;
	        border:1px solid #d1c7ac;
	        width: 130px;
	        color:#333333;
	        padding:3px;
	        margin-right:4px;
	        margin-bottom:8px;
	        font-family:tahoma, arial, sans-serif;
            border-radius:10px;
            resize:none;
              }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server" CssClass="divpan" BackColor="White" BorderColor="Aqua" DefaultButton="btnSearchInsig2">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <fieldset>
            <legend>ค้นหาข้อมูล</legend>
            <div>
                รหัสบัตรประชาชน :&nbsp<asp:TextBox ID="txtSearchInsig2CITIZENID" runat="server" CssClass="tb5" Width="150px" MaxLength="13"></asp:TextBox>
                ชื่อ :&nbsp<asp:TextBox ID="txtSearchNAME" runat="server" CssClass="tb5" Width="100px" MaxLength="100" Enabled="False"></asp:TextBox>
                นามสกุล :&nbsp<asp:TextBox ID="txtSearchLASTNAME" runat="server" CssClass="tb5" Width="100px" MaxLength="100" Enabled="False"></asp:TextBox>
                วันที่เริ่มบรรจุ :&nbsp<asp:TextBox ID="txtSearchDATE_INWORK" runat="server" CssClass="tb5" Width="80px" MaxLength="100" Enabled="False"></asp:TextBox>
                <asp:Button ID="btnSearchInsig2" Text="ค้นหา" runat="server" CssClass="master_OAT_button" OnClick="btnSearchInsig2_Click" />
                <asp:Button ID="btnSearchRefresh" Text="ล้าง" runat="server" CssClass="master_OAT_button" OnClick="btnSearchRefresh_Click" />
            </div>
        </fieldset>
    </div>
      </asp:Panel>
<asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" CssClass="divpan" BackColor="White"  BorderColor="Aqua" DefaultButton="btnSubmitInsig2">
    <div>
        <fieldset>
            <legend>วัน/เดือน/ปี, ตำแหน่ง, ระดับ, ได้รับ ชั้น/รายการ</legend>
            <div>
                <table>
                    <tr>
                        <td style="text-align: left; width:100px">วัน/เดือน/ปี</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt0" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:60px">ตำแหน่ง</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt1" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:60px">ระดับ</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt2" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:120px">ได้รับ ชั้น/รายการ</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt3" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
        </div>
        </fieldset>
    </div>


 <div>
        <fieldset>
            <legend>ราชกิจจานุเบกษา</legend>
            <div>
                <table>
                    <tr>
                        
                        <td style="text-align: left; width:60px">เล่ม</td>
                        <td style="text-align: left; width: 185px;"><asp:TextBox ID="txtt4" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:60px">ตอน</td>
                        <td style="text-align: left; width: 178px;"><asp:TextBox ID="txtt5" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:60px">หน้า</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt6" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:80px">วัน/เดือน/ปี</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt7" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                    </tr>
                </table>
        </div>
        </fieldset>
    </div>
<div>
        <fieldset>
            <legend>ใบกำกับ , เหรียญตรา , หมายเหตุ</legend>
            <div>
                 <table>
                    <tr>
                        <td style="text-align: left; width:60px">ใบกำกับ</td>
                        <td style="text-align: left; width: 175px;"><asp:TextBox ID="txtt8" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                          <td style="text-align: left; width:90px">เหรียญตรา</td>
                        <td style="text-align: left; width: 180px;"><asp:TextBox ID="txtt9" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                         <td style="text-align: left; width:80px">หมายเหตุ</td>
                        <td style="text-align: left; width: 200px;"><asp:TextBox ID="txtt10" runat="server" CssClass="tb5" MaxLength="100" Width="150px"></asp:TextBox></td>
                        <td style="text-align: left; width:1px"></td>

                        <td style="text-align: left;"><asp:Button ID="btnSubmitInsig2" Text="บันทึก" runat="server" CssClass="master_OAT_button" OnClick = "btnSubmitInsig2_Click" /></td>
                        <td style="text-align: left;"><asp:Button ID="btnCancelInsig2" Text="ยกเลิก" runat="server" CssClass="master_OAT_button" OnClick = "btnCancelInsig2_Click" /></td>

                    </tr>
                </table>
            </div>
        </fieldset>
    </div>


    <div>
        <fieldset >
            <legend>Data</legend>
            <asp:UpdatePanel ID="UpdateGridView1" runat="server">
                                   <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" style="margin-left: auto; margin-right: auto; text-align: center; width:100% "
                AutoGenerateColumns="false"
                AllowPaging="true"
                DataKeyNames="ID"
                OnRowEditing="modEditCommand"
                OnRowCancelingEdit="modCancelCommand"
                OnRowUpdating="modUpdateCommand"
                OnRowDeleting="modDeleteCommand"
                OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="myGridView1_PageIndexChanging" PageSize="10" BackColor="White" BorderColor="#999999">
                <Columns>
                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua"/>
                    <asp:TemplateField HeaderText="ลบ" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                         <ItemTemplate>
                         <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" ></asp:LinkButton>                
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CITIZEN_ID" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblCITIZEN_ID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CITIZEN_ID") %>'></asp:Label>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วัน/เดือน/ปี" ItemStyle-Width="200" ControlStyle-Width="120" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl0" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt0" MaxLength="100" CssClass="date" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DDATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ตำแหน่ง" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_WORK_NAME") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt1" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_WORK_NAME") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ระดับ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt2" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_NAME") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ได้รับ ชั้น/รายการ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRADEINSIGNIA_NAME") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt3" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GRADEINSIGNIA_NAME") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="เล่ม" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_LAM") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt4" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_LAM") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ตอน" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_TON") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt5" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_TON") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="หน้า" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_NA") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt6" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GAZETTE_NA") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="วัน/เดือน/ปี" ItemStyle-Width="200" ControlStyle-Width="120" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl7" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "GAZETTE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>' ></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt7" MaxLength="100" CssClass="date" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "GAZETTE_DATE")).ToString("dd MMM yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ใบกำกับ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INVOICE") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt8" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INVOICE") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="เหรียญตรา" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DECORATION") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt9" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DECORATION") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="หมายเหตุ" ControlStyle-Width="150" HeaderStyle-BackColor="#0099FF" HeaderStyle-ForeColor="Aqua">
                            <ItemTemplate>
                            <asp:Label ID="lbl12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTES") %>'></asp:Label>
                            </ItemTemplate>
                                    <EditItemTemplate>
                            		<asp:TextBox ID="txt10" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTES") %>'></asp:TextBox>
                        		    </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </ContentTemplate>
                                  <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                  </Triggers>
                             </asp:UpdatePanel>

        </fieldset>
    </div>
  </asp:Panel>
</asp:Content>