using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Web.UI;
using System.Globalization;
using System.Data.OleDb;
using WEB_PERSONAL.Class;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using WEB_PERSONAL.Entities;

namespace WEB_PERSONAL {

    public class Util {

        public static readonly string CONNECTION_STRING = @"Provider=OraOLEDB.Oracle; Data Source = 203.158.140.67:1521/orcl;USER ID=rmutto;PASSWORD=Zxcvbnm";
        public static string ToOracleDate2(string date) {
            string[] s = date.Split('/');
            return s[0] + " " + ToOracleMonth(s[1]) + " " + (Convert.ToInt32(s[2]) - 543);
        }
        public static System.Data.DataTable dt;
        /*public static string YearDown543(DateTime date) {

        }*/
        public static string ToOracleDate(string date) {
            string[] s = date.Split('/');
            return s[0] + " " + ToOracleMonth(s[1]) + " " + s[2];
        }
        public static string ToOracleDate(DateTime date) {
            return date.Day.ToString("00") + " " + ToOracleMonth(date.Month) + " " + date.Year.ToString("0000");
        }
        public static DateTime toOracleDateTime(string date) {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static DateTime toOracleDateTime(DateTime date) {
            return DateTime.ParseExact(date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static DateTime ODT(string date) {

            string[] ss = date.Split(' ');

            switch (ss[1]) {
                case "ม.ค.": ss[1] = "01"; break;
                case "ก.พ.": ss[1] = "02"; break;
                case "มี.ค.": ss[1] = "03"; break;
                case "เม.ย.": ss[1] = "04"; break;
                case "พ.ค.": ss[1] = "05"; break;
                case "มิ.ย.": ss[1] = "06"; break;
                case "ก.ค.": ss[1] = "07"; break;
                case "ส.ค.": ss[1] = "08"; break;
                case "ก.ย.": ss[1] = "09"; break;
                case "ต.ค.": ss[1] = "10"; break;
                case "พ.ย.": ss[1] = "11"; break;
                case "ธ.ค.": ss[1] = "12"; break;
            }
            string d1 = ss[0] + "/" + ss[1] + "/" + ss[2];

            return DateTime.ParseExact(d1, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
        public static DateTime ODTT() {
            return DateTime.ParseExact(DateTime.Today.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static DateTime ODTN() {
            return DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static string NDT(string date) {
            string[] ss = date.Split(' ');
            if (ss.Length == 3) {
                return ss[0] + " " + ss[1] + " " + ss[2];
            } else {
                return ss[0] + " " + ss[1] + " " + ss[3];
            }
        }
        public static string ToOracleMonth(string month) {
            return ToOracleMonth(Int32.Parse(month));
        }
        public static string ToOracleMonth(int month) {
            switch (month) {
                case 1:
                default:
                    return "ม.ค.";
                case 2:
                    return "ก.พ.";
                case 3:
                    return "มี.ค.";
                case 4:
                    return "เม.ย.";
                case 5:
                    return "พ.ค.";
                case 6:
                    return "มิ.ย.";
                case 7:
                    return "ก.ก.";
                case 8:
                    return "ส.ค.";
                case 9:
                    return "ก.ย.";
                case 10:
                    return "ต.ค.";
                case 11:
                    return "พ.ย.";
                case 12:
                    return "ธ.ค.";
            }
        }
        public static string ToThaiWord(string s) {
            string[] ss = s.Split(' ');
            string s_day = ss[0];
            string s_month = ss[1];
            string s_year = ss[2];
            return "วันที่" + NormalizeThaiWord(NumberToThaiWord(s_day)) + "เดือน" + shortToLong(s_month) + "ปี" + NormalizeThaiWord(NumberToThaiWord(s_year));
        }
        public static string ToThaiMonth(string s) {
            int month = Int32.Parse(s.Trim());
            switch (month) {
                case 1: return "มกราคม";
                case 2: return "กุมภาพันธ์";
                case 3: return "มีนาคม";
                case 4: return "เมษายน";
                case 5: return "พฤษภาคม";
                case 6: return "มิถุนายน";
                case 7: return "กรกฎาคม";
                case 8: return "สิงหาคม";
                case 9: return "กันยายน";
                case 10: return "ตุลาคม";
                case 11: return "พฤศจิกายน";
                case 12: return "ธันวาคม";
                default: return "[ERROR]";
            }
        }
        public static string shortToLong(string s) {
            switch (s) {
                case "ม.ค.": return "มกราคม";
                case "ก.พ.": return "กุมภาพันธ์";
                case "มี.ค.": return "มีนาคม";
                case "เม.ย.": return "เมษายน";
                case "พ.ค.": return "พฤษภาคม";
                case "มิ.ย.": return "มิถุนายน";
                case "ก.ค.": return "กรกฎาคม";
                case "ส.ค.": return "สิงหาคม";
                case "ก.ย.": return "กันยายน";
                case "ต.ค.": return "ตุลาคม";
                case "พ.ย.": return "พฤศจิกายน";
                case "ธ.ค.": return "ธันวาคม";
                default: return "[ERROR]";
            }
        }
        public static int MonthToNumber(string s) {

            switch (s) {
                case "ม.ค.": return 1;
                case "ก.พ.": return 2;
                case "มี.ค.": return 3;
                case "เม.ย.": return 4;
                case "พ.ค.": return 5;
                case "มิ.ย.": return 6;
                case "ก.ค.": return 7;
                case "ส.ค.": return 8;
                case "ก.ย.": return 9;
                case "ต.ค.": return 10;
                case "พ.ย.": return 11;
                case "ธ.ค.": return 12;
                default: return -1;
            }
        }
        public static string NormalizeThaiWord(string s) {
            s = s.Replace("หนึ่งสิบ", "สิบ");
            s = s.Replace("สองสิบ", "ยี่สิบ");
            s = s.Replace("สิบหนึ่ง", "สิบเอ็ด");
            return s;
        }
        public static string NumberToThaiWord(string s) {
            string sout = "";
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] != '0')
                    sout += SingleNumberToThaiWord(s[i]) + ColumnNumberToThaiWord(s.Length - i - 1);
            }
            return sout;
        }
        public static string SingleNumberToThaiWord(char c) {
            switch (c) {
                case '0': return "ศูนย์";
                case '1': return "หนึ่ง";
                case '2': return "สอง";
                case '3': return "สาม";
                case '4': return "สี่";
                case '5': return "ห้า";
                case '6': return "หก";
                case '7': return "เจ็ด";
                case '8': return "แปด";
                case '9': return "เก้า";
                default: return "[ERROR]";
            }
        }
        public static string ColumnNumberToThaiWord(int column) {
            if (column == 0) {
                return "";
            } else {
                column = column % 6;
            }
            switch (column) {
                case 0: return "ล้าน";
                case 1: return "สิบ";
                case 2: return "ร้อย";
                case 3: return "พัน";
                case 4: return "หมื่น";
                case 5: return "แสน";
                default: return "[ERROR]";
            }
        }
        public static OracleConnection OC() {
            OracleConnection con = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;");
            con.Open();
            return con;
        }
        public static string CS() {
            return "DATA SOURCE=ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm;";
        }
        public static void Alert(Control control, string message) {
            string script2 = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(control, control.GetType(), "ServerControlScript", script2, true);
        }
        public static void RunScript(Control control, string script) {
            ScriptManager.RegisterClientScriptBlock(control, control.GetType(), "ServerControlScript", script, true);
        }

        //-------------------

        public static string ToOracleDateTime(DateTime dt) {
            string s = dt.ToString("dd/MM/yyyy");
            string[] s2 = s.Split('/');
            switch (s2[1]) {
                case "01": s2[1] = "ม.ค."; break;
                case "02": s2[1] = "ก.พ."; break;
                case "03": s2[1] = "มี.ค."; break;
                case "04": s2[1] = "เม.ย."; break;
                case "05": s2[1] = "พ.ค."; break;
                case "06": s2[1] = "มิ.ย."; break;
                case "07": s2[1] = "ก.ค."; break;
                case "08": s2[1] = "ส.ค."; break;
                case "09": s2[1] = "ก.ย."; break;
                case "10": s2[1] = "ต.ค."; break;
                case "11": s2[1] = "พ.ย."; break;
                case "12": s2[1] = "ธ.ค."; break;
            }
            return s2[0] + " " + s2[1] + " " + s2[2];
            //return s;
        }
        public static string DatabaseToDate(string s) {
            if (s == null) {
                return "''";
            }
            string[] ss = s.Split(' ');
            if (ss.Length != 3)
                return "''";
            switch (ss[1]) {
                case "ม.ค.": ss[1] = "01"; break;
                case "ก.พ.": ss[1] = "02"; break;
                case "มี.ค.": ss[1] = "03"; break;
                case "เม.ย.": ss[1] = "04"; break;
                case "พ.ค.": ss[1] = "05"; break;
                case "มิ.ย.": ss[1] = "06"; break;
                case "ก.ค.": ss[1] = "07"; break;
                case "ส.ค.": ss[1] = "08"; break;
                case "ก.ย.": ss[1] = "09"; break;
                case "ต.ค.": ss[1] = "10"; break;
                case "พ.ย.": ss[1] = "11"; break;
                case "ธ.ค.": ss[1] = "12"; break;
            }
            return "TO_DATE('" + ss[0] + "/" + ss[1] + "/" + (int.Parse(ss[2]) - 543) + "', 'DD/MM/YYYY')";
        }
        public static string TodayDatabaseToDate() {
            string s = "-";
            using (OleDbConnection con = new OleDbConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OleDbCommand com = new OleDbCommand("SELECT TO_CHAR(CURRENT_DATE, 'DD/MM/YYYY') FROM DUAL", con)) {
                    using (OleDbDataReader reader = com.ExecuteReader()) {
                        while (reader.Read()) {
                            s = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            //string[] ss = s.Split('/');
            //s = ss[0] + " " + ss[1] + " " + (int.Parse(ss[2]) - 543);
            return "TO_DATE('" + s + "', 'DD/MM/YYYY')";
        }
        public static string PureDatabaseToThaiDate(string s) {
            if (s == null) {
                return "";
            }
            string[] ss = s.Split('/');
            if (ss.Length != 3)
                return "";
            switch (int.Parse(ss[1])) {
                case 1: ss[1] = "ม.ค."; break;
                case 2: ss[1] = "ก.พ."; break;
                case 3: ss[1] = "มี.ค."; break;
                case 4: ss[1] = "เม.ย."; break;
                case 5: ss[1] = "พ.ค."; break;
                case 6: ss[1] = "มี.ค."; break;
                case 7: ss[1] = "ก.ค."; break;
                case 8: ss[1] = "ส.ค."; break;
                case 9: ss[1] = "ก.ย."; break;
                case 10: ss[1] = "ต.ค."; break;
                case 11: ss[1] = "พ.ศ."; break;
                case 12: ss[1] = "ธ.ค."; break;
            }
            return int.Parse(ss[0]).ToString("00") + " " + ss[1] + " " + ss[2].Substring(0, 4);
        }
        public static void alertF(Page page, string message) {
            page.Page.ClientScript.RegisterStartupScript(page.GetType(), "ALERT", "alert('" + message + "')", true);
        }
        public static void alertF(MasterPage page, string message) {
            page.Page.ClientScript.RegisterStartupScript(page.GetType(), "ALERT", "alert('" + message + "')", true);
        }
        public static bool IsDateValid(string date) {
            try {
                string[] split = date.Split(' ');

                if (split.Length != 3) {
                    return false;
                }

                string day = split[0];
                string month = split[1];
                string year = split[2];

                int iDay = int.Parse(day);
                if (iDay < 1 || iDay > 31) {
                    return false;
                }
                switch (month) {
                    case "ม.ค.":
                    case "ก.พ.":
                    case "มี.ค.":
                    case "เม.ย.":
                    case "พ.ค.":
                    case "มิ.ย.":
                    case "ก.ค.":
                    case "ส.ค.":
                    case "ก.ย.":
                    case "ต.ค.":
                    case "พ.ย.":
                    case "ธ.ค.":
                        break;
                    default: return false;
                }
                int iYear = int.Parse(year);
                if (iYear < 0 || iYear > 9999) {
                    return false;
                }


                return true;
            } catch {
                return false;
            }
        }
        public static DateTime ToDateTime(string date) {
            string[] split = date.Split(' ');
            string day = split[0];
            string month = split[1];
            string year = split[2];
            string sMonth = "";
            switch (month) {
                case "ม.ค.": sMonth = "01"; break;
                case "ก.พ.": sMonth = "02"; break;
                case "มี.ค.": sMonth = "03"; break;
                case "เม.ย.": sMonth = "04"; break;
                case "พ.ค.": sMonth = "05"; break;
                case "มิ.ย.": sMonth = "06"; break;
                case "ก.ค.": sMonth = "07"; break;
                case "ส.ค.": sMonth = "08"; break;
                case "ก.ย.": sMonth = "09"; break;
                case "ต.ค.": sMonth = "10"; break;
                case "พ.ย.": sMonth = "11"; break;
                case "ธ.ค.": sMonth = "12"; break;
            }
            DateTime dt = new DateTime(int.Parse(year), int.Parse(sMonth), int.Parse(day));
            return dt;

        }
        public static string ToThaiMonthShort(string monthNum) {
            switch (int.Parse(monthNum)) {
                case 1: return "ม.ค.";
                case 2: return "ก.พ.";
                case 3: return "มี.ค.";
                case 4: return "เม.ย.";
                case 5: return "พ.ค.";
                case 6: return "มี.ค.";
                case 7: return "ก.ค.";
                case 8: return "ส.ค.";
                case 9: return "ก.ย.";
                case 10: return "ต.ค.";
                case 11: return "พ.ศ.";
                case 12: return "ธ.ค.";
                default: return "[error]";
            }
        }
        public static void NormalizeGridViewDate(GridView gw, int rowIndex) {
            for (int i = 0; i < gw.Rows.Count; ++i) {
                string s = gw.Rows[i].Cells[rowIndex].Text;
                string[] ss = s.Split('/');
                gw.Rows[i].Cells[rowIndex].Text = PureDatabaseToThaiDate(s);
            }
        }
        public static void NormalizeGridViewDate7D(GridView gw, int rowIndex) {
            for (int i = 0; i < gw.Rows.Count; ++i) {
                string s = gw.Rows[i].Cells[rowIndex].Text;
                string[] ss1 = s.Split(' ');
                string[] ss2 = ss1[0].Split('-');
                string year = ss2[0];
                string month = ToThaiMonthShort(ss2[1]);
                string day = ss2[2];
                string day7 = ss1[2];
                switch(day7) {
                    case "1": day7 = "อาทิตย์"; break;
                    case "2": day7 = "จันทร์"; break;
                    case "3": day7 = "อังคาร"; break;
                    case "4": day7 = "พุธ"; break;
                    case "5": day7 = "พฤหัสบดี"; break;
                    case "6": day7 = "ศุกร์"; break;
                    case "7": day7 = "เสาร์"; break;
                    default: day = "[error]"; break;
                }
                gw.Rows[i].Cells[rowIndex].Text = day + " " + month + " " + year + " " + day7;
            }
        }
        public static void NormalizeGridViewDate(GridView gw, int[] rowIndex) {
            for (int i = 0; i < gw.Rows.Count; ++i) {
                for (int j = 0; j < rowIndex.Length; ++j) {
                    string s = gw.Rows[i].Cells[rowIndex[j]].Text;
                    string[] ss = s.Split('/');
                    gw.Rows[i].Cells[rowIndex[j]].Text = PureDatabaseToThaiDate(s);
                }

            }
        }
        public static string BirthdayToRetireDate(string birthday) {
            string[] ss = birthday.Split(' ');
            return "30 ก.ย. " + (int.Parse(ss[2]) + 60);
        }
        public static string MinusYear543(string date) {
            string[] ss = date.Split(' ');
            return ss[0] + " " + ss[1] + " " + (int.Parse(ss[2]) - 543);
        }
        public static string ToThaiWordBirthday(string birthday) {
            return ToThaiWord(MinusYear543(birthday));
        }
        public static string ToThaiWordRetire(string birthday) {
            return ToThaiWord(MinusYear543(BirthdayToRetireDate(birthday)));
        }

        public static string RandomPassword(int n) {
            Random r = new Random();
            string password = "";
            for (int i = 0; i < n; ++i) {
                password += r.Next(10);
            }
            return password;
        }
        public static void SendMail(PS_PERSON ps) {
            var fromAddress = new MailAddress("zplaygiirlz1@hotmail.com", "From Name");
            var toAddress = new MailAddress(ps.PS_EMAIL, "To Name");
            string fromPassword = "A1a2a3a4a5a6a7a8";
            string subject = "Your registered successful for this site personnel.rmutto.ac.th";
            string body =
                "<div>ชื่อผู้ใช้ : " + ps.PS_CITIZEN_ID + "</div>" +
                "<div>รหัสผ่าน : " + ps.PS_PASSWORD + "</div>" +
                "<div style='border-bottom: 1px solid #c0c0c0' margin: 10px 0;></div>" +
                "<div><a href='http://localhost:65308/Access.aspx?ID=" + ps.PS_CITIZEN_ID + "&Password=" + ps.PS_PASSWORD + "&Action=1'>เปลี่ยนรหัสผ่านได้ที่นี่</a></div>";

            var smtp = new SmtpClient {
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            MailMessage ms = new MailMessage(fromAddress, toAddress);
            ms.IsBodyHtml = true;
            ms.Subject = subject;
            ms.Body = body;
            smtp.Send(ms);

            /*using (var message = new MailMessage(fromAddress, toAddress) {
                message.IsBodyHtml = true,
                Subject = subject,
                Body = body
            }) {
                smtp.Send(message);
            }*/
        }

        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomFileName() {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 24)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Insig() {

            string ประเภทบุคลากร = "";
            string ตำแหน่งประเภท = "";
            string ระดับ = "";
            int เงินเดือน = 0;
            int ปี = 0;
            int เครื่องราชที่จะขอ = 0;
            int เงินเดือนขั้นต่ำชำนาญงาน = 0;
            int เงินเดือนขั้นต่ำชำนาญงานพิเศษ = 0;
            int ปีทช = 0;
            int ปีปม = 0;
            int ปีปช = 0;
            int ปีมวม = 0;

            if (ประเภทบุคลากร == "ข้าราชการ") {
                if(ตำแหน่งประเภท == "ระดับทั่วไป") {
                    if (ระดับ == "ระดับปฏิบัติงาน") {
                        if (เครื่องราชที่จะขอ == 12) { //บม
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 11) { //บช
                            if (ปี >= 10 && เงินเดือน < เงินเดือนขั้นต่ำชำนาญงาน) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 10) { //จม
                            if (ปี >= 10 && เงินเดือน > เงินเดือนขั้นต่ำชำนาญงาน) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 9) { //จช
                            if (ปี >= 10 && เงินเดือน > เงินเดือนขั้นต่ำชำนาญงาน) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับชำนาญงาน") {
                        if (เครื่องราชที่จะขอ == 8) { //ตม
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 7) { //ตช
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับอาวุโส") {
                        if (เครื่องราชที่จะขอ == 6) { //ทม
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 5) { //ทช
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                    }
                }
                if (ตำแหน่งประเภท == "ประเภทวิชาการ") {
                    if (ระดับ == "ระดับวิชาการ") {
                        if (เครื่องราชที่จะขอ == 8) { //ทม
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับชำนาญการ") {
                        if (เครื่องราชที่จะขอ == 7) { //ตช
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 6) { //ทม
                            if (ปี >= 5 && เงินเดือน > เงินเดือนขั้นต่ำชำนาญงานพิเศษ) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 5) { //ทช
                            if (ปี >= 5 && เงินเดือน > เงินเดือนขั้นต่ำชำนาญงานพิเศษ) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับชำนาญการพิเศษ") {
                        if (เครื่องราชที่จะขอ == 5) { //ทช
                            if (ปี >= 5) {
                                //ขอได้
                            }
                        }
                        if (เครื่องราชที่จะขอ == 4) { //ปม
                            if (ปี >= 5 && ปีทช >= 5 && เงินเดือน > เงินเดือนขั้นต่ำชำนาญงานพิเศษ /*และได้รับเงินเดือนขั้นสูง*/) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับเชี่ยวชาญ") {
                        if (เครื่องราชที่จะขอ == 2) { //มวม
                            if (ปี >= 5 && ปีทช >= 3 && ปีปม >= 3 && ปีปช >= 3) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับทรงคุณวุฒิ" && เงินเดือน == 13000) {
                        if (เครื่องราชที่จะขอ == 1) { //มปช
                            if (ปี >= 5 && ปีปม >= 3 && ปีปช >= 3 && ปีมวม >= 5) {
                                //ขอได้
                            }
                        }
                    }
                    if (ระดับ == "ระดับทรงคุณวุฒิ" && เงินเดือน == 15600) {
                        if (เครื่องราชที่จะขอ == 1) { //มปช
                            if (ปี >= 5 && ปีปม >= 3 && ปีปช >= 3 && ปีมวม >= 3) {
                                //ขอได้
                            }
                        }
                    }
                }
                if (ตำแหน่งประเภท == "ประเภทอำนวยการ") {

                }
                

            }





        }
    }



}