using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class LeaveHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if(!IsPostBack) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล FROM LEV_MAIN WHERE LEAVE_STATE not in(100,101) AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'");
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
                        btn.CssClass = "ps-button";
                        btn.Text = "<img src='Image/Small/search.png'></img>";
                        btn.Click += (e2, e3) => {
                            Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                        };
                        cell.Controls.Add(btn);
                        GridView1.Rows[i].Cells.Add(cell);
                    }

                    Util.NormalizeGridViewDate(GridView1, 2);
                }
                
            }
            {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล FROM LEV_MAIN WHERE LEAVE_STATE = 100 AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'");
                GridView2.DataSource = sds;
                GridView2.DataBind();

                if(GridView2.Rows.Count > 0) {
                    TableHeaderCell headerCell = new TableHeaderCell();
                    headerCell.Text = "ดูข้อมูล";
                    GridView2.HeaderRow.Cells.Add(headerCell);

                    for (int i = 0; i < GridView2.Rows.Count; ++i) {
                        string ID = GridView2.Rows[i].Cells[0].Text;
                        TableCell cell = new TableCell();
                        Button btn = new Button();
                        btn.Text = "ดูข้อมูล";
                        btn.Click += (e2, e3) => {
                            Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                        };
                        cell.Controls.Add(btn);
                        GridView2.Rows[i].Cells.Add(cell);
                    }

                    Util.NormalizeGridViewDate(GridView2, 2);
                }
                
                
            }
         

            //}
        }
    }
}