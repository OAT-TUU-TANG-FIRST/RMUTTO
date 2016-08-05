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
            
            ReportGP7();
            //ReportStudy();

        }

        ///

        protected void ReportGP7()
        {
            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();

            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";

            strSQL.Append("SELECT (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE MINISTRY_ID = PS_MINISTRY_ID) PS_MINISTRY_ID,");
            strSQL.Append("PS_GROM,");
            strSQL.Append("PS_CITIZEN_ID,");
            strSQL.Append("(SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TITLE_ID = PS_TITLE_ID) PS_TITLE_ID,");
            strSQL.Append("PS_FN_TH,");
            strSQL.Append("PS_LN_TH,");
            strSQL.Append("(TO_CHAR(PS_BIRTHDAY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI')) PS_BIRTHDAY_DATE,");
            strSQL.Append("PS_BIRTHDAY_LONG,");
            strSQL.Append("(TO_CHAR(PS_RETIRE_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI')) PS_RETIRE_DATE,");
            strSQL.Append("PS_RETIRE_LONG,");
            strSQL.Append("(TO_CHAR(PS_INWORK_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI')) PS_INWORK_DATE,");
            strSQL.Append("(SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = PS_STAFFTYPE_ID) PS_STAFFTYPE_ID,");
            strSQL.Append("PS_DAD_FN || '  ' || PS_DAD_LN PS_DAD_FN,");
            strSQL.Append("PS_MOM_FN || '  ' || PS_MOM_LN PS_MOM_FN,");
            strSQL.Append("PS_MOM_LN_OLD,");
            strSQL.Append("PS_LOV_FN || '  ' || PS_LOV_LN PS_LOV_FN,");
            strSQL.Append("PS_LOV_LN_OLD");
            strSQL.Append(" FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");

            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds, "myDataGP7");
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();

            rpt.Load(Server.MapPath("~/Reports/personGP7.rpt"));
            rpt.SetDatabaseLogon("RMUTTO", "Zxcvbnm");
            rpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void ReportStudy()
        {
            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();

            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";

            strSQL.Append("SELECT PS_UNIV_NAME,");
            strSQL.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_FROM_MONTH) PS_FROM_MONTH,");
            strSQL.Append("(SELECT YEAR_ID FROM TB_DATE_YEAR WHERE YEAR_ID = PS_FROM_YEAR) PS_FROM_YEAR,");
            strSQL.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_TO_MONTH) PS_TO_MONTH,");
            strSQL.Append("(SELECT YEAR_ID FROM TB_DATE_YEAR WHERE YEAR_ID = PS_TO_YEAR) PS_TO_YEAR,");
            strSQL.Append("PS_MAJOR");
            strSQL.Append(" FROM PS_STUDY WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");

            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQL.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;

            dtAdapter.Fill(ds, "myDataStudy");
            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();

            rpt.Load(Server.MapPath("~/Reports/personGP7.rpt"));
            rpt.SetDatabaseLogon("RMUTTO", "Zxcvbnm");
            rpt.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rpt;
        }

        protected void ReportShowListName()
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

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            ReportGP7();
            //ReportStudy();
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ReportShowListName();
        }
    }
}