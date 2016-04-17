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
    public partial class Religion_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchReligionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertReligionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["Religion"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["Religion"] = data;
        }

        #endregion

        void BindData()
        {
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligionSearch(txtSearchReligionID.Text,txtSearchReligionName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchReligionID.Text = "";
            txtInsertReligionID.Text = "";
            txtSearchReligionName.Text = "";
            txtInsertReligionName.Text = "";
        }

        protected void btnSubmitReligion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertReligionID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสศาสนา')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertReligionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อศาสนา')", true);
                return;
            }
            ClassReligion r = new ClassReligion();
            r.RELIGION_ID = Convert.ToInt32(txtInsertReligionID.Text);
            r.RELIGION_NAME = txtInsertReligionName.Text;

            if (r.CheckUseReligionID())
            {
                r.InsertReligion();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสศาสนานี้ อยู่ในระบบแล้ว !')", true);
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
            ClassReligion r = new ClassReligion();
            r.RELIGION_ID = id;
            r.DeleteReligion();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtReligionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtReligionIDEdit");
            TextBox txtReligionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtReligionNameEdit");

            ClassReligion r = new ClassReligion(Convert.ToInt32(txtReligionIDEdit.Text),
                txtReligionNameEdit.Text);

            r.UpdateReligion();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อศาสนา " + DataBinder.Eval(e.Row.DataItem, "Religion_NAME") + " ใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtReligionIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewReligion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelReligion_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchReligion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchReligionID.Text) && string.IsNullOrEmpty(txtSearchReligionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassReligion r = new ClassReligion();
                DataTable dt = r.GetReligionSearch(txtSearchReligionID.Text, txtSearchReligionName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}