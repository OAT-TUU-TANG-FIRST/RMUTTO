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
    public partial class Amphur_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchAmphurID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchProvinceID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertAmphurID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertProvinceID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["AMPHUR"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["AMPHUR"] = data;
        }

        #endregion

        void BindData()
        {
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphurSearch(txtSearchAmphurID.Text, txtSearchAmphurTH.Text, txtSearchAmphurEN.Text, txtSearchProvinceID.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchAmphurID.Text = "";
            txtSearchAmphurTH.Text = "";
            txtSearchAmphurEN.Text = "";
            txtSearchProvinceID.Text = "";
            txtInsertAmphurID.Text = "";
            txtInsertAmphurTH.Text = "";
            txtInsertAmphurEN.Text = "";
            txtInsertProvinceID.Text = "";
        }

        protected void btnSubmitAmphur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertAmphurID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสอำเภอ')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertAmphurTH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่ออำเภอภาษาไทย')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertAmphurEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่ออำเภอภาษาอังกฤษ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertProvinceID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสจังหวัด')", true);
                return;
            }
            ClassAmphur a = new ClassAmphur();
            a.AMPHUR_ID = Convert.ToInt32(txtInsertAmphurID.Text);
            a.AMPHUR_TH = txtInsertAmphurTH.Text;
            a.AMPHUR_EN = txtInsertAmphurEN.Text;
            a.PROVINCE_ID = Convert.ToInt32(txtInsertProvinceID.Text);

            if (a.CheckUseAmphurID())
            {
                a.InsertAmphur();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสอำเภอนี้ อยู่ในระบบแล้ว !')", true);
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
            ClassAmphur a = new ClassAmphur();
            a.AMPHUR_ID = id;
            a.DeleteAmphur();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {

            TextBox txtAmphurIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurIDEdit");
            TextBox txtAmphurTHEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurTHEdit");
            TextBox txtAmphurENEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurENEdit");
            TextBox txtProvinceIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProvinceIDEdit");

            ClassAmphur a = new ClassAmphur(Convert.ToInt32(txtAmphurIDEdit.Text)
                , txtAmphurTHEdit.Text
                , txtAmphurENEdit.Text
                , Convert.ToInt32(txtProvinceIDEdit.Text));

            a.UpdateAmphur();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่ออำเภอ " + DataBinder.Eval(e.Row.DataItem, "AMPHUR_TH") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt1 = (TextBox)e.Row.FindControl("txtAmphurIDEdit");
                    txt1.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtProvinceIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewAmphur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelAmphur_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchAmphur_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchAmphurID.Text) && string.IsNullOrEmpty(txtSearchAmphurTH.Text) && string.IsNullOrEmpty(txtSearchAmphurEN.Text) && string.IsNullOrEmpty(txtSearchProvinceID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassAmphur a = new ClassAmphur();
                DataTable dt = a.GetAmphurSearch(txtSearchAmphurID.Text, txtSearchAmphurTH.Text, txtSearchAmphurEN.Text, txtSearchProvinceID.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}