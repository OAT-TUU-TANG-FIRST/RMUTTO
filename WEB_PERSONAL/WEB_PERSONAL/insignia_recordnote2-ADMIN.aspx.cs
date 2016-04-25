using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;

namespace WEB_PERSONAL
{
    public partial class insignia_recordnote2_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["Z11"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["Z11"] = data;
        }

        #endregion

        void BindData()
        {
            ClassInsigRecord2 n = new ClassInsigRecord2();
            DataTable dt = n.GetInsigRecord2("", "", "", "", "", "", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
        void BindData1()
        {
            ClassInsigRecord2 n = new ClassInsigRecord2();
            DataTable dt = n.GetInsigRecord2(txtSearchInsig2CITIZENID.Text, "", "", "", "", "", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }


        private void ClearData()
        {
            txtt0.Text = "";
            txtt1.Text = "";
            txtt2.Text = "";
            txtt3.Text = "";
            txtt4.Text = "";
            txtt5.Text = "";
            txtt6.Text = "";
            txtt7.Text = "";
            txtt8.Text = "";
            txtt9.Text = "";
            txtt10.Text = "";
            txtSearchInsig2CITIZENID.Text = "";
            txtSearchNAME.Text = "";
            txtSearchLASTNAME.Text = "";
            txtSearchDATE_INWORK.Text = "";

        }

        protected void btnSubmitInsig2_Click(object sender, EventArgs e)
        {
           
           if (string.IsNullOrEmpty(txtt0.Text))
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ วัน/เดือน/ปี')", true);
               return;
           }

           if (string.IsNullOrEmpty(txtt1.Text))
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ตำแหน่ง')", true);
               return;
           }

           if (string.IsNullOrEmpty(txtt2.Text))
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ระดับ')", true);
               return;
           }
            if (string.IsNullOrEmpty(txtt3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ได้รับ ชั้น/รายการ')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtt4.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ เล่ม')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtt5.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ตอน')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtt6.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ หน้า')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtt7.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ วัน/เดือน/ปี')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtt8.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ใบกำกับ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtt9.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ เหรียญตรา')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtt10.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ หมายเหตุ')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtSearchInsig2CITIZENID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนในการเพิ่มข้อมูล')", true);
                return;
            }
            if (txtSearchInsig2CITIZENID.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนให้ครบ 13 หลัก')", true);
                return;
            }

            ClassInsigRecord2 n = new ClassInsigRecord2();
            n.CITIZEN_ID = txtSearchInsig2CITIZENID.Text;
            n.DDATE = DateTime.Parse(txtt0.Text);
            n.POSITION_WORK_NAME = txtt1.Text;
            n.POSITION_NAME = txtt2.Text;
            n.GRADEINSIGNIA_NAME = txtt3.Text;
            n.GAZETTE_LAM = txtt4.Text;
            n.GAZETTE_TON = txtt5.Text;
            n.GAZETTE_NA = txtt6.Text;
            n.GAZETTE_DATE = DateTime.Parse(txtt7.Text);
            n.INVOICE = txtt8.Text;
            n.DECORATION = txtt9.Text;
            n.NOTES = txtt10.Text;

            string[] splitDate1 = txtt0.Text.Split(' ');
            string[] splitDate2 = txtt7.Text.Split(' ');
            n.DDATE = new DateTime(Convert.ToInt32(splitDate1[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate1[0]));
            n.GAZETTE_DATE = new DateTime(Convert.ToInt32(splitDate2[2]), Util.MonthToNumber(splitDate1[1]), Convert.ToInt32(splitDate2[0]));

            if (n.CheckHaveCitizenID())
            {
                n.InserInsigRecord2();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่มีรหัสประจำตัวประชาชนดังกล่าวที่จะเพิ่มข้อมูล !')", true);
            }

        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            BindData1();

        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            ClassInsigRecord2 n = new ClassInsigRecord2();
            n.ID = id;
            n.DeleteInsigRecord2();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();

        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtSearchInsig2CITIZENID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนในการ Update')", true);
                return;
            }
            if (txtSearchInsig2CITIZENID.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนให้ครบ 13 หลัก')", true);
                return;
            }

            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            Label lblCITIZEN_ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCITIZEN_ID");
            TextBox lbl0 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt0");
            TextBox txt1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt1");
            TextBox txt2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt2");
            TextBox txt3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt3");
            TextBox txt4 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt4");
            TextBox txt5 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt5");
            TextBox txt6 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt6");
            TextBox lbl7 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt7");
            TextBox txt8 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt8");
            TextBox txt9 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt9");
            TextBox txt10 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt10");
            DateTime DDATE = DateTime.Parse(lbl0.Text);
            DateTime GAZETTE_DATE = DateTime.Parse(lbl7.Text);

            ClassInsigRecord2 n = new ClassInsigRecord2(Convert.ToInt32(lblID.Text)
                , lblCITIZEN_ID.Text
                , DDATE
                , txt1.Text
                , txt2.Text
                , txt3.Text
                , txt4.Text
                , txt5.Text
                , txt6.Text
                , GAZETTE_DATE
                , txt8.Text
                , txt9.Text
                , txt10.Text);

            if (n.CheckHaveCitizenID())
            {
                n.UpdateInsigRecord2();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                GridView1.EditIndex = -1;

                DataTable dt = n.GetInsigRecord2(txtSearchInsig2CITIZENID.Text, "", "", "", "", "", "", "", "", "", "", "");
                GridView1.DataSource = dt;
                //GridView1.DataBind();

                SetViewState(dt);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่มีรหัสประจำตัวประชาชนดังกล่าวที่จะอัพเดทข้อมูล !')", true);
            }
            
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบ จริงๆใช่ไหม ?');");
            }
        }
        protected void myGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void btnCancelInsig2_Click(object sender, EventArgs e)
        {
            
            ClearData();
            ClassInsigRecord2 n = new ClassInsigRecord2();
            DataTable dt = n.GetInsigRecord2("", "", "", "", "", "", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
            
        }

        protected void btnSearchInsig2_Click(object sender, EventArgs e)
        {
           

            ClassInsigRecord2 n = new ClassInsigRecord2();
            DataTable dt = n.GetInsigRecord2(txtSearchInsig2CITIZENID.Text, "", "", "", "", "", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);

            ClassInsigRecord2 P = new ClassInsigRecord2();
            if (string.IsNullOrEmpty(txtSearchInsig2CITIZENID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนในการค้นหา')", true);
                return;
            }
            if (txtSearchInsig2CITIZENID.Text.Length <= 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ บัตรประชาชนให้ครบ 13 หลัก')", true);
                return;
            }
            else
            {
                using (OracleConnection conn = Util.OC())
                {
                    using (OracleCommand cmd = new OracleCommand("select PERSON_NAME,PERSON_LASTNAME,TO_CHAR(INWORK_DATE,'dd MON yyyy','NLS_DATE_LANGUAGE = THAI') from tb_person where citizen_id = '" + txtSearchInsig2CITIZENID.Text + "'", conn))

                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) { 
                            while (reader.Read())
                            {
                                txtSearchNAME.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                txtSearchLASTNAME.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                txtSearchDATE_INWORK.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่พบรหัสบัตรประชาชนดังกล่าว')", true);
                                return;
                            }
                        }
                    }
                }
            }

        }

        protected void btnSearchRefresh_Click(object sender, EventArgs e)
        {
            
            ClearData();
            ClassInsigRecord2 n = new ClassInsigRecord2();
            DataTable dt = n.GetInsigRecord2("", "", "", "", "", "", "", "", "", "", "", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
            
        }
    }
}