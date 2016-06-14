using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class INSG_Qualified_Detail_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
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
            return (DataTable)ViewState["INSGDA"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["INSGDA"] = data;
        }

        #endregion

        void BindData()
        {
            ClassInsigUserGet iug = new ClassInsigUserGet();
            DataTable dt = iug.GetInsigUserGet("", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; ;
            BindData();
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassInsigUserGet iug = new ClassInsigUserGet();
            iug.IUG_ID = id;
            iug.DeleteInsigUserGet();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblQDAIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblQDAIDEdit");
            Label lblCitizenEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCitizenEdit");
            DropDownList ddlNameInsigEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlNameInsigEdit");
            TextBox txtDateGetInsigEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDateGetInsigEdit");
            Label lblStatusEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblStatusEdit");
            DropDownList ddlPositionEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPositionEdit");
            TextBox txtSalaryEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSalaryEdit");
            TextBox txtRefEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRefEdit");

            ClassInsigUserGet iug = new ClassInsigUserGet(Convert.ToInt32(lblQDAIDEdit.Text)
                , lblCitizenEdit.Text
                , Convert.ToInt32(ddlNameInsigEdit.SelectedValue)
                , Util.ODT(txtDateGetInsigEdit.Text)
                , Convert.ToInt32(lblStatusEdit.Text)
                , ddlPositionEdit.SelectedValue
                , Convert.ToInt32(txtSalaryEdit.Text)
                , txtRefEdit.Text);

            iug.UpdateInsigUserGet();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlNameInsigEdit = (DropDownList)e.Row.FindControl("ddlNameInsigEdit");

                            sqlCmd1.CommandText = "select * from INS_GRADEINSIGNIA";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlNameInsigEdit.DataSource = dt;
                            ddlNameInsigEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "IUG_INSIG_ID").ToString();
                            ddlNameInsigEdit.DataValueField = "ID_GRADEINSIGNIA";
                            ddlNameInsigEdit.DataTextField = "NAME_GRADEINSIGNIA_THA";
                            ddlNameInsigEdit.DataBind();
                            sqlConn1.Close();

                            ddlNameInsigEdit.Items.Insert(0, new ListItem("--ชั้นเครื่่องราช--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlPositionEdit = (DropDownList)e.Row.FindControl("ddlPositionEdit");

                            sqlCmd1.CommandText = "select * from TB_POSITION";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPositionEdit.DataSource = dt;
                            ddlPositionEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "IUG_POSITION").ToString();
                            ddlPositionEdit.DataValueField = "ID";
                            ddlPositionEdit.DataTextField = "NAME";
                            ddlPositionEdit.DataBind();
                            sqlConn1.Close();

                            ddlPositionEdit.Items.Insert(0, new ListItem("--ตำแหน่ง--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
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
        protected void myGridViewQDA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPersonID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                ClassInsigUserGet iug = new ClassInsigUserGet();
                DataTable dt = iug.GetInsigUserGet(txtSearchPersonID.Text, "", "", "", "", "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            txtSearchPersonID.Text = "";
            ClassInsigUserGet iug = new ClassInsigUserGet();
            DataTable dt = iug.GetInsigUserGet("", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}