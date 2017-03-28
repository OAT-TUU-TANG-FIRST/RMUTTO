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
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class INSG_Request : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(*) FROM TB_INSIG_REQUEST WHERE IR_STATUS = 1 AND IR_CITIZEN_ID = '" + loginPerson.PS_CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 0)
                            {
                                return;
                            }
                        }
                    }
                }
            }

            /*lbRank.Text = loginPerson.RankName;
            lbTitleName.Text = loginPerson.TitleName;
            lbName.Text = loginPerson.FirstName;
            lbLastName.Text = loginPerson.LastName;
            lbGender.Text = loginPerson.GenderName;
            lbBirthDate.Text = loginPerson.BirthDate.Value.ToLongDateString();
            lbDateInwork.Text = loginPerson.InWorkDate.Value.ToLongDateString();
            lbPosiDateInwork.Text = loginPerson.StartPositionWorkName;
            lbDegreeDateInwork.Text = loginPerson.StartAdminPositionName;
            lbPositionCurrent.Text = loginPerson.PositionWorkName;
            lbType.Text = loginPerson.StaffTypeName;
            lbDegree.Text = loginPerson.AdminPositionName;
            lbSalaryCurrent.Text = loginPerson.Salary.ToString();
            lbPositionSalary.Text = loginPerson.PositionSalary;*/
            lbCitizen.Text = loginPerson.PS_CITIZEN_ID;

            int รหัสเครื่องราชปัจจุบัน = 0;
            int รหัสเครื่องราชทที่ขอ = 0;
            string ชื่อเครื่องราชปัจจุบัน = "-";
            string ชื่อเครื่องราชที่ขอ = "-";
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT IR_INSIG_ID FROM TB_INSIG_REQUEST WHERE IR_GET_STATUS = 1 AND IR_CITIZEN_ID = '" + loginPerson.PS_CITIZEN_ID + "' ORDER BY IR_ID DESC", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            รหัสเครื่องราชปัจจุบัน = reader.GetInt32(0);
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT IR_INSIG_ID FROM TB_INSIG_REQUEST WHERE IR_STATUS = 1 AND IR_CITIZEN_ID = '" + loginPerson.PS_CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            รหัสเครื่องราชทที่ขอ = reader.GetInt32(0);
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = " + รหัสเครื่องราชปัจจุบัน, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ชื่อเครื่องราชปัจจุบัน = reader.GetString(0);
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = " + รหัสเครื่องราชทที่ขอ, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ชื่อเครื่องราชที่ขอ = reader.GetString(0);
                        }
                    }
                }


            }

            if (รหัสเครื่องราชปัจจุบัน == 0)
            {
                imgOldInsig.Visible = false;
            }
            else
            {
                string fileName;
                switch (รหัสเครื่องราชปัจจุบัน)
                {
                    case 12: fileName = "บ.ม."; break;
                    case 11: fileName = "บ.ช."; break;
                    case 10: fileName = "จ.ม."; break;
                    case 9: fileName = "จ.ช."; break;
                    case 8: fileName = "ต.ม."; break;
                    case 7: fileName = "ต.ช."; break;
                    case 6: fileName = "ท.ม."; break;
                    case 5: fileName = "ท.ช."; break;
                    case 4: fileName = "ป.ม."; break;
                    case 3: fileName = "ป.ช."; break;
                    case 2: fileName = "ม.ว.ม."; break;
                    default: fileName = "ม.ป.ช."; break;
                }
                imgOldInsig.Attributes["src"] = "Image/Insignia/" + fileName + ".png";
            }

            if (รหัสเครื่องราชทที่ขอ == 0)
            {
                imgNewInsig.Visible = false;
            }
            else
            {
                string fileName;
                switch (รหัสเครื่องราชทที่ขอ)
                {
                    case 12: fileName = "บ.ม."; break;
                    case 11: fileName = "บ.ช."; break;
                    case 10: fileName = "จ.ม."; break;
                    case 9: fileName = "จ.ช."; break;
                    case 8: fileName = "ต.ม."; break;
                    case 7: fileName = "ต.ช."; break;
                    case 6: fileName = "ท.ม."; break;
                    case 5: fileName = "ท.ช."; break;
                    case 4: fileName = "ป.ม."; break;
                    case 3: fileName = "ป.ช."; break;
                    case 2: fileName = "ม.ว.ม."; break;
                    default: fileName = "ม.ป.ช."; break;
                }
                imgNewInsig.Attributes["src"] = "Image/Insignia/" + fileName + ".png";
            }

            lbOldInsigName.Text = ชื่อเครื่องราชปัจจุบัน;
            lbNewInsigName.Text = ชื่อเครื่องราชที่ขอ;

            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuSubmitView2_Click(object sender, EventArgs e)
        {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand command = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_CITIZEN_ID = :IR_CITIZEN_ID, IR_DATE_START = :IR_DATE_START, IR_RANK = :IR_RANK, IR_TITLE = :IR_TITLE, IR_NAME = :IR_NAME, IR_LASTNAME = :IR_LASTNAME, IR_GENDER = :IR_GENDER, IR_BIRTHDATE = :IR_BIRTHDATE, IR_DATE_INWORK = :IR_DATE_INWORK, IR_START_POSITION = :IR_START_POSITION, IR_START_DEGREE = :IR_START_DEGREE, IR_CURRENT_POSITION = :IR_CURRENT_POSITION, IR_TYPE = :IR_TYPE, IR_DEGREE = :IR_DEGREE, IR_CURRENT_SALARY = :IR_CURRENT_SALARY, IR_POSITION_SALARY = :IR_POSITION_SALARY WHERE IR_CITIZEN_ID = '" + loginPerson.PS_CITIZEN_ID + "' AND IR_STATUS = 1", con))
                {
                    command.Parameters.Add(new OracleParameter("IR_STATUS", 2));
                    command.Parameters.Add(new OracleParameter("IR_CITIZEN_ID", lbCitizen.Text));
                    command.Parameters.Add(new OracleParameter("IR_DATE_START", DateTime.Now));
                    command.Parameters.Add(new OracleParameter("IR_RANK", lbRank.Text));
                    command.Parameters.Add(new OracleParameter("IR_TITLE", lbTitleName.Text));
                    command.Parameters.Add(new OracleParameter("IR_NAME", lbName.Text));
                    command.Parameters.Add(new OracleParameter("IR_LASTNAME", lbLastName.Text));
                    command.Parameters.Add(new OracleParameter("IR_GENDER", lbGender.Text));
                    command.Parameters.Add(new OracleParameter("IR_BIRTHDATE", Util.ToDateTimeOracle(Util.ToShortMonth(lbBirthDate.Text))));
                    command.Parameters.Add(new OracleParameter("IR_DATE_INWORK", Util.ToDateTimeOracle(Util.ToShortMonth(lbDateInwork.Text))));
                    command.Parameters.Add(new OracleParameter("IR_START_POSITION", lbPosiDateInwork.Text));
                    command.Parameters.Add(new OracleParameter("IR_START_DEGREE", lbDegreeDateInwork.Text));
                    command.Parameters.Add(new OracleParameter("IR_CURRENT_POSITION", lbPositionCurrent.Text));
                    command.Parameters.Add(new OracleParameter("IR_TYPE", lbType.Text));
                    command.Parameters.Add(new OracleParameter("IR_DEGREE", lbDegree.Text));
                    command.Parameters.Add(new OracleParameter("IR_CURRENT_SALARY", lbSalaryCurrent.Text));
                    command.Parameters.Add(new OracleParameter("IR_POSITION_SALARY", lbPositionSalary.Text));
                    command.ExecuteNonQuery();
                    MultiView1.ActiveViewIndex = 2;
                }


            }
        }

    }
}