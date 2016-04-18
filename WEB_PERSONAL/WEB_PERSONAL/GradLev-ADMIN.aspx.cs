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
                txtSearchGradLevID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertGradLevID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
            DataTable dt = gl.GetGradLev("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLevSearch(txtSearchGradLevID.Text, txtSearchGradLevName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchGradLevID.Text = "";
            txtSearchGradLevName.Text = "";
            txtInsertGradLevID.Text = "";
            txtInsertGradLevName.Text = "";
        }

        protected void btnSubmitGradLev_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGradLevID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสระดับการศึกษาที่จบการศึกษาสูงสุด')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertGradLevName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับการศึกษาที่จบการศึกษาสูงสุด')", true);
                return;
            }
            ClassGradLev gl = new ClassGradLev();
            gl.GRAD_LEV_ID = txtInsertGradLevID.Text;
            gl.GRAD_LEV_NAME = txtInsertGradLevName.Text;

            if (gl.CheckUseGradLevID())
            {
                gl.InsertGradLev();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสระดับการศึกษาที่จบการศึกษาสูงสุดนี้ อยู่ในระบบแล้ว !')", true);
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
            TextBox txtGradLevIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradLevIDEdit");
            TextBox txtGradLevNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradLevNameEdit");

            ClassGradLev gl = new ClassGradLev(txtGradLevIDEdit.Text
                , txtGradLevNameEdit.Text);

            gl.UpdateGradLev();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับการศึกษาที่จบการศึกษาสูงสุด " + DataBinder.Eval(e.Row.DataItem, "GRAD_LEV_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtGradLevIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewGradLev_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelGradLev_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchGradLev_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchGradLevID.Text) && string.IsNullOrEmpty(txtSearchGradLevName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassGradLev gl = new ClassGradLev();
                DataTable dt = gl.GetGradLevSearch(txtSearchGradLevID.Text, txtSearchGradLevName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradLev gl = new ClassGradLev();
            DataTable dt = gl.GetGradLev("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}