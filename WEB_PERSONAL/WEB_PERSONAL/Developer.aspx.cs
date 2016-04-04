using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;

namespace WEB_PERSONAL {
    public partial class Developer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OleDbCommand com = new OleDbCommand("SELECT OWNER, TABLE_NAME FROM DBA_TABLES WHERE OWNER = 'RMUTTO' ORDER BY TABLE_NAME ASC", con)) {
                        using (OleDbDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                ListBox1.Items.Add(new ListItem(reader.GetValue(1).ToString()));
                            }
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
    }
}