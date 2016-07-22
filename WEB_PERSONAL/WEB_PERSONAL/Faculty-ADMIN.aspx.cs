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
    public partial class Faculty_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchCampus();
                ddlShowInsertCampus();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["FACULTY"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["FACULTY"] = data;
        }

        #endregion

        void BindData()
        {
            ClassFaculty f = new ClassFaculty();
            DataTable dt = f.GetFaculty("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchFacultyName.Text))
            {
                ClassFaculty f1 = new ClassFaculty();
                DataTable dt1 = f1.GetFaculty(txtSearchFacultyName.Text, "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (ddlSearchCampus.SelectedIndex != 0)
            {
                ClassFaculty f2 = new ClassFaculty();
                DataTable dt2 = f2.GetFaculty("", ddlSearchCampus.SelectedValue);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
        }

        private void ddlShowSearchCampus()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CAMPUS";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchCampus.DataSource = dt;
                        ddlSearchCampus.DataValueField = "CAMPUS_ID";
                        ddlSearchCampus.DataTextField = "CAMPUS_NAME";
                        ddlSearchCampus.DataBind();
                        sqlConn.Close();

                        ddlSearchCampus.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertCampus()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_CAMPUS";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertCampus.DataSource = dt;
                        ddlInsertCampus.DataValueField = "CAMPUS_ID";
                        ddlInsertCampus.DataTextField = "CAMPUS_NAME";
                        ddlInsertCampus.DataBind();
                        sqlConn.Close();

                        ddlInsertCampus.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchFacultyName.Text = "";
            ddlSearchCampus.SelectedIndex = 0;
            txtInsertFacultyName.Text = "";
            ddlInsertCampus.SelectedIndex = 0;
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertFacultyName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อสำนัก / สถาบัน / คณะ')", true);
                return;
            }

            if (ddlInsertCampus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก วิทยาเขต')", true);
                return;
            }
            ClassFaculty f = new ClassFaculty();
            f.FACULTY_NAME = txtInsertFacultyName.Text;
            f.CAMPUS_ID = Convert.ToInt32(ddlInsertCampus.SelectedValue);

            if (f.CheckUseFacultyName())
            {
                f.InsertFaculty();
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
            if (txtSearchFacultyName.Text != "" || ddlSearchCampus.SelectedIndex != 0)
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
            if (txtSearchFacultyName.Text != "" || ddlSearchCampus.SelectedIndex != 0)
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
            ClassFaculty f = new ClassFaculty();
            f.FACULTY_ID = id;
            f.DeleteFaculty();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchFacultyName.Text != "" || ddlSearchCampus.SelectedIndex != 0)
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
            Label lblFacultyIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblFacultyIDEdit");
            TextBox txtFacultyNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtFacultyNameEdit");
            DropDownList ddlCampusIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCampusIDEdit");

            ClassFaculty f = new ClassFaculty(Convert.ToInt32(lblFacultyIDEdit.Text)
                , txtFacultyNameEdit.Text
                , Convert.ToInt32(ddlCampusIDEdit.SelectedValue));

            if (f.CheckUseFacultyName())
            {
                f.UpdateFaculty();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อสำนัก / สถาบัน / คณะ " + DataBinder.Eval(e.Row.DataItem, "FACULTY_NAME") + " ใช่ไหม ?');");

                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    using (OracleConnection sqlConn1 = new OracleConnection(strConn))
                    {
                        using (OracleCommand sqlCmd1 = new OracleCommand())
                        {
                            DropDownList ddlCampusIDEdit = (DropDownList)e.Row.FindControl("ddlCampusIDEdit");

                            sqlCmd1.CommandText = "select * from TB_CAMPUS";
                            sqlCmd1.Connection = sqlConn1;
                            sqlConn1.Open();
                            OracleDataAdapter da1 = new OracleDataAdapter(sqlCmd1);
                            DataTable dt = new DataTable();
                            da1.Fill(dt);
                            ddlCampusIDEdit.DataSource = dt;
                            ddlCampusIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "CAMPUS_ID").ToString();
                            ddlCampusIDEdit.DataValueField = "CAMPUS_ID";
                            ddlCampusIDEdit.DataTextField = "CAMPUS_NAME";
                            ddlCampusIDEdit.DataBind();
                            sqlConn1.Close();

                            ddlCampusIDEdit.Items.Insert(0, new ListItem("--วิทยาเขต--", "0"));
                            DataRowView dr1 = e.Row.DataItem as DataRowView;
                        }
                    }
                }
            }
        }
        protected void myGridViewFaculty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassFaculty f = new ClassFaculty();
            DataTable dt = f.GetFaculty("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchFacultyName.Text) && ddlSearchCampus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchFacultyName.Text))
                {
                    ClassFaculty f1 = new ClassFaculty();
                    DataTable dt1 = f1.GetFaculty(txtSearchFacultyName.Text, "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (ddlSearchCampus.SelectedIndex != 0)
                {
                    ClassFaculty f2 = new ClassFaculty();
                    DataTable dt2 = f2.GetFaculty("", ddlSearchCampus.SelectedValue);
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassFaculty f = new ClassFaculty();
            DataTable dt = f.GetFaculty("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
