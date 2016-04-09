using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Globalization;
using System.Drawing;
using System.Web.UI.HtmlControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;

namespace WEB_PERSONAL {
    public partial class Leave : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DatabaseManager.BindDropDown(ddlLeaveType, "SELECT * FROM LEV_TYPE", "LEAVE_TYPE_NAME", "LEAVE_TYPE_ID", "-- กรุณาเลือกประเภทการลา --");
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
                using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
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
                }

                lbF1S2PersonName.Text = loginPerson.FullName;
                lbF1S2PersonPosition.Text = loginPerson.PositionName;
                lbF1S2PersonRank.Text = loginPerson.AdminPositionName;
                lbF1S2PersonDepartment.Text = loginPerson.DepartmentName;
                lbF1S2LastFTTDate.Text = leavedDate;
                lbF1S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;
                DateTime dtFromDate = Util.ToDateTime(tbF1S1FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(tbF1S1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF1S2FTTDate.Text = tbF1S1FromDate.Text + "&nbsp;&nbsp;ถึง&nbsp;&nbsp;" + tbF1S1ToDate.Text + "&nbsp;&nbsp;รวม&nbsp;&nbsp;" + totalDay + " วัน";
                lbF1S2Reason.Text = tbF1S1Reason.Text;
                lbF1S2Contact.Text = tbF1S1Contact.Text;
                lbF1S2Phone.Text = tbF1S1Phone.Text;





                string sql1 = "INSERT INTO LEV_MAIN (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATE, CITIZEN_ID, REQ_DATE) VALUES ({0},{1},{2},'{3}',{4})";
                sql1 = string.Format(sql1, "{0}", ddlLeaveType.SelectedValue, 1, loginPerson.CitizenID, Util.TodayDatabaseToDate());
                hfSql.Value = sql1;

                Person cmdLowPerson = DatabaseManager.GetPerson("1111111111111");
                Person cmdHighPerson = DatabaseManager.GetPerson("1111111111112");

                string sql2 = "INSERT INTO LEV_FORM1 (FORM1_ID, LEAVE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, PERSON_POSITION, PERSON_RANK, PERSON_DEPARTMENT, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, PERSON_PREFIX, PERSON_FIRST_NAME, PERSON_LAST_NAME, CMD_LOW_ID, CMD_LOW_POS, CMD_LOW_PREFIX, CMD_LOW_FIRST_NAME, CMD_LOW_LAST_NAME, CMD_HIGH_ID, CMD_HIGH_POS, CMD_HIGH_PREFIX, CMD_HIGH_FIRST_NAME, CMD_HIGH_LAST_NAME) VALUES ({0},{1},{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},{13},'{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}')";
                sql2 = string.Format(sql2, "SEQ_LEV_FORM1_ID.NEXTVAL", "{0}", Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, tbF1S1Reason.Text, tbF1S1Contact.Text, tbF1S1Phone.Text, loginPerson.PositionName, loginPerson.AdminPositionName, loginPerson.DepartmentName, Util.DatabaseToDate(lastFromDate), Util.DatabaseToDate(lastToDate), lastTotalDay, loginPerson.TitleName, loginPerson.FirstName, loginPerson.LastName, "1111111111111", cmdLowPerson.PositionName, cmdLowPerson.TitleName, cmdLowPerson.FirstName, cmdLowPerson.LastName, "1111111111112", cmdHighPerson.PositionName, cmdHighPerson.TitleName, cmdHighPerson.FirstName, cmdHighPerson.LastName);
                hfSql2.Value = sql2;

                TextBox56.Text += sql1 + System.Environment.NewLine + sql2;

                /*string sql = "INSERT INTO LEV_FORM1 (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEV_FORM1_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);
                */


            }


        }
        protected void lbuF2S1Check_Click(object sender, EventArgs e) {
            if (tbF2S1WifeName.Text == "" ||
                tbF2S1WifeLastName.Text == "" ||
                tbF2S1GiveBirthDate.Text == "" ||
                !Util.IsDateValid(tbF2S1GiveBirthDate.Text) ||
                tbF2S1FromDate.Text == "" ||
                tbF2S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF2S1FromDate.Text) ||
                !Util.IsDateValid(tbF2S1ToDate.Text) ||
                tbF2S1Contact.Text == "" ||
                tbF2S1Phone.Text == "") {
                ChangeNotification("danger", "<img src='Image/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");

                if (tbF2S1WifeName.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ชื่อภริยา</strong><br>");
                }
                if (tbF2S1WifeLastName.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>นามสกุลภริยา</strong><br>");
                }
                if (tbF2S1GiveBirthDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>วันที่คลอดบุตร</strong><br>");
                } else if (!Util.IsDateValid(tbF2S1GiveBirthDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>วันที่คลอดบุตร</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF2S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF2S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF2S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF2S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF2S1Contact.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ติดต่อได้ที่</strong><br>");
                }
                if (tbF2S1Phone.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เบอร์โทรศัพท์</strong><br>");
                }
            } else {
               /* HideAllAndShow(sectionF2S2);
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                LeaveSystem leaveSystem = ((LeaveSystem)Session["leaveSystem"]);
                Person loginPerson = leaveSystem.LoginPerson;
                lbF2S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;

                lbF2S2PersonName.Text = loginPerson.FullName;
                lbF2S2PersonPosition.Text = loginPerson.PositionName;
                lbF2S2PersonRank.Text = loginPerson.PositionRank;
                lbF2S2PersonDepartment.Text = loginPerson.DepartmentName;

                lbF2S2WifeName.Text = tbF2S1WifeName.Text;
                lbF2S2WifeLastName.Text = tbF2S1WifeLastName.Text;
                lbF2S2GiveBirthDate.Text = tbF2S1GiveBirthDate.Text;
                lbF2S2FromDate.Text = tbF2S1FromDate.Text;
                lbF2S2ToDate.Text = tbF2S1ToDate.Text;
                DateTime dtFromDate = Util.ToDateTime(lbF2S2FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(lbF2S2ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF2S2TotalDay.Text = "" + totalDay + " วัน";
                lbF2S2Contact.Text = tbF2S1Contact.Text;
                lbF2S2Phone.Text = tbF2S1Phone.Text;
                string sql = "INSERT INTO LEV_LEAVE (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEAVE_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);


    */
            }
        }
        protected void lbuF3S1Check_Click(object sender, EventArgs e) {
            if (tbF3S1FromDate.Text == "" ||
                tbF3S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF3S1FromDate.Text) ||
                !Util.IsDateValid(tbF3S1ToDate.Text) ||
                tbF3S1Contact.Text == "" ||
                tbF3S1Phone.Text == "") {
                ChangeNotification("danger", "<img src='Image/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");

                if (tbF3S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF3S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF3S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF3S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF3S1Contact.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ติดต่อได้ที่</strong><br>");
                }
                if (tbF3S1Phone.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เบอร์โทรศัพท์</strong><br>");
                }
            } else {
               /* HideAllAndShow(sectionF3S2);
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                LeaveSystem leaveSystem = ((LeaveSystem)Session["leaveSystem"]);
                Person loginPerson = leaveSystem.LoginPerson;
                lbF3S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;

                lbF3S2PersonName.Text = loginPerson.FullName;
                lbF3S2PersonPosition.Text = loginPerson.PositionName;
                lbF3S2PersonRank.Text = loginPerson.PositionRank;
                lbF3S2PersonDepartment.Text = loginPerson.DepartmentName;

                lbF3S2FromDate.Text = tbF3S1FromDate.Text;
                lbF3S2ToDate.Text = tbF3S1ToDate.Text;
                DateTime dtFromDate = Util.ToDateTime(lbF3S2FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(lbF3S2ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF3S2TotalDay.Text = "" + totalDay + " วัน";
                lbF3S2Contact.Text = tbF3S1Contact.Text;
                lbF3S2Phone.Text = tbF3S1Phone.Text;
                string sql = "INSERT INTO LEV_LEAVE (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEAVE_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);
                */


            }

        }
        protected void lbuF4S1Check_Click(object sender, EventArgs e) {
            if (tbF4S1TempleName.Text == "" ||
                tbF4S1TempleLocation.Text == "" ||
                tbF4S1OrdainDate.Text == "" ||
                tbF4S1FromDate.Text == "" ||
                tbF4S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF4S1OrdainDate.Text) ||
                !Util.IsDateValid(tbF4S1FromDate.Text) ||
                !Util.IsDateValid(tbF4S1ToDate.Text)) {
                ChangeNotification("danger", "<img src='Image/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");
                if (tbF4S1TempleName.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ชื่อวัด</strong><br>");
                }
                if (tbF4S1TempleLocation.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>สถานที่</strong><br>");
                }
                if (tbF4S1OrdainDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>วันที่อุปสมบท</strong><br>");
                } else if (!Util.IsDateValid(tbF4S1OrdainDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>วันที่อุปสมบท</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF4S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF4S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF4S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF4S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
            } else {
               /* HideAllAndShow(sectionF4S2);
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                LeaveSystem leaveSystem = ((LeaveSystem)Session["leaveSystem"]);
                Person loginPerson = leaveSystem.LoginPerson;
                lbF4S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;

                lbF4S2PersonName.Text = loginPerson.FullName;
                lbF4S2PersonPosition.Text = loginPerson.PositionName;
                lbF4S2PersonRank.Text = loginPerson.PositionRank;
                lbF4S2PersonDepartment.Text = loginPerson.DepartmentName;
                lbF4S2PersonBirthDate.Text = loginPerson.BirthDate;
                lbF4S2PersonWorkInDate.Text = loginPerson.WorkInDate;

                lbF4S2PersonOrdained.Text = rbOrdainedTrue.Checked ? "เคย" : "ไม่เคย";
                lbF4S2TempleName.Text = tbF4S1TempleName.Text;
                lbF4S2TempleLocation.Text = tbF4S1TempleLocation.Text;
                lbF4S2OrdainDate.Text = tbF4S1OrdainDate.Text;
                lbF4S2FromDate.Text = tbF4S1FromDate.Text;
                lbF4S2ToDate.Text = tbF4S1ToDate.Text;
                DateTime dtFromDate = Util.ToDateTime(lbF4S2FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(lbF4S2ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF4S2TotalDay.Text = "" + totalDay + " วัน";
                string sql = "INSERT INTO LEV_LEAVE (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEAVE_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);

    */

            }
        }
        protected void lbuF5S1Check_Click(object sender, EventArgs e) {
            if (tbF5S1FromDate.Text == "" ||
                tbF5S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF5S1FromDate.Text) ||
                !Util.IsDateValid(tbF5S1ToDate.Text)) {
                ChangeNotification("danger", "<img src='Image/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");
                if (tbF5S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF5S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF5S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF5S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
            } else {
               /* HideAllAndShow(sectionF5S2);
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                LeaveSystem leaveSystem = ((LeaveSystem)Session["leaveSystem"]);
                Person loginPerson = leaveSystem.LoginPerson;
                lbF5S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;

                lbF5S2PersonName.Text = loginPerson.FullName;
                lbF5S2PersonPosition.Text = loginPerson.PositionName;
                lbF5S2PersonRank.Text = loginPerson.PositionRank;
                lbF5S2PersonDepartment.Text = loginPerson.DepartmentName;
                lbF5S2PersonWorkInDate.Text = loginPerson.WorkInDate;

                lbF5S2PersonHujed.Text = rbHujedTrue.Checked ? "เคย" : "ไม่เคย";
                lbF5S2FromDate.Text = tbF5S1FromDate.Text;
                lbF5S2ToDate.Text = tbF5S1ToDate.Text;
                DateTime dtFromDate = Util.ToDateTime(lbF5S2FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(lbF5S2ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF5S2TotalDay.Text = "" + totalDay + " วัน";
                string sql = "INSERT INTO LEV_LEAVE (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEAVE_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);
                */
            }
        }
        protected void lbuF6S1Check_Click(object sender, EventArgs e) {
            if (tbF6S1GotFrom.Text == "" ||
                tbF6S1GotAt.Text == "" ||
                tbF6S1GotDate.Text == "" ||
                tbF6S1ToDo.Text == "" ||
                tbF6S1ToDoAt.Text == "" ||
                tbF6S1FromDate.Text == "" ||
                tbF6S1ToDate.Text == "" ||
                !Util.IsDateValid(tbF6S1GotDate.Text) ||
                !Util.IsDateValid(tbF6S1FromDate.Text) ||
                !Util.IsDateValid(tbF6S1ToDate.Text)) {
                ChangeNotification("danger", "<img src='Image/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");
                if (tbF6S1GotFrom.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ได้รับหมายเรียกของ</strong><br>");
                }
                if (tbF6S1GotAt.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ที่</strong><br>");
                }
                if (tbF6S1GotDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ลงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF6S1GotDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ลงวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF6S1ToDo.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ให้เข้ารับการ</strong><br>");
                }
                if (tbF6S1ToDoAt.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ณ ที่</strong><br>");
                }
                if (tbF6S1FromDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF6S1FromDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                }
                if (tbF6S1ToDate.Text == "") {
                    AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                } else if (!Util.IsDateValid(tbF6S1ToDate.Text)) {
                    AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                }
            } else {
                /*HideAllAndShow(sectionF6S2);
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                LeaveSystem leaveSystem = ((LeaveSystem)Session["leaveSystem"]);
                Person loginPerson = leaveSystem.LoginPerson;
                lbF6S2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;

                lbF6S2PersonName.Text = loginPerson.FullName;
                lbF6S2PersonPosition.Text = loginPerson.PositionName;
                lbF6S2PersonRank.Text = loginPerson.PositionRank;
                lbF6S2PersonDepartment.Text = loginPerson.DepartmentName;

                lbF6S2GotFrom.Text = tbF6S1GotFrom.Text;
                lbF6S2GotAt.Text = tbF6S1GotAt.Text;
                lbF6S2GotDate.Text = tbF6S1GotDate.Text;
                lbF6S2ToDo.Text = tbF6S1ToDo.Text;
                lbF6S2ToDoAt.Text = tbF6S1ToDoAt.Text;

                lbF6S2FromDate.Text = tbF6S1FromDate.Text;
                lbF6S2ToDate.Text = tbF6S1ToDate.Text;
                DateTime dtFromDate = Util.ToDateTime(lbF6S2FromDate.Text);
                DateTime dtToDate = Util.ToDateTime(lbF6S2ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbF6S2TotalDay.Text = "" + totalDay + " วัน";
                string sql = "INSERT INTO LEV_LEAVE (LEAVE_ID, CITIZEN_ID, REQ_DATE, LEAVE_TYPE_ID, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, PHONE, STATE_ID) VALUES (SEQ_LEAVE_ID.NEXTVAL, '{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', {9})";
                hfSql.Value = string.Format(sql, loginPerson.CitizenID, Util.TodayDatabaseToDate(), ddlLeaveType.SelectedValue, Util.DatabaseToDate(tbF1S1FromDate.Text), Util.DatabaseToDate(tbF1S1ToDate.Text), totalDay, lbF1S2Reason.Text, lbF1S2Contact.Text, lbF1S2Phone.Text, 1);
                */
            }
        }
        protected void lbuF7S1Check_Click(object sender, EventArgs e) {

        }
        protected void lbuF8S1Check_Click(object sender, EventArgs e) {

        }
        protected void lbuF9S1Check_Click(object sender, EventArgs e) {

        }
        protected void lbuF10S1Check_Click(object sender, EventArgs e) {

        }

        protected void lbuF1S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF2S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF3S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 4;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF4S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 6;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF5S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 8;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF6S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 10;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF7S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 12;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF8S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 14;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF9S2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 16;
            ChangeNotification("info", "กรุณากรอกข้อมูล");
        }
        protected void lbuF10S2Back_Click(object sender, EventArgs e) {

        }

        protected void lbuF1S2Add_Click(object sender, EventArgs e) {

            int leave_id = DatabaseManager.ExecuteSequence("SEQ_LEV_MAIN_ID");

            string sql1 = hfSql.Value;
            sql1 = string.Format(sql1, leave_id);
            string sql2 = hfSql2.Value;
            sql2 = string.Format(sql2, leave_id);

            DatabaseManager.ExecuteNonQuery(sql1);
            DatabaseManager.ExecuteNonQuery(sql2);

            ChangeNotification("success", "<strong>ทำการลาสำเร็จ!</strong> คุณสามารถตรวจสอบสถานะการลาได้ที่เมนู การลา -> สถานะ และ ประวัติการลา");
            MultiView1.ActiveViewIndex = 20;

        }
        protected void lbuBackMain_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e) {
            switch (ddlLeaveType.SelectedValue) {
                case "0":
                    MultiView1.ActiveViewIndex = -1;
                    ClearNotification();
                    break;
                case "1":
                    MultiView1.ActiveViewIndex = 0;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "2":
                    MultiView1.ActiveViewIndex = 0;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "3":
                    MultiView1.ActiveViewIndex = 0;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "4":
                    MultiView1.ActiveViewIndex = 4;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "5":
                    MultiView1.ActiveViewIndex = 2;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "6":
                    MultiView1.ActiveViewIndex = 6;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "7":
                    MultiView1.ActiveViewIndex = 8;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "8":
                    MultiView1.ActiveViewIndex = 10;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "9":
                    MultiView1.ActiveViewIndex = 12;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "10":
                    MultiView1.ActiveViewIndex = 14;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "11":
                    MultiView1.ActiveViewIndex = 16;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
                case "12":
                    MultiView1.ActiveViewIndex = 18;
                    ChangeNotification("info", "กรุณากรอกข้อมูล");
                    break;
            }
        }

        private void ChangeNotification(string type) {
            switch (type) {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
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

        protected void rbF7S1T1_CheckedChanged(object sender, EventArgs e) {
            F7S1Table1.Style.Add("display", "block");
            F7S1Table2.Style.Add("display", "none");
        }
        protected void rbF7S1T2_CheckedChanged(object sender, EventArgs e) {
            F7S1Table1.Style.Add("display", "none");
            F7S1Table2.Style.Add("display", "block");
        }
        protected void rbF7S1T3_CheckedChanged(object sender, EventArgs e) {
            F7S1Table1.Style.Add("display", "none");
            F7S1Table2.Style.Add("display", "block");
        }
        protected void rbF7S1T4_CheckedChanged(object sender, EventArgs e) {
            F7S1Table1.Style.Add("display", "none");
            F7S1Table2.Style.Add("display", "block");
        }


    }

}