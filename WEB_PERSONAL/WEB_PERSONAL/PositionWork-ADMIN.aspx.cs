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
    public partial class PositionWork_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchPositionWorkID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertPositionWorkID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["POSITION_WORK"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["POSITION_WORK"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionWork pw = new ClassPositionWork();
            DataTable dt = pw.GetPositionWork("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassPositionWork pw = new ClassPositionWork();
            DataTable dt = pw.GetPositionWorkSearch(txtSearchPositionWorkID.Text, txtSearchPositionWorkName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchPositionWorkID.Text = "";
            txtSearchPositionWorkName.Text = "";
            txtInsertPositionWorkID.Text = "";
            txtInsertPositionWorkName.Text = "";
        }

        protected void btnSubmitPositionWork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertPositionWorkID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสตำแหน่งในสายงาน')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertPositionWorkName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำแหน่งในสายงาน')", true);
                return;
            }
            ClassPositionWork pw = new ClassPositionWork();
            pw.POSITION_WORK_ID = txtInsertPositionWorkID.Text;
            pw.POSITION_WORK_NAME = txtInsertPositionWorkName.Text;

            if (pw.CheckUsePositionWorkID())
            {
                pw.InsertPositionWork();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสตำแหน่งในสายงานนี้ อยู่ในระบบแล้ว !')", true);
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
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            ClassPositionWork pw = new ClassPositionWork();
            pw.POSITION_WORK_ID = id;
            pw.DeletePositionWork();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtPositionWorkIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPositionWorkIDEdit");
            TextBox txtPositionWorkNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPositionWorkNameEdit");

            ClassPositionWork pw = new ClassPositionWork(txtPositionWorkIDEdit.Text, txtPositionWorkNameEdit.Text);

            pw.UpdatePositionWork();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำแหน่งในสายงาน " + DataBinder.Eval(e.Row.DataItem, "POSITION_WORK_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtPositionWorkIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewPositionWork_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPositionWork_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionWork pw = new ClassPositionWork();
            DataTable dt = pw.GetPositionWork("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPositionWork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPositionWorkID.Text) && string.IsNullOrEmpty(txtSearchPositionWorkName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassPositionWork pw = new ClassPositionWork();
                DataTable dt = pw.GetPositionWorkSearch(txtSearchPositionWorkID.Text, txtSearchPositionWorkName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionWork pw = new ClassPositionWork();
            DataTable dt = pw.GetPositionWork("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}