using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;

namespace WEB_PERSONAL {
    public partial class ViewLeaveForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string form = Request.QueryString["Form"].ToString();
            string leaveID = Request.QueryString["LeaveID"].ToString();
            if(form == "1") {
                if(leaveID == "all") {
                    using(OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        using(OleDbCommand com = new OleDbCommand("SELECT LEAVE_ID FROM LEV_MAIN", con)) {
                            using(OleDbDataReader reader = com.ExecuteReader()) {
                                while(reader.Read()) {
                                    CreateForm1Display(i1, reader.GetValue(0).ToString());
                                }
                                
                            }
                        }
                    }
                } else {
                    CreateForm1Display(i1, leaveID);
                }
                
            } else {

            }
            
        }

        public static void CreateForm1Display(HtmlGenericControl hgc, string leaveID) {

            Form1Package f1 = DatabaseManager.GetForm1Package(leaveID);
            Table table = new Table();
            table.Style.Add("border", "1px solid #f0f0f0");
            table.Style.Add("margin-bottom", "20px");

            if (f1 != null) {
                table.Rows.Add(Create2Row("รหัสการลา", f1.LeaveID));
                table.Rows.Add(Create2Row("วันที่ลงข้อมูล", f1.RequestDate));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("ชื่อผู้ลา", f1.PersonPrefix + f1.PersonFirstName + " " + f1.PersonLastName));
                table.Rows.Add(Create2Row("ตำแหน่ง", f1.PersonPosition));
                table.Rows.Add(Create2Row("ระดับ", f1.PersonRank));
                table.Rows.Add(Create2Row("สังกัด", f1.PersonDepartment));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("ประเภทการลา", f1.LeaveTypeName));
                table.Rows.Add(Create2Row("จากวันที่", f1.FromDate));
                table.Rows.Add(Create2Row("ถึงวันที่", f1.ToDate));
                table.Rows.Add(Create2Row("รวม", f1.TotalDay + " วัน"));
                table.Rows.Add(Create2Row("เหตุผล", f1.Reason));
                table.Rows.Add(Create2Row("ติดต่อได้ที่", f1.Contact));
                table.Rows.Add(Create2Row("เบอร์โทรศัพท์", f1.Phone));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("วันที่ลาล่าสุด", f1.LastFromDate));
                table.Rows.Add(Create2Row("ถึงวันที่ล่าสุด", f1.LastToDate));
                table.Rows.Add(Create2Row("รวม", f1.LastTotalDay + " วัน"));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("ชื่อผู้บังคับบัญชา", f1.CommanderLowPrefix + f1.CommanderLowFirstName + " " + f1.CommanderLowLastName));
                table.Rows.Add(Create2Row("ตำแหน่ง", f1.CommanderLowPosition));
                table.Rows.Add(Create2Row("ความเห็น", f1.CommanderLowComment));
                table.Rows.Add(Create2Row("วันที่", f1.CommanderLowDate));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("ชื่อผู้อนุมัติ", f1.CommanderHighPrefix + f1.CommanderHighFirstName + " " + f1.CommanderHighLastName));
                table.Rows.Add(Create2Row("ตำแหน่ง", f1.CommanderHighPosition));
                table.Rows.Add(Create2Row("ความเห็น", f1.CommanderHighComment));
                table.Rows.Add(Create2Row("วันที่", f1.CommanderHighDate));
                table.Rows.Add(Create2Row("การอนุมัติ", f1.CommanderHighAllowName));
                table.Rows.Add(CreateEmptyRow());
                table.Rows.Add(Create2Row("ชื่อผู้ตรวจสอบ", f1.StaffPrefix + f1.StaffFirstName + " " + f1.StaffLastName));
                table.Rows.Add(Create2Row("ตำแหน่ง", f1.StaffPosition));
                table.Rows.Add(Create2Row("วันที่", f1.StaffDate));
            } else {
                table.Rows.Add(Create2Row("", "ไม่มีข้อมูล"));
            }



            hgc.Controls.Add(table);
        }

        private static TableRow Create2Row(string v1, string v2) {
            TableRow row;
            TableCell cell;
            Label label;

            row = new TableRow();
            cell = new TableCell();
            cell.Style.Add("padding-right", "20px");
            cell.Style.Add("text-align", "right");
            cell.Style.Add("vertical-align", "top");
            cell.Style.Add("color", "#808080");
            label = new Label();
            label.Text = v1;
            cell.Controls.Add(label);
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Style.Add("font-weight", "bold");
            label = new Label();
            label.Text = v2;
            cell.Controls.Add(label);
            row.Cells.Add(cell);

            return row;
        }
        public static TableRow CreateEmptyRow() {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Style.Add("display", "block");
            cell.Style.Add("height", "16px");
            row.Cells.Add(cell);
            return row;
        }

    }


}