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
        public string PS_Title;
        public string PS_FirstName;
        public string PS_LastName;
        public string PS_Position;
        public string PS_AdminPosition;
        public DateTime? PS_WorkInDate;
        public DateTime? PS_BirthDate;

        public string CL_ID;
        public string CL_Title;
        public string CL_FirstName;
        public string CL_LastName;
        public string CL_Position;
        public string CL_AdminPosition;
        public string CL_Comment;
        public DateTime? CL_Date;

        public string CH_ID;
        public string CH_Title;
        public string CH_FirstName;
        public string CH_LastName;
        public string CH_Position;
        public string CH_AdminPosition;
        public string CH_Comment;
        public int CH_Allow;
        public DateTime? CH_Date;

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

        public string CancelReason;
        public string CL_CancelComment;
        public DateTime? CL_CancelDate;
        public string CH_CancelComment;
        public int CH_CancelAllow;
        public DateTime? CH_CancelDate;

        public string PS_Department;

        public int RestSave;
        public int RestLeft;
        public int RestTotal;
        public int BudgetYear;

        public string LeaveTypeName;
        public string LeaveStatusName;

        public LeaveData() {
            
        }
        public void Load(int ID) {
            HasData = false;
            using(OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
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
                            PS_Title = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            PS_FirstName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            PS_LastName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            PS_Position = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            PS_AdminPosition = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i)) {
                                PS_WorkInDate = null;
                            } else {
                                PS_WorkInDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i)) {
                                PS_BirthDate = null;
                            } else {
                                PS_BirthDate = reader.GetDateTime(i);
                            }
                            ++i;

                            CL_ID = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_Title = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_FirstName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_LastName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_Position = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_AdminPosition = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_Comment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i)) {
                                CL_Date = null;
                            } else {
                                CL_Date = reader.GetDateTime(i);
                            }
                            ++i;

                            CH_ID = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_Title = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_FirstName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_LastName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_Position = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_AdminPosition = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_Comment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_Allow = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            if (reader.IsDBNull(i)) {
                                CH_Date = null;
                            } else {
                                CH_Date = reader.GetDateTime(i);
                            }
                            ++i;

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
                            CancelReason = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CL_CancelComment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i)) {
                                CL_CancelDate = null;
                            } else {
                                CL_CancelDate = reader.GetDateTime(i);
                            }
                            ++i;

                            CH_CancelComment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            CH_CancelAllow = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            if (reader.IsDBNull(i)) {
                                CH_CancelDate = null;
                            } else {
                                CH_CancelDate = reader.GetDateTime(i);
                            }
                            ++i;

                            PS_Department = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            RestSave = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestLeft = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestTotal = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BudgetYear = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            LeaveTypeName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            LeaveStatusName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                        }
                    }
                }
            }
        }
        public void Update() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_TYPE_ID = :LEAVE_TYPE_ID", con)) {
                    com.Parameters.Add("", "");
                    com.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteCancel() {
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
            }
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
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, LEAVE_STATUS_ID, PS_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, CL_ID, CL_TT, CL_FN, CL_LN, CL_POS, CL_APOS, CH_ID, CH_TT, CH_FN, CH_LN, CH_POS, CH_APOS, PS_TT, PS_FN, PS_LN, PS_POS, PS_DEPT, PS_APOS, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, DR_CER_FILE_NAME, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, BUDGET_YEAR) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :LEAVE_STATUS_ID, :PS_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :CL_ID, :CL_TT, :CL_FN, :CL_LN, :CL_POS, :CL_APOS, :CH_ID, :CH_TT, :CH_FN, :CH_LN, :CH_POS, :CH_APOS, :PS_TT, :PS_FN, :PS_LN, :PS_POS, :PS_DEPT, :PS_APOS, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :DR_CER_FILE_NAME, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :BUDGET_YEAR)", con)) {
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
                    com.ExecuteNonQuery();
                }

                if(LeaveTypeID == 1) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET SICK_REQ = SICK_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                } else if (LeaveTypeID == 2) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET BUSINESS_REQ = BUSINESS_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                } else if (LeaveTypeID == 3) {
                    DatabaseManager.ExecuteNonQuery("UPDATE LEV_CLAIM SET GB_REQ = GB_NOW + " + TotalDay + " WHERE PS_CITIZEN_ID = '" + PS_ID + "' AND YEAR = " + Util.BudgetYear());
                }

            }
        }
        public void AddLeaveRest() {
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
            }
        }
        public void AddLeaveHelpGiveBirth() {
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
            }
        }
        public void AddLeaveOrdain() {
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
            }
        }
        public void AddLeaveHuj() {
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
            }
        }
        public void ExecuteComment() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CL_COM = :CL_COM, CL_DATE = :CL_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 2);
                    com.Parameters.Add("CL_COM", CL_Comment);
                    com.Parameters.Add("CL_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteCancelComment() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CL_C_COM = :CL_C_COM, CL_C_DATE = :CL_C_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 6);
                    com.Parameters.Add("CL_C_COM", CL_CancelComment);
                    com.Parameters.Add("CL_C_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteAllow() {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE LEV_DATA SET LEAVE_STATUS_ID = :LEAVE_STATUS_ID, CH_COM = :CH_COM, CH_ALLOW = :CH_ALLOW, CH_DATE = :CH_DATE WHERE LEAVE_ID = :LEAVE_ID", con)) {
                    com.Parameters.Add("LEAVE_STATUS_ID", 3);
                    com.Parameters.Add("CH_COM", CH_Comment);
                    com.Parameters.Add("CH_ALLOW", CH_Allow);
                    com.Parameters.Add("CH_DATE", DateTime.Today);
                    com.Parameters.Add("LEAVE_ID", LeaveID);
                    com.ExecuteNonQuery();
                }
                if(CH_Allow == 1) {
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
                } else if(CH_Allow == 0) {
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
                

            }
        }
        public void ExecuteCancelAllow() {
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


            }
        }

    }
}