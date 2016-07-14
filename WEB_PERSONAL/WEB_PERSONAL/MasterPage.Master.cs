using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class MasterPage : System.Web.UI.MasterPage {

        protected void Page_Init(object sender, EventArgs e) {
            if (PersonnelSystem.GetPersonnelSystem(this) == null) {
                Response.Redirect("Access.aspx");
                return;
            }
            Session.Timeout = 60;
        }

        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            lbName.Text = loginPerson.FullName;
            lbStaffType.Text = loginPerson.StaffTypeName;
            lbPosition.Text = loginPerson.PositionName;
            lbPositionRank.Text = loginPerson.AdminPositionName;
            lbDepartment.Text = loginPerson.DivisionName;

            string name = loginPerson.FirstNameAndLastName;
            profile_name.InnerText = name;
          
            string personImageFileName = DatabaseManager.GetPersonImageFileName(loginPerson.CitizenID);
            if (personImageFileName != "") {
                profile_pic.Src = "Upload/PersonImage/" + personImageFileName;
                profile_pic2.Src = "Upload/PersonImage/" + personImageFileName;
            }  else {
                profile_pic.Src = "Image/Small/person2.png";
            }

            int v1 = DatabaseManager.GetLeaveRequiredCountByCommanderLow(loginPerson.CitizenID);
            if (v1 != 0) {
                lbLeaveCommentCount.Text = "" + v1;
                lbLeaveCommentCount.Visible = true;
            } else {
                lbLeaveCommentCount.Text = "";
                lbLeaveCommentCount.Visible = false;
            }

            int v2 = DatabaseManager.GetLeaveRequiredCountByCommanderHigh(loginPerson.CitizenID);
            if (v2 != 0) {
                lbLeaveAllowCount.Text = "" + v2;
                lbLeaveAllowCount.Visible = true;
            } else {
                lbLeaveAllowCount.Text = "";
                lbLeaveAllowCount.Visible = false;
            }

            /*if(v1 + v2 == 0) {
                lbN1.Text = "ไม่มีการแจ้งเตือนการลา";
            } else {
                lbN1.Text = "คุณมี " + (v1 + v2) + " การแจ้งเตือนการลา";
            }*/

            /*
            int count = 0;
            using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(*) FROM TB_VIEW_PERMISSION WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            if(count == 0) {
                LinkAddPerson.Visible = false;
                LinkDropDown.Visible = false;
                LinkDeveloper.Visible = false;
                LinkUpload.Visible = false;
                LinkEditPerson.Visible = false;
                LinkWorkingTime.Visible = false;
            } else {
                using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand("SELECT * FROM TB_VIEW_PERMISSION WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                        using (OleDbDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                string b_addPerson = reader.GetValue(3).ToString();
                                string b_dropdown = reader.GetValue(4).ToString();
                                string b_developer = reader.GetValue(5).ToString();
                                string b_upload = reader.GetValue(6).ToString();
                                string b_editPerson = reader.GetValue(7).ToString();
                                string b_workingTime = reader.GetValue(8).ToString();
                                if (b_addPerson == "0") {
                                    LinkAddPerson.Visible = false;
                                }
                                if (b_dropdown == "0") {
                                    LinkDropDown.Visible = false;
                                }
                                if (b_developer == "0") {
                                    LinkDeveloper.Visible = false;
                                }
                                if (b_upload == "0") {
                                    LinkUpload.Visible = false;
                                }
                                if (b_editPerson == "0") {
                                    LinkEditPerson.Visible = false;
                                }
                                if (b_workingTime == "0") {
                                    LinkWorkingTime.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            */

            //---------
            int count_cl = DatabaseManager.GetLeaveRequiredCountByCommanderLow(loginPerson.CitizenID);
            int count_ch = DatabaseManager.GetLeaveRequiredCountByCommanderHigh(loginPerson.CitizenID);
            int count_leave_finish = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(LEAVE_ID) FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_STATUS_ID in(3,7)", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_leave_finish = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            int count_ins = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(IR_ID) FROM TB_INSIG_REQUEST WHERE IR_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND IR_STATUS = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_ins = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            int count_insadminknow = 0;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(IR_STATUS) FROM TB_INSIG_REQUEST WHERE IR_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND IR_STATUS = 2", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count_insadminknow = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }

            int count = count_cl + count_ch + count_leave_finish + count_ins + count_insadminknow;

            noti_leave_none.Visible = false;
            noti_cl.Visible = false;
            noti_ch.Visible = false;
            noti_leave_finish.Visible = false;

            noti_ins_none.Visible = false;
            noti_ins.Visible = false;
            noti_insadminknow.Visible = false;

            if (count_cl + count_ch + count_leave_finish == 0) {
                noti_leave_none.Visible = true;
            } else {
                if (count_cl != 0) {
                    noti_cl.Visible = true;
                }
                if (count_ch != 0) {
                    noti_ch.Visible = true;
                }
                if (count_leave_finish != 0) {
                    noti_leave_finish.Visible = true;
                }
            }

            if (count_ins + count_insadminknow == 0) {
                noti_ins_none.Visible = true;
            } else {
                if (count_ins != 0) {
                    noti_ins.Visible = true;
                }
                if (count_insadminknow != 0)
                {
                    noti_insadminknow.Visible = true;
                }
            }

            if (count > 0) {
                noti_alert.InnerText = "" + count;
                noti_alert.Attributes["class"] = "ps-ms-main-hd-noti-alert";
            }
            //---------
            /*{
                bool จัดการวันปฏิบัติราชการ = false;
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "' AND PERMISSION_TYPE = 1", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                จัดการวันปฏิบัติราชการ = true;
                            }
                        }
                    }
                }
                if (จัดการวันปฏิบัติราชการ) {
                    WorkingDay.Visible = true;
                } else {
                    WorkingDay.Visible = false;
                }
            }
            {
                bool ออกรายงานการลา = false;
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "' AND PERMISSION_TYPE = 2", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                ออกรายงานการลา = true;
                            }
                        }
                    }
                }
                if (ออกรายงานการลา) {
                    LeaveReport.Visible = true;
                } else {
                    LeaveReport.Visible = false;
                }
            }
            */
            FuncPermission(WorkingDay, loginPerson.CitizenID, 1);
            FuncPermission(LeaveReport, loginPerson.CitizenID, 2);
            FuncPermission(cbAddPerson1, loginPerson.CitizenID, 3);
            FuncPermission(cbAddPerson2, loginPerson.CitizenID, 4);
            FuncPermission(cbAddPerson3, loginPerson.CitizenID, 5);
            FuncPermission(cbAddPerson4, loginPerson.CitizenID, 6);
            FuncPermission(cbAddPerson5, loginPerson.CitizenID, 7);
            FuncPermission(cbAddPerson6, loginPerson.CitizenID, 8);

            FuncPermission(cbAddInsig1, loginPerson.CitizenID, 9);
            FuncPermission(cbAddInsig2, loginPerson.CitizenID, 10);
            FuncPermission(cbAddInsig4, loginPerson.CitizenID, 11);

            FuncPermission(cbAddManage1, loginPerson.CitizenID, 12);
            FuncPermission(cbAddManage2, loginPerson.CitizenID, 13);

            //---------

            if (!IsPostBack) {
                DatabaseManager.AddCounter();
            }
            s_counter.InnerText = "" + DatabaseManager.GetCounter().ToString("#,###");
        }

        private void FuncPermission(Control c, string citizenID, int type) {
            {
                bool b = false;
                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + citizenID + "' AND PERMISSION_TYPE = " + type, con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                b = true;
                            }
                        }
                    }
                }
                if (b) {
                    c.Visible = true;
                } else {
                    c.Visible = false;
                }
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e) {
            /*Response.Redirect("Salary.aspx");*/
        }

        protected void LinkButton5_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e) {
            Response.Redirect("Leave.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e) {
            Response.Redirect("SEMINAR-GENERAL.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e) {
            Response.Redirect("insignia_citizen.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e) {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e) {
            //log out
            Logout();

            Response.Redirect("Access.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e) {
            Response.Redirect("Salary.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e) {
            Response.Redirect("SalarybyID.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e) {
            Response.Redirect("Personnel-GENERAL.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e) {
            Response.Redirect("Study-IN.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e) {
            Response.Redirect("M-Admin.aspx");
        }

        private void Logout() {
            Session.Remove("login_person");
            Session.Remove("login_id");
            Session.Remove("login_system_status");
            Session.Remove("login_name");
            Session.Remove("login_lastname");
            Session.Remove("redirect_to");
            Session.Remove("login_system_status_id");
        }

        protected void LinkButton13_Click(object sender, EventArgs e) {
            Response.Redirect("Personnel-General.aspx");
        }

        protected void LinkButton14_Click(object sender, EventArgs e) {
            Response.Redirect("Person-General.aspx");
        }



        protected void LinkButton1_Click1(object sender, EventArgs e) {
            Response.Redirect("Profile.aspx");
        }

        protected void lbuLogout_Click(object sender, EventArgs e) {
            Session.Remove("PersonnelSystem");
            Response.Redirect("Access.aspx");
        }

        protected void lbuUser_Click(object sender, EventArgs e) {
            Response.Redirect("Profile.aspx");
        }
    }
}