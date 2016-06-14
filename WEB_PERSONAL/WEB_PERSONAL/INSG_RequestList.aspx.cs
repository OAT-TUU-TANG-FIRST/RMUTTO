﻿using WEB_PERSONAL.Entities;
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
            Random r = new Random();
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    CheckBox cb = new CheckBox();
                    cb.AutoPostBack = true;
                    cb.CheckedChanged += (e2, e3) =>
                    {
                        for (int i = 1; i < Table1.Rows.Count; i++)
                        {
                            CheckBox cb2 = (CheckBox)Table1.Rows[i].Cells[0].Controls[0];
                            cb2.Checked = cb.Checked;
                        }
                    };
                    cell.Controls.Add(cb);
                    Label lb = new Label();
                    lb.Text = "เลือก";
                    cell.Controls.Add(lb);
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เครื่องราชที่ขอ";
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

                Table1.Rows.Add(row);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                //using (OracleCommand com = new OracleCommand("SELECT IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน, IR_START_POSITION, IR_START_DEGREE, IR_CURRENT_POSITION, IR_TYPE, IR_DEGREE, IR_CURRENT_SALARY, IR_POSITION_SALARY FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 2", con))
                using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) ชั้นที่ขอ, IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 2", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            row.CssClass = "ps-ins-item";
                            string psID = reader.GetString(1);

                            {
                                CheckBox cb = new CheckBox();
                                TableCell cell = new TableCell();
                                cell.Controls.Add(cb);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblInsigName = new Label();
                                lblInsigName.Text = reader.GetString(0);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblInsigName);
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

                            Table1.Rows.Add(row);
                        }
                    }
                }
            }
        }

        protected void lbuAccept_Click(object sender, EventArgs e)
        {
            int id = 0;
            using (OracleConnection conn = Util.OC())
            {
                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person loginPerson = ps.LoginPerson;
                using (OracleCommand command = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS WHERE IR_STATUS = 2", conn))
                {

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        command.Parameters.Add(new OracleParameter("IR_STATUS", 3));

                        id = command.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        command.Dispose();
                        conn.Close();
                    }
                }
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ได้ทำการรับเรื่องการขอ เรียบร้อยแล้ว !')", true);
            Response.Redirect("INSG_RequestList.aspx");

        }

        protected void lbuPrint_Click(object sender, EventArgs e)
        {

        }

    }
}