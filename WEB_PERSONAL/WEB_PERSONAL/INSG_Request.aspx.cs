using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class INSG_Request : System.Web.UI.Page {

        private bool work = true;

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DatabaseManager.BindDropDown(ddlInsg, "SELECT * FROM INS_GRADEINSIGNIA ORDER BY ID_GRADEINSIGNIA DESC", "NAME_GRADEINSIGNIA_THA", "ID_GRADEINSIGNIA", "--กรุณาเลือกเครื่องราช--");
            }
            
        }

        protected void ddlInsg_SelectedIndexChanged(object sender, EventArgs e) {

            if(ddlInsg.SelectedIndex == 0) {
                srd.InnerHtml = "";
                return;
            }

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person lp = ps.LoginPerson;

            string isv = ddlInsg.SelectedValue;
            lp.WorkYear = 5;
            lp.Salary = 15000;

            int อายุงาน = lp.WorkYear;
            int เงินเดือน = lp.Salary;
            int เงินเดือนขั้นต่ำของชำนาญงาน = DatabaseManager.ExecuteInt("SELECT P_SAL_MIN FROM TB_POSITION_SAL_MINMAX WHERE P_POS_ID = 14102");
            int ปีดำรงตำแหน่งชำนาญงาน = 4;

            Clear();
            AddHeader("เงื่อนไข");
            if(lp.StaffTypeID == "1") {
                //บ.ม.
                if(isv == "12") {
                    if(อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    } 
                }
                //บ.ช.
                if (isv == "11") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    } 
                    if (เงินเดือน < เงินเดือนขั้นต่ำของชำนาญงาน) {
                        AddTrue("เงินเดือนต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    } else {
                        AddFalse("เงินเดือนต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    }
                    if (ปีดำรงตำแหน่งชำนาญงาน >= 10) {
                        AddTrue("ดำรงตำแหน่งชำนาญงานไม่น้อยกว่า 10 ปี ( " + ปีดำรงตำแหน่งชำนาญงาน + " / 10 ปี ) ");
                    } else {
                        AddFalse("ดำรงตำแหน่งชำนาญงานไม่น้อยกว่า 10 ปี ( " + ปีดำรงตำแหน่งชำนาญงาน + " / 10 ปี ) ");
                        work = false;
                    }
                }
                //จ.ม.
                if (isv == "10") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                    if (เงินเดือน >= เงินเดือนขั้นต่ำของชำนาญงาน) {
                        AddTrue("เงินเดือนไม่ต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    } else {
                        AddFalse("เงินเดือนไม่ต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    }
                }
                //จ.ช.
                if (isv == "9") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                    if (เงินเดือน >= เงินเดือนขั้นต่ำของชำนาญงาน) {
                        AddTrue("เงินเดือนไม่ต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    } else {
                        AddFalse("เงินเดือนไม่ต่ำกว่าขั้นต่ำของระดับชำนาญงาน ( " + เงินเดือน.ToString("#,###") + " / " + เงินเดือนขั้นต่ำของชำนาญงาน.ToString("#,###") + " บาท )");
                    }
                    if (ปีดำรงตำแหน่งชำนาญงาน >= 10) {
                        AddTrue("ดำรงตำแหน่งชำนาญงานไม่น้อยกว่า 10 ปี ( " + ปีดำรงตำแหน่งชำนาญงาน + " / 10 ปี ) ");
                    } else {
                        AddFalse("ดำรงตำแหน่งชำนาญงานไม่น้อยกว่า 10 ปี ( " + ปีดำรงตำแหน่งชำนาญงาน + " / 10 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "8") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "7") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "6") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "5") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "4") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "3") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "2") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
                if (isv == "1") {
                    if (อายุงาน >= 5) {
                        AddTrue("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                    } else {
                        AddFalse("อายุงานครบ 5 ปี ( " + lp.WorkYear + " / 5 ปี ) ");
                        work = false;
                    }
                }
            }
            AddSeparator();
            AddHeader("สรุปผลการขอ");
            if (work) {
                AddTrue("สามารถข้อได้");
            } else {
                AddFalse("ไม่สามารถข้อได้");
            }
        }
        private void Clear() {
            srd.InnerHtml = "";
        }
        private void AddHeader(string text) {
            srd.InnerHtml += "<div style='font-size: 24px;'>" + text + "</div>";
        }
        private void AddSeparator() {
            srd.InnerHtml += "<div class='ps-separator'></div>";
        }
        private void AddTrue(string text) {
            srd.InnerHtml += "<div style='color : #208000'><img src='Image/Small/correct.png' class='icon_left' />" + text + "</div>";
        }
        private void AddFalse(string text) {
            srd.InnerHtml += "<div style='color : #ff0000'><img src='Image/Small/delete.png' class='icon_left' />" + text + "</div>";
            work = false;
        }
    }
}