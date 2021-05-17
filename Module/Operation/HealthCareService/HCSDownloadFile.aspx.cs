using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class HCSDownloadFile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<string, object> _loginResult = HCSUtil.GetInfoLogin("", "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        string _personId = _loginResult["PersonId"].ToString();
        string _studentId = _loginResult["StudentId"].ToString();

        try
        {
            if (_cookieError.Equals(0) && _userError.Equals(0))
            {
                Dictionary<string, object> _valueDataRecorded = HCSUtil.SetValueDataRecorded(HCSUtil.PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN, _personId);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + HCSUtil.SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS];

                HCSUtil.HCSStaffDownloadRegistrationFormUtil.GetRegisForm(_dataRecorded);

                downloadformsuccess.Value = "Y";
                downloadformcookieerror.Value = _cookieError.ToString();
                downloadformusererror.Value = _userError.ToString();
            }
            else
            {
                downloadformsuccess.Value = "N";
                downloadformcookieerror.Value = _cookieError.ToString();
                downloadformusererror.Value = _userError.ToString();
            }
        }
        catch
        {
            downloadformsuccess.Value = "N";
            downloadformcookieerror.Value = "0";
            downloadformusererror.Value = "0";
        }
    }
}