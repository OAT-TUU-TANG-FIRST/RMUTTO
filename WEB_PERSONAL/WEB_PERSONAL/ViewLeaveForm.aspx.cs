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
            if(Request.QueryString["Form"] == null ||
                Request.QueryString["LeaveID"] == null) {
                return;
            }
            string form = Request.QueryString["Form"].ToString();
            string leaveID = Request.QueryString["LeaveID"].ToString();
            if(form == "1") {
                if(leaveID == "all") {
                    using(OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        using(OleDbCommand com = new OleDbCommand("SELECT LEAVE_ID FROM LEV_MAIN", con)) {
                            using(OleDbDataReader reader = com.ExecuteReader()) {
                                while(reader.Read()) {
                                    CreateForm1Display(reader.GetValue(0).ToString());
                                }
                                
                            }
                        }
                    }
                } else {

                    CreateForm1Display(leaveID);
                }
                
            } else {

            }
            
        }

        public void CreateForm1Display(string leaveID) {

            Form1Package f1 = DatabaseManager.GetForm1Package(leaveID);
            if (f1 != null) {
                lbLeaveID.Text = f1.LeaveID;
                lbReqDate.Text = f1.RequestDate;
                lbName.Text = f1.PersonPrefix + f1.PersonFirstName + " " + f1.PersonLastName;
                lbPosition.Text = f1.PersonPosition;
                lbRank.Text = f1.PersonRank;
                lbDepartment.Text = f1.PersonDepartment;
                lbLeaveType.Text = f1.LeaveTypeName;
                lbFromDate.Text = f1.FromDate;
                lbToDate.Text = f1.ToDate;
                lbTotalDay.Text = f1.TotalDay + " วัน";
                lbReason.Text = f1.Reason;
                lbContact.Text = f1.Contact;
                lbPhone.Text = f1.Phone;
                if(f1.LastFromDate == "") {
                    lbLastFromDate.Text = "-";
                    lbLastToDate.Text = "-";
                    lbLastTotalDay.Text = "-";
                } else {
                    lbLastFromDate.Text = f1.LastFromDate;
                    lbLastToDate.Text = f1.LastToDate;
                    lbLastTotalDay.Text = f1.LastTotalDay + " วัน";
                }
                
                lbCmdLowName.Text = f1.CommanderLowPrefix + f1.CommanderLowFirstName + " " + f1.CommanderLowLastName;
                lbCmdLowPosition.Text = f1.CommanderLowPosition;
                lbCmdLowComment.Text = f1.CommanderLowComment;
                lbCmdLowDate.Text = f1.CommanderLowDate;
                lbCmdHighName.Text = f1.CommanderHighPrefix + f1.CommanderHighFirstName + " " + f1.CommanderHighLastName;
                lbCmdHighPosition.Text = f1.CommanderHighPosition;
                lbCmdHighComment.Text = f1.CommanderHighComment;
                lbCmdHighDate.Text = f1.CommanderHighDate;
                lbCmdHighAllow.Text = f1.CommanderHighAllowName;
            }

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