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
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class AddPerson : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProvinceList();
                SQLCampus();
                tbCitizenID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbPhone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbTelephone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbZipcode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbZipcode2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";
                //view1
                DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
                DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                ddlRace.SelectedValue = "ไทย";
                DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                ddlNation.SelectedValue = "ไทย";
                DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");
                DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
                //view2
                DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                ddlCountry.SelectedValue = "Thailand";
                DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                ddlCountry2.SelectedValue = "Thailand";

                //view3
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
                DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
                DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งบริหาร--");
                DatabaseManager.BindDropDown(ddlPositionWork, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
                DatabaseManager.BindDropDown(ddlAcademic, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
                DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");

            }
        }
        private void BindProvinceList()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlProvince.DataSource = dt;
                        ddlProvince.DataValueField = "PROVINCE_ID";
                        ddlProvince.DataTextField = "PROVINCE_TH";
                        ddlProvince.DataBind();
                        sqlConn.Close();

                        ddlProvince.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";
                    }
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlProvince2.DataSource = dt;
                        ddlProvince2.DataValueField = "PROVINCE_ID";
                        ddlProvince2.DataTextField = "PROVINCE_TH";
                        ddlProvince2.DataBind();
                        sqlConn.Close();

                        ddlProvince2.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";
                    }
                }
            }
            catch { }
        }
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlProvince.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAmphur.DataSource = dt;
                        ddlAmphur.DataValueField = "AMPHUR_ID";
                        ddlAmphur.DataTextField = "AMPHUR_TH";
                        ddlAmphur.DataBind();
                        sqlConn.Close();

                        ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict.Items.Clear();
                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlAmphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DISTRICT where AMPHUR_ID=:DISTRICT_ID";
                        sqlCmd.Parameters.Add(":DISTRICT_ID", ddlAmphur.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDistrict.DataSource = dt;
                        ddlDistrict.DataValueField = "DISTRICT_ID";
                        ddlDistrict.DataTextField = "DISTRICT_TH";
                        ddlDistrict.DataBind();
                        sqlConn.Close();

                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";

                    }
                }
            }
            catch { }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC = new OracleCommand(setZIP, conn);
            string ZIPCODE = SC.ExecuteScalar().ToString();
            tbZipcode.Text = ZIPCODE;
        }

        protected void ddlProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlProvince2.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAmphur2.DataSource = dt;
                        ddlAmphur2.DataValueField = "AMPHUR_ID";
                        ddlAmphur2.DataTextField = "AMPHUR_TH";
                        ddlAmphur2.DataBind();
                        sqlConn.Close();

                        ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict2.Items.Clear();
                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlAmphur2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DISTRICT where AMPHUR_ID=:DISTRICT_ID";
                        sqlCmd.Parameters.Add(":DISTRICT_ID", ddlAmphur2.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDistrict2.DataSource = dt;
                        ddlDistrict2.DataValueField = "DISTRICT_ID";
                        ddlDistrict2.DataTextField = "DISTRICT_TH";
                        ddlDistrict2.DataBind();
                        sqlConn.Close();

                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";

                    }
                }
            }
            catch { }
        }

        protected void ddlDistrict2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP2 = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC2 = new OracleCommand(setZIP2, conn);
            string ZIPCODE2 = SC2.ExecuteScalar().ToString();
            tbZipcode2.Text = ZIPCODE2;
        }

        protected void SQLCampus()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
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
                using (OracleConnection sqlConn = new OracleConnection(strConn))
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
                using (OracleConnection sqlConn = new OracleConnection(strConn))
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
                using (OracleConnection sqlConn = new OracleConnection(strConn))
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

                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void lbuV1Next_Click(object sender, EventArgs e)
        {
            /*if(tbCitizenID.Text == "" || ddlTitle.SelectedIndex == 0 || tbNameTH.Text == ""|| tbLastNameTH.Text == "" || tbNameEN.Text == "" || tbLastNameEN.Text == "" || ddlGender.SelectedIndex == 0 || tbBirthday.Text == "" || ddlRace.SelectedIndex == 0 || ddlNation.SelectedIndex == 0 || ddlBlood.SelectedIndex == 0 || tbEmail.Text == "" || tbPhone.Text == "" || tbTelephone.Text == "" || ddlReligion.SelectedIndex == 0 || ddlStatus.SelectedIndex == 0 || tbFatherName.Text == "" || tbFatherLastName.Text == "" || tbMotherName.Text == "" || tbMotherLastName.Text == "" || tbMotherOldLastName.Text == "" || tbCoupleName.Text == "" || tbCoupleLastName.Text == "" || tbCoupleOldLastName.Text == "") {

              notification.Attributes["class"] = "alert alert_danger";
              notification.InnerHtml = "";

              notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>เกิดข้อผิดพลาด !</strong></div>";
              if (tbCitizenID.Text == "") {
                  notification.InnerHtml += "<div>กรุณากรอก 'บัตรประชาชน'</div>";
              }
              if (ddlTitle.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'คำนำหน้า'</div>";
              }
              if (tbNameTH.Text == "") {
                  notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ'</div>";
              }
              if (tbLastNameTH.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล'</div>";
              }
              if (tbNameEN.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ อังกฤษ'</div>";
              }
              if (tbLastNameEN.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล อังกฤษ'</div>";
              }
              if (ddlGender.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'เพศ'</div>";
              }
              if (tbBirthday.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'วันเกิด'</div>";
              }
              if (ddlRace.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'เชื้อชาติ'</div>";
              }
              if (ddlNation.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'สัญชาติ'</div>";
              }
              if (ddlBlood.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'กรุ๊ปเลือด'</div>";
              }
              if (tbEmail.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'อีเมล'</div>";
              }
              if (tbPhone.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์มือถือ'</div>";
              }
              if (tbTelephone.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์ที่ทำงาน'</div>";
              }
              if (ddlReligion.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'ศาสนา'</div>";
              }
              if (ddlStatus.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'สถานภาพ'</div>";
              }
              if (tbFatherName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'ชื่อบิดา'</div>";
              }
              if (tbFatherLastName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลบิดา'</div>";
              }
              if (tbMotherName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'ชื่อมารดา'</div>";
              }
              if (tbMotherLastName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดา'</div>";
              }
              if (tbMotherOldLastName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดาเดิม'</div>";
              }
              if (tbCoupleName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'ชื่อคู่สมรส'</div>";
              }
              if (tbCoupleLastName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรส'</div>";
              }
              if (tbCoupleOldLastName.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรสเดิม'</div>";
              }
          } else {
              MultiView1.ActiveViewIndex = 1;
              notification.Attributes["class"] = "none";
              notification.InnerHtml = "";
          }*/
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV2Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e)
        {
            /*if (tbHomeAdd.Text == "" || tbSoi.Text == "" || tbMoo.Text == "" || tbRoad.Text == "" || ddlProvince.SelectedIndex == 0 || ddlAmphur.SelectedIndex == 0 || ddlDistrict.SelectedIndex == 0 || tbZipcode.Text == "" || ddlCountry.SelectedIndex == 0 || tbState.Text == "" ||
                tbHomeAdd2.Text == "" || tbSoi2.Text == "" || tbMoo2.Text == "" || tbRoad2.Text == "" || ddlProvince2.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0 || tbZipcode2.Text == "" || ddlCountry2.SelectedIndex == 0 || tbState2.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbHomeAdd.Text == "" || tbHomeAdd2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'บ้านเลขที่'</div>";
                }
                if (tbSoi.Text == "" || tbSoi2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ซอย'</div>";
                }
                if (tbMoo.Text == "" || tbMoo2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หมู่'</div>";
                }
                if (tbRoad.Text == "" || tbRoad2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ถนน'</div>";
                }
                if (ddlProvince.SelectedIndex == 0 || ddlProvince2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'จังหวัด'</div>";
                }
                if (ddlAmphur.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'อำเภอ / เขต'</div>";
                }
                if (ddlDistrict.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำบล / แขวง'</div>";
                }
                if (tbZipcode.Text == "" || tbZipcode2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'รหัสไปรณีย์'</div>";
                }
                if (ddlCountry.SelectedIndex == 0 || ddlCountry2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศ'</div>";
                }
            }
            else {
                MultiView1.ActiveViewIndex = 2;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }*/
            //MultiView1.ActiveViewIndex = 2;
        }
        protected void lbuAddressFetch_Click(object sender, EventArgs e)
        {
            tbHomeAdd2.Text = tbHomeAdd.Text;
            tbSoi2.Text = tbSoi.Text;
            tbMoo2.Text = tbMoo.Text;
            tbRoad2.Text = tbRoad.Text;
            tbZipcode2.Text = tbZipcode.Text;
            tbState2.Text = tbState.Text;

            ddlProvince2.Items.Clear();
            ddlAmphur2.Items.Clear();
            ddlDistrict2.Items.Clear();

            ddlProvince2.Items.AddRange(ddlProvince.Items.OfType<ListItem>().ToArray());
            ddlAmphur2.Items.AddRange(ddlAmphur.Items.OfType<ListItem>().ToArray());
            ddlDistrict2.Items.AddRange(ddlDistrict.Items.OfType<ListItem>().ToArray());

            ddlProvince2.SelectedIndex = ddlProvince.SelectedIndex;
            ddlAmphur2.SelectedIndex = ddlAmphur.SelectedIndex;
            ddlDistrict2.SelectedIndex = ddlDistrict.SelectedIndex;
            ddlCountry2.SelectedIndex = ddlCountry.SelectedIndex;
        }

        protected void lbuV3Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV3Back_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            /*if (ddlCampus.SelectedIndex == 0 || ddlFaculty.SelectedIndex == 0 || ddlDivision.SelectedIndex == 0 || ddlWorkDivision.SelectedIndex == 0 || ddlStaffType.SelectedIndex == 0 || ddlBudget.SelectedIndex == 0 || ddlAdminPosition.SelectedIndex == 0 || ddlPositionWork.SelectedIndex == 0 || ddlAcademic.SelectedIndex == 0 || tbDateInwork.Text == "" || tbSpecialWork.Text == "" || ddlTeachISCED.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlCampus.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'วิทยาเขต'</div>";
                }
                if (ddlFaculty.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'สำนัก / สถาบัน / คณะ'</div>";
                }
                if (ddlDivision.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'กอง / สำนักงานเลขา / ภาควิชา'</div>";
                }
                if (ddlWorkDivision.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'งาน / ฝ่าย'</div>";
                }
                if (ddlStaffType.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเภทบุคลากร'</div>";
                }
                if (ddlBudget.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเภทเงินจ้าง'</div>";
                }
                if (ddlAdminPosition.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งบริหาร'</div>";
                }
                if (ddlPositionWork.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งในสายงาน'</div>";
                }
                if (ddlAcademic.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งทางวิชาการ'</div>";
                }
                if (tbDateInwork.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันที่เริ่มบรรจุ / เริ่มงาน'</div>";
                }
                if (tbSpecialWork.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ความเชี่ยวชาญในสายงาน'</div>";
                }
                if (ddlTeachISCED.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'กลุ่มสาขาวิชาที่สอน'</div>";
                }
                else {

                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }*/

            PS_PERSON P0 = new PS_PERSON();

            P0.PS_CITIZEN_ID = tbCitizenID.Text;
            P0.PS_MINISTRY_ID = 1;
            P0.PS_GROM = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            P0.PS_TITLE_ID = Convert.ToInt32(ddlTitle.SelectedValue);
            P0.PS_FN_TH = tbNameTH.Text;
            P0.PS_FN_EN = tbNameEN.Text;
            P0.PS_LN_TH = tbLastNameTH.Text;
            P0.PS_LN_EN = tbLastNameEN.Text;
            P0.PS_GENDER_ID = Convert.ToInt32(ddlGender.SelectedValue);
            P0.PS_BIRTHDAY_DATE = Util.ODT(tbBirthday.Text);
            P0.PS_BIRTHDAY_LONG = Util.ToThaiWordBirthday(tbBirthday.Text);
            P0.PS_RACE_ID = Convert.ToInt32(ddlRace.SelectedValue);
            P0.PS_NATION_ID = ddlNation.SelectedValue;
            P0.PS_BLOOD_ID = Convert.ToInt32(ddlBlood.SelectedValue);
            P0.PS_EMAIL = tbEmail.Text;
            P0.PS_PHONE = tbPhone.Text;
            P0.PS_TELEPHONE_WORK = tbTelephone.Text;
            P0.PS_RELIGION_ID = Convert.ToInt32(ddlReligion.SelectedValue);
            P0.PS_STATUS_ID = Convert.ToInt32(ddlStatus.SelectedValue);
            P0.PS_DAD_FN = tbFatherName.Text;
            P0.PS_DAD_LN = tbFatherLastName.Text;
            P0.PS_MOM_FN = tbMotherName.Text;
            P0.PS_MOM_LN = tbMotherLastName.Text;
            P0.PS_MOM_LN_OLD = tbMotherOldLastName.Text;
            P0.PS_LOV_FN = tbCoupleName.Text;
            P0.PS_LOV_LN = tbCoupleLastName.Text;
            P0.PS_LOV_LN_OLD = tbCoupleOldLastName.Text;
            //view2/8
            P0.PS_HOMEADD = tbHomeAdd.Text;
            P0.PS_SOI = tbSoi.Text;
            P0.PS_MOO = tbMoo.Text;
            P0.PS_STREET = tbRoad.Text;
            P0.PS_PROVINCE_ID = Convert.ToInt32(ddlProvince.SelectedValue);
            P0.PS_AMPHUR_ID = Convert.ToInt32(ddlAmphur.SelectedValue);
            P0.PS_DISTRICT = Convert.ToInt32(ddlDistrict.SelectedValue);
            P0.PS_ZIPCODE = tbZipcode.Text;
            P0.PS_COUNTRY_ID = Convert.ToInt32(ddlCountry.SelectedValue);
            P0.PS_STATE = tbState.Text;
            P0.PS_HOMEADD_NOW = tbHomeAdd2.Text;
            P0.PS_SOI_NOW = tbSoi2.Text;
            P0.PS_MOO_NOW = tbMoo2.Text;
            P0.PS_STREET_NOW = tbRoad.Text;
            P0.PS_PROVINCE_ID_NOW = Convert.ToInt32(ddlProvince2.SelectedValue);
            P0.PS_AMPHUR_ID_NOW = Convert.ToInt32(ddlAmphur2.SelectedValue);
            P0.PS_DISTRICT_ID_NOW = Convert.ToInt32(ddlDistrict2.SelectedValue);
            P0.PS_ZIPCODE_NOW = tbZipcode2.Text;
            P0.PS_COUNTRY_ID_NOW = Convert.ToInt32(ddlCountry2.SelectedValue);
            P0.PS_STATE_NOW = tbState2.Text;
            //view4/8
            P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
            P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
            P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            P0.PS_WORK_DIVISION_ID = Convert.ToInt32(ddlWorkDivision.SelectedValue);
            P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
            P0.PS_BUDGET_ID = Convert.ToInt32(ddlBudget.SelectedValue);
            P0.PS_ADMIN_POS_ID = ddlAdminPosition.SelectedValue;
            P0.PS_WORK_POS_ID = Convert.ToInt32(ddlPositionWork.SelectedValue);
            P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlAcademic.SelectedValue);
            P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
            P0.PS_RETIRE_DATE = Util.ODT(Util.BirthdayToRetireDate(tbBirthday.Text));
            P0.PS_RETIRE_LONG = Util.ToThaiWordRetire(tbBirthday.Text);
            P0.PS_SPECIAL_WORK = tbSpecialWork.Text;
            P0.PS_TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            P0.PS_PASSWORD = Util.RandomPassword(8);

            if (P0.CheckUseCitizenID())
            {
                P0.INSERT_PS_PERSON();
                Util.SendMail(P0);
                MultiView1.ActiveViewIndex = 0;
                //Clear Not yet
                notification.Attributes["class"] = "alert alert_success";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong> เพิ่มข้อมูลบุคลากร เรียบร้อย</strong></div>";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('รหัสประจำตัวประชาชน ที่กรอกนี้ มีอยู่ในระบบแล้ว !')", true);
            }
        }

        protected void lbCheckUseCitizen_Click(object sender, EventArgs e)
        {
            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CITIZEN_ID = tbCitizenID.Text;
            if (P0.CheckUseCitizenID())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('สามารถใช้รหัสบัตรประชาชนนี้')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('รหัสประจำตัวประชาชน ที่กรอกนี้ มีอยู่ในระบบแล้ว !')", true);
            }
        }
    }
}