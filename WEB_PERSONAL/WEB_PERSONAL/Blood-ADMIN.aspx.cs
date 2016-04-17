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
    public partial class Blood_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchBloodID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertBloodID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["BLOOD"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["BLOOD"] = data;
        }

        #endregion

        void BindData()
        {
            ClassBlood b = new ClassBlood();
            DataTable dt = b.GetBlood("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassBlood b = new ClassBlood();
            DataTable dt = b.GetBloodSearch(txtSearchBloodID.Text, txtSearchBloodName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchBloodID.Text = "";
            txtSearchBloodName.Text = "";
            txtInsertBloodID.Text = "";
            txtInsertBloodName.Text = "";
        }

        protected void btnSubmitBlood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertBloodID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสกรุ๊ปเลือด')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertBloodName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกรุ๊ปเลือด')", true);
                return;
            }
            ClassBlood b = new ClassBlood();
            b.BLOOD_ID = Convert.ToInt32(txtInsertBloodID.Text);
            b.BLOOD_NAME = txtInsertBloodName.Text;

            if (b.CheckUseBloodID())
            {
                b.InsertBlood();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสกรุ๊ปเลือดนี้นี้ อยู่ในระบบแล้ว !')", true);
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
            ClassBlood b = new ClassBlood();
            b.BLOOD_ID = id;
            b.DeleteBlood();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtBloodIDEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBloodIDEDIT");
            TextBox txtBloodNameEDIT = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBloodNameEDIT");

            ClassBlood b = new ClassBlood(Convert.ToInt32(txtBloodIDEDIT.Text), txtBloodNameEDIT.Text);

            b.UpdateBlood();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อกรุ๊ปเลือด " + DataBinder.Eval(e.Row.DataItem, "BLOOD_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtBloodIDEDIT");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewBlood_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelBlood_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassBlood b = new ClassBlood();
            DataTable dt = b.GetBlood("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchBlood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBloodID.Text) && string.IsNullOrEmpty(txtSearchBloodName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassBlood b = new ClassBlood();
                DataTable dt = b.GetBloodSearch(txtSearchBloodID.Text, txtSearchBloodName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassBlood b = new ClassBlood();
            DataTable dt = b.GetBlood("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}