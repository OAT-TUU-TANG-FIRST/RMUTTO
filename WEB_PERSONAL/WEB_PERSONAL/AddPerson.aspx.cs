using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class AddPerson : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {

                notification.Attributes["class"] = "alert alert_info";
                notification.InnerHtml = "กรุณากรอกข้อมูล";

                DatabaseManager.BindDropDown(ddlTitle, "SELECT * FROM TB_TITLENAME", "TITLE_NAME_TH", "TITLE_ID", "--กรุณาเลือกคำนำหน้า--");
                DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM TB_GENDER", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือกเพศ--");
                DatabaseManager.BindDropDown(ddlRace, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกเชื้อชาติ--");
                DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกสัญชาติ--");
                DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM TB_RELIGION", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือกศาสนา--");

                DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือกจังหวัด--");
                DatabaseManager.BindDropDown(ddlAmphur, "SELECT * FROM TB_AMPHUR", "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ / เขต--");
                DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM TB_DISTRICT", "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล / แขวง--");
                DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกประเทศ--");

                DatabaseManager.BindDropDown(ddlProvince2, "SELECT * FROM TB_PROVINCE", "PROVINCE_TH", "PROVINCE_ID", "--กรุณาเลือกจังหวัด--");
                DatabaseManager.BindDropDown(ddlAmphur2, "SELECT * FROM TB_AMPHUR", "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ / เขต--");
                DatabaseManager.BindDropDown(ddlDistrict2, "SELECT * FROM TB_DISTRICT", "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล / แขวง--");
                DatabaseManager.BindDropDown(ddlCountry2, "SELECT * FROM TB_NATIONAL", "NATION_THA", "NATION_SEQ", "--กรุณาเลือกประเทศ--");
            }
        }

        protected void lbuV1Next_Click(object sender, EventArgs e) {
            if(tbCitizenID.Text == "" ||
                tbNameTH.Text == "") {

                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>เกิดข้อผิดพลาด</strong></div>";
                if (tbCitizenID.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอกบัตรประชาชน</div>";
                }
                if (tbNameTH.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอกชื่อ</div>";
                }

            } else {
                MultiView1.ActiveViewIndex = 1;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            
        }

        protected void lbuV2Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuV2Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuAddressFetch_Click(object sender, EventArgs e) {
            tbHomeAdd2.Text = tbHomeAdd.Text;
            tbSoi2.Text = tbSoi.Text;
            tbMoo2.Text = tbMoo.Text;
            tbRoad2.Text = tbRoad.Text;
            tbZipcode2.Text = tbZipcode.Text;
            tbState2.Text = tbState.Text;

            ddlProvince2.Items.Clear();
            ddlAmphur2.Items.Clear();
            ddlDistrict2.Items.Clear();

            ddlProvince2.Items.AddRange(ddlProvince.Items.OfType<ListItem>().ToArray());
            ddlAmphur2.Items.AddRange(ddlAmphur.Items.OfType<ListItem>().ToArray());
            ddlDistrict2.Items.AddRange(ddlDistrict.Items.OfType<ListItem>().ToArray());

            ddlProvince2.SelectedIndex = ddlProvince.SelectedIndex;
            ddlAmphur2.SelectedIndex = ddlAmphur.SelectedIndex;
            ddlDistrict2.SelectedIndex = ddlDistrict.SelectedIndex;
            ddlCountry2.SelectedIndex = ddlCountry.SelectedIndex;
        }

        protected void lbuV3Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuV3Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlAmphur, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ / เขต--");
        }

        protected void ddlAmphur_SelectedIndexChanged(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล / แขวง--");
        }

        protected void ddlProvince2_SelectedIndexChanged(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlAmphur2, "SELECT * FROM TB_AMPHUR WHERE PROVINCE_ID = " + ddlProvince2.SelectedValue, "AMPHUR_TH", "AMPHUR_ID", "--กรุณาเลือกอำเภอ / เขต--");
        }

        protected void ddlAmphur2_SelectedIndexChanged(object sender, EventArgs e) {
            DatabaseManager.BindDropDown(ddlDistrict2, "SELECT * FROM TB_DISTRICT WHERE AMPHUR_ID = " + ddlAmphur2.SelectedValue, "DISTRICT_TH", "DISTRICT_ID", "--กรุณาเลือกตำบล / แขวง--");
        }

        protected void lbuV4Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuV4Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV5Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuV5Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV6Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void lbuV6Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbuV7Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 5;
        }

        protected void lbuV7Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 7;
        }

        protected void lbuV8Back_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 6;
        }

        protected void lbuV8Next_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 8;
        }

        protected void lbuV5Add_Click(object sender, EventArgs e) {

        }

        protected void lbuV3Add_Click(object sender, EventArgs e) {

        }

        protected void lbuV6Add_Click(object sender, EventArgs e) {

        }

        protected void lbuV7Add_Click(object sender, EventArgs e) {

        }

        protected void lbuV8Add_Click(object sender, EventArgs e) {

        }
    }
}