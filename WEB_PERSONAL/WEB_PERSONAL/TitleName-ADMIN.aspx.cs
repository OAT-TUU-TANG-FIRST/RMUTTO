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
    public partial class pre_title_name : System.Web.UI.Page
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
            return (DataTable)ViewState["TITLE"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["TITLE"] = data;
        }

        #endregion

        void BindData()
        {
            ClassTitleName t = new ClassTitleName();
            DataTable dt = t.GetTitleName("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassTitleName t = new ClassTitleName();
            DataTable dt = t.GetTitleName(txtSearchTitleName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchTitleName.Text = "";
            txtInsertTitleName.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertTitleName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อคำนำหน้านาม')", true);
                return;
            }
            ClassTitleName t = new ClassTitleName();
            t.TITLE_NAME_TH = txtInsertTitleName.Text;

            if (t.CheckUseTitleName())
            {
                t.InsertTitleName();
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
            ClassTitleName t = new ClassTitleName();
            t.TITLE_ID = id;
            t.DeleteTitleName();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblTitleIDEDIT = (Label)GridView1.Rows[e.RowIndex].FindControl("lblTitleIDEDIT");
            TextBox txtTitleNameEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtTitleNameEDIT");

            ClassTitleName t = new ClassTitleName(Convert.ToInt32(lblTitleIDEDIT.Text), txtTitleNameEDIT.Text);

            if (t.CheckUseTitleName())
            {
                t.UpdateTitleName();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อคำนำหน้านาม " + DataBinder.Eval(e.Row.DataItem, "TITLE_NAME_TH") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassTitleName t = new ClassTitleName();
            DataTable dt = t.GetTitleName("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchTitleName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassTitleName t = new ClassTitleName();
                DataTable dt = t.GetTitleName(txtSearchTitleName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassTitleName t = new ClassTitleName();
            DataTable dt = t.GetTitleName("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}