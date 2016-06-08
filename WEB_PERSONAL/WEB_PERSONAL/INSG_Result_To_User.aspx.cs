using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class INSG_Result_To_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseManager.BindDropDown(ddlYear, "SELECT * FROM INS_YEAR", "YEAR_ID", "YEAR_ID", "--กรุณาเลือกปี--");
            DatabaseManager.BindGridView(gv1, "SELECT INS_REQ_ID รหัส, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = INSG_REQUEST.PS_CITIZEN_ID) ชื่อ, (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = INSG_REQUEST.INS_GRADEINSIGNIA_ID) เครื่องราช, REQ_DATE วันที่ขอ, STATE สถานะ FROM INSG_REQUEST");

            if (gv1.Rows.Count > 0)
            {

                TableHeaderCell newHeader = new TableHeaderCell();
                newHeader.Text = "เลือก";
                gv1.HeaderRow.Cells.Add(newHeader);

                for (int i = 0; i < gv1.Rows.Count; ++i)
                {

                    string id = gv1.Rows[i].Cells[0].Text;
                    string person_name = gv1.Rows[i].Cells[1].Text;
                    string ins_name = gv1.Rows[i].Cells[2].Text;
                    string req_date = gv1.Rows[i].Cells[3].Text;
                    string state = gv1.Rows[i].Cells[4].Text;



                    LinkButton lbu = new LinkButton();
                    lbu.Text = "แจ้งผล";
                    lbu.CssClass = "ps-button";
                    lbu.Click += (e2, e3) =>
                    {
                        lbCitizenName.Text = person_name;
                        lbInsignia.Text = ins_name;
                        lbReqDate.Text = req_date;
                        lbState.Text = state;
                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    gv1.Rows[i].Cells.Add(cell);

                    if (gv1.Rows[i].Cells[4].Text == "1")
                    {
                        gv1.Rows[i].Cells[4].Text = "ยังไม่แจ้งผล";
                    }
                    else if (gv1.Rows[i].Cells[4].Text == "1")
                    {
                        gv1.Rows[i].Cells[4].Text = "แจ้งผลแล้ว";
                    }

                }

                Util.NormalizeGridViewDate(gv1, 3);
            }
            }
        }
    }
    