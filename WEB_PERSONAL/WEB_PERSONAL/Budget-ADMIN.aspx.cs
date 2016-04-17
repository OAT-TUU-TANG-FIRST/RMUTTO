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
    public partial class Budget_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchBudgetID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertBudgetID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["BUDGET"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["BUDGET"] = data;
        }

        #endregion

        void BindData()
        {
            ClassBudget b = new ClassBudget();
            DataTable dt = b.GetBudget("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassBudget b = new ClassBudget();
            DataTable dt = b.GetBudgetSearch(txtSearchBudgetID.Text, txtSearchBudgetName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchBudgetID.Text = "";
            txtSearchBudgetName.Text = "";
            txtInsertBudgetName.Text = "";
            txtInsertBudgetID.Text = "";
        }

        protected void btnSubmitBudget_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertBudgetID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเภทเงินจ้าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertBudgetName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อประเภทเงินจ้าง')", true);
                return;
            }
            ClassBudget b = new ClassBudget();
            b.BUDGET_ID = Convert.ToInt32(txtInsertBudgetID.Text);
            b.BUDGET_NAME = txtInsertBudgetName.Text;

            if (b.CheckUseBudgetID())
            {
                b.InsertBudget();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสประเภทเงินจ้างนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassBudget b = new ClassBudget();
            b.BUDGET_ID = id;
            b.DeleteBudget();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();

        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtBudgetIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBudgetIDEdit");
            TextBox txtBudgetNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBudgetNameEdit");

            ClassBudget b = new ClassBudget(Convert.ToInt32(txtBudgetIDEdit.Text)
                , txtBudgetNameEdit.Text);

            b.UpdateBudget();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อประเภทเงินจ้าง " + DataBinder.Eval(e.Row.DataItem, "BUDGET_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtBudgetIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewBudget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelBudget_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassBudget b = new ClassBudget();
            DataTable dt = b.GetBudget("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchBudgetName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBudgetID.Text) && string.IsNullOrEmpty(txtSearchBudgetName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassBudget b = new ClassBudget();
                DataTable dt = b.GetBudgetSearch(txtSearchBudgetID.Text, txtSearchBudgetName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassBudget b = new ClassBudget();
            DataTable dt = b.GetBudget("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}