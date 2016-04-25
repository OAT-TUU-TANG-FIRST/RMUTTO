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
    public partial class District_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                txtSearchPostCode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                txtInsertPostCode.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                ddlShowSearchAmphur();
                ddlShowSearchProvince();
                ddlShowInsertAmphur();
                ddlShowInsertProvince();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["DISTRICT"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["DISTRICT"] = data;
        }

        #endregion

        void BindData()
        {
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchDistrictTH.Text))
            {
                ClassDistrict a1 = new ClassDistrict();
                DataTable dt1 = a1.GetDistrict(txtSearchDistrictTH.Text, "", "", "", "", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (!string.IsNullOrEmpty(txtSearchDistrictEN.Text))
            {
                ClassDistrict a2 = new ClassDistrict();
                DataTable dt2 = a2.GetDistrict("", txtSearchDistrictEN.Text, "", "", "", "");
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
            if (ddlSearchAmphur.SelectedIndex != 0)
            {
                ClassDistrict a3 = new ClassDistrict();
                DataTable dt3 = a3.GetDistrict("", "", ddlSearchAmphur.SelectedValue, "", "", "");
                GridView1.DataSource = dt3;
                GridView1.DataBind();
                SetViewState(dt3);
            }
            if (ddlSearchProvince.SelectedIndex != 0)
            {
                ClassDistrict a4 = new ClassDistrict();
                DataTable dt4 = a4.GetDistrict("", "", "", ddlSearchProvince.SelectedValue, "", "");
                GridView1.DataSource = dt4;
                GridView1.DataBind();
                SetViewState(dt4);
            }
            if (!string.IsNullOrEmpty(txtSearchPostCode.Text))
            {
                ClassDistrict a5 = new ClassDistrict();
                DataTable dt5 = a5.GetDistrict("", "", "", "", txtSearchPostCode.Text, "");
                GridView1.DataSource = dt5;
                GridView1.DataBind();
                SetViewState(dt5);
            }
            if (!string.IsNullOrEmpty(txtSearchNote.Text))
            {
                ClassDistrict a6 = new ClassDistrict();
                DataTable dt6 = a6.GetDistrict("", "", "", "", "", txtSearchNote.Text);
                GridView1.DataSource = dt6;
                GridView1.DataBind();
                SetViewState(dt6);
            }
        }

        private void ddlShowSearchAmphur()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchAmphur.DataSource = dt;
                        ddlSearchAmphur.DataValueField = "AMPHUR_ID";
                        ddlSearchAmphur.DataTextField = "AMPHUR_TH";
                        ddlSearchAmphur.DataBind();
                        sqlConn.Close();

                        ddlSearchAmphur.Items.Insert(0, new ListItem("--อำเภอ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertAmphur()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_AMPHUR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertAmphur.DataSource = dt;
                        ddlInsertAmphur.DataValueField = "AMPHUR_ID";
                        ddlInsertAmphur.DataTextField = "AMPHUR_TH";
                        ddlInsertAmphur.DataBind();
                        sqlConn.Close();

                        ddlInsertAmphur.Items.Insert(0, new ListItem("--อำเภอ--", "0"));

                    }
                }
            }
            catch { }
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
            txtSearchDistrictTH.Text = "";
            txtSearchDistrictEN.Text = "";
            ddlSearchAmphur.SelectedIndex = 0;
            ddlSearchProvince.SelectedIndex = 0;
            txtSearchPostCode.Text = "";
            txtSearchNote.Text = "";
            txtInsertDistrictTH.Text = "";
            txtInsertDistrictEN.Text = "";
            ddlInsertAmphur.SelectedIndex = 0;
            ddlInsertProvince.SelectedIndex = 0;
            txtInsertPostCode.Text = "";
            txtInsertNote.Text = "";

        }

        protected void btnSubmitDistrict_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertDistrictTH.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำบลภาษาไทย')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtInsertDistrictEN.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อตำบลภาษาอังกฤษ')", true);
                return;
            }
            if (ddlInsertAmphur.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก อำเภอ')", true);
                return;
            }
            if (ddlInsertProvince.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก จังหวัด')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertPostCode.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสไปรษณีย์')", true);
                return;
            }

            ClassDistrict d = new ClassDistrict();
            d.DISTRICT_TH = txtInsertDistrictTH.Text;
            d.DISTRICT_EN = txtInsertDistrictEN.Text;
            d.AMPHUR_ID = Convert.ToInt32(ddlInsertAmphur.SelectedValue);
            d.PROVINCE_ID = Convert.ToInt32(ddlInsertProvince.SelectedValue);
            d.POST_CODE = Convert.ToInt32(txtInsertPostCode.Text);
            d.NOTE = txtInsertNote.Text;

            if (d.CheckUseDistrictName())
            {
                d.InsertDistrict();
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
            if (txtSearchDistrictTH.Text != "" || txtSearchDistrictEN.Text != "" || ddlSearchAmphur.SelectedIndex != 0 || ddlSearchProvince.SelectedIndex != 0 || txtInsertPostCode.Text != "" || txtInsertNote.Text != "")
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
            if (txtSearchDistrictTH.Text != "" || txtSearchDistrictEN.Text != "" || ddlSearchAmphur.SelectedIndex != 0 || ddlSearchProvince.SelectedIndex != 0 || txtInsertPostCode.Text != "" || txtInsertNote.Text != "")
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
            ClassDistrict d = new ClassDistrict();
            d.DISTRICT_ID = id;
            d.DeleteDistrict();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchDistrictTH.Text != "" || txtSearchDistrictEN.Text != "" || ddlSearchAmphur.SelectedIndex != 0 || ddlSearchProvince.SelectedIndex != 0 || txtInsertPostCode.Text != "" || txtInsertNote.Text != "")
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

            Label lblDistrictIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDistrictIDEdit");
            TextBox txtDistrictTHEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDistrictTHEdit");
            TextBox txtDistrictENEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDistrictENEdit");
            DropDownList ddlAmphurIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlAmphurIDEdit");
            DropDownList ddlProvinceIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlProvinceIDEdit");
            TextBox txtPostCodeEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPostCodeEdit");
            TextBox txtNoteEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNoteEdit");

            ClassDistrict d = new ClassDistrict(Convert.ToInt32(lblDistrictIDEdit.Text)
                , txtDistrictTHEdit.Text
                , txtDistrictENEdit.Text
                , Convert.ToInt32(ddlAmphurIDEdit.SelectedValue)
                , Convert.ToInt32(ddlProvinceIDEdit.SelectedValue)
                , Convert.ToInt32(txtPostCodeEdit.Text)
                , txtNoteEdit.Text);

            if (d.CheckUseDistrictName())
            {
                d.UpdateDistrict();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อตำบล " + DataBinder.Eval(e.Row.DataItem, "DISTRICT_TH") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlAmphurIDEdit = (DropDownList)e.Row.FindControl("ddlAmphurIDEdit");

                            sqlCmd1.CommandText = "select * from TB_AMPHUR";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlAmphurIDEdit.DataSource = dt;
                            ddlAmphurIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "AMPHUR_ID").ToString();
                            ddlAmphurIDEdit.DataValueField = "AMPHUR_ID";
                            ddlAmphurIDEdit.DataTextField = "AMPHUR_TH";
                            ddlAmphurIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlAmphurIDEdit.Items.Insert(0, new ListItem("--อำเภอ--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                    using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd2 = new OracleCommand())
                        {
                            DropDownList ddlProvinceIDEdit = (DropDownList)e.Row.FindControl("ddlProvinceIDEdit");

                            sqlCmd2.CommandText = "select * from TB_PROVINCE";
                            sqlCmd2.Connection = sqlConn2;
                            sqlConn2.Open();
                            OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                            DataTable dt = new DataTable();
                            da2.Fill(dt);
                            ddlProvinceIDEdit.DataSource = dt;
                            ddlProvinceIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "PROVINCE_ID").ToString();
                            ddlProvinceIDEdit.DataValueField = "PROVINCE_ID";
                            ddlProvinceIDEdit.DataTextField = "PROVINCE_TH";
                            ddlProvinceIDEdit.DataBind();
                            sqlConn2.Close();

                            ddlProvinceIDEdit.Items.Insert(0, new ListItem("--จังหวัด--", "0"));
                            DataRowView dr2 = e.Row.DataItem as DataRowView;
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
        protected void myGridViewDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelDistrict_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void btnSearchDistrict_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchDistrictTH.Text) && string.IsNullOrEmpty(txtSearchDistrictEN.Text) && ddlSearchAmphur.SelectedIndex == 0 && ddlSearchProvince.SelectedIndex == 0 && string.IsNullOrEmpty(txtSearchPostCode.Text) && string.IsNullOrEmpty(txtSearchNote.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchDistrictTH.Text))
                {
                    ClassDistrict a1 = new ClassDistrict();
                    DataTable dt1 = a1.GetDistrict(txtSearchDistrictTH.Text, "", "", "", "", "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (!string.IsNullOrEmpty(txtSearchDistrictEN.Text))
                {
                    ClassDistrict a2 = new ClassDistrict();
                    DataTable dt2 = a2.GetDistrict("", txtSearchDistrictEN.Text, "", "", "", "");
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
                if (ddlSearchAmphur.SelectedIndex != 0)
                {
                    ClassDistrict a3 = new ClassDistrict();
                    DataTable dt3 = a3.GetDistrict("", "", ddlSearchAmphur.SelectedValue, "", "", "");
                    GridView1.DataSource = dt3;
                    GridView1.DataBind();
                    SetViewState(dt3);
                }
                if (ddlSearchProvince.SelectedIndex != 0)
                {
                    ClassDistrict a4 = new ClassDistrict();
                    DataTable dt4 = a4.GetDistrict("", "", "", ddlSearchProvince.SelectedValue, "", "");
                    GridView1.DataSource = dt4;
                    GridView1.DataBind();
                    SetViewState(dt4);
                }
                if (!string.IsNullOrEmpty(txtSearchPostCode.Text))
                {
                    ClassDistrict a5 = new ClassDistrict();
                    DataTable dt5 = a5.GetDistrict("", "", "", "", txtSearchPostCode.Text, "");
                    GridView1.DataSource = dt5;
                    GridView1.DataBind();
                    SetViewState(dt5);
                }
                if (!string.IsNullOrEmpty(txtSearchNote.Text))
                {
                    ClassDistrict a6 = new ClassDistrict();
                    DataTable dt6 = a6.GetDistrict("", "", "", "", "", txtSearchNote.Text);
                    GridView1.DataSource = dt6;
                    GridView1.DataBind();
                    SetViewState(dt6);
                }
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDistrict d = new ClassDistrict();
            DataTable dt = d.GetDistrict("", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}