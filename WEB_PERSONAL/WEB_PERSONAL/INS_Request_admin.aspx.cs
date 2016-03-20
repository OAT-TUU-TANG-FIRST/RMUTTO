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

    }

}