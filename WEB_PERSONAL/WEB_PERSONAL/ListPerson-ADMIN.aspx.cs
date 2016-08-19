using WEB_PERSONAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;
using System.Data.OracleClient;

namespace WEB_PERSONAL
{
    public partial class ListPerson_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearchCitizenID.Attributes.Add("onkeypress", "return allowOnlyNumber(this);");
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchCitizenID.Text))
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องคำค้นหา</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            if (txtSearchCitizenID.Text.Length < 13)
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";
                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                notification.InnerHtml += "<div> - กรุณากรอกรหัสบัตรประชาชนในช่องค้นหาให้ครบ 13 หลัก</div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string result = "";
                using (OracleCommand com = new OracleCommand("SELECT PS_CITIZEN_ID FROM PS_PERSON WHERE PS_CITIZEN_ID = '" + txtSearchCitizenID.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetString(0);
                        }
                    }
                }

                if (result == txtSearchCitizenID.Text)
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM PS_PERSON WHERE PS_CITIZEN_ID = :PS_CITIZEN_ID";
                    SqlDataSource1.SelectParameters.Add(":PS_CITIZEN_ID", txtSearchCitizenID.Text);

                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
                else
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>แจ้งเตือน</strong></div>";
                    notification.InnerHtml += "<div> - ไม่พบข้อมูลของรหัสบัตรประชาชนดังกล่าว</div>";
                    return;
                }
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPerson-ADMIN.aspx");
        }
    }
}