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
    public partial class PositionPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 1", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทบริหาร--");
            DatabaseManager.BindDropDown(ddlDirectPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 2", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทอำนวยการ--");
            DatabaseManager.BindDropDown(ddlAcadPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 3", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภทวิชาการ--");
            DatabaseManager.BindDropDown(ddlGeneralPosition, "SELECT * FROM PS_POSITION WHERE P_GROUP = 4", "P_NAME", "P_ID", "--กรุณาเลือกตำแหน่งประเภททั่วไป--");
        }

        protected void ClearText()
        {
            tbCitizenID.Text = "";
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            if (string.IsNullOrEmpty(tbCitizenID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenID.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID รหัสบัตรประชาชน, PS_FN_TH, PS_LN_TH, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE PS_PERSON.PS_STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID) ประเภทบุคลากร, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE PS_PERSON.PS_CAMPUS_ID = TB_CAMPUS.CAMPUS_ID) || ' > ' || (SELECT FACULTY_NAME FROM TB_FACULTY WHERE PS_PERSON.PS_FACULTY_ID = TB_FACULTY.FACULTY_ID) || ' > ' || (SELECT DIVISION_NAME FROM TB_DIVISION WHERE PS_PERSON.PS_DIVISION_ID = TB_DIVISION.DIVISION_ID) || ' > ' || (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE PS_PERSON.PS_WORK_DIVISION_ID = TB_WORK_DIVISION.WORK_ID) \"งาน / ฝ่าย\", (SELECT SW_NAME FROM TB_STATUS_WORK WHERE PS_PERSON.PS_SW_ID = TB_STATUS_WORK.SW_ID) สถานะการทำงาน FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + tbCitizenID.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lblCitizenID.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            lblName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            lblLastName.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            lblStafftype.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            lblCampus.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            lblStatusPersonWork.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            ClearText();
        }

        protected void lbuAddPosition_Click(object sender, EventArgs e)
        {

        }
    }
}