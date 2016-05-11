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
            
            DatabaseManager.BindGridView(gv1, "SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.PS_CITIZEN_ID) ชื่อผู้ลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล, LEV_MAIN.FROM_DATE จากวันที่, LEV_MAIN.TO_DATE ถึงวันที่, LEV_MAIN.TOTAL_DAY รวมวัน, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CL_ID) ผู้บังคับบัญชาระดับต่ำ, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_PERSON.PS_CITIZEN_ID = LEV_MAIN.CH_ID) ผู้บังคับบัญชาระดับสูง FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 1 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID ORDER BY LEV_MAIN.LEAVE_ID DESC");
            DatabaseManager.BindGridView(gv2, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 2 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");
            DatabaseManager.BindGridView(gv3, "SELECT LEV_MAIN.*, LEV_FORM1.* FROM LEV_MAIN, LEV_FORM1 WHERE LEAVE_TYPE_ID = 3 AND LEV_MAIN.LEAVE_ID = LEV_FORM1.LEAVE_ID");

            if (gv1.Rows.Count > 0) {

                Util.GridViewAddCheckBox(gv1);

                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = "จัดการ";
                gv1.HeaderRow.Cells.Add(headerCell);

                for (int i = 0; i < gv1.Rows.Count; ++i) {
                    string ID = gv1.Rows[i].Cells[1].Text;
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
                            btn.Text = "<img src='Image/Small/document-edit.png'></img>";
                            btn.Click += (e2, e3) => {
                                MV1_1.ActiveViewIndex = 1;
                                Form1Package p = DatabaseManager.GetForm1Package(ID);
                                lbPuyEditLeaveID.Text = p.LeaveID;
                                tbPuyEditCitizenID.Text = p.CitizenID;
                                tbPuyEditFromDate.Text = p.FromDate;
                                tbPuyEditToDate.Text = p.ToDate;
                                tbPuyEditReason.Text = p.Reason;
                                tbPuyEditContact.Text = p.Contact;
                                tbPuyEditPhone.Text = p.Phone;
                                if(p.DoctorCertificate != "") {
                                    string loc = "Upload/DrCer/" + p.DoctorCertificate;
                                    divPuyEditDrCer.InnerHtml = "<a href='" + loc + "'><img src='" + loc + "' style='width: 200px;' /></a>";
                                } else {
                                    divPuyEditDrCer.InnerHtml = "";
                                }
                                tbPuyEditCL.Text = p.CommanderLowID;
                                tbPuyEditCLCom.Text = p.CommanderLowComment;
                                tbPuyEditCLDate.Text = p.CommanderLowDate;
                                tbPuyEditCH.Text = p.CommanderHighID;
                                tbPuyEditCHCom.Text = p.CommanderHighComment;
                                tbPuyEditCHDate.Text = p.CommanderHighDate;
                                if(p.CommanderHighAllow == "1") {
                                    rbPuyEditCHAllowOK.Checked = true;
                                } else {
                                    rbPuyEditCHAllowKO.Checked = true;
                                }
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


        private void ToggleOn(LinkButton target) {
            lbuLF1Select.CssClass = "ps-vs";
            lbuLF2Select.CssClass = "ps-vs";
            lbuLF3Select.CssClass = "ps-vs";
            lbuLF4Select.CssClass = "ps-vs";
            lbuLF5Select.CssClass = "ps-vs";
            lbuLF6Select.CssClass = "ps-vs";
            lbuLF7Select.CssClass = "ps-vs";
            target.CssClass = "ps-vs-sel";
        }
        protected void lbuLF1Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 0;
            MV1_1.ActiveViewIndex = 0;
            ToggleOn(lbuLF1Select);
        }

        protected void lbuLF2Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 1;
            ToggleOn(lbuLF2Select);
        }

        protected void lbuLF3Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 2;
            ToggleOn(lbuLF3Select);
        }

        protected void lbuLF4Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 3;
            ToggleOn(lbuLF4Select);
        }

        protected void lbuLF5Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 4;
            ToggleOn(lbuLF5Select);
        }

        protected void lbuLF6Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 5;
            ToggleOn(lbuLF6Select);
        }

        protected void lbuLF7Select_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 6;
            ToggleOn(lbuLF7Select);
        }

        protected void lbuPuyEditBack_Click(object sender, EventArgs e) {
            MV1_1.ActiveViewIndex = 0;
        }
    }
}