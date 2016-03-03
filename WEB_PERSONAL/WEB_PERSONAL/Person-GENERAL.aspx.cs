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

                Session["StudyHis"] = new DataTable();
                ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["StudyHis"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["StudyHis"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
                GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
                GridView1.DataBind();

                Session["JobLisence"] = new DataTable();
                ((DataTable)(Session["JobLisence"])).Columns.Add("ชื่อใบอนุญาต");
                ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
                ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
                ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
                GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
                GridView2.DataBind();

                Session["Trainning"] = new DataTable();
                ((DataTable)(Session["Trainning"])).Columns.Add("หลักสูตรฝึกอบรม");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
                GridView3.DataSource = ((DataTable)(Session["Trainning"]));
                GridView3.DataBind();

                Session["Punished"] = new DataTable();
                ((DataTable)(Session["Punished"])).Columns.Add("พ.ศ.");
                ((DataTable)(Session["Punished"])).Columns.Add("รายการ");
                ((DataTable)(Session["Punished"])).Columns.Add("เอกสารอ้างอิง");
                GridView4.DataSource = ((DataTable)(Session["Punished"]));
                GridView4.DataBind();

                Session["PositionAndSalary"] = new DataTable();
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("วัน เดือน ปี");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่ง");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เลขที่ตำแหน่ง");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่งประเภท");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ระดับ");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินเดือน");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินประจำตำแหน่ง");
                ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เอกสารอ้างอิง");
                GridView5.DataSource = ((DataTable)(Session["PositionAndSalary"]));
                GridView5.DataBind();

                Session["Lev"] = new DataTable();
                ((DataTable)(Session["Lev"])).Columns.Add("ระดับการศึกษาที่จบสูงสุด");
                ((DataTable)(Session["Lev"])).Columns.Add("สาขาที่จบสูงสุด");
                GridView6.DataSource = ((DataTable)(Session["Lev"]));
                GridView6.DataBind();

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
          /*  if (GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สถานศึกษา<ในส่วนประวัติการศึกษา>')", true);
                return true;
            }
            */
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

        protected void btnCancelPerson_Click(object sender, EventArgs e)
        {
            /*ClearData();
            ClearDataGridViewNumber10();
            ClearDataGridViewNumber11();
            ClearDataGridViewNumber12();
            ClearDataGridViewNumber13();
            ClearDataGridViewNumber14();
            ClearDataGridViewLev();

            Session["StudyHis"] = new DataTable();
            ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ - ถึง (เดือน ปี)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
            GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
            GridView1.DataBind();

            Session["JobLisence"] = new DataTable();
            ((DataTable)(Session["JobLisence"])).Columns.Add("ชื่อใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
            ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
            GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
            GridView2.DataBind();

            Session["Trainning"] = new DataTable();
            ((DataTable)(Session["Trainning"])).Columns.Add("หลักสูตรฝึกอบรม");
            ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ - ถึง (เดือน ปี)");
            ((DataTable)(Session["Trainning"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
            GridView3.DataSource = ((DataTable)(Session["Trainning"]));
            GridView3.DataBind();

            Session["Punished"] = new DataTable();
            ((DataTable)(Session["Punished"])).Columns.Add("พ.ศ.");
            ((DataTable)(Session["Punished"])).Columns.Add("รายการ");
            ((DataTable)(Session["Punished"])).Columns.Add("เอกสารอ้างอิง");
            GridView4.DataSource = ((DataTable)(Session["Punished"]));
            GridView4.DataBind();

            Session["PositionAndSalary"] = new DataTable();
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("วัน เดือน ปี");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เลขที่ตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่งประเภท");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ระดับ");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินเดือน");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินประจำตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เอกสารอ้างอิง");
            GridView5.DataSource = ((DataTable)(Session["PositionAndSalary"]));
            GridView5.DataBind();

            Session["Lev"] = new DataTable();
            ((DataTable)(Session["Lev"])).Columns.Add("ระดับการศึกษาที่จบสูงสุด");
            ((DataTable)(Session["Lev"])).Columns.Add("สาขาที่จบสูงสุด");
            GridView6.DataSource = ((DataTable)(Session["Lev"]));
            GridView6.DataBind();
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
            P.BIRTHDATE = new DateTime(Convert.ToInt32(splitDate1[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            P.INWORK_DATE = new DateTime(Convert.ToInt32(splitDate2[2]), Util.MonthToNumber(splitDate2[1]), Convert.ToInt32(splitDate2[0]));
            P.RETIRE_DATE = new DateTime(Convert.ToInt32(splitDate3[2]), Util.MonthToNumber(splitDate3[1]), Convert.ToInt32(splitDate3[0]));

            P1.GRAD_CURR = txtGRAD_CURR.Text;
            P1.CITIZEN_ID = txtCitizen.Text;
            P1.GRAD_LEV_ID = DropDownGRAD_LEV.SelectedValue;

            P.InsertPerson();
            P1.InsertPersonStudyGraduateTop();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);

            for (int i = 0; i < GridView1.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_STUDY_HISTORY (CITIZEN_ID,GRAD_UNIV,MONTH_FROM,YEAR_FROM,MONTH_TO,YEAR_TO,MAJOR) VALUES (:CITIZEN_ID,:GRAD_UNIV,:MONTH_FROM,:YEAR_FROM,:MONTH_TO,:YEAR_TO,:MAJOR)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("GRAD_UNIV", GridView1.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("MONTH_FROM", GridView1.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("YEAR_FROM", GridView1.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("MONTH_TO", GridView1.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("YEAR_TO", GridView1.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("MAJOR", GridView1.Rows[i].Cells[5].Text));

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
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_JOB_LICENSE (CITIZEN_ID,LICENCE_NAME,BRANCH,LICENCE_NO,DDATE) VALUES (:CITIZEN_ID,:LICENCE_NAME,:BRANCH,:LICENCE_NO,:DDATE)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss2 = GridView2.Rows[i].Cells[3].Text.Split(' ');
                            for (int j = 0; j < ss2.Length; ++j)
                            {
                                ss2[j] = ss2[j].Trim();
                            }
                            DateTime DATE_11 = new DateTime(Convert.ToInt32(ss2[2]), Util.MonthToNumber(ss2[1]), Convert.ToInt32(ss2[0]));

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("LICENCE_NAME", GridView2.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("BRANCH", GridView2.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("LICENCE_NO", GridView2.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("DDATE", DATE_11));

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

            for (int i = 0; i < GridView3.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_TRAINING_HISTORY (CITIZEN_ID,COURSE,MONTH_FROM,YEAR_FROM,MONTH_TO,YEAR_TO,BRANCH_TRAINING) VALUES (:CITIZEN_ID,:COURSE,:MONTH_FROM,:YEAR_FROM,:MONTH_TO,:YEAR_TO,:BRANCH_TRAINING)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("COURSE", GridView3.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("MONTH_FROM", GridView3.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("YEAR_FROM", GridView3.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("MONTH_TO", GridView3.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("YEAR_TO", GridView3.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("BRANCH_TRAINING", GridView3.Rows[i].Cells[5].Text));

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

            for (int i = 0; i < GridView4.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_DISCIPLINARY_AND_AMNESTY (CITIZEN_ID,YEAR,MENU,REF_DOC) VALUES (:CITIZEN_ID,:YEAR,:MENU,:REF_DOC)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));
                            command.Parameters.Add(new OracleParameter("YEAR", GridView4.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("MENU", GridView4.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("REF_DOC", GridView4.Rows[i].Cells[2].Text));

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

            for (int i = 0; i < GridView5.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_POSITION_AND_SALARY (DDATE,POSITION_NAME,PERSON_ID,ST_ID,POSITION_ID,SALARY,POSITION_SALARY,REFERENCE_DOCUMENT,CITIZEN_ID) VALUES (:DDATE,:POSITION_NAME,:PERSON_ID,:ST_ID,:POSITION_ID,:SALARY,:POSITION_SALARY,:REFERENCE_DOCUMENT,:CITIZEN_ID)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss5 = GridView5.Rows[i].Cells[0].Text.Split(' ');
                            for (int j = 0; j < ss5.Length; ++j)
                            {
                                ss5[j] = ss5[j].Trim();
                            }
                            DateTime DATE_11 = new DateTime(Convert.ToInt32(ss5[2]), Util.MonthToNumber(ss5[1]), Convert.ToInt32(ss5[0]));

                            command.Parameters.Add(new OracleParameter("DDATE", DATE_11));
                            command.Parameters.Add(new OracleParameter("POSITION_NAME", GridView5.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PERSON_ID", GridView5.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("ST_ID", GridView5.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("POSITION_ID", GridView5.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("SALARY", GridView5.Rows[i].Cells[5].Text));
                            command.Parameters.Add(new OracleParameter("POSITION_SALARY", GridView5.Rows[i].Cells[6].Text));
                            command.Parameters.Add(new OracleParameter("REFERENCE_DOCUMENT", GridView5.Rows[i].Cells[7].Text));
                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));



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

            for (int i = 0; i < GridView6.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO TB_STUDY_GRADUATE_TOP (GRAD_LEV_ID,GRAD_CURR,CITIZEN_ID) VALUES (:GRAD_LEV_ID,:GRAD_CURR,:CITIZEN_ID)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            command.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GridView6.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("GRAD_CURR", GridView6.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("CITIZEN_ID", txtCitizen.Text));

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

            ClearData();
            ClearDataGridViewNumber10();
            ClearDataGridViewNumber11();
            ClearDataGridViewNumber12();
            ClearDataGridViewNumber13();
            ClearDataGridViewNumber14();
            ClearDataGridViewLev();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);

            Session["StudyHis"] = new DataTable();
            ((DataTable)(Session["StudyHis"])).Columns.Add("สถานศึกษา");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ (เดือน)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ตั้งแต่ (ปี)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ถึง (เดือน)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("ถึง (ปี)");
            ((DataTable)(Session["StudyHis"])).Columns.Add("วุฒิ(สาขาวิชาเอก)");
            GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
            GridView1.DataBind();

            Session["JobLisence"] = new DataTable();
            ((DataTable)(Session["JobLisence"])).Columns.Add("ชื่อใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("หน่วยงาน");
            ((DataTable)(Session["JobLisence"])).Columns.Add("เลขที่ใบอนุญาต");
            ((DataTable)(Session["JobLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
            GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
            GridView2.DataBind();

            Session["Trainning"] = new DataTable();
            ((DataTable)(Session["Trainning"])).Columns.Add("หลักสูตรฝึกอบรม");
            ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (เดือน)");
            ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (ปี)");
            ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (เดือน)");
            ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (ปี)");
            ((DataTable)(Session["Trainning"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
            GridView3.DataSource = ((DataTable)(Session["Trainning"]));
            GridView3.DataBind();

            Session["Punished"] = new DataTable();
            ((DataTable)(Session["Punished"])).Columns.Add("พ.ศ.");
            ((DataTable)(Session["Punished"])).Columns.Add("รายการ");
            ((DataTable)(Session["Punished"])).Columns.Add("เอกสารอ้างอิง");
            GridView4.DataSource = ((DataTable)(Session["Punished"]));
            GridView4.DataBind();

            Session["PositionAndSalary"] = new DataTable();
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("วัน เดือน ปี");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เลขที่ตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ตำแหน่งประเภท");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("ระดับ");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินเดือน");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เงินประจำตำแหน่ง");
            ((DataTable)(Session["PositionAndSalary"])).Columns.Add("เอกสารอ้างอิง");
            GridView5.DataSource = ((DataTable)(Session["PositionAndSalary"]));
            GridView5.DataBind();

            Session["Lev"] = new DataTable();
            ((DataTable)(Session["Lev"])).Columns.Add("ระดับการศึกษาที่จบสูงสุด");
            ((DataTable)(Session["Lev"])).Columns.Add("สาขาที่จบสูงสุด");
            GridView6.DataSource = ((DataTable)(Session["Lev"]));
            GridView6.DataBind();

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
            dr[1] = DropDownMonth10From.SelectedValue;
            dr[2] = DropDownYear10From.SelectedValue;
            dr[3] = DropDownMonth10To.SelectedValue;
            dr[4] = DropDownYear10To.SelectedValue;
            dr[5] = txtMajor.Text;
            if (DropDownMonth10From.SelectedValue == "0" || DropDownYear10From.SelectedValue == "0" || DropDownMonth10To.SelectedValue == "0" || DropDownYear10To.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือกเดือนและปีให้ถูกต้อง<ในส่วนประวัติการศึกษา>");
                return;
            }
            if (txtGrad_Univ.Text != "" && txtMajor.Text != "")
            {
                ((DataTable)(Session["StudyHis"])).Rows.Add(dr);
                GridView1.DataSource = ((DataTable)(Session["StudyHis"]));
                GridView1.DataBind();
                ClearDataGridViewNumber10();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษาเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนประวัติการศึกษา>')", true);
            }

        }

        protected void ButtonPlus11_Click(object sender, EventArgs e)
        {

            DataRow dr = ((DataTable)(Session["JobLisence"])).NewRow();
            dr[0] = txtGrad_Univ11.Text;
            dr[1] = txtDepart11.Text;
            dr[2] = txtNolicense11.Text;
            dr[3] = txtDateEnable11.Text;
            if (txtGrad_Univ11.Text != "" && txtDepart11.Text != "" && txtNolicense11.Text != "" && txtDateEnable11.Text != "")
            {
                ((DataTable)(Session["JobLisence"])).Rows.Add(dr);
                GridView2.DataSource = ((DataTable)(Session["JobLisence"]));
                GridView2.DataBind();
                ClearDataGridViewNumber11();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบประกอบวิชาชีพเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบถ้วน<ส่วนใบประกอบวิชาชีพ>')", true);
            }

        }

        protected void ButtonPlus12_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)(Session["Trainning"])).NewRow();
            dr[0] = txtCourse.Text;
            dr[1] = DropDownMonth12From.SelectedValue;
            dr[2] = DropDownYear12From.SelectedValue;
            dr[3] = DropDownMonth12To.SelectedValue;
            dr[4] = DropDownYear12To.SelectedValue;
            dr[5] = txtBranchTrainning.Text;
            if (DropDownMonth12From.SelectedValue == "0" || DropDownYear12From.SelectedValue == "0" || DropDownMonth12To.SelectedValue == "0" || DropDownYear12To.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือกเดือนและปีให้ถูกต้อง<ในส่วนประวัติการฝึกอบรม>");
                return;
            }
            if (txtCourse.Text != "" && txtBranchTrainning.Text != "")
            {
                ((DataTable)(Session["Trainning"])).Rows.Add(dr);
                GridView3.DataSource = ((DataTable)(Session["Trainning"]));
                GridView3.DataBind();
                ClearDataGridViewNumber12();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการฝึกอบรมเรียบร้อย')", true);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนประวัติการฝึกอบรม>");
            }
        }

        protected void ButtonPlus13_Click(object sender, EventArgs e)
        {

            DataRow dr = ((DataTable)(Session["Punished"])).NewRow();
            dr[0] = DropDownYear13.SelectedValue;
            dr[1] = txtList13.Text;
            dr[2] = txtRefDoc13.Text;
            if (DropDownYear13.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือก พ.ศ. ให้ถูกต้อง<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>");
                return;
            }
            if (txtList13.Text != "" && txtRefDoc13.Text != "")
            {
                ((DataTable)(Session["Punished"])).Rows.Add(dr);
                GridView4.DataSource = ((DataTable)(Session["Punished"]));
                GridView4.DataBind();
                ClearDataGridViewNumber13();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรมเรียบร้อย')", true);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนการได้รับโทษทางวินัยและการนิรโทษกรรม>");
            }

        }

        protected void ButtonPlus14_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)(Session["PositionAndSalary"])).NewRow();
            dr[0] = txtDate14.Text;
            dr[1] = txtPosition14.Text;
            dr[2] = txtNo_Position14.Text;
            dr[3] = DropDownType_Position14.SelectedValue;
            dr[4] = txtDegree14.Text;
            dr[5] = txtSalary14.Text;
            dr[6] = txtSalaryForPosition14.Text;
            dr[7] = txtRefDoc14.Text;
            if (DropDownType_Position14.SelectedValue == "0")
            {
                Util.Alert(this, "กรุณาเลือก ตำแหน่งประเภทและระดับ ให้ถูกต้อง<ในส่วนตำแหน่งและเงินเดือน>");
                return;
            }
            if (txtDate14.Text != "" && txtPosition14.Text != "" && txtNo_Position14.Text != "" && txtSalary14.Text != "" && txtSalaryForPosition14.Text != "" && txtRefDoc14.Text != "")
            {
                ((DataTable)(Session["PositionAndSalary"])).Rows.Add(dr);
                GridView5.DataSource = ((DataTable)(Session["PositionAndSalary"]));
                GridView5.DataBind();
                ClearDataGridViewNumber14();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลตำแหน่งและเงินเดือนเรียบร้อย')", true);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลให้ครบถ้วน<ในส่วนตำแหน่งและเงินเดือน>");
            }
        }

        protected void ButtonPlusLEV_Click(object sender, EventArgs e)
        {

            DataRow dr = ((DataTable)(Session["Lev"])).NewRow();
            dr[0] = DropDownGRAD_LEV.SelectedValue;
            dr[1] = txtGRAD_CURR.Text;
            if (DropDownGRAD_LEV.SelectedValue == "0" && GridView6.Rows.Count == 0)
            {
                Util.Alert(this, "กรุณาเลือก ระดับการศึกษาที่จบสูงสุด ให้ถูกต้อง");
                return;
            }
            if (txtGRAD_CURR.Text != "" && GridView6.Rows.Count == 0)
            {
                ((DataTable)(Session["Lev"])).Rows.Add(dr);
                GridView6.DataSource = ((DataTable)(Session["Lev"]));
                GridView6.DataBind();
                ClearDataGridViewLev();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลระดับการศึกษาที่จบสูงสุด และหลักสูตรที่จบการศึกษาสูงสุด เรียบร้อย')", true);
            }
            else
            {
                Util.Alert(this, "กรุณากรอกข้อมูลหลักสูตรที่จบการศึกษาสูงสุด");
            }

        }


    }
}