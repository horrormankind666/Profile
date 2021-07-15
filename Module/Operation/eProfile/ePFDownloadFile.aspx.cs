/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๖/๐๗/๒๕๕๙>
Modify date : <๑๕/๐๗/๒๕๖๔>
Description : <หน้าใช้งานเกี่ยวกับการดาวน์โหลดไฟล์>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using NUtil;
using NFinServiceLogin;

public partial class ePFDownloadFile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _f = Request.QueryString["f"];
        string _filePath = String.Empty;
        string _fileName = String.Empty;
        int _error = 0;

        if (_f.Equals(ePFUtil.SUBJECT_SECTION_MANUAL))
        {
            _filePath = ePFUtil._myUserManualPath;
            _fileName = ePFUtil._myUserManualFile;
            _error = Util.ViewFile(_filePath, _fileName);

            if (!_error.Equals(0)) Response.Redirect(_filePath + "/" + _fileName);
        }

        if (_f.Equals(ePFUtil.SUBJECT_SECTION_HELPALLOWPOPUP))
        {
            _filePath = "../../../Content/FileDownload/eProfile";
            _fileName = "AllowPopup.pdf";
            _error = Util.ViewFile(_filePath, _fileName);

            if (!_error.Equals(0)) Response.Redirect(_filePath + "/" + _fileName);
        }

        if (_f.Equals(ePFUtil.SUBJECT_SECTION_SCBACCOUNTOPENINGFORM))
        {
            Dictionary<string, object> _loginResult = ePFUtil.GetInfoLogin("", "");
            int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
            string _personId = _loginResult["PersonId"].ToString();
            string _nationality = String.Empty;

            if (_cookieError.Equals(0))
            {
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, _personId);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS];

                if (!String.IsNullOrEmpty(_dataRecorded["NationalityNameTH"].ToString()))
                {
                    string _cookie = (Util.GetCookie(FinServiceLogin.USERTYPE_STUDENT) != null ? Util.GetCookie(FinServiceLogin.USERTYPE_STUDENT).Value : String.Empty);
                    _nationality = (_dataRecorded["NationalityNameTH"].Equals("ไทย") ? "TH" : "EN");

                    Util.DBUtil.SetEventLog(String.Empty, String.Empty, _cookie, ("e-Profile => download account opening form 0 bath ( " + _nationality + " language )"), _personId);
                    ePFUtil.GetSCBAccountOpeningForm(_dataRecorded);
                }
                else
                {
                    StringBuilder _html = new StringBuilder();

                    _html.AppendLine("<div style='padding: 10px; text-align: center;'>");
                    _html.AppendLine("  <div class='th-label'>ไม่พบสัญชาติ กรุณาบันทึกสัญชาติในระบบระเบียนประวัตินักศึกษา</div>");
                    _html.AppendLine("  <div class='en-label' style='margin-top: 5px;'>Nationality not found.</div>");
                    _html.AppendLine("</div>");

                    Response.Write(_html.ToString());
                }
            }
            else
                Response.Redirect("index.aspx");
        }
    }
}