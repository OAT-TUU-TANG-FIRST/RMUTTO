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
    public partial class AddPerson_Edit : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        public OracleConnection conn = new OracleConnection(@"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindProvinceList();
                SQLCampus();
                SQLddlPositionType14();
                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";
                //view1
                DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
                DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");
                DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");
                //view2
                DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศ--");
                //view3
                DatabaseManager.BindDropDown(ddlDegree10, "SELECT * FROM TB_GRAD_LEV", "GRAD_LEV_NAME", "GRAD_LEV_ID", "--กรุณาเลือกระดับการศึกษา--");
                DatabaseManager.BindDropDown(ddlMonth10From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlMonth10To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlCountrySuccess10, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศที่จบ--");
                //view4
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือกประเภทบุคลากร--");
                DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM TB_BUDGET", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือกประเภทเงินจ้าง--");
                DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM TB_ADMIN_POSITION", "ADMIN_POSITION_NAME", "ADMIN_POSITION_ID", "--กรุณาเลือกตำแหน่งบริหาร--");
                DatabaseManager.BindDropDown(ddlPositionWork, "SELECT * FROM TB_POSITION_WORK", "POSITION_WORK_NAME", "POSITION_WORK_ID", "--กรุณาเลือกตำแหน่งในสายงาน--");
                DatabaseManager.BindDropDown(ddlAcademic, "SELECT * FROM TB_ACADEMIC_POSITION", "ACAD_NAME", "ACAD_ID", "--กรุณาเลือกตำแหน่งทางวิชาการ--");
                DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM TB_TEACH_ISCED", "TEACH_ISCED_NAME_TH", "TEACH_ISCED_ID", "--กรุณาเลือกกลุ่มสาขาวิชาที่สอน--");
                DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM TB_POSITION", "NAME", "ID", "--กรุณาเลือกตำแหน่ง--");
                //view5
                //view6
                DatabaseManager.BindDropDown(ddlMonth12From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                DatabaseManager.BindDropDown(ddlMonth12To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                //view7
                DatabaseManager.BindDropDown(ddlYear13, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                //view8
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["AddPersonEdit"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["AddPersonEdit"] = data;
        }

        #endregion

        void BindData()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            if (loginPerson.CitizenID == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }
            PS_STUDY PStudy = new PS_STUDY();
            DataTable dt1 = PStudy.SELECT_PS_STUDY(loginPerson.CitizenID, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(loginPerson.CitizenID, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            PS_TRAINING PTraining = new PS_TRAINING();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(loginPerson.CitizenID, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(loginPerson.CitizenID, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(loginPerson.CitizenID, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);
        }

        void BindData1()
        {
            PS_STUDY PStudy = new PS_STUDY();
            DataTable dt1 = PStudy.SELECT_PS_STUDY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(txtSearchPersonID.Text, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            PS_TRAINING PTraining = new PS_TRAINING();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(txtSearchPersonID.Text, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(txtSearchPersonID.Text, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);
        }

        protected void ClearPStudy10()
        {
            ddlDegree10.SelectedIndex = 0;
            tbUnivName10.Text = "";
            ddlMonth10From.SelectedIndex = 0;
            ddlYear10From.SelectedIndex = 0;
            ddlMonth10To.SelectedIndex = 0;
            ddlYear10To.SelectedIndex = 0;
            tbQualification10.Text = "";
            tbMajor10.Text = "";
            ddlCountrySuccess10.SelectedIndex = 0;
        }

        protected void ClearPLicense11()
        {
            tbLicenseName11.Text = "";
            tbDepartment11.Text = "";
            tbLicenseNo11.Text = "";
            tbUseDate11.Text = "";
        }

        protected void ClearPTraining12()
        {
            tbCourse.Text = "";
            ddlMonth12From.SelectedIndex = 0;
            ddlYear12From.SelectedIndex = 0;
            ddlMonth12To.SelectedIndex = 0;
            ddlYear12To.SelectedIndex = 0;
            tbDepartment.Text = "";
        }

        protected void ClearPDAA13()
        {
            ddlYear13.SelectedIndex = 0;
            tbName13.Text = "";
            tbREF13.Text = "";
        }

        protected void ClearPPAS14()
        {
            tbDate14.Text = "";
            tbPosition14.Text = "";
            tbPositionNo14.Text = "";
            ddlPositionType14.SelectedIndex = 0;
            ddlPositionDegree14.SelectedIndex = 0;
            tbSalary14.Text = "";
            tbSalaryPosition14.Text = "";
            tbRef14.Text = "";
        }
        //GirdViewStudy
        protected void modEditCommand1(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewStudy.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand1(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand1(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewStudy.DataKeys[e.RowIndex].Value);
            PS_STUDY PStudy = new PS_STUDY();
            PStudy.PS_STUDY_ID = id;
            PStudy.DELETE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand1(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonStudyID = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblPersonStudyID");
            Label lblPersonStudyCitizenID = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblPersonStudyCitizenID");
            DropDownList ddlPersonStudyDegreeID = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyDegreeID");
            TextBox txtPersonStudyUnivName = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyUnivName");
            DropDownList ddlPersonStudyFromMonth = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyFromMonth");
            DropDownList ddlPersonStudyFromYear = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyFromYear");
            DropDownList ddlPersonStudyToMonth = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyToMonth");
            DropDownList ddlPersonStudyToYear = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyToYear");
            TextBox txtPersonStudyQualification = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyQualification");
            TextBox txtPersonStudyMajor = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtPersonStudyMajor");
            DropDownList ddlPersonStudyCountryID = (DropDownList)GridViewStudy.Rows[e.RowIndex].FindControl("ddlPersonStudyCountryID");

            PS_STUDY PStudy = new PS_STUDY(Convert.ToInt32(lblPersonStudyID.Text)
                , lblPersonStudyCitizenID.Text
                , Convert.ToInt32(ddlPersonStudyDegreeID.SelectedValue)
                , txtPersonStudyUnivName.Text
                , Convert.ToInt32(ddlPersonStudyFromMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyFromYear.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyToMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonStudyToYear.SelectedValue)
                , txtPersonStudyQualification.Text
                , txtPersonStudyMajor.Text
                , Convert.ToInt32(ddlPersonStudyCountryID.SelectedValue));

            if (ddlPersonStudyDegreeID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonStudyUnivName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (ddlPersonStudyFromMonth.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonStudyFromYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonStudyToMonth.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonStudyToYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonStudyQualification.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonStudyMajor.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (ddlPersonStudyCountryID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }

            PStudy.UPDATE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewStudy.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewStudy.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewStudy_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบสถานศึกษา " + DataBinder.Eval(e.Row.DataItem, "PS_UNIV_NAME") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyDegreeID = (DropDownList)e.Row.FindControl("ddlPersonStudyDegreeID");

                            sqlCmd.CommandText = "select * from TB_GRAD_LEV";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonStudyDegreeID.DataSource = dt;
                            ddlPersonStudyDegreeID.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_DEGREE_ID").ToString();
                            ddlPersonStudyDegreeID.DataValueField = "GRAD_LEV_ID";
                            ddlPersonStudyDegreeID.DataTextField = "GRAD_LEV_NAME";
                            ddlPersonStudyDegreeID.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyDegreeID.Items.Insert(0, new ListItem("--ระดับการศึกษา--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonStudyFromMonth = (DropDownList)e.Row.FindControl("ddlPersonStudyFromMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonStudyFromMonth.DataSource = dt;
                            ddlPersonStudyFromMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_MONTH").ToString();
                            ddlPersonStudyFromMonth.DataValueField = "MONTH_ID";
                            ddlPersonStudyFromMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonStudyFromMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonStudyFromMonth.Items.Insert(0, new ListItem("--เดือน--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                        using (OracleConnection sqlConn = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd = new OracleCommand())
                            {
                                DropDownList ddlPersonStudyFromYear = (DropDownList)e.Row.FindControl("ddlPersonStudyFromYear");

                                sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd.Connection = sqlConn;
                                sqlConn.Open();
                                OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd);
                                DataTable dt = new DataTable();
                                da2.Fill(dt);
                                ddlPersonStudyFromYear.DataSource = dt;
                                ddlPersonStudyFromYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_YEAR").ToString();
                                ddlPersonStudyFromYear.DataValueField = "YEAR_ID";
                                ddlPersonStudyFromYear.DataTextField = "YEAR_ID";
                                ddlPersonStudyFromYear.DataBind();
                                sqlConn.Close();

                                ddlPersonStudyFromYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd = new OracleCommand())
                            {
                                DropDownList ddlPersonStudyToMonth = (DropDownList)e.Row.FindControl("ddlPersonStudyToMonth");

                                sqlCmd.CommandText = "select * from TB_MONTH";
                                sqlCmd.Connection = sqlConn;
                                sqlConn.Open();
                                OracleDataAdapter da3 = new OracleDataAdapter(sqlCmd);
                                DataTable dt = new DataTable();
                                da3.Fill(dt);
                                ddlPersonStudyToMonth.DataSource = dt;
                                ddlPersonStudyToMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_MONTH").ToString();
                                ddlPersonStudyToMonth.DataValueField = "MONTH_ID";
                                ddlPersonStudyToMonth.DataTextField = "MONTH_SHORT";
                                ddlPersonStudyToMonth.DataBind();
                                sqlConn.Close();

                                ddlPersonStudyToMonth.Items.Insert(0, new ListItem("--เดือน--", "0"));
                                DataRowView dr = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd = new OracleCommand())
                            {
                                DropDownList ddlPersonStudyToYear = (DropDownList)e.Row.FindControl("ddlPersonStudyToYear");

                                sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                                sqlCmd.Connection = sqlConn;
                                sqlConn.Open();
                                OracleDataAdapter da4 = new OracleDataAdapter(sqlCmd);
                                DataTable dt = new DataTable();
                                da4.Fill(dt);
                                ddlPersonStudyToYear.DataSource = dt;
                                ddlPersonStudyToYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_YEAR").ToString();
                                ddlPersonStudyToYear.DataValueField = "YEAR_ID";
                                ddlPersonStudyToYear.DataTextField = "YEAR_ID";
                                ddlPersonStudyToYear.DataBind();
                                sqlConn.Close();

                                ddlPersonStudyToYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                                DataRowView dr = e.Row.DataItem as DataRowView;
                            }
                        }

                        using (OracleConnection sqlConn = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd = new OracleCommand())
                            {
                                DropDownList ddlPersonStudyCountryID = (DropDownList)e.Row.FindControl("ddlPersonStudyCountryID");

                                sqlCmd.CommandText = "select * from TB_GRAD_COUNTRY";
                                sqlCmd.Connection = sqlConn;
                                sqlConn.Open();
                                OracleDataAdapter da5 = new OracleDataAdapter(sqlCmd);
                                DataTable dt = new DataTable();
                                da5.Fill(dt);
                                ddlPersonStudyCountryID.DataSource = dt;
                                ddlPersonStudyCountryID.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_COUNTRY_ID").ToString();
                                ddlPersonStudyCountryID.DataValueField = "GRAD_COUNTRY_ID";
                                ddlPersonStudyCountryID.DataTextField = "GRAD_SHORT_NAME";
                                ddlPersonStudyCountryID.DataBind();
                                sqlConn.Close();

                                ddlPersonStudyCountryID.Items.Insert(0, new ListItem("--ประเทศที่จบ--", "0"));
                                DataRowView dr = e.Row.DataItem as DataRowView;
                            }
                        }
                    e.Row.Attributes.Add("style", "cursor:help;");
                    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                        }
                    }
                }
            }
        }
        
        protected void myGridViewStudy_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridViewStudy.PageIndex = e.NewPageIndex;
            GridViewStudy.DataSource = GetViewState();
            GridViewStudy.DataBind();
        }
        //GridViewLicense
        protected void modEditCommand2(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewLicense.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand2(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand2(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewLicense.DataKeys[e.RowIndex].Value);
            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            PLicense.PS_PL_ID = id;
            PLicense.DELETE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand2(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonLicenseID = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblPersonLicenseID");
            Label lblPersonLicenseCitizenID = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblPersonLicenseCitizenID");
            TextBox txtPersonLicenseName = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseName");
            TextBox txtPersonLicenseDepartment = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseDepartment");
            TextBox txtPersonLicenseNo = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseNo");
            TextBox txtPersonLicenseDate = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtPersonLicenseDate");


            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE(Convert.ToInt32(lblPersonLicenseID.Text)
                , lblPersonLicenseCitizenID.Text
                , txtPersonLicenseName.Text
                , txtPersonLicenseDepartment.Text
                , txtPersonLicenseNo.Text
                , Util.ODT(txtPersonLicenseDate.Text));

            if (string.IsNullOrEmpty(txtPersonLicenseName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonLicenseDepartment.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonLicenseNo.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonLicenseDate.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            PLicense.UPDATE_PS_PROFESSIONAL_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewLicense.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewLicense.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewLicense_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อใบอนุญาต " + DataBinder.Eval(e.Row.DataItem, "PS_LICENSE_NAME") + " จริงๆใช่ไหม ?');");

                e.Row.Attributes.Add("style", "cursor:help;");
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                        e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                    }
                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                        e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                    }
                }
            }
        }

        protected void myGridViewLicense_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridViewLicense.PageIndex = e.NewPageIndex;
            GridViewLicense.DataSource = GetViewState();
            GridViewLicense.DataBind();
        }
        //GridViewTraining
        protected void modEditCommand3(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewTraining.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand3(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand3(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewTraining.DataKeys[e.RowIndex].Value);
            PS_TRAINING PTraining = new PS_TRAINING();
            PTraining.PS_TRAINING_ID = id;
            PTraining.DELETE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand3(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonTrainingID = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblPersonTrainingID");
            Label lblPersonTrainingCitizenID = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblPersonTrainingCitizenID");
            TextBox txtPersonTrainingCourse = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtPersonTrainingCourse");
            DropDownList ddlPersonTrainingFromMonth = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingFromMonth");
            DropDownList ddlPersonTrainingFromYear = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingFromYear");
            DropDownList ddlPersonTrainingToMonth = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingToMonth");
            DropDownList ddlPersonTrainingToYear = (DropDownList)GridViewTraining.Rows[e.RowIndex].FindControl("ddlPersonTrainingToYear");
            TextBox txtPersonTrainingDepartment = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtPersonTrainingDepartment");

            PS_TRAINING PTraining = new PS_TRAINING(Convert.ToInt32(lblPersonTrainingID.Text)
                , lblPersonTrainingCitizenID.Text
                , txtPersonTrainingCourse.Text
                , Convert.ToInt32(ddlPersonTrainingFromMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingFromYear.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingToMonth.SelectedValue)
                , Convert.ToInt32(ddlPersonTrainingToYear.SelectedValue)
                , txtPersonTrainingDepartment.Text);

            if (string.IsNullOrEmpty(txtPersonTrainingCourse.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (ddlPersonTrainingFromMonth.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonTrainingFromYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonTrainingToMonth.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonTrainingToYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonTrainingDepartment.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            PTraining.UPDATE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewTraining.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewTraining.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewTraining_RowDataBound3(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบหลักสูตรฝึกอบรม " + DataBinder.Eval(e.Row.DataItem, "PS_COURSE") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingFromMonth = (DropDownList)e.Row.FindControl("ddlPersonTrainingFromMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingFromMonth.DataSource = dt;
                            ddlPersonTrainingFromMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_MONTH").ToString();
                            ddlPersonTrainingFromMonth.DataValueField = "MONTH_ID";
                            ddlPersonTrainingFromMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonTrainingFromMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingFromMonth.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingFromYear = (DropDownList)e.Row.FindControl("ddlPersonTrainingFromYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingFromYear.DataSource = dt;
                            ddlPersonTrainingFromYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_FROM_YEAR").ToString();
                            ddlPersonTrainingFromYear.DataValueField = "YEAR_ID";
                            ddlPersonTrainingFromYear.DataTextField = "YEAR_ID";
                            ddlPersonTrainingFromYear.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingFromYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingToMonth = (DropDownList)e.Row.FindControl("ddlPersonTrainingToMonth");

                            sqlCmd.CommandText = "select * from TB_MONTH";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingToMonth.DataSource = dt;
                            ddlPersonTrainingToMonth.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_MONTH").ToString();
                            ddlPersonTrainingToMonth.DataValueField = "MONTH_ID";
                            ddlPersonTrainingToMonth.DataTextField = "MONTH_SHORT";
                            ddlPersonTrainingToMonth.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingToMonth.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonTrainingToYear = (DropDownList)e.Row.FindControl("ddlPersonTrainingToYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonTrainingToYear.DataSource = dt;
                            ddlPersonTrainingToYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_TO_YEAR").ToString();
                            ddlPersonTrainingToYear.DataValueField = "YEAR_ID";
                            ddlPersonTrainingToYear.DataTextField = "YEAR_ID";
                            ddlPersonTrainingToYear.DataBind();
                            sqlConn.Close();

                            ddlPersonTrainingToYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    e.Row.Attributes.Add("style", "cursor:help;");
                    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                        }
                    }
                }
            }
        }

        protected void myGridViewTraining_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridViewTraining.PageIndex = e.NewPageIndex;
            GridViewTraining.DataSource = GetViewState();
            GridViewTraining.DataBind();
        }
        //GridViewDAA
        protected void modEditCommand4(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewDAA.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand4(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand4(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewDAA.DataKeys[e.RowIndex].Value);
            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            PDAA.PS_DAA_ID = id;
            PDAA.DELETE_PS_DISCIPLINARY_AND_AMNESTY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand4(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonDAAID = (Label)GridViewDAA.Rows[e.RowIndex].FindControl("lblPersonDAAID");
            Label lblPersonDAACitizenID = (Label)GridViewDAA.Rows[e.RowIndex].FindControl("lblPersonDAACitizenID");
            DropDownList ddlPersonDAAYear = (DropDownList)GridViewDAA.Rows[e.RowIndex].FindControl("ddlPersonDAAYear");
            TextBox txtPersonDAAName = (TextBox)GridViewDAA.Rows[e.RowIndex].FindControl("txtPersonDAAName");
            TextBox txtPersonDAARef = (TextBox)GridViewDAA.Rows[e.RowIndex].FindControl("txtPersonDAARef");


            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY(Convert.ToInt32(lblPersonDAAID.Text)
                , lblPersonDAACitizenID.Text
                , Convert.ToInt32(ddlPersonDAAYear.SelectedValue)
                , txtPersonDAAName.Text
                , txtPersonDAARef.Text);

            if (ddlPersonDAAYear.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonDAAName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonDAARef.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            PDAA.UPDATE_PS_DISCIPLINARY_AND_AMNESTY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewDAA.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewDAA.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewDAA_RowDataBound4(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบรายการ " + DataBinder.Eval(e.Row.DataItem, "PS_DAA_NAME") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonDAAYear = (DropDownList)e.Row.FindControl("ddlPersonDAAYear");

                            sqlCmd.CommandText = "select * from TB_DATE_YEAR";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonDAAYear.DataSource = dt;
                            ddlPersonDAAYear.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_YEAR").ToString();
                            ddlPersonDAAYear.DataValueField = "YEAR_ID";
                            ddlPersonDAAYear.DataTextField = "YEAR_ID";
                            ddlPersonDAAYear.DataBind();
                            sqlConn.Close();

                            ddlPersonDAAYear.Items.Insert(0, new ListItem("--ปี--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    e.Row.Attributes.Add("style", "cursor:help;");
                    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                        }
                    }
                }
            }
        }

        protected void myGridViewDAA_PageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridViewDAA.PageIndex = e.NewPageIndex;
            GridViewDAA.DataSource = GetViewState();
            GridViewDAA.DataBind();
        }
        //GridViewPAS
        protected void modEditCommand5(Object sender, GridViewEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewPAS.EditIndex = e.NewEditIndex;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = e.NewEditIndex;
                BindData1();
            }
        }
        protected void modCancelCommand5(Object sender, GridViewCancelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }
        }
        protected void modDeleteCommand5(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewPAS.DataKeys[e.RowIndex].Value);
            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            PPAS.PS_PAS_ID = id;
            PPAS.DELETE_PS_POSITION_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }
        }
        protected void modUpdateCommand5(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblPersonPASID = (Label)GridViewPAS.Rows[e.RowIndex].FindControl("lblPersonPASID");
            Label lblPersonPASCitizenID = (Label)GridViewPAS.Rows[e.RowIndex].FindControl("lblPersonPASCitizenID");
            TextBox txtPersonPASDate = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASDate");
            TextBox txtPersonPASPOsitionName = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASPOsitionName");
            TextBox txtPersonPASPositionNO = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASPositionNO");
            DropDownList ddlPersonPASPositionType = (DropDownList)GridViewPAS.Rows[e.RowIndex].FindControl("ddlPersonPASPositionType");
            DropDownList ddlPersonPASDegree = (DropDownList)GridViewPAS.Rows[e.RowIndex].FindControl("ddlPersonPASDegree");
            TextBox txtPersonPASSalary = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASSalary");
            TextBox txtPersonPASSalaryPosition = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASSalaryPosition");
            TextBox txtPersonPASRef = (TextBox)GridViewPAS.Rows[e.RowIndex].FindControl("txtPersonPASRef");

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY(Convert.ToInt32(lblPersonPASID.Text)
                , lblPersonPASCitizenID.Text
                , Util.ODT(txtPersonPASDate.Text)
                , txtPersonPASPOsitionName.Text
                , txtPersonPASPositionNO.Text
                , ddlPersonPASPositionType.SelectedValue
                , ddlPersonPASDegree.SelectedValue
                , Convert.ToInt32(txtPersonPASSalary.Text)
                , Convert.ToInt32(txtPersonPASSalaryPosition.Text)
                , txtPersonPASRef.Text);

            if (string.IsNullOrEmpty(txtPersonPASDate.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonPASPOsitionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonPASPositionNO.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (ddlPersonPASPositionType.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (ddlPersonPASDegree.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือกข้อมูลให้ถูกต้อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonPASSalary.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonPASSalaryPosition.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtPersonPASRef.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกข้อมูลให้ครบทุกช่อง')", true);
                return;
            }

            PPAS.UPDATE_PS_POSITION_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                GridViewPAS.EditIndex = -1;
                BindData();
            }
            else
            {
                GridViewPAS.EditIndex = -1;
                BindData1();
            }

        }

        protected void GridViewPAS_RowDataBound5(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบตำแหน่ง " + DataBinder.Eval(e.Row.DataItem, "PS_POSITION") + " จริงๆใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonPASPositionType = (DropDownList)e.Row.FindControl("ddlPersonPASPositionType");

                            sqlCmd.CommandText = "select * from TB_STAFF";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonPASPositionType.DataSource = dt;
                            ddlPersonPASPositionType.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_POSITION_TYPE").ToString();
                            ddlPersonPASPositionType.DataValueField = "ST_ID";
                            ddlPersonPASPositionType.DataTextField = "ST_NAME";
                            ddlPersonPASPositionType.DataBind();
                            sqlConn.Close();

                            ddlPersonPASPositionType.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd = new OracleCommand())
                        {
                            DropDownList ddlPersonPASDegree = (DropDownList)e.Row.FindControl("ddlPersonPASDegree");

                            sqlCmd.CommandText = "select * from TB_POSITION";
                            sqlCmd.Connection = sqlConn;
                            sqlConn.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPersonPASDegree.DataSource = dt;
                            ddlPersonPASDegree.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PS_POSITION_DEGREE").ToString();
                            ddlPersonPASDegree.DataValueField = "ID";
                            ddlPersonPASDegree.DataTextField = "NAME";
                            ddlPersonPASDegree.DataBind();
                            sqlConn.Close();

                            ddlPersonPASDegree.Items.Insert(0, new ListItem("--ระดับ--", "0"));
                            DataRowView dr = e.Row.DataItem as DataRowView;
                        }
                    }
                    e.Row.Attributes.Add("style", "cursor:help;");
                    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                        }
                    }
                    else
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                            e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                        }
                    }
                }
            }
        }

        protected void myGridViewPAS_PageIndexChanging5(object sender, GridViewPageEventArgs e)
        {
            GridViewPAS.PageIndex = e.NewPageIndex;
            GridViewPAS.DataSource = GetViewState();
            GridViewPAS.DataBind();
        }
        //End GridView
        private void BindProvinceList()
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
                        ddlProvince.DataSource = dt;
                        ddlProvince.DataValueField = "PROVINCE_ID";
                        ddlProvince.DataTextField = "PROVINCE_TH";
                        ddlProvince.DataBind();
                        sqlConn.Close();

                        ddlProvince.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";
                    }
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlProvince2.DataSource = dt;
                        ddlProvince2.DataValueField = "PROVINCE_ID";
                        ddlProvince2.DataTextField = "PROVINCE_TH";
                        ddlProvince2.DataBind();
                        sqlConn.Close();

                        ddlProvince2.Items.Insert(0, new ListItem("--กรุณาเลือก จังหวัด--", "0"));
                        ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";
                    }
                }
            }
            catch { }
        }
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlProvince.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAmphur.DataSource = dt;
                        ddlAmphur.DataValueField = "AMPHUR_ID";
                        ddlAmphur.DataTextField = "AMPHUR_TH";
                        ddlAmphur.DataBind();
                        sqlConn.Close();

                        ddlAmphur.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict.Items.Clear();
                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlAmphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DISTRICT where AMPHUR_ID=:DISTRICT_ID";
                        sqlCmd.Parameters.Add(":DISTRICT_ID", ddlAmphur.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDistrict.DataSource = dt;
                        ddlDistrict.DataValueField = "DISTRICT_ID";
                        ddlDistrict.DataTextField = "DISTRICT_TH";
                        ddlDistrict.DataBind();
                        sqlConn.Close();

                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode.Text = "";

                    }
                }
            }
            catch { }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC = new OracleCommand(setZIP, conn);
            string ZIPCODE = SC.ExecuteScalar().ToString();
            tbZipcode.Text = ZIPCODE;
        }

        protected void ddlProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlProvince2.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAmphur2.DataSource = dt;
                        ddlAmphur2.DataValueField = "AMPHUR_ID";
                        ddlAmphur2.DataTextField = "AMPHUR_TH";
                        ddlAmphur2.DataBind();
                        sqlConn.Close();

                        ddlAmphur2.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlDistrict2.Items.Clear();
                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";
                    }
                }
            }
            catch { }
        }

        protected void ddlAmphur2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DISTRICT where AMPHUR_ID=:DISTRICT_ID";
                        sqlCmd.Parameters.Add(":DISTRICT_ID", ddlAmphur2.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDistrict2.DataSource = dt;
                        ddlDistrict2.DataValueField = "DISTRICT_ID";
                        ddlDistrict2.DataTextField = "DISTRICT_TH";
                        ddlDistrict2.DataBind();
                        sqlConn.Close();

                        ddlDistrict2.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                        tbZipcode2.Text = "";

                    }
                }
            }
            catch { }
        }

        protected void ddlDistrict2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ConnectionString);
            conn.Open();
            string setZIP2 = "select POST_CODE from TB_DISTRICT where DISTRICT_ID = " + ddlDistrict.SelectedValue + "";
            OracleCommand SC2 = new OracleCommand(setZIP2, conn);
            string ZIPCODE2 = SC2.ExecuteScalar().ToString();
            tbZipcode2.Text = ZIPCODE2;
        }

        protected void SQLCampus()
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
            }
            catch { }
        }

        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
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
            }
            catch { }
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
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
            }
            catch { }
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
                        sqlCmd.CommandText = "select * FROM TB_POSITION_GOVERNMENT_OFFICER where ST_ID = " + ddlPositionType14.SelectedValue + "UNION ALL select * FROM TB_POSITION_PERMANENT_EMP where ST_ID = " + ddlPositionType14.SelectedValue;
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
            /*  if(tbCitizenID.Text == "" || ddlTitle.SelectedIndex == 0 || tbNameTH.Text == ""|| tbLastNameTH.Text == "" || tbNameEN.Text == "" || tbLastNameEN.Text == "" || ddlGender.SelectedIndex == 0 || tbBirthday.Text == "" || ddlRace.SelectedIndex == 0 || ddlNation.SelectedIndex == 0 || ddlBlood.SelectedIndex == 0 || tbEmail.Text == "" || tbPhone.Text == "" || tbTelephone.Text == "" || ddlReligion.SelectedIndex == 0 || ddlStatus.SelectedIndex == 0 || tbFatherName.Text == "" || tbFatherLastName.Text == "" || tbMotherName.Text == "" || tbMotherLastName.Text == "" || tbMotherOldLastName.Text == "" || tbCoupleName.Text == "" || tbCoupleLastName.Text == "" || tbCoupleOldLastName.Text == "") {

                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>เกิดข้อผิดพลาด !</strong></div>";
                if (tbCitizenID.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'บัตรประชาชน'</div>";
                }
                if (ddlTitle.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'คำนำหน้า'</div>";
                }
                if (tbNameTH.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ'</div>";
                }
                if (tbLastNameTH.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล'</div>";
                }
                if (tbNameEN.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ อังกฤษ'</div>";
                }
                if (tbLastNameEN.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล อังกฤษ'</div>";
                }
                if (ddlGender.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'เพศ'</div>";
                }
                if (tbBirthday.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันเกิด'</div>";
                }
                if (ddlRace.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'เชื้อชาติ'</div>";
                }
                if (ddlNation.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'สัญชาติ'</div>";
                }
                if (ddlBlood.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'กรุ๊ปเลือด'</div>";
                }
                if (tbEmail.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'อีเมล'</div>";
                }
                if (tbPhone.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์มือถือ'</div>";
                }
                if (tbTelephone.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์ที่ทำงาน'</div>";
                }
                if (ddlReligion.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ศาสนา'</div>";
                }
                if (ddlStatus.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'สถานภาพ'</div>";
                }
                if (tbFatherName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อบิดา'</div>";
                }
                if (tbFatherLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลบิดา'</div>";
                }
                if (tbMotherName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อมารดา'</div>";
                }
                if (tbMotherLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดา'</div>";
                }
                if (tbMotherOldLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดาเดิม'</div>";
                }
                if (tbCoupleName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อคู่สมรส'</div>";
                }
                if (tbCoupleLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรส'</div>";
                }
                if (tbCoupleOldLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรสเดิม'</div>";
                }
            } else {
                MultiView1.ActiveViewIndex = 1;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            */
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV2Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e)
        {
            /* if (tbHomeAdd.Text == "" || tbSoi.Text == "" || tbMoo.Text == "" || tbRoad.Text == "" || ddlProvince.SelectedIndex == 0 || ddlAmphur.SelectedIndex == 0 || ddlDistrict.SelectedIndex == 0 || tbZipcode.Text == "" || ddlCountry.SelectedIndex == 0 || tbState.Text == "" ||
                 tbHomeAdd2.Text == "" || tbSoi2.Text == "" || tbMoo2.Text == "" || tbRoad2.Text == "" || ddlProvince2.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0 || tbZipcode2.Text == "" || ddlCountry2.SelectedIndex == 0 || tbState2.Text == "")
             {
                 notification.Attributes["class"] = "alert alert_danger";
                 notification.InnerHtml = "";

                 notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                 if (tbHomeAdd.Text == "" || tbHomeAdd2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'บ้านเลขที่'</div>";
                 }
                 if (tbSoi.Text == "" || tbSoi2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'ซอย'</div>";
                 }
                 if (tbMoo.Text == "" || tbMoo2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'หมู่'</div>";
                 }
                 if (tbRoad.Text == "" || tbRoad2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'ถนน'</div>";
                 }
                 if (ddlProvince.SelectedIndex == 0 || ddlProvince2.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'จังหวัด'</div>";
                 }
                 if (ddlAmphur.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'อำเภอ / เขต'</div>";
                 }
                 if (ddlDistrict.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'ตำบล / แขวง'</div>";
                 }
                 if (tbZipcode.Text == "" || tbZipcode2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'รหัสไปรณีย์'</div>";
                 }
                 if (ddlCountry.SelectedIndex == 0 || ddlCountry2.SelectedIndex == 0)
                 {
                     notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศ'</div>";
                 }
                 if (tbState.Text == "" || tbState2.Text == "")
                 {
                     notification.InnerHtml += "<div>กรุณากรอก 'รัฐ'</div>";
                 }
             }
             else {
                 MultiView1.ActiveViewIndex = 2;
                 notification.Attributes["class"] = "none";
                 notification.InnerHtml = "";
             }
             */
            MultiView1.ActiveViewIndex = 2;
        }
        protected void lbuAddressFetch_Click(object sender, EventArgs e)
        {
            tbHomeAdd2.Text = tbHomeAdd.Text;
            tbSoi2.Text = tbSoi.Text;
            tbMoo2.Text = tbMoo.Text;
            tbRoad2.Text = tbRoad.Text;
            tbZipcode2.Text = tbZipcode.Text;
            tbState2.Text = tbState.Text;

            ddlProvince2.Items.Clear();
            ddlAmphur2.Items.Clear();
            ddlDistrict2.Items.Clear();

            ddlProvince2.Items.AddRange(ddlProvince.Items.OfType<ListItem>().ToArray());
            ddlAmphur2.Items.AddRange(ddlAmphur.Items.OfType<ListItem>().ToArray());
            ddlDistrict2.Items.AddRange(ddlDistrict.Items.OfType<ListItem>().ToArray());

            ddlProvince2.SelectedIndex = ddlProvince.SelectedIndex;
            ddlAmphur2.SelectedIndex = ddlAmphur.SelectedIndex;
            ddlDistrict2.SelectedIndex = ddlDistrict.SelectedIndex;
            ddlCountry2.SelectedIndex = ddlCountry.SelectedIndex;
        }

        protected void lbuV3Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV3Next_Click(object sender, EventArgs e)
        {
            /* if (ddlDegree10.SelectedIndex == 0 || tbUnivName10.Text == "" || ddlMonth10From.SelectedIndex == 0 || ddlYear10From.SelectedIndex == 0 || ddlMonth10To.SelectedIndex == 0 || ddlYear10To.SelectedIndex == 0 || tbQualification10.Text == "" || tbMajor10.Text == "" || tbCountrySuccess10.Text == "")
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
                MultiView1.ActiveViewIndex = 3;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            */
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV4Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuV4Next_Click(object sender, EventArgs e)
        {
            /*  if (ddlDegree10.SelectedIndex == 0 || ddlCampus.SelectedIndex == 0 || ddlFaculty.SelectedIndex == 0 || ddlDivision.SelectedIndex == 0 || ddlWorkDivision.SelectedIndex == 0 || ddlStaffType.SelectedIndex == 0 || ddlBudget.SelectedIndex == 0 || ddlAdminPosition.SelectedIndex == 0 || ddlPositionWork.SelectedIndex == 0 || ddlAcademic.SelectedIndex == 0 || tbDateInwork.Text == "" || tbSpecialWork.Text == "" || ddlTeachISCED.SelectedIndex == 0)
              {
                  notification.Attributes["class"] = "alert alert_danger";
                  notification.InnerHtml = "";

                  notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                  if (ddlCampus.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'วิทยาเขต'</div>";
                  }
                  if (ddlFaculty.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'สำนัก / สถาบัน / คณะ'</div>";
                  }
                  if (ddlDivision.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'กอง / สำนักงานเลขา / ภาควิชา'</div>";
                  }
                  if (ddlWorkDivision.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'งาน / ฝ่าย'</div>";
                  }
                  if (ddlStaffType.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'ประเภทบุคลากร'</div>";
                  }
                  if (ddlBudget.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'ประเภทเงินจ้าง'</div>";
                  }
                  if (ddlAdminPosition.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งบริหาร'</div>";
                  }
                  if (ddlPositionWork.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งในสายงาน'</div>";
                  }
                  if (ddlAcademic.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'ตำแหน่งทางวิชาการ'</div>";
                  }
                  if (tbDateInwork.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'วันที่เริ่มบรรจุ / เริ่มงาน'</div>";
                  }
                  if (tbSpecialWork.Text == "")
                  {
                      notification.InnerHtml += "<div>กรุณากรอก 'ความเชี่ยวชาญในสายงาน'</div>";
                  }
                  if (ddlTeachISCED.SelectedIndex == 0)
                  {
                      notification.InnerHtml += "<div>กรุณาเลือก 'กลุ่มสาขาวิชาที่สอน'</div>";
                  }
                  else {
                      MultiView1.ActiveViewIndex = 4;
                      notification.Attributes["class"] = "none";
                      notification.InnerHtml = "";
                  }
              }
              */
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV5Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV5Next_Click(object sender, EventArgs e)
        {
            /*  if (tbLicenseName11.Text == "" || tbLicenseName11.Text == "" || tbDepartment11.Text == "" || tbLicenseNo11.Text == "" || tbUseDate11.Text == "")
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
                      MultiView1.ActiveViewIndex = 5;
                      notification.Attributes["class"] = "none";
                      notification.InnerHtml = "";
                  }
              }
              */
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV6Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV6Next_Click(object sender, EventArgs e)
        {
            /*  if (tbCourse.Text == "" || ddlMonth12From.SelectedIndex == 0 || ddlYear12From.SelectedIndex == 0 || ddlMonth12To.SelectedIndex == 0 || ddlYear12To.SelectedIndex == 0 || tbDepartment.Text == "")
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
                    MultiView1.ActiveViewIndex = 6;
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }
            */
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbuV7Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV7Next_Click(object sender, EventArgs e)
        {
            /*  if (ddlYear13.SelectedIndex == 0 || tbName13.Text == "" || tbREF13.Text == "")
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
                    MultiView1.ActiveViewIndex = 7;
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }
            */
            MultiView1.ActiveViewIndex = 7;
        }

        protected void lbuV8Back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            /*   if (tbDate14.Text == "" || tbPosition14.Text == "" || tbPositionNo14.Text == "" || ddlPositionType14.SelectedIndex == 0 || ddlPositionDegree14.SelectedIndex == 0 || tbSalary14.Text == "" || tbSalaryPosition14.Text == "" || tbRef14.Text == "")
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

            //view1/8
            PS_PERSON P0 = new PS_PERSON();
            P0.PS_CITIZEN_ID = tbCitizenID.Text;
            P0.PS_MINISTRY_ID = 1;
            P0.PS_GROM = "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            P0.PS_TITLE_ID = Convert.ToInt32(ddlTitle.SelectedValue);
            P0.PS_FN_TH = tbNameTH.Text;
            P0.PS_FN_EN = tbNameEN.Text;
            P0.PS_LN_TH = tbLastNameTH.Text;
            P0.PS_LN_EN = tbLastNameEN.Text;
            P0.PS_GENDER_ID = Convert.ToInt32(ddlGender.SelectedValue);
            P0.PS_BIRTHDAY_DATE = Util.ODT(tbBirthday.Text);
            P0.PS_BIRTHDAY_LONG = Util.ToThaiWordBirthday(tbBirthday.Text);
            P0.PS_RACE_ID = Convert.ToInt32(ddlRace.SelectedValue);
            P0.PS_NATION_ID = ddlNation.SelectedValue;
            P0.PS_BLOOD_ID = Convert.ToInt32(ddlBlood.SelectedValue);
            P0.PS_EMAIL = tbEmail.Text;
            P0.PS_PHONE = tbPhone.Text;
            P0.PS_TELEPHONE_WORK = tbTelephone.Text;
            P0.PS_RELIGION_ID = Convert.ToInt32(ddlReligion.SelectedValue);
            P0.PS_STATUS_ID = Convert.ToInt32(ddlStatus.SelectedValue);
            P0.PS_DAD_FN = tbFatherName.Text;
            P0.PS_DAD_LN = tbFatherLastName.Text;
            P0.PS_MOM_FN = tbMotherName.Text;
            P0.PS_MOM_LN = tbMotherLastName.Text;
            P0.PS_MOM_LN_OLD = tbMotherOldLastName.Text;
            P0.PS_LOV_FN = tbCoupleName.Text;
            P0.PS_LOV_LN = tbCoupleLastName.Text;
            P0.PS_LOV_LN_OLD = tbCoupleOldLastName.Text;
            //view2/8
            P0.PS_HOMEADD = tbHomeAdd.Text;
            P0.PS_SOI = tbSoi.Text;
            P0.PS_MOO = tbMoo.Text;
            P0.PS_STREET = tbRoad.Text;
            P0.PS_PROVINCE_ID = Convert.ToInt32(ddlProvince.SelectedValue);
            P0.PS_AMPHUR_ID = Convert.ToInt32(ddlAmphur.SelectedValue);
            P0.PS_DISTRICT = Convert.ToInt32(ddlDistrict.SelectedValue);
            P0.PS_ZIPCODE = tbZipcode.Text;
            P0.PS_COUNTRY_ID = Convert.ToInt32(ddlCountry.SelectedValue);
            P0.PS_STATE = tbState.Text;
            P0.PS_HOMEADD_NOW = tbHomeAdd2.Text;
            P0.PS_SOI_NOW = tbSoi2.Text;
            P0.PS_MOO_NOW = tbMoo2.Text;
            P0.PS_STREET_NOW = tbRoad.Text;
            P0.PS_PROVINCE_ID_NOW = Convert.ToInt32(ddlProvince2.SelectedValue);
            P0.PS_AMPHUR_ID_NOW = Convert.ToInt32(ddlAmphur2.SelectedValue);
            P0.PS_DISTRICT_ID_NOW = Convert.ToInt32(ddlDistrict2.SelectedValue);
            P0.PS_ZIPCODE_NOW = tbZipcode2.Text;
            P0.PS_COUNTRY_ID_NOW = Convert.ToInt32(ddlCountry2.SelectedValue);
            P0.PS_STATE_NOW = tbState2.Text;
            //view4/8
            P0.PS_CAMPUS_ID = Convert.ToInt32(ddlCampus.SelectedValue);
            P0.PS_FACULTY_ID = Convert.ToInt32(ddlFaculty.SelectedValue);
            P0.PS_DIVISION_ID = Convert.ToInt32(ddlDivision.SelectedValue);
            P0.PS_WORK_DIVISION_ID = Convert.ToInt32(ddlWorkDivision.SelectedValue);
            P0.PS_STAFFTYPE_ID = Convert.ToInt32(ddlStaffType.SelectedValue);
            P0.PS_BUDGET_ID = Convert.ToInt32(ddlBudget.SelectedValue);
            P0.PS_ADMIN_POS_ID = ddlAdminPosition.SelectedValue;
            P0.PS_WORK_POS_ID = Convert.ToInt32(ddlPositionWork.SelectedValue);
            P0.PS_ACAD_POS_ID = Convert.ToInt32(ddlAcademic.SelectedValue);
            P0.PS_INWORK_DATE = Util.ODT(tbDateInwork.Text);
            P0.PS_RETIRE_DATE = Util.ODT(Util.BirthdayToRetireDate(tbBirthday.Text));
            P0.PS_RETIRE_LONG = Util.ToThaiWordRetire(tbBirthday.Text);
            P0.PS_SPECIAL_WORK = tbSpecialWork.Text;
            P0.PS_TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            P0.PS_PASSWORD = Util.RandomPassword(8);
            P0.PS_POSITION_ID = ddlPosition.SelectedValue;
            P0.UPDATE_PS_PERSON();

            Response.Redirect("Default.aspx");
            notification.Attributes["class"] = "alert alert_success";
            notification.InnerHtml = "";
            notification.InnerHtml += "<div><img src='Image/Small/correct.png' /><strong> เพิ่มข้อมูลบุคลากร เรียบร้อย</strong></div>";
        }

        protected void lbuV3Add_Click(object sender, EventArgs e)
        {
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
                PS_STUDY PStudy = new PS_STUDY();
                PStudy.PS_CITIZEN_ID = tbCitizenID.Text;
                PStudy.PS_DEGREE_ID = Convert.ToInt32(ddlDegree10.SelectedValue);
                PStudy.PS_UNIV_NAME = tbUnivName10.Text;
                PStudy.PS_FROM_MONTH = Convert.ToInt32(ddlMonth10From.SelectedValue);
                PStudy.PS_FROM_YEAR = Convert.ToInt32(ddlYear10From.SelectedValue);
                PStudy.PS_TO_MONTH = Convert.ToInt32(ddlMonth10To.SelectedValue);
                PStudy.PS_TO_YEAR = Convert.ToInt32(ddlYear10To.SelectedValue);
                PStudy.PS_QUALIFICATION = tbQualification10.Text;
                PStudy.PS_MAJOR = tbMajor10.Text;
                PStudy.PS_COUNTRY_ID = Convert.ToInt32(ddlCountrySuccess10.SelectedValue);
                PStudy.INSERT_PS_STUDY();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษา เรียบร้อย')", true);
                ClearPStudy10();
                DataTable dt1 = PStudy.SELECT_PS_STUDY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "", "");
                GridViewStudy.DataSource = dt1;
                GridViewStudy.DataBind();
                SetViewState(dt1);

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV5Add_Click(object sender, EventArgs e)
        {
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
                PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
                PLicense.PS_CITIZEN_ID = tbCitizenID.Text;
                PLicense.PS_LICENSE_NAME = tbLicenseName11.Text;
                PLicense.PS_DEPARTMENT = tbDepartment11.Text;
                PLicense.PS_LICENSE_NO = tbLicenseNo11.Text;
                PLicense.PS_USE_DATE = Util.ODT(tbUseDate11.Text);
                PLicense.INSERT_PS_PROFESSIONAL_LICENSE();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบอนุญาตประกอบวิชาชีพ เรียบร้อย')", true);
                ClearPLicense11();
                DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(txtSearchPersonID.Text, "", "", "", "");
                GridViewLicense.DataSource = dt2;
                GridViewLicense.DataBind();
                SetViewState(dt2);

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV6Add_Click(object sender, EventArgs e)
        {
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
                PS_TRAINING PTraining = new PS_TRAINING();
                PTraining.PS_CITIZEN_ID = tbCitizenID.Text;
                PTraining.PS_COURSE = tbCourse.Text;
                PTraining.PS_FROM_MONTH = Convert.ToInt32(ddlMonth12From.SelectedValue);
                PTraining.PS_FROM_YEAR = Convert.ToInt32(ddlYear12From.SelectedValue);
                PTraining.PS_TO_MONTH = Convert.ToInt32(ddlMonth12To.SelectedValue);
                PTraining.PS_TO_YEAR = Convert.ToInt32(ddlYear12To.SelectedValue);
                PTraining.PS_DEPARTMENT = tbDepartment.Text;
                PTraining.INSERT_PS_TRAINING();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษา เรียบร้อย')", true);
                ClearPTraining12();
                DataTable dt3 = PTraining.SELECT_PS_TRAINING(txtSearchPersonID.Text, "", "", "", "", "", "");
                GridViewTraining.DataSource = dt3;
                GridViewTraining.DataBind();
                SetViewState(dt3);

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV7Add_Click(object sender, EventArgs e)
        {
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
                PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
                PDAA.PS_CITIZEN_ID = tbCitizenID.Text;
                PDAA.PS_YEAR = Convert.ToInt32(ddlYear13.SelectedValue);
                PDAA.PS_DAA_NAME = tbName13.Text;
                PDAA.PS_REF = tbREF13.Text;
                PDAA.INSERT_PS_DISCIPLINARY_AND_AMNESTY();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม เรียบร้อย')", true);
                ClearPDAA13();
                DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(txtSearchPersonID.Text, "", "", "");
                GridViewDAA.DataSource = dt4;
                GridViewDAA.DataBind();
                SetViewState(dt4);

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV8Add_Click(object sender, EventArgs e)
        {
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
                PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
                PPAS.PS_CITIZEN_ID = tbCitizenID.Text;
                PPAS.PS_DATE = Util.ODT(tbDate14.Text);
                PPAS.PS_POSITION = tbPosition14.Text;
                PPAS.PS_POSITION_NO = tbPositionNo14.Text;
                PPAS.PS_POSITION_TYPE = ddlPositionType14.SelectedValue;
                PPAS.PS_POSITION_DEGREE = ddlPositionDegree14.SelectedValue;
                PPAS.PS_SALARY = Convert.ToInt32(tbSalary14.Text);
                PPAS.PS_SALARY_POSITION = Convert.ToInt32(tbSalaryPosition14.Text);
                PPAS.PS_REF = tbRef14.Text;
                PPAS.INSERT_PS_POSITION_AND_SALARY ();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม เรียบร้อย')", true);
                ClearPPAS14();
                DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "");
                GridViewPAS.DataSource = dt5;
                GridViewPAS.DataBind();
                SetViewState(dt5);

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 1)
            {
                tbState.Enabled = true;
            }
            else
            {
                tbState.Enabled = false;
            }
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID,PS_TITLE_ID,PS_FN_TH,PS_FN_EN,PS_LN_TH,PS_LN_EN,PS_GENDER_ID,PS_BIRTHDAY_DATE,PS_RACE_ID,PS_NATION_ID,PS_BLOOD_ID,PS_RELIGION_ID,PS_STATUS_ID,PS_EMAIL,PS_PHONE,PS_TELEPHONE_WORK,PS_DAD_FN,PS_DAD_LN,PS_MOM_FN,PS_MOM_LN,PS_MOM_LN_OLD,PS_LOV_FN,PS_LOV_LN,PS_LOV_LN_OLD,PS_HOMEADD,PS_SOI,PS_MOO,PS_STREET,PS_PROVINCE_ID,PS_AMPHUR_ID,PS_DISTRICT,PS_ZIPCODE,PS_COUNTRY_ID,PS_STATE,PS_HOMEADD_NOW,PS_SOI_NOW,PS_MOO_NOW,PS_STREET_NOW,PS_PROVINCE_ID_NOW,PS_AMPHUR_ID_NOW,PS_DISTRICT_ID_NOW,PS_ZIPCODE_NOW,PS_COUNTRY_ID_NOW,PS_STATE_NOW,PS_CAMPUS_ID,PS_FACULTY_ID,PS_DIVISION_ID,PS_WORK_DIVISION_ID,PS_STAFFTYPE_ID,PS_BUDGET_ID,PS_POSITION_ID,PS_ADMIN_POS_ID,PS_WORK_POS_ID,PS_ACAD_POS_ID,PS_INWORK_DATE,PS_SPECIAL_WORK,PS_TEACH_ISCED_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchPersonID.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //view1
                            tbCitizenID.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            ddlTitle.SelectedValue = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                            tbNameTH.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            tbLastNameTH.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            tbNameEN.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            tbLastNameEN.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            ddlGender.SelectedValue = reader.IsDBNull(6) ? "0" : reader.GetInt32(6).ToString();
                            tbBirthday.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(7) ? "" : reader.GetValue(7).ToString());
                            ddlRace.SelectedValue = reader.IsDBNull(8) ? "0" : reader.GetInt32(8).ToString();
                            ddlNation.SelectedValue = reader.IsDBNull(9) ? "" : reader.GetString(9).ToString();
                            ddlBlood.SelectedValue = reader.IsDBNull(10) ? "0" : reader.GetInt32(10).ToString();
                            ddlReligion.SelectedValue = reader.IsDBNull(11) ? "0" : reader.GetInt32(11).ToString();
                            ddlStatus.SelectedValue = reader.IsDBNull(12) ? "0" : reader.GetInt32(12).ToString();
                            tbEmail.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            tbPhone.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                            tbTelephone.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                            tbFatherName.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                            tbFatherLastName.Text = reader.IsDBNull(17) ? "" : reader.GetString(17);
                            tbMotherName.Text = reader.IsDBNull(18) ? "" : reader.GetString(18);
                            tbMotherLastName.Text = reader.IsDBNull(19) ? "" : reader.GetString(19);
                            tbMotherOldLastName.Text = reader.IsDBNull(20) ? "" : reader.GetString(20);
                            tbCoupleName.Text = reader.IsDBNull(21) ? "" : reader.GetString(21);
                            tbCoupleLastName.Text = reader.IsDBNull(22) ? "" : reader.GetString(22);
                            tbCoupleOldLastName.Text = reader.IsDBNull(23) ? "" : reader.GetString(23);
                            //view2
                            tbHomeAdd.Text = reader.IsDBNull(24) ? "" : reader.GetString(24);
                            tbSoi.Text = reader.IsDBNull(25) ? "" : reader.GetString(25);
                            tbMoo.Text = reader.IsDBNull(26) ? "" : reader.GetString(26);
                            tbRoad.Text = reader.IsDBNull(27) ? "" : reader.GetString(27);
                            ddlProvince.SelectedValue = reader.IsDBNull(28) ? "0" : reader.GetInt32(28).ToString();

                            ddlAmphur.Items.Clear();
                            string s1 = reader.IsDBNull(29) ? "0" : reader.GetInt32(29).ToString();
                            DatabaseManager.BindDropDown(ddlAmphur, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince.SelectedValue , "AMPHUR_TH", "AMPHUR_ID","--กรุณาเลือกอำเภอ--");
                            ddlAmphur.SelectedValue = s1;

                            ddlDistrict.Items.Clear();
                            string s2 = reader.IsDBNull(30) ? "0" : reader.GetInt32(30).ToString();
                            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict.SelectedValue = s2;

                            tbZipcode.Text = reader.IsDBNull(31) ? "" : reader.GetString(31);
                            ddlCountry.SelectedValue = reader.IsDBNull(32) ? "0" : reader.GetInt32(32).ToString();
                            tbState.Text = reader.IsDBNull(33) ? "" : reader.GetString(33);
                            tbHomeAdd2.Text = reader.IsDBNull(34) ? "" : reader.GetString(34);
                            tbSoi2.Text = reader.IsDBNull(35) ? "" : reader.GetString(35);
                            tbMoo2.Text = reader.IsDBNull(36) ? "" : reader.GetString(36);
                            tbRoad2.Text = reader.IsDBNull(37) ? "" : reader.GetString(37);
                            ddlProvince2.SelectedValue = reader.IsDBNull(38) ? "0" : reader.GetInt32(38).ToString();

                            ddlAmphur2.Items.Clear();
                            string s3 = reader.IsDBNull(39) ? "0" : reader.GetInt32(39).ToString();
                            DatabaseManager.BindDropDown(ddlAmphur2, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince2.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ--");
                            ddlAmphur2.SelectedValue = s3;

                            ddlDistrict2.Items.Clear();
                            string s4 = reader.IsDBNull(40) ? "0" : reader.GetInt32(40).ToString();
                            DatabaseManager.BindDropDown(ddlDistrict2, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur2.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlDistrict2.SelectedValue = s4;

                            tbZipcode2.Text = reader.IsDBNull(41) ? "" : reader.GetString(41);
                            ddlCountry2.SelectedValue = reader.IsDBNull(42) ? "0" : reader.GetInt32(42).ToString();
                            tbState2.Text = reader.IsDBNull(43) ? "" : reader.GetString(43);
                            //view3
                            if (string.IsNullOrEmpty(tbCitizenID.Text))
                            {
                                PS_STUDY PStudy = new PS_STUDY();
                                DataTable dt1 = PStudy.SELECT_PS_STUDY(loginPerson.CitizenID, "", "", "", "", "", "", "", "", "");
                                GridViewStudy.DataSource = dt1;
                                GridViewStudy.DataBind();
                                SetViewState(dt1);
                            }
                            else
                            {
                                PS_STUDY PStudy = new PS_STUDY();
                                DataTable dt1 = PStudy.SELECT_PS_STUDY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "", "");
                                GridViewStudy.DataSource = dt1;
                                GridViewStudy.DataBind();
                                SetViewState(dt1);
                            }
                            //view4
                            ddlCampus.SelectedValue = reader.IsDBNull(44) ? "0" : reader.GetInt32(44).ToString();

                            ddlFaculty.Items.Clear();
                            string f1 = reader.IsDBNull(45) ? "0" : reader.GetInt32(45).ToString();
                            DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY WHERE CAMPUS_ID = " + ddlCampus.SelectedValue, "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกสำนัก / สถาบัน / คณะ--");
                            ddlFaculty.SelectedValue = f1;

                            ddlDivision.Items.Clear();
                            string f2 = reader.IsDBNull(46) ? "0" : reader.GetInt32(46).ToString();
                            DatabaseManager.BindDropDown(ddlDivision, "SELECT * FROM TB_DIVISION WHERE FACULTY_ID = " + ddlFaculty.SelectedValue, "DIVISION_NAME", "DIVISION_ID", "--กรุณาเลือกกอง / สำนักงานเลขา / ภาควิชา--");
                            ddlDivision.SelectedValue = f2;

                            ddlWorkDivision.Items.Clear();
                            string f3 = reader.IsDBNull(47) ? "0" : reader.GetInt32(47).ToString();
                            DatabaseManager.BindDropDown(ddlWorkDivision, "SELECT * FROM TB_WORK_DIVISION WHERE DIVISION_ID = " + ddlDivision.SelectedValue, "WORK_NAME", "WORK_ID", "--กรุณาเลือกงาน / ฝ่าย--");
                            ddlWorkDivision.SelectedValue = f3;

                            ddlStaffType.SelectedValue = reader.IsDBNull(48) ? "0" : reader.GetInt32(48).ToString();
                            ddlBudget.SelectedValue = reader.IsDBNull(49) ? "0" : reader.GetInt32(49).ToString();
                            ddlPosition.SelectedValue = reader.IsDBNull(50) ? "0" : reader.GetString(50).ToString();
                            ddlAdminPosition.SelectedValue = reader.IsDBNull(51) ? "0" : reader.GetInt32(51).ToString();
                            ddlPositionWork.SelectedValue = reader.IsDBNull(52) ? "0" : reader.GetInt32(52).ToString();
                            ddlAcademic.SelectedValue = reader.IsDBNull(53) ? "0" : reader.GetInt32(53).ToString();
                            tbDateInwork.Text = Util.PureDatabaseToThaiDate(reader.IsDBNull(54) ? "" : reader.GetValue(54).ToString());
                            tbSpecialWork.Text = reader.IsDBNull(55) ? "" : reader.GetString(55);
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(56) ? "" : reader.GetString(56).ToString();
                            //view5
                            if (string.IsNullOrEmpty(tbCitizenID.Text))
                            {
                                PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
                                DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(loginPerson.CitizenID, "", "", "", "");
                                GridViewLicense.DataSource = dt2;
                                GridViewLicense.DataBind();
                                SetViewState(dt2);
                            }
                            else
                            {
                                PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
                                DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(txtSearchPersonID.Text, "", "", "", "");
                                GridViewLicense.DataSource = dt2;
                                GridViewLicense.DataBind();
                                SetViewState(dt2);
                            }
                            //view6
                            if (string.IsNullOrEmpty(tbCitizenID.Text))
                            {
                                PS_TRAINING PTraining = new PS_TRAINING();
                                DataTable dt1 = PTraining.SELECT_PS_TRAINING(loginPerson.CitizenID, "", "", "", "", "", "");
                                GridViewTraining.DataSource = dt1;
                                GridViewTraining.DataBind();
                                SetViewState(dt1);
                            }
                            else
                            {
                                PS_TRAINING PTraining = new PS_TRAINING();
                                DataTable dt1 = PTraining.SELECT_PS_TRAINING(txtSearchPersonID.Text, "", "", "", "", "", "");
                                GridViewTraining.DataSource = dt1;
                                GridViewTraining.DataBind();
                                SetViewState(dt1);
                            }
                            //view7
                            if (string.IsNullOrEmpty(tbCitizenID.Text))
                            {
                                PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
                                DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(loginPerson.CitizenID, "", "", "");
                                GridViewDAA.DataSource = dt4;
                                GridViewDAA.DataBind();
                                SetViewState(dt4);
                            }
                            else
                            {
                                PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
                                DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(txtSearchPersonID.Text, "", "", "");
                                GridViewDAA.DataSource = dt4;
                                GridViewDAA.DataBind();
                                SetViewState(dt4);
                            }
                            //view8
                            if (string.IsNullOrEmpty(tbCitizenID.Text))
                            {
                                PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
                                DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(loginPerson.CitizenID, "", "", "", "", "", "", "", "");
                                GridViewPAS.DataSource = dt5;
                                GridViewPAS.DataBind();
                                SetViewState(dt5);
                            }
                            else
                            {
                                PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
                                DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(txtSearchPersonID.Text, "", "", "", "", "", "", "", "");
                                GridViewPAS.DataSource = dt5;
                                GridViewPAS.DataBind();
                                SetViewState(dt5);
                            }
                            
                        }
                    }
                }
            }
        }


    }
}