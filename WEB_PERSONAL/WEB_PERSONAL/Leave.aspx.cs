using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Web.UI.HtmlControls;
using WEB_PERSONAL.Class;
using System.IO;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class Leave : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DatabaseManager.BindDropDown(ddlLeaveType, "SELECT * FROM LEV_TYPE", "LEAVE_TYPE_NAME", "LEAVE_TYPE_ID", "-- กรุณาเลือกประเภทการลา --");
            }
        }

        protected void lbuS1Check_Click(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            trS2BirthDate.Visible = false;
            trS2WorkInDate.Visible = false;
            trS2WifeName.Visible = false;
            trS2GBDate.Visible = false;
            trS2Ordained.Visible = false;
            trS2TempleName.Visible = false;
            trS2TempleLocation.Visible = false;
            trS2OrdainDate.Visible = false;
            trS2Hujed.Visible = false;
            trS2Reason.Visible = false;
            trS2Contact.Visible = false;
            trS2Phone.Visible = false;
            trS2DrCer.Visible = false;
            trS2RestSave.Visible = false;
            trS2RestLeft.Visible = false;
            trS2RestTotal.Visible = false;

            if (ddlLeaveType.SelectedValue == "1") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
                trS2DrCer.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "2") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "3") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "4") {
                trS2RestSave.Visible = true;
                trS2RestLeft.Visible = true;
                trS2RestTotal.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "5") {
                trS2WifeName.Visible = true;
                trS2GBDate.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "6") {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Ordained.Visible = true;
                trS2TempleName.Visible = true;
                trS2TempleLocation.Visible = true;
                trS2OrdainDate.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "7") {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Hujed.Visible = true;
            }

            if (ddlLeaveType.SelectedValue == "4") {
                if (tbS1FromDate.Text != "" && tbS1ToDate.Text != "") {
                    DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                    DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                    int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                    int max = DatabaseManager.ExecuteInt("SELECT REST_MAX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear());
                    int now = DatabaseManager.ExecuteInt("SELECT REST_NOW FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear());
                    if (now + totalDay > max) {
                        ChangeNotification("danger", "ปีนี้คุณไม่สามารถลาพักผ่อนเกิน " + max + " วันได้ ลาไปแล้ว " + now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (totalDay + now) + " วัน");
                        return;
                    }
                }
            }

            int v1 = 2;
            if(v1==1) {

                

                /*if (tbS1FromDate.Text == "" ||
                    tbS1ToDate.Text == "" ||
                    !Util.IsDateValid(tbS1FromDate.Text) ||
                    !Util.IsDateValid(tbS1ToDate.Text) ||
                    tbS1Reason.Text == "" ||
                    tbS1Contact.Text == "" ||
                    tbS1Phone.Text == "") {
                    ChangeNotification("danger", "<img src='Image/Small/red_alert.png' style='padding-right: 10px;'></img><strong>เกิดข้อผิดพลาด!</strong><br>");

                    if (tbS1FromDate.Text == "") {
                        AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>จากวันที่</strong><br>");
                    } else if (!Util.IsDateValid(tbS1FromDate.Text)) {
                        AddNotification("<div class='hm_tab'></div>- <strong>จากวันที่</strong> ไม่ถูกต้อง<br>");
                    }
                    if (tbS1ToDate.Text == "") {
                        AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ถึงวันที่</strong><br>");
                    } else if (!Util.IsDateValid(tbS1ToDate.Text)) {
                        AddNotification("<div class='hm_tab'></div>- <strong>ถึงวันที่</strong> ไม่ถูกต้อง<br>");
                    }
                    if (tbS1Reason.Text == "") {
                        AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เหตุผล</strong><br>");
                    }
                    if (tbS1Contact.Text == "") {
                        AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>ติดต่อได้ที่</strong><br>");
                    }
                    if (tbS1Phone.Text == "") {
                        AddNotification("<div class='hm_tab'></div>- กรุณากรอก <strong>เบอร์โทรศัพท์</strong><br>");
                    }
                }*/


            } else {
                MultiView1.ActiveViewIndex = 1;

                Session["LeaveSickFileUpload"] = FileUpload1;
                
                ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                

                string leavedDate = "ไม่เคยลา";
                DateTime? lastFromDate = null;
                DateTime? lastToDate = null;
                int lastTotalDay = 0;

                int pastTotalDay = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_TYPE_ID = " + ddlLeaveType.SelectedValue + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear());

                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT FROM_DATE, TO_DATE, TOTAL_DAY FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_TYPE_ID = " + ddlLeaveType.SelectedValue + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + " ORDER BY LEAVE_ID DESC", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            if (reader.Read()) {
                                lastFromDate = reader.GetDateTime(0);
                                lastToDate = reader.GetDateTime(1);
                                lastTotalDay = (int)(lastToDate.Value - lastFromDate.Value).TotalDays + 1;
                                leavedDate = lastFromDate.Value.ToLongDateString() + " ถึง " + lastToDate.Value.ToLongDateString() + " รวม " + lastTotalDay + " วัน ";
                            } else {
                                lastTotalDay = 0;
                            }
                        }
                    }

                }

                int restSave = 1;
                int restLeft = 2;
                int restTotal = 3;

                lbS2PSName.Text = loginPerson.FullName;
                lbS2PSPos.Text = loginPerson.PositionName;
                lbS2PSAPos.Text = loginPerson.AdminPositionName;
                lbS2PSDept.Text = loginPerson.DivisionName;
                lbS2PSBirthDate.Text = loginPerson.BirthDate.Value.ToLongDateString();
                lbS2PSWorkInDate.Text = loginPerson.InWorkDate.Value.ToLongDateString();
                lbS2RestSave.Text = restSave + " วัน";
                lbS2RestLeft.Text = restLeft + " วัน";
                lbS2RestTotal.Text = restTotal + " วัน";
                lbS2WifeName.Text = tbS1WifeFirstName.Text + " " + tbS1WifeLastName.Text;
                lbS2GBDate.Text = tbS1GBDate.Text;
                lbS2Ordained.Text = rbS1OrdainedT.Checked ? "เคย" : "ไม่เคย";
                lbS2TempleName.Text = tbS1TempleName.Text;
                lbS2TempleLocation.Text = tbS1TempleLocation.Text;
                lbS2OrdainDate.Text = tbS1OrdainDate.Text;
                lbS2Hujed.Text = rbS1HujedT.Checked ? "เคย" : "ไม่เคย";
                lbS2LastFTTDate.Text = leavedDate;
                lbS2LeaveTypeName.Text = ddlLeaveType.SelectedItem.Text;
                DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbS2FTTDate.Text = dtFromDate.ToLongDateString() + " ถึง " + dtToDate.ToLongDateString() + " รวม " + totalDay + " วัน";
                lbS2Statistic.Text = "ลามาแล้ว " + pastTotalDay + " วัน / ลาครั้งนี้ " + totalDay + " วัน / รวม " + (pastTotalDay + totalDay) + " วัน";
                lbS2Reason.Text = tbS1Reason.Text;
                lbS2Contact.Text = tbS1Contact.Text;
                lbS2Phone.Text = tbS1Phone.Text;
                string drCer;
                if (FileUpload1.HasFile) {
                    lbS2DrCer.Text = "มี";
                    FileInfo fi = new FileInfo(FileUpload1.FileName);
                    drCer = Util.RandomFileName() + fi.Extension;
                } else {
                    lbS2DrCer.Text = "ไม่มี";
                    drCer = "";
                }


                Person psCL = DatabaseManager.GetPerson("701");
                Person psCH = DatabaseManager.GetPerson("702");

                LeaveData leaveData = new LeaveData();
                leaveData.LeaveTypeID = int.Parse(ddlLeaveType.SelectedValue);
                leaveData.LeaveStatusID = 1;
                leaveData.PS_ID = loginPerson.CitizenID;
                leaveData.RequestDate = DateTime.Now;
                leaveData.FromDate = dtFromDate;
                leaveData.ToDate = dtToDate;
                leaveData.TotalDay = totalDay;

                leaveData.CL_ID = psCL.CitizenID;
                leaveData.CL_Title = psCL.TitleName;
                leaveData.CL_FirstName = psCL.FirstName;
                leaveData.CL_LastName = psCL.LastName;
                leaveData.CL_Position = psCL.PositionName;
                leaveData.CL_AdminPosition = psCL.AdminPositionName;

                leaveData.CH_ID = psCH.CitizenID;
                leaveData.CH_Title = psCH.TitleName;
                leaveData.CH_FirstName = psCH.FirstName;
                leaveData.CH_LastName = psCH.LastName;
                leaveData.CH_Position = psCH.PositionName;
                leaveData.CH_AdminPosition = psCH.AdminPositionName;

                leaveData.PS_Title = loginPerson.TitleName;
                leaveData.PS_FirstName = loginPerson.FirstName;
                leaveData.PS_LastName = loginPerson.LastName;
                leaveData.PS_Position = loginPerson.PositionName;
                leaveData.PS_Department = loginPerson.DivisionName;
                leaveData.PS_AdminPosition = loginPerson.AdminPositionName;
                leaveData.PS_BirthDate = loginPerson.BirthDate;
                leaveData.PS_WorkInDate = loginPerson.InWorkDate;
                leaveData.Reason = tbS1Reason.Text;
                leaveData.Contact = tbS1Contact.Text;
                leaveData.Telephone = tbS1Phone.Text;
                if (lastFromDate.HasValue) {
                    leaveData.LastFromDate = lastFromDate;
                    leaveData.LastToDate = lastToDate;
                }
                leaveData.LastTotalDay = lastTotalDay;

                leaveData.DocterCertificationFileName = drCer;
                leaveData.CountPast = pastTotalDay;
                leaveData.CountNow = totalDay;
                leaveData.CountTotal = pastTotalDay + totalDay;
                leaveData.RestLeft = restLeft;
                leaveData.RestSave = restSave;
                leaveData.RestTotal = restTotal;
                leaveData.WifeFirstName = tbS1WifeFirstName.Text;
                leaveData.WifeLastName = tbS1WifeLastName.Text;
                if(ddlLeaveType.SelectedValue == "5")
                    leaveData.GiveBirthDate = Util.ToDateTimeOracle(tbS1GBDate.Text);
                leaveData.Ordained = rbS1OrdainedT.Checked ? 1 : 0;
                leaveData.TempleName = tbS1TempleName.Text;
                leaveData.TempleLocation = tbS1TempleLocation.Text;
                if (ddlLeaveType.SelectedValue == "6")
                    leaveData.OrdainDate = Util.ToDateTimeOracle(tbS1OrdainDate.Text);
                leaveData.Hujed = rbS1HujedT.Checked ? 1 : 0;
                Session["LeaveData"] = leaveData;

                hfFileUploadName.Value = drCer;

            }

            

        }

        protected void lbuS2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuS2Finish_Click(object sender, EventArgs e) {
            LeaveData leaveData = (LeaveData)(Session["LeaveData"]);
            leaveData.LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_MAIN_ID");
            if(ddlLeaveType.SelectedValue == "1") {
                leaveData.AddLeaveSick();
                FileUpload fu = (FileUpload)Session["LeaveSickFileUpload"];
                if (fu.HasFile) {
                    fu.SaveAs(Server.MapPath("Upload/DrCer/" + hfFileUploadName.Value));
                }
            } else if (ddlLeaveType.SelectedValue == "2") {
                leaveData.AddLeaveBusiness();
            } else if (ddlLeaveType.SelectedValue == "3") {
                leaveData.AddLeaveGiveBirth();
            } else if (ddlLeaveType.SelectedValue == "4") {
                leaveData.AddLeaveRest();
            } else if (ddlLeaveType.SelectedValue == "5") {
                leaveData.AddLeaveHelpGiveBirth();
            } else if (ddlLeaveType.SelectedValue == "6") {
                leaveData.AddLeaveOrdain();
            } else if (ddlLeaveType.SelectedValue == "7") {
                leaveData.AddLeaveHuj();
            }

            ChangeNotification("success", "<strong>ทำการลาสำเร็จ!</strong> คุณสามารถตรวจสอบสถานะการลาได้ที่เมนู การลา -> ประวัติการลา");
            MultiView1.ActiveViewIndex = 2;
        }


        protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person pp = ps.LoginPerson;
            if(ddlLeaveType.SelectedValue == "1") {
                if(DatabaseManager.ExecuteInt("SELECT SICK_NOW - SICK_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาป่วยอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "2") {
                if (DatabaseManager.ExecuteInt("SELECT BUSINESS_NOW - BUSINESS_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลากิจอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "3") {
                if (DatabaseManager.ExecuteInt("SELECT GB_NOW - GB_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาคลอดบุตรอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "4") {
                if (DatabaseManager.ExecuteInt("SELECT REST_NOW - REST_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาพักผ่อนอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "5") {
                if (DatabaseManager.ExecuteInt("SELECT HGB_NOW - HGB_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปช่วยเหลือภริยาที่คลอดบุตรอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "6") {
                if (DatabaseManager.ExecuteInt("SELECT ORDAIN_NOW - ORDAIN_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปอุปสมบทอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (ddlLeaveType.SelectedValue == "7") {
                if (DatabaseManager.ExecuteInt("SELECT HUJ_NOW - HUJ_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปประกอบพิธีฮัจย์อยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            }

            lbLeaveTypeName.Text = "ข้อมูล" + ddlLeaveType.SelectedItem.Text;
            lbLeaveTypeName2.Text = "ข้อมูล" + ddlLeaveType.SelectedItem.Text;
            if(ddlLeaveType.SelectedIndex == 0) {
                MultiView1.ActiveViewIndex = -1;
                ClearNotification();
            } else {
                MultiView1.ActiveViewIndex = 0;
                ChangeNotification("info", "กรุณากรอกข้อมูล");
            }

            trS1WifeFirstName.Visible = false;
            trS1WifeLastName.Visible = false;
            trS1GBDate.Visible = false;
            trS1Ordained.Visible = false;
            trS1TempleName.Visible = false;
            trS1TempleLocation.Visible = false;
            trS1OrdainDate.Visible = false;
            trS1Hujed.Visible = false;
            trS1Reason.Visible = false;
            trS1Contact.Visible = false;
            trS1Phone.Visible = false;
            trS1DrCer.Visible = false;
            if (ddlLeaveType.SelectedValue == "1") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
                trS1DrCer.Visible = true;
            } else if(ddlLeaveType.SelectedValue == "2") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "3") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "4") {
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "5") {
                trS1WifeFirstName.Visible = true;
                trS1WifeLastName.Visible = true;
                trS1GBDate.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "6") {
                trS1Ordained.Visible = true;
                trS1TempleName.Visible = true;
                trS1TempleLocation.Visible = true;
                trS1OrdainDate.Visible = true;
            } else if (ddlLeaveType.SelectedValue == "7") {
                trS1Hujed.Visible = true;
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

        protected void lbuBackMain_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void lbuHistory_Click(object sender, EventArgs e) {
            Response.Redirect("LeaveHistory.aspx");
        }
    }

}