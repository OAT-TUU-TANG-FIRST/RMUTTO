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
    public partial class AdminPosition_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchAdminPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertAdminPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["ADMIN_POSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["ADMIN_POSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassAdminPosition ap = new ClassAdminPosition();
            DataTable dt = ap.GetAdminPosition("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassAdminPosition ap = new ClassAdminPosition();
            DataTable dt = ap.GetAdminPositionSearch(txtSearchAdminPositionID.Text, txtSearchAdminPositionName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchAdminPositionID.Text = "";
            txtSearchAdminPositionName.Text = "";
            txtInsertAdminPositionID.Text = "";
            txtInsertAdminPositionName.Text = "";
        }

        protected void btnSubmitAdminPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertAdminPositionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสตำแหน่งทางบริหาร')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertAdminPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำแหน่งทางบริหาร')", true);
                return;
            }
            ClassAdminPosition ap = new ClassAdminPosition();
            ap.ADMIN_POSITION_ID = Convert.ToInt32(txtInsertAdminPositionID.Text);
            ap.ADMIN_POSITION_NAME = txtInsertAdminPositionName.Text;

            if (ap.CheckUseAdminPositionID())
            {
                ap.InsertAdminPosition();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสตำแหน่งทางบริหารนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassAdminPosition ap = new ClassAdminPosition();
            ap.ADMIN_POSITION_ID = id;
            ap.DeleteAdminPosition();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtAdminPositionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdminPositionIDEdit");
            TextBox txtAdminPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdminPositionNameEdit");

            ClassAdminPosition ap = new ClassAdminPosition(Convert.ToInt32(txtAdminPositionIDEdit.Text), txtAdminPositionNameEdit.Text);

            ap.UpdateAdminPosition();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำแหน่งทางบริหาร " + DataBinder.Eval(e.Row.DataItem, "ADMIN_POSITION_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtAdminPositionIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewAdminPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelAdminPosition_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAdminPosition ap = new ClassAdminPosition();
            DataTable dt = ap.GetAdminPosition("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchAdminPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchAdminPositionID.Text) && string.IsNullOrEmpty(txtSearchAdminPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassAdminPosition ap = new ClassAdminPosition();
                DataTable dt = ap.GetAdminPositionSearch(txtSearchAdminPositionID.Text, txtSearchAdminPositionName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAdminPosition ap = new ClassAdminPosition();
            DataTable dt = ap.GetAdminPosition("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}