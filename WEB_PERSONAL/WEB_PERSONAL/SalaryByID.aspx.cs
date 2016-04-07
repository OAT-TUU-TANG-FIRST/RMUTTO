using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Globalization;
using WEB_PERSONAL.Class;
using System.Text.RegularExpressions;

namespace WEB_PERSONAL
{
    public partial class SalaryByID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_person"] == null)
            {
                return;
            }
            if (Session["login_system_status_id"].ToString() == "1")
            {
                LinkButton11.Visible = true;
                LinkButton7.Visible = true;
            }
            else
            {
                LinkButton11.Visible = false;
                LinkButton7.Visible = false;
            }
            string Mon = "มี.ค.";
            int year = new ThaiBuddhistCalendar().GetYear(DateTime.Now);
            switch (DateTime.Now.Month)
            {
                case 1:
                case 2:
                case 3:
                case 10:
                case 11:
                case 12:
                    Mon = "ก.ย.";
                    break;
            }

            Label20.Text = "เงินเดือนก่อนเลื่อน (ณ 1 " + Mon + " " + year + " )";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^\d+$");

            if (TextBox1.Text.Length == 13 && reg.IsMatch(TextBox1.Text))
            {
               /* Person person = new Person(Session["login_id"].ToString());
                BaseSalary salary = new BaseSalary(person.PositionID);
                Label11.Text = person.Name;
                Label3.Text = person.Name;
                Label13.Text = person.Lastname;
                Label4.Text = person.Lastname;
                Label61.Text = person.StaffTypeName;
                Label6.Text = person.StaffTypeName;
                Label17.Text = person.PositionName;
                Label10.Text = person.PositionName;
                TextBox2.Text = person.SalaryYear.ToString();
                Label64.Text = person.SalaryYear.ToString();
                Label66.Text = person.SalaryYear.ToString();
                Label68.Text = person.SalaryYear.ToString();
                Label22.Text = "" + salary.MaxSalary;
                Session["STAFFTYPE_STATUS"] = Label61.Text;
                Label19.Text = person.AdminPositionName;
                Label15.Text = person.PositionWorkName;
                Session["citizen_id"] = TextBox1.Text;
                if (Session["STAFFTYPE_STATUS"] != null)
                {
                    if (Session["STAFFTYPE_STATUS"].ToString() == "ข้าราชการ")
                    {
                        Panel_Government_Officer.Visible = true;
                        Panel_Oracle_Control.Visible = true;
                        Edit_page.Attributes["href"] = "SalarybyID-Edit.aspx";
                    }
                    if (Session["STAFFTYPE_STATUS"].ToString() == "ลูกจ้างประจำ")
                    {
                        Panel_Permanent_Emp.Visible = true;
                        Panel_Oracle_Control.Visible = true;
                        Edit_page.Attributes["href"] = "SalarybyID-Edit-Permanent.aspx";

                    }
                }*/
            }
            else
            {
                Util.Alert(this, "กรุณากรอกรหัสบัตรประชาชนให้ครบถ้วน");
            }
            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text != "" && TextBox2.Text != null && TextBox3.Text != "" && TextBox3.Text != null && TextBox6.Text != "" && TextBox6.Text != null && TextBox7.Text != "" && TextBox7.Text != null)
            {
                /*Person person = new Person(TextBox1.Text);
                BaseSalary basesalasy = new BaseSalary(person.PositionID);
                string position = person.PositionName;
                double maxsal = basesalasy.MaxSalary;
                double minsal = basesalasy.MinSalary;
                double maxlowsal = basesalasy.MaxLowSalary;
                double minlowsal = basesalasy.MinLowSalary;
                double salary = Convert.ToDouble(TextBox2.Text);
                            if (position == "ศาสตราจารย์")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "62210";
                                }
                                else
                                    Label24.Text = "66700";
                            }
                            if (position == "รองศาสตราจารย์")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "52320";
                                }
                                else
                                    Label24.Text = "60990";
                            }
                            if (position == "ผู้ช่วยศาสตราจารย์")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "37830";
                                }
                                else
                                    Label24.Text = "51290";
                            }
                            if (position == "ผู้ช่วยศาสตราจารย์")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "37830";
                                }
                                else
                                    Label24.Text = "51290";
                            }
                            if (position == "อาจารย์")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "24030";
                                }
                                else
                                    Label24.Text = "37080";
                            }
                            /* บริหาร */
                            /*if (position == "ผู้อำนวยการสำนักงานอธิการบดีหรือเทียบเท่า")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "37830";
                                }
                                else
                                    Label24.Text = "51290";
                            }
                            if (position == "ผู้อำนวยการกองหรือเทียบเท่า")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "52320";
                                }
                                else
                                    Label24.Text = "60990";
                            }*/
                            /* วิชาชีพเฉพาะหรือเชียวชาญเฉพาะ */
                            /*if (position == "เชี่ยวชาญพิเศษ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "60830";
                                }
                                else
                                    Label24.Text = "66700";
                            }
                            if (position == "เชี่ยวชาญ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "50320";
                                }
                                else
                                    Label24.Text = "59630";
                            }
                            if (position == "ชำนาญการพิเศษ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "37200";
                                }
                                else
                                    Label24.Text = "49330";
                            }
                            if (position == "ชำนาญการ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "24410";
                                }
                                else
                                    Label24.Text = "36470";
                            }
                            if (position == "ปฏิบัตการ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "17980";
                                }
                                else
                                    Label24.Text = "23930";
                            }*/
                            /* ทั่วไป */
                            /*if (position == "ชำนาญงานพิเศษ")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "32250";
                                }
                                else
                                    Label24.Text = "44970";
                            }
                            if (position == "ชำนาญงาน")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "18480";
                                }
                                else
                                    Label24.Text = "31610";
                            }
                            if (position == "ปฏิบัติงาน")
                            {
                                if (salary <= maxlowsal)
                                {
                                    Label24.Text = "12310";
                                }
                                else
                                    Label24.Text = "18110";
                            }*/
                    /* จำนวนเงินที่คำนวณได้แบบไม่ปัดเศษ */
                    double basesalcal = Convert.ToDouble(Label24.Text);
                    double rate = Convert.ToDouble(TextBox3.Text);
                    Label26.Text = String.Format("{0:.##}", basesalcal * rate / 100);

                    /* จำนวนเงินที่คำนวณได้แบบปัดเศษ */
                    Label27.Text = "" + roundUp(Convert.ToDouble(Label26.Text));
                    /* จำนวนเงินที่ได้เลื่อน */
                    Double salcalround = Convert.ToDouble(Label27.Text);

                    double salary1 = Convert.ToDouble(TextBox2.Text);
                    int maxbasesal = Convert.ToInt32(Label22.Text);
                    Double isal = salary1 + salcalround;
                    if (isal <= maxbasesal)
                    {
                        Label29.Text = "" + salcalround;
                    }
                    else
                    {
                        Label29.Text = "" + (maxbasesal - salary1);
                    }

                    /* เงินตอบแทนพิเศษ */
                    double mbonus = salary1 + salcalround;
                    Double salup = Convert.ToDouble(Label29.Text);
                    if (mbonus <= maxbasesal)
                    {
                        Label31.Text = "0";
                    }
                    else
                    {
                        Label31.Text = "" + ((basesalcal * rate / 100) - salup);
                    }
                    /* รวมใช้เลื่อน */
                    double sumup = Convert.ToDouble(Label31.Text);
                    Label33.Text = String.Format("{0:.##}", salup + sumup);

                    /* เงินเดือนใหม่ */
                    Double sumup2 = Convert.ToDouble(Label33.Text);
                    if (isal <= maxbasesal)
                    {
                        Label35.Text = "" + (salary1 + sumup2);

                    }
                    else
                    {
                        Label35.Text = "" + maxbasesal;
                    }
                    /* ร้อยละที่ได้เลื่อน */
                    Double Rateup = Convert.ToDouble(TextBox6.Text);
                    Double Rateup2 = Convert.ToDouble(DropDownList4.SelectedValue); //Convert.ToDouble(TextBox7.Text);
                    Label42.Text = "" + (rate + Rateup + Rateup2);
                    /* จำนวนเงินที่คำนวณได้แบบไม่ปัดเศษ รวมได้เลื่อนทั้งสิ้น */
                    Double Ratesum = Convert.ToDouble(Label42.Text);
                    Label44.Text = "" + (basesalcal * Ratesum / 100);
                    /* จำนวนเงินที่คำนวณได้แบบปัดเศษ รวมได้เลื่อนทั้งสิ้น */
                    Label46.Text = "" + roundUp(Convert.ToDouble(Label44.Text));
                    /* จำนวนเงินที่ได้เลื่อน รวมได้เลื่อนทั้งสิ้น */
                    Double salcalround2 = Convert.ToDouble(Label44.Text);
                    Double isal2 = salary1 + salcalround2;
                    if (isal <= maxbasesal)
                    {
                        Label48.Text = Label46.Text;
                    }
                    else
                    {
                        Label48.Text = "" + (maxbasesal - salary1);
                    }
                    /* เงินตอบแทนพิเศษ */
                    Double salup2 = Convert.ToDouble(Label48.Text);
                    double mbonus2 = salary1 + salcalround2;

                    if (mbonus2 <= maxbasesal)
                    {
                        Label50.Text = "0";
                    }
                    else
                    {
                        Label50.Text = "" + ((basesalcal * Ratesum / 100) - salup2);
                    }
                    /* รวมใช้เลื่อน */
                    Double sumup4 = Convert.ToDouble(Label50.Text);
                    Label52.Text = String.Format("{0:.##}", salup2 + sumup4);
                    /* เงินเดือนใหม่ รวมได้เลื่อนทั้งสิ้น */
                    Double salcalround3 = Convert.ToDouble(Label46.Text);
                    if (mbonus2 <= maxbasesal)
                    {
                        Label54.Text = "" + (salary1 + salcalround3);

                    }
                    else
                    {
                        Label54.Text = "" + maxbasesal;
                    }

                    Label58.Text = "" + (Convert.ToDouble(Label52.Text) - sumup2);
                }

        }

        private int roundUp(double i)
        {
            int j = Convert.ToInt32(i);
            return (10 - j % 10) + j;
        }

        protected void LinkButton2_Click(object sender, EventArgs ee)
        {
            if (Session["STAFFTYPE_STATUS"].ToString() == "ข้าราชการ")
            {
                String a = TextBox1.Text;
                String b = TextBox2.Text;
                String c = Label22.Text;
                String d = Label24.Text;
                String e = TextBox3.Text;
                String f = Label26.Text;
                String g = Label27.Text;
                String h = Label29.Text;
                String i = Label31.Text;
                String j = Label33.Text;
                String k = Label35.Text;
                String l = TextBox4.Text;
                String m = TextBox5.Text;
                String n = TextBox6.Text;
                String o = TextBox7.Text;
                String p = Label58.Text;
                String q = Label42.Text;
                String r = Label44.Text;
                String s = Label46.Text;
                String t = Label48.Text;
                String u = Label50.Text;
                String v = Label52.Text;
                String w = Label54.Text;
                String x = TextBox9.Text;
                DateTime dt = DateTime.Now;
                String y = Util.ToOracleDate(dt);

                using (OracleConnection conn = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;"))
                {
                    conn.Open();
                    string sql = "INSERT INTO TB_SALARY_UP VALUES (SEQ_SALUP_ID.NEXTVAL,'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, '{12}', {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22},'{23}', SYSDATE)";
                    sql = String.Format(sql, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x);
                    using (OracleCommand command = new OracleCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                        string script = "alert(\"SAVE SUCCESSFUL.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }


                }
            }
            if (Session["STAFFTYPE_STATUS"].ToString() == "ลูกจ้างประจำ")
            {
                /*Person person = new Person(Session["login_id"].ToString());
                using (OracleConnection conn = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;"))
                {
                    conn.Open();
                    string sql = "INSERT INTO TB_SALARY_UP_PERMANENT_EMP VALUES (SEQ_TB_SALARY_UP_PERMANENT_EMP.NEXTVAL,:1,:2)";
                    using (OracleCommand command = new OracleCommand(sql, conn))
                    {
                        if (Radio_Per_Hour_1.Checked == true || Radio_Per_Hour_2.Checked == true || Radio_Per_Hour_3.Checked == true || Radio_Per_Hour_4.Checked == true)
                        {
                            command.Parameters.AddWithValue("1", person.PositionID);
                            command.Parameters.AddWithValue("2", Convert.ToDouble(Label79.Text));
                            command.ExecuteNonQuery();
                            string script = "alert(\"SAVE SUCCESSFUL.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                        else if (Radio_Per_Day_1.Checked == true || Radio_Per_Day_2.Checked == true || Radio_Per_Day_3.Checked == true || Radio_Per_Day_4.Checked == true)
                        {
                            command.Parameters.AddWithValue("1", Session["Position_id"].ToString());
                            command.Parameters.AddWithValue("2", Convert.ToDouble(Label80.Text));
                            command.ExecuteNonQuery();
                            string script = "alert(\"SAVE SUCCESSFUL.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                        else if (Radio_Per_Month_1.Checked == true || Radio_Per_Month_2.Checked == true || Radio_Per_Month_3.Checked == true || Radio_Per_Month_4.Checked == true)
                        {
                            command.Parameters.AddWithValue("1", Session["Position_id"].ToString());
                            command.Parameters.AddWithValue("2", Convert.ToDouble(Label83.Text));
                            command.ExecuteNonQuery();
                            string script = "alert(\"SAVE SUCCESSFUL.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                        else
                        {
                            string script = "alert(\"Error!\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            return;
                        }

                    }


                }*/
            }




        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalarybyID_Edit");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalaryByID-Report.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salary_Basesalary_Admin.aspx");
        }

        protected void Radio_Per_Hour_1_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_hour("SELECT \"LEVEL\", PERHOUR,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 1");
        }
        protected void Radio_Per_Hour_2_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_hour("SELECT \"LEVEL\", PERHOUR,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 2");
        }
        protected void Radio_Per_Hour_3_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_hour("SELECT \"LEVEL\", PERHOUR,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 3");
        }
        protected void Radio_Per_Hour_4_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_hour("SELECT \"LEVEL\", PERHOUR,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 4");
        }
        private void Radio_per_hour(string sql)
        {
            SqlDataSource sd = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", sql);
            DropDownList1.DataSource = sd;
            DropDownList1.DataTextField = "LEVEL";
            DropDownList1.DataValueField = "PERHOUR";
            DropDownList1.DataBind();
        }

        protected void Radio_Per_Day_1_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_day("SELECT \"LEVEL\", PERDAY,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 1");
        }
        protected void Radio_Per_Day_2_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_day("SELECT \"LEVEL\", PERDAY,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 2");
        }
        protected void Radio_Per_Day_3_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_day("SELECT \"LEVEL\", PERDAY,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 3");
        }
        protected void Radio_Per_Day_4_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_day("SELECT \"LEVEL\", PERDAY,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 4");
        }
        private void Radio_per_day(string sql)
        {
            SqlDataSource sd = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", sql);
            DropDownList2.DataSource = sd;
            DropDownList2.DataTextField = "LEVEL";
            DropDownList2.DataValueField = "PERDAY";
            DropDownList2.DataBind();
        }

        protected void Radio_Per_Month_1_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_month("SELECT \"LEVEL\", PERMONTH,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 1");
        }
        protected void Radio_Per_Month_2_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_month("SELECT \"LEVEL\", PERMONTH,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 2");
        }
        protected void Radio_Per_Month_3_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_month("SELECT \"LEVEL\", PERMONTH,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 3");
        }
        protected void Radio_Per_Month_4_CheckedChanged(object sender, EventArgs e)
        {
            Radio_per_month("SELECT \"LEVEL\", PERMONTH,STAFF_GROUP FROM TB_BASESALARY_PERMANENT_EMP WHERE STAFF_GROUP = 4");
        }
        private void Radio_per_month(string sql)
        {
            SqlDataSource sd = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", sql);
            DropDownList3.DataSource = sd;
            DropDownList3.DataTextField = "LEVEL";
            DropDownList3.DataValueField = "PERMONTH";
            DropDownList3.DataBind();
            Label71.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label69.Visible = true;
            Label69.Text = "อัตราค่าจ้าง " + DropDownList1.SelectedValue + " บาท";
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            DropDownList1.Items.Insert(0, "--");
            DropDownList1.SelectedIndex = 0;
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label70.Visible = true;
            Label70.Text = "อัตราค่าจ้าง " + DropDownList2.SelectedValue + " บาท";
        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            DropDownList2.Items.Insert(0, "--");
            DropDownList2.SelectedIndex = 0;
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label71.Visible = true;
            Label71.Text = "อัตราค่าจ้าง " + DropDownList3.SelectedValue + " บาท";
        }

        protected void DropDownList3_DataBound(object sender, EventArgs e)
        {
            DropDownList3.Items.Insert(0, "--");
            DropDownList3.SelectedIndex = 0;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Permanent_Emp_Hour.Visible = true;
            Panel_Permanent_Emp_Day.Visible = false;
            Panel_Permanent_Emp_Month.Visible = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Permanent_Emp_Hour.Visible = false;
            Panel_Permanent_Emp_Day.Visible = true;
            Panel_Permanent_Emp_Month.Visible = false;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Permanent_Emp_Hour.Visible = false;
            Panel_Permanent_Emp_Day.Visible = false;
            Panel_Permanent_Emp_Month.Visible = true;
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            if (Label69.Text != null && Label69.Text != "" && TextBox8.Text != null && TextBox8.Text != "" && DropDownList1.SelectedIndex != 0)
            {
                Double a = Convert.ToDouble(Label69.Text.Split(' ')[1]);
                Double b = Convert.ToDouble(TextBox8.Text);
                Label79.Text = "" + (a * b);
                Label79.Style.Add("color", "red");
                Label78.Visible = true;
                Label79.Visible = true;
                Label86.Visible = true;

            }
            else
            {
                Util.Alert(this, "ข้อมูลไม่ครบถ้วน");
            }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (Label71.Text != null && Label71.Text != "" && TextBox11.Text != null && TextBox11.Text != "" && DropDownList1.SelectedIndex != 0)
            {
                Double a = Convert.ToDouble(Label71.Text.Split(' ')[1]);
                Double b = Convert.ToDouble(TextBox11.Text);
                Label83.Text = "" + (a * b);
                Label83.Style.Add("color", "red");
                Label82.Visible = true;
                Label83.Visible = true;
                Label85.Visible = true;

            }
            else
            {
                Util.Alert(this, "ข้อมูลไม่ครบถ้วน");
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Label70.Text != null && Label70.Text != "" && TextBox10.Text != null && TextBox10.Text != "" && DropDownList2.SelectedIndex != 0)
            {
                Double a = Convert.ToDouble(Label70.Text.Split(' ')[1]);
                Double b = Convert.ToDouble(TextBox10.Text);
                Label80.Text = "" + (a * b);
                Label80.Style.Add("color", "red");
                Label81.Visible = true;
                Label80.Visible = true;
                Label84.Visible = true;
            }
            else
            {
                Util.Alert(this, "ข้อมูลไม่ครบถ้วน");
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salary_Salary_Admin.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBox2.Text.Length >= 2)
            {
                int acceptednumber = Convert.ToInt32(TextBox2.Text);
                if (acceptednumber < 0)
                {
                    TextBox2.Text = "";
                    Util.Alert(this,"values are not allowed");
                }
                else
                {
                    TextBox2.Text = TextBox2.Text;
                }
            }
        }
    }
}
