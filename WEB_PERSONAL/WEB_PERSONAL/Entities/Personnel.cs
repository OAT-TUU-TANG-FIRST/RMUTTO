using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities
{
    public class Personnel
    {
        
        public string PS_CITIZEN_ID { get; set; }
        public int PS_MINISTRY_ID { get; set; }
        public string PS_GROM { get; set; }
        public int PS_TITLE_ID { get; set; }
        public string PS_FN_TH { get; set; }
        public string PS_FN_EN { get; set; }
        public string PS_LN_TH { get; set; }
        public string PS_LN_EN { get; set; }
        public int PS_GENDER_ID { get; set; }
        public DateTime PS_BIRTHDAY_DATE { get; set; }
        public string PS_BIRTHDAY_LONG { get; set; }
        public int PS_RACE_ID { get; set; }


































        public Personnel() { }
        public Personnel(int YEAR, string UNIV_ID, string CITIZEN_ID, string TITLE_ID, string STF_NAME, string STF_LNAME, int GENDER_ID,
        DateTime BIRTHDAY, string HOMEADD, string MOO, string STREET, int DISTRICT_ID, int AMPHUR_ID, int PROVINCE_ID, string TELEPHONE,
        int ZIPCODE_ID, string NATION_ID, int STAFFTYPE_ID, int TIME_CONTACT_ID, int BUDGET_ID, int SUBSTAFFTYPE_ID, string ADMIN_POSITION_ID, string POSITION_ID,
        string POSITION_WORK_ID, string DEPARTMENT_ID, DateTime DATETIME_INWORK, string SPECIAL_NAME, string TEACH_ISCED_ID, string GRAD_LEV_ID, string GRAD_CURR, string GRAD_ISCED_ID, string GRAD_PROG_ID, string GRAD_UNIV, int GRAD_COUNTRY_ID)
        {
            this.YEAR = YEAR;
            this.UNIV_ID = UNIV_ID;
            this.CITIZEN_ID = CITIZEN_ID;
            this.TITLE_ID = TITLE_ID;
            this.STF_NAME = STF_NAME;
            this.STF_LNAME = STF_LNAME;
            this.GENDER_ID = GENDER_ID;
            this.BIRTHDAY = BIRTHDAY;
            this.HOMEADD = HOMEADD;
            this.MOO = MOO;
            this.STREET = STREET;
            this.DISTRICT_ID = DISTRICT_ID;
            this.AMPHUR_ID = PROVINCE_ID;
            this.TELEPHONE = TELEPHONE;
            this.ZIPCODE_ID = ZIPCODE_ID;
            this.NATION_ID = NATION_ID;
            this.STAFFTYPE_ID = STAFFTYPE_ID;
            this.TIME_CONTACT_ID = TIME_CONTACT_ID;
            this.BUDGET_ID = BUDGET_ID;
            this.SUBSTAFFTYPE_ID = SUBSTAFFTYPE_ID;
            this.ADMIN_POSITION_ID = ADMIN_POSITION_ID;
            this.POSITION_ID = POSITION_ID;
            this.POSITION_WORK_ID = POSITION_WORK_ID;
            this.DEPARTMENT_ID = DEPARTMENT_ID;
            this.SPECIAL_NAME = SPECIAL_NAME;
            this.TEACH_ISCED_ID = TEACH_ISCED_ID;
            this.GRAD_LEV_ID = GRAD_LEV_ID;
            this.GRAD_CURR = GRAD_CURR;
            this.GRAD_ISCED_ID = GRAD_ISCED_ID;
            this.GRAD_PROG_ID = GRAD_PROG_ID;
            this.GRAD_UNIV = GRAD_UNIV;
            this.GRAD_COUNTRY_ID = GRAD_COUNTRY_ID;
        }


        public DataTable GetPersonnel(string SEMINAR_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_PERSONAL ";
            if (!string.IsNullOrEmpty(SEMINAR_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    query += " and CITIZEN_ID like :CITIZEN_ID ";
                }
            }
            OracleCommand command = new OracleCommand(query, conn);
            // Create the command
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID + "%"));
                }
                OracleDataAdapter sd = new OracleDataAdapter(command);
                sd.Fill(dt);

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

            return dt;
        }

        public int InsertPersonnel()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_PERSONAL (YEAR,UNIV_ID,CITIZEN_ID,TITLE_ID,STF_NAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,DISTRICT_ID,AMPHUR_ID,PROVINCE_ID,TELEPHONE,ZIPCODE_ID,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK_ID,DEPARTMENT_ID,DATETIME_INWORK,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG_ID,GRAD_UNIV,GRAD_COUNTRY_ID,STREET,MOO) VALUES (:YEAR,:UNIV_ID,:CITIZEN_ID,:TITLE_ID,:STF_NAME,:STF_LNAME,:GENDER_ID,:BIRTHDAY,:HOMEADD,:DISTRICT_ID,:AMPHUR_ID,:PROVINCE_ID,:TELEPHONE,:ZIPCODE_ID,:NATION_ID,:STAFFTYPE_ID,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_ID,:POSITION_WORK_ID,:DEPARTMENT_ID,:DATETIME_INWORK,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_LEV_ID,:GRAD_CURR,:GRAD_ISCED_ID,:GRAD_PROG_ID,:GRAD_UNIV,:GRAD_COUNTRY_ID,:STREET,:MOO)", conn);
        
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("YEAR", YEAR));
                command.Parameters.Add(new OracleParameter("UNIV_ID", UNIV_ID));
                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
                command.Parameters.Add(new OracleParameter("STF_NAME", STF_NAME));
                command.Parameters.Add(new OracleParameter("STF_LNAME", STF_LNAME));
                command.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                command.Parameters.Add(new OracleParameter("BIRTHDAY", BIRTHDAY));
                command.Parameters.Add(new OracleParameter("HOMEADD", HOMEADD));
                command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("TELEPHONE", TELEPHONE));
                command.Parameters.Add(new OracleParameter("ZIPCODE_ID", ZIPCODE_ID));
                command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
                command.Parameters.Add(new OracleParameter("POSITION_ID", POSITION_ID));
                command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID));
                command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
                command.Parameters.Add(new OracleParameter("DATETIME_INWORK", DATETIME_INWORK));
                command.Parameters.Add(new OracleParameter("SPECIAL_NAME", SPECIAL_NAME));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
                command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
                command.Parameters.Add(new OracleParameter("GRAD_CURR", GRAD_CURR));
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
                command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID));
                command.Parameters.Add(new OracleParameter("GRAD_UNIV", GRAD_UNIV));
                command.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", GRAD_COUNTRY_ID));
                command.Parameters.Add(new OracleParameter("STREET", STREET));
                command.Parameters.Add(new OracleParameter("MOO", MOO));       
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
            return id;
        }
        /*
        public bool UpdatePersonnel()
        {
            bool result = false;
            SqlConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_SEMINAR Set ";
            query += " SEMINAR_NAME = :SEMINAR_NAME ,";
            query += " SEMINAR_LASTNAME = :SEMINAR_LASTNAME ,";
            query += " SEMINAR_POSITION = :SEMINAR_POSITION ,";
            query += " SEMINAR_DEGREE = :SEMINAR_DEGREE ,";
            query += " SEMINAR_CAMPUS = :SEMINAR_CAMPUS ,";
            query += " SEMINAR_NAMEOFPROJECT = :SEMINAR_NAMEOFPROJECT ,";
            query += " SEMINAR_PLACE = :SEMINAR_PLACE ,";
            query += " SEMINAR_DATETIME_FROM = :SEMINAR_DATETIME_FROM ,";
            query += " SEMINAR_DATETIME_TO = :SEMINAR_DATETIME_TO ,";
            query += " SEMINAR_DAY = :SEMINAR_DAY ,";
            query += " SEMINAR_MONTH = :SEMINAR_MONTH ,";
            query += " SEMINAR_YEAR = :SEMINAR_YEAR ,";
            query += " SEMINAR_BUDGET = :SEMINAR_BUDGET ,";
            query += " SEMINAR_SUPPORT_BUDGET = :SEMINAR_SUPPORT_BUDGET ,";
            query += " SEMINAR_CERTIFICATE = :SEMINAR_CERTIFICATE ,";
            query += " SEMINAR_ABSTRACT = :SEMINAR_ABSTRACT ,";
            query += " SEMINAR_RESULT = :SEMINAR_RESULT ,";
            query += " SEMINAR_SHOW_1 = :SEMINAR_SHOW_1 ,";
            query += " SEMINAR_SHOW_2 = :SEMINAR_SHOW_2 ,";
            query += " SEMINAR_SHOW_3 = :SEMINAR_SHOW_3 ,";
            query += " SEMINAR_SHOW_4 = :SEMINAR_SHOW_4 ,";
            query += " SEMINAR_PROBLEM = :SEMINAR_PROBLEM ,";
            query += " SEMINAR_COMMENT = :SEMINAR_COMMENT ,";
            query += " SEMINAR_SIGNED_DATETIME = :SEMINAR_SIGNED_DATETIME ";
            query += " where SEMINAR_ID  = :SEMINAR_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("SEMINAR_NAME", SEMINAR_NAME));
                command.Parameters.Add(new OracleParameter("SEMINAR_LASTNAME", SEMINAR_LASTNAME));
                command.Parameters.Add(new OracleParameter("SEMINAR_POSITION", SEMINAR_POSITION));
                command.Parameters.Add(new OracleParameter("SEMINAR_DEGREE", SEMINAR_DEGREE));
                command.Parameters.Add(new OracleParameter("SEMINAR_CAMPUS", SEMINAR_CAMPUS));
                command.Parameters.Add(new OracleParameter("SEMINAR_NAMEOFPROJECT", SEMINAR_NAMEOFPROJECT));
                command.Parameters.Add(new OracleParameter("SEMINAR_PLACE", SEMINAR_PLACE));
                command.Parameters.Add(new OracleParameter("SEMINAR_DATETIME_FROM", SEMINAR_DATETIME_FROM));
                command.Parameters.Add(new OracleParameter("SEMINAR_DATETIME_TO", SEMINAR_DATETIME_TO));
                command.Parameters.Add(new OracleParameter("SEMINAR_DAY", SEMINAR_DAY));
                command.Parameters.Add(new OracleParameter("SEMINAR_MONTH", SEMINAR_MONTH));
                command.Parameters.Add(new OracleParameter("SEMINAR_YEAR", SEMINAR_YEAR));
                command.Parameters.Add(new OracleParameter("SEMINAR_BUDGET", SEMINAR_BUDGET));
                command.Parameters.Add(new OracleParameter("SEMINAR_SUPPORT_BUDGET", SEMINAR_SUPPORT_BUDGET));
                command.Parameters.Add(new OracleParameter("SEMINAR_CERTIFICATE", SEMINAR_CERTIFICATE));
                command.Parameters.Add(new OracleParameter("SEMINAR_ABSTRACT", SEMINAR_ABSTRACT));
                command.Parameters.Add(new OracleParameter("SEMINAR_RESULT", SEMINAR_RESULT));
                command.Parameters.Add(new OracleParameter("SEMINAR_SHOW_1", SEMINAR_SHOW_1));
                command.Parameters.Add(new OracleParameter("SEMINAR_SHOW_2", SEMINAR_SHOW_2));
                command.Parameters.Add(new OracleParameter("SEMINAR_SHOW_3", SEMINAR_SHOW_3));
                command.Parameters.Add(new OracleParameter("SEMINAR_SHOW_4", SEMINAR_SHOW_4));
                command.Parameters.Add(new OracleParameter("SEMINAR_PROBLEM", SEMINAR_PROBLEM));
                command.Parameters.Add(new OracleParameter("SEMINAR_COMMENT", SEMINAR_COMMENT));
                command.Parameters.Add(new OracleParameter("SEMINAR_SIGNED_DATETIME", SEMINAR_SIGNED_DATETIME));
                command.Parameters.Add(new OracleParameter("SEMINAR_ID", SEMINAR_ID));
                if (command.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
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
            return result;
        }
        */
        public bool DeletePersonnel()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_PERSONAL where CITIZEN_ID = :CITIZEN_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                if (command.ExecuteNonQuery() >= 0)
                {
                    result = true;
                }
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
            return result;
        }

        public bool CheckUseCitizenID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(CITIZEN_ID) FROM TB_PERSONAL WHERE CITIZEN_ID = :CITIZEN_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int count = (int)(decimal)command.ExecuteScalar();
                if (count >= 1)
                {
                    result = false;
                }

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
            return result;
        }
    }
}
