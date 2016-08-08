using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using WEB_PERSONAL.Class;
using Rmutto.Connection;

namespace WEB_PERSONAL
{
    public partial class Report_Insignia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ถ้ามัน เรียกเลข จากอีกฝั่งมา แล้วตรงกัน ถึงจะแสดง
            string irID = Request.QueryString["irID"];
            //string irIDthan = "";
            //string ResultIRid = "";
            //string irIDLast = "";

            if (irID == null)
            {
                Response.Redirect("INSG_RequestList.aspx");
            }

            /*OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand com = new OracleCommand("SELECT IR_ID FROM TB_INSIG_REQUEST WHERE IR_ID = '" + irIDthan + "'", conn);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            OracleDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                irIDthan = reader.GetInt32(0).ToString();
                using (MD5 md5Hash = MD5.Create())
                {
                    ResultIRid = GetMd5Hash(md5Hash, irIDthan);
                }
            }*/

            //com.Dispose();
            //conn.Close();

            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            string strConnString = null;

            DataSet dsInsig = new DataSet();
            DataTable dtInsig = null;
            StringBuilder strSQLInsig = new StringBuilder();
            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=RMUTTO";
            strSQLInsig.Append("SELECT IR_CITIZEN_ID,");
            strSQLInsig.Append("(SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = IR_INSIG_ID) IR_INSIG_ID,");
            strSQLInsig.Append("TO_CHAR(IR_DATE_START,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') IR_DATE_START,");
            strSQLInsig.Append("IR_RANK,");
            strSQLInsig.Append("IR_TITLE,");
            strSQLInsig.Append("IR_NAME,");
            strSQLInsig.Append("IR_LASTNAME,");
            strSQLInsig.Append("IR_GENDER,");
            strSQLInsig.Append("TO_CHAR(IR_BIRTHDATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') IR_BIRTHDATE,");
            strSQLInsig.Append("TO_CHAR(IR_DATE_INWORK,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') IR_DATE_INWORK,");
            strSQLInsig.Append("IR_START_POSITION,");
            strSQLInsig.Append("IR_START_DEGREE,");
            strSQLInsig.Append("IR_CURRENT_POSITION,");
            strSQLInsig.Append("IR_TYPE,");
            strSQLInsig.Append("IR_DEGREE,");
            strSQLInsig.Append("TO_CHAR(IR_CURRENT_SALARY, '9999') IR_CURRENT_SALARY,");
            strSQLInsig.Append("TO_CHAR(IR_POSITION_SALARY, '9999') IR_POSITION_SALARY");
            strSQLInsig.Append(" FROM TB_INSIG_REQUEST WHERE IR_ID = '" + irID + "'");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQLInsig.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsInsig, "myDataInsignia");
            dtInsig = dsInsig.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/Insignia1.rpt"));
            rpt.SetDataSource(dtInsig);
            CrystalReportViewer1.ReportSource = rpt;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}