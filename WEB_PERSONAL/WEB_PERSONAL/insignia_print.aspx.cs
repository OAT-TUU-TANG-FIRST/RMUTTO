using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL
{
    public partial class insignia_print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person P = DatabaseManager.GetPerson(Request.QueryString["citizen_id"].ToString());
            //TextBox2.Text = P.NameAndLastname;
            GridView1.DataSourceID = null;
            SqlDataSource sds = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", "select tb_recordnote1.id, tb_recordnote1.citizen_id, person_name || ' ' || person_lastname, to_char(DDATE,'DD MON YYYY','NLS_DATE_LANGUAGE = THAI'), POSITION_WORK_NAME, POSITION_NAME, GRADEINSIGNIA_NAME, GAZETTE_LAM, GAZETTE_TON, GAZETTE_NA, GAZETTE_DATE, INVOICE, DECORATION, NOTES from tb_recordnote1, tb_person where tb_recordnote1.citizen_id = tb_person.citizen_id and tb_person.citizen_id = " + Request.QueryString["citizen_id"].ToString());

            GridView1.DataSource = sds;
            GridView1.DataBind();
        }
    }
}