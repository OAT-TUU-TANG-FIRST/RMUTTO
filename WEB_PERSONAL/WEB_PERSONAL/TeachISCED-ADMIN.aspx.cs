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
    public partial class TeachISCED_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchISCED_ID_OLD.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertISCED_ID_OLD.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["TeachISCED"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["TeachISCED"] = data;
        }

        #endregion

        void BindData()
        {
            ClassTeachISCED ti = new ClassTeachISCED();
            DataTable dt = ti.GetTeachISCED("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassTeachISCED ti = new ClassTeachISCED();
            DataTable dt = ti.GetTeachISCEDSearch(txtSearchISCED_ID.Text, txtSearchISCED_ID_OLD.Text, txtSearchISCED_NAME_TH.Text, txtSearchISCED_NAME_ENG.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchISCED_ID.Text = "";
            txtSearchISCED_ID_OLD.Text = "";
            txtSearchISCED_NAME_TH.Text = "";
            txtSearchISCED_NAME_ENG.Text = "";
            txtInsertISCED_ID.Text = "";
            txtInsertISCED_ID_OLD.Text = "";
            txtInsertISCED_NAME_TH.Text = "";
            txtInsertISCED_NAME_ENG.Text = "";
        }

        protected void btnSubmitTeachISCED_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertISCED_ID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสกลุ่มสาขาวิชาที่สอน')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertISCED_ID_OLD.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสกลุ่มสาขาวิชาที่สอนเก่า')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertISCED_NAME_TH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกลุ่มสาขาวิชาที่สอนภาษาไทย')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertISCED_NAME_ENG.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกลุ่มสาขาวิชาที่สอนภาษาอังกฤษ')", true);
                return;
            }
            ClassTeachISCED ti = new ClassTeachISCED();
            ti.TEACH_ISCED_ID = txtInsertISCED_ID.Text;
            ti.TEACH_ISCED_ID_OLD = Convert.ToInt32(txtInsertISCED_ID_OLD.Text);
            ti.TEACH_ISCED_NAME_TH = txtInsertISCED_NAME_TH.Text;
            ti.TEACH_ISCED_NAME_ENG = txtInsertISCED_NAME_ENG.Text;
           
            ti.InsertTeachISCED();
            BindData();
            ClearData();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);

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
            ClassTeachISCED ti = new ClassTeachISCED();
            ti.ID = id;
            ti.DeleteTeachISCED();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            
            TextBox txtTeachISCEDIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtTeachISCEDIDEdit");
            TextBox txtTeachISCEDidOldEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtTeachISCEDidOldEdit");
            TextBox txtTeachISCEDThaiEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtTeachISCEDThaiEdit");
            TextBox txtTeachISCEDEnglishEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtTeachISCEDEnglishEdit");
            Label lblTeachISCEDseqEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblTeachISCEDseqEdit");

            ClassTeachISCED ti = new ClassTeachISCED(txtTeachISCEDIDEdit.Text
                , Convert.ToInt32(txtTeachISCEDidOldEdit.Text)
                , txtTeachISCEDThaiEdit.Text
                , txtTeachISCEDEnglishEdit.Text
                , Convert.ToInt32(lblTeachISCEDseqEdit.Text));

            ti.UpdateTeachISCED();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อกลุ่มสาขาวิชา " + DataBinder.Eval(e.Row.DataItem, "TEACH_ISCED_NAME_TH") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtTeachISCEDidOldEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
        }
        protected void myGridViewTeachISCED_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelTeachISCED_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassTeachISCED ti = new ClassTeachISCED();
            DataTable dt = ti.GetTeachISCED("", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchTeachISCED_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchISCED_ID.Text) && string.IsNullOrEmpty(txtSearchISCED_ID_OLD.Text) && string.IsNullOrEmpty(txtSearchISCED_NAME_TH.Text) && string.IsNullOrEmpty(txtSearchISCED_NAME_ENG.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassTeachISCED ti = new ClassTeachISCED();
                DataTable dt = ti.GetTeachISCEDSearch(txtSearchISCED_ID.Text, txtSearchISCED_ID_OLD.Text, txtSearchISCED_NAME_TH.Text, txtSearchISCED_NAME_ENG.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassTeachISCED ti = new ClassTeachISCED();
            DataTable dt = ti.GetTeachISCED("","","","");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}