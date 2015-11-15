﻿using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;

namespace WEB_PERSONAL
{
    public partial class Person_GENERAL : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLMisnistry();
                DDLDepart();
                DDLTitle();
                DDLStaffType();
                DDLMONTH10From();
                DDLYEAR10From();
                DDLMONTH10To();
                DDLYEAR10To();
                txtCitizen.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

                Session["StudyHis"] = new DataTable();
                ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ - ถึง (เดือน ปี)");
                ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
                GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
                GridView1.DataBind();

                Session["JobLisence"] = new DataTable();
                ((DataTable)(Session["JobLisence"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
                ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
                ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
                GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
                GridView2.DataBind();


            }

        }

        private void DDLMisnistry()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_MINISTRY";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMinistry.DataSource = dt;
                        DropDownMinistry.DataValueField = "MINISTRY_ID";
                        DropDownMinistry.DataTextField = "MINISTRY_NAME";
                        DropDownMinistry.DataBind();
                        sqlConn.Close();

                        DropDownMinistry.Items.Insert(0, new ListItem("--กรุณาเลือกกระทรวง--", "0"));

                    }
                }
            }
            catch { }
        }


        private void DDLDepart()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DEPARTMENT_RENEW";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownDepart.DataSource = dt;
                        DropDownDepart.DataValueField = "ID";
                        DropDownDepart.DataTextField = "DEPARTMENT_NAME";
                        DropDownDepart.DataBind();
                        sqlConn.Close();

                        // DropDownDepart.Items.Insert(0, new ListItem("--กรุณาเลือกกรม--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLTitle()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_TITLENAME";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownTitle.DataSource = dt;
                        DropDownTitle.DataValueField = "TITLE_ID";
                        DropDownTitle.DataTextField = "TITLE_NAME_TH";
                        DropDownTitle.DataBind();
                        sqlConn.Close();

                        DropDownTitle.Items.Insert(0, new ListItem("--กรุณาเลือกคำนำหน้านาม--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLStaffType()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFFTYPE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownStaffType.DataSource = dt;
                        DropDownStaffType.DataValueField = "STAFFTYPE_ID";
                        DropDownStaffType.DataTextField = "STAFFTYPE_NAME";
                        DropDownStaffType.DataBind();
                        sqlConn.Close();

                        DropDownStaffType.Items.Insert(0, new ListItem("--กรุณาเลือกประเภทข้าราชการ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLMONTH10From()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DDLMONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth10From.DataSource = dt;
                        DropDownMonth10From.DataValueField = "MONTH_SHORT";
                        DropDownMonth10From.DataTextField = "MONTH_SHORT";
                        DropDownMonth10From.DataBind();
                        sqlConn.Close();

                        DropDownMonth10From.Items.Insert(0, new ListItem("--เดือน--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLMONTH10To()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DDLMONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth10To.DataSource = dt;
                        DropDownMonth10To.DataValueField = "MONTH_SHORT";
                        DropDownMonth10To.DataTextField = "MONTH_SHORT";
                        DropDownMonth10To.DataBind();
                        sqlConn.Close();

                        DropDownMonth10To.Items.Insert(0, new ListItem("--เดือน--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLYEAR10From()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear10From.DataSource = dt;
                        DropDownYear10From.DataValueField = "YEAR_NAME";
                        DropDownYear10From.DataTextField = "YEAR_NAME";
                        DropDownYear10From.DataBind();
                        sqlConn.Close();

                        DropDownYear10From.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLYEAR10To()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear10To.DataSource = dt;
                        DropDownYear10To.DataValueField = "YEAR_NAME";
                        DropDownYear10To.DataTextField = "YEAR_NAME";
                        DropDownYear10To.DataBind();
                        sqlConn.Close();

                        DropDownYear10To.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void ClearData()
        {
            DropDownMinistry.SelectedIndex = 0;
            txtDepart.Text = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            //DropDownDepart.SelectedIndex = 0;
            DropDownTitle.SelectedIndex = 0;
            txtCitizen.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            txtFatherLastName.Text = "";
            txtMotherName.Text = "";
            txtMotherLastName.Text = "";
            txtMotherLastNameOld.Text = "";
            txtMarriedName.Text = "";
            txtMarriedLastName.Text = "";
            txtMarriedLastNameOld.Text = "";
            txtBirthDayNumber.Text = "";
            txtBirthDayChar.Text = "";
            txtDateInWork.Text = "";
            DropDownStaffType.SelectedIndex = 0;
            txtAge60Number.Text = "";
            txtAge60Char.Text = "";
        }

        protected void ClearDataGridViewNumber10()
        {
            txtGrad_Univ.Text = "";
            DropDownMonth10From.SelectedIndex = 0;
            DropDownYear10From.SelectedIndex = 0;
            DropDownMonth10To.SelectedIndex = 0;
            DropDownYear10To.SelectedIndex = 0;
            txtMajor.Text = "";
        }

        protected void ClearDataGridViewNumber11()
        {
            txtGrad_Univ11.Text = "";
            txtDepart11.Text = "";
            txtNolicense11.Text = "";
            txtDateEnable11.Text = "";
        }

        public bool NeedData1To9()
        {
            if (DropDownMinistry.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กระทรวง')", true);
                return true;
            }
            if (DropDownDepart.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กรม')", true);
                return true;
            }
            if (DropDownTitle.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก คำนำหน้านาม')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtCitizen.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รหัสบัตรประชาชน')", true);
                return true;
            }
            if (txtCitizen.Text.Length < 13)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุล')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อบิดา')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtFatherLastName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุลบิดา')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อมารดา')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMotherLastName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุลมารดา')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMotherLastNameOld.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุลมารดาเดิม')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMarriedName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อคู่สมรส')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMarriedLastName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุลคู่สมรส')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMarriedLastNameOld.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุลเดิมคู่สมรสเดิม')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBirthDayNumber.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วัน เดือน ปีเกิด (dd-mm-yyyy)')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBirthDayChar.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วัน เดือน ปีเกิด (ตัวบรรจง เต็มบรรทัด)')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDateInWork.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่บรรจุ (dd-mm-yyyy)')", true);
                return true;
            }
            if (DropDownStaffType.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทข้าราชการ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtAge60Number.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันครบเกษียณอายุ (dd-mm-yyyy)')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtAge60Char.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันครบเกษียณอายุ (ตัวบรรจง เต็มบรรทัด)')", true);
                return true;
            }
            return false;
        }

        public bool NeedData10()
        {
            if (string.IsNullOrEmpty(txtGrad_Univ.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สถานศึกษา<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownMonth10From.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownYear10From.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownMonth10To.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownYear10To.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMajor.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วุฒิ(สาาขาาวิชาเอก)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            return false;
        }

        public bool NeedData11()
        {
            if (string.IsNullOrEmpty(txtGrad_Univ11.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อใบอนุญาต<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDepart11.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หน่วยงาน<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtNolicense11.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เลขที่ใบอนุญาต<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDateEnable11.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่มีผลบังคับใช้(วัน เดือน ปี)<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            return false;
        }

        protected void btnCancelPerson_Click(object sender, EventArgs e)
        {
            ClearData();
            ClearDataGridViewNumber10();
            ClearDataGridViewNumber11();
            Session["StudyHis"] = new DataTable();
            ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ - ถึง (เดือน ปี)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
            GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
            GridView1.DataBind();

            Session["JobLisence"] = new DataTable();
            ((DataTable)(Session["JobLisence"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
            ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
            GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
            GridView2.DataBind();

        }

        protected void btnSubmitPerson_Click(object sender, EventArgs e)
        {
            //if (NeedData1To9() || NeedData10() || NeedData11()) { return; }
            
            ClassPerson P = new ClassPerson();
            P.CITIZEN_ID = txtCitizen.Text;
            P.BIRTHDATE = DateTime.Parse(txtBirthDayNumber.Text);
            P.INWORK_DATE = DateTime.Parse(txtDateInWork.Text);
            P.RETIRE_DATE = DateTime.Parse(txtAge60Number.Text);
            P.DEPARTMENT_NAME = txtDepart.Text;
            P.MINISTRY_ID = Convert.ToInt32(DropDownMinistry.SelectedValue);
            P.TITLE_ID = DropDownTitle.SelectedValue;
            P.BIRTHDATE_LONG = txtBirthDayChar.Text;
            P.RETIRE_DATE_LONG = txtAge60Char.Text;
            P.STAFFTYPE_ID = Convert.ToInt32(DropDownStaffType.SelectedValue);
            P.FATHER_NAME = txtFatherName.Text;
            P.FATHER_LASTNAME = txtFatherLastName.Text;
            P.MOTHER_NAME = txtMotherName.Text;
            P.MOTHER_LASTNAME = txtMotherLastName.Text;
            P.MOTHER_OLD_LASTNAME = txtMotherLastNameOld.Text;
            P.COUPLE_NAME = txtMarriedName.Text;
            P.COUPLE_LASTNAME = txtMarriedLastName.Text;
            P.COUPLE_OLD_LASTNAME = txtMarriedLastNameOld.Text;
            P.PERSON_LASTNAME = txtLastName.Text;
            P.PERSON_NAME = txtName.Text;

            string[] splitDate1 = txtBirthDayNumber.Text.Split('-');
            string[] splitDate2 = txtDateInWork.Text.Split('-');
            string[] splitDate3 = txtAge60Number.Text.Split('-');
            P.BIRTHDATE = new DateTime(Convert.ToInt32(splitDate1[2]), Convert.ToInt32(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            P.INWORK_DATE = new DateTime(Convert.ToInt32(splitDate2[2]), Convert.ToInt32(splitDate2[1]), Convert.ToInt32(splitDate2[0]));
            P.RETIRE_DATE = new DateTime(Convert.ToInt32(splitDate3[2]), Convert.ToInt32(splitDate3[1]), Convert.ToInt32(splitDate3[0]));

            P.InsertPerson();

            for (int i = 0; i < GridView1.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_STUDY_HISTORY VALUES (SEQ_STUDY_HISTORY_ID.NEXTVAL,:CITIZEN_ID,:GRAD_UNIV,:DATE_FROM,:DATE_TO,:MAJOR)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss1 = GridView1.Rows[i].Cells[1].Text.Split('-');
                            for (int j = 0; j < ss1.Length; ++j)
                            {
                                ss1[j] = ss1[j].Trim();
                            }
                            DateTime dt_from = new DateTime(Convert.ToInt32(ss1[1]), Util.MonthToNumber(ss1[0]), 1);
                            DateTime dt_to = new DateTime(Convert.ToInt32(ss1[3]), Util.MonthToNumber(ss1[2]), 1);

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("GRAD_UNIV", GridView1.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("DATE_FROM", dt_from));
                            command.Parameters.Add(new OracleParameter("DATE_TO", dt_to));
                            command.Parameters.Add(new OracleParameter("MAJOR", GridView1.Rows[i].Cells[2].Text));

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
                    }
                }
            }

            for (int i = 0; i < GridView2.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_JOB_LICENSE VALUES (SEQ_JOB_LICENSE_ID.NEXTVAL,:CITIZEN_ID,:LICENCE_NAME,:BRANCH,:LICENCE_NO,:DDATE)", conn))
                    {

                        //try
                        //{
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss2 = GridView2.Rows[i].Cells[3].Text.Split('-');
                            for (int j = 0; j < ss2.Length; ++j)
                            {
                                ss2[j] = ss2[j].Trim();
                            }
                            DateTime DATE_11 = new DateTime(Convert.ToInt32(ss2[2]), Convert.ToInt32(ss2[1]), Convert.ToInt32(ss2[0]));

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("LICENCE_NAME", GridView2.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("BRANCH", GridView2.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("LICENCE_NO", GridView2.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("DDATE", DATE_11));

                            id = command.ExecuteNonQuery();

                        /*}

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            command.Dispose();
                            conn.Close();
                        }*/
                    }
                }
            }

            ClearData();
            ClearDataGridViewNumber10();
            ClearDataGridViewNumber11();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            Session["StudyHis"] = new DataTable();
            ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ - ถึง (เดือน ปี)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
            GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
            GridView1.DataBind();

            Session["JobLisence"] = new DataTable();
            ((DataTable)(Session["JobLisence"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
            ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
            GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
            GridView2.DataBind();

        }


        protected void txtBirthDayNumber_TextChanged(object sender, EventArgs e)
        {
            txtBirthDayChar.Text = Util.ToThaiWord(txtBirthDayNumber.Text);
        }

        protected void txtAge60Number_TextChanged(object sender, EventArgs e)
        {
            txtAge60Char.Text = Util.ToThaiWord(txtAge60Number.Text);
        }

        protected void ButtonPlus10_Click(object sender, EventArgs e)
        {

            DataRow dr = ((DataTable)(Session["StudyHis"])).NewRow();
            dr[0] = txtGrad_Univ.Text;
            dr[1] = DropDownMonth10From.SelectedValue + "-" + DropDownYear10From.SelectedValue + " - " + DropDownMonth10To.SelectedValue + "-" + DropDownYear10To.SelectedValue;
            dr[2] = txtMajor.Text;
            ((DataTable)(Session["StudyHis"])).Rows.Add(dr);
            GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
            GridView1.DataBind();
            ClearDataGridViewNumber10();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษาเรียบร้อย')", true);

        }

        protected void ButtonPlus11_Click(object sender, EventArgs e)
        {
            
            DataRow dr = ((DataTable)(Session["JobLisence"])).NewRow();
            dr[0] = txtGrad_Univ11.Text;
            dr[1] = txtDepart11.Text;
            dr[2] = txtNolicense11.Text;
            dr[3] = txtDateEnable11.Text;
            ((DataTable)(Session["JobLisence"])).Rows.Add(dr);
            GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
            GridView2.DataBind();
            ClearDataGridViewNumber11();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบประกอบวิชาชีพเรียบร้อย')", true);

        }
    }
}