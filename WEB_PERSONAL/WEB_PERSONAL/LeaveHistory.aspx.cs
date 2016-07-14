﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class LeaveHistory : System.Web.UI.Page {
        private Person loginPerson;
        protected void Page_Load(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            loginPerson = ps.LoginPerson;

            FuncGVFinish();
            FuncGVProcessing();
            FuncGVHistory();
            FuncGVCL();
            FuncGVCH();
            FuncLeaveClaim();
        }

        protected void lbuVS1_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
            lbuVS1.CssClass = "ps-vs-sel";
            lbuVS2.CssClass = "ps-vs";
            lbuVS3.CssClass = "ps-vs";
        }

        protected void lbuVS2_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
            lbuVS1.CssClass = "ps-vs";
            lbuVS2.CssClass = "ps-vs-sel";
            lbuVS3.CssClass = "ps-vs";
        }

        protected void lbuVS3_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
            lbuVS1.CssClass = "ps-vs";
            lbuVS2.CssClass = "ps-vs";
            lbuVS3.CssClass = "ps-vs-sel";
        }

        protected void gvHistory_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvHistory.PageIndex = e.NewPageIndex;
            FuncGVHistory();
        }
        protected void gvProgressing_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvProgressing.PageIndex = e.NewPageIndex;
            FuncGVProcessing();
        }

        protected void gvFinish_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvFinish.PageIndex = e.NewPageIndex;
            FuncGVFinish();
        }

        protected void gvCL_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvCL.PageIndex = e.NewPageIndex;
            FuncGVCL();
        }

        protected void gvCH_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvCH.PageIndex = e.NewPageIndex;
            FuncGVCH();
        }

        private void FuncGVFinish() {

            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) ประเภทการลา, REQ_DATE วันที่ข้อมูล, FROM_DATE จากวันที่, TO_DATE ถึงวันที่, TOTAL_DAY รวมวัน, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) สถานะ, NVL(CH_ALLOW,0) ผลการอนุมัติ FROM LEV_DATA WHERE LEAVE_STATUS_ID in(3,7) AND PS_ID = '" + loginPerson.CitizenID + "' ORDER BY LEAVE_ID DESC");
            gvFinish.DataSource = sds;
            gvFinish.DataBind();

            if (gvFinish.Rows.Count > 0) {
                lbFinish.Visible = false;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "ตกลง";
                gvFinish.HeaderRow.Cells.Add(headerCell);

                gvFinish.HeaderRow.Cells[0].Text = "<img src='Image/Small/ID.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[0].Text;
                gvFinish.HeaderRow.Cells[1].Text = "<img src='Image/Small/list.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[1].Text;
                gvFinish.HeaderRow.Cells[2].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[2].Text;
                gvFinish.HeaderRow.Cells[3].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[3].Text;
                gvFinish.HeaderRow.Cells[4].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[4].Text;
                gvFinish.HeaderRow.Cells[6].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[6].Text;
                gvFinish.HeaderRow.Cells[7].Text = "<img src='Image/Small/correct.png' class='icon_left'/>" + gvFinish.HeaderRow.Cells[7].Text;

                for (int i = 0; i < gvFinish.Rows.Count; ++i) {
                    string ID = gvFinish.Rows[i].Cells[0].Text;
                    TableCell cell = new TableCell();
                    LinkButton btn = new LinkButton();
                    btn.CssClass = "ps-button-img";
                    btn.Text = "ตกลง";
                    btn.Click += (e2, e3) => {
                        LeaveData leaveData = new LeaveData();
                        leaveData.Load(int.Parse(ID));

                        if (leaveData.LeaveStatusID == 3) {
                            DatabaseManager.ExecuteNonQuery("UPDATE LEV_DATA SET LEAVE_STATUS_ID = 4 WHERE LEAVE_ID = " + ID);
                        } else if (leaveData.LeaveStatusID == 7) {
                            DatabaseManager.ExecuteNonQuery("UPDATE LEV_DATA SET LEAVE_STATUS_ID = 8 WHERE LEAVE_ID = " + ID);
                        }
                        Response.Redirect("LeaveHistory.aspx");
                    };
                    cell.Controls.Add(btn);
                    gvFinish.Rows[i].Cells.Add(cell);

                    if (Util.StringEqual(gvFinish.Rows[i].Cells[7].Text, new string[] { "0" })) {
                        gvFinish.Rows[i].Cells[7].Text = "ไม่อนุมัติ";
                        gvFinish.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                    }
                    if (Util.StringEqual(gvFinish.Rows[i].Cells[7].Text, new string[] { "1" })) {
                        gvFinish.Rows[i].Cells[7].Text = "อนุมัติ";
                        gvFinish.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Green;
                    }
                }

                Util.NormalizeGridViewDate(gvFinish, 2);
                Util.NormalizeGridViewDate(gvFinish, 3);
                Util.NormalizeGridViewDate(gvFinish, 4);
            } else {
                lbFinish.Visible = true;
            }
        }
        private void FuncGVProcessing() {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) ประเภทการลา, REQ_DATE วันที่ข้อมูล, FROM_DATE จากวันที่, TO_DATE ถึงวันที่, TOTAL_DAY รวมวัน, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) สถานะ FROM LEV_DATA WHERE LEAVE_STATUS_ID in(1,2,5,6) AND PS_ID = '" + loginPerson.CitizenID + "' ORDER BY LEAVE_ID DESC");
            gvProgressing.DataSource = sds;
            gvProgressing.DataBind();

            if (gvProgressing.Rows.Count > 0) {
                lbProgressing.Visible = false;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "ดูข้อมูล";
                gvProgressing.HeaderRow.Cells.Add(headerCell);

                gvProgressing.HeaderRow.Cells[0].Text = "<img src='Image/Small/ID.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[0].Text;
                gvProgressing.HeaderRow.Cells[1].Text = "<img src='Image/Small/list.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[1].Text;
                gvProgressing.HeaderRow.Cells[2].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[2].Text;
                gvProgressing.HeaderRow.Cells[3].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[3].Text;
                gvProgressing.HeaderRow.Cells[4].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[4].Text;
                gvProgressing.HeaderRow.Cells[6].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + gvProgressing.HeaderRow.Cells[6].Text;

                for (int i = 0; i < gvProgressing.Rows.Count; ++i) {
                    string ID = gvProgressing.Rows[i].Cells[0].Text;
                    TableCell cell = new TableCell();
                    LinkButton btn = new LinkButton();
                    btn.CssClass = "ps-button-img";
                    btn.Text = "<img src='Image/Small/search.png'></img>";
                    btn.Click += (e2, e3) => {
                        Response.Redirect("ViewLeaveForm.aspx?LeaveID=" + ID);
                    };
                    cell.Controls.Add(btn);
                    gvProgressing.Rows[i].Cells.Add(cell);

                }

                Util.NormalizeGridViewDate(gvProgressing, 2);
                Util.NormalizeGridViewDate(gvProgressing, 3);
                Util.NormalizeGridViewDate(gvProgressing, 4);
            } else {
                lbProgressing.Visible = true;
            }
        }
        private void FuncGVHistory() {

            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) ประเภทการลา, REQ_DATE วันที่ข้อมูล, FROM_DATE จากวันที่, TO_DATE ถึงวันที่, TOTAL_DAY รวมวัน, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) สถานะ, NVL(CH_ALLOW,-1) ผลการอนุมัติ FROM LEV_DATA WHERE LEAVE_STATUS_ID in(4,8,9) AND PS_ID = '" + loginPerson.CitizenID + "' ORDER BY LEAVE_ID DESC");
            gvHistory.DataSource = sds;
            gvHistory.DataBind();

            if (gvHistory.Rows.Count > 0) {
                lbHistory.Visible = false;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "ดูข้อมูล";
                gvHistory.HeaderRow.Cells.Add(headerCell);

                gvHistory.HeaderRow.Cells[0].Text = "<img src='Image/Small/ID.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[0].Text;
                gvHistory.HeaderRow.Cells[1].Text = "<img src='Image/Small/list.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[1].Text;
                gvHistory.HeaderRow.Cells[2].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[2].Text;
                gvHistory.HeaderRow.Cells[3].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[3].Text;
                gvHistory.HeaderRow.Cells[4].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[4].Text;
                gvHistory.HeaderRow.Cells[6].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[6].Text;
                gvHistory.HeaderRow.Cells[7].Text = "<img src='Image/Small/correct.png' class='icon_left'/>" + gvHistory.HeaderRow.Cells[7].Text;

                for (int i = 0; i < gvHistory.Rows.Count; ++i) {
                    string ID = gvHistory.Rows[i].Cells[0].Text;
                    TableCell cell = new TableCell();
                    LinkButton btn = new LinkButton();
                    btn.CssClass = "ps-button-img";
                    btn.Text = "<img src='Image/Small/search.png'></img>";
                    btn.Click += (e2, e3) => {
                        Response.Redirect("ViewLeaveForm.aspx?LeaveID=" + ID);
                    };
                    cell.Controls.Add(btn);
                    gvHistory.Rows[i].Cells.Add(cell);

                    if (Util.StringEqual(gvHistory.Rows[i].Cells[7].Text, new string[] { "-1" })) {
                        gvHistory.Rows[i].Cells[7].Text = "-";
                        gvHistory.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Black;
                    }
                    if (Util.StringEqual(gvHistory.Rows[i].Cells[7].Text, new string[] { "0" })) {
                        gvHistory.Rows[i].Cells[7].Text = "ไม่อนุมัติ";
                        gvHistory.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                    }
                    if (Util.StringEqual(gvHistory.Rows[i].Cells[7].Text, new string[] { "1" })) {
                        gvHistory.Rows[i].Cells[7].Text = "อนุมัติ";
                        gvHistory.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Green;
                    }
                }

                Util.NormalizeGridViewDate(gvHistory, 2);
                Util.NormalizeGridViewDate(gvHistory, 3);
                Util.NormalizeGridViewDate(gvHistory, 4);
            } else {
                lbHistory.Visible = true;
            }


        }
        private void FuncGVCL() {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) ประเภทการลา, REQ_DATE วันที่ข้อมูล,  (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = LEV_DATA.PS_ID) ชื่อผู้ลา, (SELECT TB_POSITION.NAME FROM TB_POSITION, PS_PERSON WHERE TB_POSITION.ID = PS_PERSON.PS_POSITION_ID AND PS_PERSON.PS_CITIZEN_ID = LEV_DATA.PS_ID) ตำแหน่ง, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION, PS_PERSON WHERE ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID AND PS_PERSON.PS_CITIZEN_ID = LEV_DATA.PS_ID) ระดับ, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) สถานะ, NVL(CH_ALLOW,-1) ผลการอนุมัติ FROM LEV_DATA WHERE CL_ID = '" + loginPerson.CitizenID + "' ORDER BY LEAVE_ID DESC");
            gvCL.DataSource = sds;
            gvCL.DataBind();

            if (gvCL.Rows.Count > 0) {
                lbCL.Visible = false;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "ดูข้อมูล";
                gvCL.HeaderRow.Cells.Add(headerCell);

                gvCL.HeaderRow.Cells[0].Text = "<img src='Image/Small/ID.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[0].Text;
                gvCL.HeaderRow.Cells[1].Text = "<img src='Image/Small/list.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[1].Text;
                gvCL.HeaderRow.Cells[2].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[2].Text;
                gvCL.HeaderRow.Cells[3].Text = "<img src='Image/Small/person2.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[3].Text;
                gvCL.HeaderRow.Cells[6].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[6].Text;
                gvCL.HeaderRow.Cells[7].Text = "<img src='Image/Small/correct.png' class='icon_left'/>" + gvCL.HeaderRow.Cells[7].Text;

                for (int i = 0; i < gvCL.Rows.Count; ++i) {
                    string ID = gvCL.Rows[i].Cells[0].Text;
                    TableCell cell = new TableCell();
                    LinkButton btn = new LinkButton();
                    btn.CssClass = "ps-button-img";
                    btn.Text = "<img src='Image/Small/search.png'></img>";
                    btn.Click += (e2, e3) => {
                        Response.Redirect("ViewLeaveForm.aspx?LeaveID=" + ID);
                    };
                    cell.Controls.Add(btn);
                    gvCL.Rows[i].Cells.Add(cell);

                    if (Util.StringEqual(gvCL.Rows[i].Cells[7].Text, new string[] { "-1" })) {
                        gvCL.Rows[i].Cells[7].Text = "-";
                        gvCL.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Black;
                    }
                    if (Util.StringEqual(gvCL.Rows[i].Cells[7].Text, new string[] { "0" })) {
                        gvCL.Rows[i].Cells[7].Text = "ไม่อนุมัติ";
                        gvCL.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                    }
                    if (Util.StringEqual(gvCL.Rows[i].Cells[7].Text, new string[] { "1" })) {
                        gvCL.Rows[i].Cells[7].Text = "อนุมัติ";
                        gvCL.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Green;
                    }
                }

                Util.NormalizeGridViewDate(gvCL, 2);
            } else {
                lbCL.Visible = true;
            }
        }
        private void FuncGVCH() {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) ประเภทการลา, REQ_DATE วันที่ข้อมูล,  (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = LEV_DATA.PS_ID) ชื่อผู้ลา, (SELECT TB_POSITION.NAME FROM TB_POSITION, PS_PERSON WHERE TB_POSITION.ID = PS_PERSON.PS_POSITION_ID AND PS_PERSON.PS_CITIZEN_ID = LEV_DATA.PS_ID) ตำแหน่ง, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION, PS_PERSON WHERE ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID AND PS_PERSON.PS_CITIZEN_ID = LEV_DATA.PS_ID) ระดับ, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) สถานะ, NVL(CH_ALLOW,-1) ผลการอนุมัติ FROM LEV_DATA WHERE CH_ID = '" + loginPerson.CitizenID + "' ORDER BY LEAVE_ID DESC");
            gvCH.DataSource = sds;
            gvCH.DataBind();

            if (gvCH.Rows.Count > 0) {
                lbCH.Visible = false;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "ดูข้อมูล";
                gvCH.HeaderRow.Cells.Add(headerCell);

                gvCH.HeaderRow.Cells[0].Text = "<img src='Image/Small/ID.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[0].Text;
                gvCH.HeaderRow.Cells[1].Text = "<img src='Image/Small/list.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[1].Text;
                gvCH.HeaderRow.Cells[2].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[2].Text;
                gvCH.HeaderRow.Cells[3].Text = "<img src='Image/Small/person2.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[3].Text;
                gvCH.HeaderRow.Cells[6].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[6].Text;
                gvCH.HeaderRow.Cells[7].Text = "<img src='Image/Small/correct.png' class='icon_left'/>" + gvCH.HeaderRow.Cells[7].Text;

                for (int i = 0; i < gvCH.Rows.Count; ++i) {
                    string ID = gvCH.Rows[i].Cells[0].Text;
                    TableCell cell = new TableCell();
                    LinkButton btn = new LinkButton();
                    btn.CssClass = "ps-button-img";
                    btn.Text = "<img src='Image/Small/search.png'></img>";
                    btn.Click += (e2, e3) => {
                        Response.Redirect("ViewLeaveForm.aspx?LeaveID=" + ID);
                    };
                    cell.Controls.Add(btn);
                    gvCH.Rows[i].Cells.Add(cell);

                    if (Util.StringEqual(gvCH.Rows[i].Cells[7].Text, new string[] { "-1" })) {
                        gvCH.Rows[i].Cells[7].Text = "-";
                        gvCH.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Black;
                    }
                    if (Util.StringEqual(gvCH.Rows[i].Cells[7].Text, new string[] { "0" })) {
                        gvCH.Rows[i].Cells[7].Text = "ไม่อนุมัติ";
                        gvCH.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                    }
                    if (Util.StringEqual(gvCH.Rows[i].Cells[7].Text, new string[] { "1" })) {
                        gvCH.Rows[i].Cells[7].Text = "อนุมัติ";
                        gvCH.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Green;
                    }
                }

                Util.NormalizeGridViewDate(gvCH, 2);
            } else {
                lbCH.Visible = true;
            }
        }
        private void FuncLeaveClaim() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (YEAR+543), SICK_NOW, SICK_REQ, SICK_MAX, BUSINESS_NOW, BUSINESS_REQ, BUSINESS_MAX, GB_NOW, GB_REQ, HGB_NOW, HGB_REQ, REST_NOW, REST_REQ, REST_SAVE, REST_SAVE_FIX, REST_THIS, REST_THIS_FIX, REST_MAX, ORDAIN_NOW, ORDAIN_REQ, ORDAIN_MAX, HUJ_NOW, HUJ_REQ, HUJ_MAX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            TableRow r = new TableRow();
                            TableCell c;
                            for (int i = 0; i < 24; i++) {
                                c = new TableCell();
                                c.Text = reader.GetValue(i).ToString();
                                r.Cells.Add(c);
                            }

                            Table1.Rows.Add(r);
                        }
                    }
                }
            }
        }

        
    }
}