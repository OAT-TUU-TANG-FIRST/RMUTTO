using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Web.UI.HtmlControls;
using WEB_PERSONAL.Class;
using System.IO;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class Leave : System.Web.UI.Page {

        private int businessBeforeDay = 3;
        private int restBeforeDay = 3;
        private int giveBirthBeforeDay = 3;
        private int helpGiveBirthBeforeDay = 3;
        private int ordainBeforeDay = 60;
        private int hujBeforeDay = 60;

        protected void Page_Load(object sender, EventArgs e) {
            /*if (!IsPostBack) {
                DatabaseManager.BindDropDown(ddlLeaveType, "SELECT * FROM LEV_TYPE", "LEAVE_TYPE_NAME", "LEAVE_TYPE_ID", "-- กรุณาเลือกประเภทการลา --");
            }*/
            DateTime dt = DateTime.Today;
            lb1.Text = dt.AddDays(60).ToLongDateString();
            lb4.Text = dt.AddDays(60).ToLongDateString();
            lb2.Text = dt.AddDays(3).ToLongDateString();
            lb3.Text = dt.AddDays(3).ToLongDateString();
            lb5.Text = dt.AddDays(3).ToLongDateString();
            lb6.Text = dt.AddDays(3).ToLongDateString();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                OracleConnection.ClearAllPools();
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT SICK_MAX - SICK_NOW, BUSINESS_MAX - BUSINESS_NOW, REST_MAX - REST_NOW, ORDAIN_MAX - ORDAIN_NOW, HUJ_MAX - HUJ_NOW FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear(), con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            lbSickLeftDay.Text = reader.GetInt32(0).ToString();
                            lbBusinessLeftDay.Text = reader.GetInt32(1).ToString();
                            lbRestLeftDay.Text = reader.GetInt32(2).ToString();
                            lbOrdainLeftDay.Text = reader.GetInt32(3).ToString();
                            lbHujLeftDay.Text = reader.GetInt32(4).ToString();
                        }
                    }
                }
            }
        }

        protected void lbuS1Check_Click(object sender, EventArgs e) {

            ClearNotification();
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            trS2BirthDate.Visible = false;
            trS2WorkInDate.Visible = false;
            trS2WifeName.Visible = false;
            trS2GBDate.Visible = false;
            trS2Ordained.Visible = false;
            trS2TempleName.Visible = false;
            trS2TempleLocation.Visible = false;
            trS2OrdainDate.Visible = false;
            trS2Hujed.Visible = false;
            trS2Reason.Visible = false;
            trS2Contact.Visible = false;
            trS2Phone.Visible = false;
            trS2DrCer.Visible = false;
            trS2RestSave.Visible = false;
            trS2RestLeft.Visible = false;
            trS2RestTotal.Visible = false;

            if (hfLeaveTypeID.Value == "1") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
                trS2DrCer.Visible = true;
            } else if (hfLeaveTypeID.Value == "2") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "3") {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "4") {
                trS2RestSave.Visible = true;
                trS2RestLeft.Visible = true;
                trS2RestTotal.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "5") {
                trS2WifeName.Visible = true;
                trS2GBDate.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "6") {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Ordained.Visible = true;
                trS2TempleName.Visible = true;
                trS2TempleLocation.Visible = true;
                trS2OrdainDate.Visible = true;
                trS2Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "7") {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Hujed.Visible = true;
            }

            if(tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                ChangeNotification("danger", "กรุณากรอกวันที่ให้ถูกต้อง");
                return;
            } else {
                DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                int fromToNowtotalDay = (int)(dtFromDate - DateTime.Today).TotalDays;
                if (totalDay <= 0) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                int sick_now = -1;
                int sick_max = -1;
                int business_now = -1;
                int business_max = -1;
                int huj_now = -1;
                int huj_max = -1;
                int ordain_now = -1;
                int ordain_max = -1;
                {
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                        con.Open();
                        using (OracleCommand com = new OracleCommand("SELECT SICK_NOW, SICK_MAX, BUSINESS_NOW, BUSINESS_MAX, HUJ_NOW, HUJ_MAX, ORDAIN_NOW, ORDAIN_MAX FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'", con)) {
                            using (OracleDataReader reader = com.ExecuteReader()) {
                                while (reader.Read()) {
                                    sick_now = reader.GetInt32(0);
                                    sick_max = reader.GetInt32(1);
                                    business_now = reader.GetInt32(2);
                                    business_max = reader.GetInt32(3);
                                    huj_now = reader.GetInt32(4);
                                    huj_max = reader.GetInt32(5);
                                    ordain_now = reader.GetInt32(6);
                                    ordain_max = reader.GetInt32(7);
                                }
                            }
                        }

                    }
                }
                if(hfLeaveTypeID.Value == "1") {
                    if(sick_now + totalDay > sick_max) {
                        ChangeNotification("danger", "ไม่สามารถลาป่วยได้มากกว่า " + sick_max + " วัน คุณลาไปแล้ว " + sick_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (sick_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "2") {
                    if (fromToNowtotalDay < businessBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + businessBeforeDay + " วัน");
                        return;
                    } else if (business_now + totalDay > business_max) {
                        ChangeNotification("danger", "ไม่สามารถลากิจได้มากกว่า " + business_max + " วัน คุณลาไปแล้ว " + business_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (business_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "3") {
                    if (fromToNowtotalDay < giveBirthBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + giveBirthBeforeDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "4") {
                    if (fromToNowtotalDay < restBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + restBeforeDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "5") {
                    if (fromToNowtotalDay < helpGiveBirthBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + helpGiveBirthBeforeDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "6") {
                    if (fromToNowtotalDay < ordainBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + ordainBeforeDay + " วัน");
                        return;
                    } else if (huj_now + totalDay > huj_max) {
                        ChangeNotification("danger", "ไม่สามารถลาไปอุปสมบทได้มากกว่า " + ordain_max + " วัน คุณลาไปแล้ว " + ordain_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (ordain_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "7") {
                    if(fromToNowtotalDay < hujBeforeDay) {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + hujBeforeDay + " วัน");
                        return;
                    }
                    else if (huj_now + totalDay > huj_max) {
                        ChangeNotification("danger", "ไม่สามารถลาไปประกอบพิธีฮัจญ์ได้มากกว่า " + huj_max + " วัน คุณลาไปแล้ว " + huj_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (huj_now + totalDay) + " วัน");
                        return;
                    }
                }
            }

            if(hfLeaveTypeID.Value == "1" || hfLeaveTypeID.Value == "2" || hfLeaveTypeID.Value == "3") {
                if(tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if(tbS1Reason.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกเหตุผล");
                    return;
                }
                if (tbS1Contact.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
                if(hfLeaveTypeID.Value == "1") {
                    DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                    DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                    int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                    if (totalDay >= 30 && !FileUpload1.HasFile) {
                        ChangeNotification("danger", "คุณต้องมีใบรับรองแพทย์เมื่อทำการลาเกิน 30 วัน ลาครั้งนี้ " + totalDay + " วัน");
                        return;
                    }
                }
            }
            if (hfLeaveTypeID.Value == "4") {
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Contact.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
                DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                int max = DatabaseManager.ExecuteInt("SELECT REST_MAX FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear());
                int now = DatabaseManager.ExecuteInt("SELECT REST_NOW FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear());
                if (now + totalDay > max) {
                    ChangeNotification("danger", "ปีนี้คุณไม่สามารถลาพักผ่อนเกิน " + max + " วันได้ ลาไปแล้ว " + now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (totalDay + now) + " วัน");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "5") {
                if (tbS1WifeFirstName.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกชื่อจริงภริยา");
                    return;
                }
                if (tbS1WifeLastName.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกนามสกุลภริยา");
                    return;
                }
                if (tbS1GBDate.Text == "" || !Util.IsDateValid(tbS1GBDate.Text)) {
                    ChangeNotification("danger", "วันที่คลอดบุตรไม่ถูกต้อง");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Contact.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "6") {
                if (!rbS1OrdainedT.Checked && !rbS1OrdainedF.Checked) {
                    ChangeNotification("danger", "กรุณาเลือกการอุปสมบท");
                    return;
                }
                if (tbS1TempleName.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกชื่อวัด");
                    return;
                }
                if (tbS1TempleLocation.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกสถานที่");
                    return;
                }
                if (tbS1OrdainDate.Text == "" || !Util.IsDateValid(tbS1OrdainDate.Text)) {
                    ChangeNotification("danger", "วันที่อุปสมบทไม่ถูกต้อง");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Phone.Text == "") {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "7") {
                if (!rbS1HujedT.Checked && !rbS1HujedF.Checked) {
                    ChangeNotification("danger", "กรุณาเลือกการไปประกอบพิธีฮัจย์");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "" || !Util.IsDateValid(tbS1FromDate.Text) || !Util.IsDateValid(tbS1ToDate.Text)) {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
            }



            {
               
                MV1.ActiveViewIndex = 2;

                Session["LeaveSickFileUpload"] = FileUpload1;

                divReq.Visible = false;
                //ChangeNotification("info", "กรุณายืนยันข้อมูลอีกครั้ง");

                

                string leavedDate = "ไม่เคยลา";
                DateTime? lastFromDate = null;
                DateTime? lastToDate = null;
                int lastTotalDay = 0;

                int pastTotalDay = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_TYPE_ID = " + hfLeaveTypeID.Value + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + " AND CH_ALLOW = 1");

                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT FROM_DATE, TO_DATE, TOTAL_DAY FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_TYPE_ID = " + hfLeaveTypeID.Value + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + " AND CH_ALLOW = 1 ORDER BY LEAVE_ID DESC", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            if (reader.Read()) {
                                lastFromDate = reader.GetDateTime(0);
                                lastToDate = reader.GetDateTime(1);
                                lastTotalDay = (int)(lastToDate.Value - lastFromDate.Value).TotalDays + 1;
                                leavedDate = lastFromDate.Value.ToLongDateString() + " ถึง " + lastToDate.Value.ToLongDateString() + " รวม " + lastTotalDay + " วัน ";
                            } else {
                                lastTotalDay = 0;
                            }
                        }
                    }

                }

                int restSave = -1;
                int restLeft = -1;
                int restTotal = -1;
                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT REST_SAVE, REST_THIS FROM LEV_CLAIM WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "' AND YEAR = " + Util.BudgetYear(), con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            if (reader.Read()) {
                                restSave = reader.GetInt32(0);
                                restLeft = reader.GetInt32(1);
                                restTotal = restSave + restLeft;
                            }
                        }
                    }

                }


                lbS2PSName.Text = loginPerson.FullName;
                lbS2PSPos.Text = loginPerson.PositionName;
                lbS2PSAPos.Text = loginPerson.AdminPositionName;
                lbS2PSDept.Text = loginPerson.DivisionName;
                lbS2PSBirthDate.Text = loginPerson.BirthDate.Value.ToLongDateString();
                lbS2PSWorkInDate.Text = loginPerson.InWorkDate.Value.ToLongDateString();
                lbS2RestSave.Text = restSave + " วัน";
                lbS2RestLeft.Text = restLeft + " วัน";
                lbS2RestTotal.Text = restTotal + " วัน";
                lbS2WifeName.Text = tbS1WifeFirstName.Text + " " + tbS1WifeLastName.Text;
                lbS2GBDate.Text = tbS1GBDate.Text;
                lbS2Ordained.Text = rbS1OrdainedT.Checked ? "เคย" : "ไม่เคย";
                lbS2TempleName.Text = tbS1TempleName.Text;
                lbS2TempleLocation.Text = tbS1TempleLocation.Text;
                lbS2OrdainDate.Text = tbS1OrdainDate.Text;
                lbS2Hujed.Text = rbS1HujedT.Checked ? "เคย" : "ไม่เคย";
                lbS2LastFTTDate.Text = leavedDate;
                lbS2LeaveTypeName.Text = hfLeaveTypeName.Value;
                DateTime dtFromDate = Util.ToDateTimeOracle(tbS1FromDate.Text);
                DateTime dtToDate = Util.ToDateTimeOracle(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbS2FTTDate.Text = dtFromDate.ToLongDateString() + " ถึง " + dtToDate.ToLongDateString() + " รวม " + totalDay + " วัน";
                lbS2Statistic.Text = "ลามาแล้ว " + pastTotalDay + " วัน / ลาครั้งนี้ " + totalDay + " วัน / รวม " + (pastTotalDay + totalDay) + " วัน";
                lbS2Reason.Text = tbS1Reason.Text;
                lbS2Contact.Text = tbS1Contact.Text;
                lbS2Phone.Text = tbS1Phone.Text;
                string drCer;
                if (FileUpload1.HasFile) {
                    lbS2DrCer.Text = "มี";
                    FileInfo fi = new FileInfo(FileUpload1.FileName);
                    drCer = Util.RandomFileName() + fi.Extension;
                } else {
                    lbS2DrCer.Text = "ไม่มี";
                    drCer = "";
                }

                //----------CL CH--

                string psCLID = "";
                string psCHID = "";

                int รัฐมนตรีเจ้าสังกัดลาป่วยวัน = -1;
                int รัฐมนตรีเจ้าสังกัดลากิจวัน = -1;
                bool รัฐมนตรีเจ้าสังกัดลาคลอดบุตร = false;
                bool รัฐมนตรีเจ้าสังกัดลาช่วยเหลือภริยาคลอดบุตร = false;
                bool รัฐมนตรีเจ้าสังกัดลาพักผ่อน = false;
                bool รัฐมนตรีเจ้าสังกัดลาอุปสมบทฮัจญ์ = false;

                int เลขาธิการคณะกรรมการลาป่วยวัน = -1;
                int เลขาธิการคณะกรรมการลากิจวัน = -1;
                bool เลขาธิการคณะกรรมการลาคลอดบุตร = false;
                bool เลขาธิการคณะกรรมการลาช่วยเหลือภริยาคลอดบุตร = false;
                bool เลขาธิการคณะกรรมการลาพักผ่อน = false;
                bool เลขาธิการคณะกรรมการลาอุปสมบทฮัจญ์ = false;

                int อธิการบดีลาป่วยวัน = -1;
                int อธิการบดีลากิจวัน = -1;
                bool อธิการบดีลาคลอดบุตร = false;
                bool อธิการบดีลาช่วยเหลือภริยาคลอดบุตร = false;
                bool อธิการบดีลาพักผ่อน = false;
                bool อธิการบดีลาอุปสมบทฮัจญ์ = false;

                int คณะบดีลาป่วยวัน = -1;
                int คณะบดีลากิจวัน = -1;
                bool คณะบดีลาคลอดบุตร = false;
                bool คณะบดีลาช่วยเหลือภริยาคลอดบุตร = false;
                bool คณะบดีลาพักผ่อน = false;
                bool คณะบดีลาอุปสมบทฮัจญ์ = false;

                int หัวหน้าภาควิชาลาป่วยวัน = -1;
                int หัวหน้าภาควิชาลากิจวัน = -1;
                bool หัวหน้าภาควิชาลาคลอดบุตร = false;
                bool หัวหน้าภาควิชาลาช่วยเหลือภริยาคลอดบุตร = false;
                bool หัวหน้าภาควิชาลาพักผ่อน = false;
                bool หัวหน้าภาควิชาลาอุปสมบทฮัจญ์ = false;

                int หัวหน้าฝ่ายลาป่วยวัน = -1;
                int หัวหน้าฝ่ายลากิจวัน = -1;
                bool หัวหน้าฝ่ายลาคลอดบุตร = false;
                bool หัวหน้าฝ่ายลาช่วยเหลือภริยาคลอดบุตร = false;
                bool หัวหน้าฝ่ายลาพักผ่อน = false;
                bool หัวหน้าฝ่ายลาอุปสมบทฮัจญ์ = false;

                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT * FROM LEV_PERMISSION", con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {
                                int APID = reader.GetInt32(1);
                                if(APID == 10021) {
                                    รัฐมนตรีเจ้าสังกัดลาป่วยวัน = reader.GetInt32(2);
                                    รัฐมนตรีเจ้าสังกัดลากิจวัน = reader.GetInt32(3);
                                    รัฐมนตรีเจ้าสังกัดลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    รัฐมนตรีเจ้าสังกัดลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    รัฐมนตรีเจ้าสังกัดลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    รัฐมนตรีเจ้าสังกัดลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                } else if(APID == 10022) {
                                    เลขาธิการคณะกรรมการลาป่วยวัน = reader.GetInt32(2);
                                    เลขาธิการคณะกรรมการลากิจวัน = reader.GetInt32(3);
                                    เลขาธิการคณะกรรมการลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    เลขาธิการคณะกรรมการลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    เลขาธิการคณะกรรมการลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    เลขาธิการคณะกรรมการลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                } else if (APID == 1) {
                                    อธิการบดีลาป่วยวัน = reader.GetInt32(2);
                                    อธิการบดีลากิจวัน = reader.GetInt32(3);
                                    อธิการบดีลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    อธิการบดีลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    อธิการบดีลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    อธิการบดีลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                } else if (APID == 3) {
                                    คณะบดีลาป่วยวัน = reader.GetInt32(2);
                                    คณะบดีลากิจวัน = reader.GetInt32(3);
                                    คณะบดีลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    คณะบดีลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    คณะบดีลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    คณะบดีลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                } else if (APID == 10023) {
                                    หัวหน้าภาควิชาลาป่วยวัน = reader.GetInt32(2);
                                    หัวหน้าภาควิชาลากิจวัน = reader.GetInt32(3);
                                    หัวหน้าภาควิชาลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    หัวหน้าภาควิชาลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    หัวหน้าภาควิชาลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    หัวหน้าภาควิชาลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                } else if (APID == 10024) {
                                    หัวหน้าฝ่ายลาป่วยวัน = reader.GetInt32(2);
                                    หัวหน้าฝ่ายลากิจวัน = reader.GetInt32(3);
                                    หัวหน้าฝ่ายลาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(4));
                                    หัวหน้าฝ่ายลาช่วยเหลือภริยาคลอดบุตร = Convert.ToBoolean(reader.GetInt32(5));
                                    หัวหน้าฝ่ายลาพักผ่อน = Convert.ToBoolean(reader.GetInt32(6));
                                    หัวหน้าฝ่ายลาอุปสมบทฮัจญ์ = Convert.ToBoolean(reader.GetInt32(7));
                                }
                            }
                        }
                    }

                }

                if(hfLeaveTypeID.Value == "1") {
                    if(totalDay <= หัวหน้าฝ่ายลาป่วยวัน) {
                        if(loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCHID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= หัวหน้าภาควิชาลาป่วยวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= คณะบดีลาป่วยวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= อธิการบดีลาป่วยวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCLID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    }
                } else if (hfLeaveTypeID.Value == "2") {
                    if (totalDay <= หัวหน้าฝ่ายลากิจวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCHID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= หัวหน้าภาควิชาลากิจวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= คณะบดีลากิจวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else if (totalDay <= อธิการบดีลากิจวัน) {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    } else {
                        if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                            psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                            psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                            psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                            psCLID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                            psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                        } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                            psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                        }
                    }
                } else if (hfLeaveTypeID.Value == "3") {
                    if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                        psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                    } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                        psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                    } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                        psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                    } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    }
                } else if (hfLeaveTypeID.Value == "4") {
                    if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                        psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                    } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                        psCHID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                    } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                        psCHID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                    } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    }
                } else if (hfLeaveTypeID.Value == "5") {
                    if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                        psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                        psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                        psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                        psCHID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                    } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    }
                } else if (hfLeaveTypeID.Value == "6" || hfLeaveTypeID.Value == "7") {
                    if (loginPerson.AdminPositionID == "8") { //ตำแหน่งอ่ื่นๆ
                        psCLID = DatabaseManager.รหัสหัวหน้าฝ่าย(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10024") { //หัวหน้าฝ่าย
                        psCLID = DatabaseManager.รหัสหัวหน้าภาควิชา(loginPerson.DivisionID);
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10023") { //หัวหน้าภาควิชา
                        psCLID = DatabaseManager.รหัสคณบดี(loginPerson.FacultyID);
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "3") { //คณบดี
                        psCLID = DatabaseManager.รหัสอธิการบดี(loginPerson.CampusID);
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "1") { //อธิการบดี
                        psCHID = DatabaseManager.รหัสเลขาธิการคณะกรรมการ();
                    } else if (loginPerson.AdminPositionID == "10022") { //เลขาธิการคณะกรรมการ	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    } else if (loginPerson.AdminPositionID == "10021") { //รัฐมนตรีเจ้าสังกัด	
                        psCHID = DatabaseManager.รหัสรัฐมนตรีเจ้าสังกัด();
                    }
                }


                //Person psCL = DatabaseManager.GetPerson(psCLID);
                //Person psCH = DatabaseManager.GetPerson(psCHID);

                Person psCL = DatabaseManager.GetPerson("1700070000701");
                Person psCH = DatabaseManager.GetPerson("1700070000702");

                if (psCL == null) {
                    lbS2CL.Text = "-";
                }

                //----------- END CL CH--

                LeaveData leaveData = new LeaveData();
                leaveData.LeaveTypeID = int.Parse(hfLeaveTypeID.Value);
                leaveData.LeaveStatusID = 1;
                leaveData.PS_ID = loginPerson.CitizenID;
                leaveData.RequestDate = DateTime.Now;
                leaveData.FromDate = dtFromDate;
                leaveData.ToDate = dtToDate;
                leaveData.TotalDay = totalDay;

                if(psCL != null) {
                    leaveData.CL_ID = psCL.CitizenID;
                    leaveData.CL_Title = psCL.TitleName;
                    leaveData.CL_FirstName = psCL.FirstName;
                    leaveData.CL_LastName = psCL.LastName;
                    leaveData.CL_Position = psCL.PositionName;
                    leaveData.CL_AdminPosition = psCL.AdminPositionName;
                    lbS2CL.Text = "<span class='ps-lb-red-b'>" + psCL.FirstNameAndLastName + "</span><br />" + psCL.CitizenID + "<br />" + psCL.PositionName + "<br />" + psCL.AdminPositionName;
                } else {
                    leaveData.CL_ID = "";
                    leaveData.CL_Title = "";
                    leaveData.CL_FirstName = "";
                    leaveData.CL_LastName = "";
                    leaveData.CL_Position = "";
                    leaveData.CL_AdminPosition = "";
                    leaveData.LeaveStatusID = 2;
                }
                
                leaveData.CH_ID = psCH.CitizenID;
                leaveData.CH_Title = psCH.TitleName;
                leaveData.CH_FirstName = psCH.FirstName;
                leaveData.CH_LastName = psCH.LastName;
                leaveData.CH_Position = psCH.PositionName;
                leaveData.CH_AdminPosition = psCH.AdminPositionName;
                lbS2CH.Text = "<span class='ps-lb-red-b'>" + psCH.FirstNameAndLastName + "</span><br />" + psCH.CitizenID + "<br />" + psCH.PositionName + "<br />" + psCH.AdminPositionName;

                leaveData.PS_Title = loginPerson.TitleName;
                leaveData.PS_FirstName = loginPerson.FirstName;
                leaveData.PS_LastName = loginPerson.LastName;
                leaveData.PS_Position = loginPerson.PositionName;
                leaveData.PS_Department = loginPerson.DivisionName;
                leaveData.PS_AdminPosition = loginPerson.AdminPositionName;
                leaveData.PS_BirthDate = loginPerson.BirthDate;
                leaveData.PS_WorkInDate = loginPerson.InWorkDate;
                leaveData.Reason = tbS1Reason.Text;
                leaveData.Contact = tbS1Contact.Text;
                leaveData.Telephone = tbS1Phone.Text;
                if (lastFromDate.HasValue) {
                    leaveData.LastFromDate = lastFromDate;
                    leaveData.LastToDate = lastToDate;
                }
                leaveData.LastTotalDay = lastTotalDay;

                leaveData.DocterCertificationFileName = drCer;
                leaveData.CountPast = pastTotalDay;
                leaveData.CountNow = totalDay;
                leaveData.CountTotal = pastTotalDay + totalDay;
                leaveData.RestLeft = restLeft;
                leaveData.RestSave = restSave;
                leaveData.RestTotal = restTotal;
                leaveData.WifeFirstName = tbS1WifeFirstName.Text;
                leaveData.WifeLastName = tbS1WifeLastName.Text;
                if(hfLeaveTypeID.Value == "5")
                    leaveData.GiveBirthDate = Util.ToDateTimeOracle(tbS1GBDate.Text);
                leaveData.Ordained = rbS1OrdainedT.Checked ? 1 : 0;
                leaveData.TempleName = tbS1TempleName.Text;
                leaveData.TempleLocation = tbS1TempleLocation.Text;
                if (hfLeaveTypeID.Value == "6")
                    leaveData.OrdainDate = Util.ToDateTimeOracle(tbS1OrdainDate.Text);
                leaveData.Hujed = rbS1HujedT.Checked ? 1 : 0;
                Session["LeaveData"] = leaveData;

                hfFileUploadName.Value = drCer;

                string _psCLImage = DatabaseManager.GetPersonImageFileName(psCL.CitizenID);
                string _psCHImage = DatabaseManager.GetPersonImageFileName(psCH.CitizenID);
                if (_psCLImage != "") {
                    psCLImage.Src = "Upload/PersonImage/" + _psCLImage;
                }
                if (_psCHImage != "") {
                    psCHImage.Src = "Upload/PersonImage/" + _psCHImage;
                }

            }



        }

        protected void lbuS2Back_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 1;
            ClearNotification();
            divReq.Visible = true;
        }

        protected void lbuS2Finish_Click(object sender, EventArgs e) {
            LeaveData leaveData = (LeaveData)(Session["LeaveData"]);
            leaveData.LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_MAIN_ID");
            if(hfLeaveTypeID.Value == "1") {
                leaveData.AddLeaveSick();
                FileUpload fu = (FileUpload)Session["LeaveSickFileUpload"];
                if (fu.HasFile) {
                    fu.SaveAs(Server.MapPath("Upload/DrCer/" + hfFileUploadName.Value));
                }
            } else if (hfLeaveTypeID.Value == "2") {
                leaveData.AddLeaveBusiness();
            } else if (hfLeaveTypeID.Value == "3") {
                leaveData.AddLeaveGiveBirth();
            } else if (hfLeaveTypeID.Value == "4") {
                leaveData.AddLeaveRest();
            } else if (hfLeaveTypeID.Value == "5") {
                leaveData.AddLeaveHelpGiveBirth();
            } else if (hfLeaveTypeID.Value == "6") {
                leaveData.AddLeaveOrdain();
            } else if (hfLeaveTypeID.Value == "7") {
                leaveData.AddLeaveHuj();
            }

            ClearNotification();
            MV1.ActiveViewIndex = 3;
        }


        /*protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person pp = ps.LoginPerson;
            if(hfLeaveTypeID.Value == "1") {
                if(DatabaseManager.ExecuteInt("SELECT SICK_NOW - SICK_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาป่วยอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "2") {
                if (DatabaseManager.ExecuteInt("SELECT BUSINESS_NOW - BUSINESS_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลากิจอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "3") {
                if (DatabaseManager.ExecuteInt("SELECT GB_NOW - GB_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาคลอดบุตรอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "4") {
                if (DatabaseManager.ExecuteInt("SELECT REST_NOW - REST_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาพักผ่อนอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "5") {
                if (DatabaseManager.ExecuteInt("SELECT HGB_NOW - HGB_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปช่วยเหลือภริยาที่คลอดบุตรอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "6") {
                if (DatabaseManager.ExecuteInt("SELECT ORDAIN_NOW - ORDAIN_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปอุปสมบทอยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            } else if (hfLeaveTypeID.Value == "7") {
                if (DatabaseManager.ExecuteInt("SELECT HUJ_NOW - HUJ_REQ FROM LEV_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND PS_CITIZEN_ID = '" + pp.CitizenID + "'") != 0) {
                    ChangeNotification("danger", "ไม่สามารถทำการลาได้เนื่องจากมีการลาไปประกอบพิธีฮัจย์อยู่ในระหว่างดำเนินการ");
                    ddlLeaveType.SelectedIndex = 0;
                    return;
                }
            }

            //lbLeaveTypeName.Text = "ข้อมูล" + ddlLeaveType.SelectedItem.Text;
            lbLeaveTypeName2.Text = "ข้อมูล" + ddlLeaveType.SelectedItem.Text;
            if(ddlLeaveType.SelectedIndex == 0) {
                MV1.ActiveViewIndex = -1;
                ClearNotification();
            } else {
                MV1.ActiveViewIndex = 1;
                ChangeNotification("info", "กรุณากรอกข้อมูล");
            }

            trS1WifeName.Visible = false;
            trS1GBDate.Visible = false;
            trS1Ordained.Visible = false;
            trS1TempleName.Visible = false;
            trS1TempleLocation.Visible = false;
            trS1OrdainDate.Visible = false;
            trS1Hujed.Visible = false;
            trS1Reason.Visible = false;
            trS1Contact.Visible = false;
            trS1Phone.Visible = false;
            trS1DrCer.Visible = false;
            if (hfLeaveTypeID.Value == "1") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
                trS1DrCer.Visible = true;
            } else if(hfLeaveTypeID.Value == "2") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "3") {
                trS1Reason.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "4") {
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "5") {
                trS1WifeName.Visible = true;
                trS1GBDate.Visible = true;
                trS1Contact.Visible = true;
                trS1Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "6") {
                trS1Ordained.Visible = true;
                trS1TempleName.Visible = true;
                trS1TempleLocation.Visible = true;
                trS1OrdainDate.Visible = true;
                trS1Phone.Visible = true;
            } else if (hfLeaveTypeID.Value == "7") {
                trS1Hujed.Visible = true;
            }

        }*/

        private void ChangeNotification(string type) {
            switch (type) {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
        }
        private void ChangeNotification(string type, string text) {
            switch (type) {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
            notification.InnerHtml = text;
        }
        private void ClearNotification() {
            notification.Attributes["class"] = null;
            notification.InnerHtml = "";
        }
        private void AddNotification(string text) {
            notification.InnerHtml += text;
        }

        protected void lbuBackMain_Click(object sender, EventArgs e) {
            Response.Redirect("Default.aspx");
        }

        protected void lbuHistory_Click(object sender, EventArgs e) {
            Response.Redirect("LeaveHistory.aspx");
        }
        protected void lbuSelectSick_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "1";
            hfLeaveTypeName.Value = "ลาป่วย";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqSick.Visible = true;
            HideAllFromFill();
            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
            trS1DrCer.Visible = true;
        }
        protected void lbuSelectBusiness_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "2";
            hfLeaveTypeName.Value = "ลากิจ";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqBusiness.Visible = true;
            HideAllFromFill();
            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectRest_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "4";
            hfLeaveTypeName.Value = "ลาพักผ่อน";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqRest.Visible = true;
            HideAllFromFill();
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectGiveBirth_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "3";
            hfLeaveTypeName.Value = "ลาคลอดบุตร";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqGiveBirth.Visible = true;
            HideAllFromFill();
            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectHelpGiveBirth_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "5";
            hfLeaveTypeName.Value = "ลาไปช่วยเหลือภริยาที่คลอดบุตร";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqHelpGiveBirth.Visible = true;
            HideAllFromFill();
            trS1WifeName.Visible = true;
            trS1GBDate.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectOrdain_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "6";
            hfLeaveTypeName.Value = "ลาไปอุปสมบท";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqOrdain.Visible = true;
            HideAllFromFill();
            trS1Ordained.Visible = true;
            trS1TempleName.Visible = true;
            trS1TempleLocation.Visible = true;
            trS1OrdainDate.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectHuj_Click(object sender, EventArgs e) {
            hfLeaveTypeID.Value = "7";
            hfLeaveTypeName.Value = "ลาไปประกอบพิธีฮัจญ์";
            MV1.ActiveViewIndex = 1;
            HideAllReq();
            trReqHuj.Visible = true;
            HideAllFromFill();
            trS1Hujed.Visible = true;
        }
        private void HideAllReq() {
            trReqSick.Visible = false;
            trReqBusiness.Visible = false;
            trReqRest.Visible = false;
            trReqGiveBirth.Visible = false;
            trReqHelpGiveBirth.Visible = false;
            trReqOrdain.Visible = false;
            trReqHuj.Visible = false;
        }
        private void ShowAllReq() {
            trReqSick.Visible = true;
            trReqBusiness.Visible = true;
            trReqRest.Visible = true;
            trReqGiveBirth.Visible = true;
            trReqHelpGiveBirth.Visible = true;
            trReqOrdain.Visible = true;
            trReqHuj.Visible = true;
        }
        private void HideAllFromFill() {
            trS1WifeName.Visible = false;
            trS1GBDate.Visible = false;
            trS1Ordained.Visible = false;
            trS1TempleName.Visible = false;
            trS1TempleLocation.Visible = false;
            trS1OrdainDate.Visible = false;
            trS1Hujed.Visible = false;
            trS1Reason.Visible = false;
            trS1Contact.Visible = false;
            trS1Phone.Visible = false;
            trS1DrCer.Visible = false;
        }

        protected void lbuS1Back_Click(object sender, EventArgs e) {
            MV1.ActiveViewIndex = 0;
            ShowAllReq();
            ClearNotification();
        }
    }

}