<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary80_20_1.aspx.cs" Inherits="WEB_PERSONAL.UpSalary80_20_1" enableEventValidation="false" %>
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

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <p align="right" style="font-size:15px"><b> (แบบที่ 1)</b> </p>
	        <p align="center" style="font-size:16px"><b>แบบข้อตกลงการประเมินผลสัมฤทธิ์ของงาน ของข้าราชการพลเรือนในสถาบันอุดมศึกษา หรือพนักงานในสถาบันอุดมศึกษา <br />มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</b></p>
	        <p align="center" style="font-size:16px"><b>ตำแหน่งประเภทผู้บริหาร (ไม่ครองตำแหน่งวิชาการ) (องค์ประกอบที่ 1 ผลสัมฤทธิ์ของงาน 80%)</b></p>
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
				<td style="font-size:14px"><b>1.1&nbsp;&nbsp;การบริหารจัดการภาระงานตามตำแหน่งหน้าที่</b>
				<br>
				(1) การวางแผนกลยุทธ์ตามภาระงานที่รับผิดชอบ
				<br>
				- ด้านการบริหารทรัพยากรบุคคล
				<br>
				- ด้านการบริหารงบประมาณ
				<br>
				- ด้านการบริหารพัสดุ
				<br>
				- ด้านการบริหารจัดการทั่วไป
				<br>
				- ด้านการบริหารจัดการพัฒนานักศึกษา
				<br>
				- ด้านการบริหารกิจการงานสภามหาวิทยาลัย
				<br>
				- ด้านการบริหารกิจการวิเทศสัมพันธ์
				<br>
				- ด้านการวางระบบงาน
				<br>
				- ด้านระบบงานสารบรรณ
				<br>
				- ด้านการประสานงาน
				</td>
				<td valign="top" align="center" style="font-size:14px"><b>30</b></td>
				<td valign="top" style="font-size:14px">ระดับความสำเร็จในการบริหารจัดการภาระงานตามตำแหน่งหน้าที่ด้าน.................................................
				<br>
				<b><u>ระดับที่ 1</u></b>ผลงานที่ปฏิบัติได้ต่ำกว่าเกณฑ์ขั้นต่ำร้อยละ 10
				<br>
				<b><u>ระดับที่ 2</u></b>ผลงานที่ปฏิบัติได้ต่ำกว่าเกณฑ์ขั้นต่ำร้อยละ 5
				<br>
				<b><u>ระดับที่ 3</u></b>ผลงานที่ปฏิบัติได้ตามเกณฑ์ขั้นต่ำ
				<br>
				<b><u>ระดับที่ 4</u></b>ผลงานที่ปฏิบัติได้สูงกว่าเกณฑ์ขั้นต่ำร้อยละ 5
				<br>
				<b><u>ระดับที่ 5</u></b>ผลงานที่ปฏิบัติได้สูงกว่าเกณฑ์ขั้นต่ำร้อยละ 10 
				</td>
				<td valign="top" align="center" style="font-size:15px"><b>ระดับ</b></td>
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
					แผนกุลยุทธ์ของคณะ/หน่วยงาน
				<br />
					รายงานการดำเนินการตามแผนกลยุทธ์
                <br />
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
				</td>
			</tr>
			<tr>
				<td valign="top" style="font-size:15px"><b>1.2 ภาระงาน QA /สมศ./กพร./สกอ./ยุทธศาสตร์ของมหาวิทยาลัย</b>
				<br>
				(1) การบริหารความเสี่ยง เช่น
				<br>
				ความเสี่ยงด้านการบริหารทรัพยากรบุคคล
				<br>
				การคลัง การพัสดุ สิ่งแวดล้อม การประหยัดพลังงาน ไฟฟ้า ด้านอาคารและสถานที่ 
				<br>
				การประกันคุณภาพ
				</td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">ระดับความสำเร็จในการบริหารจัดการความเสี่ยง
				<br>
				<b><u>ระดับที่ 1</u></b>มีแผนบริหารจัดการความเสี่ยงที่เกี่ยวข้องและสอดคล้องกับนโยบายของหน่วยงาน
				<br>
				<b><u>ระดับที่ 2</u></b>ดำเนินการตามแผนบริหารจัดการความเสี่ยง
				<br>
				<b><u>ระดับที่ 3</u></b>ดำเนินการตามแผนบริหารจัดการความเสี่ยงและร่างรายงานผลการดำเนินการ
				<br>
				<b><u>ระดับที่ 4</u></b>รายงานผลการดำเนินการตามแผนการปฏิบัติงาน ปัญหา อุปสรรค ที่พบเพื่อนำไปสู่การพัฒนา
				<br>
				<b><u>ระดับที่ 5</u></b>ทบทวน ปรับปรุง และพัฒนาบริหารความเสี่ยง และการเปรียบเทียบการบริหารจัดการความเสี่ยง เพื่อนำไปพัฒนาขั้นสูงและเผยแพร่ต่อไป
				</td>
				<td></td>
				<td></td>
				<td></td>
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
			<tr>
				<td valign="top" style="font-size:15px">(2) การจัดเก็บและติดตามข้อมูลประกอบการประกันคุณภาพการศึกษาทั้งภายในและภายนอก  QA/สมศ./กพร./สกอ.</td>
				<td valign="top" align="center"style="font-size:15px"><b>10</b></td>
				<td style="font-size:15px">
				ระดับความสำเร็จในการจัดเก็บและติดตามข้อมูลประกอบการประกันคุณภาพการศึกษาทั้งภายในและภายนอก  QA /สมศ./กพร./สกอ.
				<br>
				<b><u>ระดับที่ 1</u></b>จัดทำแผนการจัดเก็บและติดตามข้อมูล
				<br>
				<b><u>ระดับที่ 2</u></b>ประชุมผู้ที่เกี่ยวข้องและรับผิดชอบ KPIs เดือนละครั้ง
				<br>
				<b><u>ระดับที่ 3</u></b>ติดตาม ตรวจสอบข้อมูล และการวิเคราะห์ข้อมูล
				<br>
				<b><u>ระดับที่ 4</u></b>รายงานความก้าวหน้าในการจัดเก็บข้อมูลและเตรียมการประเมิน
				<br>
				<b><u>ระดับที่ 5</u></b>ข้อมูลและเอกสารสมบูรณ์พร้อมต่อการตรวจประเมิน
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">(3) การจัดทำรายงานประจำปีของคณะ/หน่วยงาน</td>
				<td valign="top" align="center"style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">
				ระดับความสำเร็จในการจัดทำรายงานประจำปี
				<br>
				<b><u>ระดับที่ 1</u></b>มีแผนการจัดทำรายงานประจำปีของหน่วยงานให้แล้วเสร็จภายใน 2 เดือน
				<br>
				<b><u>ระดับที่ 2</u></b>รวบรวมข้อมูลที่เกี่ยวข้องเพื่อดำเนินการตามแผนการจัดทำรายงานประจำปีของคณะ/หน่วยงาน
				<br>
				<b><u>ระดับที่ 3</u></b>จัดทำร่างรายงานประจำปีของคณะ/หน่วยงาน
				<br>
				<b><u>ระดับที่ 4</u></b>รายงานความก้าวหน้าในการจัดเก็บข้อมูลและเตรียมการประเมินรายงานประจำปีของคณะ/หน่วยงาน เสร็จเรียบร้อยสมบูรณ์ตามกำหนดและสามารถรายงานตัวชี้วัดการประเมินคุณภาพทั้งภายในและภายนอกมหาวิทยาลัย
				<br>
				<b><u>ระดับที่ 5</u></b>เผยแพร่รายงานประจำปีของคณะ/หน่วยงาน ที่เสร็จเรียบร้อยสมบูรณ์ ให้คณะ/หน่วยงาน ต่าง ๆ ทราบและเป็นข้อมูล
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">(4) การบริหารจัดการความรู้ (KM)</td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">
				ระดับความสำเร็จในการบริหารจัดการความรู้ (KM)
				<br>
				<b><u>ระดับที่ 1</u></b>มีแผนบริหารจัดการความรู้
				<br>
				<b><u>ระดับที่ 2</u></b>ดำเนินการตามแผนการบริหารจัดการความรู้อย่างน้อย1 เรื่องต่อรอบการประเมิน
				<br>
				<b><u>ระดับที่ 3</u></b>ดำเนินการตามแผนการบริหารจัดการความรู้อย่างน้อย2 เรื่องต่อรอบการประเมิน
				<br>
				<b><u>ระดับที่ 4</u></b>รายงานผลการดำเนินการตามแผนการปฏิบัติงาน ปัญหาอุปสรรค ที่พบเพื่อนำไปสู่การพัฒนา และสามารถรายงานตัวชี้วัดการประเมินคุณภาพทั้งภายในและภายนอกมหาวิทยาลัย
				<br>
				<b><u>ระดับที่ 5</u></b>ทบทวน ปรับปรุง และพัฒนาการจัดการความรู้ และการเปรียบเทียบองค์ความรู้ ก่อนและหลัง เพื่อนำไปพัฒนาขั้นสูง และเผยแพร่ต่อไป
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">(5) การประหยัดพลังงาน</td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">ระดับความสำเร็จในการประหยัดพลังงาน
				<br>
				<b><u>ระดับที่ 1</u></b>มีแผนในการประหยัดพลังงานของหน่วยงาน
				<br>
				<b><u>ระดับที่ 2</u></b>แต่งตั้งคณะกรรมการประหยัดพลังงานของหน่วยงานและมีการประชุมคณะกรรมการ
				<br>
				<b><u>ระดับที่ 3</u></b>คณะกรรมการร่างมาตรการประหยัดพลังงาน และนำเสนอคณะกรรมการพิจารณา แก้ไข ปรับปรุง เพิ่มเติม
				<br>
				<b><u>ระดับที่ 4</u></b>ประชาสัมพันธ์ให้บุคลากรในหน่วยงานรับทราบถือปฏิบัติและมีการติดตามประเมินผลการปฏิบัติตามมาตรการ
				<br>
				<b><u>ระดับที่ 5</u></b>รายงานผลการประหยัดพลังงาน เสนอต่อผู้บริหาร และรายงานผลต่อการประกันคุณภาพทั้งภายในและภายนอกมหาวิทยาลัย
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">(6) การประเมินความพึงพอใจของผู้รับบริการ</td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">ร้อยละความพึงพอใจของผู้รับบริการโดยเฉลี่ย
				<br>
				<b><u>ระดับที่ 1</u></b> ≤ ร้อยละ 55
				<br>
				<b><u>ระดับที่ 2</u></b> ≥ ร้อยละ 65
				<br>
				<b><u>ระดับที่ 3</u></b>≥ ร้อยละ 75
				<br>
				<b><u>ระดับที่ 4</u></b> ≥ ร้อยละ 85
				<br>
				<b><u>ระดับที่ 5</u></b> ≥ ร้อยละ 90
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">(7) กระบวนการบริการวิชาการด้านการบริหารทรัพยากรบุคคลให้เกิดประโยชน์ต่อบุคลากร</td>
				<td valign="top" align="center" style="font-size:15px"><b>5</b></td>
				<td style="font-size:15px">ระดับความสำเร็จในกระบวนการบริการวิชาการด้านการบริหารทรัพยากรบุคคลให้เกิดประโยชน์ต่อบุคลากร
				<br>
				<b><u>ระดับที่ 1</u></b>มีการสำรวจความต้องการของบุคลากรเพื่อประกอบการกำหนดทิศทางและจัดทำแผนการบริการทางวิชาการ
				<br>
				<b><u>ระดับที่ 2</u></b>มีความร่วมมือด้านบริการวิชาการเพื่อการเรียนรู้ และการเสริมสร้างความเข้มแข็งในวิชาชีพด้านบริหารทรัพยากรบุคคล
				<br>
				<b><u>ระดับที่ 3</u></b>มีการประเมินผลประโยชน์ หรือผลกระทบของการบริการวิชาการด้านการบริหารทรัพยากรบุคคลต่อบุคคล
				<br>
				<b><u>ระดับที่ 4</u></b>มีการนำผลการประเมินจากข้อ 3 ไปพัฒนากลไก หรือกิจกรรมในการบริการ
				<br>
				<b><u>ระดับที่ 5</u></b>มีการพัฒนาความรู้ที่ได้จากการให้บริการวิชาการและถ่ายทอดความรู้สู่บุคลากร และสามารถรายงานตัวชี้วัดการประเมินคุณภาพทั้งภายในและภายนอกมหาวิทยาลัย
				</td>
				<td></td>
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
				<td valign="top" style="font-size:15px">ภาระงานนอกเหนือจากภาระงานหลักเช่น 
				<br>
				กฐินพระราชทาน/พิธีพระราชทานปริญญาบัตร/ผ้าป่า/ปฐมนิเทศ-ปัจฉิมนิเทศ/กีฬาบุคลากร/
				<br>
				รับสมัครนักศึกษา/กิจกรรมลอยกระทง/สัปดาห์วิชาการ/กิจกรรมงานเกษียณ/วันสถาปนามหาวิทยาลัย/งานเกษตรแฟร์/งานแห่พญายมประเพณีกองข้าว/งานสานสัมพันธ์จักรพงษภูวนารถ/วันสำคัญทางศาสนา/วันสำคัญของชาติ/วันเฉลิมพระชนมพรรษาฯ/ศูนย์สอบ v – net/ประชุมวิชาการนานาชาติของ มทร. 9 แห่ง/
				<br>
				งานนัดพบแรงงาน/งานรักษ์เหลืองจันทร์/
				<br>
				งานรับสมัครบุคลากร/การออกข้อสอบตัดเลือกกรรมการสอบสวน
				</td>
				<td valign="top" align="center" style="font-size:15px"><b>10</b></td>
				<td valign="top" style="font-size:15px">จำนวนครั้งในการเข้าร่วมกิจกรรมของมหาวิทยาลัย/คณะ/หน่วยงาน
				<br>
				<b><u>ระดับที่ 1</u></b>จำนวน 2-3 ครั้งในรอบการประเมิน
				<br>
				<b><u>ระดับที่ 2</u></b>จำนวน 4-5 ครั้งในรอบการประเมิน
				<br>
				<b><u>ระดับที่ 3</u></b>จำนวน 6-7 ครั้งในรอบการประเมิน
				<br>
				<b><u>ระดับที่ 4</u></b>จำนวน 8-9 ครั้งในรอบการประเมิน
				<br>
				<b><u>ระดับที่ 5</u></b>จำนวน 10 ครั้งขึ้นไปในรอบการประเมิน
				</td>
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
				<td align="center" style="font-size:15px"><b>80</b></td>
				<td colspan="10" align="right" style="font-size:15px"><b>(10) ผลรวมค่าคะแนนที่ได้</b></td>
				<td align="center"><b>
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
    <p align="center"><asp:Button ID="Button1" runat="server" Text="คำนวน" Width="100px" OnClick="Button1_Click" Font-Bold="True" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="บันทึก" Visible="False" Width="100px" Font-Bold="True" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="ต่อไป" Width="100px" OnClick="Button2_Click" Font-Bold="True"/>
    </p>
        </asp:View>
        
        <asp:View ID="View2" runat="server">
        
		   <table border="2px solid black" height= "auto" >
              <tr>
				<td colspan="14" style="font-size:15px"><b>
                    <br />
					(12)  ผู้ประเมินและผู้รับการประเมินได้ตกลงร่วมกันและเห็นพ้องกันแล้ว  จึงลงลายมือชื่อไว้เป็นหลักฐาน  (ลงนามเมื่อจัดทำข้อตกลง)</b>
                    <br />
				    <br />
				    <b>ลายมือชื่อ&nbsp;</b>
                    <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>&nbsp;(ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>ลายมือชื่อ&nbsp;</b>
                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>(ผู้รับการประเมิน)</b>
				    <br />
				    <b>วันที่</b>
                    <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                    <b>&nbsp;เดือน</b>
                    <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                    <b>&nbsp;พ.ศ.</b>
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>วันที่</b>
                    <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                    <b>&nbsp;เดือน</b>
                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                    <b>&nbsp;พ.ศ.&nbsp;</b>
                    <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </td>
			</tr>
			<tr>
				<td colspan="14" style="font-size:15px"><b>
                    <br />
					(13)  ความเห็นเพิ่มเติมของผู้ประเมิน (ระบุข้อมูลเมื่อสิ้นรอบการประเมิน)</b>
                    <br />
				 <br />
				 1)  จุดเด่น  และ/หรือ สิ่งที่ควรปรับปรุงแก้ไข
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" Height="120px" Width="420px" ></asp:TextBox>
             	    <br />
             	 <br />
				 2)  ข้อเสนอแนะเกี่ยวกับวิธีส่งเสริมและพัฒนา
				    <br />
                    <asp:TextBox ID="TextBox22" runat="server" Height="120px" Width="420px"></asp:TextBox>
				    <br />
				 </td>
			</tr>
			<tr>
				<td colspan="14" style="font-size:15px"><b>
					<br />
					(14)  ผู้ประเมินและผู้รับการประเมินได้เห็นชอบผลการประเมินแล้ว  จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อสิ้นรอบการประเมิน)</b>
                    <br />
				    <br /><b>
				    ลายมือชื่อ&nbsp;</b>
                    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                    &nbsp; <b>(ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>ลายมือชื่อ&nbsp;</b>
                    <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                    &nbsp; <b>(ผู้รับการประเมิน)</b>
				    <br /><b>วันที่&nbsp;</b>
                    <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>เดือน&nbsp;</b>
                    <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
                    &nbsp; <b>พ.ศ.</b>
                    <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>วันที่&nbsp;</b>
                    <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b> เดือน&nbsp;</b>
                    <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b> พ.ศ.</b>
                    <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" Text="ยืนยัน" Width="100px" Font-Bold="True" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" Text="ส่งกลับ" Font-Bold="True" Width="100px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button6" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
                    &nbsp;
                    <asp:Button ID="Button7" runat="server" Font-Bold="True" Text="ต่อไป" Width="100px" />
                    <br />
                 </td>
			</tr>
		</table>
	
        </asp:View>

    </asp:MultiView>
 
</asp:Content>
