using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

namespace WEB_PERSONAL.Class {
    
    public class DatabaseManager {

        public static readonly string PROVIDER = "System.Data.OracleClient";
        //public static readonly string DATA_SOURCE = "203.158.140.67";
        public static readonly string DATA_SOURCE = "localhost";
        public static readonly string PORT = "1521";
        public static readonly string SID = "orcl";
        public static readonly string USER_ID = "rmutto";
        public static readonly string PASSWORD = "Zxcvbnm";
        //public static readonly string CONNECTION_STRING_OLE = @"Provider=" + PROVIDER + "; Data Source = " + DATA_SOURCE + ":" + PORT + "/" + SID + ";USER ID=" + USER_ID + ";PASSWORD=" + PASSWORD;
        public static readonly string CONNECTION_STRING = @"Data Source = " + DATA_SOURCE + ":" + PORT + "/" + SID + ";USER ID=" + USER_ID + ";PASSWORD=" + PASSWORD + ";";
        //public static readonly string CONNECTION_STRING_FIXED = @"Provider=OraOLEDB.Oracle; Data Source = 203.158.140.67:1521/orcl;USER ID=rmutto;PASSWORD=Zxcvbnm";

        public static void ExecuteNonQuery(string sql) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con)) {
                    com.ExecuteNonQuery();
                }
            } 
        }
        public static int ExecuteInt(string sql) {
            OracleConnection.ClearAllPools();
            int output = -1;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con)) {
                    using(OracleDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            output = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return output;
        }
        public static string ExecuteString(string sql) {
            OracleConnection.ClearAllPools();
            string output = null;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            output = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return output;
        }
        public static int ExecuteSequence(string seq_name) {
            OracleConnection.ClearAllPools();
            int seq;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT " + seq_name + ".NEXTVAL FROM DUAL", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        reader.Read();
                        seq = int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            return seq;
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value) {
            OracleConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value, string first) {
            OracleConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(first, "0"));
        }
        public static void BindGridView(GridView gv, string sql) {
            OracleConnection.ClearAllPools();
            SqlDataSource sds = CreateSQLDataSource(sql);
            gv.DataSource = sds;
            gv.DataBind();
        }
        public static SqlDataSource CreateSQLDataSource(string sql) {
            return new SqlDataSource("Oracle.DataAccess.Client", CONNECTION_STRING, sql);
        }
        public static bool ValidateUser(string personID, string password) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_PASSWORD FROM PS_PERSON", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            if (reader.GetString(0) == personID && reader.GetString(1) == password) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static Person GetPerson(string citizenID) {
            OracleConnection.ClearAllPools();

            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(

                    "SELECT PS_PERSON.PS_CITIZEN_ID, PS_PERSON.PS_TITLE_ID, (SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TB_TITLENAME.TITLE_ID = PS_PERSON.PS_TITLE_ID) TITLE_NAME_TH, PS_PERSON.PS_FN_TH, PS_PERSON.PS_LN_TH, PS_GENDER_ID, (SELECT GENDER_NAME FROM TB_GENDER WHERE TB_GENDER.GENDER_ID = PS_PERSON.PS_GENDER_ID) GENDER_NAME, PS_BIRTHDAY_DATE, PS_BIRTHDAY_LONG, PS_RETIRE_DATE, PS_RETIRE_LONG, PS_INWORK_DATE, PS_PERSON.PS_STAFFTYPE_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE TB_STAFFTYPE.STAFFTYPE_ID = PS_PERSON.PS_STAFFTYPE_ID) STAFFTYPE_NAME, PS_DAD_FN, PS_DAD_LN, PS_MOM_FN, PS_MOM_LN, PS_MOM_LN_OLD, PS_LOV_FN, PS_LOV_LN, PS_LOV_LN_OLD, PS_PERSON.PS_MINISTRY_ID, (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE TB_MINISTRY.MINISTRY_ID = PS_PERSON.PS_MINISTRY_ID) MINISTRY_NAME, PS_DIVISION_ID, (SELECT DIVISION_NAME FROM TB_DIVISION WHERE TB_DIVISION.DIVISION_ID = PS_PERSON.PS_DIVISION_ID) DIVISION_NAME, PS_PASSWORD, PS_RACE_ID, (SELECT NATION_THA FROM TB_NATIONAL WHERE TB_NATIONAL.NATION_SEQ = PS_PERSON.PS_RACE_ID) RACE_THA, PS_NATION_ID, (SELECT NATION_THA FROM TB_NATIONAL WHERE TB_NATIONAL.NATION_SEQ = PS_PERSON.PS_NATION_ID) NATION_THA, PS_HOMEADD, PS_SOI, PS_MOO, PS_STREET, PS_DISTRICT, (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE TB_DISTRICT.DISTRICT_ID = PS_PERSON.PS_DISTRICT) DISTRICT_TH, PS_AMPHUR_ID, (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE TB_AMPHUR.AMPHUR_ID = PS_PERSON.PS_AMPHUR_ID) AMPHUR_TH, PS_PROVINCE_ID, (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE TB_PROVINCE.PROVINCE_ID = PS_PERSON.PS_PROVINCE_ID) PROVINCE_TH, PS_ZIPCODE, PS_COUNTRY_ID, (SELECT COUNTRY_TH FROM TB_COUNTRY WHERE TB_COUNTRY.COUNTRY_ID = PS_PERSON.PS_COUNTRY_ID) PS_COUNTRY_NAME, PS_STATE, PS_HOMEADD_NOW, PS_SOI_NOW, PS_MOO_NOW, PS_STREET_NOW, PS_DISTRICT_ID_NOW, (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE TB_DISTRICT.DISTRICT_ID = PS_PERSON.PS_DISTRICT_ID_NOW) DISTRICT_TH, PS_AMPHUR_ID_NOW, (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE TB_AMPHUR.AMPHUR_ID = PS_PERSON.PS_AMPHUR_ID_NOW) AMPHUR_TH, PS_PROVINCE_ID_NOW, (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE TB_PROVINCE.PROVINCE_ID = PS_PERSON.PS_PROVINCE_ID_NOW) PROVINCE_TH, PS_ZIPCODE_NOW, PS_COUNTRY_ID_NOW, (SELECT COUNTRY_TH FROM TB_COUNTRY WHERE TB_COUNTRY.COUNTRY_ID = PS_PERSON.PS_COUNTRY_ID_NOW) PS_COUNTRY_NAME_NOW, PS_STATE_NOW, PS_PHONE, PS_BUDGET_ID, (SELECT BUDGET_NAME FROM TB_BUDGET WHERE TB_BUDGET.BUDGET_ID = PS_PERSON.PS_BUDGET_ID) BUDGET_NAME, PS_ADMIN_POS_ID, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID) ADMIN_POSITION_NAME, (SELECT ADMIN_POSITION_POWER FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID) ADMIN_POSITION_POWER, PS_SPECIAL_WORK, PS_TEACH_ISCED_ID, PS_FACULTY_ID, (SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = PS_PERSON.PS_FACULTY_ID) FACULTY_NAME, PS_CAMPUS_ID, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = PS_PERSON.PS_CAMPUS_ID) CAMPUS_NAME, PS_SW_ID, PS_RELIGION_ID, (SELECT RELIGION_NAME FROM TB_RELIGION WHERE TB_RELIGION.RELIGION_ID = PS_PERSON.PS_RELIGION_ID) RELIGION_NAME, (SELECT PS_POSITION_AND_SALARY.PS_POSITION_NO FROM PS_POSITION_AND_SALARY WHERE PS_PERSON.PS_CITIZEN_ID = PS_POSITION_AND_SALARY.PS_CITIZEN_ID AND PRESENT = 1) POSITION_NO, (SELECT TB_POSITION.NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) POSITION_NAME, PS_SALARY, PS_STATUS_ID, (SELECT STATUS_NAME FROM TB_STATUS_PERSON WHERE PS_PERSON.PS_STATUS_ID = TB_STATUS_PERSON.STATUS_ID) STATUS_PERSON_NAME, PS_BLOOD_ID, (SELECT BLOOD_NAME FROM TB_BLOOD WHERE PS_PERSON.PS_BLOOD_ID = TB_BLOOD.BLOOD_ID) BLOOD_NAME, PS_TELEPHONE_WORK, PS_EMAIL, PS_GROM, (SELECT SW_NAME FROM TB_STATUS_WORK WHERE PS_PERSON.PS_SW_ID = TB_STATUS_WORK.SW_ID) STATUS_NAME, PS_WORK_DIVISION_ID, (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE PS_PERSON.PS_WORK_DIVISION_ID = TB_WORK_DIVISION.WORK_ID) WORK_NAME, PS_WORK_POS_ID, (SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE TB_POSITION_WORK.POSITION_WORK_ID = PS_PERSON.PS_WORK_POS_ID) POSITION_WORK_NAME, PS_RANK_ID, (SELECT RANK_NAME_TH FROM TB_RANK WHERE TB_RANK.RANK_ID = PS_PERSON.PS_RANK_ID) RANK_NAME, PS_START_POSI_ID, (SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE TB_POSITION_WORK.POSITION_WORK_ID = PS_PERSON.PS_START_POSI_ID) START_POSITION_WORK_NAME, PS_START_ADMIN_POSI_ID, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = PS_PERSON.PS_START_ADMIN_POSI_ID) START_ADMIN_POSITION_NAME, PS_POSS_SALARY, PS_DATE_QUIT, PS_PERMISSION FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + citizenID + "'"




                    , con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {

                            Person person = new Person();
                            int i = 0;

                            person.CitizenID = reader.GetValue(i++).ToString();
                            person.TitleID = reader.GetValue(i++).ToString();
                            person.TitleName = reader.GetValue(i++).ToString();
                            person.FirstName = reader.GetValue(i++).ToString();
                            person.LastName = reader.GetValue(i++).ToString();
                            person.GenderID = reader.GetValue(i++).ToString();
                            person.GenderName = reader.GetValue(i++).ToString();
                            person.BirthDate = reader.GetDateTime(i++);
                            person.BirthDateLong = reader.GetValue(i++).ToString();

                            if(reader.IsDBNull(i)) {
                                person.RetireDate = null;
                            } else {
                                person.RetireDate = reader.GetDateTime(i);
                            }
                            ++i;
                            
                            person.RetireDateLong = reader.GetValue(i++).ToString();

                            if (reader.IsDBNull(i))
                            {
                                person.InWorkDate = null;
                            }
                            else
                            {
                                person.InWorkDate = reader.GetDateTime(i);
                            }
                            ++i;

                            person.StaffTypeID = reader.GetValue(i++).ToString();
                            person.StaffTypeName = reader.GetValue(i++).ToString();
                            person.FatherFirstName = reader.GetValue(i++).ToString();
                            person.FatherLastName = reader.GetValue(i++).ToString();
                            person.MotherFirstName = reader.GetValue(i++).ToString();
                            person.MotherLastName = reader.GetValue(i++).ToString();
                            person.MotherOldLastName = reader.GetValue(i++).ToString();
                            person.CoupleFirstName = reader.GetValue(i++).ToString();
                            person.CoupleLastName = reader.GetValue(i++).ToString();
                            person.CoupleOldLastName = reader.GetValue(i++).ToString();
                            person.MinistryID = reader.GetValue(i++).ToString();
                            person.MinistryName = reader.GetValue(i++).ToString();

                            if (reader.IsDBNull(i)) {
                                person.DivisionID = null;
                            } else {
                                person.DivisionID = reader.GetValue(i).ToString();
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                person.DivisionName = null;
                            } else {
                                person.DivisionName = reader.GetValue(i).ToString();
                            }
                            ++i;

                            person.Password = reader.GetValue(i++).ToString();
                            person.RaceID = reader.GetValue(i++).ToString();
                            person.RaceName = reader.GetValue(i++).ToString();
                            person.NationID = reader.GetValue(i++).ToString();
                            person.NationName = reader.GetValue(i++).ToString();

                            person.HomeAdd = reader.GetValue(i++).ToString();
                            person.Soi = reader.GetValue(i++).ToString();
                            person.Moo = reader.GetValue(i++).ToString();
                            person.Street = reader.GetValue(i++).ToString();
                            person.DistrictID = reader.GetValue(i++).ToString();
                            person.DistrictName = reader.GetValue(i++).ToString();
                            person.AmphurID = reader.GetValue(i++).ToString();
                            person.AmphurName = reader.GetValue(i++).ToString();
                            person.ProvinceID = reader.GetValue(i++).ToString();
                            person.ProvinceName = reader.GetValue(i++).ToString();
                            person.ZipCode = reader.GetValue(i++).ToString();
                            person.PlaceCountryID = reader.GetValue(i++).ToString();
                            person.PlaceCountryName = reader.GetValue(i++).ToString();
                            person.PlaceState = reader.GetValue(i++).ToString();

                            person.HomeAddNow = reader.GetValue(i++).ToString();
                            person.SoiNow = reader.GetValue(i++).ToString();
                            person.MooNow = reader.GetValue(i++).ToString();
                            person.StreetNow = reader.GetValue(i++).ToString();
                            person.DistrictIDNow = reader.GetValue(i++).ToString();
                            person.DistrictNameNow = reader.GetValue(i++).ToString();
                            person.AmphurIDNow = reader.GetValue(i++).ToString();
                            person.AmphurNameNow = reader.GetValue(i++).ToString();
                            person.ProvinceIDNow = reader.GetValue(i++).ToString();
                            person.ProvinceNameNow = reader.GetValue(i++).ToString();
                            person.ZipCodeNow = reader.GetValue(i++).ToString();
                            person.PlaceCountryID = reader.GetValue(i++).ToString();
                            person.PlaceCountryNowName = reader.GetValue(i++).ToString();
                            person.PlaceStateNow = reader.GetValue(i++).ToString();

                            person.Telephone = reader.GetValue(i++).ToString();
                            person.BudgetID = reader.GetValue(i++).ToString();
                            person.BudgetName = reader.GetValue(i++).ToString();
                            person.AdminPositionID = reader.GetValue(i++).ToString();
                            person.AdminPositionName = reader.GetValue(i++).ToString();
                            person.AdminPositionPower = reader.GetValue(i++).ToString();
                            person.SpecialName = reader.GetValue(i++).ToString();
                            person.TeachISCEDID = reader.GetValue(i++).ToString();
                            person.FacultyID = reader.GetValue(i++).ToString();
                            person.FacultyName = reader.GetValue(i++).ToString();
                            person.CampusID = reader.GetValue(i++).ToString();
                            person.CampusName = reader.GetValue(i++).ToString();
                            person.StatusID = reader.GetValue(i++).ToString();
                            person.ReligionID = reader.GetValue(i++).ToString();
                            person.ReligionName = reader.GetValue(i++).ToString();
                            person.PositionID = reader.GetValue(i++).ToString();
                            person.PositionName = reader.GetValue(i++).ToString();

                            if (reader.IsDBNull(i))
                            {
                                person.Salary = 0;
                            }
                            else {
                                person.Salary = reader.GetInt32(i);
                            }
                            ++i;

                            //person.Salary = reader.GetInt32(i++);
                            person.StatusPersonID = reader.GetValue(i++).ToString();
                            person.StatusPersonName = reader.GetValue(i++).ToString();
                            person.BloodID = reader.GetValue(i++).ToString();
                            person.BloodName = reader.GetValue(i++).ToString();
                            person.WorkTelephone = reader.GetValue(i++).ToString();
                            person.Email = reader.GetValue(i++).ToString();
                            person.Grom = reader.GetValue(i++).ToString();
                            person.StatusName = reader.GetValue(i++).ToString();

                            if (reader.IsDBNull(i)) {
                                person.WorkDivisionID = null;
                            } else {
                                person.WorkDivisionID = reader.GetValue(i).ToString();
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                person.WorkDivisionName = null;
                            } else {
                                person.WorkDivisionName = reader.GetValue(i).ToString();
                            }
                            ++i;


                            person.PositionWorkID = reader.GetValue(i++).ToString();
                            person.PositionWorkName = reader.GetValue(i++).ToString();

                            person.RankID = reader.GetValue(i++).ToString();
                            person.RankName = reader.GetValue(i++).ToString();

                            person.StartPositionWorkID = reader.GetValue(i++).ToString();
                            person.StartPositionWorkName = reader.GetValue(i++).ToString();
                            person.StartAdminPositionID = reader.GetValue(i++).ToString();
                            person.StartAdminPositionName = reader.GetValue(i++).ToString();

                            person.PositionSalary = reader.GetValue(i++).ToString();

                            if (reader.IsDBNull(i))
                            {
                                person.DateQuit = null;
                            }
                            else
                            {
                                person.DateQuit = reader.GetDateTime(i);
                            }
                            ++i;

                            person.Permission = reader.GetInt32(i++);

                            return person;
                        }
                    }
                }
            }
            return null;
        }
        
        public static int GetLeaveRequiredCountByCommander(string citizenID) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(LEV_BOSS_DATA.LEAVE_BOSS_ID) FROM LEV_DATA, LEV_BOSS_DATA WHERE LEAVE_STATUS_ID IN(1,4) AND LEV_DATA.LEAVE_ID = LEV_BOSS_DATA.LEAVE_ID AND LEV_DATA.BOSS_STATE = LEV_BOSS_DATA.STATE AND LEV_BOSS_DATA.CITIZEN_ID = '" + citizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            int count = int.Parse(reader.GetInt32(0).ToString());
                            return count;
                        }
                    }
                }
            }
            return -1;
        }
        public static List<DateTime> GetLeaveDateTimeFromToDate(string citizenID) {
            OracleConnection.ClearAllPools();
            List<DateTime> list = new List<DateTime>();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT FROM_DATE, TO_DATE FROM LEV_DATA WHERE PS_ID = '" + citizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            DateTime start = reader.GetDateTime(0);
                            DateTime to = reader.GetDateTime(1);
                            while (true) {
                                if(!list.Contains(start)) {
                                    list.Add(start);
                                }
                                start = start.AddDays(1);
                                if((to - start).TotalDays < 0) {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }
        public static string รหัสหัวหน้าฝ่าย(string DVID) {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 4 AND PS_WORK_DIVISION_ID = " + DVID, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }
        public static string รหัสหัวหน้าภาควิชา(string DVID) {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 7 AND PS_DIVISION_ID = " + DVID, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }
        public static string รหัสคณบดี(string FID) {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 3 AND PS_FACULTY_ID = " + FID, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }
        public static string รหัสอธิการบดี(string CID) {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }
        public static List<Person> รหัสหัวหน้า(string citizenID) {
            List<Person> bossList = new List<Person>();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                int workPositionID = -1;
                int adminPositionPower = 0;
                int facultyID = 0;
                int divisionID = 0;
                int workDivisionID = 0;
                int adminPositionID = 0;
                int campusID = 0;
                bool no_me = false;
                bool cancel = false;
                using (OracleCommand com = new OracleCommand("SELECT PS_WORK_POS_ID, PS_FACULTY_ID, PS_DIVISION_ID, PS_WORK_DIVISION_ID, PS_ADMIN_POS_ID, PS_CAMPUS_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + citizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            workPositionID = reader.GetInt32(0);
                            facultyID = reader.GetInt32(1);
                            divisionID = reader.GetInt32(2);
                            
                            if(reader.IsDBNull(3)) {
                                workDivisionID = -1;
                            } else {
                                workDivisionID = reader.GetInt32(3);
                            }
                            adminPositionID = reader.GetInt32(4);
                            campusID = reader.GetInt32(5);

                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("SELECT ADMIN_POSITION_POWER FROM PS_PERSON, TB_ADMIN_POSITION WHERE PS_CITIZEN_ID = '" + citizenID + "' AND PS_ADMIN_POS_ID = ADMIN_POSITION_ID", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            adminPositionPower = reader.GetInt32(0);
                        }
                    }
                }
                int bossNodeType = -1;
                int bossNodeTypeID = -1;
                if ((workPositionID == 10108 || workPositionID == 10077) && (adminPositionPower >= 3 || adminPositionPower == 0)) { //อาจารย์
                    if(adminPositionPower == 0) {
                        bossNodeType = 3;
                        bossNodeTypeID = divisionID;
                    }
                    else if(adminPositionPower == 3) {
                        bossNodeType = 3;
                        bossNodeTypeID = divisionID;
                        no_me = true;
                    }
                } else {
                    if(adminPositionPower == 2 && adminPositionID != 4) {
                        bossNodeType = 2;
                        bossNodeTypeID = facultyID;
                    } else if (adminPositionID == 4) { //คณบดี
                        bossNodeType = 1;
                        bossNodeTypeID = campusID;
                    } else if (adminPositionID == 2) { //รองอธิการ
                        bossNodeType = -1;
                        bossNodeTypeID = -1;
                    } else if(adminPositionID == 1) { //อธิการ
                        cancel = true;
                    }
                }
                if(cancel) {
                    return null;
                }

                int? nextNodeID = null;
                while (true) {
                    string sql = "SELECT * FROM TB_BOSS_NODE WHERE BOSS_NODE_TYPE = " + bossNodeType + " AND BOSS_NODE_TYPE_ID = '" + bossNodeTypeID + "'";
                    if(bossNodeType == -1) {
                        sql = "SELECT * FROM TB_BOSS_NODE WHERE BOSS_NODE_ID = 1";
                    }
                    if(nextNodeID != null) {
                        sql = "SELECT * FROM TB_BOSS_NODE WHERE BOSS_NODE_ID = " + nextNodeID;
                    }
                    using (OracleCommand com = new OracleCommand(sql, con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                if (reader.IsDBNull(3)) {
                                    nextNodeID = null;
                                } else {
                                    nextNodeID = reader.GetInt32(3);   
                                }

                                string bossID = reader.GetString(6);
                                Person p = GetPerson(bossID);
                                if(no_me) {
                                    no_me = false;
                                } else {
                                    bossList.Add(p);
                                }
                                

                            }
                        }
                    }
                    if (nextNodeID == null)
                        break;
                }



               
            }
            return bossList;
        }
        /*public static string รหัสเลขาธิการคณะกรรมการ() {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 10022", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }
        public static string รหัสรัฐมนตรีเจ้าสังกัด() {
            OracleConnection.ClearAllPools();
            string citizenID = "-1";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 10021", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            citizenID = reader.GetString(0);
                        }
                    }
                }
            }
            return citizenID;
        }*/
        public static void AddCounter() {
            ExecuteNonQuery("UPDATE TB_WEB SET COUNTER = COUNTER+1 WHERE ID = 1");
        }
        public static int GetCounter() {
            return ExecuteInt("SELECT COUNTER FROM TB_WEB WHERE ID = 1");
        }
        public static string GetPersonImageFileName(string citizenID) {
            OracleConnection.ClearAllPools();
            string fileName = "";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "' AND PRESENT = 1", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            fileName = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return fileName;
        }
        public static string[] GetPersonImageFileNames(string citizenID) {
            OracleConnection.ClearAllPools();
            List<string> fileNameList = new List<string>();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            fileNameList.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return fileNameList.ToArray();
        }
        

    }
}