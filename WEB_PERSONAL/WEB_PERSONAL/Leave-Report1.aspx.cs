using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class Leave_Report1 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (PersonnelSystem.GetPersonnelSystem(this) == null) {
                Response.Redirect("Access.aspx");
                return;
            }
            if (!IsPostBack) {
                for (int i = 2500; i < 2600; ++i) {
                    DropDownList1.Items.Add(new ListItem("" + i, "" + i));
                }
                DateTime dt = Util.ODTT();
                
                if(dt.Month >= 10) {
                    DropDownList1.SelectedValue = "" + (dt.Year + 1);
                } else {
                    DropDownList1.SelectedValue = "" + dt.Year;
                }
                Label1.Text = "(1 ตุลาคม " + (int.Parse(DropDownList1.SelectedValue)-1) + " - 30 กันยายน " + DropDownList1.SelectedValue + ")";
            }

            
            
            BindGridView1();

        }
        private void BindGridView1() {

            

            DataTable dt = new DataTable();


            dt.Columns.Add("ลำดับที่");
            dt.Columns.Add("ชื่อ - นามสกุล");
            dt.Columns.Add("ตำแหน่ง");
            dt.Columns.Add("ครั้ง");
            dt.Columns.Add("วัน");
            dt.Columns.Add("ครั้ง ");
            dt.Columns.Add("วัน ");
            dt.Columns.Add("ครั้ง  ");
            dt.Columns.Add("วัน  ");
            dt.Columns.Add("มาสาย(ครั้ง)");
            dt.Columns.Add("ขาดราชการ(วัน)");
            dt.Columns.Add("ลาศึกษาต่อ(ระบุวันที่ลา)");
            dt.Columns.Add("ลาคลอดบุตร(ระบุวันที่ลา)");
            dt.Columns.Add("ลาอุปสมบทฯ(ระบุวันที่ลา)");
            dt.Columns.Add("หมายเหตุ");

            List<Person> persons = new List<Person>();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand command = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON ORDER BY PS_CITIZEN_ID ASC", con)) {
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        while(reader.Read()) {
                            Person ps = DatabaseManager.GetPerson(reader.GetString(0));
                            persons.Add(ps);
                        }
                    }
                }
            }

            int budgetYear = int.Parse(DropDownList1.SelectedValue)-543;

            for (int i = 0; i < persons.Count; i++) {
                Person ps = persons[i];
                DataRow dr = dt.NewRow();
                dr[0] = (i+1);
                dr[1] = ps.FirstNameAndLastName;
                dr[2] = ps.PositionName;

                dr[3] = DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 1 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                dr[4] = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 1 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                dr[5] = DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 2 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                dr[6] = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 2 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                dr[7] = DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 4 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                dr[8] = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 4 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);

                dr[9] = DatabaseManager.ExecuteInt("SELECT NVL(COUNT(WORKTIME_ID),0) FROM LEV_WORKTIME WHERE LATE = 1 AND CITIZEN_ID = '" + ps.CitizenID + "' AND EXTRACT(YEAR FROM TODAY) = " + budgetYear);
                dr[10] = DatabaseManager.ExecuteInt("SELECT NVL(COUNT(WORKTIME_ID),0) FROM LEV_WORKTIME WHERE ABSENT = 1 AND CITIZEN_ID = '" + ps.CitizenID + "' AND EXTRACT(YEAR FROM TODAY) = " + budgetYear);

                dr[11] = "-";
                dr[12] = "-";
                dr[13] = "-";
                dr[14] = "-";

                dt.Rows.Add(dr);

            }



            

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if(GridView1.Rows.Count > 0) {
                Label4.Text = "";
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                {
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = " ";
                    HeaderCell.ColumnSpan = 3;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }
                {
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = "ลาป่วย";
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }
                {
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = "ลากิจ";
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }
                {
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = "ลาพักผ่อน";
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }
                {
                    TableCell HeaderCell = new TableCell();
                    HeaderCell.Text = " ";
                    HeaderCell.ColumnSpan = 6;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }


                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);
            } else {
                Label4.Text = "ไม่มีข้อมูลในปี " + DropDownList1.SelectedValue;
            }

            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            Label1.Text = "(1 ตุลาคม " + DropDownList1.SelectedValue + " - 30 กันยายน " + (Convert.ToInt32(DropDownList1.SelectedValue) + 1) + ")";
            BindGridView1();
        }
    }
}