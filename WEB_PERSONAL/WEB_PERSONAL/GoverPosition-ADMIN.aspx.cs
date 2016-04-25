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
    public partial class GoverPosition_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchGoverSTID();
                ddlShowInsertGoverSTID();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["GOVERPOSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GOVERPOSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchGoverPositionName.Text))
            {
                ClassPositionGoverment pg = new ClassPositionGoverment();
                DataTable dt = pg.GetPositionGoverment(txtSearchGoverPositionName.Text, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchGoverSTID.SelectedIndex != 0)
            {
                ClassPositionGoverment pg = new ClassPositionGoverment();
                DataTable dt = pg.GetPositionGoverment("", ddlSearchGoverSTID.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        private void ClearData()
        {
            txtSearchGoverPositionName.Text = "";
            ddlSearchGoverSTID.SelectedIndex = 0;
            txtInsertGoverPositionName.Text = "";
            ddlInsertGoverSTID.SelectedIndex = 0;
        }

        private void ddlShowSearchGoverSTID()
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
                        ddlSearchGoverSTID.DataSource = dt;
                        ddlSearchGoverSTID.DataValueField = "ST_ID";
                        ddlSearchGoverSTID.DataTextField = "ST_NAME";
                        ddlSearchGoverSTID.DataBind();
                        sqlConn.Close();

                        ddlSearchGoverSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertGoverSTID()
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
                        ddlInsertGoverSTID.DataSource = dt;
                        ddlInsertGoverSTID.DataValueField = "ST_ID";
                        ddlInsertGoverSTID.DataTextField = "ST_NAME";
                        ddlInsertGoverSTID.DataBind();
                        sqlConn.Close();

                        ddlInsertGoverSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void btnSubmitGoverPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGoverPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับข้าราชการ')", true);
                return;
            }
            if (ddlInsertGoverSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทตำแหน่ง')", true);
                return;
            }
            ClassPositionGoverment pg = new ClassPositionGoverment();
            pg.NAME = txtInsertGoverPositionName.Text;
            pg.ST_ID = ddlInsertGoverSTID.SelectedValue;

            if (pg.CheckUsePositionGovermentName())
            {
                pg.InsertPositionGoverment();
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
            if(txtSearchGoverPositionName.Text != "" || ddlSearchGoverSTID.SelectedIndex != 0)
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
            if (txtSearchGoverPositionName.Text != "" || ddlSearchGoverSTID.SelectedIndex != 0)
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
            ClassPositionGoverment pg = new ClassPositionGoverment();
            pg.ID = id;
            pg.DeletePositionGoverment();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchGoverPositionName.Text != "" || ddlSearchGoverSTID.SelectedIndex != 0)
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
            Label lblGoverPositionIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGoverPositionIDEdit");
            TextBox txtGoverPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGoverPositionNameEdit");
            DropDownList ddlGoverSTIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGoverSTIDEdit");

            ClassPositionGoverment pg = new ClassPositionGoverment(Convert.ToInt32(lblGoverPositionIDEdit.Text), txtGoverPositionNameEdit.Text, ddlGoverSTIDEdit.SelectedValue);

            if (pg.CheckUsePositionGovermentName())
            {
                pg.UpdatePositionGoverment();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับข้าราชการ " + DataBinder.Eval(e.Row.DataItem, "NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlGoverSTIDEdit = (DropDownList)e.Row.FindControl("ddlGoverSTIDEdit");

                            sqlCmd1.CommandText = "select * from TB_STAFF";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlGoverSTIDEdit.DataSource = dt;
                            ddlGoverSTIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ST_ID").ToString();
                            ddlGoverSTIDEdit.DataValueField = "ST_ID";
                            ddlGoverSTIDEdit.DataTextField = "ST_NAME";
                            ddlGoverSTIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlGoverSTIDEdit.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
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
        protected void myGridViewGoverPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelGoverPosition_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchGoverPosition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchGoverPositionName.Text) && ddlSearchGoverSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchGoverPositionName.Text))
                {
                    ClassPositionGoverment pg = new ClassPositionGoverment();
                    DataTable dt = pg.GetPositionGoverment(txtSearchGoverPositionName.Text, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchGoverSTID.SelectedIndex != 0)
                {
                    ClassPositionGoverment pg = new ClassPositionGoverment();
                    DataTable dt = pg.GetPositionGoverment("", ddlSearchGoverSTID.SelectedValue);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionGoverment pg = new ClassPositionGoverment();
            DataTable dt = pg.GetPositionGoverment("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}