/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๘/๐๙/๒๕๕๗>
Modify date : <๑๘/๐๖/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไป>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using NUtil;
using NExportToPDF;
using NFinServiceLogin;

public class ePFUtil
{
    public const string SUBJECT_SECTION_PRIVACYPOLICY = "PrivacyPolicy";
    public const string SUBJECT_SECTION_TERMSCONDITION = "TermsCondition";
    public const string SUBJECT_SECTION_PRIVACYNOTICE = "PrivacyNotice";
    public const string SUBJECT_SECTION_CONSENT = "Consent";
    public const string SUBJECT_SECTION_PRIVACYPOLICYTERMSCONDITION = (SUBJECT_SECTION_PRIVACYPOLICY + SUBJECT_SECTION_TERMSCONDITION);
    public const string SUBJECT_SECTION_PRIVACYPOLICYPRIVACYNOTICE = (SUBJECT_SECTION_PRIVACYPOLICY + SUBJECT_SECTION_PRIVACYNOTICE);
    public const string SUBJECT_SECTION_PRIVACYPOLICYCONSENT = (SUBJECT_SECTION_PRIVACYPOLICY + SUBJECT_SECTION_CONSENT);
    public const string SUBJECT_SECTION_STUDENTRECORDS = "StudentRecords";
    public const string SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV = (SUBJECT_SECTION_STUDENTRECORDS + "StudentCV");
    public const string SUBJECT_SECTION_PERSONAL = "Personal";
    public const string SUBJECT_SECTION_ADDRESS = "Address";
    public const string SUBJECT_SECTION_ADDRESSPERMANENT = (SUBJECT_SECTION_ADDRESS + "Permanent");
    public const string SUBJECT_SECTION_ADDRESSCURRENT = (SUBJECT_SECTION_ADDRESS + "Current");
    public const string SUBJECT_SECTION_EDUCATION = "Education";
    public const string SUBJECT_SECTION_EDUCATIONPRIMARYSCHOOL = (SUBJECT_SECTION_EDUCATION + "PrimarySchool");
    public const string SUBJECT_SECTION_EDUCATIONJUNIORHIGHSCHOOL = (SUBJECT_SECTION_EDUCATION + "JuniorHighSchool");
    public const string SUBJECT_SECTION_EDUCATIONHIGHSCHOOL = (SUBJECT_SECTION_EDUCATION + "HighSchool");
    public const string SUBJECT_SECTION_EDUCATIONUNIVERSITY = (SUBJECT_SECTION_EDUCATION + "University");
    public const string SUBJECT_SECTION_EDUCATIONADMISSIONSCORES = (SUBJECT_SECTION_EDUCATION + "AdmissionScores");
    public const string SUBJECT_SECTION_TALENT = "Talent";
    public const string SUBJECT_SECTION_HEALTHY = "Healthy";
    public const string SUBJECT_SECTION_BODYMASSINDEX = "BodyMassIndex";
    public const string SUBJECT_SECTION_TRAVELABROAD = "TravelAbroad";
    public const string SUBJECT_SECTION_WORK = "Work";
    public const string SUBJECT_SECTION_FINANCIAL = "Financial";
    public const string SUBJECT_SECTION_FAMILY = "Family";
    public const string SUBJECT_FAMILYFATHER = "Father";
    public const string SUBJECT_FAMILYMOTHER = "Mother";
    public const string SUBJECT_FAMILYPARENT = "Parent";
    public const string SUBJECT_SECTION_MANUAL = "Manual";
    public const string SUBJECT_SECTION_HELP = "Help";
    public const string SUBJECT_SECTION_CONTACTUS = "ContactUs";
    public const string SUBJECT_SECTION_FILLINFORMATIONSTUDENTRECORDS = "FillInformationStudentRecords";    
    public const string SUBJECT_SECTION_ALLOWPOPUP = "AllowPopup";
    public const string SUBJECT_SECTION_HELPFILLINFORMATIONSTUDENTRECORDS = (SUBJECT_SECTION_HELP + SUBJECT_SECTION_FILLINFORMATIONSTUDENTRECORDS);            
    public const string SUBJECT_SECTION_HELPCONTACTUS = (SUBJECT_SECTION_HELP + SUBJECT_SECTION_CONTACTUS);
    public const string SUBJECT_SECTION_HELPALLOWPOPUP = (SUBJECT_SECTION_HELP + SUBJECT_SECTION_ALLOWPOPUP);
    public const string SUBJECT_SECTION_SCBACCOUNTOPENINGFORM = "SCBAccountOpeningForm";
    public const string SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_STUDENTRECORDS);
    public const string SUBJECT_SECTION_STUDENTRECORDSPERSONAL = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_PERSONAL);
    public const string SUBJECT_SECTION_STUDENTRECORDSADDRESS = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_ADDRESS);
    public const string SUBJECT_SECTION_STUDENTRECORDSADDRESSPERMANENT = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_ADDRESSPERMANENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSADDRESSCURRENT = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_ADDRESSCURRENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATION = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATION);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATIONPRIMARYSCHOOL);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATIONJUNIORHIGHSCHOOL);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATIONHIGHSCHOOL);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATIONUNIVERSITY);
    public const string SUBJECT_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_EDUCATIONADMISSIONSCORES);
    public const string SUBJECT_SECTION_STUDENTRECORDSTALENT = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_TALENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSHEALTHY = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_HEALTHY);
    public const string SUBJECT_SECTION_STUDENTRECORDSBODYMASSINDEX = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_BODYMASSINDEX);
    public const string SUBJECT_SECTION_STUDENTRECORDSTRAVELABROAD = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_TRAVELABROAD);
    public const string SUBJECT_SECTION_STUDENTRECORDSWORK = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_WORK);
    public const string SUBJECT_SECTION_STUDENTRECORDSFINANCIAL = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_FINANCIAL);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILY = (SUBJECT_SECTION_STUDENTRECORDS + SUBJECT_SECTION_FAMILY);            
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER = (SUBJECT_SECTION_STUDENTRECORDSFAMILY + SUBJECT_FAMILYFATHER);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER + SUBJECT_SECTION_PERSONAL);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER + SUBJECT_SECTION_ADDRESSPERMANENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER + SUBJECT_SECTION_ADDRESSCURRENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERWORK = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER + SUBJECT_SECTION_WORK);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER = (SUBJECT_SECTION_STUDENTRECORDSFAMILY + SUBJECT_FAMILYMOTHER);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER + SUBJECT_SECTION_PERSONAL);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER + SUBJECT_SECTION_ADDRESSPERMANENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER + SUBJECT_SECTION_ADDRESSCURRENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERWORK = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER + SUBJECT_SECTION_WORK);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILY + SUBJECT_FAMILYPARENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT + SUBJECT_SECTION_PERSONAL);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT + SUBJECT_SECTION_ADDRESSPERMANENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT + SUBJECT_SECTION_ADDRESSCURRENT);
    public const string SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTWORK = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT + SUBJECT_SECTION_WORK);
    
    public const string ID_SECTION_PRIVACYPOLICY_MAIN = ("Main-" + SUBJECT_SECTION_PRIVACYPOLICY);
    public const string ID_SECTION_PRIVACYPOLICYTERMSCONDITION_MAIN = ("Main-" + SUBJECT_SECTION_PRIVACYPOLICYTERMSCONDITION);
    public const string ID_SECTION_PRIVACYPOLICYPRIVACYNOTICE_MAIN = ("Main-" + SUBJECT_SECTION_PRIVACYPOLICYPRIVACYNOTICE);
    public const string ID_SECTION_PRIVACYPOLICYCONSENT_MAIN = ("Main-" + SUBJECT_SECTION_PRIVACYPOLICYCONSENT);
    public const string ID_SECTION_STUDENTRECORDS_MAIN = ("Main-" + SUBJECT_SECTION_STUDENTRECORDS);
    public const string ID_SECTION_STUDENTRECORDS_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDS);
    public const string ID_SECTION_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS);
    public const string ID_SECTION_STUDENTRECORDSPERSONAL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSPERSONAL);
    public const string ID_SECTION_STUDENTRECORDSADDRESS_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSADDRESS);
    public const string ID_SECTION_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSADDRESSPERMANENT);
    public const string ID_SECTION_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSADDRESSCURRENT);
    public const string ID_SECTION_STUDENTRECORDSEDUCATION_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATION);
    public const string ID_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL);
    public const string ID_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL);
    public const string ID_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL);
    public const string ID_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY);
    public const string ID_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES);
    public const string ID_SECTION_STUDENTRECORDSTALENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSTALENT);
    public const string ID_SECTION_STUDENTRECORDSHEALTHY_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSHEALTHY);
    public const string ID_SECTION_STUDENTRECORDSWORK_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSWORK);
    public const string ID_SECTION_STUDENTRECORDSFINANCIAL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFINANCIAL);
    public const string ID_SECTION_STUDENTRECORDSFAMILY_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILY);
    public const string ID_SECTION_STUDENTRECORDSFAMILYFATHER_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER);    
    public const string ID_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL);
    public const string ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERWORK);
    public const string ID_SECTION_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER);    
    public const string ID_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL);
    public const string ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERWORK);
    public const string ID_SECTION_STUDENTRECORDSFAMILYPARENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT);    
    public const string ID_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL);
    public const string ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT);
    public const string ID_SECTION_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTWORK);
  
    public const string PAGE_MSENT_MAIN = "M-SentMain";
    public const string PAGE_PRIVACYPOLICY_MAIN = (SUBJECT_SECTION_PRIVACYPOLICY + "Main");
    public const string PAGE_PRIVACYPOLICYTERMSCONDITION_MAIN = (SUBJECT_SECTION_PRIVACYPOLICYTERMSCONDITION + "Main");
    public const string PAGE_PRIVACYPOLICYPRIVACYNOTICE_MAIN = (SUBJECT_SECTION_PRIVACYPOLICYPRIVACYNOTICE + "Main");
    public const string PAGE_PRIVACYPOLICYCONSENT_MAIN = (SUBJECT_SECTION_PRIVACYPOLICYCONSENT + "Main");
    public const string PAGE_MANUAL_MAIN = (SUBJECT_SECTION_MANUAL + "Main");
    public const string PAGE_HELPCONTACTUS_MAIN = (SUBJECT_SECTION_HELPCONTACTUS + "Main");
    public const string PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN = (SUBJECT_SECTION_HELPFILLINFORMATIONSTUDENTRECORDS + "Main");
    public const string PAGE_STUDENTRECORDSSTUDENTCV_MAIN = (SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV + "Main");
    public const string PAGE_STUDENTRECORDS_MAIN = (SUBJECT_SECTION_STUDENTRECORDS + "Main");
    public const string PAGE_STUDENTRECORDS_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDS + "AddUpdate");
    public const string PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS + "AddUpdate");
    public const string PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSPERSONAL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSADDRESS_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSADDRESS + "AddUpdate");
    public const string PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSADDRESSPERMANENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSADDRESSCURRENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATION + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY + "AddUpdate");
    public const string PAGE_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES + "AddUpdate");
    public const string PAGE_STUDENTRECORDSTALENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSTALENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSHEALTHY + "AddUpdate");
    public const string PAGE_STUDENTRECORDSWORK_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSWORK + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFINANCIAL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILY_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILY + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYFATHER_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHER + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYFATHERWORK + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHER + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYMOTHERWORK + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYPARENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT + "AddUpdate");
    public const string PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE = (SUBJECT_SECTION_STUDENTRECORDSFAMILYPARENTWORK + "AddUpdate");

    public static string _myUserManualPath = System.Configuration.ConfigurationManager.AppSettings["ePFUserManualPath"].ToString();
    public static string _myUserManualFile = System.Configuration.ConfigurationManager.AppSettings["ePFUserManualFile"].ToString();
    public static string _myURLPictureStudent = System.Configuration.ConfigurationManager.AppSettings["urlPictureStudent"].ToString();
    public static string _myHandlerPath = System.Configuration.ConfigurationManager.AppSettings["ePFHandlerPath"].ToString();
    public static string _myFormPath = System.Configuration.ConfigurationManager.AppSettings["ePFFormPath"].ToString();
    public static string _myPDFFontNormal = System.Configuration.ConfigurationManager.AppSettings["ePFPDFFontNormal"].ToString();
    public static string _myPDFFontBold = System.Configuration.ConfigurationManager.AppSettings["ePFPDFFontBold"].ToString();

    public static string[,] _menu = new string[,]
    {
        { "บันทึกข้อมูลระเบียนประวัตินักศึกษา", "Recording Student Records", SUBJECT_SECTION_STUDENTRECORDS },
        { "คู่มือ", "Manual", SUBJECT_SECTION_MANUAL },
        { "ช่วยเหลือ", "Help", SUBJECT_SECTION_HELP },
        { "นโยบายคุ้มครองข้อมูลส่วนบุคคล", "Privacy Policy", SUBJECT_SECTION_PRIVACYPOLICY }
    };    

    public static string[,] _submenu = new string[,]
    {
        { "ติดต่อสอบถาม", "Contact Us", SUBJECT_SECTION_HELPCONTACTUS },
        { "การกรอกข้อมูลระเบียนประวัตินักศึกษา", "How to Fill the Information Student Records", SUBJECT_SECTION_HELPFILLINFORMATIONSTUDENTRECORDS },
        { "วิธีการปลดบล็อค popup ของ browser ต่าง ๆ", "Allow Popup", SUBJECT_SECTION_HELPALLOWPOPUP }
    };

    public static string[,] _menuPrivacyPolicy = new string[,]
    {
        { "ข้อตกลงและเงื่อนไข", "Terms and Condition", "active", ID_SECTION_PRIVACYPOLICYTERMSCONDITION_MAIN, PAGE_PRIVACYPOLICYTERMSCONDITION_MAIN },
        { "นโยบายการรักษาความปลอดภัย", "Privacy Notice", "", ID_SECTION_PRIVACYPOLICYPRIVACYNOTICE_MAIN, PAGE_PRIVACYPOLICYPRIVACYNOTICE_MAIN },
        { "ความยินยอม", "Consent", "", ID_SECTION_PRIVACYPOLICYCONSENT_MAIN, PAGE_PRIVACYPOLICYCONSENT_MAIN }
    };

    public static string[,] _ynEverNever = new string[,]
    {
        { "N", "ไม่เคย", "Never" },
        { "Y", "เคย", "Ever" }
    };

    public static string[,] _ynHaveWithout = new string[,]
    {
        { "N", "ไม่มี", "Without" },
        { "Y", "มี", "Have" }
    };

    public static string[,] _ynYesNo = new string[,]
    {
        { "N", "ไม่", "No" },
        { "Y", "ใช่", "Yes" }
    };

    public static string[] _ranking = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

    public static Dictionary<string, object> GetInfoLogin(string _page, string _id)
    {
        Dictionary<string, object> _finServiceLoginResult = FinServiceLogin.GetFinServiceLogin(FinServiceLogin.USERTYPE_STUDENT, "e-Profile");
        Dictionary<string, object> _loginResult = new Dictionary<string, object>();
        int _systemError = Util.DBUtil.ChkSystemPermissionStudent(_finServiceLoginResult);
        int _cookieError = 0;
        int _userError = 0;
        string _personId = _finServiceLoginResult["PersonID"].ToString();
        string _studentId = _finServiceLoginResult["StudentID"].ToString();
        string _studentCode = _finServiceLoginResult["StudentCode"].ToString();
        string _fullnameEN = _finServiceLoginResult["FullnameEN"].ToString();

        //_systemError = 0;
        switch (_systemError)
        {
            case 1: 
                _cookieError = 1;
                break;
            case 2:
                _userError = 1;
                break;
            case 3:
                _userError = 2;
                break;
            case 4:
                _userError = 3;
                break;
            case 5: 
                _userError = 4;
                break;
        }
        
        _loginResult.Add("CookieError", _cookieError.ToString());
        _loginResult.Add("UserError", _userError.ToString());
        _loginResult.Add("PersonId", _personId);
        _loginResult.Add("StudentId", _studentId);
        _loginResult.Add("StudentCode", _studentCode);
        _loginResult.Add("FullnameEN", _fullnameEN);

        return _loginResult;
    }

    public static string GetCUID(string[] data)
    {
        string _randAlphaNumStr = Util.GeneratePasscode(20, 0);

        return Util.EncodeToBase64(
            (new String(Util.EncodeToBase64(_randAlphaNumStr).Reverse().ToArray())) + "." +
            (new String(_randAlphaNumStr.Reverse().ToArray())) + "." +
            (new String(Util.EncodeToBase64(String.Join(".", data)).Reverse().ToArray()))
        );
    }

    public static Dictionary<string, object> GetPage(string _page)
    {        
        Dictionary<string, object> _loginResult = GetInfoLogin(_page, "");
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _pageError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        string _signinYN = String.Empty;
        string _personId = _loginResult["PersonId"].ToString();
        string _studentId = _loginResult["StudentId"].ToString();
        string _studentCode = _loginResult["StudentCode"].ToString();
        string _cuid = String.Empty;
        StringBuilder _menuContent = new StringBuilder();
        StringBuilder _mainContent = new StringBuilder();

        _pageError = 1;
        _signinYN = String.Empty;
        _mainContent = null;

        if (!_page.Equals(PAGE_MSENT_MAIN))
        {
            if (_userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4))
                _page = (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN) || _page.Equals(PAGE_PRIVACYPOLICY_MAIN) ? _page : PAGE_STUDENTRECORDS_MAIN);
        }

        if (_page.Equals(PAGE_MSENT_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _userError = 0;
            _mainContent = null;
            _cuid = GetCUID(new string[] { _personId, _studentCode });
        }

        if (_page.Equals(PAGE_PRIVACYPOLICY_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _userError = 0;
            _mainContent = (_cookieError.Equals(0) ? ePFUI.PrivacyPolicyUI.GetSection(_loginResult, "MAIN", "", _personId) : null);
        }

        if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _userError = 0;
            _mainContent = (_cookieError.Equals(0) ? Util.GetStudentRecordsToStudentCV(_personId) : null);
        }     

        if (_page.Equals(PAGE_STUDENTRECORDS_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) ? ePFStudentRecordsUI.GetSection(_loginResult, "MAIN", "", _personId) : null);
        }
        
        if (_page.Equals(PAGE_STUDENTRECORDS_ADDUPDATE))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.GetSection(_loginResult, "ADDUPDATE", "", _personId) : null);
        }   

        _pageResult.Add("Page", _page);
        _pageResult.Add("PageError", _pageError.ToString());
        _pageResult.Add("SignInYN", _signinYN);
        _pageResult.Add("CookieError", _cookieError.ToString());
        _pageResult.Add("UserError", _userError.ToString());
        _pageResult.Add("MenuBarContent", (_pageError.Equals(0) && !_page.Equals(PAGE_MSENT_MAIN) ? ePFUI.GetMenuBar(_loginResult).ToString() : String.Empty));
        _pageResult.Add("MainContent", (_mainContent != null ? _mainContent.ToString() : String.Empty));
        _pageResult.Add("CUID", _cuid);
        
        return _pageResult;
    }        
    
    public static Dictionary<string, object> GetForm(string _form, string _id)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin(_form, _id);
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _formError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _width = 0;
        int _height = 0;
        string _signinYN = String.Empty;
        string _title = String.Empty;
        StringBuilder _content = new StringBuilder();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();    

        _formError = 1;

        if (_form.Equals(PAGE_HELPCONTACTUS_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _userError = 0;
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? ePFUI.GetFrmHelp(_form) : null);
            _width = 800;
            _height = 0;
            _title = (_submenu[0, 0] + " : " + _submenu[0, 1]);
        }

        if (_form.Equals(PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _userError = 0;
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? ePFUI.GetFrmHelp(_form) : null);
            _width = 800;
            _height = 0;
            _title = (_submenu[1, 0] + " : " + _submenu[1, 1]);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.PersonalUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSADDRESS_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.AddressUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.AddressUI.PermanentAddressUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.AddressUI.CurrentAddressUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.GetMain(_id) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.PrimarySchoolUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.JuniorHighSchoolUI.GetMain() : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.HighSchoolUI.GetMain() : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.UniversityUI.GetMain() : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.EducationUI.AdmissionScoresUI.GetMain() : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSTALENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.TalentUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.HealthyUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSWORK_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.WorkUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FinancialUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILY_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.GetMain(_id) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYFATHER_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.GetSubMain(SUBJECT_FAMILYFATHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.GetSubMain(SUBJECT_FAMILYMOTHER) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYPARENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.GetSubMain(SUBJECT_FAMILYPARENT) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.PersonalUI.GetMain(SUBJECT_FAMILYFATHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.PersonalUI.GetMain(SUBJECT_FAMILYMOTHER) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.PersonalUI.GetMain(SUBJECT_FAMILYPARENT) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.PermanentAddressUI.GetMain(SUBJECT_FAMILYFATHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.PermanentAddressUI.GetMain(SUBJECT_FAMILYMOTHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.PermanentAddressUI.GetMain(SUBJECT_FAMILYPARENT) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.CurrentAddressUI.GetMain(SUBJECT_FAMILYFATHER) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.CurrentAddressUI.GetMain(SUBJECT_FAMILYMOTHER) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.AddressUI.CurrentAddressUI.GetMain(SUBJECT_FAMILYPARENT) : null);
        }
        
        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.WorkUI.GetMain(SUBJECT_FAMILYFATHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.WorkUI.GetMain(SUBJECT_FAMILYMOTHER) : null);
        }

        if (_form.Equals(PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? ePFStudentRecordsUI.SectionAddUpdateUI.FamilyUI.WorkUI.GetMain(SUBJECT_FAMILYPARENT) : null);
        }
                        
        _formResult.Add("FormError", _formError.ToString());
        _formResult.Add("SignInYN", _signinYN);
        _formResult.Add("CookieError", _cookieError.ToString());
        _formResult.Add("UserError", _userError.ToString());
        _formResult.Add("Content", (_content != null ? _content.ToString() : String.Empty));
        _formResult.Add("Width", _width.ToString());
        _formResult.Add("Height", _height.ToString());
        _formResult.Add("Title", _title);

        return _formResult;
    }
    
    public static Dictionary<string, object> GetInfoData(string _page, Dictionary<string, object> _data)
    {
        Dictionary<string, object> _infoDataResult = new Dictionary<string, object>();
        StringBuilder _contentTemp = new StringBuilder();
        string _infoId = String.Empty;
        string _infoIcon = String.Empty;
        string _infoTitleTH = String.Empty;
        string _infoTitleEN = String.Empty;
        string _infoContent = String.Empty;
        string _infoOperatorHome = String.Empty;
        string _infoOperatorNew = String.Empty;
        string _infoOperatorEdit = String.Empty;
        string _infoOperatorDelete = String.Empty;
        string _infoOperatorSearch = String.Empty;
        string _infoOperatorReset = String.Empty;
        string _infoOperatorSave = String.Empty;
        string _infoOperatorSaveAll = String.Empty;
        string _infoOperatorApply = String.Empty;
        string _infoOperatorUndo = String.Empty;
        string _infoOperatorPrint = String.Empty;
        string _infoOperatorUpload = String.Empty;
        string _infoOperatorTransfer = String.Empty;
        string _infoOperatorExportAll = String.Empty;
        string _infoOperatorExportSelected = String.Empty;
        string _infoOperatorProfile = String.Empty;
        string _infoOperatorClose = String.Empty;
        string _infoLinkTo = String.Empty;
        string _infoLinkTo1Id = String.Empty;
        string _infoLinkTo1TH = String.Empty;
        string _infoLinkTo1EN = String.Empty;
        string _infoLinkTo1Page = String.Empty;
        string _infoLinkTo2Id = String.Empty;
        string _infoLinkTo2TH = String.Empty;
        string _infoLinkTo2EN = String.Empty;
        string _infoLinkTo2Page = String.Empty;
        string _infoLinkTo3Id = String.Empty;
        string _infoLinkTo3TH = String.Empty;
        string _infoLinkTo3EN = String.Empty;
        string _infoLinkTo3Page = String.Empty;
        string _infoImportantId = String.Empty;
        string _infoImportantRecommendTitle = String.Empty;
        string _infoImportantRecommendMsgTH = String.Empty;
        string _infoImportantRecommendMsgEN = String.Empty;
        string _infoImportantSuccessTitle = String.Empty;
        string _infoImportantSuccessMsg = String.Empty;

        if (_page.Equals(PAGE_PRIVACYPOLICY_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_PRIVACYPOLICY.ToLower());
            _infoIcon = "icon-privacypolicy";
            _infoTitleTH = _menu[3, 0];
            _infoTitleEN = _menu[3, 1];
            _infoOperatorHome = ("home-" + _page.ToLower());
            _infoOperatorProfile = ("profile-" + _page.ToLower());
        }

        if (_page.Equals(PAGE_STUDENTRECORDS_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_STUDENTRECORDS.ToLower());
            _infoIcon = "icon-profile";
            _infoTitleTH = _menu[0, 0];
            _infoTitleEN = _menu[0, 1];
            _infoOperatorProfile = ("profile-" + _page.ToLower());
            _infoLinkTo = ("linkto-" + _page.ToLower());
            _infoLinkTo1Id = "linkto-healthcareservice";
            _infoLinkTo1TH = "ดาวน์โหลดแบบฟอร์มสุขภาพ";
            _infoLinkTo1EN = "Health Care Service";
            _infoLinkTo1Page = "../HealthCareService/index.aspx";
            _infoLinkTo2Id = "linkto-uploaddocument";
            _infoLinkTo2TH = "อัพโหลดเอกสารของนักศึกษา";
            _infoLinkTo2EN = "Upload Document Student";
            _infoLinkTo2Page = "../UploadDocument/index.aspx";
            /*
            _infoLinkTo3Id = "linkto-downloadscbaccountopeningform";
            _infoLinkTo3TH = "ดาว์นโหลดแบบฟอร์มเปิดบัญชีกับ SCB";
            _infoLinkTo3EN = "Download SCB Account Opening Form";
            _infoLinkTo3Page = String.Empty;
            */
        }

        if (_page.Equals(PAGE_STUDENTRECORDS_ADDUPDATE))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_STUDENTRECORDS.ToLower());
            _infoIcon = "icon-profile";
            _infoTitleTH = _menu[0, 0];
            _infoTitleEN = _menu[0, 1];
            _infoOperatorHome = ("home-" + _page.ToLower());
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorSaveAll = ("saveall-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorProfile = ("profile-" + _page.ToLower());
            _infoLinkTo = ("linkto-" + _page.ToLower());
            _infoLinkTo1Id = "linkto-healthcareservice";
            _infoLinkTo1TH = "ดาวน์โหลดแบบฟอร์มสุขภาพ";
            _infoLinkTo1EN = "Health Care Service";
            _infoLinkTo1Page = "../HealthCareService/index.aspx";
            _infoLinkTo2Id = "linkto-uploaddocument";
            _infoLinkTo2TH = "อัพโหลดเอกสารของนักศึกษา";
            _infoLinkTo2EN = "Upload Document Student";
            _infoLinkTo2Page = "../UploadDocument/index.aspx";
            /*
            _infoLinkTo3Id = "linkto-downloadscbaccountopeningform";
            _infoLinkTo3TH = "ดาว์นโหลดแบบฟอร์มเปิดบัญชีกับ SCB";
            _infoLinkTo3EN = "Download SCB Account Opening Form";
            _infoLinkTo3Page = String.Empty;
            */
            _infoImportantId = ("important" + _page.ToLower());
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์ ข้อมูลใดที่ไม่ทราบให้ข้ามไป และกรุณาบันทึกข้อมูลในแต่ละหน้า";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all. Skip, Any information that does not know. Please save data each page.";
        }

        _infoDataResult.Add("ID", _infoId);
        _infoDataResult.Add("Icon", _infoIcon);
        _infoDataResult.Add("TitleTH", _infoTitleTH);
        _infoDataResult.Add("TitleEN",  _infoTitleEN);
        _infoDataResult.Add("Content", _infoContent);
        _infoDataResult.Add("OperatorHome", _infoOperatorHome);
        _infoDataResult.Add("OperatorNew", _infoOperatorNew);
        _infoDataResult.Add("OperatorEdit", _infoOperatorEdit);
        _infoDataResult.Add("OperatorDelete", _infoOperatorDelete);
        _infoDataResult.Add("OperatorExportAll", _infoOperatorExportAll);
        _infoDataResult.Add("OperatorExportSelected", _infoOperatorExportSelected);
        _infoDataResult.Add("OperatorSearch", _infoOperatorSearch);
        _infoDataResult.Add("OperatorReset", _infoOperatorReset);
        _infoDataResult.Add("OperatorSave", _infoOperatorSave);
        _infoDataResult.Add("OperatorSaveAll", _infoOperatorSaveAll);
        _infoDataResult.Add("OperatorApply", _infoOperatorApply);
        _infoDataResult.Add("OperatorUndo", _infoOperatorUndo);
        _infoDataResult.Add("OperatorPrint", _infoOperatorPrint);
        _infoDataResult.Add("OperatorUpload", _infoOperatorUpload);
        _infoDataResult.Add("OperatorTransfer", _infoOperatorTransfer);
        _infoDataResult.Add("OperatorProfile", _infoOperatorProfile);
        _infoDataResult.Add("OperatorClose", _infoOperatorClose);        
        _infoDataResult.Add("LinkTo", _infoLinkTo);
        _infoDataResult.Add("LinkTo1ID", _infoLinkTo1Id);
        _infoDataResult.Add("LinkTo1TH", _infoLinkTo1TH);
        _infoDataResult.Add("LinkTo1EN", _infoLinkTo1EN);
        _infoDataResult.Add("LinkTo1Page", _infoLinkTo1Page);
        _infoDataResult.Add("LinkTo2ID", _infoLinkTo2Id);
        _infoDataResult.Add("LinkTo2TH", _infoLinkTo2TH);
        _infoDataResult.Add("LinkTo2EN", _infoLinkTo2EN);
        _infoDataResult.Add("LinkTo2Page", _infoLinkTo2Page);
        _infoDataResult.Add("LinkTo3ID", _infoLinkTo3Id);
        _infoDataResult.Add("LinkTo3TH", _infoLinkTo3TH);
        _infoDataResult.Add("LinkTo3EN", _infoLinkTo3EN);
        _infoDataResult.Add("LinkTo3Page", _infoLinkTo3Page);
        _infoDataResult.Add("ImportantID", _infoImportantId);
        _infoDataResult.Add("ImportantRecommendTitle", _infoImportantRecommendTitle);
        _infoDataResult.Add("ImportantRecommendMsgTH", _infoImportantRecommendMsgTH);
        _infoDataResult.Add("ImportantRecommendMsgEN", _infoImportantRecommendMsgEN);
        _infoDataResult.Add("ImportantSuccessTitle", _infoImportantSuccessTitle);
        _infoDataResult.Add("ImportantSuccessMsg", _infoImportantSuccessMsg);

        return _infoDataResult;
    }
    
    public static int CalAge(string _dateStart, string _dateEnd)
    {
        int _age = 0;

        try
        {
            _dateStart = (_dateStart.Substring(3, 2) + "/" + _dateStart.Substring(0, 2) + "/" + _dateStart.Substring(6, 4));
            _dateEnd = (_dateEnd.Substring(3, 2) + "/" + _dateEnd.Substring(0, 2) + "/" + _dateEnd.Substring(6, 4));
            DateTime _dateA = DateTime.Parse(DateTime.Parse(_dateStart.ToString(), new CultureInfo("en-US")).ToString("MM/dd/yyyy"));
            DateTime _dateB = DateTime.Parse(DateTime.Parse(_dateEnd.ToString(), new CultureInfo("en-US")).ToString("MM/dd/yyyy"));

            _age = _dateB.Year - _dateA.Year;
        }
        catch
        {
        }

        return _age;
    }
   
    public static DataTable StringArrayToDataTable(Dictionary<string, object> _dtContent)
    {
        DataTable _dt = new DataTable();
        string _data = _dtContent["Data"].ToString();
        char _separatorRow = (char)_dtContent["SeparatorRow"];
        string[] _column = (string[])_dtContent["Column"];
        char _separatorColumn = (char)_dtContent["SeparatorColumn"];
        Type _columnType = null;

        string[] _dataRowArray;
        string[] _dataColArray;
        string[] _dateArray;
        int _i = 0;
        int _j = 0;

        if (!String.IsNullOrEmpty(_data))
        {
            for (_i = 0; _i < _column.GetLength(0); _i++)
            {
                switch (_column[_i])
                {
                    case "string":
                        _columnType = typeof(string);
                        break;
                    case "datetime":
                        _columnType = typeof(DateTime);
                        break;
                }

                _dt.Columns.Add((_i + 1).ToString(), _columnType);
            }

            _dataRowArray = _data.Split(_separatorRow);

            for (_i = 0; _i < _dataRowArray.GetLength(0); _i++)
            {
                _dataColArray = _dataRowArray[_i].Split(_separatorColumn);

                DataRow _dr = _dt.NewRow();

                for (_j = 0; _j < _column.GetLength(0); _j++)
                {
                    if (_column[_j].Equals("datetime"))
                    {
                        _dateArray = _dataColArray[_j].Split('/');
                        _dr[_j] = (_dateArray[2] + "/" + _dateArray[1] + "/" + _dateArray[0]);
                    }
                    else
                        _dr[_j] = _dataColArray[_j];
                }

                _dt.Rows.Add(_dr);
            }
        }
        else
            _dt = null;

        return _dt;
    }
    
    public static Dictionary<string, object> SetValueDataRecorded(string _page, string _id)
    {
        Dictionary<string, object> _valueDataRecordedResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        DataSet _ds = new DataSet();

        if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE))
            _ds = Util.DBUtil.GetStudentRecords(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsPersonal(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSADDRESS_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsAddress(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsEducation(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSTALENT_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsActivity(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsHealthy(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSWORK_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsWork(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsFinancial(_id);

        if (_page.Equals(PAGE_STUDENTRECORDSFAMILY_ADDUPDATE))
            _ds = Util.DBUtil.GetPersonRecordsFamily(_id);

        if (_ds.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.StudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.PersonalUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSADDRESS_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.AddressUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.EducationUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSTALENT_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.TalentUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.HealthyUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSWORK_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.WorkUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE))
                _dataRecorded = ePFStudentRecordsUtil.FinancialUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_STUDENTRECORDSFAMILY_ADDUPDATE)) {
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYFATHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYMOTHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYPARENT);

                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYFATHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYMOTHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYPARENT);

                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYFATHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYMOTHER);
                _dataRecorded = ePFStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(_dataRecorded, _ds, ePFUtil.SUBJECT_FAMILYPARENT);
            }
        }

        _ds.Dispose();

        if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSPERSONAL), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSADDRESS_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSADDRESS), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSEDUCATION), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSTALENT_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSTALENT), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSHEALTHY), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSWORK_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSWORK), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSFINANCIAL), _dataRecorded);

        if (_page.Equals(PAGE_STUDENTRECORDSFAMILY_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_STUDENTRECORDSFAMILY), _dataRecorded);

        return _valueDataRecordedResult;
    }

    public static void GetSCBAccountOpeningForm()
    {
        Dictionary<string, object> _loginResult = ePFUtil.GetInfoLogin("", "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        string _personId = _loginResult["PersonId"].ToString();

        if (_cookieError.Equals(0))
        {
            Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, _personId);
            Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS];

            ExportToPDF _e = new ExportToPDF();
            _e.ExportToPDFConnect(ePFUtil.SUBJECT_SECTION_SCBACCOUNTOPENINGFORM + ".pdf");
            _e.PDFConnectTemplate((ePFUtil._myFormPath + "/" + ePFUtil.SUBJECT_SECTION_SCBACCOUNTOPENINGFORM + ".pdf"), "pdf");
            _e.PDFAddTemplate("pdf", 1, 1);
            
            _e.FillForm(_myPDFFontBold, 14, 1, DateTime.Today.Day.ToString(), 318, 628, 37, 0);
            _e.FillForm(_myPDFFontBold, 14, 1, Util._longMonth[DateTime.Today.Month - 1, 0], 377, 628, 88, 0);
            _e.FillForm(_myPDFFontBold, 14, 1, DateTime.Today.ToString("yyyy", new CultureInfo("th-TH")), 484, 628, 47, 0);

            switch (_dataRecorded["TitleFullNameTH"].ToString())
            {
                case "นาย":
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 338, 548, 14, 0);
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 356, 548, 29, 0);
                    _dataRecorded["TitleInitialsTH"] = String.Empty;
                    break;
                case "นาง":
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 318, 548, 16, 0);
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 356, 548, 29, 0);
                    _dataRecorded["TitleInitialsTH"] = String.Empty;
                    break;
                case "นางสาว":
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 318, 548, 16, 0);
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 338, 548, 14, 0);
                    _dataRecorded["TitleInitialsTH"] = String.Empty;
                    break;
                default:
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 318, 548, 16, 0);
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 338, 548, 14, 0);
                    _e.FillForm(_myPDFFontBold, 15, 1, "/", 356, 548, 29, 0);
                    break;
            }
            _e.FillForm(_myPDFFontBold, 14, 1, (Util.GetBlank(_dataRecorded["FirstName"].ToString(), "") + (!String.IsNullOrEmpty(_dataRecorded["MiddleName"].ToString()) ? (" " + Util.GetBlank(_dataRecorded["MiddleName"].ToString(), "")) : String.Empty)), 387, 549, 145, 0);
            _e.FillForm(_myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["LastName"].ToString(), ""), 121, 530, 93, 0);
            _e.FillForm(_myPDFFontBold, 14, 1, (!_dataRecorded["StudentCode"].Equals("XXXXXXX") ? Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "") : String.Empty), 270, 530, 68, 0);
            
            _e.ExportToPdfDisconnect();
        }
    }
}