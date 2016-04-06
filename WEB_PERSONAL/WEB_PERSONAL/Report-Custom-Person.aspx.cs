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
        public class ReportBase
        {

            string ServerName = "ORCL_RMUTTO"; //Database server name to which report connected
            string DataBaseName = ""; //Database name to which report connected
            string UserID = "RMUTTO"; //Database user name to which report connected
            string Password = "Zxcvbnm"; //Database user password to which report connected

            ReportDocument crReportDocument = new ReportDocument();

            public ReportBase()
            {
            }
            ///
            ///Base method to generate report document.
            ///

            public ReportDocument PFSubReportConnectionMainParameter(string ReportName, ArrayList ParamArraylist, string ReportFolder)
            {
                int ObjArrayA, ObjArrayB, Paraindex;
                string Paravalue;
                ObjArrayB = 0;

                string path = ReportFolder + @"\" + @ReportName; //Full path of report

                try
                {
                    crReportDocument.Load(path); //Load crystal Report
                }
                catch (Exception ex)
                {

                    string msg = "The report file " + path +
                    " can not be loaded, ensure that the report exists or the path is correct." +
                    "\nException:\n" + ex.Message +
                    "\nSource:" + ex.Source +
                    "\nStacktrace:" + ex.StackTrace;
                    throw new Exception(msg);
                }

                //Ensure login to the database server
                if (!Logon(crReportDocument, ServerName, DataBaseName, UserID, Password))
                {
                    string msg = "Can not login to Report Server " +
                    "\nDatabase Server: " + ServerName +
                    "\nDatabase:\n" + DataBaseName +
                    "\nDBUser:" + UserID +
                    "\nDBPassword:" + Password;
                    throw new Exception(msg);
                }

                Logon(crReportDocument, ServerName, DataBaseName, UserID, Password);

                //To Check Parameter Feild Array have the Same Amount of Parameter Feild in the Report
                int ParamArrayCount, ParameterFieldCount;
                //Getting Value from the Array

                if (ParamArraylist.Count != 0)
                {
                    ParamArrayCount = (ParamArraylist.Count / 2);

                    //Getting Value From the Report (Parameter and Formula Feild)
                    ParameterFieldCount = crReportDocument.DataDefinition.ParameterFields.Count;

                    //Parameter on The Report and Array List Parameter Amount is not the same
                    ParamArrayCount = ParameterFieldCount;

                    for (ObjArrayA = 0; ObjArrayA < ((ParamArraylist.Count / 2)); ObjArrayA++)
                    {
                        Paraindex = (int)ParamArraylist[ObjArrayB]; //Parameter index
                        Paravalue = (string)ParamArraylist[ObjArrayB + 1]; //Paramter Value
                        PassParameter(Paraindex, Paravalue);
                        ObjArrayB = ObjArrayB + 2;
                    }
                }

                return crReportDocument;

            }

            ///
            /// Set parameter value in crystal report on corresponding index
            ///

            public void PassParameter(int ParameterIndex, string ParameterValue)
            {
                // '
                // ' Declare the parameter related objects.
                // '
                ParameterDiscreteValue crParameterDiscreteValue;
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldLocation;
                ParameterValues crParameterValues;

                crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields;
                crParameterFieldLocation = (ParameterFieldDefinition)crParameterFieldDefinitions[ParameterIndex];
                crParameterValues = crParameterFieldLocation.CurrentValues;
                crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                crParameterDiscreteValue.Value = System.Convert.ToString(ParameterValue);
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldLocation.ApplyCurrentValues(crParameterValues);
            }

            //Check whether crytal report can login to the server
            private bool Logon(CrystalDecisions.CrystalReports.Engine.ReportDocument cr, string server, string database, string user_id, string password)
            {
                // Declare and instantiate a new connection info object.
                CrystalDecisions.Shared.ConnectionInfo ci;
                ci = new CrystalDecisions.Shared.ConnectionInfo();

                ci.ServerName = server;
                ci.DatabaseName = database;
                ci.UserID = user_id;
                ci.Password = password;//password;
                                       // ci.IntegratedSecurity = false;

                // If the ApplyLogon function fails then return a false for this function.
                // We are applying logon information to the main report at this stage.
                if (!ApplyLogon(cr, ci))
                {
                    return false;
                }

                // Declare a subreport object.
                CrystalDecisions.CrystalReports.Engine.SubreportObject subobj;

                // Loop through all the report objects and locate subreports.
                // If a subreport is found then apply logon information to
                // the subreport.
                foreach (CrystalDecisions.CrystalReports.Engine.ReportObject obj in cr.ReportDefinition.ReportObjects)
                {
                    if (obj.Kind == CrystalDecisions.Shared.ReportObjectKind.SubreportObject)
                    {
                        subobj = (CrystalDecisions.CrystalReports.Engine.SubreportObject)obj;
                        if (!ApplyLogon(cr.OpenSubreport(subobj.SubreportName), ci))
                        {
                            return false;
                        }
                    }
                }

                // Return True if the code runs to this stage.
                return true;

            }

            ///
            ///This function is called by the "Logon" function. It loops through the report tables and applies the connection information to each table.
            ///

            private bool ApplyLogon(CrystalDecisions.CrystalReports.Engine.ReportDocument cr, CrystalDecisions.Shared.ConnectionInfo ci)
            {
                // This function is called by the "Logon" function
                // It loops through the report tables and applies
                // the connection information to each table.

                // Declare the TableLogOnInfo object and a table object for use later.
                CrystalDecisions.Shared.TableLogOnInfo li;
                // For each table apply connection info.

                foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in cr.Database.Tables)
                {

                    li = tbl.LogOnInfo;
                    li.ConnectionInfo.ServerName = ci.ServerName;
                    li.ConnectionInfo.DatabaseName = ci.DatabaseName;
                    li.ConnectionInfo.UserID = ci.UserID;
                    li.ConnectionInfo.Password = ci.Password;
                    tbl.ApplyLogOnInfo(li);
                    tbl.Location = ci.DatabaseName + ".dbo." + tbl.Name;

                    // Verify that the logon was successful.
                    // If TestConnectivity returns false, correct table locations.
                    if (!tbl.TestConnectivity())
                    {
                        return false;

                    }
                }
                return true;
            }

        }

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

            rpt.SetParameterValue("CITIZEN_ID", this.txt1.Text);
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
            //ObjReportClientDocument.SetParameterValue("CITIZEN_ID", this.txt1.Text);
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

            rpt.SetParameterValue("CITIZEN_ID", this.txt1.Text);
            //rpt.Database.Tables[0].SetDatasource(this.dataset);
            CrystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("RMUTTO", "Zxcvbnm", "ORCL_RMUTTO", "");

            GetReportDocument(); //Generate Report document
            ViewCystalReport(); //View report document in crystal report viewer

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