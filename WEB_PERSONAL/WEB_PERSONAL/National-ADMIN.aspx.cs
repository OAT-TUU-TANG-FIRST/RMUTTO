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
    public partial class National_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["NATION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["NATION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassNational n = new ClassNational();
            DataTable dt = n.GetNational("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassNational n = new ClassNational();
            DataTable dt = n.GetNationalSearch(txtSearchNationID.Text, txtSearchNationENG.Text, txtSearchNationTHA.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchNationID.Text = "";
            txtSearchNationENG.Text = "";
            txtSearchNationTHA.Text = "";
            txtInsertNationID.Text = "";
            txtInsertNationENG.Text = "";
            txtInsertNationTHA.Text = "";
        }

        protected void btnSubmitNATIONAL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertNationID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสสัญชาติ')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertNationENG.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อสัญชาติภาษาอังกฤษ')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertNationTHA.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อสัญชาติภาษาไทย')", true);
                return;
            }
            ClassNational n = new ClassNational();
            n.NATION_ID = txtInsertNationID.Text;
            n.NATION_ENG = txtInsertNationENG.Text;
            n.NATION_THA = txtInsertNationTHA.Text;

            if (n.CheckUseNationID())
            {
                n.InsertNational();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('มีรหัสสัญชาตินี้ อยู่ในระบบแล้ว !')", true);
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
            ClassNational n = new ClassNational();
            n.NATION_SEQ = id;
            n.DeleteNational();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblNationSEQ = (Label)GridView1.Rows[e.RowIndex].FindControl("lblNationSEQ");
            TextBox txtNationIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNationIDEdit");
            TextBox txtNationENGEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNationENGEdit");
            TextBox txtNationTHAEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNationTHAEdit");

            ClassNational n = new ClassNational(Convert.ToInt32(lblNationSEQ.Text)
                , txtNationIDEdit.Text
                , txtNationENGEdit.Text
                , txtNationTHAEdit.Text);

            n.UpdateNational();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อสัญชาติ " + DataBinder.Eval(e.Row.DataItem, "NATION_ENG") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewNATIONAL_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelNATIONAL_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassNational n = new ClassNational();
            DataTable dt = n.GetNational("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchNATIONAL_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchNationID.Text) && string.IsNullOrEmpty(txtSearchNationENG.Text) && string.IsNullOrEmpty(txtSearchNationTHA.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassNational n = new ClassNational();
                DataTable dt = n.GetNationalSearch(txtSearchNationID.Text, txtSearchNationENG.Text, txtSearchNationTHA.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassNational n = new ClassNational();
            DataTable dt = n.GetNational("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}