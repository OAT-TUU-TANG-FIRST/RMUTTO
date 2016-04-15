using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities
{
    /// <summary>
    /// คำนำหน้า
    /// </summary>
    public class ClassTitleName
    {

        public int TITLE_ID { get; set; }
        public string TITLE_NAME_TH { get; set; }

        public ClassTitleName() { }
        public ClassTitleName(int TITLE_ID, string TITLE_NAME_TH)
        {
            this.TITLE_ID = TITLE_ID;
            this.TITLE_NAME_TH = TITLE_NAME_TH;
        }

        public DataTable GetTitleName(string TITLE_ID, string TITLE_NAME_TH)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TITLENAME ";
            if (!string.IsNullOrEmpty(TITLE_ID) || !string.IsNullOrEmpty(TITLE_NAME_TH))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TITLE_ID))
                {
                    query += " and TITLE_ID like :TITLE_ID ";
                }
                if (!string.IsNullOrEmpty(TITLE_NAME_TH))
                {
                    query += " and TITLE_NAME_TH like :TITLE_NAME_TH ";
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

                if (!string.IsNullOrEmpty(TITLE_ID))
                {
                    command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TITLE_NAME_TH))
                {
                    command.Parameters.Add(new OracleParameter("TITLE_NAME_TH", TITLE_NAME_TH + "%"));
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

        public DataTable GetTitleNameSearch(string TITLE_ID, string TITLE_NAME_TH)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TITLENAME ";
            if (!string.IsNullOrEmpty(TITLE_ID) || !string.IsNullOrEmpty(TITLE_NAME_TH))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TITLE_ID))
                {
                    query += " and TITLE_ID like :TITLE_ID ";
                }
                if (!string.IsNullOrEmpty(TITLE_NAME_TH))
                {
                    query += " and TITLE_NAME_TH like :TITLE_NAME_TH ";
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

                if (!string.IsNullOrEmpty(TITLE_ID))
                {
                    command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TITLE_NAME_TH))
                {
                    command.Parameters.Add(new OracleParameter("TITLE_NAME_TH", TITLE_NAME_TH + "%"));
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

        public int InsertTitleName()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_TITLENAME (TITLE_ID,TITLE_NAME_TH) VALUES (:TITLE_ID,:TITLE_NAME_TH)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
                command.Parameters.Add(new OracleParameter("TITLE_NAME_TH", TITLE_NAME_TH));
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

        public bool UpdateTitleName()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_TITLENAME Set ";
            query += " TITLE_ID = :TITLE_ID,";
            query += " TITLE_NAME_TH = :TITLE_NAME_TH";
            query += " where TITLE_ID = :TITLE_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
                command.Parameters.Add(new OracleParameter("TITLE_NAME_TH", TITLE_NAME_TH));

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

        public bool DeleteTitleName()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_TITLENAME where TITLE_ID = :TITLE_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
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

        public bool CheckUseTitleID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(TITLE_ID) FROM TB_TITLENAME WHERE TITLE_ID = :TITLE_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("TITLE_ID", TITLE_ID));
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
    /// <summary>
    /// เพศ
    /// </summary>
    public class ClassGender
    {
        public int Gender_ID { get; set; }
        public string Gender_Name { get; set; }

        public ClassGender() { }
        public ClassGender(int Gender_ID, string Gender_Name)
        {
            this.Gender_ID = Gender_ID;
            this.Gender_Name = Gender_Name;
        }

        public DataTable GetGender(string Gender_ID, string Gender_Name)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GENDER ";
            if (!string.IsNullOrEmpty(Gender_ID) || !string.IsNullOrEmpty(Gender_Name))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(Gender_ID))
                {
                    query += " and Gender_ID like :Gender_ID ";
                }
                if (!string.IsNullOrEmpty(Gender_Name))
                {
                    query += " and Gender_Name like :Gender_Name ";
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
                if (!string.IsNullOrEmpty(Gender_ID))
                {
                    command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID + "%"));
                }
                if (!string.IsNullOrEmpty(Gender_Name))
                {
                    command.Parameters.Add(new OracleParameter("Gender_Name", "%" + Gender_Name + "%"));
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

        public DataTable GetGenderSearch(string Gender_ID, string Gender_Name)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GENDER";
            if (!string.IsNullOrEmpty(Gender_ID) || !string.IsNullOrEmpty(Gender_Name))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(Gender_ID))
                {
                    query += " and Gender_ID like :Gender_ID ";
                }
                if (!string.IsNullOrEmpty(Gender_Name))
                {
                    query += " and Gender_Name like :Gender_Name ";
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
                if (!string.IsNullOrEmpty(Gender_ID))
                {
                    command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID + "%"));
                }
                if (!string.IsNullOrEmpty(Gender_Name))
                {
                    command.Parameters.Add(new OracleParameter("Gender_Name", "%" + Gender_Name + "%"));
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

        public int InsertGender()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_GENDER (Gender_ID,Gender_Name) VALUES (:Gender_ID,:Gender_Name)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID));
                command.Parameters.Add(new OracleParameter("Gender_Name", Gender_Name));
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

        public bool UpdateGender()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_GENDER Set ";
            query += " Gender_ID = :Gender_ID,";
            query += " Gender_Name = :Gender_Name";
            query += " where Gender_ID = :Gender_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID));
                command.Parameters.Add(new OracleParameter("Gender_Name", Gender_Name));

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

        public bool DeleteGender()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_GENDER where Gender_ID = :Gender_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID));
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

        public bool CheckUseGenderID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(Gender_ID) FROM TB_GENDER WHERE Gender_ID = :Gender_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("Gender_ID", Gender_ID));
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
    /// <summary>
    /// เชื้อชาติ / สัญชาติ
    /// </summary>
    public class ClassNational
    {
        public int NATION_SEQ { get; set; }
        public string NATION_ID { get; set; }
        public string NATION_ENG { get; set; }
        public string NATION_THA { get; set; }


        public ClassNational() { }
        public ClassNational(int NATION_SEQ, string NATION_ID, string NATION_ENG, string NATION_THA)
        {
            this.NATION_SEQ = NATION_SEQ;
            this.NATION_ID = NATION_ID;
            this.NATION_ENG = NATION_ENG;
            this.NATION_THA = NATION_THA;
        }

        public DataTable GetNational(string NATION_ID, string NATION_ENG, string NATION_THA)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_NATIONAL ";
            if (!string.IsNullOrEmpty(NATION_ID) || !string.IsNullOrEmpty(NATION_ENG) || !string.IsNullOrEmpty(NATION_THA))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(NATION_ID))
                {
                    query += " and lower(NATION_ID) like lower (:NATION_ID) ";
                }
                if (!string.IsNullOrEmpty(NATION_ENG))
                {
                    query += " and lower(NATION_ENG) like lower (:NATION_ENG) ";
                }
                if (!string.IsNullOrEmpty(NATION_THA))
                {
                    query += " and NATION_THA like :NATION_THA ";
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

                if (!string.IsNullOrEmpty(NATION_ID))
                {
                    command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(NATION_ENG))
                {
                    command.Parameters.Add(new OracleParameter("NATION_ENG", "%" + NATION_ENG + "%"));
                }
                if (!string.IsNullOrEmpty(NATION_THA))
                {
                    command.Parameters.Add(new OracleParameter("NATION_THA", "%" + NATION_THA + "%"));
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

        public DataTable GetNationalSearch(string NATION_ID, string NATION_ENG, string NATION_THA)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_NATIONAL ";
            if (!string.IsNullOrEmpty(NATION_ID) || !string.IsNullOrEmpty(NATION_ENG) || !string.IsNullOrEmpty(NATION_THA))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(NATION_ID))
                {
                    query += " and lower(NATION_ID) like lower (:NATION_ID) ";
                }
                if (!string.IsNullOrEmpty(NATION_ENG))
                {
                    query += " and lower(NATION_ENG) like lower (:NATION_ENG) ";
                }
                if (!string.IsNullOrEmpty(NATION_THA))
                {
                    query += " and NATION_THA like :NATION_THA ";
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

                if (!string.IsNullOrEmpty(NATION_ID))
                {
                    command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(NATION_ENG))
                {
                    command.Parameters.Add(new OracleParameter("NATION_ENG", "%" + NATION_ENG + "%"));
                }
                if (!string.IsNullOrEmpty(NATION_THA))
                {
                    command.Parameters.Add(new OracleParameter("NATION_THA", "%" + NATION_THA + "%"));
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

        public int InsertNational()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_NATIONAL (NATION_ID,NATION_ENG,NATION_THA) VALUES (:NATION_ID,:NATION_ENG,:NATION_THA)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                command.Parameters.Add(new OracleParameter("NATION_ENG", NATION_ENG));
                command.Parameters.Add(new OracleParameter("NATION_THA", NATION_THA));
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

        public bool UpdateNational()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_NATIONAL Set ";
            query += " NATION_ID = :NATION_ID,";
            query += " NATION_ENG = :NATION_ENG,";
            query += " NATION_THA = :NATION_THA";
            query += " where NATION_SEQ = :NATION_SEQ";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                command.Parameters.Add(new OracleParameter("NATION_ENG", NATION_ENG));
                command.Parameters.Add(new OracleParameter("NATION_THA", NATION_THA));
                command.Parameters.Add(new OracleParameter("NATION_SEQ", NATION_SEQ));
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

        public bool DeleteNational()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_NATIONAL where NATION_SEQ = :NATION_SEQ", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("NATION_SEQ", NATION_SEQ));
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

        public bool CheckUseNationID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(NATION_ID) FROM TB_NATIONAL WHERE NATION_ID = :NATION_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
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
    /// <summary>
    /// กรุ๊ปเลือด
    /// </summary>
    public class ClassBlood
    {
        public int BLOOD_ID { get; set; }
        public string BLOOD_NAME { get; set; }

        public ClassBlood() { }
        public ClassBlood(int BLOOD_ID, string BLOOD_NAME)
        {
            this.BLOOD_ID = BLOOD_ID;
            this.BLOOD_NAME = BLOOD_NAME;
        }

        public DataTable GetBlood(string BLOOD_ID, string BLOOD_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BLOOD ";
            if (!string.IsNullOrEmpty(BLOOD_ID) || !string.IsNullOrEmpty(BLOOD_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BLOOD_ID))
                {
                    query += " and BLOOD_ID like :BLOOD_ID ";
                }
                if (!string.IsNullOrEmpty(BLOOD_NAME))
                {
                    query += " and BLOOD_NAME like :BLOOD_NAME ";
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
                if (!string.IsNullOrEmpty(BLOOD_ID))
                {
                    command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BLOOD_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BLOOD_NAME", "%" + BLOOD_NAME + "%"));
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

        public DataTable GetBloodSearch(string BLOOD_ID, string BLOOD_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BLOOD";
            if (!string.IsNullOrEmpty(BLOOD_ID) || !string.IsNullOrEmpty(BLOOD_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BLOOD_ID))
                {
                    query += " and BLOOD_ID like :BLOOD_ID ";
                }
                if (!string.IsNullOrEmpty(BLOOD_NAME))
                {
                    query += " and BLOOD_NAME like :BLOOD_NAME ";
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
                if (!string.IsNullOrEmpty(BLOOD_ID))
                {
                    command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BLOOD_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BLOOD_NAME", BLOOD_NAME + "%"));
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

        public int InsertBlood()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_BLOOD (BLOOD_ID,BLOOD_NAME) VALUES (:BLOOD_ID,:BLOOD_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID));
                command.Parameters.Add(new OracleParameter("BLOOD_NAME", BLOOD_NAME));
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

        public bool UpdateBlood()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_BLOOD Set ";
            query += " BLOOD_ID = :BLOOD_ID,";
            query += " BLOOD_NAME = :BLOOD_NAME";
            query += " where BLOOD_ID = :BLOOD_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID));
                command.Parameters.Add(new OracleParameter("BLOOD_NAME", BLOOD_NAME));

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

        public bool DeleteBlood()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_BLOOD where BLOOD_ID = :BLOOD_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID));
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

        public bool CheckUseBloodID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(BLOOD_ID) FROM TB_BLOOD WHERE BLOOD_ID = :BLOOD_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("BLOOD_ID", BLOOD_ID));
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
    /// <summary>
    /// ศาสนา
    /// </summary>
    public class ClassReligion
    {

        public int RELIGION_ID { get; set; }
        public string RELIGION_NAME { get; set; }

        public ClassReligion() { }
        public ClassReligion(int RELIGION_ID, string RELIGION_NAME)
        {
            this.RELIGION_ID = RELIGION_ID;
            this.RELIGION_NAME = RELIGION_NAME;
        }

        public DataTable GetReligion(string RELIGION_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_RELIGION ";
            if (!string.IsNullOrEmpty(RELIGION_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(RELIGION_NAME))
                {
                    query += " and RELIGION_NAME like :RELIGION_NAME ";
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
                if (!string.IsNullOrEmpty(RELIGION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("RELIGION_NAME", RELIGION_NAME + "%"));
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

        public DataTable GetReligionSearch(string RELIGION_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_RELIGION ";
            if (!string.IsNullOrEmpty(RELIGION_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(RELIGION_NAME))
                {
                    query += " and RELIGION_NAME like :RELIGION_NAME ";
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
                if (!string.IsNullOrEmpty(RELIGION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("RELIGION_NAME", RELIGION_NAME + "%"));
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

        public int InsertReligion()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_RELIGION (RELIGION_NAME) VALUES (:RELIGION_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("RELIGION_NAME", RELIGION_NAME));
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

        public bool UpdateReligion()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_RELIGION Set ";
            query += " RELIGION_NAME = :RELIGION_NAME";
            query += " where RELIGION_ID = :RELIGION_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("RELIGION_ID", RELIGION_ID));
                command.Parameters.Add(new OracleParameter("RELIGION_NAME", RELIGION_NAME));

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

        public bool DeleteReligion()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_RELIGION where RELIGION_ID = :RELIGION_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("RELIGION_ID", RELIGION_ID));
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

        public bool CheckUseReligionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(RELIGION_ID) FROM TB_RELIGION WHERE RELIGION_ID = :RELIGION_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("RELIGION_ID", RELIGION_ID));
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
    /// <summary>
    /// สถานภาพ
    /// </summary>
    public class ClassStatusPerson
    {

        public int STATUS_ID { get; set; }
        public string STATUS_NAME { get; set; }

        public ClassStatusPerson() { }
        public ClassStatusPerson(int STATUS_ID, string STATUS_NAME)
        {
            this.STATUS_ID = STATUS_ID;
            this.STATUS_NAME = STATUS_NAME;
        }

        public DataTable GetStatusPerson(string STATUS_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STATUS_PERSON ";
            if (!string.IsNullOrEmpty(STATUS_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STATUS_NAME))
                {
                    query += " and STATUS_NAME like :STATUS_NAME ";
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
                if (!string.IsNullOrEmpty(STATUS_NAME))
                {
                    command.Parameters.Add(new OracleParameter("STATUS_NAME", STATUS_NAME + "%"));
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

        public DataTable GetStatusPersonSearch(string STATUS_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STATUS_PERSON ";
            if (!string.IsNullOrEmpty(STATUS_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STATUS_NAME))
                {
                    query += " and STATUS_NAME like :STATUS_NAME ";
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
                if (!string.IsNullOrEmpty(STATUS_NAME))
                {
                    command.Parameters.Add(new OracleParameter("STATUS_NAME", STATUS_NAME + "%"));
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

        public int InsertStatusPerson()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_STATUS_PERSON (STATUS_NAME) VALUES (:STATUS_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_NAME", STATUS_NAME));
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

        public bool UpdateStatusPerson()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_STATUS_PERSON Set ";
            query += " STATUS_NAME = :STATUS_NAME";
            query += " where STATUS_ID = :STATUS_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
                command.Parameters.Add(new OracleParameter("STATUS_NAME", STATUS_NAME));

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

        public bool DeleteStatusPerson()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_STATUS_PERSON where STATUS_ID = :STATUS_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
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

        public bool CheckUseStatusPersonID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(STATUS_ID) FROM TB_STATUS_PERSON WHERE STATUS_ID = :STATUS_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
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
    /// <summary>
    /// จังหวัด
    /// </summary>
    public class ClassProvince
    {
        public int PROVINCE_ID { get; set; }
        public string PROVINCE_TH { get; set; }
        public string PROVINCE_EN { get; set; }


        public ClassProvince() { }
        public ClassProvince(int PROVINCE_ID, string PROVINCE_TH, string PROVINCE_EN)
        {
            this.PROVINCE_ID = PROVINCE_ID;
            this.PROVINCE_TH = PROVINCE_TH;
            this.PROVINCE_EN = PROVINCE_EN;
        }

        public DataTable GetProvince(string PROVINCE_ID, string PROVINCE_TH, string PROVINCE_EN)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_PROVINCE ";
            if (!string.IsNullOrEmpty(PROVINCE_ID) || !string.IsNullOrEmpty(PROVINCE_TH) || !string.IsNullOrEmpty(PROVINCE_EN))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_TH))
                {
                    query += " and PROVINCE_TH like :PROVINCE_TH ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_EN))
                {
                    query += " and lower(PROVINCE_EN) like lower (:PROVINCE_EN) ";
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

                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_TH))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_TH", "%" + PROVINCE_TH + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_EN))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_EN", "%" + PROVINCE_EN + "%"));
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

        public DataTable GetProvinceSearch(string PROVINCE_ID, string PROVINCE_TH, string PROVINCE_EN)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_PROVINCE ";
            if (!string.IsNullOrEmpty(PROVINCE_ID) || !string.IsNullOrEmpty(PROVINCE_TH) || !string.IsNullOrEmpty(PROVINCE_EN))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_TH))
                {
                    query += " and PROVINCE_TH like :PROVINCE_TH ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_EN))
                {
                    query += " and lower(PROVINCE_EN) like lower (:PROVINCE_EN) ";
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

                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_TH))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_TH", "%" + PROVINCE_TH + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_EN))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_EN", "%" + PROVINCE_EN + "%"));
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

        public int InsertProvince()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_PROVINCE (PROVINCE_ID,PROVINCE_TH,PROVINCE_EN) VALUES (:PROVINCE_ID,:PROVINCE_TH,:PROVINCE_EN)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("PROVINCE_TH", PROVINCE_TH));
                command.Parameters.Add(new OracleParameter("PROVINCE_EN", PROVINCE_EN));
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

        public bool UpdateProvince()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_PROVINCE Set ";
            query += " PROVINCE_ID = :PROVINCE_ID,";
            query += " PROVINCE_TH = :PROVINCE_TH,";
            query += " PROVINCE_EN = :PROVINCE_EN";
            query += " where PROVINCE_ID = :PROVINCE_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("PROVINCE_TH", PROVINCE_TH));
                command.Parameters.Add(new OracleParameter("PROVINCE_EN", PROVINCE_EN));

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

        public bool DeleteProvince()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_PROVINCE where PROVINCE_ID = :PROVINCE_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
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

        public bool CheckUseProvinceID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(PROVINCE_ID) FROM TB_PROVINCE WHERE PROVINCE_ID = :PROVINCE_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
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
    /// <summary>
    /// อำเภอ
    /// </summary>
    public class ClassAmphur
    {
        public int AMPHUR_ID { get; set; }
        public string AMPHUR_TH { get; set; }
        public string AMPHUR_EN { get; set; }
        public int PROVINCE_ID { get; set; }


        public ClassAmphur() { }
        public ClassAmphur(int AMPHUR_ID, string AMPHUR_TH, string AMPHUR_EN, int PROVINCE_ID)
        {
            this.AMPHUR_ID = AMPHUR_ID;
            this.AMPHUR_TH = AMPHUR_TH;
            this.AMPHUR_EN = AMPHUR_EN;
            this.PROVINCE_ID = PROVINCE_ID;
        }

        public DataTable GetAmphur(string AMPHUR_ID, string AMPHUR_TH, string AMPHUR_EN, string PROVINCE_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_AMPHUR ";
            if (!string.IsNullOrEmpty(AMPHUR_ID) || !string.IsNullOrEmpty(AMPHUR_TH) || !string.IsNullOrEmpty(AMPHUR_EN) || !string.IsNullOrEmpty(PROVINCE_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    query += " and AMPHUR_ID like :AMPHUR_ID ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_TH))
                {
                    query += " and AMPHUR_TH like :AMPHUR_TH ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_EN))
                {
                    query += " and lower(AMPHUR_EN) like lower (:AMPHUR_EN) ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
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

                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_TH))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_TH", "%" + AMPHUR_TH + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_EN))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_EN", "%" + AMPHUR_EN + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
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

        public DataTable GetAmphurSearch(string AMPHUR_ID, string AMPHUR_TH, string AMPHUR_EN, string PROVINCE_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_AMPHUR ";
            if (!string.IsNullOrEmpty(AMPHUR_ID) || !string.IsNullOrEmpty(AMPHUR_TH) || !string.IsNullOrEmpty(AMPHUR_EN) || !string.IsNullOrEmpty(PROVINCE_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    query += " and AMPHUR_ID like :AMPHUR_ID ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_TH))
                {
                    query += " and AMPHUR_TH like :AMPHUR_TH ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_EN))
                {
                    query += " and lower(AMPHUR_EN) like lower (:AMPHUR_EN) ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
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

                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_TH))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_TH", "%" + AMPHUR_TH + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_EN))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_EN", "%" + AMPHUR_EN + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
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

        public int InsertAmphur()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_AMPHUR (AMPHUR_ID,AMPHUR_TH,AMPHUR_EN,PROVINCE_ID) VALUES (:AMPHUR_ID,:AMPHUR_TH,:AMPHUR_EN,:PROVINCE_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("AMPHUR_TH", AMPHUR_TH));
                command.Parameters.Add(new OracleParameter("AMPHUR_EN", AMPHUR_EN));
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
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

        public bool UpdateAmphur()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_AMPHUR Set ";
            query += " AMPHUR_ID = :AMPHUR_ID,";
            query += " AMPHUR_TH = :AMPHUR_TH,";
            query += " AMPHUR_EN = :AMPHUR_EN,";
            query += " PROVINCE_ID = :PROVINCE_ID";
            query += " where AMPHUR_ID = :AMPHUR_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("AMPHUR_TH", AMPHUR_TH));
                command.Parameters.Add(new OracleParameter("AMPHUR_EN", AMPHUR_EN));
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));

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

        public bool DeleteAmphur()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_AMPHUR where AMPHUR_ID = :AMPHUR_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
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

        public bool CheckUseAmphurID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(AMPHUR_ID) FROM TB_AMPHUR WHERE AMPHUR_ID = :AMPHUR_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
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
    /// <summary>
    /// ตำบล
    /// </summary>
    public class ClassDistrict
    {
        public int DISTRICT_ID { get; set; }
        public string DISTRICT_TH { get; set; }
        public string DISTRICT_EN { get; set; }
        public int AMPHUR_ID { get; set; }
        public int PROVINCE_ID { get; set; }
        public int POST_CODE { get; set; }
        public string NOTE { get; set; }


        public ClassDistrict() { }
        public ClassDistrict(int DISTRICT_ID, string DISTRICT_TH, string DISTRICT_EN, int AMPHUR_ID, int PROVINCE_ID, int POST_CODE, string NOTE)
        {
            this.DISTRICT_ID = DISTRICT_ID;
            this.DISTRICT_TH = DISTRICT_TH;
            this.DISTRICT_EN = DISTRICT_EN;
            this.AMPHUR_ID = AMPHUR_ID;
            this.PROVINCE_ID = PROVINCE_ID;
            this.POST_CODE = POST_CODE;
            this.NOTE = NOTE;
        }

        public DataTable GetDistrict(string DISTRICT_ID, string DISTRICT_TH, string DISTRICT_EN, string AMPHUR_ID, string PROVINCE_ID, string POST_CODE, string NOTE)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DISTRICT ";
            if (!string.IsNullOrEmpty(DISTRICT_ID) || !string.IsNullOrEmpty(DISTRICT_TH) || !string.IsNullOrEmpty(DISTRICT_EN) || !string.IsNullOrEmpty(AMPHUR_ID) || !string.IsNullOrEmpty(PROVINCE_ID) || !string.IsNullOrEmpty(POST_CODE) || !string.IsNullOrEmpty(NOTE))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DISTRICT_ID))
                {
                    query += " and DISTRICT_ID like :DISTRICT_ID ";
                }
                if (!string.IsNullOrEmpty(DISTRICT_TH))
                {
                    query += " and DISTRICT_TH like :DISTRICT_TH ";
                }
                if (!string.IsNullOrEmpty(DISTRICT_EN))
                {
                    query += " and lower(DISTRICT_EN) like lower (:DISTRICT_EN) ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    query += " and AMPHUR_ID like :AMPHUR_ID ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
                }
                if (!string.IsNullOrEmpty(POST_CODE))
                {
                    query += " and POST_CODE like :POST_CODE ";
                }
                if (!string.IsNullOrEmpty(NOTE))
                {
                    query += " and NOTE like :NOTE ";
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

                if (!string.IsNullOrEmpty(DISTRICT_ID))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DISTRICT_TH))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_TH", "%" + DISTRICT_TH + "%"));
                }
                if (!string.IsNullOrEmpty(DISTRICT_EN))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_EN", "%" + DISTRICT_EN + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(POST_CODE))
                {
                    command.Parameters.Add(new OracleParameter("POST_CODE", POST_CODE + "%"));
                }
                if (!string.IsNullOrEmpty(NOTE))
                {
                    command.Parameters.Add(new OracleParameter("NOTE", "%" + NOTE + "%"));
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

        public DataTable GetDistrictSearch(string DISTRICT_ID, string DISTRICT_TH, string DISTRICT_EN, string AMPHUR_ID, string PROVINCE_ID, string POST_CODE, string NOTE)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DISTRICT ";
            if (!string.IsNullOrEmpty(DISTRICT_ID) || !string.IsNullOrEmpty(DISTRICT_TH) || !string.IsNullOrEmpty(DISTRICT_EN) || !string.IsNullOrEmpty(AMPHUR_ID) || !string.IsNullOrEmpty(PROVINCE_ID) || !string.IsNullOrEmpty(POST_CODE) || !string.IsNullOrEmpty(NOTE))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DISTRICT_ID))
                {
                    query += " and DISTRICT_ID like :DISTRICT_ID ";
                }
                if (!string.IsNullOrEmpty(DISTRICT_TH))
                {
                    query += " and DISTRICT_TH like :DISTRICT_TH ";
                }
                if (!string.IsNullOrEmpty(DISTRICT_EN))
                {
                    query += " and lower(DISTRICT_EN) like lower (:DISTRICT_EN) ";
                }
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    query += " and AMPHUR_ID like :AMPHUR_ID ";
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    query += " and PROVINCE_ID like :PROVINCE_ID ";
                }
                if (!string.IsNullOrEmpty(POST_CODE))
                {
                    query += " and POST_CODE like :POST_CODE ";
                }
                if (!string.IsNullOrEmpty(NOTE))
                {
                    query += " and NOTE like :NOTE ";
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

                if (!string.IsNullOrEmpty(DISTRICT_ID))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DISTRICT_TH))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_TH", "%" + DISTRICT_TH + "%"));
                }
                if (!string.IsNullOrEmpty(DISTRICT_EN))
                {
                    command.Parameters.Add(new OracleParameter("DISTRICT_EN", "%" + DISTRICT_EN + "%"));
                }
                if (!string.IsNullOrEmpty(AMPHUR_ID))
                {
                    command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID + "%"));
                }
                if (!string.IsNullOrEmpty(PROVINCE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(POST_CODE))
                {
                    command.Parameters.Add(new OracleParameter("POST_CODE", POST_CODE + "%"));
                }
                if (!string.IsNullOrEmpty(NOTE))
                {
                    command.Parameters.Add(new OracleParameter("NOTE", "%" + NOTE + "%"));
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

        public int InsertDistrict()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_DISTRICT (DISTRICT_ID,DISTRICT_TH,DISTRICT_EN,AMPHUR_ID,PROVINCE_ID,POST_CODE,NOTE) VALUES (:DISTRICT_ID,:DISTRICT_TH,:DISTRICT_EN,:AMPHUR_ID,:PROVINCE_ID,:POST_CODE,:NOTE)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                command.Parameters.Add(new OracleParameter("DISTRICT_TH", DISTRICT_TH));
                command.Parameters.Add(new OracleParameter("DISTRICT_EN", DISTRICT_EN));
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("POST_CODE", POST_CODE));
                command.Parameters.Add(new OracleParameter("NOTE", NOTE));
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

        public bool UpdateDistrict()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_DISTRICT Set ";
            query += " DISTRICT_ID = :DISTRICT_ID,";
            query += " DISTRICT_TH = :DISTRICT_TH,";
            query += " DISTRICT_EN = :DISTRICT_EN,";
            query += " AMPHUR_ID = :AMPHUR_ID,";
            query += " PROVINCE_ID = :PROVINCE_ID,";
            query += " POST_CODE = :POST_CODE,";
            query += " NOTE = :NOTE";
            query += " where DISTRICT_ID = :DISTRICT_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                command.Parameters.Add(new OracleParameter("DISTRICT_TH", DISTRICT_TH));
                command.Parameters.Add(new OracleParameter("DISTRICT_EN", DISTRICT_EN));
                command.Parameters.Add(new OracleParameter("AMPHUR_ID", AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("POST_CODE", POST_CODE));
                command.Parameters.Add(new OracleParameter("NOTE", NOTE));

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

        public bool DeleteDistrict()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_DISTRICT where DISTRICT_ID = :DISTRICT_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
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

        public bool CheckUseDistrictID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(DISTRICT_ID) FROM TB_DISTRICT WHERE DISTRICT_ID = :DISTRICT_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
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
    /// <summary>
    /// ประเทศ
    /// </summary>
    public class ClassGradCountry
    {
        public int GRAD_COUNTRY_ID { get; set; }
        public string GRAD_ISO2 { get; set; }
        public string GRAD_SHORT_NAME { get; set; }
        public string GRAD_LONG_NAME { get; set; }


        public ClassGradCountry() { }
        public ClassGradCountry(int GRAD_COUNTRY_ID, string GRAD_ISO2, string GRAD_SHORT_NAME, string GRAD_LONG_NAME)
        {
            this.GRAD_COUNTRY_ID = GRAD_COUNTRY_ID;
            this.GRAD_ISO2 = GRAD_ISO2;
            this.GRAD_SHORT_NAME = GRAD_SHORT_NAME;
            this.GRAD_LONG_NAME = GRAD_LONG_NAME;
        }

        public DataTable GetGradCountry(string GRAD_ISO2, string GRAD_SHORT_NAME, string GRAD_LONG_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_COUNTRY ";
            if (!string.IsNullOrEmpty(GRAD_ISO2) || !string.IsNullOrEmpty(GRAD_SHORT_NAME) || !string.IsNullOrEmpty(GRAD_LONG_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_ISO2))
                {
                    query += " and lower(GRAD_ISO2) like lower (:GRAD_ISO2) ";
                }
                if (!string.IsNullOrEmpty(GRAD_SHORT_NAME))
                {
                    query += " and lower(GRAD_SHORT_NAME) like lower (:GRAD_SHORT_NAME) ";
                }
                if (!string.IsNullOrEmpty(GRAD_LONG_NAME))
                {
                    query += " and lower(GRAD_LONG_NAME) like lower (:GRAD_LONG_NAME) ";
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

                if (!string.IsNullOrEmpty(GRAD_ISO2))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISO2", GRAD_ISO2 + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_SHORT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_SHORT_NAME", "%" + GRAD_SHORT_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_LONG_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LONG_NAME", "%" + GRAD_LONG_NAME + "%"));
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

        public DataTable GetGradCountrySearch(string GRAD_ISO2, string GRAD_SHORT_NAME, string GRAD_LONG_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_COUNTRY ";
            if (!string.IsNullOrEmpty(GRAD_ISO2) || !string.IsNullOrEmpty(GRAD_SHORT_NAME) || !string.IsNullOrEmpty(GRAD_LONG_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_ISO2))
                {
                    query += " and lower(GRAD_ISO2) like lower (:GRAD_ISO2) ";
                }
                if (!string.IsNullOrEmpty(GRAD_SHORT_NAME))
                {
                    query += " and lower(GRAD_SHORT_NAME) like lower (:GRAD_SHORT_NAME) ";
                }
                if (!string.IsNullOrEmpty(GRAD_LONG_NAME))
                {
                    query += " and lower(GRAD_LONG_NAME) like lower (:GRAD_LONG_NAME) ";
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

                if (!string.IsNullOrEmpty(GRAD_ISO2))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISO2", GRAD_ISO2 + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_SHORT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_SHORT_NAME", "%" + GRAD_SHORT_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_LONG_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LONG_NAME", "%" + GRAD_LONG_NAME + "%"));
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

        public int InsertGradCountry()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_GRAD_COUNTRY (GRAD_ISO2,GRAD_SHORT_NAME,GRAD_LONG_NAME) VALUES (:GRAD_ISO2,:GRAD_SHORT_NAME,:GRAD_LONG_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_ISO2", GRAD_ISO2));
                command.Parameters.Add(new OracleParameter("GRAD_SHORT_NAME", GRAD_SHORT_NAME));
                command.Parameters.Add(new OracleParameter("GRAD_LONG_NAME", GRAD_LONG_NAME));
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

        public bool UpdateGradCountry()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_GRAD_COUNTRY Set ";
            query += " GRAD_ISO2 = :GRAD_ISO2,";
            query += " GRAD_SHORT_NAME = :GRAD_SHORT_NAME,";
            query += " GRAD_LONG_NAME = :GRAD_LONG_NAME";
            query += " where GRAD_COUNTRY_ID = :GRAD_COUNTRY_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_ISO2", GRAD_ISO2));
                command.Parameters.Add(new OracleParameter("GRAD_SHORT_NAME", GRAD_SHORT_NAME));
                command.Parameters.Add(new OracleParameter("GRAD_LONG_NAME", GRAD_LONG_NAME));
                command.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", GRAD_COUNTRY_ID));
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

        public bool DeleteGradCountry()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_GRAD_COUNTRY where GRAD_COUNTRY_ID = :GRAD_COUNTRY_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", GRAD_COUNTRY_ID));
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

        public bool CheckUseGradCountryID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(GRAD_ISO2) FROM TB_GRAD_COUNTRY WHERE GRAD_ISO2 = :GRAD_ISO2 ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("GRAD_ISO2", GRAD_ISO2));
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
    /// <summary>
    /// ระดับการศึกษา
    /// </summary>
    public class ClassGradLev
    {
        public string GRAD_LEV_ID { get; set; }
        public string GRAD_LEV_NAME { get; set; }

        public ClassGradLev() { }
        public ClassGradLev(string GRAD_LEV_ID, string GRAD_LEV_NAME)
        {
            this.GRAD_LEV_ID = GRAD_LEV_ID;
            this.GRAD_LEV_NAME = GRAD_LEV_NAME;
        }

        public DataTable GetGradLev(string GRAD_LEV_ID, string GRAD_LEV_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_LEV ";
            if (!string.IsNullOrEmpty(GRAD_LEV_ID) || !string.IsNullOrEmpty(GRAD_LEV_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_LEV_ID))
                {
                    query += " and GRAD_LEV_ID like :GRAD_LEV_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_LEV_NAME))
                {
                    query += " and GRAD_LEV_NAME like :GRAD_LEV_NAME ";
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
                if (!string.IsNullOrEmpty(GRAD_LEV_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_LEV_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LEV_NAME", "%" + GRAD_LEV_NAME + "%"));
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

        public DataTable GetGradLevSearch(string GRAD_LEV_ID, string GRAD_LEV_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_LEV ";
            if (!string.IsNullOrEmpty(GRAD_LEV_ID) || !string.IsNullOrEmpty(GRAD_LEV_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_LEV_ID))
                {
                    query += " and GRAD_LEV_ID like :GRAD_LEV_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_LEV_NAME))
                {
                    query += " and GRAD_LEV_NAME like :GRAD_LEV_NAME ";
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
                if (!string.IsNullOrEmpty(GRAD_LEV_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_LEV_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_LEV_NAME", "%" + GRAD_LEV_NAME + "%"));
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

        public int InsertGradLev()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_GRAD_LEV (GRAD_LEV_ID,GRAD_LEV_NAME) VALUES (:GRAD_LEV_ID,:GRAD_LEV_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
                command.Parameters.Add(new OracleParameter("GRAD_LEV_NAME", GRAD_LEV_NAME));
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

        public bool UpdateGradLev()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_GRAD_LEV Set ";
            query += " GRAD_LEV_ID = :GRAD_LEV_ID,";
            query += " GRAD_LEV_NAME = :GRAD_LEV_NAME";
            query += " where GRAD_LEV_ID = :GRAD_LEV_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
                command.Parameters.Add(new OracleParameter("GRAD_LEV_NAME", GRAD_LEV_NAME));

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

        public bool DeleteGradLev()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_GRAD_LEV where GRAD_LEV_ID = :GRAD_LEV_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
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

        public bool CheckUseGradLevID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(GRAD_LEV_ID) FROM TB_GRAD_LEV WHERE GRAD_LEV_ID = :GRAD_LEV_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
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
    /// <summary>
    /// เดือน
    /// </summary>
    public class ClassMonth
    {
        public int MONTH_ID { get; set; }
        public string MONTH_SHORT { get; set; }
        public string MONTH_LONG { get; set; }

        public ClassMonth() { }
        public ClassMonth(int MONTH_ID, string MONTH_SHORT, string MONTH_LONG)
        {
            this.MONTH_ID = MONTH_ID;
            this.MONTH_SHORT = MONTH_SHORT;
            this.MONTH_LONG = MONTH_LONG;
        }

        public DataTable GetMonth(string MONTH_SHORT, string MONTH_LONG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_MONTH ";
            if (!string.IsNullOrEmpty(MONTH_SHORT) || !string.IsNullOrEmpty(MONTH_LONG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(MONTH_SHORT))
                {
                    query += " and MONTH_SHORT like :MONTH_SHORT ";
                }
                if (!string.IsNullOrEmpty(MONTH_LONG))
                {
                    query += " and MONTH_LONG like :MONTH_LONG ";
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

                if (!string.IsNullOrEmpty(MONTH_SHORT))
                {
                    command.Parameters.Add(new OracleParameter("MONTH_SHORT", "%" + MONTH_SHORT + "%"));
                }
                if (!string.IsNullOrEmpty(MONTH_LONG))
                {
                    command.Parameters.Add(new OracleParameter("MONTH_LONG", "%" + MONTH_LONG + "%"));
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

        public DataTable GetMonthSearch(string MONTH_SHORT, string MONTH_LONG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_MONTH ";
            if (!string.IsNullOrEmpty(MONTH_SHORT) || !string.IsNullOrEmpty(MONTH_LONG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(MONTH_SHORT))
                {
                    query += " and MONTH_SHORT like :MONTH_SHORT ";
                }
                if (!string.IsNullOrEmpty(MONTH_LONG))
                {
                    query += " and MONTH_LONG like :MONTH_LONG ";
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

                if (!string.IsNullOrEmpty(MONTH_SHORT))
                {
                    command.Parameters.Add(new OracleParameter("MONTH_SHORT", "%" + MONTH_SHORT + "%"));
                }
                if (!string.IsNullOrEmpty(MONTH_LONG))
                {
                    command.Parameters.Add(new OracleParameter("MONTH_LONG", "%" + MONTH_LONG + "%"));
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

        public int InsertMonth()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_MONTH (MONTH_SHORT,MONTH_LONG) VALUES (:MONTH_SHORT,:MONTH_LONG)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("MONTH_SHORT", MONTH_SHORT));
                command.Parameters.Add(new OracleParameter("MONTH_LONG", MONTH_LONG));
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

        public bool UpdateMonth()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_MONTH Set ";
            query += " MONTH_SHORT = :MONTH_SHORT,";
            query += " MONTH_LONG = :MONTH_LONG";
            query += " where MONTH_ID = :MONTH_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("MONTH_SHORT", MONTH_SHORT));
                command.Parameters.Add(new OracleParameter("MONTH_LONG", MONTH_LONG));
                command.Parameters.Add(new OracleParameter("MONTH_ID", MONTH_ID));

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

        public bool DeleteMonth()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_MONTH where MONTH_ID = :MONTH_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("MONTH_ID", MONTH_ID));
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
    /// <summary>
    /// ปี
    /// </summary>
    public class ClassYear
    {
        public int YEAR_ID { get; set; }

        public ClassYear() { }
        public ClassYear(int YEAR_ID)
        {
            this.YEAR_ID = YEAR_ID;
        }

        public DataTable GetYear(string YEAR_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DATE_YEAR ";
            if (!string.IsNullOrEmpty(YEAR_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(YEAR_ID))
                {
                    query += " and YEAR_ID YEAR_ID :YEAR_ID ";
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

                if (!string.IsNullOrEmpty(YEAR_ID))
                {
                    command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID + "%"));
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

        public DataTable GetYearSearch(string YEAR_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DATE_YEAR";
            if (!string.IsNullOrEmpty(YEAR_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(YEAR_ID))
                {
                    query += " and YEAR_ID like :YEAR_ID ";
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

                if (!string.IsNullOrEmpty(YEAR_ID))
                {
                    command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID + "%"));
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

        public int InsertYear()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_DATE_YEAR (YEAR_ID) VALUES (:YEAR_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID));
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

        public bool UpdateYear()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_DATE_YEAR Set ";
            query += " YEAR_ID = :YEAR_ID";
            query += " where YEAR_ID = :YEAR_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID));

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

        public bool DeleteYear()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_DATE_YEAR where YEAR_ID = :YEAR_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID));
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

        public bool CheckUseYearName()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(YEAR_ID) FROM TB_DATE_YEAR WHERE YEAR_ID = :YEAR_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("YEAR_ID", YEAR_ID));
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
    /// <summary>
    /// วิทยาเขต
    /// </summary>
    public class ClassCampus
    {

        public int CAMPUS_ID { get; set; }
        public string CAMPUS_NAME { get; set; }

        public ClassCampus() { }
        public ClassCampus(int CAMPUS_ID, string CAMPUS_NAME)
        {
            this.CAMPUS_ID = CAMPUS_ID;
            this.CAMPUS_NAME = CAMPUS_NAME;
        }

        public DataTable GetCampus(string CAMPUS_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_CAMPUS ";
            if (!string.IsNullOrEmpty(CAMPUS_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(CAMPUS_NAME))
                {
                    query += " and CAMPUS_NAME like :CAMPUS_NAME ";
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

                if (!string.IsNullOrEmpty(CAMPUS_NAME))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_NAME", "%" + CAMPUS_NAME + "%"));
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

        public DataTable GetCampusSearch(string CAMPUS_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_CAMPUS ";
            if (!string.IsNullOrEmpty(CAMPUS_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(CAMPUS_NAME))
                {
                    query += " and CAMPUS_NAME like :CAMPUS_NAME ";
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

                if (!string.IsNullOrEmpty(CAMPUS_NAME))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_NAME", "%" + CAMPUS_NAME + "%"));
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

        public int InsertCampus()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_CAMPUS (CAMPUS_NAME) VALUES (:CAMPUS_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("CAMPUS_NAME", CAMPUS_NAME));
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

        public bool UpdateCampus()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_CAMPUS Set ";
            query += " CAMPUS_NAME = :CAMPUS_NAME";
            query += " where CAMPUS_ID = :CAMPUS_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("CAMPUS_NAME", CAMPUS_NAME));

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

        public bool DeleteCampus()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_CAMPUS where CAMPUS_ID = :CAMPUS_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
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
    /// <summary>
    /// สำนัก / สถาบัน / คณะ
    /// </summary>
    public class ClassFaculty
    {
        public int FACULTY_ID { get; set; }
        public string FACULTY_NAME { get; set; }
        public int CAMPUS_ID { get; set; }


        public ClassFaculty() { }
        public ClassFaculty(int FACULTY_ID, string FACULTY_NAME, int CAMPUS_ID)
        {
            this.FACULTY_ID = FACULTY_ID;
            this.FACULTY_NAME = FACULTY_NAME;
            this.CAMPUS_ID = CAMPUS_ID;
        }

        public DataTable GetFaculty(string FACULTY_ID, string FACULTY_NAME, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_FACULTY ";
            if (!string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(FACULTY_NAME) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(FACULTY_NAME))
                {
                    query += " and FACULTY_NAME like :FACULTY_NAME ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", "%" + FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_NAME))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_NAME", "%" + FACULTY_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID + "%"));
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

        public DataTable GetFacultySearch(string FACULTY_ID, string FACULTY_NAME, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_FACULTY ";
            if (!string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(FACULTY_NAME) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(FACULTY_NAME))
                {
                    query += " and FACULTY_NAME like :FACULTY_NAME ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", "%" + FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_NAME))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_NAME", "%" + FACULTY_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID + "%"));
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

        public int InsertFaculty()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_FACULTY (FACULTY_ID,FACULTY_NAME,CAMPUS_ID) VALUES (:FACULTY_ID,:FACULTY_NAME,:CAMPUS_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_NAME", FACULTY_NAME));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
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

        public bool UpdateFaculty()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_FACULTY Set ";
            query += " FACULTY_ID = :FACULTY_ID,";
            query += " FACULTY_NAME = :FACULTY_NAME,";
            query += " CAMPUS_ID = :CAMPUS_ID";
            query += " where FACULTY_ID = :FACULTY_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_NAME", FACULTY_NAME));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
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

        public bool DeleteFaculty()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_FACULTY where FACULTY_ID = :FACULTY_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
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
    /// <summary>
    /// กอง / สำนักงานเลขา / ภาควิชา
    /// </summary>
    public class ClassDivision
    {
        public int DIVISION_ID { get; set; }
        public string DIVISION_NAME { get; set; }
        public int FACULTY_ID { get; set; }
        public int CAMPUS_ID { get; set; }


        public ClassDivision() { }
        public ClassDivision(int DIVISION_ID, string DIVISION_NAME, int FACULTY_ID, int CAMPUS_ID)
        {
            this.DIVISION_ID = DIVISION_ID;
            this.DIVISION_NAME = DIVISION_NAME;
            this.FACULTY_ID = FACULTY_ID;
            this.CAMPUS_ID = CAMPUS_ID;
        }

        public DataTable GetDivision(string DIVISION_ID, string DIVISION_NAME, string FACULTY_ID, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DIVISION ";
            if (!string.IsNullOrEmpty(DIVISION_ID) || !string.IsNullOrEmpty(DIVISION_NAME) || !string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    query += " and DIVISION_ID like :DIVISION_ID ";
                }
                if (!string.IsNullOrEmpty(DIVISION_NAME))
                {
                    query += " and DIVISION_NAME like :DIVISION_NAME ";
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DIVISION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_NAME", "%" + DIVISION_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", "%" + FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", "%" + CAMPUS_ID + "%"));
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

        public DataTable GetDivisionSearch(string DIVISION_ID, string DIVISION_NAME, string FACULTY_ID, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DIVISION ";
            if (!string.IsNullOrEmpty(DIVISION_ID) || !string.IsNullOrEmpty(DIVISION_NAME) || !string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    query += " and DIVISION_ID like :DIVISION_ID ";
                }
                if (!string.IsNullOrEmpty(DIVISION_NAME))
                {
                    query += " and DIVISION_NAME like :DIVISION_NAME ";
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DIVISION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_NAME", "%" + DIVISION_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", "%" + FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", "%" + CAMPUS_ID + "%"));
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

        public int InsertDivision()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_DIVISION (DIVISION_ID,DIVISION_NAME,FACULTY_ID,CAMPUS_ID) VALUES (:DIVISION_ID,:DIVISION_NAME,:FACULTY_ID,:CAMPUS_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
                command.Parameters.Add(new OracleParameter("DIVISION_NAME", DIVISION_NAME));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
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

        public bool UpdateDivision()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_DIVISION Set ";
            query += " DIVISION_NAME = :DIVISION_NAME,";
            query += " FACULTY_ID = :FACULTY_ID,";
            query += " CAMPUS_ID = :CAMPUS_ID";
            query += " where DIVISION_ID = :DIVISION_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DIVISION_NAME", DIVISION_NAME));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
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

        public bool DeleteDivision()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_DIVISION where DIVISION_ID = :DIVISION_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
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

        public bool CheckUseDivisionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(DIVISION_ID) FROM TB_DIVISION WHERE DIVISION_ID = :DIVISION_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
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
    /// <summary>
    /// งาน / ฝ่าย
    /// </summary>
    public class ClassWorkDivision
    {
        public int WORK_ID { get; set; }
        public string WORK_NAME { get; set; }
        public int DIVISION_ID { get; set; }
        public int FACULTY_ID { get; set; }
        public int CAMPUS_ID { get; set; }


        public ClassWorkDivision() { }
        public ClassWorkDivision(int WORK_ID, string WORK_NAME, int DIVISION_ID, int FACULTY_ID, int CAMPUS_ID)
        {
            this.WORK_ID = WORK_ID;
            this.WORK_NAME = WORK_NAME;
            this.DIVISION_ID = DIVISION_ID;
            this.FACULTY_ID = FACULTY_ID;
            this.CAMPUS_ID = CAMPUS_ID;
        }

        public DataTable GetWorkDivision(string WORK_ID, string WORK_NAME, string DIVISION_ID, string FACULTY_ID, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_WORK_DIVISION ";
            if (!string.IsNullOrEmpty(WORK_ID) || !string.IsNullOrEmpty(WORK_NAME) || !string.IsNullOrEmpty(DIVISION_ID) || !string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(WORK_ID))
                {
                    query += " and WORK_ID like :WORK_ID ";
                }
                if (!string.IsNullOrEmpty(WORK_NAME))
                {
                    query += " and WORK_NAME like :WORK_NAME ";
                }
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    query += " and DIVISION_ID like :DIVISION_ID ";
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(WORK_ID))
                {
                    command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID + "%"));
                }
                if (!string.IsNullOrEmpty(WORK_NAME))
                {
                    command.Parameters.Add(new OracleParameter("WORK_NAME", "%" + WORK_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID + "%"));
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

        public DataTable GetWorkDivisionSearch(string WORK_ID, string WORK_NAME, string DIVISION_ID, string FACULTY_ID, string CAMPUS_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_WORK_DIVISION ";
            if (!string.IsNullOrEmpty(WORK_ID) || !string.IsNullOrEmpty(WORK_NAME) || !string.IsNullOrEmpty(DIVISION_ID) || !string.IsNullOrEmpty(FACULTY_ID) || !string.IsNullOrEmpty(CAMPUS_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(WORK_ID))
                {
                    query += " and WORK_ID like :WORK_ID ";
                }
                if (!string.IsNullOrEmpty(WORK_NAME))
                {
                    query += " and WORK_NAME like :WORK_NAME ";
                }
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    query += " and DIVISION_ID like :DIVISION_ID ";
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    query += " and FACULTY_ID like :FACULTY_ID ";
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    query += " and CAMPUS_ID like :CAMPUS_ID ";
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
                if (!string.IsNullOrEmpty(WORK_ID))
                {
                    command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID + "%"));
                }
                if (!string.IsNullOrEmpty(WORK_NAME))
                {
                    command.Parameters.Add(new OracleParameter("WORK_NAME", "%" + WORK_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(DIVISION_ID))
                {
                    command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(FACULTY_ID))
                {
                    command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID + "%"));
                }
                if (!string.IsNullOrEmpty(CAMPUS_ID))
                {
                    command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID + "%"));
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

        public int InsertWorkDivision()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_WORK_DIVISION (WORK_ID,WORK_NAME,DIVISION_ID,FACULTY_ID,CAMPUS_ID) VALUES (:WORK_ID,:WORK_NAME,:DIVISION_ID,:FACULTY_ID,:CAMPUS_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID));
                command.Parameters.Add(new OracleParameter("WORK_NAME", WORK_NAME));
                command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
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

        public bool UpdateWorkDivision()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_WORK_DIVISION Set ";
            query += " WORK_NAME = :WORK_NAME,";
            query += " DIVISION_ID = :DIVISION_ID,";
            query += " FACULTY_ID = :FACULTY_ID,";
            query += " CAMPUS_ID = :CAMPUS_ID";
            query += " where WORK_ID = :WORK_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("WORK_NAME", WORK_NAME));
                command.Parameters.Add(new OracleParameter("DIVISION_ID", DIVISION_ID));
                command.Parameters.Add(new OracleParameter("FACULTY_ID", FACULTY_ID));
                command.Parameters.Add(new OracleParameter("CAMPUS_ID", CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID));
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

        public bool DeleteWorkDivision()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_WORK_DIVISION where WORK_ID = :WORK_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID));
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

        public bool CheckUseWorkDivisionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(WORK_ID) FROM TB_WORK_DIVISION WHERE WORK_ID = :WORK_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("WORK_ID", WORK_ID));
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
    /// <summary>
    /// ประเภทบุคลากร
    /// </summary>
    public class ClassStaffType
    {
        public int STAFFTYPE_ID { get; set; }
        public string STAFFTYPE_NAME { get; set; }

        public ClassStaffType() { }
        public ClassStaffType(int STAFFTYPE_ID, string STAFFTYPE_NAME)
        {
            this.STAFFTYPE_ID = STAFFTYPE_ID;
            this.STAFFTYPE_NAME = STAFFTYPE_NAME;
        }

        public DataTable GetStaffType(string STAFFTYPE_ID, string STAFFTYPE_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STAFFTYPE ";
            if (!string.IsNullOrEmpty(STAFFTYPE_ID) || !string.IsNullOrEmpty(STAFFTYPE_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STAFFTYPE_ID))
                {
                    query += " and STAFFTYPE_ID like :STAFFTYPE_ID ";
                }
                if (!string.IsNullOrEmpty(STAFFTYPE_NAME))
                {
                    query += " and STAFFTYPE_NAME like :STAFFTYPE_NAME ";
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
                if (!string.IsNullOrEmpty(STAFFTYPE_ID))
                {
                    command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(STAFFTYPE_NAME))
                {
                    command.Parameters.Add(new OracleParameter("STAFFTYPE_NAME", "%" + STAFFTYPE_NAME + "%"));
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

        public DataTable GetStaffTypeSearch(string STAFFTYPE_ID, string STAFFTYPE_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STAFFTYPE ";
            if (!string.IsNullOrEmpty(STAFFTYPE_ID) || !string.IsNullOrEmpty(STAFFTYPE_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STAFFTYPE_ID))
                {
                    query += " and STAFFTYPE_ID like :STAFFTYPE_ID ";
                }
                if (!string.IsNullOrEmpty(STAFFTYPE_NAME))
                {
                    query += " and STAFFTYPE_NAME like :STAFFTYPE_NAME ";
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
                if (!string.IsNullOrEmpty(STAFFTYPE_ID))
                {
                    command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(STAFFTYPE_NAME))
                {
                    command.Parameters.Add(new OracleParameter("STAFFTYPE_NAME", "%" + STAFFTYPE_NAME + "%"));
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

        public int InsertStaffType()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_STAFFTYPE (STAFFTYPE_ID,STAFFTYPE_NAME) VALUES (:STAFFTYPE_ID,:STAFFTYPE_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("STAFFTYPE_NAME", STAFFTYPE_NAME));
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

        public bool UpdateStaffType()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_STAFFTYPE Set ";
            query += " STAFFTYPE_ID = :STAFFTYPE_ID,";
            query += " STAFFTYPE_NAME = :STAFFTYPE_NAME";
            query += " where STAFFTYPE_ID = :STAFFTYPE_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("STAFFTYPE_NAME", STAFFTYPE_NAME));

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

        public bool DeleteStaffType()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_STAFFTYPE where STAFFTYPE_ID = :STAFFTYPE_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
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

        public bool CheckUseStaffTypeID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(STAFFTYPE_ID) FROM TB_STAFFTYPE WHERE STAFFTYPE_ID = :STAFFTYPE_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
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
    /// <summary>
    /// ประเภทเงินจ้าง
    /// </summary>
    public class ClassBudget
    {
        public int BUDGET_ID { get; set; }
        public string BUDGET_NAME { get; set; }

        public ClassBudget() { }
        public ClassBudget(int BUDGET_ID, string BUDGET_NAME)
        {
            this.BUDGET_ID = BUDGET_ID;
            this.BUDGET_NAME = BUDGET_NAME;
        }

        public DataTable GetBudget(string BUDGET_ID, string BUDGET_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BUDGET ";
            if (!string.IsNullOrEmpty(BUDGET_ID) || !string.IsNullOrEmpty(BUDGET_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BUDGET_ID))
                {
                    query += " and BUDGET_ID like :BUDGET_ID ";
                }
                if (!string.IsNullOrEmpty(BUDGET_NAME))
                {
                    query += " and BUDGET_NAME like :BUDGET_NAME ";
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
                if (!string.IsNullOrEmpty(BUDGET_ID))
                {
                    command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BUDGET_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BUDGET_NAME", "%" + BUDGET_NAME + "%"));
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

        public DataTable GetBudgetSearch(string BUDGET_ID, string BUDGET_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BUDGET";
            if (!string.IsNullOrEmpty(BUDGET_ID) || !string.IsNullOrEmpty(BUDGET_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BUDGET_ID))
                {
                    query += " and BUDGET_ID like :BUDGET_ID ";
                }
                if (!string.IsNullOrEmpty(BUDGET_NAME))
                {
                    query += " and BUDGET_NAME like :BUDGET_NAME ";
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
                if (!string.IsNullOrEmpty(BUDGET_ID))
                {
                    command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BUDGET_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BUDGET_NAME", "%" + BUDGET_NAME + "%"));
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

        public int InsertBudget()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_BUDGET (BUDGET_ID,BUDGET_NAME) VALUES (:BUDGET_ID,:BUDGET_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
                command.Parameters.Add(new OracleParameter("BUDGET_NAME", BUDGET_NAME));
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

        public bool UpdateBudget()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_BUDGET Set ";
            query += " BUDGET_ID = :BUDGET_ID,";
            query += " BUDGET_NAME = :BUDGET_NAME";
            query += " where BUDGET_ID = :BUDGET_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
                command.Parameters.Add(new OracleParameter("BUDGET_NAME", BUDGET_NAME));

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

        public bool DeleteBudget()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_BUDGET where BUDGET_ID = :BUDGET_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
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

        public bool CheckUseBudgetID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(BUDGET_ID) FROM TB_BUDGET WHERE BUDGET_ID = :BUDGET_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
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
    /// <summary>
    /// ตำแหน่งบริหาร
    /// </summary>
    public class ClassAdminPosition
    {
        public string ADMIN_POSITION_ID { get; set; }
        public string ADMIN_POSITION_NAME { get; set; }

        public ClassAdminPosition() { }
        public ClassAdminPosition(string ADMIN_POSITION_ID, string ADMIN_POSITION_NAME)
        {
            this.ADMIN_POSITION_ID = ADMIN_POSITION_ID;
            this.ADMIN_POSITION_NAME = ADMIN_POSITION_NAME;
        }

        public DataTable GetAdminPosition(string ADMIN_POSITION_ID, string ADMIN_POSITION_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_ADMIN_POSITION ";
            if (!string.IsNullOrEmpty(ADMIN_POSITION_ID) || !string.IsNullOrEmpty(ADMIN_POSITION_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ADMIN_POSITION_ID))
                {
                    query += " and ADMIN_POSITION_ID like :ADMIN_POSITION_ID ";
                }
                if (!string.IsNullOrEmpty(ADMIN_POSITION_NAME))
                {
                    query += " and ADMIN_POSITION_NAME like :ADMIN_POSITION_NAME ";
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
                if (!string.IsNullOrEmpty(ADMIN_POSITION_ID))
                {
                    command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(ADMIN_POSITION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ADMIN_POSITION_NAME", "%" + ADMIN_POSITION_NAME + "%"));
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

        public DataTable GetAdminPositionSearch(string ADMIN_POSITION_ID, string ADMIN_POSITION_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_ADMIN_POSITION";
            if (!string.IsNullOrEmpty(ADMIN_POSITION_ID) || !string.IsNullOrEmpty(ADMIN_POSITION_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ADMIN_POSITION_ID))
                {
                    query += " and ADMIN_POSITION_ID like :ADMIN_POSITION_ID ";
                }
                if (!string.IsNullOrEmpty(ADMIN_POSITION_NAME))
                {
                    query += " and ADMIN_POSITION_NAME like :ADMIN_POSITION_NAME ";
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
                if (!string.IsNullOrEmpty(ADMIN_POSITION_ID))
                {
                    command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID + "%"));
                }
                if (!string.IsNullOrEmpty(ADMIN_POSITION_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ADMIN_POSITION_NAME", "%" + ADMIN_POSITION_NAME + "%"));
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

        public int InsertAdminPosition()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_ADMIN_POSITION (ADMIN_POSITION_ID,ADMIN_POSITION_NAME) VALUES (:ADMIN_POSITION_ID,:ADMIN_POSITION_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_NAME", ADMIN_POSITION_NAME));
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

        public bool UpdateAdminPosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_ADMIN_POSITION Set ";
            query += " ADMIN_POSITION_ID = :ADMIN_POSITION_ID,";
            query += " ADMIN_POSITION_NAME = :ADMIN_POSITION_NAME";
            query += " where ADMIN_POSITION_ID = :ADMIN_POSITION_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_NAME", ADMIN_POSITION_NAME));

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

        public bool DeleteAdminPosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_ADMIN_POSITION where ADMIN_POSITION_ID = :ADMIN_POSITION_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
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

        public bool CheckUseAdminPositionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ADMIN_POSITION_ID) FROM TB_ADMIN_POSITION WHERE ADMIN_POSITION_ID = :ADMIN_POSITION_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
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
    /// <summary>
    /// ตำแหน่งในสายงาน
    /// </summary>
    public class ClassPositionWork
    {
        public string POSITION_WORK_ID { get; set; }
        public string POSITION_WORK_NAME { get; set; }

        public ClassPositionWork() { }
        public ClassPositionWork(string POSITION_WORK_ID, string POSITION_WORK_NAME)
        {
            this.POSITION_WORK_ID = POSITION_WORK_ID;
            this.POSITION_WORK_NAME = POSITION_WORK_NAME;
        }

        public DataTable GetPositionWork(string POSITION_WORK_ID, string POSITION_WORK_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_WORK ";
            if (!string.IsNullOrEmpty(POSITION_WORK_ID) || !string.IsNullOrEmpty(POSITION_WORK_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(POSITION_WORK_ID))
                {
                    query += " and POSITION_WORK_ID like :POSITION_WORK_ID ";
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    query += " and POSITION_WORK_NAME like :POSITION_WORK_NAME ";
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
                if (!string.IsNullOrEmpty(POSITION_WORK_ID))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID + "%"));
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", "%" + POSITION_WORK_NAME + "%"));
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

        public DataTable GetPositionWorkSearch(string POSITION_WORK_ID, string POSITION_WORK_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_WORK";
            if (!string.IsNullOrEmpty(POSITION_WORK_ID) || !string.IsNullOrEmpty(POSITION_WORK_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(POSITION_WORK_ID))
                {
                    query += " and POSITION_WORK_ID like :POSITION_WORK_ID ";
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    query += " and POSITION_WORK_NAME like :POSITION_WORK_NAME ";
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
                if (!string.IsNullOrEmpty(POSITION_WORK_ID))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID + "%"));
                }
                if (!string.IsNullOrEmpty(POSITION_WORK_NAME))
                {
                    command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", "%" + POSITION_WORK_NAME + "%"));
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

        public int InsertPositionWork()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_POSITION_WORK (POSITION_WORK_ID,POSITION_WORK_NAME) VALUES (:POSITION_WORK_ID,:POSITION_WORK_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID));
                command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", POSITION_WORK_NAME));
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

        public bool UpdatePositionWork()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_POSITION_WORK Set ";
            query += " POSITION_WORK_ID = :POSITION_WORK_ID,";
            query += " POSITION_WORK_NAME = :POSITION_WORK_NAME";
            query += " where POSITION_WORK_ID = :POSITION_WORK_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID));
                command.Parameters.Add(new OracleParameter("POSITION_WORK_NAME", POSITION_WORK_NAME));

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

        public bool DeletePositionWork()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_POSITION_WORK where POSITION_WORK_ID = :POSITION_WORK_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID));
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

        public bool CheckUsePositionWorkID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(POSITION_WORK_ID) FROM TB_POSITION_WORK WHERE POSITION_WORK_ID = :POSITION_WORK_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("POSITION_WORK_ID", POSITION_WORK_ID));
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
    /// <summary>
    /// ตำแหน่งทางวิชาการ
    /// </summary>
    public class ClassAcademicPosition
    {
        public int ACAD_ID { get; set; }
        public string ACAD_NAME { get; set; }
        public string ACAD_NAME_SHORT { get; set; }


        public ClassAcademicPosition() { }
        public ClassAcademicPosition(int ACAD_ID, string ACAD_NAME, string ACAD_NAME_SHORT)
        {
            this.ACAD_ID = ACAD_ID;
            this.ACAD_NAME = ACAD_NAME;
            this.ACAD_NAME_SHORT = ACAD_NAME_SHORT;
        }

        public DataTable GetAcademicPosition(string ACAD_NAME, string ACAD_NAME_SHORT)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_ACADEMIC_POSITION ";
            if (!string.IsNullOrEmpty(ACAD_NAME) || !string.IsNullOrEmpty(ACAD_NAME_SHORT))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ACAD_NAME))
                {
                    query += " and ACAD_NAME like :ACAD_NAME ";
                }
                if (!string.IsNullOrEmpty(ACAD_NAME_SHORT))
                {
                    query += " and ACAD_NAME_SHORT like :ACAD_NAME_SHORT ";
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

                if (!string.IsNullOrEmpty(ACAD_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ACAD_NAME", "%" + ACAD_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ACAD_NAME_SHORT))
                {
                    command.Parameters.Add(new OracleParameter("ACAD_NAME_SHORT", "%" + ACAD_NAME_SHORT + "%"));
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

        public DataTable GetAcademicPositionSearch(string ACAD_NAME, string ACAD_NAME_SHORT)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_ACADEMIC_POSITION ";
            if (!string.IsNullOrEmpty(ACAD_NAME) || !string.IsNullOrEmpty(ACAD_NAME_SHORT))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ACAD_NAME))
                {
                    query += " and ACAD_NAME like :ACAD_NAME ";
                }
                if (!string.IsNullOrEmpty(ACAD_NAME_SHORT))
                {
                    query += " and ACAD_NAME_SHORT like :ACAD_NAME_SHORT ";
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

                if (!string.IsNullOrEmpty(ACAD_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ACAD_NAME", "%" + ACAD_NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ACAD_NAME_SHORT))
                {
                    command.Parameters.Add(new OracleParameter("ACAD_NAME_SHORT", "%" + ACAD_NAME_SHORT + "%"));
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

        public int InsertAcademicPosition()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_ACADEMIC_POSITION (ACAD_NAME,ACAD_NAME_SHORT) VALUES (:ACAD_NAME,:ACAD_NAME_SHORT)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ACAD_NAME", ACAD_NAME));
                command.Parameters.Add(new OracleParameter("ACAD_NAME_SHORT", ACAD_NAME_SHORT));
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

        public bool UpdateAcademicPosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_ACADEMIC_POSITION Set ";
            query += " ACAD_NAME = :ACAD_NAME,";
            query += " ACAD_NAME_SHORT = :ACAD_NAME_SHORT";
            query += " where ACAD_ID = :ACAD_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ACAD_NAME", ACAD_NAME));
                command.Parameters.Add(new OracleParameter("ACAD_NAME_SHORT", ACAD_NAME_SHORT));
                command.Parameters.Add(new OracleParameter("ACAD_ID", ACAD_ID));
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

        public bool DeleteAcademicPosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_ACADEMIC_POSITION where ACAD_ID = :ACAD_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ACAD_ID", ACAD_ID));
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

        public bool CheckUseAcademicPositionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ACAD_ID) FROM TB_ACADEMIC_POSITION WHERE ACAD_ID = :ACAD_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ACAD_ID", ACAD_ID));
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
    /// <summary>
    /// กลุ่มสาขาวิชาที่สอน
    /// </summary>
    public class ClassTeachISCED
    {
        public string TEACH_ISCED_ID { get; set; }
        public int TEACH_ISCED_ID_OLD { get; set; }
        public string TEACH_ISCED_NAME_TH { get; set; }
        public string TEACH_ISCED_NAME_ENG { get; set; }
        public int ID { get; set; }


        public ClassTeachISCED() { }
        public ClassTeachISCED(string TEACH_ISCED_ID, int TEACH_ISCED_ID_OLD, string TEACH_ISCED_NAME_TH, string TEACH_ISCED_NAME_ENG, int ID)
        {
            this.TEACH_ISCED_ID = TEACH_ISCED_ID;
            this.TEACH_ISCED_ID_OLD = TEACH_ISCED_ID_OLD;
            this.TEACH_ISCED_NAME_TH = TEACH_ISCED_NAME_TH;
            this.TEACH_ISCED_NAME_ENG = TEACH_ISCED_NAME_ENG;
            this.ID = ID;
        }

        public DataTable GetTeachISCED(string TEACH_ISCED_ID, string TEACH_ISCED_ID_OLD, string TEACH_ISCED_NAME_TH, string TEACH_ISCED_NAME_ENG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TEACH_ISCED ";
            if (!string.IsNullOrEmpty(TEACH_ISCED_ID) || !string.IsNullOrEmpty(TEACH_ISCED_ID_OLD) || !string.IsNullOrEmpty(TEACH_ISCED_NAME_TH) || !string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID))
                {
                    query += " and TEACH_ISCED_ID like :TEACH_ISCED_ID ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID_OLD))
                {
                    query += " and TEACH_ISCED_ID_OLD like :TEACH_ISCED_ID_OLD ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_TH))
                {
                    query += " and TEACH_ISCED_NAME_TH like :TEACH_ISCED_NAME_TH ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
                {
                    query += " and lower(TEACH_ISCED_NAME_ENG) like lower (:TEACH_ISCED_NAME_ENG) ";
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

                if (!string.IsNullOrEmpty(TEACH_ISCED_ID))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", "%" + TEACH_ISCED_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID_OLD))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID_OLD", "%" + TEACH_ISCED_ID_OLD + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_TH))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_TH", "%" + TEACH_ISCED_NAME_TH + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_ENG", "%" + TEACH_ISCED_NAME_ENG + "%"));
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

        public DataTable GetTeachISCEDSearch(string TEACH_ISCED_ID, string TEACH_ISCED_ID_OLD, string TEACH_ISCED_NAME_TH, string TEACH_ISCED_NAME_ENG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TEACH_ISCED ";
            if (!string.IsNullOrEmpty(TEACH_ISCED_ID) || !string.IsNullOrEmpty(TEACH_ISCED_ID_OLD) || !string.IsNullOrEmpty(TEACH_ISCED_NAME_TH) || !string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID))
                {
                    query += " and TEACH_ISCED_ID like :TEACH_ISCED_ID ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID_OLD))
                {
                    query += " and TEACH_ISCED_ID_OLD like :TEACH_ISCED_ID_OLD ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_TH))
                {
                    query += " and TEACH_ISCED_NAME_TH like :TEACH_ISCED_NAME_TH ";
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
                {
                    query += " and lower(TEACH_ISCED_NAME_ENG) like lower (:TEACH_ISCED_NAME_ENG) ";
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

                if (!string.IsNullOrEmpty(TEACH_ISCED_ID))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", "%" + TEACH_ISCED_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_ID_OLD))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID_OLD", "%" + TEACH_ISCED_ID_OLD + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_TH))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_TH", "%" + TEACH_ISCED_NAME_TH + "%"));
                }
                if (!string.IsNullOrEmpty(TEACH_ISCED_NAME_ENG))
                {
                    command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_ENG", "%" + TEACH_ISCED_NAME_ENG + "%"));
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

        public int InsertTeachISCED()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_TEACH_ISCED (TEACH_ISCED_ID,TEACH_ISCED_ID_OLD,TEACH_ISCED_NAME_TH,TEACH_ISCED_NAME_ENG) VALUES (:TEACH_ISCED_ID,:TEACH_ISCED_ID_OLD,:TEACH_ISCED_NAME_TH,:TEACH_ISCED_NAME_ENG)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID_OLD", TEACH_ISCED_ID_OLD));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_TH", TEACH_ISCED_NAME_TH));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_ENG", TEACH_ISCED_NAME_ENG));
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

        public bool UpdateTeachISCED()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_TEACH_ISCED Set ";
            query += " TEACH_ISCED_ID = :TEACH_ISCED_ID,";
            query += " TEACH_ISCED_ID_OLD = :TEACH_ISCED_ID_OLD,";
            query += " TEACH_ISCED_NAME_TH = :TEACH_ISCED_NAME_TH,";
            query += " TEACH_ISCED_NAME_ENG = :TEACH_ISCED_NAME_ENG";
            query += " where ID = :ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_ID_OLD", TEACH_ISCED_ID_OLD));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_TH", TEACH_ISCED_NAME_TH));
                command.Parameters.Add(new OracleParameter("TEACH_ISCED_NAME_ENG", TEACH_ISCED_NAME_ENG));
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

        public bool DeleteTeachISCED()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_TEACH_ISCED where ID = :ID", conn);
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
    }
    /// <summary>
    /// ตำแหน่งประเภท
    /// </summary>
    public class ClassStaff
    {
        public int ST_ID { get; set; }
        public string ST_NAME { get; set; }

        public ClassStaff() { }
        public ClassStaff(int ST_ID, string ST_NAME)
        {
            this.ST_ID = ST_ID;
            this.ST_NAME = ST_NAME;
        }

        public DataTable GetStaff(string ST_ID, string ST_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STAFF ";
            if (!string.IsNullOrEmpty(ST_ID) || !string.IsNullOrEmpty(ST_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
                }
                if (!string.IsNullOrEmpty(ST_NAME))
                {
                    query += " and ST_NAME like :ST_NAME ";
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
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
                }
                if (!string.IsNullOrEmpty(ST_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ST_NAME", "%" + ST_NAME + "%"));
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

        public DataTable GetStaffSearch(string ST_ID, string ST_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STAFF ";
            if (!string.IsNullOrEmpty(ST_ID) || !string.IsNullOrEmpty(ST_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
                }
                if (!string.IsNullOrEmpty(ST_NAME))
                {
                    query += " and ST_NAME like :ST_NAME ";
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
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
                }
                if (!string.IsNullOrEmpty(ST_NAME))
                {
                    command.Parameters.Add(new OracleParameter("ST_NAME", "%" + ST_NAME + "%"));
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

        public int InsertStaff()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_STAFF (ST_ID,ST_NAME) VALUES (:ST_ID,:ST_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
                command.Parameters.Add(new OracleParameter("ST_NAME", ST_NAME));
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

        public bool UpdateStaff()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_STAFF Set ";
            query += " ST_ID = :ST_ID,";
            query += " ST_NAME = :ST_NAME";
            query += " where ST_ID = :ST_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
                command.Parameters.Add(new OracleParameter("ST_NAME", ST_NAME));

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

        public bool DeleteStaff()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_STAFF where ST_ID = :ST_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool CheckUseStaffID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ST_ID) FROM TB_STAFF WHERE ST_ID = :ST_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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
    /// <summary>
    /// ระดับข้าราชการ
    /// </summary>
    public class ClassPositionGoverment
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string ST_ID { get; set; }

        public ClassPositionGoverment() { }
        public ClassPositionGoverment(int ID, string NAME, string ST_ID)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.ST_ID = ST_ID;
        }

        public DataTable GetPositionGoverment(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_GOVERNMENT_OFFICER ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", "%" + NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
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

        public DataTable GetPositionGovermentSearch(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_GOVERNMENT_OFFICER ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", "%" + NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
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

        public int InsertPositionGoverment()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_POSITION_GOVERNMENT_OFFICER (ID,NAME,ST_ID) VALUES (:ID,:NAME,:ST_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ID", ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool UpdatePositionGoverment()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_POSITION_GOVERNMENT_OFFICER Set ";
            query += " NAME = :NAME,";
            query += " ST_ID = :ST_ID";
            query += " where ID = :ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool DeletePositionGoverment()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_POSITION_GOVERNMENT_OFFICER where ID = :ID", conn);
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
        public bool CheckUsePositionGovermentID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ID) FROM TB_POSITION_GOVERNMENT_OFFICER WHERE ID = :ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ID", ID));
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
    /// <summary>
    /// ลูกจ้างประจำ
    /// </summary>
    public class ClassPositionPermanent
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string ST_ID { get; set; }

        public ClassPositionPermanent() { }
        public ClassPositionPermanent(int ID, string NAME, string ST_ID)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.ST_ID = ST_ID;
        }

        public DataTable GetPositionPermanent(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_GOVERNMENT_OFFICER ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", "%" + NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
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

        public DataTable GetPositionPermanentSearch(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION_GOVERNMENT_OFFICER ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", "%" + NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", ST_ID + "%"));
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

        public int InsertPositionPermanent()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_POSITION_GOVERNMENT_OFFICER (ID,NAME,ST_ID) VALUES (:ID,:NAME,:ST_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ID", ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool UpdatePositionPermanent()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_POSITION_GOVERNMENT_OFFICER Set ";
            query += " NAME = :NAME,";
            query += " ST_ID = :ST_ID";
            query += " where ID = :ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool DeletePositionPermanent()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_POSITION_GOVERNMENT_OFFICER where ID = :ID", conn);
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
        public bool CheckUsePositionPermanentID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ID) FROM TB_POSITION_GOVERNMENT_OFFICER WHERE ID = :ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ID", ID));
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

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ClassBranch
    {
        public int BRANCH_ID { get; set; }
        public string BRANCH_NAME { get; set; }

        public ClassBranch() { }
        public ClassBranch(int BRANCH_ID, string BRANCH_NAME)
        {
            this.BRANCH_ID = BRANCH_ID;
            this.BRANCH_NAME = BRANCH_NAME;
        }

        public DataTable GetBranch(string BRANCH_ID, string BRANCH_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BRANCH ";
            if (!string.IsNullOrEmpty(BRANCH_ID) || !string.IsNullOrEmpty(BRANCH_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BRANCH_ID))
                {
                    query += " and BRANCH_ID like :BRANCH_ID ";
                }
                if (!string.IsNullOrEmpty(BRANCH_NAME))
                {
                    query += " and BRANCH_NAME like :BRANCH_NAME ";
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
                if (!string.IsNullOrEmpty(BRANCH_ID))
                {
                    command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BRANCH_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BRANCH_NAME", "%" + BRANCH_NAME + "%"));
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

        public DataTable GetBranchSearch(string BRANCH_ID, string BRANCH_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_BRANCH ";
            if (!string.IsNullOrEmpty(BRANCH_ID) || !string.IsNullOrEmpty(BRANCH_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(BRANCH_ID))
                {
                    query += " and BRANCH_ID like :BRANCH_ID ";
                }
                if (!string.IsNullOrEmpty(BRANCH_NAME))
                {
                    query += " and BRANCH_NAME like :BRANCH_NAME ";
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
                if (!string.IsNullOrEmpty(BRANCH_ID))
                {
                    command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID + "%"));
                }
                if (!string.IsNullOrEmpty(BRANCH_NAME))
                {
                    command.Parameters.Add(new OracleParameter("BRANCH_NAME", "%" + BRANCH_NAME + "%"));
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

        public int InsertBranch()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_BRANCH(BRANCH_ID,BRANCH_NAME) VALUES (:BRANCH_ID,:BRANCH_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID));
                command.Parameters.Add(new OracleParameter("BRANCH_NAME", BRANCH_NAME));
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

        public bool UpdateBranch()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_BRANCH Set ";
            query += " BRANCH_ID = :BRANCH_ID,";
            query += " BRANCH_NAME = :BRANCH_NAME";
            query += " where BRANCH_ID = :BRANCH_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID));
                command.Parameters.Add(new OracleParameter("BRANCH_NAME", BRANCH_NAME));

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

        public bool DeleteBranch()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_BRANCH where BRANCH_ID = :BRANCH_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID));
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

        public bool CheckUseBranchID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(BRANCH_ID) FROM TB_BRANCH WHERE BRANCH_ID = :BRANCH_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("BRANCH_ID", BRANCH_ID));
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
    //////////////////////////////////////////////////////////////////////////////////////////////
    public class ClassDepartment
    {
        public string DEPARTMENT_ID { get; set; }
        public string DEPARTMENT_NAME { get; set; }

        public ClassDepartment() { }
        public ClassDepartment(string DEPARTMENT_ID, string DEPARTMENT_NAME)
        {
            this.DEPARTMENT_ID = DEPARTMENT_ID;
            this.DEPARTMENT_NAME = DEPARTMENT_NAME;
        }

        public DataTable GetDepartment(string DEPARTMENT_ID, string DEPARTMENT_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DEPARTMENT ";
            if (!string.IsNullOrEmpty(DEPARTMENT_ID) || !string.IsNullOrEmpty(DEPARTMENT_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DEPARTMENT_ID))
                {
                    query += " and DEPARTMENT_ID like :DEPARTMENT_ID ";
                }
                if (!string.IsNullOrEmpty(DEPARTMENT_NAME))
                {
                    query += " and DEPARTMENT_NAME like :DEPARTMENT_NAME ";
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
                if (!string.IsNullOrEmpty(DEPARTMENT_ID))
                {
                    command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DEPARTMENT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("DEPARTMENT_NAME", "%" + DEPARTMENT_NAME + "%"));
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

        public DataTable GetDepartmentSearch(string DEPARTMENT_ID, string DEPARTMENT_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_DEPARTMENT";
            if (!string.IsNullOrEmpty(DEPARTMENT_ID) || !string.IsNullOrEmpty(DEPARTMENT_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(DEPARTMENT_ID))
                {
                    query += " and DEPARTMENT_ID like :DEPARTMENT_ID ";
                }
                if (!string.IsNullOrEmpty(DEPARTMENT_NAME))
                {
                    query += " and DEPARTMENT_NAME like :DEPARTMENT_NAME ";
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
                if (!string.IsNullOrEmpty(DEPARTMENT_ID))
                {
                    command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(DEPARTMENT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("DEPARTMENT_NAME", "%" + DEPARTMENT_NAME + "%"));
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

        public int InsertDepartment()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_DEPARTMENT (DEPARTMENT_ID,DEPARTMENT_NAME) VALUES (:DEPARTMENT_ID,:DEPARTMENT_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
                command.Parameters.Add(new OracleParameter("DEPARTMENT_NAME", DEPARTMENT_NAME));
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

        public bool UpdateDepartment()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_DEPARTMENT Set ";
            query += " DEPARTMENT_ID = :DEPARTMENT_ID,";
            query += " DEPARTMENT_NAME = :DEPARTMENT_NAME";
            query += " where DEPARTMENT_ID = :DEPARTMENT_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
                command.Parameters.Add(new OracleParameter("DEPARTMENT_NAME", DEPARTMENT_NAME));

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

        public bool DeleteDepartment()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_DEPARTMENT where DEPARTMENT_ID = :DEPARTMENT_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
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

        public bool CheckUseDepartmentID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(DEPARTMENT_ID) FROM TB_DEPARTMENT WHERE DEPARTMENT_ID = :DEPARTMENT_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
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
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ClassGradISCED
    {
        public string GRAD_ISCED_ID { get; set; }
        public string GRAD_ISCED_NAME_THAI { get; set; }
        public string GRAD_ISCED_NAME_ENG { get; set; }

        public ClassGradISCED() { }
        public ClassGradISCED(string GRAD_ISCED_ID, string GRAD_ISCED_NAME_THAI, string GRAD_ISCED_NAME_ENG)
        {
            this.GRAD_ISCED_ID = GRAD_ISCED_ID;
            this.GRAD_ISCED_NAME_THAI = GRAD_ISCED_NAME_THAI;
            this.GRAD_ISCED_NAME_ENG = GRAD_ISCED_NAME_ENG;
        }

        public DataTable GetGradISCED(string GRAD_ISCED_ID, string GRAD_ISCED_NAME_THAI, string GRAD_ISCED_NAME_ENG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_ISCED ";
            if (!string.IsNullOrEmpty(GRAD_ISCED_ID) || !string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI) || !string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_ISCED_ID))
                {
                    query += " and GRAD_ISCED_ID like :GRAD_ISCED_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI))
                {
                    query += " and GRAD_ISCED_NAME_THAI like :GRAD_ISCED_NAME_THAI ";
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
                {
                    query += " and lower(GRAD_ISCED_NAME_ENG) like lower (:GRAD_ISCED_NAME_ENG) ";
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
                if (!string.IsNullOrEmpty(GRAD_ISCED_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_THAI", "%" + GRAD_ISCED_NAME_THAI + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_ENG", "%" + GRAD_ISCED_NAME_ENG + "%"));
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

        public DataTable GetGradISCEDSearch(string GRAD_ISCED_ID, string GRAD_ISCED_NAME_THAI, string GRAD_ISCED_NAME_ENG)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_ISCED ";
            if (!string.IsNullOrEmpty(GRAD_ISCED_ID) || !string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI) || !string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_ISCED_ID))
                {
                    query += " and GRAD_ISCED_ID like :GRAD_ISCED_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI))
                {
                    query += " and GRAD_ISCED_NAME_THAI like :GRAD_ISCED_NAME_THAI ";
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
                {
                    query += " and lower(GRAD_ISCED_NAME_ENG) like lower (:GRAD_ISCED_NAME_ENG) ";
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
                if (!string.IsNullOrEmpty(GRAD_ISCED_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_THAI))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_THAI", "%" + GRAD_ISCED_NAME_THAI + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_ISCED_NAME_ENG))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_ENG", "%" + GRAD_ISCED_NAME_ENG + "%"));
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

        public int InsertGradISCED()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_GRAD_ISCED (GRAD_ISCED_ID,GRAD_ISCED_NAME_THAI,GRAD_ISCED_NAME_ENG) VALUES (:GRAD_ISCED_ID,:GRAD_ISCED_NAME_THAI,:GRAD_ISCED_NAME_ENG)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_THAI", GRAD_ISCED_NAME_THAI));
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_ENG", GRAD_ISCED_NAME_ENG));
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

        public bool UpdateGradISCED()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_GRAD_ISCED Set ";
            query += " GRAD_ISCED_ID = :GRAD_ISCED_ID,";
            query += " GRAD_ISCED_NAME_THAI = :GRAD_ISCED_NAME_THAI,";
            query += " GRAD_ISCED_NAME_ENG = :GRAD_ISCED_NAME_ENG";
            query += " where GRAD_ISCED_ID = :GRAD_ISCED_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_THAI", GRAD_ISCED_NAME_THAI));
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_NAME_ENG", GRAD_ISCED_NAME_ENG));
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

        public bool DeleteGradISCED()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_GRAD_ISCED where GRAD_ISCED_ID = :GRAD_ISCED_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
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

        public bool CheckUseGradISCEDID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(GRAD_ISCED_ID) FROM TB_GRAD_ISCED WHERE GRAD_ISCED_ID = :GRAD_ISCED_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
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
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ClassGradProgram
    {
        public string GRAD_PROG_ID { get; set; }
        public string GRAD_PROG_NAME { get; set; }

        public ClassGradProgram() { }
        public ClassGradProgram(string GRAD_PROG_ID, string GRAD_PROG_NAME)
        {
            this.GRAD_PROG_ID = GRAD_PROG_ID;
            this.GRAD_PROG_NAME = GRAD_PROG_NAME;
        }

        public DataTable GetGradProgram(string GRAD_PROG_ID, string GRAD_PROG_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_PROGRAM ";
            if (!string.IsNullOrEmpty(GRAD_PROG_ID) || !string.IsNullOrEmpty(GRAD_PROG_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_PROG_ID))
                {
                    query += " and GRAD_PROG_ID like :GRAD_PROG_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_PROG_NAME))
                {
                    query += " and GRAD_PROG_NAME like :GRAD_PROG_NAME ";
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
                if (!string.IsNullOrEmpty(GRAD_PROG_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_PROG_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_PROG_NAME", "%" + GRAD_PROG_NAME + "%"));
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

        public DataTable GetGradProgramSearch(string GRAD_PROG_ID, string GRAD_PROG_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_GRAD_PROGRAM ";
            if (!string.IsNullOrEmpty(GRAD_PROG_ID) || !string.IsNullOrEmpty(GRAD_PROG_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(GRAD_PROG_ID))
                {
                    query += " and GRAD_PROG_ID like :GRAD_PROG_ID ";
                }
                if (!string.IsNullOrEmpty(GRAD_PROG_NAME))
                {
                    query += " and GRAD_PROG_NAME like :GRAD_PROG_NAME ";
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
                if (!string.IsNullOrEmpty(GRAD_PROG_ID))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID + "%"));
                }
                if (!string.IsNullOrEmpty(GRAD_PROG_NAME))
                {
                    command.Parameters.Add(new OracleParameter("GRAD_PROG_NAME", "%" + GRAD_PROG_NAME + "%"));
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

        public int InsertGradProgram()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_GRAD_PROGRAM (GRAD_PROG_ID,GRAD_PROG_NAME) VALUES (:GRAD_PROG_ID,:GRAD_PROG_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID));
                command.Parameters.Add(new OracleParameter("GRAD_PROG_NAME", GRAD_PROG_NAME));
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

        public bool UpdateGradProgram()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_GRAD_PROGRAM Set ";
            query += " GRAD_PROG_ID = :GRAD_PROG_ID,";
            query += " GRAD_PROG_NAME = :GRAD_PROG_NAME";
            query += " where GRAD_PROG_ID = :GRAD_PROG_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID));
                command.Parameters.Add(new OracleParameter("GRAD_PROG_NAME", GRAD_PROG_NAME));

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

        public bool DeleteGradProgram()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_GRAD_PROGRAM where GRAD_PROG_ID = :GRAD_PROG_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID));
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

        public bool CheckUseGradProgramID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(GRAD_PROG_ID) FROM TB_GRAD_PROGRAM WHERE GRAD_PROG_ID = :GRAD_PROG_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("GRAD_PROG_ID", GRAD_PROG_ID));
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
    /////////////////////////////////////////////////////////////////////////////////////////
    public class ClassPosition
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string ST_ID { get; set; }


        public ClassPosition() { }
        public ClassPosition(string ID, string NAME, string ST_ID)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.ST_ID = ST_ID;

        }

        public DataTable GetPosition(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", "%" + ST_ID + "%"));
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

        public DataTable GetPositionSearch(string ID, string NAME, string ST_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_POSITION ";
            if (!string.IsNullOrEmpty(ID) || !string.IsNullOrEmpty(NAME) || !string.IsNullOrEmpty(ST_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(ID))
                {
                    query += " and ID like :ID ";
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    query += " and NAME like :NAME ";
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    query += " and ST_ID like :ST_ID ";
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
                if (!string.IsNullOrEmpty(ID))
                {
                    command.Parameters.Add(new OracleParameter("ID", ID + "%"));
                }
                if (!string.IsNullOrEmpty(NAME))
                {
                    command.Parameters.Add(new OracleParameter("NAME", NAME + "%"));
                }
                if (!string.IsNullOrEmpty(ST_ID))
                {
                    command.Parameters.Add(new OracleParameter("ST_ID", "%" + ST_ID + "%"));
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

        public int InsertPosition()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_POSITION (ID,NAME,ST_ID) VALUES (:ID,:NAME,:ST_ID)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ID", ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));
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

        public bool UpdatePosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_POSITION Set ";
            query += " ID = :ID,";
            query += " NAME = :NAME,";
            query += " ST_ID = :ST_ID";
            query += " where ID = :ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("ID", ID));
                command.Parameters.Add(new OracleParameter("NAME", NAME));
                command.Parameters.Add(new OracleParameter("ST_ID", ST_ID));

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

        public bool DeletePosition()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_POSITION where ID = :ID", conn);
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

        public bool CheckUsePositionID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(ID) FROM TB_POSITION WHERE ID = :ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("ID", ID));
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
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public class ClassStatusWork
    {

        public int STATUS_ID { get; set; }
        public string STATUS_WORK { get; set; }

        public ClassStatusWork() { }
        public ClassStatusWork(int STATUS_ID, string STATUS_WORK)
        {
            this.STATUS_ID = STATUS_ID;
            this.STATUS_WORK = STATUS_WORK;
        }

        public DataTable GetStatusWork(string STATUS_WORK)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STATUS_WORK ";
            if (!string.IsNullOrEmpty(STATUS_WORK))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STATUS_WORK))
                {
                    query += " and STATUS_WORK like :STATUS_WORK ";
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
                if (!string.IsNullOrEmpty(STATUS_WORK))
                {
                    command.Parameters.Add(new OracleParameter("STATUS_WORK", STATUS_WORK + "%"));
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

        public DataTable GetStatusWorkSearch(string STATUS_WORK)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_STATUS_WORK ";
            if (!string.IsNullOrEmpty(STATUS_WORK))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(STATUS_WORK))
                {
                    query += " and STATUS_WORK like :STATUS_WORK ";
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
                if (!string.IsNullOrEmpty(STATUS_WORK))
                {
                    command.Parameters.Add(new OracleParameter("STATUS_WORK", STATUS_WORK + "%"));
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

        public int InsertStatusWork()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_STATUS_WORK (STATUS_WORK) VALUES (:STATUS_WORK)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_WORK", STATUS_WORK));
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

        public bool UpdateStatusWork()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_STATUS_WORK Set ";
            query += " STATUS_WORK = :STATUS_WORK";
            query += " where STATUS_ID = :STATUS_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
                command.Parameters.Add(new OracleParameter("STATUS_WORK", STATUS_WORK));

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

        public bool DeleteStatusWork()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_STATUS_WORK where STATUS_ID = :STATUS_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
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

        public bool CheckUseStatusWorkID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(STATUS_ID) FROM TB_STATUS_WORK WHERE STATUS_ID = :STATUS_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("STATUS_ID", STATUS_ID));
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
    /////////////////////////////////////////////////////////////////////////////////////
    public class ClassSubStaffType
    {
        public int SUBSTAFFTYPE_ID { get; set; }
        public string SUBSTAFFTYPE_NAME { get; set; }


        public ClassSubStaffType() { }
        public ClassSubStaffType(int SUBSTAFFTYPE_ID, string SUBSTAFFTYPE_NAME)
        {
            this.SUBSTAFFTYPE_ID = SUBSTAFFTYPE_ID;
            this.SUBSTAFFTYPE_NAME = SUBSTAFFTYPE_NAME;
        }

        public DataTable GetSubStaffType(string SUBSTAFFTYPE_ID, string SUBSTAFFTYPE_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_SUBSTAFFTYPE ";
            if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID) || !string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID))
                {
                    query += " and SUBSTAFFTYPE_ID like :SUBSTAFFTYPE_ID ";
                }
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
                {
                    query += " and SUBSTAFFTYPE_NAME like :SUBSTAFFTYPE_NAME ";
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

                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID))
                {
                    command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_NAME", "%" + SUBSTAFFTYPE_NAME + "%"));
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

        public DataTable GetSubStaffTypeSearch(string SUBSTAFFTYPE_ID, string SUBSTAFFTYPE_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_SUBSTAFFTYPE ";
            if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID) || !string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID))
                {
                    query += " and SUBSTAFFTYPE_ID like :SUBSTAFFTYPE_ID ";
                }
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
                {
                    query += " and SUBSTAFFTYPE_NAME like :SUBSTAFFTYPE_NAME ";
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

                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_ID))
                {
                    command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID + "%"));
                }
                if (!string.IsNullOrEmpty(SUBSTAFFTYPE_NAME))
                {
                    command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_NAME", "%" + SUBSTAFFTYPE_NAME + "%"));
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

        public int InsertSubStaffType()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_SUBSTAFFTYPE (SUBSTAFFTYPE_ID,SUBSTAFFTYPE_NAME) VALUES (:SUBSTAFFTYPE_ID,:SUBSTAFFTYPE_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_NAME", SUBSTAFFTYPE_NAME));
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

        public bool UpdateSubStaffType()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_SUBSTAFFTYPE Set ";
            query += " SUBSTAFFTYPE_ID = :SUBSTAFFTYPE_ID,";
            query += " SUBSTAFFTYPE_NAME = :SUBSTAFFTYPE_NAME";
            query += " where SUBSTAFFTYPE_ID = :SUBSTAFFTYPE_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_NAME", SUBSTAFFTYPE_NAME));

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

        public bool DeleteSubStaffType()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_SUBSTAFFTYPE where SUBSTAFFTYPE_ID = :SUBSTAFFTYPE_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
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
        public bool CheckUseSubStaffTypeID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(SUBSTAFFTYPE_ID) FROM TB_SUBSTAFFTYPE WHERE SUBSTAFFTYPE_ID = :SUBSTAFFTYPE_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
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
    public class ClassTimeContact
    {
        public int TIME_CONTACT_ID { get; set; }
        public string TIME_CONTACT_NAME { get; set; }

        public ClassTimeContact() { }
        public ClassTimeContact(int TIME_CONTACT_ID, string TIME_CONTACT_NAME)
        {
            this.TIME_CONTACT_ID = TIME_CONTACT_ID;
            this.TIME_CONTACT_NAME = TIME_CONTACT_NAME;
        }

        public DataTable GetTimeContact(string TIME_CONTACT_ID, string TIME_CONTACT_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TIME_CONTACT ";
            if (!string.IsNullOrEmpty(TIME_CONTACT_ID) || !string.IsNullOrEmpty(TIME_CONTACT_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                {
                    query += " and TIME_CONTACT_ID like :TIME_CONTACT_ID ";
                }
                if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                {
                    query += " and TIME_CONTACT_NAME like :TIME_CONTACT_NAME ";
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
                if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                {
                    command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", "%" + TIME_CONTACT_NAME + "%"));
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

        public DataTable GetTimeContactSearch(string TIME_CONTACT_ID, string TIME_CONTACT_NAME)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM TB_TIME_CONTACT";
            if (!string.IsNullOrEmpty(TIME_CONTACT_ID) || !string.IsNullOrEmpty(TIME_CONTACT_NAME))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                {
                    query += " and TIME_CONTACT_ID like :TIME_CONTACT_ID ";
                }
                if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                {
                    query += " and TIME_CONTACT_NAME like :TIME_CONTACT_NAME ";
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
                if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                {
                    command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID + "%"));
                }
                if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                {
                    command.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", "%" + TIME_CONTACT_NAME + "%"));
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

        public int InsertTimeContact()
        {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO TB_TIME_CONTACT (TIME_CONTACT_ID,TIME_CONTACT_NAME) VALUES (:TIME_CONTACT_ID,:TIME_CONTACT_NAME)", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME));
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

        public bool UpdateTimeContact()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update TB_TIME_CONTACT Set ";
            query += " TIME_CONTACT_ID = :TIME_CONTACT_ID,";
            query += " TIME_CONTACT_NAME = :TIME_CONTACT_NAME";
            query += " where TIME_CONTACT_ID = :TIME_CONTACT_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME));

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

        public bool DeleteTimeContact()
        {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete TB_TIME_CONTACT where TIME_CONTACT_ID = :TIME_CONTACT_ID", conn);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
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

        public bool CheckUseTimeContactID()
        {
            bool result = true;
            OracleConnection conn = ConnectionDB.GetOracleConnection();

            // Create the command
            OracleCommand command = new OracleCommand("SELECT count(TIME_CONTACT_ID) FROM TB_TIME_CONTACT WHERE TIME_CONTACT_ID = :TIME_CONTACT_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
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
    /////////////////////////////////////////////////////////////////////////////////////////////////////




}
