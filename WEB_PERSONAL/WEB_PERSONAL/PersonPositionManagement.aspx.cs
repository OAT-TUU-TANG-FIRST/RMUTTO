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

        string psID;
        string psName;
        string divisionID;
        string divisionName;
        string workDivisionID;
        string workDivisionName;
        string state;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SQLCampus();
            }
            if(Request.QueryString["psID"] != null) {
                psID = Request.QueryString["psID"];
            }
            if (Request.QueryString["psName"] != null) {
                psName = Request.QueryString["psName"];
            }
            if (Request.QueryString["DIV"] != null) {
                divisionID = Request.QueryString["DIV"];
            }
            if (Request.QueryString["DIVN"] != null) {
                divisionName = Request.QueryString["DIVN"];
            }
            if (Request.QueryString["WDIV"] != null) {
                workDivisionID = Request.QueryString["WDIV"];
            }
            if (Request.QueryString["WDIVN"] != null) {
                workDivisionName = Request.QueryString["WDIVN"];
            }
            if (Request.QueryString["state"] != null) {
                state = Request.QueryString["state"];
            } else {
                state = "1";
            }

            if(state == "1") {
                divState1.Visible = true;
                divState2.Visible = false;
                divState3.Visible = false;

                {
                    TableHeaderRow row = new TableHeaderRow();
                    tbPerson.Rows.Add(row);
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ลำดับ";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เลขประจำตัวประชาชน";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ชื่อ";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เลือก";
                        row.Cells.Add(cell);
                    }
                }
                

                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT PS_ID, PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON", con)) {
                        using(OracleDataReader reader = com.ExecuteReader()) {
                            while(reader.Read()) {
                                string psID = reader.GetString(1);

                                TableRow row = new TableRow();
                                tbPerson.Rows.Add(row);

                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetInt32(0).ToString();
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetString(1);
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetString(2);
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    LinkButton lbu = new LinkButton();
                                    lbu.CssClass = "ps-button";
                                    lbu.Text = "เลือก";
                                    lbu.Click += (e1, e2) => {
                                        state1Selected(psID);
                                    };
                                    cell.Controls.Add(lbu);
                                    row.Cells.Add(cell);
                                }
                            }
                            
                        }
                    }

                }
            } else if(state == "2") {
                divState1.Visible = false;
                divState2.Visible = true;
                divState3.Visible = false;
            } else if(state == "3") {
                divState1.Visible = false;
                divState2.Visible = false;
                divState3.Visible = true;

                if (divisionID != null) {
                    //รูปคนเก่า
                    {
                        string oldBossID = "";
                        using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                            con.Open();
                            using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID FROM PS_BOSS WHERE BOS_TYPE = 'DV' AND BOS_TYPE_ID = " + divisionID, con)) {
                                using(OracleDataReader reader = com.ExecuteReader()) {
                                    while(reader.Read()) {
                                        oldBossID = reader.GetString(0);
                                    }
                                }
                            }
                            if(oldBossID != "") {
                                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + oldBossID + "'", con)) {
                                    using (OracleDataReader reader = com.ExecuteReader()) {
                                        while (reader.Read()) {
                                            lbuOldBossName.Text = reader.GetString(0);
                                        }
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
                        using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                            con.Open();
                            using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + psID + "'", con)) {
                                using (OracleDataReader reader = com.ExecuteReader()) {
                                    while (reader.Read()) {
                                        lbuNewBossName.Text = reader.GetString(0);
                                    }
                                }
                            }
                        }
                        if (DatabaseManager.GetPersonImageFileName(psID) != "") {
                            imgNewBoss.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(psID);
                        }
                    }

                    //ปุ่มย้อนกลับ
                    {
                        LinkButton lbu = new LinkButton();
                        lbu.CssClass = "ps-button";
                        lbu.Text = "ย้อนกลับ";
                        lbu.Click += (e1, e2) => {
                            psName = psName.Replace(' ', '+');
                            Response.Redirect("PersonPositionManagement.aspx?psID=" + psID + "&psName=" + psName + "&state=2");
                        };
                        pConfirm.Controls.Add(lbu);
                    }

                    //ปุ่มยืนยัน
                    {

                        LinkButton lbu = new LinkButton();
                        lbu.CssClass = "ps-button";
                        lbu.Text = "แต่งตั้ง " + psName + " ให้เป็นหัวหน้า" + divisionName;
                        lbu.Click += (e1, e2) => {
                            OracleConnection.ClearAllPools();
                            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                                con.Open();
                                using (OracleCommand com = new OracleCommand("DELETE FROM PS_BOSS WHERE BOS_TYPE = 'DV' AND BOS_TYPE_ID = " + divisionID, con)) {
                                    com.ExecuteNonQuery();
                                }
                                using (OracleCommand com = new OracleCommand("INSERT INTO PS_BOSS (CITIZEN_ID, BOS_TYPE, BOS_TYPE_ID) VALUES(:CITIZEN_ID, :BOS_TYPE, :BOS_TYPE_ID)", con)) {
                                    com.Parameters.Add("CITIZEN_ID", psID);
                                    com.Parameters.Add("BOS_TYPE", "DV");
                                    com.Parameters.Add("BOS_TYPE_ID", divisionID);
                                    com.ExecuteNonQuery();
                                }
                            }
                        };

                        pConfirm.Controls.Add(lbu);
                    }
                   
                } else {

                    //รูปคนเก่า
                    {
                        string oldBossID = "";
                        using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                            con.Open();
                            using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID FROM PS_BOSS WHERE BOS_TYPE = 'WD' AND BOS_TYPE_ID = " + workDivisionID, con)) {
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

                        }
                        if (DatabaseManager.GetPersonImageFileName(oldBossID) != "") {
                            imgOldBoss.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(oldBossID);
                        }

                    }

                    //รูปคนใหม่
                    {
                        using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                            con.Open();
                            using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + psID + "'", con)) {
                                using (OracleDataReader reader = com.ExecuteReader()) {
                                    while (reader.Read()) {
                                        lbuNewBossName.Text = reader.GetString(0);
                                    }
                                }
                            }
                        }
                        if(DatabaseManager.GetPersonImageFileName(psID) != "") {
                            imgNewBoss.Attributes["src"] = "Upload/PersonImage/" + DatabaseManager.GetPersonImageFileName(psID);
                        }
                    }

                    //ปุ่มย้อนกลับ
                    {
                        LinkButton lbu = new LinkButton();
                        lbu.CssClass = "ps-button";
                        lbu.Text = "ย้อนกลับ";
                        lbu.Click += (e1, e2) => {
                            psName = psName.Replace(' ', '+');
                            Response.Redirect("PersonPositionManagement.aspx?psID=" + psID + "&psName=" + psName + "&state=2");
                        };
                        pConfirm.Controls.Add(lbu);
                    }

                    //ปุ่มยืนยัน
                    {

                        LinkButton lbu = new LinkButton();
                        lbu.CssClass = "ps-button";
                        lbu.Text = "แต่งตั้ง " + psName + " ให้เป็นหัวหน้า" + workDivisionName;
                        lbu.Click += (e1, e2) => {
                            OracleConnection.ClearAllPools();
                            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                                con.Open();
                                using (OracleCommand com = new OracleCommand("DELETE FROM PS_BOSS WHERE BOS_TYPE = 'DV' AND BOS_TYPE_ID = " + workDivisionID, con)) {
                                    com.ExecuteNonQuery();
                                }
                                using (OracleCommand com = new OracleCommand("INSERT INTO PS_BOSS (CITIZEN_ID, BOS_TYPE, BOS_TYPE_ID) VALUES(:CITIZEN_ID, :BOS_TYPE, :BOS_TYPE_ID)", con)) {
                                    com.Parameters.Add("CITIZEN_ID", psID);
                                    com.Parameters.Add("BOS_TYPE", "DV");
                                    com.Parameters.Add("BOS_TYPE_ID", workDivisionID);
                                    com.ExecuteNonQuery();
                                }
                            }
                        };

                        pConfirm.Controls.Add(lbu);
                    }

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
                searchID = "WDIV=" + ddlWorkDivision.SelectedValue + "&WDIVN=" + ddlWorkDivision.SelectedItem.Text;
            } else {
                searchID = "DIV=" + ddlDivision.SelectedValue + "&DIVN=" + ddlDivision.SelectedItem.Text;
            }
            Response.Redirect("PersonPositionManagement.aspx?psID=" + psID + "&psName=" + psName + "&" + searchID + "&state=3");
        }

        private void state1Selected(string psID) {
            string psName = "";
            using(OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = " + psID, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            psName = reader.GetString(0);
                        }
                    }
                }
            }
            psName = psName.Replace(' ', '+');
            Response.Redirect("PersonPositionManagement.aspx?psID=" + psID + "&psName=" + psName + "&state=2");
        }

        protected void lbuState2Back_Click(object sender, EventArgs e) {
            Response.Redirect("PersonPositionManagement.aspx");
        }
    }
}