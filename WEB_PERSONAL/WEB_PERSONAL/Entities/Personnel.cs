using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WEB_PERSONAL.Entities {
    public class PS_PERSON {
        public string PS_CITIZEN_ID { get; set; }
        public int PS_ID { get; set; }
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
        public string PS_NATION_ID { get; set; }
        public int PS_BLOOD_ID { get; set; }
        public string PS_EMAIL { get; set; }
        public string PS_PHONE { get; set; }
        public string PS_TELEPHONE_WORK { get; set; }
        public int PS_RELIGION_ID { get; set; }
        public int PS_STATUS_ID { get; set; }
        public string PS_DAD_FN { get; set; }
        public string PS_DAD_LN { get; set; }
        public string PS_MOM_FN { get; set; }
        public string PS_MOM_LN { get; set; }
        public string PS_MOM_LN_OLD { get; set; }
        public string PS_LOV_FN { get; set; }
        public string PS_LOV_LN { get; set; }
        public string PS_LOV_LN_OLD { get; set; }
        public string PS_HOMEADD { get; set; }
        public string PS_SOI { get; set; }
        public string PS_MOO { get; set; }
        public string PS_STREET { get; set; }
        public int PS_PROVINCE_ID { get; set; }
        public int PS_AMPHUR_ID { get; set; }
        public int PS_DISTRICT { get; set; }
        public string PS_ZIPCODE { get; set; }
        public int PS_COUNTRY_ID { get; set; }
        public string PS_STATE { get; set; }
        public string PS_HOMEADD_NOW { get; set; }
        public string PS_SOI_NOW { get; set; }
        public string PS_MOO_NOW { get; set; }
        public string PS_STREET_NOW { get; set; }
        public int PS_PROVINCE_ID_NOW { get; set; }
        public int PS_AMPHUR_ID_NOW { get; set; }
        public int PS_DISTRICT_ID_NOW { get; set; }
        public string PS_ZIPCODE_NOW { get; set; }
        public int PS_COUNTRY_ID_NOW { get; set; }
        public string PS_STATE_NOW { get; set; }
        public int PS_CAMPUS_ID { get; set; }
        public int PS_FACULTY_ID { get; set; }
        public int PS_DIVISION_ID { get; set; }
        public int PS_WORK_DIVISION_ID { get; set; }
        public int PS_STAFFTYPE_ID { get; set; }
        public int PS_BUDGET_ID { get; set; }
        public string PS_ADMIN_POS_ID { get; set; }
        public int PS_WORK_POS_ID { get; set; }
        public int PS_ACAD_POS_ID { get; set; }
        public DateTime PS_INWORK_DATE { get; set; }
        public DateTime PS_RETIRE_DATE { get; set; }
        public string PS_RETIRE_LONG { get; set; }
        public string PS_SPECIAL_WORK { get; set; }
        public string PS_TEACH_ISCED_ID { get; set; }
        public string PS_PASSWORD { get; set; }
        public string PS_POSITION_ID { get; set; }
        public int PS_PIG_ID { get; set; }
        public int PS_SW_ID { get; set; }
        public int PS_RANK_ID { get; set; }

        public PS_PERSON() { }
        public PS_PERSON(string PS_CITIZEN_ID, int PS_ID, int PS_MINISTRY_ID, string PS_GROM, int PS_TITLE_ID, string PS_FN_TH, string PS_FN_EN, string PS_LN_TH, string PS_LN_EN, int PS_GENDER_ID, DateTime PS_BIRTHDAY_DATE, string PS_BIRTHDAY_LONG, int PS_RACE_ID, string PS_NATION_ID, int PS_BLOOD_ID, string PS_EMAIL, string PS_PHONE, string PS_TELEPHONE_WORK, int PS_RELIGION_ID, int PS_STATUS_ID, string PS_DAD_FN, string PS_DAD_LN, string PS_MOM_FN, string PS_MOM_LN, string PS_MOM_LN_OLD, string PS_LOV_FN, string PS_LOV_LN, string PS_LOV_LN_OLD, string PS_HOMEADD, string PS_SOI, string PS_MOO, string PS_STREET, int PS_PROVINCE_ID, int PS_AMPHUR_ID, int PS_DISTRICT, string PS_ZIPCODE, int PS_COUNTRY_ID, string PS_STATE, string PS_HOMEADD_NOW, string PS_SOI_NOW, string PS_MOO_NOW, string PS_STREET_NOW, int PS_PROVINCE_ID_NOW, int PS_AMPHUR_ID_NOW, int PS_DISTRICT_ID_NOW, string PS_ZIPCODE_NOW, int PS_COUNTRY_ID_NOW, string PS_STATE_NOW, int PS_CAMPUS_ID, int PS_FACULTY_ID, int PS_DIVISION_ID, int PS_WORK_DIVISION_ID, int PS_STAFFTYPE_ID, int PS_BUDGET_ID, string PS_ADMIN_POS_ID, int PS_WORK_POS_ID, int PS_ACAD_POS_ID, DateTime PS_INWORK_DATE, DateTime PS_RETIRE_DATE, string PS_RETIRE_LONG, string PS_SPECIAL_WORK, string PS_TEACH_ISCED_ID, string PS_PASSWORD, string PS_POSITION_ID, int PS_PIG_ID, int PS_SW_ID, int PS_RANK_ID) {
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_ID = PS_ID;
            this.PS_MINISTRY_ID = PS_MINISTRY_ID;
            this.PS_GROM = PS_GROM;
            this.PS_TITLE_ID = PS_TITLE_ID;
            this.PS_FN_TH = PS_FN_TH;
            this.PS_FN_EN = PS_FN_EN;
            this.PS_LN_TH = PS_LN_TH;
            this.PS_LN_EN = PS_LN_EN;
            this.PS_GENDER_ID = PS_GENDER_ID;
            this.PS_BIRTHDAY_DATE = PS_BIRTHDAY_DATE;
            this.PS_BIRTHDAY_LONG = PS_BIRTHDAY_LONG;
            this.PS_RACE_ID = PS_RACE_ID;
            this.PS_NATION_ID = PS_NATION_ID;
            this.PS_BLOOD_ID = PS_BLOOD_ID;
            this.PS_EMAIL = PS_EMAIL;
            this.PS_PHONE = PS_PHONE;
            this.PS_TELEPHONE_WORK = PS_TELEPHONE_WORK;
            this.PS_RELIGION_ID = PS_RELIGION_ID;
            this.PS_STATUS_ID = PS_STATUS_ID;
            this.PS_DAD_FN = PS_DAD_FN;
            this.PS_DAD_LN = PS_DAD_LN;
            this.PS_MOM_FN = PS_MOM_FN;
            this.PS_MOM_LN = PS_MOM_LN;
            this.PS_MOM_LN_OLD = PS_MOM_LN_OLD;
            this.PS_LOV_FN = PS_LOV_FN;
            this.PS_LOV_LN = PS_LOV_LN;
            this.PS_LOV_LN_OLD = PS_LOV_LN_OLD;
            this.PS_HOMEADD = PS_HOMEADD;
            this.PS_SOI = PS_SOI;
            this.PS_MOO = PS_MOO;
            this.PS_STREET = PS_STREET;
            this.PS_PROVINCE_ID = PS_PROVINCE_ID;
            this.PS_AMPHUR_ID = PS_AMPHUR_ID;
            this.PS_DISTRICT = PS_DISTRICT;
            this.PS_ZIPCODE = PS_ZIPCODE;
            this.PS_COUNTRY_ID = PS_COUNTRY_ID;
            this.PS_STATE = PS_STATE;
            this.PS_HOMEADD_NOW = PS_HOMEADD_NOW;
            this.PS_SOI_NOW = PS_SOI_NOW;
            this.PS_MOO_NOW = PS_MOO_NOW;
            this.PS_STREET_NOW = PS_STREET_NOW;
            this.PS_PROVINCE_ID_NOW = PS_PROVINCE_ID_NOW;
            this.PS_AMPHUR_ID_NOW = PS_AMPHUR_ID_NOW;
            this.PS_DISTRICT_ID_NOW = PS_DISTRICT_ID_NOW;
            this.PS_ZIPCODE_NOW = PS_ZIPCODE_NOW;
            this.PS_COUNTRY_ID_NOW = PS_COUNTRY_ID_NOW;
            this.PS_STATE_NOW = PS_STATE_NOW;
            this.PS_CAMPUS_ID = PS_CAMPUS_ID;
            this.PS_FACULTY_ID = PS_FACULTY_ID;
            this.PS_DIVISION_ID = PS_DIVISION_ID;
            this.PS_WORK_DIVISION_ID = PS_WORK_DIVISION_ID;
            this.PS_STAFFTYPE_ID = PS_STAFFTYPE_ID;
            this.PS_BUDGET_ID = PS_BUDGET_ID;
            this.PS_ADMIN_POS_ID = PS_ADMIN_POS_ID;
            this.PS_WORK_POS_ID = PS_WORK_POS_ID;
            this.PS_ACAD_POS_ID = PS_ACAD_POS_ID;
            this.PS_INWORK_DATE = PS_INWORK_DATE;
            this.PS_RETIRE_DATE = PS_RETIRE_DATE;
            this.PS_RETIRE_LONG = PS_RETIRE_LONG;
            this.PS_SPECIAL_WORK = PS_SPECIAL_WORK;
            this.PS_TEACH_ISCED_ID = PS_TEACH_ISCED_ID;
            this.PS_PASSWORD = PS_PASSWORD;
            this.PS_POSITION_ID = PS_POSITION_ID;
            this.PS_PIG_ID = PS_PIG_ID;   
            this.PS_SW_ID = PS_SW_ID;
            this.PS_RANK_ID = PS_RANK_ID;
        }

        public int INSERT_PS_PERSON() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_PERSON (PS_CITIZEN_ID,PS_MINISTRY_ID,PS_GROM,PS_TITLE_ID,PS_FN_TH,PS_FN_EN,PS_LN_TH,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_BIRTHDAY_LONG,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK,PS_RELIGION_ID,PS_STATUS_ID,PS_DAD_FN,PS_DAD_LN,PS_MOM_FN,PS_MOM_LN,PS_MOM_LN_OLD,PS_LOV_FN,PS_LOV_LN,PS_LOV_LN_OLD,PS_HOMEADD,PS_SOI,PS_MOO,PS_STREET,PS_PROVINCE_ID,PS_AMPHUR_ID,PS_DISTRICT,PS_ZIPCODE,PS_COUNTRY_ID,PS_STATE,PS_HOMEADD_NOW,PS_SOI_NOW,PS_MOO_NOW,PS_STREET_NOW,PS_PROVINCE_ID_NOW,PS_AMPHUR_ID_NOW,PS_DISTRICT_ID_NOW,PS_ZIPCODE_NOW,PS_COUNTRY_ID_NOW,PS_STATE_NOW,PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_ADMIN_POS_ID,PS_WORK_POS_ID,PS_ACAD_POS_ID,PS_INWORK_DATE,PS_RETIRE_DATE,PS_RETIRE_LONG,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID,PS_PASSWORD) VALUES (:PS_CITIZEN_ID,:PS_MINISTRY_ID,:PS_GROM,:PS_TITLE_ID,:PS_FN_TH,:PS_FN_EN,:PS_LN_TH,:PS_LN_EN,:PS_GENDER_ID,:PS_BIRTHDAY_DATE,:PS_BIRTHDAY_LONG,:PS_RACE_ID,:PS_NATION_ID,:PS_BLOOD_ID,:PS_EMAIL,:PS_PHONE,:PS_TELEPHONE_WORK,:PS_RELIGION_ID,:PS_STATUS_ID,:PS_DAD_FN, :PS_DAD_LN, :PS_MOM_FN, :PS_MOM_LN, :PS_MOM_LN_OLD, :PS_LOV_FN, :PS_LOV_LN, :PS_LOV_LN_OLD, :PS_HOMEADD, :PS_SOI, :PS_MOO, :PS_STREET, :PS_PROVINCE_ID, :PS_AMPHUR_ID, :PS_DISTRICT, :PS_ZIPCODE, :PS_COUNTRY_ID, :PS_STATE, :PS_HOMEADD_NOW, :PS_SOI_NOW, :PS_MOO_NOW, :PS_STREET_NOW, :PS_PROVINCE_ID_NOW, :PS_AMPHUR_ID_NOW, :PS_DISTRICT_ID_NOW, :PS_ZIPCODE_NOW, :PS_COUNTRY_ID_NOW, :PS_STATE_NOW, :PS_CAMPUS_ID, :PS_FACULTY_ID, :PS_DIVISION_ID, :PS_WORK_DIVISION_ID, :PS_STAFFTYPE_ID, :PS_BUDGET_ID, :PS_ADMIN_POS_ID, :PS_WORK_POS_ID, :PS_ACAD_POS_ID, :PS_INWORK_DATE, :PS_RETIRE_DATE, :PS_RETIRE_LONG, :PS_SPECIAL_WORK, :PS_TEACH_ISCED_ID, :PS_PASSWORD)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_MINISTRY_ID", PS_MINISTRY_ID));
                command.Parameters.Add(new OracleParameter("PS_GROM", PS_GROM));
                command.Parameters.Add(new OracleParameter("PS_TITLE_ID", PS_TITLE_ID));
                command.Parameters.Add(new OracleParameter("PS_FN_TH", PS_FN_TH));
                command.Parameters.Add(new OracleParameter("PS_FN_EN", PS_FN_EN));
                command.Parameters.Add(new OracleParameter("PS_LN_TH", PS_LN_TH));
                command.Parameters.Add(new OracleParameter("PS_LN_EN", PS_LN_EN));
                command.Parameters.Add(new OracleParameter("PS_GENDER_ID", PS_GENDER_ID));
                command.Parameters.Add(new OracleParameter("PS_BIRTHDAY_DATE", PS_BIRTHDAY_DATE));
                command.Parameters.Add(new OracleParameter("PS_BIRTHDAY_LONG", PS_BIRTHDAY_LONG));
                command.Parameters.Add(new OracleParameter("PS_RACE_ID", PS_RACE_ID));
                command.Parameters.Add(new OracleParameter("PS_NATION_ID", PS_NATION_ID));
                command.Parameters.Add(new OracleParameter("PS_BLOOD_ID", PS_BLOOD_ID));
                command.Parameters.Add(new OracleParameter("PS_EMAIL", PS_EMAIL));
                command.Parameters.Add(new OracleParameter("PS_PHONE", PS_PHONE));
                command.Parameters.Add(new OracleParameter("PS_TELEPHONE_WORK", PS_TELEPHONE_WORK));
                command.Parameters.Add(new OracleParameter("PS_RELIGION_ID", PS_RELIGION_ID));
                command.Parameters.Add(new OracleParameter("PS_STATUS_ID", PS_STATUS_ID));
                command.Parameters.Add(new OracleParameter("PS_DAD_FN", PS_DAD_FN));
                command.Parameters.Add(new OracleParameter("PS_DAD_LN", PS_DAD_LN));
                command.Parameters.Add(new OracleParameter("PS_MOM_FN", PS_MOM_FN));
                command.Parameters.Add(new OracleParameter("PS_MOM_LN", PS_MOM_LN));
                command.Parameters.Add(new OracleParameter("PS_MOM_LN_OLD", PS_MOM_LN_OLD));
                command.Parameters.Add(new OracleParameter("PS_LOV_FN", PS_LOV_FN));
                command.Parameters.Add(new OracleParameter("PS_LOV_LN", PS_LOV_LN));
                command.Parameters.Add(new OracleParameter("PS_LOV_LN_OLD", PS_LOV_LN_OLD));
                command.Parameters.Add(new OracleParameter("PS_HOMEADD", PS_HOMEADD));
                command.Parameters.Add(new OracleParameter("PS_SOI", PS_SOI));
                command.Parameters.Add(new OracleParameter("PS_MOO", PS_MOO));
                command.Parameters.Add(new OracleParameter("PS_STREET", PS_STREET));
                command.Parameters.Add(new OracleParameter("PS_PROVINCE_ID", PS_PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("PS_AMPHUR_ID", PS_AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("PS_DISTRICT", PS_DISTRICT));
                command.Parameters.Add(new OracleParameter("PS_ZIPCODE", PS_ZIPCODE));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", PS_COUNTRY_ID));
                command.Parameters.Add(new OracleParameter("PS_STATE", PS_STATE));
                command.Parameters.Add(new OracleParameter("PS_HOMEADD_NOW", PS_HOMEADD_NOW));
                command.Parameters.Add(new OracleParameter("PS_SOI_NOW", PS_SOI_NOW));
                command.Parameters.Add(new OracleParameter("PS_MOO_NOW", PS_MOO_NOW));
                command.Parameters.Add(new OracleParameter("PS_STREET_NOW", PS_STREET_NOW));
                command.Parameters.Add(new OracleParameter("PS_PROVINCE_ID_NOW", PS_PROVINCE_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_AMPHUR_ID_NOW", PS_AMPHUR_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_DISTRICT_ID_NOW", PS_DISTRICT_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_ZIPCODE_NOW", PS_ZIPCODE_NOW));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID_NOW", PS_COUNTRY_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_STATE_NOW", PS_STATE_NOW));
                command.Parameters.Add(new OracleParameter("PS_CAMPUS_ID", PS_CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("PS_FACULTY_ID", PS_FACULTY_ID));
                command.Parameters.Add(new OracleParameter("PS_DIVISION_ID", PS_DIVISION_ID));
                command.Parameters.Add(new OracleParameter("PS_WORK_DIVISION_ID", PS_WORK_DIVISION_ID));
                command.Parameters.Add(new OracleParameter("PS_STAFFTYPE_ID", PS_STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("PS_BUDGET_ID", PS_BUDGET_ID));
                command.Parameters.Add(new OracleParameter("PS_ADMIN_POS_ID", PS_ADMIN_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_WORK_POS_ID", PS_WORK_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_ACAD_POS_ID", PS_ACAD_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_INWORK_DATE", PS_INWORK_DATE));
                command.Parameters.Add(new OracleParameter("PS_RETIRE_DATE", PS_RETIRE_DATE));
                command.Parameters.Add(new OracleParameter("PS_RETIRE_LONG", PS_RETIRE_LONG));
                command.Parameters.Add(new OracleParameter("PS_SPECIAL_WORK", PS_SPECIAL_WORK));
                command.Parameters.Add(new OracleParameter("PS_TEACH_ISCED_ID", PS_TEACH_ISCED_ID));
                command.Parameters.Add(new OracleParameter("PS_PASSWORD", PS_PASSWORD));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_PERSON() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_PERSON Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_MINISTRY_ID = :PS_MINISTRY_ID  ,";
            query += " PS_GROM = :PS_GROM ,";
            query += " PS_TITLE_ID = :PS_TITLE_ID ,";
            query += " PS_FN_TH = :PS_FN_TH ,";
            query += " PS_FN_EN = :PS_FN_EN ,";
            query += " PS_LN_TH = :PS_LN_TH ,";
            query += " PS_LN_EN = :PS_LN_EN ,";
            query += " PS_GENDER_ID = :PS_GENDER_ID ,";
            query += " PS_BIRTHDAY_DATE = :PS_BIRTHDAY_DATE ,";
            query += " PS_BIRTHDAY_LONG = :PS_BIRTHDAY_LONG ,";
            query += " PS_RACE_ID = :PS_RACE_ID ,";
            query += " PS_NATION_ID = :PS_NATION_ID ,";
            query += " PS_BLOOD_ID = :PS_BLOOD_ID ,";
            query += " PS_EMAIL = :PS_EMAIL ,";
            query += " PS_PHONE = :PS_PHONE ,";
            query += " PS_TELEPHONE_WORK = :PS_TELEPHONE_WORK ,";
            query += " PS_RELIGION_ID = :PS_RELIGION_ID ,";
            query += " PS_STATUS_ID = :PS_STATUS_ID ,";
            query += " PS_DAD_FN = :PS_DAD_FN ,";
            query += " PS_DAD_LN = :PS_DAD_LN    ,";
            query += " PS_MOM_FN = :PS_MOM_FN ,";
            query += " PS_MOM_LN = :PS_MOM_LN ,";
            query += " PS_MOM_LN_OLD = :PS_MOM_LN_OLD ,";
            query += " PS_LOV_FN = :PS_LOV_FN ,";
            query += " PS_LOV_LN = :PS_LOV_LN ,";
            query += " PS_LOV_LN_OLD = :PS_LOV_LN_OLD ,";
            query += " PS_HOMEADD = :PS_HOMEADD ,";
            query += " PS_SOI = :PS_SOI ,";
            query += " PS_MOO = :PS_MOO ,";
            query += " PS_STREET = :PS_STREET ,";
            query += " PS_PROVINCE_ID = :PS_PROVINCE_ID ,";
            query += " PS_AMPHUR_ID = :PS_AMPHUR_ID ,";
            query += " PS_DISTRICT = :PS_DISTRICT ,";
            query += " PS_ZIPCODE = :PS_ZIPCODE ,";
            query += " PS_COUNTRY_ID = :PS_COUNTRY_ID ,";
            query += " PS_STATE = :PS_STATE ,";
            query += " PS_HOMEADD_NOW = :PS_HOMEADD_NOW ,";
            query += " PS_SOI_NOW = :PS_SOI_NOW ,";
            query += " PS_MOO_NOW = :PS_MOO_NOW ,";
            query += " PS_STREET_NOW = :PS_STREET_NOW ,";
            query += " PS_PROVINCE_ID_NOW = :PS_PROVINCE_ID_NOW ,";
            query += " PS_AMPHUR_ID_NOW = :PS_AMPHUR_ID_NOW ,";
            query += " PS_DISTRICT_ID_NOW = :PS_DISTRICT_ID_NOW ,";
            query += " PS_ZIPCODE_NOW = :PS_ZIPCODE_NOW ,";
            query += " PS_COUNTRY_ID_NOW = :PS_COUNTRY_ID_NOW ,";
            query += " PS_STATE_NOW = :PS_STATE_NOW ,";
            query += " PS_CAMPUS_ID = :PS_CAMPUS_ID ,";
            query += " PS_FACULTY_ID = :PS_FACULTY_ID ,";
            query += " PS_DIVISION_ID = :PS_DIVISION_ID ,";
            query += " PS_WORK_DIVISION_ID = :PS_WORK_DIVISION_ID ,";
            query += " PS_STAFFTYPE_ID = :PS_STAFFTYPE_ID ,";
            query += " PS_BUDGET_ID = :PS_BUDGET_ID ,";
            query += " PS_ADMIN_POS_ID = :PS_ADMIN_POS_ID ,";
            query += " PS_WORK_POS_ID = :PS_WORK_POS_ID ,";
            query += " PS_ACAD_POS_ID = :PS_ACAD_POS_ID ,";
            query += " PS_INWORK_DATE = :PS_INWORK_DATE ,";
            query += " PS_RETIRE_DATE = :PS_RETIRE_DATE ,";
            query += " PS_RETIRE_LONG = :PS_RETIRE_LONG ,";
            query += " PS_SPECIAL_WORK = :PS_SPECIAL_WORK ,";
            query += " PS_TEACH_ISCED_ID = :PS_TEACH_ISCED_ID ,";
            query += " PS_PASSWORD = :PS_PASSWORD";
            query += " where PS_ID  = :PS_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_MINISTRY_ID", PS_MINISTRY_ID));
                command.Parameters.Add(new OracleParameter("PS_GROM", PS_GROM));
                command.Parameters.Add(new OracleParameter("PS_TITLE_ID", PS_TITLE_ID));
                command.Parameters.Add(new OracleParameter("PS_FN_TH", PS_FN_TH));
                command.Parameters.Add(new OracleParameter("PS_FN_EN", PS_FN_EN));
                command.Parameters.Add(new OracleParameter("PS_LN_TH", PS_LN_TH));
                command.Parameters.Add(new OracleParameter("PS_LN_EN", PS_LN_EN));
                command.Parameters.Add(new OracleParameter("PS_GENDER_ID", PS_GENDER_ID));
                command.Parameters.Add(new OracleParameter("PS_BIRTHDAY_DATE", PS_BIRTHDAY_DATE));
                command.Parameters.Add(new OracleParameter("PS_BIRTHDAY_LONG", PS_BIRTHDAY_LONG));
                command.Parameters.Add(new OracleParameter("PS_RACE_ID", PS_RACE_ID));
                command.Parameters.Add(new OracleParameter("PS_NATION_ID", PS_NATION_ID));
                command.Parameters.Add(new OracleParameter("PS_BLOOD_ID", PS_BLOOD_ID));
                command.Parameters.Add(new OracleParameter("PS_EMAIL", PS_EMAIL));
                command.Parameters.Add(new OracleParameter("PS_PHONE", PS_PHONE));
                command.Parameters.Add(new OracleParameter("PS_TELEPHONE_WORK", PS_TELEPHONE_WORK));
                command.Parameters.Add(new OracleParameter("PS_RELIGION_ID", PS_RELIGION_ID));
                command.Parameters.Add(new OracleParameter("PS_STATUS_ID", PS_STATUS_ID));
                command.Parameters.Add(new OracleParameter("PS_DAD_FN", PS_DAD_FN));
                command.Parameters.Add(new OracleParameter("PS_DAD_LN", PS_DAD_LN));
                command.Parameters.Add(new OracleParameter("PS_MOM_FN", PS_MOM_FN));
                command.Parameters.Add(new OracleParameter("PS_MOM_LN", PS_MOM_LN));
                command.Parameters.Add(new OracleParameter("PS_MOM_LN_OLD", PS_MOM_LN_OLD));
                command.Parameters.Add(new OracleParameter("PS_LOV_FN", PS_LOV_FN));
                command.Parameters.Add(new OracleParameter("PS_LOV_LN", PS_LOV_LN));
                command.Parameters.Add(new OracleParameter("PS_LOV_LN_OLD", PS_LOV_LN_OLD));
                command.Parameters.Add(new OracleParameter("PS_HOMEADD", PS_HOMEADD));
                command.Parameters.Add(new OracleParameter("PS_SOI", PS_SOI));
                command.Parameters.Add(new OracleParameter("PS_MOO", PS_MOO));
                command.Parameters.Add(new OracleParameter("PS_STREET", PS_STREET));
                command.Parameters.Add(new OracleParameter("PS_PROVINCE_ID", PS_PROVINCE_ID));
                command.Parameters.Add(new OracleParameter("PS_AMPHUR_ID", PS_AMPHUR_ID));
                command.Parameters.Add(new OracleParameter("PS_DISTRICT", PS_DISTRICT));
                command.Parameters.Add(new OracleParameter("PS_ZIPCODE", PS_ZIPCODE));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", PS_COUNTRY_ID));
                command.Parameters.Add(new OracleParameter("PS_STATE", PS_STATE));
                command.Parameters.Add(new OracleParameter("PS_HOMEADD_NOW", PS_HOMEADD_NOW));
                command.Parameters.Add(new OracleParameter("PS_SOI_NOW", PS_SOI_NOW));
                command.Parameters.Add(new OracleParameter("PS_MOO_NOW", PS_MOO_NOW));
                command.Parameters.Add(new OracleParameter("PS_STREET_NOW", PS_STREET_NOW));
                command.Parameters.Add(new OracleParameter("PS_PROVINCE_ID_NOW", PS_PROVINCE_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_AMPHUR_ID_NOW", PS_AMPHUR_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_DISTRICT_ID_NOW", PS_DISTRICT_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_ZIPCODE_NOW", PS_ZIPCODE_NOW));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID_NOW", PS_COUNTRY_ID_NOW));
                command.Parameters.Add(new OracleParameter("PS_STATE_NOW", PS_STATE_NOW));
                command.Parameters.Add(new OracleParameter("PS_CAMPUS_ID", PS_CAMPUS_ID));
                command.Parameters.Add(new OracleParameter("PS_FACULTY_ID", PS_FACULTY_ID));
                command.Parameters.Add(new OracleParameter("PS_DIVISION_ID", PS_DIVISION_ID));
                command.Parameters.Add(new OracleParameter("PS_WORK_DIVISION_ID", PS_WORK_DIVISION_ID));
                command.Parameters.Add(new OracleParameter("PS_STAFFTYPE_ID", PS_STAFFTYPE_ID));
                command.Parameters.Add(new OracleParameter("PS_BUDGET_ID", PS_BUDGET_ID));
                command.Parameters.Add(new OracleParameter("PS_ADMIN_POS_ID", PS_ADMIN_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_WORK_POS_ID", PS_WORK_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_ACAD_POS_ID", PS_ACAD_POS_ID));
                command.Parameters.Add(new OracleParameter("PS_INWORK_DATE", PS_INWORK_DATE));
                command.Parameters.Add(new OracleParameter("PS_RETIRE_DATE", PS_RETIRE_DATE));
                command.Parameters.Add(new OracleParameter("PS_RETIRE_LONG", PS_RETIRE_LONG));
                command.Parameters.Add(new OracleParameter("PS_SPECIAL_WORK", PS_SPECIAL_WORK));
                command.Parameters.Add(new OracleParameter("PS_TEACH_ISCED_ID", PS_TEACH_ISCED_ID));
                command.Parameters.Add(new OracleParameter("PS_PASSWORD", PS_PASSWORD));
                command.Parameters.Add(new OracleParameter("PS_ID", PS_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_PERSON() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_PERSON where PS_CITIZEN_ID = :PS_CITIZEN_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
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
            OracleCommand command = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = :PS_CITIZEN_ID ", conn);

            // Add the parameters.
            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string count = (string)command.ExecuteScalar();
                if (Convert.ToInt64(count) >= 1)
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

    public class PS_STUDY {
        public int PS_STUDY_ID { get; set; }
        public string PS_CITIZEN_ID { get; set; }
        public int PS_DEGREE_ID { get; set; }
        public string PS_UNIV_NAME { get; set; }
        public int PS_FROM_MONTH { get; set; }
        public int PS_FROM_YEAR { get; set; }
        public int PS_TO_MONTH { get; set; }
        public int PS_TO_YEAR { get; set; }
        public string PS_QUALIFICATION { get; set; }
        public string PS_MAJOR { get; set; }
        public int PS_COUNTRY_ID { get; set; }

        public PS_STUDY() { }
        public PS_STUDY(int PS_STUDY_ID, string PS_CITIZEN_ID, int PS_DEGREE_ID, string PS_UNIV_NAME, int PS_FROM_MONTH, int PS_FROM_YEAR, int PS_TO_MONTH, int PS_TO_YEAR, string PS_QUALIFICATION, string PS_MAJOR, int PS_COUNTRY_ID) {
            this.PS_STUDY_ID = PS_STUDY_ID;
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_DEGREE_ID = PS_DEGREE_ID;
            this.PS_UNIV_NAME = PS_UNIV_NAME;
            this.PS_FROM_MONTH = PS_FROM_MONTH;
            this.PS_FROM_YEAR = PS_FROM_YEAR;
            this.PS_TO_MONTH = PS_TO_MONTH;
            this.PS_TO_YEAR = PS_TO_YEAR;
            this.PS_QUALIFICATION = PS_QUALIFICATION;
            this.PS_MAJOR = PS_MAJOR;
            this.PS_COUNTRY_ID = PS_COUNTRY_ID;
        }

        public DataTable SELECT_PS_STUDY(string PS_CITIZEN_ID, string PS_DEGREE_ID, string PS_UNIV_NAME, string PS_FROM_MONTH, string PS_FROM_YEAR, string PS_TO_MONTH, string PS_TO_YEAR, string PS_QUALIFICATION, string PS_MAJOR, string PS_COUNTRY_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM PS_STUDY ";
            if (!string.IsNullOrEmpty(PS_CITIZEN_ID) || !string.IsNullOrEmpty(PS_DEGREE_ID) || !string.IsNullOrEmpty(PS_UNIV_NAME) || !string.IsNullOrEmpty(PS_FROM_MONTH) || !string.IsNullOrEmpty(PS_FROM_YEAR) || !string.IsNullOrEmpty(PS_TO_MONTH) || !string.IsNullOrEmpty(PS_TO_YEAR) || !string.IsNullOrEmpty(PS_QUALIFICATION) || !string.IsNullOrEmpty(PS_MAJOR) || !string.IsNullOrEmpty(PS_COUNTRY_ID))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    query += " and PS_CITIZEN_ID like :PS_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(PS_DEGREE_ID))
                {
                    query += " and PS_DEGREE_ID like :PS_DEGREE_ID ";
                }
                if (!string.IsNullOrEmpty(PS_UNIV_NAME))
                {
                    query += " and PS_UNIV_NAME like :PS_UNIV_NAME ";
                }
                if (!string.IsNullOrEmpty(PS_FROM_MONTH))
                {
                    query += " and PS_FROM_MONTH like :PS_FROM_MONTH ";
                }
                if (!string.IsNullOrEmpty(PS_FROM_YEAR))
                {
                    query += " and PS_FROM_YEAR like :PS_FROM_YEAR ";
                }
                if (!string.IsNullOrEmpty(PS_TO_MONTH))
                {
                    query += " and PS_TO_MONTH like :PS_TO_MONTH ";
                }
                if (!string.IsNullOrEmpty(PS_TO_YEAR))
                {
                    query += " and PS_TO_YEAR like :PS_TO_YEAR ";
                }
                if (!string.IsNullOrEmpty(PS_QUALIFICATION))
                {
                    query += " and PS_QUALIFICATION like :PS_QUALIFICATION ";
                }
                if (!string.IsNullOrEmpty(PS_MAJOR))
                {
                    query += " and PS_MAJOR like :PS_MAJOR ";
                }
                if (!string.IsNullOrEmpty(PS_COUNTRY_ID))
                {
                    query += " and PS_COUNTRY_ID like :PS_COUNTRY_ID ";
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
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(PS_DEGREE_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_DEGREE_ID", PS_DEGREE_ID));
                }
                if (!string.IsNullOrEmpty(PS_UNIV_NAME))
                {
                    command.Parameters.Add(new OracleParameter("PS_UNIV_NAME", PS_UNIV_NAME));
                }
                if (!string.IsNullOrEmpty(PS_FROM_MONTH))
                {
                    command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                }
                if (!string.IsNullOrEmpty(PS_FROM_YEAR))
                {
                    command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                }
                if (!string.IsNullOrEmpty(PS_TO_MONTH))
                {
                    command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                }
                if (!string.IsNullOrEmpty(PS_TO_YEAR))
                {
                    command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                }
                if (!string.IsNullOrEmpty(PS_QUALIFICATION))
                {
                    command.Parameters.Add(new OracleParameter("PS_QUALIFICATION", PS_QUALIFICATION));
                }
                if (!string.IsNullOrEmpty(PS_MAJOR))
                {
                    command.Parameters.Add(new OracleParameter("PS_MAJOR", PS_MAJOR));
                }
                if (!string.IsNullOrEmpty(PS_COUNTRY_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", PS_COUNTRY_ID));
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

        public int INSERT_PS_STUDY() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_STUDY (PS_CITIZEN_ID,PS_DEGREE_ID,PS_UNIV_NAME,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_QUALIFICATION,PS_MAJOR,PS_COUNTRY_ID) VALUES (:PS_CITIZEN_ID,:PS_DEGREE_ID,:PS_UNIV_NAME,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_QUALIFICATION,:PS_MAJOR,:PS_COUNTRY_ID)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_DEGREE_ID", PS_DEGREE_ID));
                command.Parameters.Add(new OracleParameter("PS_UNIV_NAME", PS_UNIV_NAME));
                command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                command.Parameters.Add(new OracleParameter("PS_QUALIFICATION", PS_QUALIFICATION));
                command.Parameters.Add(new OracleParameter("PS_MAJOR", PS_MAJOR));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", PS_COUNTRY_ID));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_STUDY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_STUDY Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_DEGREE_ID = :PS_DEGREE_ID  ,";
            query += " PS_UNIV_NAME = :PS_UNIV_NAME ,";
            query += " PS_FROM_MONTH = :PS_FROM_MONTH ,";
            query += " PS_FROM_YEAR = :PS_FROM_YEAR ,";
            query += " PS_TO_MONTH = :PS_TO_MONTH ,";
            query += " PS_TO_YEAR = :PS_TO_YEAR ,";
            query += " PS_QUALIFICATION = :PS_QUALIFICATION ,";
            query += " PS_MAJOR = :PS_MAJOR ,";
            query += " PS_COUNTRY_ID = :PS_COUNTRY_ID ";
            query += " where PS_STUDY_ID  = :PS_STUDY_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_DEGREE_ID", PS_DEGREE_ID));
                command.Parameters.Add(new OracleParameter("PS_UNIV_NAME", PS_UNIV_NAME));
                command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                command.Parameters.Add(new OracleParameter("PS_QUALIFICATION", PS_QUALIFICATION));
                command.Parameters.Add(new OracleParameter("PS_MAJOR", PS_MAJOR));
                command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", PS_COUNTRY_ID));
                command.Parameters.Add(new OracleParameter("PS_STUDY_ID", PS_STUDY_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_STUDY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_STUDY where PS_STUDY_ID = :PS_STUDY_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_STUDY_ID", PS_STUDY_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }
    }

    public class PS_PROFESSIONAL_LICENSE {
        public int PS_PL_ID { get; set; }
        public string PS_CITIZEN_ID { get; set; }
        public string PS_LICENSE_NAME { get; set; }
        public string PS_DEPARTMENT { get; set; }
        public string PS_LICENSE_NO { get; set; }
        public DateTime PS_USE_DATE { get; set; }

        public PS_PROFESSIONAL_LICENSE() { }
        public PS_PROFESSIONAL_LICENSE(int PS_PL_ID, string PS_CITIZEN_ID, string PS_LICENSE_NAME, string PS_DEPARTMENT, string PS_LICENSE_NO, DateTime PS_USE_DATE) {
            this.PS_PL_ID = PS_PL_ID;
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_LICENSE_NAME = PS_LICENSE_NAME;
            this.PS_DEPARTMENT = PS_DEPARTMENT;
            this.PS_LICENSE_NO = PS_LICENSE_NO;
            this.PS_USE_DATE = PS_USE_DATE;
        }

        public DataTable SELECT_PS_PROFESSIONAL_LICENSE(string PS_CITIZEN_ID, string PS_LICENSE_NAME, string PS_DEPARTMENT, string PS_LICENSE_NO, string PS_USE_DATE)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM PS_PROFESSIONAL_LICENSE ";
            if (!string.IsNullOrEmpty(PS_CITIZEN_ID) || !string.IsNullOrEmpty(PS_LICENSE_NAME) || !string.IsNullOrEmpty(PS_DEPARTMENT) || !string.IsNullOrEmpty(PS_LICENSE_NO) || !string.IsNullOrEmpty(PS_USE_DATE))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    query += " and PS_CITIZEN_ID like :PS_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(PS_LICENSE_NAME))
                {
                    query += " and PS_LICENSE_NAME like :PS_LICENSE_NAME ";
                }
                if (!string.IsNullOrEmpty(PS_DEPARTMENT))
                {
                    query += " and PS_DEPARTMENT like :PS_DEPARTMENT ";
                }
                if (!string.IsNullOrEmpty(PS_LICENSE_NO))
                {
                    query += " and PS_LICENSE_NO like :PS_LICENSE_NO ";
                }
                if (!string.IsNullOrEmpty(PS_USE_DATE))
                {
                    query += " and PS_USE_DATE like :PS_USE_DATE ";
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
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(PS_LICENSE_NAME))
                {
                    command.Parameters.Add(new OracleParameter("PS_LICENSE_NAME", PS_LICENSE_NAME));
                }
                if (!string.IsNullOrEmpty(PS_DEPARTMENT))
                {
                    command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));
                }
                if (!string.IsNullOrEmpty(PS_LICENSE_NO))
                {
                    command.Parameters.Add(new OracleParameter("PS_LICENSE_NO", PS_LICENSE_NO));
                }
                if (!string.IsNullOrEmpty(PS_USE_DATE))
                {
                    command.Parameters.Add(new OracleParameter("PS_USE_DATE", PS_USE_DATE));
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

        public int INSERT_PS_PROFESSIONAL_LICENSE() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_PROFESSIONAL_LICENSE (PS_CITIZEN_ID,PS_LICENSE_NAME,PS_DEPARTMENT,PS_LICENSE_NO,PS_USE_DATE) VALUES (:PS_CITIZEN_ID,:PS_LICENSE_NAME,:PS_DEPARTMENT,:PS_LICENSE_NO,:PS_USE_DATE)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_LICENSE_NAME", PS_LICENSE_NAME));
                command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));
                command.Parameters.Add(new OracleParameter("PS_LICENSE_NO", PS_LICENSE_NO));
                command.Parameters.Add(new OracleParameter("PS_USE_DATE", PS_USE_DATE));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_PROFESSIONAL_LICENSE() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_PROFESSIONAL_LICENSE Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_LICENSE_NAME = :PS_LICENSE_NAME  ,";
            query += " PS_DEPARTMENT = :PS_DEPARTMENT ,";
            query += " PS_LICENSE_NO = :PS_LICENSE_NO ,";
            query += " PS_USE_DATE = :PS_USE_DATE ";
            query += " where PS_PL_ID  = :PS_PL_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_LICENSE_NAME", PS_LICENSE_NAME));
                command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));
                command.Parameters.Add(new OracleParameter("PS_LICENSE_NO", PS_LICENSE_NO));
                command.Parameters.Add(new OracleParameter("PS_USE_DATE", PS_USE_DATE));
                command.Parameters.Add(new OracleParameter("PS_PL_ID", PS_PL_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_PROFESSIONAL_LICENSE() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_PROFESSIONAL_LICENSE where PS_PL_ID = :PS_PL_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_PL_ID", PS_PL_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }
    }

    public class PS_TRAINING {
        public int PS_TRAINING_ID { get; set; }
        public string PS_CITIZEN_ID { get; set; }
        public string PS_COURSE { get; set; }
        public int PS_FROM_MONTH { get; set; }
        public int PS_FROM_YEAR { get; set; }
        public int PS_TO_MONTH { get; set; }
        public int PS_TO_YEAR { get; set; }
        public string PS_DEPARTMENT { get; set; }

        public PS_TRAINING() { }
        public PS_TRAINING(int PS_TRAINING_ID, string PS_CITIZEN_ID, string PS_COURSE, int PS_FROM_MONTH, int PS_FROM_YEAR, int PS_TO_MONTH, int PS_TO_FROM, string PS_DEPARTMENT) {
            this.PS_TRAINING_ID = PS_TRAINING_ID;
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_COURSE = PS_COURSE;
            this.PS_FROM_MONTH = PS_FROM_MONTH;
            this.PS_FROM_YEAR = PS_FROM_YEAR;
            this.PS_TO_MONTH = PS_TO_MONTH;
            this.PS_TO_YEAR = PS_TO_YEAR;
            this.PS_DEPARTMENT = PS_DEPARTMENT;
        }

        public DataTable SELECT_PS_TRAINING(string PS_CITIZEN_ID, string PS_COURSE, string PS_FROM_MONTH, string PS_FROM_YEAR, string PS_TO_MONTH, string PS_TO_YEAR, string PS_DEPARTMENT)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM PS_TRAINING ";
            if (!string.IsNullOrEmpty(PS_CITIZEN_ID) || !string.IsNullOrEmpty(PS_COURSE) || !string.IsNullOrEmpty(PS_FROM_MONTH) || !string.IsNullOrEmpty(PS_FROM_YEAR) || !string.IsNullOrEmpty(PS_TO_MONTH) || !string.IsNullOrEmpty(PS_TO_YEAR) || !string.IsNullOrEmpty(PS_DEPARTMENT))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    query += " and PS_CITIZEN_ID like :PS_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(PS_COURSE))
                {
                    query += " and PS_COURSE like :PS_COURSE ";
                }
                if (!string.IsNullOrEmpty(PS_FROM_MONTH))
                {
                    query += " and PS_FROM_MONTH like :PS_FROM_MONTH ";
                }
                if (!string.IsNullOrEmpty(PS_FROM_YEAR))
                {
                    query += " and PS_FROM_YEAR like :PS_FROM_YEAR ";
                }
                if (!string.IsNullOrEmpty(PS_TO_MONTH))
                {
                    query += " and PS_TO_MONTH like :PS_TO_MONTH ";
                }
                if (!string.IsNullOrEmpty(PS_TO_YEAR))
                {
                    query += " and PS_TO_YEAR like :PS_TO_YEAR ";
                }
                if (!string.IsNullOrEmpty(PS_DEPARTMENT))
                {
                    query += " and PS_DEPARTMENT like :PS_DEPARTMENT ";
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
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(PS_COURSE))
                {
                    command.Parameters.Add(new OracleParameter("PS_COURSE", PS_COURSE));
                }
                if (!string.IsNullOrEmpty(PS_FROM_MONTH))
                {
                    command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                }
                if (!string.IsNullOrEmpty(PS_FROM_YEAR))
                {
                    command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                }
                if (!string.IsNullOrEmpty(PS_TO_MONTH))
                {
                    command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                }
                if (!string.IsNullOrEmpty(PS_TO_YEAR))
                {
                    command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                }
                if (!string.IsNullOrEmpty(PS_DEPARTMENT))
                {
                    command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));
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

        public int INSERT_PS_TRAINING() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_TRAINING (PS_CITIZEN_ID,PS_COURSE,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_DEPARTMENT) VALUES (:PS_CITIZEN_ID,:PS_COURSE,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_DEPARTMENT)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_COURSE", PS_COURSE));
                command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_TRAINING() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_TRAINING Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_COURSE = :PS_COURSE ,";
            query += " PS_FROM_MONTH = :PS_FROM_MONTH ,";
            query += " PS_FROM_YEAR = :PS_FROM_YEAR ,";
            query += " PS_TO_MONTH = :PS_TO_MONTH ,";
            query += " PS_TO_YEAR = :PS_TO_YEAR ,";
            query += " PS_DEPARTMENT = :PS_DEPARTMENT ";
            query += " where PS_TRAINING_ID  = :PS_TRAINING_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_COURSE", PS_COURSE));
                command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", PS_FROM_MONTH));
                command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", PS_FROM_YEAR));
                command.Parameters.Add(new OracleParameter("PS_TO_MONTH", PS_TO_MONTH));
                command.Parameters.Add(new OracleParameter("PS_TO_YEAR", PS_TO_YEAR));
                command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", PS_DEPARTMENT));
                command.Parameters.Add(new OracleParameter("PS_TRAINING_ID", PS_TRAINING_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_TRAINING() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_TRAINING where PS_TRAINING_ID = :PS_TRAINING_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_TRAINING_ID", PS_TRAINING_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }
    }

    public class PS_DISCIPLINARY_AND_AMNESTY {
        public int PS_DAA_ID { get; set; }
        public string PS_CITIZEN_ID { get; set; }
        public int PS_YEAR { get; set; }
        public string PS_DAA_NAME { get; set; }
        public string PS_REF { get; set; }

        public PS_DISCIPLINARY_AND_AMNESTY() { }
        public PS_DISCIPLINARY_AND_AMNESTY(int PS_DAA_ID, string PS_CITIZEN_ID, int PS_YEAR, string PS_DAA_NAME, string PS_REF) {
            this.PS_DAA_ID = PS_DAA_ID;
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_YEAR = PS_YEAR;
            this.PS_DAA_NAME = PS_DAA_NAME;
            this.PS_REF = PS_REF;
        }

        public DataTable SELECT_PS_DISCIPLINARY_AND_AMNESTY(string PS_CITIZEN_ID, string PS_YEAR, string PS_DAA_NAME, string PS_REF)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM PS_DISCIPLINARY_AND_AMNESTY ";
            if (!string.IsNullOrEmpty(PS_CITIZEN_ID) || !string.IsNullOrEmpty(PS_YEAR) || !string.IsNullOrEmpty(PS_DAA_NAME) || !string.IsNullOrEmpty(PS_REF))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    query += " and PS_CITIZEN_ID like :PS_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(PS_YEAR))
                {
                    query += " and PS_YEAR like :PS_YEAR ";
                }
                if (!string.IsNullOrEmpty(PS_DAA_NAME))
                {
                    query += " and PS_DAA_NAME like :PS_DAA_NAME ";
                }
                if (!string.IsNullOrEmpty(PS_REF))
                {
                    query += " and PS_REF like :PS_REF ";
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
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(PS_YEAR))
                {
                    command.Parameters.Add(new OracleParameter("PS_YEAR", PS_YEAR));
                }
                if (!string.IsNullOrEmpty(PS_DAA_NAME))
                {
                    command.Parameters.Add(new OracleParameter("PS_DAA_NAME", PS_DAA_NAME));
                }
                if (!string.IsNullOrEmpty(PS_REF))
                {
                    command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));
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

        public int INSERT_PS_DISCIPLINARY_AND_AMNESTY() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_DISCIPLINARY_AND_AMNESTY (PS_CITIZEN_ID,PS_YEAR,PS_DAA_NAME,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_YEAR,:PS_DAA_NAME,:PS_REF)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_YEAR", PS_YEAR));
                command.Parameters.Add(new OracleParameter("PS_DAA_NAME", PS_DAA_NAME));
                command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_DISCIPLINARY_AND_AMNESTY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_DISCIPLINARY_AND_AMNESTY Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_YEAR = :PS_YEAR ,";
            query += " PS_DAA_NAME = :PS_DAA_NAME ,";
            query += " PS_REF = :PS_REF ";
            query += " where PS_DAA_ID  = :PS_DAA_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_DAA_NAME", PS_DAA_NAME));
                command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));
                command.Parameters.Add(new OracleParameter("PS_DAA_ID", PS_DAA_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_DISCIPLINARY_AND_AMNESTY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_DISCIPLINARY_AND_AMNESTY where PS_DAA_ID = :PS_DAA_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_DAA_ID", PS_DAA_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }
    }

    public class PS_POSITION_AND_SALARY {
        public int PS_PAS_ID { get; set; }
        public string PS_CITIZEN_ID { get; set; }
        public DateTime PS_DATE { get; set; }
        public string PS_POSITION { get; set; }
        public string PS_POSITION_NO { get; set; }
        public string PS_POSITION_TYPE { get; set; }
        public string PS_POSITION_DEGREE { get; set; }
        public int PS_SALARY { get; set; }
        public int PS_SALARY_POSITION { get; set; }
        public string PS_REF { get; set; }

        public PS_POSITION_AND_SALARY() { }
        public PS_POSITION_AND_SALARY(int PS_PAS_ID, string PS_CITIZEN_ID, DateTime PS_DATE, string PS_POSITION, string PS_POSITION_NO, string PS_POSITION_TYPE, string PS_POSITION_DEGREE, int PS_SALARY, int PS_SALARY_POSITION, string PS_REF) {
            this.PS_PAS_ID = PS_PAS_ID;
            this.PS_CITIZEN_ID = PS_CITIZEN_ID;
            this.PS_DATE = PS_DATE;
            this.PS_POSITION = PS_POSITION;
            this.PS_POSITION_NO = PS_POSITION_NO;
            this.PS_POSITION_TYPE = PS_POSITION_TYPE;
            this.PS_POSITION_DEGREE = PS_POSITION_DEGREE;
            this.PS_SALARY = PS_SALARY;
            this.PS_SALARY_POSITION = PS_SALARY_POSITION;
            this.PS_REF = PS_REF;
        }

        public DataTable SELECT_PS_POSITION_AND_SALARY(string PS_CITIZEN_ID, string PS_DATE, string PS_POSITION, string PS_POSITION_NO, string PS_POSITION_TYPE, string PS_POSITION_DEGREE, string PS_SALARY, string PS_SALARY_POSITION, string PS_REF)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "SELECT * FROM PS_POSITION_AND_SALARY ";
            if (!string.IsNullOrEmpty(PS_CITIZEN_ID) || !string.IsNullOrEmpty(PS_DATE) || !string.IsNullOrEmpty(PS_POSITION) || !string.IsNullOrEmpty(PS_POSITION_NO) || !string.IsNullOrEmpty(PS_POSITION_TYPE) || !string.IsNullOrEmpty(PS_POSITION_DEGREE) || !string.IsNullOrEmpty(PS_SALARY) || !string.IsNullOrEmpty(PS_SALARY_POSITION) || !string.IsNullOrEmpty(PS_REF))
            {
                query += " where 1=1 ";
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    query += " and PS_CITIZEN_ID like :PS_CITIZEN_ID ";
                }
                if (!string.IsNullOrEmpty(PS_DATE))
                {
                    query += " and PS_DATE like :PS_DATE ";
                }
                if (!string.IsNullOrEmpty(PS_POSITION))
                {
                    query += " and PS_POSITION like :PS_POSITION ";
                }
                if (!string.IsNullOrEmpty(PS_POSITION_NO))
                {
                    query += " and PS_POSITION_NO like :PS_POSITION_NO ";
                }
                if (!string.IsNullOrEmpty(PS_POSITION_TYPE))
                {
                    query += " and PS_POSITION_TYPE like :PS_POSITION_TYPE ";
                }
                if (!string.IsNullOrEmpty(PS_POSITION_DEGREE))
                {
                    query += " and PS_POSITION_DEGREE like :PS_POSITION_DEGREE ";
                }
                if (!string.IsNullOrEmpty(PS_SALARY))
                {
                    query += " and PS_SALARY like :PS_SALARY ";
                }
                if (!string.IsNullOrEmpty(PS_SALARY_POSITION))
                {
                    query += " and PS_SALARY_POSITION like :PS_SALARY_POSITION ";
                }
                if (!string.IsNullOrEmpty(PS_REF))
                {
                    query += " and PS_REF like :PS_REF ";
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
                if (!string.IsNullOrEmpty(PS_CITIZEN_ID))
                {
                    command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                }
                if (!string.IsNullOrEmpty(PS_DATE))
                {
                    command.Parameters.Add(new OracleParameter("PS_DATE", PS_DATE));
                }
                if (!string.IsNullOrEmpty(PS_POSITION))
                {
                    command.Parameters.Add(new OracleParameter("PS_POSITION", PS_POSITION));
                }
                if (!string.IsNullOrEmpty(PS_POSITION_NO))
                {
                    command.Parameters.Add(new OracleParameter("PS_POSITION_NO", PS_POSITION_NO));
                }
                if (!string.IsNullOrEmpty(PS_POSITION_TYPE))
                {
                    command.Parameters.Add(new OracleParameter("PS_POSITION_TYPE", PS_POSITION_TYPE));
                }
                if (!string.IsNullOrEmpty(PS_POSITION_DEGREE))
                {
                    command.Parameters.Add(new OracleParameter("PS_POSITION_DEGREE", PS_POSITION_DEGREE));
                }
                if (!string.IsNullOrEmpty(PS_SALARY))
                {
                    command.Parameters.Add(new OracleParameter("PS_SALARY", PS_SALARY));
                }
                if (!string.IsNullOrEmpty(PS_SALARY_POSITION))
                {
                    command.Parameters.Add(new OracleParameter("PS_SALARY_POSITION", PS_SALARY_POSITION));
                }
                if (!string.IsNullOrEmpty(PS_REF))
                {
                    command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));
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

        public int INSERT_PS_POSITION_AND_SALARY() {
            int id = 0;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("INSERT INTO PS_POSITION_AND_SALARY (PS_CITIZEN_ID,PS_DATE,PS_POSITION,PS_POSITION_NO,PS_POSITION_TYPE,PS_POSITION_DEGREE,PS_SALARY,PS_SALARY_POSITION,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_DATE,:PS_POSITION,:PS_POSITION_NO,:PS_POSITION_TYPE,:PS_POSITION_DEGREE,:PS_SALARY,:PS_SALARY_POSITION,:PS_REF)", conn);

            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_DATE", PS_DATE));
                command.Parameters.Add(new OracleParameter("PS_POSITION", PS_POSITION));
                command.Parameters.Add(new OracleParameter("PS_POSITION_NO", PS_POSITION_NO));
                command.Parameters.Add(new OracleParameter("PS_POSITION_TYPE", PS_POSITION_TYPE));
                command.Parameters.Add(new OracleParameter("PS_POSITION_DEGREE", PS_POSITION_DEGREE));
                command.Parameters.Add(new OracleParameter("PS_SALARY", PS_SALARY));
                command.Parameters.Add(new OracleParameter("PS_SALARY_POSITION", PS_SALARY_POSITION));
                command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));

                id = command.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return id;
        }

        public bool UPDATE_PS_POSITION_AND_SALARY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            string query = "Update PS_POSITION_AND_SALARY Set ";
            query += " PS_CITIZEN_ID = :PS_CITIZEN_ID ,";
            query += " PS_DATE = :PS_DATE ,";
            query += " PS_POSITION = :PS_POSITION ,";
            query += " PS_POSITION_NO = :PS_POSITION_NO  ,";
            query += " PS_POSITION_TYPE = :PS_POSITION_TYPE ,";
            query += " PS_POSITION_DEGREE = :PS_POSITION_DEGREE ,";
            query += " PS_SALARY = :PS_SALARY ,";
            query += " PS_SALARY_POSITION = :PS_SALARY_POSITION ,";
            query += " PS_REF = :PS_REF ";
            query += " where PS_PAS_ID  = :PS_PAS_ID";

            OracleCommand command = new OracleCommand(query, conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", PS_CITIZEN_ID));
                command.Parameters.Add(new OracleParameter("PS_DATE", PS_DATE));
                command.Parameters.Add(new OracleParameter("PS_POSITION", PS_POSITION));
                command.Parameters.Add(new OracleParameter("PS_POSITION_NO", PS_POSITION_NO));
                command.Parameters.Add(new OracleParameter("PS_POSITION_TYPE", PS_POSITION_TYPE));
                command.Parameters.Add(new OracleParameter("PS_POSITION_DEGREE", PS_POSITION_DEGREE));
                command.Parameters.Add(new OracleParameter("PS_SALARY", PS_SALARY));
                command.Parameters.Add(new OracleParameter("PS_SALARY_POSITION", PS_SALARY_POSITION));
                command.Parameters.Add(new OracleParameter("PS_REF", PS_REF));
                command.Parameters.Add(new OracleParameter("PS_PAS_ID", PS_PAS_ID));
                if (command.ExecuteNonQuery() > 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }

        public bool DELETE_PS_POSITION_AND_SALARY() {
            bool result = false;
            OracleConnection conn = ConnectionDB.GetOracleConnection();
            OracleCommand command = new OracleCommand("Delete PS_POSITION_AND_SALARY where PS_PAS_ID = :PS_PAS_ID", conn);
            try {
                if (conn.State != ConnectionState.Open) {
                    conn.Open();
                }
                command.Parameters.Add(new OracleParameter("PS_PAS_ID", PS_PAS_ID));
                if (command.ExecuteNonQuery() >= 0) {
                    result = true;
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                command.Dispose();
                conn.Close();
            }
            return result;
        }
    }

}