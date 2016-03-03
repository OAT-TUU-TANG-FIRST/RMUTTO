using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_PERSONAL
{
    public partial class SEMINAR_ADMIN : System.Web.UI.Page
    {
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtName.Text = row.Cells[2].Text;
        }
        protected void btnCancelSeminar_Click(object sender, EventArgs e)
        {
            //ClearData();
        }


        protected void txtDateTO_TextChanged(object sender, EventArgs e)
        {
            DateTime df = DateTime.Parse(txtDateFrom.Text);
            DateTime dt = DateTime.Parse(txtDateTO.Text);
            int day = (int)(dt - df).TotalDays + 1;

            int year = (day / 365);
            int month = (day % 365) / 30;
            day = (day % 365) % 30;

            txtYear.Text = "" + year;
            txtMonth.Text = "" + month;
            txtDay.Text = "" + day;
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            DateTime df = DateTime.Parse(txtDateFrom.Text);
            DateTime dt = DateTime.Parse(txtDateTO.Text);
            int day = (int)(dt - df).TotalDays + 1;

            int year = (day / 365);
            int month = (day % 365) / 30;
            day = (day % 365) % 30;

            txtYear.Text = "" + year;
            txtMonth.Text = "" + month;
            txtDay.Text = "" + day;
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            txtSupportBudget.Text = chkBox.Checked.ToString();
            if (chkBox.Checked)
            {
                txtCertificate.Enabled = true;
                txtCertificate.Text = "";
            }
            else
            {
                txtCertificate.Enabled = false;
                txtCertificate.Text = "ไม่มี";
            }
        }

        protected void btnSubmitSeminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchSeminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}