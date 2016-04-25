using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class LeaveHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if(!IsPostBack) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEAVE_STATE สถานะ, NVL(CH_ALLOW,0) ผลการอนุมัติ FROM LEV_MAIN WHERE LEAVE_STATE in(1,2) AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                GridView1.DataSource = sds;
                GridView1.DataBind();

                if(GridView1.Rows.Count > 0) {
                    TableHeaderCell headerCell = new TableHeaderCell();
                    headerCell.Text = "ดูข้อมูล";
                    GridView1.HeaderRow.Cells.Add(headerCell);

                    for (int i = 0; i < GridView1.Rows.Count; ++i) {
                        string ID = GridView1.Rows[i].Cells[0].Text;
                        TableCell cell = new TableCell();
                        LinkButton btn = new LinkButton();
                        btn.CssClass = "ps-button-img";
                        btn.Text = "<img src='Image/Small/search.png'></img>";
                        btn.Click += (e2, e3) => {
                            Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                        };
                        cell.Controls.Add(btn);
                        GridView1.Rows[i].Cells.Add(cell);

                        if(Util.StringEqual(GridView1.Rows[i].Cells[3].Text, new string[] {"1", "2" })) {
                            GridView1.Rows[i].Cells[3].Text = "อยู่ระหว่างการพิจารณา";
                            GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView1.Rows[i].Cells[3].Text, new string[] { "3", "4" })) {
                            GridView1.Rows[i].Cells[3].Text = "เสร็จสิ้น";
                            GridView1.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView1.Rows[i].Cells[4].Text, new string[] { "0" })) {
                            GridView1.Rows[i].Cells[4].Text = "-";
                            GridView1.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView1.Rows[i].Cells[4].Text, new string[] { "1" })) {
                            GridView1.Rows[i].Cells[4].Text = "อนุมัติ";
                            GridView1.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView1.Rows[i].Cells[4].Text, new string[] { "2" })) {
                            GridView1.Rows[i].Cells[4].Text = "ไม่อนุมัติ";
                            GridView1.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                        }

                    }

                    Util.NormalizeGridViewDate(GridView1, 2);
                }
                
            }
            {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEAVE_STATE สถานะ, NVL(CH_ALLOW,0) ผลการอนุมัติ FROM LEV_MAIN WHERE LEAVE_STATE = 3 AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                GridView3.DataSource = sds;
                GridView3.DataBind();

                if (GridView3.Rows.Count > 0) {
                    TableHeaderCell headerCell = new TableHeaderCell();
                    headerCell.Text = "ตกลง";
                    GridView3.HeaderRow.Cells.Add(headerCell);

                    for (int i = 0; i < GridView3.Rows.Count; ++i) {
                        string ID = GridView3.Rows[i].Cells[0].Text;
                        TableCell cell = new TableCell();
                        LinkButton btn = new LinkButton();
                        btn.CssClass = "ps-button-img";
                        btn.Text = "ตกลง";
                        btn.Click += (e2, e3) => {
                            DatabaseManager.ExecuteNonQuery("UPDATE LEV_MAIN SET LEAVE_STATE = 4 WHERE LEAVE_ID = " + ID);
                            Response.Redirect("LeaveHistory.aspx");
                        };
                        cell.Controls.Add(btn);
                        GridView3.Rows[i].Cells.Add(cell);

                        if (Util.StringEqual(GridView3.Rows[i].Cells[3].Text, new string[] { "1", "2" })) {
                            GridView3.Rows[i].Cells[3].Text = "อยู่ระหว่างการพิจารณา";
                            GridView3.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView3.Rows[i].Cells[3].Text, new string[] { "3", "4" })) {
                            GridView3.Rows[i].Cells[3].Text = "เสร็จสิ้น";
                            GridView3.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView3.Rows[i].Cells[4].Text, new string[] { "0" })) {
                            GridView3.Rows[i].Cells[4].Text = "-";
                            GridView3.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView3.Rows[i].Cells[4].Text, new string[] { "1" })) {
                            GridView3.Rows[i].Cells[4].Text = "อนุมัติ";
                            GridView3.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView3.Rows[i].Cells[4].Text, new string[] { "2" })) {
                            GridView3.Rows[i].Cells[4].Text = "ไม่อนุมัติ";
                            GridView3.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    Util.NormalizeGridViewDate(GridView3, 2);
                }


            }
            {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEAVE_STATE สถานะ, NVL(CH_ALLOW,0) ผลการอนุมัติ FROM LEV_MAIN WHERE LEAVE_STATE = 4 AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                GridView2.DataSource = sds;
                GridView2.DataBind();

                if(GridView2.Rows.Count > 0) {
                    TableHeaderCell headerCell = new TableHeaderCell();
                    headerCell.Text = "ดูข้อมูล";
                    GridView2.HeaderRow.Cells.Add(headerCell);

                    for (int i = 0; i < GridView2.Rows.Count; ++i) {
                        string ID = GridView2.Rows[i].Cells[0].Text;
                        TableCell cell = new TableCell();
                        LinkButton btn = new LinkButton();
                        btn.CssClass = "ps-button-img";
                        btn.Text = "<img src='Image/Small/search.png'></img>";
                        btn.Click += (e2, e3) => {
                            Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                        };
                        cell.Controls.Add(btn);
                        GridView2.Rows[i].Cells.Add(cell);

                        if (Util.StringEqual(GridView2.Rows[i].Cells[3].Text, new string[] { "1", "2" })) {
                            GridView2.Rows[i].Cells[3].Text = "อยู่ระหว่างการพิจารณา";
                            GridView2.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView2.Rows[i].Cells[3].Text, new string[] { "3", "4" })) {
                            GridView2.Rows[i].Cells[3].Text = "เสร็จสิ้น";
                            GridView2.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView2.Rows[i].Cells[4].Text, new string[] { "0" })) {
                            GridView2.Rows[i].Cells[4].Text = "-";
                            GridView2.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Orange;
                        }
                        if (Util.StringEqual(GridView2.Rows[i].Cells[4].Text, new string[] { "1" })) {
                            GridView2.Rows[i].Cells[4].Text = "อนุมัติ";
                            GridView2.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Green;
                        }
                        if (Util.StringEqual(GridView2.Rows[i].Cells[4].Text, new string[] { "2" })) {
                            GridView2.Rows[i].Cells[4].Text = "ไม่อนุมัติ";
                            GridView2.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    Util.NormalizeGridViewDate(GridView2, 2);
                }
                
                
            }
         

            //}
        }
    }
}