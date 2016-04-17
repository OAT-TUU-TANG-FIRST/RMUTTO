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
    public partial class GoverPosition_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchGoverPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchSubStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertGoverPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertSubStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["GOVERPOSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GOVERPOSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGovermentSearch(txtSearchGoverPositionID.Text, txtSearchGoverPositionName.Text, txtSearchSubStaffID.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchGoverPositionID.Text = "";
            txtSearchGoverPositionName.Text = "";
            txtSearchSubStaffID.Text = "";
            txtInsertGoverPositionID.Text = "";
            txtInsertGoverPositionName.Text = "";
            txtInsertSubStaffID.Text = "";
        }

        protected void btnSubmitGoverPosition_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtInsertGoverPositionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสระดับข้าราชการ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertGoverPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับข้าราชการ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertSubStaffID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเภทตำแหน่ง')", true);
                return;
            }
            ClassPositionGoverment pg = new ClassPositionGoverment();
            pg.ID = Convert.ToInt32(txtInsertGoverPositionID.Text);
            pg.NAME = txtInsertGoverPositionName.Text;
            pg.ST_ID = txtInsertSubStaffID.Text;

            if (pg.CheckUsePositionGovermentID())
            {
                pg.InsertPositionGoverment();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสระดับข้าราชการนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassPositionGoverment pg = new ClassPositionGoverment();
            pg.ID = id;
            pg.DeletePositionGoverment();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtGoverPositionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGoverPositionIDEdit");
            TextBox txtGoverPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGoverPositionNameEdit");
            TextBox txtSubStaffIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSubStaffIDEdit");

            ClassPositionGoverment pg = new ClassPositionGoverment(Convert.ToInt32(txtGoverPositionIDEdit.Text), txtGoverPositionNameEdit.Text, txtSubStaffIDEdit.Text);

            pg.UpdatePositionGoverment();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับข้าราชการ " + DataBinder.Eval(e.Row.DataItem, "NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtGoverPositionIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtSubStaffIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewGoverPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelGoverPosition_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchGoverPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchGoverPositionID.Text) && string.IsNullOrEmpty(txtSearchGoverPositionName.Text) && string.IsNullOrEmpty(txtSearchSubStaffID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassPositionGoverment pg = new ClassPositionGoverment();
                DataTable dt = pg.GetPositionGovermentSearch(txtSearchGoverPositionID.Text, txtSearchGoverPositionName.Text, txtSearchSubStaffID.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}