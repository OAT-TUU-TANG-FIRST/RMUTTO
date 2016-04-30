using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;

namespace WEB_PERSONAL
{
    public partial class insignia_from_view : System.Web.UI.Page
    {

        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("insignia_from_edit.aspx");
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            Other.Visible = !Other.Visible;
        }
    }
}


