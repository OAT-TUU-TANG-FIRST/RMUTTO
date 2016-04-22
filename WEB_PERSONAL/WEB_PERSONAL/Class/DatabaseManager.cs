using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WEB_PERSONAL.Class {
    
    public class DatabaseManager {

        public static readonly string PROVIDER = "OraOLEDB.Oracle";
        public static readonly string DATA_SOURCE = "203.158.140.67";
        public static readonly string PORT = "1521";
        public static readonly string SID = "orcl";
        public static readonly string USER_ID = "rmutto";
        public static readonly string PASSWORD = "Zxcvbnm";
        public static readonly string CONNECTION_STRING = @"Provider=" + PROVIDER + "; Data Source = " + DATA_SOURCE + ":" + PORT + "/" + SID + ";USER ID=" + USER_ID + ";PASSWORD=" + PASSWORD;
        public static readonly string CONNECTION_STRING_FIXED = @"Provider=OraOLEDB.Oracle; Data Source = 203.158.140.67:1521/orcl;USER ID=rmutto;PASSWORD=Zxcvbnm";

        public static void ExecuteNonQuery(string sql) {
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand(sql, con)) {
                    com.ExecuteNonQuery();
                }
            }
        }
        public static int ExecuteInt(string sql) {
            int output = -1;
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand(sql, con)) {
                    using(OleDbDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            output = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return output;
        }
        public static int ExecuteSequence(string seq_name) {
            int seq;
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT " + seq_name + ".NEXTVAL FROM DUAL", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        reader.Read();
                        seq = int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            return seq;
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value) {
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value, string first) {
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(first, "0"));
        }
        public static SqlDataSource CreateSQLDataSource(string sql) {
            return new SqlDataSource("System.Data.OleDb", CONNECTION_STRING, sql);
        }
        public static bool ValidateUser(string personID, string password) {
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT PS_CITIZEN_ID, PS_PASSWORD FROM PS_PERSON", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
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
            /*
            "SELECT * FROM (" +
                    " SELECT TB_POSITION_AND_SALARY.ID, TB_PERSON.CITIZEN_ID, TB_TITLENAME.TITLE_NAME_TH, TB_PERSON.PERSON_NAME, TB_PERSON.PERSON_LASTNAME, TB_POSITION.NAME, TB_ADMIN_POSITION.ADMIN_POSITION_NAME, TB_PERSON.DEPARTMENT_NAME, TB_PERSON.BIRTHDATE, TB_PERSON.INWORK_DATE, TB_GENDER.GENDER_NAME, RANK() OVER(PARTITION BY TB_PERSON.CITIZEN_ID ORDER BY TB_POSITION_AND_SALARY.ID DESC) AS RNK" +
                    " FROM TB_PERSON, TB_POSITION_AND_SALARY, TB_POSITION, TB_TITLENAME, TB_ADMIN_POSITION, TB_GENDER" +
                    " WHERE TB_PERSON.CITIZEN_ID = TB_POSITION_AND_SALARY.CITIZEN_ID AND TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID AND TB_PERSON.TITLE_ID = TB_TITLENAME.TITLE_ID AND TB_PERSON.ADMIN_POSITION_ID = TB_ADMIN_POSITION.ADMIN_POSITION_ID AND TB_PERSON.GENDER_ID = TB_GENDER.GENDER_ID AND TB_PERSON.CITIZEN_ID = '" + personID + "'" +
                    " ) TB_A" +
                    " WHERE TB_A.RNK = 1"
    */
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand(
                    //"SELECT TB_PERSON.CITIZEN_ID, TB_PERSON.TITLE_ID, (SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TB_TITLENAME.TITLE_ID = TB_PERSON.TITLE_ID) TITLE_NAME_TH, TB_PERSON.PERSON_NAME, TB_PERSON.PERSON_LASTNAME, BIRTHDATE, BIRTHDATE_LONG, RETIRE_DATE, RETIRE_DATE_LONG, INWORK_DATE, TB_PERSON.STAFFTYPE_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE TB_STAFFTYPE.STAFFTYPE_ID = TB_PERSON.STAFFTYPE_ID) STAFFTYPE_NAME, FATHER_NAME, FATHER_LASTNAME, MOTHER_NAME, MOTHER_LASTNAME, MOTHER_OLD_LASTNAME, COUPLE_NAME, COUPLE_LASTNAME, COUPLE_OLD_LASTNAME, TB_PERSON.MINISTRY_ID, (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE TB_MINISTRY.MINISTRY_ID = TB_PERSON.MINISTRY_ID) MINISTRY_NAME, TB_PERSON.DEPARTMENT_NAME, PASSWORD, SYSTEM_STATUS_ID, (SELECT SYSTEM_STATUS_NAME FROM TB_SYSTEM_STATUS WHERE TB_SYSTEM_STATUS.SYSTEM_STATUS_ID = TB_PERSON.SYSTEM_STATUS_ID) SYSTEM_STATUS_NAME, GENDER_ID, (SELECT GENDER_NAME FROM TB_GENDER WHERE TB_GENDER.GENDER_ID = TB_PERSON.GENDER_ID) GENDER_NAME, NATION_ID, (SELECT NATION_THA FROM TB_NATIONAL WHERE TB_NATIONAL.NATION_ID = TB_PERSON.NATION_ID) NATION_THA, HOMEADD, MOO, STREET, DISTRICT_ID, (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE TB_DISTRICT.DISTRICT_ID = TB_PERSON.DISTRICT_ID) DISTRICT_TH, AMPHUR_ID, (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE TB_AMPHUR.AMPHUR_ID = TB_PERSON.AMPHUR_ID) AMPHUR_TH, PROVINCE_ID, (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE TB_PROVINCE.PROVINCE_ID = TB_PERSON.PROVINCE_ID) PROVINCE_TH, ZIPCODE_ID, TELEPHONE, TIME_CONTACT_ID, (SELECT TIME_CONTACT_NAME FROM TB_TIME_CONTACT WHERE TB_TIME_CONTACT.TIME_CONTACT_ID = TB_PERSON.TIME_CONTACT_ID) TIME_CONTACT_NAME, BUDGET_ID, (SELECT BUDGET_NAME FROM TB_BUDGET WHERE TB_BUDGET.BUDGET_ID = TB_PERSON.BUDGET_ID) BUDGET_NAME, SUBSTAFFTYPE_ID, (SELECT SUBSTAFFTYPE_NAME FROM TB_SUBSTAFFTYPE WHERE TB_SUBSTAFFTYPE.SUBSTAFFTYPE_ID = TB_PERSON.SUBSTAFFTYPE_ID) SUBSTAFFTYPE_NAME, ADMIN_POSITION_ID, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = TB_PERSON.ADMIN_POSITION_ID) ADMIN_POSITION_NAME, POSITION_WORK_ID, (SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE TB_POSITION_WORK.POSITION_WORK_ID = TB_PERSON.POSITION_WORK_ID) POSITION_WORK_NAME, SPECIAL_NAME, TEACH_ISCED_ID, GRAD_ISCED_ID, GRAD_PROG_ID, GRAD_UNIV, GRAD_COUNTRY_ID, BRANCH_ID, (SELECT BRANCH_NAME FROM TB_BRANCH WHERE TB_BRANCH.BRANCH_ID = TB_PERSON.BRANCH_ID) BRANCH_NAME, RANK_ID, (SELECT RANK_NAME_TH FROM TB_RANK WHERE TB_RANK.SEQ = TB_PERSON.RANK_ID) RANK_NAME, GOT_ID, GET_ID, FACULTY_ID, (SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = TB_PERSON.FACULTY_ID) FACULTY_NAME, START_POSITION_WORK_ID, (SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE TB_POSITION_WORK.POSITION_WORK_ID = TB_PERSON.START_POSITION_WORK_ID) START_POSITION_WORK_NAME, CAMPUS_ID, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = TB_PERSON.CAMPUS_ID) CAMPUS_NAME, STATUS_ID, RELIGION_ID, (SELECT RELIGION_NAME FROM TB_RELIGION WHERE TB_RELIGION.RELIGION_ID = TB_PERSON.RELIGION_ID) RELIGION_NAME, (SELECT TB_POSITION_AND_SALARY.POSITION_ID FROM TB_POSITION_AND_SALARY WHERE TB_PERSON.CITIZEN_ID = TB_POSITION_AND_SALARY.CITIZEN_ID AND PRESENT = 1) POSITION_ID, (SELECT TB_POSITION.NAME FROM TB_POSITION_AND_SALARY, TB_POSITION WHERE TB_PERSON.CITIZEN_ID = TB_POSITION_AND_SALARY.CITIZEN_ID AND TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID AND TB_POSITION_AND_SALARY.PRESENT = 1) POSITION_NAME, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE ADMIN_POSITION_ID = TB_PERSON.ADMIN_POSITION_ID) AS ADMIN_POSITION_NAME FROM TB_PERSON WHERE CITIZEN_ID = '" + citizenID + "'"
                    "SELECT PS_PERSON.PS_CITIZEN_ID, PS_PERSON.PS_TITLE_ID, (SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TB_TITLENAME.TITLE_ID = PS_PERSON.PS_TITLE_ID) TITLE_NAME_TH, PS_PERSON.PS_FN_TH, PS_PERSON.PS_LN_TH, PS_GENDER_ID, (SELECT GENDER_NAME FROM TB_GENDER WHERE TB_GENDER.GENDER_ID = PS_PERSON.PS_GENDER_ID) GENDER_NAME, PS_BIRTHDAY_DATE, PS_BIRTHDAY_LONG, PS_RETIRE_DATE, PS_RETIRE_LONG, PS_INWORK_DATE, PS_PERSON.PS_STAFFTYPE_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE TB_STAFFTYPE.STAFFTYPE_ID = PS_PERSON.PS_STAFFTYPE_ID) STAFFTYPE_NAME, PS_DAD_FN, PS_DAD_LN, PS_MOM_FN, PS_MOM_LN, PS_MOM_LN_OLD, PS_LOV_FN, PS_LOV_LN, PS_LOV_LN_OLD, PS_PERSON.PS_MINISTRY_ID, (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE TB_MINISTRY.MINISTRY_ID = PS_PERSON.PS_MINISTRY_ID) MINISTRY_NAME, PS_DIVISION_ID, (SELECT DIVISION_NAME FROM TB_DIVISION WHERE TB_DIVISION.DIVISION_ID = PS_PERSON.PS_DIVISION_ID) DIVISION_NAME, PS_PASSWORD, PS_RACE_ID, (SELECT NATION_THA FROM TB_NATIONAL WHERE TB_NATIONAL.NATION_SEQ = PS_PERSON.PS_RACE_ID) RACE_THA, PS_NATION_ID, (SELECT NATION_THA FROM TB_NATIONAL WHERE TB_NATIONAL.NATION_SEQ = PS_PERSON.PS_NATION_ID) NATION_THA, PS_HOMEADD, PS_MOO, PS_STREET, PS_DISTRICT, (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE TB_DISTRICT.DISTRICT_ID = PS_PERSON.PS_DISTRICT) DISTRICT_TH, PS_AMPHUR_ID, (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE TB_AMPHUR.AMPHUR_ID = PS_PERSON.PS_AMPHUR_ID) AMPHUR_TH, PS_PROVINCE_ID, (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE TB_PROVINCE.PROVINCE_ID = PS_PERSON.PS_PROVINCE_ID) PROVINCE_TH, PS_ZIPCODE, PS_HOMEADD_NOW, PS_MOO_NOW, PS_STREET_NOW, PS_DISTRICT_ID_NOW, (SELECT DISTRICT_TH FROM TB_DISTRICT WHERE TB_DISTRICT.DISTRICT_ID = PS_PERSON.PS_DISTRICT_ID_NOW) DISTRICT_TH, PS_AMPHUR_ID_NOW, (SELECT AMPHUR_TH FROM TB_AMPHUR WHERE TB_AMPHUR.AMPHUR_ID = PS_PERSON.PS_AMPHUR_ID_NOW) AMPHUR_TH, PS_PROVINCE_ID_NOW, (SELECT PROVINCE_TH FROM TB_PROVINCE WHERE TB_PROVINCE.PROVINCE_ID = PS_PERSON.PS_PROVINCE_ID_NOW) PROVINCE_TH, PS_ZIPCODE_NOW, PS_PHONE, PS_BUDGET_ID, (SELECT BUDGET_NAME FROM TB_BUDGET WHERE TB_BUDGET.BUDGET_ID = PS_PERSON.PS_BUDGET_ID) BUDGET_NAME, PS_ADMIN_POS_ID, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID) ADMIN_POSITION_NAME, PS_SPECIAL_WORK, PS_TEACH_ISCED_ID, PS_FACULTY_ID, (SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = PS_PERSON.PS_FACULTY_ID) FACULTY_NAME, PS_CAMPUS_ID, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = PS_PERSON.PS_CAMPUS_ID) CAMPUS_NAME, PS_STATUS_ID, PS_RELIGION_ID, (SELECT RELIGION_NAME FROM TB_RELIGION WHERE TB_RELIGION.RELIGION_ID = PS_PERSON.PS_RELIGION_ID) RELIGION_NAME, (SELECT PS_POSITION_AND_SALARY.PS_POSITION_NO FROM PS_POSITION_AND_SALARY WHERE PS_PERSON.PS_CITIZEN_ID = PS_POSITION_AND_SALARY.PS_CITIZEN_ID AND PRESENT = 1) POSITION_NO, (SELECT TB_POSITION.NAME FROM PS_POSITION_AND_SALARY, TB_POSITION WHERE PS_PERSON.PS_CITIZEN_ID = PS_POSITION_AND_SALARY.PS_CITIZEN_ID AND PS_POSITION_AND_SALARY.PS_POSITION_NO = TB_POSITION.ID AND PS_POSITION_AND_SALARY.PRESENT = 1) POSITION_NAME FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + citizenID + "'"




                    , con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
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
                            person.BirthDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            person.BirthDateLong = reader.GetValue(i++).ToString();
                            person.RetireDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            person.RetireDateLong = reader.GetValue(i++).ToString();
                            person.InWorkDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
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
                            person.DivisionID = reader.GetValue(i++).ToString();
                            person.DivisionName = reader.GetValue(i++).ToString();
                            person.Password = reader.GetValue(i++).ToString();
                            person.RaceID = reader.GetValue(i++).ToString();
                            person.RaceName = reader.GetValue(i++).ToString();
                            person.NationID = reader.GetValue(i++).ToString();
                            person.NationName = reader.GetValue(i++).ToString();

                            person.HomeAdd = reader.GetValue(i++).ToString();
                            person.Moo = reader.GetValue(i++).ToString();
                            person.Street = reader.GetValue(i++).ToString();
                            person.DistrictID = reader.GetValue(i++).ToString();
                            person.DistrictName = reader.GetValue(i++).ToString();
                            person.AmphurID = reader.GetValue(i++).ToString();
                            person.AmphurName = reader.GetValue(i++).ToString();
                            person.ProvinceID = reader.GetValue(i++).ToString();
                            person.ProvinceName = reader.GetValue(i++).ToString();
                            person.ZipCode = reader.GetValue(i++).ToString();

                            person.HomeAddNow = reader.GetValue(i++).ToString();
                            person.MooNow = reader.GetValue(i++).ToString();
                            person.StreetNow = reader.GetValue(i++).ToString();
                            person.DistrictIDNow = reader.GetValue(i++).ToString();
                            person.DistrictNameNow = reader.GetValue(i++).ToString();
                            person.AmphurIDNow = reader.GetValue(i++).ToString();
                            person.AmphurNameNow = reader.GetValue(i++).ToString();
                            person.ProvinceIDNow = reader.GetValue(i++).ToString();
                            person.ProvinceNameNow = reader.GetValue(i++).ToString();
                            person.ZipCodeNow = reader.GetValue(i++).ToString();

                            person.Telephone = reader.GetValue(i++).ToString();
                            person.BudgetID = reader.GetValue(i++).ToString();
                            person.BudgetName = reader.GetValue(i++).ToString();
                            person.AdminPositionID = reader.GetValue(i++).ToString();
                            person.AdminPositionName = reader.GetValue(i++).ToString();
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

                            /*
                            person.CitizenID = reader.GetValue(0).ToString();
                            person.TitleID = reader.GetValue(1).ToString();
                            person.TitleName = reader.GetValue(2).ToString();     
                            person.FirstName = reader.GetValue(3).ToString();
                            person.LastName = reader.GetValue(4).ToString();
                            person.BirthDate = Util.PureDatabaseToThaiDate(reader.GetValue(5).ToString());
                            person.BirthDateLong = reader.GetValue(6).ToString();
                            person.RetireDate = Util.PureDatabaseToThaiDate(reader.GetValue(7).ToString());
                            person.RetireDateLong = reader.GetValue(8).ToString();
                            person.InWorkDate = Util.PureDatabaseToThaiDate(reader.GetValue(9).ToString());
                            person.StaffTypeID = reader.GetValue(10).ToString();
                            person.StaffTypeName = reader.GetValue(11).ToString();
                            person.FatherFirstName = reader.GetValue(12).ToString();
                            person.FatherLastName = reader.GetValue(13).ToString();
                            person.MotherFirstName = reader.GetValue(14).ToString();
                            person.MotherLastName = reader.GetValue(15).ToString();
                            person.MotherOldLastName = reader.GetValue(16).ToString();
                            person.CoupleFirstName = reader.GetValue(17).ToString();
                            person.CoupleLastName = reader.GetValue(18).ToString();
                            person.CoupleOldLastName = reader.GetValue(19).ToString();
                            person.MinistryID = reader.GetValue(20).ToString();
                            person.MinistryName = reader.GetValue(21).ToString();
                            person.DepartmentName = reader.GetValue(22).ToString();
                            person.Password = reader.GetValue(23).ToString();
                            person.SystemStatusID = reader.GetValue(24).ToString();
                            person.SystemStatusName = reader.GetValue(25).ToString();
                            person.GenderID = reader.GetValue(26).ToString();
                            person.GenderName = reader.GetValue(27).ToString();
                            person.NationID = reader.GetValue(28).ToString();
                            person.NationName = reader.GetValue(29).ToString();
                            person.HomeAdd = reader.GetValue(30).ToString();
                            person.Moo = reader.GetValue(31).ToString();
                            person.Street = reader.GetValue(32).ToString();
                            person.DistrictID = reader.GetValue(33).ToString();
                            person.DistrictName = reader.GetValue(34).ToString();
                            person.AmphurID = reader.GetValue(35).ToString();
                            person.AmphurName = reader.GetValue(36).ToString();
                            person.ProvinceID = reader.GetValue(37).ToString();
                            person.ProvinceName = reader.GetValue(38).ToString();
                            person.ZipCodeID = reader.GetValue(39).ToString();
                            person.Telephone = reader.GetValue(40).ToString();
                            person.TimeContactID = reader.GetValue(41).ToString();
                            person.TimeContactName = reader.GetValue(42).ToString();
                            person.BudgetID = reader.GetValue(43).ToString();
                            person.BudgetName = reader.GetValue(44).ToString();
                            person.SubStaffTypeID = reader.GetValue(45).ToString();
                            person.SubStaffTypeName = reader.GetValue(46).ToString();
                            person.AdminPositionID = reader.GetValue(47).ToString();
                            person.AdminPositionName = reader.GetValue(48).ToString();
                            person.PositionWorkID = reader.GetValue(49).ToString();
                            person.PositionWorkName = reader.GetValue(50).ToString();
                            person.SpecialName = reader.GetValue(51).ToString();
                            person.TeachISCEDID = reader.GetValue(52).ToString();
                            person.GradISCEDID = reader.GetValue(53).ToString();
                            person.GradProgID = reader.GetValue(54).ToString();
                            person.GradUniv = reader.GetValue(55).ToString();
                            person.GradCountryID = reader.GetValue(56).ToString();
                            person.BranchID = reader.GetValue(57).ToString();
                            person.BranchName = reader.GetValue(58).ToString();
                            person.RankID = reader.GetValue(59).ToString();
                            person.RankName = reader.GetValue(60).ToString();
                            person.GotID = reader.GetValue(61).ToString();
                            person.GetID = reader.GetValue(62).ToString();
                            person.FacultyID = reader.GetValue(63).ToString();
                            person.FacultyName = reader.GetValue(64).ToString();
                            person.StartPositionWorkID = reader.GetValue(65).ToString();
                            person.StartPositionWorkName = reader.GetValue(66).ToString();
                            person.CampusID = reader.GetValue(67).ToString();
                            person.CampusName = reader.GetValue(68).ToString();
                            person.StatusID = reader.GetValue(69).ToString();
                            person.ReligionID = reader.GetValue(70).ToString();
                            person.ReligionName = reader.GetValue(71).ToString();
                            person.PositionID = reader.GetValue(72).ToString();
                            person.PositionName = reader.GetValue(73).ToString();*/

                            return person;
                        }
                    }
                }
            }
            return null;
        }
        public static Form1Package GetForm1Package(string leaveID) {
            try {
                int.Parse(leaveID);
            } catch {
                return null;
            }
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT LEV_MAIN.*, LEV_FORM1.*, (SELECT LEAVE_TYPE_NAME FROM LEV_MAIN, LEV_TYPE WHERE LEV_MAIN.LEAVE_TYPE_ID = LEV_TYPE.LEAVE_TYPE_ID AND LEV_MAIN.LEAVE_ID = " + leaveID + ") LEAVE_TYPE_NAME, (SELECT LEAVE_ALLOW_NAME FROM LEV_MAIN, LEV_ALLOW WHERE CH_ALLOW = LEAVE_ALLOW_ID AND LEV_FORM1.LEAVE_ID = " + leaveID + ") LEAVE_ALLOW_NAME FROM LEV_MAIN, LEV_FORM1 WHERE LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID AND LEV_MAIN.LEAVE_ID = " + leaveID, con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            Form1Package form1Package = new Form1Package();
                            int i = 0;
                            form1Package.LeaveID = reader.GetValue(i++).ToString();
                            form1Package.LeaveTypeID = reader.GetValue(i++).ToString();
                            form1Package.LeaveState = reader.GetValue(i++).ToString();
                            form1Package.CitizenID = reader.GetValue(i++).ToString();
                            form1Package.RequestDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.FromDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.ToDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.TotalDay = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowID = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowPrefix = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowFirstName = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowLastName = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowPosition = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowComment = reader.GetValue(i++).ToString();
                            form1Package.CommanderLowDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.CommanderHighID = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighPrefix = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighFirstName = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighLastName = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighPosition = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighComment = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighAllow = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.PersonPrefix = reader.GetValue(i++).ToString();
                            form1Package.PersonFirstName = reader.GetValue(i++).ToString();
                            form1Package.PersonLastName = reader.GetValue(i++).ToString();
                            form1Package.PersonPosition = reader.GetValue(i++).ToString();
                            form1Package.PersonDepartment = reader.GetValue(i++).ToString();
                            form1Package.FormID = reader.GetValue(i++).ToString();
                            i++;
                            form1Package.Reason = reader.GetValue(i++).ToString();
                            form1Package.Contact = reader.GetValue(i++).ToString();
                            form1Package.Phone = reader.GetValue(i++).ToString();
                            form1Package.LastFromDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.LastToDate = Util.PureDatabaseToThaiDate(reader.GetValue(i++).ToString());
                            form1Package.LastTotalDay = reader.GetValue(i++).ToString();
                            form1Package.DoctorCertificate = reader.GetValue(i++).ToString();
                            form1Package.CountPast = reader.GetValue(i++).ToString();
                            form1Package.CountNow = reader.GetValue(i++).ToString();
                            form1Package.CountTotal = reader.GetValue(i++).ToString();
                            form1Package.LeaveTypeName = reader.GetValue(i++).ToString();
                            form1Package.CommanderHighAllowName = reader.GetValue(i++).ToString();
                            

                            return form1Package;
                        }
                    }
                }
            }
            return null;
        }
        public static int GetLeaveRequiredCountByCommanderLow(string citizenID) {
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEV_MAIN.LEAVE_ID) FROM LEV_MAIN WHERE LEV_MAIN.LEAVE_TYPE_ID in(1,2,3) AND LEV_MAIN.LEAVE_STATE = 1 AND LEV_MAIN.CL_ID = '" + citizenID + "'", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            int count = int.Parse(reader.GetValue(0).ToString());
                            return count;
                        }
                    }
                }
            }
            return -1;
        }
        public static int GetLeaveRequiredCountByCommanderHigh(string citizenID) {
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEV_MAIN.LEAVE_ID) FROM LEV_MAIN WHERE LEV_MAIN.LEAVE_TYPE_ID in(1,2,3) AND LEV_MAIN.LEAVE_STATE = 2 AND LEV_MAIN.CH_ID = '" + citizenID + "'", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            int count = int.Parse(reader.GetValue(0).ToString());
                            return count;
                        }
                    }
                }
            }
            return -1;
        }
        public static void AddCounter() {
            ExecuteNonQuery("UPDATE TB_WEB SET COUNTER = COUNTER+1 WHERE ID = 1");
        }
        public static string GetPersonImageFileName(string citizenID) {
            string fileName = "";
            using (OleDbConnection con = new OleDbConnection(CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "' AND PRESENT = 1", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            fileName = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return fileName;
        }

    }
}