using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Globalization;

namespace WEB_PERSONAL.Class {

    public class Person {

        public string ID;
        public string CitizenID;
        public string TitleID;
        public string TitleName;
        public string FirstName;
        public string LastName;
        public DateTime? BirthDate;
        public string BirthDateLong;
        public DateTime? RetireDate;
        public string RetireDateLong;
        public DateTime? InWorkDate;
        public string StaffTypeID;
        public string StaffTypeName;
        public string FatherFirstName;
        public string FatherLastName;
        public string MotherFirstName;
        public string MotherLastName;
        public string MotherOldLastName;
        public string CoupleFirstName;
        public string CoupleLastName;
        public string CoupleOldLastName;
        public string MinistryID;
        public string MinistryName;
        public string DivisionID;
        public string DivisionName;
        public string Password;
        public string SystemStatusID;
        public string SystemStatusName;
        public string GenderID;
        public string GenderName;
        public string RaceID;
        public string RaceName;
        public string NationID;
        public string NationName;

        public string HomeAdd;
        public string Moo;
        public string Street;
        public string DistrictID;
        public string DistrictName;
        public string AmphurID;
        public string AmphurName;
        public string ProvinceID;
        public string ProvinceName;
        public string ZipCode;

        public string HomeAddNow;
        public string MooNow;
        public string StreetNow;
        public string DistrictIDNow;
        public string DistrictNameNow;
        public string AmphurIDNow;
        public string AmphurNameNow;
        public string ProvinceIDNow;
        public string ProvinceNameNow;
        public string ZipCodeNow;

        public string Telephone;
        public string TimeContactID;
        public string TimeContactName;
        public string BudgetID;
        public string BudgetName;
        public string SubStaffTypeID;
        public string SubStaffTypeName;
        public string AdminPositionID;
        public string AdminPositionName;
        public string AdminPositionPower;
        public string PositionWorkID;
        public string PositionWorkName;
        public string SpecialName;
        public string TeachISCEDID;
        public string TeachISCEDName;
        public string GradISCEDID;
        public string GradISCEDName;
        public string GradProgID;
        public string GradProgName;
        public string GradUniv;
        public string GradCountryID;
        public string GradCountryName;
        public string BranchID;
        public string BranchName;
        public string RankID;
        public string RankName;
        public string FacultyID;
        public string FacultyName;
        public string StartPositionWorkID;
        public string StartPositionWorkName;
        public string CampusID;
        public string CampusName;
        public string StatusID;
        public string StatusName;
        public string ReligionID;
        public string ReligionName;

        public string GotID;
        public string GetID;

        public string PositionID;
        public string PositionName;

        public int WorkYear;
        public int Salary;
        
        public int NotificationCount;

        public string Grom;
        public string BloodID;
        public string BloodName;
        public string Email;
        public string WorkTelephone;
        public string Soi;
        public string SoiNow;
        public string PlaceCountryID;
        public string PlaceCountryName;
        public string PlaceCountryNowID;
        public string PlaceCountryNowName;
        public string PlaceState;
        public string PlaceStateNow;
        public string StatusPersonID;
        public string StatusPersonName;

        public string WorkDivisionID;
        public string WorkDivisionName;

        public string StartAdminPositionID;
        public string StartAdminPositionName;

        public string PositionSalary;

        public DateTime? DateQuit;
        public int Permission;

        public string FullName {
            get { return TitleName + FirstName + " " + LastName; }
        }
        public string FirstNameAndLastName {
            get { return FirstName + " " + LastName; }
        }
        public string FatherFirstNameAndLastName {
            get { return FatherFirstName + " " + FatherLastName; }
        }
        public string MotherFirstNameAndLastName {
            get { return MotherFirstName + " " + MotherLastName; }
        }
        public string CoupleFirstNameAndLastName {
            get { return CoupleFirstName + " " + CoupleLastName; }
        }

        public bool IsTeacher() {
            return PositionWorkID == "10108" ? true : false;
        }
        public string AdminPositionNameExtra() {
            if(AdminPositionID == "1") {
                return "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            } else if (AdminPositionID == "2") {
                return CampusName;
            } else if (AdminPositionID == "4") {
                return FacultyName;
            } else if (AdminPositionID == "5") {
                return WorkDivisionName;
            } else if (AdminPositionID == "10") {
                return DivisionName;
            }
            return AdminPositionName;
        }

    }

}