using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Data.OracleClient;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Security.Cryptography;

namespace WEB_PERSONAL
{
    public partial class INSG_RequestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();
                
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เครื่องราชที่ขอ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "รหัสบัตรประชาชน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่ทำเรื่องการขอ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ยศ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "คำนำหน้า";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - สกุล";
                    row.Cells.Add(cell);
                } 
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "เพศ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันเกิด";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "วันที่เข้าทำงาน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ปริ้น";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "แจ้งผล";
                    row.Cells.Add(cell);
                }

                Table1.Rows.Add(row);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT NAME_GRADEINSIGNIA_THA FROM INS_GRADEINSIGNIA WHERE INS_GRADEINSIGNIA.ID_GRADEINSIGNIA = TB_INSIG_REQUEST.IR_INSIG_ID) ชั้นที่ขอ, IR_CITIZEN_ID รหัสประชาชน, IR_DATE_START วันที่ทำเรื่องขอ, IR_RANK ยศ, IR_TITLE คำนำหน้า, IR_NAME || ' ' || IR_LASTNAME ชื่อ, IR_GENDER เพศ, IR_BIRTHDATE วันเกิด, IR_DATE_INWORK วันที่เข้าทำงาน, IR_ID FROM TB_INSIG_REQUEST WHERE TB_INSIG_REQUEST.IR_STATUS = 2", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            string psID = reader.GetString(1);
                            int IRID = reader.GetInt32(9);

                            {
                                Label lblInsigName = new Label();
                                lblInsigName.Text = reader.GetString(0);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblInsigName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblCitizenID = new Label();
                                lblCitizenID.Text = psID;
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblCitizenID);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblDateStartRequest = new Label();
                                lblDateStartRequest.Text = reader.GetDateTime(2).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblDateStartRequest);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblRank = new Label();
                                lblRank.Text = reader.GetString(3);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblRank);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblTitleName = new Label();
                                lblTitleName.Text = reader.GetString(4);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblTitleName);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbName = new LinkButton();
                                lbName.Text = reader.GetString(5);
                                lbName.Click += (e2, e3) =>
                                {
                                    Response.Redirect("INSG_Qualified_Detail.aspx?psID=" + psID);
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblGender = new Label();
                                lblGender.Text = reader.GetString(6);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblGender);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblBirthDate = new Label();
                                lblBirthDate.Text = reader.GetDateTime(7).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblBirthDate);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblDateInwork = new Label();
                                lblDateInwork.Text = reader.GetDateTime(8).ToString("dd MMM yyyy");
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblDateInwork);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbuPrint = new LinkButton();
                                lbuPrint.Text = "ปริ้น";
                                lbuPrint.CssClass = "ps-button";
                                lbuPrint.Click += (e2, e3) =>
                                {             
                                    hfIRID.Value = "" + IRID;
                                    //
                                    string result = "";
                                    using (MD5 md5Hash = MD5.Create())
                                    {
                                        result = GetMd5Hash(md5Hash, hfIRID.Value);
                                        //Bind Number แล้ว
                                    }

                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('Report-Insignia.aspx?irID=" + result + "', null, 'height=780,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('Report-Insignia.aspx?irID=" + IRID + "', null, 'height=780,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbuPrint);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbuResult = new LinkButton();
                                lbuResult.Text = "แจ้งผล";
                                lbuResult.CssClass = "ps-button";
                                lbuResult.Click += (e2,e3) => 
                                {
                                    hfIRID.Value = "" + IRID;
                                    MultiView1.ActiveViewIndex = 1;
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbuResult);
                                row.Cells.Add(cell);
                            }

                            Table1.Rows.Add(row);
                        }
                    }
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        protected void lbBack_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuSave_Click(object sender, EventArgs e) {
            int IRID = int.Parse(hfIRID.Value);
            int res = 1;
            if (rbNotGet.Checked) {
                res = 2;
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                if (res == 1) {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_DATE_GET_INSIG = :IR_DATE_GET_INSIG, IR_GET_STATUS = :IR_GET_STATUS, IR_REFERENCE = :IR_REFERENCE WHERE IR_ID = :IR_ID", con)) {
                        com.Parameters.AddWithValue("IR_STATUS", 3);
                        com.Parameters.AddWithValue("IR_DATE_GET_INSIG", Util.ToDateTimeOracle(tbDateGet.Text));
                        com.Parameters.AddWithValue("IR_GET_STATUS", res);
                        com.Parameters.AddWithValue("IR_REFERENCE", tbRef.Text);
                        com.Parameters.AddWithValue("IR_ID", IRID);
                        com.ExecuteNonQuery();
                    }
                } else {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_INSIG_REQUEST SET IR_STATUS = :IR_STATUS, IR_GET_STATUS = :IR_GET_STATUS WHERE IR_ID = :IR_ID", con)) {
                        com.Parameters.AddWithValue("IR_STATUS", 3);
                        com.Parameters.AddWithValue("IR_GET_STATUS", res);
                        com.Parameters.AddWithValue("IR_ID", IRID);
                        com.ExecuteNonQuery();
                    }
                }
                
            }
            MultiView1.ActiveViewIndex = 2;
        }
    }
    
}