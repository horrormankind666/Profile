/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๖/๐๗/๒๕๕๙>
Modify date : <๑๖/๐๖/๒๕๖๔>
Description : <หน้าใช้งานเกี่ยวกับการดาวน์โหลดไฟล์>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Web.UI;
using NUtil;

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
            Dictionary<string, object> _loginResult = HCSUtil.GetInfoLogin("", "");
            int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
            string _personId = _loginResult["PersonId"].ToString();

            if (_cookieError.Equals(0))
            {
                ePFDB.SetEventLog(_loginResult, "download SCB account opening form");
                ePFUtil.GetSCBAccountOpeningForm();
            }
            else
                Response.Redirect("index.aspx");
        }
    }
}