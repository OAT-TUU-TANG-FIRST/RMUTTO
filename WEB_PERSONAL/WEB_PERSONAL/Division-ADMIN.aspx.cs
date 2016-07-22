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
    public partial class Division_ADMIN : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlShowSearchCampus();
                ddlShowInsertCampus();
                ddlShowSearchFaculty();
                ddlShowInsertFaculty();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["DIVISION"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["DIVISION"] = data;
        }

        #endregion

        void BindData()
        {
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            if (!string.IsNullOrEmpty(txtSearchDivisionName.Text))
            {
                ClassDivision d1 = new ClassDivision();
                DataTable dt1 = d1.GetDivision(txtSearchDivisionName.Text, "", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                SetViewState(dt1);
            }
            if (ddlSearchCampus.SelectedIndex != 0)
            {
                ClassDivision d2 = new ClassDivision();
                DataTable dt2 = d2.GetDivision("", ddlSearchCampus.SelectedValue, "");
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                SetViewState(dt2);
            }
            if (ddlSearchFaculty.SelectedIndex != 0)
            {
                ClassDivision d3 = new ClassDivision();
                DataTable dt3 = d3.GetDivision("", "", ddlSearchFaculty.SelectedValue);
                GridView1.DataSource = dt3;
                GridView1.DataBind();
                SetViewState(dt3);
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

        private void ddlShowSearchFaculty()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSearchFaculty.DataSource = dt;
                        ddlSearchFaculty.DataValueField = "FACULTY_ID";
                        ddlSearchFaculty.DataTextField = "FACULTY_NAME";
                        ddlSearchFaculty.DataBind();
                        sqlConn.Close();

                        ddlSearchFaculty.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ddlShowInsertFaculty()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlInsertFaculty.DataSource = dt;
                        ddlInsertFaculty.DataValueField = "FACULTY_ID";
                        ddlInsertFaculty.DataTextField = "FACULTY_NAME";
                        ddlInsertFaculty.DataBind();
                        sqlConn.Close();

                        ddlInsertFaculty.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));

                    }
                }
            }
            catch { }
        }

        private void ClearData()
        {
            txtSearchDivisionName.Text = "";
            ddlSearchCampus.SelectedIndex = 0;
            ddlSearchFaculty.SelectedIndex = 0;
            txtInsertDivisionName.Text = "";
            ddlInsertCampus.SelectedIndex = 0;
            ddlInsertFaculty.SelectedIndex = 0;
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertDivisionName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อกอง / สำนักงานเลขา / ภาควิชา')", true);
                return;
            }
            if (ddlInsertCampus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก วิทยาเขต')", true);
                return;
            }
            if (ddlInsertFaculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาเลือก สำนัก / สถาบัน / คณะ')", true);
                return;
            }
            ClassDivision d = new ClassDivision();
            d.DIVISION_NAME = txtInsertDivisionName.Text;
            d.CAMPUS_ID = Convert.ToInt32(ddlInsertCampus.SelectedValue);
            d.FACULTY_ID = Convert.ToInt32(ddlInsertFaculty.SelectedValue);

            if (d.CheckUseDivisionName())
            {
                d.InsertDivision();
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
            if (txtSearchDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0)
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
            if(txtSearchDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1; ;
                BindData();
            }
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassDivision d = new ClassDivision();
            d.DIVISION_ID = id;
            d.DeleteDivision();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            if (txtSearchDivisionName.Text != "" || ddlSearchCampus.SelectedIndex != 0 || ddlSearchFaculty.SelectedIndex != 0)
            {
                GridView1.EditIndex = -1; ;
                BindData1();
            }
            else
            {
                GridView1.EditIndex = -1; ;
                BindData();
            }
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblDivisionIDEdit = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDivisionIDEdit");
            TextBox txtDivisionNameEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDivisionNameEdit");
            DropDownList ddlCampusIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCampusIDEdit");
            DropDownList ddlFacultyIDEdit = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlFacultyIDEdit");

            ClassDivision d = new ClassDivision(Convert.ToInt32(lblDivisionIDEdit.Text)
                , txtDivisionNameEdit.Text
                , Convert.ToInt32(ddlCampusIDEdit.SelectedValue)
                , Convert.ToInt32(ddlFacultyIDEdit.SelectedValue));

            if (d.CheckUseDivisionName())
            {
                d.UpdateDivision();
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
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อกอง / สำนักงานเลขา / ภาควิชา " + DataBinder.Eval(e.Row.DataItem, "DIVISION_NAME") + " ใช่ไหม ?');");

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

                        using (OracleConnection sqlConn2 = new OracleConnection(strConn))
                        {
                            using (OracleCommand sqlCmd2 = new OracleCommand())
                            {
                                DropDownList ddlFacultyIDEdit = (DropDownList)e.Row.FindControl("ddlFacultyIDEdit");

                                sqlCmd2.CommandText = "select * from TB_FACULTY";
                                sqlCmd2.Connection = sqlConn2;
                                sqlConn2.Open();
                                OracleDataAdapter da2 = new OracleDataAdapter(sqlCmd2);
                                DataTable dt = new DataTable();
                                da2.Fill(dt);
                                ddlFacultyIDEdit.DataSource = dt;
                                ddlFacultyIDEdit.SelectedValue = DataBinder.Eval(e.Row.DataItem, "FACULTY_ID").ToString();
                                ddlFacultyIDEdit.DataValueField = "FACULTY_ID";
                                ddlFacultyIDEdit.DataTextField = "FACULTY_NAME";
                                ddlFacultyIDEdit.DataBind();
                                sqlConn2.Close();

                                ddlFacultyIDEdit.Items.Insert(0, new ListItem("--สำนัก / สถาบัน / คณะ--", "0"));
                                DataRowView dr2 = e.Row.DataItem as DataRowView;
                            }
                        }
                    }
                }
            }
        }
        protected void myGridViewDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearchDivisionName.Text) && ddlSearchCampus.SelectedIndex == 0 && ddlSearchFaculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);

                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSearchDivisionName.Text))
                {
                    ClassDivision d1 = new ClassDivision();
                    DataTable dt1 = d1.GetDivision(txtSearchDivisionName.Text, "", "");
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    SetViewState(dt1);
                }
                if (ddlSearchCampus.SelectedIndex != 0)
                {
                    ClassDivision d2 = new ClassDivision();
                    DataTable dt2 = d2.GetDivision("", ddlSearchCampus.SelectedValue, "");
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    SetViewState(dt2);
                }
                if (ddlSearchFaculty.SelectedIndex != 0)
                {
                    ClassDivision d3 = new ClassDivision();
                    DataTable dt3 = d3.GetDivision("", "", ddlSearchFaculty.SelectedValue);
                    GridView1.DataSource = dt3;
                    GridView1.DataBind();
                    SetViewState(dt3);
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            ClassDivision d = new ClassDivision();
            DataTable dt = d.GetDivision("", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}
