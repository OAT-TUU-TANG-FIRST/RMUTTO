using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class INSG_Qualified : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlYear, "SELECT * FROM INS_YEAR", "YEAR_ID", "YEAR_ID", "--กรุณาเลือกปี--");
            DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาประเภทบุคลากร--");
            DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM TB_CAMPUS", "CAMPUS_NAME", "CAMPUS_ID", "--กรุณาวิทยาเขต--");
            DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY", "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกคณะ--");
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            DatabaseManager.BindGridView(gv1, "SELECT * FROM PS_PERSON");
        }
    }
}