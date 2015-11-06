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
    public partial class SubStaffType_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["SUBSTAFFTYPE_NAME"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["SUBSTAFFTYPE_NAME"] = data;
        }

        #endregion

        void BindData()
        {
            ClassSubStaffType sst = new ClassSubStaffType();
            DataTable dt = sst.GetSubStaffType("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchSubStaffTypeName.Text = "";
            txtInsertSubStaffTypeName.Text = "";
        }

        protected void btnSubmitSubStaffType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertSubStaffTypeName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ประเภทบุคลากรย่อย')", true);
                return;
            }
            ClassSubStaffType sst = new ClassSubStaffType();
            sst.SUBSTAFFTYPE_NAME = txtInsertSubStaffTypeName.Text;

            sst.InsertSubStaffType();
            BindData();
            ClearData();
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
            ClassSubStaffType sst = new ClassSubStaffType();
            sst.SUBSTAFFTYPE_ID = id;
            sst.DeleteSubStaffType();

            GridView1.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblSubStaffTypeID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSubStaffTypeID");

            TextBox txtSubStaffTypeNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSubStaffTypeNameEdit");

            ClassSubStaffType sst = new ClassSubStaffType(Convert.ToInt32(lblSubStaffTypeID.Text)
                , txtSubStaffTypeNameEdit.Text);

            sst.UpdateSubStaffType();

            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void myGridViewSubStaffType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelSubStaffType_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassSubStaffType sst = new ClassSubStaffType();
            DataTable dt = sst.GetSubStaffType("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void SearchSubStaffType_Click(object sender, EventArgs e)
        {
            ClassSubStaffType sst = new ClassSubStaffType();
            DataTable dt = sst.GetSubStaffType(txtSearchSubStaffTypeName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}