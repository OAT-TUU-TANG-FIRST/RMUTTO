using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WEB_PERSONAL.Class;
using System.Data.OleDb;
using System.Text;
using System.IO;

namespace WEB_PERSONAL {
    public partial class ViewLeaveForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if(!IsPostBack) {
                if (Request.QueryString["LeaveID"] == null) {
                    return;
                }

                int leaveID = int.Parse(Request.QueryString["LeaveID"]);
                LeaveData leaveData = new LeaveData();
                leaveData.Load(leaveID);

                if (!leaveData.HasData) {
                    return;
                }

                trPSBirthDate.Visible = false;
                trPSWorkInDate.Visible = false;
                trWifeName.Visible = false;
                trGBDate.Visible = false;
                trOrdained.Visible = false;
                trTempleName.Visible = false;
                trTempleLocation.Visible = false;
                trOrdainDate.Visible = false;
                trHujed.Visible = false;
                trReason.Visible = false;
                trContact.Visible = false;
                trPhone.Visible = false;
                trRestSave.Visible = false;
                trRestLeft.Visible = false;
                trRestTotal.Visible = false;
                trStatistic.Visible = false;
                trCancelReason.Visible = false;
                trCLCancelComment.Visible = false;
                trCLCancelDate.Visible = false;
                trCHCancelComment.Visible = false;
                trCHCancelDate.Visible = false;
                trCHCancelAllow.Visible = false;

                if (leaveData.LeaveTypeID == 1) {
                    trStatistic.Visible = true;
                    trReason.Visible = true;
                    trContact.Visible = true;
                    trPhone.Visible = true;
                } else if (leaveData.LeaveTypeID == 2) {
                    trStatistic.Visible = true;
                    trReason.Visible = true;
                    trContact.Visible = true;
                    trPhone.Visible = true;
                } else if (leaveData.LeaveTypeID == 3) {
                    trStatistic.Visible = true;
                    trReason.Visible = true;
                    trContact.Visible = true;
                    trPhone.Visible = true;
                } else if (leaveData.LeaveTypeID == 4) {
                    trRestSave.Visible = true;
                    trRestLeft.Visible = true;
                    trRestTotal.Visible = true;
                    trContact.Visible = true;
                    trPhone.Visible = true;
                } else if (leaveData.LeaveTypeID == 5) {
                    trWifeName.Visible = true;
                    trGBDate.Visible = true;
                    trContact.Visible = true;
                    trPhone.Visible = true;
                } else if (leaveData.LeaveTypeID == 6) {
                    trPSBirthDate.Visible = true;
                    trPSWorkInDate.Visible = true;
                    trOrdained.Visible = true;
                    trTempleName.Visible = true;
                    trTempleLocation.Visible = true;
                    trOrdainDate.Visible = true;
                } else if (leaveData.LeaveTypeID == 7) {
                    trPSBirthDate.Visible = true;
                    trPSWorkInDate.Visible = true;
                    trHujed.Visible = true;
                }

                if (leaveData.LeaveStatusID >= 1 && leaveData.LeaveStatusID <= 4) {

                } else if (leaveData.LeaveStatusID >= 5 && leaveData.LeaveStatusID <= 8) {
                    trCancelReason.Visible = true;
                    trCLCancelComment.Visible = true;
                    trCLCancelDate.Visible = true;
                    trCHCancelComment.Visible = true;
                    trCHCancelDate.Visible = true;
                    trCHCancelAllow.Visible = true;
                }

                lbLeaveID.Text = leaveData.LeaveID.ToString();
                lbLeaveStatusID.Text = leaveData.LeaveStatusName;
                lbLeaveType.Text = leaveData.LeaveTypeName;
                lbReqDate.Text = leaveData.RequestDate.Value.ToLongDateString();
                /*lbPSName.Text = leaveData.PS_Title + leaveData.PS_FirstName + " " + leaveData.PS_LastName;
                lbPSPos.Text = leaveData.PS_Position;
                lbPSAPos.Text = leaveData.PS_AdminPosition;
                lbPSDept.Text = leaveData.PS_Department;

                if (leaveData.PS_BirthDate.HasValue) {
                    lbPSBirthDate.Text = leaveData.PS_BirthDate.Value.ToLongDateString();
                } else {
                    lbPSBirthDate.Text = "-";
                }
                if (leaveData.PS_WorkInDate.HasValue) {
                    lbPSWorkInDate.Text = leaveData.PS_WorkInDate.Value.ToLongDateString();
                } else {
                    lbPSWorkInDate.Text = "-";
                }*/

                lbRestSave.Text = leaveData.RestSave + " วัน";
                lbRestLeft.Text = leaveData.RestLeft + " วัน";
                lbRestTotal.Text = leaveData.RestTotal + " วัน";

                lbWifeName.Text = leaveData.WifeFirstName + " " + leaveData.WifeLastName;
                if (leaveData.GiveBirthDate.HasValue) {
                    lbGBDate.Text = leaveData.GiveBirthDate.Value.ToLongDateString();
                } else {
                    lbGBDate.Text = "-";
                }

                lbOrdained.Text = leaveData.Ordained == 1 ? "เคย" : "ไม่เคย";
                lbTempleName.Text = leaveData.TempleName;
                lbTempleLocation.Text = leaveData.TempleLocation;
                if (leaveData.OrdainDate.HasValue) {
                    lbOrdainDate.Text = leaveData.OrdainDate.Value.ToLongDateString();
                } else {
                    lbOrdainDate.Text = "-";
                }

                lbHujed.Text = leaveData.Hujed == 1 ? "เคย" : "ไม่เคย";

                if (leaveData.FromDate.HasValue) {
                    lbFTTDate.Text = leaveData.FromDate.Value.ToLongDateString() + " ถึง " + leaveData.ToDate.Value.ToLongDateString() + " รวม " + leaveData.TotalDay + " วัน";
                } else {
                    lbFTTDate.Text = "ไม่เคยลา";
                }
                lbStatistic.Text = "ลามาแล้ว " + leaveData.CountPast + " วัน / ลาครั้งนี้ " + leaveData.CountNow + " วัน / รวม " + leaveData.CountTotal + " วัน";

                lbReason.Text = leaveData.Reason;
                lbContact.Text = leaveData.Contact;
                lbPhone.Text = leaveData.Telephone;

                if (leaveData.LastFromDate.HasValue) {
                    lbLastFTTDate.Text = leaveData.LastFromDate.Value.ToLongDateString() + " ถึง " + leaveData.LastToDate.Value.ToLongDateString() + " รวม " + leaveData.LastTotalDay + " วัน";
                } else {
                    lbLastFTTDate.Text = "ไม่เคยลา";
                }

                /*if(leaveData.CL_ID == null) {
                    lbCLName.Text = "-";
                    lbCLPos.Text = "-";
                    lbCLCom.Text = "-";
                    lbCLDate.Text = "-";
                } else {
                    lbCLName.Text = leaveData.CL_Title + leaveData.CL_FirstName + " " + leaveData.CL_LastName;
                    lbCLPos.Text = leaveData.CL_Position;
                    if (leaveData.CL_Comment != "") {
                        lbCLCom.Text = leaveData.CL_Comment;
                    } else {
                        lbCLCom.Text = "-";
                    }
                    if (leaveData.CL_Date.HasValue) {
                        lbCLDate.Text = leaveData.CL_Date.Value.ToLongDateString();
                    } else {
                        lbCLDate.Text = "-";
                    }
                }

                
                lbCHName.Text = leaveData.CH_Title + leaveData.CH_FirstName + " " + leaveData.CH_LastName;
                lbCHPos.Text = leaveData.CH_Position;
                if (leaveData.CH_Comment != "") {
                    lbCHCom.Text = leaveData.CH_Comment;
                } else {
                    lbCHCom.Text = "-";
                }
                if (leaveData.CH_Date.HasValue) {
                    lbCHDate.Text = leaveData.CH_Date.Value.ToLongDateString();
                    lbCHAllow.Text = leaveData.CH_Allow == 1 ? "อนุมัติ" : "ไม่อนุมัติ";
                } else {
                    lbCHDate.Text = "-";
                    lbCHAllow.Text = "-";
                }

                if (leaveData.DocterCertificationFileName != "") {
                    string loc = "Upload/DrCer/" + leaveData.DocterCertificationFileName;
                    div_dr_cer.InnerHtml += "<a href='" + loc + "'><img src='" + loc + "' /></a>";
                }

                if (leaveData.LeaveStatusID >= 1 && leaveData.LeaveStatusID <= 4) {

                } else if (leaveData.LeaveStatusID >= 5 && leaveData.LeaveStatusID <= 8) {
                    lbCancelReason.Text = leaveData.CancelReason;
                    if (leaveData.CL_CancelDate.HasValue) {
                        lbCL_C_Com.Text = leaveData.CL_CancelComment;
                        lbCL_C_Date.Text = leaveData.CL_CancelDate.Value.ToLongDateString();
                    } else {
                        lbCL_C_Com.Text = "-";
                        lbCL_C_Date.Text = "-";
                    }
                    if (leaveData.CH_CancelDate.HasValue) {
                        lbCH_C_Com.Text = leaveData.CH_CancelComment;
                        lbCH_C_Date.Text = leaveData.CH_CancelDate.Value.ToLongDateString();
                        lbCH_C_Allow.Text = leaveData.CH_CancelAllow == 1 ? "อนุมัติ" : "ไม่อนุมัติ";
                    } else {
                        lbCH_C_Com.Text = "-";
                        lbCH_C_Date.Text = "-";
                        lbCH_C_Allow.Text = "-";
                    }

                }

                string _psCLImage = DatabaseManager.GetPersonImageFileName(leaveData.CL_ID);
                string _psCHImage = DatabaseManager.GetPersonImageFileName(leaveData.CH_ID);
                if (_psCLImage != "") {
                    psCLImage.Src = "Upload/PersonImage/" + _psCLImage;
                }
                if (_psCHImage != "") {
                    psCHImage.Src = "Upload/PersonImage/" + _psCHImage;
                }*/
            }

            


        }

        

        /*protected void lbuPrint_Click(object sender, EventArgs e) {
            Response.Redirect("PrintLeaveForm.aspx?LeaveID=" + Request.QueryString["LeaveID"].ToString());
        }*/
    }


}