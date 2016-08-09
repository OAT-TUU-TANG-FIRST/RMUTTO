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
    public partial class Report_Seminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand com = new OracleCommand("SELECT COUNT(CITIZEN_ID) FROM TB_SEMINAR WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "'", conn);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            OracleDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                if(reader.GetInt32(0) == 0)
                {
                    return;
                }else
                {
                    MultiView1.ActiveViewIndex = 1;
                }
            }

            com.Dispose();
            conn.Close();

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
            OracleCommand com1 = new OracleCommand("SELECT CITIZEN_ID, SEMINAR_NAME || ' ' || SEMINAR_LASTNAME, SEMINAR_NAMEOFPROJECT, SEMINAR_PLACE, SEMINAR_SIGNED_DATETIME, SEMINAR_ID FROM TB_SEMINAR WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "' ORDER BY SEMINAR_SIGNED_DATETIME ASC ", con1);
            if (conn.State != ConnectionState.Open)
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
                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('Report-Seminar-Detail.aspx?seID=" + seID + "', null, 'height=780,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);        
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

    }
}
