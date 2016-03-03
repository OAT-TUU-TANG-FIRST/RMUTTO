using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class Person_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand cmd = new OracleCommand("select CITIZEN_ID,TITLE_ID,PERSON_NAME,PERSON_LASTNAME,TO_CHAR(BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),BIRTHDATE_LONG,TO_CHAR(RETIRE_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),RETIRE_DATE_LONG,TO_CHAR(INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),STAFFTYPE_ID,FATHER_NAME,FATHER_LASTNAME,MOTHER_NAME,MOTHER_LASTNAME,MOTHER_OLD_LASTNAME,COUPLE_NAME,COUPLE_LASTNAME,COUPLE_OLD_LASTNAME,MINISTRY_ID,DEPARTMENT_NAME,GENDER_ID,NATION_ID,HOMEADD,MOO,STREET,DISTRICT_ID,AMPHUR_ID,PROVINCE_ID,ZIPCODE_ID,TELEPHONE,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_WORK_ID,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_ISCED_ID,GRAD_PROG_ID,GRAD_UNIV,GRAD_COUNTRY_ID,FACULTY_ID,CAMPUS_ID from tb_person where citizen_id = '" + Session["login_id"].ToString() + "'", conn))

                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtCitizen.Text = reader.GetString(0);
                                DropDownTitle.SelectedValue = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                                txtName.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                txtLastName.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                txtBirthDayNumber.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                txtBirthDayChar.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                                txtAge60Number.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                txtAge60Char.Text = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                txtDateInWork.Text = reader.IsDBNull(8) ? "" : reader.GetString(8);
                                DropDownStaffType.SelectedValue = reader.IsDBNull(9) ? "0" : reader.GetInt32(9).ToString();
                                txtFatherName.Text = reader.IsDBNull(10) ? "" : reader.GetString(10);
                                txtFatherLastName.Text = reader.IsDBNull(11) ? "" : reader.GetString(11);
                                txtMotherName.Text = reader.IsDBNull(12) ? "" : reader.GetString(12);
                                txtMotherLastName.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                                txtMotherLastNameOld.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                                txtMarriedName.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                                txtMarriedLastName.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                                txtMarriedLastNameOld.Text = reader.IsDBNull(17) ? "" : reader.GetString(17);
                                DropDownMinistry.SelectedValue = reader.IsDBNull(18) ? "0" : reader.GetInt32(18).ToString();
                                txtDepart.Text = reader.IsDBNull(19) ? "" : reader.GetString(19);
                                DropDownGENDER.SelectedValue = reader.IsDBNull(20) ? "0" : reader.GetInt32(20).ToString();
                                DropDownNATION.SelectedValue = reader.IsDBNull(21) ? "0" : reader.GetString(21).ToString();
                                txtHOMEADD.Text = reader.IsDBNull(22) ? "" : reader.GetString(22);
                                txtMOO.Text = reader.IsDBNull(23) ? "" : reader.GetString(23);
                                txtSTREET.Text = reader.IsDBNull(24) ? "" : reader.GetString(24);
                                ddlDISTRICT.SelectedValue = reader.IsDBNull(25) ? "0" : reader.GetInt32(25).ToString();
                                ddlAMPHUR.SelectedValue = reader.IsDBNull(26) ? "0" : reader.GetInt32(26).ToString();
                                ddlPROVINCE.SelectedValue = reader.IsDBNull(27) ? "0" : reader.GetInt32(27).ToString();
                                txtZIPCODE.Text = reader.IsDBNull(28) ? "" : reader.GetInt32(28).ToString();
                                txtTELEPHONE.Text = reader.IsDBNull(29) ? "" : reader.GetString(29);
                                DropDownTIME_CONTACT.SelectedValue = reader.IsDBNull(30) ? "0" : reader.GetInt32(30).ToString();
                                DropDownBUDGET.SelectedValue = reader.IsDBNull(31) ? "0" : reader.GetInt32(31).ToString();
                                DropDownSUBSTAFFTYPE.SelectedValue = reader.IsDBNull(32) ? "0" : reader.GetInt32(32).ToString();
                                DropDownADMIN_POSITION.SelectedValue = reader.IsDBNull(33) ? "0" : reader.GetString(33).ToString();
                                DropDownPOSITION_WORK.SelectedValue = reader.IsDBNull(34) ? "0" : reader.GetString(34).ToString();
                                txtSPECIAL_NAME.Text = reader.IsDBNull(35) ? "" : reader.GetString(35);
                                DropDownTEACH_ISCED.SelectedValue = reader.IsDBNull(36) ? "0" : reader.GetString(36).ToString();
                                DropDownGRAD_ISCED.SelectedValue = reader.IsDBNull(37) ? "0" : reader.GetString(37).ToString();
                                DropDownGRAD_PROG.SelectedValue = reader.IsDBNull(38) ? "0" : reader.GetString(38).ToString();
                                txtGRAD_UNIVDown.Text = reader.IsDBNull(39) ? "" : reader.GetString(39);
                                DropDownGRAD_COUNTRY.SelectedValue = reader.IsDBNull(40) ? "0" : reader.GetInt32(40).ToString();
                                DropDownFaculty.SelectedValue = reader.IsDBNull(41) ? "0" : reader.GetInt32(41).ToString();
                                DropDownCampus.SelectedValue = reader.IsDBNull(42) ? "0" : reader.GetInt32(42).ToString();
                            }
                        }
                    }
                }

                DDLMisnistry();
                DDLTitle();
                DDLStaffType();
                DDLMONTH10From();
                DDLYEAR10From();
                DDLMONTH10To();
                DDLYEAR10To();
                DDLMONTH12From();
                DDLYEAR12From();
                DDLMONTH12To();
                DDLYEAR12To();
                DDLYEAR13();
                DDLSTAFFTYPE14();
                txtCitizen.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSalary14.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSalaryForPosition14.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtDegree14.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

                BindPROVINCEList();
                DDLGender();
                DDLNation();
                DDLTimeContact();
                DDLBudget();
                DDLSubStaffType();
                DDLAdminPosition();
                DDLPositionWork();
                DDLTeachISCED();
                DDLGradLEV();
                DDLISCED();
                DDLGradProg();
                DDLGradCountry();
                txtTELEPHONE.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtZIPCODE.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                DDLCampus();
            }
        }

        private void DDLGender()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GENDER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownGENDER.DataSource = dt;
                        DropDownGENDER.DataValueField = "GENDER_ID";
                        DropDownGENDER.DataTextField = "GENDER_NAME";
                        DropDownGENDER.DataBind();
                        sqlConn.Close();

                        DropDownGENDER.Items.Insert(0, new ListItem("--กรุณเลือก เพศ--", "0"));

                    }
                }
            }
            catch { }
        }


        private void BindPROVINCEList()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPROVINCE.DataSource = dt;
                        ddlPROVINCE.DataValueField = "PROVINCE_ID";
                        ddlPROVINCE.DataTextField = "PROVINCE_TH";
                        ddlPROVINCE.DataBind();
                        sqlConn.Close();

                        ddlPROVINCE.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAMPHUR.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDISTRICT.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        txtZIPCODE.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlPROVINCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.AddWithValue(":PROVINCE_ID", ddlPROVINCE.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAMPHUR.DataSource = dt;
                        ddlAMPHUR.DataValueField = "AMPHUR_ID";
                        ddlAMPHUR.DataTextField = "AMPHUR_TH";
                        ddlAMPHUR.DataBind();
                        sqlConn.Close();

                        ddlAMPHUR.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDISTRICT.Items.Clear();
                        ddlDISTRICT.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        txtZIPCODE.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlAMPHUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DISTRICT where AMPHUR_ID=:DISTRICT_ID";
                        sqlCmd.Parameters.AddWithValue(":DISTRICT_ID", ddlAMPHUR.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDISTRICT.DataSource = dt;
                        ddlDISTRICT.DataValueField = "DISTRICT_ID";
                        ddlDISTRICT.DataTextField = "DISTRICT_TH";
                        ddlDISTRICT.DataBind();
                        sqlConn.Close();

                        ddlDISTRICT.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        txtZIPCODE.Text = "";

                    }
                }
            }
            catch { }
        }

        protected void ddlDISTRICT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ZIPCODE = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDISTRICT.SelectedValue + "";

            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["RMUTTOORCL"].ConnectionString);

            conn.Open();

            OracleCommand SC = new OracleCommand(ZIPCODE, conn);
            string ZIPCODE2 = SC.ExecuteScalar().ToString();

            txtZIPCODE.Text = ZIPCODE2;
        }

        private void DDLNation()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_NATIONAL";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownNATION.DataSource = dt;
                        DropDownNATION.DataValueField = "NATION_ID";
                        DropDownNATION.DataTextField = "NATION_THA";
                        DropDownNATION.DataBind();
                        sqlConn.Close();

                        DropDownNATION.Items.Insert(0, new ListItem("--กรุณาเลือก สัญชาติ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLTimeContact()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_TIME_CONTACT";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownTIME_CONTACT.DataSource = dt;
                        DropDownTIME_CONTACT.DataValueField = "TIME_CONTACT_ID";
                        DropDownTIME_CONTACT.DataTextField = "TIME_CONTACT_NAME";
                        DropDownTIME_CONTACT.DataBind();
                        sqlConn.Close();

                        DropDownTIME_CONTACT.Items.Insert(0, new ListItem("--กรุณาเลือก ระยะเวลาจ้าง--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLBudget()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_BUDGET";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownBUDGET.DataSource = dt;
                        DropDownBUDGET.DataValueField = "BUDGET_ID";
                        DropDownBUDGET.DataTextField = "BUDGET_NAME";
                        DropDownBUDGET.DataBind();
                        sqlConn.Close();

                        DropDownBUDGET.Items.Insert(0, new ListItem("--กรุณาเลือก ประเภทเงินจ้าง--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLSubStaffType()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_SUBSTAFFTYPE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownSUBSTAFFTYPE.DataSource = dt;
                        DropDownSUBSTAFFTYPE.DataValueField = "SUBSTAFFTYPE_ID";
                        DropDownSUBSTAFFTYPE.DataTextField = "SUBSTAFFTYPE_NAME";
                        DropDownSUBSTAFFTYPE.DataBind();
                        sqlConn.Close();

                        DropDownSUBSTAFFTYPE.Items.Insert(0, new ListItem("--กรุณาเลือก ประเภทบุคลากรย่อย--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLAdminPosition()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_ADMIN_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownADMIN_POSITION.DataSource = dt;
                        DropDownADMIN_POSITION.DataValueField = "ADMIN_POSITION_ID";
                        DropDownADMIN_POSITION.DataTextField = "ADMIN_POSITION_NAME";
                        DropDownADMIN_POSITION.DataBind();
                        sqlConn.Close();

                        DropDownADMIN_POSITION.Items.Insert(0, new ListItem("--กรุณาเลือก ตำแหน่งบริหาร--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLPositionWork()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_WORK";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownPOSITION_WORK.DataSource = dt;
                        DropDownPOSITION_WORK.DataValueField = "POSITION_WORK_ID";
                        DropDownPOSITION_WORK.DataTextField = "POSITION_WORK_NAME";
                        DropDownPOSITION_WORK.DataBind();
                        sqlConn.Close();

                        DropDownPOSITION_WORK.Items.Insert(0, new ListItem("--กรุณาเลือก ตำแหน่งในสายงาน--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLTeachISCED()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_TEACH_ISCED";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownTEACH_ISCED.DataSource = dt;
                        DropDownTEACH_ISCED.DataValueField = "TEACH_ISCED_ID";
                        DropDownTEACH_ISCED.DataTextField = "TEACH_ISCED_NAME_TH";
                        DropDownTEACH_ISCED.DataBind();
                        sqlConn.Close();

                        DropDownTEACH_ISCED.Items.Insert(0, new ListItem("--กรุณาเลือก กลุ่มสาขาวิชาที่สอน(ISCED)--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLGradLEV()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GRAD_LEV";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownGRAD_LEV.DataSource = dt;
                        DropDownGRAD_LEV.DataValueField = "GRAD_LEV_ID";
                        DropDownGRAD_LEV.DataTextField = "GRAD_LEV_NAME";
                        DropDownGRAD_LEV.DataBind();
                        sqlConn.Close();

                        DropDownGRAD_LEV.Items.Insert(0, new ListItem("--กรุณาเลือก ระดับการศึกษาที่จบสูงสุด--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLISCED()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GRAD_ISCED";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownGRAD_ISCED.DataSource = dt;
                        DropDownGRAD_ISCED.DataValueField = "GRAD_ISCED_ID";
                        DropDownGRAD_ISCED.DataTextField = "GRAD_ISCED_NAME_THAI";
                        DropDownGRAD_ISCED.DataBind();
                        sqlConn.Close();

                        DropDownGRAD_ISCED.Items.Insert(0, new ListItem("--กรุณาเลือก กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLGradProg()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GRAD_PROGRAM";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownGRAD_PROG.DataSource = dt;
                        DropDownGRAD_PROG.DataValueField = "GRAD_PROG_ID";
                        DropDownGRAD_PROG.DataTextField = "GRAD_PROG_NAME";
                        DropDownGRAD_PROG.DataBind();
                        sqlConn.Close();

                        DropDownGRAD_PROG.Items.Insert(0, new ListItem("--กรุณาเลือก สาขาวิชาที่จบสูงสุด--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLGradCountry()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_GRAD_COUNTRY order by GRAD_SHORT_NAME asc";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownGRAD_COUNTRY.DataSource = dt;
                        DropDownGRAD_COUNTRY.DataValueField = "GRAD_COUNTRY_ID";
                        DropDownGRAD_COUNTRY.DataTextField = "GRAD_SHORT_NAME";
                        DropDownGRAD_COUNTRY.DataBind();
                        sqlConn.Close();

                        DropDownGRAD_COUNTRY.Items.Insert(0, new ListItem("--กรุณาเลือก ประเทศที่จบการศึกษาสูงสุด--", "0"));

                    }
                }
            }
            catch { }
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

                        DropDownMinistry.Items.Insert(0, new ListItem("--กรุณาเลือก กระทรวง--", "0"));

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
                        sqlCmd.CommandText = "select * from TB_MONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth10From.DataSource = dt;
                        DropDownMonth10From.DataValueField = "MONTH_ID";
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
                        sqlCmd.CommandText = "select * from TB_MONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth10To.DataSource = dt;
                        DropDownMonth10To.DataValueField = "MONTH_ID";
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
                        sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear10From.DataSource = dt;
                        DropDownYear10From.DataValueField = "YEAR_ID";
                        DropDownYear10From.DataTextField = "YEAR_ID";
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
                        sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear10To.DataSource = dt;
                        DropDownYear10To.DataValueField = "YEAR_ID";
                        DropDownYear10To.DataTextField = "YEAR_ID";
                        DropDownYear10To.DataBind();
                        sqlConn.Close();

                        DropDownYear10To.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLMONTH12From()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_MONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth12From.DataSource = dt;
                        DropDownMonth12From.DataValueField = "MONTH_ID";
                        DropDownMonth12From.DataTextField = "MONTH_SHORT";
                        DropDownMonth12From.DataBind();
                        sqlConn.Close();

                        DropDownMonth12From.Items.Insert(0, new ListItem("--เดือน--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLMONTH12To()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_MONTH";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownMonth12To.DataSource = dt;
                        DropDownMonth12To.DataValueField = "MONTH_ID";
                        DropDownMonth12To.DataTextField = "MONTH_SHORT";
                        DropDownMonth12To.DataBind();
                        sqlConn.Close();

                        DropDownMonth12To.Items.Insert(0, new ListItem("--เดือน--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLYEAR12From()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear12From.DataSource = dt;
                        DropDownYear12From.DataValueField = "YEAR_ID";
                        DropDownYear12From.DataTextField = "YEAR_ID";
                        DropDownYear12From.DataBind();
                        sqlConn.Close();

                        DropDownYear12From.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLYEAR12To()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear12To.DataSource = dt;
                        DropDownYear12To.DataValueField = "YEAR_ID";
                        DropDownYear12To.DataTextField = "YEAR_ID";
                        DropDownYear12To.DataBind();
                        sqlConn.Close();

                        DropDownYear12To.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }

        private void DDLYEAR13()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownYear13.DataSource = dt;
                        DropDownYear13.DataValueField = "YEAR_ID";
                        DropDownYear13.DataTextField = "YEAR_ID";
                        DropDownYear13.DataBind();
                        sqlConn.Close();

                        DropDownYear13.Items.Insert(0, new ListItem("--ปี--", "0"));

                    }
                }
            }
            catch { }
        }
        //
        private void DDLSTAFFTYPE14()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFF";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownType_Position14.DataSource = dt;
                        DropDownType_Position14.DataValueField = "ST_ID";
                        DropDownType_Position14.DataTextField = "ST_NAME";
                        DropDownType_Position14.DataBind();
                        sqlConn.Close();

                        DropDownType_Position14.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                    }
                }
            }
            catch { }
        }

        private void DDLCampus()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CAMPUS";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownCampus.DataSource = dt;
                        DropDownCampus.DataValueField = "CAMPUS_ID";
                        DropDownCampus.DataTextField = "CAMPUS_NAME";
                        DropDownCampus.DataBind();
                        sqlConn.Close();

                        DropDownCampus.Items.Insert(0, new ListItem("--กรุณาเลือก วิทยาเขต--", "0"));
                        DropDownFaculty.Items.Insert(0, new ListItem("--กรุณาเลือก คณะ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY where CAMPUS_ID=:CAMPUS_ID";
                        sqlCmd.Parameters.AddWithValue(":CAMPUS_ID", DropDownCampus.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownFaculty.DataSource = dt;
                        DropDownFaculty.DataValueField = "FACULTY_ID";
                        DropDownFaculty.DataTextField = "FACULTY_NAME";
                        DropDownFaculty.DataBind();
                        sqlConn.Close();

                        DropDownFaculty.Items.Insert(0, new ListItem("--กรุณาเลือก คณะ--", "0"));
                    }
                }
            }
            catch { }
        }

        /* private void DDLFaculty()
         {
             try
             {
                 using (OracleConnection sqlConn = new OracleConnection(strConn))
                 {
                     using (OracleCommand sqlCmd = new OracleCommand())
                     {
                         sqlCmd.CommandText = "select * from TB_FACULTY";
                         sqlCmd.Connection = sqlConn;
                         sqlConn.Open();
                         OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                         DataTable dt = new DataTable();
                         da.Fill(dt);
                         DropDownFaculty.DataSource = dt;
                         DropDownFaculty.DataValueField = "FACULTY_ID";
                         DropDownFaculty.DataTextField = "FACULTY_NAME";
                         DropDownFaculty.DataBind();
                         sqlConn.Close();

                         DropDownFaculty.Items.Insert(0, new ListItem("--กรุณาเลือก คณะ--", "0"));
                     }
                 }
             }
             catch { }
         } */

        protected void ClearData()
        {
            txtCitizen.Text = "";
            DropDownCampus.SelectedIndex = 0;
            DropDownFaculty.SelectedIndex = 0;
            DropDownMinistry.SelectedIndex = 0;
            txtDepart.Text = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            DropDownTitle.SelectedIndex = 0;
            txtName.Text = "";
            txtLastName.Text = "";
            txtDateInWork.Text = "";
            txtBirthDayNumber.Text = "";
            txtBirthDayChar.Text = "";
            txtHOMEADD.Text = "";
            txtMOO.Text = "";
            txtSTREET.Text = "";
            ddlPROVINCE.SelectedIndex = 0;
            ddlAMPHUR.SelectedIndex = 0;
            ddlDISTRICT.SelectedIndex = 0;
            txtZIPCODE.Text = "";
            txtTELEPHONE.Text = "";
            DropDownGENDER.SelectedIndex = 0;
            txtAge60Number.Text = "";
            txtAge60Char.Text = "";
            txtFatherName.Text = "";
            txtFatherLastName.Text = "";
            txtMotherName.Text = "";
            txtMotherLastName.Text = "";
            txtMotherLastNameOld.Text = "";
            txtMarriedName.Text = "";
            txtMarriedLastName.Text = "";
            txtMarriedLastNameOld.Text = "";
            DropDownNATION.SelectedIndex = 0;

            DropDownStaffType.SelectedIndex = 0;
            DropDownTIME_CONTACT.SelectedIndex = 0;
            DropDownBUDGET.SelectedIndex = 0;
            DropDownSUBSTAFFTYPE.SelectedIndex = 0;
            DropDownADMIN_POSITION.SelectedIndex = 0;
            DropDownPOSITION_WORK.SelectedIndex = 0;
            txtSPECIAL_NAME.Text = "";
            DropDownTEACH_ISCED.SelectedIndex = 0;
            DropDownGRAD_ISCED.SelectedIndex = 0;
            DropDownGRAD_PROG.SelectedIndex = 0;
            txtGRAD_UNIVDown.Text = "";
            DropDownGRAD_COUNTRY.SelectedIndex = 0;

            DropDownGRAD_LEV.SelectedIndex = 0;
            txtGRAD_CURR.Text = "";
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

        protected void ClearDataGridViewNumber12()
        {
            txtCourse.Text = "";
            DropDownMonth12From.SelectedIndex = 0;
            DropDownYear12From.SelectedIndex = 0;
            DropDownMonth12To.SelectedIndex = 0;
            DropDownYear12To.SelectedIndex = 0;
            txtBranchTrainning.Text = "";
        }

        protected void ClearDataGridViewNumber13()
        {
            DropDownYear13.SelectedIndex = 0;
            txtList13.Text = "";
            txtRefDoc13.Text = "";
        }

        protected void ClearDataGridViewNumber14()
        {
            txtDate14.Text = "";
            txtPosition14.Text = "";
            txtNo_Position14.Text = "";
            DropDownType_Position14.SelectedIndex = 0;
            txtDegree14.Text = "";
            txtSalary14.Text = "";
            txtSalaryForPosition14.Text = "";
            txtRefDoc14.Text = "";
        }

        protected void ClearDataGridViewLev()
        {
            DropDownGRAD_LEV.SelectedIndex = 0;
            txtGRAD_CURR.Text = "";
        }

        public bool NeedData1To9()
        {
            if (string.IsNullOrEmpty(txtCitizen.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เลขบัตรประจำตัวประชาชน 13 หลัก')", true);
                return true;
            }
            //เสริม
            if (txtCitizen.Text.Length < 13)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                return true;
            }
            if (DropDownCampus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก วิทยาเขต')", true);
                return true;
            }
            if (DropDownFaculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก คณะ')", true);
                return true;
            }
            if (DropDownMinistry.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กระทรวง')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDepart.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก กรม')", true);
                return true;
            }
            if (DropDownTitle.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก คำนำหน้านาม')", true);
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
            if (string.IsNullOrEmpty(txtDateInWork.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่บรรจุ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBirthDayNumber.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วัน เดือน ปีเกิด')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBirthDayChar.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วัน เดือน ปีเกิด')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtHOMEADD.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก บ้านเลขที่')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtMOO.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หมู่')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtSTREET.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ถนน')", true);
                return true;
            }
            if (ddlPROVINCE.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก จังหวัด')", true);
                return true;
            }
            if (ddlAMPHUR.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก อำเภอ')", true);
                return true;
            }
            if (ddlDISTRICT.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำบล')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtZIPCODE.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รหัสไปรษณีย์')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtTELEPHONE.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หมายเลขโทรศัพท์ที่ทำงาน')", true);
                return true;
            }
            if (DropDownGENDER.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก เพศ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtAge60Number.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันครบเกษียณอายุ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtAge60Char.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันครบเกษียณอายุ')", true);
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
            if (DropDownNATION.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก สัญชาติ')", true);
                return true;
            }
            //
            //
            //
            if (DropDownStaffType.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทข้าราชการ')", true);
                return true;
            }
            if (DropDownTIME_CONTACT.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ระยะเวลาจ้าง')", true);
                return true;
            }
            if (DropDownBUDGET.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทเงินจ้าง')", true);
                return true;
            }
            if (DropDownSUBSTAFFTYPE.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทบุคลากรย่อย')", true);
                return true;
            }
            if (DropDownADMIN_POSITION.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่งบริหาร')", true);
                return true;
            }
            if (DropDownPOSITION_WORK.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่งในสายงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtSPECIAL_NAME.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สาขางานที่เชี่ยวชาญ')", true);
                return true;
            }
            if (DropDownTEACH_ISCED.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กลุ่มสาขาวิชาที่สอน(ISCED)')", true);
                return true;
            }
            if (DropDownGRAD_ISCED.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กลุ่มสาขาวิชาที่จบสูงสุด')", true);
                return true;
            }
            if (DropDownGRAD_PROG.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก สาขาวิชาที่จบสูงสุด')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtGRAD_UNIVDown.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อสถาบันที่จบการศึกษาสูงสุด')", true);
                return true;
            }
            if (DropDownGRAD_COUNTRY.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเทศที่จบการศึกษาสูงสุด')", true);
                return true;
            }
            //
            //
            //
            if (GridView6.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ระดับการศึกษาที่จบสูงสุด และหลักสูตรที่จบการศึกษาสูงสุด')", true);
                return true;
            }


            return false;
        }

        public bool NeedData10()
        {
            if (GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สถานศึกษา<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownMonth10From.SelectedIndex == 0 && GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownYear10From.SelectedIndex == 0 && GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownMonth10To.SelectedIndex == 0 && GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (DropDownYear10To.SelectedIndex == 0 && GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            if (GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วุฒิ(สาาขาาวิชาเอก)<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            return false;
        }

        public bool NeedData11()
        {
            if (string.IsNullOrEmpty(txtGrad_Univ11.Text) && GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อใบอนุญาต<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDepart11.Text) && GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หน่วยงาน<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtNolicense11.Text) && GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เลขที่ใบอนุญาต<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDateEnable11.Text) && GridView2.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่มีผลบังคับใช้(วัน เดือน ปี)<ใบอนุญาตประกอบวิชาชีพ>')", true);
                return true;
            }
            return false;
        }

        public bool NeedData12()
        {
            if (string.IsNullOrEmpty(txtCourse.Text) && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หลักสูตรฝึกอบรม<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            if (DropDownMonth12From.SelectedIndex == 0 && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            if (DropDownYear12From.SelectedIndex == 0 && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            if (DropDownMonth12To.SelectedIndex == 0 && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            if (DropDownYear12To.SelectedIndex == 0 && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกให้ครบ ตั้งแต่ - ถึง (เดือน ปี)<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBranchTrainning.Text) && GridView3.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก หน่วยงานที่จัดฝึกอบรม<ในส่วนประวัติการฝึกอบรม>')", true);
                return true;
            }
            return false;
        }

        public bool NeedData13()
        {
            if (DropDownYear13.SelectedIndex == 0 && GridView4.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก พ.ศ.<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtList13.Text) && GridView4.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รายการ<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtRefDoc13.Text) && GridView4.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เอกสารอ้างอิง<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>')", true);
                return true;
            }
            return false;
        }

        public bool NeedData14()
        {
            if (string.IsNullOrEmpty(txtDate14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วัน เดือน ปี<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtPosition14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ตำแหน่ง<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtNo_Position14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เลขที่ตำแหน่ง<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (DropDownType_Position14.SelectedIndex == 0 && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่งประเภท<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDegree14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ระดับ<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtSalary14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เงินเดือน<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtSalaryForPosition14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เงินประจำตำแหน่ง<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtRefDoc14.Text) && GridView5.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก เอกสารอ้างอิง<ในส่วนตำแหน่งและเงินเดือน>')", true);
                return true;
            }
            return false;
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["PERSON10"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PERSON10"] = data;
        }

        #endregion

        void BindData()
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }

            ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
            DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", Session["login_id"].ToString());
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            ClassPersonJobLisence p2 = new ClassPersonJobLisence();
            DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", Session["login_id"].ToString());
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            ClassPersonTraining p3 = new ClassPersonTraining();
            DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", Session["login_id"].ToString());
            GridView3.DataSource = dt3;
            GridView3.DataBind();

            ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
            DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", Session["login_id"].ToString());
            GridView4.DataSource = dt4;
            GridView4.DataBind();

            ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
            DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", Session["login_id"].ToString());
            GridView5.DataSource = dt5;
            GridView5.DataBind();

            ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
            DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", Session["login_id"].ToString());
            GridView6.DataSource = dt6;
            GridView6.DataBind();

            SetViewState(dt1);
            SetViewState(dt2);
            SetViewState(dt3);
            SetViewState(dt4);
            SetViewState(dt5);
            SetViewState(dt6);
        }

        void BindData1()
        {
            ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
            DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", txtSearchPersonID.Text);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            SetViewState(dt1);

            ClassPersonJobLisence p2 = new ClassPersonJobLisence();
            DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", txtSearchPersonID.Text);
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            SetViewState(dt2);

            ClassPersonTraining p3 = new ClassPersonTraining();
            DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", txtSearchPersonID.Text);
            GridView3.DataSource = dt3;
            GridView3.DataBind();
            SetViewState(dt3);

            ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
            DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", txtSearchPersonID.Text);
            GridView4.DataSource = dt4;
            GridView4.DataBind();
            SetViewState(dt4);

            ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
            DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", txtSearchPersonID.Text);
            GridView5.DataSource = dt5;
            GridView5.DataBind();
            SetViewState(dt5);

            ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
            DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", txtSearchPersonID.Text);
            GridView6.DataSource = dt6;
            GridView6.DataBind();
            SetViewState(dt6);

        }

        /// <summary>
        /// 
        /// </summary>
        /// 

        void BindDataStudyHistory()
        {
            ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
            DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", txtSearchPersonID.Text);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            SetViewState(dt1);
        }

        void BindDataJobLisence()
        {
            ClassPersonJobLisence p2 = new ClassPersonJobLisence();
            DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", txtSearchPersonID.Text);
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            SetViewState(dt2);
        }

        void BindDataTraining()
        {
            ClassPersonTraining p3 = new ClassPersonTraining();
            DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", txtSearchPersonID.Text);
            GridView3.DataSource = dt3;
            GridView3.DataBind();
            SetViewState(dt3);
        }

        void BindDataDISCIPLINARY()
        {
            ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
            DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", txtSearchPersonID.Text);
            GridView4.DataSource = dt4;
            GridView4.DataBind();
            SetViewState(dt4);
        }

        void BindDataPosiSalary()
        {
            ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
            DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", txtSearchPersonID.Text);
            GridView5.DataSource = dt5;
            GridView5.DataBind();
            SetViewState(dt5);
        }

        void BindDataStudyGraduateTop()
        {
            ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
            DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", txtSearchPersonID.Text);
            GridView6.DataSource = dt6;
            GridView6.DataBind();
            SetViewState(dt6);
        }

        protected void modEditCommand1(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView1.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView1.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand1(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView1.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand1(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
            p1.ID = id;
            p1.DeletePersonStudyHistory();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView1.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand1(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonStudyHistoryID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPersonStudyHistoryID");
            Label lblPersonStudyHistoryCitizenID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPersonStudyHistoryCitizenID");
            TextBox txtPersonStudyHistoryGradUNIVEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPersonStudyHistoryGradUNIVEdit");
            DropDownList ddl_101 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_101");
            DropDownList ddl_102 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_102");
            DropDownList ddl_103 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_103");
            DropDownList ddl_104 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl_104");
            TextBox txtPersonStudyHistoryMajorEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPersonStudyHistoryMajorEdit");

            ClassPersonStudyHistory p1 = new ClassPersonStudyHistory(Convert.ToInt32(lblPersonStudyHistoryID.Text), lblPersonStudyHistoryCitizenID.Text
                , txtPersonStudyHistoryGradUNIVEdit.Text
                , Convert.ToInt32(ddl_101.SelectedValue)
                , Convert.ToInt32(ddl_102.SelectedValue)
                , Convert.ToInt32(ddl_103.SelectedValue)
                , Convert.ToInt32(ddl_104.SelectedValue)
                , txtPersonStudyHistoryMajorEdit.Text);


            if (ddl_101.SelectedIndex == 0 && ddl_102.SelectedIndex == 0 && ddl_103.SelectedIndex == 0 && ddl_104.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตั้งแต่ - ถึง (เดือน ปี) ให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonStudyHistoryGradUNIVEdit.Text) && string.IsNullOrEmpty(txtPersonStudyHistoryMajorEdit.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            p1.UpdatePersonStudyHistory();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView1.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "GRAD_UNIV") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddl_101 = (DropDownList)e.Row.FindControl("ddl_101");

                            sqlCmd1.CommandText = "select * from TB_MONTH";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddl_101.DataSource = dt;
                            ddl_101.SelectedValue = DataBinder.Eval(e.Row.DataItem, "MONTH_FROM").ToString();
                            ddl_101.DataValueField = "MONTH_ID";
                            ddl_101.DataTextField = "MONTH_SHORT";
                            ddl_101.DataBind();
                            sqlConn1.Close();

                            ddl_101.Items.Insert(0, new ListItem("--เดือน--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }

                        using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd2 = new OracleCommand())
                            {
                                DropDownList ddl_102 = (DropDownList)e.Row.FindControl("ddl_102");

                                sqlCmd2.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd2.Connection = sqlConn2;
                                sqlConn2.Open();
                                OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                                DataTable dt = new DataTable();
                                da2.Fill(dt);
                                ddl_102.DataSource = dt;
                                ddl_102.SelectedValue = DataBinder.Eval(e.Row.DataItem, "YEAR_FROM").ToString();
                                ddl_102.DataValueField = "YEAR_ID";
                                ddl_102.DataTextField = "YEAR_ID";
                                ddl_102.DataBind();
                                sqlConn2.Close();

                                ddl_102.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr2 = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn3 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd3 = new OracleCommand())
                            {
                                DropDownList ddl_103 = (DropDownList)e.Row.FindControl("ddl_103");

                                sqlCmd3.CommandText = "select * from TB_MONTH";
                                sqlCmd3.Connection = sqlConn3;
                                sqlConn3.Open();
                                OracleDataAdapter da3 = new OracleDataAdapter(sqlCmd3);
                                DataTable dt = new DataTable();
                                da3.Fill(dt);
                                ddl_103.DataSource = dt;
                                ddl_103.SelectedValue = DataBinder.Eval(e.Row.DataItem, "MONTH_TO").ToString();
                                ddl_103.DataValueField = "MONTH_ID";
                                ddl_103.DataTextField = "MONTH_SHORT";
                                ddl_103.DataBind();
                                sqlConn3.Close();

                                ddl_103.Items.Insert(0, new ListItem("--เดือน--", "0"));
                                DataRowView dr3 = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn4 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd4 = new OracleCommand())
                            {
                                DropDownList ddl_104 = (DropDownList)e.Row.FindControl("ddl_104");

                                sqlCmd4.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd4.Connection = sqlConn4;
                                sqlConn4.Open();
                                OracleDataAdapter da4 = new OracleDataAdapter(sqlCmd4);
                                DataTable dt = new DataTable();
                                da4.Fill(dt);
                                ddl_104.DataSource = dt;
                                ddl_104.SelectedValue = DataBinder.Eval(e.Row.DataItem, "YEAR_TO").ToString();
                                ddl_104.DataValueField = "YEAR_ID";
                                ddl_104.DataTextField = "YEAR_ID";
                                ddl_104.DataBind();
                                sqlConn4.Close();

                                ddl_104.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr4 = e.Row.DataItem as DataRowView;
                            }
                        }
                    }
                }
            }
        }

        protected void myGridViewPersonStudyHistory_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        protected void modEditCommand2(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView2.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView2.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand2(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView2.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView2.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand2(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            ClassPersonJobLisence p2 = new ClassPersonJobLisence();
            p2.ID = id;
            p2.DeletePersonJobLisence();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView2.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView2.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand2(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonJobLisenceID = (Label)GridView2.Rows[e.RowIndex].FindControl("lblPersonJobLisenceID");
            Label lblPersonJobLisenceCitizenID = (Label)GridView2.Rows[e.RowIndex].FindControl("lblPersonJobLisenceCitizenID");
            TextBox txtPersonJobLisenceNameEdit = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtPersonJobLisenceNameEdit");
            TextBox txtPersonJobLisenceBranchEdit = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtPersonJobLisenceBranchEdit");
            TextBox txtPersonJobLisenceLicenseNOEdit = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtPersonJobLisenceLicenseNOEdit");
            TextBox lblPersonJobLisenceDDATEEdit = (TextBox)GridView2.Rows[e.RowIndex].FindControl("txtPersonJobLisenceDDATEEdit");
            DateTime DDATE = DateTime.Parse(lblPersonJobLisenceDDATEEdit.Text);

            ClassPersonJobLisence p2 = new ClassPersonJobLisence(Convert.ToInt32(lblPersonJobLisenceID.Text), lblPersonJobLisenceCitizenID.Text
                , txtPersonJobLisenceNameEdit.Text
                , txtPersonJobLisenceBranchEdit.Text
                , txtPersonJobLisenceLicenseNOEdit.Text
                , DDATE);

            p2.UpdatePersonJobLisence();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView2.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView2.EditIndex = -1;
                BindData1();
            }

        }
        protected void GridView2_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton2");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "LICENCE_NAME") + " จริงๆใช่ไหม ?');");

                //TextBox txt1 = (e.Row.FindControl("txtPersonJobLisenceDDATEEdit") as TextBox);
                //txt1.Attributes.Add("onfocus", "ShowDate('" + txt1.ClientID + "')");

                // var DtShmt = (TextBox)e.Row.FindControl("txtPersonJobLisenceDDATEEdit");
                //ClientScript.RegisterStartupScript(this.GetType(), "datepick",
                //   "$(function () { $('#" + DtShmt.ClientID + "').datepicker({ dateFormat: 'dd/mm/yyyy' });  })", true);
                //$("#ContentPlaceHolder1_txtBirthDayNumber")
            }
        }
        protected void myGridViewPersonJobLisence_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = GetViewState();
            GridView2.DataBind();
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        protected void modEditCommand3(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView3.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView3.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand3(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView3.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView3.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand3(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            ClassPersonTraining p3 = new ClassPersonTraining();
            p3.ID = id;
            p3.DeletePersonTraining();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView3.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView3.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand3(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonTrainingID = (Label)GridView3.Rows[e.RowIndex].FindControl("lblPersonTrainingID");
            Label lblPersonTrainingCitizenID = (Label)GridView3.Rows[e.RowIndex].FindControl("lblPersonTrainingCitizenID");
            TextBox txtPersonTrainingCourseEdit = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtPersonTrainingCourseEdit");
            DropDownList ddl_301 = (DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddl_301");
            DropDownList ddl_302 = (DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddl_302");
            DropDownList ddl_303 = (DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddl_303");
            DropDownList ddl_304 = (DropDownList)GridView3.Rows[e.RowIndex].FindControl("ddl_304");
            TextBox txtPersonTrainingBranchEdit = (TextBox)GridView3.Rows[e.RowIndex].FindControl("txtPersonTrainingBranchEdit");

            ClassPersonTraining p3 = new ClassPersonTraining(Convert.ToInt32(lblPersonTrainingID.Text), lblPersonTrainingCitizenID.Text
                , txtPersonTrainingCourseEdit.Text
                , Convert.ToInt32(ddl_301.SelectedValue)
                , Convert.ToInt32(ddl_302.SelectedValue)
                , Convert.ToInt32(ddl_303.SelectedValue)
                , Convert.ToInt32(ddl_304.SelectedValue)
                , txtPersonTrainingBranchEdit.Text);

            if (ddl_301.SelectedIndex == 0 && ddl_302.SelectedIndex == 0 && ddl_303.SelectedIndex == 0 && ddl_304.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตั้งแต่ - ถึง (เดือน ปี) ให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonTrainingCourseEdit.Text) && string.IsNullOrEmpty(txtPersonTrainingBranchEdit.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            p3.UpdatePersonTraining();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView3.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView3.EditIndex = -1;
                BindData1();
            }

        }
        protected void GridView3_RowDataBound3(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton3");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "COURSE") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddl_301 = (DropDownList)e.Row.FindControl("ddl_301");

                            sqlCmd1.CommandText = "select * from TB_MONTH";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddl_301.DataSource = dt;
                            ddl_301.SelectedValue = DataBinder.Eval(e.Row.DataItem, "MONTH_FROM").ToString();
                            ddl_301.DataValueField = "MONTH_ID";
                            ddl_301.DataTextField = "MONTH_SHORT";
                            ddl_301.DataBind();
                            sqlConn1.Close();

                            ddl_301.Items.Insert(0, new ListItem("--เดือน--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }

                        using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd2 = new OracleCommand())
                            {
                                DropDownList ddl_302 = (DropDownList)e.Row.FindControl("ddl_302");

                                sqlCmd2.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd2.Connection = sqlConn2;
                                sqlConn2.Open();
                                OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                                DataTable dt = new DataTable();
                                da2.Fill(dt);
                                ddl_302.DataSource = dt;
                                ddl_302.SelectedValue = DataBinder.Eval(e.Row.DataItem, "YEAR_FROM").ToString();
                                ddl_302.DataValueField = "YEAR_ID";
                                ddl_302.DataTextField = "YEAR_ID";
                                ddl_302.DataBind();
                                sqlConn2.Close();

                                ddl_302.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr2 = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn3 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd3 = new OracleCommand())
                            {
                                DropDownList ddl_303 = (DropDownList)e.Row.FindControl("ddl_303");

                                sqlCmd3.CommandText = "select * from TB_MONTH";
                                sqlCmd3.Connection = sqlConn3;
                                sqlConn3.Open();
                                OracleDataAdapter da3 = new OracleDataAdapter(sqlCmd3);
                                DataTable dt = new DataTable();
                                da3.Fill(dt);
                                ddl_303.DataSource = dt;
                                ddl_303.SelectedValue = DataBinder.Eval(e.Row.DataItem, "MONTH_TO").ToString();
                                ddl_303.DataValueField = "MONTH_ID";
                                ddl_303.DataTextField = "MONTH_SHORT";
                                ddl_303.DataBind();
                                sqlConn3.Close();

                                ddl_303.Items.Insert(0, new ListItem("--เดือน--", "0"));
                                DataRowView dr3 = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn4 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd4 = new OracleCommand())
                            {
                                DropDownList ddl_304 = (DropDownList)e.Row.FindControl("ddl_304");

                                sqlCmd4.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd4.Connection = sqlConn4;
                                sqlConn4.Open();
                                OracleDataAdapter da4 = new OracleDataAdapter(sqlCmd4);
                                DataTable dt = new DataTable();
                                da4.Fill(dt);
                                ddl_304.DataSource = dt;
                                ddl_304.SelectedValue = DataBinder.Eval(e.Row.DataItem, "YEAR_TO").ToString();
                                ddl_304.DataValueField = "YEAR_ID";
                                ddl_304.DataTextField = "YEAR_ID";
                                ddl_304.DataBind();
                                sqlConn4.Close();

                                ddl_304.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr4 = e.Row.DataItem as DataRowView;
                            }
                        }
                    }
                }
            }
        }
        protected void myGridViewPersonTraining_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = GetViewState();
            GridView3.DataBind();
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        protected void modEditCommand4(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView4.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView4.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand4(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView4.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView4.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand4(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value);
            ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
            p4.ID = id;
            p4.DeletePersonDISCIPLINARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView4.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView4.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand4(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonDISCIPLINARYID = (Label)GridView4.Rows[e.RowIndex].FindControl("lblPersonDISCIPLINARYID");
            Label lblPersonDISCIPLINARYCitizenID = (Label)GridView4.Rows[e.RowIndex].FindControl("lblPersonDISCIPLINARYCitizenID");
            DropDownList ddl_401 = (DropDownList)GridView4.Rows[e.RowIndex].FindControl("ddl_401");
            TextBox txtPersonDISCIPLINARYListEdit = (TextBox)GridView4.Rows[e.RowIndex].FindControl("txtPersonDISCIPLINARYListEdit");
            TextBox txtPersonDISCIPLINARYRefEdit = (TextBox)GridView4.Rows[e.RowIndex].FindControl("txtPersonDISCIPLINARYRefEdit");

            ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY(Convert.ToInt32(lblPersonDISCIPLINARYID.Text), lblPersonDISCIPLINARYCitizenID.Text
                , Convert.ToInt32(ddl_401.SelectedValue)
                , txtPersonDISCIPLINARYListEdit.Text
                , txtPersonDISCIPLINARYRefEdit.Text);

            p4.UpdatePersonDISCIPLINARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView4.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView4.EditIndex = -1;
                BindData1();
            }

        }
        protected void GridView4_RowDataBound4(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton4");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "MENU") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd2 = new OracleCommand())
                        {
                            DropDownList ddl_401 = (DropDownList)e.Row.FindControl("ddl_401");

                            sqlCmd2.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd2.Connection = sqlConn2;
                            sqlConn2.Open();
                            OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                            DataTable dt = new DataTable();
                            da2.Fill(dt);
                            ddl_401.DataSource = dt;
                            ddl_401.SelectedValue = DataBinder.Eval(e.Row.DataItem, "YEAR").ToString();
                            ddl_401.DataValueField = "YEAR_ID";
                            ddl_401.DataTextField = "YEAR_ID";
                            ddl_401.DataBind();
                            sqlConn2.Close();

                            ddl_401.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr2 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewPersonDISCIPLINARY_PageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            GridView4.DataSource = GetViewState();
            GridView4.DataBind();
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        protected void modEditCommand5(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView5.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView5.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand5(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView5.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView5.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand5(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView5.DataKeys[e.RowIndex].Value);
            ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
            p5.ID = id;
            p5.DeletePersonPosiSalary();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView5.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView5.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand5(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonPosiSalaryID = (Label)GridView5.Rows[e.RowIndex].FindControl("lblPersonPosiSalaryID");
            TextBox lblPersonPosiSalaryDateEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryDateEdit");
            TextBox txtPersonPosiSalaryPositionEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryPositionEdit");
            TextBox txtPersonPosiSalaryNoPositionEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryNoPositionEdit");
            DropDownList ddl_501 = (DropDownList)GridView5.Rows[e.RowIndex].FindControl("ddl_501");
            TextBox txtPersonPosiSalaryDegreeEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryDegreeEdit");
            TextBox txtPersonPosiSalarySALARYEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalarySALARYEdit");
            TextBox txtPersonPosiSalaryPositionSALARYEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryPositionSALARYEdit");
            TextBox txtPersonPosiSalaryRefEdit = (TextBox)GridView5.Rows[e.RowIndex].FindControl("txtPersonPosiSalaryRefEdit");
            Label lblPersonPosiSalaryCitizenID = (Label)GridView5.Rows[e.RowIndex].FindControl("lblPersonPosiSalaryCitizenID");
            DateTime DDATE = DateTime.Parse(lblPersonPosiSalaryDateEdit.Text);

            ClassPersonPosiSalary p5 = new ClassPersonPosiSalary(Convert.ToInt32(lblPersonPosiSalaryID.Text)
                , DDATE
                , txtPersonPosiSalaryPositionEdit.Text
                , txtPersonPosiSalaryNoPositionEdit.Text
                , Convert.ToInt32(ddl_501.SelectedValue)
                , txtPersonPosiSalaryDegreeEdit.Text
                , Convert.ToInt32(txtPersonPosiSalarySALARYEdit.Text)
                , Convert.ToInt32(txtPersonPosiSalaryPositionSALARYEdit.Text)
                , txtPersonPosiSalaryRefEdit.Text
                , lblPersonPosiSalaryCitizenID.Text);

            p5.UpdatePersonPosiSalary();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView5.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView5.EditIndex = -1;
                BindData1();
            }

        }
        protected void GridView5_RowDataBound5(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton5");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "POSITION_NAME") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddl_501 = (DropDownList)e.Row.FindControl("ddl_501");

                            sqlCmd1.CommandText = "select * from TB_STAFF";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddl_501.DataSource = dt;
                            ddl_501.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ST_ID").ToString();
                            ddl_501.DataValueField = "ST_ID";
                            ddl_501.DataTextField = "ST_NAME";
                            ddl_501.DataBind();
                            sqlConn1.Close();

                            ddl_501.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewPersonPosiSalary_PageIndexChanging5(object sender, GridViewPageEventArgs e)
        {
            GridView5.PageIndex = e.NewPageIndex;
            GridView5.DataSource = GetViewState();
            GridView5.DataBind();
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        protected void modEditCommand6(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView6.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridView6.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand6(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView6.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView6.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand6(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView6.DataKeys[e.RowIndex].Value);
            ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
            p6.STUDY_GRADUATE_TOP_ID = id;
            p6.DeletePersonStudyGraduateTop();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView6.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView6.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand6(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonStudyTopID = (Label)GridView6.Rows[e.RowIndex].FindControl("lblPersonStudyTopID");
            DropDownList ddl_Lev = (DropDownList)GridView6.Rows[e.RowIndex].FindControl("ddl_Lev");
            TextBox txtPersonStudyTopGradCurrEdit = (TextBox)GridView6.Rows[e.RowIndex].FindControl("txtPersonStudyTopGradCurrEdit");
            Label lblPersonStudyTopCitizen = (Label)GridView6.Rows[e.RowIndex].FindControl("lblPersonStudyTopCitizen");

            ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop(Convert.ToInt32(lblPersonStudyTopID.Text), ddl_Lev.SelectedValue
                , txtPersonStudyTopGradCurrEdit.Text
                , lblPersonStudyTopCitizen.Text);

            p6.UpdatePersonStudyGraduateTop();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridView6.EditIndex = -1;
                BindData();
            }
            else
            {
                GridView6.EditIndex = -1;
                BindData1();
            }

        }
        protected void GridView6_RowDataBound6(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton6");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ " + DataBinder.Eval(e.Row.DataItem, "GRAD_CURR") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd2 = new OracleCommand())
                        {
                            DropDownList ddl_Lev = (DropDownList)e.Row.FindControl("ddl_Lev");

                            sqlCmd2.CommandText = "select * from TB_GRAD_LEV";
                            sqlCmd2.Connection = sqlConn2;
                            sqlConn2.Open();
                            OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                            DataTable dt = new DataTable();
                            da2.Fill(dt);
                            ddl_Lev.DataSource = dt;
                            ddl_Lev.SelectedValue = DataBinder.Eval(e.Row.DataItem, "GRAD_LEV_ID").ToString();
                            ddl_Lev.DataValueField = "GRAD_LEV_ID";
                            ddl_Lev.DataTextField = "GRAD_LEV_NAME";
                            ddl_Lev.DataBind();
                            sqlConn2.Close();

                            ddl_Lev.Items.Insert(0, new ListItem("--ระดับการศึกษาที่จบสูงสุด--", "0"));
                            DataRowView dr2 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewPersonStudyTop_PageIndexChanging6(object sender, GridViewPageEventArgs e)
        {
            GridView6.PageIndex = e.NewPageIndex;
            GridView6.DataSource = GetViewState();
            GridView6.DataBind();
        }

        protected void btnCancelPerson_Click(object sender, EventArgs e)
        {
            /*
            ClearData();
            ClearDataGridViewNumber10();
            ClearDataGridViewNumber11();
            ClearDataGridViewNumber12();
            ClearDataGridViewNumber13();
            ClearDataGridViewNumber14();
            ClearDataGridViewLev();
            */
            Response.Redirect("Default.aspx");

        }

        protected void btnSubmitPerson_Click(object sender, EventArgs e)
        {
            //if (NeedData1To9() || NeedData10() || NeedData11() || NeedData12() || NeedData13() || NeedData14()) { return; }
            if (NeedData1To9()) { return; }

            ClassPerson P = new ClassPerson();
            ClassPersonStudyGraduateTop P1 = new ClassPersonStudyGraduateTop();

            P.CITIZEN_ID = txtCitizen.Text;
            P.TITLE_ID = Convert.ToInt32(DropDownTitle.SelectedValue);
            P.PERSON_NAME = txtName.Text;
            P.PERSON_LASTNAME = txtLastName.Text;
            P.BIRTHDATE = DateTime.Parse(txtBirthDayNumber.Text);
            P.BIRTHDATE_LONG = txtBirthDayChar.Text;
            P.RETIRE_DATE = DateTime.Parse(txtAge60Number.Text);
            P.RETIRE_DATE_LONG = txtAge60Char.Text;
            P.INWORK_DATE = DateTime.Parse(txtDateInWork.Text);
            P.STAFFTYPE_ID = Convert.ToInt32(DropDownStaffType.SelectedValue);
            P.FATHER_NAME = txtFatherName.Text;
            P.FATHER_LASTNAME = txtFatherLastName.Text;
            P.MOTHER_NAME = txtMotherName.Text;
            P.MOTHER_LASTNAME = txtMotherLastName.Text;
            P.MOTHER_OLD_LASTNAME = txtMotherLastNameOld.Text;
            P.COUPLE_NAME = txtMarriedName.Text;
            P.COUPLE_LASTNAME = txtMarriedLastName.Text;
            P.COUPLE_OLD_LASTNAME = txtMarriedLastNameOld.Text;
            P.MINISTRY_ID = Convert.ToInt32(DropDownMinistry.SelectedValue);
            P.DEPARTMENT_NAME = txtDepart.Text;
            P.GENDER_ID = Convert.ToInt32(DropDownGENDER.SelectedValue);
            P.NATION_ID = DropDownNATION.SelectedValue;
            P.HOMEADD = txtHOMEADD.Text;
            P.MOO = txtMOO.Text;
            P.STREET = txtSTREET.Text;
            P.DISTRICT_ID = Convert.ToInt32(ddlDISTRICT.SelectedValue);
            P.AMPHUR_ID = Convert.ToInt32(ddlAMPHUR.SelectedValue);
            P.PROVINCE_ID = Convert.ToInt32(ddlPROVINCE.SelectedValue);
            P.ZIPCODE_ID = Convert.ToInt32(txtZIPCODE.Text);
            P.TELEPHONE = txtTELEPHONE.Text;
            P.TIME_CONTACT_ID = Convert.ToInt32(DropDownTIME_CONTACT.SelectedValue);
            P.BUDGET_ID = Convert.ToInt32(DropDownBUDGET.SelectedValue);
            P.SUBSTAFFTYPE_ID = Convert.ToInt32(DropDownSUBSTAFFTYPE.SelectedValue);
            P.ADMIN_POSITION_ID = DropDownADMIN_POSITION.SelectedValue;
            P.POSITION_WORK_ID = DropDownPOSITION_WORK.SelectedValue;
            P.SPECIAL_NAME = txtSPECIAL_NAME.Text;
            P.TEACH_ISCED_ID = DropDownTEACH_ISCED.SelectedValue;
            P.GRAD_ISCED_ID = DropDownGRAD_ISCED.SelectedValue;
            P.GRAD_PROG_ID = DropDownGRAD_PROG.SelectedValue;
            P.GRAD_UNIV = txtGRAD_UNIVDown.Text;
            P.GRAD_COUNTRY_ID = Convert.ToInt32(DropDownGRAD_COUNTRY.SelectedValue);
            P.FACULTY_ID = Convert.ToInt32(DropDownFaculty.SelectedValue);
            P.CAMPUS_ID = Convert.ToInt32(DropDownCampus.SelectedValue);

            string[] splitDate1 = txtBirthDayNumber.Text.Split(' ');
            string[] splitDate2 = txtDateInWork.Text.Split(' ');
            string[] splitDate3 = txtAge60Number.Text.Split(' ');
            if (splitDate1.Length == 4)
            {
                splitDate1[2] = splitDate1[3];
            }
            if (splitDate2.Length == 4)
            {
                splitDate2[2] = splitDate2[3];
            }
            if (splitDate3.Length == 4)
            {
                splitDate3[2] = splitDate3[3];
            }
            P.BIRTHDATE = new DateTime(Convert.ToInt32(splitDate1[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            P.INWORK_DATE = new DateTime(Convert.ToInt32(splitDate2[2]), Util.MonthToNumber(splitDate2[1]), Convert.ToInt32(splitDate2[0]));
            P.RETIRE_DATE = new DateTime(Convert.ToInt32(splitDate3[2]), Util.MonthToNumber(splitDate3[1]), Convert.ToInt32(splitDate3[0]));

            P1.GRAD_CURR = txtGRAD_CURR.Text;
            P1.CITIZEN_ID = txtCitizen.Text;
            P1.GRAD_LEV_ID = DropDownGRAD_LEV.SelectedValue;

            P.UpdatePerson();
            P1.UpdatePersonStudyGraduateTop();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);

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
            if (DropDownMonth10From.SelectedValue == "0" || DropDownYear10From.SelectedValue == "0" || DropDownMonth10To.SelectedValue == "0" || DropDownYear10To.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือกเดือนและปีให้ถูกต้อง<ในส่วนประวัติการศึกษา>");
                return;
            }
            if (txtGrad_Univ.Text != "" && txtMajor.Text != "")
            {
                ClassPersonStudyHistory P = new ClassPersonStudyHistory();
                P.CITIZEN_ID = txtCitizen.Text;
                P.GRAD_UNIV = txtGrad_Univ.Text;
                P.MONTH_FROM = Convert.ToInt32(DropDownMonth10From.SelectedValue);
                P.YEAR_FROM = Convert.ToInt32(DropDownYear10From.SelectedValue);
                P.MONTH_TO = Convert.ToInt32(DropDownMonth10To.SelectedValue);
                P.YEAR_TO = Convert.ToInt32(DropDownYear10To.SelectedValue);
                P.MAJOR = txtMajor.Text;
                P.InsertPersonStudyHistory();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเในส่วน<ประวัติการศึกษา>เรียบร้อย')", true);
                ClearDataGridViewNumber10();
                ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
                DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", Session["login_id"].ToString());
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนประวัติการศึกษา>')", true);
            }
        }

        protected void ButtonPlus11_Click(object sender, EventArgs e)
        {
            if (txtGrad_Univ11.Text != "" && txtDepart11.Text != "" && txtNolicense11.Text != "" && txtDateEnable11.Text != "")
            {
                ClassPersonJobLisence P = new ClassPersonJobLisence();
                P.CITIZEN_ID = txtCitizen.Text;
                P.LICENCE_NAME = txtGrad_Univ11.Text;
                P.BRANCH = txtDepart11.Text;
                P.LICENCE_NO = txtNolicense11.Text;
                P.DDATE = DateTime.Parse(txtDateEnable11.Text);

                P.InsertPersonJobLisence();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเในส่วน<ใบอนุญาตประกอบวิชาชีพ>เรียบร้อย')", true);
                ClearDataGridViewNumber11();
                ClassPersonJobLisence p2 = new ClassPersonJobLisence();
                DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", Session["login_id"].ToString());
                GridView2.DataSource = dt2;
                GridView2.DataBind();
                SetViewState(dt2);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบถ้วน<ส่วนใบประกอบวิชาชีพ>')", true);
            }
        }

        protected void ButtonPlus12_Click(object sender, EventArgs e)
        {
            if (DropDownMonth12From.SelectedValue == "0" || DropDownYear12From.SelectedValue == "0" || DropDownMonth12To.SelectedValue == "0" || DropDownYear12To.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือกเดือนและปีให้ถูกต้อง<ในส่วนประวัติการฝึกอบรม>");
                return;
            }
            if (txtCourse.Text != "" && txtBranchTrainning.Text != "")
            {
                ClassPersonTraining P = new ClassPersonTraining();
                P.CITIZEN_ID = txtCitizen.Text;
                P.COURSE = txtCourse.Text;
                P.MONTH_FROM = Convert.ToInt32(DropDownMonth12From.SelectedValue);
                P.YEAR_FROM = Convert.ToInt32(DropDownYear12From.SelectedValue);
                P.MONTH_TO = Convert.ToInt32(DropDownMonth12To.SelectedValue);
                P.YEAR_TO = Convert.ToInt32(DropDownYear12To.SelectedValue);
                P.BRANCH_TRAINING = txtBranchTrainning.Text;
                P.InsertPersonTraining();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเในส่วน<ประวัติการฝึกอบรม>เรียบร้อย')", true);
                ClearDataGridViewNumber12();
                ClassPersonTraining p3 = new ClassPersonTraining();
                DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", Session["login_id"].ToString());
                GridView3.DataSource = dt3;
                GridView3.DataBind();
                SetViewState(dt3);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนประวัติการฝึกอบรม>");
            }
        }

        protected void ButtonPlus13_Click(object sender, EventArgs e)
        {
            if (DropDownYear13.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือก พ.ศ. ให้ถูกต้อง<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>");
                return;
            }
            if (txtList13.Text != "" && txtRefDoc13.Text != "")
            {
                ClassPersonDISCIPLINARY P = new ClassPersonDISCIPLINARY();
                P.CITIZEN_ID = txtCitizen.Text;
                P.YEAR = Convert.ToInt32(DropDownYear13.SelectedValue);
                P.MENU = txtList13.Text;
                P.REF_DOC = txtRefDoc13.Text;
                P.InsertPersonDISCIPLINARY();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเในส่วน<การได้รับโทษทางวินัยและการนิรโทษกรรม>เรียบร้อย')", true);
                ClearDataGridViewNumber13();
                ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
                DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", Session["login_id"].ToString());
                GridView4.DataSource = dt4;
                GridView4.DataBind();
                SetViewState(dt4);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>");
            }
        }

        protected void ButtonPlus14_Click(object sender, EventArgs e)
        {
            if (DropDownType_Position14.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือก ตำแหน่งประเภท ให้ถูกต้อง<ในส่วนตำแหน่งและเงินเดือน>");
                return;
            }
            if (txtDate14.Text != "" && txtPosition14.Text != "" && txtNo_Position14.Text != "" && txtSalary14.Text != "" && txtSalaryForPosition14.Text != "" && txtRefDoc14.Text != "")
            {
                ClassPersonPosiSalary P = new ClassPersonPosiSalary();
                P.DDATE = DateTime.Parse(txtDate14.Text);
                P.POSITION_NAME = txtPosition14.Text;
                P.PERSON_ID = txtNo_Position14.Text;
                P.ST_ID = Convert.ToInt32(DropDownType_Position14.SelectedValue);
                P.POSITION_ID = txtDegree14.Text;
                P.SALARY = Convert.ToInt32(txtSalary14.Text);
                P.POSITION_SALARY = Convert.ToInt32(txtSalaryForPosition14.Text);
                P.REFERENCE_DOCUMENT = txtRefDoc14.Text;
                P.CITIZEN_ID = txtCitizen.Text;
                P.InsertPersonPosiSalary();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเในส่วน<ตำแหน่งและเงินเดือน>เรียบร้อย')", true);
                ClearDataGridViewNumber14();
                ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
                DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", Session["login_id"].ToString());
                GridView5.DataSource = dt5;
                GridView5.DataBind();
                SetViewState(dt5);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนตำแหน่งและเงินเดือน>");
            }
        }

        protected void ButtonPlusLEV_Click(object sender, EventArgs e)
        {
            if (DropDownGRAD_LEV.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือก ระดับการศึกษาที่จบสูงสุด ให้ถูกต้อง");
                return;
            }
            if (txtGRAD_CURR.Text != "")
            {
                ClassPersonStudyGraduateTop P = new ClassPersonStudyGraduateTop();
                P.GRAD_CURR = txtGRAD_CURR.Text;
                P.CITIZEN_ID = txtCitizen.Text;
                P.GRAD_LEV_ID = DropDownGRAD_LEV.SelectedValue;
                P.InsertPersonStudyGraduateTop();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลระดับการศึกษาที่จบสูงสุด และหลักสูตรที่จบการศึกษาสูงสุด เรียบร้อย')", true);
                ClearDataGridViewLev();
                ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
                DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", Session["login_id"].ToString());
                GridView6.DataSource = dt6;
                GridView6.DataBind();
                SetViewState(dt6);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลหลักสูตรที่จบการศึกษาสูงสุด");
            }

        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
                DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", Session["login_id"].ToString());
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            else
            {
                ClassPersonStudyHistory p1 = new ClassPersonStudyHistory();
                DataTable dt1 = p1.GetPersonStudyHistory("", "", "", "", "", "", txtSearchPersonID.Text);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            //
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonJobLisence p2 = new ClassPersonJobLisence();
                DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", Session["login_id"].ToString());
                GridView2.DataSource = dt2;
                GridView2.DataBind();
                SetViewState(dt2);
            }
            else
            {
                ClassPersonJobLisence p2 = new ClassPersonJobLisence();
                DataTable dt2 = p2.GetPersonJobLisence("", "", "", "", txtSearchPersonID.Text);
                GridView2.DataSource = dt2;
                GridView2.DataBind();
                SetViewState(dt2);
            }
            //
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonTraining p3 = new ClassPersonTraining();
                DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", Session["login_id"].ToString());
                GridView3.DataSource = dt3;
                GridView3.DataBind();
                SetViewState(dt3);
            }
            else
            {
                ClassPersonTraining p3 = new ClassPersonTraining();
                DataTable dt3 = p3.GetPersonTraining("", "", "", "", "", "", txtSearchPersonID.Text);
                GridView3.DataSource = dt3;
                GridView3.DataBind();
                SetViewState(dt3);
            }
            //
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
                DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", Session["login_id"].ToString());
                GridView4.DataSource = dt4;
                GridView4.DataBind();
                SetViewState(dt4);
            }
            else
            {
                ClassPersonDISCIPLINARY p4 = new ClassPersonDISCIPLINARY();
                DataTable dt4 = p4.GetPersonDISCIPLINARY("", "", "", txtSearchPersonID.Text);
                GridView4.DataSource = dt4;
                GridView4.DataBind();
                SetViewState(dt4);
            }
            //
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
                DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", Session["login_id"].ToString());
                GridView5.DataSource = dt5;
                GridView5.DataBind();
                SetViewState(dt5);

            }
            else
            {
                ClassPersonPosiSalary p5 = new ClassPersonPosiSalary();
                DataTable dt5 = p5.GetPersonPosiSalary("", "", "", "", 0, 0, 0, "", txtSearchPersonID.Text);
                GridView5.DataSource = dt5;
                GridView5.DataBind();
                SetViewState(dt5);
            }
            //
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
                DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", Session["login_id"].ToString());
                GridView6.DataSource = dt6;
                GridView6.DataBind();
                SetViewState(dt6);
            }
            else
            {
                ClassPersonStudyGraduateTop p6 = new ClassPersonStudyGraduateTop();
                DataTable dt6 = p6.GetPersonStudyGraduateTop("", "", txtSearchPersonID.Text);
                GridView6.DataSource = dt6;
                GridView6.DataBind();
                SetViewState(dt6);
            }

            /*using (OracleConnection conn = Util.OC())
            {
                using (OracleCommand cmd = new OracleCommand("select CITIZEN_ID,TITLE_ID,PERSON_NAME,PERSON_LASTNAME,TO_CHAR(BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),BIRTHDATE_LONG,TO_CHAR(RETIRE_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),RETIRE_DATE_LONG,TO_CHAR(INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),STAFFTYPE_ID,FATHER_NAME,FATHER_LASTNAME,MOTHER_NAME,MOTHER_LASTNAME,MOTHER_OLD_LASTNAME,COUPLE_NAME,COUPLE_LASTNAME,COUPLE_OLD_LASTNAME,MINISTRY_ID,DEPARTMENT_NAME,GENDER_ID,NATION_ID,HOMEADD,MOO,STREET,DISTRICT_ID,AMPHUR_ID,PROVINCE_ID,ZIPCODE_ID,TELEPHONE,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_WORK_ID,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_ISCED_ID,GRAD_PROG_ID,GRAD_UNIV,GRAD_COUNTRY_ID,FACULTY_ID,CAMPUS_ID from tb_person where citizen_id = '" + txtSearchPersonID.Text + "'", conn))

                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtCitizen.Text = reader.GetString(0);
                            DropDownTitle.SelectedValue = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                            txtName.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            txtLastName.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            txtBirthDayNumber.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            txtBirthDayChar.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            txtAge60Number.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            txtAge60Char.Text = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            txtDateInWork.Text = reader.IsDBNull(8) ? "" : reader.GetString(8);
                            DropDownStaffType.SelectedValue = reader.IsDBNull(9) ? "0" : reader.GetInt32(9).ToString();
                            txtFatherName.Text = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            txtFatherLastName.Text = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            txtMotherName.Text = reader.IsDBNull(12) ? "" : reader.GetString(12);
                            txtMotherLastName.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            txtMotherLastNameOld.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                            txtMarriedName.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                            txtMarriedLastName.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                            txtMarriedLastNameOld.Text = reader.IsDBNull(17) ? "" : reader.GetString(17);
                            DropDownMinistry.SelectedValue = reader.IsDBNull(18) ? "0" : reader.GetInt32(18).ToString();
                            txtDepart.Text = reader.IsDBNull(19) ? "" : reader.GetString(19);
                            DropDownGENDER.SelectedValue = reader.IsDBNull(20) ? "0" : reader.GetInt32(20).ToString();
                            DropDownNATION.SelectedValue = reader.IsDBNull(21) ? "0" : reader.GetString(21).ToString();
                            txtHOMEADD.Text = reader.IsDBNull(22) ? "" : reader.GetString(22);
                            txtMOO.Text = reader.IsDBNull(23) ? "" : reader.GetString(23);
                            txtSTREET.Text = reader.IsDBNull(24) ? "" : reader.GetString(24);
                            ddlDISTRICT.SelectedValue = reader.IsDBNull(25) ? "0" : reader.GetInt32(25).ToString();
                            ddlAMPHUR.SelectedValue = reader.IsDBNull(26) ? "0" : reader.GetInt32(26).ToString();
                            ddlPROVINCE.SelectedValue = reader.IsDBNull(27) ? "0" : reader.GetInt32(27).ToString();
                            txtZIPCODE.Text = reader.IsDBNull(28) ? "" : reader.GetInt32(28).ToString();
                            txtTELEPHONE.Text = reader.IsDBNull(29) ? "" : reader.GetString(29);
                            DropDownTIME_CONTACT.SelectedValue = reader.IsDBNull(30) ? "0" : reader.GetInt32(30).ToString();
                            DropDownBUDGET.SelectedValue = reader.IsDBNull(31) ? "0" : reader.GetInt32(31).ToString();
                            DropDownSUBSTAFFTYPE.SelectedValue = reader.IsDBNull(32) ? "0" : reader.GetInt32(32).ToString();
                            DropDownADMIN_POSITION.SelectedValue = reader.IsDBNull(33) ? "0" : reader.GetString(33).ToString();
                            DropDownPOSITION_WORK.SelectedValue = reader.IsDBNull(34) ? "0" : reader.GetString(34).ToString();
                            txtSPECIAL_NAME.Text = reader.IsDBNull(35) ? "" : reader.GetString(35);
                            DropDownTEACH_ISCED.SelectedValue = reader.IsDBNull(36) ? "0" : reader.GetString(36).ToString();
                            DropDownGRAD_ISCED.SelectedValue = reader.IsDBNull(37) ? "0" : reader.GetString(37).ToString();
                            DropDownGRAD_PROG.SelectedValue = reader.IsDBNull(38) ? "0" : reader.GetString(38).ToString();
                            txtGRAD_UNIVDown.Text = reader.IsDBNull(39) ? "" : reader.GetString(39);
                            DropDownGRAD_COUNTRY.SelectedValue = reader.IsDBNull(40) ? "0" : reader.GetInt32(40).ToString();
                            DropDownFaculty.SelectedValue = reader.IsDBNull(41) ? "0" : reader.GetInt32(41).ToString();
                            DropDownCampus.SelectedValue = reader.IsDBNull(42) ? "0" : reader.GetInt32(42).ToString();
                        }
                    }
                } 
            }*/

        }

    }
}