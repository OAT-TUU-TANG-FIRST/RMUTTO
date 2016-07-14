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

namespace WEB_PERSONAL
{
    public partial class INSG_Qualififed_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เครื่องราชฯที่ได้รับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่ได้รับเครื่องราชฯ";
                    row.Cells.Add(cell);
                }

                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ตำแหน่ง ณ ตอนที่ได้รับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เงินเดือน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เอกสารอ้างอิง";
                    row.Cells.Add(cell);
                }

                Table1.Rows.Add(row);
            }

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            string psID = Request.QueryString["psID"];
            if(psID == null) {
                psID = loginPerson.CitizenID;
            }

            //Person pp = DatabaseManager.GetPerson(psID);

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH, PS_LN_TH, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE PS_PERSON.PS_STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID) ประเภทบุคลากร, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE PS_PERSON.PS_CAMPUS_ID = TB_CAMPUS.CAMPUS_ID) || ' > ' || (SELECT FACULTY_NAME FROM TB_FACULTY WHERE PS_PERSON.PS_FACULTY_ID = TB_FACULTY.FACULTY_ID) || ' > ' || (SELECT DIVISION_NAME FROM TB_DIVISION WHERE PS_PERSON.PS_DIVISION_ID = TB_DIVISION.DIVISION_ID) || ' > ' || (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE PS_PERSON.PS_WORK_DIVISION_ID = TB_WORK_DIVISION.WORK_ID) \"งาน / ฝ่าย\", (SELECT NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) ตำแหน่ง, (SELECT SW_NAME FROM TB_STATUS_WORK WHERE PS_PERSON.PS_SW_ID = TB_STATUS_WORK.SW_ID) สถานะการทำงาน FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + psID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lblName.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            lblLastName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            lblStafftype.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            lblCampus.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            lblPosition.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            lblStatusPersonWork.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                //using (OracleCommand com = new OracleCommand("SELECT IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน, IR_START_POSITION, IR_START_DEGREE, IR_CURRENT_POSITION, IR_TYPE, IR_DEGREE, IR_CURRENT_SALARY, IR_POSITION_SALARY FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 2", con))
                //using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) ชั้นที่ขอ, IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 4", con))
                using (OracleCommand com = new OracleCommand("SELECT IUG_CITIZEN_ID,(SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = TB_INSIG_USER_GET.IUG_INSIG_ID) ชื่อเครื่องราช,IUG_INSIG_DATE_GET,(SELECT NAME FROM TB_POSITION WHERE TB_POSITION.ID = TB_INSIG_USER_GET.IUG_POSITION) ตำแหน่ง,IUG_SALARY,IUG_REF FROM TB_INSIG_USER_GET WHERE IUG_CITIZEN_ID = '" + psID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            row.CssClass = "ps-ins-item";
                            string psID1 = reader.GetString(1);

                            {
                                Label lblCitizenID = new Label();
                                lblCitizenID.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblCitizenID);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblInsigName = new Label();
                                lblInsigName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblInsigName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblInsigDateGet = new Label();
                                lblInsigDateGet.Text = reader.IsDBNull(2) ? "" : reader.GetDateTime(2).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblInsigDateGet);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblPositionGet = new Label();
                                lblPositionGet.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblPositionGet);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblSalaryGet = new Label();
                                lblSalaryGet.Text = reader.IsDBNull(4) ? "" : reader.GetInt32(4).ToString("#,###");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblSalaryGet);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblRef = new Label();
                                lblRef.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblRef);
                                row.Cells.Add(cell);
                            }

                            Table1.Rows.Add(row);
                        }
                    }
                }
            }
        }

    }
            
    }
