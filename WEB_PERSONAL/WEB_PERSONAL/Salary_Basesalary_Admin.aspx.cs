using System;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class Salary_Basesalary_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_system_status_id"].ToString() != "1")
            {
                Response.Redirect("Default.aspx");
            }
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn  = Util.OC())
            {
                try
                {
                    if (LinkButton2.Text == "เพิ่มข้อมูลฐานเงินเดือน")
                    {
                        DropDownList1.Enabled = true;
                        String sql = "INSERT INTO TB_BASESALARY VALUES (SEQ_BASESALARY_ID.NEXTVAL,:1,:2,:3,:4,:5)";
                        sql = String.Format(sql, DropDownList1.SelectedValue, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {
                            command.Parameters.Add("1", DropDownList1.SelectedValue);
                            command.Parameters.Add("2", TextBox1.Text);
                            command.Parameters.Add("3", TextBox2.Text);
                            command.Parameters.Add("4", TextBox3.Text);
                            command.Parameters.Add("5", TextBox4.Text);
                            command.ExecuteNonQuery();
                            Session.Remove("base_id");
                        }
                        Util.Alert(this, "Insert Successful.");
                    }
                    else
                    {
                        String sql = "UPDATE TB_BASESALARY SET POSITION_ID=:1,MAXSALARY=:2,MINSALARY=:3,MAXLOWSALARY=:4,MINLOWSALARY=:5 WHERE ID = :0";
                        sql = String.Format(sql, DropDownList1.SelectedValue, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {
                            command.Parameters.Add("0", Session["base_id"].ToString());
                            command.Parameters.Add("1", DropDownList1.SelectedValue);
                            command.Parameters.Add("2", TextBox1.Text);
                            command.Parameters.Add("3", TextBox2.Text);
                            command.Parameters.Add("4", TextBox3.Text);
                            command.Parameters.Add("5", TextBox4.Text);
                            command.ExecuteNonQuery();
                            Session.Remove("base_id");
                        }
                        Util.Alert(this, "Update Successful.");
                    }
                }
                catch
                {

                }
                
            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            DropDownList1.ClearSelection();
            DropDownList1.Items.FindByText(row.Cells[2].Text).Selected = true;
            Session["base_id"] = row.Cells[1].Text;
            TextBox1.Text = row.Cells[3].Text;
            TextBox2.Text = row.Cells[4].Text;
            TextBox3.Text = row.Cells[5].Text;
            TextBox4.Text = row.Cells[6].Text;
            LinkButton2.Text = "อัพเดทฐานเงินเดือน";
            DropDownList1.Enabled = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        //------------------Permanent Emp------------------------------------
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;

            Session["Per_EMP_ID"] = row.Cells[1].Text;
            TextBox5.Text = row.Cells[2].Text;
            TextBox6.Text = row.Cells[3].Text;
            TextBox7.Text = row.Cells[4].Text;
            TextBox8.Text = row.Cells[5].Text;
            LinkButton2.Text = "อัพเดทฐานเงินเดือน";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Per_EMP"] = DropDownList2.SelectedValue;
        }
        protected void LinkButton2x_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = Util.OC())
            {
                try
                {
                    if (LinkButton2.Text == "เพิ่มข้อมูลฐานเงินเดือน")
                    {
                        DropDownList1.Enabled = true;
                        String sql = "INSERT INTO TB_BASESALARY_PERMANENT_EMP VALUES (SEQ_BASE_PER.NEXTVAL,:1,:2,:3,:4,:5)";
                        sql = String.Format(sql, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, Session["Per_EMP"].ToString());
                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {
                            command.Parameters.Add("1", TextBox5.Text);
                            command.Parameters.Add("2", TextBox6.Text);
                            command.Parameters.Add("3", TextBox7.Text);
                            command.Parameters.Add("4", TextBox8.Text);
                            command.Parameters.Add("5", Session["Per_EMP"].ToString());
                            command.ExecuteNonQuery();
                            Session.Remove("Per_EMP");
                            Session.Remove("Per_EMP_ID");
                        }
                        Util.Alert(this, "Insert Successful.");
                    }
                    else
                    {
                        String sql = "UPDATE TB_BASESALARY SET \"LEVEL\"=:1,PERMONTH=:2,PERDAY=:3,PERHOUR=:4,STAFF_GROUP=:5 WHERE ID = :0";
                        sql = String.Format(sql, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, Session["Per_EMP"].ToString());
                        using (OracleCommand command = new OracleCommand(sql, conn))
                        {
                            command.Parameters.Add("0", Session["Per_EMP_ID"].ToString());
                            command.Parameters.Add("1", TextBox5.Text);
                            command.Parameters.Add("2", TextBox6.Text);
                            command.Parameters.Add("3", TextBox7.Text);
                            command.Parameters.Add("4", TextBox8.Text);
                            command.Parameters.Add("5", Session["Per_EMP"].ToString());
                            command.ExecuteNonQuery();
                            Session.Remove("Per_EMP");
                            Session.Remove("Per_EMP_ID");
                        }
                        Util.Alert(this, "Update Successful.");
                    }
                }
                catch
                {

                }

            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel_Gov_Base.Visible = true;
            Panel_Per_EMP.Visible = false;
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Panel_Gov_Base.Visible = false;
            Panel_Per_EMP.Visible = true;
        }
    }
}