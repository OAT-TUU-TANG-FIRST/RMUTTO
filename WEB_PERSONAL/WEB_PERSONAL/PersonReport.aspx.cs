using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;
using System.Text;
using System.IO;
using System.Data;

namespace WEB_PERSONAL {
    public partial class PersonReport : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                BindProvinceList();
                //Row1
                DatabaseManager.BindDropDown(ddlRank, "SELECT * FROM TB_RANK", "RANK_NAME_TH", "RANK_ID", "-กรุณาเลือกยศ-");
                DatabaseManager.BindDropDown(ddlRaceCondition, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                DatabaseManager.BindDropDown(ddlNationCondition, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                DatabaseManager.BindDropDown(ddlBloodCondition, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                //Row2
                DatabaseManager.BindDropDown(ddlReligionCondition, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
                //
                DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM TB_CAMPUS", "CAMPUS_NAME", "CAMPUS_ID", "-กรุณาเลือกวิทยาเขต-");
                DatabaseManager.BindDropDown(ddlStatusWork, "SELECT * FROM TB_STATUS_WORK", "SW_NAME", "SW_ID", "-กรุณาเลือกสถานะการทำงาน-");
            }
        }

        private void BindProvinceList()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAddressProvinceCondition.DataSource = dt;
                        ddlAddressProvinceCondition.DataValueField = "PROVINCE_ID";
                        ddlAddressProvinceCondition.DataTextField = "PROVINCE_TH";
                        ddlAddressProvinceCondition.DataBind();
                        sqlConn.Close();

                        ddlAddressProvinceCondition.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAddressAmphurCondition.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlAddressDistrictCondition.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                    }
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAddressProvinceCondition2.DataSource = dt;
                        ddlAddressProvinceCondition2.DataValueField = "PROVINCE_ID";
                        ddlAddressProvinceCondition2.DataTextField = "PROVINCE_TH";
                        ddlAddressProvinceCondition2.DataBind();
                        sqlConn.Close();

                        ddlAddressProvinceCondition2.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAddressAmphurCondition2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlAddressDistrictCondition2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                    }
                }
            }
            catch { }
        }
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlAddressProvinceCondition.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAddressAmphurCondition.DataSource = dt;
                        ddlAddressAmphurCondition.DataValueField = "AMPHUR_ID";
                        ddlAddressAmphurCondition.DataTextField = "AMPHUR_TH";
                        ddlAddressAmphurCondition.DataBind();
                        sqlConn.Close();

                        ddlAddressAmphurCondition.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlAddressDistrictCondition.Items.Clear();
                        ddlAddressDistrictCondition.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
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
                        sqlCmd.Parameters.Add(":DISTRICT_ID", ddlAddressAmphurCondition.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAddressDistrictCondition.DataSource = dt;
                        ddlAddressDistrictCondition.DataValueField = "DISTRICT_ID";
                        ddlAddressDistrictCondition.DataTextField = "DISTRICT_TH";
                        ddlAddressDistrictCondition.DataBind();
                        sqlConn.Close();

                        ddlAddressDistrictCondition.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {

            //--

            /*if(!cbPsID.Checked && !cbCitizenID.Checked && !cbPsName.Checked && !cbGender.Checked && !cbAge.Checked && !cbCampus.Checked && !cbBirthdayDate.Checked && !cbStatusWork.Checked) {
                Util.Alert(this, "กรุณาเลือกข้อมูลที่ต้องการออกรายงานอย่างน้อย 1 ช่อง");
                return;
            }*/

            //--


            List<string> headList = new List<string>();
            List<int> typeList = new List<int>();
            
            // 1 = int
            // 2 = string
            // 3 = date

            bool seq = false;
            string select = "SELECT";
            if (cbPsID.Checked) {
                seq = true;
                /*select += ", PS_ID";
                headList.Add("ลำดับ");
                typeList.Add(1);*/
            }
            if (cbCitizenID.Checked) {
                select += ", PS_CITIZEN_ID";
                headList.Add("บัตรประชาชน");
                typeList.Add(2);
            }
            if (cbRank.Checked)
            {
                select += ", NVL((SELECT RANK_NAME_TH FROM TB_RANK WHERE RANK_ID = PS_RANK_ID),'-')";
                headList.Add("ยศ");
                typeList.Add(2);
            }
            if (cbNameTH.Checked) {
                select += ", PS_FN_TH || ' ' || PS_LN_TH";
                headList.Add("ชื่อภาษาไทย");
                typeList.Add(2);
            }
            if (cbNameEN.Checked)
            {
                select += ", PS_FN_EN || ' ' || PS_LN_EN";
                headList.Add("ชื่อภาษาอังกฤษ");
                typeList.Add(2);
            }
            if (cbGender.Checked)
            {
                select += ", (SELECT GENDER_NAME FROM TB_GENDER WHERE GENDER_ID = PS_GENDER_ID)";
                headList.Add("เพศ");
                typeList.Add(2);
            }
            if (cbBirthdayDate.Checked)
            {
                select += ", PS_BIRTHDAY_DATE";
                headList.Add("วันเกิด");
                typeList.Add(3);
            }
            if (cbRace.Checked)
            {
                select += ", (SELECT NATION_THA FROM TB_NATIONAL WHERE NATION_SEQ = PS_RACE_ID)";
                headList.Add("เชื้อชาติ");
                typeList.Add(2);
            }
            if (cbNation.Checked)
            {
                select += ", (SELECT NATION_THA FROM TB_NATIONAL WHERE NATION_SEQ = PS_NATION_ID)";
                headList.Add("สัญชาติ");
                typeList.Add(2);
            }
            if (cbBlood.Checked)
            {
                select += ", (SELECT BLOOD_NAME FROM TB_BLOOD WHERE BLOOD_ID = PS_BLOOD_ID)";
                headList.Add("กรุ๊ปเลือด");
                typeList.Add(2);
            }
            if (cbEmail.Checked)
            {
                select += ", PS_EMAIL";
                headList.Add("อีเมล");
                typeList.Add(2);
            }
            if (cbPhone.Checked)
            {
                select += ", PS_PHONE";
                headList.Add("เบอร์โทรศัพท์ส่วนตัว");
                typeList.Add(2);
            }
            if (cbPhoneWork.Checked)
            {
                select += ", PS_TELEPHONE_WORK";
                headList.Add("เบอร์โทรศัพท์ที่ทำงาน");
                typeList.Add(2);
            }
            if (cbReligion.Checked)
            {
                select += ", (SELECT RELIGION_NAME FROM TB_RELIGION WHERE RELIGION_ID = PS_RELIGION_ID)";
                headList.Add("ศาสนา");
                typeList.Add(2);
            }
            if (cbStatus.Checked)
            {
                select += ", (SELECT STATUS_NAME FROM TB_STATUS_PERSON WHERE STATUS_ID = PS_STATUS_ID)";
                headList.Add("สถานภาพ");
                typeList.Add(2);
            }
            if (cbNameFather.Checked)
            {
                select += ", PS_DAD_FN || ' ' || PS_DAD_LN";
                headList.Add("ชื่อบิดา");
                typeList.Add(2);
            }
            if (cbNameMother.Checked)
            {
                select += ", PS_MOM_FN || ' ' || PS_MOM_LN";
                headList.Add("ชื่อมารดา");
                typeList.Add(2);
            }
            if (cbNameCouple.Checked)
            {
                select += ", PS_LOV_FN || ' ' || PS_LOV_LN";
                headList.Add("ชื่อคู่สมรส");
                typeList.Add(2);
            }
            if (cbAddress.Checked)
            {
                select += ", 'บ้านเลขที่ ' || PS_HOMEADD || ' ซอย ' || PS_SOI || ' หมู่ ' || PS_MOO || ' ถนน ' || PS_STREET || ' ตำบล/แขวง ' || (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE DISTRICT_ID = PS_DISTRICT) || ' อำเภอ/เขต ' || (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE AMPHUR_ID = PS_AMPHUR_ID) || ' จังหวัด ' || (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE PROVINCE_ID = PS_PROVINCE_ID) || ' รหัสไปรษณีย์ ' || PS_ZIPCODE";
                headList.Add("ที่อยู่ตามทะเบียนบ้าน");
                typeList.Add(2);
            }
            if (cbAddressNow.Checked)
            {
                select += ", 'บ้านเลขที่ ' || PS_HOMEADD_NOW || ' ซอย ' || PS_SOI_NOW || ' หมู่ ' || PS_MOO_NOW || ' ถนน ' || PS_STREET_NOW || ' ตำบล/แขวง ' || (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE DISTRICT_ID = PS_DISTRICT_ID_NOW) || ' อำเภอ/เขต ' || (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE AMPHUR_ID = PS_AMPHUR_ID_NOW) || ' จังหวัด ' || (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE PROVINCE_ID = PS_PROVINCE_ID_NOW) || ' รหัสไปรษณีย์ ' || PS_ZIPCODE_NOW";
                headList.Add("ที่อยู่ปัจจุบัน");
                typeList.Add(2);
            }
            if (cbCampus.Checked)
            {
                select += ", (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE CAMPUS_ID = PS_CAMPUS_ID)";
                headList.Add("วิทยาเขต");
                typeList.Add(2);
            }
            if (cbFaculty.Checked)
            {
                select += ", (SELECT FACULTY_NAME FROM TB_FACULTY WHERE FACULTY_ID = PS_FACULTY_ID)";
                headList.Add("สำนัก / สถาบัน / คณะ");
                typeList.Add(2);
            }
            if (cbDivision.Checked)
            {
                select += ", (SELECT DIVISION_NAME FROM TB_DIVISION WHERE DIVISION_ID = PS_DIVISION_ID)";
                headList.Add("กอง / สำนักงานเลขา / ภาควิชา");
                typeList.Add(2);
            }
            if (cbWorkDivision.Checked)
            {
                select += ", (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE WORK_ID = PS_WORK_DIVISION_ID)";
                headList.Add("งาน / ฝ่าย");
                typeList.Add(2);
            }
            if (cbStafftype.Checked)
            {
                select += ", (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = PS_STAFFTYPE_ID)";
                headList.Add("ประเภทบุคลากร");
                typeList.Add(2);
            }
            if (cbBudget.Checked)
            {
                select += ", (SELECT BUDGET_NAME FROM TB_BUDGET WHERE BUDGET_ID = PS_BUDGET_ID)";
                headList.Add("ประเภทเงินจ้าง");
                typeList.Add(2);
            }
            if (cbDateInwork.Checked)
            {
                select += ", PS_INWORK_DATE";
                headList.Add("วันที่เข้าทำงาน");
                typeList.Add(3);
            }
            if (cbDateRetire.Checked)
            {
                select += ", PS_RETIRE_DATE";
                headList.Add("วันที่เกษียณ");
                typeList.Add(3);
            }
            if (cbAge.Checked) {
                select += ", FUNC_AGE(PS_BIRTHDAY_DATE)";
                headList.Add("อายุ");
                typeList.Add(2);
            }
            if (cbStatusWork.Checked)
            {
                select += ", (SELECT SW_NAME FROM TB_STATUS_WORK WHERE SW_ID = PS_SW_ID)";
                headList.Add("สถานะการทำงาน");
                typeList.Add(2);
            }
            select = select.Replace("SELECT,", "SELECT ");

            ///---------
            string where = "";
            //รหัสบัตรประชาชน
            if (cbCitizenIDCondition.Checked)
            {
                //where += " AND PS_CITIZEN_ID like '" + tbCitizenIDCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_CITIZEN_ID like '%" + tbCitizenIDCondition.Text + "%'"; //แบบ มี %
            }
            //ยศ
            if (cbRankCondition.Checked)
            {
                where += " AND PS_RANK_ID = " + ddlRank.SelectedValue;
            }
            //ชื่อไทย
            if (cbNameTHCondition.Checked)
            {
                //where += " AND PS_FN_TH like '" + tbNameFNTHCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_FN_TH like '%" + tbNameFNTHCondition.Text + "%'"; //แบบ มี %
            }
            //นามสกุลไทย
            if (cbNameTHCondition.Checked)
            {
                //where += " AND PS_LN_TH like '" + tbNameLNTHCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_LN_TH like '%" + tbNameLNTHCondition.Text + "%'"; //แบบ มี %
            }
            //ชื่ออังกฤษ
            if (cbNameENCondition.Checked)
            {
                //where += " AND PS_FN_EN like '" + tbNameFNENCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_FN_EN like '%" + tbNameFNENCondition.Text + "%'"; //แบบ มี %
            }
            //นามสกุลอังกฤษ
            if (cbNameENCondition.Checked)
            {
                //where += " AND PS_LN_EN like '" + tbNameLNENCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_LN_EN like '%" + tbNameLNENCondition.Text + "%'"; //แบบ มี %
            }
            //เพศ
            if (cbGenderCondition.Checked) {
                where += " AND PS_GENDER_ID = " + (rbMale.Checked ? "1" : "2");
            }
            //วันเกิด
            if (cbBirthdayDateCondition.Checked)
            {
                where += " AND PS_BIRTHDAY_DATE >= " + Util.DatabaseToDateSearch(tbBirthdayDateFrom.Text) + " AND PS_BIRTHDAY_DATE <= " + Util.DatabaseToDateSearch(tbBirthdayDateTo.Text);
            }
            //สัญชาติ
            if (cbRaceCondition.Checked)
            {
                where += " AND PS_RACE_ID = " + ddlRaceCondition.SelectedValue;
            }
            //เชื้อชาติ
            if (cbNationCondition.Checked)
            {
                where += " AND PS_NATION_ID = " + ddlNationCondition.SelectedValue;
            }
            //กรุ๊ปเลือด
            if (cbBloodCondition.Checked)
            {
                where += " AND PS_BLOOD_ID = " + ddlBloodCondition.SelectedValue;
            }
            //อีเมล
            if (cbEmailCondition.Checked)
            {
                //where += " AND PS_EMAIL like '" + tbEmailCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_EMAIL like '%" + tbEmailCondition.Text + "%'"; //แบบ มี %
            }
            //เบอร์โทรศัพท์ส่วนตัว
            if (cbPhoneCondition.Checked)
            {
                //where += " AND PS_PHONE like '" + tbPhoneCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_PHONE like '%" + tbPhoneCondition.Text + "%'"; //แบบ มี %
            }
            //เบอร์โทรศัพท์ที่ทำงาน
            if (cbPhoneWorkCondition.Checked)
            {
                //where += " AND PS_TELEPHONE_WORK like '" + tbPhoneWorkCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_TELEPHONE_WORK like '%" + tbPhoneWorkCondition.Text + "%'"; //แบบ มี %
            }
            //ศาสนา
            if (cbReligionCondition.Checked)
            {
                where += " AND PS_RELIGION_ID = " + ddlReligionCondition.SelectedValue;
            }
            //สถานภาพ
            if (cbStatusCondition.Checked)
            {
                where += " AND PS_STATUS_ID = " + (rbSingle.Checked ? "1" : rbMarried.Checked ? "2" : rbLeftAlone.Checked ? "3" : "4");
            }
            //ชื่อบิดา
            if (cbNameFatherCondition.Checked)
            {
                //where += " AND PS_DAD_FN like '" + tbFNFatherCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_DAD_FN like '%" + tbFNFatherCondition.Text + "%'"; //แบบ มี %
            }
            //นามสกุลบิดา
            if (cbNameFatherCondition.Checked)
            {
                //where += " AND PS_DAD_LN like '" + tbLNFatherCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_DAD_LN like '%" + tbLNFatherCondition.Text + "%'"; //แบบ มี %
            }
            //ชื่อมารดา
            if (cbNameMotherCondition.Checked)
            {
                //where += " AND PS_MOM_FN like '" + tbFNMotherCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_MOM_FN like '%" + tbFNMotherCondition.Text + "%'"; //แบบ มี %
            }
            //นามสกุลมารดา
            if (cbNameMotherCondition.Checked)
            {
                //where += " AND PS_MOM_LN like '" + tbLNMotherCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_MOM_LN like '%" + tbLNMotherCondition.Text + "%'"; //แบบ มี %
            }
            //ชื่อคู่สมรส
            if (cbNameCoupleCondition.Checked)
            {
                //where += " AND PS_LOV_FN like '" + tbFNCoupleCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_LOV_FN like '%" + tbFNCoupleCondition.Text + "%'"; //แบบ มี %
            }
            //นามสกุลคู่สมรส
            if (cbNameCoupleCondition.Checked)
            {
                //where += " AND PS_LOV_LN like '" + tbLNCoupleCondition.Text + "'"; //แบบไม่มี %
                where += " AND PS_LOV_LN like '%" + tbLNCoupleCondition.Text + "%'"; //แบบ มี %
            }
            //ที่อยู่ตามทะเบียนบ้าน จังหวัด
            if (cbAddressCondition.Checked && ddlAddressProvinceCondition.SelectedIndex != 0)
            {
                where += " AND PS_PROVINCE_ID = " + ddlAddressProvinceCondition.SelectedValue;
            }
            //ที่อยู่ตามทะเบียนบ้าน อำเภอ
            if (cbAddressCondition.Checked && ddlAddressAmphurCondition.SelectedIndex != 0)
            {
                where += " AND PS_AMPHUR_ID = " + ddlAddressAmphurCondition.SelectedValue;
            }
            //ที่อยู่ตามทะเบียนบ้าน ตำบล
            if (cbAddressCondition.Checked && ddlAddressDistrictCondition.SelectedIndex != 0)
            {
                where += " AND PS_DISTRICT = " + ddlAddressDistrictCondition.SelectedValue;
            }
            //ที่อยู่ตามทะเบียนบ้าน
            //ที่อยู๋ปัจจุบัน
            //วิทยาเขต
            //สำนัก / สถาบัน / คณะ
            //กอง / สำนักงานเลขา / ภาควิชา
            //งาน / ฝ่าย
            //ประเภทบุคลากร
            //ประเภทเงินจ้าง
            //วันที่เข้าทำงาน
            //วันที่เกษียณ
            //อายุ
            //สถานะการทำงาน
            if (cbAgeCondition.Checked) {
                where += " AND FUNC_AGE(PS_BIRTHDAY_DATE) >= " + tbAgeConditionFrom.Text + " AND FUNC_AGE(PS_BIRTHDAY_DATE) <= " + tbAgeConditionTo.Text;
            }
            if (cbCampusCondition.Checked) {
                where += " AND PS_CAMPUS_ID = " + ddlCampus.SelectedValue;
            }
            
            if (cbStatusWorkCondition.Checked)
            {
                where += " AND PS_SW_ID = " + ddlStatusWork.SelectedValue;
            }
            tb.Rows.Clear();
  
            {
                TableHeaderRow row = new TableHeaderRow();
                if (seq) {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                for (int i = 0; i < headList.Count; i++) {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = headList[i];
                    row.Cells.Add(cell);
                }
                tb.Rows.Add(row);
            }
            
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(select + " FROM PS_PERSON WHERE 1=1" + where, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        int j = 1;
                        while (reader.Read()) {
                            TableRow row = new TableRow();
                            if (seq) {
                                TableCell cell = new TableCell();
                                cell.Text = "" + j;
                                row.Cells.Add(cell);
                            }
                            for (int i = 0; i < typeList.Count; i++) {
                                TableCell cell = new TableCell();
                                if (typeList[i] == 1) {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetInt32(i).ToString();
                                } else if (typeList[i] == 2) {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetString(i);
                                } else {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToLongDateString();
                                }
                                row.Cells.Add(cell);
                            }
                            tb.Rows.Add(row);
                            ++j;
                        }
                    }
                }
            }

            Session["PersonReportTable"] = tb;
        }

        protected void lbuExport_Click(object sender, EventArgs e) {
            /*for (int i = 0; i < 5; i++) {
                tb.Rows[0].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 0; i < 15; i++) {
                tb.Rows[1].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 2; i < tb.Rows.Count; i++) {
                for (int j = 0; j < 15; j++) {
                    tb.Rows[i].Cells[j].Style.Add("border", "1px solid #000000");
                }
            }*/

             Response.ContentType = "application/x-msexcel";
             Response.AddHeader("Content-Disposition", "attachment;filename=PersonReport.xls");
             Response.ContentEncoding = Encoding.UTF8;
             StringWriter tw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(tw);
             ((Table)Session["PersonReportTable"]).RenderControl(hw);
             Response.Write(tw.ToString());
             Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control) {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lbuExport2_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < 5; i++)
            {
                tb.Rows[0].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 0; i < 15; i++)
            {
                tb.Rows[1].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 2; i < tb.Rows.Count; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tb.Rows[i].Cells[j].Style.Add("border", "1px solid #000000");
                }
            }*/

            Response.ContentType = "application/x-msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=PersonReport.doc");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ((Table)Session["PersonReportTable"]).RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}