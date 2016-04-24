using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class LeaveManager : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DatabaseManager.BindGridView(gv1, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 1 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
                DatabaseManager.BindGridView(gv2, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 2 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
                DatabaseManager.BindGridView(gv3, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 3 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
            }
        }

        protected void lbuLF1Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
            lbuLF1Select.CssClass = "ps-vs-sel";
            lbuLF2Select.CssClass = "ps-vs";
            lbuLF3Select.CssClass = "ps-vs";
        }

        protected void lbuLF2Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
            lbuLF1Select.CssClass = "ps-vs";
            lbuLF2Select.CssClass = "ps-vs-sel";
            lbuLF3Select.CssClass = "ps-vs";
        }

        protected void lbuLF3Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
            lbuLF1Select.CssClass = "ps-vs";
            lbuLF2Select.CssClass = "ps-vs";
            lbuLF3Select.CssClass = "ps-vs-sel";
        }
    }
}