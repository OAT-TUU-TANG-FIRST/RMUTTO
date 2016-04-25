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
    public partial class Permanent_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchPermaSTID();
                ddlShowInsertPermaSTID();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["PERMAPOSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PERMAPOSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionPermanent pg = new ClassPositionPermanent();
            DataTable dt = pg.GetPositionPermanent("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchPermaPositionName.Text))
            {
                ClassPositionPermanent pg = new ClassPositionPermanent();
                DataTable dt = pg.GetPositionPermanent(txtSearchPermaPositionName.Text, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchPermaSTID.SelectedIndex != 0)
            {
                ClassPositionPermanent pg = new ClassPositionPermanent();
                DataTable dt = pg.GetPositionPermanent("", ddlSearchPermaSTID.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        private void ClearData()
        {
            txtSearchPermaPositionName.Text = "";
            ddlSearchPermaSTID.SelectedIndex = 0;
            txtInsertPermaPositionName.Text = "";
            ddlInsertPermaSTID.SelectedIndex = 0;
        }

        private void ddlShowSearchPermaSTID()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFF";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchPermaSTID.DataSource = dt;
                        ddlSearchPermaSTID.DataValueField = "ST_ID";
                        ddlSearchPermaSTID.DataTextField = "ST_NAME";
                        ddlSearchPermaSTID.DataBind();
                        sqlConn.Close();

                        ddlSearchPermaSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertPermaSTID()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFF";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertPermaSTID.DataSource = dt;
                        ddlInsertPermaSTID.DataValueField = "ST_ID";
                        ddlInsertPermaSTID.DataTextField = "ST_NAME";
                        ddlInsertPermaSTID.DataBind();
                        sqlConn.Close();

                        ddlInsertPermaSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void btnSubmitPermaPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertPermaPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับลูกจ้าง')", true);
                return;
            }
            if (ddlInsertPermaSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทตำแหน่ง')", true);
                return;
            }
            ClassPositionPermanent pg = new ClassPositionPermanent();
            pg.NAME = txtInsertPermaPositionName.Text;
            pg.ST_ID = ddlInsertPermaSTID.SelectedValue;

            if (pg.CheckUsePositionPermanentName())
            {
                pg.InsertPositionPermanent();
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
            if (txtSearchPermaPositionName.Text != "" || ddlSearchPermaSTID.SelectedIndex != 0)
            {
                GridView1.EditIndex = e.NewEditIndex; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = e.NewEditIndex; ;
                BindData();
            }
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            if (txtSearchPermaPositionName.Text != "" || ddlSearchPermaSTID.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1;
                BindData();
            }
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassPositionPermanent pg = new ClassPositionPermanent();
            pg.ID = id;
            pg.DeletePositionPermanent();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchPermaPositionName.Text != "" || ddlSearchPermaSTID.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1;
                BindData();
            }
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPermaPositionIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPermaPositionIDEdit");
            TextBox txtPermaPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPermaPositionNameEdit");
            DropDownList ddlPermaSTIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPermaSTIDEdit");

            ClassPositionPermanent pg = new ClassPositionPermanent(Convert.ToInt32(lblPermaPositionIDEdit.Text), txtPermaPositionNameEdit.Text, ddlPermaSTIDEdit.SelectedValue);

            if (pg.CheckUsePositionPermanentName())
            {
                pg.UpdatePositionPermanent();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับลูกจ้าง " + DataBinder.Eval(e.Row.DataItem, "NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlPermaSTIDEdit = (DropDownList)e.Row.FindControl("ddlPermaSTIDEdit");

                            sqlCmd1.CommandText = "select * from TB_STAFF";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPermaSTIDEdit.DataSource = dt;
                            ddlPermaSTIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ST_ID").ToString();
                            ddlPermaSTIDEdit.DataValueField = "ST_ID";
                            ddlPermaSTIDEdit.DataTextField = "ST_NAME";
                            ddlPermaSTIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlPermaSTIDEdit.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
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
        }
        protected void myGridViewPermaPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPermaPosition_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionPermanent pg = new ClassPositionPermanent();
            DataTable dt = pg.GetPositionPermanent("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPermaPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPermaPositionName.Text) && ddlSearchPermaSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchPermaPositionName.Text))
                {
                    ClassPositionPermanent pg = new ClassPositionPermanent();
                    DataTable dt = pg.GetPositionPermanent(txtSearchPermaPositionName.Text, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchPermaSTID.SelectedIndex != 0)
                {
                    ClassPositionPermanent pg = new ClassPositionPermanent();
                    DataTable dt = pg.GetPositionPermanent("", ddlSearchPermaSTID.SelectedValue);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionPermanent pg = new ClassPositionPermanent();
            DataTable dt = pg.GetPositionPermanent("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}