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
    public partial class AddPersonGP7_Edit : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        public OracleConnection conn = new OracleConnection(@"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                SQLddlPositionType14();
                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";

                //view1
                DatabaseManager.BindDropDown(ddlDegree10, "SELECT * FROM TB_GRAD_LEV", "GRAD_LEV_NAME", "GRAD_LEV_ID", "--กรุณาเลือกระดับการศึกษา--");
                DatabaseManager.BindDropDown(ddlMonth10From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear10From.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlMonth10To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear10To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear10To.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlCountrySuccess10, "SELECT * FROM TB_GRAD_COUNTRY", "GRAD_SHORT_NAME", "GRAD_COUNTRY_ID", "--กรุณาเลือกประเทศที่จบ--");
                //view2
                //view3
                DatabaseManager.BindDropDown(ddlMonth12From, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12From, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear12From.SelectedValue = "2559";
                DatabaseManager.BindDropDown(ddlMonth12To, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear12To, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear12To.SelectedValue = "2559";
                //view4
                DatabaseManager.BindDropDown(ddlYear13, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
                ddlYear13.SelectedValue = "2559";
                //view5
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
            DataTable dt1 = PStudy.SELECT_PS_STUDY(tbCitizenID.Text, "", "", "", "", "", "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(tbCitizenID.Text, "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            PS_TRAINING PTraining = new PS_TRAINING();
            DataTable dt3 = PTraining.SELECT_PS_TRAINING(tbCitizenID.Text, "", "", "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
            DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(tbCitizenID.Text, "", "", "");
            GridViewDAA.DataSource = dt4;
            GridViewDAA.DataBind();
            SetViewState(dt4);

            PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
            DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(tbCitizenID.Text, "", "", "", "", "", "", "", "");
            GridViewPAS.DataSource = dt5;
            GridViewPAS.DataBind();
            SetViewState(dt5);
        }

        protected void ClearText()
        {
            tbCitizenID.Text = "";
            lblCitizenID.Text = "";
            lblName.Text = "";
            lblLastName.Text = "";
            lblStafftype.Text = "";
            lblCampus.Text = "";
            lblPosition.Text = "";
            lblStatusPersonWork.Text = "";

            ddlDegree10.SelectedIndex = 0;
            tbUnivName10.Text = "";
            ddlMonth10From.SelectedIndex = 0;
            ddlYear10From.SelectedIndex = 0;
            ddlMonth10To.SelectedIndex = 0;
            ddlYear10To.SelectedIndex = 0;
            tbQualification10.Text = "";
            tbMajor10.Text = "";
            ddlCountrySuccess10.SelectedIndex = 0;

            tbLicenseName11.Text = "";
            tbDepartment11.Text = "";
            tbLicenseNo11.Text = "";
            tbUseDate11.Text = "";

            tbCourse.Text = "";
            ddlMonth12From.SelectedIndex = 0;
            ddlYear12From.SelectedIndex = 0;
            ddlMonth12To.SelectedIndex = 0;
            ddlYear12To.SelectedIndex = 0;
            tbDepartment.Text = "";

            ddlYear13.SelectedIndex = 0;
            tbName13.Text = "";
            tbREF13.Text = "";

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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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

            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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

            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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

            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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

            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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

            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            if (string.IsNullOrEmpty(tbCitizenID.Text))
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
            else
            {
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
                else
                {
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
                else
                {
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
                else
                {
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

        protected void lbuV1Add_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(tbCitizenID.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
                }
                if (tbCitizenID.Text.Length <= 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                }
                else
                {
                    PS_STUDY PStudy = new PS_STUDY();
                    PStudy.PS_CITIZEN_ID = lblCitizenID.Text;
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
                    DataTable dt1 = PStudy.SELECT_PS_STUDY(lblCitizenID.Text, "", "", "", "", "", "", "", "", "");
                    GridViewStudy.DataSource = dt1;
                    GridViewStudy.DataBind();
                    SetViewState(dt1);
                }

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV2Add_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(tbCitizenID.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
                }
                if (tbCitizenID.Text.Length <= 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                }
                else
                {
                    PS_PROFESSIONAL_LICENSE PLicense = new PS_PROFESSIONAL_LICENSE();
                    PLicense.PS_CITIZEN_ID = lblCitizenID.Text;
                    PLicense.PS_LICENSE_NAME = tbLicenseName11.Text;
                    PLicense.PS_DEPARTMENT = tbDepartment11.Text;
                    PLicense.PS_LICENSE_NO = tbLicenseNo11.Text;
                    PLicense.PS_USE_DATE = Util.ODT(tbUseDate11.Text);
                    PLicense.INSERT_PS_PROFESSIONAL_LICENSE();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลใบอนุญาตประกอบวิชาชีพ เรียบร้อย')", true);
                    ClearPLicense11();
                    DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(tbCitizenID.Text, "", "", "", "");
                    GridViewLicense.DataSource = dt2;
                    GridViewLicense.DataBind();
                    SetViewState(dt2);
                }

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV3Add_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(tbCitizenID.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
                }
                if (tbCitizenID.Text.Length <= 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                }
                else
                {
                    PS_TRAINING PTraining = new PS_TRAINING();
                    PTraining.PS_CITIZEN_ID = lblCitizenID.Text;
                    PTraining.PS_COURSE = tbCourse.Text;
                    PTraining.PS_FROM_MONTH = Convert.ToInt32(ddlMonth12From.SelectedValue);
                    PTraining.PS_FROM_YEAR = Convert.ToInt32(ddlYear12From.SelectedValue);
                    PTraining.PS_TO_MONTH = Convert.ToInt32(ddlMonth12To.SelectedValue);
                    PTraining.PS_TO_YEAR = Convert.ToInt32(ddlYear12To.SelectedValue);
                    PTraining.PS_DEPARTMENT = tbDepartment.Text;
                    PTraining.INSERT_PS_TRAINING();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลประวัติการศึกษา เรียบร้อย')", true);
                    ClearPTraining12();
                    DataTable dt3 = PTraining.SELECT_PS_TRAINING(tbCitizenID.Text, "", "", "", "", "", "");
                    GridViewTraining.DataSource = dt3;
                    GridViewTraining.DataBind();
                    SetViewState(dt3);
                }

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV4Add_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(tbCitizenID.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
                }
                if (tbCitizenID.Text.Length <= 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                }
                else
                {
                    PS_DISCIPLINARY_AND_AMNESTY PDAA = new PS_DISCIPLINARY_AND_AMNESTY();
                    PDAA.PS_CITIZEN_ID = lblCitizenID.Text;
                    PDAA.PS_YEAR = Convert.ToInt32(ddlYear13.SelectedValue);
                    PDAA.PS_DAA_NAME = tbName13.Text;
                    PDAA.PS_REF = tbREF13.Text;
                    PDAA.INSERT_PS_DISCIPLINARY_AND_AMNESTY();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม เรียบร้อย')", true);
                    ClearPDAA13();
                    DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(tbCitizenID.Text, "", "", "");
                    GridViewDAA.DataSource = dt4;
                    GridViewDAA.DataBind();
                    SetViewState(dt4);
                }

                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void lbuV5Add_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(tbCitizenID.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
                }
                if (tbCitizenID.Text.Length <= 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
                }
                else
                {
                    PS_POSITION_AND_SALARY PPAS = new PS_POSITION_AND_SALARY();
                    PPAS.PS_CITIZEN_ID = lblCitizenID.Text;
                    PPAS.PS_DATE = Util.ODT(tbDate14.Text);
                    PPAS.PS_POSITION = tbPosition14.Text;
                    PPAS.PS_POSITION_NO = tbPositionNo14.Text;
                    PPAS.PS_POSITION_TYPE = ddlPositionType14.SelectedValue;
                    PPAS.PS_POSITION_DEGREE = ddlPositionDegree14.SelectedValue;
                    PPAS.PS_SALARY = Convert.ToInt32(tbSalary14.Text);
                    PPAS.PS_SALARY_POSITION = Convert.ToInt32(tbSalaryPosition14.Text);
                    PPAS.PS_REF = tbRef14.Text;
                    PPAS.INSERT_PS_POSITION_AND_SALARY();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลการได้รับโทษทางวินัยและการนิรโทษกรรม เรียบร้อย')", true);
                    ClearPPAS14();
                    DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(tbCitizenID.Text, "", "", "", "", "", "", "", "");
                    GridViewPAS.DataSource = dt5;
                    GridViewPAS.DataBind();
                    SetViewState(dt5);
                }
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            if (string.IsNullOrEmpty(tbCitizenID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชน')", true);
            }
            if (tbCitizenID.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกรหัสบัตรประชาชนให้ครบ 13 หลัก')", true);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID รหัสบัตรประชาชน, PS_FN_TH, PS_LN_TH, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE PS_PERSON.PS_STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID) ประเภทบุคลากร, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE PS_PERSON.PS_CAMPUS_ID = TB_CAMPUS.CAMPUS_ID) || ' > ' || (SELECT FACULTY_NAME FROM TB_FACULTY WHERE PS_PERSON.PS_FACULTY_ID = TB_FACULTY.FACULTY_ID) || ' > ' || (SELECT DIVISION_NAME FROM TB_DIVISION WHERE PS_PERSON.PS_DIVISION_ID = TB_DIVISION.DIVISION_ID) || ' > ' || (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE PS_PERSON.PS_WORK_DIVISION_ID = TB_WORK_DIVISION.WORK_ID) \"งาน / ฝ่าย\", (SELECT NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) ตำแหน่ง, (SELECT SW_NAME FROM TB_STATUS_WORK WHERE PS_PERSON.PS_SW_ID = TB_STATUS_WORK.SW_ID) สถานะการทำงาน FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + tbCitizenID.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lblCitizenID.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            lblName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            lblLastName.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            lblStafftype.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            lblCampus.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            lblPosition.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            lblStatusPersonWork.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);

                            //view1
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
                                DataTable dt1 = PStudy.SELECT_PS_STUDY(tbCitizenID.Text, "", "", "", "", "", "", "", "", "");
                                GridViewStudy.DataSource = dt1;
                                GridViewStudy.DataBind();
                                SetViewState(dt1);
                            }
                            //view2
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
                                DataTable dt2 = PLicense.SELECT_PS_PROFESSIONAL_LICENSE(tbCitizenID.Text, "", "", "", "");
                                GridViewLicense.DataSource = dt2;
                                GridViewLicense.DataBind();
                                SetViewState(dt2);
                            }
                            //view3
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
                                DataTable dt3 = PTraining.SELECT_PS_TRAINING(tbCitizenID.Text, "", "", "", "", "", "");
                                GridViewTraining.DataSource = dt3;
                                GridViewTraining.DataBind();
                                SetViewState(dt3);
                            }
                            //view4
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
                                DataTable dt4 = PDAA.SELECT_PS_DISCIPLINARY_AND_AMNESTY(tbCitizenID.Text, "", "", "");
                                GridViewDAA.DataSource = dt4;
                                GridViewDAA.DataBind();
                                SetViewState(dt4);
                            }
                            //view5
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
                                DataTable dt5 = PPAS.SELECT_PS_POSITION_AND_SALARY(tbCitizenID.Text, "", "", "", "", "", "", "", "");
                                GridViewPAS.DataSource = dt5;
                                GridViewPAS.DataBind();
                                SetViewState(dt5);
                            }

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
    }

}