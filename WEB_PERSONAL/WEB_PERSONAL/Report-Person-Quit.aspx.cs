using Rmutto.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using WEB_PERSONAL.Class;
using System.Text;
using System.IO;
using System.Data;

namespace WEB_PERSONAL
{
    public partial class Report_Person_Quit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DatabaseManager.BindDropDown(ddlMonth, "SELECT * FROM TB_MONTH", "MONTH_SHORT", "MONTH_ID", "--เดือน--");
                DatabaseManager.BindDropDown(ddlYear, "SELECT * FROM TB_DATE_YEAR", "YEAR_ID", "YEAR_ID", "--ปี--");
            }
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if(ddlMonth.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> กรุณาเลือกข้อมูลให้ถูกต้อง</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกเดือน</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (ddlYear.SelectedIndex == 0)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> กรุณาเลือกข้อมูลให้ถูกต้อง</strong></div>";
                notification.InnerHtml += "<div>กรุณาเลือกปี</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            {
                tb.Rows.Clear();
                TableRow row = new TableRow();

                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - สกุล";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ตำแหน่ง";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "สถานะบุคลากร";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่บรรจุ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่ลาออก";
                    row.Cells.Add(cell);
                }

                tb.Rows.Add(row);
            }

            OracleConnection con1 = ConnectionDB.GetOracleConnection();
            OracleCommand com0 = new OracleCommand("SELECT COUNT(*) FROM PS_PERSON WHERE EXTRACT(MONTH FROM PS_DATE_QUIT) = " + ddlMonth.SelectedValue + " AND EXTRACT(YEAR FROM PS_DATE_QUIT) = " + ddlYear.SelectedValue + "-543 AND PS_SW_ID = 19", con1);
            OracleCommand com1 = new OracleCommand("SELECT PS_CITIZEN_ID,PS_FN_TH || ' ' || PS_LN_TH,(SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE POSITION_WORK_ID = PS_WORK_POS_ID),(SELECT SW_NAME FROM TB_STATUS_WORK WHERE SW_ID = PS_SW_ID),PS_INWORK_DATE,PS_DATE_QUIT FROM PS_PERSON WHERE EXTRACT(MONTH FROM PS_DATE_QUIT) = " + ddlMonth.SelectedValue + " AND EXTRACT(YEAR FROM PS_DATE_QUIT) = " + ddlYear.SelectedValue + "-543 AND PS_SW_ID = 19", con1);
            if (con1.State != ConnectionState.Open)
            {
                con1.Open();
            }
            OracleDataReader reader0 = com0.ExecuteReader();
            OracleDataReader reader1 = com1.ExecuteReader();
            int j = 1;
            while (reader0.Read())
            {
                if (reader0.GetInt32(0) == 0)
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                    notification.InnerHtml += "<div>ไม่พบข้อมูลดังกล่าว</div>";
                    return;
                }
                else
                {
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }

            while (reader1.Read())
            {
                TableRow row = new TableRow();

                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + j;
                    row.Cells.Add(cell);
                }
                {
                    Label lblCitizenID = new Label();
                    lblCitizenID.Text = reader1.GetString(0);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblCitizenID);
                    row.Cells.Add(cell);
                }

                {
                    Label lblName = new Label();
                    lblName.Text = reader1.GetString(1);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblName);
                    row.Cells.Add(cell);
                }

                {
                    Label lblPosition = new Label();
                    lblPosition.Text = reader1.GetString(2);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblPosition);
                    row.Cells.Add(cell);
                }

                {
                    Label lblStatusWork = new Label();
                    lblStatusWork.Text = reader1.GetString(3);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblStatusWork);
                    row.Cells.Add(cell);
                }

                {
                    Label lblDateInwork = new Label();
                    lblDateInwork.Text = reader1.GetDateTime(4).ToString("dd MMM yyyy");
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblDateInwork);
                    row.Cells.Add(cell);
                }

                {
                    Label lblDateQuit = new Label();
                    lblDateQuit.Text = reader1.GetDateTime(5).ToString("dd MMM yyyy");
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblDateQuit);
                    row.Cells.Add(cell);
                }
                tb.Rows.Add(row);
                ++j;
            }
            Session["PersonReportTable"] = tb;
            com1.Dispose();
            con1.Close();
        }

        protected void lbuExport_Click(object sender, EventArgs e)
        {
            Table tb = ((Table)Session["PersonReportTable"]);
            int cols = tb.Rows[0].Cells.Count;
            for (int i = 0; i < cols; i++)
            {
                tb.Rows[0].Cells[i].Style.Add("border", "thin solid black");
            }
            for (int i = 1; i < tb.Rows.Count; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tb.Rows[i].Cells[j].Style.Add("border", "thin solid black");
                }
            }
            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename=PersonReportQuit.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            string style = @"<style> TD { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Write(tw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lbuSearchAll_Click(object sender, EventArgs e)
        {
            {
                tb.Rows.Clear();
                TableRow row = new TableRow();

                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - สกุล";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ตำแหน่ง";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "สถานะบุคลากร";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่บรรจุ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่ลาออก";
                    row.Cells.Add(cell);
                }

                tb.Rows.Add(row);
            }

            OracleConnection con1 = ConnectionDB.GetOracleConnection();
            OracleCommand com1 = new OracleCommand("SELECT PS_CITIZEN_ID,PS_FN_TH || ' ' || PS_LN_TH,(SELECT POSITION_WORK_NAME FROM TB_POSITION_WORK WHERE POSITION_WORK_ID = PS_WORK_POS_ID),(SELECT SW_NAME FROM TB_STATUS_WORK WHERE SW_ID = PS_SW_ID),PS_INWORK_DATE,PS_DATE_QUIT FROM PS_PERSON WHERE PS_DATE_QUIT IS NOT NULL", con1);
            if (con1.State != ConnectionState.Open)
            {
                con1.Open();
            }
            OracleDataReader reader1 = com1.ExecuteReader();
            int j = 1;

            while (reader1.Read())
            {
                TableRow row = new TableRow();

                {
                    TableCell cell = new TableCell();
                    cell.Text = "" + j;
                    row.Cells.Add(cell);
                }
                {
                    Label lblCitizenID = new Label();
                    lblCitizenID.Text = reader1.GetString(0);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblCitizenID);
                    row.Cells.Add(cell);
                }

                {
                    Label lblName = new Label();
                    lblName.Text = reader1.GetString(1);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblName);
                    row.Cells.Add(cell);
                }

                {
                    Label lblPosition = new Label();
                    lblPosition.Text = reader1.GetString(2);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblPosition);
                    row.Cells.Add(cell);
                }

                {
                    Label lblStatusWork = new Label();
                    lblStatusWork.Text = reader1.GetString(3);
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblStatusWork);
                    row.Cells.Add(cell);
                }

                {
                    Label lblDateInwork = new Label();
                    lblDateInwork.Text = reader1.GetDateTime(4).ToString("dd MMM yyyy");
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblDateInwork);
                    row.Cells.Add(cell);
                }

                {
                    Label lblDateQuit = new Label();
                    lblDateQuit.Text = reader1.GetDateTime(5).ToString("dd MMM yyyy");
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lblDateQuit);
                    row.Cells.Add(cell);
                }
                tb.Rows.Add(row);
                ++j;
            }
            Session["PersonReportTable"] = tb;
            com1.Dispose();
            con1.Close();
        }
    }
}