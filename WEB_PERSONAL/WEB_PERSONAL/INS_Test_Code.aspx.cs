using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PERSONAL
{
    public partial class INS_Test_Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BT1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "select * from INS_COMMAND";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            
        }
    }
}