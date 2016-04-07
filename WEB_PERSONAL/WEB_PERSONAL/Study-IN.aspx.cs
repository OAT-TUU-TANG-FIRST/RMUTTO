using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OracleClient;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class Study_IN : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                Util.RunScript(this, "$(function () { foggle('1'); });");
            }
            BindGridView1();
        }

        protected void LinkButton15_Click(object sender, EventArgs e) {
            Util.RunScript(this, "$(function () { foggle('1'); });");
            //try
            //{
            using (OracleConnection con = Util.OC()) {
                {
                    {
                        string sql = "select STUDY_ID, CITIZEN_ID, STUDY_YEAR, STUDY_DEGREE_ID, STUDY_BRANCH_NAME, STUDY_LOCATION, STUDY_COURSE_ID, STUDY_TIME, STUDY_TIME_YEAR, TO_CHAR(STUDY_FROM_DATE,'dd MON yyyy', 'NLS_DATE_LANGUAGE=THAI'), TO_CHAR(STUDY_TO_DATE,'dd MON yyyy', 'NLS_DATE_LANGUAGE=THAI'), STUDY_TIME_COURSE, \"COMMENT\" from TB_STUDY WHERE STUDY_ID = " + TextBox23.Text;
                        using (OracleCommand command = new OracleCommand(sql, con)) {
                            using (OracleDataReader reader = command.ExecuteReader()) {
                                while (reader.Read()) {
                                    TextBox1.Text = reader.GetInt32(0).ToString();
                                    TextBox3.Text = reader.GetString(1);
                                    TextBox28.Text = reader.GetInt32(2).ToString();
                                    DropDownList1.SelectedValue = reader.GetInt32(3).ToString();
                                    TextBox29.Text = reader.GetString(4);
                                    TextBox6.Text = reader.GetString(5);
                                    DropDownList3.SelectedValue = reader.GetInt32(6).ToString();
                                    TextBox24.Text = reader.GetFloat(7).ToString();
                                    TextBox25.Text = reader.GetFloat(8).ToString();
                                    TextBox7.Text = Util.NDT(reader.GetString(9));
                                    TextBox8.Text = Util.NDT(reader.GetString(10));
                                    TextBox26.Text = reader.GetFloat(11).ToString();
                                    TextBox27.Text = reader.IsDBNull(12) ? "-" : reader.GetString(12);
                                }
                            }

                        }
                    }

                   /* {
                        string sql = "SELECT TB_PERSON.PERSON_NAME || ' ' || TB_PERSON.PERSON_LASTNAME, TB_POSITION.POSITION_NAME, TB_POSITION_WORK.POSITION_WORK_NAME FROM TB_PERSONAL, TB_POSITION, TB_POSITION_WORK WHERE CITIZEN_ID = '" + TextBox3.Text + "' AND TB_PERSONAL.POSITION_ID = TB_POSITION.POSITION_ID AND TB_PERSONAL.POSITION_WORK_ID = TB_POSITION_WORK.POSITION_WORK_ID";
                        using (OracleCommand command = new OracleCommand(sql, con)) {
                            using (OracleDataReader reader = command.ExecuteReader()) {
                                if (reader.HasRows) {
                                    while (reader.Read()) {
                                        Label37.Text = reader.GetString(0);
                                        Label39.Text = reader.GetString(1);
                                        Label41.Text = reader.GetString(2);
                                    }
                                } else {
                                    Util.Alert(this, "ไม่พบรหัสพนักงาน");
                                }

                            }

                        }
                    }*/

                    {
                        string sql = "SELECT TB_POSITION.NAME FROM TB_POSITION, TB_POSITION_AND_SALARY WHERE TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID AND TB_POSITION_AND_SALARY.CITIZEN_ID = :1 ORDER BY TB_POSITION_AND_SALARY.ID DESC";
                        using (OracleCommand command = new OracleCommand(sql, con)) {
                            command.Parameters.AddWithValue("1", TextBox3.Text);
                            using (OracleDataReader reader = command.ExecuteReader()) {
                                if (reader.HasRows) {
                                    while (reader.Read()) {
                                        Label41.Text = reader.GetString(0);
                                    }
                                } else {
                                    Util.Alert(this, "ไม่พบรหัสพนักงาน");
                                }

                            }

                        }
                    }


                }
            }
            //}
            //catch (Exception e2)
            //{
            //    string script = "alert('เกิดข้อผิดพลาด! " + e2.Message + "');";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
        }

        protected void LinkButton16_Click(object sender, EventArgs e) {
            Util.RunScript(this, "$(function () { foggle('1'); });");
            //try
            //{
            using (OracleConnection con = Util.OC()) {
                {
                    string sql = "insert into TB_STUDY values(SEQ_STUDY_ID.NEXTVAL,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14)";
                    using (OracleCommand command = new OracleCommand(sql, con)) {
                        command.Parameters.AddWithValue("2", TextBox3.Text);
                        command.Parameters.AddWithValue("3", TextBox28.Text);
                        command.Parameters.AddWithValue("4", DropDownList1.SelectedValue);
                        command.Parameters.AddWithValue("5", TextBox29.Text);
                        command.Parameters.AddWithValue("6", TextBox6.Text);
                        command.Parameters.AddWithValue("7", DropDownList3.SelectedValue);
                        command.Parameters.AddWithValue("8", TextBox24.Text);
                        command.Parameters.AddWithValue("9", TextBox25.Text);
                        command.Parameters.AddWithValue("10", Util.ODT(TextBox7.Text));
                        command.Parameters.AddWithValue("11", Util.ODT(TextBox8.Text));
                        command.Parameters.AddWithValue("12", TextBox26.Text);
                        command.Parameters.AddWithValue("13", TextBox27.Text);
                        command.Parameters.AddWithValue("14", Util.ODTT());
                        command.ExecuteNonQuery();
                        //Util.Alert(this, "เพิ่มข้อมูลสำเร็จ!");
                        BindGridView1();
                    }
                }
            }
            //}
            //catch (Exception e2)
            //{
            //  string script = "alert('เกิดข้อผิดพลาด! " + e2.Message + "');";
            //   ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
        }

        private string toDate(String str) {
            string[] paper_date_s = str.Split('/');
            int paper_date_y = Convert.ToInt32(paper_date_s[2]) - 543;
            return paper_date_y + paper_date_s[1] + paper_date_s[0];
        }

        protected void LinkButton17_Click(object sender, EventArgs e) {
            Util.RunScript(this, "$(function () { foggle('1'); });");
            /*try
            {
                string connectionString = "Data Source=203.158.140.66;Initial Catalog=personal;Integrated Security=FALSE;User ID=rmutto;Password=Zxcvbnm!";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    {
                        string sql = "update TB_STUDY set ID={0}, DATE='{1}', CITIZEN_ID='{2}', LEVEL='{3}', BRANCH_NAME='{4}', LOCATION_NAME='{5}', FROM_DATE='{6}', TO_DATE='{7}', CONTRACT_GIVER_NAME='{8}', CONTRACT_RECEIVER_NAME='{9}', CONTRACT_WITNESS1_NAME='{10}', CONTRACT_WITNESS2_NAME='{11}', MATE_NAME='{12}', MATE_WITNESS1_NAME='{13}', MATE_WITNESS2_NAME='{14}', LAWYER_NAME='{15}', DEPARTMENT_OFFICIAL_NAME='{16}', DIRECTOR_NAME='{17}', DEPUTY_DIRECTOR_NAME='{18}', TYPE_ID={19}, FUND_TYPE='{20}', COUNTRY_NAME='{21}' WHERE ID = " + TextBox1.Text;
                        sql = String.Format(sql, TextBox1.Text, toDate(TextBox2.Text), TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, toDate(TextBox7.Text), toDate(TextBox8.Text), TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox15.Text, TextBox16.Text, TextBox17.Text, TextBox18.Text, TextBox19.Text, DropDownList1.SelectedValue, TextBox20.Text, TextBox21.Text);
                        using (SqlCommand command = new SqlCommand(sql, con))
                        {
                            command.ExecuteNonQuery();
                            string script = "alert('แก้ไขข้อมูลสำเร็จ!');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                    }
                }
            }
            catch (Exception e2)
            {
                string script = "alert('เกิดข้อผิดพลาด! " + e2.Message + "');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }*/
            using (OracleConnection con = Util.OC()) {
                using(OracleCommand command = new OracleCommand("UPDATE TB_STUDY SET CITIZEN_ID = :2, STUDY_YEAR = :3, STUDY_DEGREE_ID = :4, STUDY_BRANCH_NAME = :5, STUDY_LOCATION = :6, STUDY_COURSE_ID = :7, STUDY_TIME = :8, STUDY_TIME_YEAR = :9, STUDY_FROM_DATE = :10, STUDY_TO_DATE = :11, STUDY_TIME_COURSE = :12, \"COMMENT\" = :13 WHERE STUDY_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", TextBox1.Text);
                    command.Parameters.AddWithValue("2", TextBox3.Text);
                    command.Parameters.AddWithValue("3", TextBox28.Text);
                    command.Parameters.AddWithValue("4", DropDownList1.SelectedValue);
                    command.Parameters.AddWithValue("5", TextBox29.Text);
                    command.Parameters.AddWithValue("6", TextBox6.Text);
                    command.Parameters.AddWithValue("7", DropDownList3.SelectedValue);
                    command.Parameters.AddWithValue("8", TextBox24.Text);
                    command.Parameters.AddWithValue("9", TextBox25.Text);
                    command.Parameters.AddWithValue("10", Util.ODT(TextBox7.Text));
                    command.Parameters.AddWithValue("11", Util.ODT(TextBox8.Text));
                    command.Parameters.AddWithValue("12", TextBox26.Text);
                    command.Parameters.AddWithValue("13", TextBox27.Text);
                    command.ExecuteNonQuery();
                    Util.Alert(this, "แก้ไขข้อมูลสำเร็จ");
                    BindGridView1();
                }
            }
        }

        protected void LinkButton18_Click(object sender, EventArgs e) {
            Util.RunScript(this, "$(function () { foggle('1'); });");
            //try
            {
                using (OracleConnection con = Util.OC()) {
                    {
                        string sql = "SELECT TB_POSITION.NAME FROM TB_POSITION, TB_POSITION_AND_SALARY WHERE TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID AND TB_POSITION_AND_SALARY.CITIZEN_ID = :1 ORDER BY TB_POSITION_AND_SALARY.ID DESC";
                        using (OracleCommand command = new OracleCommand(sql, con)) {
                            command.Parameters.AddWithValue("1", TextBox3.Text);
                            using (OracleDataReader reader = command.ExecuteReader()) {
                                if (reader.HasRows) {
                                    while (reader.Read()) {
                                        Label41.Text = reader.GetString(0);
                                    }
                                } else {
                                    Util.Alert(this, "ไม่พบรหัสพนักงาน");
                                }

                            }

                        }
                    }
                }
            }
            //catch (Exception e2)
            //{
            //   string script = "alert('เกิดข้อผิดพลาด! " + e2.Message + "');";
            //   ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e) {
            DropDownList1.Items.Insert(0, new ListItem("--กรุณาเลือกระดับการศึกษา--", String.Empty));
            DropDownList1.SelectedIndex = 0;
        }

        protected void DropDownList3_DataBound(object sender, EventArgs e) {
            DropDownList3.Items.Insert(0, new ListItem("--กรุณาเลือกหลักสูตร--", String.Empty));
            DropDownList3.SelectedIndex = 0;
        }
        private void BindGridView1() {
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {
           /* if (!Person.IsAdmin(Session["login_id"].ToString())) {
                e.Cancel = true;
                Util.Alert(this, "คุณไม่มีสิทธิใช้งานในส่วนนี้");
            }*/
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e) {
            Util.RunScript(this, "$(function () { foggle('2'); });");
        }

    }
}