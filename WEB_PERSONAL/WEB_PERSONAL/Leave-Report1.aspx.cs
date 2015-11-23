﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace WEB_PERSONAL {
    public partial class Leave_Report1 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            BindGridView1();
        }
        private void BindGridView1() {

            

            DataTable dt = new DataTable();

                
                dt.Columns.Add("ลำดับที่");
                dt.Columns.Add("ชื่อ - นามสกุล");
                dt.Columns.Add("ตำแหน่ง");
                dt.Columns.Add("ครั้ง");
                dt.Columns.Add("วัน");
                {
                    DataColumn dc = new DataColumn("ครั้ง ");
                    dc.Caption = "ครั้ง";
                    dt.Columns.Add(dc);
                }
                {
                    DataColumn dc = new DataColumn("วัน ");
                    dc.Caption = "วัน";
                    dt.Columns.Add(dc);
                }
                {
                    DataColumn dc = new DataColumn("ครั้ง  ");
                    dc.Caption = "ครั้ง";
                    dt.Columns.Add(dc);
                }
                {
                    DataColumn dc = new DataColumn("วัน  ");
                    dc.Caption = "วัน";
                    dt.Columns.Add(dc);
                }
                dt.Columns.Add("มาสาย(ครั้ง)");
                dt.Columns.Add("ขาดราชการ(วัน)");
                dt.Columns.Add("ลาศึกษาต่อ(ระบุวันที่ลา)");
                dt.Columns.Add("ลาคลอดบุตร(ระบุวันที่ลา)");
                dt.Columns.Add("ลาอุปสมบทฯ(ระบุวันที่ลา)");
                dt.Columns.Add("หมายเหตุ");

                



            int i = 1;
            using (OracleConnection con = Util.OC()) {
                using (OracleCommand command = new OracleCommand("SELECT CITIZEN_ID, PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON", con)) {
                    using (OracleDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                DataRow dr = dt.NewRow();
                                dr[0] = i++;
                                dr[1] = reader.GetString(1);


                                if (!reader.IsDBNull(0)) {
                                    using (OracleCommand command2 = new OracleCommand("SELECT POSITION_NAME FROM TB_POSITION_AND_SALARY WHERE CITIZEN_ID = :1 ORDER BY ID DESC", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[2] = reader2.GetString(0);
                                            } else {
                                                dr[2] = "-";
                                            }
                                        }
                                    }
                                    //puy time
                                    using (OracleCommand command2 = new OracleCommand("SELECT COUNT(CITIZEN_ID) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 1", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[3] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[3] = "-";
                                            }
                                        }
                                    }
                                    //puy day
                                    using (OracleCommand command2 = new OracleCommand("SELECT NVL(SUM(LEAVE_TO_DATE-LEAVE_FROM_DATE+1),0) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 1", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[4] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[4] = "-";
                                            }
                                        }
                                    }
                                    //kid time
                                    using (OracleCommand command2 = new OracleCommand("SELECT COUNT(CITIZEN_ID) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 2", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[5] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[5] = "-";
                                            }
                                        }
                                    }
                                    //kid day
                                    using (OracleCommand command2 = new OracleCommand("SELECT NVL(SUM(LEAVE_TO_DATE-LEAVE_FROM_DATE+1),0) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 2", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[6] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[6] = "-";
                                            }
                                        }
                                    }
                                    //pakpon time
                                    using (OracleCommand command2 = new OracleCommand("SELECT COUNT(CITIZEN_ID) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 3", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[7] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[7] = "-";
                                            }
                                        }
                                    }
                                    //pakpon day
                                    using (OracleCommand command2 = new OracleCommand("SELECT NVL(SUM(LEAVE_TO_DATE-LEAVE_FROM_DATE+1),0) FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 3", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[8] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[8] = "-";
                                            }
                                        }
                                    }
                                    //late time
                                    using (OracleCommand command2 = new OracleCommand("SELECT COUNT(*) FROM TB_WORK_CHECK_IN WHERE CITIZEN_ID = :1 AND HOUR_IN * 60 + MINUTE_IN > 510", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[9] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[9] = "-";
                                            }
                                        }
                                    }
                                    //kad-rasha-kan day
                                    using (OracleCommand command2 = new OracleCommand("SELECT NVL(SUM(LEAVE_TO_DATE - LEAVE_FROM_DATE + 1), 0) FROM TB_LEAVE WHERE CITIZEN_ID = :1", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[10] = reader2.GetInt32(0).ToString();
                                            } else {
                                                dr[10] = "-";
                                            }
                                        }
                                    }
                                    //la-suk-sa-tor
                                    using (OracleCommand command2 = new OracleCommand("SELECT TO_CHAR(STUDY_FROM_DATE, 'DD MON RRRR', 'NLS_DATE_LANGUAGE = THAI') FROM TB_STUDY WHERE CITIZEN_ID = :1 AND ROWNUM = 1 ORDER BY STUDY_FROM_DATE DESC", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[11] = reader2.GetString(0);
                                            } else {
                                                dr[11] = "-";
                                            }
                                        }
                                    }
                                    //la-klod-bud
                                    using (OracleCommand command2 = new OracleCommand("SELECT TO_CHAR(LEAVE_FROM_DATE, 'DD MON RRRR', 'NLS_DATE_LANGUAGE = THAI') FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 4 AND ROWNUM = 1 ORDER BY LEAVE_FROM_DATE DESC", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[12] = reader2.GetString(0);
                                            } else {
                                                dr[12] = "-";
                                            }
                                        }
                                    }
                                    //la-uppa-som-bod
                                    using (OracleCommand command2 = new OracleCommand("SELECT TO_CHAR(LEAVE_FROM_DATE, 'DD MON RRRR', 'NLS_DATE_LANGUAGE = THAI') FROM TB_LEAVE WHERE CITIZEN_ID = :1 AND LEAVE_TYPE_ID = 5 AND ROWNUM = 1 ORDER BY LEAVE_FROM_DATE DESC", con)) {
                                        command2.Parameters.AddWithValue("1", reader.GetString(0));
                                        using (OracleDataReader reader2 = command2.ExecuteReader()) {
                                            if (reader2.HasRows) {
                                                reader2.Read();
                                                dr[13] = reader2.GetString(0);
                                            } else {
                                                dr[13] = "-";
                                            }
                                        }
                                    }
                                }





                                dt.Rows.Add(dr);
                            }
                        } else {
                            Util.Alert(this, "no data");
                            return;
                        }
                    }
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            {
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);
            }
            {
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "ลาป่วย";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);
            }
            {
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "ลากิจ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);
            }
            {
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "ลาพักผ่อน";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);
            }
            {
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 6;
                HeaderGridRow.Cells.Add(HeaderCell);
            }


            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }

    }
}