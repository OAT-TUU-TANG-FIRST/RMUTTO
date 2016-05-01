using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.IO;
using WEB_PERSONAL.Class;

namespace WEB_PERSONAL {
    public partial class Profile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            Person pp = ps.LoginPerson;

            profile_images.InnerHtml = "";
            string[] personImageFileNames = DatabaseManager.GetPersonImageFileNames(pp.CitizenID);
            for (int i = 0; i < personImageFileNames.Length; i++) {
                string path = "Upload/PersonImage/" + personImageFileNames[i];

                Panel p = new Panel();
                p.Style.Add("display", "inline-block");

                LinkButton lb = new LinkButton();
                lb.Attributes["href"] = path;
                p.Controls.Add(lb);

                Image img = new Image();
                img.Attributes["src"] = path;
                lb.Controls.Add(img);

                profile_images.Controls.Add(p);

                Panel p2 = new Panel();
                p.Controls.Add(p2);
                /*lb.Controls.Add(img1);
                
                profile_images.InnerHtml += "<div style='display: inline-block;'>";
                profile_images.InnerHtml += "<a href='" + path + "'><img src='" + path + "' /></a>";
                profile_images.InnerHtml += "<div id='id1'></div>";
                profile_images.InnerHtml += "</div>";*/

                LinkButton lbSelectImagePresent = new LinkButton();
                lbSelectImagePresent.CssClass = "ps-button";
                lbSelectImagePresent.Text = "เลือก";
                lbSelectImagePresent.Click += (e1,e2) => {
                    Response.Redirect("Default.aspx");
                };
                p2.Controls.Add(lbSelectImagePresent);
                //FindControl("id1").Controls.Add(lbSelectImagePresent);
            }
 

            lbCitizenID.Text = pp.CitizenID;
            lbFirstName.Text = pp.FirstName;
            lbLastName.Text = pp.LastName;
            lbGender.Text = pp.GenderName;
            lbBirthday.Text = pp.BirthDate;
            lbInWorkDay.Text = pp.InWorkDate;
            lbPosition.Text = pp.PositionName;
            lbAdminPosition.Text = pp.AdminPositionName;
            lbDept.Text = pp.DivisionName;
            lbFaculty.Text = pp.FacultyName;
            lbCampus.Text = pp.CampusName;
            lbMinistry.Text = pp.MinistryName;
            //lbGrom.Text = pp.Grom;
            lbRace.Text = pp.RaceName;
            lbNation.Text = pp.NationName;
            //lbBlood.Text = pp.BloodName;
            //lbEmail.Text = pp.Email;
            //lbPhone.Text = pp.Phone;
            //lbWorkPhone = pp.WorkPhone;
            lbReligion.Text = pp.ReligionName;
            lbStatus.Text = pp.StatusName;
            lbFather.Text = pp.FatherFirstNameAndLastName;
            lbMother.Text = pp.MotherFirstNameAndLastName;
            lbCouple.Text = pp.CoupleFirstNameAndLastName;

            lbHomeAdd.Text = pp.HomeAdd;
            //lbSoi.Text = pp.Soi;
            lbMoo.Text = pp.Moo;
            lbStreet.Text = pp.Street;
            lbProvince.Text = pp.ProvinceName;
            lbAmphur.Text = pp.AmphurName;
            lbDistrict.Text = pp.DistrictName;
            lbZipcode.Text = pp.ZipCode;
            //lbCountry.Text = pp.PlaceCountry;
            //lbState.Text = pp.PlaceState;

            lbHomeAddNow.Text = pp.HomeAddNow;
            //lbSoiNow.Text = pp.SoiNow;
            lbMooNow.Text = pp.MooNow;
            lbStreetNow.Text = pp.StreetNow;
            lbProvinceNow.Text = pp.ProvinceNameNow;
            lbAmphurNow.Text = pp.AmphurNameNow;
            lbDistrictNow.Text = pp.DistrictNameNow;
            lbZipcodeNow.Text = pp.ZipCodeNow;
            //lbCountryNow.Text = pp.PlaceCountryNow;
            //lbStateNow.Text = pp.PlaceStateNow;

        }

        protected void lbuUploadPicture_Click(object sender, EventArgs e) {
            if (FileUpload1.HasFile) {
                string fname = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Upload/PersonImage/" + fname));
            }
        }

        protected void lbuSec1_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 0;
            lbuSec1.CssClass = "ps-vs-sel";
            lbuSec2.CssClass = "ps-vs";
            lbuSec3.CssClass = "ps-vs";
        }

        protected void lbuSec2_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 1;
            lbuSec1.CssClass = "ps-vs";
            lbuSec2.CssClass = "ps-vs-sel";
            lbuSec3.CssClass = "ps-vs";
        }

        protected void lbuSec3_Click(object sender, EventArgs e) {
            MultiView1.ActiveViewIndex = 2;
            lbuSec1.CssClass = "ps-vs";
            lbuSec2.CssClass = "ps-vs";
            lbuSec3.CssClass = "ps-vs-sel";
        }
    }
}