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
                DatabaseManager.BindDropDown(ddlBlood, "SELECT * FROM TB_BLOOD", "BLOOD_NAME", "BLOOD_ID", "--กรุณาเลือกกรุ๊ปเลือด--");
                DatabaseManager.BindDropDown(ddlStatus, "SELECT * FROM TB_STATUS_PERSON", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือกสถานภาพ--");

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
            if(tbCitizenID.Text == "" || ddlTitle.SelectedIndex == 0 || tbNameTH.Text == ""|| tbLastNameTH.Text == "" || tbNameEN.Text == "" || tbLastNameEN.Text == "" || ddlGender.SelectedIndex == 0 || tbBirthday.Text == "" || ddlRace.SelectedIndex == 0 || ddlNation.SelectedIndex == 0 || ddlBlood.SelectedIndex == 0 || tbEmail.Text == "" || tbPhone.Text == "" || tbTelephone.Text == "" || ddlReligion.SelectedIndex == 0 || ddlStatus.SelectedIndex == 0 || tbFatherName.Text == "" || tbFatherLastName.Text == "" || tbMotherName.Text == "" || tbMotherLastName.Text == "" || tbMotherOldLastName.Text == "" || tbCoupleName.Text == "" || tbCoupleLastName.Text == "" || tbCoupleOldLastName.Text == "") {

                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong>เกิดข้อผิดพลาด !</strong></div>";
                if (tbCitizenID.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'บัตรประชาชน'</div>";
                }
                if (ddlTitle.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'คำนำหน้า'</div>";
                }
                if (tbNameTH.Text == "") {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ'</div>";
                }
                if (tbLastNameTH.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล'</div>";
                }
                if (tbNameEN.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อ อังกฤษ'</div>";
                }
                if (tbLastNameEN.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุล อังกฤษ'</div>";
                }
                if (ddlGender.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'เพศ'</div>";
                }
                if (tbBirthday.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'วันเกิด'</div>";
                }
                if (ddlRace.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'เชื้อชาติ'</div>";
                }
                if (ddlNation.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'สัญชาติ'</div>";
                }
                if (ddlBlood.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'กรุ๊ปเลือด'</div>";
                }
                if (tbEmail.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'อีเมล'</div>";
                }
                if (tbPhone.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์มือถือ'</div>";
                }
                if (tbTelephone.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'โทรศัพท์ที่ทำงาน'</div>";
                }
                if (ddlReligion.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ศาสนา'</div>";
                }
                if (ddlStatus.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'สถานภาพ'</div>";
                }
                if (tbFatherName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อบิดา'</div>";
                }
                if (tbFatherLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลบิดา'</div>";
                }
                if (tbMotherName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อมารดา'</div>";
                }
                if (tbMotherLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดา'</div>";
                }
                if (tbMotherOldLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลมารดาเดิม'</div>";
                }
                if (tbCoupleName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ชื่อคู่สมรส'</div>";
                }
                if (tbCoupleLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรส'</div>";
                }
                if (tbCoupleOldLastName.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'นามสกุลคู่สมรสเดิม'</div>";
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

        protected void lbuV2Next_Click(object sender, EventArgs e)
        {
            if (tbHomeAdd.Text == "" || tbSoi.Text == "" || tbMoo.Text == "" || tbRoad.Text == "" || ddlProvince.SelectedIndex == 0 || ddlAmphur.SelectedIndex == 0 || ddlDistrict.SelectedIndex == 0 || tbZipcode.Text == "" || ddlCountry.SelectedIndex == 0 || tbState.Text == "" ||
                tbHomeAdd2.Text == "" || tbSoi2.Text == "" || tbMoo2.Text == "" || tbRoad2.Text == "" || ddlProvince2.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0 || tbZipcode2.Text == "" || ddlCountry2.SelectedIndex == 0 || tbState2.Text == "")
            {
                notification.Attributes["class"] = "alert alert_danger";
                notification.InnerHtml = "";

                notification.InnerHtml += "<div><img src='Image/Small/red_alert.png' /><strong> เกิดข้อผิดพลาด !</strong></div>";
                if (tbHomeAdd.Text == "" || tbHomeAdd2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'บ้านเลขที่'</div>";
                }
                if (tbSoi.Text == "" || tbSoi2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ซอย'</div>";
                }
                if (tbMoo.Text == "" || tbMoo2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'หมู่'</div>";
                }
                if (tbRoad.Text == "" || tbRoad2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'ถนน'</div>";
                }
                if (ddlProvince.SelectedIndex == 0 || ddlProvince2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'จังหวัด'</div>";
                }
                if (ddlAmphur.SelectedIndex == 0 || ddlAmphur2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'อำเภอ / เขต'</div>";
                }
                if (ddlDistrict.SelectedIndex == 0 || ddlDistrict2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ตำบล / แขวง'</div>";
                }
                if (tbZipcode.Text == "" || tbZipcode2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'รหัสไปรณีย์'</div>";
                }
                if (ddlCountry.SelectedIndex == 0 || ddlCountry2.SelectedIndex == 0)
                {
                    notification.InnerHtml += "<div>กรุณาเลือก 'ประเทศ'</div>";
                }
                if (tbState.Text == "" || tbState2.Text == "")
                {
                    notification.InnerHtml += "<div>กรุณากรอก 'รัฐ'</div>";
                }
            }
            else {
                MultiView1.ActiveViewIndex = 2;
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
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