using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;

namespace WEB_PERSONAL {
    public partial class LeaveComment : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            int count = DatabaseManager.GetLeaveRequiredCountByCommanderLow(loginPerson.CitizenID); ;
            /*using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEV_MAIN.LEAVE_ID) FROM LEV_MAIN, LEV_FORM1 WHERE LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND CMD_LOW_ID = '" + loginPerson.CitizenID + "' AND LEAVE_STATE = 1", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }*/
            if (count == 0) {
                error_area.InnerHtml = "ไม่มีรายการที่ท่านต้องลงความเห็น";
            } else {
                error_area.InnerHtml = "กรุณาเลือกรายการที่ต้องการลงความเห็น";
            }
            error_area.Attributes["class"] = "alert alert_info";

            if (count > 0) {

                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE CITIZEN_ID = LEV_MAIN.CITIZEN_ID) ชื่อผู้ลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล FROM LEV_MAIN, LEV_FORM1 WHERE LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND LEAVE_STATE = 1 AND CMD_LOW_ID = '" + loginPerson.CitizenID + "'");
                GridView1.DataSource = sds;
                GridView1.DataBind();

                Util.NormalizeGridViewDate(GridView1, 3);

                TableCell newHeader = new TableCell();
                newHeader.Text = "เลือก";
                GridView1.HeaderRow.Cells.Add(newHeader);

                for(int i=0; i<GridView1.Rows.Count; ++i) {

                    string id = GridView1.Rows[i].Cells[0].Text;
                    Form1Package f1 = DatabaseManager.GetForm1Package(id);

                    LinkButton lbu = new LinkButton();
                    lbu.Text = "เลือก";
                    lbu.CssClass = "button button_default";
                    lbu.Click += (e2, e3) => { 
                        lbF1LeaveID.Text = id;
                        lbF1LeaverName.Text = f1.PersonPrefix + f1.PersonFirstName + " " + f1.PersonLastName;
                        lbF1PersonPosition.Text = f1.PersonPosition;
                        lbF1PersonDepartment.Text = f1.PersonDepartment;
                        lbF1PersonRank.Text = f1.PersonRank;
                        lbF1ReqDate.Text = f1.RequestDate;
                        lbF1LeaveTypeName.Text = f1.LeaveTypeName;
                        if (f1.LastFromDate == "") {
                            lbF1LastFTTDate.Text = "ยังไม่เคยลา";
                        } else {
                            lbF1LastFTTDate.Text = f1.LastFromDate + " - " + f1.LastToDate + " / รวม " + f1.LastTotalDay + " วัน";
                        }
                        lbF1FTTDate.Text = f1.FromDate + " - " + f1.ToDate + " / รวม " + f1.TotalDay + " วัน";
                        lbF1Reason.Text = f1.Reason;
                        lbF1Contact.Text = f1.Contact;
                        lbF1Phone.Text = f1.Phone;

                        MultiView1.ActiveViewIndex = 1;

                        error_area.Attributes["class"] = "alert alert_info";
                        error_area.InnerHtml = "กรุณาลงความเห็น";
                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    GridView1.Rows[i].Cells.Add(cell);
                }

                /*HTable htable = new HTable(i1);
                htable.AddHeaderRow(new string[] { "รหัสการลา", "วันที่ยื่นเรื่อง", "ผู้ลา", "ประเภทการลา", "เลือก" });
                using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand("SELECT LEV_MAIN.LEAVE_ID, REQ_DATE, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE CITIZEN_ID = LEV_MAIN.CITIZEN_ID), LEAVE_TYPE_NAME FROM LEV_MAIN, LEV_FORM1, LEV_TYPE WHERE LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND LEV_FORM1.CMD_LOW_ID = '" + loginPerson.CitizenID + "' AND LEV_MAIN.LEAVE_TYPE_ID = LEV_TYPE.LEAVE_TYPE_ID AND LEV_MAIN.LEAVE_STATE = 1", con)) {
                        using (OleDbDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {

                                string id = reader.GetValue(0).ToString();
                                Form1Package f1 = DatabaseManager.GetForm1Package(id);
                                string req_date = Util.PureDatabaseToThaiDate(reader.GetValue(1).ToString());
                                string name = reader.GetValue(2).ToString();
                                string leave_type_name = reader.GetValue(3).ToString();
                                htable.AddRow(new string[] {
                                id,
                                req_date,
                                name,
                                leave_type_name,
                            });
                                LinkButton b = new LinkButton();
                                b.Text = "เลือก";
                                b.CssClass = "hm_button_primary";
                                b.Click += (e2, e3) => {
                                    lbF1LeaveID.Text = id;
                                    lbF1LeaverName.Text = name;

                                    lbF1PersonPosition.Text = f1.PersonPosition;
                                    lbF1PersonDepartment.Text = f1.PersonDepartment;
                                    lbF1PersonRank.Text = f1.PersonRank;
                                    lbF1ReqDate.Text = req_date;
                                    lbF1LeaveTypeName.Text = leave_type_name;
                                    if (f1.LastFromDate == "''") {
                                        lbF1LastFTTDate.Text = "ยังไม่เคยลา";
                                    } else {
                                        lbF1LastFTTDate.Text = f1.LastFromDate + " - " + f1.LastToDate + " / รวม " + f1.LastTotalDay + " วัน";
                                    }

                                    lbF1FTTDate.Text = f1.FromDate + " - " + f1.ToDate + " / รวม " + f1.TotalDay + " วัน";

                                    lbF1Reason.Text = f1.Reason;
                                    lbF1Contact.Text = f1.Contact;
                                    lbF1Phone.Text = f1.Phone;

                                    i1.Style.Add("display", "none");
                                    i2.Style.Add("display", "block");
                                    i3.Style.Add("display", "none");
                                    error_area.Attributes["class"] = "hm_alert_info";
                                    error_area.InnerHtml = "กรุณาลงความเห็น";
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

        protected void lbuF1Add_Click(object sender, EventArgs e) {
            if (tbF1Comment.Text == "") {
                error_area.Attributes["class"] = "alert alert_danger";
                error_area.InnerHtml = "";
                error_area.InnerHtml += "<strong>เกิดข้อผิดพลาด!</strong><br>";
                error_area.InnerHtml += "<div class='hm_tab'></div>- กรุณากรอก <strong>ความเห็น</strong><br>";
            } else {
                error_area.Attributes["class"] = "alert alert_success";
                error_area.InnerHtml = "";
                error_area.InnerHtml += "<strong>ลงความเห็นสำเร็จ!</strong><br>";

                MultiView1.ActiveViewIndex = 2;

                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person loginPerson = ps.LoginPerson;

                DatabaseManager.ExecuteNonQuery("UPDATE LEV_MAIN SET LEAVE_STATE = 2 WHERE LEAVE_ID = '" + lbF1LeaveID.Text + "'");
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_FORM1 SET CMD_LOW_POS = '" + loginPerson.PositionName + "', CMD_LOW_COMMENT = '" + tbF1Comment.Text + "', CMD_LOW_DATE = " + Util.TodayDatabaseToDate() + " WHERE LEAVE_ID = '" + lbF1LeaveID.Text + "'");
            }
        }

        protected void lbu1_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void lbu2_Click(object sender, EventArgs e) {
            Response.Redirect("LeaveComment.aspx");
        }

        protected void lbuF1Back_Click(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            int count = 0;
            using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEAVE_ID) FROM LEV_LEAVE WHERE CMD_LOW_ID = '" + loginPerson.CitizenID + "' AND LEV_LEAVE.STATE_ID = 1", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            if (count == 0) {
                error_area.InnerHtml = "ไม่มีรายการที่ท่านต้องลงความเห็น";
            } else {
                error_area.InnerHtml = "กรุณาเลือกรายการที่ต้องการลงความเห็น";
            }
            error_area.Attributes["class"] = "alert alert_info";

            MultiView1.ActiveViewIndex = 0;
        }
    }
}