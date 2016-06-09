using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;

namespace WEB_PERSONAL
{
    public partial class insignia_from_edit : System.Web.UI.Page
    {

        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_id"] == null)
            {
                return;
            }
            if (Session["insignia_citizen_id"] == null)
            {
                Response.Redirect("insignia_citizen.aspx");
                return;

            }
            string citizen_id = Session["insignia_citizen_id"].ToString();
            int staff_type_id = 1;

            if (!IsPostBack)
            {
                BindDropDown1();
                BindDropDown2();
                BindDropDown3();
                BindDropDown4();
                BindDropDown11();
                BindDropDown6();
                BindDropDown9();
                BindDropDown10();
            }

            // try
            {
                string connectionString = "Data Source=ORCL_RMUTTO;User ID=rmutto;Password=Zxcvbnm";
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();
                    {
                        string Oracle = "SELECT STAFFTYPE_ID FROM TB_PERSON WHERE CITIZEN_ID = '" + citizen_id + "'";
                        using (OracleCommand command = new OracleCommand(Oracle, con))
                        {
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    staff_type_id = reader.GetInt32(0);
                                }
                            }
                        }
                    }

                    //Select ยศ
                    {
                        string Oracle = "SELECT RANK_SEQ FROM AA_REQUEST_INSIGNIA WHERE CITIZEN_ID = '" + citizen_id + "' ORDER BY ID DESC";
                        using (OracleCommand command = new OracleCommand(Oracle, con))
                        {
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                {
                                    DropDownList10.SelectedValue = reader.GetInt32(0).ToString();
                                }
                            }
                        }
                    }
                    {
                        //select 1
                        {
                            string Oracle = "select TB_TITLENAME.TITLE_NAME_TH, TB_PERSON.PERSON_NAME, TB_PERSON.PERSON_LASTNAME, TO_CHAR(TB_PERSON.BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'), TB_PERSON.CITIZEN_ID,"
                                + " TO_CHAR(TB_PERSON.INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'), TB_POSITION_AND_SALARY.POSITION_NAME"
                                + " from TB_PERSON, TB_TITLENAME, TB_POSITION_AND_SALARY"
                                + " where tb_person.citizen_id = '" + citizen_id + "' AND TB_PERSON.TITLE_ID = TB_TITLENAME.TITLE_ID order by TB_POSITION_AND_SALARY.DDATE desc";

                            using (OracleCommand command = new OracleCommand(Oracle, con))
                            {
                                using (OracleDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        TextBox3.Text = reader.GetString(0); /*TB_TITLENAME.TITLE_NAME_TH*/
                                        TextBox4.Text = reader.GetString(1); /*TB_PERSON.PERSON_NAME*/
                                        TextBox5.Text = reader.GetString(2); /*TB_PERSON.PERSON_LASTNAME*/
                                        TextBox7.Text = reader.GetString(3); /*TB_PERSON.BIRTHDATE*/
                                        TextBox8.Text = reader.GetString(4); /*TB_PERSON.CITIZEN_ID*/
                                        TextBox9.Text = reader.GetString(5); /*TO_CHAR(TB_PERSON.INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI')*/
                                        TextBox10.Text = reader.GetString(6); /*TB_POSITION_AND_SALARY.POSITION_NAME*/

                                    }
                                }
                            }
                        }

                        //select 1.9 ชื่อตำแหน่งปัจจุบัน (เพราะตารางชนกันเลยต้องการอีก Select)
                        {
                            string Oracle = "select TB_POSITION_AND_SALARY.POSITION_NAME" +
                            " from TB_POSITION_AND_SALARY " +
                            " where TB_POSITION_AND_SALARY.citizen_id = '" + citizen_id + "'" +
                            " order by TB_POSITION_AND_SALARY.DDATE";

                            using (OracleCommand command = new OracleCommand(Oracle, con))
                            {
                                using (OracleDataReader reader = command.ExecuteReader())
                                {
                                    reader.Read();
                                    {
                                        TextBox10.Text = reader.GetString(0);
                                    }
                                }
                            }
                        }

                        //select 2 ชื่อตำแหน่งปัจจุบัน (เพราะตารางชนกันเลยต้องการอีก Select)
                        {
                            string Oracle = "select TB_POSITION_AND_SALARY.POSITION_NAME,TB_POSITION_AND_SALARY.SALARY,TB_POSITION_AND_SALARY.POSITION_SALARY " +
                            " from TB_POSITION_AND_SALARY " +
                            " where TB_POSITION_AND_SALARY.citizen_id = '" + citizen_id + "'" +
                            " order by TB_POSITION_AND_SALARY.DDATE desc";

                            using (OracleCommand command = new OracleCommand(Oracle, con))
                            {
                                using (OracleDataReader reader = command.ExecuteReader())
                                {

                                    reader.Read();
                                    {
                                        TextBox11.Text = reader.GetString(0);
                                        TextBox14.Text = reader.GetInt32(1).ToString();
                                        TextBox15.Text = reader.GetInt32(2).ToString();
                                    }
                                }
                            }
                        }

                        //select 3
                        {
                            string Oracle = "select count(*) " +
                            " from AA_REQUEST_INSIGNIA " +
                            " where citizen_id = '" + citizen_id + "'";

                            using (OracleCommand command = new OracleCommand(Oracle, con))
                            {
                                using (OracleDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if (reader.GetInt32(0) == 0)
                                        {
                                            TextBox21.Text = TextBox9.Text;
                                        }

                                    }
                                }
                            }
                        }
                    }


                    {
                        if (staff_type_id == 1)
                        {
                            RadioButton1.Checked = true;
                        }
                        else if (staff_type_id == 2)
                        {
                            RadioButton2.Checked = true;
                        }
                        else if (staff_type_id == 5)
                        {
                            RadioButton3.Checked = true;
                        }
                        else if (staff_type_id == 3)
                        {
                            RadioButton4.Checked = true;
                        }



                    }

                }
            }
            // catch (Exception e2)
            // {
            //    string script = "alert(\"เกิดข้อผิดพลาด! " + e2.Message + "\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //S }

        }

        private void BindDropDown1()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from AA_COMMAND";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataValueField = "ID_COMM";
                        DropDownList1.DataTextField = "NAME_COMM";
                        DropDownList1.DataBind();
                        sqlConn.Close();

                        DropDownList1.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown2()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from AA_BUDDHISTERA";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList2.DataSource = dt;
                        DropDownList2.DataValueField = "ID_BBE";
                        DropDownList2.DataTextField = "ID_BBE";
                        DropDownList2.DataBind();
                        sqlConn.Close();

                        DropDownList2.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown3()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GRADEINSIGNIA";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList3.DataSource = dt;
                        DropDownList3.DataValueField = "ID_GRADEINSIGNIA";
                        DropDownList3.DataTextField = "NAME_GRADEINSIGNIA_THA";
                        DropDownList3.DataBind();
                        sqlConn.Close();

                        DropDownList3.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown4()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_TITLENAME";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList4.DataSource = dt;
                        DropDownList4.DataValueField = "TITLE_ID";
                        DropDownList4.DataTextField = "TITLE_NAME_TH";
                        DropDownList4.DataBind();
                        sqlConn.Close();

                        DropDownList4.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown11()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList11.DataSource = dt;
                        DropDownList11.DataValueField = "ID";
                        DropDownList11.DataTextField = "NAME";
                        DropDownList11.DataBind();

                        DropDownList6.DataSource = dt;
                        DropDownList6.DataValueField = "ID";
                        DropDownList6.DataTextField = "NAME";
                        DropDownList6.DataBind();

                        sqlConn.Close();

                        DropDownList11.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));
                        DropDownList6.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown6()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_WORK";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList7.DataSource = dt;
                        DropDownList7.DataValueField = "POSITION_WORK_ID";
                        DropDownList7.DataTextField = "POSITION_WORK_NAME";
                        DropDownList7.DataBind();

                        DropDownList8.DataSource = dt;
                        DropDownList8.DataValueField = "POSITION_WORK_ID";
                        DropDownList8.DataTextField = "POSITION_WORK_NAME";
                        DropDownList8.DataBind();

                        sqlConn.Close();

                        DropDownList7.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));
                        DropDownList8.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown9()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList9.DataSource = dt;
                        DropDownList9.DataValueField = "FACULTY_ID";
                        DropDownList9.DataTextField = "FACULTY_NAME";
                        DropDownList9.DataBind();
                        sqlConn.Close();

                        DropDownList9.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        private void BindDropDown10()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_RANK";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList10.DataSource = dt;
                        DropDownList10.DataValueField = "RANK_ID";
                        DropDownList10.DataTextField = "RANK_NAME_TH";
                        DropDownList10.DataBind();
                        sqlConn.Close();

                        DropDownList10.Items.Insert(0, new ListItem("-- กรุณาเลือก --", "0"));

                    }
                }
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*ดักช่องว่างที่ยังไม่ได้กรอก*/
            Label60.Text = "";
            Label61.Text = "";
            Label62.Text = "";
            if (DropDownList9.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0)
            {
                Util.Alert(this, "ยังเลือกไม่ครบ");
                if (DropDownList9.SelectedIndex == 0)
                {
                    Label60.Text = "*";
                }
                if (DropDownList2.SelectedIndex == 0)
                {
                    Label61.Text = "*";
                }
                if (DropDownList3.SelectedIndex == 0)
                {
                    Label62.Text = "*";
                }
                return;
            }
            /*--------- ดักช่องว่างที่ยังไม่ได้กรอก ---------*/

            // try
            {
                string connectionString = "Data Source=ORCL_RMUTTO;User ID=rmutto;Password=Zxcvbnm";
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();
                    //Select 1
                    {
                        string Oracle = "insert into AA_REQUEST_INSIGNIA values (SEQ_REQUEST_INSIGNIA_id.nextval,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,:16,:17,:18,:19,:20,:21)";

                        using (OracleCommand command = new OracleCommand(Oracle, con))
                        {
                            command.Parameters.AddWithValue("2", Session["insignia_citizen_id"].ToString());
                            command.Parameters.AddWithValue("3", DropDownList1.SelectedValue); //ID_COMM
                            command.Parameters.AddWithValue("4", DropDownList2.SelectedValue); //YEAR
                            command.Parameters.AddWithValue("5", DropDownList3.SelectedValue); //ID_GRADEINSIGNIA
                            command.Parameters.AddWithValue("6", RadioButton5.Checked ? "1" : "0"); //REPEAT_REQUEST
                            command.Parameters.AddWithValue("7", TextBox17.Text); //SALARY_BACK5Y
                            command.Parameters.AddWithValue("8", DropDownList4.SelectedValue); //OLD_TITLE_ID
                            command.Parameters.AddWithValue("9", TextBox19.Text); //OLD_NAME
                            command.Parameters.AddWithValue("10", TextBox20.Text); //OLD_LASTNAME
                            command.Parameters.AddWithValue("11", DropDownList11.SelectedValue); //H1_POSITION_ID_1
                            command.Parameters.AddWithValue("12", Util.ODT(TextBox25.Text)); //H1_DATE_1
                            command.Parameters.AddWithValue("13", DropDownList6.SelectedValue); //H1_POSITION_ID_2
                            command.Parameters.AddWithValue("14", Util.ODT(TextBox26.Text)); //H1_DATE_2
                            command.Parameters.AddWithValue("15", DropDownList7.SelectedValue); //H2_OLD_POSITION_WORK_ID
                            command.Parameters.AddWithValue("16", DropDownList8.SelectedValue); //H2_NEW_POSITION_WORK_ID
                            command.Parameters.AddWithValue("20", DropDownList9.SelectedValue); //FACULTY_ID
                            command.Parameters.AddWithValue("21", DropDownList10.SelectedValue); //RANK_SEQ */

                            int g2id = 1;
                            if (CheckBox2.Checked)
                            {
                                g2id = 2;
                            }

                            int g2id2 = 3;
                            if (CheckBox4.Checked)
                            {
                                g2id2 = 4;
                            }
                            else
                            {
                                g2id2 = 5;
                            }

                            command.Parameters.AddWithValue("17", g2id);
                            command.Parameters.AddWithValue("18", g2id2);
                            command.Parameters.AddWithValue("19", TextBox16.Text); //YEAR_BACK5Y
                            command.ExecuteNonQuery();
                            Util.Alert(this, "บันทีกเรียบร้อย");
                        }
                    }
                }
            }
        }
        
    }
}


