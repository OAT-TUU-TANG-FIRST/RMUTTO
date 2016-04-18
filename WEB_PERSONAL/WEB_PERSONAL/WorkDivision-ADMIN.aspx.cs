using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WEB_PERSONAL
{
    public partial class WorkDivision_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchWorkDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertWorkDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchFacultyID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertFacultyID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
            DataTable dt = wd.GetWorkDivision("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassWorkDivision wd = new ClassWorkDivision();
            DataTable dt = wd.GetWorkDivisionSearch(txtSearchWorkDivisionID.Text, txtSearchWorkDivisionName.Text, txtSearchCampusID.Text, txtSearchFacultyID.Text, txtSearchDivisionID.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchWorkDivisionID.Text = "";
            txtSearchWorkDivisionName.Text = "";
            txtSearchCampusID.Text = "";
            txtSearchFacultyID.Text = "";
            txtSearchDivisionID.Text = "";
            txtInsertWorkDivisionID.Text = "";
            txtInsertWorkDivisionName.Text = "";
            txtInsertCampusID.Text = "";
            txtInsertFacultyID.Text = "";
            txtInsertDivisionID.Text = "";
        }

        protected void btnSubmitWorkDivision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertWorkDivisionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสงาน / ฝ่าย')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertWorkDivisionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่องาน / ฝ่าย')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertCampusID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสวิทยาเขต')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertFacultyID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสสำนัก / สถาบัน / คณะ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertDivisionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสกอง / สำนักงานเลขา / ภาควิชา')", true);
                return;
            }
            ClassWorkDivision wd = new ClassWorkDivision();
            wd.WORK_ID = Convert.ToInt32(txtInsertWorkDivisionID.Text);
            wd.WORK_NAME = txtInsertWorkDivisionName.Text;
            wd.CAMPUS_ID = Convert.ToInt32(txtInsertCampusID.Text);
            wd.FACULTY_ID = Convert.ToInt32(txtInsertFacultyID.Text);
            wd.DIVISION_ID = Convert.ToInt32(txtInsertDivisionID.Text);

            if (wd.CheckUseWorkDivisionID())
            {
                wd.InsertWorkDivision();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสงาน / ฝ่าย นี้อยู่ในระบบแล้ว !')", true);
            }
        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData1();
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassWorkDivision wd = new ClassWorkDivision();
            wd.WORK_ID = id;
            wd.DeleteWorkDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtWorkDivisionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtWorkDivisionIDEdit");
            TextBox txtWorkDivisionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtWorkDivisionNameEdit");
            TextBox txtCampusIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCampusIDEdit");
            TextBox txtFacultyIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtFacultyIDEdit");
            TextBox txtDivisionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDivisionIDEdit");

            ClassWorkDivision wd = new ClassWorkDivision(Convert.ToInt32(txtWorkDivisionIDEdit.Text)
                , txtWorkDivisionNameEdit.Text
                , Convert.ToInt32(txtCampusIDEdit.Text)
                , Convert.ToInt32(txtFacultyIDEdit.Text)
                , Convert.ToInt32(txtDivisionIDEdit.Text));

            wd.UpdateWorkDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่องาน / ฝ่าย " + DataBinder.Eval(e.Row.DataItem, "WORK_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt1 = (TextBox)e.Row.FindControl("txtWorkDivisionIDEdit");
                    txt1.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtCampusIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt3 = (TextBox)e.Row.FindControl("txtFacultyIDEdit");
                    txt3.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt4 = (TextBox)e.Row.FindControl("txtDivisionIDEdit");
                    txt4.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
            DataTable dt = wd.GetWorkDivision("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchWorkDivision_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchWorkDivisionID.Text) && string.IsNullOrEmpty(txtSearchWorkDivisionName.Text) && string.IsNullOrEmpty(txtSearchCampusID.Text) && string.IsNullOrEmpty(txtSearchFacultyID.Text) && string.IsNullOrEmpty(txtSearchDivisionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassWorkDivision wd = new ClassWorkDivision();
                DataTable dt = wd.GetWorkDivisionSearch(txtSearchWorkDivisionID.Text, txtSearchWorkDivisionName.Text, txtSearchCampusID.Text, txtSearchFacultyID.Text, txtSearchDivisionID.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassWorkDivision wd = new ClassWorkDivision();
            DataTable dt = wd.GetWorkDivision("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}