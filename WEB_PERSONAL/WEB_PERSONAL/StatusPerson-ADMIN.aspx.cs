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
                txtSearchStatusPersonID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertStatusPersonID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
            DataTable dt = sp.GetStatusPerson("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPersonSearch(txtSearchStatusPersonID.Text, txtSearchStatusPersonName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchStatusPersonID.Text = "";
            txtSearchStatusPersonName.Text = "";
            txtInsertStatusPersonID.Text = "";
            txtInsertStatusPersonName.Text = "";
        }

        protected void btnSubmitStatusPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertStatusPersonID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสสถานภาพ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertStatusPersonName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อสถานภาพ')", true);
                return;
            }
            ClassStatusPerson sp = new ClassStatusPerson();
            sp.STATUS_ID = Convert.ToInt32(txtInsertStatusPersonID.Text);
            sp.STATUS_NAME = txtInsertStatusPersonName.Text;

            if (sp.CheckUseStatusPersonID())
            {
                sp.InsertStatusPerson();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสสถานภาพนี้ อยู่ในระบบแล้ว !')", true);
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
            TextBox txtStatusPersonIDEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStatusPersonIDEDIT");
            TextBox txtStatusPersonNameEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStatusPersonNameEDIT");

            ClassStatusPerson sp = new ClassStatusPerson(Convert.ToInt32(txtStatusPersonIDEDIT.Text), txtStatusPersonNameEDIT.Text);

            sp.UpdateStatusPerson();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบรหัสสถานภาพ " + DataBinder.Eval(e.Row.DataItem, "STATUS_ID") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtStatusPersonIDEDIT");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewStatusPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelStatusPerson_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchStatusPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchStatusPersonID.Text) && string.IsNullOrEmpty(txtSearchStatusPersonName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassStatusPerson sp = new ClassStatusPerson();
                DataTable dt = sp.GetStatusPersonSearch(txtSearchStatusPersonID.Text, txtSearchStatusPersonName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassStatusPerson sp = new ClassStatusPerson();
            DataTable dt = sp.GetStatusPerson("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}