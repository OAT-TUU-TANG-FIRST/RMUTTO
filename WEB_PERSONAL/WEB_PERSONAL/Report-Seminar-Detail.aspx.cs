using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using WEB_PERSONAL.Class;
using Rmutto.Connection;

namespace WEB_PERSONAL {
    public partial class Report_Seminar_Detail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string id = Request.QueryString["seID"];

            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            string strConnString = null;

            DataSet dsSE = new DataSet();
            DataTable dtSE = null;
            StringBuilder strSQLSE = new StringBuilder();
            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";
            strSQLSE.Append("SELECT SEMINAR_NAME || ' ' || SEMINAR_LASTNAME SEMINAR_NAME,");
            strSQLSE.Append("SEMINAR_POSITION,");
            strSQLSE.Append("SEMINAR_DEGREE,");
            strSQLSE.Append("SEMINAR_CAMPUS,");
            strSQLSE.Append("SEMINAR_NAMEOFPROJECT,");
            strSQLSE.Append("SEMINAR_PLACE,");
            strSQLSE.Append("TO_CHAR(SEMINAR_DATETIME_FROM,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') SEMINAR_DATETIME_FROM,");
            strSQLSE.Append("TO_CHAR(SEMINAR_DATETIME_TO,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') SEMINAR_DATETIME_TO,");
            strSQLSE.Append("TO_CHAR(SEMINAR_DAY, '9999') SEMINAR_DAY,");
            strSQLSE.Append("TO_CHAR(SEMINAR_MONTH, '9999') SEMINAR_MONTH,");
            strSQLSE.Append("TO_CHAR(SEMINAR_YEAR, '9999') SEMINAR_YEAR,");
            strSQLSE.Append("TO_CHAR(SEMINAR_BUDGET, '9,999') SEMINAR_BUDGET,");
            strSQLSE.Append("SEMINAR_SUPPORT_BUDGET,");
            strSQLSE.Append("SEMINAR_CERTIFICATE,");
            strSQLSE.Append("SEMINAR_ABSTRACT,");
            strSQLSE.Append("SEMINAR_RESULT,");
            strSQLSE.Append("SEMINAR_SHOW_1,");
            strSQLSE.Append("SEMINAR_SHOW_2,");
            strSQLSE.Append("SEMINAR_SHOW_3,");
            strSQLSE.Append("SEMINAR_SHOW_4,");
            strSQLSE.Append("SEMINAR_PROBLEM,");
            strSQLSE.Append("SEMINAR_COMMENT");
            strSQLSE.Append(" FROM TB_SEMINAR WHERE SEMINAR_ID = " + id + "");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQLSE.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsSE, "myDataSeminar");
            dtSE = dsSE.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/Seminar1.rpt"));
            rpt.SetDataSource(dtSE);
            CrystalReportViewer1.ReportSource = rpt;
        }
    }
}