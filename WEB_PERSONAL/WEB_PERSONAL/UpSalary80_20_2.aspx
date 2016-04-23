<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpSalary80_20_2.aspx.cs" Inherits="WEB_PERSONAL.UpSalary80_20_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
        <p align="right" style="font-size:16px"><b>(แบบที่ 2)</b></p>
	    <p align="center" style="font-size:18px"><b>แบบข้อตกลงการประเมินพฤติกรรมการปฏิบัติราชการ (สมรรถนะ) ของข้าราชการพลเรือนในสถาบันอุดมศึกษา หรือพนักงานในสถาบันอุดมศึกษา มหาวิทยาลัยเทคโนโลยีราชมงคล</b></p>
	    <p align="center" style="font-size:18px"><b>ผู้ดำรงตำแหน่งประเภทผู้บริหาร (ไม่ครองตำแหน่งวิชาการ)  (องค์ประกอบที่ 2 พฤติกรรมการปฏิบัติราชการ 20%)</b></p>
	    <p style="font-size:15px"><b>รอบการประเมิน</b></p>
	    <p align="left" style="font-size:15px"><b>ชื่อผู้รับการประเมิน...........................&nbsp;ตำแหน่ง...........................
	    &nbsp;สังกัด...........................</b></p>
	    <p style="font-size:15px"><b>ชื่อผู้ประเมิน...........................&nbsp;ตำแหน่ง...........................
	    &nbsp;สังกัด...........................</b></p>
	<form >
		<table align="center" border="2px solid black" height= "auto" >
			<tr bgcolor="grey" style="font-size:15px">
				<td align="center"><b>สมรรถนะหลักที่กำหนด </b></td>
				<td align="center"><b>(1) ระดับสมรรถนะ<br>ที่คาดหวัง</b></td>
				<td align="center"><b>(2) จำนวนตัวบ่งชี้<br>ที่ประเมิน</b></td>
				<td align="center"><b>(3) จำนวนตัวบ่งชี้<br>ที่ผ่านการประเมิน</b></td>
				<td align="center"><b>(4) คะแนนที่ได้รับ<br>100 X (3)/(2)</b></td>
				<td align="center"><b>(5) คะแนนที่ได้<br>20 X (4)/100</b></td>
			</tr>
			<tr>
				<td><b>1.การมุ่งผลสัมฤทธิ์  </b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td><b>2.การบริการที่ดี </b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td><b>3.การสั่งสมความเชี่ยวชาญ ในงานอาชีพ</b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td><b>4.จริยธรรม</b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td><b>5.ความร่วมแรงร่วมใจ</b></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td colspan="4" align="right"><b>(6) คะแนนที่ได้รับ = ผลรวม(4)/5 = </b></td>
				<td><b></b></td>
				<td bgcolor="grey"></td>
				
			</tr>
			<tr>
				<td colspan="5" align="right"><b>(7) ค่าคะแนนที่ได้  =  ผลรวม(5)/5) = </b></td>
				<td><b></b></td>
			</tr>
            <tr>
				<td colspan="6" style="font-size:15px"><b>
                    <br />
					2.ผู้ประเมินและผู้รับการประเมิน ได้ตกลงร่วมกันและเห็นพ้องกันแล้ว จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อจัดทำข้อตกลง) </b>
                    <br />
				    <br /><b>
				    ลายมือชื่อ&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>
                    (ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>ลายมือชื่อ
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>(ผู้รับการประเมิน)</b>
				    <br />
				    <b>วันที่
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>พ.ศ.
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>วันที่
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>พ.ศ.&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></b>
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
	</form >
    <br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
    <br />
        </asp:View>

        <asp:View ID="View2" runat="server">

         <form >
		   <table align="center" border="2px solid black" height= "auto" >
              <tr>
				<td colspan="6" style="font-size:15px"><b>
                    <br />
					2.ผู้ประเมินและผู้รับการประเมิน ได้ตกลงร่วมกันและเห็นพ้องกันแล้ว จึงลงลายมือชื่อไว้เป็นหลักฐาน (ลงนามเมื่อจัดทำข้อตกลง) </b>
                    <br />
				    <br /><b>
				    ลายมือชื่อ&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>
                    (ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>ลายมือชื่อ
                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>(ผู้รับการประเมิน)</b>
				    <br />
				    <b>วันที่
                    <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน
                    <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>พ.ศ.
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>วันที่
                    <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน
                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>พ.ศ.&nbsp;
                    <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label></b>
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
                    <asp:TextBox ID="TextBox3" runat="server" Height="120px" Width="420px" ></asp:TextBox>
             	    <br />
             	    <br />
				    <b>2.) ข้อเสนอแนะเกี่ยวกับวิธีส่งเสริมและพัฒนา</b>
				    <br />
                    <asp:TextBox ID="TextBox22" runat="server" Height="120px" Width="420px"></asp:TextBox>
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
                    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>(ผู้ประเมิน)</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>ลายมือชื่อ&nbsp;
                    <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>(ผู้รับการประเมิน)</b>
				    <br /><b>วันที่&nbsp;
                    <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b>เดือน&nbsp;
                    <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label></b>
                    &nbsp; <b>พ.ศ.
                    <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <b>วันที่&nbsp;
                    <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b> เดือน&nbsp;
                    <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label></b>
                    &nbsp;<b> พ.ศ.
                    <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label></b>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <br />
                    
				</td>
			</tr>
		</table>
	</form>


        </asp:View>


    </asp:MultiView>
</asp:Content>
