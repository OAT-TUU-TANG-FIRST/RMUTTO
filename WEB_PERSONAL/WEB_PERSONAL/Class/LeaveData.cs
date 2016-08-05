using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL.Class {

    public class LeaveData {

        public bool HasData = true;
        public int LeaveID;
        public int LeaveTypeID;
        public int LeaveStatusID;
        public DateTime? RequestDate;
        public DateTime? CancelDate;
        public DateTime? FromDate;
        public DateTime? ToDate;
        public int TotalDay;
        public DateTime? LastFromDate;
        public DateTime? LastToDate;
        public int LastTotalDay;
        public string Reason;
        public string Contact;
        public string Telephone;

        public string PS_ID;
        public Person Person;

        public string DocterCertificationFileName;
        public int CountPast;
        public int CountNow;
        public int CountTotal;

        public string WifeFirstName;
        public string WifeLastName;
        public DateTime? GiveBirthDate;

        public string TempleName;
        public string TempleLocation;
        public DateTime? OrdainDate;
        public int Ordained;
        public int Hujed;


        public string PS_Department;

        public int RestSave;
        public int RestLeft;
        public int RestTotal;
        public int BudgetYear;

        public string LeaveTypeName;
        public string LeaveStatusName;

        public int? Allow;
        public DateTime? AllowDate;
        public int? CancelAllow;
        public DateTime? CancelAllowDate;

        public int BossState;
        public int BossStateMax;

        public List<LeaveBossData> LeaveBossDataList = new List<LeaveBossData>();

        public LeaveData() {
            
        }
        public void Load(int ID) {
            HasData = false;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using(OracleCommand com = new OracleCommand("SELECT LEV_DATA.*, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_DATA.LEAVE_TYPE_ID) LEAVE_TYPE_NAME, (SELECT LEAVE_STATUS_NAME FROM LEV_STATUS WHERE LEV_STATUS.LEAVE_STATUS_ID = LEV_DATA.LEAVE_STATUS_ID) LEAVE_STATUS_NAME FROM LEV_DATA WHERE LEAVE_ID = " + ID, con)) {
                    using(OracleDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            HasData = true;
                            int i = 1;
                            LeaveID = ID;
                            LeaveTypeID = reader.GetInt32(i++);
                            LeaveStatusID = reader.GetInt32(i++);

                            if(reader.IsDBNull(i)) {
                                RequestDate = null;
                            } else {
                                RequestDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                CancelDate = null;
                            } else {
                                CancelDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                FromDate = null;
                            } else {
                                FromDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                ToDate = null;
                            } else {
                                ToDate = reader.GetDateTime(i);
                            }
                            ++i;

                            TotalDay = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            if (reader.IsDBNull(i)) {
                                LastFromDate = null;
                            } else {
                                LastFromDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                LastToDate = null;
                            } else {
                                LastToDate = reader.GetDateTime(i);
                            }
                            ++i;

                            LastTotalDay = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            Reason = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            Contact = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            Telephone = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            PS_ID = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            

                            DocterCertificationFileName = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            CountPast = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            CountNow = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            CountTotal = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            WifeFirstName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            WifeLastName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i)) {
                                GiveBirthDate = null;
                            } else {
                                GiveBirthDate = reader.GetDateTime(i);
                            }
                            ++i;

                            TempleName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            TempleLocation = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i)) {
                                OrdainDate = null;
                            } else {
                                OrdainDate = reader.GetDateTime(i);
                            }
                            ++i;

                            Ordained = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            Hujed = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            PS_Department = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            RestSave = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestLeft = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestTotal = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BudgetYear = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            if (reader.IsDBNull(i)) {
                                Allow = null;
                            } else {
                                Allow = reader.GetInt32(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                AllowDate = null;
                            } else {
                                AllowDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                CancelAllow = null;
                            } else {
                                CancelAllow = reader.GetInt32(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                CancelAllowDate = null;
                            } else {
                                CancelAllowDate = reader.GetDateTime(i);
                            }
                            ++i;

                            BossState = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BossStateMax = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            LeaveTypeName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            LeaveStatusName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                        }
                    }
                }

                Person = DatabaseManager.GetPerson(PS_ID);

                using (OracleCommand com = new OracleCommand("SELECT LEV_BOSS_DATA.* FROM LEV_BOSS_DATA WHERE LEAVE_ID = " + ID, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            LeaveBossData leaveBossData = new LeaveBossData();
                            leaveBossData.LeaveBossID = reader.GetInt32(0);
                            leaveBossData.LeaveID = reader.GetInt32(1);
                            leaveBossData.CitizenID = reader.GetString(2);
                            leaveBossData.Comment = reader.IsDBNull(3) ? null : reader.GetString(3);
                            if(reader.IsDBNull(4)) {
                                leaveBossData.Allow = null;
                            } else {
                                leaveBossData.Allow = reader.GetInt32(4);
                            }
                            
                            leaveBossData.State = reader.GetInt32(5);
                            if(reader.IsDBNull(6)) {
                                leaveBossData.AllowDate = null;
                            } else {
                                leaveBossData.AllowDate = reader.GetDateTime(6);
                            }
                            leaveBossData.CancelComment = reader.IsDBNull(7) ? null : reader.GetString(7);
                            if (reader.IsDBNull(8)) {
                                leaveBossData.CancelAllow = null;
                            } else {
                                leaveBossData.CancelAllow = reader.GetInt32(8);
                            }
                            if (reader.IsDBNull(9)) {
                                leaveBossData.CancelAllowDate = null;
                            } else {
                                leaveBossData.CancelAllowDate = reader.GetDateTime(9);
                            }
                            leaveBossData.Person = DatabaseManager.GetPerson(leaveBossData.CitizenID);
                            LeaveBossDataList.Add(leaveBossData);

                        }
                    }
                }

            }
        }
        public void Update() {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_TYPE_ID = :LEAVE_TYPE_ID", con)) {
                    com.Parameters.Add("", "");
                    com.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteCancel() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET CANCEL_DATE = :CANCEL_DATE, CANCEL_REASON = :CANCEL_REASON, LEAVE_STATUS_ID = :LEAVE_STATUS_ID WHERE LEAVE_ID = " + LeaveID, con)) {
                    com.Parameters.Add("CANCEL_DATE", DateTime.Today);
                    com.Parameters.Add("CANCEL_REASON", CancelReason);
                    if(CL_ID == null) {
                        com.Parameters.Add("LEAVE_STATUS_ID", 6);
                    } else {
                        com.Parameters.Add("LEAVE_STATUS_ID", 5);
                    }
                    
                    com.ExecuteNonQuery();
                }

                if (LeaveTypeID == 1) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 2) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 3) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 4) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 5) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 6) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 7) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW - " + TotalDay + " WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                }
            }*/
        }
        public void AddLeaveSick() {
            AddLeave3K();
        }
        public void AddLeaveBusiness() {
            AddLeave3K();
        }
        public void AddLeaveGiveBirth() {
            AddLeave3K();
        }
        public void AddLeave3K() {
            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, DR_CER_FILE_NAME, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, BUDGET_YEAR, BOSS_STATE, BOSS_STATE_MAX) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :DR_CER_FILE_NAME, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :BUDGET_YEAR, :BOSS_STATE, :BOSS_STATE_MAX)", con)) {
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.Parameters.Add("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.Add("LEAVE_STATUS_ID", LeaveStatusID);
                    com.Parameters.Add("PS_ID", PS_ID);
                    com.Parameters.Add("REQ_DATE", RequestDate);
                    com.Parameters.Add("FROM_DATE", FromDate);
                    com.Parameters.Add("TO_DATE", ToDate);
                    com.Parameters.Add("TOTAL_DAY", TotalDay);
                    com.Parameters.Add("REASON", Reason);
                    com.Parameters.Add("CONTACT", Contact);
                    com.Parameters.Add("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue) {
                        com.Parameters.Add("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.Add("LAST_TO_DATE", LastToDate.Value);
                    } else {
                        com.Parameters.Add("LAST_FROM_DATE", null);
                        com.Parameters.Add("LAST_TO_DATE", null);
                    }
                    com.Parameters.Add("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.Add("DR_CER_FILE_NAME", DocterCertificationFileName);
                    com.Parameters.Add("COUNT_PAST", CountPast);
                    com.Parameters.Add("COUNT_NOW", CountNow);
                    com.Parameters.Add("COUNT_TOTAL", CountTotal);
                    com.Parameters.Add("BUDGET_YEAR", Util.BudgetYear());
                    com.Parameters.Add("BOSS_STATE", 1);
                    com.Parameters.Add("BOSS_STATE_MAX", LeaveBossDataList.Count);
                    com.ExecuteNonQuery();
                }

                int bossMax = LeaveBossDataList.Count;
                for (int i = 0; i < bossMax; i++) {
                    LeaveBossData leaveBossData = LeaveBossDataList[i];
                    using (OracleCommand com = new OracleCommand("INSERT INTO LEV_BOSS_DATA (LEAVE_BOSS_ID, LEAVE_ID, CITIZEN_ID, STATE) VALUES (SEQ_LEV_BOSS_DATA.NEXTVAL, :LEAVE_ID, :CITIZEN_ID, :STATE)", con)) {
                        com.Parameters.Add("LEAVE_ID", LeaveID);
                        com.Parameters.Add("CITIZEN_ID", leaveBossData.CitizenID);
                        com.Parameters.Add("STATE", i+1);
                        com.ExecuteNonQuery();
                    }
                }
                

                    if (LeaveTypeID == 1) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                } else if (LeaveTypeID == 2) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                } else if (LeaveTypeID == 3) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                }

            }
        }
        public void AddLeaveRest() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, CL_ID, CL_TT, CL_FN, CL_LN, CL_POS, CL_APOS, CH_ID, CH_TT, CH_FN, CH_LN, CH_POS, CH_APOS, PS_TT, PS_FN, PS_LN, PS_POS, PS_DEPT, PS_APOS, CONTACT, TELEPHONE, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, REST_SAVE, REST_LEFT, REST_TOTAL, BUDGET_YEAR) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :CL_ID, :CL_TT, :CL_FN, :CL_LN, :CL_POS, :CL_APOS, :CH_ID, :CH_TT, :CH_FN, :CH_LN, :CH_POS, :CH_APOS, :PS_TT, :PS_FN, :PS_LN, :PS_POS, :PS_DEPT, :PS_APOS, :CONTACT, :TELEPHONE, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :REST_SAVE, :REST_LEFT, :REST_TOTAL, :BUDGET_YEAR)", con)) {
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.Parameters.Add("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.Add("LEAVE_STATUS_ID", LeaveStatusID);
                    com.Parameters.Add("PS_ID", PS_ID);
                    com.Parameters.Add("REQ_DATE", RequestDate);
                    com.Parameters.Add("FROM_DATE", FromDate);
                    com.Parameters.Add("TO_DATE", ToDate);
                    com.Parameters.Add("TOTAL_DAY", TotalDay);
                    com.Parameters.Add("CL_ID", CL_ID);
                    com.Parameters.Add("CL_TT", CL_Title);
                    com.Parameters.Add("CL_FN", CL_FirstName);
                    com.Parameters.Add("CL_LN", CL_LastName);
                    com.Parameters.Add("CL_POS", CL_Position);
                    com.Parameters.Add("CL_APOS", CL_AdminPosition);
                    com.Parameters.Add("CH_ID", CH_ID);
                    com.Parameters.Add("CH_TT", CH_Title);
                    com.Parameters.Add("CH_FN", CH_FirstName);
                    com.Parameters.Add("CH_LN", CH_LastName);
                    com.Parameters.Add("CH_POS", CH_Position);
                    com.Parameters.Add("CH_APOS", CH_AdminPosition);
                    com.Parameters.Add("PS_TT", PS_Title);
                    com.Parameters.Add("PS_FN", PS_FirstName);
                    com.Parameters.Add("PS_LN", PS_LastName);
                    com.Parameters.Add("PS_POS", PS_Position);
                    com.Parameters.Add("PS_DEPT", PS_Department);
                    com.Parameters.Add("PS_APOS", PS_AdminPosition);
                    com.Parameters.Add("CONTACT", Contact);
                    com.Parameters.Add("TELEPHONE", Telephone);
                    com.Parameters.Add("COUNT_PAST", CountPast);
                    com.Parameters.Add("COUNT_NOW", CountNow);
                    com.Parameters.Add("COUNT_TOTAL", CountTotal);
                    com.Parameters.Add("REST_SAVE", RestSave);
                    com.Parameters.Add("REST_LEFT", RestLeft);
                    com.Parameters.Add("REST_TOTAL", RestTotal);
                    com.Parameters.Add("BUDGET_YEAR", Util.BudgetYear());
                    com.ExecuteNonQuery();
                }
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
            }*/
        }
        public void AddLeaveHelpGiveBirth() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, CL_ID, CL_TT, CL_FN, CL_LN, CL_POS, CL_APOS, CH_ID, CH_TT, CH_FN, CH_LN, CH_POS, CH_APOS, PS_TT, PS_FN, PS_LN, PS_POS, PS_DEPT, PS_APOS, CONTACT, TELEPHONE, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, WIFE_FN, WIFE_LN, GB_DATE, BUDGET_YEAR) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :CL_ID, :CL_TT, :CL_FN, :CL_LN, :CL_POS, :CL_APOS, :CH_ID, :CH_TT, :CH_FN, :CH_LN, :CH_POS, :CH_APOS, :PS_TT, :PS_FN, :PS_LN, :PS_POS, :PS_DEPT, :PS_APOS, :CONTACT, :TELEPHONE, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :WIFE_FN, :WIFE_LN, :GB_DATE, :BUDGET_YEAR)", con)) {
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.Parameters.Add("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.Add("LEAVE_STATUS_ID", LeaveStatusID);
                    com.Parameters.Add("PS_ID", PS_ID);
                    com.Parameters.Add("REQ_DATE", RequestDate);
                    com.Parameters.Add("FROM_DATE", FromDate);
                    com.Parameters.Add("TO_DATE", ToDate);
                    com.Parameters.Add("TOTAL_DAY", TotalDay);
                    com.Parameters.Add("CL_ID", CL_ID);
                    com.Parameters.Add("CL_TT", CL_Title);
                    com.Parameters.Add("CL_FN", CL_FirstName);
                    com.Parameters.Add("CL_LN", CL_LastName);
                    com.Parameters.Add("CL_POS", CL_Position);
                    com.Parameters.Add("CL_APOS", CL_AdminPosition);
                    com.Parameters.Add("CH_ID", CH_ID);
                    com.Parameters.Add("CH_TT", CH_Title);
                    com.Parameters.Add("CH_FN", CH_FirstName);
                    com.Parameters.Add("CH_LN", CH_LastName);
                    com.Parameters.Add("CH_POS", CH_Position);
                    com.Parameters.Add("CH_APOS", CH_AdminPosition);
                    com.Parameters.Add("PS_TT", PS_Title);
                    com.Parameters.Add("PS_FN", PS_FirstName);
                    com.Parameters.Add("PS_LN", PS_LastName);
                    com.Parameters.Add("PS_POS", PS_Position);
                    com.Parameters.Add("PS_DEPT", PS_Department);
                    com.Parameters.Add("PS_APOS", PS_AdminPosition);
                    com.Parameters.Add("CONTACT", Contact);
                    com.Parameters.Add("TELEPHONE", Telephone);
                    com.Parameters.Add("COUNT_PAST", CountPast);
                    com.Parameters.Add("COUNT_NOW", CountNow);
                    com.Parameters.Add("COUNT_TOTAL", CountTotal);
                    com.Parameters.Add("WIFE_FN", WifeFirstName);
                    com.Parameters.Add("WIFE_LN", WifeLastName);
                    com.Parameters.Add("GB_DATE", GiveBirthDate);
                    com.Parameters.Add("BUDGET_YEAR", Util.BudgetYear());
                    com.ExecuteNonQuery();
                }
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
            }*/
        }
        public void AddLeaveOrdain() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, CL_ID, CL_TT, CL_FN, CL_LN, CL_POS, CL_APOS, CH_ID, CH_TT, CH_FN, CH_LN, CH_POS, CH_APOS, PS_TT, PS_FN, PS_LN, PS_POS, PS_DEPT, PS_APOS, PS_BIRTHDATE, PS_WORKIN_DATE, TELEPHONE, OD_ED, TP_NAME, TP_LOC, OD_DATE, BUDGET_YEAR) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :CL_ID, :CL_TT, :CL_FN, :CL_LN, :CL_POS, :CL_APOS, :CH_ID, :CH_TT, :CH_FN, :CH_LN, :CH_POS, :CH_APOS, :PS_TT, :PS_FN, :PS_LN, :PS_POS, :PS_DEPT, :PS_APOS, :PS_BIRTHDATE, :PS_WORKIN_DATE, :TELEPHONE, :OD_ED, :TP_NAME, :TP_LOC, :OD_DATE, :BUDGET_YEAR)", con)) {
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.Parameters.Add("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.Add("LEAVE_STATUS_ID", LeaveStatusID);
                    com.Parameters.Add("PS_ID", PS_ID);
                    com.Parameters.Add("REQ_DATE", RequestDate);
                    com.Parameters.Add("FROM_DATE", FromDate);
                    com.Parameters.Add("TO_DATE", ToDate);
                    com.Parameters.Add("TOTAL_DAY", TotalDay);
                    com.Parameters.Add("CL_ID", CL_ID);
                    com.Parameters.Add("CL_TT", CL_Title);
                    com.Parameters.Add("CL_FN", CL_FirstName);
                    com.Parameters.Add("CL_LN", CL_LastName);
                    com.Parameters.Add("CL_POS", CL_Position);
                    com.Parameters.Add("CL_APOS", CL_AdminPosition);
                    com.Parameters.Add("CH_ID", CH_ID);
                    com.Parameters.Add("CH_TT", CH_Title);
                    com.Parameters.Add("CH_FN", CH_FirstName);
                    com.Parameters.Add("CH_LN", CH_LastName);
                    com.Parameters.Add("CH_POS", CH_Position);
                    com.Parameters.Add("CH_APOS", CH_AdminPosition);
                    com.Parameters.Add("PS_TT", PS_Title);
                    com.Parameters.Add("PS_FN", PS_FirstName);
                    com.Parameters.Add("PS_LN", PS_LastName);
                    com.Parameters.Add("PS_POS", PS_Position);
                    com.Parameters.Add("PS_DEPT", PS_Department);
                    com.Parameters.Add("PS_APOS", PS_AdminPosition);
                    com.Parameters.Add("PS_BIRTHDATE", PS_BirthDate);
                    com.Parameters.Add("PS_WORKIN_DATE", PS_WorkInDate);
                    com.Parameters.Add("TELEPHONE", Telephone);
                    com.Parameters.Add("OD_ED", Ordained);
                    com.Parameters.Add("TP_NAME", TempleName);
                    com.Parameters.Add("TP_LOC", TempleLocation);
                    com.Parameters.Add("OD_DATE", OrdainDate);
                    com.Parameters.Add("BUDGET_YEAR", Util.BudgetYear());
                    com.ExecuteNonQuery();
                }
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
            }*/
        }
        public void AddLeaveHuj() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, CL_ID, CL_TT, CL_FN, CL_LN, CL_POS, CL_APOS, CH_ID, CH_TT, CH_FN, CH_LN, CH_POS, CH_APOS, PS_TT, PS_FN, PS_LN, PS_POS, PS_DEPT, PS_APOS, PS_BIRTHDATE, PS_WORKIN_DATE, HUJ_ED, BUDGET_YEAR) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :CL_ID, :CL_TT, :CL_FN, :CL_LN, :CL_POS, :CL_APOS, :CH_ID, :CH_TT, :CH_FN, :CH_LN, :CH_POS, :CH_APOS, :PS_TT, :PS_FN, :PS_LN, :PS_POS, :PS_DEPT, :PS_APOS, :PS_BIRTHDATE, :PS_WORKIN_DATE, :HUJ_ED, :BUDGET_YEAR)", con)) {
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.Parameters.Add("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.Add("LEAVE_STATUS_ID", LeaveStatusID);
                    com.Parameters.Add("PS_ID", PS_ID);
                    com.Parameters.Add("REQ_DATE", RequestDate);
                    com.Parameters.Add("FROM_DATE", FromDate);
                    com.Parameters.Add("TO_DATE", ToDate);
                    com.Parameters.Add("TOTAL_DAY", TotalDay);
                    com.Parameters.Add("CL_ID", CL_ID);
                    com.Parameters.Add("CL_TT", CL_Title);
                    com.Parameters.Add("CL_FN", CL_FirstName);
                    com.Parameters.Add("CL_LN", CL_LastName);
                    com.Parameters.Add("CL_POS", CL_Position);
                    com.Parameters.Add("CL_APOS", CL_AdminPosition);
                    com.Parameters.Add("CH_ID", CH_ID);
                    com.Parameters.Add("CH_TT", CH_Title);
                    com.Parameters.Add("CH_FN", CH_FirstName);
                    com.Parameters.Add("CH_LN", CH_LastName);
                    com.Parameters.Add("CH_POS", CH_Position);
                    com.Parameters.Add("CH_APOS", CH_AdminPosition);
                    com.Parameters.Add("PS_TT", PS_Title);
                    com.Parameters.Add("PS_FN", PS_FirstName);
                    com.Parameters.Add("PS_LN", PS_LastName);
                    com.Parameters.Add("PS_POS", PS_Position);
                    com.Parameters.Add("PS_DEPT", PS_Department);
                    com.Parameters.Add("PS_APOS", PS_AdminPosition);
                    com.Parameters.Add("PS_BIRTHDATE", PS_BirthDate);
                    com.Parameters.Add("PS_WORKIN_DATE", PS_WorkInDate);
                    com.Parameters.Add("HUJ_ED", Hujed);
                    com.Parameters.Add("BUDGET_YEAR", Util.BudgetYear());
                    com.ExecuteNonQuery();
                }
                DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
            }*/
        }
        public void ExecuteComment() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CL_COM = :CL_COM, CL_DATE = :CL_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 2);
                    com.Parameters.Add("CL_COM", CL_Comment);
                    com.Parameters.Add("CL_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
            }*/
        }
        public void ExecuteCancelComment() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CL_C_COM = :CL_C_COM, CL_C_DATE = :CL_C_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 6);
                    com.Parameters.Add("CL_C_COM", CL_CancelComment);
                    com.Parameters.Add("CL_C_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
            }*/
        }
        public void ExecuteAllow() {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();

                if(BossState != BossStateMax) {
                    LeaveBossData leaveBossData = GetCurrentBoss();
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_BOSS_DATA SET V_COMMENT = :V_COMMENT, V_ALLOW = :V_ALLOW, ALLOW_DATE = :ALLOW_DATE WHERE LEAVE_BOSS_ID = :LEAVE_BOSS_ID", con)) {
                        com.Parameters.Add("V_COMMENT", leaveBossData.Comment );
                        com.Parameters.Add("V_ALLOW", leaveBossData.Allow.Value);
                        com.Parameters.Add("ALLOW_DATE", DateTime.Today);
                        com.Parameters.Add("LEAVE_BOSS_ID", leaveBossData.LeaveBossID);
                        com.ExecuteNonQuery();
                    }
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET BOSS_STATE = BOSS_STATE + 1 WHERE LEAVE_ID = :LEAVE_ID", con)) {
                        com.Parameters.Add("LEAVE_ID", LeaveID);
                        com.ExecuteNonQuery();
                    }

                } else {

                }

               /* using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CH_COM = :CH_COM, CH_ALLOW = :CH_ALLOW, CH_DATE = :CH_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 3);
                    com.Parameters.Add("CH_COM", CH_Comment);
                    com.Parameters.Add("CH_ALLOW", CH_Allow);
                    com.Parameters.Add("CH_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }*/

                
                /*if(CH_Allow == 1) {

                    DateTime start = FromDate.Value;
                    DateTime to = ToDate.Value;

                    while (true) {
                        bool have = false;
                        using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_WORKTIME WHERE TODAY = :TODAY AND CITIZEN_ID = :CITIZEN_ID", con)) {
                            com.Parameters.Add("TODAY", start);
                            com.Parameters.Add("CITIZEN_ID", PS_ID);
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                if (reader.Read()) {
                                    have = true;
                                }
                            }
                        }
                        if (have) {
                            using (OracleCommand com = new OracleCommand("UPDATE LEV_WORKTIME SET LEAVE = 1 WHERE TODAY = :TODAY AND CITIZEN_ID = :CITIZEN_ID", con)) {
                                com.Parameters.Add("TODAY", start);
                                com.Parameters.Add("CITIZEN_ID", PS_ID);
                                com.ExecuteNonQuery();
                            }
                        } else {
                            using (OracleCommand com = new OracleCommand("INSERT INTO LEV_WORKTIME (WORKTIME_ID, CITIZEN_ID, TODAY, LEAVE) VALUES(SEQ_WORKTIME_ID.NEXTVAL, :CITIZEN_ID, :TODAY, 1)", con)) {
                                com.Parameters.Add("CITIZEN_ID", PS_ID);
                                com.Parameters.Add("TODAY", start);
                                com.ExecuteNonQuery();
                            }
                        }

                        start = start.AddDays(1);
                        if ((to - start).TotalDays < 0) {
                            break;
                        }

                    }

                    if (LeaveTypeID == 1) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_NOW = SICK_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 2) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_NOW = BUSINESS_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 3) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_NOW = GB_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 4) {
                        int _restSave = DatabaseManager.ExecuteInt("SELECT REST_SAVE FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                        int _restThis = DatabaseManager.ExecuteInt("SELECT REST_THIS FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                        _restSave -= TotalDay;
                        if(_restSave < 0) {
                            _restThis += _restSave;
                            _restSave = 0;
                        }
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_NOW = REST_REQ, REST_SAVE = " + _restSave + ", REST_THIS = " + _restThis + " WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 5) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_NOW = HGB_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 6) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_NOW = ORDAIN_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 7) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_NOW = HUJ_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    }
                } else if(CH_Allow == 2) {
                    if (LeaveTypeID == 1) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 2) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 3) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 4) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 5) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 6) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 7) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    }
                }*/
                

            }
        }
        public void ExecuteCancelAllow() {
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CH_C_COM = :CH_C_COM, CH_C_ALLOW = :CH_C_ALLOW, CH_C_DATE = :CH_C_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 7);
                    com.Parameters.Add("CH_C_COM", CH_CancelComment);
                    com.Parameters.Add("CH_C_ALLOW", CH_CancelAllow);
                    com.Parameters.Add("CH_C_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
                if (CH_Allow == 1) {

                    DateTime start = FromDate.Value;
                    DateTime to = ToDate.Value;

                    while (true) {

                        using (OracleCommand com = new OracleCommand("DELETE LEV_WORKTIME WHERE TODAY = :TODAY AND CITIZEN_ID = :CITIZEN_ID", con)) {
                            com.Parameters.Add("TODAY", start);
                            com.Parameters.Add("CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }

                        start = start.AddDays(1);
                        if ((to - start).TotalDays < 0) {
                            break;
                        }

                    }

                    if (LeaveTypeID == 1) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_NOW = SICK_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 2) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_NOW = BUSINESS_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 3) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_NOW = GB_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 4) {
                        int _restSave = DatabaseManager.ExecuteInt("SELECT REST_SAVE FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                        int _restThis = DatabaseManager.ExecuteInt("SELECT REST_THIS FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                        int _restThisFix = DatabaseManager.ExecuteInt("SELECT REST_THIS_FIX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                        _restThis += TotalDay;
                        if (_restThis > _restThisFix) {
                            _restSave += _restThisFix - _restThis;
                            _restThis = _restThisFix;
                        }
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_NOW = REST_REQ, REST_SAVE = " + _restSave + ", REST_THIS = " + _restThis + " WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 5) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_NOW = HGB_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 6) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_NOW = ORDAIN_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 7) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_NOW = HUJ_REQ WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    }
                } else if (CH_Allow == 2) {
                    if (LeaveTypeID == 1) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 2) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 3) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 4) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 5) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 6) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    } else if (LeaveTypeID == 7) {
                        using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                            com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                            com.ExecuteNonQuery();
                        }
                    }
                }


            }*/
        }

        public void ExecuteCancelByUser() {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 9);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
                
                DateTime start = FromDate.Value;
                DateTime to = ToDate.Value;

                if (LeaveTypeID == 1) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 2) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 3) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 4) {
                    int _restSave = DatabaseManager.ExecuteInt("SELECT REST_SAVE FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    int _restThis = DatabaseManager.ExecuteInt("SELECT REST_THIS FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    int _restThisFix = DatabaseManager.ExecuteInt("SELECT REST_THIS_FIX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    _restThis += TotalDay;
                    if (_restThis > _restThisFix) {
                        _restSave += _restThisFix - _restThis;
                        _restThis = _restThisFix;
                    }
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW, REST_SAVE = " + _restSave + ", REST_THIS = " + _restThis + " WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 5) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 6) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 7) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                }
            }

        }

        public void ExecuteCancelBySystem() {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 10);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }

                DateTime start = FromDate.Value;
                DateTime to = ToDate.Value;

                if (LeaveTypeID == 1) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 2) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 3) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 4) {
                    int _restSave = DatabaseManager.ExecuteInt("SELECT REST_SAVE FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    int _restThis = DatabaseManager.ExecuteInt("SELECT REST_THIS FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    int _restThisFix = DatabaseManager.ExecuteInt("SELECT REST_THIS_FIX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + BudgetYear);
                    _restThis += TotalDay;
                    if (_restThis > _restThisFix) {
                        _restSave += _restThisFix - _restThis;
                        _restThis = _restThisFix;
                    }
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET REST_REQ = REST_NOW, REST_SAVE = " + _restSave + ", REST_THIS = " + _restThis + " WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 5) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HGB_REQ = HGB_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 6) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET ORDAIN_REQ = ORDAIN_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                } else if (LeaveTypeID == 7) {
                    using (OracleCommand com = new OracleCommand("UPDATE LEV_CLAIM SET HUJ_REQ = HUJ_NOW WHERE YEAR = " + BudgetYear + " AND PS_CITIZEN_ID = :PS_CITIZEN_ID", con)) {
                        com.Parameters.Add("PS_CITIZEN_ID", PS_ID);
                        com.ExecuteNonQuery();
                    }
                }
            }

        }

        public void AddBoss(LeaveBossData leaveBossData) {
            LeaveBossDataList.Add(leaveBossData);
        }
        public LeaveBossData GetCurrentBoss() {
            return GetBossState(BossState);
        }
        public LeaveBossData GetBossState(int state) {
            for (int i = 0; i < LeaveBossDataList.Count; i++) {
                if(LeaveBossDataList[i].State == state) {
                    return LeaveBossDataList[i];
                }
            }
            return null;
        }


    }
}