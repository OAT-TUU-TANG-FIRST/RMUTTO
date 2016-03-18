using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities
{
    public class ClassInsigRecord2
    {
        public int ID { get; set; }
        public string CITIZEN_ID { get; set; }
        public DateTime DDATE { get; set; }
        public string POSITION_WORK_NAME { get; set; }
        public string POSITION_NAME { get; set; }
        public string GRADEINSIGNIA_NAME { get; set; }
        public string GAZETTE_LAM { get; set; }
        public string GAZETTE_TON { get; set; }
        public string GAZETTE_NA { get; set; }
        public DateTime GAZETTE_DATE { get; set; }
        public string INVOICE { get; set; }
        public string DECORATION { get; set; }
        public string NOTES { get; set; }


        public ClassInsigRecord2() { }
        public ClassInsigRecord2(int ID, string CITIZEN_ID, DateTime DDATE, string POSITION_WORK_NAME, string POSITION_NAME, string GRADEINSIGNIA_NAME, string GAZETTE_LAM, string GAZETTE_TON, string GAZETTE_NA, DateTime GAZETTE_DATE, string INVOICE, string DECORATION, string NOTES)
        {
            this.ID = ID;
            this.CITIZEN_ID = CITIZEN_ID;
            this.DDATE = DDATE;
            this.POSITION_WORK_NAME = POSITION_WORK_NAME;
            this.POSITION_NAME = POSITION_NAME;
            this.GRADEINSIGNIA_NAME = GRADEINSIGNIA_NAME;
            this.GAZETTE_LAM = GAZETTE_LAM;
            this.GAZETTE_TON = GAZETTE_TON;
            this.GAZETTE_NA = GAZETTE_NA;
            this.GAZETTE_DATE = GAZETTE_DATE;
            this.INVOICE = INVOICE;
            this.DECORATION = DECORATION;
            this.NOTES = NOTES;
        }

        public DataTable GetInsigRecord2(string CITIZEN_ID, string DDATE, string POSITION_WORK_NAME, string POSITION_NAME, string GRADEINSIGNIA_NAME, string GAZETTE_LAM, string GAZETTE_TON, string GAZETTE_NA, string GAZETTE_DATE, string INVOICE, string DECORATION, string NOTES)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_RECORDNOTE1 ";
            if (!string.IsNullOrEmpty(CITIZEN_ID) || !string.IsNullOrEmpty(DDATE) || !string.IsNullOrEmpty(POSITION_WORK_NAME) || !string.IsNullOrEmpty(POSITION_NAME) || !string.IsNullOrEmpty(GRADEINSIGNIA_NAME) || !string.IsNullOrEmpty(GAZETTE_LAM) || !string.IsNullOrEmpty(GAZETTE_TON) || !string.IsNullOrEmpty(GAZETTE_NA) || !string.IsNullOrEmpty(GAZETTE_DATE) || !string.IsNullOrEmpty(INVOICE) || !string.IsNullOrEmpty(DECORATION) || !string.IsNullOrEmpty(NOTES))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(CITIZEN_ID))
                {
                    query += " and CITIZEN_ID like :CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(DDATE))
                {
                    query += " and DDATE like :DDATE ";
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    query += " and POSITION_WORK_NAME like :POSITION_WORK_NAME ";
                }
                if (!string.IsNullOrEmpty(POSITION_NAME))
                {
                    query += " and POSITION_NAME like :POSITION_NAME ";
                }
                if (!string.IsNullOrEmpty(GRADEINSIGNIA_NAME))
                {
                    query += " and GRADEINSIGNIA_NAME like :GRADEINSIGNIA_NAME ";
                }
                if (!string.IsNullOrEmpty(GAZETTE_LAM))
                {
                    query += " and GAZETTE_LAM like :GAZETTE_LAM ";
                }
                if (!string.IsNullOrEmpty(GAZETTE_TON))
                {
                    query += " and GAZETTE_TON like :GAZETTE_TON ";
                }
                if (!string.IsNullOrEmpty(GAZETTE_NA))
                {
                    query += " and GAZETTE_NA like :GAZETTE_NA ";
                }
                if (!string.IsNullOrEmpty(GAZETTE_DATE))
                {
                    query += " and GAZETTE_DATE like :GAZETTE_DATE ";
                }
                if (!string.IsNullOrEmpty(INVOICE))
                {
                    query += " and INVOICE like :INVOICE ";
                }
                if (!string.IsNullOrEmpty(DECORATION))
                {
                    query += " and DECORATION like :DECORATION ";
                }
                if (!string.IsNullOrEmpty(NOTES))
                {
                    query += " and NOTES like :NOTES ";
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
                if (!string.IsNullOrEmpty(CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("CITIZEN_ID", "%" + CITIZEN_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DDATE))
                {
                    command.Parameters.Add(new OracleParameter("DDATE", "%" + DDATE + "%"));
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", "%" + POSITION_WORK_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(POSITION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_NAME", "%" + POSITION_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(GRADEINSIGNIA_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRADEINSIGNIA_NAME", "%" + GRADEINSIGNIA_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(GAZETTE_LAM))
                {
                    command.Parameters.Add(new OracleParameter("GAZETTE_LAM", "%" + GAZETTE_LAM + "%"));
                }
                if (!string.IsNullOrEmpty(GAZETTE_TON))
                {
                    command.Parameters.Add(new OracleParameter("GAZETTE_TON", "%" + GAZETTE_TON + "%"));
                }
                if (!string.IsNullOrEmpty(GAZETTE_NA))
                {
                    command.Parameters.Add(new OracleParameter("GAZETTE_NA", "%" + GAZETTE_NA + "%"));
                }
                if (!string.IsNullOrEmpty(GAZETTE_DATE))
                {
                    command.Parameters.Add(new OracleParameter("GAZETTE_DATE", "%" + GAZETTE_DATE + "%"));
                }
                if (!string.IsNullOrEmpty(INVOICE))
                {
                    command.Parameters.Add(new OracleParameter("INVOICE", "%" + INVOICE + "%"));
                }
                if (!string.IsNullOrEmpty(DECORATION))
                {
                    command.Parameters.Add(new OracleParameter("DECORATION", "%" + DECORATION + "%"));
                }
                if (!string.IsNullOrEmpty(NOTES))
                {
                    command.Parameters.Add(new OracleParameter("NOTES", "%" + NOTES + "%"));
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

        public int InserInsigRecord2()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_RECORDNOTE1 (CITIZEN_ID,DDATE,POSITION_WORK_NAME,POSITION_NAME,GRADEINSIGNIA_NAME,GAZETTE_LAM,GAZETTE_TON,GAZETTE_NA,GAZETTE_DATE,INVOICE,DECORATION,NOTES) VALUES (:CITIZEN_ID,:DDATE,:POSITION_WORK_NAME,:POSITION_NAME,:GRADEINSIGNIA_NAME,:GAZETTE_LAM,:GAZETTE_TON,:GAZETTE_NA,:GAZETTE_DATE,:INVOICE,:DECORATION,:NOTES)", conn);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("DDATE", DDATE));
                command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", POSITION_WORK_NAME));
                command.Parameters.Add(new OracleParameter("POSITION_NAME", POSITION_NAME));
                command.Parameters.Add(new OracleParameter("GRADEINSIGNIA_NAME", GRADEINSIGNIA_NAME));
                command.Parameters.Add(new OracleParameter("GAZETTE_LAM", GAZETTE_LAM));
                command.Parameters.Add(new OracleParameter("GAZETTE_TON", GAZETTE_TON));
                command.Parameters.Add(new OracleParameter("GAZETTE_NA", GAZETTE_NA));
                command.Parameters.Add(new OracleParameter("GAZETTE_DATE", GAZETTE_DATE));
                command.Parameters.Add(new OracleParameter("INVOICE", INVOICE));
                command.Parameters.Add(new OracleParameter("DECORATION", DECORATION));
                command.Parameters.Add(new OracleParameter("NOTES", NOTES));

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

        public bool UpdateInsigRecord2()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_RECORDNOTE1 Set ";
            query += " DDATE = :DDATE,";
            query += " POSITION_WORK_NAME = :POSITION_WORK_NAME,";
            query += " POSITION_NAME = :POSITION_NAME,";
            query += " GRADEINSIGNIA_NAME = :GRADEINSIGNIA_NAME,";
            query += " GAZETTE_LAM = :GAZETTE_LAM,";
            query += " GAZETTE_TON = :GAZETTE_TON,";
            query += " GAZETTE_NA = :GAZETTE_NA,";
            query += " GAZETTE_DATE = :GAZETTE_DATE,";
            query += " INVOICE = :INVOICE,";
            query += " DECORATION = :DECORATION,";
            query += " NOTES = :NOTES";
            query += " where ID = :ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DateTime d = DDATE;
                d = d.AddYears(543);
                command.Parameters.Add(new OracleParameter("DDATE", d));
                command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", POSITION_WORK_NAME));
                command.Parameters.Add(new OracleParameter("POSITION_NAME", POSITION_NAME));
                command.Parameters.Add(new OracleParameter("GRADEINSIGNIA_NAME", GRADEINSIGNIA_NAME));
                command.Parameters.Add(new OracleParameter("GAZETTE_LAM", GAZETTE_LAM));
                command.Parameters.Add(new OracleParameter("GAZETTE_TON", GAZETTE_TON));
                command.Parameters.Add(new OracleParameter("GAZETTE_NA", GAZETTE_NA));
                command.Parameters.Add(new OracleParameter("GAZETTE_DATE", d));
                command.Parameters.Add(new OracleParameter("INVOICE", INVOICE));
                command.Parameters.Add(new OracleParameter("DECORATION", DECORATION));
                command.Parameters.Add(new OracleParameter("NOTES", NOTES));
                command.Parameters.Add(new OracleParameter("ID", ID));

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
            }
            return result;
        }

        public bool DeleteInsigRecord2()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_RECORDNOTE1 where ID = :ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ID", ID));
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

        public bool CheckHaveCitizenID()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(CITIZEN_ID) FROM TB_PERSON WHERE CITIZEN_ID = :CITIZEN_ID ", conn);

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
    }

    public class ClassRequest
    {
        public int ID { get; set; }
        public string CITIZEN_ID { get; set; }
        public int RANK_ID { get; set; }
        public int TITLE_ID { get; set; }
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public int GENDER_ID { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public int STAFFTYPE_ID { get; set; }
        public int FACULTY_ID { get; set; }
        public int GRADEINSIGNIA_ID { get; set; }
        public DateTime STARTING_DATE { get; set; }
        public int STARTING_POSITION_ID { get; set; }
        public string CURRENT_POSITION { get; set; }
        public int CURRENT_SALARY { get; set; }

        public ClassRequest() { }
        public ClassRequest(int ID, string CITIZEN_ID, int RANK_ID, int TITLE_ID, string NAME, string LASTNAME, int GENDER_ID,
           DateTime BIRTHDATE, int STAFFTYPE_ID, int FACULTY_ID, int GRADEINSIGNIA_ID, DateTime STARTING_DATE, int STARTING_POSITION_ID,
           string CURRENT_POSITION, int CURRENT_SALARY)
        {
            this.ID = ID;
            this.CITIZEN_ID = CITIZEN_ID;
            this.RANK_ID = RANK_ID;
            this.TITLE_ID = TITLE_ID;
            this.NAME = NAME;
            this.LASTNAME = LASTNAME;
            this.GENDER_ID = GENDER_ID;
            this.BIRTHDATE = BIRTHDATE;
            this.STAFFTYPE_ID = STAFFTYPE_ID;
            this.FACULTY_ID = FACULTY_ID;
            this.GRADEINSIGNIA_ID = GRADEINSIGNIA_ID;
            this.STARTING_DATE = STARTING_DATE;
            this.STARTING_POSITION_ID = STARTING_POSITION_ID;
            this.CURRENT_POSITION = CURRENT_POSITION;
            this.CURRENT_SALARY = CURRENT_SALARY;

        }
        public int InsertRequest()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_PERSON (CITIZEN_ID,TITLE_ID,PERSON_NAME,PERSON_LASTNAME,BIRTHDATE,BIRTHDATE_LONG,RETIRE_DATE,RETIRE_DATE_LONG,INWORK_DATE,STAFFTYPE_ID,FATHER_NAME,FATHER_LASTNAME,MOTHER_NAME,MOTHER_LASTNAME,MOTHER_OLD_LASTNAME,COUPLE_NAME,COUPLE_LASTNAME,COUPLE_OLD_LASTNAME,MINISTRY_ID,DEPARTMENT_NAME,GENDER_ID,NATION_ID,HOMEADD,MOO,STREET,DISTRICT_ID,AMPHUR_ID,PROVINCE_ID,ZIPCODE_ID,TELEPHONE,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_WORK_ID,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_ISCED_ID,GRAD_PROG_ID,GRAD_UNIV,GRAD_COUNTRY_ID,FACULTY_ID,CAMPUS_ID,STATUS_ID,RELIGION_ID) VALUES (:CITIZEN_ID,:TITLE_ID,:PERSON_NAME,:PERSON_LASTNAME,:BIRTHDATE,:BIRTHDATE_LONG,:RETIRE_DATE,:RETIRE_DATE_LONG,:INWORK_DATE,:STAFFTYPE_ID,:FATHER_NAME,:FATHER_LASTNAME,:MOTHER_NAME,:MOTHER_LASTNAME,:MOTHER_OLD_LASTNAME,:COUPLE_NAME,:COUPLE_LASTNAME,:COUPLE_OLD_LASTNAME,:MINISTRY_ID,:DEPARTMENT_NAME,:GENDER_ID,:NATION_ID,:HOMEADD,:MOO,:STREET,:DISTRICT_ID,:AMPHUR_ID,:PROVINCE_ID,:ZIPCODE_ID,:TELEPHONE,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_WORK_ID,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_ISCED_ID,:GRAD_PROG_ID,:GRAD_UNIV,:GRAD_COUNTRY_ID,:FACULTY_ID,:CAMPUS_ID,:STATUS_ID,:RELIGION_ID)", conn);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("RANK_ID", RANK_ID));
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("LASTNAME", LASTNAME));
                command.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                command.Parameters.Add(new OracleParameter("BIRTHDATE", BIRTHDATE));
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("GRADEINSIGNIA_ID", GRADEINSIGNIA_ID));
                command.Parameters.Add(new OracleParameter("STARTING_DATE", STARTING_DATE));
                command.Parameters.Add(new OracleParameter("STARTING_POSITION_ID", STARTING_POSITION_ID));
                command.Parameters.Add(new OracleParameter("CURRENT_POSITION", CURRENT_POSITION));
                command.Parameters.Add(new OracleParameter("CURRENT_SALARY", CURRENT_SALARY));    

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

        public bool UpdateRequest()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_PERSON Set ";
            query += " RANK_ID = :RANK_ID ,";
            query += " TITLE_ID = :TITLE_ID ,";
            query += " NAME = :NAME ,";
            query += " LASTNAME = :LASTNAME ,";
            query += " GENDER_ID = :GENDER_ID ,";
            query += " BIRTHDATE = :BIRTHDATE ,";
            query += " STAFFTYPE_ID = :STAFFTYPE_ID ,";
            query += " FACULTY_ID = :FACULTY_ID ,";
            query += " STAFFTYPE_ID = :STAFFTYPE_ID ,";
            query += " GRADEINSIGNIA_ID = :GRADEINSIGNIA_ID ,";
            query += " STARTING_DATE = :STARTING_DATE ,";
            query += " STARTING_POSITION_ID = :STARTING_POSITION_ID ,";
            query += " CURRENT_POSITION = :CURRENT_POSITION ,";
            query += " CURRENT_SALARY = :CURRENT_SALARY ";
            query += " where CITIZEN_ID  = :CITIZEN_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                
                command.Parameters.Add(new OracleParameter("RANK_ID", RANK_ID));
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("LASTNAME", LASTNAME));
                command.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                command.Parameters.Add(new OracleParameter("BIRTHDATE", BIRTHDATE));
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("GRADEINSIGNIA_ID", GRADEINSIGNIA_ID));
                command.Parameters.Add(new OracleParameter("STARTING_DATE", STARTING_DATE));
                command.Parameters.Add(new OracleParameter("STARTING_POSITION_ID", STARTING_POSITION_ID));
                command.Parameters.Add(new OracleParameter("CURRENT_POSITION", CURRENT_POSITION));
                command.Parameters.Add(new OracleParameter("CURRENT_SALARY", CURRENT_SALARY));
                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));

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
    }
}