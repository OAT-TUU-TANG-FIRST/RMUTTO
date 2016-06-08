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
    public partial class Claninsignia_ADMIN : System.Web.UI.Page
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
            return (DataTable)ViewState["CLANINSIG"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["CLANINSIG"] = data;
        }

        #endregion

        void BindData()
        {
            ClassClanInsignia ci = new ClassClanInsignia();
            DataTable dt = ci.GetClanInsignia("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassClanInsignia ci = new ClassClanInsignia();
            DataTable dt = ci.GetClanInsignia(txtSearchClanInsigName.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchClanInsigName.Text = "";
            txtInsertClanInsigName.Text = "";
        }

        protected void btnSubmitClanInsig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertClanInsigName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกลุ่มเครื่องราชฯ')", true);
                return;
            }
            ClassClanInsignia ci = new ClassClanInsignia();
            ci.NAME_CLANINSIGNIA_THA = txtInsertClanInsigName.Text;

            if (ci.CheckUseClanInsignia())
            {
                ci.InsertClanInsignia();
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
            ClassClanInsignia ci = new ClassClanInsignia();
            ci.ID_CLANINSIGNIA = id;
            ci.DeleteClanInsignia();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblClanInsigIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblClanInsigIDEdit");
            TextBox txtClanInsigNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtClanInsigNameEdit");

            ClassClanInsignia ci = new ClassClanInsignia(Convert.ToInt32(lblClanInsigIDEdit.Text),
                txtClanInsigNameEdit.Text);

            if (ci.CheckUseClanInsignia())
            {
                ci.UpdateClanInsignia();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อกลุ่มเครื่องราชฯ " + DataBinder.Eval(e.Row.DataItem, "NAME_CLANINSIGNIA_THA") + " ใช่ไหม ?');");
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
        protected void myGridViewClanInsig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelClanInsig_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassClanInsignia ci = new ClassClanInsignia();
            DataTable dt = ci.GetClanInsignia("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchClanInsig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchClanInsigName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassClanInsignia ci = new ClassClanInsignia();
                DataTable dt = ci.GetClanInsignia(txtSearchClanInsigName.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassClanInsignia ci = new ClassClanInsignia();
            DataTable dt = ci.GetClanInsignia("");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}