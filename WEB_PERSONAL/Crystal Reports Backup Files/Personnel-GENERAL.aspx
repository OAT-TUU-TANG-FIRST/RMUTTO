<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Personnel-GENERAL.aspx.cs" Inherits="WEB_PERSONAL.Personnel_GENERAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="Script/jquery-ui-1.8.20.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#ContentPlaceHolder1_txtBIRTHDAY,#ContentPlaceHolder1_txtDATETIME_INWORRK").datepicker({
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
                dayNamesMin: ['อา', 'จ', 'อ', 'พ', 'พฤ', 'ศ', 'ส'],
                monthNamesShort: ['มกราคม', 'กุมภาพันธ์', 'มีนาคม', 'เมษายน', 'พฤษภาคม', 'มิถุนายน', 'กรกฎาคม', 'สิงหาคม', 'กันยายน', 'ตุลาคม', 'พฤศจิกายน', 'ธันวาคม'],
                yearRange: "-60:+40",
                beforeShow: function () {
                    $(".ui-datepicker").css('font-size', 14)
                    if ($(this).val() != "") {
                        var arrayDate = $(this).val().split("-");
                        arrayDate[2] = parseInt(arrayDate[2]) - 543;
                        $(this).val(arrayDate[0] + "-" + arrayDate[1] + "-" + arrayDate[2]);
                    }
                    setTimeout(function () {
                        $.each($(".ui-datepicker-year option"), function (j, k) {
                            var textYear = parseInt($(".ui-datepicker-year option").eq(j).val()) + 543;
                            $(".ui-datepicker-year option").eq(j).text(textYear);
                        });
                    }, 50);
                },
                onChangeMonthYear: function () {
                    setTimeout(function () {
                        $.each($(".ui-datepicker-year option"), function (j, k) {
                            var textYear = parseInt($(".ui-datepicker-year option").eq(j).val()) + 543;
                            $(".ui-datepicker-year option").eq(j).text(textYear);
                        });
                    }, 50);
                },
                onClose:function(){
                    if (dateBefore == null) {
                        dateBefore=$(this).val();
                    }
                    if($(this).val()!="" && $(this).val()==dateBefore){
                        var arrayDate=dateBefore.split("-");
                        arrayDate[2]=parseInt(arrayDate[2])+543;
                        $(this).val(arrayDate[0]+"-"+arrayDate[1]+"-"+arrayDate[2]);
                    }
                },
                onSelect: function (dateText, inst) {
                    dateBefore = $(this).val();
                    var arrayDate = dateText.split("-");
                    arrayDate[2] = parseInt(arrayDate[2]) + 543;
                    $(this).val(arrayDate[0] + "-" + arrayDate[1] + "-" + arrayDate[2]);
                    
                }
            });
        }    
    </script>
    <style type="text/CSS">
        .ui-datepicker{  
        font-family:tahoma;  
        text-align:center;
        color:dodgerblue;
        }  
        .multext{
            resize:none;
        }
         .a1{
            border-radius:20px;
            padding:5px 10px;
            background-color:#00ff21;
            text-decoration:none;
            color:black;
        }
         body {
            background-image: url("Image/444.png");
        }
        .tb5 {
            background-image: url(images/form_bg.jpg);
            background-repeat: repeat-x;
            border: 1px solid #d1c7ac;
            width: 230px;
            color: #333333;
            padding: 3px;
            margin-right: 4px;
            margin-bottom: 8px;
            font-family: tahoma, arial, sans-serif;
            border-radius: 10px;
            resize: none;
        }
        .textred{
            color:red;
        }
    </style>
    <asp:Panel runat="server" CssClass="divpan" Height="1200px" BackColor="White" ForeColor="#6699FF" BorderColor="Aqua" DefaultButton="btnSavePersonnel">
    <div>

        <fieldset>
            <legend style="margin-left: auto; margin-right: auto; text-align: center;">เพิ่มข้อมูลบุคลากร</legend>
            <div>
               <asp:ScriptManager ID="ScriptManager1" runat="server" />
                 <table>
                     <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">ปีการศึกษา <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">จังหวัด <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="DropDownYEAR" runat="server" Width="257px" CssClass="tb5" ></asp:DropDownList>
                         </td> 
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlPROVINCE" runat="server" Width="257px" OnSelectedIndexChanged="ddlPROVINCE_SelectedIndexChanged" AutoPostBack="true" CssClass="tb5"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPROVINCE" EventName="SelectedIndexChanged" />
                            </Triggers>
                            </asp:UpdatePanel>
                            </td> 
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownDEPARTMENT" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                     </tr>
                      <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">มหาวิทยาลัย <span class="textred">*</span></td>
                        <td style="text-align: left; "> </td> 
                        <td style="text-align: left; margin-right: 5px; ">อำเภอ <span class="textred">*</span></td>
                        <td style="text-align: left; "> </td> 
                        <td style="text-align: left; margin-right: 5px; ">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="DropDownUNIV" runat="server" CssClass="tb5" Width="257px" ></asp:DropDownList> 
                        </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                               <ContentTemplate>
                             <asp:DropDownList ID="ddlAMPHUR" runat="server" Width="257px" OnSelectedIndexChanged="ddlAMPHUR_SelectedIndexChanged" AutoPostBack="true" CssClass="tb5"></asp:DropDownList>
                             </ContentTemplate>
                            <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="ddlAMPHUR" EventName="SelectedIndexChanged" />
                            </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:TextBox ID="txtDATETIME_INWORRK" runat="server" MaxLength="100" Width="250px" CssClass="tb5"></asp:TextBox></td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">รหัสประจำตัวประชาชน <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ตำบล <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">สาขางานที่เชี่ยวชาญ <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                        <asp:TextBox ID="txtCITIZEN_ID" runat="server" MaxLength="13" Width="250px" CssClass="tb5" placeholder="รหัสประจำตัวประชาชน 13 หลัก"></asp:TextBox>   
                        </td>   
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                   <ContentTemplate>
                                      <asp:DropDownList ID="ddlDISTRICT" runat="server" OnSelectedIndexChanged="ddlDISTRICT_SelectedIndexChanged" Width="257px" AutoPostBack="true" CssClass="tb5"></asp:DropDownList>
                                   </ContentTemplate>
                                  <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="ddlDISTRICT" EventName="SelectedIndexChanged" />
                                  </Triggers>
                             </asp:UpdatePanel>
                         </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                          <asp:TextBox ID="txtSPECIAL_NAME" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="ตัวอย่าง ความปลอดภัยและประสิทธิภาพของยา"></asp:TextBox></td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">คำนำหน้าชื่อ (ยึดตามบัตรประชาชน) <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">รหัสไปรษณีย์ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">กลุ่มสาขาวิชาที่สอน(ISCED) <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:DropDownList ID="DropDownTITLE" runat="server" CssClass="tb5" Width="257px" Font-Bold="False"></asp:DropDownList>
                            </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                   <ContentTemplate>
                            <asp:TextBox ID="txtZIPCODE" runat="server" Width="250px" CssClass="tb5"></asp:TextBox>    
                                   </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownTEACH_ISCED" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                            
                        </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">ชื่อ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">หมายเลขโทรศัพท์ที่ทำงาน</td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ระดับการศึกษาที่จบสูงสุด <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtSTF_NAME" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="ชื่อ"></asp:TextBox>
                            </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                         <asp:TextBox ID="txtTELEPHONE" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="ตัวอย่าง(0-2456-5789) ต่อ 2240"></asp:TextBox>   
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownGRAD_LEV" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">นามสกุล <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">สัญชาติ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">หลักสูตรที่จบการศึกษาสูงสุด <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                           <asp:TextBox ID="txtSTF_LNAME" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="นามสกุล"></asp:TextBox>
                        </td>   
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                             <asp:DropDownList ID="DropDownNATION" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:TextBox ID="txtGRAD_CURR" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="ชื่อหลักสูตร/ชื่อสาขา"></asp:TextBox></td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">เพศ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ประเภทบุคลากร <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED) <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                             <asp:DropDownList ID="DropDownGENDER" runat="server" Width="257px" CssClass="tb5"></asp:DropDownList>
                            </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownSTAFFTYPE" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownGRAD_ISCED" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">วันเกิด <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ระยะเวลาจ้าง <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">สาขาวิชาที่จบสูงสุด <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtBIRTHDAY" runat="server" MaxLength="100" Width="250px" CssClass="tb5"></asp:TextBox>
                            </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownTIME_CONTACT" runat="server" Width="257px" CssClass="tb5"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownGRAD_PROG" runat="server" Width="257px" CssClass="tb5"></asp:DropDownList> 
                         </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">บ้านเลขที่ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ประเภทเงินจ้าง <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ชื่อสถาบันที่จบการศึกษาสูงสุด <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtHOMEADD" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="บ้านเลขที่"></asp:TextBox>
                            </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownBUDGET" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:TextBox ID="txtGRAD_UNIV" runat="server" MaxLength="70" Width="250px" CssClass="tb5" placeholder="ชื่อสถาบันที่จบการศึกษาสูงสุด"></asp:TextBox></td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">หมู่</td>
                        <td style="text-align: left; width: 80px;"> </td> 
                         <td style="text-align: left; margin-right: 5px; ">ประเภทบุคลากรย่อย <span class="textred">*</span></td> 
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ประเทศที่จบการศึกษาสูงสุด <span class="textred">*</span></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtMOO" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="หมู่บ้าน"></asp:TextBox>
                            </td> 
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownSUBSTAFFTYPE" runat="server" Width="257px" CssClass="tb5"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                            <asp:DropDownList ID="DropDownGRAD_COUNTRY" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                         </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; ">ถนน</td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ตำแหน่งบริหาร <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; "></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                            <asp:TextBox ID="txtSTREET" runat="server" MaxLength="100" Width="250px" CssClass="tb5" placeholder="ถนน"></asp:TextBox>
                        </td>   
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                             <asp:DropDownList ID="DropDownADMIN_POSITION" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;"> </td>
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; "></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ตำแหน่งทางวิชาการ <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; "></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                        </td>  
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                             <asp:DropDownList ID="DropDownPOSITION" runat="server" Width="257px" CssClass="tb5"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;"> </td> 
                     </tr>
                      <tr>
                        <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; margin-right: 5px; "></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; ">ตำแหน่งในสายงาน <span class="textred">*</span></td>
                        <td style="text-align: left; width: 80px;"> </td> 
                        <td style="text-align: left; margin-right: 5px; "></td>
                     </tr>
                     <tr>
                         <td style="text-align: left; width: 30px;"> </td>
                        <td style="text-align: left; width: 80px;">
                        </td> 
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;">
                             <asp:DropDownList ID="DropDownPOSITION_WORK" runat="server" CssClass="tb5" Width="257px"></asp:DropDownList>
                        </td>
                        <td style="text-align: left; width: 10px;"> </td> 
                        <td style="text-align: left; width: 170px;"> </td> 

                     </tr>
                 </table>

                 <table>
                          <tr>
                            <td style="text-align: left; width:350px; height:50px;"> </td> 
                            <td style="text-align: left; width: 50px;"> 
                            <asp:Button ID="btnCancelPersonnel" Text="Cancel" runat="server" OnClick="btnCancelPersonnel_Click" Width="140px" CssClass="master_OAT_button" /></td>
                            <td style="text-align: left; width: 50px;"> </td> 
                            <td style="text-align: right; margin-right: 5px; ">  
                            <asp:Button ID="btnSavePersonnel" Text="OK" runat="server" OnClick="btnSubmitPersonnel_Click" Width="140px" CssClass="master_OAT_button" /></td>
                           </tr>               
                </table>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div id="ajaxloader">
                            Loading..</div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                 <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <div id="ajaxloader">
                            Loading..</div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                 <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <div id="ajaxloader">
                            Loading..</div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                    <ProgressTemplate>
                        <div id="ajaxloader">
                            Loading..</div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
               
    </div>
        </fieldset>
    </div>
        </asp:Panel>
</asp:Content>
