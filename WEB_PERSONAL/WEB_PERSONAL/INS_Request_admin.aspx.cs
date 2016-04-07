using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class INS_Request_admin : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                DDLyear1();
                DDLstafftype1();
                DDLCampus();
            }

        }

        void BindData()
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }
        }

        private void DDLyear1()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from INS_YEAR";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DDLyear.DataSource = dt;
                        DDLyear.DataValueField = "YEAR_ID";
                        DDLyear.DataTextField = "YEAR_ID";
                        DDLyear.DataBind();
                        sqlConn.Close();

                        DDLyear.Items.Insert(0, new ListItem("--กรุณาเลือก ปี--", "0"));
                    }
                }
            }
            catch { }
        }

        private void DDLstafftype1()
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_STAFFTYPE";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DDLstafftype.DataSource = dt;
                        DDLstafftype.DataValueField = "STAFFTYPE_ID";
                        DDLstafftype.DataTextField = "STAFFTYPE_NAME";
                        DDLstafftype.DataBind();
                        sqlConn.Close();

                        DDLstafftype.Items.Insert(0, new ListItem("--กรุณาเลือก ประเภทบุคลากร--", "0"));
                    }
                }
            }
            catch { }
        }

        private void DDLCampus()
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
                        DropDownCampus.DataSource = dt;
                        DropDownCampus.DataValueField = "CAMPUS_ID";
                        DropDownCampus.DataTextField = "CAMPUS_NAME";
                        DropDownCampus.DataBind();
                        sqlConn.Close();

                        DropDownCampus.Items.Insert(0, new ListItem("--กรุณาเลือก วิทยาเขต--", "0"));
                        DropDownFaculty.Items.Insert(0, new ListItem("--กรุณาเลือก คณะ--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void DropDownCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(strConn))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_FACULTY where CAMPUS_ID=:CAMPUS_ID";
                        sqlCmd.Parameters.AddWithValue(":CAMPUS_ID", DropDownCampus.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownFaculty.DataSource = dt;
                        DropDownFaculty.DataValueField = "FACULTY_ID";
                        DropDownFaculty.DataTextField = "FACULTY_NAME";
                        DropDownFaculty.DataBind();
                        sqlConn.Close();

                        DropDownFaculty.Items.Insert(0, new ListItem("--กรุณาเลือก คณะ--", "0"));
                    }
                }
            }
            catch { }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "คำนำหน้า";
                e.Row.Cells[2].Text = "ชื่อ";
                e.Row.Cells[3].Text = "นามสกุล";
                e.Row.Cells[4].Text = "วันเกิด";
                e.Row.Cells[5].Text = "ประเภทบุคลากร";
                e.Row.Cells[6].Text = "เพศ";
                e.Row.Cells[7].Text = "เบอร์โทรศัพท์";
                e.Row.Cells[8].Text = "ตำแหน่งในสายงาน";
                e.Row.Cells[9].Text = "คณะ";
                e.Row.Cells[10].Text = "วิทยาเขต";
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
             
            SqlDataSource1.SelectCommand = "select t.TITLE_NAME_TH,p.PERSON_NAME,p.PERSON_LASTNAME,TO_CHAR(p.BIRTHDATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI'),s.STAFFTYPE_NAME,g.GENDER_NAME,p.TELEPHONE,pw.POSITION_WORK_NAME,f.FACULTY_NAME,c.CAMPUS_NAME from TB_PERSON p inner join TB_TITLENAME t on p.TITLE_ID = t.TITLE_ID inner join TB_STAFFTYPE s on p.STAFFTYPE_ID = s.STAFFTYPE_ID inner join TB_GENDER g on p.GENDER_ID = g.GENDER_ID inner join TB_POSITION_WORK pw on p.POSITION_WORK_ID = pw.POSITION_WORK_ID inner join TB_FACULTY f on p.FACULTY_ID = f.FACULTY_ID inner join TB_CAMPUS c on p.CAMPUS_ID = c.CAMPUS_ID";

            GridView1.DataBind();
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkEmp");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

    }

}

