using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class LeaveCancel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                ChangeNotification("info", "กรุณากรอกข้อมูล");
            }
        }

        protected void lbuF1S1Check_Click(object sender, EventArgs e) {

            if (tbF1S1FromDate.Text == "" ||
                tbF1S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF1S1FromDate.Text) ||
                !Util.IsDateValid(tbF1S1ToDate.Text) ||
                tbF1S1Reason.Text == "" ||
                tbF1S1Contact.Text == "" ||
                tbF1S1Phone.Text == "") {
                ChangeNotification("danger", "<img src='Image/Small/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");

                if (tbF1S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF1S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF1S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF1S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF1S1Reason.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เหตุผล</strong><br>");
                }
                if (tbF1S1Contact.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ติดต่อได้ที่</strong><br>");
                }
                if (tbF1S1Phone.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เบอร์โทรศัพท์</strong><br>");
                }
            } else {
                MultiView1.ActiveViewIndex = 1;
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person loginPerson = ps.LoginPerson;

                string leavedDate = "ไม่เคยลา";
                string lastFromDate = "''";
                string lastToDate = "''";
                string lastTotalDay = "''";
                /*using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand("SELECT LEV_FORM1.FROM_DATE, LEV_FORM1.TO_DATE, LEV_FORM1.TOTAL_DAY FROM LEV_MAIN, LEV_FORM1 WHERE LEV_MAIN.CITIZEN_ID = '" + loginPerson.CitizenID + "' AND LEV_MAIN.LEAVE_TYPE_ID = " + ddlLeaveType.SelectedValue + " AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND ROWNUM = 1 ORDER BY LEV_MAIN.LEAVE_ID DESC", con)) {
                        using (OleDbDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                lastFromDate = Util.PureDatabaseToThaiDate(reader.GetValue(0).ToString());
                                lastToDate = Util.PureDatabaseToThaiDate(reader.GetValue(1).ToString());
                                lastTotalDay = reader.GetValue(2).ToString();
                                leavedDate = lastFromDate + "&nbsp;&nbsp;ถึง&nbsp;&nbsp;" + lastToDate + "&nbsp;&nbsp;รวม&nbsp;&nbsp;" + lastTotalDay + " วัน ";
                            }
                        }
                    }
                }*/

                lbF1S2PersonName.Text = loginPerson.FullName;
                lbF1S2PersonPosition.Text = loginPerson.PositionName;
                lbF1S2PersonRank.Text = loginPerson.AdminPositionName;
                lbF1S2PersonDepartment.Text = loginPerson.DepartmentName;
                lbF1S2LastFTTDate.Text = leavedDate;
                //lbF1S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;
                DateTime dtFromDate = Util.ToDateTime(tbF1S1FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(tbF1S1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF1S2FTTDate.Text = tbF1S1FromDate.Text + "&nbsp;&nbsp;ถึง&nbsp;&nbsp;" + tbF1S1ToDate.Text + "&nbsp;&nbsp;รวม&nbsp;&nbsp;" + totalDay + " วัน";
                lbF1S2Reason.Text = tbF1S1Reason.Text;
                lbF1S2Contact.Text = tbF1S1Contact.Text;
                lbF1S2Phone.Text = tbF1S1Phone.Text;





                /* string sql1 = "INSERT INTO LEV_MAIN (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATE, CITIZEN_ID, REQ_DATE) VALUES ({0},{1},{2},'{3}',{4})";
                 sql1 = string.Format(sql1, "{0}", ddlLeaveType.SelectedValue, 1, loginPerson.CitizenID, Util.TodayDatabaseToDate());
                 hfSql.Value = sql1;

                 Person cmdLowPerson = DatabaseManager.GetPerson("1111111111111");
                 Person cmdHighPerson = DatabaseManager.GetPerson("1111111111112");

                 string sql2 = "INSERT INTO LEV_FORM1 (FORM1_ID, LEAVE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, PERSON_POSITION, PERSON_RANK, PERSON_DEPARTMENT, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, PERSON_PREFIX, PERSON_FIRST_NAME, PERSON_LAST_NAME, CMD_LOW_ID, CMD_LOW_POS, CMD_LOW_PREFIX, CMD_LOW_FIRST_NAME, CMD_LOW_LAST_NAME, CMD_HIGH_ID, CMD_HIGH_POS, CMD_HIGH_PREFIX, CMD_HIGH_FIRST_NAME, CMD_HIGH_LAST_NAME) VALUES ({0},{1},{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},{13},'{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}')";
                 sql2 = string.Format(sql2, "SEQ_LEV_FORM1_ID.NEXTVAL", "{0}", Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, tbF1S1Reason.Text, tbF1S1Contact.Text, tbF1S1Phone.Text, loginPerson.PositionName, loginPerson.AdminPositionName, loginPerson.DepartmentName, Util.DatabaseToDate(lastFromDate), Util.DatabaseToDate(lastToDate), lastTotalDay, loginPerson.TitleName, loginPerson.FirstName, loginPerson.LastName, "1111111111111", cmdLowPerson.PositionName, cmdLowPerson.TitleName, cmdLowPerson.FirstName, cmdLowPerson.LastName, "1111111111112", cmdHighPerson.PositionName, cmdHighPerson.TitleName, cmdHighPerson.FirstName, cmdHighPerson.LastName);
                 hfSql2.Value = sql2;*/

                // TextBox56.Text += sql1 + System.Environment.NewLine + sql2;

                /*string sql = "INSERT INTO LEV_FORM1 (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEV_FORM1_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);
                */


            }
        }

        protected void lbuF1S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }

        protected void lbuF1S2Add_Click(object sender, EventArgs e) {

            /*int leave_id = DatabaseManager.ExecuteSequence("SEQ_LEV_MAIN_ID");

            string sql1 = hfSql.Value;
            sql1 = string.Format(sql1, leave_id);
            string sql2 = hfSql2.Value;
            sql2 = string.Format(sql2, leave_id);

            DatabaseManager.ExecuteNonQuery(sql1);
            DatabaseManager.ExecuteNonQuery(sql2);

            ChangeNotification("success", "<strong>ทำการลาสำเร็จ!</strong> คุณสามารถตรวจสอบสถานะการลาได้ที่เมนู การลา -> สถานะ และ ประวัติการลา");
            MultiView1.ActiveViewIndex = 20;*/

        }

        protected void lbuBackMain_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        private void ChangeNotification(string type, string text) {
            switch (type) {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
            notification.InnerHtml = text;
        }
        private void ClearNotification() {
            notification.Attributes["class"] = null;
            notification.InnerHtml = "";
        }
        private void AddNotification(string text) {
            notification.InnerHtml += text;
        }
    }
}