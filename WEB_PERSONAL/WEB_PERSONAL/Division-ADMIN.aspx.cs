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
    public partial class Division_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertDivisionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchFacultyID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertFacultyID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["DIVISION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["DIVISION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivisionSearch(txtSearchDivisionID.Text, txtSearchDivisionName.Text, txtSearchCampusID.Text, txtSearchFacultyID.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchDivisionID.Text = "";
            txtSearchDivisionName.Text = "";
            txtSearchCampusID.Text = "";
            txtSearchFacultyID.Text = "";
            txtInsertDivisionID.Text = "";
            txtInsertDivisionName.Text = "";
            txtInsertCampusID.Text = "";
            txtInsertFacultyID.Text = "";
        }

        protected void btnSubmitDivision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertDivisionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสกอง / สำนักงานเลขา / ภาควิชา')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertDivisionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกอง / สำนักงานเลขา / ภาควิชา')", true);
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
            ClassDivision d = new ClassDivision();
            d.DIVISION_ID = Convert.ToInt32(txtInsertDivisionID.Text);
            d.DIVISION_NAME = txtInsertDivisionName.Text;
            d.CAMPUS_ID = Convert.ToInt32(txtInsertCampusID.Text);
            d.FACULTY_ID = Convert.ToInt32(txtInsertFacultyID.Text);

            if (d.CheckUseDivisionID())
            {
                d.InsertDivision();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสกอง / สำนักงานเลขา / ภาควิชา นี้อยู่ในระบบแล้ว !')", true);
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
            ClassDivision d = new ClassDivision();
            d.DIVISION_ID = id;
            d.DeleteDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtDivisionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDivisionIDEdit");
            TextBox txtDivisionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDivisionNameEdit");
            TextBox txtCampusIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCampusIDEdit");
            TextBox txtFacultyIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtFacultyIDEdit");

            ClassDivision d = new ClassDivision(Convert.ToInt32(txtDivisionIDEdit.Text)
                , txtDivisionNameEdit.Text
                , Convert.ToInt32(txtCampusIDEdit.Text)
                , Convert.ToInt32(txtFacultyIDEdit.Text));

            d.UpdateDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อกอง / สำนักงานเลขา / ภาควิชา " + DataBinder.Eval(e.Row.DataItem, "DIVISION_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt1 = (TextBox)e.Row.FindControl("txtDivisionIDEdit");
                    txt1.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtCampusIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt3 = (TextBox)e.Row.FindControl("txtFacultyIDEdit");
                    txt3.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelDivision_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchDivision_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchDivisionID.Text) && string.IsNullOrEmpty(txtSearchDivisionName.Text) && string.IsNullOrEmpty(txtSearchCampusID.Text) && string.IsNullOrEmpty(txtSearchFacultyID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassDivision d = new ClassDivision();
                DataTable dt = d.GetDivisionSearch(txtSearchDivisionID.Text, txtSearchDivisionName.Text, txtSearchCampusID.Text, txtSearchFacultyID.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
