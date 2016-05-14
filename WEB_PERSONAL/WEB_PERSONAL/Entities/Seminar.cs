using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities
{
    public class Seminar
    {
        public int SEMINAR_ID { get; set; }
        public string SEMINAR_NAME { get; set; }
        public string SEMINAR_LASTNAME { get; set; }
        public string SEMINAR_POSITION { get; set; }
        public string SEMINAR_DEGREE { get; set; }
        public string SEMINAR_CAMPUS { get; set; }
        public string SEMINAR_NAMEOFPROJECT { get; set; }
        public string SEMINAR_PLACE { get; set; }
        public DateTime SEMINAR_DATETIME_FROM { get; set; }
        public DateTime SEMINAR_DATETIME_TO { get; set; }
        public int SEMINAR_DAY { get; set; }
        public int SEMINAR_MONTH { get; set; }
        public int SEMINAR_YEAR { get; set; }
        public int SEMINAR_BUDGET { get; set; }
        public string SEMINAR_SUPPORT_BUDGET { get; set; }
        public string SEMINAR_CERTIFICATE { get; set; }
        public string SEMINAR_ABSTRACT { get; set; }
        public string SEMINAR_RESULT { get; set; }
        public string SEMINAR_SHOW_1 { get; set; }
        public string SEMINAR_SHOW_2 { get; set; }
        public string SEMINAR_SHOW_3 { get; set; }
        public string SEMINAR_SHOW_4 { get; set; }
        public string SEMINAR_PROBLEM { get; set; }
        public string SEMINAR_COMMENT { get; set; }
        public DateTime SEMINAR_SIGNED_DATETIME { get; set; }
        public string CITIZEN_ID { get; set; }

        public Seminar() { }
        public Seminar(int SEMINAR_ID, string SEMINAR_NAME, string SEMINAR_LASTNAME, string SEMINAR_POSITION, string SEMINAR_DEGREE, string SEMINAR_CAMPUS, string SEMINAR_NAMEOFPROJECT,
        string SEMINAR_PLACE, DateTime SEMINAR_DATETIME_FROM, DateTime SEMINAR_DATETIME_TO, int SEMINAR_DAY, int SEMINAR_MONTH, int SEMINAR_YEAR, int SEMINAR_BUDGET, string SEMINAR_SUPPORT_BUDGET,
        string SEMINAR_CERTIFICATE, string SEMINAR_ABSTRACT, string SEMINAR_RESULT, string SEMINAR_SHOW_1, string SEMINAR_SHOW_2, string SEMINAR_SHOW_3, string SEMINAR_SHOW_4, string SEMINAR_PROBLEM,
        string SEMINAR_COMMENT, DateTime SEMINAR_SIGNED_DATETIME, string CITIZEN_ID)
        {
            this.SEMINAR_ID = SEMINAR_ID;
            this.SEMINAR_NAME = SEMINAR_NAME;
            this.SEMINAR_LASTNAME = SEMINAR_LASTNAME;
            this.SEMINAR_POSITION = SEMINAR_POSITION;
            this.SEMINAR_DEGREE = SEMINAR_DEGREE;
            this.SEMINAR_CAMPUS = SEMINAR_CAMPUS;
            this.SEMINAR_NAMEOFPROJECT = SEMINAR_NAMEOFPROJECT;
            this.SEMINAR_PLACE = SEMINAR_PLACE;
            this.SEMINAR_DATETIME_FROM = SEMINAR_DATETIME_FROM;
            this.SEMINAR_DATETIME_TO = SEMINAR_DATETIME_TO;
            this.SEMINAR_DAY = SEMINAR_DAY;
            this.SEMINAR_MONTH = SEMINAR_MONTH;
            this.SEMINAR_YEAR = SEMINAR_YEAR;
            this.SEMINAR_BUDGET = SEMINAR_BUDGET;
            this.SEMINAR_SUPPORT_BUDGET = SEMINAR_SUPPORT_BUDGET;
            this.SEMINAR_CERTIFICATE = SEMINAR_CERTIFICATE;
            this.SEMINAR_ABSTRACT = SEMINAR_ABSTRACT;
            this.SEMINAR_RESULT = SEMINAR_RESULT;
            this.SEMINAR_SHOW_1 = SEMINAR_SHOW_1;
            this.SEMINAR_SHOW_2 = SEMINAR_SHOW_2;
            this.SEMINAR_SHOW_3 = SEMINAR_SHOW_3;
            this.SEMINAR_SHOW_4 = SEMINAR_SHOW_4;
            this.SEMINAR_PROBLEM = SEMINAR_PROBLEM;
            this.SEMINAR_COMMENT = SEMINAR_COMMENT;
            this.SEMINAR_SIGNED_DATETIME = SEMINAR_SIGNED_DATETIME;
            this.CITIZEN_ID = CITIZEN_ID;
        }

        public DataTable GetSEMINAR(string CITIZEN_ID, string SEMINAR_NAME, string SEMINAR_LASTNAME, string SEMINAR_NAMEOFPROJECT, string SEMINAR_PLACE)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_SEMINAR ";
            if (!string.IsNullOrEmpty(CITIZEN_ID) || !string.IsNullOrEmpty(SEMINAR_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(CITIZEN_ID))
                {
                    query += " and CITIZEN_ID like :CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    query += " and SEMINAR_NAME like :SEMINAR_NAME ";
                }
                if (!string.IsNullOrEmpty(SEMINAR_LASTNAME))
                {
                    query += " and SEMINAR_LASTNAME like :SEMINAR_LASTNAME ";
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAMEOFPROJECT))
                {
                    query += " and SEMINAR_NAMEOFPROJECT like :SEMINAR_NAMEOFPROJECT ";
                }
                if (!string.IsNullOrEmpty(SEMINAR_PLACE))
                {
                    query += " and SEMINAR_PLACE like :SEMINAR_PLACE ";
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
                    command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SEMINAR_NAME", SEMINAR_NAME ));
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SEMINAR_LASTNAME", SEMINAR_LASTNAME));
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SEMINAR_NAMEOFPROJECT", SEMINAR_NAMEOFPROJECT));
                }
                if (!string.IsNullOrEmpty(SEMINAR_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SEMINAR_PLACE", SEMINAR_PLACE));
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

        public int InsertSEMINAR()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_SEMINAR (seminar_name,seminar_lastname,seminar_position,seminar_degree,seminar_campus,seminar_nameofproject,seminar_place,seminar_datetime_from,seminar_datetime_to, seminar_day, seminar_month, seminar_year, seminar_budget, seminar_support_budget, seminar_certificate, seminar_abstract, seminar_result, seminar_show_1, seminar_show_2, seminar_show_3, seminar_show_4, seminar_problem, seminar_comment,SEMINAR_SIGNED_DATETIME,citizen_id) VALUES (:seminar_name,:seminar_lastname,:seminar_position,:seminar_degree,:seminar_campus,:seminar_nameofproject,:seminar_place,:seminar_datetime_from,:seminar_datetime_to, :seminar_day, :seminar_month, :seminar_year, :seminar_budget, :seminar_support_budget, :seminar_certificate, :seminar_abstract, :seminar_result, :seminar_show_1, :seminar_show_2, :seminar_show_3, :seminar_show_4, :seminar_problem, :seminar_comment,:SEMINAR_SIGNED_DATETIME,:citizen_id)", conn);

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
                command.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
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

        public bool UpdateSEMINAR()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
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

        public bool DeleteSEMINAR()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_SEMINAR where SEMINAR_ID = :SEMINAR_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("SEMINAR_ID", SEMINAR_ID));
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

        public int SelectSEMINAR()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_SEMINAR (seminar_name,seminar_lastname,seminar_position,seminar_degree,seminar_campus,seminar_nameofproject,seminar_place,seminar_datetime_from,seminar_datetime_to, seminar_day, seminar_month, seminar_year, seminar_budget, seminar_support_budget, seminar_certificate, seminar_abstract, seminar_result, seminar_show_1, seminar_show_2, seminar_show_3, seminar_show_4, seminar_problem, seminar_comment,SEMINAR_SIGNED_DATETIME) VALUES (:seminar_name,:seminar_lastname,:seminar_position,:seminar_degree,:seminar_campus,:seminar_nameofproject,:seminar_place,:seminar_datetime_from,:seminar_datetime_to, :seminar_day, :seminar_month, :seminar_year, :seminar_budget, :seminar_support_budget, :seminar_certificate, :seminar_abstract, :seminar_result, :seminar_show_1, :seminar_show_2, :seminar_show_3, :seminar_show_4, :seminar_problem, :seminar_comment,:SEMINAR_SIGNED_DATETIME)", conn);

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
    }
}
