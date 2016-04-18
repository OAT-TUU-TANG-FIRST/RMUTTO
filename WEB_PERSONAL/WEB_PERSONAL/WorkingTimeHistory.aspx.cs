using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class WorkingTimeHistory : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                SqlDataSource sds = DatabaseManager.CreateSQLDataSource("SELECT LEV_WORKTIME.CITIZEN_ID รหัสพนักงาน, (SELECT PERSON_NAME || ' ' || PERSON_LASTNAME FROM TB_PERSON WHERE TB_PERSON.CITIZEN_ID = LEV_WORKTIME.CITIZEN_ID) ชื่อ, TODAY || ' ' || TO_CHAR(TODAY, 'DY') วันที่, LEV_WORKTIME.WORKTIME_SEC_ID รหัสกะงาน, (SELECT WORKTIME_SEC_HOUR_IN || ':' || WORKTIME_SEC_MINUTE_IN FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เข้างาน, (SELECT WORKTIME_SEC_HOUR_OUT || ':' || WORKTIME_SEC_MINUTE_OUT FROM LEV_WORKTIME_SEC WHERE LEV_WORKTIME_SEC.WORKTIME_SEC_ID = LEV_WORKTIME.WORKTIME_SEC_ID) เลิกงาน, HOUR_IN || ':' || MINUTE_IN เข้า, HOUR_OUT || ':' || MINUTE_OUT ออก, LATE_IN สาย, LATE_OUT ออกก่อน, ABSENT ขาด FROM LEV_WORKTIME, LEV_WORKTIME_SEC WHERE LEV_WORKTIME.WORKTIME_SEC_ID = LEV_WORKTIME_SEC.WORKTIME_SEC_ID");
                GridView1.DataSource = sds;
                GridView1.DataBind();
            }
        }
    }
}