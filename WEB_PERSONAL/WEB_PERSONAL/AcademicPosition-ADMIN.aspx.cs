using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL
{
    public partial class AcademicPosition_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person ps = PersonnelSystem.GetPersonnelSystem(this).LoginPerson;
            if (ps.Permission != 2)
            {
                Response.Redirect("NoPermission.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["ACAD"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["ACAD"] = data;
        }

        #endregion

        void BindData()
        {
            ClassAcademicPosition ap = new ClassAcademicPosition();
            DataTable dt = ap.GetAcademicPosition("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassAcademicPosition ap = new ClassAcademicPosition();
            DataTable dt = ap.GetAcademicPosition(txtSearchAcadName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchAcadName.Text = "";
            txtInsertAcadName.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertAcadName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำแหน่งทางวิชาการ')", true);
                return;
            }
            ClassAcademicPosition ap = new ClassAcademicPosition();
            ap.ACAD_NAME = txtInsertAcadName.Text;

            if (ap.CheckUseAcademicPositionName())
            {
                ap.InsertAcademicPosition();
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
            ClassAcademicPosition ap = new ClassAcademicPosition();
            ap.ACAD_ID = id;
            ap.DeleteAcademicPosition();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblAcadIDEDIT = (Label)GridView1.Rows[e.RowIndex].FindControl("lblAcadIDEDIT");
            TextBox txtAcadNameEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAcadNameEDIT");

            ClassAcademicPosition ap = new ClassAcademicPosition(Convert.ToInt32(lblAcadIDEDIT.Text), txtAcadNameEDIT.Text);

            if (ap.CheckUseAcademicPositionName())
            {
                ap.UpdateAcademicPosition();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำแหน่งทางวิชาการ " + DataBinder.Eval(e.Row.DataItem, "ACAD_NAME") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewAcad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAcademicPosition ap = new ClassAcademicPosition();
            DataTable dt = ap.GetAcademicPosition("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchAcadName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassAcademicPosition ap = new ClassAcademicPosition();
                DataTable dt = ap.GetAcademicPosition(txtSearchAcadName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAcademicPosition ap = new ClassAcademicPosition();
            DataTable dt = ap.GetAcademicPosition("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}