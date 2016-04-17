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
    public partial class District_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchDistrictID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchAmphurID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchProvinceID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchPostCode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertDistrictID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertAmphurID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertProvinceID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertPostCode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["DISTRICT"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["DISTRICT"] = data;
        }

        #endregion

        void BindData()
        {
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrictSearch(txtSearchDistrictID.Text, txtSearchDistrictTH.Text, txtSearchDistrictEN.Text, txtSearchAmphurID.Text, txtSearchProvinceID.Text, txtSearchPostCode.Text, txtSearchNote.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchDistrictID.Text = "";
            txtSearchDistrictTH.Text = "";
            txtSearchDistrictEN.Text = "";
            txtSearchAmphurID.Text = "";
            txtSearchProvinceID.Text = "";
            txtSearchPostCode.Text = "";
            txtSearchNote.Text = "";
            txtInsertDistrictID.Text = "";
            txtInsertDistrictTH.Text = "";
            txtInsertDistrictEN.Text = "";
            txtInsertAmphurID.Text = "";
            txtInsertProvinceID.Text = "";
            txtInsertPostCode.Text = "";
            txtInsertNote.Text = "";

        }

        protected void btnSubmitDistrict_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertDistrictID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสตำบล')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertDistrictTH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำบลภาษาไทย')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertDistrictEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำบลภาษาอังกฤษ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertAmphurID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสอำเภอ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertProvinceID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสจังหวัด')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertPostCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสไปรษณีย์')", true);
                return;
            }
            
            ClassDistrict d = new ClassDistrict();
            d.DISTRICT_ID = Convert.ToInt32(txtInsertDistrictID.Text);
            d.DISTRICT_TH = txtInsertDistrictTH.Text;
            d.DISTRICT_EN = txtInsertDistrictEN.Text;
            d.AMPHUR_ID = Convert.ToInt32(txtInsertAmphurID.Text);
            d.PROVINCE_ID = Convert.ToInt32(txtInsertProvinceID.Text);
            d.POST_CODE = Convert.ToInt32(txtInsertPostCode.Text);
            d.NOTE = txtInsertNote.Text;

            if (d.CheckUseDistrictID())
            {
                d.InsertDistrict();
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
            ClassDistrict d = new ClassDistrict();
            d.DISTRICT_ID = id;
            d.DeleteDistrict();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {

            TextBox txtDistrictIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDistrictIDEdit");
            TextBox txtDistrictTHEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDistrictTHEdit");
            TextBox txtDistrictENEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDistrictENEdit");
            TextBox txtAmphurIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurIDEdit");

            TextBox txtProvinceIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProvinceIDEdit");
            TextBox txtPostCodeEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPostCodeEdit");
            TextBox txtNoteEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNoteEdit");

            ClassDistrict d = new ClassDistrict(Convert.ToInt32(txtDistrictIDEdit.Text)
                , txtDistrictTHEdit.Text
                , txtDistrictENEdit.Text
                , Convert.ToInt32(txtAmphurIDEdit.Text)
                , Convert.ToInt32(txtProvinceIDEdit.Text)
                , Convert.ToInt32(txtPostCodeEdit.Text)
                , txtNoteEdit.Text);

            d.UpdateDistrict();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำบล " + DataBinder.Eval(e.Row.DataItem, "DISTRICT_TH") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt1 = (TextBox)e.Row.FindControl("txtDistrictIDEdit");
                    txt1.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt2 = (TextBox)e.Row.FindControl("txtAmphurIDEdit");
                    txt2.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt3 = (TextBox)e.Row.FindControl("txtProvinceIDEdit");
                    txt3.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    TextBox txt4 = (TextBox)e.Row.FindControl("txtPostCodeEdit");
                    txt4.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelDistrict_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchDistrict_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchDistrictID.Text) && string.IsNullOrEmpty(txtSearchDistrictTH.Text) && string.IsNullOrEmpty(txtSearchDistrictEN.Text) && string.IsNullOrEmpty(txtSearchAmphurID.Text) && string.IsNullOrEmpty(txtSearchProvinceID.Text) && string.IsNullOrEmpty(txtSearchPostCode.Text) && string.IsNullOrEmpty(txtSearchNote.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassDistrict d = new ClassDistrict();
                DataTable dt = d.GetDistrictSearch(txtSearchDistrictID.Text, txtSearchDistrictTH.Text, txtSearchDistrictEN.Text, txtSearchAmphurID.Text, txtSearchProvinceID.Text, txtSearchPostCode.Text, txtSearchNote.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}