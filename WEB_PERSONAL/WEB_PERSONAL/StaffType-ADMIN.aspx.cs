﻿using WEB_PERSONAL.Entities;
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
                txtInsertStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
            DataTable dt = s.GetStaffType(0,"");
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเภทของบุคลากร')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertStaffName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อประเภทของบุคลากร')", true);
                return;
            }
            ClassStaffType s = new ClassStaffType();
            s.STAFFTYPE_ID = Convert.ToInt32(txtInsertStaffID.Text);
            s.STAFFTYPE_NAME = txtInsertStaffName.Text;

            if (s.CheckUseStaffTypeID())
            {
                s.InsertStaffType();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสประเภทของบุคลากรนี้ อยู่ในระบบแล้ว !')", true);
            }
        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassStaffType s = new ClassStaffType();
            s.STAFFTYPE_ID = id;
            s.DeleteStaffType();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtStaffIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffIDEdit");
            TextBox txtStaffNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStaffNameEdit");

            ClassStaffType s = new ClassStaffType(Convert.ToInt32(txtStaffIDEdit.Text)
                , txtStaffNameEdit.Text);

            s.UpdateStaffType();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtStaffIDEdit");
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

        protected void btnCancelStaff_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffType(0,"");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchStaff_Click(object sender, EventArgs e)
        {
            ClassStaffType s = new ClassStaffType();
            DataTable dt = s.GetStaffTypeSearch(Convert.ToInt32(txtSearchStaffID.Text), txtSearchStaffName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}