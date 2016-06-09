using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class INSG_Request : System.Web.UI.Page {

        private bool work = true;

        protected void Page_Load(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) FROM TB_INSIG_REQUEST WHERE IR_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "' AND IR_STATUS = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            tbInsig.Text = reader.GetString(0);
                            //tbCitizen.Text = reader.IsDBNull(0) ? "" : reader.GetString(0) + " ";
                        }
                    }
                }
            }
        }

        protected void lbuSubmitView2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ได้ทำการขอเครื่องราชฯ เรียบร้อยแล้ว !')", true);
        }
    }
}