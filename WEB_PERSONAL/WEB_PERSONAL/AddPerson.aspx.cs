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
                SqlddlRank();
                SqlddlTypePosition();
                SqlddlPosition();
                SqlddlAdminPosition();
                SqlddlPositionWork();
                SqlddlPositionAcademic();
                SqlddlTeachISCED();
                SqlddlPosiInsigGover();
                SqlddlPosiInsigDegree();
                SqlddlPosiInsigEMP();

                tbCitizenID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbPhone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbTelephone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbZipcode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbZipcode2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbSalary.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                tbPositionSalary.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

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
                //DatabaseManager.BindDropDown(ddlRank, "SELECT * FROM TB_RANK", "RANK_NAME_TH", "RANK_ID", "--กรุณาเลือกยศ--");
                //view2
                DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                ddlCountry.SelectedValue = "Thailand";
                DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                ddlCountry2.SelectedValue = "Thailand";

                //view3
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
                DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
                //DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM TB_POSITION", "NAME", "ID", "--กรุณาเลือกตำแหน่ง--");
                //DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งบริหาร--");
                //DatabaseManager.BindDropDown(ddlPositionWork, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
                //DatabaseManager.BindDropDown(ddlAcademic, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
                //DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");
                //DatabaseManager.BindDropDown(ddlTpyePosition, "SELECT * FROM TB_POSITION_INSIG_GOVER", "PIG_NAME", "PIG_ID", "--กรุณาเลือกตำแหน่งประเภท--");

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
            ddlRace.SelectedIndex = 0;
            ddlNation.SelectedIndex = 0;
            ddlBlood.SelectedIndex = 0;
            ddlReligion.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlRank.SelectedIndex = 0;
            tbEmail.Text = "";
            tbPhone.Text = "";
            tbTelephone.Text = "";
            /*tbFatherName.Text = "";
            tbFatherLastName.Text = "";
            tbMotherName.Text = "";
            tbMotherLastName.Text = "";
            tbMotherOldLastName.Text = "";
            tbCoupleName.Text = "";
            tbCoupleLastName.Text = "";
            tbCoupleOldLastName.Text = "";*/
            tbHomeAdd.Text = "";
            tbSoi.Text = "";
            tbMoo.Text = "";
            tbRoad.Text = "";
            ddlProvince.SelectedIndex = 0;
            ddlAmphur.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            tbZipcode.Text = "";
            ddlCountry.SelectedIndex = 0;
            tbState.Text = "";
            tbHomeAdd2.Text = "";
            tbSoi2.Text = "";
            tbMoo2.Text = "";
            tbRoad2.Text = "";
            ddlProvince2.SelectedIndex = 0;
            ddlAmphur2.SelectedIndex = 0;
            ddlDistrict2.SelectedIndex = 0;
            tbZipcode2.Text = "";
            ddlCountry2.SelectedIndex = 0;
            tbState2.Text = "";
            ddlCampus.SelectedIndex = 0;
            ddlFaculty.SelectedIndex = 0;
            ddlDivision.SelectedIndex = 0;
            ddlWorkDivision.SelectedIndex = 0;
            ddlStaffType.SelectedIndex = 0;
            ddlBudget.SelectedIndex = 0;
            tbDateInwork.Text = "";
            tbSalary.Text = "";
            tbPositionSalary.Text = "";
            ddlTpyePosition.SelectedIndex = 0;
            ddlPosition.SelectedIndex = 0;
            ddlAdminPosition.SelectedIndex = 0;
            ddlPositionWork.SelectedIndex = 0;
            ddlAcademic.SelectedIndex = 0;
            tbSpecialWork.Text = "";
            ddlTeachISCED.SelectedIndex = 0;
            ddlPosiInsigGover.SelectedIndex = 0;
            ddlPosiInsigDegree.SelectedIndex = 0;
            ddlPosiInsigEMP.SelectedIndex = 0;
        }

        protected void SqlddlRank()
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
                        ddlRank.DataSource = dt;
                        ddlRank.DataValueField = "RANK_ID";
                        ddlRank.DataTextField = "RANK_NAME_TH_MIN";
                        ddlRank.DataBind();
                        sqlConn.Close();

                        ddlRank.Items.Insert(0, new ListItem("--กรุณาเลือกยศ--", "0"));
                    }
                }
            }
            catch { }
        }
        //View3
        protected void SqlddlTypePosition()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_GOVER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlTpyePosition.DataSource = dt;
                        ddlTpyePosition.DataValueField = "PIG_ID";
                        ddlTpyePosition.DataTextField = "PIG_NAME";
                        ddlTpyePosition.DataBind();
                        sqlConn.Close();

                        ddlTpyePosition.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งประเภท--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPosition()
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
                        ddlPosition.DataSource = dt;
                        ddlPosition.DataValueField = "ID";
                        ddlPosition.DataTextField = "NAME";
                        ddlPosition.DataBind();
                        sqlConn.Close();

                        ddlPosition.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่ง--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlAdminPosition()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_ADMIN_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAdminPosition.DataSource = dt;
                        ddlAdminPosition.DataValueField = "ADMIN_POSITION_ID";
                        ddlAdminPosition.DataTextField = "ADMIN_POSITION_NAME";
                        ddlAdminPosition.DataBind();
                        sqlConn.Close();

                        ddlAdminPosition.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งบริหาร--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPositionWork()
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
                        ddlPositionWork.DataSource = dt;
                        ddlPositionWork.DataValueField = "POSITION_WORK_ID";
                        ddlPositionWork.DataTextField = "POSITION_WORK_NAME";
                        ddlPositionWork.DataBind();
                        sqlConn.Close();

                        ddlPositionWork.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งในสายงาน--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPositionAcademic()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_ACADEMIC_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAcademic.DataSource = dt;
                        ddlAcademic.DataValueField = "ACAD_ID";
                        ddlAcademic.DataTextField = "ACAD_NAME";
                        ddlAcademic.DataBind();
                        sqlConn.Close();

                        ddlAcademic.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งทางวิชาการ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlTeachISCED()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_TEACH_ISCED";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlTeachISCED.DataSource = dt;
                        ddlTeachISCED.DataValueField = "TEACH_ISCED_ID";
                        ddlTeachISCED.DataTextField = "TEACH_ISCED_NAME_TH";
                        ddlTeachISCED.DataBind();
                        sqlConn.Close();

                        ddlTeachISCED.Items.Insert(0, new ListItem("--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPosiInsigGover()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_GOVER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPosiInsigGover.DataSource = dt;
                        ddlPosiInsigGover.DataValueField = "PIG_ID";
                        ddlPosiInsigGover.DataTextField = "PIG_NAME";
                        ddlPosiInsigGover.DataBind();
                        sqlConn.Close();

                        ddlPosiInsigGover.Items.Insert(0, new ListItem("--กรุณาเลือกระดับตำแหน่งประเภท--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPosiInsigDegree()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_DEGREE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPosiInsigDegree.DataSource = dt;
                        ddlPosiInsigDegree.DataValueField = "PID_ID";
                        ddlPosiInsigDegree.DataTextField = "PID_NAME";
                        ddlPosiInsigDegree.DataBind();
                        sqlConn.Close();

                        ddlPosiInsigDegree.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งระดับ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SqlddlPosiInsigEMP()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_EMP";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPosiInsigEMP.DataSource = dt;
                        ddlPosiInsigEMP.DataValueField = "PIE_ID";
                        ddlPosiInsigEMP.DataTextField = "PIE_NAME";
                        ddlPosiInsigEMP.DataBind();
                        sqlConn.Close();

                        ddlPosiInsigEMP.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งกลุ่มพนักงานราชการ--", "0"));
                    }
                }
            }
            catch { }
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
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV2Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
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
            PS_PERSON P0 = new PS_PERSON();
            //view1/3
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
            /*P0.PS_DAD_FN = tbFatherName.Text;
            P0.PS_DAD_LN = tbFatherLastName.Text;
            P0.PS_MOM_FN = tbMotherName.Text;
            P0.PS_MOM_LN = tbMotherLastName.Text;
            P0.PS_MOM_LN_OLD = tbMotherOldLastName.Text;
            P0.PS_LOV_FN = tbCoupleName.Text;
            P0.PS_LOV_LN = tbCoupleLastName.Text;
            P0.PS_LOV_LN_OLD = tbCoupleOldLastName.Text;*/
            //view2/3
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
            //view3/3
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
            P0.PS_POSITION_ID = ddlPosition.SelectedValue;
            P0.PS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_PIG_ID = Convert.ToInt32(ddlPosiInsigGover.SelectedValue);
            P0.PS_SW_ID = 6;
            P0.PS_RANK_ID = Convert.ToInt32(ddlRank.SelectedValue);
            P0.PS_POSS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_PIE_ID = Convert.ToInt32(ddlPosiInsigEMP.SelectedValue);
            P0.PS_PID_ID = Convert.ToInt32(ddlPosiInsigDegree.SelectedValue);

            if (P0.CheckUseCitizenID())
            {
                P0.INSERT_PS_PERSON();
                Util.SendMail(P0);
                MultiView1.ActiveViewIndex = 0;
                ClearText();
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenID.Text.Length < 13)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            if (P0.CheckUseCitizenID())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('สามารถใช้รหัสบัตรประชาชนนี้')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('รหัสประจำตัวประชาชน ที่กรอกนี้ มีอยู่ในระบบแล้ว !')", true);
            }
            
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 234)
            {
                tbState.Enabled = false;
            }
            else
            {
                tbState.Enabled = true;
            }
        }

        protected void ddlCountry2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry2.SelectedIndex != 234)
            {
                tbState2.Enabled = false;
            }
            else
            {
                tbState2.Enabled = true;
            }
        }
    }
}