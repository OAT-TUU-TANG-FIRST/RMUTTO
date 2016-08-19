using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using WEB_PERSONAL.Class;
using System.Data.OracleClient;

namespace WEB_PERSONAL {
    public partial class SEMINAR_GENERAL : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PS_FN_TH, PS_LN_TH, (SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE POSITION_WORK_ID = PS_WORK_POS_ID), (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE ADMIN_POSITION_ID = PS_ADMIN_POS_ID), (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE CAMPUS_ID = PS_CAMPUS_ID) || ' ' || (SELECT FACULTY_NAME FROM TB_FACULTY WHERE FACULTY_ID = PS_FACULTY_ID) || ' ' || (SELECT DIVISION_NAME FROM TB_DIVISION WHERE DIVISION_ID = PS_DIVISION_ID) || ' ' || (SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE WORK_ID = PS_WORK_DIVISION_ID) FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + loginPerson.CitizenID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lblName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lblLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lblPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lblDegree.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lblCampus.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                        }
                    }
                }
            }

            if (!IsPostBack) {
                txtBudget.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
            }
        }

        protected void ClearData() {
            lblName.Text = "";
            lblLastName.Text = "";
            lblPosition.Text = "";
            lblDegree.Text = "";
            lblCampus.Text = "";
            txtNameOfProject.Text = "";
            txtPlace.Text = "";
            txtDateFrom.Text = "";
            txtDateTO.Text = "";
            lblYear.Text = "";
            lblMonth.Text = "";
            lblDay.Text = "";
            txtBudget.Text = "";
            txtSupportBudget.Text = "";
            txtAbstract.Text = "";
            txtResult.Text = "";
            txtShow1.Text = "";
            txtShow2.Text = "";
            txtShow3.Text = "";
            txtShow4.Text = "";
            txtProblem.Text = "";
            txtComment.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e) {
            if (txtNameOfProject.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPlace.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสถานที่ฝึกอบรม/สัมมนา/ดูงาน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtDateFrom.Text == "" && txtDateTO.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน ตั้งแต่วันที่ - ถึงวันที่</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            // วันที่ติดลบ ไม่ให้
            DateTime dtFromDate = Util.ToDateTimeOracle(txtDateFrom.Text);
            DateTime dtToDate = Util.ToDateTimeOracle(txtDateTO.Text);
            int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;

            if (totalDay <= 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div> - ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน ตั้งแต่วันที่ - ถึงวันที่ : วันที่ไม่ถูกต้อง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            if (txtSupportBudget.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกแหล่งงบประมาณที่ได้รับการสนับสนุน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            Panel0.Visible = false;

            Seminar S = new Seminar();
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person PP = ps.LoginPerson;
            S.SEMINAR_NAME = lblName.Text;
            S.SEMINAR_LASTNAME = lblLastName.Text;
            S.SEMINAR_POSITION = lblPosition.Text;
            S.SEMINAR_DEGREE = lblDegree.Text;
            S.SEMINAR_CAMPUS = lblCampus.Text;
            S.SEMINAR_NAMEOFPROJECT = txtNameOfProject.Text;
            S.SEMINAR_PLACE = txtPlace.Text;
            S.SEMINAR_DATETIME_FROM = Util.ODT(txtDateFrom.Text);
            S.SEMINAR_DATETIME_TO = Util.ODT(txtDateTO.Text);
            S.SEMINAR_YEAR = Convert.ToInt32(lblYear.Text);
            S.SEMINAR_MONTH = Convert.ToInt32(lblMonth.Text);
            S.SEMINAR_DAY = Convert.ToInt32(lblDay.Text);
            S.SEMINAR_BUDGET = Convert.ToInt32(txtBudget.Text);
            S.SEMINAR_SUPPORT_BUDGET = txtSupportBudget.Text;
            S.SEMINAR_CERTIFICATE = txtCertificate.Text;
            S.SEMINAR_ABSTRACT = txtAbstract.Text;
            S.SEMINAR_RESULT = txtResult.Text;
            S.SEMINAR_SHOW_1 = txtShow1.Text;
            S.SEMINAR_SHOW_2 = txtShow2.Text;
            S.SEMINAR_SHOW_3 = txtShow3.Text;
            S.SEMINAR_SHOW_4 = txtShow4.Text;
            S.SEMINAR_PROBLEM = txtProblem.Text;
            S.SEMINAR_COMMENT = txtComment.Text;
            S.SEMINAR_SIGNED_DATETIME = DateTime.Now;
            S.CITIZEN_ID = PP.CitizenID;

            S.InsertSEMINAR();
            ClearData();
            MultiView1.ActiveViewIndex = 1;
        }
        //จากวันที่
        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDateTO.Text))
            {
                DateTime dtFromDate = Util.ToDateTimeOracle(txtDateFrom.Text);
                DateTime dtToDate = Util.ToDateTimeOracle(txtDateTO.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;

                if (totalDay <= 0)
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                    notification.InnerHtml += "<div> - ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน ตั้งแต่วันที่ - ถึงวันที่ : วันที่ไม่ถูกต้อง</div>";

                    lblYear.Text = "0";
                    lblMonth.Text = "0";
                    lblDay.Text = "0";
                    return;
                }
                else
                {
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }

                DateTime df = DateTime.Parse(txtDateFrom.Text);
                DateTime dt = DateTime.Parse(txtDateTO.Text);
                int day = (int)(dt - df).TotalDays + 1;

                int year = (day / 365);
                int month = (day % 365) / 30;
                day = (day % 365) % 30;

                lblYear.Text = "" + year;
                lblMonth.Text = "" + month;
                lblDay.Text = "" + day;
            }
        }
        //ถึงวันที่
        protected void txtDateTO_TextChanged(object sender, EventArgs e) {
            DateTime dtFromDate = Util.ToDateTimeOracle(txtDateFrom.Text);
            DateTime dtToDate = Util.ToDateTimeOracle(txtDateTO.Text);
            int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;

            if (totalDay <= 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div> - ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน ตั้งแต่วันที่ - ถึงวันที่ : วันที่ไม่ถูกต้อง</div>";

                lblYear.Text = "0";
                lblMonth.Text = "0";
                lblDay.Text = "0";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            DateTime df = DateTime.Parse(txtDateFrom.Text);
            DateTime dt = DateTime.Parse(txtDateTO.Text);
            int day = (int)(dt - df).TotalDays + 1;

            int year = (day / 365);
            int month = (day % 365) / 30;
            day = (day % 365) % 30;

            lblYear.Text = "" + year;
            lblMonth.Text = "" + month;
            lblDay.Text = "" + day;
        }
        //เช็คติ๊กบ๊อค
        protected void chkBox_CheckedChanged(object sender, EventArgs e) {
            if (chkBox.Checked) {
                txtCertificate.Enabled = true;
                txtCertificate.Text = "";
            } else {
                txtCertificate.Enabled = false;
                txtCertificate.Text = "ไม่มี";
            }
        }

        
    }
}