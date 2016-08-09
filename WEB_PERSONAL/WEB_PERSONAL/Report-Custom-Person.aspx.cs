using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using Rmutto.Connection;


namespace WEB_PERSONAL
{
    public partial class Report_Custom_Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";
            OracleConnection con2 = ConnectionDB.GetOracleConnection();
            OracleCommand com2 = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'", con2);

            if (con2.State != ConnectionState.Open) {
                con2.Open();
            }
            OracleDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read()) {
                result = reader2.GetString(0);
            }

            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            string strConnString = null;

            DataSet dsMain = new DataSet();
            DataTable dtMain = null;
            StringBuilder strSQLMain = new StringBuilder();
            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";
            strSQLMain.Append("SELECT (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE MINISTRY_ID = PS_MINISTRY_ID) PS_MINISTRY_ID,");
            strSQLMain.Append("PS_GROM,");
            strSQLMain.Append("PS_CITIZEN_ID,");
            strSQLMain.Append("(SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TITLE_ID = PS_TITLE_ID) PS_TITLE_ID,");
            strSQLMain.Append("PS_FN_TH,");
            strSQLMain.Append("PS_LN_TH,");
            strSQLMain.Append("TO_CHAR(PS_BIRTHDAY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') PS_BIRTHDAY_DATE,");
            strSQLMain.Append("PS_BIRTHDAY_LONG,");
            strSQLMain.Append("TO_CHAR(PS_RETIRE_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') PS_RETIRE_DATE,");
            strSQLMain.Append("PS_RETIRE_LONG,");
            strSQLMain.Append("TO_CHAR(PS_INWORK_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') PS_INWORK_DATE,");
            strSQLMain.Append("(SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = PS_STAFFTYPE_ID) PS_STAFFTYPE_ID,");
            strSQLMain.Append("PS_DAD_FN || '  ' || PS_DAD_LN PS_DAD_FN,");
            strSQLMain.Append("PS_MOM_FN || '  ' || PS_MOM_LN PS_MOM_FN,");
            strSQLMain.Append("PS_MOM_LN_OLD,");
            strSQLMain.Append("PS_LOV_FN || '  ' || PS_LOV_LN PS_LOV_FN,");
            strSQLMain.Append("PS_LOV_LN_OLD");
            strSQLMain.Append(" FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQLMain.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsMain, "myDataGP7");
            dtMain = dsMain.Tables[0];

            DataSet dsStudy = new DataSet();
            DataTable dtStudy = null;
            StringBuilder strSQLStudy = new StringBuilder();
            strSQLStudy.Append("SELECT PS_UNIV_NAME,");
            strSQLStudy.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_FROM_MONTH) PS_FROM_MONTH,");
            strSQLStudy.Append("TO_CHAR(PS_FROM_YEAR, '9999') PS_FROM_YEAR,");
            strSQLStudy.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_TO_MONTH) PS_TO_MONTH,");
            strSQLStudy.Append("TO_CHAR(PS_TO_YEAR, '9999') PS_TO_YEAR,");
            strSQLStudy.Append("PS_MAJOR");
            strSQLStudy.Append(" FROM PS_STUDY WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            strSQLStudy.Append(" ORDER BY PS_STUDY_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with2 = objCmd;
            _with2.Connection = objConn;
            _with2.CommandText = strSQLStudy.ToString();
            _with2.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsStudy, "myDataStudy");
            dtStudy = dsStudy.Tables[0];

            DataSet dsProLicense = new DataSet();
            DataTable dtProLicense = null;
            StringBuilder strSQLProLicense = new StringBuilder();
            strSQLProLicense.Append("SELECT PS_LICENSE_NAME,");
            strSQLProLicense.Append("PS_DEPARTMENT,");
            strSQLProLicense.Append("PS_LICENSE_NO,");
            strSQLProLicense.Append("TO_CHAR(PS_USE_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') PS_USE_DATE");
            strSQLProLicense.Append(" FROM PS_PROFESSIONAL_LICENSE WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            strSQLProLicense.Append(" ORDER BY PS_PL_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with3 = objCmd;
            _with3.Connection = objConn;
            _with3.CommandText = strSQLProLicense.ToString();
            _with3.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsProLicense, "myDataProLicense");
            dtProLicense = dsProLicense.Tables[0];

            DataSet dsTraining = new DataSet();
            DataTable dtTraining = null;
            StringBuilder strSQLTraining = new StringBuilder();
            strSQLTraining.Append("SELECT PS_COURSE,");
            strSQLTraining.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_FROM_MONTH) PS_FROM_MONTH,");
            strSQLTraining.Append("TO_CHAR(PS_FROM_YEAR, '9999') PS_FROM_YEAR,");
            strSQLTraining.Append("(SELECT MONTH_SHORT FROM TB_MONTH WHERE MONTH_ID = PS_TO_MONTH) PS_TO_MONTH,");
            strSQLTraining.Append("TO_CHAR(PS_TO_YEAR, '9999') PS_TO_YEAR,");
            strSQLTraining.Append("PS_DEPARTMENT");
            strSQLTraining.Append(" FROM PS_TRAINING WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            strSQLTraining.Append(" ORDER BY PS_TRAINING_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with4 = objCmd;
            _with4.Connection = objConn;
            _with4.CommandText = strSQLTraining.ToString();
            _with4.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsTraining, "myDataTraining");
            dtTraining = dsTraining.Tables[0];

            DataSet dsDAA = new DataSet();
            DataTable dtDAA = null;
            StringBuilder strSQLDAA = new StringBuilder();
            strSQLDAA.Append("SELECT TO_CHAR(PS_YEAR, '9999') PS_YEAR,");
            strSQLDAA.Append("PS_DAA_NAME,");
            strSQLDAA.Append("PS_REF");
            strSQLDAA.Append(" FROM PS_DISCIPLINARY_AND_AMNESTY WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            strSQLDAA.Append(" ORDER BY PS_DAA_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with5 = objCmd;
            _with5.Connection = objConn;
            _with5.CommandText = strSQLDAA.ToString();
            _with5.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsDAA, "myDataDAA");
            dtDAA = dsDAA.Tables[0];


            DataSet dsPositionAndSalary = new DataSet();
            DataTable dtPositionAndSalary = null;
            StringBuilder strSQLPositionAndSalary = new StringBuilder();
            strSQLPositionAndSalary.Append("SELECT TO_CHAR(PS_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') PS_DATE,");
            strSQLPositionAndSalary.Append("PS_POSITION,");
            strSQLPositionAndSalary.Append("TO_CHAR(PS_POSITION_NO, '9999') PS_POSITION_NO,");
            strSQLPositionAndSalary.Append("(SELECT ST_NAME FROM TB_STAFF WHERE ST_ID = PS_POSITION_TYPE) PS_POSITION_TYPE,");
            strSQLPositionAndSalary.Append("(SELECT NAME FROM TB_POSITION WHERE ID = PS_POSITION_DEGREE) PS_POSITION_DEGREE,");
            strSQLPositionAndSalary.Append("PS_SALARY,");
            strSQLPositionAndSalary.Append("PS_SALARY_POSITION,");
            strSQLPositionAndSalary.Append("PS_REF");
            strSQLPositionAndSalary.Append(" FROM PS_POSITION_AND_SALARY WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'");
            strSQLPositionAndSalary.Append(" ORDER BY PS_PAS_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with6 = objCmd;
            _with6.Connection = objConn;
            _with6.CommandText = strSQLPositionAndSalary.ToString();
            _with6.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsPositionAndSalary, "myDataPositionAndSalary");
            dtPositionAndSalary = dsPositionAndSalary.Tables[0];


            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/personGP7.rpt"));

            rpt.SetDataSource(dtMain);
            rpt.Subreports["psStudy"].Database.Tables[0].SetDataSource(dtStudy);
            rpt.Subreports["psProLicense"].Database.Tables[0].SetDataSource(dtProLicense);
            rpt.Subreports["psTraining"].Database.Tables[0].SetDataSource(dtTraining);
            rpt.Subreports["psDAA"].Database.Tables[0].SetDataSource(dtDAA);
            rpt.Subreports["psPositionAndSalary"].Database.Tables[0].SetDataSource(dtPositionAndSalary);

            CrystalReportViewer1.ReportSource = rpt;

            if (result != txtSearchCitizenID.Text) {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - ไม่พบข้อมูลของรหัสบัตรประชาชนดังกล่าว</div>";
                return;
            }
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCitizenID.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องคำค้นหา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtSearchCitizenID.Text.Length < 13)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องค้นหาให้ครบ 13 หลัก</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report-Custom-Person.aspx");
        }
    }
}