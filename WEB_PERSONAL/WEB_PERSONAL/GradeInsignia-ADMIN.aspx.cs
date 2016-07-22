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
    public partial class GradeInsignia_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchClanInsig();
                ddlShowInsertClanInsig();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["GRADINSIG"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["GRADINSIG"] = data;
        }

        #endregion

        void BindData()
        {
            ClassGradeInsignia gi = new ClassGradeInsignia();
            DataTable dt = gi.GetGradeInsignia("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchGradeInsigName.Text))
            {
                ClassGradeInsignia gi1 = new ClassGradeInsignia();
                DataTable dt1 = gi1.GetGradeInsignia(txtSearchGradeInsigName.Text, "", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (!string.IsNullOrEmpty(txtSearchGradeInsigNameSmall.Text))
            {
                ClassGradeInsignia gi2 = new ClassGradeInsignia();
                DataTable dt1 = gi2.GetGradeInsignia("", txtSearchGradeInsigNameSmall.Text, "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (ddlSearchClanInsig.SelectedIndex != 0)
            {
                ClassGradeInsignia gi3 = new ClassGradeInsignia();
                DataTable dt2 = gi3.GetGradeInsignia("", "", ddlSearchClanInsig.SelectedValue);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
        }

        private void ddlShowSearchClanInsig()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CLANINSIGNIA";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchClanInsig.DataSource = dt;
                        ddlSearchClanInsig.DataValueField = "ID_CLANINSIGNIA";
                        ddlSearchClanInsig.DataTextField = "NAME_CLANINSIGNIA_THA";
                        ddlSearchClanInsig.DataBind();
                        sqlConn.Close();

                        ddlSearchClanInsig.Items.Insert(0, new ListItem("--ชื่อกลุ่มเครื่องราชฯ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertClanInsig()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CLANINSIGNIA";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertClanInsig.DataSource = dt;
                        ddlInsertClanInsig.DataValueField = "ID_CLANINSIGNIA";
                        ddlInsertClanInsig.DataTextField = "NAME_CLANINSIGNIA_THA";
                        ddlInsertClanInsig.DataBind();
                        sqlConn.Close();

                        ddlInsertClanInsig.Items.Insert(0, new ListItem("--ชื่อกลุ่มเครื่องราชฯ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchGradeInsigName.Text = "";
            txtSearchGradeInsigNameSmall.Text = "";
            ddlSearchClanInsig.SelectedIndex = 0;
            txtInsertGradeInsigName.Text = "";
            txtInsertGradeInsigNameSmall.Text = "";
            ddlInsertClanInsig.SelectedIndex = 0;
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertGradeInsigName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อเครื่องราชฯ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertGradeInsigNameSmall.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อย่อเครื่องราชฯ')", true);
                return;
            }
            if (ddlInsertClanInsig.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก ชื่อกลุ่มเครื่องราชฯ')", true);
                return;
            }
            ClassGradeInsignia gi = new ClassGradeInsignia();
            gi.NAME_GRADEINSIGNIA_THA = txtInsertGradeInsigName.Text;
            gi.ABBREVIATIONS_THA = txtInsertGradeInsigNameSmall.Text;
            gi.ID_CLANINSIGNIA = Convert.ToInt32(ddlInsertClanInsig.SelectedValue);

            if (gi.CheckUseGradeInsignia())
            {
                gi.InsertGradeInsignia();
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
            if (txtSearchGradeInsigName.Text != "" || txtSearchGradeInsigNameSmall.Text != "" || ddlSearchClanInsig.SelectedIndex != 0)
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
            if (txtSearchGradeInsigName.Text != "" || txtSearchGradeInsigNameSmall.Text != "" || ddlSearchClanInsig.SelectedIndex != 0)
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
            ClassGradeInsignia gi = new ClassGradeInsignia();
            gi.ID_GRADEINSIGNIA = id;
            gi.DeleteGradeInsignia();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchGradeInsigName.Text != "" || txtSearchGradeInsigNameSmall.Text != "" || ddlSearchClanInsig.SelectedIndex != 0)
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
            Label lblGradeInsigIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGradeInsigIDEdit");
            TextBox txtGradeInsigNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradeInsigNameEdit");
            TextBox txtGradeInsigNameSmallEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGradeInsigNameSmallEdit");
            DropDownList ddlClanInsigIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlClanInsigIDEdit");

            ClassGradeInsignia gi = new ClassGradeInsignia(Convert.ToInt32(lblGradeInsigIDEdit.Text)
                , txtGradeInsigNameEdit.Text
                , txtGradeInsigNameSmallEdit.Text
                , Convert.ToInt32(ddlClanInsigIDEdit.SelectedValue));

            if (gi.CheckUseGradeInsignia())
            {
                gi.UpdateGradeInsignia();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อเครื่องราชฯ " + DataBinder.Eval(e.Row.DataItem, "NAME_GRADEINSIGNIA_THA") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlClanInsigIDEdit = (DropDownList)e.Row.FindControl("ddlClanInsigIDEdit");

                            sqlCmd1.CommandText = "select * from TB_CLANINSIGNIA";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlClanInsigIDEdit.DataSource = dt;
                            ddlClanInsigIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ID_CLANINSIGNIA").ToString();
                            ddlClanInsigIDEdit.DataValueField = "ID_CLANINSIGNIA";
                            ddlClanInsigIDEdit.DataTextField = "NAME_CLANINSIGNIA_THA";
                            ddlClanInsigIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlClanInsigIDEdit.Items.Insert(0, new ListItem("--ชื่อกลุ่มเครื่องราชฯ--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewGradeInsig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradeInsignia gi = new ClassGradeInsignia();
            DataTable dt = gi.GetGradeInsignia("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchGradeInsigName.Text) && string.IsNullOrEmpty(txtSearchGradeInsigNameSmall.Text) && ddlSearchClanInsig.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchGradeInsigName.Text))
                {
                    ClassGradeInsignia gi1 = new ClassGradeInsignia();
                    DataTable dt1 = gi1.GetGradeInsignia(txtSearchGradeInsigName.Text, "", "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (!string.IsNullOrEmpty(txtSearchGradeInsigNameSmall.Text))
                {
                    ClassGradeInsignia gi2 = new ClassGradeInsignia();
                    DataTable dt1 = gi2.GetGradeInsignia("", txtSearchGradeInsigNameSmall.Text, "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (ddlSearchClanInsig.SelectedIndex != 0)
                {
                    ClassGradeInsignia gi3 = new ClassGradeInsignia();
                    DataTable dt2 = gi3.GetGradeInsignia("", "", ddlSearchClanInsig.SelectedValue);
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassGradeInsignia gi = new ClassGradeInsignia();
            DataTable dt = gi.GetGradeInsignia("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}

