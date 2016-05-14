using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class UpSalary70_30_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbuNext_Click(object sender, EventArgs e) {
            /*using(OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using(OracleCommand com = new OracleCommand("INSERT INTO TB_UPSALARY_1(ID_US1, NAME_US1, STATUS_US1, PERCENT_US1, PS_CITIZEN_ID, ID_RUS, ID_HUS_US1, ID_TUS_US1) VALUES(:1,:2,:3,:4,:5,:6,:7,:8)", con)) {
                    com.Parameters.Add("1", "SEQ_UPSAL_1.NEXTVAL");

                }
            }*/
            
        }
    }
}
