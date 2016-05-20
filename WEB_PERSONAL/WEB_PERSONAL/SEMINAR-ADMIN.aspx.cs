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
           /* SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT SEMINAR_ID รหัส,CITIZEN_ID รหัสบัตรประชาชน,SEMINAR_NAME ชื่อ,SEMINAR_LASTNAME นามสกุล,SEMINAR_NAMEOFPROJECT ชื่อโครงการ, SEMINAR_PLACE สถานที่ FROM TB_SEMINAR WHERE CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "'");
            GridView1.DataSource = sds;
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                TableHeaderCell newHeader = new TableHeaderCell();
                newHeader.Text = "เลือก";
                GridView1.HeaderRow.Cells.Add(newHeader);

                for (int i = 0; i < GridView1.Rows.Count; ++i)
                {
                    string id = GridView1.Rows[i].Cells[0].Text;
                    string SeminarName = "";
                    using (OracleConnection conn = Util.OC())
                    {
                        PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                        Person PP = ps.LoginPerson;
                        using (OracleCommand cmd = new OracleCommand("select SEMINAR_NAME from TB_SEMINAR where SEMINAR_ID = " + id, conn))

                        {
                            using (OracleDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    SeminarName = reader.IsDBNull(0) ? "" : reader.GetString(0);

                                }
                            }
                        }

                    }

                    LinkButton lbu = new LinkButton();
                    lbu.Text = "เลือก";
                    lbu.CssClass = "ps-button";
                    lbu.Click += (e2, e3) =>
                    {
                        txtName.Text = SeminarName;

                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    GridView1.Rows[i].Cells.Add(cell);
                }
            }  */
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
            Seminar s = new Seminar();
            DataTable dt = s.GetSEMINAR("", "", "", "", "");
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

        protected bool NeedData()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก นามสกุล')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ตำแหน่ง')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDegree.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ระดับ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtCampus.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สังกัด')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtNameOfProject.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtPlace.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สถานที่ฝึกอบรม/สัมมนา/ดูงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDateFrom.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่เริ่ม')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtDateTO.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก วันที่สิ้นสุด')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtBudget.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ค่าใช้จ่ายตลอดโครงการ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtSupportBudget.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก แหล่งงบประมาณที่ได้รับการสนับสนุน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtCertificate.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ประกาศนียบัตรที่ได้รับ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtAbstract.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก สรุปผลการฝึกอบรม/สัมมนา/ดูงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtShow1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน : ด้านการเรียนการสอน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtShow2.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน : ด้านการวิจัย')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtShow3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน : ด้านการบริการวิชาการ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtShow4.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน : ด้านอื่นๆ')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtProblem.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน')", true);
                return true;
            }
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก ความคิดเห็น/ข้อเสนอแนะอื่นๆ')", true);
                return true;
            }
            return false;
        }

        protected void btnSubmitSeminar_Click(object sender, EventArgs e)
        {
            // if (NeedData()) { return; };

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
            S.InsertSEMINAR();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            ClearData();
            MultiView1.ActiveViewIndex = 0;
        }


        protected void btnCancelSeminar_Click(object sender, EventArgs e)
        {
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

        protected void lblNextV1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[0].Visible = false;
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบชื่อโครงการ" + DataBinder.Eval(e.Row.DataItem, "SEMINAR_NAMEOFPROJECT") + " ใช่ไหม ?');");
            }
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffb3b3'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffe6e6'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffe6e6");
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffcc80'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffebcc'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffebcc");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void modUpdateCommand(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            txtName.Text = row.Cells[0].Text;
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            Seminar s = new Seminar();
            s.SEMINAR_ID = id;
            s.DeleteSEMINAR();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView2.EditIndex = -1;
        }
        protected void myGridViewSeminar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = GetViewState();
            GridView2.DataBind();
        }
        protected void btnSearchSeminar_Click(object sender, EventArgs e)
        {
            //SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT SEMINAR_ID รหัส,CITIZEN_ID รหัสบัตรประชาชน,SEMINAR_NAME ชื่อ,SEMINAR_LASTNAME นามสกุล,SEMINAR_NAMEOFPROJECT ชื่อโครงการ, SEMINAR_PLACE สถานที่ FROM TB_SEMINAR WHERE CITIZEN_ID = '" + txtSearchSeminarCitizen.Text + "'");
            //GridView1.DataSource = sds;
            //GridView1.DataBind();
            if (string.IsNullOrEmpty(txtSearchSeminarCitizen.Text) || string.IsNullOrEmpty(txtSearchSeminarName.Text) || string.IsNullOrEmpty(txtSearchSeminarLastName.Text) || string.IsNullOrEmpty(txtSearchSeminarNameOfProject.Text) || string.IsNullOrEmpty(txtSearchSeminarCitizen.Text) || string.IsNullOrEmpty(txtSearchSeminarPlace.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                Seminar s = new Seminar();
                DataTable dt = s.GetSEMINAR(txtSearchSeminarCitizen.Text, txtSearchSeminarName.Text, txtSearchSeminarLastName.Text, txtSearchSeminarNameOfProject.Text, txtSearchSeminarPlace.Text);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                SetViewState(dt);
            }
        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            Seminar s = new Seminar();
            DataTable dt = s.GetSEMINAR("","","","","");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        
    }
}