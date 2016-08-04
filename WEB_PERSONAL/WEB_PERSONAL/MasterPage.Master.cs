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
            OracleConnection.ClearAllPools();
        }

        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            lbName.Text = loginPerson.FullName;
            lbStaffType.Text = loginPerson.StaffTypeName;
            lbPosition.Text = loginPerson.PositionWorkName;
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

            //---------
            int count_approve = 0;
            int count_leave_finish = 0;
            int count_ins = 0;
            int count_get_ins = 0;

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                

                using (OracleCommand com = new OracleCommand("SELECT COUNT(LEV_BOSS_DATA.LEAVE_BOSS_ID) FROM LEV_DATA, LEV_BOSS_DATA WHERE LEAVE_STATUS_ID IN(1,4) AND LEV_DATA.LEAVE_ID = LEV_BOSS_DATA.LEAVE_ID AND LEV_DATA.BOSS_STATE = LEV_BOSS_DATA.STATE AND LEV_BOSS_DATA.CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_approve = reader.GetInt32(0);
                        }
                    }
                }
                if (count_approve != 0) {
                    lbLeaveAllowCount.Text = "" + count_approve;
                    lbLeaveAllowCount.Visible = true;
                } else {
                    lbLeaveAllowCount.Text = "";
                    lbLeaveAllowCount.Visible = false;
                }

                using (OracleCommand com = new OracleCommand("SELECT COUNT(LEAVE_ID) FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_STATUS_ID in(3,7)", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_leave_finish = reader.GetInt32(0);
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT COUNT(IR_ID) FROM TB_INSIG_REQUEST WHERE IR_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND IR_STATUS = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_ins = reader.GetInt32(0);
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT COUNT(IR_ID) FROM TB_INSIG_REQUEST WHERE IR_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND IR_STATUS = 3", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_get_ins = reader.GetInt32(0);
                        }
                    }
                }


                int count = count_approve + count_leave_finish + count_ins + count_get_ins;

                noti_leave_none.Visible = false;
                noti_approve.Visible = false;
                noti_leave_finish.Visible = false;

                noti_ins_none.Visible = false;
                noti_ins.Visible = false;
                noti_get_ins.Visible = false;

                if (count_approve + count_leave_finish == 0) {
                    noti_leave_none.Visible = true;
                } else {
                    if (count_approve != 0) {
                        noti_approve.Visible = true;
                    }
                    if (count_leave_finish != 0) {
                        noti_leave_finish.Visible = true;
                    }
                }

                if (count_ins + count_get_ins == 0) {
                    noti_ins_none.Visible = true;
                } else {
                    if (count_ins != 0) {
                        noti_ins.Visible = true;
                    }
                    if (count_get_ins != 0) {
                        noti_get_ins.Visible = true;
                    }
                }

                if (count > 0) {
                    noti_alert.InnerText = "" + count;
                    noti_alert.Attributes["class"] = "ps-ms-main-hd-noti-alert";
                }

                //--Permission--

                WorkingDay.Visible = false;
                LeaveReport.Visible = false;
                cbAddPerson1.Visible = false;
                cbAddPerson2.Visible = false;
                cbAddPerson6.Visible = false;
                cbAddInsig1.Visible = false;
                cbAddInsig2.Visible = false;
                
                cbAddManage1.Visible = false;
                cbAddManage2.Visible = false;
                cbPersonPosition.Visible = false;
                

                using (OracleCommand com = new OracleCommand("SELECT PERMISSION_TYPE FROM TB_PERMISSION WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            int type = reader.GetInt32(0);
                            if (type == 1) WorkingDay.Visible = true;
                            else if (type == 2) LeaveReport.Visible = true;
                            else if (type == 3) cbAddPerson1.Visible = true;
                            else if (type == 4) cbAddPerson2.Visible = true;
                            //else if (type == 5) cbAddPerson3.Visible = true;
                            //else if (type == 6) cbAddPerson4.Visible = true;
                            else if (type == 8) cbAddPerson6.Visible = true;
                            else if (type == 9) cbAddInsig1.Visible = true;
                            else if (type == 10) cbAddInsig2.Visible = true;
                            //else if (type == 11) cbAddInsig4.Visible = true;
                            else if (type == 12) cbAddManage1.Visible = true;
                            else if (type == 13) cbAddManage2.Visible = true;
                            else if (type == 14) cbPersonPosition.Visible = true;
                            //else if (type == 15) cbPosition.Visible = true;
                            

                        }
                    }
                }

                if (!IsPostBack) {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_WEB SET COUNTER = COUNTER+1 WHERE ID = 1", con)) {
                        com.ExecuteNonQuery();
                    }
                    //s_counter.InnerText = "" + DatabaseManager.GetCounter().ToString("#,###");
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