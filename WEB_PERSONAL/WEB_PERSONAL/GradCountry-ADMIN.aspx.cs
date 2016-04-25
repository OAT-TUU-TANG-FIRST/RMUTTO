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
    public partial class GradCountry_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["GRADCOUNTRY"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GRADCOUNTRY"] = data;
        }

        #endregion

        void BindData()
        {
            ClassGradCountry gc = new ClassGradCountry();
            DataTable dt = gc.GetGradCountry("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassGradCountry gn = new ClassGradCountry();
            DataTable dt = gn.GetGradCountrySearch(txtSearchGradCountry2.Text, txtSearchGradCountryShort.Text, txtSearchGradCountryLong.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchGradCountry2.Text = "";
            txtSearchGradCountryShort.Text = "";
            txtSearchGradCountryLong.Text = "";
            txtInsertGradCountry2.Text = "";
            txtInsertGradCountryShort.Text = "";
            txtInsertGradCountryLong.Text = "";
        }

        protected void btnSubmitGradCountry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGradCountry2.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสประเทศ 2 ตัวอักษร(ENG)')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertGradCountryShort.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อย่อของประเทศ(ENG)')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertGradCountryLong.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อเต็มของประเทศ(ENG)')", true);
                return;
            }
            ClassGradCountry cg = new ClassGradCountry();
            cg.GRAD_ISO2 = txtInsertGradCountry2.Text;
            cg.GRAD_SHORT_NAME = txtInsertGradCountryShort.Text;
            cg.GRAD_LONG_NAME = txtInsertGradCountryLong.Text;

            if (cg.CheckUseGradCountryNameInsert())
            {
                cg.InsertGradCountry();
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
            ClassGradCountry cg = new ClassGradCountry();
            cg.GRAD_COUNTRY_ID = id;
            cg.DeleteGradCountry();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblGradCountryID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGradCountryID");
            TextBox txtGradCountry2Edit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradCountry2Edit");
            TextBox txtGradCountryShortEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradCountryShortEdit");
            TextBox txtGradCountryLongEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradCountryLongEdit");

            ClassGradCountry cg = new ClassGradCountry(Convert.ToInt32(lblGradCountryID.Text)
                , txtGradCountry2Edit.Text
                , txtGradCountryShortEdit.Text
                , txtGradCountryLongEdit.Text);

            if (cg.CheckUseGradCountryNameUpdate())
            {
                cg.UpdateGradCountry();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อประเทศ " + DataBinder.Eval(e.Row.DataItem, "GRAD_SHORT_NAME") + " ใช่ไหม ?');");
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
        protected void myGridViewGradCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelGradCountry_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradCountry cg = new ClassGradCountry();
            DataTable dt = cg.GetGradCountry("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchGradCountry_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchGradCountry2.Text) && string.IsNullOrEmpty(txtSearchGradCountryShort.Text) && string.IsNullOrEmpty(txtSearchGradCountryLong.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                ClassGradCountry cg = new ClassGradCountry();
                DataTable dt = cg.GetGradCountrySearch(txtSearchGradCountry2.Text, txtSearchGradCountryShort.Text, txtSearchGradCountryLong.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradCountry cg = new ClassGradCountry();
            DataTable dt = cg.GetGradCountry("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}