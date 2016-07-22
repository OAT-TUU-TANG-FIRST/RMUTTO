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
    public partial class GradLev_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["GRADLEV"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GRADLEV"] = data;
        }

        #endregion

        void BindData()
        {
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev(txtSearchGradLevName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchGradLevName.Text = "";
            txtInsertGradLevName.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGradLevName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับการศึกษา')", true);
                return;
            }
            ClassGradLev gl = new ClassGradLev();
            gl.GRAD_LEV_NAME = txtInsertGradLevName.Text;

            if (gl.CheckUseGradLevName())
            {
                gl.InsertGradLev();
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
            ClassGradLev gl = new ClassGradLev();
            gl.GRAD_LEV_ID = id;
            gl.DeleteGradLev();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblGradLevIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGradLevIDEdit");
            TextBox txtGradLevNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradLevNameEdit");

            ClassGradLev gl = new ClassGradLev(lblGradLevIDEdit.Text
                , txtGradLevNameEdit.Text);

            if (gl.CheckUseGradLevName())
            {
                gl.UpdateGradLev();
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
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับการศึกษา " + DataBinder.Eval(e.Row.DataItem, "GRAD_LEV_NAME") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewGradLev_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchGradLevName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassGradLev gl = new ClassGradLev();
                DataTable dt = gl.GetGradLev(txtSearchGradLevName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}