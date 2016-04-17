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
    public partial class StaffType_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchStaffTypeID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertStaffTypeID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["STAFFTYPE"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["STAFFTYPE"] = data;
        }

        #endregion

        void BindData()
        {
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffType("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffTypeSearch(txtSearchStaffTypeID.Text, txtSearchStaffTypeName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchStaffTypeID.Text = "";
            txtSearchStaffTypeName.Text = "";
            txtInsertStaffTypeID.Text = "";
            txtInsertStaffTypeName.Text = "";
        }

        protected void btnSubmitStaffType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertStaffTypeID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเภทข้าราชการ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertStaffTypeName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อประเภทข้าราชการ')", true);
                return;
            }
            ClassStaffType s = new ClassStaffType();
            s.STAFFTYPE_ID = Convert.ToInt32(txtInsertStaffTypeID.Text);
            s.STAFFTYPE_NAME = txtInsertStaffTypeName.Text;

            if (s.CheckUseStaffTypeID())
            {
                s.InsertStaffType();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสประเภทข้าราชการนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassStaffType s = new ClassStaffType();
            s.STAFFTYPE_ID = id;
            s.DeleteStaffType();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtStaffTypeIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffTypeIDEdit");
            TextBox txtStaffTypeNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffTypeNameEdit");

            ClassStaffType s = new ClassStaffType(Convert.ToInt32(txtStaffTypeIDEdit.Text)
                , txtStaffTypeNameEdit.Text);

            s.UpdateStaffType();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อประเภทข้าราชการ " + DataBinder.Eval(e.Row.DataItem, "STAFFTYPE_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtStaffTypeIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewSTAFFTYPE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelStaffType_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffType("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchStaffType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchStaffTypeID.Text) && string.IsNullOrEmpty(txtSearchStaffTypeName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassStaffType s = new ClassStaffType();
                DataTable dt = s.GetStaffTypeSearch(txtSearchStaffTypeID.Text, txtSearchStaffTypeName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffType("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}