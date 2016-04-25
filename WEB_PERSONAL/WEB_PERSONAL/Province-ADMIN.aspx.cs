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
    public partial class Province_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["PROVINCE"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PROVINCE"] = data;
        }

        #endregion

        void BindData()
        {
            ClassProvince p = new ClassProvince();
            DataTable dt = p.GetProvince("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassProvince p = new ClassProvince();
            DataTable dt = p.GetProvince(txtSearchProvinceTH.Text, txtSearchProvinceEN.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchProvinceTH.Text = "";
            txtSearchProvinceEN.Text = "";
            txtInsertProvinceTH.Text = "";
            txtInsertProvinceEN.Text = "";
        }

        protected void btnSubmitProvince_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertProvinceTH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อจังหวัดภาษาไทย')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertProvinceEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อจังหวัดภาษาอังกฤษ')", true);
                return;
            }
            ClassProvince p = new ClassProvince();
            p.PROVINCE_TH = txtInsertProvinceTH.Text;
            p.PROVINCE_EN = txtInsertProvinceEN.Text;

            if (p.CheckUseProvinceNameInsert())
            {
                p.InsertProvince();
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
            ClassProvince p = new ClassProvince();
            p.PROVINCE_ID = id;
            p.DeleteProvince();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {

            Label lblProvinceIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblProvinceIDEdit");
            TextBox txtProvinceTHEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProvinceTHEdit");
            TextBox txtProvinceENEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProvinceENEdit");

            ClassProvince p = new ClassProvince(Convert.ToInt32(lblProvinceIDEdit.Text)
                , txtProvinceTHEdit.Text
                , txtProvinceENEdit.Text);

            if (p.CheckUseProvinceNameUpdate())
            {
                p.UpdateProvince();
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อจังหวัด " + DataBinder.Eval(e.Row.DataItem, "PROVINCE_TH") + " ใช่ไหม ?');");
            }
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                }
            }
        }
        protected void myGridViewProvince_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelProvince_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassProvince p = new ClassProvince();
            DataTable dt = p.GetProvince("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchProvince_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchProvinceTH.Text) && string.IsNullOrEmpty(txtSearchProvinceEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassProvince p = new ClassProvince();
                DataTable dt = p.GetProvince(txtSearchProvinceTH.Text, txtSearchProvinceEN.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassProvince p = new ClassProvince();
            DataTable dt = p.GetProvince("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}