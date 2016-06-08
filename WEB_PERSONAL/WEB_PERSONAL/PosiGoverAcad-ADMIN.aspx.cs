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
    public partial class PosiGoverAcad_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["PosiGoverAcad"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PosiGoverAcad"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            DataTable dt = pmm.GetPositionMinMax("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            DataTable dt = pmm.GetPositionMinMax(txtSearchPosiGoverAcadName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchPosiGoverAcadName.Text = "";
            txtInsertPosiGoverAcadName.Text = "";
        }

        protected void btnSubmitPosiGoverAcad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertPosiGoverAcadName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำแหน่ง')", true);
                return;
            }
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            pmm.P_NAME = txtInsertPosiGoverAcadName.Text;

            if (pmm.CheckUsePositionMinMaxName())
            {
                pmm.InsertPositionMinMax();
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
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            pmm.P_ID = id;
            pmm.DeletePositionMinMax();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPosiGoverAcadIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPosiGoverAcadIDEdit");
            TextBox txtPosiGoverAcadNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPosiGoverAcadNameEdit");

            ClassPositionMinMax pmm = new ClassPositionMinMax(Convert.ToInt32(lblPosiGoverAcadIDEdit.Text),
                txtPosiGoverAcadNameEdit.Text);

            if (pmm.CheckUsePositionMinMaxName())
            {
                pmm.UpdatePositionMinMax();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำแหน่ง " + DataBinder.Eval(e.Row.DataItem, "P_NAME") + " ใช่ไหม ?');");
            }
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                }
            }
        }
        protected void myGridViewPosiGoverAcad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPosiGoverAcad_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            DataTable dt = pmm.GetPositionMinMax("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPosiGoverAcad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPosiGoverAcadName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassPositionMinMax pmm = new ClassPositionMinMax();
                DataTable dt = pmm.GetPositionMinMax(txtSearchPosiGoverAcadName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionMinMax pmm = new ClassPositionMinMax();
            DataTable dt = pmm.GetPositionMinMax("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}