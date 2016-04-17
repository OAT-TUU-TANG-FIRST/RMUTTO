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
    public partial class Staff_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["STAFF"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["STAFF"] = data;
        }

        #endregion

        void BindData()
        {
            ClassStaff s = new ClassStaff();
            DataTable dt = s.GetStaff("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassStaff s = new ClassStaff();
            DataTable dt = s.GetStaffSearch(txtSearchStaffID.Text, txtSearchStaffName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchStaffID.Text = "";
            txtSearchStaffName.Text = "";
            txtInsertStaffID.Text = "";
            txtInsertStaffName.Text = "";
        }

        protected void btnSubmitStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertStaffID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสตำแหน่งประเภท')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertStaffName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำแหน่งประเภท')", true);
                return;
            }
            ClassStaff s = new ClassStaff();
            s.ST_ID = Convert.ToInt32(txtInsertStaffID.Text);
            s.ST_NAME = txtInsertStaffName.Text;

            if (s.CheckUseStaffID())
            {
                s.InsertStaff();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสตำแหน่งประเภทนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassStaff s = new ClassStaff();
            s.ST_ID = id;
            s.DeleteStaff();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtStaffIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffIDEdit");
            TextBox txtStaffNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffNameEdit");

            ClassStaff s = new ClassStaff(Convert.ToInt32(txtStaffIDEdit.Text)
                , txtStaffNameEdit.Text);

            s.UpdateStaff();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำแหน่งประเภท " + DataBinder.Eval(e.Row.DataItem, "ST_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtStaffIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewSTAFF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelStaff_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStaff s = new ClassStaff();
            DataTable dt = s.GetStaff("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchStaffID.Text) && string.IsNullOrEmpty(txtSearchStaffName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassStaff s = new ClassStaff();
                DataTable dt = s.GetStaffSearch(txtSearchStaffID.Text, txtSearchStaffName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStaff s = new ClassStaff();
            DataTable dt = s.GetStaff("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}