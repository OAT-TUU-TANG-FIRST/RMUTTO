using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

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

                    if (DatabaseManager.ExecuteInt("SELECT COUNT(*) FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear()) == 0) {
                        using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                            con.Open();
                            using (OracleCommand com = new OracleCommand("INSERT INTO LEV_CLAIM (LEAVE_CLAIM_ID, PS_CITIZEN_ID, YEAR, SICK_NOW, SICK_REQ, BUSINESS_NOW, BUSINESS_REQ, GB_NOW, GB_REQ, REST_NOW, REST_REQ, REST_SAVE, REST_SAVE_FIX, REST_THIS, REST_THIS_FIX, REST_MAX, HGB_NOW, HGB_REQ, ORDAIN_NOW, ORDAIN_REQ, HUJ_NOW, HUJ_REQ) VALUES (SEQ_LEV_CLAIM_ID.NEXTVAL, :PS_CITIZEN_ID, :YEAR, :SICK_NOW, :SICK_REQ, :BUSINESS_NOW, :BUSINESS_REQ, :GB_NOW, :GB_REQ, :REST_NOW, :REST_REQ, :REST_SAVE, :REST_SAVE_FIX, :REST_THIS, :REST_THIS_FIX, :REST_MAX, :HGB_NOW, :HGB_REQ, :ORDAIN_NOW, :ORDAIN_REQ, :HUJ_NOW, :HUJ_REQ)", con)) {
                                
                                com.Parameters.Add("PS_CITIZEN_ID", ps.LoginPerson.CitizenID);
                                com.Parameters.Add("YEAR", Util.BudgetYear());
                                int v1 = 0;
                                int v2 = 10;
                                com.Parameters.Add("SICK_NOW", v1);
                                com.Parameters.Add("SICK_REQ", v1);
                                com.Parameters.Add("BUSINESS_NOW", v1);
                                com.Parameters.Add("BUSINESS_REQ", v1);
                                com.Parameters.Add("GB_NOW", v1);
                                com.Parameters.Add("GB_REQ", v1);
                                com.Parameters.Add("REST_NOW", v1);
                                com.Parameters.Add("REST_REQ", v1);
                                com.Parameters.Add("REST_SAVE", v1);
                                com.Parameters.Add("REST_SAVE_FIX", v1);
                                com.Parameters.Add("REST_THIS", v2);
                                com.Parameters.Add("REST_THIS_FIX", v2);
                                com.Parameters.Add("REST_MAX", v2);
                                com.Parameters.Add("HGB_NOW", v1);
                                com.Parameters.Add("HGB_REQ", v1);
                                com.Parameters.Add("ORDAIN_NOW", v1);
                                com.Parameters.Add("ORDAIN_REQ", v1);
                                com.Parameters.Add("HUJ_NOW", v1);
                                com.Parameters.Add("HUJ_REQ", v1);
                                com.ExecuteNonQuery();
                            }
                        }

                    }

                    Response.Redirect("Default.aspx");
                } else {
                    Label12X.Text = "รหัสผ่านไม่ถูกต้อง!";
                }
                
            }
        }

    }
}