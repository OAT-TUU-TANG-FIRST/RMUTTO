using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class Developer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {


            if(!IsPostBack) {
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT OWNER, TABLE_NAME FROM DBA_TABLES WHERE OWNER = 'RMUTTO' ORDER BY TABLE_NAME ASC", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                ListBox1.Items.Add(new ListItem(reader.GetValue(1).ToString()));
                            }
                        }
                    }
                }
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT PS_CITIZEN_ID, PS_FN_TH, PS_LN_TH FROM PS_PERSON");
                GridView2.DataSource = sds;
                GridView2.DataBind();
            }
            
        }
        protected void Page_LoadComplete(object sender, EventArgs e) {

            lbo1.Items.Clear();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT * FROM TB_CHAT", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            lbo1.Items.Add(new ListItem(reader.GetString(1) + " : " + reader.GetString(2)));
                        }
                    }
                }
            }
        }

        protected void lbuSQL_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource(tbSQL.Text);
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void lbuTableSQL_Click(object sender, EventArgs e) {
            SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM " + ListBox1.SelectedValue);
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e) {
            int max = MultiView1.Views.Count;
            int next = MultiView1.ActiveViewIndex + 1;
            if(next >= max) {
                next = 0;
            }
            MultiView1.ActiveViewIndex = next;
        }

        protected void btnSqlUpdate_Click(object sender, EventArgs e) {
            DatabaseManager.ExecuteNonQuery(tbSqlUpdate.Text);
        }

        protected void Button2_Click(object sender, EventArgs e) {
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = "1";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "2";
            row.Cells.Add(cell);

            Table1.Rows.Add(row);

            //Session["dev_t1"] = Table1;

        }

        protected void LinkButton1_Click(object sender, EventArgs e) {
            TextBox1.Text = "" + new Random().Next();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "openPopup('popup1');", true);
        }

        protected void lbuSearchCitizenID_Click(object sender, EventArgs e) {
            if(TextBox1.Text == "") {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM PS_PERSON ORDER BY PS_CITIZEN_ID ASC");
                GridView2.DataSource = sds;
            } else {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT * FROM PS_PERSON WHERE PS_CITIZEN_ID LIKE '%" + TextBox1.Text + "%' ORDER BY PS_CITIZEN_ID ASC");
                GridView2.DataSource = sds;
            }
            GridView2.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "openPopup('popup1');", true);
        }

        protected void lbc_Click(object sender, EventArgs e) {
            DatabaseManager.ExecuteNonQuery("INSERT INTO TB_CHAT VALUES(SEQ_CHAT_ID.NEXTVAL, '" + tbc1.Text + "','" + tbc2.Text + "')");
        }
    }
}