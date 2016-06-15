using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class INSG_Qualified : System.Web.UI.Page {

        private Panel pCondition;
        private Panel pBar;
        private Image img1;
        private Image img2;
        private Label lb1;
        private Label lb2;
        private bool OK = true;
        private string cccStaffType = "";
        private string cccCampus = "";
        private string cccFaculty = "";

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาประเภทบุคลากร--");
                DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM TB_CAMPUS", "CAMPUS_NAME", "CAMPUS_ID", "--กรุณาวิทยาเขต--");
                DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY", "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกคณะ--");
            }
            
            search();
        }
        private void search() {

            if(ddlStaffType.SelectedIndex > 0 ) {
                cccStaffType = " AND PS_STAFFTYPE_ID = " + ddlStaffType.SelectedValue;
            }
            if (ddlCampus.SelectedIndex > 0)
            {
                cccCampus = " AND PS_CAMPUS_ID = " + ddlCampus.SelectedValue;
            }
            if (ddlFaculty.SelectedIndex > 0)
            {
                cccFaculty = " AND PS_FACULTY_ID = " + ddlFaculty.SelectedValue;
            }

            if (hf1.Value != "") {
                Random r = new Random();
                {
                    Table1.Rows.Clear();
                    TableRow row = new TableRow();
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        CheckBox cb = new CheckBox();
                        cb.AutoPostBack = true;
                        cb.CheckedChanged += (e2, e3) => {
                            for (int i = 1; i < Table1.Rows.Count; i++) {
                                CheckBox cb2 = (CheckBox)Table1.Rows[i].Cells[0].Controls[0];
                                cb2.Checked = cb.Checked;
                            }
                        };
                        cell.Controls.Add(cb);
                        Label lb = new Label();
                        lb.Text = "เลือก";
                        cell.Controls.Add(lb);
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ชื่อ - สกุล";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ชั้นเครื่องราชฯ ปัจจุบัน";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เงื่อนไข";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ชั้นเครื่องราชฯ ชั้นถัดไป";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "วันที่บรรจุ";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "เงินเดือน";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ตำแหน่ง";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "ประเภทบุคลากร";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "วิทยาเขต";
                        row.Cells.Add(cell);
                    }
                    {
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "สำนัก / สถาบัน / คณะ";
                        row.Cells.Add(cell);
                    }
                    Table1.Rows.Add(row);
                }
                
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT PS_PERSON.PS_CITIZEN_ID รหัสประชาชน, PS_PERSON.PS_FN_TH || ' ' || PS_PERSON.PS_LN_TH ชื่อ, PS_STAFFTYPE_ID, PS_PIG_ID, (SELECT TRUNC((SYSDATE - PS_INWORK_DATE)/365,0) from PS_PERSON A WHERE A.PS_CITIZEN_ID = PS_PERSON.PS_CITIZEN_ID) ปีทำงาน, PS_SALARY, PS_INWORK_DATE, PS_SALARY, (SELECT NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) ตำแหน่ง, PS_ACAD_POS_ID, PS_ADMIN_POS_ID, PS_PIE_ID, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE PS_PERSON.PS_STAFFTYPE_ID = TB_STAFFTYPE.STAFFTYPE_ID) ชื่อประเภทบุคลากร, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = PS_PERSON.PS_CAMPUS_ID) วิทยาเขต, (SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = PS_PERSON.PS_FACULTY_ID) คณะ FROM PS_PERSON WHERE PS_STAFFTYPE_ID in(1,2,3,6) " + cccStaffType + cccCampus + cccFaculty, con)) {
                        using (OracleDataReader reader = com.ExecuteReader()) {
                            while (reader.Read()) {

                                OK = true;
                                string psID = reader.GetString(0);

                                TableRow row = new TableRow();
                                row.CssClass = "ps-ins-item";

                                img1 = new Image();
                                img2 = new Image();
                                lb1 = new Label();
                                lb2 = new Label();
                                pBar = new Panel();
                                pCondition = new Panel();

                                lb1.Style.Add("font-weight", "bold");
                                lb1.Style.Add("font-size", "16px");
                                lb1.Text = "[ERROR]";

                                lb2.Style.Add("font-weight", "bold");
                                lb2.Style.Add("font-size", "16px");
                                lb2.Text = "[ERROR]";

                                {
                                    CheckBox cb = new CheckBox();
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(cb);
                                    row.Cells.Add(cell);
                                }

                                {
                                    LinkButton lbName = new LinkButton();
                                    lbName.Text = reader.GetString(1);
                                    lbName.Click += (e2, e3) => {
                                        Response.Redirect("INSG_Qualified_Detail.aspx?psID=" + psID);
                                    };
                                    lbName.Attributes.Add("tuu", psID);
                                    //lbName.Attributes.Add("tuu2", psID);
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lbName);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Panel p1 = new Panel();
                                    p1.Style.Add("text-align", "center");

                                    p1.Controls.Add(img1);

                                    Panel p2 = new Panel();
                                    p2.Style.Add("text-align", "center");

                                    p2.Controls.Add(lb1);

                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(p1);
                                    cell.Controls.Add(p2);
                                    row.Cells.Add(cell);
                                }

                                {

                                    Panel barOFF = new Panel();
                                    barOFF.Style.Add("width", "200px");
                                    barOFF.Style.Add("height", "10px");
                                    barOFF.Style.Add("display", "inline-block");
                                    barOFF.Style.Add("background", "linear-gradient(to bottom, #808080, #414141)");
                                    barOFF.Style.Add("border-radius", "10px");

                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(pBar);
                                    cell.Controls.Add(pCondition);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Panel p1 = new Panel();
                                    p1.CssClass = "ps-ins-container";

                                    Panel p1c = new Panel();
                                    p1c.CssClass = "ps-ins-tag";
                                    p1.Controls.Add(p1c);
                                    p1.Controls.Add(img2);

                                    Panel p2 = new Panel();
                                    p2.Style.Add("text-align", "center");


                                    p2.Controls.Add(lb2);

                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(p1);
                                    cell.Controls.Add(p2);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblDateInwork = new Label();
                                    lblDateInwork.Text = reader.GetDateTime(6).ToString("dd MMM yyyy");
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblDateInwork);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblSalary = new Label();
                                    lblSalary.Text = reader.GetInt32(7).ToString("#,###");
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblSalary);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblPosition = new Label();
                                    lblPosition.Text = reader.GetString(8);
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblPosition);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblStaffTypeName = new Label();
                                    lblStaffTypeName.Text = reader.GetString(12);
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblStaffTypeName);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblCampus = new Label();
                                    lblCampus.Text = reader.GetString(13);
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblCampus);
                                    row.Cells.Add(cell);
                                }

                                {
                                    Label lblFaculty = new Label();
                                    lblFaculty.Text = reader.GetString(14);
                                    TableCell cell = new TableCell();
                                    cell.Controls.Add(lblFaculty);
                                    row.Cells.Add(cell);
                                }

                                //Table1.Rows.Add(row);

                                int รหัสประเภทบุคลากร = reader.GetInt32(2);
                                int รหัสระดับตำแหน่ง = reader.GetInt32(3);
                                int รหัสตำแหน่งทางวิชาการ = reader.GetInt32(9);
                                int รหัสตำแหน่งทางบริหาร = reader.GetInt32(10);
                                int รหัสกลุ่มงานพนักงานราชการ = reader.GetInt32(11);
                                int รหัสเครืองราชปัจจุบัน = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT IUG_INSIG_ID FROM TB_INSIG_USER_GET WHERE IUG_STATUS = 1 AND IUG_CITIZEN_ID = '" + psID + "'", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            รหัสเครืองราชปัจจุบัน = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                int ปีที่ทำงาน = reader.GetInt32(4);
                                int เงินเดือนปัจจุบัน = reader.GetInt32(5);

                                int เงินเดือนขั้นต่ำของระดับชำนาญงาน = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT P_SAL_MIN FROM TB_POSITION_SAL_MINMAX WHERE P_POS_ID = 14102", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            เงินเดือนขั้นต่ำของระดับชำนาญงาน = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                int ปีที่ดำรงตำแหน่งระดับปฏิบัติงาน = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT TRUNC((CURRENT_DATE - PDH_DATE_START)/365,0) FROM TB_POSITION_DEGREE_HISTORY WHERE PID_ID = 1 AND PDH_CITIZEN_ID = '" + psID + "'", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            ปีที่ดำรงตำแหน่งระดับปฏิบัติงาน = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                int ปีที่ดำรงตำแหน่งระดับชำนาญงาน = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT TRUNC((CURRENT_DATE - PDH_DATE_START)/365,0) FROM TB_POSITION_DEGREE_HISTORY WHERE PID_ID = 2 AND PDH_CITIZEN_ID = '" + psID + "'", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            ปีที่ดำรงตำแหน่งระดับชำนาญงาน = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                int ปีที่ดำรงตำแหน่งระดับอาวุโส = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT TRUNC((CURRENT_DATE - PDH_DATE_START)/365,0) FROM TB_POSITION_DEGREE_HISTORY WHERE PID_ID = 3 AND PDH_CITIZEN_ID = '" + psID + "'", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            ปีที่ดำรงตำแหน่งระดับอาวุโส = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                int เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ = -1;
                                using (OracleCommand com2 = new OracleCommand("SELECT P_SAL_MIN FROM TB_POSITION_SAL_MINMAX WHERE P_POS_ID = 13103", con)) {
                                    using (OracleDataReader reader2 = com2.ExecuteReader()) {
                                        while (reader2.Read()) {
                                            เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ = reader2.GetInt32(0);
                                        }

                                    }
                                }

                                if (รหัสประเภทบุคลากร == 1) {//ข้าราชการ
                                    if (รหัสระดับตำแหน่ง == 1) {//ระดับปฏิบัติงาน
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","บ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 12) {
                                            ConditionExecute(new string[] {
                                                "บ.ม.","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน <= เงินเดือนขั้นต่ำของระดับชำนาญงาน,
                                                ปีที่ดำรงตำแหน่งระดับปฏิบัติงาน >= 10
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนน้อยกว่าเงินเดือนขั้นต่ำของระดับชำนาญงาน",
                                                "ปีที่ดำรงตำแหน่งระดับปฏิบัติงานไม่น้อยกว่า 10 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญงาน,
                                                ปีที่ดำรงตำแหน่งระดับปฏิบัติงาน >= 10
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญงาน",
                                                "ปีที่ดำรงตำแหน่งระดับปฏิบัติงานไม่น้อยกว่า 10 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญงาน,
                                                ปีที่ดำรงตำแหน่งระดับปฏิบัติงาน >= 10
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญงาน",
                                                "ปีที่ดำรงตำแหน่งระดับปฏิบัติงานไม่น้อยกว่า 10 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] { "จ.ช.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 2) {//ระดับชำนาญงาน
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                ปีที่ดำรงตำแหน่งระดับชำนาญงาน >= 5
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ปีที่ดำรงตำแหน่งระดับชำนาญงานไม่น้อยกว่า 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] { "ต.ช.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 3) {//ระดับอาวุโส
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                ปีที่ดำรงตำแหน่งระดับอาวุโส >= 5
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ปีที่ดำรงตำแหน่งระดับอาวุโสไม่น้อยกว่า 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] { "ท.ช.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 4) {//ระดับปฏิบัติการ
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] { "ต.ม.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 5) {//ระดับชำนาญการ
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ,
                                                1 == 1 /*--------------------------*/
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ",
                                                "ได้รับเงินเดือนไม่ต่ำกว่าขั้นต่ำของระดับชำนาญการพิเศษมาแล้วไม่น้อยกว่า 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] { "ท.ช.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 6) {//ระดับชำนาญการพิเศษ
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ,
                                                1 == 1 /*--------------------------*/
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ",
                                                "ได้รับเงินเดือนขั้นสูงและได้ ท.ช. มาแล้วไม่น้อยกว่า 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] { "ป.ม.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 7) {//ระดับเชี่ยวชาญ
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ม.ว.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                                1 == 1,
                                                1 == 1
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ช. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ป.ม. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ป.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 2) {
                                            ConditionExecute(new string[] { "ม.ว.ม.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 8) {//ระดับทรงคุณวุฒิ 13000
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ม.ป.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                                1 == 1,
                                                1 == 1
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ป.ม. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ป.ช. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ม.ว.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 2) {
                                            ConditionExecute(new string[] { "ม.ป.ช.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 10) {//อำนวยการ ระดับต้น
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                เงินเดือนปัจจุบัน > เงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ,
                                                1 == 1 , /*--------------------------*/
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "เงินเดือนมากกว่าเงินเดือนขั้นต่ำของระดับชำนาญการพิเศษ",
                                                "ได้รับเงินเดือนขั้นสูงและได้ ท.ช. มาแล้วไม่น้อยกว่า 3 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] { "ป.ม.", "" });
                                        }
                                    } else if (รหัสระดับตำแหน่ง == 11) {//อำนวยการ ระดับสูง
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ม.ว.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                                1 == 1,
                                                1 == 1
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ช. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ป.ม. มาแล้วไม่น้อยกว่า 3 ปี",
                                                "ได้ ป.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 2) {
                                            ConditionExecute(new string[] { "ม.ว.ม.", "" });
                                        }
                                    }
                                } else if (รหัสประเภทบุคลากร == 2) {//พนง ในสถาบัน
                                    if (รหัสตำแหน่งทางบริหาร == 10024) {// 2.หัวหน้าแผนก / ฝ่าย
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] {
                                                "จ.ช.","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] { "ต.ม.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางวิชาการ == 1 || รหัสตำแหน่งทางวิชาการ == 2) {// 3.ผศ. หรือ อาจารย์
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] {
                                                "จ.ช.","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] { "ท.ม.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางบริหาร == 5 || รหัสตำแหน่งทางบริหาร == 6) {// 4.ผช อธิการบดี หรือ รอง คณบดี
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] { "ท.ม.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางบริหาร == 5 || รหัสตำแหน่งทางบริหาร == 6) {// 5.รศ
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] { "ป.ม.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางบริหาร == 5 || รหัสตำแหน่งทางบริหาร == 6) {// 6.รองอธิการบดี คณบดี
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] { "ท.ช.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางวิชาการ == 4) {// 7.ศาสตราจารย์
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] {
                                                "ป.ม.","ป.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 3) {
                                            ConditionExecute(new string[] { "ป.ช.", "" });
                                        }
                                    } else if (รหัสตำแหน่งทางบริหาร == 1) {// 8.อธิการบดี
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] { "ป.ม.", "" });
                                        }
                                    } else {
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","บ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 12) {
                                            ConditionExecute(new string[] {
                                                "บ.ม.","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] { "จ.ช.", "" });
                                        }
                                    }
                                } else if (รหัสประเภทบุคลากร == 6) {//พนักงานราชการ
                                    if (รหัสกลุ่มงานพนักงานราชการ == 1 || รหัสกลุ่มงานพนักงานราชการ == 2) {
                                        if (รหัสเครืองราชปัจจุบัน == -1) { //1
                                            ConditionExecute(new string[] {
                                                "","บ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 12) {
                                            ConditionExecute(new string[] {
                                                "บ.ม.","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ บ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ บ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] { "จ.ช.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 3) { //2
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ บ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] {
                                                "จ.ช.","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] { "ต.ม.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 4) { //3
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] {
                                                "จ.ช.","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] { "ต.ช.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 5) { //4
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] {
                                                "จ.ช.","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ จ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] { "ท.ม.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 6) { //5
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 8) {
                                            ConditionExecute(new string[] {
                                                "ต.ม.","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] { "ท.ช.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 7) { //6
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ต.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 7) {
                                            ConditionExecute(new string[] {
                                                "ต.ช.","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ต.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ช. มาแล้วไม่น้อยกว่า 3 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] { "ป.ม.", "" });
                                        }
                                    } else if (รหัสกลุ่มงานพนักงานราชการ == 8) { //7
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","ท.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5
                                            }, new string[] {
                                                "อายุงานครบ 5 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 6) {
                                            ConditionExecute(new string[] {
                                                "ท.ม.","ท.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 5) {
                                            ConditionExecute(new string[] {
                                                "ท.ช.","ป.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ท.ช. มาแล้วไม่น้อยกว่า 3 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 4) {
                                            ConditionExecute(new string[] {
                                                "ป.ม.","ป.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 5,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 5 ปี",
                                                "ได้ ป.ม. มาแล้วไม่น้อยกว่า 3 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 3) {
                                            ConditionExecute(new string[] { "ป.ช.", "" });
                                        }
                                    }
                                } else if (รหัสประเภทบุคลากร == 3) {//ลูกจ้างประจำ
                                    if(เงินเดือนปัจจุบัน >= 8340 && เงินเดือนปัจจุบัน <= 15050) {
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","บ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6
                                            }, new string[] {
                                                "อายุงานครบ 6 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 12) {
                                            ConditionExecute(new string[] {
                                                "บ.ม.","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 6 ปี",
                                                "ได้ บ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 6 ปี",
                                                "ได้ บ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] { "จ.ม.", "" });
                                        }
                                    } else if (เงินเดือนปัจจุบัน >= 15050) {
                                        if (รหัสเครืองราชปัจจุบัน == -1) {
                                            ConditionExecute(new string[] {
                                                "","บ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6
                                            }, new string[] {
                                                "อายุงานครบ 6 ปี"
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 11) {
                                            ConditionExecute(new string[] {
                                                "บ.ช.","จ.ม."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 6 ปี",
                                                "ได้ บ.ช. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 10) {
                                            ConditionExecute(new string[] {
                                                "จ.ม.","จ.ช."
                                            }, new bool[] {
                                                ปีที่ทำงาน >= 6,
                                                1 == 1,
                                        }, new string[] {
                                                "อายุงานครบ 6 ปี",
                                                "ได้ จ.ม. มาแล้วไม่น้อยกว่า 5 ปี",
                                            });
                                        } else if (รหัสเครืองราชปัจจุบัน == 9) {
                                            ConditionExecute(new string[] { "จ.ช.", "" });
                                        }
                                    }
                                }

                                    if (OK) {
                                    Table1.Rows.Add(row);
                                }

                            }
                        }
                    }

                }

            }
        }
        private void ConditionExecute(string[] ins) {
            if (ins[0] == "") {
                img1.Attributes["src"] = "";
                lb1.Text = "ไม่เคยได้รับ";
            } else {
                img1.Attributes["src"] = "Image/Insignia/" + ins[0] + ".png";
                lb1.Text = ins[0];
            }
            if (ins[1] == "") {
                img2.Attributes["src"] = "";
                lb2.Text = "-";
            } else {
                img2.Attributes["src"] = "Image/Insignia/" + ins[1] + ".png";
                lb2.Text = ins[1];
            }
        }
        private void ConditionExecute(string[] ins, bool[] b, string[] s) {
            if(ins[0] == "") {
                img1.Attributes["src"] = "";
                lb1.Text = "ไม่เคยได้รับ";
            } else {
                img1.Attributes["src"] = "Image/Insignia/" + ins[0] + ".png";
                lb1.Text = ins[0];
            }
            if (ins[1] == "") {
                img2.Attributes["src"] = "";
                lb2.Text = "-";
            } else {
                img2.Attributes["src"] = "Image/Insignia/" + ins[1] + ".png";
                lb2.Text = ins[1];
            }

            int size = b.Length;
            int get = 0;
            for (int i = 0; i < size; i++) {
                get += Convert.ToInt32(b[i]);
                ConditionLabel(pCondition, s[i], b[i]);
            }
            ConditionBar(pBar, get, size);
        }
        private void ConditionLabel(Panel p, string word, bool b) {
            if (b) {
                Panel pp = new Panel();
                Label lb = new Label();
                lb.Text = "<img src='Image/Small/correct.png' class='icon_left'/>" + word;
                pp.Controls.Add(lb);
                p.Controls.Add(pp);
            } else {
                Panel pp = new Panel();
                Label lb = new Label();
                lb.Text = "<img src='Image/Small/delete.png' class='icon_left'/>" + word;
                pp.Controls.Add(lb);
                p.Controls.Add(pp);
                if (hf1.Value == "1") {
                    OK = false;
                }
                 
            }
        }
        private void ConditionBar(Panel p, int get, int max) {

            int width = 200;
            int height = 10;
            double widthON = (double)width * ((double)get / (double)max);
            double widthOFF = (double)width * (((double)max - (double)get) / (double)max);


            Panel bar = new Panel();
            Panel barON = new Panel();
            Panel barOFF = new Panel();
            barON.Style.Add("width", widthON + "px");
            barON.Style.Add("height", height + "px");
            barON.Style.Add("display", "inline-block");
            barON.Style.Add("background", "linear-gradient(to bottom, #22ff00, #1ac600)");
            barON.Style.Add("border-top-left-radius", height + "px");
            barON.Style.Add("border-bottom-left-radius", height + "px");

            barOFF.Style.Add("width", widthOFF + "px");
            barOFF.Style.Add("height", height + "px");
            barOFF.Style.Add("display", "inline-block");
            barOFF.Style.Add("background", "linear-gradient(to bottom, #808080, #636363)");
            barOFF.Style.Add("border-top-right-radius", height + "px");
            barOFF.Style.Add("border-bottom-right-radius", height + "px");

            if (get == 0) {
                barOFF.Style.Add("border-top-left-radius", height + "px");
                barOFF.Style.Add("border-bottom-left-radius", height + "px");
            }
            if (get == max) {
                barON.Style.Add("border-top-right-radius", height + "px");
                barON.Style.Add("border-bottom-right-radius", height + "px");
            }

            bar.Controls.Add(barON);
            bar.Controls.Add(barOFF);
            p.Controls.Add(bar);
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            hf1.Value = "1";
            Page_Load(sender, e);
        }

        protected void lbuSend_Click(object sender, EventArgs e) {
            
            for (int i = 1; i < Table1.Rows.Count; ++i)
            {
                CheckBox cb = (CheckBox)Table1.Rows[i].Cells[0].Controls[0];
                LinkButton lbu = (LinkButton)Table1.Rows[i].Cells[1].Controls[0];
                if (cb != null && cb.Checked)
                {
                    int id = 0;
                    using (OracleConnection conn = Util.OC())
                    {
                        PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                        Person loginPerson = ps.LoginPerson;
                        using (OracleCommand command = new OracleCommand("INSERT INTO TB_INSIG_REQUEST (IR_STATUS,IR_CITIZEN_ID,IR_INSIG_ID) VALUES (:IR_STATUS,:IR_CITIZEN_ID,:IR_INSIG_ID) ", conn))
                        {

                            try
                            {
                                if (conn.State != ConnectionState.Open)
                                {
                                    conn.Open();
                                }
                                command.Parameters.Add(new OracleParameter("IR_STATUS", 1));
                                command.Parameters.Add(new OracleParameter("IR_CITIZEN_ID", lbu.Attributes["tuu"]));
                                command.Parameters.Add(new OracleParameter("IR_INSIG_ID", "12"));
                                id = command.ExecuteNonQuery();
                            }

                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                command.Dispose();
                                conn.Close();
                            }
                        }
                    }
                } 
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ส่งรายชื่อเรียบร้อยแล้ว !')", true);
        }

        protected void lbuSearchAll_Click(object sender, EventArgs e) {
            hf1.Value = "2";
            Page_Load(sender, e);
        }
    }
}