using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class INSG_Qualified : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlYear, "SELECT * FROM INS_YEAR", "YEAR_ID", "YEAR_ID", "--กรุณาเลือกปี--");
            DatabaseManager.BindDropDown(ddlStaffType, "SELECT * FROM TB_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาประเภทบุคลากร--");
            DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM TB_CAMPUS", "CAMPUS_NAME", "CAMPUS_ID", "--กรุณาวิทยาเขต--");
            DatabaseManager.BindDropDown(ddlFaculty, "SELECT * FROM TB_FACULTY", "FACULTY_NAME", "FACULTY_ID", "--กรุณาเลือกคณะ--");
        }

        protected void lbuSearch_Click(object sender, EventArgs e) {
            DatabaseManager.BindGridView(gv1, "SELECT PS_PERSON.PS_CITIZEN_ID รหัสประชาชน, PS_PERSON.PS_FN_TH || ' ' || PS_PERSON.PS_LN_TH ชื่อ, FUNC_AGE(PS_BIRTHDAY_DATE) อายุ, FUNC_SHOW_DATE(PS_INWORK_DATE) วันที่เริ่มรับราชการ, (SELECT STAFFTYPE_NAME FROM TB_STAFFTYPE WHERE TB_STAFFTYPE.STAFFTYPE_ID = PS_PERSON.PS_STAFFTYPE_ID) ประเภทบุคลากร, (SELECT TB_POSITION.NAME FROM TB_POSITION WHERE PS_PERSON.PS_POSITION_ID = TB_POSITION.ID) ตำแหน่ง, (SELECT ADMIN_POSITION_NAME FROM TB_ADMIN_POSITION WHERE TB_ADMIN_POSITION.ADMIN_POSITION_ID = PS_PERSON.PS_ADMIN_POS_ID) ระดับ, (SELECT DIVISION_NAME FROM TB_DIVISION WHERE TB_DIVISION.DIVISION_ID = PS_PERSON.PS_DIVISION_ID) แผนก, (SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = PS_PERSON.PS_FACULTY_ID) คณะ, (SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = PS_PERSON.PS_CAMPUS_ID) วิทยาเขต, PS_SALARY เงินเดือน FROM PS_PERSON");
            if (gv1.Rows.Count > 0) {

                /*SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_MAIN.LEAVE_ID รหัสการลา, (SELECT PS_FN_TH || ' ' || PS_LN_TH FROM PS_PERSON WHERE PS_CITIZEN_ID = LEV_MAIN.PS_CITIZEN_ID) ชื่อผู้ลา, (SELECT LEAVE_TYPE_NAME FROM LEV_TYPE WHERE LEV_TYPE.LEAVE_TYPE_ID = LEV_MAIN.LEAVE_TYPE_ID) ประเภทการลา, LEV_MAIN.REQ_DATE วันที่ข้อมูล FROM LEV_MAIN WHERE LEAVE_STATE = 1 AND CL_ID = '" + loginPerson.CitizenID + "'");
                gv1.DataSource = sds;
                gv1.DataBind();*/

                //Util.NormalizeGridViewDate(gv1, 3);

                TableHeaderCell newHeader = new TableHeaderCell();
                newHeader.Text = "เลือก";
                gv1.HeaderRow.Cells.Add(newHeader);

                for (int i = 0; i < gv1.Rows.Count; ++i) {

                    string id = gv1.Rows[i].Cells[0].Text;

                    LinkButton lbu = new LinkButton();
                    lbu.Text = "<img src='Image/Small/send-email.png' class='icon_left'/>ส่งอีเมล";
                    lbu.CssClass = "ps-button";
                    lbu.Click += (e2, e3) => {

                    };
                    TableCell cell = new TableCell();
                    cell.Controls.Add(lbu);
                    gv1.Rows[i].Cells.Add(cell);
                }
            }
        }
    }
}