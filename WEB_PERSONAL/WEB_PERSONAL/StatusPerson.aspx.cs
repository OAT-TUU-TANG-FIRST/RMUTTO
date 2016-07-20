using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL
{
    public partial class StatusPerson : System.Web.UI.Page
    {
        string psID;
        string psName;
        string SW_ID;
        string state;

        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseManager.BindDropDown(ddlStatusWork, "SELECT * FROM PS_POSITION WHERE P_GROUP = 1", "P_NAME", "P_ID", "--กรุณาเลือกสถานะการทำงาน--");

            if (Request.QueryString["psID"] != null)
            {
                psID = Request.QueryString["psID"];
            }
            if (Request.QueryString["psName"] != null)
            {
                psName = Request.QueryString["psName"];
            }
            if (Request.QueryString["SW_ID"] != null)
            {
                SW_ID = Request.QueryString["SW_ID"];
            }
            else
            {
                state = "1";
            }

            if (state == "1")
            {
                divState1.Visible = true;
                divState2.Visible = false;

                {
                    TableHeaderRow row = new TableHeaderRow();
                    tbPerson.Rows.Add(row);
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ลำดับ";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เลขประจำตัวประชาชน";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ชื่อ";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เลือก";
                        row.Cells.Add(cell);
                    }
                }


                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT PS_ID, PS_CITIZEN_ID, PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string psID = reader.GetString(1);

                                TableRow row = new TableRow();
                                tbPerson.Rows.Add(row);

                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetInt32(0).ToString();
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetString(1);
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    cell.Text = reader.GetString(2);
                                    row.Cells.Add(cell);
                                }
                                {
                                    TableCell cell = new TableCell();
                                    LinkButton lbu = new LinkButton();
                                    lbu.CssClass = "ps-button";
                                    lbu.Text = "เลือก";
                                    lbu.Click += (e1, e2) =>
                                    {
                                        state1Selected(psID);
                                    };
                                    cell.Controls.Add(lbu);
                                    row.Cells.Add(cell);
                                }
                            }

                        }
                    }

                }
            }
            else if (state == "2")
            {
                divState1.Visible = false;
                divState2.Visible = true;
            }

            //ปุ่มย้อนกลับ
            {
                LinkButton lbu = new LinkButton();
                lbu.CssClass = "ps-button";
                lbu.Text = "ย้อนกลับ";
                lbu.Click += (e1, e2) =>
                {
                    psName = psName.Replace(' ', '+');
                    Response.Redirect("PersonPositionManagement.aspx?psID=" + psID + "&psName=" + psName + "&state=2");
                };
                //pConfirm.Controls.Add(lbu);
            }
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {

        }

        private void state1Selected(string psID)
        {
            string psName = "";
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = " + psID, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            psName = reader.GetString(0);
                        }
                    }
                }
            }
            psName = psName.Replace(' ', '+');
            Response.Redirect("StatusPerson.aspx?psID=" + psID + "&psName=" + psName + "&state=2");
        }

        protected void lbuState2Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatusPerson.aspx.aspx");
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatusPerson.aspx.aspx");
        }
    }
}