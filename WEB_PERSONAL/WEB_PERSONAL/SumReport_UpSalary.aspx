<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SumReport_UpSalary.aspx.cs" Inherits="WEB_PERSONAL.SumReport_UpSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
    table, th, td {
        border-collapse: collapse;
	}
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="center"><img src="Image/RMUTTO.png" width="90" height="150" ></p>
	
	<p align="center" style="font-size:16px"><b>แบบสรุปการประเมินผลการปฏิบัติราชการของข้าราชการพลเรือนในสถาบันอุดมศึกษาหรือพนักงานในสถาบันอุดมศึกษา</b></p>

	<p align="center" style="font-size:16px"><b>มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</b></p>
    
    <br />

	<p style="font-size:16px"><u><b>ส่วนที่&nbsp;1:&nbsp;ข้อมูลของผู้รับการประเมิน</b></u></p>
    
    <br />

	<p align="left" style="font-size:15px">
    <b>รอบการประเมิน&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;<b>วันที่&nbsp;</b>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;<b>เดือน&nbsp;</b>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    &nbsp;<b>ปีพ.ศ.</b>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </p>
    <br />
    <p align="left" style="font-size:15px"><b>ชื่อผู้รับการประเมิน&nbsp;&nbsp; &nbsp;</b><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </p>
    <br />
	<p style="font-size:15px"><b>ตำแหน่ง&nbsp;</b>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;<b>ประเภทตำแหน่ง&nbsp;</b>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    </p>
    <br />
	<p style="font-size:15px"><b>ชื่อผู้บังคับบัญชา/ผู้ประเมิน&nbsp;&nbsp;</b>
        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    </p>
    <br />
	<p style="font-size:15px"><b>ตำแหน่ง&nbsp;</b>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
    </p>
    <br />
    <br />
	<form >
	<table style="font-size:15px" border="1px solid black" border-collapse= "collapse" height= "auto" width="595">
		<tr>
			<td>
				<p style="text-align:left" style="font-size:15px"><u>คำชี้แจง</u></p>
				<p style="text-align:left" style="font-size:15px">แบบสรุปการประเมินผลการปฏิบัติงานนี้มีด้วยกัน&nbsp;3&nbsp;หน้า&nbsp;ประกอบด้วย</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;ส่วนที่&nbsp;1:&nbsp;<u>ข้อมูลของผู้รับการประเมิน</u>&nbsp;เพื่อระบุรายละเอียดต่างๆ ที่เกี่ยวข้องกับตัวผู้รับการประเมิน</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;ส่วนที่&nbsp;2:&nbsp;<u>สรุปผลการประเมิน</u>&nbsp;ใช้เพื่อกรอกค่าคะแนนการประเมินในองค์ประกอบด้านผลสัมฤทธิ์ของงาน องค์ประกอบด้านพฤติกรรมการปฏิบัติราชการ&nbsp;(สมรรถนะ) และน้ำหนักของทั้งสององค์ประกอบ  ในแบบสรุปส่วนที่ 2 นี้ ยังใช้สำหรับคำนวณคะแนนผลการปฏิบัติราชการรวมด้วย</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;สำหรับคะแนนองค์ประกอบด้วยผลสัมฤทธิ์ของงาน ให้นำมาจากแบบประเมินผลสัมฤทธิ์ของงาน โดยให้แนบท้ายแบบสรุปฉบับนี้</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp; สำหรับคะแนนองค์ประกอบด้านสมรรถนะ ให้นำมาจากแบบประเมินสมรรถนะ โดยให้แนบท้ายแบบสรุปฉบับนี้</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;ส่วนที่&nbsp;3:&nbsp;<u>แผนพัฒนาผลการปฏิบัติราชการรายบุคคล</u>&nbsp;ผู้ประเมินและผู้รับการประเมินร่วมกันจัดทำแผนพัฒนาผลการปฏิบัติราชการ</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;ส่วนที่&nbsp;4:&nbsp;<u>การรับทราบผลการประเมิน</u>&nbsp;ผู้รับการประเมินลงนามรับทราบผลการประเมิน</p>
				<p style="text-align:left" style="font-size:15px">&nbsp;&nbsp;ส่วนที่&nbsp;5:&nbsp;<u>ความเห็นของผู้บังคับบัญชาเหนือขึ้นไป</u>&nbsp;ผู้บังคับบัญชาเหนือขึ้นไปกลั่นกรองผลการประเมิน แผนพัฒนาผลการปฏิบัติราชการ และให้ความเห็น</p>
			</td>
		</tr>
	</table>
	</form>
	<br />
	<p style="text-align:left" style="font-size:16px"><u><b>ส่วนที่&nbsp;2:&nbsp;การสรุปผลการประเมิน</b></u></p>
    <br />

	<table style="font-size:15px" align="center" border="1px solid black" height="auto" width="595">
		<tr>
			<td align="center">องค์ประกอบการประเมิน</td>
			<td align="center">คะแนน</td>
			<td align="center">คะแนนที่ได้</td>
		</tr>
		<tr>
			<td>องค์ประกอบที่ 1: ผลสัมฤทธิ์ของงาน</td>
			<td align="center">80%</td>
			<td align="center"></td>
		</tr>
		<tr>
			<td>องค์ประกอบที่ 2: พฤติกรรมการปฏิบัติราชการ</td>
			<td align="center">20%</td>
			<td align="center"></td>
		</tr>
		<tr>
			<td align="center">รวม</td>
			<td align="center">100%</td>
			<td align="center"></td>
		</tr>
	</table>
	<br>
	<p style="font-size:16px"><b><u>ระดับผลการประเมิน</u></b></p>
    <br />
	
	<table style="font-size:15px">
		<tr>
			<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" Text="ดีเด่น&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;90.00 – 100&nbsp;)" />
                <br></td>
		</tr>
		<tr>
			<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="ดีมาก&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;80.00 – 89.99&nbsp;)" />
            </td>
		</tr>
		<tr>
			<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" Text="ดี&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;70.00 – 79.99&nbsp;)" />
                &nbsp;&nbsp;<br></td>
		</tr>
		<tr>
			<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton4" runat="server" Text="พอใช้&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;60.00 – 69.99&nbsp;)" />
                &nbsp;&nbsp;<br></td>
		</tr>
		<tr>
			<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton5" runat="server" Text="ต้องปรับปรุง&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (&nbsp;ต่ำกว่า&nbsp;60&nbsp;)" />
                &nbsp;</td>
		</tr>
	</table>
	
	<br />

	<p style="font-size:16px"><u><b>ส่วนที่&nbsp;3:&nbsp;แผนพัฒนาการปฏิบัติราชการรายบุคคล</b></u></p>
    <br />
	
	<table style="font-size:15px" align="center" border="1px solid black" height="auto" width="595">
			<tr>
				<td align="center">ความรู้/&nbsp;ทักษะ/&nbsp;สมรรถนะ ที่ต้องได้รับการพัฒนา</td>
				<td align="center">วิธีการพัฒนา</td>
				<td align="center">ช่วงเวลาที่ต้องการการพัฒนา</td>
			</tr>
			<tr>
				<td align="center">
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    <br></td>
			</tr>
			<tr>
				<td align="center">
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    <br></td>
			</tr>
			<tr>
				<td align="center">
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                    <br></td>
			</tr>
			<tr>
				<td align="center">
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                    <br></td>
				<td align="center">
                    <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    <br></td>
			</tr>
		</table>
	<br>
	<p style="font-size:16px"><u><b>ส่วนที่&nbsp;4:&nbsp;การรับทราบผลการประเมิน</b></u></p>
	<br />
		<table style="font-size:15px" align="center" border="1px solid black" height="auto" width="595">
			<tr>
				<td style="font-size:15px" valign="top" class="auto-style1">
					<p ><b>ผู้รับการประเมิน&nbsp;:</b></p>

					<p >
                        &nbsp;&nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="ได้รับทราบผลการประเมินและแผนพัฒนาการปฏิบัติราชการรายบุคคลแล้ว" />
                    </p>
				</td>
				<td style="font-size:15px" valign="top">
					<p>ลงชื่อ&nbsp;:&nbsp;<asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                    </p>
					<p>ตำแหน่ง&nbsp;:&nbsp;<asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                    </p>
					<p>วันที่&nbsp;:&nbsp;<asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                    </p>
				</td>
			</tr>
			<tr>
				<td style="font-size:15px" valign="top">
					<p><b>ผู้ประเมิน&nbsp;:</b></p>
					<p>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="ได้แจ้งผลการประเมินและผู้รับการประเมินได้ลงนามรับทราบ" />
                    </p>
					<p><asp:CheckBox ID="CheckBox1" runat="server" Text="ได้แจ้งผลการประเมินเมื่อวันที่..............แต่ผู้รับการประเมินไม่ลงนามรับทราบผลการประเมิน โดยมี.......................................เป็นพยาน" /></p>
                        <br />
                        <br />
      				<p align="right">ลงชื่อ
                        <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
&nbsp;พยาน</p>
      				<p align="right">ตำแหน่ง
                        <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
&nbsp;</p>
      				<p align="right">วันที่
                        <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                    </p>
				</td>
				<td style="font-size:15px" valign="top">
					<p>ลงชื่อ&nbsp;:&nbsp;<asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                    </p>
					<p>ตำแหน่ง&nbsp;:&nbsp;<asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                    </p>
					<p>วันที่&nbsp;:&nbsp;<asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    </p>
				</td>
			</tr>
		</table>
	
	<br />
	<p style="font-size:15px" valign="top"><b><u>ส่วนที่&nbsp;5&nbsp;:ความเห็นของผู้ประเมิน/ผู้บังคับบัญชาเหนือขึ้นไป</u></b></p>
	
		<table align="center" border="1px solid black" height="auto" width="595">
		<tr>
			<td>
				<p><b>ความเห็นของผู้ประเมิน&nbsp;:</b></p>
				<p><b><u>ความคิดเห็นและข้อเสนอแนะ</u></b></p>
				<br>
				<asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
				<br>
				<br>
      			<br>
      			<br>
			</td>
			<td>
				<p>ลงชื่อ&nbsp;:&nbsp;...................................</p>
				<p>ตำแหน่ง&nbsp;:&nbsp;..............................</p>
				<p>วันที่&nbsp;:&nbsp;.....................................</p>
			</td>
		</tr>
		<tr>
			<td>
				<p><b>ผู้บังคับบัญชาเหนือขึ้นไป&nbsp;(ถ้ามี)&nbsp;:</b></p>
				<p><b><input type="radio" name="assessment_4" value="Yes">&nbsp;&nbsp;เห็นด้วยกับผลการประเมิน</b></p>
				<p><b><input type="radio" name="assessment_4" value="No">&nbsp;&nbsp;มีความเห็นต่าง ดังนี้
      			</b></p>
      			<br />
      			<br />
      			<br />
      			<br />
      			<br />
      		
			</td>
			<td>
				<p>ลงชื่อ&nbsp;:&nbsp;...................................</p>
				<p>ตำแหน่ง&nbsp;:&nbsp;..............................</p>
				<p>วันที่&nbsp;:&nbsp;.....................................</p>
			</td>
		</tr>
	</table>
	
</asp:Content>
