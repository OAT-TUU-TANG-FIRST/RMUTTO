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

namespace WEB_PERSONAL
{
    public partial class Report_Seminar_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();

                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - สกุล";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "สถานที่ฝึกอบรม/สัมมนา/ดูงาน ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่บันทึกการอบรม/สัมมนา/ดูงาน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ปริ้น";
                    row.Cells.Add(cell);
                }

                Table1.Rows.Add(row);
            }

            OracleConnection con1 = ConnectionDB.GetOracleConnection();
            OracleCommand com1 = new OracleCommand("SELECT CITIZEN_ID, SEMINAR_NAME || ' ' || SEMINAR_LASTNAME, SEMINAR_NAMEOFPROJECT, SEMINAR_PLACE, SEMINAR_SIGNED_DATETIME, SEMINAR_ID FROM TB_SEMINAR WHERE CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "' ORDER BY SEMINAR_SIGNED_DATETIME ASC ", con1);
            if (con1.State != ConnectionState.Open)
            {
                con1.Open();
            }
            OracleDataReader reader1 = com1.ExecuteReader();

            int j = 1;

            while (reader1.Read())
            {
                TableRow row = new TableRow();
                string psID = reader1.GetString(0);
                int seID = reader1.GetInt32(5);

                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + j;
                    row.Cells.Add(cell);
                }
                {
                    Label lblCitizenID = new Label();
                    lblCitizenID.Text = psID;
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblCitizenID);
                    row.Cells.Add(cell);
                }

                {
                    Label lblName = new Label();
                    lblName.Text = reader1.GetString(1);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblName);
                    row.Cells.Add(cell);
                }

                {
                    Label lblNameProject = new Label();
                    lblNameProject.Text = reader1.GetString(2);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblNameProject);
                    row.Cells.Add(cell);
                }

                {
                    Label lblPlace = new Label();
                    lblPlace.Text = reader1.GetString(3);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblPlace);
                    row.Cells.Add(cell);
                }

                {
                    Label lblDateSave = new Label();
                    lblDateSave.Text = reader1.GetDateTime(4).ToString("dd MMM yyyy");
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblDateSave);
                    row.Cells.Add(cell);
                }

                {
                    LinkButton lbuPrint = new LinkButton();
                    lbuPrint.Text = "ปริ้น";
                    lbuPrint.CssClass = "ps-button";
                    lbuPrint.Click += (e2, e3) =>
                    {
                        if (string.IsNullOrEmpty(txtSearchSeminarCitizen.Text))
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
                        if (txtSearchSeminarCitizen.Text.Length < 13)
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

                        hfSEID.Value = "" + seID;

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
                        strSQLSE.Append(" FROM TB_SEMINAR WHERE SEMINAR_ID = " + seID + " AND CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "'");
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

                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbuPrint);
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
                ++j;
            }
            com1.Dispose();
            con1.Close();
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchSeminarCitizen.Text))
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
            if (txtSearchSeminarCitizen.Text.Length < 13)
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

            string result = "";
            OracleConnection con2 = ConnectionDB.GetOracleConnection();
            OracleCommand com2 = new OracleCommand("SELECT CITIZEN_ID FROM TB_SEMINAR WHERE CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "'", con2);
            
            if (con2.State != ConnectionState.Open)
            {
                con2.Open();
            }
            OracleDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                result = reader2.GetString(0);
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/Seminar1.rpt"));
            rpt.SetDataSource("");
            CrystalReportViewer1.ReportSource = rpt;

            if (result != txtSearchSeminarCitizen.Text)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - ไม่พบข้อมูลของรหัสบัตรประชาชนดังกล่าว</div>";
                return;
            }

            com2.Dispose();
            con2.Close();
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
    }
}