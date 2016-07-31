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
            
        }

        private void BindDropDown() {
            //tab1
            DatabaseManager.BindDropDown(ddlRank, "SELECT * FROM TB_RANK", "RANK_NAME_TH_MIN", "RANK_ID", "--กรุณาเลือกยศ--");
            DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
            DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
            DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
            DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
            DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
            DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
            DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");

            //tab2
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            tbZipcode.Text = "";
            DatabaseManager.BindDropDown(ddlProvince2, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            tbZipcode2.Text = "";
            DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");
            DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");

            //tab3
            SQLCampus();
            DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
            DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
            DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID_OLD", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");
            DatabaseManager.BindDropDown(ddlTab10StatusWork, "SELECT * FROM TB_STATUS_WORK", "SW_NAME", "SW_ID", "--กรุณาเลือกสถานะบุคลากร--");

            //tab4
            DatabaseManager.BindDropDown(ddlTab4PositionWorkRow1, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
            DatabaseManager.BindDropDown(ddlTab4AdminPositionRow1, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งทางบริหาร--");
            DatabaseManager.BindDropDown(ddlTab4AcadPositionRow1, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
            DatabaseManager.BindDropDown(ddlTab4AdminPositionDegreeRow2, "SELECT * FROM PS_POSITION WHERE P_GROUP = 1", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทบริหาร--");
            DatabaseManager.BindDropDown(ddlTab4DirectPositionDegreeRow2, "SELECT * FROM PS_POSITION WHERE P_GROUP = 2", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทอำนวยการ--");
            DatabaseManager.BindDropDown(ddlTab4AcadPositionDegreeRow2, "SELECT * FROM PS_POSITION WHERE P_GROUP = 3", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทวิชาการ--");
            DatabaseManager.BindDropDown(ddlTab4GeneralPositionDegreeRow2, "SELECT * FROM PS_POSITION WHERE P_GROUP = 4", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภททั่วไป--");
            DatabaseManager.BindDropDown(ddlTab4EmpPositionRow3, "SELECT * FROM PS_POSITION WHERE P_GROUP = 5", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภททั่วไป--");

            //tab5
            DatabaseManager.BindDropDown(ddlDegree10, "SELECT * FROM TB_GRAD_LEV", "GRAD_LEV_NAME", "GRAD_LEV_ID", "--กรุณาเลือกระดับการศึกษา--");
            DatabaseManager.BindDropDown(ddlMonth10From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
            DatabaseManager.BindDropDown(ddlYear10From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
            DatabaseManager.BindDropDown(ddlMonth10To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
            DatabaseManager.BindDropDown(ddlYear10To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
            DatabaseManager.BindDropDown(ddlCountrySuccess10, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศ--");

            //tab6 ไม่มี

            //tab7
            DatabaseManager.BindDropDown(ddlMonth12From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
            DatabaseManager.BindDropDown(ddlYear12From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
            DatabaseManager.BindDropDown(ddlMonth12To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
            DatabaseManager.BindDropDown(ddlYear12To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");

            //tab8
            DatabaseManager.BindDropDown(ddlYear13, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");

            //tab9
            SQLddlPositionType14();

            //Gridview
            BindData();

            //Can't press characters
            tbPhone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            tbTelephone.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            tbZipcode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            tbZipcode2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            tbSalary.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            tbPositionSalary.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            
        }

        protected void ClearMiddleTab4()
        {
            tbDateGetPositionGoverTab4.Text = "";
            ddlTab4AdminPositionDegreeRow2.SelectedIndex = 0;
            ddlTab4DirectPositionDegreeRow2.SelectedIndex = 0;
            ddlTab4AcadPositionDegreeRow2.SelectedIndex = 0;
            ddlTab4GeneralPositionDegreeRow2.SelectedIndex = 0;
        }
        protected void ClearRightTab4()
        {
            tbDateGetPositionEMPTab4.Text = "";
            ddlTab4EmpPositionRow3.SelectedIndex = 0;
        }

        private void selectTab(string _tab) {
            divState1.Visible = false;
            divTab1.Visible = false;
            divTab2.Visible = false;
            divTab3.Visible = false;
            divTab4.Visible = false;
            divTab5.Visible = false;
            divTab6.Visible = false;
            divTab7.Visible = false;
            divTab8.Visible = false;
            divTab9.Visible = false;
            lbuTab1.CssClass = "ps-tab-unselected";
            lbuTab2.CssClass = "ps-tab-unselected";
            lbuTab3.CssClass = "ps-tab-unselected";
            lbuTab4.CssClass = "ps-tab-unselected";
            lbuTab5.CssClass = "ps-tab-unselected";
            lbuTab6.CssClass = "ps-tab-unselected";
            lbuTab7.CssClass = "ps-tab-unselected";
            lbuTab8.CssClass = "ps-tab-unselected";
            lbuTab9.CssClass = "ps-tab-unselected";

            if (_tab == "0") {
                divState1.Visible = true;
            } else if (_tab == "1") {
                divTab1.Visible = true;
                lbuTab1.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "2") {
                divTab2.Visible = true;
                lbuTab2.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "3") {
                divTab3.Visible = true;
                lbuTab3.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "4") {
                divTab4.Visible = true;
                lbuTab4.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "5") {
                divTab5.Visible = true;
                lbuTab5.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "6") {
                divTab6.Visible = true;
                lbuTab6.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "7") {
                divTab7.Visible = true;
                lbuTab7.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "8") {
                divTab8.Visible = true;
                lbuTab8.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            } else if (_tab == "9") {
                divTab9.Visible = true;
                lbuTab9.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                int staffTypeID = -1;
                using (OracleCommand com = new OracleCommand("SELECT PS_STAFFTYPE_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staffTypeID = reader.GetInt32(0);

                        }
                    }
                }
       
                idPositionShowAll.Visible = false;
                idPositionShowGover.Visible = false;
                idPositionShowOfficeEmp.Visible = false;

                GridviewPDHgover.Visible = false;
                GridviewPDHemp.Visible = false;

                if (staffTypeID == 1) {
                    idPositionShowAll.Visible = true;
                    idPositionShowGover.Visible = true;
                    GridviewPDHgover.Visible = true;
                } else if (staffTypeID == 2) {
                    idPositionShowAll.Visible = true;
                } else if (staffTypeID == 3) {
                    idPositionShowAll.Visible = true;
                } else if (staffTypeID == 4) {
                    idPositionShowAll.Visible = true;
                } else if (staffTypeID == 5) {
                    idPositionShowAll.Visible = true;
                } else if (staffTypeID == 6) {
                    idPositionShowAll.Visible = true;
                    idPositionShowOfficeEmp.Visible = true;
                    GridviewPDHemp.Visible = true;
                }

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
        protected void lbuTab5_Click(object sender, EventArgs e) {
            selectTab("5");
        }
        protected void lbuTab6_Click(object sender, EventArgs e) {
            selectTab("6");
        }
        protected void lbuTab7_Click(object sender, EventArgs e) {
            selectTab("7");
        }
        protected void lbuTab8_Click(object sender, EventArgs e) {
            selectTab("8");
        }
        protected void lbuTab9_Click(object sender, EventArgs e) {
            selectTab("9");
        }
        protected void lbuTab1Save_Click(object sender, EventArgs e) {
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
            if (tbNameEN.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อ อังกฤษ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbLastNameEN.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกนามสกุล อังกฤษ</div>";
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
            P0.PS_DAD_FN = tbFatherName.Text;
            P0.PS_DAD_LN = tbFatherLastName.Text;
            P0.PS_MOM_FN = tbMotherName.Text;
            P0.PS_MOM_LN = tbMotherLastName.Text;
            P0.PS_MOM_LN_OLD = tbMotherOldLastName.Text;
            P0.PS_LOV_FN = tbCoupleName.Text;
            P0.PS_LOV_LN = tbCoupleLastName.Text;
            P0.PS_LOV_LN_OLD = tbCoupleOldLastName.Text;
            P0.PS_RETIRE_DATE = Util.ODT(Util.BirthdayToRetireDate(tbBirthday.Text));
            P0.PS_RETIRE_LONG = Util.ToThaiWordRetire(tbBirthday.Text);

            P0.UPDATE_PS_PERSON_TAB1();
            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลพื้นฐานสำเร็จ</strong></div>";
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
            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลที่อยู่สำเร็จ</strong></div>";
        }
        protected void lbuTab3Save_Click(object sender, EventArgs e) {

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

            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
            P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
            P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            P0.PS_WORK_DIVISION_ID = Convert.ToInt32(ddlWorkDivision.SelectedValue); ;
            P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
            P0.PS_BUDGET_ID = Convert.ToInt32(ddlBudget.SelectedValue);
            P0.PS_SPECIAL_WORK = tbSpecialWork.Text;
            P0.PS_TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
            P0.PS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_POSS_SALARY = Convert.ToInt32(tbPositionSalary.Text);
            P0.PS_SW_ID = Convert.ToInt32(ddlTab10StatusWork.SelectedValue);
            P0.PS_CITIZEN_ID = p;

            P0.UPDATE_PS_PERSON_TAB3();
            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลการทำงานสำเร็จ</strong></div>";

        }

        protected void lbuTab4Save_Click(object sender, EventArgs e) {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                int staffTypeID = -1;
                using (OracleCommand com = new OracleCommand("SELECT PS_STAFFTYPE_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            staffTypeID = reader.GetInt32(0);
                        }
                    }
                }

                idPositionShowAll.Visible = false;
                idPositionShowGover.Visible = false;
                idPositionShowOfficeEmp.Visible = false;

                GridviewPDHgover.Visible = false;
                GridviewPDHemp.Visible = false;

                if (staffTypeID == 1)
                {
                    idPositionShowAll.Visible = true;
                    idPositionShowGover.Visible = true;
                    GridviewPDHgover.Visible = true;
                }
                else if (staffTypeID == 2)
                {
                    idPositionShowAll.Visible = true;
                }
                else if (staffTypeID == 3)
                {
                    idPositionShowAll.Visible = true;
                }
                else if (staffTypeID == 4)
                {
                    idPositionShowAll.Visible = true;
                }
                else if (staffTypeID == 5)
                {
                    idPositionShowAll.Visible = true;
                }
                else if (staffTypeID == 6)
                {
                    idPositionShowAll.Visible = true;
                    idPositionShowOfficeEmp.Visible = true;
                    GridviewPDHemp.Visible = true;
                }

                {
                    if (ddlTab4PositionWorkRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งในสายงาน</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AdminPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางบริหาร</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AcadPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางวิชาการ</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }

                    //บันทึก 3 ตัว
                    PS_PERSON P0 = new PS_PERSON();
                    P0.PS_WORK_POS_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                    P0.PS_ADMIN_POS_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                    P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlTab4AcadPositionRow1.SelectedValue);
                    P0.PS_CITIZEN_ID = p;
                    P0.UPDATE_PS_PERSON_TAB4_EVERYONE();

                    if (chkBoxWorkPosition.Checked)
                    {
                        PS_PERSON P2 = new PS_PERSON();
                        P2.PS_START_POSI_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                        P2.PS_CITIZEN_ID = p;
                        P2.UPDATE_PS_PERSON_START_WORK_POSITION_FIRST_TIME();

                    }
                    if (chkBoxAdminPosition.Checked)
                    {
                        PS_PERSON P3 = new PS_PERSON();
                        P3.PS_START_ADMIN_POSI_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                        P3.PS_CITIZEN_ID = p;
                        P3.UPDATE_PS_PERSON_START_ADMIN_POSITION_FIRST_TIME();
                    }

                    notification.Attributes["class"] = "alert alert_success";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งสำเร็จ</strong></div>";
                }

                if (staffTypeID == 1) {
                    if (ddlTab4PositionWorkRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งในสายงาน</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AdminPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางบริหาร</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AcadPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางวิชาการ</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }

                    if(ddlTab4AdminPositionDegreeRow2.SelectedIndex == 0 && ddlTab4DirectPositionDegreeRow2.SelectedIndex == 0 && ddlTab4AcadPositionDegreeRow2.SelectedIndex == 0 && ddlTab4GeneralPositionDegreeRow2.SelectedIndex == 0)
                    {
                        //กลาง
                        PS_PERSON P0 = new PS_PERSON();
                        TB_POSITION_DEGREE_HISTORY_GOVER P1 = new TB_POSITION_DEGREE_HISTORY_GOVER();
                        P0.PS_WORK_POS_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                        P0.PS_ADMIN_POS_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                        P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlTab4AcadPositionRow1.SelectedValue);
                        P0.PS_POSI_ADMIN = Convert.ToInt32(ddlTab4AdminPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_DIRECT = Convert.ToInt32(ddlTab4DirectPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_ACAD = Convert.ToInt32(ddlTab4AcadPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_GENERAL = Convert.ToInt32(ddlTab4GeneralPositionDegreeRow2.SelectedValue);
                        P0.PS_CITIZEN_ID = p;
                        P0.UPDATE_PS_PERSON_TAB4_EVERYONE_GOVER();

                        DataTable dt = P1.SELECT_POSI_GOVER_ONLY(p, "", "", "", "", "");
                        GridviewPDHgover.DataSource = dt;
                        GridviewPDHgover.DataBind();
                        SetViewState(dt);

                        notification.Attributes["class"] = "alert alert_success";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งสำเร็จ</strong></div>";
                    }
                    else
                    {
                        //ก่อนที่จะเริ่มใหม่
                        //กลาง ////////////////////////////
                        PS_PERSON P0 = new PS_PERSON();
                        P0.PS_WORK_POS_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                        P0.PS_ADMIN_POS_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                        P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlTab4AcadPositionRow1.SelectedValue);
                        P0.PS_POSI_ADMIN = Convert.ToInt32(ddlTab4AdminPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_DIRECT = Convert.ToInt32(ddlTab4DirectPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_ACAD = Convert.ToInt32(ddlTab4AcadPositionDegreeRow2.SelectedValue);
                        P0.PS_POSI_GENERAL = Convert.ToInt32(ddlTab4GeneralPositionDegreeRow2.SelectedValue);
                        P0.PS_CITIZEN_ID = p;
                        P0.UPDATE_PS_PERSON_TAB4_EVERYONE_GOVER();

                        TB_POSITION_DEGREE_HISTORY_GOVER P1 = new TB_POSITION_DEGREE_HISTORY_GOVER();
                        P1.PDH_CITIZEN_ID = p;
                        P1.PDH_DATE_START = Util.ODT(tbDateGetPositionGoverTab4.Text);
                        P1.POSI_ADMIN = Convert.ToInt32(ddlTab4AdminPositionDegreeRow2.SelectedValue);
                        P1.POSI_DIRECT = Convert.ToInt32(ddlTab4DirectPositionDegreeRow2.SelectedValue);
                        P1.POSI_ACAD = Convert.ToInt32(ddlTab4AcadPositionDegreeRow2.SelectedValue);
                        P1.POSI_GENERAL = Convert.ToInt32(ddlTab4GeneralPositionDegreeRow2.SelectedValue);
                        P1.INSERT_POSI_GOVER_ONLY();

                        ClearMiddleTab4();
                        DataTable dt = P1.SELECT_POSI_GOVER_ONLY(p, "", "", "", "", "");
                        GridviewPDHgover.DataSource = dt;
                        GridviewPDHgover.DataBind();
                        SetViewState(dt);

                        notification.Attributes["class"] = "alert alert_success";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งสำเร็จ</strong></div>";
                    }


                } else if (staffTypeID == 6) {
                    if (ddlTab4PositionWorkRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งในสายงาน</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AdminPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางบริหาร</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                    if (ddlTab4AcadPositionRow1.SelectedIndex == 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                        notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งทางวิชาการ</div>";
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }

                    if(ddlTab4EmpPositionRow3.SelectedIndex == 0)
                    {
                        //ขวา
                        PS_PERSON P0 = new PS_PERSON();
                        TB_POSITION_DEGREE_HISTORY_EMP P2 = new TB_POSITION_DEGREE_HISTORY_EMP();
                        P0.PS_WORK_POS_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                        P0.PS_ADMIN_POS_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                        P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlTab4AcadPositionRow1.SelectedValue);
                        P0.PS_POSI_EMP_GROUP = Convert.ToInt32(ddlTab4EmpPositionRow3.SelectedValue);
                        P0.PS_CITIZEN_ID = p;
                        P0.UPDATE_PS_PERSON_TAB4_EVERYONE_EMP();

                        DataTable dt = P2.SELECT_POSI_EMP_ONLY(p, "", "");
                        GridviewPDHemp.DataSource = dt;
                        GridviewPDHemp.DataBind();
                        SetViewState(dt);

                        notification.Attributes["class"] = "alert alert_success";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งสำเร็จ</strong></div>";
                    }
                    else
                    {
                        //ขวา
                        PS_PERSON P0 = new PS_PERSON();
                        P0.PS_WORK_POS_ID = Convert.ToInt32(ddlTab4PositionWorkRow1.SelectedValue);
                        P0.PS_ADMIN_POS_ID = Convert.ToInt32(ddlTab4AdminPositionRow1.SelectedValue);
                        P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlTab4AcadPositionRow1.SelectedValue);
                        P0.PS_POSI_EMP_GROUP = Convert.ToInt32(ddlTab4EmpPositionRow3.SelectedValue);
                        P0.PS_CITIZEN_ID = p;
                        P0.UPDATE_PS_PERSON_TAB4_EVERYONE_EMP();

                        TB_POSITION_DEGREE_HISTORY_EMP P2 = new TB_POSITION_DEGREE_HISTORY_EMP();
                        P2.PDH_CITIZEN_ID = p;
                        P2.PDH_DATE_START = Util.ODT(tbDateGetPositionEMPTab4.Text);
                        P2.POSI_EMP_GROUP = Convert.ToInt32(ddlTab4EmpPositionRow3.SelectedValue);
                        P2.INSERT_POSI_EMP_ONLY();

                        ClearRightTab4();
                        DataTable dt = P2.SELECT_POSI_EMP_ONLY(p, "", "");
                        GridviewPDHemp.DataSource = dt;
                        GridviewPDHemp.DataBind();
                        SetViewState(dt);

                        notification.Attributes["class"] = "alert alert_success";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งสำเร็จ</strong></div>";
                    }

                }
            }
        }

        protected void lbuTab5Save_Click(object sender, EventArgs e) {
            if (ddlDegree10.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกระดับการศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbUnivName10.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสถานศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlMonth10From.SelectedIndex == 0 && ddlYear10From.SelectedIndex == 0 && ddlMonth10To.SelectedIndex == 0 && ddlYear10To.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตั้งแต่ - ถึง (เดือน ปี)ให้ถูกต้อง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbQualification10.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวุฒิ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbMajor10.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสาขาวิชาเอก</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlCountrySuccess10.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกประเทศที่จบการศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PS_STUDY PStudy = new PS_STUDY();
            PStudy.PS_CITIZEN_ID = p;
            PStudy.PS_DEGREE_ID = Convert.ToInt32(ddlDegree10.SelectedValue);
            PStudy.PS_UNIV_NAME = tbUnivName10.Text;
            PStudy.PS_FROM_MONTH = Convert.ToInt32(ddlMonth10From.SelectedValue);
            PStudy.PS_FROM_YEAR = Convert.ToInt32(ddlYear10From.SelectedValue);
            PStudy.PS_TO_MONTH = Convert.ToInt32(ddlMonth10To.SelectedValue);
            PStudy.PS_TO_YEAR = Convert.ToInt32(ddlYear10To.SelectedValue);
            PStudy.PS_QUALIFICATION = tbQualification10.Text;
            PStudy.PS_MAJOR = tbMajor10.Text;
            PStudy.PS_COUNTRY_ID = Convert.ToInt32(ddlCountrySuccess10.SelectedValue);
            PStudy.INSERT_PS_STUDY();

            ClearPStudy10();
            DataTable dt1 = PStudy.SELECT_PS_STUDY(p, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลประวัติการศึกษาสำเร็จ</strong></div>";
        }
        protected void lbuTab6Save_Click(object sender, EventArgs e) {
            if (tbLicenseName11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อใบอนุญาต</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbDepartment11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหน่วยงาน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbLicenseNo11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเลขที่ใบอนุญาต</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbUseDate11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวันที่มีผลบังคับใช้ (วัน เดือน ปี)</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            PLicense.PS_CITIZEN_ID = p;
            PLicense.PS_LICENSE_NAME = tbLicenseName11.Text;
            PLicense.PS_DEPARTMENT = tbDepartment11.Text;
            PLicense.PS_LICENSE_NO = tbLicenseNo11.Text;
            PLicense.PS_USE_DATE = Util.ODT(tbUseDate11.Text);
            PLicense.INSERT_PS_PROFESSIONAL_LICENSE();

            ClearPLicense11();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(p, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลใบอนุญาตประกอบวิชาชีพสำเร็จ</strong></div>";
        }
        protected void lbuTab7Save_Click(object sender, EventArgs e) {
            if (tbCourse.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหลักสูตรฝึกอบรม</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlMonth12From.SelectedIndex == 0 && ddlYear12From.SelectedIndex == 0 && ddlMonth12To.SelectedIndex == 0 && ddlYear12To.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตั้งแต่ - ถึง (เดือน ปี)ให้ถูกต้อง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbDepartment.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหน่วยงานที่จัดฝึกอบรม</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PS_TRAINING PTraining = new PS_TRAINING();
            PTraining.PS_CITIZEN_ID = p;
            PTraining.PS_COURSE = tbCourse.Text;
            PTraining.PS_FROM_MONTH = Convert.ToInt32(ddlMonth12From.SelectedValue);
            PTraining.PS_FROM_YEAR = Convert.ToInt32(ddlYear12From.SelectedValue);
            PTraining.PS_TO_MONTH = Convert.ToInt32(ddlMonth12To.SelectedValue);
            PTraining.PS_TO_YEAR = Convert.ToInt32(ddlYear12To.SelectedValue);
            PTraining.PS_DEPARTMENT = tbDepartment.Text;
            PTraining.INSERT_PS_TRAINING();

            ClearPTraining12();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(p, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลประวัติการฝึกอบรมสำเร็จ</strong></div>";
        }
        protected void lbuTab8Save_Click(object sender, EventArgs e) {
            if (ddlYear13.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกพ.ศ.</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbName13.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกรายการ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbREF13.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเอกสารอ้างอิง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            PDAA.PS_CITIZEN_ID = p;
            PDAA.PS_YEAR = Convert.ToInt32(ddlYear13.SelectedValue);
            PDAA.PS_DAA_NAME = tbName13.Text;
            PDAA.PS_REF = tbREF13.Text;
            PDAA.INSERT_PS_DISCIPLINARY_AND_AMNESTY();

            ClearPDAA13();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(p, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรมสำเร็จ</strong></div>";
        }
        protected void lbuTab9Save_Click(object sender, EventArgs e) {
            if (tbDate14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวัน เดือน ปี</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbPosition14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbPositionNo14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเลขที่ตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlPositionType14.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งประเภท</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlPositionDegree14.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกระดับ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbSalary14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเงินเดือน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbSalaryPosition14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเงินประจำตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (tbRef14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเอกสารอ้างอิง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PS_PERSON P0 = new PS_PERSON();
            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            PPAS.PS_CITIZEN_ID = p;
            PPAS.PS_DATE = Util.ODT(tbDate14.Text);
            PPAS.PS_POSITION = tbPosition14.Text;
            PPAS.PS_POSITION_NO = tbPositionNo14.Text;
            PPAS.PS_POSITION_TYPE = ddlPositionType14.SelectedValue;
            PPAS.PS_POSITION_DEGREE = ddlPositionDegree14.SelectedValue;
            PPAS.PS_SALARY = Convert.ToInt32(tbSalary14.Text);
            PPAS.PS_SALARY_POSITION = Convert.ToInt32(tbSalaryPosition14.Text);
            PPAS.PS_REF = tbRef14.Text;
            PPAS.INSERT_PS_POSITION_AND_SALARY();

            P0.PS_SALARY = Convert.ToInt32(tbSalary14.Text);
            P0.PS_POSS_SALARY = Convert.ToInt32(tbSalaryPosition14.Text);
            P0.PS_CITIZEN_ID = p;
            P0.UPDATE_CURRENT_SALARY_PERSON();

            ClearPPAS14();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(p, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong>บันทึกข้อมูลตำแหน่งและเงินเดือนสำเร็จ</strong></div>";
        }

        private void BindView1() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID,PS_RANK_ID,PS_TITLE_ID,PS_FN_TH,PS_LN_TH,PS_FN_EN,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_RELIGION_ID,PS_STATUS_ID,PS_DAD_FN,PS_DAD_LN,PS_MOM_FN,PS_MOM_LN,PS_MOM_LN_OLD,PS_LOV_FN,PS_LOV_LN,PS_LOV_LN_OLD FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            //view1
                            int i = 0;
                            labelCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlRank.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlTitle.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbNameTH.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastNameTH.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbNameEN.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastNameEN.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlGender.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbBirthday.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString()); ++i;
                            tbEmail.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbPhone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbTelephone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlRace.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlNation.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            ddlBlood.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlReligion.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlStatus.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbFatherName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbFatherLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMotherName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMotherLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMotherOldLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCoupleName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCoupleLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCoupleOldLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
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
                using (OracleCommand com = new OracleCommand("SELECT PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID,PS_INWORK_DATE,PS_SALARY,PS_POSS_SALARY,PS_SW_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
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

                            tbSpecialWork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbDateInwork.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString()); ++i;
                            tbSalary.Text = reader.IsDBNull(i) ? "" : reader.GetInt32(i).ToString(); ++i;
                            tbPositionSalary.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlTab10StatusWork.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                        }
                    }
                }
            }
        }
        private void BindView4()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_WORK_POS_ID,PS_ADMIN_POS_ID,PS_ACAD_POS_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //view3
                            int i = 0;
                            ddlTab4PositionWorkRow1.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlTab4AdminPositionRow1.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlTab4AcadPositionRow1.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
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
                lb.Text = "ค้นหารายชื่อ";
                ppp.Controls.Add(lb);
            }
            {
                Panel ppp = new Panel();
                ppp.Style.Add("text-align", "center");
                ppp.DefaultButton = "pppSearch";
                pp.Controls.Add(ppp);

                Label lb = new Label();
                lb.Text = "เลขบัตรประจำตัวประชาชน 13 หลัก : ";
                ppp.Controls.Add(lb);

                TextBox tbSearchCitizenID = new TextBox();
                tbSearchCitizenID.Style.Add("margin-right", "5px");
                tbSearchCitizenID.CssClass = "ps-textbox";
                tbSearchCitizenID.MaxLength = 13;
                tbSearchCitizenID.Width = Unit.Parse("230px");
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
                                    BindView4();
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

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["AddPersonEdit"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["AddPersonEdit"] = data;
        }

        #endregion

        void BindData()
        {
            //GridViewStudy
            PS_STUDY PStudy = new PS_STUDY();
            DataTable dt1 = PStudy.SELECT_PS_STUDY(p, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);
            //GridViewLicense
            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(p, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);
            //GridViewTraining
            PS_TRAINING PTraining = new PS_TRAINING();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(p, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);
            //GridViewDisciplinary
            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(p, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);
            //GridViewPositionAndSalary
            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(p, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);
            //GridViewPositionDegreeHistoryGover
            TB_POSITION_DEGREE_HISTORY_GOVER PDHgover = new TB_POSITION_DEGREE_HISTORY_GOVER();
            DataTable dt6 = PDHgover.SELECT_POSI_GOVER_ONLY(p, "", "", "", "", "");
            GridviewPDHgover.DataSource = dt6;
            GridviewPDHgover.DataBind();
            SetViewState(dt6);
            //GridViewPositionDegreeHistoryEMP
            TB_POSITION_DEGREE_HISTORY_EMP PDHemp = new TB_POSITION_DEGREE_HISTORY_EMP();
            DataTable dt7 = PDHemp.SELECT_POSI_EMP_ONLY(p, "", "");
            GridviewPDHemp.DataSource = dt7;
            GridviewPDHemp.DataBind();
            SetViewState(dt7);
        }

        void BindData1()
        {
            PS_STUDY PStudy = new PS_STUDY();
            DataTable dt1 = PStudy.SELECT_PS_STUDY(labelCitizenID.Text, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(labelCitizenID.Text, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            PS_TRAINING PTraining = new PS_TRAINING();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(labelCitizenID.Text, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(labelCitizenID.Text, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(labelCitizenID.Text, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);

            TB_POSITION_DEGREE_HISTORY_GOVER PDHgover = new TB_POSITION_DEGREE_HISTORY_GOVER();
            DataTable dt6 = PDHgover.SELECT_POSI_GOVER_ONLY(labelCitizenID.Text, "", "", "", "", "");
            GridviewPDHgover.DataSource = dt6;
            GridviewPDHgover.DataBind();
            SetViewState(dt6);

            TB_POSITION_DEGREE_HISTORY_EMP PDHemp = new TB_POSITION_DEGREE_HISTORY_EMP();
            DataTable dt7 = PDHemp.SELECT_POSI_EMP_ONLY(labelCitizenID.Text, "", "");
            GridviewPDHemp.DataSource = dt7;
            GridviewPDHemp.DataBind();
            SetViewState(dt7);
        }

        protected void ClearPStudy10()
        {
            ddlDegree10.SelectedIndex = 0;
            tbUnivName10.Text = "";
            ddlMonth10From.SelectedIndex = 0;
            ddlYear10From.SelectedIndex = 0;
            ddlMonth10To.SelectedIndex = 0;
            ddlYear10To.SelectedIndex = 0;
            tbQualification10.Text = "";
            tbMajor10.Text = "";
            ddlCountrySuccess10.SelectedIndex = 0;
        }

        protected void ClearPLicense11()
        {
            tbLicenseName11.Text = "";
            tbDepartment11.Text = "";
            tbLicenseNo11.Text = "";
            tbUseDate11.Text = "";
        }

        protected void ClearPTraining12()
        {
            tbCourse.Text = "";
            ddlMonth12From.SelectedIndex = 0;
            ddlYear12From.SelectedIndex = 0;
            ddlMonth12To.SelectedIndex = 0;
            ddlYear12To.SelectedIndex = 0;
            tbDepartment.Text = "";
        }

        protected void ClearPDAA13()
        {
            ddlYear13.SelectedIndex = 0;
            tbName13.Text = "";
            tbREF13.Text = "";
        }

        protected void ClearPPAS14()
        {
            tbDate14.Text = "";
            tbPosition14.Text = "";
            tbPositionNo14.Text = "";
            ddlPositionType14.SelectedIndex = 0;
            ddlPositionDegree14.SelectedIndex = 0;
            tbSalary14.Text = "";
            tbSalaryPosition14.Text = "";
            tbRef14.Text = "";
        }

        //Start GridView
        //GirdViewStudy
        protected void modEditCommand1(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewStudy.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand1(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand1(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewStudy.DataKeys[e.RowIndex].Value);
            PS_STUDY PStudy = new PS_STUDY();
            PStudy.PS_STUDY_ID = id;
            PStudy.DELETE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand1(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPersonStudyID = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblPersonStudyID");
            Label lblPersonStudyCitizenID = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblPersonStudyCitizenID");
            DropDownList ddlPersonStudyDegreeID = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyDegreeID");
            TextBox txtPersonStudyUnivName = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyUnivName");
            DropDownList ddlPersonStudyFromMonth = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyFromMonth");
            DropDownList ddlPersonStudyFromYear = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyFromYear");
            DropDownList ddlPersonStudyToMonth = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyToMonth");
            DropDownList ddlPersonStudyToYear = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyToYear");
            TextBox txtPersonStudyQualification = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyQualification");
            TextBox txtPersonStudyMajor = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyMajor");
            DropDownList ddlPersonStudyCountryID = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyCountryID");

            PS_STUDY PStudy = new PS_STUDY(Convert.ToInt32(lblPersonStudyID.Text)
                , lblPersonStudyCitizenID.Text
                , Convert.ToInt32(ddlPersonStudyDegreeID.SelectedValue)
                , txtPersonStudyUnivName.Text
                , Convert.ToInt32(ddlPersonStudyFromMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyFromYear.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyToMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyToYear.SelectedValue)
                , txtPersonStudyQualification.Text
                , txtPersonStudyMajor.Text
                , Convert.ToInt32(ddlPersonStudyCountryID.SelectedValue));

            if (ddlPersonStudyDegreeID.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกระดับการศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (string.IsNullOrEmpty(txtPersonStudyUnivName.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสถานศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (ddlPersonStudyFromMonth.SelectedIndex == 0 && ddlPersonStudyFromYear.SelectedIndex == 0 && ddlPersonStudyToMonth.SelectedIndex == 0 && ddlPersonStudyToYear.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตั้งแต่ - ถึง (เดือน ปี)ให้ถูกต้อง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (string.IsNullOrEmpty(txtPersonStudyQualification.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวุฒิ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (string.IsNullOrEmpty(txtPersonStudyMajor.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสาขาวิชาเอก</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (ddlPersonStudyCountryID.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกประเทศที่จบการศึกษา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PStudy.UPDATE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewStudy_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบสถานศึกษา " + DataBinder.Eval(e.Row.DataItem, "PS_UNIV_NAME") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyDegreeID = (DropDownList)e.Row.FindControl("ddlPersonStudyDegreeID");

                            sqlCmd.CommandText = "select * from TB_GRAD_LEV";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonStudyDegreeID.DataSource = dt;
                            ddlPersonStudyDegreeID.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_DEGREE_ID").ToString();
                            ddlPersonStudyDegreeID.DataValueField = "GRAD_LEV_ID";
                            ddlPersonStudyDegreeID.DataTextField = "GRAD_LEV_NAME";
                            ddlPersonStudyDegreeID.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyDegreeID.Items.Insert(0, new ListItem("--ระดับการศึกษา--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyFromMonth = (DropDownList)e.Row.FindControl("ddlPersonStudyFromMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonStudyFromMonth.DataSource = dt;
                            ddlPersonStudyFromMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_MONTH").ToString();
                            ddlPersonStudyFromMonth.DataValueField = "MONTH_ID";
                            ddlPersonStudyFromMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonStudyFromMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyFromMonth.Items.Insert(0, new ListItem("--เดือน--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyFromYear = (DropDownList)e.Row.FindControl("ddlPersonStudyFromYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da2.Fill(dt);
                            ddlPersonStudyFromYear.DataSource = dt;
                            ddlPersonStudyFromYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_YEAR").ToString();
                            ddlPersonStudyFromYear.DataValueField = "YEAR_ID";
                            ddlPersonStudyFromYear.DataTextField = "YEAR_ID";
                            ddlPersonStudyFromYear.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyFromYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyToMonth = (DropDownList)e.Row.FindControl("ddlPersonStudyToMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da3 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);
                            ddlPersonStudyToMonth.DataSource = dt;
                            ddlPersonStudyToMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_MONTH").ToString();
                            ddlPersonStudyToMonth.DataValueField = "MONTH_ID";
                            ddlPersonStudyToMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonStudyToMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyToMonth.Items.Insert(0, new ListItem("--เดือน--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyToYear = (DropDownList)e.Row.FindControl("ddlPersonStudyToYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da4 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da4.Fill(dt);
                            ddlPersonStudyToYear.DataSource = dt;
                            ddlPersonStudyToYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_YEAR").ToString();
                            ddlPersonStudyToYear.DataValueField = "YEAR_ID";
                            ddlPersonStudyToYear.DataTextField = "YEAR_ID";
                            ddlPersonStudyToYear.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyToYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyCountryID = (DropDownList)e.Row.FindControl("ddlPersonStudyCountryID");

                            sqlCmd.CommandText = "select * from TB_COUNTRY";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da5 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da5.Fill(dt);
                            ddlPersonStudyCountryID.DataSource = dt;
                            ddlPersonStudyCountryID.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_COUNTRY_ID").ToString();
                            ddlPersonStudyCountryID.DataValueField = "COUNTRY_ID";
                            ddlPersonStudyCountryID.DataTextField = "COUNTRY_TH";
                            ddlPersonStudyCountryID.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyCountryID.Items.Insert(0, new ListItem("--ประเทศที่จบ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }

        protected void myGridViewStudy_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridViewStudy.PageIndex = e.NewPageIndex;
            GridViewStudy.DataSource = GetViewState();
            GridViewStudy.DataBind();
        }
        //GridViewLicense
        protected void modEditCommand2(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewLicense.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand2(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand2(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewLicense.DataKeys[e.RowIndex].Value);
            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            PLicense.PS_PL_ID = id;
            PLicense.DELETE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand2(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonLicenseID = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblPersonLicenseID");
            Label lblPersonLicenseCitizenID = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblPersonLicenseCitizenID");
            TextBox txtPersonLicenseName = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseName");
            TextBox txtPersonLicenseDepartment = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseDepartment");
            TextBox txtPersonLicenseNo = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseNo");
            TextBox txtPersonLicenseDate = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseDate");

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE(Convert.ToInt32(lblPersonLicenseID.Text)
                , lblPersonLicenseCitizenID.Text
                , txtPersonLicenseName.Text
                , txtPersonLicenseDepartment.Text
                , txtPersonLicenseNo.Text
                , Util.ODT(txtPersonLicenseDate.Text));

            if (txtPersonLicenseName.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อใบอนุญาต</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonLicenseDepartment.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหน่วยงาน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonLicenseNo.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเลขที่ใบอนุญาต</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonLicenseDate.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวันที่มีผลบังคับใช้ (วัน เดือน ปี)</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PLicense.UPDATE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewLicense_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อใบอนุญาต " + DataBinder.Eval(e.Row.DataItem, "PS_LICENSE_NAME") + " จริงๆใช่ไหม ?');");
            }
        }

        protected void myGridViewLicense_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridViewLicense.PageIndex = e.NewPageIndex;
            GridViewLicense.DataSource = GetViewState();
            GridViewLicense.DataBind();
        }
        //GridViewTraining
        protected void modEditCommand3(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewTraining.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand3(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand3(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewTraining.DataKeys[e.RowIndex].Value);
            PS_TRAINING PTraining = new PS_TRAINING();
            PTraining.PS_TRAINING_ID = id;
            PTraining.DELETE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand3(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPersonTrainingID = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblPersonTrainingID");
            Label lblPersonTrainingCitizenID = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblPersonTrainingCitizenID");
            TextBox txtPersonTrainingCourse = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtPersonTrainingCourse");
            DropDownList ddlPersonTrainingFromMonth = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingFromMonth");
            DropDownList ddlPersonTrainingFromYear = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingFromYear");
            DropDownList ddlPersonTrainingToMonth = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingToMonth");
            DropDownList ddlPersonTrainingToYear = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingToYear");
            TextBox txtPersonTrainingDepartment = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtPersonTrainingDepartment");

            PS_TRAINING PTraining = new PS_TRAINING(Convert.ToInt32(lblPersonTrainingID.Text)
                , lblPersonTrainingCitizenID.Text
                , txtPersonTrainingCourse.Text
                , Convert.ToInt32(ddlPersonTrainingFromMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingFromYear.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingToMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingToYear.SelectedValue)
                , txtPersonTrainingDepartment.Text);

            if (txtPersonTrainingCourse.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหลักสูตรฝึกอบรม</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlPersonTrainingFromMonth.SelectedIndex == 0 && ddlPersonTrainingFromYear.SelectedIndex == 0 && ddlPersonTrainingToMonth.SelectedIndex == 0 && ddlPersonTrainingToYear.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตั้งแต่ - ถึง (เดือน ปี)ให้ถูกต้อง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonTrainingDepartment.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกหน่วยงานที่จัดฝึกอบรม</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PTraining.UPDATE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewTraining_RowDataBound3(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบหลักสูตรฝึกอบรม " + DataBinder.Eval(e.Row.DataItem, "PS_COURSE") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingFromMonth = (DropDownList)e.Row.FindControl("ddlPersonTrainingFromMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingFromMonth.DataSource = dt;
                            ddlPersonTrainingFromMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_MONTH").ToString();
                            ddlPersonTrainingFromMonth.DataValueField = "MONTH_ID";
                            ddlPersonTrainingFromMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonTrainingFromMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingFromMonth.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingFromYear = (DropDownList)e.Row.FindControl("ddlPersonTrainingFromYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingFromYear.DataSource = dt;
                            ddlPersonTrainingFromYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_YEAR").ToString();
                            ddlPersonTrainingFromYear.DataValueField = "YEAR_ID";
                            ddlPersonTrainingFromYear.DataTextField = "YEAR_ID";
                            ddlPersonTrainingFromYear.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingFromYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingToMonth = (DropDownList)e.Row.FindControl("ddlPersonTrainingToMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingToMonth.DataSource = dt;
                            ddlPersonTrainingToMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_MONTH").ToString();
                            ddlPersonTrainingToMonth.DataValueField = "MONTH_ID";
                            ddlPersonTrainingToMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonTrainingToMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingToMonth.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingToYear = (DropDownList)e.Row.FindControl("ddlPersonTrainingToYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingToYear.DataSource = dt;
                            ddlPersonTrainingToYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_YEAR").ToString();
                            ddlPersonTrainingToYear.DataValueField = "YEAR_ID";
                            ddlPersonTrainingToYear.DataTextField = "YEAR_ID";
                            ddlPersonTrainingToYear.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingToYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }

        protected void myGridViewTraining_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridViewTraining.PageIndex = e.NewPageIndex;
            GridViewTraining.DataSource = GetViewState();
            GridViewTraining.DataBind();
        }
        //GridViewDAA
        protected void modEditCommand4(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewDAA.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand4(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand4(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewDAA.DataKeys[e.RowIndex].Value);
            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            PDAA.PS_DAA_ID = id;
            PDAA.DELETE_PS_DISCIPLINARY_AND_AMNESTY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand4(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonDAAID = (Label)GridViewDAA.Rows[e.RowIndex].FindControl("lblPersonDAAID");
            Label lblPersonDAACitizenID = (Label)GridViewDAA.Rows[e.RowIndex].FindControl("lblPersonDAACitizenID");
            DropDownList ddlPersonDAAYear = (DropDownList)GridViewDAA.Rows[e.RowIndex].FindControl("ddlPersonDAAYear");
            TextBox txtPersonDAAName = (TextBox)GridViewDAA.Rows[e.RowIndex].FindControl("txtPersonDAAName");
            TextBox txtPersonDAARef = (TextBox)GridViewDAA.Rows[e.RowIndex].FindControl("txtPersonDAARef");

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY(Convert.ToInt32(lblPersonDAAID.Text)
                , lblPersonDAACitizenID.Text
                , Convert.ToInt32(ddlPersonDAAYear.SelectedValue)
                , txtPersonDAAName.Text
                , txtPersonDAARef.Text);

            if (ddlPersonDAAYear.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกพ.ศ.</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonDAAName.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกรายการ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonDAARef.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเอกสารอ้างอิง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PDAA.UPDATE_PS_DISCIPLINARY_AND_AMNESTY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewDAA_RowDataBound4(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบรายการ " + DataBinder.Eval(e.Row.DataItem, "PS_DAA_NAME") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonDAAYear = (DropDownList)e.Row.FindControl("ddlPersonDAAYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonDAAYear.DataSource = dt;
                            ddlPersonDAAYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_YEAR").ToString();
                            ddlPersonDAAYear.DataValueField = "YEAR_ID";
                            ddlPersonDAAYear.DataTextField = "YEAR_ID";
                            ddlPersonDAAYear.DataBind();
                            sqlConn.Close();

                            ddlPersonDAAYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }

        protected void myGridViewDAA_PageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridViewDAA.PageIndex = e.NewPageIndex;
            GridViewDAA.DataSource = GetViewState();
            GridViewDAA.DataBind();
        }
        //GridViewPAS
        protected void modEditCommand5(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewPAS.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand5(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand5(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewPAS.DataKeys[e.RowIndex].Value);
            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            PPAS.PS_PAS_ID = id;
            PPAS.DELETE_PS_POSITION_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand5(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonPASID = (Label)GridViewPAS.Rows[e.RowIndex].FindControl("lblPersonPASID");
            Label lblPersonPASCitizenID = (Label)GridViewPAS.Rows[e.RowIndex].FindControl("lblPersonPASCitizenID");
            TextBox txtPersonPASDate = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASDate");
            TextBox txtPersonPASPOsitionName = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASPOsitionName");
            TextBox txtPersonPASPositionNO = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASPositionNO");
            DropDownList ddlPersonPASPositionType = (DropDownList)GridViewPAS.Rows[e.RowIndex].FindControl("ddlPersonPASPositionType");
            DropDownList ddlPersonPASDegree = (DropDownList)GridViewPAS.Rows[e.RowIndex].FindControl("ddlPersonPASDegree");
            TextBox txtPersonPASSalary = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASSalary");
            TextBox txtPersonPASSalaryPosition = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASSalaryPosition");
            TextBox txtPersonPASRef = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASRef");

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY(Convert.ToInt32(lblPersonPASID.Text)
                , lblPersonPASCitizenID.Text
                , Util.ODT(txtPersonPASDate.Text)
                , txtPersonPASPOsitionName.Text
                , txtPersonPASPositionNO.Text
                , ddlPersonPASPositionType.SelectedValue
                , ddlPersonPASDegree.SelectedValue
                , Convert.ToInt32(txtPersonPASSalary.Text)
                , Convert.ToInt32(txtPersonPASSalaryPosition.Text)
                , txtPersonPASRef.Text);

            if (txtPersonPASDate.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกวัน เดือน ปี</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonPASPOsitionName.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonPASPositionNO.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเลขที่ตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlPersonPASPositionType.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกตำแหน่งประเภท</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlPersonPASDegree.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกระดับ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonPASSalary.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเงินเดือน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonPASSalaryPosition.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเงินประจำตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPersonPASRef.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกเอกสารอ้างอิง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            PPAS.UPDATE_PS_POSITION_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewPAS_RowDataBound5(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบตำแหน่ง " + DataBinder.Eval(e.Row.DataItem, "PS_POSITION") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonPASPositionType = (DropDownList)e.Row.FindControl("ddlPersonPASPositionType");

                            sqlCmd.CommandText = "select * from TB_STAFF";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonPASPositionType.DataSource = dt;
                            ddlPersonPASPositionType.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_POSITION_TYPE").ToString();
                            ddlPersonPASPositionType.DataValueField = "ST_ID";
                            ddlPersonPASPositionType.DataTextField = "ST_NAME";
                            ddlPersonPASPositionType.DataBind();
                            sqlConn.Close();

                            ddlPersonPASPositionType.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonPASDegree = (DropDownList)e.Row.FindControl("ddlPersonPASDegree");

                            sqlCmd.CommandText = "select * from TB_POSITION";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonPASDegree.DataSource = dt;
                            ddlPersonPASDegree.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_POSITION_DEGREE").ToString();
                            ddlPersonPASDegree.DataValueField = "ID";
                            ddlPersonPASDegree.DataTextField = "NAME";
                            ddlPersonPASDegree.DataBind();
                            sqlConn.Close();

                            ddlPersonPASDegree.Items.Insert(0, new ListItem("--ระดับ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }

        protected void myGridViewPAS_PageIndexChanging5(object sender, GridViewPageEventArgs e)
        {
            GridViewPAS.PageIndex = e.NewPageIndex;
            GridViewPAS.DataSource = GetViewState();
            GridViewPAS.DataBind();
        }
        //GridViewPositionDegreeHistoryGover
        protected void modEditCommandGover(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHgover.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridviewPDHgover.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommandGover(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHgover.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHgover.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommandGover(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridviewPDHgover.DataKeys[e.RowIndex].Value);
            TB_POSITION_DEGREE_HISTORY_GOVER PDHgover = new TB_POSITION_DEGREE_HISTORY_GOVER();
            PDHgover.PDH_ID = id;
            PDHgover.DELETE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHgover.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHgover.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommandGover(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPDHid = (Label)GridviewPDHgover.Rows[e.RowIndex].FindControl("lblPDHid");
            Label lblPDHcitizenID = (Label)GridviewPDHgover.Rows[e.RowIndex].FindControl("lblPDHcitizenID");
            TextBox txtPDHdate = (TextBox)GridviewPDHgover.Rows[e.RowIndex].FindControl("txtPDHdate");
            DropDownList ddlPDHposiAdmin = (DropDownList)GridviewPDHgover.Rows[e.RowIndex].FindControl("ddlPDHposiAdmin");
            DropDownList ddlPDHposiDirect = (DropDownList)GridviewPDHgover.Rows[e.RowIndex].FindControl("ddlPDHposiDirect");
            DropDownList ddlPDHposiAcad = (DropDownList)GridviewPDHgover.Rows[e.RowIndex].FindControl("ddlPDHposiAcad");
            DropDownList ddlPDHposiGeneral = (DropDownList)GridviewPDHgover.Rows[e.RowIndex].FindControl("ddlPDHposiGeneral");

            TB_POSITION_DEGREE_HISTORY_GOVER PDHgover = new TB_POSITION_DEGREE_HISTORY_GOVER(Convert.ToInt32(lblPDHid.Text)
                , lblPDHcitizenID.Text
                , Util.ODT(txtPDHdate.Text)
                , Convert.ToInt32(ddlPDHposiAdmin.SelectedValue)
                , Convert.ToInt32(ddlPDHposiDirect.SelectedValue)
                , Convert.ToInt32(ddlPDHposiAcad.SelectedValue)
                , Convert.ToInt32(ddlPDHposiGeneral.SelectedValue));

            PDHgover.UPDATE_POSI_GOVER_ONLY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHgover.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHgover.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewGover_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบจริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPDHposiAdmin = (DropDownList)e.Row.FindControl("ddlPDHposiAdmin");

                            sqlCmd.CommandText = "select * from PS_POSITION WHERE P_GROUP = 1";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPDHposiAdmin.DataSource = dt;
                            //ddlPDHposiAdminEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "POSI_ADMIN").ToString();
                            ddlPDHposiAdmin.DataValueField = "P_ID";
                            ddlPDHposiAdmin.DataTextField = "P_NAME";
                            ddlPDHposiAdmin.DataBind();
                            sqlConn.Close();

                            ddlPDHposiAdmin.Items.Insert(0, new ListItem("--ตำแหน่งประเภทบริหาร--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPDHposiDirect = (DropDownList)e.Row.FindControl("ddlPDHposiDirect");

                            sqlCmd.CommandText = "select * from PS_POSITION WHERE P_GROUP = 2";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPDHposiDirect.DataSource = dt;
                            //ddlPDHposiDirect.SelectedValue = DataBinder.Eval(e.Row.DataItem, "POSI_ADMIN").ToString();
                            ddlPDHposiDirect.DataValueField = "P_ID";
                            ddlPDHposiDirect.DataTextField = "P_NAME";
                            ddlPDHposiDirect.DataBind();
                            sqlConn.Close();

                            ddlPDHposiDirect.Items.Insert(0, new ListItem("--ตำแหน่งประเภทอำนวยการ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPDHposiAcad = (DropDownList)e.Row.FindControl("ddlPDHposiAcad");

                            sqlCmd.CommandText = "select * from PS_POSITION WHERE P_GROUP = 3";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPDHposiAcad.DataSource = dt;
                            //ddlPDHposiAcad.SelectedValue = DataBinder.Eval(e.Row.DataItem, "POSI_ADMIN").ToString();
                            ddlPDHposiAcad.DataValueField = "P_ID";
                            ddlPDHposiAcad.DataTextField = "P_NAME";
                            ddlPDHposiAcad.DataBind();
                            sqlConn.Close();

                            ddlPDHposiAcad.Items.Insert(0, new ListItem("--ตำแหน่งประเภทวิชาการ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPDHposiGeneral = (DropDownList)e.Row.FindControl("ddlPDHposiGeneral");

                            sqlCmd.CommandText = "select * from PS_POSITION WHERE P_GROUP = 4";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPDHposiGeneral.DataSource = dt;
                            //ddlPDHposiGeneral.SelectedValue = DataBinder.Eval(e.Row.DataItem, "POSI_ADMIN").ToString();
                            ddlPDHposiGeneral.DataValueField = "P_ID";
                            ddlPDHposiGeneral.DataTextField = "P_NAME";
                            ddlPDHposiGeneral.DataBind();
                            sqlConn.Close();

                            ddlPDHposiGeneral.Items.Insert(0, new ListItem("--ตำแหน่งประเภททั่วไป--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }


                }
            }
        }

        protected void myGridViewGover_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewPDHgover.PageIndex = e.NewPageIndex;
            GridviewPDHgover.DataSource = GetViewState();
            GridviewPDHgover.DataBind();
        }
        //GridViewPositionDegreeHistoryGoverEMP
        protected void modEditCommandEmp(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHemp.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridviewPDHemp.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommandEmp(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHemp.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHemp.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommandEmp(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridviewPDHemp.DataKeys[e.RowIndex].Value);
            TB_POSITION_DEGREE_HISTORY_EMP PDHemp = new TB_POSITION_DEGREE_HISTORY_EMP();
            PDHemp.PDH_ID = id;
            PDHemp.DELETE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHemp.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHemp.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommandEmp(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPDHid = (Label)GridviewPDHemp.Rows[e.RowIndex].FindControl("lblPDHid");
            Label lblPDHcitizenID = (Label)GridviewPDHemp.Rows[e.RowIndex].FindControl("lblPDHcitizenID");
            TextBox txtPDHdate = (TextBox)GridviewPDHemp.Rows[e.RowIndex].FindControl("txtPDHdate");
            DropDownList ddlPDHposiAdmin = (DropDownList)GridviewPDHemp.Rows[e.RowIndex].FindControl("ddlPDHposiAdmin");


            TB_POSITION_DEGREE_HISTORY_EMP PDHemp = new TB_POSITION_DEGREE_HISTORY_EMP(Convert.ToInt32(lblPDHid.Text)
                , lblPDHcitizenID.Text
                , Util.ODT(txtPDHdate.Text)
                , Convert.ToInt32(ddlPDHposiAdmin.SelectedValue));

            PDHemp.UPDATE_POSI_EMP_ONLY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(labelCitizenID.Text))
            {
                GridviewPDHemp.EditIndex = -1;
                BindData();
            }
            else
            {
                GridviewPDHemp.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบจริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPDHempGroup = (DropDownList)e.Row.FindControl("ddlPDHempGroup");

                            sqlCmd.CommandText = "select * from PS_POSITION WHERE P_GROUP = 5";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPDHempGroup.DataSource = dt;
                            //ddlPDHempGroup.SelectedValue = DataBinder.Eval(e.Row.DataItem, "POSI_ADMIN").ToString();
                            ddlPDHempGroup.DataValueField = "P_ID";
                            ddlPDHempGroup.DataTextField = "P_NAME";
                            ddlPDHempGroup.DataBind();
                            sqlConn.Close();

                            ddlPDHempGroup.Items.Insert(0, new ListItem("--ตำแหน่งพนักงานราชการ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }

        protected void myGridViewEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewPDHemp.PageIndex = e.NewPageIndex;
            GridviewPDHemp.DataSource = GetViewState();
            GridviewPDHemp.DataBind();
        }
        //End GridView

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
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
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
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
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
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
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
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

                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void SQLddlPositionType14()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
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
            }
            catch { }
        }

        protected void ddlPositionType14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * FROM TB_POSITION where ST_ID = '" + ddlPositionType14.SelectedValue + "'";
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
            }
            catch { }
        }

        protected void lbCopyAddress_Click(object sender, EventArgs e)
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

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string CountryName = "";
                using (OracleCommand com = new OracleCommand("SELECT COUNTRY_TH FROM TB_COUNTRY WHERE COUNTRY_TH = '" + ddlCountry.SelectedValue + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CountryName = reader.GetString(0);
                        }
                    }
                }
                
                if (CountryName == "ไทย")
                {
                    tbState.Visible = true;
                }
                else if(CountryName != "ไทย")
                {
                    tbState.Visible = false;
                }
                
            }
        }

        protected void ddlCountry2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string CountryName2 = "";
                using (OracleCommand com = new OracleCommand("SELECT COUNTRY_TH FROM TB_COUNTRY WHERE COUNTRY_TH = '" + ddlCountry2.SelectedValue + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CountryName2 = reader.GetString(0);
                        }
                    }
                }
                tbState2.Visible = false;

                if (CountryName2 == "ไทย")
                {
                    tbState2.Visible = true;
                }
                else if (CountryName2 != "ไทย")
                {
                    tbState2.Visible = false;
                }
            }
        }

        
    }
}

