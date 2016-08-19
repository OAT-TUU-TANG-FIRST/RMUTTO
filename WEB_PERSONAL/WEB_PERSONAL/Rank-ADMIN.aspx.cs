using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL
{
    public partial class Rank_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person ps = PersonnelSystem.GetPersonnelSystem(this).LoginPerson;
            if (ps.Permission != 2)
            {
                Response.Redirect("NoPermission.aspx");
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["RANK"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["RANK"] = data;
        }

        #endregion

        void BindData()
        {
            ClassRank r = new ClassRank();
            DataTable dt = r.GetRank("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            ClassRank r = new ClassRank();
            DataTable dt = r.GetRank(txtSearchRankNameFull.Text, txtSearchRankNameSmall.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchRankNameFull.Text = "";
            txtSearchRankNameSmall.Text = "";
            txtInsertRankNameFull.Text = "";
            txtInsertRankNameSmall.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertRankNameFull.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อยศเต็ม')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertRankNameSmall.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อยศย่อ')", true);
                return;
            }
            ClassRank r = new ClassRank();
            r.RANK_NAME_TH = txtInsertRankNameFull.Text;
            r.RANK_NAME_TH_MIN = txtInsertRankNameSmall.Text;

            if (r.CheckUseRankNameInsert())
            {
                r.InsertRank();
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
            ClassRank r = new ClassRank();
            r.RANK_ID = id;
            r.DeleteRank();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblRankIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblRankIDEdit");
            TextBox txtRankNameFullEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRankNameFullEdit");
            TextBox txtRankNameSmallEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRankNameSmallEdit");

            ClassRank r = new ClassRank(Convert.ToInt32(lblRankIDEdit.Text)
                , txtRankNameFullEdit.Text
                , txtRankNameSmallEdit.Text);

            if (r.CheckUseRankNameUpdate())
            {
                r.UpdateRank();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อยศ " + DataBinder.Eval(e.Row.DataItem, "RANK_NAME_TH") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewRank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassRank r = new ClassRank();
            DataTable dt = r.GetRank("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchRankNameFull.Text) && string.IsNullOrEmpty(txtSearchRankNameSmall.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassRank r = new ClassRank();
                DataTable dt = r.GetRank(txtSearchRankNameFull.Text, txtSearchRankNameSmall.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassRank r = new ClassRank();
            DataTable dt = r.GetRank("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}