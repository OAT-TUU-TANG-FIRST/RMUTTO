using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class LeaveManager : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
            DatabaseManager.BindGridView(gv1, "SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.PS_CITIZEN_ID) ชื่อผู้ลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEV_MAIN.FROM_DATE จากวันที่, LEV_MAIN.TO_DATE ถึงวันที่, LEV_MAIN.TOTAL_DAY รวมวัน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CL_ID) ผู้บังคับบัญชาระดับต่ำ, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CH_ID) ผู้บังคับบัญชาระดับสูง FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 1 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
            DatabaseManager.BindGridView(gv2, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 2 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
            DatabaseManager.BindGridView(gv3, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 3 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
            


            if (gv1.Rows.Count > 0) {

                Util.GridViewAddCheckBox(gv1);

                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "จัดการ";
                gv1.HeaderRow.Cells.Add(headerCell);

                for (int i = 0; i < gv1.Rows.Count; ++i) {
                    string ID = gv1.Rows[i].Cells[0].Text;
                    {

 

                        TableCell cell = new TableCell();
                        {
                            LinkButton btn = new LinkButton();
                            btn.CssClass = "ps-button-img";
                            btn.Text = "<img src='Image/Small/search.png'></img>";
                            btn.Click += (e2, e3) => {
                                Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                            };
                            cell.Controls.Add(btn);
                        }
                        {
                            LinkButton btn = new LinkButton();
                            btn.CssClass = "ps-button-img";
                            btn.Text = "<img src='Image/Small/wrench.png'></img>";
                            btn.Click += (e2, e3) => {
                                //Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                            };
                            cell.Controls.Add(btn);
                        }
                        {
                            LinkButton btn = new LinkButton();
                            btn.CssClass = "ps-button-img";
                            btn.Text = "<img src='Image/Small/bin.png'></img>";
                            btn.Click += (e2, e3) => {
                                //Response.Redirect("ViewLeaveForm.aspx?Form=1&LeaveID=" + ID);
                            };
                            cell.Controls.Add(btn);
                        }


                        gv1.Rows[i].Cells.Add(cell);
                    }
                }
                

            }

            Util.NormalizeGridViewDate(gv1, 3);
            Util.NormalizeGridViewDate(gv1, 4);
            Util.NormalizeGridViewDate(gv1, 5);

        }
        protected void Page_LoadComplete(object sender, EventArgs e) {
            /*switch (MultiView1.ActiveViewIndex) {
                case 0:
                    DatabaseManager.BindGridView(gv1, "SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.PS_CITIZEN_ID) ชื่อผู้ลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEV_MAIN.FROM_DATE จากวันที่, LEV_MAIN.TO_DATE ถึงวันที่, LEV_MAIN.TOTAL_DAY รวมวัน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CL_ID) ผู้บังคับบัญชาระดับต่ำ, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CH_ID) ผู้บังคับบัญชาระดับสูง FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 1 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
                    Util.NormalizeGridViewDate(gv1, 2);
                    Util.NormalizeGridViewDate(gv1, 3);
                    Util.NormalizeGridViewDate(gv1, 4);
                    break;
                case 1: DatabaseManager.BindGridView(gv2, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 2 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
                    break;
                case 2: DatabaseManager.BindGridView(gv3, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 3 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
                    break;
            }*/
            
        }



        protected void lbuLF1Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
            lbuLF1Select.CssClass = "ps-vs-sel";
            lbuLF2Select.CssClass = "ps-vs";
            lbuLF3Select.CssClass = "ps-vs";
        }

        protected void lbuLF2Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
            lbuLF1Select.CssClass = "ps-vs";
            lbuLF2Select.CssClass = "ps-vs-sel";
            lbuLF3Select.CssClass = "ps-vs";
        }

        protected void lbuLF3Select_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
            lbuLF1Select.CssClass = "ps-vs";
            lbuLF2Select.CssClass = "ps-vs";
            lbuLF3Select.CssClass = "ps-vs-sel";
        }
    }
}