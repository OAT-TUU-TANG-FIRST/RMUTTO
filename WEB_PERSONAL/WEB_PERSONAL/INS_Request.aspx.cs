using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class INS_Request : System.Web.UI.Page
    {

        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand cmd = new OracleCommand("select STAFFTYPE_ID,FACULTY_ID,TITLE_ID,PERSON_NAME,PERSON_LASTNAME,GENDER_ID,TO_CHAR(BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),CITIZEN_ID, TO_CHAR(INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),POSITION_WORK_ID from TB_PERSON where citizen_id = '" + Session["login_id"].ToString() + "'", conn))
                    //using (OracleCommand cmd = new OracleCommand("select s.STAFFTYPE_ID, f.FACULTY_NAME, t.TITLE_NAME_TH, p.PERSON_NAME, p.PERSON_LASTNAME, g.GENDER_NAME ,TO_CHAR(p.BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'), p.CITIZEN_ID ,TO_CHAR(p.INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'), pw.POSITION_WORK_NAME FROM TB_PERSON p inner join TB_STAFFTYPE s on p.STAFFTYPE_ID = s.STAFFTYPE_ID inner join TB_FACULTY f on p.FACULTY_ID = f.FACULTY_ID inner join TB_TITLENAME t on p.TITLE_ID = t.TITLE_ID inner join TB_GENDER g on p.GENDER_ID = g.GENDER_ID inner join TB_POSITION_WORK pw on p.POSITION_WORK_ID = pw.POSITION_WORK_ID where p.citizen_id = '" + Session["login_id"].ToString() + "'", conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                ddl1.SelectedValue = reader.IsDBNull(0) ? "0" : reader.GetInt32(0).ToString();
                                ddl2.SelectedValue = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                                ddl6.SelectedValue = reader.IsDBNull(2) ? "0" : reader.GetInt32(2).ToString();
                                txt1.Text = reader.IsDBNull(3) ? "" : reader.GetString(3).ToString();
                                txt2.Text = reader.IsDBNull(4) ? "" : reader.GetString(4).ToString();
                                ddl7.SelectedValue = reader.IsDBNull(5) ? "0" : reader.GetInt32(5).ToString();
                                txt3.Text = reader.IsDBNull(6) ? "" : reader.GetString(6).ToString();
                                txt4.Text = reader.IsDBNull(7) ? "" : reader.GetString(7).ToString();
                                txt5.Text = reader.IsDBNull(8) ? "" : reader.GetString(8).ToString();
                                ddl8.SelectedValue = reader.IsDBNull(9) ? "0" : reader.GetString(9).ToString();
                            }
                        }
                    }
                }

                DDLCOMMAND();
                DDLINS_GRADEINSIGNIA();
                DDLStaffType();
                DDLFaculty();
                DDLTitle();
                DDLGender();
                DDLPositionWork();
            }
        }


        void BindData()
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }
        }

        private void DDLCOMMAND()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from INS_COMMAND";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddl3.DataSource = dt;
                        ddl3.DataValueField = "ID_COMM";
                        ddl3.DataTextField = "NAME_COMM";
                        ddl3.DataBind();
                        sqlConn.Close();

                        ddl3.Items.Insert(0, new ListItem("--กรุณเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLINS_GRADEINSIGNIA()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from INS_GRADEINSIGNIA";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddl4.DataSource = dt;
                        ddl4.DataValueField = "ID_GRADEINSIGNIA";
                        ddl4.DataTextField = "NAME_GRADEINSIGNIA_THA";
                        ddl4.DataBind();
                        sqlConn.Close();

                        ddl4.Items.Insert(0, new ListItem("--กรุณเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLStaffType()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFFTYPE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddl1.DataSource = dt;
                        ddl1.DataValueField = "STAFFTYPE_ID";
                        ddl1.DataTextField = "STAFFTYPE_NAME";
                        ddl1.DataBind();
                        sqlConn.Close();

                        ddl1.Items.Insert(0, new ListItem("--กรุณาเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLFaculty()
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
                        ddl2.DataSource = dt;
                        ddl2.DataValueField = "FACULTY_ID";
                        ddl2.DataTextField = "FACULTY_NAME";
                        ddl2.DataBind();
                        sqlConn.Close();

                        ddl2.Items.Insert(0, new ListItem("--กรุณาเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLTitle()
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
                        ddl6.DataSource = dt;
                        ddl6.DataValueField = "TITLE_ID";
                        ddl6.DataTextField = "TITLE_NAME_TH";
                        ddl6.DataBind();
                        sqlConn.Close();

                        ddl6.Items.Insert(0, new ListItem("--กรุณาเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLGender()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GENDER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddl7.DataSource = dt;
                        ddl7.DataValueField = "GENDER_ID";
                        ddl7.DataTextField = "GENDER_NAME";
                        ddl7.DataBind();
                        sqlConn.Close();

                        ddl7.Items.Insert(0, new ListItem("--กรุณเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLPositionWork()
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
                        ddl8.DataSource = dt;
                        ddl8.DataValueField = "POSITION_WORK_ID";
                        ddl8.DataTextField = "POSITION_WORK_NAME";
                        ddl8.DataBind();
                        sqlConn.Close();

                        ddl8.Items.Insert(0, new ListItem("--กรุณาเลือก--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            ClassRequest r = new ClassRequest();

            r.CITIZEN_ID = txt4.Text;
            //r.RANK_ID = Convert.ToInt32(ddl5.SelectedValue);
            r.TITLE_ID = Convert.ToInt32(ddl6.SelectedValue);
            r.NAME = txt1.Text;
            r.LASTNAME = txt2.Text;
            r.GENDER_ID = Convert.ToInt32(ddl7.SelectedValue);
            r.BIRTHDATE = DateTime.Parse(txt3.Text);
            r.STAFFTYPE_ID = Convert.ToInt32(ddl1.SelectedValue);
            r.FACULTY_ID = Convert.ToInt32(ddl2.SelectedValue);
            r.GRADEINSIGNIA_ID = Convert.ToInt32(ddl7.SelectedValue);
            r.STARTING_DATE = DateTime.Parse(txt5.Text);
            r.STARTING_POSITION_ID = Convert.ToInt32(ddl8.SelectedValue);
           // r.CURRENT_POSITION = ddl9.SelectedValue;
            r.CURRENT_SALARY = Convert.ToInt32(txt6.Text);
            

            string[] splitDate1 = txt3.Text.Split(' ');
            string[] splitDate2 = txt5.Text.Split(' ');
            if (splitDate1.Length == 4)
            {
                splitDate1[2] = splitDate1[3];
            }
            if (splitDate2.Length == 4)
            {
                splitDate2[2] = splitDate2[3];
            }
            r.BIRTHDATE = new DateTime(Convert.ToInt32(splitDate1[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            r.STARTING_DATE = new DateTime(Convert.ToInt32(splitDate2[2]), Util.MonthToNumber(splitDate2[1]), Convert.ToInt32(splitDate2[0]));
            
            r.InsertRequest();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);

        }



    }
}