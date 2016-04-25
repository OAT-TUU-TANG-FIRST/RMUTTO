using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class Salary_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Oracleloop();
        }
        private void Oracleloop()
        {
            List<int> branch_ids = new List<int>();
            string sql = "";
            using (OracleConnection conn = Util.OC())
            {
                using (OracleCommand command = new OracleCommand("SELECT BRANCH_ID FROM TB_BRANCH", conn))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            branch_ids.Add(reader.GetInt32(0));
                        }
                        
                    }
                }
            }
            for(int i=0;i<branch_ids.Count-1;++i)
            {
                sql += "SELECT * FROM(SELECT TB_BRANCH.BRANCH_NAME, TB_DPIS.COUNT_PEOPLE, TB_DPIS.SUM_SALARY, TB_DPIS.RATE_SUMSALARY, TB_DPIS.RATE_MONEY_UP, TB_DPIS.RATE_BALANCE, TB_DPIS.SUM_PRE_MONTH, TB_DPIS.ADMIN_MONEY_ADD, TB_DPIS.SUM_MONEY_UP, TB_DPIS.SUM_MONEY_TOTAL, TB_DPIS.SUM_BALANCE, nvl(TB_DPIS.\"COMMENT\", ' ') as \"COMMENT\" FROM TB_DPIS, TB_BRANCH WHERE tb_dpis.branch_id = " + i + " and TB_DPIS.BRANCH_ID = TB_BRANCH.BRANCH_ID order by tb_dpis.dpis_id desc) where rownum = 1 UNION ";
            }
            sql += "SELECT * FROM(SELECT TB_BRANCH.BRANCH_NAME, TB_DPIS.COUNT_PEOPLE, TB_DPIS.SUM_SALARY, TB_DPIS.RATE_SUMSALARY, TB_DPIS.RATE_MONEY_UP, TB_DPIS.RATE_BALANCE, TB_DPIS.SUM_PRE_MONTH, TB_DPIS.ADMIN_MONEY_ADD, TB_DPIS.SUM_MONEY_UP, TB_DPIS.SUM_MONEY_TOTAL, TB_DPIS.SUM_BALANCE, nvl(TB_DPIS.\"COMMENT\", ' ') as \"COMMENT\" FROM TB_DPIS, TB_BRANCH WHERE tb_dpis.branch_id = " + branch_ids[branch_ids.Count-1] + " and TB_DPIS.BRANCH_ID = TB_BRANCH.BRANCH_ID order by tb_dpis.dpis_id desc) where rownum = 1";
            SqlDataSource sds = new SqlDataSource("System.Data.OracleClient", "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;", sql);
            GridView1.DataSourceID = null;
            GridView1.DataSource = sds;
            GridView1.DataBind();
        }
    }
}