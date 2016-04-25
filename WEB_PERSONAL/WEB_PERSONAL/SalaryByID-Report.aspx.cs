using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL
{
    public partial class SalaryByID_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = Util.OC();
            using (OracleCommand command = new OracleCommand("Select CITIZEN_ID,STF_NAME || ' ' || STF_LNAME as \"NAME\" From TB_PERSONAL", conn))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        ExcelPackage p = new ExcelPackage();

                        p.Workbook.Properties.Author = "Prakasit Janta";
                        p.Workbook.Properties.Title = "Salary Report";
                        p.Workbook.Properties.Company = "RMUTTO";
                        p.Workbook.Properties.Manager = "Prakasit Janta";
                        p.Workbook.Worksheets.Add("รายละเอียดการขึ้นเงินเดือนข้าราชกาลในมหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออกวิทยาเขตบางพระ");
                        ExcelWorksheet ws = p.Workbook.Worksheets[1]; // 1 is the position of the worksheet
                        ws.Name = "รายละเอียดการขึ้นเงินเดือนข้าราชกาลในมหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออกวิทยาเขตบางพระ";
                        int c = 0;
                        {
                            var cell_head1 = ws.Cells[1, 1];
                            var fill = cell_head1.Style.Fill;
                            var exfont = cell_head1.Style.Font;
                            exfont.SetFromFont(new System.Drawing.Font("TH SarabunPSK", 16));
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            cell_head1.Value = "รหัสประชาชน";
                        }
                        {
                            var cell_head2 = ws.Cells[1, 2];
                            var fill = cell_head2.Style.Fill;
                            var exfont = cell_head2.Style.Font;
                            exfont.SetFromFont(new System.Drawing.Font("TH SarabunPSK", 16));
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            cell_head2.Value = "ชื่อ - นามสกุล";
                        }
                        {
                            var cell_head3 = ws.Cells[1, 3];
                            var fill = cell_head3.Style.Fill;
                            var exfont = cell_head3.Style.Font;
                            exfont.SetFromFont(new System.Drawing.Font("TH SarabunPSK", 16));
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            cell_head3.Value = "รหัสเลขที่ตำแหน่ง";
                        }


                        while (reader.Read())
                        {
                            String b = reader.GetString(0);
                            String c1 = reader.GetString(1);
                            int rowIndex = 2 + c++;
                            int colIndex = 1;
                            do
                            {
                                // Set the background colours

                                    var cell = ws.Cells[rowIndex, colIndex];
                                    var fill1 = cell.Style.Fill;
                                    var exfont = cell.Style.Font;
                                    exfont.SetFromFont(new System.Drawing.Font("TH SarabunPSK", 16));
                                    fill1.PatternType = ExcelFillStyle.Solid;
                                    fill1.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                                    colIndex++;
                                

                            }
                            while (colIndex != 4);
                            // Set the cell values
                            var cell_actionName = ws.Cells[rowIndex, 1];
                            var cell_timeTaken = ws.Cells[rowIndex, 2];
                            cell_actionName.Value = b;
                            cell_timeTaken.Value = c1;
                            ws.Column(1).AutoFit();
                            ws.Column(2).Width = 30;
                            ws.Column(3).Width = 30;
                        }
                        // Save the Excel file
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(@"D:\Report.xlsx", bin);
                        Util.Alert(this, "CREATE EXCEL COMPLETE!");
                    }
                }
            }


        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 7;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "รายละเอียดการขึ้นเงินเดือนร้อยละ 2.9";
                HeaderCell.ColumnSpan = 12;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "อธิการบดีเพิ่มให้";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "รวมได้เลื่อนทั้งสิ้น";
                HeaderCell.ColumnSpan = 7;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }
    }
}