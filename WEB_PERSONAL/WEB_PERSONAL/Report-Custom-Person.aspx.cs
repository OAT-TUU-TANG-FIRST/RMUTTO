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

namespace WEB_PERSONAL
{
    public partial class Report_Custom_Person : System.Web.UI.Page
    {
        
        ArrayList ParameterArrayList = new ArrayList(); //Report parameter list
        ReportDocument ObjReportClientDocument = new ReportDocument(); //Report document

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/CrystalReport1.rpt"));
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
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

            /*The report with two parameters. */
            // ParameterArrayList.Add(0);
            // ParameterArrayList.Add("1"); //Parameter 1 with input 1. This is actually dept id according to report parameter
            // ParameterArrayList.Add(1);
            // ParameterArrayList.Add("1"); //Parameter 2 with input 1. This is actually team id according to report parameter

            ReportBase objReportBase = new ReportBase();
            

            //ObjReportClientDocument.SetParameterValue("CITIZEN_ID", this.txt1.Text);
            GetReportDocument();
            ViewCystalReport();
            
        }
        /*Generate report document*/
        private void GetReportDocument()
        {
            ReportBase objReportBase = new ReportBase();
            string sRptFolder = string.Empty;
            string sRptName = string.Empty;

            sRptName = "CrystalReport1.rpt"; //Report name
            sRptFolder = Server.MapPath("~/Reports"); //Report folder name

            ObjReportClientDocument = objReportBase.PFSubReportConnectionMainParameter(sRptName, ParameterArrayList, sRptFolder);

            //This section is for manipulating font and font size. This an optional section
            foreach (Section oSection in ObjReportClientDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in oSection.ReportObjects)
                {
                    FieldObject field;
                    field = ObjReportClientDocument.ReportDefinition.ReportObjects[obj.Name] as FieldObject;

                    if (field != null)
                    {
                        Font oFon1 = new Font("Arial Narrow", field.Font.Size - 1F);
                        Font oFon2 = new Font("Arial", field.Font.Size - 1F);

                        if (oFon1 != null)
                        {
                            field.ApplyFont(oFon1);
                        }
                        else if (oFon2 != null)
                        {
                            field.ApplyFont(oFon2);
                        }
                    }
                }
            }
        }

        protected void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {
           // OnInit(e);
           // ViewCystalReport();
        }

        ///
        /// To view crystal report
        ///

        private void ViewCystalReport()
        {

            //Set generated report document as Crystal Report viewer report source
            CrystalReportViewer1.ReportSource = ObjReportClientDocument;
        }

    }
}