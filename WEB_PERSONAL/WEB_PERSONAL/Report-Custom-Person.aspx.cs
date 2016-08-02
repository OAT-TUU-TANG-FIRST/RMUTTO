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
using CrystalDecisions.ReportSource;
using System.Collections;
using System.Drawing;
using CrystalDecisions.Web;
using System.Data.OracleClient;
using System.Data;
using System.Text;

namespace WEB_PERSONAL
{
    public partial class Report_Custom_Person : System.Web.UI.Page
    {
        OracleConnection conn = ConnectionDB.GetOracleConnection();

        ArrayList ParameterArrayList = new ArrayList(); //Report parameter list
        ReportDocument ObjReportClientDocument = new ReportDocument(); //Report document

        protected void Page_Load(object sender, EventArgs e)
        {
            /*CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/Personnel1.rpt"));
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "ORCL_RMUTTO"; //Database server or ODBC
            crConnectionInfo.DatabaseName = ""; // Database name
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
            CrystalReportViewer1.ReportSource = rpt;
            */


            ///////////////////////////
            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            DataSet ds = new DataSet();
            DataTable dt = null;
            string strConnString = null;
            StringBuilder strSQL = new StringBuilder();


            //strConnString = "Server=localhost;UID=sa;PASSWORD=;database=mydatabase;Max Pool Size=400;Connect Timeout=600;";
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
            rpt.SetDataSource(dt);
            this.CrystalReportViewer1.ReportSource = rpt;
            ////////////////

        }

        /*Generate report document*/
        private void GetReportDocument()
        {
            ReportBase objReportBase = new ReportBase();
            string sRptFolder = string.Empty;
            string sRptName = string.Empty;

            sRptName = "Personnel.rpt"; //Report name
            sRptFolder = Server.MapPath("~/Reports"); //Report folder name

            ObjReportClientDocument = objReportBase.PFSubReportConnectionMainParameter(sRptName, ParameterArrayList, sRptFolder);

        }

        protected void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
           // OnInit(e);
           // ViewCystalReport();
        }

        private void ViewCystalReport()
        {

            //Set generated report document as Crystal Report viewer report source
            CrystalReportViewer1.ReportSource = ObjReportClientDocument;
        }

        protected void ImgPdf32_Click(object sender, ImageClickEventArgs e)
        {
            ReportBase objReportBase = new ReportBase();
            GetReportDocument();
            ViewCystalReport();
        }

        protected void ImgExcel32_Click(object sender, ImageClickEventArgs e)
        {

            //(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "PersonDetails");
            //here i have use [ CrystalDecisions.Shared.ExportFormatType.ExcelRecord ] to Export in Excel
        }

        protected void ImgWord32_Click(object sender, ImageClickEventArgs e)
        {

            //(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "PersonDetails");
            //here i have use [ CrystalDecisions.Shared.ExportFormatType.WordForWindows ] to Export in Word
        }
    }
}