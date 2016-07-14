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

namespace WEB_PERSONAL {
    public partial class INSG_Request : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) เครื่องราช,(SELECT RANK_NAME_TH FROM TB_RANK WHERE TB_RANK.RANK_ID = PS_PERSON.PS_RANK_ID) ยศ,(SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TB_TITLENAME.TITLE_ID = PS_PERSON.PS_TITLE_ID) คำนำหน้าชื่อ,IR_CITIZEN_ID รหัสบัตรประชาชน,PS_FN_TH ชื่อ,PS_LN_TH นามสกุล,(SELECT GENDER_NAME FROM TB_GENDER WHERE PS_PERSON.PS_GENDER_ID = TB_GENDER.GENDER_ID) เพศ, PS_BIRTHDAY_DATE วันเกิด,PS_INWORK_DATE วันที่เริ่มรับราชการ,(SELECT NAME FROM TB_POSITION WHERE TB_POSITION.ID = PS_POSITION_HISTORY.POSITION_ID) ตำแหน่งที่เริ่มรับราชการ,(SELECT PID_NAME FROM TB_POSITION_INSIG_DEGREE WHERE TB_POSITION_INSIG_DEGREE.PID_ID = TB_POSITION_DEGREE_HISTORY.PID_ID) ระดับที่เริ่มรับราชการ,(SELECT NAME FROM TB_POSITION WHERE TB_POSITION.ID = PS_PERSON.PS_POSITION_ID) ตำแหน่งปัจจุบัน,(SELECT PIG_NAME FROM TB_POSITION_INSIG_GOVER WHERE TB_POSITION_INSIG_GOVER.PIG_ID = PS_PERSON.PS_PIG_ID) ประเภท, (SELECT PID_NAME FROM TB_POSITION_INSIG_DEGREE WHERE TB_POSITION_INSIG_DEGREE.PID_ID = PS_PERSON.PS_PID_ID) ระดับ,PS_SALARY เงินเดือนปัจจุบัน,PS_POSS_SALARY เงินประจำตำแหน่ง FROM TB_INSIG_REQUEST,PS_PERSON,PS_POSITION_HISTORY,TB_POSITION_DEGREE_HISTORY WHERE IR_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "' AND IR_STATUS = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            tbInsig.Text = reader.GetString(0);
                            tbRank.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            tbTitleName.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            tbCitizen.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            tbName.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            tbLastName.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            tbGender.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            tbBirthDate.Text = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd MMM yyyy");
                            tbDateInwork.Text = reader.IsDBNull(8) ? "" : reader.GetDateTime(8).ToString("dd MMM yyyy");
                            tbPosiDateInwork.Text = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            tbDegreeDateInwork.Text = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            tbPositionCurrent.Text = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            tbType.Text = reader.IsDBNull(12) ? "" : reader.GetString(12);
                            tbDegree.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            tbSalaryCurrent.Text = reader.IsDBNull(14) ? "" : reader.GetInt32(14).ToString("#,###");
                            tbPositionSalary.Text = reader.IsDBNull(15) ? "" : reader.GetInt32(15).ToString("#,###");
                        }
                    }
                }
            }
        }

        protected void lbuSubmitView2_Click(object sender, EventArgs e)
        {
            int id = 0;
            using (OracleConnection conn = Util.OC())
            {
                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person loginPerson = ps.LoginPerson;
                using (OracleCommand command = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_CITIZEN_ID = :IR_CITIZEN_ID, IR_DATE_START = :IR_DATE_START, IR_RANK = :IR_RANK, IR_TITLE = :IR_TITLE, IR_NAME = :IR_NAME, IR_LASTNAME = :IR_LASTNAME, IR_GENDER = :IR_GENDER, IR_BIRTHDATE = :IR_BIRTHDATE, IR_DATE_INWORK = :IR_DATE_INWORK, IR_START_POSITION = :IR_START_POSITION, IR_START_DEGREE = :IR_START_DEGREE, IR_CURRENT_POSITION = :IR_CURRENT_POSITION, IR_TYPE = :IR_TYPE, IR_DEGREE = :IR_DEGREE, IR_CURRENT_SALARY = :IR_CURRENT_SALARY, IR_POSITION_SALARY = :IR_POSITION_SALARY WHERE IR_CITIZEN_ID = '" + ps.LoginPerson.CitizenID + "' AND IR_STATUS = 1", conn))
                {

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        command.Parameters.Add(new OracleParameter("IR_STATUS", 2));
                        command.Parameters.Add(new OracleParameter("IR_CITIZEN_ID", tbCitizen.Text));
                        command.Parameters.Add(new OracleParameter("IR_DATE_START", Util.ODT(DateTime.Now.ToString("dd MMM yyyy"))));
                        command.Parameters.Add(new OracleParameter("IR_RANK", tbRank.Text));
                        command.Parameters.Add(new OracleParameter("IR_TITLE", tbTitleName.Text));
                        command.Parameters.Add(new OracleParameter("IR_NAME", tbName.Text));
                        command.Parameters.Add(new OracleParameter("IR_LASTNAME", tbLastName.Text));
                        command.Parameters.Add(new OracleParameter("IR_GENDER", tbGender.Text));
                        command.Parameters.Add(new OracleParameter("IR_BIRTHDATE", Util.ODT(tbBirthDate.Text)));
                        command.Parameters.Add(new OracleParameter("IR_DATE_INWORK", Util.ODT(tbDateInwork.Text)));
                        command.Parameters.Add(new OracleParameter("IR_START_POSITION", tbPosiDateInwork.Text));
                        command.Parameters.Add(new OracleParameter("IR_START_DEGREE", tbDegreeDateInwork.Text));
                        command.Parameters.Add(new OracleParameter("IR_CURRENT_POSITION", tbPositionCurrent.Text));
                        command.Parameters.Add(new OracleParameter("IR_TYPE", tbType.Text));
                        command.Parameters.Add(new OracleParameter("IR_DEGREE", tbDegree.Text));
                        command.Parameters.Add(new OracleParameter("IR_CURRENT_SALARY", tbSalaryCurrent.Text));
                        command.Parameters.Add(new OracleParameter("IR_POSITION_SALARY", tbPositionSalary.Text));
                        //command.Parameters.Add(new OracleParameter("IR_BACK_5Y_SALARY", xxx.Text));

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

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ได้ทำการขอเครื่องราชฯ เรียบร้อยแล้ว !')", true);

        }
    }
}