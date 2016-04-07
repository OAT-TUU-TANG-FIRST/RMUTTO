using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace WEB_PERSONAL.Class {
    public class PositionAndSalary {

        private int id;
        private string date;
        private string position_description;
        private string person_id;
        private int st_id;
        private string position_id;
        private string position_name;
        private int salary;
        private int position_salary;
        private string reference_document;
        private string citizen_id;

        public PositionAndSalary(int id) {
            this.id = id;
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT NVL(TO_CHAR(DDATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), '-'), NVL(POSITION_NAME, '-'), NVL(PERSON_ID, '-'), NVL(ST_ID, -1), NVL(POSITION_ID, '-'), NVL(SALARY, -1), NVL(POSITION_SALARY, -1), NVL(REFERENCE_DOCUMENT, '-'), NVL(CITIZEN_ID, '-') FROM TB_POSITION_AND_SALARY WHERE ID = :1", con)) {
                    command.Parameters.AddWithValue("1", id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            date = reader.GetString(0);
                            position_description = reader.GetString(1);
                            person_id = reader.GetString(2);
                            st_id = reader.GetInt32(3);
                            position_id = reader.GetString(4);
                            salary = reader.GetInt32(5);
                            position_salary = reader.GetInt32(6);
                            reference_document = reader.GetString(7);
                            citizen_id = reader.GetString(8);
                        } else {
                            date = "-";
                            position_description = "-";
                            person_id = "-";
                            st_id = -1;
                            position_id = "-";
                            salary = -1;
                            position_salary = -1;
                            reference_document = "-";
                            citizen_id = "-";
                        }
                    }
                }
                using (OracleCommand command = new OracleCommand("SELECT NVL(TB_POSITION.NAME, '-') FROM TB_POSITION_AND_SALARY, TB_POSITION WHERE TB_POSITION_AND_SALARY.ID = :1 AND TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID", con)) {
                    command.Parameters.AddWithValue("1", id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            position_name = reader.GetString(0);
                        } else {
                            position_name = "-";
                        }
                    }
                }

            }
        }

        public int ID {
            get { return id; }
        }
        public string Date {
            get { return date; }
        }
        public string PositionDescription {
            get { return position_description; }
        }
        public string PersonID {
            get { return person_id; }
        }
        public int STID {
            get { return st_id; }
        }
        public string PositionID {
            get { return position_id; }
        }
        public string PositionName {
            get { return position_name; }
        }
        public int Salary {
            get { return salary; }
        }
        public int PositionSalary {
            get { return position_salary; }
        }
        public string ReferenceDocument {
            get { return reference_document; }
        }
        public string CitizenID {
            get { return citizen_id; }
        }
        public Person Citizen {
           get { return DatabaseManager.GetPerson(citizen_id); }
        }

    }
}