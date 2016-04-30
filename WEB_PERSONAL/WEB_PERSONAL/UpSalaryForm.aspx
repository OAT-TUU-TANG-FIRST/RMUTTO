<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalaryForm.aspx.cs" Inherits="WEB_PERSONAL.UpSalaryForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
	table, th, td {
      border-collapse: collapse;
	}
	input[type="text"] {
     width: 100%; 
     box-sizing: border-box;
     -webkit-box-sizing:border-box;
     -moz-box-sizing: border-box;
	}	
   
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<p align="right" style="font-size:15px"><b> (แบบที่ 1)</b> </p>
	        <p align="center" style="font-size:16px"><b>แบบข้อตกลงการประเมินผลสัมฤทธิ์ของงาน ของข้าราชการพลเรือนในสถาบันอุดมศึกษา หรือพนักงานในสถาบันอุดมศึกษา <br />มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</b></p>
	        <p align="center" style="font-size:16px"><b>ตำแหน่งประเภทผู้บริหาร (ไม่ครองตำแหน่งวิชาการ) (องค์ประกอบที่ 1 ผลสัมฤทธิ์ของงาน
                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
&nbsp;)</b></p>
	        <br />
            <p align="center" style="font-size:15px"><b>รอบการประเมิน</b>
            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            &nbsp;<b>วัน&nbsp;&nbsp;&nbsp;</b><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            &nbsp; <b>เดือน</b>
            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            &nbsp; <b>ปีพ.ศ.</b>
            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            </p>
	        <br />
            <p align="left" style="font-size:15px"><b>ชื่อผู้รับการประเมิน
            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            &nbsp;ตำแหน่ง
            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;สังกัด </b>
            <b>
            <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            </b></p>
            <br />
	        <p align="left" style="font-size:15px"><b>ชื่อผู้ประเมิน
            <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            &nbsp;ตำแหน่ง
            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;สังกัด </b>
            <b>
            <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
            </b></p>
	
	<form >
		<table border="2px solid black" height= "auto" >
			<tr>
				<th align="center" rowspan="2" width="300" style="font-size:15px">(1) กิจกรรม / โครงการ / งาน</th>
				<th align="center" rowspan="2" width="70" style="font-size:15px">(2)ค่า<br>น้ำหนัก%</th>
				<th align="center" rowspan="2" width="230" style="font-size:15px">(3)คำอธิบาย<br>ตัวชี้วัด<br>โดยย่อ</th>
				<th align="center" rowspan="2" style="font-size:15px">(4)ค่า<br>เป้าหมาย</th>
				<th align="center" rowspan="2" style="font-size:15px">(5)ข้อมูลพื้นฐาน<br>(Base Line)ใน<br>รอบการประเมินที่ผ่านมา</th>
				<th align="center" colspan="5" style="font-size:15px">(6)ระดับค่า<br>เป้าหมาย</th>
				<th align="center" rowspan="2" style="font-size:15px">(7)ผลการ<br>ดำเนิน<br>งาน</th>
				<th align="center" rowspan="2" style="font-size:15px">(8)ค่า<br>คะแนน<br>ที่ได้</th>
				<th align="center" rowspan="2"rowspan="2" style="font-size:15px">(9)<br>ค่าคะแนน<br>ถ่วงน้ำหนัก<br>(8)x(2)/80</th>
				<th align="center" rowspan="2" style="font-size:15px">(10)รายการหลักฐาน</th>
			</tr>
			<tr>
				<td align="center" style="font-size:14px"><b>1</b></td>
				<td align="center" style="font-size:14px"><b>2</b></td>
				<td align="center" style="font-size:14px"><b>3</b></td>
				<td align="center" style="font-size:14px"><b>4</b></td>
				<td align="center" style="font-size:14px"><b>5</b></td>
			</tr>
			<tr bgcolor="grey">
				<td valign="top" style="font-size:16px" ><b>1.&nbsp;ภาระงานหลัก </b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td style="font-size:14px" valign="top">
                    <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
				</td>
				<td valign="top" align="center" style="font-size:14px">
                    <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                </td>
				<td valign="top" style="font-size:14px">
                    <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
				</td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                </td>
				<td valign="top"></td>
				<td valign="top" align="center" style="font-size:15px"><b>1</b></td>
				<td valign="top" align="center" style="font-size:15px"><b>2</b></td>
				<td valign="top" align="center" style="font-size:15px"><b>3</b></td>
				<td valign="top" align="center" style="font-size:15px"><b>4</b></td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top" style="font-size:15px">
					<asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                <br />
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
				</td>
			</tr>
			<tr valign="top">
				<td valign="top" style="font-size:15px">
                <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
				</td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">
                    <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                </td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
			</tr>
			<tr valign="top">
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center"style="font-size:15px">
                    <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px" valign="top">
				<asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                   
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center"style="font-size:15px">
                    <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">
				    <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox39" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                </td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">
				    <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload5" runat="server" />
                </td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox44" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox45" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">&nbsp;<asp:TextBox ID="TextBox46" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox47" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload6" runat="server" />
                </td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox48" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox49" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">&nbsp;<asp:TextBox ID="TextBox50" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox51" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload7" runat="server" />
                </td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox52" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox53" runat="server"></asp:TextBox>
                </td>
				<td style="font-size:15px">
                    <asp:TextBox ID="TextBox54" runat="server"></asp:TextBox>
				</td>
				<td>
                    <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox>
                </td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                </td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload8" runat="server" />
                </td>
			</tr>
			<tr bgcolor="grey">
				<td valign="top" style="font-size:15px"><b>2. งานส่วนรวม</b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px">
                    <asp:TextBox ID="TextBox56" runat="server"></asp:TextBox>
				</td>
				<td valign="top" align="center" style="font-size:15px">
                    <asp:TextBox ID="TextBox57" runat="server"></asp:TextBox>
                </td>
				<td valign="top" style="font-size:15px">&nbsp;</td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                </td>
				<td valign="top" align="center">
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
				<td valign="top">
                    <asp:FileUpload ID="FileUpload9" runat="server" />
                </td>
			</tr>
			<tr>
				<td></td>
				<td align="center" style="font-size:15px">
                    <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                </td>
				<td colspan="10" align="right" style="font-size:15px"><b>(10) ผลรวมค่าคะแนนที่ได้ align="center"><b>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></b>
                </td>
				<td></td>
			</tr>
			<tr>
				<td colspan="12" align="right" style="font-size:15px"><b>
					(11)&nbsp;&nbsp;&nbsp;สรุปคะแนนส่วนผลสัมฤทธิ์ของงาน&nbsp;&nbsp;&nbsp;=&nbsp;&nbsp;&nbsp;ผลรวมของค่าคะแนนถ่วงน้ำหนัก&nbsp;x&nbsp;80&nbsp;/&nbsp;5&nbsp;=&nbsp;</b>
				</td>
				<td align="center"><b>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></b>
                </td>
				<td></td>
			</tr>
		</table>
	</form>
    <br />
    <br />
    <p align="center"><asp:Button ID="Button1" runat="server" Text="คำนวน" Width="100px" Font-Bold="True" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="บันทึก" Visible="False" Width="100px" Font-Bold="True" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="ต่อไป" Width="100px" Font-Bold="True"/>
    </p>

</asp:Content>
