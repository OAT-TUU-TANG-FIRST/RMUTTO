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
    public partial class Campus_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertCampusID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["CAMPUS"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["CAMPUS"] = data;
        }

        #endregion

        void BindData()
        {
            ClassCampus c = new ClassCampus();
            DataTable dt = c.GetCampus("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassCampus c = new ClassCampus();
            DataTable dt = c.GetCampusSearch(txtSearchCampusID.Text, txtSearchCampusName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchCampusID.Text = "";
            txtSearchCampusName.Text = "";
            txtInsertCampusID.Text = "";
            txtInsertCampusName.Text = "";
        }

        protected void btnSubmitCampus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertCampusID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสวิทยาเขต')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertCampusName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อวิทยาเขต')", true);
                return;
            }
            ClassCampus c = new ClassCampus();
            c.CAMPUS_ID = Convert.ToInt32(txtInsertCampusID.Text);
            c.CAMPUS_NAME = txtInsertCampusName.Text;

            if (c.CheckUseCampusID())
            {
                c.InsertCampus();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสวิทยาเขตนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassCampus c = new ClassCampus();
            c.CAMPUS_ID = id;
            c.DeleteCampus();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtCampusIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCampusIDEdit");
            TextBox txtCampusNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCampusNameEdit");

            ClassCampus c = new ClassCampus(Convert.ToInt32(txtCampusIDEdit.Text),
                txtCampusNameEdit.Text);

            c.UpdateCampus();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อวิทยาเขต " + DataBinder.Eval(e.Row.DataItem, "CAMPUS_NAME") + " ใช่ไหม ?');");
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtCampusIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewCampus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelCampus_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassCampus c = new ClassCampus();
            DataTable dt = c.GetCampus("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchCampus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCampusID.Text) && string.IsNullOrEmpty(txtSearchCampusName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassCampus c = new ClassCampus();
                DataTable dt = c.GetCampusSearch(txtSearchCampusID.Text, txtSearchCampusName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassCampus c = new ClassCampus();
            DataTable dt = c.GetCampus("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}