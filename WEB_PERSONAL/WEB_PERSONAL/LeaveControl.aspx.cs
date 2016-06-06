using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class LeaveControl : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lbSaveComplete.Visible = false;
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            d1.Style.Add("display", "none");
            d2.Style.Add("display", "none");
            bool found = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + tbCitizenID.Text + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            found = true;
                            lbName.Text = reader.GetString(0);
                        }
                    }
                }
                if(found) {
                    hfCitizenID.Value = tbCitizenID.Text;
                    d1.Style.Add("display", "block");
                    cb1.Checked = false;
                    cb2.Checked = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_ACT WHERE PS_CITIZEN_ID = '" + tbCitizenID.Text + "'", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                int type = reader.GetInt32(2);
                                if (type == 1) {
                                    cb1.Checked = true;
                                } else if (type == 2) {
                                    cb2.Checked = true;
                                }
                            }
                        }
                    }
                } else {
                    d2.Style.Add("display", "block");
                }
               
            }
            
        }

        protected void lbuSave_Click(object sender, EventArgs e) {
            string citizenID = hfCitizenID.Value;
            lbSaveComplete.Visible = true;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();

                if(cb1.Checked) {
                    bool have = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_ACT WHERE PS_CITIZEN_ID = '" + citizenID + "' AND TYPE = 1", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                have = true;
                            }
                        }
                    }
                    if(!have) {
                        using (OracleCommand com = new OracleCommand("INSERT INTO LEV_ACT VALUES(SEQ_LEAVE_ACT_ID.NEXTVAL, :PS, 1)", con)) {
                            com.Parameters.Add("PS", citizenID);
                            com.ExecuteNonQuery();
                        }
                    }
                } else {
                    using (OracleCommand com = new OracleCommand("DELETE LEV_ACT WHERE PS_CITIZEN_ID = :PS AND TYPE = 1", con)) {
                        com.Parameters.Add("PS", citizenID);
                        com.ExecuteNonQuery();
                    }
                }

                if (cb2.Checked) {
                    bool have = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_ACT WHERE PS_CITIZEN_ID = '" + citizenID + "' AND TYPE = 2", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                have = true;
                            }
                        }
                    }
                    if (!have) {
                        using (OracleCommand com = new OracleCommand("INSERT INTO LEV_ACT VALUES(SEQ_LEAVE_ACT_ID.NEXTVAL, :PS, 2)", con)) {
                            com.Parameters.Add("PS", citizenID);
                            com.ExecuteNonQuery();
                        }
                    }
                } else {
                    using (OracleCommand com = new OracleCommand("DELETE LEV_ACT WHERE PS_CITIZEN_ID = :PS AND TYPE = 2", con)) {
                        com.Parameters.Add("PS", citizenID);
                        com.ExecuteNonQuery();
                    }
                }


            }
        }
    }
}