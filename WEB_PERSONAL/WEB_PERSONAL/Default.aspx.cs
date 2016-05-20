using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using WEB_PERSONAL.Class;
using Oracle.DataAccess.Client;

namespace WEB_PERSONAL {
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            lbName.Text = loginPerson.FullName;
            lbStaffType.Text = loginPerson.StaffTypeName;
            lbPosition.Text = loginPerson.PositionName;
            lbPositionRank.Text = loginPerson.AdminPositionName;
            lbDepartment.Text = loginPerson.DivisionName;

            int count_cmd_low = DatabaseManager.GetLeaveRequiredCountByCommanderLow(loginPerson.CitizenID);
            int count_cmd_high = DatabaseManager.GetLeaveRequiredCountByCommanderHigh(loginPerson.CitizenID);
            int count_finish = 0;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNT(LEAVE_ID) FROM LEV_DATA WHERE PS_ID = '" + loginPerson.CitizenID + "' AND LEAVE_STATUS_ID in(3,7)", con)) {
                    using (OracleDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            count_finish = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            int count = count_cmd_low + count_cmd_high + count_finish;
            notification_area.InnerHtml = "";
            if (count == 0) {
                notification_area.InnerHtml += "<div class='alert alert_info'>ไม่มีรายการแจ้งเตือนในขณะนี้</div>";
                notification_area.InnerHtml += "<div><img src='Image/no-email.jpg' style='width: 100px;'/></div>";
            } else {
                notification_area.InnerHtml += "<div class='alert alert_warning'>คุณมี <strong>" + count + "</strong> รายการแจ้งเตือน</div>";
                if (count_cmd_low != 0) {
                    notification_area.InnerHtml += "<div class='comment_left' style='margin-bottom: 20px;'></div>";
                    notification_area.InnerHtml += "<div class='comment_center'><img src='Image/Small/pencil_y.png' class='icon_left'/>คุณมี <strong>" + count_cmd_low + "</strong> รายการที่ต้องลงความเห็นการลา<br>";
                    notification_area.InnerHtml += "<a href='LeaveComment.aspx' class='ps-button'>ไปหน้าการลงความเห็น<img src='Image/Small/next.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }
                if (count_cmd_high != 0) {
                    notification_area.InnerHtml += "<div class='allow_left' style='margin-bottom: 20px;'></div>";
                    notification_area.InnerHtml += "<div class='allow_center'><img src='Image/Small/correct.png' class='icon_left'/>คุณมี " + count_cmd_high + " รายการที่ต้องอนุมัติการลา<br>";
                    notification_area.InnerHtml += "<a href='LeaveAllow.aspx' class='ps-button'>ไปหน้าการอนุมัติ<img src='Image/Small/next.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }
                if (count_finish != 0) {
                    notification_area.InnerHtml += "<div class='complete_left' style='margin-bottom: 20px;'></div>";
                    notification_area.InnerHtml += "<div class='complete_center'><img src='Image/Small/correct.png' class='icon_left'/>คุณมี " + count_finish + " การลาที่เสร็จสิ้น<br>";
                    notification_area.InnerHtml += "<a href='LeaveHistory.aspx' class='ps-button'>ไปหน้าประวัติการลา<img src='Image/Small/next.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }

            }
        }

    }
}