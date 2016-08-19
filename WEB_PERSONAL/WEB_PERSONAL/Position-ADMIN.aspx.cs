using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL
{
    public partial class nent_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
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
                txtSearchPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertPositionID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                ddlShowSearchPositionSTID();
                ddlShowInsertPositionSTID();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["POSITION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["POSITION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPosition pg = new ClassPosition();
            DataTable dt = pg.GetPosition("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchPositionID.Text)) {
                ClassPosition pg = new ClassPosition();
                DataTable dt = pg.GetPosition(txtSearchPositionID.Text, "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (!string.IsNullOrEmpty(txtSearchPositionName.Text))
            {
                ClassPosition pg = new ClassPosition();
                DataTable dt = pg.GetPosition("", txtSearchPositionName.Text, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchPositionSTID.SelectedIndex != 0)
            {
                ClassPosition pg = new ClassPosition();
                DataTable dt = pg.GetPosition("" ,"", ddlSearchPositionSTID.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        private void ClearData()
        {
            txtSearchPositionID.Text = "";
            txtSearchPositionName.Text = "";
            ddlSearchPositionSTID.SelectedIndex = 0;
            txtInsertPositionID.Text = "";
            txtInsertPositionName.Text = "";
            ddlInsertPositionSTID.SelectedIndex = 0;
        }

        private void ddlShowSearchPositionSTID()
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
                        ddlSearchPositionSTID.DataSource = dt;
                        ddlSearchPositionSTID.DataValueField = "ST_ID";
                        ddlSearchPositionSTID.DataTextField = "ST_NAME";
                        ddlSearchPositionSTID.DataBind();
                        sqlConn.Close();

                        ddlSearchPositionSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertPositionSTID()
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
                        ddlInsertPositionSTID.DataSource = dt;
                        ddlInsertPositionSTID.DataValueField = "ST_ID";
                        ddlInsertPositionSTID.DataTextField = "ST_NAME";
                        ddlInsertPositionSTID.DataBind();
                        sqlConn.Close();

                        ddlInsertPositionSTID.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertPositionID.Text)) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสระดับ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertPositionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับ')", true);
                return;
            }
            if (ddlInsertPositionSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ประเภทตำแหน่ง')", true);
                return;
            }
            ClassPosition pg = new ClassPosition();
            pg.ID = txtInsertPositionID.Text;
            pg.NAME = txtInsertPositionName.Text;
            pg.ST_ID = ddlInsertPositionSTID.SelectedValue;

            if (pg.CheckUsePositionID())
            {
                pg.InsertPosition();
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
            if (txtSearchPositionID.Text != "" || txtSearchPositionName.Text != "" || ddlSearchPositionSTID.SelectedIndex != 0)
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
            if (txtSearchPositionID.Text != "" || txtSearchPositionName.Text != "" || ddlSearchPositionSTID.SelectedIndex != 0)
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
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            ClassPosition pg = new ClassPosition();
            pg.ID = id;
            pg.DeletePosition();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchPositionID.Text != "" || txtSearchPositionName.Text != "" || ddlSearchPositionSTID.SelectedIndex != 0)
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
            TextBox txtPositionIDEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPositionIDEdit");
            TextBox txtPositionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPositionNameEdit");
            DropDownList ddlSTIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSTIDEdit");

            ClassPosition pg = new ClassPosition(txtPositionIDEdit.Text, txtPositionNameEdit.Text, ddlSTIDEdit.SelectedValue);

            if (pg.CheckUsePositionID())
            {
                pg.UpdatePosition();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับ " + DataBinder.Eval(e.Row.DataItem, "NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    TextBox txt = (TextBox)e.Row.FindControl("txtPositionIDEdit");
                    txt.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlSTIDEdit = (DropDownList)e.Row.FindControl("ddlSTIDEdit");

                            sqlCmd1.CommandText = "select * from TB_STAFF";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlSTIDEdit.DataSource = dt;
                            ddlSTIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ST_ID").ToString();
                            ddlSTIDEdit.DataValueField = "ST_ID";
                            ddlSTIDEdit.DataTextField = "ST_NAME";
                            ddlSTIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlSTIDEdit.Items.Insert(0, new ListItem("--ตำแหน่งประเภท--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPosition pg = new ClassPosition();
            DataTable dt = pg.GetPosition("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchPositionID.Text) && string.IsNullOrEmpty(txtSearchPositionName.Text) && ddlSearchPositionSTID.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchPositionID.Text)) {
                    ClassPosition pg = new ClassPosition();
                    DataTable dt = pg.GetPosition(txtSearchPositionID.Text, "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (!string.IsNullOrEmpty(txtSearchPositionName.Text)) {
                    ClassPosition pg = new ClassPosition();
                    DataTable dt = pg.GetPosition("", txtSearchPositionName.Text, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchPositionSTID.SelectedIndex != 0) {
                    ClassPosition pg = new ClassPosition();
                    DataTable dt = pg.GetPosition("", "", ddlSearchPositionSTID.SelectedValue);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPosition pg = new ClassPosition();
            DataTable dt = pg.GetPosition("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}