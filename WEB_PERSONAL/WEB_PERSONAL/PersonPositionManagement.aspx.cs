using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class PersonPositionManagement : System.Web.UI.Page {
        string ps;
        string p;
        string t;

        string divisionID;
        //string divisionName;
        string workDivisionID;
        //string workDivisionName;
        string state;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SQLCampus();
            }

            if (Request.QueryString["ps"] != null) {
                ps = Request.QueryString["ps"];
            }
            if(Request.QueryString["p"] != null) {
                p = Request.QueryString["p"];
            }
            if (Request.QueryString["t"] != null) {
                t = Request.QueryString["t"];
            }


            if (Request.QueryString["DIV"] != null) {
                divisionID = Request.QueryString["DIV"];
            }
            /*if (Request.QueryString["DIVN"] != null) {
                divisionName = Request.QueryString["DIVN"];
            }*/
            if (Request.QueryString["WDIV"] != null) {
                workDivisionID = Request.QueryString["WDIV"];
            }
            /*if (Request.QueryString["WDIVN"] != null) {
                workDivisionName = Request.QueryString["WDIVN"];
            }*/
            if (Request.QueryString["state"] != null) {
                state = Request.QueryString["state"];
            } else {
                state = "1";
            }

            if (ps != null) {
                divState1.Visible = true;
                divState2.Visible = false;
                divState3.Visible = false;
                divState4.Visible = false;
                divTab.Visible = false;
                Util.CreateSelectPersonPanel(this, pPerson, "PersonPositionManagement.aspx", ps);
                //createState1Table(q);
                return;
            }

            lbuTab1.CssClass = "ps-tab-unselected";
            lbuTab2.CssClass = "ps-tab-unselected";
            lbuTab3.CssClass = "ps-tab-unselected";
            lbuTab4.CssClass = "ps-tab-unselected";
            lbuTab5.CssClass = "ps-tab-unselected";
            lbuTab6.CssClass = "ps-tab-unselected";

            divState2Tab4.Visible = false;
            divState2Tab5.Visible = false;
            divState2Tab6.Visible = false;

            divState3Tab1.Visible = false;
            divState3Tab2.Visible = false;
            divState3Tab3.Visible = false;
            divState3Tab4.Visible = false;
            divState3Tab5.Visible = false;
            divState3Tab6.Visible = false;

            divState4Tab1.Visible = false;
            divState4Tab2.Visible = false;
            divState4Tab3.Visible = false;
            divState4Tab4.Visible = false;
            divState4Tab5.Visible = false;
            divState4Tab6.Visible = false;

            if (t == "1") {
                lbuTab1.CssClass = "ps-tab-selected";
            } else if (t == "2") {
                lbuTab2.CssClass = "ps-tab-selected";
            } else if (t == "3") {
                lbuTab3.CssClass = "ps-tab-selected";
            } else if (t == "4") {
                lbuTab4.CssClass = "ps-tab-selected";
            } else if (t == "5") {
                lbuTab5.CssClass = "ps-tab-selected";
            } else if (t == "6") {
                lbuTab6.CssClass = "ps-tab-selected";
            }


            if (state == "1") {
                divState1.Visible = true;
                divState2.Visible = false;
                divState3.Visible = false;
                divTab.Visible = false;
                Util.CreateSelectPersonPanel(this, pPerson, "PersonPositionManagement.aspx");
                //createState1Table();

            } else if (state == "2") {
                divState1.Visible = false;
                divState2.Visible = true;
                divState3.Visible = false;
                divTab.Visible = true;

                if (t == "4") {
                    divState2Tab4.Visible = true;
                } else if (t == "5") {
                    divState2Tab5.Visible = true;
                } else if (t == "6") {
                    divState2Tab6.Visible = true;
                }


            } else if (state == "3") {
                divState1.Visible = false;
                divState2.Visible = false;
                divState3.Visible = true;
                divTab.Visible = true;

                if (t == "1") { //อธิการบดี
                    divState3Tab1.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbuNewAtikan.Text = reader.GetString(0);
                                }
                            }
                        }
                        string atikanID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 1", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    atikanID = reader.GetString(0);
                                    lbuOldAtikan.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(atikanID) != "") {
                            imgOldAtikan.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(atikanID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewAtikan.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }

                    }

                } else if (t == "2") { //รองอธิการบดี
                    divState3Tab2.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string campusID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_CAMPUS_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbuNewRongAtikan.Text = reader.GetString(0);
                                    campusID = reader.GetInt32(1).ToString();
                                }
                            }
                        }
                        string rongAtikanID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 2 AND PS_CAMPUS_ID = " + campusID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    rongAtikanID = reader.GetString(0);
                                    lbuOldRongAtikan.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(rongAtikanID) != "") {
                            imgOldRongAtikan.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(rongAtikanID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewRongAtikan.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }
                        using (OracleCommand com = new OracleCommand("SELECT CAMPUS_NAME FROM PS_PERSON, TB_CAMPUS WHERE PS_CITIZEN_ID = '" + p + "' AND PS_CAMPUS_ID = CAMPUS_ID", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab2Campus.Text = reader.GetString(0);
                                }
                            }
                        }

                    }

                } else if (t == "3") { //คณะบดี
                    divState3Tab3.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string facultyID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_FACULTY_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbNewFac.Text = reader.GetString(0);
                                    facultyID = reader.GetInt32(1).ToString();
                                }
                            }
                        }
                        string facID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 4 AND PS_FACULTY_ID = " + facultyID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    facID = reader.GetString(0);
                                    lbOldFac.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(facID) != "") {
                            imgOldFac.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(facID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewFac.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }
                        using (OracleCommand com = new OracleCommand("SELECT FACULTY_NAME FROM PS_PERSON, TB_FACULTY WHERE PS_CITIZEN_ID = '" + p + "' AND PS_FACULTY_ID = FACULTY_ID", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab3Faculty.Text = reader.GetString(0);
                                }
                            }
                        }

                    }
                } else if (t == "4") { //รองคณะบดี
                    divState3Tab4.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string facultyID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_FACULTY_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbNewRongFaculty.Text = reader.GetString(0);
                                    facultyID = reader.GetInt32(1).ToString();
                                }
                            }
                        }
                        string rongFacultyID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 5 AND PS_FACULTY_ID = " + facultyID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    rongFacultyID = reader.GetString(0);
                                    lbOldRongFaculty.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(rongFacultyID) != "") {
                            imgOldFac.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(rongFacultyID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewFac.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }
                        using (OracleCommand com = new OracleCommand("SELECT FACULTY_NAME FROM PS_PERSON, TB_FACULTY WHERE PS_CITIZEN_ID = '" + p + "' AND PS_FACULTY_ID = FACULTY_ID", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab4Faculty.Text = reader.GetString(0);
                                }
                            }
                        }

                    }
                } else if (t == "5") { //หัวหน้าภาควิชา

                    divState3Tab5.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string divisionID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_DIVISION_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbNewDivision.Text = reader.GetString(0);
                                    divisionID = reader.GetInt32(1).ToString();
                                }
                            }
                        }
                        string divisionBossID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 9 AND PS_DIVISION_ID = " + divisionID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    divisionBossID = reader.GetString(0);
                                    lbOldDivision.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(divisionBossID) != "") {
                            imgOldWork.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(divisionBossID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewWork.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }
                        using (OracleCommand com = new OracleCommand("SELECT DIVISION_NAME FROM PS_PERSON, TB_DIVISION WHERE PS_CITIZEN_ID = '" + p + "' AND PS_DIVISION_ID = DIVISION_ID", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab5Division.Text = reader.GetString(0);
                                }
                            }
                        }

                    }

                } else if (t == "6") { //หัวหน้าฝ่าย

                    divState3Tab6.Visible = true;
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string workID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_WORK_DIVISION_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbNewWork.Text = reader.GetString(0);
                                    workID = reader.GetInt32(1).ToString();
                                }
                            }
                        }
                        string workBossID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_ADMIN_POS_ID = 11 AND PS_WORK_DIVISION_ID = " + workID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    workBossID = reader.GetString(0);
                                    lbOldWork.Text = reader.GetString(1);
                                }
                            }
                        }

                        if (DatabaseManager.GetPersonImageFileName(workBossID) != "") {
                            imgOldWork.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(workBossID);
                        }
                        if (DatabaseManager.GetPersonImageFileName(p) != "") {
                            imgNewWork.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                        }
                        using (OracleCommand com = new OracleCommand("SELECT WORK_NAME FROM PS_PERSON, TB_WORK_DIVISION WHERE PS_CITIZEN_ID = '" + p + "' AND PS_WORK_DIVISION_ID = WORK_ID", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab6Work.Text = reader.GetString(0);
                                }
                            }
                        }

                    }

                    /*using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        string workID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH, PS_WORK_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = " + p, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbNewWork.Text = reader.GetString(0);
                                    workID = reader.GetInt32(0).ToString();
                                }
                            }
                        }
                        using (OracleCommand com = new OracleCommand("SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE WORK_ID = " + workID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    lbState3Tab6Work.Text = reader.GetString(0);
                                }
                            }
                        }
                        string workBossID = "";
                        using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON, PS_BOSS WHERE PS_CITIZEN_ID =  PS_ADMIN_POS_ID = 3 AND PS_WORK_ID = " + workID, con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    facID = reader.GetString(0);
                                    lbOldFac.Text = reader.GetString(1);
                                }
                            }
                        }




                        string DV_AND_WD_ID = "";
                        string DV_AND_WD_NAME = "";
                        string oldBossID = "";
                        string DV_AND_WD_SHORT = "";
                        if (divisionID != null) {
                            DV_AND_WD_ID = divisionID;
                            DV_AND_WD_SHORT = "DV";
                            
                        } else {
                            DV_AND_WD_ID = workDivisionID;
                            DV_AND_WD_SHORT = "WD";
                            using (OracleCommand com = new OracleCommand("SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE WORK_ID = " + DV_AND_WD_ID, con)) {
                                using (OracleDataReader reader = com.ExecuteReader()) {
                                    while (reader.Read()) {
                                        DV_AND_WD_NAME = reader.GetString(0);
                                    }
                                }
                            }
                        }
                        lbNewBossDVName1.Text = DV_AND_WD_NAME;
                        lbNewBossDVName2.Text = DV_AND_WD_NAME;

                        //รูปคนเก่า
                        {


                            using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID FROM PS_BOSS WHERE BOS_TYPE = '" + DV_AND_WD_SHORT + "' AND BOS_TYPE_ID = " + DV_AND_WD_ID, con)) {
                                using (OracleDataReader reader = com.ExecuteReader()) {
                                    while (reader.Read()) {
                                        oldBossID = reader.GetString(0);
                                    }
                                }
                            }
                            if (oldBossID != "") {
                                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + oldBossID + "'", con)) {
                                    using (OracleDataReader reader = com.ExecuteReader()) {
                                        while (reader.Read()) {
                                            lbuOldBossName.Text = reader.GetString(0);
                                        }
                                    }
                                }
                            }


                            if (DatabaseManager.GetPersonImageFileName(oldBossID) != "") {
                                imgOldBoss.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(oldBossID);
                            }


                        }

                        //รูปคนใหม่
                        {


                            using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                                using (OracleDataReader reader = com.ExecuteReader()) {
                                    while (reader.Read()) {
                                        lbuNewBossName.Text = reader.GetString(0);
                                    }
                                }
                            }

                            if (DatabaseManager.GetPersonImageFileName(p) != "") {
                                imgNewBoss.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(p);
                            }
                        }


                    }*/
                }




            } else if (state == "4") {
                if(t == "1") {
                    divState4Tab1.Visible = true;
                } else if (t == "2") {
                    divState4Tab2.Visible = true;
                } else if (t == "3") {
                    divState4Tab3.Visible = true;
                } else if (t == "4") {
                    divState4Tab4.Visible = true;
                } else if (t == "5") {
                    divState4Tab5.Visible = true;
                } else if (t == "6") {
                    divState4Tab6.Visible = true;
                }
            }
        }
        protected void SQLCampus() {
            try {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * from TB_CAMPUS";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlCampus.DataSource = dt;
                        ddlCampus.DataValueField = "CAMPUS_ID";
                        ddlCampus.DataTextField = "CAMPUS_NAME";
                        ddlCampus.DataBind();
                        sqlConn.Close();

                        ddlCampus.Items.Insert(0, new ListItem("--กรุณาเลือกวิทยาเขต--", "0"));
                        ddlFaculty.Items.Insert(0, new ListItem("--กรุณาเลือกสำนัก / สถาบัน / คณะ--", "0"));
                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            } catch { }
        }

        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * from TB_FACULTY where CAMPUS_ID = " + ddlCampus.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlFaculty.DataSource = dt;
                        ddlFaculty.DataValueField = "FACULTY_ID";
                        ddlFaculty.DataTextField = "FACULTY_NAME";
                        ddlFaculty.DataBind();
                        sqlConn.Close();

                        ddlFaculty.Items.Insert(0, new ListItem("--กรุณาเลือกสำนัก / สถาบัน / คณะ--", "0"));
                        ddlDivision.Items.Clear();
                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Clear();
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            } catch { }
        }

        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * from TB_DIVISION where FACULTY_ID = " + ddlFaculty.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDivision.DataSource = dt;
                        ddlDivision.DataValueField = "DIVISION_ID";
                        ddlDivision.DataTextField = "DIVISION_NAME";
                        ddlDivision.DataBind();
                        sqlConn.Close();

                        ddlDivision.Items.Insert(0, new ListItem("--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--", "0"));
                        ddlWorkDivision.Items.Clear();
                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            } catch { }

        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    using (OracleCommand sqlCmd = new OracleCommand()) {
                        sqlCmd.CommandText = "select * from TB_WORK_DIVISION where DIVISION_ID = " + ddlDivision.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlWorkDivision.DataSource = dt;
                        ddlWorkDivision.DataValueField = "WORK_ID";
                        ddlWorkDivision.DataTextField = "WORK_NAME";
                        ddlWorkDivision.DataBind();
                        sqlConn.Close();

                        ddlWorkDivision.Items.Insert(0, new ListItem("--กรุณาเลือกงาน / ฝ่าย--", "0"));
                    }
                }
            } catch { }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(*) FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            if (reader.GetInt32(0) == 0) {
                                ddlWorkDivision.Visible = false;
                                trWorkDivision.Visible = false;
                            } else {
                                ddlWorkDivision.Visible = true;
                                trWorkDivision.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        protected void lbuSearch_Click(object sender, EventArgs e) {
            string searchID;
            if(ddlWorkDivision.Visible) {
                searchID = "WDIV=" + ddlWorkDivision.SelectedValue;
            } else {
                searchID = "DIV=" + ddlDivision.SelectedValue;
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&" + searchID);
        }

        protected void lbuState2Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuTab1_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=1");
        }

        protected void lbuTab2_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=2");
        }

        protected void lbuTab3_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=3");
        }

        protected void lbuTab4_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=4");
        }

        protected void lbuTab5_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=5");
        }

        protected void lbuTab6_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=3&t=6");
        }

        protected void lbuAtikanSave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '1'", con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '1' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=1");
        }

        protected void lbuRongAtikanSave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                string campusID = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_CAMPUS_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            campusID = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '2' AND PS_CAMPUS_ID = " + campusID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '2' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=2");
        }

        protected void lbuFacSave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                string facultyID = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_FACULTY_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            facultyID = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '4' AND PS_FACULTY_ID = " + facultyID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '4' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=3");
        }

        protected void lbuRongFacultySave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                string facultyID = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_FACULTY_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            facultyID = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '5' AND PS_FACULTY_ID = " + facultyID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '5' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=4");
        }

        protected void lbuDivisionSave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                string divisionID = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_DIVISION_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            divisionID = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '9' AND PS_DIVISION_ID = " + divisionID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '9' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=5");
        }

        protected void lbuWorkDivisionSave_Click(object sender, EventArgs e) {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                string workID = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_WORK_DIVISION_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            workID = reader.GetInt32(0).ToString();
                        }
                    }
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '0' WHERE PS_ADMIN_POS_ID = '11' AND PS_WORK_DIVISION_ID = " + workID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("UPDATE PS_PERSON SET PS_ADMIN_POS_ID = '11' WHERE PS_CITIZEN_ID = '" + p + "'", con)) {
                    com.ExecuteNonQuery();
                }
            }
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=4&t=6");
            /*OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE FROM PS_BOSS WHERE BOS_TYPE = '" + DV_AND_WD_SHORT + "' AND BOS_TYPE_ID = " + DV_AND_WD_ID, con)) {
                    com.ExecuteNonQuery();
                }
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_BOSS (CITIZEN_ID, BOS_TYPE, BOS_TYPE_ID) VALUES(:CITIZEN_ID, :BOS_TYPE, :BOS_TYPE_ID)", con)) {
                    com.Parameters.Add("CITIZEN_ID", p);
                    com.Parameters.Add("BOS_TYPE", DV_AND_WD_SHORT);
                    com.Parameters.Add("BOS_TYPE_ID", DV_AND_WD_ID);
                    com.ExecuteNonQuery();
                }
            }*/
        }

        protected void lbuState3Tab1Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState3Tab2Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState3Tab3Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState3Tab4Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState3Tab5Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState3Tab6Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx?p=" + p + "&state=2");
        }

        protected void lbuState4Tab1OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuState4Tab2OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuState4Tab3OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuState4Tab4OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuState4Tab5OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        protected void lbuState4Tab6OK_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }

        
    }
}