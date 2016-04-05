using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;

namespace WEB_PERSONAL {
    public partial class LeaveAllow : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                i2.Style.Add("display", "none");
                i3.Style.Add("display", "none");
            }

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            int count = DatabaseManager.GetLeaveRequiredCountByCommanderHigh(loginPerson.CitizenID);
           /* using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEAVE_ID) FROM LEV_LEAVE WHERE CMD_HIGH_ID = '" + loginPerson.CitizenID + "' AND LEV_LEAVE.STATE_ID = 2", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }*/
            if (count == 0) {
                error_area.InnerHtml = "ไม่มีรายการที่ท่านต้องอนุมัติ";
            } else {
                error_area.InnerHtml = "กรุณาเลือกรายการที่ต้องการอนุมัติ";
            }
            error_area.Attributes["class"] = "alert alert_info";

            if (count > 0) {

                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.* FROM LEV_MAIN, LEV_FORM1 WHERE LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND LEAVE_STATE = 2 AND CMD_HIGH_ID = '" + loginPerson.CitizenID + "'");
                GridView1.DataSource = sds;
                GridView1.DataBind();

                TableCell newHeader = new TableCell();
                newHeader.Text = "เลือก";
                GridView1.HeaderRow.Cells.Add(newHeader);

                for (int i = 0; i < GridView1.Rows.Count; ++i) {

                    string id = GridView1.Rows[i].Cells[0].Text;
                    Form1Package f1 = DatabaseManager.GetForm1Package(id);

                    LinkButton lbu = new LinkButton();
                    lbu.Text = "เลือก";
                    lbu.CssClass = "button button_default";
                    lbu.Click += (e2, e3) => {

                        lbLeaveID.Text = id;
                        /*lbLeaverName.Text = name;
                        lbReqDate.Text = req_date;
                        lbLeaveTypeName.Text = leave_type_name;
                        lbFromDate.Text = from_date;
                        lbToDate.Text = to_date;
                        lbTotalDay.Text = total_day + " วัน";
                        lbReason.Text = reason;*/

                        /*lbF1LeaveID.Text = id;
                        //lbF1LeaverName.Text = name;

                        lbF1PersonPosition.Text = f1.PersonPosition;
                        lbF1PersonDepartment.Text = f1.PersonDepartment;
                        lbF1PersonRank.Text = f1.PersonRank;
                        //lbF1ReqDate.Text = req_date;
                        //lbF1LeaveTypeName.Text = leave_type_name;
                        if (f1.LastFromDate == "''") {
                            lbF1LastFTTDate.Text = "ยังไม่เคยลา";
                        } else {
                            lbF1LastFTTDate.Text = f1.LastFromDate + " - " + f1.LastToDate + " / รวม " + f1.LastTotalDay + " วัน";
                        }

                        lbF1FTTDate.Text = f1.FromDate + " - " + f1.ToDate + " / รวม " + f1.TotalDay + " วัน";

                        lbF1Reason.Text = f1.Reason;
                        lbF1Contact.Text = f1.Contact;
                        lbF1Phone.Text = f1.Phone;*/

                        i1.Style.Add("display", "none");
                        i2.Style.Add("display", "block");
                        i3.Style.Add("display", "none");
                        error_area.Attributes["class"] = "alert alert_info";
                        error_area.InnerHtml = "กรุณาลงความเห็น";
                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    GridView1.Rows[i].Cells.Add(cell);
                }


                /*HTable htable = new HTable(i1);
                htable.AddHeaderRow(new string[] { "รหัสการลา", "ผู้ลา", "วันที่ยื่นเรื่อง", "ประเภทการลา", "จากวันที่", "ถึงวันที่", "รวมวัน", "เหตุผล", "สถานะ", "เลือก" });
                using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand("SELECT LEAVE_ID, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE CITIZEN_ID = LEV_LEAVE.CITIZEN_ID), REQ_DATE, LEAVE_TYPE_NAME, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, LEAVE_STATE_NAME FROM LEV_LEAVE, LEV_TYPE, LEV_STATE WHERE CMD_HIGH_ID = '" + loginPerson.CitizenID + "' AND LEV_LEAVE.LEAVE_TYPE_ID = LEV_TYPE.LEAVE_TYPE_ID AND LEV_LEAVE.STATE_ID = LEV_STATE.LEAVE_STATE_ID AND LEV_LEAVE.STATE_ID = 3", con)) {
                        using (OleDbDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                string id = reader.GetValue(0).ToString();
                                string name = reader.GetValue(1).ToString();
                                string req_date = Util.ToOracleDateTime(reader.GetDateTime(2));
                                string leave_type_name = reader.GetValue(3).ToString();
                                string from_date = Util.ToOracleDateTime(reader.GetDateTime(4));
                                string to_date = Util.ToOracleDateTime(reader.GetDateTime(5));
                                string total_day = reader.GetValue(6).ToString();
                                string reason = reader.GetValue(7).ToString();
                                string state = reader.GetValue(8).ToString();
                                htable.AddRow(new string[] {
                                id,
                                name,
                                req_date,
                                leave_type_name,
                                from_date,
                                to_date,
                                total_day,
                                reason,
                                state
                            });
                                LinkButton b = new LinkButton();
                                b.Text = "เลือก";
                                b.CssClass = "hm_button_primary";
                                b.Click += (e2, e3) => {
                                    lbLeaveID.Text = id;
                                    lbLeaverName.Text = name;
                                    lbReqDate.Text = req_date;
                                    lbLeaveTypeName.Text = leave_type_name;
                                    lbFromDate.Text = from_date;
                                    lbToDate.Text = to_date;
                                    lbTotalDay.Text = total_day + " วัน";
                                    lbReason.Text = reason;
                                    i1.Style.Add("display", "none");
                                    i2.Style.Add("display", "block");
                                    i3.Style.Add("display", "none");
                                    error_area.Attributes["class"] = "hm_alert_info";
                                    error_area.InnerHtml = "กรุณาเลือกการอนุมัติ";
                                };
                                TableCell c = new TableCell();
                                c.Controls.Add(b);
                                htable.LastestRow().Cells.Add(c);
                            }
                        }
                    }
                }*/
            }
        }

        protected void lbuAddComment_Click(object sender, EventArgs e) {
            if (tbComment.Text == "" || (!rbAllow.Checked && !rbNotAllow.Checked)) {
                error_area.Attributes["class"] = "alert alert_danger";
                error_area.InnerHtml = "";
                error_area.InnerHtml += "<strong>เกิดข้อผิดพลาด!</strong><br>";
                if (tbComment.Text == "") {
                    error_area.InnerHtml += "<div class='hm_tab'></div>- กรุณากรอก <strong>ความเห็น</strong><br>";
                }
                if (!rbAllow.Checked && !rbNotAllow.Checked) {
                    error_area.InnerHtml += "<div class='hm_tab'></div>- กรุณาเลือก <strong>การอนุมัติ</strong><br>";
                }

            } else {
                error_area.Attributes["class"] = "alert alert_success";
                error_area.InnerHtml = "";
                error_area.InnerHtml += "<strong>ทำการอนุมัติสำเร็จ!</strong><br>";
                i1.Style.Add("display", "none");
                i2.Style.Add("display", "none");
                i3.Style.Add("display", "block");
                int allow = 1;
                if (rbNotAllow.Checked) {
                    allow = 2;
                }
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_LEAVE SET CMD_HIGH_COMMENT = '" + tbComment.Text + "', CMD_HIGH_DATE = " + Util.TodayDatabaseToDate() + ", CMD_HIGH_ALLOW = " + allow + ", STATE_ID = 4 WHERE LEAVE_ID = " + lbLeaveID.Text);
            }
        }

        protected void lbu1_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void lbu2_Click(object sender, EventArgs e) {
            Response.Redirect("LeaveComment.aspx");
        }

        protected void lbuBack_Click(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            int count = 0;
            using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEAVE_ID) FROM LEV_LEAVE WHERE CMD_HIGH_ID = '" + loginPerson.CitizenID + "' AND LEV_LEAVE.STATE_ID = 3", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            if (count == 0) {
                error_area.InnerHtml = "ไม่มีรายการที่ท่านต้องอนุมัติ";
            } else {
                error_area.InnerHtml = "กรุณาเลือกรายการที่ต้องอนุมัติ";
            }
            error_area.Attributes["class"] = "alert alert_info";
            i1.Style.Add("display", "block");
            i2.Style.Add("display", "none");
            i3.Style.Add("display", "none");
        }
    }
}