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
    public partial class PosiGoverSalary_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchPosiGover();
                ddlShowSearchPosi();
                ddlShowInsertPosiGover();
                ddlShowInsertPosi();
                txtSearchSalMin.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchSalMax.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtSearchSalMinTemp.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertSalMin.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertSalMax.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertSalMinTemp.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["PosiGoverSalary"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["PosiGoverSalary"] = data;
        }

        #endregion

        void BindData()
        {
            ClassSalMinMax smm = new ClassSalMinMax();
            DataTable dt = smm.GetSalMinMax("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (ddlSearchPosiGroup.SelectedIndex != 0)
            {
                ClassSalMinMax smm = new ClassSalMinMax();
                DataTable dt = smm.GetSalMinMax(ddlSearchPosiGroup.SelectedValue, "", "", "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (ddlSearchPosi.SelectedIndex != 0)
            {
                ClassSalMinMax smm = new ClassSalMinMax();
                DataTable dt = smm.GetSalMinMax("", ddlSearchPosi.SelectedValue, "", "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (!string.IsNullOrEmpty(txtSearchSalMin.Text))
            {
                ClassSalMinMax smm = new ClassSalMinMax();
                DataTable dt = smm.GetSalMinMax("", "", txtSearchSalMin.Text, "", "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (!string.IsNullOrEmpty(txtSearchSalMax.Text))
            {
                ClassSalMinMax smm = new ClassSalMinMax();
                DataTable dt = smm.GetSalMinMax("", "", "", txtSearchSalMax.Text, "");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
            if (!string.IsNullOrEmpty(txtSearchSalMin.Text))
            {
                ClassSalMinMax smm = new ClassSalMinMax();
                DataTable dt = smm.GetSalMinMax("", "", "", "", txtSearchSalMinTemp.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }

        }

        private void ddlShowSearchPosiGover()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POS_GOVER_ACADEMIC";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchPosiGroup.DataSource = dt;
                        ddlSearchPosiGroup.DataValueField = "P_ID";
                        ddlSearchPosiGroup.DataTextField = "P_NAME";
                        ddlSearchPosiGroup.DataBind();
                        sqlConn.Close();

                        ddlSearchPosiGroup.Items.Insert(0, new ListItem("--ตำแหน่งกลุ่ม--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertPosiGover()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POS_GOVER_ACADEMIC";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertPosiGroup.DataSource = dt;
                        ddlInsertPosiGroup.DataValueField = "P_ID";
                        ddlInsertPosiGroup.DataTextField = "P_NAME";
                        ddlInsertPosiGroup.DataBind();
                        sqlConn.Close();

                        ddlInsertPosiGroup.Items.Insert(0, new ListItem("--ตำแหน่งกลุ่ม--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowSearchPosi()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchPosi.DataSource = dt;
                        ddlSearchPosi.DataValueField = "ID";
                        ddlSearchPosi.DataTextField = "NAME";
                        ddlSearchPosi.DataBind();
                        sqlConn.Close();

                        ddlSearchPosi.Items.Insert(0, new ListItem("--ตำแหน่ง--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertPosi()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_POSITION";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertPosi.DataSource = dt;
                        ddlInsertPosi.DataValueField = "ID";
                        ddlInsertPosi.DataTextField = "NAME";
                        ddlInsertPosi.DataBind();
                        sqlConn.Close();

                        ddlInsertPosi.Items.Insert(0, new ListItem("--ตำแหน่ง--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            ddlSearchPosiGroup.SelectedIndex = 0;
            ddlSearchPosi.SelectedIndex = 0;
            txtSearchSalMin.Text = "";
            txtSearchSalMax.Text = "";
            txtSearchSalMinTemp.Text = "";
            ddlInsertPosiGroup.SelectedIndex = 0;
            ddlInsertPosi.SelectedIndex = 0;
            txtInsertSalMin.Text = "";
            txtInsertSalMax.Text = "";
            txtInsertSalMinTemp.Text = "";
        }

        protected void btnSubmitPosiGoverSalary_Click(object sender, EventArgs e)
        {
            if (ddlInsertPosiGroup.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่่งกลุ่ม')", true);
                return;
            }
            if (ddlInsertPosi.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ตำแหน่่ง')", true);
                return;
            }
            ClassSalMinMax smm = new ClassSalMinMax();
            smm.P_POS_GOVER_ACADEMIC = Convert.ToInt32(ddlInsertPosiGroup.SelectedValue);
            smm.P_POS_ID = Convert.ToInt32(ddlInsertPosi.SelectedValue);
            smm.P_SAL_MIN = Convert.ToInt32(txtInsertSalMin.Text);
            smm.P_SAL_MAX = Convert.ToInt32(txtInsertSalMax.Text);
            smm.P_SAL_MIN_TEMP = Convert.ToInt32(txtInsertSalMinTemp.Text);

            smm.InsertSalMinMax();
            BindData();
            ClearData();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
        }
    
        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            if (ddlSearchPosiGroup.SelectedIndex != 0 || ddlSearchPosi.SelectedIndex != 0 || txtSearchSalMin.Text != "" || txtSearchSalMax.Text != "" || txtSearchSalMinTemp.Text != "")
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
            if (ddlSearchPosiGroup.SelectedIndex != 0 || ddlSearchPosi.SelectedIndex != 0 || txtSearchSalMin.Text != "" || txtSearchSalMax.Text != "" || txtSearchSalMinTemp.Text != "")
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
            ClassSalMinMax smm = new ClassSalMinMax();
            smm.P_ID = id;
            smm.DeleteSalMinMax();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (ddlSearchPosiGroup.SelectedIndex != 0 || ddlSearchPosi.SelectedIndex != 0 || txtSearchSalMin.Text != "" || txtSearchSalMax.Text != "" || txtSearchSalMinTemp.Text != "")
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
            Label lblPosiGoverSalaryIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPosiGoverSalaryIDEdit");
            DropDownList ddlPosiGoverSalaryGroupEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPosiGoverSalaryGroupEdit");
            DropDownList ddlPosiGoverSalaryEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlPosiGoverSalaryEdit");
            TextBox txtPosiGoverSalaryMinEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPosiGoverSalaryMinEdit");
            TextBox txtPosiGoverSalaryMaxEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPosiGoverSalaryMaxEdit");
            TextBox txtPosiGoverSalaryMinTempEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPosiGoverSalaryMinTempEdit");

            ClassSalMinMax smm = new ClassSalMinMax(Convert.ToInt32(lblPosiGoverSalaryIDEdit.Text)
                , Convert.ToInt32(ddlPosiGoverSalaryGroupEdit.SelectedValue)
                , Convert.ToInt32(ddlPosiGoverSalaryEdit.SelectedValue)
                , Convert.ToInt32(txtPosiGoverSalaryMinEdit.Text)
                , Convert.ToInt32(txtPosiGoverSalaryMaxEdit.Text)
                , Convert.ToInt32(txtPosiGoverSalaryMinTempEdit.Text));

            smm.UpdateSalMinMax();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่ไหม ?");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlPosiGoverSalaryGroupEdit = (DropDownList)e.Row.FindControl("ddlPosiGoverSalaryGroupEdit");

                            sqlCmd1.CommandText = "select * from TB_POS_GOVER_ACADEMIC";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPosiGoverSalaryGroupEdit.DataSource = dt;
                            ddlPosiGoverSalaryGroupEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "P_POS_GOVER_ACADEMIC").ToString();
                            ddlPosiGoverSalaryGroupEdit.DataValueField = "P_ID";
                            ddlPosiGoverSalaryGroupEdit.DataTextField = "P_NAME";
                            ddlPosiGoverSalaryGroupEdit.DataBind();
                            sqlConn1.Close();

                            ddlPosiGoverSalaryGroupEdit.Items.Insert(0, new ListItem("--ตำแหน่งกลุ่่ม--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }

                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlPosiGoverSalaryEdit = (DropDownList)e.Row.FindControl("ddlPosiGoverSalaryEdit");

                            sqlCmd1.CommandText = "select * from TB_POSITION";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlPosiGoverSalaryEdit.DataSource = dt;
                            ddlPosiGoverSalaryEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "P_POS_ID").ToString();
                            ddlPosiGoverSalaryEdit.DataValueField = "ID";
                            ddlPosiGoverSalaryEdit.DataTextField = "NAME";
                            ddlPosiGoverSalaryEdit.DataBind();
                            sqlConn1.Close();

                            ddlPosiGoverSalaryEdit.Items.Insert(0, new ListItem("--ตำแหน่ง--", "0"));
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
        protected void myGridViewPosiGoverSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelPosiGoverSalary_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassSalMinMax smm = new ClassSalMinMax();
            DataTable dt = smm.GetSalMinMax("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchPosiGoverSalary_Click(object sender, EventArgs e)
        {

            if (ddlSearchPosiGroup.SelectedIndex == 0 && ddlSearchPosi.SelectedIndex == 0 && txtSearchSalMin.Text == "" && txtSearchSalMax.Text == "" && txtSearchSalMinTemp.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (ddlSearchPosiGroup.SelectedIndex != 0)
                {
                    ClassSalMinMax smm = new ClassSalMinMax();
                    DataTable dt = smm.GetSalMinMax(ddlSearchPosiGroup.SelectedValue, "", "", "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (ddlSearchPosi.SelectedIndex != 0)
                {
                    ClassSalMinMax smm = new ClassSalMinMax();
                    DataTable dt = smm.GetSalMinMax("", ddlSearchPosi.SelectedValue, "", "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (!string.IsNullOrEmpty(txtSearchSalMin.Text))
                {
                    ClassSalMinMax smm = new ClassSalMinMax();
                    DataTable dt = smm.GetSalMinMax("", "", txtSearchSalMin.Text, "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (!string.IsNullOrEmpty(txtSearchSalMax.Text))
                {
                    ClassSalMinMax smm = new ClassSalMinMax();
                    DataTable dt = smm.GetSalMinMax("", "", "", txtSearchSalMax.Text, "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
                if (!string.IsNullOrEmpty(txtSearchSalMin.Text))
                {
                    ClassSalMinMax smm = new ClassSalMinMax();
                    DataTable dt = smm.GetSalMinMax("", "", "", "", txtSearchSalMinTemp.Text);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassSalMinMax smm = new ClassSalMinMax();
            DataTable dt = smm.GetSalMinMax("", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
