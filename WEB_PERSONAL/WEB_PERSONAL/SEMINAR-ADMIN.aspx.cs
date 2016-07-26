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
            BindData();

            if (!IsPostBack)
            {
                txtBudget.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
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
        void BindData()
        {
            if (Session["PersonnelSystem"] == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }
        }

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
            txtName.Text = "";
            txtLastName.Text = "";
            txtPosition.Text = "";
            txtDegree.Text = "";
            txtCampus.Text = "";
            txtNameOfProject.Text = "";
            txtPlace.Text = "";
            txtDateFrom.Text = "";
            txtDateTO.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
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
            if (txtName.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกชื่อ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtLastName.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกนามสกุล</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtPosition.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกตำแหน่ง</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtDegree.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกระดับ</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtCampus.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>กรุณากรอกข้อมูลให้ครบถ้วน</strong></div>";
                notification.InnerHtml += "<div>กรุณากรอกสังกัด</div>";
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

            Seminar S = new Seminar();
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person PP = ps.LoginPerson;
            S.SEMINAR_NAME = txtName.Text;
            S.SEMINAR_LASTNAME = txtLastName.Text;
            S.SEMINAR_POSITION = txtPosition.Text;
            S.SEMINAR_DEGREE = txtDegree.Text;
            S.SEMINAR_CAMPUS = txtCampus.Text;
            S.SEMINAR_NAMEOFPROJECT = txtNameOfProject.Text;
            S.SEMINAR_PLACE = txtPlace.Text;
            S.SEMINAR_DATETIME_FROM = DateTime.Parse(txtDateFrom.Text);
            S.SEMINAR_DATETIME_TO = DateTime.Parse(txtDateTO.Text);
            S.SEMINAR_YEAR = Convert.ToInt32(txtYear.Text);
            S.SEMINAR_MONTH = Convert.ToInt32(txtMonth.Text);
            S.SEMINAR_DAY = Convert.ToInt32(txtDay.Text);
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

            string[] splitDate1 = txtDateFrom.Text.Split(' ');
            string[] splitDate2 = txtDateTO.Text.Split(' ');
            S.SEMINAR_DATETIME_FROM = new DateTime(Convert.ToInt32(splitDate1[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            S.SEMINAR_DATETIME_TO = new DateTime(Convert.ToInt32(splitDate2[2]), Util.MonthToNumber(splitDate2[1]), Convert.ToInt32(splitDate2[0]));

            DateTime SEMINAR_SIGNED_DATETIME = DateTime.Now;
            S.UpdateSEMINAR();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            ClearData();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void txtDateTO_TextChanged(object sender, EventArgs e)
        {
            DateTime df = DateTime.Parse(txtDateFrom.Text);
            DateTime dt = DateTime.Parse(txtDateTO.Text);
            int day = (int)(dt - df).TotalDays + 1;

            int year = (day / 365);
            int month = (day % 365) / 30;
            day = (day % 365) % 30;

            txtYear.Text = "" + year;
            txtMonth.Text = "" + month;
            txtDay.Text = "" + day;
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            DateTime df = DateTime.Parse(txtDateFrom.Text);
            DateTime dt = DateTime.Parse(txtDateTO.Text);
            int day = (int)(dt - df).TotalDays + 1;

            int year = (day / 365);
            int month = (day % 365) / 30;
            day = (day % 365) % 30;

            txtYear.Text = "" + year;
            txtMonth.Text = "" + month;
            txtDay.Text = "" + day;
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            txtSupportBudget.Text = chkBox.Checked.ToString();
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก รหัสบัตรประชาชน')", true);
                return;
            }
            else
            {
                Seminar s = new Seminar();
                DataTable dt = s.GetSEMINAR(txtSearchSeminarCitizen.Text,"", "","","");
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        } 

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            Seminar s = new Seminar();
            DataTable dt = s.GetSEMINAR("","","","","");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;
            //txtName.Text = row.Cells[0].Text;
            //txtLastName.Text = row.Cells[1].Text;

            //txtName.Text = GridView1.SelectedRow.Cells[1].Text;

            txtName.Text = GridView1.SelectedRow.Cells[0].Text;
            txtLastName.Text = GridView1.SelectedRow.Cells[1].Text;
            txtPosition.Text = GridView1.SelectedRow.Cells[2].Text;
            txtDegree.Text = GridView1.SelectedRow.Cells[3].Text;
            txtCampus.Text = GridView1.SelectedRow.Cells[4].Text;
            txtNameOfProject.Text = GridView1.SelectedRow.Cells[5].Text;
            txtPlace.Text = GridView1.SelectedRow.Cells[6].Text;
            txtDateFrom.Text = GridView1.SelectedRow.Cells[7].Text;
            /*txtDateTO.Text = GridView1.SelectedRow.Cells[8].Text;
            txtDay.Text = GridView1.SelectedRow.Cells[9].Text;
            txtMonth.Text = GridView1.SelectedRow.Cells[10].Text;
            txtYear.Text = GridView1.SelectedRow.Cells[11].Text;
            txtBudget.Text = GridView1.SelectedRow.Cells[12].Text;
            txtSupportBudget.Text = GridView1.SelectedRow.Cells[13].Text;
            txtCertificate.Text = GridView1.SelectedRow.Cells[14].Text;
            txtAbstract.Text = GridView1.SelectedRow.Cells[15].Text;
            txtResult.Text = GridView1.SelectedRow.Cells[16].Text;
            txtShow1.Text = GridView1.SelectedRow.Cells[17].Text;
            txtShow2.Text = GridView1.SelectedRow.Cells[18].Text;
            txtShow3.Text = GridView1.SelectedRow.Cells[19].Text;
            txtShow4.Text = GridView1.SelectedRow.Cells[20].Text;
            txtProblem.Text = GridView1.SelectedRow.Cells[21].Text;
            txtComment.Text = GridView1.SelectedRow.Cells[22].Text;*/
        }
    }
}