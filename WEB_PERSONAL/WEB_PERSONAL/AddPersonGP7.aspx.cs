using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class AddPersonGP7 : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SQLddlPositionType14();
                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";

                //View0
                //DatabaseManager.BindDropDown(ddlMinistry, "SELECT * FROM TB_MINISTRY", "MINISTRY_NAME", "MINISTRY_ID", "--กรุณาเลือกกระทรวง--");
                //DatabaseManager.BindDropDown(ddlTitleName, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                //DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");

                //view1
                DatabaseManager.BindDropDown(ddlDegree10, "SELECT * FROM TB_GRAD_LEV", "GRAD_LEV_NAME", "GRAD_LEV_ID", "--กรุณาเลือกระดับการศึกษา--");
                DatabaseManager.BindDropDown(ddlMonth10From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear10From.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlMonth10To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear10To.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlCountrySuccess10, "SELECT * FROM TB_COUNTRY", "COUNTRY_TH", "COUNTRY_ID", "--กรุณาเลือกประเทศที่จบ--");
                ddlCountrySuccess10.SelectedValue = "'Thailand'";

                //view3
                DatabaseManager.BindDropDown(ddlMonth12From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear12From.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlMonth12To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear12To.SelectedValue = "2559";

                //view4
                DatabaseManager.BindDropDown(ddlYear13, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear10To.SelectedValue = "2559";

                Session["Study"] = new DataTable();
                ((DataTable)(Session["Study"])).Columns.Add("ระดับการศึกษา");
                ((DataTable)(Session["Study"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["Study"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["Study"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["Study"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["Study"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["Study"])).Columns.Add("วุฒิ");
                ((DataTable)(Session["Study"])).Columns.Add("สาขาวิชาเอก");
                ((DataTable)(Session["Study"])).Columns.Add("ประเทศที่จบ");
                GridViewStudy.DataSource = ((DataTable)(Session["Study"]));
                GridViewStudy.DataBind();
                Session["StudyShow"] = new DataTable();
                ((DataTable)(Session["StudyShow"])).Columns.Add("ระดับการศึกษา");
                ((DataTable)(Session["StudyShow"])).Columns.Add("สถานศึกษา");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["StudyShow"])).Columns.Add("วุฒิ");
                ((DataTable)(Session["StudyShow"])).Columns.Add("สาขาวิชาเอก");
                ((DataTable)(Session["StudyShow"])).Columns.Add("ประเทศที่จบ");
                GridViewStudyShow.DataSource = ((DataTable)(Session["StudyShow"]));
                GridViewStudyShow.DataBind();

                Session["ProLisence"] = new DataTable();
                ((DataTable)(Session["ProLisence"])).Columns.Add("ชื่อใบอนุญาต");
                ((DataTable)(Session["ProLisence"])).Columns.Add("หน่วยงาน");
                ((DataTable)(Session["ProLisence"])).Columns.Add("เลขที่ใบอนุญาต");
                ((DataTable)(Session["ProLisence"])).Columns.Add("วันที่มีผลบังคับใช้ (วัน เดือน ปี)");
                GridViewLicense.DataSource = ((DataTable)(Session["ProLisence"]));
                GridViewLicense.DataBind();

                Session["Trainning"] = new DataTable();
                ((DataTable)(Session["Trainning"])).Columns.Add("หลักสูตรฝึกอบรม");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["Trainning"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["Trainning"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
                GridViewTraining.DataSource = ((DataTable)(Session["Trainning"]));
                GridViewTraining.DataBind();
                Session["TrainningShow"] = new DataTable();
                ((DataTable)(Session["TrainningShow"])).Columns.Add("หลักสูตรฝึกอบรม");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ตั้งแต่ (เดือน)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ตั้งแต่ (ปี)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ถึง (เดือน)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("ถึง (ปี)");
                ((DataTable)(Session["TrainningShow"])).Columns.Add("หน่วยงานที่จัดฝึกอบรม");
                GridViewTrainingShow.DataSource = ((DataTable)(Session["TrainningShow"]));
                GridViewTrainingShow.DataBind();

                Session["DDA"] = new DataTable();
                ((DataTable)(Session["DDA"])).Columns.Add("พ.ศ.");
                ((DataTable)(Session["DDA"])).Columns.Add("รายการ");
                ((DataTable)(Session["DDA"])).Columns.Add("เอกสารอ้างอิง");
                GridViewDDA.DataSource = ((DataTable)(Session["DDA"]));
                GridViewDDA.DataBind();

                Session["PAS"] = new DataTable();
                ((DataTable)(Session["PAS"])).Columns.Add("วัน เดือน ปี");
                ((DataTable)(Session["PAS"])).Columns.Add("ตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("เลขที่ตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("ตำแหน่งประเภท");
                ((DataTable)(Session["PAS"])).Columns.Add("ระดับ");
                ((DataTable)(Session["PAS"])).Columns.Add("เงินเดือน");
                ((DataTable)(Session["PAS"])).Columns.Add("เงินประจำตำแหน่ง");
                ((DataTable)(Session["PAS"])).Columns.Add("เอกสารอ้างอิง");
                GridViewPAS.DataSource = ((DataTable)(Session["PAS"]));
                GridViewPAS.DataBind();
                Session["PASShow"] = new DataTable();
                ((DataTable)(Session["PASShow"])).Columns.Add("วัน เดือน ปี");
                ((DataTable)(Session["PASShow"])).Columns.Add("ตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("เลขที่ตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("ตำแหน่งประเภท");
                ((DataTable)(Session["PASShow"])).Columns.Add("ระดับ");
                ((DataTable)(Session["PASShow"])).Columns.Add("เงินเดือน");
                ((DataTable)(Session["PASShow"])).Columns.Add("เงินประจำตำแหน่ง");
                ((DataTable)(Session["PASShow"])).Columns.Add("เอกสารอ้างอิง");
                GridViewPASShow.DataSource = ((DataTable)(Session["PASShow"]));
                GridViewPASShow.DataBind();
            }
        }

        protected void ClearText()
        {
            tbCitizenIDSearch.Text = ""; //Search
            //1
            tbMinistry.Text = "";
            tbTitleName.Text = "";
            tbNameTH.Text = "";
            tbLastNameTH.Text = "";
            tbBirthdayDate.Text = "";
            tbBirthdayLong.Text = "";
            tbInworkDate.Text = "";
            tbRetireDate.Text = "";
            tbRetireLong.Text = "";
            tbStaffType.Text = "";
            //2
            tbGrom.Text = "";
            tbCitizenID.Text = "";
            tbFatherName.Text = "";
            tbFatherLastName.Text = "";
            tbMotherName.Text = "";
            tbMotherLastName.Text = "";
            tbMotherOldLastName.Text = "";
            tbCoupleName.Text = "";
            tbCoupleLastName.Text = "";
            tbCoupleOldLastName.Text = "";
            //view0
            ddlDegree10.SelectedIndex = 0;
            tbUnivName10.Text = "";
            ddlMonth10From.SelectedIndex = 0;
            ddlYear10From.SelectedIndex = 0;
            ddlMonth10To.SelectedIndex = 0;
            ddlYear10To.SelectedIndex = 0;
            tbQualification10.Text = "";
            tbMajor10.Text = "";
            ddlCountrySuccess10.SelectedIndex = 0;
            //view1
            tbLicenseName11.Text = "";
            tbDepartment11.Text = "";
            tbLicenseNo11.Text = "";
            tbUseDate11.Text = "";
            //view2
            tbCourse.Text = "";
            ddlMonth12From.SelectedIndex = 0;
            ddlYear12From.SelectedIndex = 0;
            ddlMonth12To.SelectedIndex = 0;
            ddlYear12To.SelectedIndex = 0;
            tbDepartment.Text = "";
            //view3
            ddlYear13.SelectedIndex = 0;
            tbName13.Text = "";
            tbREF13.Text = "";
            //view4
            tbDate14.Text = "";
            tbPosition14.Text = "";
            tbPositionNo14.Text = "";
            ddlPositionType14.SelectedIndex = 0;
            ddlPositionDegree14.SelectedIndex = 0;
            tbSalary14.Text = "";
            tbSalaryPosition14.Text = "";
            tbRef14.Text = "";

            notification.Attributes["class"] = "none";
            notification.InnerHtml = "";
        }

        protected void SQLddlPositionType14()
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
                        ddlPositionType14.DataSource = dt;
                        ddlPositionType14.DataValueField = "ST_ID";
                        ddlPositionType14.DataTextField = "ST_NAME";
                        ddlPositionType14.DataBind();
                        sqlConn.Close();

                        ddlPositionType14.Items.Insert(0, new ListItem("--กรุณาเลือกตำแหน่งประเภท--", "0"));
                        ddlPositionDegree14.Items.Insert(0, new ListItem("--กรุณาเลือกระดับ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlPositionType14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * FROM TB_POSITION where ST_ID = " + ddlPositionType14.SelectedValue;
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPositionDegree14.DataSource = dt;
                        ddlPositionDegree14.DataValueField = "ID";
                        ddlPositionDegree14.DataTextField = "NAME";
                        ddlPositionDegree14.DataBind();
                        sqlConn.Close();
                        ddlPositionDegree14.Items.Insert(0, new ListItem("--กรุณาเลือกระดับ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void lbuV1Next_Click(object sender, EventArgs e)
        {
            /*if (ddlDegree10.SelectedIndex == 0 || tbUnivName10.Text == "" || ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0 || tbQualification10.Text == "" || tbMajor10.Text == "" || ddlCountrySuccess10.SelectedIndex == 0)
           {
               notification.Attributes["class"] = "alert alert_danger";
               notification.InnerHtml = "";

               notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
               if (ddlDegree10.SelectedIndex == 0)
               {
                   notification.InnerHtml += "<div>กรุณาเลือก 'ระดับการศึกษา'</div>";
               }
               if (tbUnivName10.Text == "")
               {
                   notification.InnerHtml += "<div>กรุณากรอก 'สถานศึกษา'</div>";
               }
               if (ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0)
               {
                   notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
               }
               if (tbQualification10.Text == "")
               {
                   notification.InnerHtml += "<div>กรุณากรอก 'วุฒิ'</div>";
               }
               if (tbMajor10.Text == "")
               {
                   notification.InnerHtml += "<div>กรุณากรอก 'สาขาวิชาเอก'</div>";
               }
               if (ddlCountrySuccess10.SelectedIndex == 0)
               {
                   notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศที่จบ'</div>";
               }
           }
           else {
               MultiView1.ActiveViewIndex = 1;
               notification.Attributes["class"] = "none";
               notification.InnerHtml = "";
           }*/

            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV2Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e)
        {
            /*if (tbLicenseName11.Text == "" || tbLicenseName11.Text == "" || tbDepartment11.Text == "" || tbLicenseNo11.Text == "" || tbUseDate11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbLicenseName11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อใบอนุญาต'</div>";
                }
                if (tbDepartment11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงาน'</div>";
                }
                if (tbLicenseNo11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ใบอนุญาต'</div>";
                }
                if (tbUseDate11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันที่มีผลบังคับใช้ (วัน เดือน ปี)'</div>";
                }
                else {
                    MultiView1.ActiveViewIndex = 2;
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }*/

            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuV3Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV3Next_Click(object sender, EventArgs e)
        {
            /*if (tbCourse.Text == "" || ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0 || tbDepartment.Text == "")
          {
              notification.Attributes["class"] = "alert alert_danger";
              notification.InnerHtml = "";

              notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
              if (tbCourse.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'หลักสูตรฝึกอบรม'</div>";
              }
              if (ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
              }
              if (tbDepartment.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงานที่จัดฝึกอบรม'</div>";
              }
              else {
                  MultiView1.ActiveViewIndex = 3;
                  notification.Attributes["class"] = "none";
                  notification.InnerHtml = "";
              }
          }*/

            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV4Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuV4Next_Click(object sender, EventArgs e)
        {
            /*if (ddlYear13.SelectedIndex == 0 || tbName13.Text == "" || tbREF13.Text == "")
          {
              notification.Attributes["class"] = "alert alert_danger";
              notification.InnerHtml = "";

              notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
              if (ddlYear13.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'พ.ศ.'</div>";
              }
              if (tbName13.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'รายการ'</div>";
              }
              if (tbREF13.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
              }
              else {
                  MultiView1.ActiveViewIndex = 4;
                  notification.Attributes["class"] = "none";
                  notification.InnerHtml = "";
              }
          }*/

            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV5Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            /*if (tbDate14.Text == "" || tbPosition14.Text == "" || tbPositionNo14.Text == "" || ddlPositionType14.SelectedIndex == 0 || ddlPositionDegree14.SelectedIndex == 0 || tbSalary14.Text == "" || tbSalaryPosition14.Text == "" || tbRef14.Text == "")
          {
              notification.Attributes["class"] = "alert alert_danger";
              notification.InnerHtml = "";

              notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";

              if (tbDate14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'วัน เดือน ปี'</div>";
              }
              if (tbPosition14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'ตำแหน่ง'</div>";
              }
              if (tbPositionNo14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ตำแหน่ง'</div>";
              }
              if (ddlPositionType14.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งประเภท'</div>";
              }
              if (ddlPositionDegree14.SelectedIndex == 0)
              {
                  notification.InnerHtml += "<div>กรุณาเลือก 'ระดับ'</div>";
              }
              if (tbSalary14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'เงินเดือน'</div>";
              }
              if (tbSalaryPosition14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'เงินประจำตำแหน่ง'</div>";
              }
              if (tbRef14.Text == "")
              {
                  notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
              }
              else {
                  notification.Attributes["class"] = "none";
                  notification.InnerHtml = "";
              }
          } */

            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }

            for (int i = 0; i < GridViewStudy.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_STUDY (PS_CITIZEN_ID,PS_DEGREE_ID,PS_UNIV_NAME,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_QUALIFICATION,PS_MAJOR,PS_COUNTRY_ID) VALUES (:PS_CITIZEN_ID,:PS_DEGREE_ID,:PS_UNIV_NAME,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_QUALIFICATION,:PS_MAJOR,:PS_COUNTRY_ID)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_DEGREE_ID", GridViewStudy.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_UNIV_NAME", GridViewStudy.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", GridViewStudy.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", GridViewStudy.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_MONTH", GridViewStudy.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_YEAR", GridViewStudy.Rows[i].Cells[5].Text));
                            command.Parameters.Add(new OracleParameter("PS_QUALIFICATION", GridViewStudy.Rows[i].Cells[6].Text));
                            command.Parameters.Add(new OracleParameter("PS_MAJOR", GridViewStudy.Rows[i].Cells[7].Text));
                            command.Parameters.Add(new OracleParameter("PS_COUNTRY_ID", GridViewStudy.Rows[i].Cells[8].Text));
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

            for (int i = 0; i < GridViewLicense.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_PROFESSIONAL_LICENSE (PS_CITIZEN_ID,PS_LICENSE_NAME,PS_DEPARTMENT,PS_LICENSE_NO,PS_USE_DATE) VALUES (:PS_CITIZEN_ID,:PS_LICENSE_NAME,:PS_DEPARTMENT,:PS_LICENSE_NO,:PS_USE_DATE)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss2 = GridViewLicense.Rows[i].Cells[3].Text.Split(' ');
                            for (int j = 0; j < ss2.Length; ++j)
                            {
                                ss2[j] = ss2[j].Trim();
                            }
                            DateTime DATE_11 = Util.ODT(GridViewLicense.Rows[i].Cells[3].Text);

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_LICENSE_NAME", GridViewLicense.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", GridViewLicense.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_LICENSE_NO", GridViewLicense.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_USE_DATE", DATE_11));
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

            for (int i = 0; i < GridViewTraining.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_TRAINING (PS_CITIZEN_ID,PS_COURSE,PS_FROM_MONTH,PS_FROM_YEAR,PS_TO_MONTH,PS_TO_YEAR,PS_DEPARTMENT) VALUES (:PS_CITIZEN_ID,:PS_COURSE,:PS_FROM_MONTH,:PS_FROM_YEAR,:PS_TO_MONTH,:PS_TO_YEAR,:PS_DEPARTMENT)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_COURSE", GridViewTraining.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_MONTH", GridViewTraining.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_FROM_YEAR", GridViewTraining.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_MONTH", GridViewTraining.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_TO_YEAR", GridViewTraining.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_DEPARTMENT", GridViewTraining.Rows[i].Cells[5].Text));
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

            for (int i = 0; i < GridViewDDA.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_DISCIPLINARY_AND_AMNESTY (PS_CITIZEN_ID,PS_YEAR,PS_DAA_NAME,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_YEAR,:PS_DAA_NAME,:PS_REF)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_YEAR", GridViewDDA.Rows[i].Cells[0].Text));
                            command.Parameters.Add(new OracleParameter("PS_DAA_NAME", GridViewDDA.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_REF", GridViewDDA.Rows[i].Cells[2].Text));
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

            for (int i = 0; i < GridViewPAS.Rows.Count; ++i)
            {
                int id = 0;
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand command = new OracleCommand("INSERT INTO PS_POSITION_AND_SALARY (PS_CITIZEN_ID,PS_DATE,PS_POSITION,PS_POSITION_NO,PS_POSITION_TYPE,PS_POSITION_DEGREE,PS_SALARY,PS_SALARY_POSITION,PS_REF) VALUES (:PS_CITIZEN_ID,:PS_DATE,:PS_POSITION,:PS_POSITION_NO,:PS_POSITION_TYPE,:PS_POSITION_DEGREE,:PS_SALARY,:PS_SALARY_POSITION,:PS_REF)", conn))
                    {

                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            string[] ss5 = GridViewPAS.Rows[i].Cells[0].Text.Split(' ');
                            for (int j = 0; j < ss5.Length; ++j)
                            {
                                ss5[j] = ss5[j].Trim();
                            }
                            DateTime DATE_11 = Util.ODT(GridViewPAS.Rows[i].Cells[0].Text);

                            command.Parameters.Add(new OracleParameter("PS_CITIZEN_ID", tbCitizenID.Text));
                            command.Parameters.Add(new OracleParameter("PS_DATE", DATE_11));
                            command.Parameters.Add(new OracleParameter("PS_POSITION", GridViewPAS.Rows[i].Cells[1].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_NO", GridViewPAS.Rows[i].Cells[2].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_TYPE", GridViewPAS.Rows[i].Cells[3].Text));
                            command.Parameters.Add(new OracleParameter("PS_POSITION_DEGREE", GridViewPAS.Rows[i].Cells[4].Text));
                            command.Parameters.Add(new OracleParameter("PS_SALARY", GridViewPAS.Rows[i].Cells[5].Text));
                            command.Parameters.Add(new OracleParameter("PS_SALARY_POSITION", GridViewPAS.Rows[i].Cells[6].Text));
                            command.Parameters.Add(new OracleParameter("PS_REF", GridViewPAS.Rows[i].Cells[7].Text));
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

            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CITIZEN_ID = tbCitizenID.Text;
            P0.PS_DAD_FN = tbFatherName.Text;
            P0.PS_DAD_LN = tbFatherLastName.Text;
            P0.PS_MOM_FN = tbMotherName.Text;
            P0.PS_MOM_LN = tbMotherLastName.Text;
            P0.PS_MOM_LN_OLD = tbMotherOldLastName.Text;
            P0.PS_LOV_FN = tbCoupleName.Text;
            P0.PS_LOV_LN = tbCoupleLastName.Text;
            P0.PS_LOV_LN_OLD = tbCoupleOldLastName.Text;

            P0.UPDATE_PS_PERSON2();
            ClearText();
            MultiView1.ActiveViewIndex = 0;
            MultiView1.ActiveViewIndex = 0;

            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong> เพิ่มข้อมูลบุคลากร เรียบร้อย</strong></div>";
        }

        protected void lbuV1Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            DataRow dr = ((DataTable)(Session["Study"])).NewRow();
            DataRow drShow = ((DataTable)(Session["StudyShow"])).NewRow();
            dr[0] = ddlDegree10.SelectedValue;
            dr[1] = tbUnivName10.Text;
            dr[2] = ddlMonth10From.SelectedValue;
            dr[3] = ddlYear10From.SelectedValue;
            dr[4] = ddlMonth10To.SelectedValue;
            dr[5] = ddlYear10To.SelectedValue;
            dr[6] = tbQualification10.Text;
            dr[7] = tbMajor10.Text;
            dr[8] = ddlCountrySuccess10.SelectedValue;
            drShow[0] = ddlDegree10.SelectedItem.Text;
            drShow[1] = tbUnivName10.Text;
            drShow[2] = ddlMonth10From.SelectedItem.Text;
            drShow[3] = ddlYear10From.SelectedItem.Text;
            drShow[4] = ddlMonth10To.SelectedItem.Text;
            drShow[5] = ddlYear10To.SelectedItem.Text;
            drShow[6] = tbQualification10.Text;
            drShow[7] = tbMajor10.Text;
            drShow[8] = ddlCountrySuccess10.SelectedItem.Text;
            if (ddlDegree10.SelectedIndex == 0 || tbUnivName10.Text == "" || ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0 || tbQualification10.Text == "" || tbMajor10.Text == "" || ddlCountrySuccess10.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlDegree10.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ระดับการศึกษา'</div>";
                }
                if (tbUnivName10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'สถานศึกษา'</div>";
                }
                if (ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbQualification10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วุฒิ'</div>";
                }
                if (tbMajor10.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'สาขาวิชาเอก'</div>";
                }
                if (ddlCountrySuccess10.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศที่จบ'</div>";
                }
            }
            else
            {
                ((DataTable)(Session["Study"])).Rows.Add(dr);
                ((DataTable)(Session["StudyShow"])).Rows.Add(drShow);
                GridViewStudy.DataSource = ((DataTable)(Session["Study"]));
                GridViewStudy.DataBind();
                GridViewStudyShow.DataSource = ((DataTable)(Session["StudyShow"]));
                GridViewStudyShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษาเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV2Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            DataRow dr = ((DataTable)(Session["ProLisence"])).NewRow();
            dr[0] = tbLicenseName11.Text;
            dr[1] = tbDepartment11.Text;
            dr[2] = tbLicenseNo11.Text;
            dr[3] = tbUseDate11.Text;
            if (tbLicenseName11.Text == "" || tbLicenseName11.Text == "" || tbDepartment11.Text == "" || tbLicenseNo11.Text == "" || tbUseDate11.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbLicenseName11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อใบอนุญาต'</div>";
                }
                if (tbDepartment11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงาน'</div>";
                }
                if (tbLicenseNo11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ใบอนุญาต'</div>";
                }
                if (tbUseDate11.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันที่มีผลบังคับใช้ (วัน เดือน ปี)'</div>";
                }
            }
            else
            {
                ((DataTable)(Session["ProLisence"])).Rows.Add(dr);
                GridViewLicense.DataSource = ((DataTable)(Session["ProLisence"]));
                GridViewLicense.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบประกอบวิชาชีพเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV3Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            DataRow dr = ((DataTable)(Session["Trainning"])).NewRow();
            DataRow drShow = ((DataTable)(Session["TrainningShow"])).NewRow();
            dr[0] = tbCourse.Text;
            dr[1] = ddlMonth12From.SelectedValue;
            dr[2] = ddlYear12From.SelectedValue;
            dr[3] = ddlMonth12To.SelectedValue;
            dr[4] = ddlYear12To.SelectedValue;
            dr[5] = tbDepartment.Text;
            drShow[0] = tbCourse.Text;
            drShow[1] = ddlMonth12From.SelectedItem.Text;
            drShow[2] = ddlYear12From.SelectedItem.Text;
            drShow[3] = ddlMonth12To.SelectedItem.Text;
            drShow[4] = ddlYear12To.SelectedItem.Text;
            drShow[5] = tbDepartment.Text;
            if (tbCourse.Text == "" || ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0 || tbDepartment.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbCourse.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หลักสูตรฝึกอบรม'</div>";
                }
                if (ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตั้งแต่ - ถึง (เดือน ปี)' ให้ถูกต้อง</div>";
                }
                if (tbDepartment.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หน่วยงานที่จัดฝึกอบรม'</div>";
                }
            }
            else
            {
                ((DataTable)(Session["Trainning"])).Rows.Add(dr);
                GridViewTraining.DataSource = ((DataTable)(Session["Trainning"]));
                GridViewTraining.DataBind();
                ((DataTable)(Session["TrainningShow"])).Rows.Add(drShow);
                GridViewTrainingShow.DataSource = ((DataTable)(Session["TrainningShow"]));
                GridViewTrainingShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการฝึกอบรมเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV4Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            DataRow dr = ((DataTable)(Session["DDA"])).NewRow();
            dr[0] = ddlYear13.SelectedValue;
            dr[1] = tbName13.Text;
            dr[2] = tbREF13.Text;
            if (ddlYear13.SelectedIndex == 0 || tbName13.Text == "" || tbREF13.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (ddlYear13.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'พ.ศ.'</div>";
                }
                if (tbName13.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'รายการ'</div>";
                }
                if (tbREF13.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                }
            }
            else
            {
                ((DataTable)(Session["DDA"])).Rows.Add(dr);
                GridViewDDA.DataSource = ((DataTable)(Session["DDA"]));
                GridViewDDA.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรมเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV5Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }
            DataRow dr = ((DataTable)(Session["PAS"])).NewRow();
            DataRow drShow = ((DataTable)(Session["PASShow"])).NewRow();
            dr[0] = tbDate14.Text;
            dr[1] = tbPosition14.Text;
            dr[2] = tbPositionNo14.Text;
            dr[3] = ddlPositionType14.SelectedValue;
            dr[4] = ddlPositionDegree14.SelectedValue;
            dr[5] = tbSalary14.Text;
            dr[6] = tbSalaryPosition14.Text;
            dr[7] = tbRef14.Text;
            drShow[0] = tbDate14.Text;
            drShow[1] = tbPosition14.Text;
            drShow[2] = tbPositionNo14.Text;
            drShow[3] = ddlPositionType14.SelectedItem.Text;
            drShow[4] = ddlPositionDegree14.SelectedItem.Text;
            drShow[5] = tbSalary14.Text;
            drShow[6] = tbSalaryPosition14.Text;
            drShow[7] = tbRef14.Text;
            if (tbDate14.Text == "" || tbPosition14.Text == "" || tbPositionNo14.Text == "" || ddlPositionType14.SelectedIndex == 0 || ddlPositionDegree14.SelectedIndex == 0 || tbSalary14.Text == "" || tbSalaryPosition14.Text == "" || tbRef14.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";

                if (tbDate14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วัน เดือน ปี'</div>";
                }
                if (tbPosition14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ตำแหน่ง'</div>";
                }
                if (tbPositionNo14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เลขที่ตำแหน่ง'</div>";
                }
                if (ddlPositionType14.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งประเภท'</div>";
                }
                if (ddlPositionDegree14.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ระดับ'</div>";
                }
                if (tbSalary14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เงินเดือน'</div>";
                }
                if (tbSalaryPosition14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เงินประจำตำแหน่ง'</div>";
                }
                if (tbRef14.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'เอกสารอ้างอิง'</div>";
                }
            }
            else
            {
                ((DataTable)(Session["PAS"])).Rows.Add(dr);
                GridViewPAS.DataSource = ((DataTable)(Session["PAS"]));
                GridViewPAS.DataBind();
                ((DataTable)(Session["PASShow"])).Rows.Add(drShow);
                GridViewPASShow.DataSource = ((DataTable)(Session["PASShow"]));
                GridViewPASShow.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลตำแหน่งและเงินเดือนเรียบร้อย')", true);
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            if (string.IsNullOrEmpty(tbCitizenIDSearch.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenIDSearch.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT MINISTRY_NAME FROM TB_MINISTRY WHERE TB_MINISTRY.MINISTRY_ID = PS_PERSON.PS_MINISTRY_ID), (SELECT TITLE_NAME_TH FROM TB_TITLENAME WHERE TB_TITLENAME.TITLE_ID = PS_PERSON.PS_TITLE_ID), PS_FN_TH,PS_LN_TH,PS_BIRTHDAY_DATE,PS_BIRTHDAY_LONG,PS_INWORK_DATE,PS_RETIRE_DATE,PS_RETIRE_LONG,(SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE TB_STAFFTYPE.STAFFTYPE_ID = PS_PERSON.PS_STAFFTYPE_ID),PS_GROM,PS_CITIZEN_ID,PS_DAD_FN,PS_DAD_LN,PS_MOM_FN,PS_MOM_LN,PS_MOM_LN_OLD,PS_LOV_FN,PS_LOV_LN,PS_LOV_LN_OLD FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + tbCitizenIDSearch.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tbMinistry.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            tbTitleName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            tbNameTH.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            tbLastNameTH.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            Util.ODT(tbBirthdayDate.Text = reader.IsDBNull(4) ? "" : reader.GetDateTime(4).ToString("dd MMM yyyy"));
                            tbBirthdayLong.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Util.ODT(tbInworkDate.Text = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString("dd MMM yyyy"));
                            Util.ODT(tbRetireDate.Text = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd MMM yyyy"));
                            tbRetireLong.Text = reader.IsDBNull(8) ? "" : reader.GetString(8);
                            tbStaffType.Text = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            tbGrom.Text = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            tbCitizenID.Text = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            tbFatherName.Text = reader.IsDBNull(12) ? "" : reader.GetString(12);
                            tbFatherLastName.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            tbMotherName.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                            tbMotherLastName.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                            tbMotherOldLastName.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                            tbCoupleName.Text = reader.IsDBNull(17) ? "" : reader.GetString(17);
                            tbCoupleLastName.Text = reader.IsDBNull(18) ? "" : reader.GetString(18);
                            tbCoupleOldLastName.Text = reader.IsDBNull(19) ? "" : reader.GetString(19);
                        }
                    }
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            ClearText();
        }
    }
}
