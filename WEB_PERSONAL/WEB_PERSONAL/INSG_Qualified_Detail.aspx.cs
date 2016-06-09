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
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH, PS_LN_TH, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE PS_PERSON.PS_STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID) ประเภทบุคลากร, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE PS_PERSON.PS_CAMPUS_ID = TB_CAMPUS.CAMPUS_ID) || ' > ' || (SELECT FACULTY_NAME FROM TB_FACULTY WHERE PS_PERSON.PS_FACULTY_ID = TB_FACULTY.FACULTY_ID) || ' > ' || (SELECT DIVISION_NAME FROM TB_DIVISION WHERE PS_PERSON.PS_DIVISION_ID = TB_DIVISION.DIVISION_ID) แผนก, (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE PS_PERSON.PS_WORK_DIVISION_ID = TB_WORK_DIVISION.WORK_ID) \"งาน / ฝ่าย\", (SELECT NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) ตำแหน่ง, (SELECT SW_NAME FROM TB_STATUS_WORK WHERE PS_PERSON.PS_SW_ID = TB_STATUS_WORK.SW_ID) สถานะการทำงาน FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + psID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lblName.Text = reader.IsDBNull(0) ? "" : reader.GetString(0) + " ";
                            lblLastName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            lblStafftype.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            lblCampus.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            //lblFaculty.Text = reader.IsDBNull(4) ? "" : reader.GetString(4) + " >";
                            //lblDivision.Text = reader.IsDBNull(5) ? "" : reader.GetString(5) + " >";
                            //lblWorkDivision.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            lblPosition.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            lblStatusPersonWork.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }

            

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT EXTRACT(YEAR FROM IUG_INSIG_DATE_GET) ปี, (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = IUG_INSIG_ID) ชั้น, (SELECT NAME FROM TB_POSITION WHERE TB_POSITION.ID = IUG_POSITION) ตำแหน่ง, IUG_SALARY เงินเดือน FROM TB_INSIG_USER_GET WHERE IUG_CITIZEN_ID = '" + psID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.IsDBNull(0) ? "" : "" + reader.GetInt32(0);
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                row.Cells.Add(cell);
                            }
                            {
                                TableCell cell = new TableCell();
                                cell.Text = reader.IsDBNull(3) ? "" : "" + reader.GetInt32(3);
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