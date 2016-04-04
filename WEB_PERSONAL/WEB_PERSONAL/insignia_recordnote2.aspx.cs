using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WEB_PERSONAL.Class;



namespace WEB_PERSONAL
{
    public partial class insignia_recordnote_2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=203.158.140.67;Initial Catalog=personal;Integrated Security=False;User ID=rmutto1;Password=Zxcvbnm!");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Cmd = con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "insert into TB_recordnote value()";
            Cmd.ExecuteNonQuery();

            con.Close();
            Response.Redirect("insignia_recordnote2.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ราชกิจจานุเบกษา";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                /*HeaderCell = new TableCell();
                HeaderCell.Text = "ใบกำกับ";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "เหรียญตราฯ";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);*/

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Person P = DatabaseManager.GetPerson(TextBox1.Text);
            TextBox2.Text = P.FirstNameAndLastName;
            GridView1.DataSourceID = null;
            SqlDataSource sds = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", "select tb_recordnote1.id, tb_recordnote1.citizen_id, person_name || ' ' || person_lastname, to_char(DDATE,'DD MON YYYY','NLS_DATE_LANGUAGE = THAI'), POSITION_WORK_NAME, POSITION_NAME, GRADEINSIGNIA_NAME, GAZETTE_LAM, GAZETTE_TON, GAZETTE_NA, GAZETTE_DATE, INVOICE, DECORATION, NOTES from tb_recordnote1, tb_person where tb_recordnote1.citizen_id = tb_person.citizen_id and tb_person.citizen_id = " + TextBox1.Text);
            
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("insignia_print.aspx?citizen_id="+TextBox1.Text);
        }
    }
}