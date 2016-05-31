using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class WorkingTimeHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                Person pp = ps.LoginPerson;
                //DatabaseManager.BindDropDown(ddlKa, "SELECT * FROM LEV_WORKTIME_SEC", "WORKTIME_SEC_NAME", "WORKTIME_SEC_ID", "--กรุณาเลือกกะงาน--");
                //SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT WORKTIME_ID รหัส, LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY วันที่, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE สาย, ABSENT ขาด FROM LEV_WORKTIME WHERE CITIZEN_ID = '" + pp.CitizenID + "' ORDER BY WORKTIME_ID DESC");
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT TODAY วันที่, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE สาย, ABSENT ขาด FROM LEV_WORKTIME WHERE CITIZEN_ID = '" + pp.CitizenID + "' ORDER BY TODAY DESC");
                GridView1.DataSource = sds;
                GridView1.DataBind();
                Normalize();
                //Util.NormalizeGridViewDate7D(GridView1, 3);
            }
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person pp = ps.LoginPerson;
            if (tbDate.Text == "") {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT TODAY วันที่, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE สาย, ABSENT ขาด FROM LEV_WORKTIME WHERE CITIZEN_ID = '" + pp.CitizenID + "' ORDER BY TODAY DESC");
                GridView1.DataSource = sds;
                GridView1.DataBind();
            } else {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT TODAY วันที่, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE สาย, ABSENT ขาด FROM LEV_WORKTIME WHERE CITIZEN_ID = '" + pp.CitizenID + "' AND TODAY = " + Util.DatabaseToDateSearch(tbDate.Text) + " ORDER BY TODAY DESC");
                GridView1.DataSource = sds;
                GridView1.DataBind();
            }
            Normalize();
        }

        private void Normalize() {

            GridView1.HeaderRow.Cells[0].Text = "<img src='Image/Small/calendar.png' class='icon_left'/>" + GridView1.HeaderRow.Cells[0].Text;
            GridView1.HeaderRow.Cells[1].Text = "<img src='Image/Small/clock-history.png' class='icon_left'/>" + GridView1.HeaderRow.Cells[1].Text;
            GridView1.HeaderRow.Cells[2].Text = "<img src='Image/Small/clock-history.png' class='icon_left'/>" + GridView1.HeaderRow.Cells[2].Text;
            GridView1.HeaderRow.Cells[3].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + GridView1.HeaderRow.Cells[3].Text;
            GridView1.HeaderRow.Cells[4].Text = "<img src='Image/Small/question.png' class='icon_left'/>" + GridView1.HeaderRow.Cells[4].Text;

            Util.NormalizeGridViewDate(GridView1, 0);
            for (int i = 0; i < GridView1.Rows.Count; i++) {
                if(GridView1.Rows[i].Cells[1].Text == ":") {
                    GridView1.Rows[i].Cells[1].Text = "-";
                }
                if (GridView1.Rows[i].Cells[2].Text == ":") {
                    GridView1.Rows[i].Cells[2].Text = "-";
                }
                if (GridView1.Rows[i].Cells[3].Text == "0") {
                    GridView1.Rows[i].Cells[3].Text = "-";
                }
                if (GridView1.Rows[i].Cells[3].Text == "1") {
                    GridView1.Rows[i].Cells[3].Text = "สาย";
                }
                if (GridView1.Rows[i].Cells[4].Text == "0") {
                    GridView1.Rows[i].Cells[4].Text = "-";
                }
                if (GridView1.Rows[i].Cells[4].Text == "1") {
                    GridView1.Rows[i].Cells[4].Text = "ขาด";
                }
            }
        }
    }
}