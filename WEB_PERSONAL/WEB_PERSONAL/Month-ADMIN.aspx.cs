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
    public partial class Month_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["MONTH"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["MONTH"] = data;
        }

        #endregion

        void BindData()
        {
            ClassMonth m = new ClassMonth();
            DataTable dt = m.GetMonth("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassMonth m = new ClassMonth();
            DataTable dt = m.GetMonth(txtSearchMonthNameSmall.Text, txtSearchMonthNameFull.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchMonthNameSmall.Text = "";
            txtSearchMonthNameFull.Text = "";
            txtInsertMonthNameSmall.Text = "";
            txtInsertMonthNameFull.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertMonthNameSmall.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อเดือนย่อ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertMonthNameFull.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อเดือนเต็ม')", true);
                return;
            }
            ClassMonth m = new ClassMonth();
            m.MONTH_SHORT = txtInsertMonthNameSmall.Text;
            m.MONTH_LONG = txtInsertMonthNameFull.Text;

            if (m.CheckUseMonthNameInsert())
            {
                m.InsertMonth();
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
            ClassMonth m = new ClassMonth();
            m.MONTH_ID = id;
            m.DeleteMonth();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblMonthIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblMonthIDEdit");
            TextBox txtMonthNameSmallEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMonthNameSmallEdit");
            TextBox txtMonthNameFullEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMonthNameFullEdit");

            ClassMonth m = new ClassMonth(Convert.ToInt32(lblMonthIDEdit.Text)
                , txtMonthNameSmallEdit.Text
                , txtMonthNameFullEdit.Text);

            if (m.CheckUseMonthNameUpdate())
            {
                m.UpdateMonth();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อเดือน " + DataBinder.Eval(e.Row.DataItem, "MONTH_LONG") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassMonth m = new ClassMonth();
            DataTable dt = m.GetMonth("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchMonthNameSmall.Text) && string.IsNullOrEmpty(txtSearchMonthNameFull.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassMonth m = new ClassMonth();
                DataTable dt = m.GetMonth(txtSearchMonthNameSmall.Text, txtSearchMonthNameFull.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassMonth m = new ClassMonth();
            DataTable dt = m.GetMonth("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}