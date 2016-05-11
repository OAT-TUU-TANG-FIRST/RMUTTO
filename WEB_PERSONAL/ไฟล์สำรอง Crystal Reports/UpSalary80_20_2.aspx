<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary80_20_2.aspx.cs" Inherits="WEB_PERSONAL.UpSalary80_20_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
        <asp:View ID="View1" runat="server">
        <p align="right" style="font-size:16px"><b>(แบบที่ 2)</b></p>
	    <p align="center" style="font-size:16px"><b>แบบข้อตกลงการประเมินพฤติกรรมการปฏิบัติราชการ (สมรรถนะ) ของข้าราชการพลเรือนในสถาบันอุดมศึกษา หรือพนักงานในสถาบันอุดมศึกษา<br />มหาวิทยาลัยเทคโนโลยีราชมงคล</b></p>
	    <p align="center" style="font-size:16px"><b>ผู้ดำรงตำแหน่งประเภทผู้บริหาร (ไม่ครองตำแหน่งวิชาการ)  (องค์ประกอบที่ 2 พฤติกรรมการปฏิบัติราชการ 20%)</b></p>
	    <br />
        <p align="center" style="font-size:15px"><b>รอบการประเมิน&nbsp; </b>
            <b><asp:Label ID="Label39" runat="server" Text="Label"></asp:Label></b>
            &nbsp;<b>วันที่&nbsp;
            <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label></b> 
            &nbsp;<b>เดือน&nbsp;
            <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label></b>
            &nbsp;<b>ปีพ.ศ.&nbsp;
            <asp:Label ID="Label42" runat="server" Text="Label"></asp:Label></b>
            </p>
	        <br />
            <p align="left" style="font-size:15px"><b>ชื่อผู้รับการประเมิน</b>
                <asp:Label ID="Label71" runat="server" Text="Label"></asp:Label>
                <b>&nbsp;ตำแหน่ง</b>
                <asp:Label ID="Label72" runat="server" Text="Label"></asp:Label>
                <b>&nbsp;&nbsp;สังกัด </b>
                <asp:Label ID="Label73" runat="server" Text="Label"></asp:Label>
            </p>
            <br />
	        <p style="font-size:15px"><b>ชื่อผู้ประเมิน</b>
                <asp:Label ID="Label74" runat="server" Text="Label"></asp:Label>
                <b>&nbsp;ตำแหน่ง</b>
                <asp:Label ID="Label75" runat="server" Text="Label"></asp:Label>
                <b>&nbsp;&nbsp;สังกัด </b>
                <asp:Label ID="Label76" runat="server" Text="Label"></asp:Label>
            </p>
	        <br />
    <table border="2px solid black" height= "auto" >
			<tr bgcolor="grey" style="font-size:15px">
				<td align="center" style="font-size:15px"><b>สมรรถนะหลักที่กำหนด </b></td>
				<td align="center" style="font-size:15px"><b>(1) ระดับสมรรถนะ<br>ที่คาดหวัง</b></td>
				<td align="center" style="font-size:15px"><b>(2) จำนวนตัวบ่งชี้<br>ที่ประเมิน</b></td>
				<td align="center" style="font-size:15px"><b>(3) จำนวนตัวบ่งชี้<br>ที่ผ่านการประเมิน</b></td>
				<td align="center" style="font-size:15px"><b>(4) คะแนนที่ได้รับ<br>100 X (3)/(2)</b></td>
				<td align="center" style="font-size:15px"><b>(5) คะแนนที่ได้<br>20 X (4)/100</b></td>
			</tr>
			<tr>
				<td style="font-size:15px"><b>1.การมุ่งผลสัมฤทธิ์  </b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label50" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label55" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label60" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label65" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
			<tr>
				<td style="font-size:15px"><b>2.การบริการที่ดี </b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label51" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label56" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label61" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label66" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
			<tr>
				<td style="font-size:15px"><b>3.การสั่งสมความเชี่ยวชาญ ในงานอาชีพ</b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label45" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center"> 
                    <asp:Label ID="Label52" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label57" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label62" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label67" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
			<tr>
				<td style="font-size:15px"><b>4.จริยธรรม</b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label46" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label53" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label58" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label63" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
			<tr>
				<td style="font-size:15px"><b>5.ความร่วมแรงร่วมใจ</b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label47" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label54" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label59" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label64" runat="server" Text="Label"></asp:Label>
                </td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label69" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
			<tr>
				<td colspan="4" align="right" style="font-size:15px"><b>(6) คะแนนที่ได้รับ = ผลรวม(4)/5 = </b></td>
				<td style="font-size:15px" align="center">
                    <asp:Label ID="Label48" runat="server" Text="Label"></asp:Label>
                </td>
				<td bgcolor="grey" align="center" style="font-size:15px">
                    <asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>
                </td>
				
			</tr>
			<tr>
				<td colspan="5" align="right" style="font-size:15px"><b>(7) ค่าคะแนนที่ได้  =  ผลรวม(5)/5) = </b></td>
				<td align="center" style="font-size:15px"><b></b>
                    <asp:Label ID="Label49" runat="server" Text="Label"></asp:Label>
                </td>
			</tr>
            <tr>
				<td colspan="6" style="font-size:15px"><b>
                    <br />
					2.ผู้ประเมินและผู้รับการประเมิน ได้ตกลงร่วมกันและเห็นพ้องกันแล้ว จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อจัดทำข้อตกลง) </b>
                    <br />
				    <br /><b>
				    ลายมือชื่อ&nbsp;</b>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>
                    (ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>&nbsp;ลายมือชื่อ
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>(ผู้รับการประเมิน)</b>
				    <br />
				    <b>วันที่</b>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>เดือน</b>
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>พ.ศ.</b>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>วันที่</b>
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>เดือน</b>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    &nbsp;<b>พ.ศ.&nbsp;</b>
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </td>
			</tr>
			<tr>
				<td colspan="6" style="font-size:15px"><b>
                    <br />
					3. ความเห็นเพิ่มเติมของผู้ประเมิน (ระบุข้อมูลเมื่อสิ้นรอบการประเมิน)</b>
                    <br />
				    <br />
				    <b>1.) จุดเด่น  และ/หรือ สิ่งที่ควรปรับปรุงแก้ไข</b>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Height="120px" Width="420px" ></asp:TextBox>
             	    <br />
             	    <br />
				    <b>2.) ข้อเสนอแนะเกี่ยวกับวิธีส่งเสริมและพัฒนา</b>
				    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Height="120px" Width="420px"></asp:TextBox>
				    <br />
				    <br />
				</td>
			</tr>
			<tr>
				<td colspan="6" style="font-size:15px"><b>
					<br />
					4. ผู้ประเมินและผู้รับการประเมินได้เห็นชอบผลการประเมินแล้ว  จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อสิ้นรอบการประเมิน)</b>
                    <br />
				    <br /><b>
				    ลายมือชื่อ&nbsp;
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>(ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>ลายมือชื่อ&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>(ผู้รับการประเมิน)</b>
				    <br /><b>วันที่&nbsp;
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>พ.ศ.
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>วันที่&nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b> เดือน&nbsp;
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b> พ.ศ.
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></b>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <br />
                </td>
			</tr>
		</table>
	    <br />
            <p align="center"> 
                <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="คำนวน"   Width="100px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Font-Bold="True" Text="ต่อไป" Width="100px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Font-Bold="True" Text="ยกเลิก" Width="100px" />
            </p>
        <br />
        </asp:View>

        <asp:View ID="View2" runat="server">

         <p align="center"><b>สำหรับข้าราชการพลเรือนในสถาบันอุดมศึกษา มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก  ลงวันที่  ๒๙  กันยายน ๒๕๕๔)
	</b></p>
    <br />
	<center>
	<table border="2px solid black" >
		
		<tr>
			<td colspan="2" rowspan="2" align="center">ประเภทตำแหน่ง/อายุราชการ</td>
			<td colspan="26" align="center">สมรรถนะหลัก ๕ รายการ (ระดับ)</td>
		</tr>
		<tr>
			<td colspan="5" align="center">การมุ่งผลสัมฤทธิ์</td>
			<td colspan="6" align="center">การบริการที่ดี</td>
			<td colspan="5" align="center">การสั่งสมความเชี่ยวชาญในงานอาชีพ	</td>
			<td colspan="5" align="center">จริยธรรม</td>
			<td colspan="5" align="center">ความร่วมแรงร่วมใจ	</td>
		</tr>
		<tr>
			<td align="center">ปัจจุบัน</td>
			<td align="center">เดิม</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			<td align="center">6</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
		</tr>
		<tr>
			<td colspan="2" align="center">ตำแหน่งประเภทผู้บริหาร</td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
                <asp:CheckBox runat="server" />
            </td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5" align="center">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5" align="center">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5" align="center">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5" align="center">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5" align="center">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="5">
             <asp:CheckBox runat="server" />
			</td>
		</tr>
		<tr>
			<td> - ผู้ช่วยอธิการบดี</td>
			<td rowspan="4"  align="center"> ผู้บริหารระดับกลาง </td>
			
		</tr>
		<tr>
			<td>  - ผู้อำนวยการกอง
			<br> หัวหน้าสำนักงานคณบดี
			<br> หัวหน้าสำนักงานผู้อำนวยการ
			<br> สถาบัน/สำนัก หรือหัวหน้า
			<br> หน่วยงานที่เรียกชื่ออย่างอื่น
			<br> ที่มีฐานะเทียบเท่ากอง
			</td>
			
		</tr>
		<tr>
			<td> - รองผู้อำนวยการ
			<br> สถาบัน/สำนัก
		</td>
		</tr>
		<tr>
			<td>- รองคณบดี</td>
		</tr>
		<tr>
			<td >- รองอธิการบดี</td>
			<td rowspan="4" align="center">  ผู้บริหารระดับสูง	</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4"> 
            <asp:CheckBox runat="server" />
            </td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
			<td rowspan="4">
             <asp:CheckBox runat="server" />
			</td>
		</tr>
		<tr>
			<td> - ผู้อำนวยการสำนักงาน
			<br>
			อธิการบดี ผู้อำนวยการ
			<br>
			สำนักงานวิทยาเขต 
			</td>
		</tr>
		<tr>
			<td>- คณบดี</td>
		</tr>
		<tr>
			<td>- ผู้อำนวยการสถาบัน/สำนัก</td>
		</tr>
	</table>
</center>
        <br />
        <p align="center">  
            <asp:Button ID="Button5" runat="server" Text="ย้อนกลับ" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <br />
        </asp:View>
        
        <asp:View ID="View3" runat="server">
        <form>
	<p><b>2.  การประเมินพฤติกรรมการปฏิบัติราชการเป็นรายสมรรถนะ</b></p>
	<p><b>1)  การมุ่งผลสัมฤทธิ์ (Achievement Orientation) : ความมุ่งมั่นจะปฏิบัติราชการให้ดี หรือให้เกินมาตรฐานที่มีอยู่ โดยมาตรฐานนี้อาจเป็นผลการปฏิบัติงานที่ผ่านมาของตนเอง หรือเกณฑ์วัดผลสัมฤทธิ์ที่ มหาวิทยาลัยกำหนดขึ้น อีกทั้งยังหมายรวมถึงการสร้างสรรค์พัฒนาผลงานหรือกระบวนการปฏิบัติงานตามเป้าหมายที่ยากและท้าทายชนิดที่อาจไม่เคยมีผู้ใดสามารถกระทำได้มาก่อน</b></p>

	<table border="2px solid black" align="center">
		<tr align="center">
			<td colspan="10"><b>ระดับสมรรถนะ</b</td>

		</tr>
		<tr>
			<td align="center"><b>ระดับ 1</b></td>
			<td align="center"><b>ระดับ 2</b></td>
			<td align="center"><b>ระดับ 3</b></td>
			<td align="center"><b>ระดับ 4</b></td>
			<td align="center" colspan="6"><b>ระดับ 5</b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><b><u>แสดงความพยายามในการทำงานให้ดีโดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 1 <br>และสามารถทำงานได้ผลตามเป้าหมายที่วางไว้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 2 <br>และสามารถทำงานได้ผลงานที่มีประสิทธิภาพมากยิ่งขึ้น  </u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 3 <br>และสามารถพัฒนาวิธีการทำงาน เพื่อให้ได้ผลงานที่โดดเด่นและแตกต่างอย่างไม่เคยมีใคร
			<br>ได้ทำมาก่อน
			</u></b></td>
			<td align="left" valign="top" colspan="10"><b><u>แสดงสมรรถนะระดับที่ 4 <br>และสามารถตัดสินใจได้ แม้จะมีความเสี่ยง เพื่อให้องค์กรบรรลุเป้าหมายโดยมีพฤติกรรมบ่งชี้ 
			ดังนี้
			</u></b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			พยายามทำงานในหน้าที่ให้ดีและ ถูกต้อง </td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			กำหนดมาตรฐานหรือเป้าหมายในการทำงาน<br>เพื่อให้ได้ผลงานที่ดี</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ปรับปรุงวิธีการที่ทำให้ทำงานได้ดีขึ้นหรือมีประสิทธิภาพมากขึ้น</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			กำหนดเป้าหมายที่ท้าทายและเป็นไปได้ยาก เพื่อทำให้ได้ผลงานที่ดีกว่าเดิมอย่างเห็นได้ชัด</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			ตัดสินใจได้ โดยมีการคำนวณผลได้ผลเสียอย่างชัดเจน เพื่อให้ภาครัฐและประชาชนได้ประโยชน์สูงสุด</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			มีความมานะและอดทน ขยันหมั่นเพียรในการทำงานและตรงต่อเวลา </td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			หมั่นติดตามผลงาน และประเมินผลงานของตน<br>โดยใช้เกณฑ์ที่กำหนดขึ้น โดยไม่ได้ถูกบังคับ เช่น ถามว่า
			ผลงานดีหรือยัง หรือต้องปรับปรุง อะไรถึงจะดีขึ้น
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			เสนอหรือทดลองวิธีการทำงานแบบใหม่ที่มีประสิทธิภาพมากกว่าเดิมเพื่อให้ได้ผลตามที่กำหนดไว้</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ทำการพัฒนาระบบ ขั้นตอน วิธีการทำงาน เพื่อให้ได้ผลงานที่โดดเด่นและแตกต่างอย่างไม่เคยมีใครได้ทำ
			มาก่อน
			</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			บริหารจัดการและทุ่มเทเวลา ตลอดจนทรัพยากร เพื่อให้ได้ประโยชน์สูงสุดต่อภารกิจของหน่วยงานตามที่วางแผนไว้</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			มีความรับผิดชอบในงาน สามารถส่งงานได้ตามกำหนดเวลาแสดงออกว่าต้องการทำงานให้ได้ดีขึ้น<br>เช่น ถาม ถึงวิธีการ 
			หรือข้อแนะนำ<br>อย่างกระตือรือร้น สนใจใคร่รู้</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ทำงานได้ตามผลงานตามเป้าหมายที่ผู้บังคับบัญชากำหนด หรือเป้าหมายของหน่วยงานที่รับผิดชอบ</td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top" colspan="10"></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			แสดงความเห็นในเชิงปรับปรุงพัฒนา เมื่อเห็นสิ่งก่อให้เกิดการสูญเปล่าหรือหย่อนประสิทธิภาพในงาน</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			มีความละเอียดรอบคอบเอาใจใส่ตรวจตราความถูกต้องของงาน เพื่อ ให้ได้งานที่มีคุณภาพ</td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"colspan="10"></td>
		</tr>
		<tr>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center" colspan="10"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
		</tr>
		<tr align="left">
			<td colspan="10"><b><u>หมายเหตุ</u></b>เงื่อนไขการผ่านประเมินแต่ละระดับ พฤติกรรมบ่งชี้ต้องผ่านร้อยละ 50 ของตัวบ่งชี้ทั้งหมดในระดับสมรรถนะนั้น ๆ  กรณีไม่ผ่านร้อยละ 50 ไม่ต้องประเมินสมรรถนะในระดับถัดไป</td>

		</tr>
		<tr align="left">
			<td colspan="4" rowspan="2">การประเมินรายสมรรถนะ เหตุผลสนับสนุนและหลักฐานเชิงพฤติกรรม</td>
			<td colspan="6" align="center">ระดับสมรรถนะที่คาดหวัง</td>
		</tr>
		<tr>
			<td align="center">0</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			
		</tr>
		<tr align="left">
			<td colspan="4" rowspan="4"></td>
		
		</tr>
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
		<tr>
			<td colspan="6" align="center">ผลการประเมินสมรรถนะ</td>
		</tr>
		
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
	</table>
</form>
        <br />
        <br />
        <p align="center">
            <asp:Button ID="Button6" runat="server" Text="คำนวน" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" Font-Bold="True" Text="ย้อนกลับ" Width="100px" />
        </p>
        </asp:View>

        <asp:View ID="View4" runat="server">
        <form >
	<p><b>2)  การบริการที่ดี (Service Orientation) : ความตั้งใจและพยายามของข้าราชการในการให้บริการ <br>เพื่อสนองความต้องการของประชาชน ตลอดจนหน่วยงานภาครัฐอื่น ๆ ที่เกี่ยวข้อง</b></p>
	
	<table border="2px solid black" align="center">
		<tr align="center">
			<td colspan="14"><b>ระดับสมรรถนะ</b</td>

		</tr>
		<tr>
			<td align="center"><b>ระดับ 1</b></td>
			<td align="center"><b>ระดับ 2</b></td>
			<td align="center"><b>ระดับ 3</b></td>
			<td align="center"><b>ระดับ 4</b></td>
			<td align="center"><b>ระดับ 5</b></td>
			<td align="center" colspan="9"><b>ระดับ 6</b></td>

		</tr>
		<tr>
			<td align="left" valign="top"><b><u>แสดงความเต็มใจในการให้บริการโดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 1 <br>และสามารถให้บริการที่ผู้รับบริการต้องการได้
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 2 <br>และเต็มใจช่วยแก้ปัญหาให้กับผู้รับบริการได้
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 3 <br>และให้บริการที่เกินความคาดหวังในระดับทั่วไป แม้ต้องใช้เวลาหรือ
			ความพยายามอย่างมากโดยมีพฤติกรรมบ่งชี้ ดังนี้
			</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 4 <br>และสามารถเข้าใจและให้บริการที่ตรงตามความต้องการที่แท้จริงของ
			ผู้รับบริการได้โดยมีพฤติกรรมบ่งชี้ ดังนี้
			</u></b></td>
			<td align="left" valign="top" colspan="12"><b><u>แสดงสมรรถนะระดับที่ 5 <br>และสามารถให้บริการที่เป็นประโยชน์
			อย่างแท้จริงและยั่งยืนให้กับผู้รับบริการ  โดยมีพฤติกรรมบ่งชี้ ดังนี้
			</u></b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ให้การบริการที่เป็นมิตรสุภาพเต็มใจต้อนรับให้บริการด้วยอัธยาศัยไมตรี อันดีและสร้างความประทับใจแก่ผู้รับบริการ </td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ให้ข้อมูล ข่าวสาร ของการ บริการที่ถูกต้อง ชัดเจนแก่ผู้รับบริการได้ตลอดการให้บริการแจ้งให้ผู้รับบริการทราบความคืบหน้าในการ
			ดำเนินเรื่อง หรือขั้นตอนงานต่าง ๆ ที่ให้บริการอยู่</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			รับเป็นธุระ ช่วยแก้ปัญหาหรือหาแนวทางแก้ไขปัญหาที่เกิดขึ้นแก่ผู้รับบริการอย่างรวดเร็วเต็มใจ ไม่บ่ายเบี่ยง 
			ไม่แก้ตัว หรือปัดภาระ</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ให้เวลาแก่ผู้รับบริการ โดยเฉพาะ เมื่อผู้รับบริการประสบความยากลำบาก เช่น ให้เวลาและความพยายามพิเศษในการให้บริการเพื่อช่วยผู้
			รับบริการแก้ปัญหา</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			เข้าใจความจำเป็นหรือความต้องการที่แท้จริงของผู้มารับบริการและ/หรือใช้เวลาแสวงหาข้อมูลและทำความ เข้าใจเกี่ยวกับความจำเป็น
			หรือความต้องการที่แท้จริงของผู้รับบริการ</td>
			<td align="left" valign="top" colspan="12"><input type="checkbox" name="score" value="score"> 
			เล็งเห็นผลประโยชน์ที่จะเกิดขึ้น กับผู้รับบริการในระยะยาวและสามารถเปลี่ยนแปลงวิธีหรือ ขั้นตอนการให้บริการ เพื่อให้
			ผู้รับบริการได้ประโยชน์สูงสุด</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ให้คำแนะนำ และคอยติด ตามเรื่อง เมื่อผู้รับบริการมีคำถามข้อเรียกร้องที่เกี่ยวกับภารกิจของหน่วยงาน </td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ประสานงานภายในหน่วย งานและกับหน่วยงานที่เกี่ยวข้องเพื่อให้ผู้รับบริการได้รับบริการที่ต่อเนื่องและรวดเร็ว
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			 คอยดูแลให้ผู้รับบริการได้รับความพึงพอใจ และนำข้อขัดข้องใดๆ ในการให้บริการ(ถ้ามี) ไปพัฒนาการให้ บริการให้ดียิ่งขึ้น</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			คอยให้ข้อมูล ข่าวสาร ความรู้ ที่เกี่ยวข้องกับงานที่กำลังให้บริการอยู่ ซึ่งเป็นประโยน์แก่ผู้รับบริการ แม้ว่าผู้รับบริการ
			จะไม่ได้ถามถึงหรือไม่ทราบมาก่อน
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score">
			ให้คำแนะนำที่เป็นประโยชน์ แก่ผู้รับบริการ เพื่อตอบสนองความจำเป็นหรือความต้องการที่แท้จริงของผู้รับบริการ</td>
			<td align="left" valign="top" colspan="12"><input type="checkbox" name="score" value="score"> 
			ปฏิบัติตนเป็นที่ปรึกษาที่ผู้รับบริการไว้วางใจ ตลอดจนเป็นส่วนช่วยในการตัดสินใจของผู้รับบริการ</td>
		</tr>
		<tr>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score">
			ให้บริการที่เกินความคาดหวังในระดับทั่วไป</td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top" colspan="12"><input type="checkbox" name="score" value="score">
			สามารถให้วามเห็นส่วนตัวที่อาจแตกต่างไปจากวิธีการหรือขั้นตอนที่ผู้รับบริการต้องการเพื่อสอดคล้องกับความจำเป็น
			ปัญหา โอกาส ฯลฯ เพื่อประโยชน์อย่างแท้จริงหรือในระยะยาวแก่ผู้รับบริการ</td>
		</tr>
		<tr>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center" colspan="12"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
		</tr>
		<tr align="left">
			<td colspan="14"><b><u>หมายเหตุ</u></b>เงื่อนไขการผ่านประเมินแต่ละระดับ พฤติกรรมบ่งชี้ต้องผ่านร้อยละ 50 ของตัวบ่งชี้ทั้งหมดในระดับสมรรถนะนั้น ๆ  กรณีไม่ผ่านร้อยละ 50 ไม่ต้องประเมินสมรรถนะในระดับถัดไป</td>

		</tr>
		<tr align="left">
			<td colspan="7" rowspan="2">การประเมินรายสมรรถนะ เหตุผลสนับสนุนและหลักฐานเชิงพฤติกรรม</td>
			<td colspan="7" align="center">ระดับสมรรถนะที่คาดหวัง</td>
		</tr>
		<tr>
			<td align="center">0</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			<td align="center">6</td>
			
		</tr>
		<tr align="left">
			<td colspan="7" rowspan="4"></td>
		
		</tr>
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
		<tr>
			<td colspan="7" align="center">ผลการประเมินสมรรถนะ</td>
		</tr>
		
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
	</table>
</form>
        <br />
        <br />
        <p align="center">
            <asp:Button ID="Button9" runat="server" Text="คำนวน" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11" runat="server" Font-Bold="True" Text="ย้อนกลับ" Width="100px" />
        </p>

        </asp:View>

        <asp:View ID="View5" runat="server">

        <form >
	<p><b>3)การสั่งสมความเชี่ยวชาญในงานอาชีพ (Expertise) : ความขวนขวาย สนใจใฝ่รู้เพื่อสั่งสม พัฒนาศักยภาพ ความรู้ความสามารถของตนในการปฏิบัติราชการ ด้วยการศึกษา ค้นคว้าหาความรู้ พัฒนาตนเองอย่างต่อเนื่อง อีกทั้งรู้จักพัฒนาปรับปรุง ประยุกต์ใช้ความรู้เชิงวิชาการและเทคโนโลยีต่าง ๆ เข้ากับการปฏิบัติงานให้เกิดผลสัมฤทธิ์</b></p>

	<table border="2px solid black" align="center">
		<tr align="center">
			<td colspan="10"><b>ระดับสมรรถนะ</b</td>

		</tr>
		<tr>
			<td align="center"><b>ระดับ 1</b></td>
			<td align="center"><b>ระดับ 2</b></td>
			<td align="center"><b>ระดับ 3</b></td>
			<td align="center"><b>ระดับ 4</b></td>
			<td align="center" colspan="6"><b>ระดับ 5</b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><b><u>แสดงความสนใจและติดตามความรู้ใหม่ๆในสาขาอาชีพของตน/ที่เกี่ยวข้อง
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 1 <br>และมีความรู้ในวิชาการและเทคโนโลยีใหม่ ๆ ในสายอาชีพของตน
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 2 <br>และสามารถนำความรู้ วิทยาการ หรือเทคโนโลยี
			ใหม่ ๆ ที่ได้ศึกษามาปรับใช้กับการทำงานโดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 3 <br>ศึกษา พัฒนาตนเองให้มีความรู้ และความเชี่ยวชาญ
			ในงานมากขึ้น ทั้งในเชิงลึก และเชิงกว้างอย่างต่อเนื่องโดยมีพฤติกรรมบ่งชี้ ดังนี้
			</u></b></td>
			<td align="left" valign="top" colspan="10"><b><u>แสดงสมรรถนะระดับที่ 4 <br>และสนับสนุนการทำงานของคนในองค์กรที่เน้นความ
			เชี่ยวชาญในวิทยาการด้านต่าง ๆ
			</u></b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			กระตือรือร้นในการศึกษาหาความรู้สนใจเทคโนโลยีและองค์ความรู้ใหม่ ๆ ในสาขาอาชีพของตน </td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			รอบรู้เท่าทันเทคโนโลยีหรือองค์คว่ามรู้ใหม่ ๆ ในสาขาอาชีพของตนและที่เกี่ยวข้องหรืออาจมีผลกระทบต่อการปฏิบัติหน้าที่ของตน</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			 เข้าใจประเด็นหลัก ๆ นัยสำคัญ และผลกระทบของวิทยาการต่าง ๆ  อย่างลึกซึ้ง</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			มีความรู้ความเชี่ยวขาญในเรื่องที่เกี่ยวกับงานหลายด้าน (สหวิทยาการ)และสามารถนำความรู้ไปปรับใช้ให้
			ปฏิบัติได้อย่างกว้างขวางครอบคลุม</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			สนับสนุนให้เกิดบรรยากาศแห่งการพัฒนาความเชี่ยวชาญในองค์กร ด้วยการจัดสรร ทรัพยากร เครื่องมือ อุปกรณ์ ที่เอื้อต่อ
			การพัฒนา</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			หมั่นทดลองวิธีการทำงานแบบใหม่เพื่อพัฒนาประสิทธิภาพ และความรู้ความสามารถของตนให้ดียิ่งขึ้น</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ติดตามแนวโน้มวิทยาการที่ทันสมัยและเทคโนโลยีที่เกี่ยวข้องกับงานอย่างต่อเนื่อง
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			สามารถนำวิชาการ ความรู้ หรือเทคโนโลยีใหม่ ๆ มาประยุกต์ใช้ในการปฏิบัติงานได้</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			สามารถนำความรู้เชิงบูรณาการของตนไปใช้ในการสร้างวิสัยทัศน์ เพื่อการ ปฏิบัติงานในอนาคต
			</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			ให้การสนับสนุนชมเชย เมื่อมีผู้แสดงออกถึงความตั้งใจที่จะพัฒนาความเชี่ยวชาญในงาน</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ติดตามเทคโนโลยีและความรู้ใหม่ ๆอยู่เสมอด้วยการสืบค้นข้อมูลจากแหล่งต่าง ๆ ที่จะเป็นประโยชน์ ต่อการปฏิบัติราชการ</td>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			สั่งสมความรู้ใหม่ ๆ อยู่เสมอ และเล็งเห็นประโยชน์ความสำคัญขององค์ความรู้เทคโนโลยีใหม่ ๆ ที่จะส่งผลกระทบต่องานของตนในอนาคต</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score">ขวนขวายหาความรู้ที่เกี่ยวข้องกับงาน
			ทั้งเชิงลึกและเชิงกว้างอข่างต่อเนื่อง</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score">
			มีวิสัยทัศน์ในการเล็งเห็นประโยชน์ของเทคโนโลยี องค์ความรู้ หรือวิทยาการใหม่ๆต่อการปฏิบัติงานในอนาคต และสนับสนุน
			ส่งเสริมให้มีการนำมาประยุกต์ใช้ในหน่วยงานอย่างต่อเนื่อง</td>
		</tr>
		<tr>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center" colspan="10"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
		</tr>
		<tr align="left">
			<td colspan="10"><b><u>หมายเหตุ</u></b>เงื่อนไขการผ่านประเมินแต่ละระดับ พฤติกรรมบ่งชี้ต้องผ่านร้อยละ 50 ของตัวบ่งชี้ทั้งหมดในระดับสมรรถนะนั้น ๆ  กรณีไม่ผ่านร้อยละ 50 ไม่ต้องประเมินสมรรถนะในระดับถัดไป</td>

		</tr>
		<tr align="left">
			<td colspan="4" rowspan="2">การประเมินรายสมรรถนะ เหตุผลสนับสนุนและหลักฐานเชิงพฤติกรรม</td>
			<td colspan="6" align="center">ระดับสมรรถนะที่คาดหวัง</td>
		</tr>
		<tr>
			<td align="center">0</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			
		</tr>
		<tr align="left">
			<td colspan="4" rowspan="4"></td>
		
		</tr>
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
		<tr>
			<td colspan="6" align="center">ผลการประเมินสมรรถนะ</td>
		</tr>
		
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
	</table>
</form>
        <br />
        <br />
        <p align="center">
            <asp:Button ID="Button12" runat="server" Text="คำนวน" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button13" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button14" runat="server" Font-Bold="True" Text="ย้อนกลับ" Width="100px" />
        </p>

        </asp:View>

        <asp:View ID="View6" runat="server">

        <form >
	<p><b>4.) จริยธรรม (Integrity) : การครองตนและการประพฤติปฏิบัติถูกต้องเหมาะสมทั้งตามหลักกฎหมายและคุณธรรม จริยธรรม ตลอดจนหลักแนวทางในวิชาชีพของตน โดยมุ่งประโยชน์ของประเทศชาติมากกว่าประโยชน์ส่วนตน ทั้งนี้ เพื่อธำรงรักษาศักดิ์ศรีแห่งอาชีพข้าราชการ อีกทั้งเพื่อเป็นกำลังสำคัญในการสนับสนุนผลักดันให้ภารกิจหลักภาครัฐบรรลุเป้าหมายที่กำหนดไว้</b></p>

	<table border="2px solid black" align="center">
		<tr align="center">
			<td colspan="10"><b>ระดับสมรรถนะ</b</td>

		</tr>
		<tr>
			<td align="center"><b>ระดับ 1</b></td>
			<td align="center"><b>ระดับ 2</b></td>
			<td align="center"><b>ระดับ 3</b></td>
			<td align="center"><b>ระดับ 4</b></td>
			<td align="center" colspan="6"><b>ระดับ 5</b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><b><u>มีความซื่อสัตย์สุจริต	โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 1 <br>และมีสัจจะเชื่อถือได้ โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 2 <br>และยึดมั่นในหลักการ โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 3 <br>และธำรงความถูกต้อง โดยมีพฤติกรรมบ่งชี้ ดังนี้	</u></b></td>
			<td align="left" valign="top" colspan="10"><b><u>แสดงสมรรถนะระดับที่ 4 <br>และอุทิศตนเพื่อผดุงความยุติธรรม
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ปฏิบัติหน้าที่ด้วยความโปร่งใส ซื่อสัตย์สุจริต ถูกต้องทั้งตามหลักกฎ</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			 รักษาวาจา มีสัจจะเชื่อถือได้ พูด อย่างไรก็ทำอย่างนั้น ไม่บิดเบือนอ้างข้อยกเว้นให้ตนเอง</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			 ยึดมั่นในหลักการและจรรยาบรรณของวิชาชีพ ไม่เบี่ยงเบนด้วยอคติหรือผลประโยชน์ส่วนตน</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ธำรงความถูกต้อง ยืนหยัดพิทักษ์ผลประโยชน์และชื่อเสียงของประเทศชาติ แม้ในสถานการณ์ที่อาจสร้างความลำบากใจให้</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			ธำรงความถูกต้อง ยืนหยัดพิทักษ์ผลประโยชน์และชื่อเสียงของประเทศชาติ แม้ในสถานการณ์ที่อาจเสี่ยงต่อความมั่นคงในตำแหน่งหน้าที่การงาน 
			 หรืออาจเสี่ยงภัยต่อชีวิต</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			แสดงความเห็นของตนตามหลักวิชาชีพอย่างเปิดเผยตรงไปตรงมา</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			มีจิตสำนึกและความภาคภูมิใจในความเป็นข้าราชการ อุทิศแรงกายแรงใจผลักดันให้ภารกิจหลักของตนและหน่วยงานบรรลุผล เพื่อสนับ 
			สนุนส่งเสริมการพัฒนาประเทศชาติและสังคมไทย
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			เสียสละความสุขสบายตลอดจนความพึงพอใจส่วนตนหรือของครอบ ครัว โดยมุ่งให้ภารกิจในหน้าที่สัมฤทธิ์ผลเป็นสำคัญ</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ตัดสินใจในหน้าที่ ปฏิบัติราชการด้วยความถูกต้อง โปร่งใส เป็นธรรมแม้ผลการปฏิบัติอาจสร้างศัตรูหรือก่อความไม่พึงพอใจให้แก่ผู้ที่
			เกี่ยวข้องหรือเสียผลประโยชน์
			</td>
			<td align="left" valign="top" colspan="10"></td>
		</tr>
		<tr>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center" colspan="10"><b>จำนวนตัวบ่งชี้ที่<br>ผ่านการประเมิน........ตัวบ่งชี้</b></td>
		</tr>
		<tr align="left">
			<td colspan="10"><b><u>หมายเหตุ</u></b>เงื่อนไขการผ่านประเมินแต่ละระดับ พฤติกรรมบ่งชี้ต้องผ่านร้อยละ 50 ของตัวบ่งชี้ทั้งหมดในระดับสมรรถนะนั้น ๆ  กรณีไม่ผ่านร้อยละ 50 ไม่ต้องประเมินสมรรถนะในระดับถัดไป</td>

		</tr>
		<tr align="left">
			<td colspan="4" rowspan="2">การประเมินรายสมรรถนะ เหตุผลสนับสนุนและหลักฐานเชิงพฤติกรรม</td>
			<td colspan="6" align="center">ระดับสมรรถนะที่คาดหวัง</td>
		</tr>
		<tr>
			<td align="center">0</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			
		</tr>
		<tr align="left">
			<td colspan="4" rowspan="4"></td>
		
		</tr>
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
		<tr>
			<td colspan="6" align="center">ผลการประเมินสมรรถนะ</td>
		</tr>
		
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
	</table>
</form>
        <br />
        <br />
        <p align="center">
            <asp:Button ID="Button15" runat="server" Text="คำนวน" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button16" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button17" runat="server" Font-Bold="True" Text="ย้อนกลับ" Width="100px" />
        </p>

        </asp:View>

        <asp:View ID="View7" runat="server">

        <form >
	<p><b>5)  ความร่วมแรงร่วมใจ (Teamwork) : พฤติกรรมที่แสดง 1) ความตั้งใจที่ทำงานร่วมกับผู้อื่น เป็นส่วนหนึ่งในทีมงาน หน่วยงานหรือองค์กร โดยผู้ปฏิบัติเป็นสมาชิกในทีม มิใช่ฐานะ หัวหน้าทีม และ 2) ความสามารถในการสร้างและธำรงรักษาสัมพันธภาพกับสมาชิกในทีม</b></p>

	<table border="2px solid black" align="center">
		<tr align="center">
			<td colspan="10"><b>ระดับสมรรถนะ</b</td>

		</tr>
		<tr>
			<td align="center"><b>ระดับ 1</b></td>
			<td align="center"><b>ระดับ 2</b></td>
			<td align="center"><b>ระดับ 3</b></td>
			<td align="center"><b>ระดับ 4</b></td>
			<td align="center" colspan="6"><b>ระดับ 5</b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><b><u>ทำหน้าที่ของตนในทีมให้สำเร็จโดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 1 <br>และให้ความร่วมมือในการทำงานกับเพื่อนร่วมงาน
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 2 <br>และประสานความร่วมมือของสมาชิกในทีม
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
			<td align="left" valign="top"><b><u>แสดงสมรรถนะระดับที่ 3 <br>และสนับสนุนและช่วยเหลืองานเพื่อนร่วมทีมคนอื่น ๆ
			เพื่อให้งานประสบความสำเร็จ โดยมีพฤติกรรมบ่งชี้ ดังนี้	</u></b></td>
			<td align="left" valign="top" colspan="10"><b><u>แสดงสมรรถนะระดับที่ 4 <br>และสามารถนำทีมให้ปฏิบัติภารกิจให้ได้ผลสำเร็จ
			โดยมีพฤติกรรมบ่งชี้ ดังนี้</u></b></td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ทำงานในส่วนของตนที่ได้รับมอบหมายได้สำเร็จ<br>สนับสนุนการตัดสิน<br>ใจในกลุ่ม</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			สร้างสัมพันธ์<br>เข้ากับผู้อื่นในกลุ่มได้ดี</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			รับฟังความเห็นของสมาชิกในทีม<br>เต็มใจเรียนรู้จากผู้อื่นรวมถึงผู้ใต้บังคับบัญชาและผู้ร่วมงาน</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			กล่าวชื่นชมให้กำลังใจเพื่อนร่วมงาน<br>ได้อย่างจริงใจ</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score"> 
			ส่งเสริมความสามัคคีเป็นน้ำหนึ่ง<br>ใจเดียวกันในทีมโดยไม่คำนึงถึงความชอบ<br>หรือไม่ชอบส่วนตน</td>
		</tr>
		<tr>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			รายงานให้สมาชิกทราบความคืบหน้า<br>ของการดำเนินงานในกลุ่มหรือข้อมูลอื่นๆ<br>ที่เป็นประโยชน์ต่อการทำงานอย่างต่อเนื่อง</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			เอื้อเฟื้อเผื่อแผ่<br>ให้ความร่วมมือกับผู้อื่นในทีมด้วยดี
			</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ประมวลความคิดเห็นต่างๆ<br>มาใช้ประกอบการตัดสินใจหรือวางแผนงานร่วมกันในทีม</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			แสดงน้ำใจในเหตุวิกฤต<br>ให้ความช่วยเหลือแก่เพื่อนร่วมงานที่มีเหตุจำเป็น<br>โดยไม่ต้องให้ร้องขอ
			</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score">
			ช่วยประสานรอยร้าว<br>หรือคลี่คลายแก้ไขข้อขัดแย้งที่เกิดขึ้นในทีม
			</td>
		</tr>
		<tr>
			<td align="left" valign="top"></td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			กล่าวถึงเพื่อนร่วมงานในเชิงสร้างสรรค์</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			ประสานและส่งเสริมสัมพันธภาพอันดีในทีมเพื่อสนับสนุนการทำงานร่วมกันให้มีประสิทธิภาพยิ่งขึ้น</td>
			<td align="left" valign="top"><input type="checkbox" name="score" value="score"> 
			รักษามิตรภาพอันดีกับเพื่อนร่วมงานเพื่อช่วยเหลือกันในวาระต่างๆ<br>ให้งานสำเร็จลุล่วงเป็นประโยชน์ต่อส่วนรวม
			</td>
			<td align="left" valign="top" colspan="10"><input type="checkbox" name="score" value="score">
			ประสานสัมพันธ์ส่งเสริมขวัญกำลังใจของทีมเพื่อรวมพลังกันในการปฏิบัติภารกิจใหญ่น้อยต่างๆ<br>ให้บรรลุผล</td>
		</tr>
		<tr>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center"><b>จำนวนตัวบ่งชี้ที่ผ่านการประเมิน........ตัวบ่งชี้</b></td>
			<td align="center" colspan="10"><b>จำนวนตัวบ่งชี้ที่ผ่านการประเมิน........ตัวบ่งชี้</b></td>
		</tr>
		<tr align="left">
			<td colspan="10"><b><u>หมายเหตุ</u></b>เงื่อนไขการผ่านประเมินแต่ละระดับ พฤติกรรมบ่งชี้ต้องผ่านร้อยละ 50 ของตัวบ่งชี้ทั้งหมดในระดับสมรรถนะนั้น ๆ  กรณีไม่ผ่านร้อยละ 50 ไม่ต้องประเมินสมรรถนะในระดับถัดไป</td>

		</tr>
		<tr align="left">
			<td colspan="4" rowspan="2">การประเมินรายสมรรถนะ เหตุผลสนับสนุนและหลักฐานเชิงพฤติกรรม</td>
			<td colspan="6" align="center">ระดับสมรรถนะที่คาดหวัง</td>
		</tr>
		<tr>
			<td align="center">0</td>
			<td align="center">1</td>
			<td align="center">2</td>
			<td align="center">3</td>
			<td align="center">4</td>
			<td align="center">5</td>
			
		</tr>
		<tr align="left">
			<td colspan="4" rowspan="4"></td>
		
		</tr>
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
		<tr>
			<td colspan="6" align="center">ผลการประเมินสมรรถนะ</td>
		</tr>
		
		<tr>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
			<td align="center">...</td>
		</tr>
	</table>
</form>
        <br />
        <br />
        <p align="center">
            <asp:Button ID="Button18" runat="server" Text="คำนวน" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button19" runat="server" Font-Bold="True" Text="บันทึก" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button20" runat="server" Font-Bold="True" Text="ย้อนกลับ" Width="100px" />
        </p>
        </asp:View>
                
    </asp:MultiView>
</asp:Content>
