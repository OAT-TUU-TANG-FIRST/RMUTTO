using Rmutto.Connection;
using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using System.Collections;
using System.Drawing;
using CrystalDecisions.Web;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using System.Runtime.CompilerServices;

namespace WEB_PERSONAL
{
    public partial class Report_Custom_Person : System.Web.UI.Page
    {
        OracleConnection conn = ConnectionDB.GetOracleConnection();

        ArrayList ParameterArrayList = new ArrayList(); //Report parameter list
        ReportDocument ObjReportClientDocument = new ReportDocument(); //Report document

        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/Personnel1.rpt"));
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "ORCL_RMUTTO"; //Database server or ODBC
            crConnectionInfo.DatabaseName = ""; // Database name
            crConnectionInfo.UserID = "RMUTTO"; // username
            crConnectionInfo.Password = "Zxcvbnm"; // password
            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            rpt.SetDatabaseLogon("RMUTTO", "Zxcvbnm");
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
            {
                crTableLogonInfo.TableName = table.Name;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTableLogonInfos.Add(crTableLogonInfo);
                table.ApplyLogOnInfo(crTableLogonInfo);
            }
            CrystalReportViewer1.LogOnInfo = crTableLogonInfos;
            CrystalReportViewer1.ReportSource = rpt;
            

            ReportDocument();
        }

        ///

        protected void ReportDocument()
        {
            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();

            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";

            strSQL.Append(" SELECT PS_CITIZEN_ID, PS_FN_TH, PS_LN_TH, (SELECT GENDER_NAME FROM TB_GENDER WHERE GENDER_ID = PS_GENDER_ID) PS_GENDER_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = PS_STAFFTYPE_ID) PS_STAFFTYPE_ID");
            strSQL.Append(" FROM PS_PERSON ");

            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds, "myDataReport");
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();

            rpt.Load(Server.MapPath("~/Reports/Personnel1.rpt"));
            rpt.SetDatabaseLogon("RMUTTO", "Zxcvbnm");
            rpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void ReportDocumentWhere()
        {
            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();

            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";

            strSQL.Append(" SELECT PS_CITIZEN_ID, PS_FN_TH, PS_LN_TH, (SELECT GENDER_NAME FROM TB_GENDER WHERE GENDER_ID = PS_GENDER_ID) PS_GENDER_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = PS_STAFFTYPE_ID) PS_STAFFTYPE_ID");
            strSQL.Append(" FROM PS_PERSON ");
            strSQL.Append(" WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");

            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds, "myDataReport");
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();

            rpt.Load(Server.MapPath("~/Reports/Personnel1.rpt"));
            rpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            ReportDocumentWhere();
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ReportDocument();
        }
    }
}