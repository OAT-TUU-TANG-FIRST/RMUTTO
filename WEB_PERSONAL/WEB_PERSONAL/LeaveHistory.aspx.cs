using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class LeaveHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person loginPerson = ps.LoginPerson;
                {
                    SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM LEV_MAIN WHERE LEAVE_STATE not in(100,101) AND CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                    GridView1.DataSource = sds;
                    GridView1.DataBind();
                }
                {
                    SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM LEV_MAIN WHERE LEAVE_STATE = 100 AND CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                    GridView2.DataSource = sds;
                    GridView2.DataBind();
                }
                {
                    SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM LEV_MAIN WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                    GridView3.DataSource = sds;
                    GridView3.DataBind();
                }

            }
        }
    }
}