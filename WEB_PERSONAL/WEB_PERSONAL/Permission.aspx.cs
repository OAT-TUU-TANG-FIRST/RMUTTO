using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class Permission : System.Web.UI.Page {

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
                if (found) {
                    hfCitizenID.Value = tbCitizenID.Text;
                    d1.Style.Add("display", "block");
                    cb1.Checked = false;
                    cb2.Checked = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + tbCitizenID.Text + "'", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                int type = reader.GetInt32(2);
                                if (type == 1) { cb1.Checked = true; }
                                else if (type == 2) { cb2.Checked = true; }
                                else if (type == 3) { cb3.Checked = true; }
                                else if (type == 4) { cb4.Checked = true; }
                                else if (type == 5) { cb5.Checked = true; }
                                else if (type == 6) { cb6.Checked = true; }
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
                Exe(cb1, citizenID, 1);
                Exe(cb2, citizenID, 2);
                Exe(cb3, citizenID, 3);
                Exe(cb4, citizenID, 4);
                Exe(cb5, citizenID, 5);
                Exe(cb6, citizenID, 6);
                /*if (cb1.Checked) {
                    bool have = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + citizenID + "' AND PERMISSION_TYPE = 1", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                have = true;
                            }
                        }
                    }
                    if (!have) {
                        using (OracleCommand com = new OracleCommand("INSERT INTO TB_PERMISSION VALUES(SEQ_PERMISSION_ID.NEXTVAL, :PS, 1)", con)) {
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
                }*/


            }
        }

        private void Exe(CheckBox cb, string citizenID, int type) {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                if (cb.Checked) {
                    bool have = false;
                    using (OracleCommand com = new OracleCommand("SELECT * FROM TB_PERMISSION WHERE CITIZEN_ID = '" + citizenID + "' AND PERMISSION_TYPE = " + type, con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                have = true;
                            }
                        }
                    }
                    if (!have) {
                        using (OracleCommand com = new OracleCommand("INSERT INTO TB_PERMISSION VALUES(SEQ_PERMISSION_ID.NEXTVAL, :PS, " + type + ")", con)) {
                            com.Parameters.Add("PS", citizenID);
                            com.ExecuteNonQuery();
                        }
                    }
                } else {
                    using (OracleCommand com = new OracleCommand("DELETE TB_PERMISSION WHERE CITIZEN_ID = :PS AND PERMISSION_TYPE = " + type, con)) {
                        com.Parameters.Add("PS", citizenID);
                        com.ExecuteNonQuery();
                    }
                }
            }
                
        }

    }
}