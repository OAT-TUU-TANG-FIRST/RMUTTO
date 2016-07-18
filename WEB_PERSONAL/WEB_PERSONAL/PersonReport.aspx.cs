using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using WEB_PERSONAL.Class;
using System.Text;
using System.IO;

namespace WEB_PERSONAL {
    public partial class PersonReport : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM TB_CAMPUS", "CAMPUS_NAME", "CAMPUS_ID", "-กรุณาเลือกวิทยาเขต-");
            }
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {

            //--

            if(!cbPsID.Checked && !cbCitizenID.Checked && !cbPsName.Checked && !cbGender.Checked && !cbAge.Checked && !cbCampus.Checked && !cbBirthdayDate.Checked) {
                Util.Alert(this, "กรุณาเลือกข้อมูลที่ต้องการออกรายงานอย่างน้อย 1 ช่อง");
                return;
            }

            //--


            List<string> headList = new List<string>();
            List<int> typeList = new List<int>();
            
            // 1 = int
            // 2 = string
            // 3 = date

            bool seq = false;
            string select = "SELECT";
            if (cbPsID.Checked) {
                seq = true;
                /*select += ", PS_ID";
                headList.Add("ลำดับ");
                typeList.Add(1);*/
            }
            if (cbCitizenID.Checked) {
                select += ", PS_CITIZEN_ID";
                headList.Add("บัตรประชาชน");
                typeList.Add(2);
            }
            if (cbPsName.Checked) {
                select += ", PS_FN_TH || ' ' || PS_LN_TH";
                headList.Add("ชื่อ");
                typeList.Add(2);
            }
            if (cbGender.Checked) {
                select += ", (SELECT GENDER_NAME FROM TB_GENDER WHERE GENDER_ID = PS_GENDER_ID)";
                headList.Add("เพศ");
                typeList.Add(2);
            }
            if (cbAge.Checked) {
                select += ", FUNC_AGE(PS_BIRTHDAY_DATE)";
                headList.Add("อายุ");
                typeList.Add(2);
            }
            if (cbCampus.Checked) {
                select += ", (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE CAMPUS_ID = PS_CAMPUS_ID)";
                headList.Add("วิทยาเขต");
                typeList.Add(2);
            }
            if (cbBirthdayDate.Checked) {
                select += ", PS_BIRTHDAY_DATE";
                headList.Add("วันเกิด");
                typeList.Add(3);
            }
            select = select.Replace("SELECT,", "SELECT ");

            ///---------
            string where = "";
            if(cbGenderCondition.Checked) {
                where += " AND PS_GENDER_ID = " + (rbMale.Checked ? "1" : "2");
            }
            if (cbAgeCondition.Checked) {
                where += " AND FUNC_AGE(PS_BIRTHDAY_DATE) >= " + tbAgeConditionFrom.Text + " AND FUNC_AGE(PS_BIRTHDAY_DATE) <= " + tbAgeConditionTo.Text;
            }
            if (cbCampusCondition.Checked) {
                where += " AND PS_CAMPUS_ID = " + ddlCampus.SelectedValue;
            }
            if (cbBirthdayDateCondition.Checked) {
                where += " AND PS_BIRTHDAY_DATE >= " + Util.DatabaseToDateSearch(tbBirthdayDateFrom.Text) + " AND PS_BIRTHDAY_DATE <= " + Util.DatabaseToDateSearch(tbBirthdayDateTo.Text);
            }
            tb.Rows.Clear();

            
            {
                TableHeaderRow row = new TableHeaderRow();
                if (seq) {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                for (int i = 0; i < headList.Count; i++) {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = headList[i];
                    row.Cells.Add(cell);
                }
                tb.Rows.Add(row);
            }
            

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand(select + " FROM PS_PERSON WHERE 1=1" + where, con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        int j = 1;
                        while (reader.Read()) {
                            TableRow row = new TableRow();
                            if (seq) {
                                TableCell cell = new TableCell();
                                cell.Text = "" + j;
                                row.Cells.Add(cell);
                            }
                            for (int i = 0; i < typeList.Count; i++) {
                                TableCell cell = new TableCell();
                                if (typeList[i] == 1) {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetInt32(i).ToString();
                                } else if (typeList[i] == 2) {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetString(i);
                                } else {
                                    cell.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToLongDateString();
                                }
                                row.Cells.Add(cell);
                            }
                            tb.Rows.Add(row);
                            ++j;
                        }
                    }
                }
            }

            Session["PersonReportTable"] = tb;
        }

        protected void lbuExport_Click(object sender, EventArgs e) {
            /*for (int i = 0; i < 5; i++) {
                tb.Rows[0].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 0; i < 15; i++) {
                tb.Rows[1].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 2; i < tb.Rows.Count; i++) {
                for (int j = 0; j < 15; j++) {
                    tb.Rows[i].Cells[j].Style.Add("border", "1px solid #000000");
                }
            }*/

             Response.ContentType = "application/x-msexcel";
             Response.AddHeader("Content-Disposition", "attachment;filename=PersonReport.xls");
             Response.ContentEncoding = Encoding.UTF8;
             StringWriter tw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(tw);
             ((Table)Session["PersonReportTable"]).RenderControl(hw);
             Response.Write(tw.ToString());
             Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control) {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lbuExport2_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < 5; i++)
            {
                tb.Rows[0].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 0; i < 15; i++)
            {
                tb.Rows[1].Cells[i].Style.Add("border", "1px solid #000000");
            }
            for (int i = 2; i < tb.Rows.Count; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tb.Rows[i].Cells[j].Style.Add("border", "1px solid #000000");
                }
            }*/

            Response.ContentType = "application/x-msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=PersonReport.doc");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ((Table)Session["PersonReportTable"]).RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}