using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.IO;
using WEB_PERSONAL.Class;
using System.Text;

namespace WEB_PERSONAL {
    public partial class LeaveReport1 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (PersonnelSystem.GetPersonnelSystem(this) == null) {
                Response.Redirect("Access.aspx");
                return;
            }
            if (!IsPostBack) {
                for (int i = 2500; i < 2600; ++i) {
                    DropDownList1.Items.Add(new System.Web.UI.WebControls.ListItem("" + i, "" + i));
                }
                DateTime dt = Util.ODTT();


                /*if (dt.Month >= 10) {
                    DropDownList1.SelectedValue = "" + (dt.Year + 1);
                } else {
                    DropDownList1.SelectedValue = "" + dt.Year;
                }*/

                DropDownList1.SelectedValue = "" + (Util.BudgetYear() + 543);

            }



            BindGridView1();
        }

        private void BindGridView1() {

            Label1.Text = "(1 ตุลาคม " + (int.Parse(DropDownList1.SelectedValue) - 1) + " - 30 กันยายน " + DropDownList1.SelectedValue + ")";
            tb.Rows.Clear();
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 3; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลาป่วย"; cell.ColumnSpan = 2; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลากิจ"; cell.ColumnSpan = 2; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลาพักผ่อน"; cell.ColumnSpan = 2; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 6; row.Cells.Add(cell); }
                tb.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลำดับที่"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ชื่อ - นามสกุล"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ตำแหน่ง"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ครั้ง"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วัน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ครั้ง"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วัน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ครั้ง"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วัน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "มาสาย(ครั้ง)"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ขาดราชการ(วัน)"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลาศึกษาต่อ(ระบุวันที่ลา)"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลาคลอดบุตร(ระบุวันที่ลา)"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลาอุปสมบทฯ(ระบุวันที่ลา)"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "หมายเหตุ"; row.Cells.Add(cell); }
                tb.Rows.Add(row);
            }

            List<Person> persons = new List<Person>();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand command = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON ORDER BY PS_CITIZEN_ID ASC", con)) {
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Person ps = DatabaseManager.GetPerson(reader.GetString(0));
                            persons.Add(ps);
                        }
                    }
                }
            }

            int budgetYear = int.Parse(DropDownList1.SelectedValue) - 543;

            for (int i = 0; i < persons.Count; i++) {
                Person ps = persons[i];
                TableRow row = new TableRow();
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + (i + 1);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = ps.FirstNameAndLastName;
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = ps.PositionName;
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 1 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 1 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 2 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 2 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(COUNT(LEAVE_ID),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 4 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE LEAVE_TYPE_ID = 4 AND PS_ID = '" + ps.CitizenID + "' AND BUDGET_YEAR = " + budgetYear);
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(COUNT(WORKTIME_ID),0) FROM LEV_WORKTIME WHERE LATE = 1 AND CITIZEN_ID = '" + ps.CitizenID + "' AND TODAY > TO_DATE('30-09-" + (budgetYear-1) + "', 'DD-MM-YYYY') AND TODAY < TO_DATE('01-10-" + (budgetYear) + "', 'DD-MM-YYYY')");
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + DatabaseManager.ExecuteInt("SELECT NVL(COUNT(WORKTIME_ID),0) FROM LEV_WORKTIME WHERE ABSENT = 1 AND CITIZEN_ID = '" + ps.CitizenID + "' AND TODAY > TO_DATE('30-09-" + (budgetYear-1) + "', 'DD-MM-YYYY') AND TODAY < TO_DATE('01-10-" + (budgetYear) + "', 'DD-MM-YYYY')");
                    row.Cells.Add(cell);
                }
                {
                    TableCell cell = new TableCell();
                    cell.Text = "";
                    row.Cells.Add(cell);
                }
                {
                   
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        {
                            TableCell cell = new TableCell();
                            cell.Text = "";
                            using (OracleCommand command = new OracleCommand("SELECT FROM_DATE FROM LEV_DATA WHERE PS_ID = '" + ps.CitizenID + "' AND LEAVE_TYPE_ID = 3 ORDER BY LEAVE_ID DESC", con)) {
                                using (OracleDataReader reader = command.ExecuteReader()) {
                                    if (reader.Read()) {
                                        cell.Text = reader.GetDateTime(0).ToLongDateString();
                                    }
                                }
                            }
                            row.Cells.Add(cell);
                        }
                        {
                            TableCell cell = new TableCell();
                            cell.Text = "";
                            using (OracleCommand command = new OracleCommand("SELECT FROM_DATE FROM LEV_DATA WHERE PS_ID = '" + ps.CitizenID + "' AND LEAVE_TYPE_ID = 6 ORDER BY LEAVE_ID DESC", con)) {
                                using (OracleDataReader reader = command.ExecuteReader()) {
                                    if (reader.Read()) {
                                        cell.Text = reader.GetDateTime(0).ToLongDateString();
                                    }
                                }
                            }
                            row.Cells.Add(cell);
                        }

                    }
                    
                }
                
                {
                    TableCell cell = new TableCell();
                    cell.Text = "";
                    row.Cells.Add(cell);
                }
                tb.Rows.Add(row);
            }

            if (tb.Rows.Count > 2) {
                Label4.Text = "";
                Label4.Visible = false;
            } else {
                Label4.Text = "ไม่มีข้อมูลในปี " + DropDownList1.SelectedValue;
                Label4.Visible = true;
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            Label1.Text = "(1 ตุลาคม " + DropDownList1.SelectedValue + " - 30 กันยายน " + (Convert.ToInt32(DropDownList1.SelectedValue) + 1) + ")";
            BindGridView1();
        }

        protected void lbuExport_Click(object sender, EventArgs e) {
            /* Response.Clear();
             Response.Buffer = true;
             Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
             Response.Charset = "";
             Response.ContentType = "application/vnd.ms-excel";
             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             GridView1.AllowPaging = false;
             GridView1.DataBind();
             //Change the Header Row back to white color
             GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
             //Apply style to Individual Cells
             GridView1.HeaderRow.Cells[0].Style.Add("background-color", "green");
             GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
             GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
             GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");
             for (int i = 0; i < GridView1.Rows.Count; i++) {
                 GridViewRow row = GridView1.Rows[i];
                 //Change Color back to white
                 row.BackColor = System.Drawing.Color.White;
                 //Apply text style to each Row
                 row.Attributes.Add("class", "textmode");
                 //Apply style to Individual Cells of Alternating Row
                 if (i % 2 != 0) {
                     row.Cells[0].Style.Add("background-color", "#C2D69B");
                     row.Cells[1].Style.Add("background-color", "#C2D69B");
                     row.Cells[2].Style.Add("background-color", "#C2D69B");
                     row.Cells[3].Style.Add("background-color", "#C2D69B");
                 }
             }
             GridView1.RenderControl(hw);
             //style to format numbers to string
             string style = @"<style> .textmode { mso-number-format:\@; } </style>";
             Response.Write(style);
             Response.Output.Write(sw.ToString());
             Response.Flush();
             Response.End();*/

            /*tb.Rows[1].Cells[0].Style.Add("background-color", "green");
            tb.Rows[1].Cells[1].Style.Add("background-color", "green");
            tb.Rows[1].Cells[2].Style.Add("background-color", "green");
            tb.Rows[1].Cells[3].Style.Add("background-color", "green");*/

            for (int i = 0; i < 5; i++) {
                tb.Rows[0].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 0; i < 15; i++) {
                tb.Rows[1].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 2; i < tb.Rows.Count; i++) {
                for (int j = 0; j < 15; j++) {
                    tb.Rows[i].Cells[j].Style.Add("border", "1px solid #000000");
                }
                
            }

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename=LeaveReport" + DropDownList1.SelectedValue + ".xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();


        }

        public override void VerifyRenderingInServerForm(Control control) {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}