using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PERSONAL
{
    public partial class ListPerson_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearchCitizenID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM PS_PERSON WHERE PS_CITIZEN_ID = :PS_CITIZEN_ID";
            SqlDataSource1.SelectParameters.Add(":PS_CITIZEN_ID", txtSearchCitizenID.Text);
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPerson-ADMIN.aspx");
        }
    }
}