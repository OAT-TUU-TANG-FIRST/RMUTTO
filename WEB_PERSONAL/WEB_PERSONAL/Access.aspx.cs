using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Threading;

namespace WEB_PERSONAL {
    public partial class Access : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                
                if(Request.QueryString["ID"] != null && Request.QueryString["Password"] != null && Request.QueryString["Action"] != null) {
                    if (DatabaseManager.ValidateUser(Request.QueryString["ID"], Request.QueryString["Password"])) {
                        PersonnelSystem ps = new PersonnelSystem();
                        ps.LoginPerson = DatabaseManager.GetPerson(Request.QueryString["ID"].ToString());
                        Session["PersonnelSystem"] = ps;
                        if(Request.QueryString["Action"] == "1") {
                            Response.Redirect("ChangePassword.aspx");
                        } else {
                            Response.Redirect("Default.aspx");
                        }
                    } else {
                        Label12X.Text = "รหัสผ่านไม่ถูกต้อง!";
                    }
                }
            }
        }
        protected void lbuLogin_Click(object sender, EventArgs e) {      
            int count = DatabaseManager.ExecuteInt("SELECT count(*) FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + tbUsername.Text + "'");
            if(count == 0) {
                Label12X.Text = "ไม่พบผู้ใช้งาน!";
            } else {
                if(DatabaseManager.ValidateUser(tbUsername.Text, tbPassword.Text)) {
                    PersonnelSystem ps = new PersonnelSystem();
                    ps.LoginPerson = DatabaseManager.GetPerson(tbUsername.Text);
                    Session["PersonnelSystem"] = ps;
                    Response.Redirect("Default.aspx");
                } else {
                    Label12X.Text = "รหัสผ่านไม่ถูกต้อง!";
                }
                
            }
        }

    }
}