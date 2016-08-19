using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {

    public partial class DataManager : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            Person ps = PersonnelSystem.GetPersonnelSystem(this).LoginPerson;
            if (ps.Permission == 1)
            {
                Response.Redirect("NoPermission.aspx");
            }
        }

    }

}