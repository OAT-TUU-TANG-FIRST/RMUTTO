using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;
using System.Collections;
using System.Drawing;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;

namespace WEB_PERSONAL
{
    public partial class INSG_RequestList : System.Web.UI.Page
    {
        ArrayList ParameterArrayList = new ArrayList(); //Report parameter list
        ReportDocument ObjReportClientDocument = new ReportDocument(); //Report document

        protected void Page_Load(object sender, EventArgs e)
        {
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();
                
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เครื่องราชที่ขอ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่ทำเรื่องการขอ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ยศ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "คำนำหน้า";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - สกุล";
                    row.Cells.Add(cell);
                } 
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เพศ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันเกิด";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่เข้าทำงาน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ปริ้น";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "แจ้งผล";
                    row.Cells.Add(cell);
                }

                Table1.Rows.Add(row);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) ชั้นที่ขอ, IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน, IR_ID FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 2", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            string psID = reader.GetString(1);
                            int IRID = reader.GetInt32(9);

                            {
                                Label lblInsigName = new Label();
                                lblInsigName.Text = reader.GetString(0);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblInsigName);
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
                                Label lblDateStartRequest = new Label();
                                lblDateStartRequest.Text = reader.GetDateTime(2).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblDateStartRequest);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblRank = new Label();
                                lblRank.Text = reader.GetString(3);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblRank);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblTitleName = new Label();
                                lblTitleName.Text = reader.GetString(4);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblTitleName);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbName = new LinkButton();
                                lbName.Text = reader.GetString(5);
                                lbName.Click += (e2, e3) =>
                                {
                                    Response.Redirect("INSG_Qualified_Detail.aspx?psID=" + psID);
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblGender = new Label();
                                lblGender.Text = reader.GetString(6);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblGender);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblBirthDate = new Label();
                                lblBirthDate.Text = reader.GetDateTime(7).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblBirthDate);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblDateInwork = new Label();
                                lblDateInwork.Text = reader.GetDateTime(8).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblDateInwork);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbuPrint = new LinkButton();
                                lbuPrint.Text = "ปริ้น";
                                lbuPrint.CssClass = "ps-button";
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbuPrint);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbuResult = new LinkButton();
                                lbuResult.Text = "แจ้งผล";
                                lbuResult.CssClass = "ps-button";
                                lbuResult.Click += (e2,e3) => 
                                {
                                    hfIRID.Value = "" + IRID;
                                    MultiView1.ActiveViewIndex = 1;
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbuResult);
                                row.Cells.Add(cell);
                            }

                            Table1.Rows.Add(row);
                        }
                    }
                }
            }
        }

        protected void lbuPrint_Click(object sender, EventArgs e)
        {

        }

        protected void lbBack_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuSave_Click(object sender, EventArgs e) {
            int IRID = int.Parse(hfIRID.Value);
            int res = 1;
            if (rbNotGet.Checked) {
                res = 2;
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                if (res == 1) {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_DATE_GET_INSIG = :IR_DATE_GET_INSIG, IR_GET_STATUS = :IR_GET_STATUS, IR_REFERENCE = :IR_REFERENCE WHERE IR_ID = :IR_ID", con)) {
                        com.Parameters.Add("IR_STATUS", 3);
                        com.Parameters.Add("IR_DATE_GET_INSIG", Util.ToDateTimeOracle(tbDateGet.Text));
                        com.Parameters.Add("IR_GET_STATUS", res);
                        com.Parameters.Add("IR_REFERENCE", tbRef.Text);
                        com.Parameters.Add("IR_ID", IRID);
                        com.ExecuteNonQuery();
                    }
                } else {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_GET_STATUS = :IR_GET_STATUS WHERE IR_ID = :IR_ID", con)) {
                        com.Parameters.Add("IR_STATUS", 3);
                        com.Parameters.Add("IR_GET_STATUS", res);
                        com.Parameters.Add("IR_ID", IRID);
                        com.ExecuteNonQuery();
                    }
                }
                
            }
            MultiView1.ActiveViewIndex = 2;
        }
    }
    
}