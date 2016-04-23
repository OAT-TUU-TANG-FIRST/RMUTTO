using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class MasterPage : System.Web.UI.MasterPage {

        protected void Page_Init(object sender, EventArgs e) {
            if (PersonnelSystem.GetPersonnelSystem(this) == null) {
                Response.Redirect("Access.aspx");
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            string name = loginPerson.FirstNameAndLastName;
            LinkButton1.Text = "<img src='Image/Small/person2.png'/>" + name;
            LinkButton10.Visible = true;
            
            string personImageFileName = DatabaseManager.GetPersonImageFileName(loginPerson.CitizenID);
            if (personImageFileName != "") {
                profile_pic.Src = "Upload/PersonImage/" + personImageFileName;
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
            
            

            if (!IsPostBack) {
                DatabaseManager.AddCounter();
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

   

 

    }
}