using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities
{
    public class ClassInsigRequest
    {
        public int IR_ID { get; set; }
        public int IR_STATUS { get; set; }
        public string IR_CITIZEN_ID { get; set; }
        public int IR_INSIG_ID { get; set; }
        public DateTime IR_DATE_START { get; set; }
        public int IR_RANK_ID { get; set; }
        public int IR_TITLE_ID { get; set; }
        public string IR_NAME { get; set; }
        public string IR_LASTNAME { get; set; }
        public int IR_GENDER_ID { get; set; }
        public DateTime IR_BIRTHDATE { get; set; }
        public DateTime IR_DATE_INWORK { get; set; }
        public string IR_START_POSITION { get; set; }
        public string IR_START_DEGREE { get; set; }
        public string IR_CURRENT_POSITION { get; set; }
        public string IR_TYPE { get; set; }
        public string IR_DEGREE { get; set; }
        public int IR_CURRENT_SALARY { get; set; }
        public int IR_POSITION_SALARY { get; set; }
        public int IR_BACK_5Y_SALARY { get; set; }
        
        public ClassInsigRequest() { }
        public ClassInsigRequest(int IR_ID, int IR_STATUS, string IR_CITIZEN_ID, int IR_INSIG_ID, DateTime IR_DATE_START, int IR_RANK_ID, int IR_TITLE_ID, string IR_NAME, string IR_LASTNAME, int IR_GENDER_ID, DateTime IR_BIRTHDATE, DateTime IR_DATE_INWORK, string IR_START_POSITION, string IR_START_DEGREE, string IR_CURRENT_POSITION, string IR_TYPE, string IR_DEGREE, int IR_CURRENT_SALARY, int IR_POSITION_SALARY, int IR_BACK_5Y_SALARY)
        {
            this.IR_ID = IR_ID;
            this.IR_STATUS = IR_STATUS;
            this.IR_INSIG_ID = IR_INSIG_ID;
            this.IR_DATE_START = IR_DATE_START;
            this.IR_RANK_ID = IR_RANK_ID;
            this.IR_TITLE_ID = IR_TITLE_ID;
            this.IR_NAME = IR_NAME;
            this.IR_LASTNAME = IR_LASTNAME;
            this.IR_GENDER_ID = IR_GENDER_ID;
            this.IR_BIRTHDATE = IR_BIRTHDATE;
            this.IR_DATE_INWORK = IR_DATE_INWORK;
            this.IR_START_POSITION = IR_START_POSITION;
            this.IR_START_DEGREE = IR_START_DEGREE;
            this.IR_CURRENT_POSITION = IR_CURRENT_POSITION;
            this.IR_TYPE = IR_TYPE;
            this.IR_DEGREE = IR_DEGREE;
            this.IR_CURRENT_SALARY = IR_CURRENT_SALARY;
            this.IR_POSITION_SALARY = IR_POSITION_SALARY;
            this.IR_BACK_5Y_SALARY = IR_BACK_5Y_SALARY;
        }
        
    }
    /////////
    /////////
    public class ClassInsigUserGet
    {
        public int IUG_ID { get; set; }
        public string IUG_CITIZEN_ID { get; set; }
        public int IUG_INSIG_ID { get; set; }
        public DateTime IUG_INSIG_DATE_GET { get; set; }
        public int IUG_STATUS { get; set; }
        public string IUG_POSITION { get; set; }
        public int IUG_SALARY { get; set; }
        public string IUG_REF { get; set; }

        public ClassInsigUserGet() { }
        public ClassInsigUserGet(int IUG_ID, string IUG_CITIZEN_ID, int IUG_INSIG_ID, DateTime IUG_INSIG_DATE_GET, int IUG_STATUS, string IUG_POSITION, int IUG_SALARY, string IUG_REF)
        {
            this.IUG_ID = IUG_ID;
            this.IUG_CITIZEN_ID = IUG_CITIZEN_ID;
            this.IUG_INSIG_ID = IUG_INSIG_ID;
            this.IUG_INSIG_DATE_GET = IUG_INSIG_DATE_GET;
            this.IUG_STATUS = IUG_STATUS;
            this.IUG_POSITION = IUG_POSITION;
            this.IUG_SALARY = IUG_SALARY;
            this.IUG_REF = IUG_REF;
        }

        public DataTable GetInsigUserGet(string IUG_CITIZEN_ID, string IUG_INSIG_ID, string IUG_INSIG_DATE_GET, string IUG_STATUS, string IUG_POSITION, string IUG_SALARY, string IUG_REF)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_INSIG_USER_GET ";
            if (!string.IsNullOrEmpty(IUG_CITIZEN_ID) || !string.IsNullOrEmpty(IUG_INSIG_ID) || !string.IsNullOrEmpty(IUG_INSIG_DATE_GET) || !string.IsNullOrEmpty(IUG_STATUS) || !string.IsNullOrEmpty(IUG_POSITION) || !string.IsNullOrEmpty(IUG_SALARY) || !string.IsNullOrEmpty(IUG_REF))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(IUG_CITIZEN_ID))
                {
                    query += " and IUG_CITIZEN_ID like :IUG_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(IUG_INSIG_ID))
                {
                    query += " and IUG_INSIG_ID like :IUG_INSIG_ID ";
                }
                if (!string.IsNullOrEmpty(IUG_INSIG_DATE_GET))
                {
                    query += " and IUG_INSIG_DATE_GET like :IUG_INSIG_DATE_GET ";
                }
                if (!string.IsNullOrEmpty(IUG_STATUS))
                {
                    query += " and IUG_STATUS like :IUG_STATUS ";
                }
                if (!string.IsNullOrEmpty(IUG_POSITION))
                {
                    query += " and IUG_POSITION like :IUG_POSITION ";
                }
                if (!string.IsNullOrEmpty(IUG_SALARY))
                {
                    query += " and IUG_SALARY like :IUG_SALARY ";
                }
                if (!string.IsNullOrEmpty(IUG_REF))
                {
                    query += " and IUG_REF like :IUG_REF ";
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
                if (!string.IsNullOrEmpty(IUG_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("IUG_CITIZEN_ID", IUG_CITIZEN_ID ));
                }
                if (!string.IsNullOrEmpty(IUG_INSIG_ID))
                {
                    command.Parameters.Add(new OracleParameter("IUG_INSIG_ID", IUG_INSIG_ID));
                }
                if (!string.IsNullOrEmpty(IUG_INSIG_DATE_GET))
                {
                    command.Parameters.Add(new OracleParameter("IUG_INSIG_DATE_GET", IUG_INSIG_DATE_GET));
                }
                if (!string.IsNullOrEmpty(IUG_STATUS))
                {
                    command.Parameters.Add(new OracleParameter("IUG_STATUS", IUG_STATUS));
                }
                if (!string.IsNullOrEmpty(IUG_POSITION))
                {
                    command.Parameters.Add(new OracleParameter("IUG_POSITION", IUG_POSITION));
                }
                if (!string.IsNullOrEmpty(IUG_SALARY))
                {
                    command.Parameters.Add(new OracleParameter("IUG_SALARY", IUG_SALARY));
                }
                if (!string.IsNullOrEmpty(IUG_REF))
                {
                    command.Parameters.Add(new OracleParameter("IUG_REF", IUG_REF));
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

        public bool UpdateInsigUserGet()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_INSIG_USER_GET Set ";
            query += " IUG_CITIZEN_ID = :IUG_CITIZEN_ID,";
            query += " IUG_INSIG_ID = :IUG_INSIG_ID,";
            query += " IUG_INSIG_DATE_GET = :IUG_INSIG_DATE_GET,";
            query += " IUG_STATUS = :IUG_STATUS,";
            query += " IUG_POSITION = :IUG_POSITION,";
            query += " IUG_SALARY = :IUG_SALARY,";
            query += " IUG_REF = :IUG_REF";
            query += " where IUG_ID = :IUG_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("IUG_CITIZEN_ID", IUG_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("IUG_INSIG_ID", IUG_INSIG_ID));
                command.Parameters.Add(new OracleParameter("IUG_INSIG_DATE_GET", IUG_INSIG_DATE_GET));
                command.Parameters.Add(new OracleParameter("IUG_STATUS", IUG_STATUS));
                command.Parameters.Add(new OracleParameter("IUG_POSITION", IUG_POSITION));
                command.Parameters.Add(new OracleParameter("IUG_SALARY", IUG_SALARY));
                command.Parameters.Add(new OracleParameter("IUG_REF", IUG_REF));
                command.Parameters.Add(new OracleParameter("IUG_ID", IUG_ID));
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

        public bool DeleteInsigUserGet()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_INSIG_USER_GET where IUG_ID = :IUG_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("IUG_ID", IUG_ID));
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
    }

}