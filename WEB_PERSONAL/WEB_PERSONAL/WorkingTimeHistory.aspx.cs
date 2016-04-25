﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class WorkingTimeHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DatabaseManager.BindDropDown(ddlKa, "SELECT * FROM LEV_WORKTIME_SEC", "WORKTIME_SEC_NAME", "WORKTIME_SEC_ID", "--กรุณาเลือกกะงาน--");
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT WORKTIME_ID รหัส, LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID ORDER BY WORKTIME_ID DESC");
                GridView1.DataSource = sds;
                GridView1.DataBind();
                //Util.NormalizeGridViewDate7D(GridView1, 3);
            }
        }

        protected void lbuShowAll_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT WORKTIME_ID, LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuShowLateIn_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND LATE_IN > 0");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuShowLateOut_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND LATE_OUT > 0");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuShowAbsent_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND ABSENT = 1");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuSearchKa_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND LEV_WORKTIME.WORKTIME_SEC_ID = " + ddlKa.SelectedValue);
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuSearchCitizenID_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND CITIZEN_ID = '" + tbCitizenID.Text + "'");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuSearchDate_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID AND TODAY = TO_DATE('" + tbDate.Text + "', 'DD MON YYYY')");
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }
    }
}