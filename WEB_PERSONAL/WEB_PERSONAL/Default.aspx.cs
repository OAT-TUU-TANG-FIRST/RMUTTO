using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person loginPerson = ps.LoginPerson;
            lbName.Text = loginPerson.FullName;
            lbPosition.Text = loginPerson.PositionName;
            lbPositionRank.Text = loginPerson.AdminPositionName;
            lbDepartment.Text = loginPerson.DepartmentName;

            int count_cmd_low = DatabaseManager.GetLeaveRequiredCountByCommanderLow(loginPerson.CitizenID);
            int count_cmd_high = DatabaseManager.GetLeaveRequiredCountByCommanderHigh(loginPerson.CitizenID);
            int count_finish = 0;
            using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT COUNT(LEAVE_ID) FROM LEV_LEAVE WHERE CITIZEN_ID = '" + loginPerson.CitizenID + "' AND LEV_LEAVE.STATE_ID = 5", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
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
                    notification_area.InnerHtml += "<a href='LeaveComment.aspx' class='button button_default'>ไปหน้าการลงความเห็น<img src='Image/Small/forward.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }
                if (count_cmd_high != 0) {
                    notification_area.InnerHtml += "<div class='allow_left' style='margin-bottom: 20px;'></div>";
                    notification_area.InnerHtml += "<div class='allow_center'><img src='Image/Small/correct.png' class='icon_left'/>คุณมี " + count_cmd_high + " รายการที่ต้องอนุมัติการลา<br>";
                    notification_area.InnerHtml += "<a href='LeaveAllow.aspx' class='button button_default'>ไปหน้าการอนุมัติ<img src='Image/Small/forward.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }
                if (count_finish != 0) {
                    notification_area.InnerHtml += "<div class='complete_left' style='margin-bottom: 20px;'></div>";
                    notification_area.InnerHtml += "<div class='complete_center'>คุณมี " + count_finish + " รายการที่สำเร็จ<br>";
                    notification_area.InnerHtml += "<a href='LeaveHistory.aspx' class='button button_default'>ไปหน้าสถานะ และ ประวัติการลา<img src='Image/Small/forward.png' class='icon_right' /></a>";
                    notification_area.InnerHtml += "</div>";
                }

            }
        }

    }
}