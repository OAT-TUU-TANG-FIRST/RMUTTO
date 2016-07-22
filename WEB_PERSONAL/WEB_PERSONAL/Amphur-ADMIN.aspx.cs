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
    public partial class Amphur_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchProvince();
                ddlShowInsertProvince();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["AMPHUR"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["AMPHUR"] = data;
        }

        #endregion

        void BindData()
        {
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchAmphurTH.Text))
            {
                ClassAmphur a1 = new ClassAmphur();
                DataTable dt1 = a1.GetAmphur(txtSearchAmphurTH.Text, "", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (!string.IsNullOrEmpty(txtSearchAmphurEN.Text))
            {
                ClassAmphur a2 = new ClassAmphur();
                DataTable dt2 = a2.GetAmphur("", txtSearchAmphurEN.Text, "");
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
            if (ddlSearchProvince.SelectedIndex != 0)
            {
                ClassAmphur a3 = new ClassAmphur();
                DataTable dt3 = a3.GetAmphur("", "", ddlSearchProvince.SelectedValue);
                GridView1.DataSource = dt3;
                GridView1.DataBind();
                SetViewState(dt3);
            }
        }

        private void ddlShowSearchProvince()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchProvince.DataSource = dt;
                        ddlSearchProvince.DataValueField = "PROVINCE_ID";
                        ddlSearchProvince.DataTextField = "PROVINCE_TH";
                        ddlSearchProvince.DataBind();
                        sqlConn.Close();

                        ddlSearchProvince.Items.Insert(0, new ListItem("--จังหวัด--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertProvince()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROVINCE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertProvince.DataSource = dt;
                        ddlInsertProvince.DataValueField = "PROVINCE_ID";
                        ddlInsertProvince.DataTextField = "PROVINCE_TH";
                        ddlInsertProvince.DataBind();
                        sqlConn.Close();

                        ddlInsertProvince.Items.Insert(0, new ListItem("--จังหวัด--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchAmphurTH.Text = "";
            txtSearchAmphurEN.Text = "";
            ddlSearchProvince.SelectedIndex = 0;
            txtInsertAmphurTH.Text = "";
            txtInsertAmphurEN.Text = "";
            ddlInsertProvince.SelectedIndex = 0;
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertAmphurTH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่ออำเภอภาษาไทย')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertAmphurEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่ออำเภอภาษาอังกฤษ')", true);
                return;
            }
            if (ddlInsertProvince.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก จังหวัด')", true);
                return;
            }
            ClassAmphur a = new ClassAmphur();
            a.AMPHUR_TH = txtInsertAmphurTH.Text;
            a.AMPHUR_EN = txtInsertAmphurEN.Text;
            a.PROVINCE_ID = Convert.ToInt32(ddlInsertProvince.SelectedValue);

            if (a.CheckUseAmphurName())
            {
                a.InsertAmphur();
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
            if (txtSearchAmphurTH.Text != "" || txtSearchAmphurEN.Text != "" || ddlSearchProvince.SelectedIndex != 0)
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
            if (txtSearchAmphurTH.Text != "" || txtSearchAmphurEN.Text != "" || ddlSearchProvince.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1 ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1 ;
                BindData();
            }
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassAmphur a = new ClassAmphur();
            a.AMPHUR_ID = id;
            a.DeleteAmphur();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchAmphurTH.Text != "" || txtSearchAmphurEN.Text != "" || ddlSearchProvince.SelectedIndex != 0)
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

            Label lblAmphurIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblAmphurIDEdit");
            TextBox txtAmphurTHEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurTHEdit");
            TextBox txtAmphurENEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAmphurENEdit");
            DropDownList ddlProvinceIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlProvinceIDEdit");

            ClassAmphur a = new ClassAmphur(Convert.ToInt32(lblAmphurIDEdit.Text)
                , txtAmphurTHEdit.Text
                , txtAmphurENEdit.Text
                , Convert.ToInt32(ddlProvinceIDEdit.SelectedValue));

            if (a.CheckUseAmphurName())
            {
                a.UpdateAmphur();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่ออำเภอ " + DataBinder.Eval(e.Row.DataItem, "AMPHUR_TH") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlProvinceIDEdit = (DropDownList)e.Row.FindControl("ddlProvinceIDEdit");

                            sqlCmd1.CommandText = "select * from TB_PROVINCE";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlProvinceIDEdit.DataSource = dt;
                            ddlProvinceIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PROVINCE_ID").ToString();
                            ddlProvinceIDEdit.DataValueField = "PROVINCE_ID";
                            ddlProvinceIDEdit.DataTextField = "PROVINCE_TH";
                            ddlProvinceIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlProvinceIDEdit.Items.Insert(0, new ListItem("--จังหวัด--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewAmphur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchAmphurTH.Text) && string.IsNullOrEmpty(txtSearchAmphurEN.Text) && ddlSearchProvince.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchAmphurTH.Text))
                {
                    ClassAmphur a1 = new ClassAmphur();
                    DataTable dt1 = a1.GetAmphur(txtSearchAmphurTH.Text,"","");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (!string.IsNullOrEmpty(txtSearchAmphurEN.Text))
                {
                    ClassAmphur a2 = new ClassAmphur();
                    DataTable dt2 = a2.GetAmphur("", txtSearchAmphurEN.Text, "");
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
                if (ddlSearchProvince.SelectedIndex != 0)
                {
                    ClassAmphur a3 = new ClassAmphur();
                    DataTable dt3 = a3.GetAmphur("", "", ddlSearchProvince.SelectedValue);
                    GridView1.DataSource = dt3;
                    GridView1.DataBind();
                    SetViewState(dt3);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassAmphur a = new ClassAmphur();
            DataTable dt = a.GetAmphur("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}