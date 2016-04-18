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
    public partial class Gender_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchGenderID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertGenderID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["GENDER"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GENDER"] = data;
        }

        #endregion

        void BindData()
        {
            ClassGender g = new ClassGender();
            DataTable dt = g.GetGender("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassGender g = new ClassGender();
            DataTable dt = g.GetGenderSearch(txtSearchGenderID.Text, txtSearchGenderName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchGenderID.Text = "";
            txtSearchGenderName.Text = "";
            txtInsertGenderID.Text = "";
            txtInsertGenderName.Text = "";
        }

        protected void btnSubmitGender_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGenderID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสเพศ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertGenderName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อเพศ')", true);
                return;
            }
            ClassGender g = new ClassGender();
            g.Gender_ID = Convert.ToInt32(txtInsertGenderID.Text);
            g.Gender_Name = txtInsertGenderName.Text;

            if (g.CheckUseGenderID())
            {
                g.InsertGender();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสเพศนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassGender y = new ClassGender();
            y.Gender_ID = id;
            y.DeleteGender();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtGenderIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGenderIDEdit");
            TextBox txtGenderNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGenderNameEdit");

            ClassGender g = new ClassGender(Convert.ToInt32(txtGenderIDEdit.Text)
                , txtGenderNameEdit.Text);

            g.UpdateGender();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อเพศ " + DataBinder.Eval(e.Row.DataItem, "GENDER_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtGenderIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewGENDER_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelGender_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGender g = new ClassGender();
            DataTable dt = g.GetGender("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchGender_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchGenderID.Text) && string.IsNullOrEmpty(txtSearchGenderName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassGender g = new ClassGender();
                DataTable dt = g.GetGenderSearch(txtSearchGenderID.Text, txtSearchGenderName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGender g = new ClassGender();
            DataTable dt = g.GetGender("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}