using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class WorkingTimeManager : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                DatabaseManager.BindDropDown(ddlVX1WorktimeSec, "SELECT * FROM LEV_WORKTIME_SEC ORDER BY WORKTIME_SEC_ID ASC", "WORKTIME_SEC_NAME", "WORKTIME_SEC_ID", "--กรุณาเลือกกะงาน--");
                DatabaseManager.BindDropDown(ddlEditKa, "SELECT * FROM LEV_WORKTIME_SEC ORDER BY WORKTIME_SEC_ID ASC", "WORKTIME_SEC_NAME", "WORKTIME_SEC_ID", "--กรุณาเลือกกะงาน--");
            }

            BindGV("SELECT WORKTIME_ID รหัส, LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID ORDER BY WORKTIME_ID DESC");
        }

        private void BindGV(string sql) {
            DatabaseManager.BindGridView(gv1, sql);

            if (gv1.Rows.Count > 0) {
                lbuVX1DeleteSelected.Visible = true;
                Util.GridViewAddCheckBox(gv1);

                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "จัดการ";
                gv1.HeaderRow.Cells.Add(headerCell);

                for (int i = 0; i < gv1.Rows.Count; ++i) {
                    string ID = gv1.Rows[i].Cells[0].Text;
                    {
                        TableCell cell = new TableCell();
                        {
                            LinkButton btn = new LinkButton();
                            btn.CssClass = "ps-button-img";
                            btn.Text = "<img src='Image/Small/document-edit.png'></img>";
                            btn.Click += (e2, e3) => {
                                MultiView1.ActiveViewIndex = 1;
                                //Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                            };
                            cell.Controls.Add(btn);
                        }
                        {
                            LinkButton btn = new LinkButton();
                            btn.CssClass = "ps-button-img";
                            btn.Text = "<img src='Image/Small/bin.png'></img>";
                            btn.Click += (e2, e3) => {
                                //Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                            };
                            cell.Controls.Add(btn);
                        }


                        gv1.Rows[i].Cells.Add(cell);
                    }

                    if (Util.StringEqual(gv1.Rows[i].Cells[8].Text, new string[] { "0", "", ":", " ", "&nbsp;" })) {
                        gv1.Rows[i].Cells[8].Text = "-";
                    }

                    if (Util.StringEqual(gv1.Rows[i].Cells[9].Text, new string[] { "0", "", ":", " ", "&nbsp;" })) {
                        gv1.Rows[i].Cells[9].Text = "-";
                    }

                    if (Util.StringEqual(gv1.Rows[i].Cells[10].Text, new string[] { "0", "", ":", " ", "&nbsp;" })) {
                        gv1.Rows[i].Cells[10].Text = "-";
                    }

                    if (Util.StringEqual(gv1.Rows[i].Cells[11].Text, new string[] { "0", "", ":", " ", "&nbsp;" })) {
                        gv1.Rows[i].Cells[11].Text = "-";
                    }

                    if (gv1.Rows[i].Cells[12].Text == "0") {
                        gv1.Rows[i].Cells[12].Text = "-";
                    } else {
                        gv1.Rows[i].Cells[12].Text = "ขาด";
                    }

                }

                Util.NormalizeGridViewDate(gv1, 4);

            } else {
                lbuVX1DeleteSelected.Visible = false;
            }
        }

        protected void ddlVX1WorktimeSec_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlVX1WorktimeSec.SelectedIndex == 0) {
                lbVX1WorkTimeTime.Text = "";
                lbVX1WorkTimeDes.Text = "";
                return;
            }
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_WORKTIME_SEC WHERE WORKTIME_SEC_ID = " + ddlVX1WorktimeSec.SelectedValue, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            string shi = int.Parse(reader.GetValue(1).ToString()).ToString("00");
                            string smi = int.Parse(reader.GetValue(2).ToString()).ToString("00");
                            string sho = int.Parse(reader.GetValue(3).ToString()).ToString("00");
                            string smo = int.Parse(reader.GetValue(4).ToString()).ToString("00");
                            string time = shi + ":" + smi + " - " + sho + ":" + smo;
                            string des = reader.GetValue(6).ToString();
                            lbVX1WorkTimeTime.Text = time;
                            lbVX1WorkTimeDes.Text = des;
                            hfHI.Value = shi;
                            hfMI.Value = smi;
                            hfHO.Value = sho;
                            hfMO.Value = smo;
                        }
                    }
                }
            }
        }

        protected void lbuAdd_Click(object sender, EventArgs e) {
            if (cbVX1Late.Checked) {
   
                string sql = "INSERT INTO LEV_WORKTIME(WORKTIME_ID, CITIZEN_ID, TODAY, WORKTIME_SEC_ID, HOUR_IN, MINUTE_IN, HOUR_OUT, MINUTE_OUT, ABSENT, \"COMMENT\", LATE_IN, LATE_OUT) VALUES({0},'{1}',{2},{3},{4},{5},{6},{7},{8},'{9}',{10},{11})";
                sql = string.Format(sql, "SEQ_WORKTIME_ID.NEXTVAL", tbVX1CitizenID.Text, Util.DatabaseToDate(tbVX1Date.Text), ddlVX1WorktimeSec.SelectedValue, "''", "''", "''", "''", 1, tbVX1Comment.Text, "''", "''");

            } else {

                int hi = int.Parse(hfHI.Value);
                int mi = int.Parse(hfMI.Value);
                int ci = hi * 60 + mi;
                int ho = int.Parse(hfHO.Value);
                int mo = int.Parse(hfMO.Value);
                int co = ho * 60 + mo;

                int phi = int.Parse(tbVX1HourIn.Text);
                int pmi = int.Parse(tbVX1MinuteIn.Text);
                int pci = phi * 60 + pmi;
                int pho = int.Parse(tbVX1HourOut.Text);
                int pmo = int.Parse(tbVX1MinuteOut.Text);
                int pco = pho * 60 + pmo;

                int vi = pci - ci;
                int vo = co - pco;


                string sql = "INSERT INTO LEV_WORKTIME(WORKTIME_ID, CITIZEN_ID, TODAY, WORKTIME_SEC_ID, HOUR_IN, MINUTE_IN, HOUR_OUT, MINUTE_OUT, ABSENT, \"COMMENT\", LATE_IN, LATE_OUT) VALUES({0},'{1}',{2},{3},{4},{5},{6},{7},{8},'{9}',{10},{11})";
                sql = string.Format(sql, "SEQ_WORKTIME_ID.NEXTVAL", tbVX1CitizenID.Text, Util.DatabaseToDate(tbVX1Date.Text), ddlVX1WorktimeSec.SelectedValue, tbVX1HourIn.Text, tbVX1MinuteIn.Text, tbVX1HourOut.Text, tbVX1MinuteOut.Text, 0, tbVX1Comment.Text, vi, vo);
 
 
            }
        }

        protected void ddlEditKa_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void lbuEditBack_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuEditFinish_Click(object sender, EventArgs e) {

        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            string sql = "SELECT WORKTIME_ID รหัส, LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID";
            if(tbSearchCitizenID.Text != "") {
                sql += " AND CITIZEN_ID = '" + tbSearchCitizenID.Text + "'";
            }
            if (tbSearchDate.Text != "") {
                sql += " AND TODAY = '" + Util.DatabaseToDateSearch(tbSearchDate.Text) + "'";
            }
            sql += " ORDER BY WORKTIME_ID DESC";
            BindGV(sql);
        }
    }
}