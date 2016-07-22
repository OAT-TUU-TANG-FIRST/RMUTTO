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

        private string p;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (hfpsID.Value != "") {
                p = hfpsID.Value;
            } else {
                divTab.Visible = false;
            }

 
            if(p == null) {
                selectTab("0");
                if (CreateSelectPersonPageLoad(this, pPerson, "AddPerson-Edit.aspx")) {
                    return;
                }
            }



            if(!IsPostBack) {
                BindDropDown();

            }



            /*if (tab == "1") {
                BindView1();
            } else if(tab == "2") {
                
                BindView2();
            } else if(tab == "3") {
                
                BindView3();

            } else if(tab == "4") {
                
            }*/

            
        }

        private void BindDropDown() {
            //view1
            DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
            DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
            DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
            //ddlRace.SelectedValue = "ไทย";
            DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
            //ddlNation.SelectedValue = "ไทย";
            DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
            DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");
            DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
            //view2
            BindProvinceList();
            DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");
            DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");
            //view3
            SQLCampus();
            DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
            DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
            DatabaseManager.BindDropDown(ddlTab10StatusWork, "SELECT * FROM TB_STATUS_WORK", "SW_NAME", "SW_ID", "--กรุณาเลือกสถาะการทำงาน--");

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

            DatabaseManager.BindDropDown(ddlTab4AdminPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 1", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทบริหาร--");
            DatabaseManager.BindDropDown(ddlTab4DirectPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 2", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทอำนวยการ--");
            DatabaseManager.BindDropDown(ddlTab4AcadPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 3", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทวิชาการ--");
            DatabaseManager.BindDropDown(ddlTab4GeneralPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 4", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภททั่วไป--");
        }

        private void selectTab(string _tab) {
            divState1.Visible = false;
            divTab1.Visible = false;
            divTab2.Visible = false;
            divTab3.Visible = false;
            divTab4.Visible = false;
            lbuTab1.CssClass = "ps-tab-unselected";
            lbuTab2.CssClass = "ps-tab-unselected";
            lbuTab3.CssClass = "ps-tab-unselected";
            lbuTab4.CssClass = "ps-tab-unselected";
            if(_tab == "0") {
                divState1.Visible = true;
            } else if (_tab == "1") {
                divTab1.Visible = true;
                lbuTab1.CssClass = "ps-tab-selected";
            } else if (_tab == "2") {
                divTab2.Visible = true;
                lbuTab2.CssClass = "ps-tab-selected";
            } else if (_tab == "3") {
                divTab3.Visible = true;
                lbuTab3.CssClass = "ps-tab-selected";
            } else if (_tab == "4") {
                divTab4.Visible = true;
                lbuTab4.CssClass = "ps-tab-selected";
            }
        }

        protected void lbuTab1_Click(object sender, EventArgs e) {
            selectTab("1");
        }
        protected void lbuTab2_Click(object sender, EventArgs e) {
            selectTab("2");
        }
        protected void lbuTab3_Click(object sender, EventArgs e) {
            selectTab("3");
        } 
        protected void lbuTab4_Click(object sender, EventArgs e) {
            selectTab("4");
        }
        protected void lbuTab1Save_Click(object sender, EventArgs e) {

            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CITIZEN_ID = p;
            P0.PS_RANK_ID = Convert.ToInt32(ddlRank.SelectedValue);
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

            P0.UPDATE_PS_PERSON_TAB1();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลพื้นฐานสำเร็จ')", true);
        }
        protected void lbuTab2Save_Click(object sender, EventArgs e) {

            PS_PERSON P0 = new PS_PERSON();
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
            P0.PS_CITIZEN_ID = p;

            P0.UPDATE_PS_PERSON_TAB2();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลที่อยู่สำเร็จ')", true);
        }
        protected void lbuTab3Save_Click(object sender, EventArgs e) {

           /* P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
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
            P0.PS_RANK_ID = Convert.ToInt32(ddlRank.SelectedValue);
            P0.PS_POSS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_PIE_ID = Convert.ToInt32(ddlPosiInsigEMP.SelectedValue);
            P0.PS_PID_ID = Convert.ToInt32(ddlPosiInsigDegree.SelectedValue);*/

            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
            P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
            P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            P0.PS_WORK_DIVISION_ID = Convert.ToInt32(ddlWorkDivision.SelectedValue); ;
            P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
            P0.PS_BUDGET_ID = Convert.ToInt32(ddlBudget.SelectedValue);
            P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
            P0.PS_RETIRE_DATE = Util.ODT(Util.BirthdayToRetireDate(tbBirthday.Text));
            P0.PS_RETIRE_LONG = Util.ToThaiWordRetire(tbBirthday.Text);
            P0.PS_SPECIAL_WORK = tbSpecialWork.Text;
            P0.PS_PASSWORD = Util.RandomPassword(8);
            P0.PS_CITIZEN_ID = p;

            P0.UPDATE_PS_PERSON_TAB3();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลการทำงานสำเร็จ')", true);
        }
        protected void lbuTab4Save_Click(object sender, EventArgs e) {
            //---
        }

        private void BindView1() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID,PS_TITLE_ID,PS_FN_TH,PS_LN_TH,PS_FN_EN,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_RELIGION_ID,PS_STATUS_ID,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            //view1
                            int i = 0;
                            tbCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlTitle.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbNameTH.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastNameTH.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbNameEN.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastNameEN.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlGender.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbBirthday.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString()); ++i;
                            ddlRace.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlNation.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            ddlBlood.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlReligion.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlStatus.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbEmail.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbPhone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbTelephone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                        }
                    }
                }
            }
        }
        private void BindView2() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_HOMEADD,PS_SOI,PS_MOO,PS_STREET,PS_PROVINCE_ID,PS_AMPHUR_ID,PS_DISTRICT,PS_ZIPCODE,PS_COUNTRY_ID,PS_STATE,PS_HOMEADD_NOW,PS_SOI_NOW,PS_MOO_NOW,PS_STREET_NOW,PS_PROVINCE_ID_NOW,PS_AMPHUR_ID_NOW,PS_DISTRICT_ID_NOW,PS_ZIPCODE_NOW,PS_COUNTRY_ID_NOW,PS_STATE_NOW FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            //view2
                            int i = 0;
                            tbHomeAdd.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSoi.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMoo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbRoad.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlProvince.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;

                            ddlAmphur.Items.Clear();
                            string s1 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlAmphur, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ--");
                            ddlAmphur.SelectedValue = s1;

                            ddlDistrict.Items.Clear();
                            string s2 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict.SelectedValue = s2;

                            tbZipcode.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlCountry.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbState.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbHomeAdd2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSoi2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMoo2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbRoad2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlProvince2.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;

                            ddlAmphur2.Items.Clear();
                            string s3 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlAmphur2, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince2.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ--");
                            ddlAmphur2.SelectedValue = s3;

                            ddlDistrict2.Items.Clear();
                            string s4 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlDistrict2, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur2.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict2.SelectedValue = s4;

                            tbZipcode2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlCountry2.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbState2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                        }
                    }
                }
            }
        }

        private void BindView3() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_ADMIN_POS_ID,PS_WORK_POS_ID,PS_ACAD_POS_ID,PS_INWORK_DATE,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID,PS_POSITION_ID,PS_SALARY,PS_PIG_ID,PS_RANK_ID,PS_POSS_SALARY,PS_PIE_ID,PS_PID_ID,PS_SW_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            //view3
                            int i = 0;
                            ddlCampus.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;

                            ddlFaculty.Items.Clear();
                            string f1 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY WHERE CAMPUS_ID = " + ddlCampus.SelectedValue, "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกสำนัก / สถาบัน / คณะ--");
                            ddlFaculty.SelectedValue = f1;

                            ddlDivision.Items.Clear();
                            string f2 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlDivision, "SELECT * FROM TB_DIVISION WHERE FACULTY_ID = " + ddlFaculty.SelectedValue, "DIVISION_NAME", "DIVISION_ID", "--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--");
                            ddlDivision.SelectedValue = f2;

                            ddlWorkDivision.Items.Clear();
                            string f3 = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            DatabaseManager.BindDropDown(ddlWorkDivision, "SELECT * FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, "WORK_NAME", "WORK_ID", "--กรุณาเลือกงาน / ฝ่าย--");
                            ddlWorkDivision.SelectedValue = f3;

                            ddlStaffType.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlBudget.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlAdminPosition.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlPositionWork.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlAcademic.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbDateInwork.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString()); ++i;
                            tbSpecialWork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetInt32(i).ToString(); ++i;
                            ddlPosition.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbSalary.Text = reader.IsDBNull(i) ? "" : reader.GetInt32(i).ToString(); ++i;
                            ddlPosiInsigGover.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlRank.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbPositionSalary.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlPosiInsigEMP.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlPosiInsigDegree.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlTab10StatusWork.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                        }
                    }
                }
            }
        }

        public bool CreateSelectPersonPageLoad(Page page, Panel pPerson, string pageURL) {

   
            string ps = null;
   
            if (page.Request.QueryString["ps"] != null) {
                ps = page.Request.QueryString["ps"];
            }

            if (ps != null) {
                CreateSelectPersonPanel(page, pPerson, pageURL, ps);
                return true;
            }
            if (p == null) {
                CreateSelectPersonPanel(page, pPerson, pageURL);
                return true;
            }
            return false;
        }
        public void CreateSelectPersonPanel(Page page, Panel panel, string pageURL) {
            CreateSelectPersonPanel(page, panel, pageURL, null);
        }
        public void CreateSelectPersonPanel(Page page, Panel panel, string pageURL, string ps) {
            Panel pp = new Panel();
            panel.Controls.Add(pp);

            {
                Panel ppp = new Panel();
                ppp.CssClass = "ps-div-title-red";
                pp.Controls.Add(ppp);

                Image img = new Image();
                img.Attributes["src"] = "Image/Small/Search.png";
                img.CssClass = "icon_left";
                ppp.Controls.Add(img);

                Label lb = new Label();
                lb.Text = "ค้นหารายชื่อพนักงาน";
                ppp.Controls.Add(lb);
            }
            {
                Panel ppp = new Panel();
                ppp.Style.Add("text-align", "center");
                ppp.DefaultButton = "pppSearch";
                pp.Controls.Add(ppp);

                Label lb = new Label();
                lb.Text = "รหัสบัตรประชาชน : ";
                ppp.Controls.Add(lb);

                TextBox tbSearchCitizenID = new TextBox();
                tbSearchCitizenID.Style.Add("margin-right", "5px");
                tbSearchCitizenID.CssClass = "ps-textbox";
                tbSearchCitizenID.MaxLength = 13;
                ppp.Controls.Add(tbSearchCitizenID);

                LinkButton lbuSearchPerson = new LinkButton();
                lbuSearchPerson.ID = "pppSearch";
                lbuSearchPerson.Style.Add("margin-right", "5px");
                lbuSearchPerson.CssClass = "ps-button";
                lbuSearchPerson.Click += (ee, eee) => {
                    page.Response.Redirect(pageURL + "?ps=" + tbSearchCitizenID.Text);
                };
                lbuSearchPerson.Text = "<img src='Image/Small/search.png' class='icon_left'/>ค้นหา";
                ppp.Controls.Add(lbuSearchPerson);

                LinkButton lbuRefresh = new LinkButton();
                lbuRefresh.CssClass = "ps-button";
                lbuRefresh.Click += (ee, eee) => {
                    page.Response.Redirect(pageURL);
                };
                lbuRefresh.Text = "<img src='Image/Small/refresh.png' class='icon_left'/>รีเฟรช";
                ppp.Controls.Add(lbuRefresh);

                Panel pSeparator = new Panel();
                pSeparator.CssClass = "ps-separator";
                ppp.Controls.Add(pSeparator);

            }


            Table tbPerson = new Table();
            tbPerson.CssClass = "ps-table-1";
            tbPerson.Style.Add("margin", "0 auto");
            pp.Controls.Add(tbPerson);
            {
                TableHeaderRow row = new TableHeaderRow();
                tbPerson.Rows.Add(row);
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เลขประจำตัวประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เลือก";
                    row.Cells.Add(cell);
                }
            }

            string select = "SELECT PS_ID, PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON";
            if (ps != null) {
                select += " WHERE PS_CITIZEN_ID = '" + ps + "'";
            }


            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(select, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            string psID = reader.GetString(1);

                            TableRow row = new TableRow();
                            tbPerson.Rows.Add(row);

                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.GetInt32(0).ToString();
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.GetString(1);
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.GetString(2);
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                LinkButton lbu = new LinkButton();
                                lbu.CssClass = "ps-button";
                                lbu.Text = "เลือก";
                                lbu.Click += (e1, e2) => {
                                    p = psID;
                                    BindDropDown();
                                    BindView1();
                                    BindView2();
                                    BindView3();
                                    //page.Response.Redirect(pageURL + "?p=" + psID + "&state=2");
                                    hfpsID.Value = p;
                                    selectTab("1");
                                    divTab.Visible = true;
                                };
                                cell.Controls.Add(lbu);
                                row.Cells.Add(cell);
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
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlRank, "SELECT * FROM TB_RANK", "RANK_NAME_TH_MIN", "RANK_ID", "--กรุณาเลือกยศ--");
        }
        //View3
        protected void SqlddlTypePosition()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlTpyePosition, "SELECT * FROM TB_POSITION_INSIG_GOVER", "PIG_NAME", "PIG_ID", "--กรุณาเลือกตำแหน่งประเภท--");
        }

        protected void SqlddlPosition()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM TB_POSITION", "NAME", "ID", "--กรุณาเลือกตำแหน่ง--");
        }

        protected void SqlddlAdminPosition()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งบริหาร--");
        }

        protected void SqlddlPositionWork()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlPositionWork, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
        }

        protected void SqlddlPositionAcademic()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlAcademic, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
        }

        protected void SqlddlTeachISCED()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID_OLD", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");
        }

        protected void SqlddlPosiInsigGover()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlPosiInsigGover, "SELECT * FROM TB_POSITION_INSIG_GOVER", "PIG_NAME", "PIG_ID", "--กรุณาเลือกระดับตำแหน่งประเภท--");
        }

        protected void SqlddlPosiInsigDegree()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlPosiInsigDegree, "SELECT * FROM TB_POSITION_INSIG_DEGREE", "PID_NAME", "PID_ID", "--กรุณาเลือกตำแหน่งระดับ--");
        }

        protected void SqlddlPosiInsigEMP()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlPosiInsigEMP, "SELECT * FROM TB_POSITION_INSIG_EMP", "PIE_NAME", "PIE_ID", "--กรุณาเลือกตำแหน่งกลุ่มพนักงานราชการ--");
        }

        private void BindProvinceList()
        {
            /*try
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
            catch { }*/
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            tbZipcode.Text = "";

            DatabaseManager.BindDropDown(ddlProvince2, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            tbZipcode2.Text = "";

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

        //deleetetetete
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

       
        //delete
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
            P0.PS_RANK_ID = Convert.ToInt32(ddlRank.SelectedValue);
            P0.PS_POSS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_PIE_ID = Convert.ToInt32(ddlPosiInsigEMP.SelectedValue);
            P0.PS_PID_ID = Convert.ToInt32(ddlPosiInsigDegree.SelectedValue);

            P0.UPDATE_PS_PERSON();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูล บุคลากรเรียบร้อย')", true);
            //MultiView1.ActiveViewIndex = 0;
        }

        
        private void BindAAA()
        {
            /*if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (txtSearchPersonID.Text.Length < 13)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }*/

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                //using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID,PS_TITLE_ID,PS_FN_TH,PS_FN_EN,PS_LN_TH,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_RELIGION_ID,PS_STATUS_ID,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK,PS_DAD_FN,PS_DAD_LN,PS_MOM_FN,PS_MOM_LN,PS_MOM_LN_OLD,PS_LOV_FN,PS_LOV_LN,PS_LOV_LN_OLD,PS_HOMEADD,PS_SOI,PS_MOO,PS_STREET,PS_PROVINCE_ID,PS_AMPHUR_ID,PS_DISTRICT,PS_ZIPCODE,PS_COUNTRY_ID,PS_STATE,PS_HOMEADD_NOW,PS_SOI_NOW,PS_MOO_NOW,PS_STREET_NOW,PS_PROVINCE_ID_NOW,PS_AMPHUR_ID_NOW,PS_DISTRICT_ID_NOW,PS_ZIPCODE_NOW,PS_COUNTRY_ID_NOW,PS_STATE_NOW,PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_ADMIN_POS_ID,PS_WORK_POS_ID,PS_ACAD_POS_ID,PS_INWORK_DATE,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID,PS_POSITION_ID,PS_SALARY,PS_PIG_ID,PS_SW_ID,PS_RANK_ID,PS_POSS_SALARY,PS_PIE_ID,PS_PID_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchPersonID.Text + "'", con))
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID,PS_TITLE_ID,PS_FN_TH,PS_FN_EN,PS_LN_TH,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_RELIGION_ID,PS_STATUS_ID,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK,PS_HOMEADD,PS_SOI,PS_MOO,PS_STREET,PS_PROVINCE_ID,PS_AMPHUR_ID,PS_DISTRICT,PS_ZIPCODE,PS_COUNTRY_ID,PS_STATE,PS_HOMEADD_NOW,PS_SOI_NOW,PS_MOO_NOW,PS_STREET_NOW,PS_PROVINCE_ID_NOW,PS_AMPHUR_ID_NOW,PS_DISTRICT_ID_NOW,PS_ZIPCODE_NOW,PS_COUNTRY_ID_NOW,PS_STATE_NOW,PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_ADMIN_POS_ID,PS_WORK_POS_ID,PS_ACAD_POS_ID,PS_INWORK_DATE,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID,PS_POSITION_ID,PS_SALARY,PS_PIG_ID,PS_RANK_ID,PS_POSS_SALARY,PS_PIE_ID,PS_PID_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        { 

                            //view1
                            tbCitizenID.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            ddlTitle.SelectedValue = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                            tbNameTH.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            tbLastNameTH.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            tbNameEN.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            tbLastNameEN.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            ddlGender.SelectedValue = reader.IsDBNull(6) ? "0" : reader.GetInt32(6).ToString();
                            tbBirthday.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(7) ? "" : reader.GetValue(7).ToString());
                            ddlRace.SelectedValue = reader.IsDBNull(8) ? "0" : reader.GetInt32(8).ToString();
                            ddlNation.SelectedValue = reader.IsDBNull(9) ? "" : reader.GetString(9).ToString();
                            ddlBlood.SelectedValue = reader.IsDBNull(10) ? "0" : reader.GetInt32(10).ToString();
                            ddlReligion.SelectedValue = reader.IsDBNull(11) ? "0" : reader.GetInt32(11).ToString();
                            ddlStatus.SelectedValue = reader.IsDBNull(12) ? "0" : reader.GetInt32(12).ToString();
                            tbEmail.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            tbPhone.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                            tbTelephone.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                            //view2
                            tbHomeAdd.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                            tbSoi.Text = reader.IsDBNull(17) ? "" : reader.GetString(17);
                            tbMoo.Text = reader.IsDBNull(18) ? "" : reader.GetString(18);
                            tbRoad.Text = reader.IsDBNull(19) ? "" : reader.GetString(19);
                            ddlProvince.SelectedValue = reader.IsDBNull(20) ? "0" : reader.GetInt32(20).ToString();

                            ddlAmphur.Items.Clear();
                            string s1 = reader.IsDBNull(21) ? "0" : reader.GetInt32(21).ToString();
                            DatabaseManager.BindDropDown(ddlAmphur, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ--");
                            ddlAmphur.SelectedValue = s1;

                            ddlDistrict.Items.Clear();
                            string s2 = reader.IsDBNull(22) ? "0" : reader.GetInt32(22).ToString();
                            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict.SelectedValue = s2;

                            tbZipcode.Text = reader.IsDBNull(23) ? "" : reader.GetString(23);
                            ddlCountry.SelectedValue = reader.IsDBNull(24) ? "0" : reader.GetInt32(24).ToString();
                            tbState.Text = reader.IsDBNull(25) ? "" : reader.GetString(25);
                            tbHomeAdd2.Text = reader.IsDBNull(26) ? "" : reader.GetString(26);
                            tbSoi2.Text = reader.IsDBNull(27) ? "" : reader.GetString(27);
                            tbMoo2.Text = reader.IsDBNull(28) ? "" : reader.GetString(28);
                            tbRoad2.Text = reader.IsDBNull(29) ? "" : reader.GetString(29);
                            ddlProvince2.SelectedValue = reader.IsDBNull(30) ? "0" : reader.GetInt32(30).ToString();

                            ddlAmphur2.Items.Clear();
                            string s3 = reader.IsDBNull(31) ? "0" : reader.GetInt32(31).ToString();
                            DatabaseManager.BindDropDown(ddlAmphur2, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince2.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ--");
                            ddlAmphur2.SelectedValue = s3;

                            ddlDistrict2.Items.Clear();
                            string s4 = reader.IsDBNull(32) ? "0" : reader.GetInt32(32).ToString();
                            DatabaseManager.BindDropDown(ddlDistrict2, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur2.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict2.SelectedValue = s4;

                            tbZipcode2.Text = reader.IsDBNull(33) ? "" : reader.GetString(33);
                            ddlCountry2.SelectedValue = reader.IsDBNull(34) ? "0" : reader.GetInt32(34).ToString();
                            tbState2.Text = reader.IsDBNull(35) ? "" : reader.GetString(35);

                            //view4
                            ddlCampus.SelectedValue = reader.IsDBNull(36) ? "0" : reader.GetInt32(36).ToString();

                            ddlFaculty.Items.Clear();
                            string f1 = reader.IsDBNull(37) ? "0" : reader.GetInt32(37).ToString();
                            DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY WHERE CAMPUS_ID = " + ddlCampus.SelectedValue, "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกสำนัก / สถาบัน / คณะ--");
                            ddlFaculty.SelectedValue = f1;

                            ddlDivision.Items.Clear();
                            string f2 = reader.IsDBNull(38) ? "0" : reader.GetInt32(38).ToString();
                            DatabaseManager.BindDropDown(ddlDivision, "SELECT * FROM TB_DIVISION WHERE FACULTY_ID = " + ddlFaculty.SelectedValue, "DIVISION_NAME", "DIVISION_ID", "--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--");
                            ddlDivision.SelectedValue = f2;

                            ddlWorkDivision.Items.Clear();
                            string f3 = reader.IsDBNull(39) ? "0" : reader.GetInt32(39).ToString();
                            DatabaseManager.BindDropDown(ddlWorkDivision, "SELECT * FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, "WORK_NAME", "WORK_ID", "--กรุณาเลือกงาน / ฝ่าย--");
                            ddlWorkDivision.SelectedValue = f3;

                            ddlStaffType.SelectedValue = reader.IsDBNull(40) ? "0" : reader.GetInt32(40).ToString();
                            ddlBudget.SelectedValue = reader.IsDBNull(41) ? "0" : reader.GetInt32(41).ToString();
                            ddlAdminPosition.SelectedValue = reader.IsDBNull(42) ? "0" : reader.GetInt32(42).ToString();
                            ddlPositionWork.SelectedValue = reader.IsDBNull(43) ? "0" : reader.GetInt32(43).ToString();
                            ddlAcademic.SelectedValue = reader.IsDBNull(44) ? "0" : reader.GetInt32(44).ToString();
                            tbDateInwork.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(45) ? "" : reader.GetValue(45).ToString());
                            tbSpecialWork.Text = reader.IsDBNull(46) ? "" : reader.GetString(46);
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(47) ? "" : reader.GetString(47).ToString();
                            ddlPosition.SelectedValue = reader.IsDBNull(48) ? "" : reader.GetString(48).ToString();
                            tbSalary.Text = reader.IsDBNull(49) ? "" : reader.GetInt32(49).ToString();
                            ddlPosiInsigGover.SelectedValue = reader.IsDBNull(50) ? "0" : reader.GetInt32(50).ToString();
                            ddlRank.SelectedValue = reader.IsDBNull(51) ? "0" : reader.GetInt32(51).ToString();
                            tbPositionSalary.Text = reader.IsDBNull(52) ? "0" : reader.GetInt32(52).ToString();
                            ddlPosiInsigEMP.SelectedValue = reader.IsDBNull(53) ? "0" : reader.GetInt32(53).ToString();
                            ddlPosiInsigDegree.SelectedValue = reader.IsDBNull(54) ? "0" : reader.GetInt32(54).ToString();

                        }
                    }
                }
            }
        }

        /*protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearText();
        }*/

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

