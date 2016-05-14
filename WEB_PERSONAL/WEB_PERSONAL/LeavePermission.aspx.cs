﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class LeavePermission : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            
            using(OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using(OracleCommand com = new OracleCommand("SELECT (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE ADMIN_POSITION_ID = LEV_PERMISSION.ADMIN_POSITION_ID) ระดับ, REPLACE(PUY_MAX, 999, 'ตามที่เห็นสมควร') ลาป่วย, REPLACE(KIJ_MAX, 999, 'ตามที่เห็นสมควร') ลากิจ, FUNC_LEV_PM(GIVE_BIRTH) ลาคลอดบุตร, FUNC_LEV_PM(HELP_GIVE_BIRTH) ลาไปช่วยเหลือภริยาที่คลอดบุตร, FUNC_LEV_PM(REST) ลาพักผ่อน, FUNC_LEV_PM(ORDAIN_HUJ) ลาไปอุปสมบทหรือประกอบพิธีฮัจย์ FROM LEV_PERMISSION", con)) {
                    using(OracleDataReader reader = com.ExecuteReader()) {
                        while(reader.Read()) {
                            TableRow r = new TableRow();
                            TableCell c;

                            for (int i = 0; i < 7; i++) {
                                c = new TableCell();
                                c.Text = reader.GetString(i);
                                r.Cells.Add(c);
                            }
                            


                            Table1.Rows.Add(r);
                        }
                    }
                }
            }
        }

        protected void lbuEdit_Click(object sender, EventArgs e) {

        }
    }
}