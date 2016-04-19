using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class ChangePassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void lbuFinish_Click(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person pp = ps.LoginPerson;
            DatabaseManager.ExecuteNonQuery("UPDATE PS_PERSON SET PS_PASSWORD = '" + tbNew.Text + "' WHERE PS_CITIZEN_ID = '" + pp.CitizenID + "'");
        }
    }
}