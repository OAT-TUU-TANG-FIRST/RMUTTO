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
            DataTable dt = r.GetReligion("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion(txtSearchReligionName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchReligionName.Text = "";
            txtInsertReligionName.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertReligionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อศาสนา')", true);
                return;
            }
            ClassReligion r = new ClassReligion();
            r.RELIGION_NAME = txtInsertReligionName.Text;

            if (r.CheckUseReligionName())
            {
                r.InsertReligion();
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
            ClassReligion r = new ClassReligion();
            r.RELIGION_ID = id;
            r.DeleteReligion();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblReligionIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblReligionIDEdit");
            TextBox txtReligionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtReligionNameEdit");

            ClassReligion r = new ClassReligion(Convert.ToInt32(lblReligionIDEdit.Text),
                txtReligionNameEdit.Text);

            if (r.CheckUseReligionName())
            {
                r.UpdateReligion();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อศาสนา " + DataBinder.Eval(e.Row.DataItem, "Religion_NAME") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewReligion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchReligionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassReligion r = new ClassReligion();
                DataTable dt = r.GetReligion(txtSearchReligionName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassReligion r = new ClassReligion();
            DataTable dt = r.GetReligion("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}