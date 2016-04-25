using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PERSONAL
{
    public partial class UpSalary80_20_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double result = double.Parse(TextBox5.Text) * 30f / 80f;
            double result1 = double.Parse(TextBox7.Text) * 5f / 80f;
            double result2 = double.Parse(TextBox9.Text) * 10f / 80f;
            Label1.Text = result.ToString("0.00");
            Label4.Text = result1.ToString("0.00");
            Label12.Text = result2.ToString("0.00");
            Button3.Visible = true;
        }
    }
}