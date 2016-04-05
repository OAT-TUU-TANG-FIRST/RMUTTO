using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

namespace WEB_PERSONAL
{
    public partial class Report_Custom_Person : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport1.rpt"));
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "ORCL_RMUTTO"; //Database server or ODBC
            //crConnectionInfo.DatabaseName = "ORCL_RMUTTO"; // Database name
            crConnectionInfo.UserID = "RMUTTO"; // username
            crConnectionInfo.Password = "Zxcvbnm"; // password

            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
            {
                crTableLogonInfo.TableName = table.Name;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTableLogonInfos.Add(crTableLogonInfo);
                table.ApplyLogOnInfo(crTableLogonInfo);
            }
            CrystalReportViewer1.LogOnInfo = crTableLogonInfos;
            //rpt.SetParameterValue("CITIZEN PARAMETER", this.txt1.Text);
            CrystalReportViewer1.ReportSource = rpt;
            
        }

    }
}