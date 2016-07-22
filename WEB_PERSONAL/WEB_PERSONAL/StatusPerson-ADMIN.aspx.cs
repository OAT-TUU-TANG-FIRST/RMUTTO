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
    public partial class StatusPerson_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["STATUSPERSON"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["STATUSPERSON"] = data;
        }

        #endregion

        void BindData()
        {
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson(txtSearchStatusPersonName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchStatusPersonName.Text = "";
            txtInsertStatusPersonName.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertStatusPersonName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อสถานภาพ')", true);
                return;
            }
            ClassStatusPerson sp = new ClassStatusPerson();
            sp.STATUS_NAME = txtInsertStatusPersonName.Text;

            if (sp.CheckUseStatusPersonName())
            {
                sp.InsertStatusPerson();
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
            ClassStatusPerson sp = new ClassStatusPerson();
            sp.STATUS_ID = id;
            sp.DeleteStatusPerson();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblStatusPersonIDEDIT = (Label)GridView1.Rows[e.RowIndex].FindControl("lblStatusPersonIDEDIT");
            TextBox txtStatusPersonNameEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStatusPersonNameEDIT");

            ClassStatusPerson sp = new ClassStatusPerson(Convert.ToInt32(lblStatusPersonIDEDIT.Text), txtStatusPersonNameEDIT.Text);

            if (sp.CheckUseStatusPersonName())
            {
                sp.UpdateStatusPerson();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบรหัสสถานภาพ " + DataBinder.Eval(e.Row.DataItem, "STATUS_ID") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewStatusPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchStatusPersonName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassStatusPerson sp = new ClassStatusPerson();
                DataTable dt = sp.GetStatusPerson(txtSearchStatusPersonName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}