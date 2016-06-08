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

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT p.PS_FN_TH,p.PS_LN_TH,s.STAFFTYPE_NAME, c.CAMPUS_NAME, f.FACULTY_NAME, d.DIVISION_NAME, wd.WORK_NAME, tp.NAME, tsw.SW_NAME from PS_PERSON p INNER JOIN TB_STAFFTYPE s ON p.PS_STAFFTYPE_ID = s.STAFFTYPE_ID inner join TB_CAMPUS c ON p.PS_CAMPUS_ID = c.CAMPUS_ID inner join TB_FACULTY f on p.PS_FACULTY_ID = f.FACULTY_ID inner join TB_DIVISION d on p.PS_DIVISION_ID = d.DIVISION_ID inner join TB_WORK_DIVISION wd on p.PS_WORK_DIVISION_ID = wd.WORK_ID inner join TB_POSITION tp ON p.PS_POSITION_ID = tp.ID inner join TB_STATUS_WORK tsw on p.PS_SW_ID = tsw.SW_ID where p.PS_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lblName.Text = reader.IsDBNull(0) ? "" : reader.GetString(0) + " ";
                            lblLastName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            lblStafftype.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            lblCampus.Text = reader.IsDBNull(3) ? "" : reader.GetString(3) + " >";
                            lblFaculty.Text = reader.IsDBNull(4) ? "" : reader.GetString(4) + " >";
                            lblDivision.Text = reader.IsDBNull(5) ? "" : reader.GetString(5) + " >";
                            lblWorkDivision.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            lblPosition.Text = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            lblStatusPersonWork.Text = reader.IsDBNull(8) ? "" : reader.GetString(8);
                        }
                    }
                }
            }

            TableRow row = new TableRow();
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "ข้อมูล";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "แก้ไข";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "ลบ";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "ปีที่ได้รับ";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "ชั้น";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "ตำแหน่ง";
                row.Cells.Add(cell);
            }
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "เงินเดือน";
                row.Cells.Add(cell);
            }
            Table1.Rows.Add(row);

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT p.PS_FN_TH,p.PS_LN_TH,s.STAFFTYPE_NAME from PS_PERSON p INNER JOIN TB_STAFFTYPE s ON p.PS_STAFFTYPE_ID = s.STAFFTYPE_ID where p.PS_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //lblName.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            //lblLastName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            //lblStafftype.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        }
                    }
                }
            }

        }
            
    }
}