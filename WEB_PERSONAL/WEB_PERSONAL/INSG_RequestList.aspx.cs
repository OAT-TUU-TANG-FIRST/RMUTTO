using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class INSG_RequestList : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DatabaseManager.BindGridView(gv1, "SELECT INS_REQ_ID รหัส, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = INSG_REQUEST.PS_CITIZEN_ID) ชื่อ, (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = INSG_REQUEST.INS_GRADEINSIGNIA_ID) เครื่องราช, REQ_DATE วันที่ขอ, STATE สถานะ FROM INSG_REQUEST");

            if (gv1.Rows.Count > 0) {

                TableHeaderCell newHeader = new TableHeaderCell();
                newHeader.Text = "เลือก";
                gv1.HeaderRow.Cells.Add(newHeader);

                for (int i = 0; i < gv1.Rows.Count; ++i) {

                    string id = gv1.Rows[i].Cells[0].Text;
                    string person_name = gv1.Rows[i].Cells[1].Text;
                    string ins_name = gv1.Rows[i].Cells[2].Text;
                    string req_date = gv1.Rows[i].Cells[3].Text;
                    string state = gv1.Rows[i].Cells[4].Text;

                    LinkButton lbu = new LinkButton();
                    lbu.Text = "เลือก";
                    lbu.CssClass = "ps-button";
                    lbu.Click += (e2, e3) => {
                        lbCitizenName.Text = person_name;
                        lbInsignia.Text = ins_name;
                        lbReqDate.Text = req_date;
                        lbState.Text = state;

                        MultiView1.ActiveViewIndex = 1;
                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    gv1.Rows[i].Cells.Add(cell);

                    if(gv1.Rows[i].Cells[4].Text == "1") {
                        gv1.Rows[i].Cells[4].Text = "ยังไม่รับเรื่อง";
                    }
                    else if (gv1.Rows[i].Cells[4].Text == "1") {
                        gv1.Rows[i].Cells[4].Text = "รับเรื่องแล้ว";
                    }

                }

                Util.NormalizeGridViewDate(gv1, 3);
                
            }
        }

        protected void lbuBack_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}