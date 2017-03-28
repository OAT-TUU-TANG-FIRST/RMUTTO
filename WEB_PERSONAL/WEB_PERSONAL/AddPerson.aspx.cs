using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using WEB_PERSONAL.Class;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class AddPerson : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
                DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
                DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");
                SQLCampus();
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");

                tbCitizenID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbPhone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbTelephone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        protected void SQLCampus()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CAMPUS";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlCampus.DataSource = dt;
                        ddlCampus.DataValueField = "CAMPUS_ID";
                        ddlCampus.DataTextField = "CAMPUS_NAME";
                        ddlCampus.DataBind();
                        sqlConn.Close();

                        ddlCampus.Items.Insert(0, new ListItem("--กรุณาเลือกวิทยาเขต--", "0"));
                        ddlFaculty.Items.Insert(0, new ListItem("--กรุณาเลือกสำนัก / สถาบัน / คณะ--", "0"));
                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY where CAMPUS_ID = " + ddlCampus.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlFaculty.DataSource = dt;
                        ddlFaculty.DataValueField = "FACULTY_ID";
                        ddlFaculty.DataTextField = "FACULTY_NAME";
                        ddlFaculty.DataBind();
                        sqlConn.Close();

                        ddlFaculty.Items.Insert(0, new ListItem("--กรุณาเลือกสำนัก / สถาบัน / คณะ--", "0"));
                        ddlDivision.Items.Clear();
                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Clear();
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DIVISION where FACULTY_ID = " + ddlFaculty.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDivision.DataSource = dt;
                        ddlDivision.DataValueField = "DIVISION_ID";
                        ddlDivision.DataTextField = "DIVISION_NAME";
                        ddlDivision.DataBind();
                        sqlConn.Close();

                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Clear();
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_WORK_DIVISION where DIVISION_ID = " + ddlDivision.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlWorkDivision.DataSource = dt;
                        ddlWorkDivision.DataValueField = "WORK_ID";
                        ddlWorkDivision.DataTextField = "WORK_NAME";
                        ddlWorkDivision.DataBind();
                        sqlConn.Close();

                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--"));
                    }
                }
            }
            catch { }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(*) FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 0)
                            {
                                ddlWorkDivision.Visible = false;
                                trWorkDivision.Visible = false;
                            }
                            else
                            {
                                ddlWorkDivision.Visible = true;
                                trWorkDivision.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void ClearText()
        {
            tbCitizenID.Text = "";
            ddlTitle.SelectedIndex = 0;
            tbNameTH.Text = "";
            tbLastNameTH.Text = "";
            tbNameEN.Text = "";
            tbLastNameEN.Text = "";
            ddlGender.SelectedIndex = 0;
            tbBirthday.Text = "";
            tbEmail.Text = "";
            tbPhone.Text = "";
            tbTelephone.Text = "";
            ddlRace.SelectedIndex = 0;
            ddlNation.SelectedIndex = 0;
            ddlBlood.SelectedIndex = 0;
            ddlReligion.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;      
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            if (tbCitizenID.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกบัตรประชาชน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlTitle.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกคำนำหน้า</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbNameTH.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbLastNameTH.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกนามสกุล</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlGender.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกเพศ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbBirthday.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวันเกิด</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbEmail.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกอีเมล</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlCampus.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกวิทยาเขต</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlFaculty.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกสำนัก / สถาบัน / คณะ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlDivision.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }       

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(*) FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) != 0 && ddlWorkDivision.SelectedIndex == 0)
                            {
                                notification.Attributes["class"] = "alert alert_danger";
                                notification.InnerHtml = "";
                                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                                notification.InnerHtml += "<div>กรุณาเลือกงาน / ฝ่าย</div>";
                                return;
                            }
                            else
                            {
                                notification.Attributes["class"] = "none";
                                notification.InnerHtml = "";
                            }
                        }
                    }
                }
            }

            if (ddlStaffType.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกประเภทบุคลากร</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbDateInwork.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวันที่บรรจุ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (ddlWorkDivision.SelectedIndex == 0)
            {
                PS_PERSON P0 = new PS_PERSON();
                P0.PS_MINISTRY_ID = 1;
                P0.PS_GROM = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
                P0.PS_CITIZEN_ID = tbCitizenID.Text;
                P0.PS_TITLE_ID = Convert.ToInt32(ddlTitle.SelectedValue);
                P0.PS_FN_TH = tbNameTH.Text;
                P0.PS_LN_TH = tbLastNameTH.Text;
                P0.PS_FN_EN = tbNameEN.Text;
                P0.PS_LN_EN = tbLastNameEN.Text;
                P0.PS_GENDER_ID = Convert.ToInt32(ddlGender.SelectedValue);
                P0.PS_BIRTHDAY_DATE = Util.ODT(tbBirthday.Text);
                P0.PS_BIRTHDAY_LONG = Util.ToThaiWordBirthday(tbBirthday.Text);
                P0.PS_EMAIL = tbEmail.Text;
                P0.PS_PHONE = tbPhone.Text;
                P0.PS_TELEPHONE_WORK = tbTelephone.Text;
                P0.PS_RACE_ID = Convert.ToInt32(ddlRace.SelectedValue);
                P0.PS_NATION_ID = ddlNation.SelectedValue;
                P0.PS_BLOOD_ID = Convert.ToInt32(ddlBlood.SelectedValue);
                P0.PS_RELIGION_ID = Convert.ToInt32(ddlReligion.SelectedValue);
                P0.PS_STATUS_ID = Convert.ToInt32(ddlStatus.SelectedValue);
                P0.PS_SW_ID = 6;
                P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
                P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
                P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
                P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
                P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
                P0.PS_PASSWORD = Util.RandomPassword(8);
                P0.PS_POSI_ADMIN = 1;
                P0.PS_POSI_DIRECT = 3;
                P0.PS_POSI_ACAD = 5;
                P0.PS_POSI_GENERAL = 10;
                P0.PS_POSI_EMP_GROUP = 14;

                if (P0.CheckUseCitizenID())
                {
                    P0.INSERT_PS_PERSON_DV();
                    Util.SendMail(P0);
                    ClearText();
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                    notification.InnerHtml += "<div>มีรหัสบัตรประชาชนที่กรอกแล้วในฐานข้อมูล</div>";
                }
            }
            else
            {
                PS_PERSON P0 = new PS_PERSON();
                P0.PS_MINISTRY_ID = 1;
                P0.PS_GROM = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
                P0.PS_CITIZEN_ID = tbCitizenID.Text;
                P0.PS_TITLE_ID = Convert.ToInt32(ddlTitle.SelectedValue);
                P0.PS_FN_TH = tbNameTH.Text;
                P0.PS_LN_TH = tbLastNameTH.Text;
                P0.PS_FN_EN = tbNameEN.Text;
                P0.PS_LN_EN = tbLastNameEN.Text;
                P0.PS_GENDER_ID = Convert.ToInt32(ddlGender.SelectedValue);
                P0.PS_BIRTHDAY_DATE = Util.ODT(tbBirthday.Text);
                P0.PS_BIRTHDAY_LONG = Util.ToThaiWordBirthday(tbBirthday.Text);
                P0.PS_EMAIL = tbEmail.Text;
                P0.PS_PHONE = tbPhone.Text;
                P0.PS_TELEPHONE_WORK = tbTelephone.Text;
                P0.PS_RACE_ID = Convert.ToInt32(ddlRace.SelectedValue);
                P0.PS_NATION_ID = ddlNation.SelectedValue;
                P0.PS_BLOOD_ID = Convert.ToInt32(ddlBlood.SelectedValue);
                P0.PS_RELIGION_ID = Convert.ToInt32(ddlReligion.SelectedValue);
                P0.PS_STATUS_ID = Convert.ToInt32(ddlStatus.SelectedValue);
                P0.PS_SW_ID = 6;
                P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
                P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
                P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
                P0.PS_WORK_DIVISION_ID = Convert.ToInt32(ddlWorkDivision.SelectedValue);
                P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
                P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
                P0.PS_PASSWORD = Util.RandomPassword(8);
                P0.PS_POSI_ADMIN = 1;
                P0.PS_POSI_DIRECT = 3;
                P0.PS_POSI_ACAD = 5;
                P0.PS_POSI_GENERAL = 10;
                P0.PS_POSI_EMP_GROUP = 14;

                if (P0.CheckUseCitizenID())
                {
                    P0.INSERT_PS_PERSON_WD();
                    Util.SendMail(P0);
                    ClearText();
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                    notification.InnerHtml += "<div>มีรหัสบัตรประชาชนที่กรอกแล้วในฐานข้อมูล</div>";
                }
            }
        }

    }
}