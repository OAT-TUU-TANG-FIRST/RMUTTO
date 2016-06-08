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
    public partial class PosiInsigDegree_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchPosiInsigGover();
                ddlShowInsertPosiInsigGover();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["PosiInsigDegree"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PosiInsigDegree"] = data;
        }

        #endregion

        void BindData()
        {
            ClassPositionInsigDegree f = new ClassPositionInsigDegree();
            DataTable dt = f.GetPositionInsigDegree("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchPosiInsigDegreeName.Text))
            {
                ClassPositionInsigDegree f = new ClassPositionInsigDegree();
                DataTable dt = f.GetPositionInsigDegree(txtSearchPosiInsigDegreeName.Text, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchPosiInsigGover.SelectedIndex != 0)
            {
                ClassPositionInsigDegree f = new ClassPositionInsigDegree();
                DataTable dt = f.GetPositionInsigDegree("", ddlSearchPosiInsigGover.SelectedValue);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        private void ddlShowSearchPosiInsigGover()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_GOVER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchPosiInsigGover.DataSource = dt;
                        ddlSearchPosiInsigGover.DataValueField = "PIG_ID";
                        ddlSearchPosiInsigGover.DataTextField = "PIG_NAME";
                        ddlSearchPosiInsigGover.DataBind();
                        sqlConn.Close();

                        ddlSearchPosiInsigGover.Items.Insert(0, new ListItem("--ชื่่อระดับตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertPosiInsigGover()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION_INSIG_GOVER";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertPosiInsigGover.DataSource = dt;
                        ddlInsertPosiInsigGover.DataValueField = "PIG_ID";
                        ddlInsertPosiInsigGover.DataTextField = "PIG_NAME";
                        ddlInsertPosiInsigGover.DataBind();
                        sqlConn.Close();

                        ddlInsertPosiInsigGover.Items.Insert(0, new ListItem("--ชื่่อระดับตำแหน่งประเภท--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchPosiInsigDegreeName.Text = "";
            ddlSearchPosiInsigGover.SelectedIndex = 0;
            txtInsertPosiInsigDegreeName.Text = "";
            ddlInsertPosiInsigGover.SelectedIndex = 0;
        }

        protected void btnSubmitPosiInsigDegree_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertPosiInsigDegreeName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระดับตำแหน่ง')", true);
                return;
            }

            if (ddlInsertPosiInsigGover.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ชื่่อระดับตำแหน่งประเภท')", true);
                return;
            }
            ClassPositionInsigDegree f = new ClassPositionInsigDegree();
            f.PID_NAME = txtInsertPosiInsigDegreeName.Text;
            f.PIG_ID = Convert.ToInt32(ddlInsertPosiInsigGover.SelectedValue);

            if (f.CheckUsePositionInsigDegreeName())
            {
                f.InsertPositionInsigDegree();
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
            if (txtSearchPosiInsigDegreeName.Text != "" || ddlSearchPosiInsigGover.SelectedIndex != 0)
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
            if (txtSearchPosiInsigDegreeName.Text != "" || ddlSearchPosiInsigGover.SelectedIndex != 0)
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
            ClassPositionInsigDegree f = new ClassPositionInsigDegree();
            f.PID_ID = id;
            f.DeletePositionInsigDegree();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchPosiInsigDegreeName.Text != "" || ddlSearchPosiInsigGover.SelectedIndex != 0)
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
            Label lblPosiInsigDegreeIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPosiInsigDegreeIDEdit");
            TextBox txtPosiInsigDegreeNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPosiInsigDegreeNameEdit");
            DropDownList ddlPosiInsigGoverIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPosiInsigGoverIDEdit");

            ClassPositionInsigDegree f = new ClassPositionInsigDegree(Convert.ToInt32(lblPosiInsigDegreeIDEdit.Text)
                , txtPosiInsigDegreeNameEdit.Text
                , Convert.ToInt32(ddlPosiInsigGoverIDEdit.SelectedValue));

            if (f.CheckUsePositionInsigDegreeName())
            {
                f.UpdatePositionInsigDegree();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อระดับตำแหน่ง " + DataBinder.Eval(e.Row.DataItem, "PID_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlPosiInsigGoverIDEdit = (DropDownList)e.Row.FindControl("ddlPosiInsigGoverIDEdit");

                            sqlCmd1.CommandText = "select * from TB_POSITION_INSIG_GOVER";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPosiInsigGoverIDEdit.DataSource = dt;
                            ddlPosiInsigGoverIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PIG_ID").ToString();
                            ddlPosiInsigGoverIDEdit.DataValueField = "PIG_ID";
                            ddlPosiInsigGoverIDEdit.DataTextField = "PIG_NAME";
                            ddlPosiInsigGoverIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlPosiInsigGoverIDEdit.Items.Insert(0, new ListItem("--ชื่่อระดับตำแหน่งประเภท--", "0"));
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
        protected void myGridViewPosiInsigDegree_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPosiInsigDegree_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionInsigDegree f = new ClassPositionInsigDegree();
            DataTable dt = f.GetPositionInsigDegree("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPosiInsigDegree_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchPosiInsigDegreeName.Text) && ddlSearchPosiInsigGover.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchPosiInsigDegreeName.Text))
                {
                    ClassPositionInsigDegree f = new ClassPositionInsigDegree();
                    DataTable dt = f.GetPositionInsigDegree(txtSearchPosiInsigDegreeName.Text, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchPosiInsigGover.SelectedIndex != 0)
                {
                    ClassPositionInsigDegree f = new ClassPositionInsigDegree();
                    DataTable dt = f.GetPositionInsigDegree("", ddlSearchPosiInsigGover.SelectedValue);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassPositionInsigDegree f = new ClassPositionInsigDegree();
            DataTable dt = f.GetPositionInsigDegree("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
