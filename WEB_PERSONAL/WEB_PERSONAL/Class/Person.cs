using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Globalization;

namespace WEB_PERSONAL.Class {

    public class Person {

        public string ID;
        public string CitizenID;
        public string TitleID;
        public string TitleName;
        public string FirstName;
        public string LastName;
        public string BirthDate;
        public string BirthDateLong;
        public string RetireDate;
        public string RetireDateLong;
        public string InWorkDate;
        public string StaffTypeID;
        public string StaffTypeName;
        public string FatherFirstName;
        public string FatherLastName;
        public string MotherFirstName;
        public string MotherLastName;
        public string MotherOldLastName;
        public string CoupleFirstName;
        public string CoupleLastName;
        public string CoupleOldLastName;
        public string MinistryID;
        public string MinistryName;
        public string DepartmentName;
        public string Password;
        public string SystemStatusID;
        public string SystemStatusName;
        public string GenderID;
        public string GenderName;
        public string NationID;
        public string NationName;
        public string HomeAdd;
        public string Moo;
        public string Street;
        public string DistrictID;
        public string DistrictName;
        public string AmphurID;
        public string AmphurName;
        public string ProvinceID;
        public string ProvinceName;
        public string ZipCodeID;
        public string Telephone;
        public string TimeContactID;
        public string TimeContactName;
        public string BudgetID;
        public string BudgetName;
        public string SubStaffTypeID;
        public string SubStaffTypeName;
        public string AdminPositionID;
        public string AdminPositionName;
        public string PositionWorkID;
        public string PositionWorkName;
        public string SpecialName;
        public string TeachISCEDID;
        public string TeachISCEDName;
        public string GradISCEDID;
        public string GradISCEDName;
        public string GradProgID;
        public string GradProgName;
        public string GradUniv;
        public string GradCountryID;
        public string GradCountryName;
        public string BranchID;
        public string BranchName;
        public string RankID;
        public string RankName;
        public string FacultyID;
        public string FacultyName;
        public string StartPositionWorkID;
        public string StartPositionWorkName;
        public string CampusID;
        public string CampusName;
        public string StatusID;
        public string StatusName;
        public string ReligionID;
        public string ReligionName;

        public string GotID;
        public string GetID;

        public string PositionID;
        public string PositionName;


        
        
        public int NotificationCount;

        public string FullName {
            get { return TitleName + FirstName + " " + LastName; }
        }
        public string FirstNameAndLastName {
            get { return FirstName + " " + LastName; }
        }
        public string FatherFirstNameAndLastName {
            get { return FatherFirstName + " " + FatherLastName; }
        }
        public string MotherFirstNameAndLastName {
            get { return MotherFirstName + " " + MotherLastName; }
        }












        //static -----------------------------------------------------------------

        /*public static bool IsExist(string citizen_id) {
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", citizen_id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            if (reader.GetInt32(0) > 0) {
                                return true;
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    }
                }
            }
        }
        public static bool IsAdmin(string citizen_id) {
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT SYSTEM_STATUS_ID FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", citizen_id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            if (reader.GetInt32(0) == 1) {
                                return true;
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    }
                }
            }
        }
        public static string GetName(string citizen_id) {
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT PERSON_NAME FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", citizen_id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            return reader.GetString(0);
                        } else {
                            return "-";
                        }
                    }
                }
            }
        }
        public static string GetLastname(string citizen_id) {
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT PERSON_LASTNAME FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", citizen_id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            return reader.GetString(0);
                        } else {
                            return "-";
                        }
                    }
                }
            }
        }
        public static string GetNameAndLastname(string citizen_id) {
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                    command.Parameters.AddWithValue("1", citizen_id);
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            reader.Read();
                            return reader.GetString(0);
                        } else {
                            return "-";
                        }
                    }
                }
            }
        }

        //instance ---------------------------------------------------------------------

        private bool error;
        private bool exist;
        private string citizen_id;
        private int title_id;
        private string title_name;
        private string name;
        private string lastname;
        private int gender_id;
        private string gender_name;
        private int system_status_id;
        private string system_status_name;
        private int staff_type_id;
        private string staff_type_name;
        private string position_id;
        private string position_name;
        private string position_name_description;
        private int ministry_id;
        private string ministry_name;
        private string department_name;
        private string birth_date;
        private string inwork_date;
        private string retire_date;
        private string father_name;
        private string father_lastname;
        private string mother_name;
        private string mother_lastname;
        private string mother_old_lastname;
        private string couple_name;
        private string couple_lastname;
        private string couple_old_lastname;
        private double salary;
        private double salary_year;
        private string admin_position_id;
        private string admin_position_name;
        private string position_work_id;
        private string position_work_name;
        private string nation_id;
        private string nation_name_en;
        private string nation_name_th;
        private string home_add;
        private string moo;
        private string street;
        private int district_id;
        private string district_name;
        private int amphur_id;
        private string amphur_name;
        private int province_id;
        private string province_name;
        private int zipcode;
        private string telephone;
        private int time_contact_id;
        private string time_contact_name;
        private int budget_id;
        private string budget_name;
        private int sub_staff_type_id;
        private string sub_staff_type_name;
        private string special_name;
        private string teach_isced_id;
        private string teach_isced_name;
        private string grad_lev_id;
        private string grad_lev_name;
        private string grad_curr;
        private string grad_isced_id;
        private string grad_isced_name;
        private string grad_prog_id;
        private string grad_prog_name;
        private string grad_univ;
        private int grad_country_id;
        private string grad_country_name;
        private int branch_id;
        private string branch_name;
        private int rank_id;
        private string rank_name;
        private string faculty_id;
        private string faculty_name;
        private string start_position_work_id;
        private string start_position_work_name;
        private List<PositionAndSalary> position_and_salary_list = new List<PositionAndSalary>();
        private List<StudyHistory> study_history_list = new List<StudyHistory>();
        private List<JobLicense> job_license_list = new List<JobLicense>();
        private List<TrainingHistory> training_history_list = new List<TrainingHistory>();
        private List<DisciplinaryAndAmnesty> disciplinary_and_amnesty_list = new List<DisciplinaryAndAmnesty>();


        public Person(string citizen_id) {
            //try {
            this.citizen_id = citizen_id;
            using (OracleConnection con = Util.OC()) {
                try {
                    using (OracleCommand command = new OracleCommand("SELECT COUNT(*) FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                if (reader.GetInt32(0) > 0) {
                                    exist = true;
                                } else {
                                    exist = false;
                                }
                            } else {
                                exist = false;
                            }
                        }
                    }
                } catch {
                    exist = false;
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TITLE_ID, -1), NVL(PERSON_NAME, '-'), NVL(PERSON_LASTNAME, '-'), NVL(GENDER_ID, -1), NVL(SYSTEM_STATUS_ID, -1), NVL(STAFFTYPE_ID, -1), NVL(MINISTRY_ID, -1), NVL(DEPARTMENT_NAME, '-'), NVL(TO_CHAR(BIRTHDATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), '-'), NVL(TO_CHAR(INWORK_DATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), '-'), NVL(TO_CHAR(RETIRE_DATE, 'DD MON YYYY', 'NLS_DATE_LANGUAGE = THAI'), '-'), NVL(FATHER_NAME, '-'), NVL(FATHER_LASTNAME, '-'), NVL(MOTHER_NAME, '-'), NVL(MOTHER_LASTNAME, '-'), NVL(MOTHER_OLD_LASTNAME, '-'), NVL(COUPLE_NAME, '-'), NVL(COUPLE_LASTNAME, '-'), NVL(COUPLE_OLD_LASTNAME, '-'), NVL(ADMIN_POSITION_ID, '-'), NVL(POSITION_WORK_ID, '-'), NVL(NATION_ID, '-'), NVL(HOMEADD, '-'), NVL(MOO, '-'), NVL(STREET, '-'), NVL(DISTRICT_ID, -1), NVL(AMPHUR_ID, -1), NVL(PROVINCE_ID, -1), NVL(ZIPCODE_ID, -1), NVL(TELEPHONE, '-'), NVL(TIME_CONTACT_ID, -1), NVL(BUDGET_ID, -1), NVL(SUBSTAFFTYPE_ID, -1), NVL(SPECIAL_NAME, '-'), NVL(TEACH_ISCED_ID, '-'), NVL(GRAD_ISCED_ID, '-'), NVL(GRAD_PROG_ID, '-'), NVL(GRAD_UNIV, '-'), NVL(GRAD_COUNTRY_ID, -1), NVL(BRANCH_ID, -1), NVL(RANK_ID, -1), NVL(FACULTY_ID, -1), NVL(START_POSITION_WORK_ID, '-') FROM TB_PERSON WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                title_id = reader.GetInt32(0);
                                name = reader.GetString(1);
                                lastname = reader.GetString(2);
                                gender_id = reader.GetInt32(3);
                                system_status_id = reader.GetInt32(4);
                                staff_type_id = reader.GetInt32(5);
                                ministry_id = reader.GetInt32(6);
                                department_name = reader.GetString(7);
                                birth_date = reader.GetString(8);
                                inwork_date = reader.GetString(9);
                                retire_date = reader.GetString(10);
                                father_name = reader.GetString(11);
                                father_lastname = reader.GetString(12);
                                mother_name = reader.GetString(13);
                                mother_lastname = reader.GetString(14);
                                mother_old_lastname = reader.GetString(15);
                                couple_name = reader.GetString(16);
                                couple_lastname = reader.GetString(17);
                                couple_old_lastname = reader.GetString(18);
                                admin_position_id = reader.GetString(19);
                                position_work_id = reader.GetString(20);
                                nation_id = reader.GetString(21);
                                home_add = reader.GetString(22);
                                moo = reader.GetString(23);
                                street = reader.GetString(24);
                                district_id = reader.GetInt32(25);
                                amphur_id = reader.GetInt32(26);
                                province_id = reader.GetInt32(27);
                                zipcode = reader.GetInt32(28);
                                telephone = reader.GetString(29);
                                time_contact_id = reader.GetInt32(30);
                                budget_id = reader.GetInt32(31);
                                sub_staff_type_id = reader.GetInt32(32);
                                special_name = reader.GetString(33);
                                teach_isced_id = reader.GetString(34);
                               // grad_lev_id = reader.GetString(35);
                                //grad_curr = reader.GetString(36);
                                grad_isced_id = reader.GetString(35);
                                grad_prog_id = reader.GetString(36);
                                grad_univ = reader.GetString(37);
                                grad_country_id = reader.GetInt32(38);
                                branch_id = reader.GetInt32(39);
                                rank_id = reader.GetInt32(40);
                                faculty_id = reader.GetString(41);
                                start_position_work_id = reader.GetString(42);
                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_TITLENAME.TITLE_NAME_TH, '-') FROM TB_PERSON, TB_TITLENAME WHERE CITIZEN_ID = :1 AND TB_PERSON.TITLE_ID = TB_TITLENAME.TITLE_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                title_name = reader.GetString(0);
                            } else {
                                title_name = "-";
                            }
                        }
                    }
                } catch {
                    title_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(GENDER_NAME, '-') FROM TB_PERSON, TB_GENDER WHERE CITIZEN_ID = :1 AND TB_PERSON.GENDER_ID = TB_GENDER.GENDER_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                gender_name = reader.GetString(0);
                            } else {
                                gender_name = "-";
                            }
                        }
                    }
                } catch {
                    gender_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_SYSTEM_STATUS.SYSTEM_STATUS_NAME, '-') FROM TB_PERSON, TB_SYSTEM_STATUS WHERE CITIZEN_ID = :1 AND TB_PERSON.SYSTEM_STATUS_ID = TB_SYSTEM_STATUS.SYSTEM_STATUS_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                system_status_name = reader.GetString(0);
                            } else {
                                system_status_name = "-";
                            }
                        }
                    }
                } catch {
                    system_status_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_STAFFTYPE.STAFFTYPE_NAME, '-') FROM TB_PERSON, TB_STAFFTYPE WHERE CITIZEN_ID = :1 AND TB_PERSON.STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                staff_type_name = reader.GetString(0);
                            } else {
                                staff_type_name = "-";
                            }
                        }
                    }
                } catch {
                    staff_type_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(POSITION_ID, '-') FROM TB_POSITION_AND_SALARY WHERE CITIZEN_ID = :1 ORDER BY ID DESC", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                position_id = reader.GetString(0);
                            } else {
                                position_id = "-";
                            }
                        }
                    }
                } catch {
                    position_id = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_POSITION.NAME, '-') FROM TB_POSITION_AND_SALARY, TB_POSITION WHERE TB_POSITION_AND_SALARY.CITIZEN_ID = :1 AND TB_POSITION_AND_SALARY.POSITION_ID = TB_POSITION.ID ORDER BY TB_POSITION_AND_SALARY.ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                position_name = reader.GetString(0);
                            } else {
                                position_name = "-";
                            }
                        }
                    }
                } catch {
                    position_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(POSITION_NAME, '-') FROM TB_POSITION_AND_SALARY WHERE CITIZEN_ID = :1 ORDER BY ID DESC", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                position_name_description = reader.GetString(0);
                            } else {
                                position_name_description = "-";
                            }
                        }
                    }
                } catch {
                    position_name_description = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_MINISTRY.MINISTRY_NAME, '-') FROM TB_PERSON, TB_MINISTRY WHERE CITIZEN_ID = :1 AND TB_PERSON.MINISTRY_ID = TB_MINISTRY.MINISTRY_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                ministry_name = reader.GetString(0);
                            } else {
                                ministry_name = "-";
                            }
                        }
                    }
                } catch {
                    ministry_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT ID FROM TB_POSITION_AND_SALARY WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    position_and_salary_list.Add(new PositionAndSalary(reader.GetInt32(0)));
                                }
                            } else {

                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT IDSEQ FROM TB_STUDY_HISTORY WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    study_history_list.Add(new StudyHistory(reader.GetInt32(0)));
                                }
                            } else {

                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT ID FROM TB_JOB_LICENSE WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    job_license_list.Add(new JobLicense(reader.GetInt32(0)));
                                }
                            } else {

                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT ID FROM TB_TRAINING_HISTORY WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    training_history_list.Add(new TrainingHistory(reader.GetInt32(0)));
                                }
                            } else {

                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT ID FROM TB_DISCIPLINARY_AND_AMNESTY WHERE CITIZEN_ID = :1", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                while (reader.Read()) {
                                    disciplinary_and_amnesty_list.Add(new DisciplinaryAndAmnesty(reader.GetInt32(0)));
                                }
                            } else {

                            }
                        }
                    }
                } catch {
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TB_POSITION_AND_SALARY.SALARY, -1) FROM TB_PERSON, TB_POSITION_AND_SALARY WHERE TB_POSITION_AND_SALARY.CITIZEN_ID = :1 AND TB_POSITION_AND_SALARY.CITIZEN_ID = TB_PERSON.CITIZEN_ID ORDER BY TB_POSITION_AND_SALARY.ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                salary = reader.GetDouble(0);
                            } else {
                                salary = -1;
                            }
                        }
                    }
                } catch {
                    salary = -1;
                    error = true;
                }
                try {
                    {
                        int m = 3;
                        int y = Util.ODTN().Year;
                        switch (DateTime.Now.Month) {
                            case 1:
                            case 2:
                            case 3:
                            case 10:
                            case 11:
                            case 12:
                                m = 9;
                                break;
                        }
                        switch (DateTime.Now.Month) {
                            case 1:
                            case 2:
                            case 3:
                                --y;
                                break;
                        }

                        using (OracleCommand command = new OracleCommand("select salary from tb_position_and_salary where CITIZEN_ID = :1 and extract(MONTH FROM DDATE) = :2 and extract(YEAR FROM DDATE) = :3", con)) {
                            command.Parameters.AddWithValue("1", citizen_id);
                            command.Parameters.AddWithValue("2", m);
                            command.Parameters.AddWithValue("3", y);
                            using (OracleDataReader reader = command.ExecuteReader()) {
                                if (reader.HasRows) {
                                    reader.Read();
                                    salary_year = reader.GetDouble(0);
                                } else {
                                    salary_year = -1;
                                }
                            }
                        }
                    }
                } catch {
                    salary_year = -1;
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("select nvl(tb_admin_position.admin_position_name,'-') from tb_person,tb_admin_position where citizen_id = :1 and tb_person.admin_position_id = tb_admin_position.admin_position_id", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                admin_position_name = reader.GetString(0);
                            } else {
                                admin_position_name = "-";
                            }
                        }
                    }
                } catch {
                    admin_position_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("select nvl(tb_position_work.position_work_name,'-') from tb_person,tb_position_work where citizen_id = :1 and tb_person.position_work_id = tb_position_work.position_work_id", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                position_work_name = reader.GetString(0);
                            } else {
                                position_work_name = "-";
                            }
                        }
                    }
                } catch {
                    position_work_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(NATION_ENG, '-'), NVL(NATION_THA, '-') FROM TB_PERSON, TB_NATIONAL WHERE CITIZEN_ID = :1 AND TB_PERSON.NATION_ID = TB_NATIONAL.NATION_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                nation_name_en = reader.GetString(0);
                                nation_name_th = reader.GetString(1);
                            } else {
                                nation_name_en = "-";
                                nation_name_th = "-";
                            }
                        }
                    }
                } catch {
                    nation_name_en = "error";
                    nation_name_th = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(DISTRICT_TH, '-') FROM TB_PERSON, TB_DISTRICT WHERE CITIZEN_ID = :1 AND TB_PERSON.DISTRICT_ID = TB_DISTRICT.DISTRICT_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                district_name = reader.GetString(0);
                            } else {
                                district_name = "-";
                            }
                        }
                    }
                } catch {
                    district_name = "errror";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(AMPHUR_TH, '-') FROM TB_PERSON, TB_AMPHUR WHERE CITIZEN_ID = :1 AND TB_PERSON.AMPHUR_ID = TB_AMPHUR.AMPHUR_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                amphur_name = reader.GetString(0);
                            } else {
                                amphur_name = "-";
                            }
                        }
                    }
                } catch {
                    amphur_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(PROVINCE_TH, '-') FROM TB_PERSON, TB_PROVINCE WHERE CITIZEN_ID = :1 AND TB_PERSON.PROVINCE_ID = TB_PROVINCE.PROVINCE_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                province_name = reader.GetString(0);
                            } else {
                                province_name = "-";
                            }
                        }
                    }
                } catch {
                    province_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TIME_CONTACT_NAME, '-') FROM TB_PERSON, TB_TIME_CONTACT WHERE CITIZEN_ID = :1 AND TB_PERSON.TIME_CONTACT_ID = TB_TIME_CONTACT.TIME_CONTACT_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                time_contact_name = reader.GetString(0);
                            } else {
                                time_contact_name = "-";
                            }
                        }
                    }
                } catch {
                    time_contact_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(BUDGET_NAME, '-') FROM TB_PERSON, TB_BUDGET WHERE CITIZEN_ID = :1 AND TB_PERSON.BUDGET_ID = TB_BUDGET.BUDGET_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                budget_name = reader.GetString(0);
                            } else {
                                budget_name = "-";
                            }
                        }
                    }
                } catch {
                    budget_name = "error";
                    error = true;
                }
                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(SUBSTAFFTYPE_NAME, '-') FROM TB_PERSON, TB_SUBSTAFFTYPE WHERE CITIZEN_ID = :1 AND TB_PERSON.SUBSTAFFTYPE_ID = TB_SUBSTAFFTYPE.SUBSTAFFTYPE_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                sub_staff_type_name = reader.GetString(0);
                            } else {
                                sub_staff_type_name = "-";
                            }
                        }
                    }
                } catch {
                    sub_staff_type_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TEACH_ISCED_NAME_TH, '-') FROM TB_PERSON, TB_TEACH_ISCED WHERE CITIZEN_ID = :1 AND TB_PERSON.TEACH_ISCED_ID = TB_TEACH_ISCED.TEACH_ISCED_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                teach_isced_name = reader.GetString(0);
                            } else {
                                teach_isced_name = "-";
                            }
                        }
                    }
                } catch {
                    teach_isced_name = "error";
                    error = true;
                }




                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(TEACH_ISCED_NAME_TH, '-') FROM TB_PERSON, TB_TEACH_ISCED WHERE CITIZEN_ID = :1 AND TB_PERSON.GRAD_ISCED_ID = TB_TEACH_ISCED.TEACH_ISCED_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                grad_isced_name = reader.GetString(0);
                            } else {
                                grad_isced_name = "-";
                            }
                        }
                    }
                } catch {
                    grad_isced_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(GRAD_PROG_NAME, '-') FROM TB_PERSON, TB_GRAD_PROGRAM WHERE CITIZEN_ID = :1 AND TB_PERSON.GRAD_PROG_ID = TB_GRAD_PROGRAM.GRAD_PROG_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                grad_prog_name = reader.GetString(0);
                            } else {
                                grad_prog_name = "-";
                            }
                        }
                    }
                } catch {
                    grad_prog_name = "error";
                    error = true;
                }



                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(BRANCH_NAME, '-') FROM TB_PERSON, TB_BRANCH WHERE CITIZEN_ID = :1 AND TB_PERSON.BRANCH_ID = TB_BRANCH.BRANCH_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                branch_name = reader.GetString(0);
                            } else {
                                branch_name = "-";
                            }
                        }
                    }
                } catch {
                    branch_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(RANK_NAME_TH, '-') FROM TB_PERSON, TB_RANK WHERE CITIZEN_ID = :1 AND TB_PERSON.RANK_ID = TB_RANK.SEQ", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                rank_name = reader.GetString(0);
                            } else {
                                rank_name = "-";
                            }
                        }
                    }
                } catch {
                    rank_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(FACULTY_NAME, '-') FROM TB_PERSON, TB_FACULTY WHERE CITIZEN_ID = :1 AND TB_PERSON.FACULTY_ID = TB_FACULTY.FACULTY_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                faculty_name = reader.GetString(0);
                            } else {
                                faculty_name = "-";
                            }
                        }
                    }
                } catch {
                    faculty_name = "error";
                    error = true;
                }

                try {
                    using (OracleCommand command = new OracleCommand("SELECT NVL(POSITION_WORK_NAME, '-') FROM TB_PERSON, TB_POSITION_WORK WHERE CITIZEN_ID = :1 AND TB_PERSON.START_POSITION_WORK_ID = TB_POSITION_WORK.POSITION_WORK_ID", con)) {
                        command.Parameters.AddWithValue("1", citizen_id);
                        using (OracleDataReader reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();
                                start_position_work_name = reader.GetString(0);
                            } else {
                                start_position_work_name = "-";
                            }
                        }
                    }
                } catch {
                    start_position_work_name = "error";
                    error = true;
                }


            }


            //} catch {
            //    error = true;
            //}
        }

        public bool Error {
            get { return error; }
        }
        public bool Exist {
            get { return exist; }
        }
        public string CitizenID {
            get { return citizen_id; }
        }
        public int TitleID {
            get { return title_id; }
        }
        public string TitleName {
            get { return title_name; }
        }
        public string Name {
            get { return name; }
        }
        public string Lastname {
            get { return lastname; }
        }
        public string NameAndLastname {
            get { return name + " " + lastname; }
        }
        public string FullName {
            get { return title_name + name + " " + lastname; }
        }
        public int GenderID {
            get { return gender_id; }
        }
        public string GenderName {
            get { return gender_name; }
        }
        public int SystemStatusID {
            get { return system_status_id; }
        }
        public string SystemStatusName {
            get { return system_status_name; }
        }
        public int StaffTypeID {
            get { return staff_type_id; }
        }
        public string StaffTypeName {
            get { return staff_type_name; }
        }
        public string PositionID {
            get { return position_id; }
        }
        public string PositionName {
            get { return position_name; }
        }
        public string PositionNameDescription {
            get { return position_name_description; }
        }
        public string PositionRank {
            get { return "rank"; }
        }
        public int MinistryID {
            get { return ministry_id; }
        }
        public string MinistryName {
            get { return ministry_name; }
        }
        public string DepartmentName {
            get { return department_name; }
        }
        public string Birthdate {
            get { return birth_date; }
        }
        public string InworkDate {
            get { return inwork_date; }
        }
        public string RetireDate {
            get { return retire_date; }
        }
        public string FatherName {
            get { return father_name; }
        }
        public string FatherLastname {
            get { return father_lastname; }
        }
        public string FatherNameAndLastname {
            get { return father_name + " " + father_lastname; }
        }
        public string MotherName {
            get { return mother_name; }
        }
        public string MotherLastname {
            get { return mother_lastname; }
        }
        public string MotherOldLastname {
            get { return mother_old_lastname; }
        }
        public string MotherNameAndLastname {
            get { return mother_name + " " + mother_lastname; }
        }
        public string CoupleName {
            get { return couple_name; }
        }
        public string CoupleLastname {
            get { return couple_lastname; }
        }
        public string CoupleOldLastname {
            get { return couple_old_lastname; }
        }
        public string CoupleNameAndLastname {
            get { return couple_name + " " + couple_lastname; }
        }
        public List<PositionAndSalary> PositionAndSalaryList {
            get { return position_and_salary_list; }
        }
        public List<StudyHistory> StudyHistoryList {
            get { return study_history_list; }
        }
        public List<JobLicense> JobLicenseList {
            get { return job_license_list; }
        }
        public List<TrainingHistory> TrainingHistoryList {
            get { return training_history_list; }
        }
        public List<DisciplinaryAndAmnesty> DisciplinaryAndAmnestyList {
            get { return disciplinary_and_amnesty_list; }
        }
        public double Salary {
            get { return salary; }
        }
        public double SalaryYear {
            get { return salary_year; }
        }
        public string AdminPositionName {
            get { return admin_position_name; }
        }
        public string AdminPositionID {
            get { return admin_position_id; }
        }
        public string PositionWorkID {
            get { return position_work_id; }
        }
        public string PositionWorkName {
            get { return position_work_name; }
        }
        public string NationID {
            get { return nation_id; }
        }
        public string NationNameEN {
            get { return nation_name_en; }
        }
        public string NationNameTH {
            get { return nation_name_th; }
        }
        public string HomeAdd {
            get { return home_add; }
        }
        public string Moo {
            get { return moo; }
        }
        public string Street {
            get { return street; }
        }
        public int DistrictID {
            get { return district_id; }
        }
        public string DistrictName {
            get { return district_name; }
        }
        public int AmphurID {
            get { return amphur_id; }
        }
        public string AmphurName {
            get { return amphur_name; }
        }
        public int ProvinceID {
            get { return province_id; }
        }
        public string ProvinceName {
            get { return province_name; }
        }
        public int Zipcode {
            get { return zipcode; }
        }
        public string Telephone {
            get { return telephone; }
        }
        public int TimeContactID {
            get { return time_contact_id; }
        }
        public string TimeContactName {
            get { return time_contact_name; }
        }
        public int BudgetID {
            get { return budget_id; }
        }
        public string BudgetName {
            get { return budget_name; }
        }
        public int SubStaffTypeID {
            get { return sub_staff_type_id; }
        }
        public string SubStaffTypeName {
            get { return sub_staff_type_name; }
        }
        public string SpecialName {
            get { return special_name; }
        }
        public string TeachISCED_ID {
            get { return teach_isced_id; }
        }
        public string TeachISCED_Name {
            get { return teach_isced_name; }
        }
        public string GraduationLevelID {
            get { return grad_lev_id; }
        }
        public string GraduationLevelName {
            get { return grad_lev_name; }
        }
        public string GraduationCurr {
            get { return grad_curr; }
        }
        public string GraduationISCED_ID {
            get { return grad_isced_id; }
        }
        public string GraduationISCED_Name {
            get { return grad_isced_name; }
        }
        public string GraduationProgramID {
            get { return grad_prog_id; }
        }
        public string GraduationProgramName {
            get { return grad_prog_name; }
        }
        public string GraduationUniversity {
            get { return grad_univ; }
        }
        public int GraduationCountryID {
            get { return grad_country_id; }
        }
        public string GraduationCountryName {
            get { return grad_country_name; }
        }
        public int BranchID {
            get { return branch_id; }
        }
        public string BranchName {
            get { return branch_name; }
        }
        public int RankID {
            get { return rank_id; }
        }
        public string RankName {
            get { return rank_name; }
        }
        public string FacultyID {
            get { return faculty_id; }
        }
        public string FacultyName {
            get { return faculty_name; }
        }
        public string StartPositionWorkID {
            get { return start_position_work_id; }
        }
        public string StartPositionWorkName {
            get { return start_position_work_name; }
        }
        */
    }

}