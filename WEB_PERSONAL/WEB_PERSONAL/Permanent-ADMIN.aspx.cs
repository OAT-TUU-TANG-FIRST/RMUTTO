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
    public partial class Permanent_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchPermaPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchSubStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertPermaPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertSubStaffID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");

            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["PERMAPOSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PERMAPOSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionPermanent pp = new ClassPositionPermanent();
            DataTable dt = pp.GetPositionPermanent("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassPositionPermanent pp = new ClassPositionPermanent();
            DataTable dt = pp.GetPositionPermanentSearch(txtSearchPermaPositionID.Text, txtSearchPermaPositionName.Text, txtSearchSubStaffID.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchPermaPositionID.Text = "";
            txtSearchPermaPositionName.Text = "";
            txtSearchSubStaffID.Text = "";
            txtInsertPermaPositionID.Text = "";
            txtInsertPermaPositionName.Text = "";
            txtInsertSubStaffID.Text = "";
        }

        protected void btnSubmitPermaPosition_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtInsertPermaPositionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสระดับลูกจ้างประจำ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertPermaPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับลูกจ้างประจำ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertSubStaffID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเภทตำแหน่ง')", true);
                return;
            }
            ClassPositionPermanent pp = new ClassPositionPermanent();
            pp.ID = Convert.ToInt32(txtInsertPermaPositionID.Text);
            pp.NAME = txtInsertPermaPositionName.Text;
            pp.ST_ID = txtInsertSubStaffID.Text;

            if (pp.CheckUsePositionPermanentID())
            {
                pp.InsertPositionPermanent();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสระดับลูกจ้างประจำนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassPositionPermanent pp = new ClassPositionPermanent();
            pp.ID = id;
            pp.DeletePositionPermanent();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtPermaPositionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPermaPositionIDEdit");
            TextBox txtPermaPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPermaPositionNameEdit");
            TextBox txtSubStaffIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSubStaffIDEdit");

            ClassPositionPermanent pp = new ClassPositionPermanent(Convert.ToInt32(txtPermaPositionIDEdit.Text), txtPermaPositionNameEdit.Text, txtSubStaffIDEdit.Text);

            pp.UpdatePositionPermanent();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบรหัสระดับลูกจ้างประจำ " + DataBinder.Eval(e.Row.DataItem, "ID") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtPermaPositionIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtSubStaffIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewPermaPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPermaPosition_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionPermanent pp = new ClassPositionPermanent();
            DataTable dt = pp.GetPositionPermanent("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPermaPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPermaPositionID.Text) && string.IsNullOrEmpty(txtSearchPermaPositionName.Text) && string.IsNullOrEmpty(txtSearchSubStaffID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassPositionPermanent pp = new ClassPositionPermanent();
                DataTable dt = pp.GetPositionPermanentSearch(txtSearchPermaPositionID.Text, txtSearchPermaPositionName.Text, txtSearchSubStaffID.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionPermanent pp = new ClassPositionPermanent();
            DataTable dt = pp.GetPositionPermanent("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}