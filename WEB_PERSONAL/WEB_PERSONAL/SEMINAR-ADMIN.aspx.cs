using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class SEMINAR_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person ps = PersonnelSystem.GetPersonnelSystem(this).LoginPerson;
            if (ps.Permission == 2)
            {
                if (!IsPostBack)
                {
                    txtSearchSeminarCitizen.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                    txtBudget.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถใช้งานหน้าดังกล่าวได้ เนื่องจากสิทธิ์ไม่ถึง')", true);
                Response.Redirect("Default.aspx");
            }

        }
        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["SEMINAR"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["SEMINAR"] = data;
        }

        #endregion

        void BindData1()
        {
            Seminar S = new Seminar();
            DataTable dt = S.GetSEMINAR(txtSearchSeminarCitizen.Text, "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void ClearData()
        {
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

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow == null)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณาทำการค้นหารายชื่อ และเลือกข้อมูลที่ต้องการจะแก้ไข</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกรหัสบัตรประชาชน 13 หลักที่ช่องค้นหาและเลือกข้อมูลที่ต้องการแก้ไข เมื่อแก้ไขเสร็จแล้วให้กดปุ่มบันทึกอีกครั้ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

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

            Panel2.Visible = false;
            Panel3.Visible = false;

            Seminar S = new Seminar();
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

            GridViewRow row = GridView1.SelectedRow;
            Label LabelID = row.FindControl("lblSEidEDIT") as Label;
            S.SEMINAR_ID = Convert.ToInt32(LabelID.Text);

            Label LabelCitizenID = row.FindControl("lblSECitizenIDEDIT") as Label;
            S.CITIZEN_ID = LabelCitizenID.Text;

            S.UpdateSEMINAR();
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
        protected void txtDateTO_TextChanged(object sender, EventArgs e)
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
        //เช็คติ๊กบ๊อค
        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow != null)
            {
                if (chkBox.Checked)
                {
                    txtCertificate.Enabled = true;
                    txtCertificate.Text = "";
                }
                else
                {
                    txtCertificate.Enabled = false;
                    txtCertificate.Text = "ไม่มี";
                }
            }
        }

        protected void lbuNextV1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                //lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อโครงการ " + DataBinder.Eval(e.Row.DataItem, "SEMINAR_NAMEOFPROJECT") + " ใช่ไหม ?');");
            }
        }

        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Seminar s = new Seminar();
            s.SEMINAR_ID = id;
            s.DeleteSEMINAR();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void myGridViewSeminar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }
        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchSeminarCitizen.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องคำค้นหา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtSearchSeminarCitizen.Text.Length < 13)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องค้นหาให้ครบ 13 หลัก</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string result = "";
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID FROM TB_SEMINAR WHERE CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetString(0);
                        }
                    }
                }

                if (result == txtSearchSeminarCitizen.Text)
                {
                    Seminar s = new Seminar();
                    DataTable dt = s.GetSEMINAR(txtSearchSeminarCitizen.Text, "", "", "", "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    SetViewState(dt);

                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
                else
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                    notification.InnerHtml += "<div> - ไม่พบข้อมูลของรหัสบัตรประชาชนดังกล่าว</div>";
                    return;
                }
            }

        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("SEMINAR-ADMIN.aspx");
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label LabelCitizenID = row.FindControl("lblSECitizenIDEDIT") as Label;
            Label LabelName = row.FindControl("lblSEnameEDIT") as Label;
            Label LabelLastName = row.FindControl("lblSElastnameEDIT") as Label;
            Label LabelNameOfProject = row.FindControl("lblSEnameofprojectEDIT") as Label;
            Label LabelPlace = row.FindControl("lblSEplaceEDIT") as Label;
            Label LabelPosition = row.FindControl("lblSEpositionEDIT") as Label;
            Label LabelDegree = row.FindControl("lblSEdegreeEDIT") as Label;
            Label LabelCampus = row.FindControl("lblSEcampusEDIT") as Label;
            Label LabelDateFrom = row.FindControl("lblSEdatetimefromEDIT") as Label;
            Label LabelDateTo = row.FindControl("lblSEdatetimetoEDIT") as Label;
            Label LabelDay = row.FindControl("lblSEdayEDIT") as Label;
            Label LabelMonth = row.FindControl("lblSEmonthEDIT") as Label;
            Label LabelYear = row.FindControl("lblSEyearEDIT") as Label;
            Label LabelBudget = row.FindControl("lblSEbudgetEDIT") as Label;
            Label LabelSupportBudget = row.FindControl("lblSEsupportbudgetEDIT") as Label;
            Label LabelCertificate = row.FindControl("lblSEcertificateEDIT") as Label;
            Label LabelAbstract = row.FindControl("lblSEabstractEDIT") as Label;
            Label LabelResult = row.FindControl("lblSEresultEDIT") as Label;
            Label LabelShow1 = row.FindControl("lblSEshow1EDIT") as Label;
            Label LabelShow2 = row.FindControl("lblSEshow2EDIT") as Label;
            Label LabelShow3 = row.FindControl("lblSEshow3EDIT") as Label;
            Label LabelShow4 = row.FindControl("lblSEshow4EDIT") as Label;
            Label LabelProblem = row.FindControl("lblSEproblemEDIT") as Label;
            Label LabelComment = row.FindControl("lblSEcommentEDIT") as Label;
            Label LabelSignedDatetime = row.FindControl("lblSEsigneddatetimeEDIT") as Label;
            
            lblName.Text = LabelName.Text;
            lblLastName.Text = LabelLastName.Text;
            lblPosition.Text = LabelPosition.Text;
            lblDegree.Text = LabelDegree.Text;
            lblCampus.Text = LabelCampus.Text;
            txtNameOfProject.Text = LabelNameOfProject.Text;
            txtPlace.Text = LabelPlace.Text;
            txtDateFrom.Text = LabelDateFrom.Text;
            txtDateTO.Text = LabelDateTo.Text;
            lblDay.Text = LabelDay.Text;
            lblMonth.Text = LabelMonth.Text;
            lblYear.Text = LabelYear.Text;
            txtBudget.Text = LabelBudget.Text;
            txtSupportBudget.Text = LabelSupportBudget.Text;
            txtCertificate.Text = LabelCertificate.Text;
            txtAbstract.Text = LabelAbstract.Text;
            txtResult.Text = LabelResult.Text;
            txtShow1.Text = LabelShow1.Text;
            txtShow2.Text = LabelShow2.Text;
            txtShow3.Text = LabelShow3.Text;
            txtShow4.Text = LabelShow4.Text;
            txtProblem.Text = LabelProblem.Text;
            txtComment.Text = LabelComment.Text;
            
        }
    }
}