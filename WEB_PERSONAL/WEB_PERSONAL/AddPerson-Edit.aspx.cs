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
    public partial class AddPerson_Edit : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindProvinceList();
                SQLCampus();
                SQLddlPositionType14();
                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";
                //view1
                DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
                DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");
                DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
                //view2
                DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                //view3
                DatabaseManager.BindDropDown(ddlDegree10, "SELECT * FROM TB_GRAD_LEV", "GRAD_LEV_NAME", "GRAD_LEV_ID", "--กรุณาเลือกระดับการศึกษา--");
                DatabaseManager.BindDropDown(ddlMonth10From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlMonth10To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlCountrySuccess10, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศที่จบ--");
                //view4
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
                DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
                DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งบริหาร--");
                DatabaseManager.BindDropDown(ddlPositionWork, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
                DatabaseManager.BindDropDown(ddlAcademic, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
                DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");
                //view5
                //view6
                DatabaseManager.BindDropDown(ddlMonth12From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlMonth12To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                //view7
                DatabaseManager.BindDropDown(ddlYear13, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                //view8

                Session["Study"] = new DataTable();
                ((DataTable)(Session["Study"])).Columns.Add("ระดับการศึกษา");
                ((DataTable)(Session["Study"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["Study"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["Study"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["Study"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["Study"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["Study"])).Columns.Add("วุฒิ");
                ((DataTable)(Session["Study"])).Columns.Add("สาขาวิชาเอก");
                ((DataTable)(Session["Study"])).Columns.Add("ประเทศที่จบ");
                GridViewStudy.DataSource = ((DataTable)(Session["Study"]));
                GridViewStudy.DataBind();
                Session["StudyShow"] = new DataTable();
                ((DataTable)(Session["StudyShow"])).Columns.Add("ระดับการศึกษา");
                ((DataTable)(Session["StudyShow"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("วุฒิ");
                ((DataTable)(Session["StudyShow"])).Columns.Add("สาขาวิชาเอก");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ประเทศที่จบ");
                GridViewStudyShow.DataSource = ((DataTable)(Session["StudyShow"]));
                GridViewStudyShow.DataBind();

                Session["ProLisence"] = new DataTable();
                ((DataTable)(Session["ProLisence"])).Columns.Add("ชื่อใบอนุญาต");
                ((DataTable)(Session["ProLisence"])).Columns.Add("หน่วยงาน");
                ((DataTable)(Session["ProLisence"])).Columns.Add("เลขที่ใบอนุญาต");
                ((DataTable)(Session["ProLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
                GridViewLicense.DataSource = ((DataTable)(Session["ProLisence"]));
                GridViewLicense.DataBind();

                Session["Trainning"] = new DataTable();
                ((DataTable)(Session["Trainning"])).Columns.Add("หลักสูตรฝึกอบรม");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
                GridViewTraining.DataSource = ((DataTable)(Session["Trainning"]));
                GridViewTraining.DataBind();
                Session["TrainningShow"] = new DataTable();
                ((DataTable)(Session["TrainningShow"])).Columns.Add("หลักสูตรฝึกอบรม");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
                GridViewTrainingShow.DataSource = ((DataTable)(Session["TrainningShow"]));
                GridViewTrainingShow.DataBind();

                Session["DDA"] = new DataTable();
                ((DataTable)(Session["DDA"])).Columns.Add("พ.ศ.");
                ((DataTable)(Session["DDA"])).Columns.Add("รายการ");
                ((DataTable)(Session["DDA"])).Columns.Add("เอกสารอ้างอิง");
                GridViewDDA.DataSource = ((DataTable)(Session["DDA"]));
                GridViewDDA.DataBind();

                Session["PAS"] = new DataTable();
                ((DataTable)(Session["PAS"])).Columns.Add("วัน เดือน ปี");
                ((DataTable)(Session["PAS"])).Columns.Add("ตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("เลขที่ตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("ตำแหน่งประเภท");
                ((DataTable)(Session["PAS"])).Columns.Add("ระดับ");
                ((DataTable)(Session["PAS"])).Columns.Add("เงินเดือน");
                ((DataTable)(Session["PAS"])).Columns.Add("เงินประจำตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("เอกสารอ้างอิง");
                GridViewPAS.DataSource = ((DataTable)(Session["PAS"]));
                GridViewPAS.DataBind();
                Session["PASShow"] = new DataTable();
                ((DataTable)(Session["PASShow"])).Columns.Add("วัน เดือน ปี");
                ((DataTable)(Session["PASShow"])).Columns.Add("ตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("เลขที่ตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("ตำแหน่งประเภท");
                ((DataTable)(Session["PASShow"])).Columns.Add("ระดับ");
                ((DataTable)(Session["PASShow"])).Columns.Add("เงินเดือน");
                ((DataTable)(Session["PASShow"])).Columns.Add("เงินประจำตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("เอกสารอ้างอิง");
                GridViewPASShow.DataSource = ((DataTable)(Session["PASShow"]));
                GridViewPASShow.DataBind();
            }
        }
        private void BindProvinceList() {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlAmphur_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e) {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC = new OracleCommand(setZIP, conn);
            string ZIPCODE = SC.ExecuteScalar().ToString();
            tbZipcode.Text = ZIPCODE;
        }

        protected void ddlProvince2_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlAmphur2_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlDistrict2_SelectedIndexChanged(object sender, EventArgs e) {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP2 = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC2 = new OracleCommand(setZIP2, conn);
            string ZIPCODE2 = SC2.ExecuteScalar().ToString();
            tbZipcode2.Text = ZIPCODE2;
        }

        protected void SQLCampus() {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
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
            } catch { }
        }

        protected void SQLddlPositionType14() {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * from TB_STAFF";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPositionType14.DataSource = dt;
                        ddlPositionType14.DataValueField = "ST_ID";
                        ddlPositionType14.DataTextField = "ST_NAME";
                        ddlPositionType14.DataBind();
                        sqlConn.Close();

                        ddlPositionType14.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งประเภท--", "0"));
                        ddlPositionDegree14.Items.Insert(0, new ListItem("--กรุณาเลือกระดับ--", "0"));
                    }
                }
            } catch { }
        }

        protected void ddlPositionType14_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(strConn)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * FROM TB_POSITION_GOVERNMENT_OFFICER where ST_ID = " + ddlPositionType14.SelectedValue + "UNION ALL select * FROM TB_POSITION_PERMANENT_EMP where ST_ID = " + ddlPositionType14.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPositionDegree14.DataSource = dt;
                        ddlPositionDegree14.DataValueField = "ID";
                        ddlPositionDegree14.DataTextField = "NAME";
                        ddlPositionDegree14.DataBind();
                        sqlConn.Close();
                        ddlPositionDegree14.Items.Insert(0, new ListItem("--กรุณาเลือกระดับ--", "0"));
                    }
                }
            } catch { }
        }

        protected void lbuV1Next_Click(object sender, EventArgs e) {
            /*  if(tbCitizenID.Text == "" || ddlTitle.SelectedIndex == 0 || tbNameTH.Text == ""|| tbLastNameTH.Text == "" || tbNameEN.Text == "" || tbLastNameEN.Text == "" || ddlGender.SelectedIndex == 0 || tbBirthday.Text == "" || ddlRace.SelectedIndex == 0 || ddlNation.SelectedIndex == 0 || ddlBlood.SelectedIndex == 0 || tbEmail.Text == "" || tbPhone.Text == "" || tbTelephone.Text == "" || ddlReligion.SelectedIndex == 0 || ddlStatus.SelectedIndex == 0 || tbFatherName.Text == "" || tbFatherLastName.Text == "" || tbMotherName.Text == "" || tbMotherLastName.Text == "" || tbMotherOldLastName.Text == "" || tbCoupleName.Text == "" || tbCoupleLastName.Text == "" || tbCoupleOldLastName.Text == "") {

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
            }
            */
            MultiView1.ActiveViewIndex = 1;
            //Util.SendMail();
            // PS_PERSON P0 = new PS_PERSON();
            //P0.PS_BIRTHDAY_DATE = Util.DatabaseToDate(tbBirthday.Text);
            //P0.PS_BIRTHDAY_LONG = Util.ToThaiWordBirthday(tbBirthday.Text);

            // P0.PS_INWORK_DATE = Util.DatabaseToDate(tbDateInwork.Text);
            //P0.PS_RETIRE_DATE = Util.DatabaseToDate(Util.BirthdayToRetireDate(tbBirthday.Text));
            //P0.PS_RETIRE_LONG = Util.ToThaiWordRetire(tbBirthday.Text);
            ////P0.INSERT_PS_PERSON();
            //tbHomeAdd.Text = P0.PS_BIRTHDAY_LONG;
            //tbSoi.Text = P0.PS_RETIRE_LONG;
        }

        protected void lbuV2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e) {
            /* if (tbHomeAdd.Text == "" || tbSoi.Text == "" || tbMoo.Text == "" || tbRoad.Text == "" || ddlProvince.SelectedIndex == 0 || ddlAmphur.SelectedIndex == 0 || ddlDistrict.SelectedIndex == 0 || tbZipcode.Text == "" || ddlCountry.SelectedIndex == 0 || tbState.Text == "" ||
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
                 if (tbState.Text == "" || tbState2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'รัฐ'</div>";
                 }
             }
             else {
                 MultiView1.ActiveViewIndex = 2;
                 notification.Attributes["class"] = "none";
                 notification.InnerHtml = "";
             }
             */
            MultiView1.ActiveViewIndex = 2;
        }
        protected void lbuAddressFetch_Click(object sender, EventArgs e) {
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

        protected void lbuV3Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV3Next_Click(object sender, EventArgs e) {
            /* if (ddlDegree10.SelectedIndex == 0 || tbUnivName10.Text == "" || ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0 || tbQualification10.Text == "" || tbMajor10.Text == "" || tbCountrySuccess10.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlDegree10.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ระดับการศึกษา'</div>";
                }
                if (tbUnivName10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'สถานศึกษา'</div>";
                }
                if (ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbQualification10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วุฒิ'</div>";
                }
                if (tbMajor10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'สาขาวิชาเอก'</div>";
                }
                if (ddlCountrySuccess10.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศที่จบ'</div>";
                }
            }
            else {
                MultiView1.ActiveViewIndex = 3;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            */
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV4Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuV4Next_Click(object sender, EventArgs e) {
            /*  if (ddlDegree10.SelectedIndex == 0 || ddlCampus.SelectedIndex == 0 || ddlFaculty.SelectedIndex == 0 || ddlDivision.SelectedIndex == 0 || ddlWorkDivision.SelectedIndex == 0 || ddlStaffType.SelectedIndex == 0 || ddlBudget.SelectedIndex == 0 || ddlAdminPosition.SelectedIndex == 0 || ddlPositionWork.SelectedIndex == 0 || ddlAcademic.SelectedIndex == 0 || tbDateInwork.Text == "" || tbSpecialWork.Text == "" || ddlTeachISCED.SelectedIndex == 0)
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
                      MultiView1.ActiveViewIndex = 4;
                      notification.Attributes["class"] = "none";
                      notification.InnerHtml = "";
                  }
              }
              */
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV5Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV5Next_Click(object sender, EventArgs e) {
            /*  if (tbLicenseName11.Text == "" || tbLicenseName11.Text == "" || tbDepartment11.Text == "" || tbLicenseNo11.Text == "" || tbUseDate11.Text == "")
              {
                  notification.Attributes["class"] = "alert alert_danger";
                  notification.InnerHtml = "";

                  notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                  if (tbLicenseName11.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'ชื่อใบอนุญาต'</div>";
                  }
                  if (tbDepartment11.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงาน'</div>";
                  }
                  if (tbLicenseNo11.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ใบอนุญาต'</div>";
                  }
                  if (tbUseDate11.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'วันที่มีผลบังคับใช้ (วัน เดือน ปี)'</div>";
                  }
                  else {
                      MultiView1.ActiveViewIndex = 5;
                      notification.Attributes["class"] = "none";
                      notification.InnerHtml = "";
                  }
              }
              */
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV6Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV6Next_Click(object sender, EventArgs e) {
            /*  if (tbCourse.Text == "" || ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0 || tbDepartment.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbCourse.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หลักสูตรฝึกอบรม'</div>";
                }
                if (ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbDepartment.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงานที่จัดฝึกอบรม'</div>";
                }
                else {
                    MultiView1.ActiveViewIndex = 6;
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }
            */
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbuV7Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV7Next_Click(object sender, EventArgs e) {
            /*  if (ddlYear13.SelectedIndex == 0 || tbName13.Text == "" || tbREF13.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlYear13.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'พ.ศ.'</div>";
                }
                if (tbName13.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'รายการ'</div>";
                }
                if (tbREF13.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                }
                else {
                    MultiView1.ActiveViewIndex = 7;
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }
            */
            MultiView1.ActiveViewIndex = 7;
        }

        protected void lbuV8Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbSubmit_Click(object sender, EventArgs e) {
            /*   if (tbDate14.Text == "" || tbPosition14.Text == "" || tbPositionNo14.Text == "" || ddlPositionType14.SelectedIndex == 0 || ddlPositionDegree14.SelectedIndex == 0 || tbSalary14.Text == "" || tbSalaryPosition14.Text == "" || tbRef14.Text == "")
             {
                 notification.Attributes["class"] = "alert alert_danger";
                 notification.InnerHtml = "";

                 notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";

                 if (tbDate14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'วัน เดือน ปี'</div>";
                 }
                 if (tbPosition14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'ตำแหน่ง'</div>";
                 }
                 if (tbPositionNo14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ตำแหน่ง'</div>";
                 }
                 if (ddlPositionType14.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งประเภท'</div>";
                 }
                 if (ddlPositionDegree14.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'ระดับ'</div>";
                 }
                 if (tbSalary14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'เงินเดือน'</div>";
                 }
                 if (tbSalaryPosition14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'เงินประจำตำแหน่ง'</div>";
                 }
                 if (tbRef14.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                 }
                 else {
                     notification.Attributes["class"] = "none";
                     notification.InnerHtml = "";
                 }
             } */

            //view1/8
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
            P0.INSERT_PS_PERSON();



            for (int i = 0; i < GridViewStudy.Rows.Count; ++i) {
                int id = 0;
                using (OracleConnection conn = Util.OC()) {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_STUDY (PS_CITIZEN_ID,PS_DEGREE_ID,PS_UNIV_NAME,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_QUALIFICATION,PS_MAJOR,PS_COUNTRY_ID) VALUES (:PS_CITIZEN_ID,:PS_DEGREE_ID,:PS_UNIV_NAME,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_QUALIFICATION,:PS_MAJOR,:PS_COUNTRY_ID)", conn)) {

                        try {
                            if (conn.State != ConnectionState.Open) {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_DEGREE_ID", GridViewStudy.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_UNIV_NAME", GridViewStudy.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", GridViewStudy.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", GridViewStudy.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_MONTH", GridViewStudy.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_YEAR", GridViewStudy.Rows[i].Cells[5].Text));
                            command.Parameters.Add(new OracleParameter("PS_QUALIFICATION", GridViewStudy.Rows[i].Cells[6].Text));
                            command.Parameters.Add(new OracleParameter("PS_MAJOR", GridViewStudy.Rows[i].Cells[7].Text));
                            command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", GridViewStudy.Rows[i].Cells[8].Text));
                            id = command.ExecuteNonQuery();
                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            command.Dispose();
                            conn.Close();
                        }
                    }
                }
            }

            for (int i = 0; i < GridViewLicense.Rows.Count; ++i) {
                int id = 0;
                using (OracleConnection conn = Util.OC()) {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_PROFESSIONAL_LICENSE (PS_CITIZEN_ID,PS_LICENSE_NAME,PS_DEPARTMENT,PS_LICENSE_NO,PS_USE_DATE) VALUES (:PS_CITIZEN_ID,:PS_LICENSE_NAME,:PS_DEPARTMENT,:PS_LICENSE_NO,:PS_USE_DATE)", conn)) {

                        try {
                            if (conn.State != ConnectionState.Open) {
                                conn.Open();
                            }
                            string[] ss2 = GridViewLicense.Rows[i].Cells[3].Text.Split(' ');
                            for (int j = 0; j < ss2.Length; ++j) {
                                ss2[j] = ss2[j].Trim();
                            }
                            DateTime DATE_11 = Util.ODT(GridViewLicense.Rows[i].Cells[3].Text);

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_LICENSE_NAME", GridViewLicense.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", GridViewLicense.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_LICENSE_NO", GridViewLicense.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_USE_DATE", DATE_11));
                            id = command.ExecuteNonQuery();

                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            command.Dispose();
                            conn.Close();
                        }
                    }
                }
            }

            for (int i = 0; i < GridViewTraining.Rows.Count; ++i) {
                int id = 0;
                using (OracleConnection conn = Util.OC()) {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_TRAINING (PS_CITIZEN_ID,PS_COURSE,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_DEPARTMENT) VALUES (:PS_CITIZEN_ID,:PS_COURSE,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_DEPARTMENT)", conn)) {

                        try {
                            if (conn.State != ConnectionState.Open) {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_COURSE", GridViewTraining.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", GridViewTraining.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", GridViewTraining.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_MONTH", GridViewTraining.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_YEAR", GridViewTraining.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", GridViewTraining.Rows[i].Cells[5].Text));
                            id = command.ExecuteNonQuery();
                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            command.Dispose();
                            conn.Close();
                        }
                    }
                }
            }

            for (int i = 0; i < GridViewDDA.Rows.Count; ++i) {
                int id = 0;
                using (OracleConnection conn = Util.OC()) {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_DISCIPLINARY_AND_AMNESTY (PS_CITIZEN_ID,PS_YEAR,PS_DAA_NAME,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_YEAR,:PS_DAA_NAME,:PS_REF)", conn)) {

                        try {
                            if (conn.State != ConnectionState.Open) {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_YEAR", GridViewDDA.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_DAA_NAME", GridViewDDA.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_REF", GridViewDDA.Rows[i].Cells[2].Text));
                            id = command.ExecuteNonQuery();
                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            command.Dispose();
                            conn.Close();
                        }
                    }
                }
            }

            for (int i = 0; i < GridViewPAS.Rows.Count; ++i) {
                int id = 0;
                using (OracleConnection conn = Util.OC()) {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_POSITION_AND_SALARY (PS_CITIZEN_ID,PS_DATE,PS_POSITION,PS_POSITION_NO,PS_POSITION_TYPE,PS_POSITION_DEGREE,PS_SALARY,PS_SALARY_POSITION,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_DATE,:PS_POSITION,:PS_POSITION_NO,:PS_POSITION_TYPE,:PS_POSITION_DEGREE,:PS_SALARY,:PS_SALARY_POSITION,:PS_REF)", conn)) {

                        try {
                            if (conn.State != ConnectionState.Open) {
                                conn.Open();
                            }
                            string[] ss5 = GridViewPAS.Rows[i].Cells[0].Text.Split(' ');
                            for (int j = 0; j < ss5.Length; ++j) {
                                ss5[j] = ss5[j].Trim();
                            }
                            DateTime DATE_11 = Util.ODT(GridViewPAS.Rows[i].Cells[0].Text);

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_DATE", DATE_11));
                            command.Parameters.Add(new OracleParameter("PS_POSITION", GridViewPAS.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_NO", GridViewPAS.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_TYPE", GridViewPAS.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_DEGREE", GridViewPAS.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_SALARY", GridViewPAS.Rows[i].Cells[5].Text));
                            command.Parameters.Add(new OracleParameter("PS_SALARY_POSITION", GridViewPAS.Rows[i].Cells[6].Text));
                            command.Parameters.Add(new OracleParameter("PS_REF", GridViewPAS.Rows[i].Cells[7].Text));
                            id = command.ExecuteNonQuery();

                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            command.Dispose();
                            conn.Close();
                        }
                    }
                }
            }

            //Util.SendMail(P0.PS_EMAIL, P0.PS_PASSWORD);
            Response.Redirect("Default.aspx");
            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong> เพิ่มข้อมูลบุคลากร เรียบร้อย</strong></div>";
        }

        protected void lbuV3Add_Click(object sender, EventArgs e) {
            DataRow dr = ((DataTable)(Session["Study"])).NewRow();
            DataRow drShow = ((DataTable)(Session["StudyShow"])).NewRow();
            dr[0] = ddlDegree10.SelectedValue;
            dr[1] = tbUnivName10.Text;
            dr[2] = ddlMonth10From.SelectedValue;
            dr[3] = ddlYear10From.SelectedValue;
            dr[4] = ddlMonth10To.SelectedValue;
            dr[5] = ddlYear10To.SelectedValue;
            dr[6] = tbQualification10.Text;
            dr[7] = tbMajor10.Text;
            dr[8] = ddlCountrySuccess10.SelectedValue;
            drShow[0] = ddlDegree10.SelectedItem.Text;
            drShow[1] = tbUnivName10.Text;
            drShow[2] = ddlMonth10From.SelectedItem.Text;
            drShow[3] = ddlYear10From.SelectedItem.Text;
            drShow[4] = ddlMonth10To.SelectedItem.Text;
            drShow[5] = ddlYear10To.SelectedItem.Text;
            drShow[6] = tbQualification10.Text;
            drShow[7] = tbMajor10.Text;
            drShow[8] = ddlCountrySuccess10.SelectedItem.Text;
            if (ddlDegree10.SelectedIndex == 0 || tbUnivName10.Text == "" || ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0 || tbQualification10.Text == "" || tbMajor10.Text == "" || ddlCountrySuccess10.SelectedIndex == 0) {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlDegree10.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ระดับการศึกษา'</div>";
                }
                if (tbUnivName10.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'สถานศึกษา'</div>";
                }
                if (ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbQualification10.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'วุฒิ'</div>";
                }
                if (tbMajor10.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'สาขาวิชาเอก'</div>";
                }
                if (ddlCountrySuccess10.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศที่จบ'</div>";
                }
            } else {
                ((DataTable)(Session["Study"])).Rows.Add(dr);
                ((DataTable)(Session["StudyShow"])).Rows.Add(drShow);
                GridViewStudy.DataSource = ((DataTable)(Session["Study"]));
                GridViewStudy.DataBind();
                GridViewStudyShow.DataSource = ((DataTable)(Session["StudyShow"]));
                GridViewStudyShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษาเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV5Add_Click(object sender, EventArgs e) {
            DataRow dr = ((DataTable)(Session["ProLisence"])).NewRow();
            dr[0] = tbLicenseName11.Text;
            dr[1] = tbDepartment11.Text;
            dr[2] = tbLicenseNo11.Text;
            dr[3] = tbUseDate11.Text;
            if (tbLicenseName11.Text == "" || tbLicenseName11.Text == "" || tbDepartment11.Text == "" || tbLicenseNo11.Text == "" || tbUseDate11.Text == "") {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbLicenseName11.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อใบอนุญาต'</div>";
                }
                if (tbDepartment11.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงาน'</div>";
                }
                if (tbLicenseNo11.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ใบอนุญาต'</div>";
                }
                if (tbUseDate11.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันที่มีผลบังคับใช้ (วัน เดือน ปี)'</div>";
                }
            } else {
                ((DataTable)(Session["ProLisence"])).Rows.Add(dr);
                GridViewLicense.DataSource = ((DataTable)(Session["ProLisence"]));
                GridViewLicense.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบประกอบวิชาชีพเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV6Add_Click(object sender, EventArgs e) {
            DataRow dr = ((DataTable)(Session["Trainning"])).NewRow();
            DataRow drShow = ((DataTable)(Session["TrainningShow"])).NewRow();
            dr[0] = tbCourse.Text;
            dr[1] = ddlMonth12From.SelectedValue;
            dr[2] = ddlYear12From.SelectedValue;
            dr[3] = ddlMonth12To.SelectedValue;
            dr[4] = ddlYear12To.SelectedValue;
            dr[5] = tbDepartment.Text;
            drShow[0] = tbCourse.Text;
            drShow[1] = ddlMonth12From.SelectedItem.Text;
            drShow[2] = ddlYear12From.SelectedItem.Text;
            drShow[3] = ddlMonth12To.SelectedItem.Text;
            drShow[4] = ddlYear12To.SelectedItem.Text;
            drShow[5] = tbDepartment.Text;
            if (tbCourse.Text == "" || ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0 || tbDepartment.Text == "") {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbCourse.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'หลักสูตรฝึกอบรม'</div>";
                }
                if (ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbDepartment.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงานที่จัดฝึกอบรม'</div>";
                }
            } else {
                ((DataTable)(Session["Trainning"])).Rows.Add(dr);
                GridViewTraining.DataSource = ((DataTable)(Session["Trainning"]));
                GridViewTraining.DataBind();
                ((DataTable)(Session["TrainningShow"])).Rows.Add(drShow);
                GridViewTrainingShow.DataSource = ((DataTable)(Session["TrainningShow"]));
                GridViewTrainingShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการฝึกอบรมเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV7Add_Click(object sender, EventArgs e) {
            DataRow dr = ((DataTable)(Session["DDA"])).NewRow();
            dr[0] = ddlYear13.SelectedValue;
            dr[1] = tbName13.Text;
            dr[2] = tbREF13.Text;
            if (ddlYear13.SelectedIndex == 0 || tbName13.Text == "" || tbREF13.Text == "") {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlYear13.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'พ.ศ.'</div>";
                }
                if (tbName13.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'รายการ'</div>";
                }
                if (tbREF13.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                }
            } else {
                ((DataTable)(Session["DDA"])).Rows.Add(dr);
                GridViewDDA.DataSource = ((DataTable)(Session["DDA"]));
                GridViewDDA.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรมเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV8Add_Click(object sender, EventArgs e) {
            DataRow dr = ((DataTable)(Session["PAS"])).NewRow();
            DataRow drShow = ((DataTable)(Session["PASShow"])).NewRow();
            dr[0] = tbDate14.Text;
            dr[1] = tbPosition14.Text;
            dr[2] = tbPositionNo14.Text;
            dr[3] = ddlPositionType14.SelectedValue;
            dr[4] = ddlPositionDegree14.SelectedValue;
            dr[5] = tbSalary14.Text;
            dr[6] = tbSalaryPosition14.Text;
            dr[7] = tbRef14.Text;
            drShow[0] = tbDate14.Text;
            drShow[1] = tbPosition14.Text;
            drShow[2] = tbPositionNo14.Text;
            drShow[3] = ddlPositionType14.SelectedItem.Text;
            drShow[4] = ddlPositionDegree14.SelectedItem.Text;
            drShow[5] = tbSalary14.Text;
            drShow[6] = tbSalaryPosition14.Text;
            drShow[7] = tbRef14.Text;
            if (tbDate14.Text == "" || tbPosition14.Text == "" || tbPositionNo14.Text == "" || ddlPositionType14.SelectedIndex == 0 || ddlPositionDegree14.SelectedIndex == 0 || tbSalary14.Text == "" || tbSalaryPosition14.Text == "" || tbRef14.Text == "") {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";

                if (tbDate14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'วัน เดือน ปี'</div>";
                }
                if (tbPosition14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'ตำแหน่ง'</div>";
                }
                if (tbPositionNo14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ตำแหน่ง'</div>";
                }
                if (ddlPositionType14.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งประเภท'</div>";
                }
                if (ddlPositionDegree14.SelectedIndex == 0) {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ระดับ'</div>";
                }
                if (tbSalary14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เงินเดือน'</div>";
                }
                if (tbSalaryPosition14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เงินประจำตำแหน่ง'</div>";
                }
                if (tbRef14.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                }
            } else {
                ((DataTable)(Session["PAS"])).Rows.Add(dr);
                GridViewPAS.DataSource = ((DataTable)(Session["PAS"]));
                GridViewPAS.DataBind();
                ((DataTable)(Session["PASShow"])).Rows.Add(drShow);
                GridViewPASShow.DataSource = ((DataTable)(Session["PASShow"]));
                GridViewPASShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลตำแหน่งและเงินเดือนเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }
    }
}