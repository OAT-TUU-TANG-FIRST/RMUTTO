using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class WorkDivision_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchCampus();
                ddlShowInsertCampus();
                ddlShowSearchFaculty();
                ddlShowInsertFaculty();
                ddlShowSearchDivision();
                ddlShowInsertDivision();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["WORKDIVISION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["WORKDIVISION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassWorkDivision wd = new ClassWorkDivision();
            DataTable dt = wd.GetWorkDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchWorkDivisionName.Text))
            {
                ClassWorkDivision wd1 = new ClassWorkDivision();
                DataTable dt1 = wd1.GetWorkDivision(txtSearchWorkDivisionName.Text, "", "", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (ddlSearchCampus.SelectedIndex != 0)
            {
                ClassWorkDivision wd2 = new ClassWorkDivision();
                DataTable dt2 = wd2.GetWorkDivision("", ddlSearchCampus.SelectedValue, "", "");
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
            if (ddlSearchFaculty.SelectedIndex != 0)
            {
                ClassWorkDivision wd3 = new ClassWorkDivision();
                DataTable dt3 = wd3.GetWorkDivision("", "", ddlSearchFaculty.SelectedValue, "");
                GridView1.DataSource = dt3;
                GridView1.DataBind();
                SetViewState(dt3);
            }
            if (ddlSearchDivision.SelectedIndex != 0)
            {
                ClassWorkDivision wd4 = new ClassWorkDivision();
                DataTable dt4 = wd4.GetWorkDivision("", "", "", ddlSearchDivision.SelectedValue);
                GridView1.DataSource = dt4;
                GridView1.DataBind();
                SetViewState(dt4);
            }
        }

        private void ddlShowSearchCampus()
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
                        ddlSearchCampus.DataSource = dt;
                        ddlSearchCampus.DataValueField = "CAMPUS_ID";
                        ddlSearchCampus.DataTextField = "CAMPUS_NAME";
                        ddlSearchCampus.DataBind();
                        sqlConn.Close();

                        ddlSearchCampus.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertCampus()
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
                        ddlInsertCampus.DataSource = dt;
                        ddlInsertCampus.DataValueField = "CAMPUS_ID";
                        ddlInsertCampus.DataTextField = "CAMPUS_NAME";
                        ddlInsertCampus.DataBind();
                        sqlConn.Close();

                        ddlInsertCampus.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowSearchFaculty()
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
                        ddlSearchFaculty.DataSource = dt;
                        ddlSearchFaculty.DataValueField = "FACULTY_ID";
                        ddlSearchFaculty.DataTextField = "FACULTY_NAME";
                        ddlSearchFaculty.DataBind();
                        sqlConn.Close();

                        ddlSearchFaculty.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertFaculty()
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
                        ddlInsertFaculty.DataSource = dt;
                        ddlInsertFaculty.DataValueField = "FACULTY_ID";
                        ddlInsertFaculty.DataTextField = "FACULTY_NAME";
                        ddlInsertFaculty.DataBind();
                        sqlConn.Close();

                        ddlInsertFaculty.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowSearchDivision()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DIVISION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchDivision.DataSource = dt;
                        ddlSearchDivision.DataValueField = "DIVISION_ID";
                        ddlSearchDivision.DataTextField = "DIVISION_NAME";
                        ddlSearchDivision.DataBind();
                        sqlConn.Close();

                        ddlSearchDivision.Items.Insert(0, new ListItem("--กอง / สำนักงานเลขา / ภาควิชา--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertDivision()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_DIVISION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertDivision.DataSource = dt;
                        ddlInsertDivision.DataValueField = "DIVISION_ID";
                        ddlInsertDivision.DataTextField = "DIVISION_NAME";
                        ddlInsertDivision.DataBind();
                        sqlConn.Close();

                        ddlInsertDivision.Items.Insert(0, new ListItem("--กอง / สำนักงานเลขา / ภาควิชา--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchWorkDivisionName.Text = "";
            ddlSearchCampus.SelectedIndex = 0;
            ddlSearchFaculty.SelectedIndex = 0;
            ddlSearchDivision.SelectedIndex = 0;
            txtInsertWorkDivisionName.Text = "";
            ddlInsertCampus.SelectedIndex = 0;
            ddlInsertFaculty.SelectedIndex = 0;
            ddlInsertDivision.SelectedIndex = 0;
        }

        protected void btnSubmitWorkDivision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertWorkDivisionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่องาน / ฝ่าย')", true);
                return;
            }
            if (ddlInsertCampus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก วิทยาเขต')", true);
                return;
            }
            if (ddlInsertFaculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก สำนัก / สถาบัน / คณะ')", true);
                return;
            }
            if (ddlInsertDivision.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก กอง / สำนักงานเลขา / ภาควิชา')", true);
                return;
            }
            ClassWorkDivision wd = new ClassWorkDivision();
            wd.WORK_NAME = txtInsertWorkDivisionName.Text;
            wd.CAMPUS_ID = Convert.ToInt32(ddlInsertCampus.SelectedValue);
            wd.FACULTY_ID = Convert.ToInt32(ddlInsertFaculty.SelectedValue);
            wd.DIVISION_ID = Convert.ToInt32(ddlInsertDivision.SelectedValue);

            if (wd.CheckUseWorkDivisionName())
            {
                wd.InsertWorkDivision();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะเพิ่ม มีอยู่ในระบบแล้ว !')", true);
            }
        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            if (txtSearchWorkDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0 || ddlSearchDivision.SelectedIndex != 0)
            {
                GridView1.EditIndex = e.NewEditIndex; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = e.NewEditIndex; ;
                BindData();
            }
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            if (txtSearchWorkDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0 || ddlSearchDivision.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1; ;
                BindData();
            }
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassWorkDivision wd = new ClassWorkDivision();
            wd.WORK_ID = id;
            wd.DeleteWorkDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchWorkDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0 || ddlSearchDivision.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1; ;
                BindData();
            }
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblWorkDivisionIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblWorkDivisionIDEdit");
            TextBox txtWorkDivisionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtWorkDivisionNameEdit");
            DropDownList ddlCampusIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCampusIDEdit");
            DropDownList ddlFacultyIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlFacultyIDEdit");
            DropDownList ddlDivisionIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlDivisionIDEdit");

            ClassWorkDivision wd = new ClassWorkDivision(Convert.ToInt32(lblWorkDivisionIDEdit.Text)
                , txtWorkDivisionNameEdit.Text
                , Convert.ToInt32(ddlCampusIDEdit.SelectedValue)
                , Convert.ToInt32(ddlFacultyIDEdit.SelectedValue)
                , Convert.ToInt32(ddlDivisionIDEdit.SelectedValue));

            if (wd.CheckUseWorkDivisionName())
            {
                wd.UpdateWorkDivision();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                GridView1.EditIndex = -1;
                BindData1();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะอัพเดท มีอยู่ในระบบแล้ว !')", true);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่องาน / ฝ่าย " + DataBinder.Eval(e.Row.DataItem, "WORK_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlCampusIDEdit = (DropDownList)e.Row.FindControl("ddlCampusIDEdit");

                            sqlCmd1.CommandText = "select * from TB_CAMPUS";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlCampusIDEdit.DataSource = dt;
                            ddlCampusIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "CAMPUS_ID").ToString();
                            ddlCampusIDEdit.DataValueField = "CAMPUS_ID";
                            ddlCampusIDEdit.DataTextField = "CAMPUS_NAME";
                            ddlCampusIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlCampusIDEdit.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd2 = new OracleCommand())
                        {
                            DropDownList ddlFacultyIDEdit = (DropDownList)e.Row.FindControl("ddlFacultyIDEdit");

                            sqlCmd2.CommandText = "select * from TB_FACULTY";
                            sqlCmd2.Connection = sqlConn2;
                            sqlConn2.Open();
                            OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                            DataTable dt = new DataTable();
                            da2.Fill(dt);
                            ddlFacultyIDEdit.DataSource = dt;
                            ddlFacultyIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "FACULTY_ID").ToString();
                            ddlFacultyIDEdit.DataValueField = "FACULTY_ID";
                            ddlFacultyIDEdit.DataTextField = "FACULTY_NAME";
                            ddlFacultyIDEdit.DataBind();
                            sqlConn2.Close();

                            ddlFacultyIDEdit.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));
                            DataRowView dr2 = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn3 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd3 = new OracleCommand())
                        {
                            DropDownList ddlDivisionIDEdit = (DropDownList)e.Row.FindControl("ddlDivisionIDEdit");

                            sqlCmd3.CommandText = "select * from TB_DIVISION";
                            sqlCmd3.Connection = sqlConn3;
                            sqlConn3.Open();
                            OracleDataAdapter da3 = new OracleDataAdapter(sqlCmd3);
                            DataTable dt = new DataTable();
                            da3.Fill(dt);
                            ddlDivisionIDEdit.DataSource = dt;
                            ddlDivisionIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "DIVISION_ID").ToString();
                            ddlDivisionIDEdit.DataValueField = "DIVISION_ID";
                            ddlDivisionIDEdit.DataTextField = "DIVISION_NAME";
                            ddlDivisionIDEdit.DataBind();
                            sqlConn3.Close();

                            ddlDivisionIDEdit.Items.Insert(0, new ListItem("--กอง / สำนักงานเลขา / ภาควิชา--", "0"));
                            DataRowView dr3 = e.Row.DataItem as DataRowView;
                        }
                    }
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
        protected void myGridViewWorkDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelWorkDivision_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassWorkDivision wd = new ClassWorkDivision();
            DataTable dt = wd.GetWorkDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchWorkDivision_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchWorkDivisionName.Text) && ddlSearchCampus.SelectedIndex == 0 && ddlSearchFaculty.SelectedIndex == 0 && ddlSearchDivision.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchWorkDivisionName.Text))
                {
                    ClassWorkDivision wd1 = new ClassWorkDivision();
                    DataTable dt1 = wd1.GetWorkDivision(txtSearchWorkDivisionName.Text, "", "", "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (ddlSearchCampus.SelectedIndex != 0)
                {
                    ClassWorkDivision wd2 = new ClassWorkDivision();
                    DataTable dt2 = wd2.GetWorkDivision("", ddlSearchCampus.SelectedValue, "", "");
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
                if (ddlSearchFaculty.SelectedIndex != 0)
                {
                    ClassWorkDivision wd3 = new ClassWorkDivision();
                    DataTable dt3 = wd3.GetWorkDivision("", "", ddlSearchFaculty.SelectedValue, "");
                    GridView1.DataSource = dt3;
                    GridView1.DataBind();
                    SetViewState(dt3);
                }
                if (ddlSearchDivision.SelectedIndex != 0)
                {
                    ClassWorkDivision wd4 = new ClassWorkDivision();
                    DataTable dt4 = wd4.GetWorkDivision("", "", "", ddlSearchDivision.SelectedValue);
                    GridView1.DataSource = dt4;
                    GridView1.DataBind();
                    SetViewState(dt4);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassWorkDivision wd = new ClassWorkDivision();
            DataTable dt = wd.GetWorkDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}