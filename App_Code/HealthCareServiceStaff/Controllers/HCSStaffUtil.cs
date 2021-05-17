/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๐๗/๒๕๕๘>
Modify date : <๑๘/๐๓/๒๕๖๓>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไป>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class HCSStaffUtil
{
    public const string SUBJECT_SECTION_MEANINGOFADMISSIONTYPE = "MeaningOfAdmissionType";
    public const string SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS = "MeaningOfStudentStatus";
    public const string SUBJECT_SECTION_MEANINGOFHEALTHCARESERVICEFORM = "MeaningOfHealthCareServiceForm";
    public const string SUBJECT_SECTION_VIEWCHART = "ViewChart";
    public const string SUBJECT_SECTION_VIEWTABLE = "ViewTable";
    public const string SUBJECT_SECTION_HOSPITALOFHEALTHCARESERVICE = "HospitalOfHealthCareService";
    public const string SUBJECT_SECTION_REGISTRATIONFORM = "RegistrationForm";
    public const string SUBJECT_SECTION_AGENCYREGISTERED = "AgencyRegistered";
    public const string SUBJECT_SECTION_MASTERDATA = "MasterData";
    public const string SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE = (SUBJECT_SECTION_MASTERDATA + SUBJECT_SECTION_HOSPITALOFHEALTHCARESERVICE);
    public const string SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM = (SUBJECT_SECTION_MASTERDATA + SUBJECT_SECTION_REGISTRATIONFORM);
    public const string SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED = (SUBJECT_SECTION_MASTERDATA + SUBJECT_SECTION_AGENCYREGISTERED);
    public const string SUBJECT_SECTION_STUDENTRECORDS = "StudentRecords";
    public const string SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV = (SUBJECT_SECTION_STUDENTRECORDS + "StudentCV");
    public const string SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM = "DownloadRegistrationForm";
    public const string SUBJECT_SECTION_OURSERVICES = "OurServices";
    public const string SUBJECT_SECTION_HEALTHINFORMATION = "HealthInformation";
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM = "StatisticsDownloadHealthCareServiceForm";
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1 = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + "Level1");
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2 = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + "Level2");
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + SUBJECT_SECTION_VIEWCHART);    
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + SUBJECT_SECTION_VIEWTABLE);
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1 + SUBJECT_SECTION_VIEWTABLE);
    public const string SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE = (SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2 + SUBJECT_SECTION_VIEWTABLE);
    public const string SUBJECT_SECTION_TERMSERVICEHCSCONSENT = "TermServiceHCSConsent";
    public const string SUBJECT_SECTION_TERMSERVICEHCSCONSENTSELECTHOSPITAL = (SUBJECT_SECTION_TERMSERVICEHCSCONSENT + "SelectHospital");
    public const string SUBJECT_SECTION_TERMSERVICEHCSCONSENTREGISTRATION = "TermServiceHCSConsentRegistration";    
    public const string SUBJECT_SECTION_TERMSERVICEHCSCONSENTOOCA = "TermServiceHCSConsentOOCA";
    public const string SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_HEALTHINFORMATION);
    public const string SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM);
    public const string SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART);
    public const string SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE);
    public const string SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE);
    public const string SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE);
    public const string SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENT = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_TERMSERVICEHCSCONSENT);
    public const string SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_TERMSERVICEHCSCONSENTSELECTHOSPITAL);
    public const string SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_TERMSERVICEHCSCONSENTREGISTRATION);    
    public const string SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA = (SUBJECT_SECTION_OURSERVICES + SUBJECT_SECTION_TERMSERVICEHCSCONSENTOOCA);

    public const string ID_SECTION_MEANINGOFADMISSIONTYPE_MAIN = ("Main-" + SUBJECT_SECTION_MEANINGOFADMISSIONTYPE);
    public const string ID_SECTION_MEANINGOFSTUDENTSTATUS_MAIN = ("Main-" + SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS);
    public const string ID_SECTION_MEANINGOFHEALTHCARESERVICEFORM_MAIN = ("Main-" + SUBJECT_SECTION_MEANINGOFHEALTHCARESERVICEFORM);
    public const string ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN = ("Main-" + SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE);
    public const string ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_SEARCH = ("Search-" + SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE);
    public const string ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW = ("New-" + SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE);
    public const string ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT = ("Edit-" + SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE);
    public const string ID_SECTION_MASTERDATAREGISTRATIONFORM_MAIN = ("Main-" + SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM);
    public const string ID_SECTION_MASTERDATAREGISTRATIONFORM_SEARCH = ("Search-" + SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM);
    public const string ID_SECTION_MASTERDATAREGISTRATIONFORM_NEW = ("New-" + SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM);
    public const string ID_SECTION_MASTERDATAREGISTRATIONFORM_EDIT = ("Edit-" + SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM);
    public const string ID_SECTION_MASTERDATAAGENCYREGISTERED_MAIN = ("Main-" + SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED);
    public const string ID_SECTION_MASTERDATAAGENCYREGISTERED_SEARCH = ("Search-" + SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED);    
    public const string ID_SECTION_MASTERDATAAGENCYREGISTERED_NEW = ("New-" + SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED);
    public const string ID_SECTION_MASTERDATAAGENCYREGISTERED_EDIT = ("Edit-" + SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED);
    public const string ID_SECTION_DOWNLOADREGISTRATIONFORM_MAIN = ("Main-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM);
    public const string ID_SECTION_DOWNLOADREGISTRATIONFORM_SEARCH = ("Search-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM);
    public const string ID_SECTION_DOWNLOADREGISTRATIONFORM_PROGRESS = ("Progress-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM);
    public const string ID_SECTION_OURSERVICESHEALTHINFORMATION_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION);
    public const string ID_SECTION_OURSERVICESHEALTHINFORMATION_SEARCH = ("Search-" + SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION);
    public const string ID_SECTION_OURSERVICESHEALTHINFORMATION_PROGRESS = ("Progress-" + SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_SEARCH = ("Search-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS = ("Progress-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE);
    public const string ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS = ("Progress-" + SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE);
    public const string ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_MAIN = ("Main-" + SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENT);
    public const string ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_SEARCH = ("Search-" + SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENT);
    public const string ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL_DIALOG = ("Dialog-" + SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL);
    public const string ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_PROGRESS = ("Progress-" + SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENT);

    public const string PAGE_MAIN = "Main";    
    public const string PAGE_MEANINGOFADMISSIONTYPE_MAIN = (SUBJECT_SECTION_MEANINGOFADMISSIONTYPE + "Main");
    public const string PAGE_MEANINGOFSTUDENTSTATUS_MAIN = (SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS + "Main");
    public const string PAGE_MEANINGOFHEALTHCARESERVICEFORM_MAIN = (SUBJECT_SECTION_MEANINGOFHEALTHCARESERVICEFORM + "Main");
    public const string PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN = (SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE + "Main");
    public const string PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW = (SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE + "New");
    public const string PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT = (SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE + "Edit");
    public const string PAGE_MASTERDATAREGISTRATIONFORM_MAIN = (SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM + "Main");
    public const string PAGE_MASTERDATAREGISTRATIONFORM_NEW = (SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM + "New");
    public const string PAGE_MASTERDATAREGISTRATIONFORM_EDIT = (SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM + "Edit");
    public const string PAGE_MASTERDATAAGENCYREGISTERED_MAIN = (SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED + "Main");
    public const string PAGE_MASTERDATAAGENCYREGISTERED_NEW = (SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED + "New");
    public const string PAGE_MASTERDATAAGENCYREGISTERED_EDIT = (SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED + "Edit");
    public const string PAGE_STUDENTRECORDSSTUDENTCV_MAIN = (SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV + "Main");
    public const string PAGE_DOWNLOADREGISTRATIONFORM_MAIN = (SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM + "Main");
    public const string PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS = (SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM + "Progress");
    public const string PAGE_OURSERVICESHEALTHINFORMATION_MAIN = (SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION + "Main");
    public const string PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS = (SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION + "Progress");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM + "Main");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART + "Main");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE + "Main");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE + "Main");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE + "Progress");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE + "Main");
    public const string PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS = (SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE + "Progress");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL_DIALOG = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL + "Dialog");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION + "Main");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_EDIT = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION + "Edit");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION + "Progress");    
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA + "Main");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_EDIT = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA + "Edit");
    public const string PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS = (SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA + "Progress");

    public static string _myURLPictureStudent = System.Configuration.ConfigurationManager.AppSettings["urlPictureStudent"].ToString();
    public static string _myParamSearchCookieName = System.Configuration.ConfigurationManager.AppSettings["hcsStaffParamSearchCookieName"].ToString();
    public static string _myHandlerPath = System.Configuration.ConfigurationManager.AppSettings["hcsStaffHandlerPath"].ToString();    
    public static string _myRowPerPageDefault = System.Configuration.ConfigurationManager.AppSettings["hcsStaffRowPerPageDefault"].ToString();
    public static string _myRowPerPage = System.Configuration.ConfigurationManager.AppSettings["hcsStaffRowPerPage"].ToString();
    public static string _myFileDownloadPath = System.Configuration.ConfigurationManager.AppSettings["hcsStaffFileDownloadPath"].ToString();
    public static string _myPDFFormTemplate = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFormTemplate"].ToString();
    public static string _myPDFFontNormal = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontNormal"].ToString();
    public static string _myPDFFontBold = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontBold"].ToString();
    public static string _myPDFFontBarcode = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontBarcode"].ToString();    
   
    public static string[,] _menu = new string[,]
    {
        { "จัดการข้อมูลหลัก", "Master Data", SUBJECT_SECTION_MASTERDATA },
        { "ขึ้นทะเบียนสิทธิรักษาพยาบาล", "Download Health Care Service Form", SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM },
        { "บริการอื่น", "Our Services", SUBJECT_SECTION_OURSERVICES }
    };

    public static string[,] _submenu = new string[,]
    {
        { "ข้อมูลหน่วยบริการสุขภาพ", "Hospital of Health Care Service", SUBJECT_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE },
        { "ข้อมูลแบบฟอร์มบริการสุขภาพ", "Health Care Service Form", SUBJECT_SECTION_MASTERDATAREGISTRATIONFORM },
        { "ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล", "Agency Registered", SUBJECT_SECTION_MASTERDATAAGENCYREGISTERED },
        { "ประวัติสุขภาพนักศึกษา", "Health Information", SUBJECT_SECTION_OURSERVICESHEALTHINFORMATION },
        { "สถิติการดาวน์โหลดแบบฟอร์มบริการสุขภาพ", "Statistics Download Health Care Service Form", SUBJECT_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM },
        { "จำนวนการดาวน์โหลดแบบฟอร์มบริการสุขภาพ", "Number of Times Download Health Care Service Form", "" },
        { "จำนวนนักศึกษาที่ดาวน์โหลดแบบฟอร์มบริการสุขภาพ", "Number of Student Download Health Care Service Form", "" },
        { "การแสดงความยินยอมให้มหาวิทยาลัยมหิดลขึ้นทะเบียนสิทธิหลักประกันสุขภาพแห่งชาติ", "Consent Provides Mahidol University to Registration for Health Care Service", SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION },
        { "การแสดงความยินยอมให้ข้อมูลสำหรับการรับบริการปรึกษาออนไลน์สำหรับนักศึกษา", "Consent Provides Information For Receiving Online Counseling Services For Mahidol University’ Students", SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA },
        { "ข้อมูลนักศึกษาที่ยินยอม / ไม่ยินยอมให้มหาวิทยาลัยมหิดลขึ้นทะเบียนสิทธิหลักประกันสุขภาพแห่งชาติ", "Student Records Information", SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION },
        { "ข้อมูลนักศึกษาที่ยินยอม / ไม่ยินยอมให้ข้อมูลสำหรับการรับบริการปรึกษาออนไลน์", "Student Records Information", SUBJECT_SECTION_OURSERVICESTERMSERVICEHCSCONSENTOOCA }
    };

    public static string[,] _activeStatus = new string[,]
    {
        { "N", "ไม่ใช้งาน", "Inactive" },
        { "Y", "ใช้งาน", "Active" }
    };

    public static string[,] _cancelledStatus = new string[,]
    {
        { "N", "ใช้งาน", "Active" },
        { "Y", "ยกเลิก", "Cancel" }
    };

    public static string[,] _downloadStatus = new string[,]
    {
        { "N", "ยังไม่เคยดาว์นโหลด", "Never Download" },
        { "Y", "เคยดาว์นโหลดแล้ว", "Ever Download" }
    };

    public static string[,] _hcsJoinStatus = new string[,]
    {
        { "N", "ไม่มีสิทธิขึ้นทะเบียนสิทธิรักษาพยาบาล", "Have No Right" },
        { "Y", "มีสิทธิขึ้นทะเบียนสิทธิรักษาพยาบาล", "Have the Right" }
    };

    public static string[,] _consentStatus = new string[,]
    {
        { "Y", "ยินยอม", "Agree" },
        { "N", "ไม่ยินยอม", "Disagree" },
        { "W", "ไม่มีความเห็น", "No Comment" }
    };

    public static string[] _sortExpression = new string[]
    {
        "Ascending",
        "Descending"
    };

    public static string[] _selectOption = new string[]
    {
        "All",
        "Selected"
    };

    public static string[,] _viewsDisplay = new string[,]
    {
        { "แผนภูมิ", "Chart", "active", SUBJECT_SECTION_VIEWCHART },
        { "ตาราง", "Table", "", SUBJECT_SECTION_VIEWTABLE }
    };

    public static Dictionary<string, object> GetInfoLogin(string _page, string _id)
    {
        Dictionary<string, object> _finServiceLoginResult = FinServiceLogin.GetFinServiceLogin(FinServiceLogin.USERTYPE_STAFF, "HealthCareService");
        Dictionary<string, object> _loginResult = new Dictionary<string, object>();
        int _systemError = Util.DBUtil.ChkSystemPermissionStaff(_finServiceLoginResult);
        int _cookieError = 0;
        int _userError = 0;
        int _studentError = 0;
        string _username = _finServiceLoginResult["Username"].ToString();
        string _fullnameEN = _finServiceLoginResult["FullnameEN"].ToString();
        string _fullnameTH = _finServiceLoginResult["FullnameTH"].ToString();
        string _department = _finServiceLoginResult["DepID"].ToString();
        string _userlevel = _finServiceLoginResult["Userlevel"].ToString();
        string _systemGroup = _finServiceLoginResult["SystemGroup"].ToString();
        string _faculty = _finServiceLoginResult["FacultyId"].ToString();
        string _program = _finServiceLoginResult["ProgramId"].ToString();

        if (_systemError.Equals(0))
            _systemError = (ChkUserPermission(_finServiceLoginResult, _page).Equals(true) ? 0 : 2);

        if (_systemError.Equals(0)) {
            if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
                _systemError = (!String.IsNullOrEmpty(_id) ? (HCSStaffDB.GetHCSHospital(_id).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);

            if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
                _systemError = (!String.IsNullOrEmpty(_id) ? (HCSStaffDB.GetHCSRegistrationForm(_id).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);

            if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
                _systemError = (!String.IsNullOrEmpty(_id) ? (HCSStaffDB.GetHCSAgencyRegistered(_id).Tables[0].Rows.Count > 0 ? 0 : 4) : 4);

            if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_EDIT))
                _systemError = (!String.IsNullOrEmpty(_id) ? (Util.DBUtil.ChkUserStudentWithAuthenStaff(_username, _userlevel, _systemGroup, _id).Equals(0) ? 0 : 3) : 3);

            if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_EDIT))
                _systemError = (!String.IsNullOrEmpty(_id) ? (Util.DBUtil.ChkUserStudentWithAuthenStaff(_username, _userlevel, _systemGroup, _id).Equals(0) ? 0 : 3) : 3);

            if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN))
                _systemError = (!String.IsNullOrEmpty(_id) ? (Util.DBUtil.ChkUserStudentWithAuthenStaff(_username, _userlevel, _systemGroup, _id).Equals(0) ? 0 : 3) : 3);
        }

        switch (_systemError)
        {
            case 1:
                _cookieError = 1;
                break;
            case 2:
                _userError = 1;
                break;
            case 3:
                _studentError = 1;
                break;
            case 4:
                _userError = 3;
                break;
        }

        _loginResult.Add("CookieError", _cookieError.ToString());
        _loginResult.Add("UserError", _userError.ToString());
        _loginResult.Add("StudentError", _studentError.ToString());
        _loginResult.Add("Username", _username);
        _loginResult.Add("FullnameEN", _fullnameEN);
        _loginResult.Add("FullnameTH", _fullnameTH);
        _loginResult.Add("Department", _department);
        _loginResult.Add("Userlevel", _userlevel);
        _loginResult.Add("SystemGroup", _systemGroup);
        _loginResult.Add("Faculty", _faculty);
        _loginResult.Add("Program", _program);

        return _loginResult;
    }

    public static bool ChkUserPermission(Dictionary<string, object> _finServiceLogin, string _page)
    {
        string _userlevel = _finServiceLogin["Userlevel"].ToString();
        string _faculty = _finServiceLogin["FacultyId"].ToString();        
        bool _access = false;
               
        switch (_page)
        {
            case PAGE_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_MEANINGOFADMISSIONTYPE_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_MEANINGOFSTUDENTSTATUS_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_MEANINGOFHEALTHCARESERVICEFORM_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAREGISTRATIONFORM_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAREGISTRATIONFORM_NEW:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAREGISTRATIONFORM_EDIT:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAAGENCYREGISTERED_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAAGENCYREGISTERED_NEW:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_MASTERDATAAGENCYREGISTERED_EDIT:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_STUDENTRECORDSSTUDENTCV_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_DOWNLOADREGISTRATIONFORM_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESHEALTHINFORMATION_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS:
                _access = (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER) ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL_DIALOG:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_EDIT:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_EDIT:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
            case PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS:
                _access = ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _faculty.Equals("MU-01") ? true : false);
                break;
        }

        return _access;
    } 

    public static Dictionary<string, object> GetPage(string _page, string _id)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin(_page, _id);
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _pageError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());        
        string _signinYN = String.Empty;
        string _action = String.Empty;
        string _userlevel = _loginResult["Userlevel"].ToString();
        StringBuilder _menuContent = new StringBuilder();
        StringBuilder _mainContent = new StringBuilder();
        StringBuilder _searchContent = new StringBuilder();

        _pageError = 1;
        _signinYN = String.Empty;
        _mainContent = null;
        _searchContent = null;

        if (_page.Equals(PAGE_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
        }

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.HospitalOfHealthCareServiceUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.HospitalOfHealthCareServiceUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.HospitalOfHealthCareServiceUI.GetSection(_loginResult, "NEW", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.HospitalOfHealthCareServiceUI.GetSection(_loginResult, "EDIT", "", _id) : null);
        }
        
        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.RegistrationFormUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.RegistrationFormUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_NEW))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.RegistrationFormUI.GetSection(_loginResult, "NEW", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.RegistrationFormUI.GetSection(_loginResult, "EDIT", "", _id) : null);
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.AgencyRegisteredUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.AgencyRegisteredUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_NEW))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.AgencyRegisteredUI.GetSection(_loginResult, "NEW", "", "") : null);
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffMasterDataUI.AgencyRegisteredUI.GetSection(_loginResult, "EDIT", "", _id) : null);
        }

        if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _userError = (_userError.Equals(0) ? (_studentError.Equals(0) ? _studentError : 2) : _userError);
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? Util.GetStudentRecordsToStudentCV(_id) : null);
        }

        if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffDownloadRegistrationFormUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffDownloadRegistrationFormUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_OURSERVICESHEALTHINFORMATION_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.HealthInformationUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.HealthInformationUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.GetSection(_loginResult, "MAIN", "", "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.GetSection(_loginResult, "SEARCH", "", "") : null);
        }

        if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN) ||
            _page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN))
        {
            string _sectionAction = String.Empty;

            if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
                _sectionAction = SUBJECT_SECTION_TERMSERVICEHCSCONSENTREGISTRATION;

            if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN))
                _sectionAction = SUBJECT_SECTION_TERMSERVICEHCSCONSENTOOCA;

            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.TermServiceConsentUI.GetSection(_loginResult, "MAIN", _sectionAction, "") : null);
            _searchContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.TermServiceConsentUI.GetSection(_loginResult, "SEARCH", _sectionAction, "") : null);
        }

        _pageResult.Add("Page", _page);
        _pageResult.Add("PageError", _pageError.ToString());
        _pageResult.Add("SignInYN", _signinYN);
        _pageResult.Add("CookieError", _cookieError.ToString());
        _pageResult.Add("UserError", _userError.ToString());
        _pageResult.Add("MenuBarContent", (_pageError.Equals(0) ? HCSStaffUI.GetMenuBar(_loginResult, _page).ToString() : String.Empty));
        _pageResult.Add("MainContent", (_mainContent != null ? _mainContent.ToString() : String.Empty));
        _pageResult.Add("SearchContent", (_searchContent != null ? _searchContent.ToString() : String.Empty));

        return _pageResult;
    }
    
    public static Dictionary<string, object> GetForm(string _form, string _id)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin(_form, _id);
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _formError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());
        int _width = 0;
        int _height = 0;
        string _signinYN = String.Empty;
        string _title = String.Empty;
        StringBuilder _content = new StringBuilder();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formError = 1;

        if (_form.Equals(PAGE_MEANINGOFADMISSIONTYPE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffUI.GetFrmMeaningOfAdmissionType() : null);
            _width = 800;
            _height = 0;
            _title = "ความหมายของระบบการสอบเข้า : Meaning of Admission Type";
        }

        if (_form.Equals(PAGE_MEANINGOFSTUDENTSTATUS_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSStaffUI.GetFrmMeaningOfStudentStatus() : null);
            _width = 800;
            _height = 0;
            _title = "ความหมายของสถานภาพการเป็นนักศึกษา : Meaning of Student Status";
        }

        if (_form.Equals(PAGE_MEANINGOFHEALTHCARESERVICEFORM_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffUI.GetFrmMeaningOfHealthCareServiceForm() : null);
            _width = 800;
            _height = 0;
            _title = "แบบฟอร์มบริการสุขภาพ : Health Care Service Form";
        }

        if (_form.Equals(PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffDownloadRegistrationFormUI.GetSection(_loginResult, "PROGRESSDOWNLOAD", "", "") : null);
            _width = 855;
            _height = 0;
            _title = "ดาว์นโหลดแบบฟอร์มบริการสุขภาพ : Download Health Care Service Form";
        }

        if (_form.Equals(PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.HealthInformationUI.GetSection(_loginResult, "PROGRESSEXPORT", "", "") : null);
            _width = 855;
            _height = 0;
            _title = ("ส่งออก" + _submenu[3, 0] + " : Export " + _submenu[3, 1]);
        }

        if (_form.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewChartUI.GetSection(_loginResult, "MAIN", "", "") : null);
        }
        
        if (_form.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewTableUI.GetSection(_loginResult, "MAIN", "", "") : null);
        }

        if (_form.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewTableUI.GetSection(_loginResult, "LEVEL1PROGRESSEXPORT", "", "") : null);
            _width = 855;
            _height = 0;
            _title = ("ส่งออก" + _submenu[4, 0] + " : Export " + _submenu[4, 1]);
        }

        if (_form.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewTableUI.GetSection(_loginResult, "LEVEL2PROGRESSEXPORT", "", "") : null);
            _width = 855;
            _height = 0;
            _title = ("ส่งออก" + _submenu[4, 0] + " : Export " + _submenu[4, 1]);
        }

        if (_form.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
            _form.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
        {            
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.TermServiceConsentUI.GetSection(_loginResult, "PROGRESSEXPORT", "", "") : null);
            _width = 855;
            _height = 0;

            if (_form.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
                _title = ("ส่งออก" + _submenu[7, 0]);

            if (_form.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                _title = ("ส่งออก" + _submenu[8, 0]);
        }

        if (_form.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL_DIALOG))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSStaffOurServicesUI.TermServiceConsentUI.GetSection(_loginResult, "DIALOG", SUBJECT_SECTION_TERMSERVICEHCSCONSENTSELECTHOSPITAL, "") : null);
            _width = 500;
            _height = 0;
            _title = "เลือกสถานพยาบาล : Please Select Hospital of Health Care Service";
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
        string _infoOperatorApply = String.Empty;
        string _infoOperatorUndo = String.Empty;
        string _infoOperatorPrint = String.Empty;
        string _infoOperatorUpload = String.Empty;
        string _infoOperatorTransfer = String.Empty;
        string _infoOperatorExportAll = String.Empty;
        string _infoOperatorExportSelected = String.Empty;
        string _infoOperatorClose = String.Empty;
        string _infoImportantId = String.Empty;
        string _infoImportantRecommendTitle = String.Empty;
        string _infoImportantRecommendMsgTH = String.Empty;
        string _infoImportantRecommendMsgEN = String.Empty;
        string _infoImportantSuccessTitle = String.Empty;
        string _infoImportantSuccessMsg = String.Empty;

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[0, 0]);
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[0, 1]);
            _infoOperatorNew = ("new-" + _page.ToLower());
        }

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[0, 0] + " [ เพิ่ม ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[0, 1] + " [ New ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = (_page.ToLower() + "-important");
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[0, 0] + " [ แก้ไข ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[0, 1] + " [ Edit ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = (_page.ToLower() + "-important");
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[1, 0]);
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[1, 1]);
            _infoOperatorNew = ("new-" + _page.ToLower());
        }

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_NEW))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[1, 0] + " [ เพิ่ม ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[1, 1] + " [ New ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = (_page.ToLower() + "-important");
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[1, 0] + " [ แก้ไข ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[1, 1] + " [ Edit ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = (_page.ToLower() + "-important");
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[2, 0]);
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[2, 1]);
            _infoOperatorNew = ("new-" + _page.ToLower());
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_NEW))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[2, 0] + " [ เพิ่ม ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[2, 1] + " [ New ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = (_page.ToLower() + "-important");
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk ( <div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_MASTERDATA.ToLower());
            _infoIcon = "icon-storage";
            _infoTitleTH = (_menu[0, 0] + " - " + _submenu[2, 0] + " [ แก้ไข ]");
            _infoTitleEN = (_menu[0, 1] + " - " + _submenu[2, 1] + " [ Edit ]");
            _infoOperatorSave = ("save-" + _page.ToLower());
            _infoOperatorUndo = ("undo-" + _page.ToLower());
            _infoOperatorClose = ("close-" + _page.ToLower());
            _infoImportantId = ("important-" + _page.ToLower());
            _infoImportantRecommendMsgTH = "รายการที่มีเครื่องหมาย (<div class='icon-fieldmark'></div>) จำเป็นต้องกรอก กรอกข้อมูลให้ครบถ้วนและสมบูรณ์";
            _infoImportantRecommendMsgEN = "Fields marked with an asterisk (<div class='icon-fieldmark'></div>) are required. Fill the information complete all.";
        }

        if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM.ToLower());
            _infoIcon = "icon-profile";
            _infoTitleTH = _menu[1, 0];
            _infoTitleEN = _menu[1, 1];
        }

        if (_page.Equals(PAGE_OURSERVICESHEALTHINFORMATION_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_OURSERVICES.ToLower());
            _infoIcon = "icon-service";
            _infoTitleTH = (_menu[2, 0] + " - " + _submenu[3, 0]);
            _infoTitleEN = (_menu[2, 1] + " - " + _submenu[3, 1]);
        }

        if (_page.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_OURSERVICES.ToLower());
            _infoIcon = "icon-service";
            _infoTitleTH = (_menu[2, 0] + " - " + _submenu[4, 0]);
            _infoTitleEN = (_menu[2, 1] + " - " + _submenu[4, 1]);
        }

        if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_OURSERVICES.ToLower());
            _infoIcon = "icon-service";
            _infoTitleTH = (_menu[2, 0] + " - " + _submenu[7, 0]);
            _infoTitleEN = (_menu[2, 1] + " - " + _submenu[7, 1]);
        }

        if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_OURSERVICES.ToLower());
            _infoIcon = "icon-service";
            _infoTitleTH = (_menu[2, 0] + " - " + _submenu[8, 0]);
            _infoTitleEN = (_menu[2, 1] + " - " + _submenu[8, 1]);
        }

        _infoDataResult.Add("ID", _infoId);
        _infoDataResult.Add("Icon", _infoIcon);
        _infoDataResult.Add("TitleTH", _infoTitleTH);
        _infoDataResult.Add("TitleEN", _infoTitleEN);
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
        _infoDataResult.Add("OperatorApply", _infoOperatorApply);
        _infoDataResult.Add("OperatorUndo", _infoOperatorUndo);
        _infoDataResult.Add("OperatorPrint", _infoOperatorPrint);
        _infoDataResult.Add("OperatorUpload", _infoOperatorUpload);
        _infoDataResult.Add("OperatorTransfer", _infoOperatorTransfer);
        _infoDataResult.Add("OperatorClose", _infoOperatorClose);
        _infoDataResult.Add("ImportantID", _infoImportantId);
        _infoDataResult.Add("ImportantRecommendTitle", _infoImportantRecommendTitle);
        _infoDataResult.Add("ImportantRecommendMsgTH", _infoImportantRecommendMsgTH);
        _infoDataResult.Add("ImportantRecommendMsgEN", _infoImportantRecommendMsgEN);
        _infoDataResult.Add("ImportantSuccessTitle", _infoImportantSuccessTitle);
        _infoDataResult.Add("ImportantSuccessMsg", _infoImportantSuccessMsg);

        return _infoDataResult;
    }
    
    public static Dictionary<string, object> SetValueSearch(string _page)
    {        
        Dictionary<string, object> _valueSearchResult = new Dictionary<string, object>();
        string _keyword = String.Empty;
        string _degreeLevel = String.Empty;
        string _faculty = String.Empty;
        string _program = String.Empty;
        string _yearEntry = String.Empty;
        string _entranceType = String.Empty;
        string _studentStatus = String.Empty;
        string _cancelledStatus = String.Empty;
        string _forPublicServant = String.Empty;                        
        string _hospital = String.Empty;
        string _hcsJoin = String.Empty;
        string _registrationForm = String.Empty;                        
        string _downloadStatus = String.Empty;
        string _termServiceType = String.Empty;
        string _consentStatus = String.Empty;
        string _termServiceNote = String.Empty;
        string _consentDateStart = String.Empty;
        string _consentDateEnd = String.Empty;        
        string _sortOrderBy = String.Empty;
        string _sortExpression = String.Empty;
        int _currentPage = 1;
        int _startRow = 1;
        int _endRow = int.Parse(_myRowPerPageDefault);
        int _rowPerPage = int.Parse(_myRowPerPageDefault);
        int _cookieError = Util.ChkCookie(_myParamSearchCookieName);

        if (_cookieError.Equals(0))
        {
            HttpCookie _objCookie = Util.GetCookie(_myParamSearchCookieName);

            if (_objCookie["Command"].Equals(_page))
            {
                _keyword = (_objCookie["Keyword"] != null ? _objCookie["Keyword"] : _keyword);
                _degreeLevel = (_objCookie["DegreeLevel"] != null ? _objCookie["DegreeLevel"] : _degreeLevel);
                _faculty = (_objCookie["Faculty"] != null ? _objCookie["Faculty"] : _faculty);
                _program = (_objCookie["Program"] != null ? _objCookie["Program"] : _program);
                _yearEntry = (_objCookie["YearEntry"] != null ? _objCookie["YearEntry"] : _yearEntry);                
                _entranceType = (_objCookie["EntranceType"] != null ? _objCookie["EntranceType"] : _entranceType);
                _studentStatus = (_objCookie["StudentStatus"] != null ? _objCookie["StudentStatus"] : _studentStatus);
                _cancelledStatus = (_objCookie["CancelledStatus"] != null ? _objCookie["CancelledStatus"] : _cancelledStatus);
                _forPublicServant = (_objCookie["ForPublicServant"] != null ? _objCookie["ForPublicServant"] : _forPublicServant);                                
                _hospital = (_objCookie["Hospital"] != null ? _objCookie["Hospital"] : _hospital);
                _hcsJoin = (_objCookie["HCSJoin"] != null ? _objCookie["HCSJoin"] : _hcsJoin);                                
                _registrationForm = (_objCookie["RegistrationForm"] != null ? _objCookie["RegistrationForm"] : _registrationForm);                                
                _downloadStatus = (_objCookie["DownloadStatus"] != null ? _objCookie["DownloadStatus"] : _downloadStatus);
                _termServiceType = (_objCookie["TermServiceType"] != null ? _objCookie["TermServiceType"] : _termServiceType);
                _consentStatus = (_objCookie["ConsentStatus"] != null ? _objCookie["ConsentStatus"] : _consentStatus);
                _termServiceNote = (_objCookie["TermServiceNote"] != null ? _objCookie["TermServiceNote"] : _termServiceNote);
                _consentDateStart = (_objCookie["ConsentDateStart"] != null ? _objCookie["ConsentDateStart"] : _consentDateStart);
                _consentDateEnd = (_objCookie["ConsentDateEnd"] != null ? _objCookie["ConsentDateEnd"] : _consentDateEnd);                
                _sortOrderBy = (_objCookie["SortOrderBy"] != null ? _objCookie["SortOrderBy"] : _sortOrderBy);
                _sortExpression = (_objCookie["SortExpression"] != null ? _objCookie["SortExpression"] : _sortExpression);
                _currentPage = (_objCookie["CurrentPage"] != null ? int.Parse(_objCookie["CurrentPage"]) : _currentPage);
                _startRow = (_objCookie["StartRow"] != null ? int.Parse(_objCookie["StartRow"]) : _startRow);
                _endRow = (_objCookie["EndRow"] != null ? int.Parse(_objCookie["EndRow"]) : _endRow);
                _rowPerPage = (_objCookie["RowPerPage"] != null ? int.Parse(_objCookie["RowPerPage"]) : _rowPerPage);
            }
        }

        _valueSearchResult.Add("Keyword", _keyword);
        _valueSearchResult.Add("DegreeLevel", _degreeLevel);
        _valueSearchResult.Add("Faculty", _faculty);
        _valueSearchResult.Add("Program", _program);
        _valueSearchResult.Add("YearEntry", _yearEntry);
        _valueSearchResult.Add("EntranceType", _entranceType);
        _valueSearchResult.Add("StudentStatus", _studentStatus);
        _valueSearchResult.Add("CancelledStatus", _cancelledStatus);  
        _valueSearchResult.Add("ForPublicServant", _forPublicServant);
        _valueSearchResult.Add("Hospital", _hospital);
        _valueSearchResult.Add("HCSJoin", _hcsJoin);
        _valueSearchResult.Add("RegistrationForm", _registrationForm);
        _valueSearchResult.Add("DownloadStatus", _downloadStatus);
        _valueSearchResult.Add("TermServiceType", _termServiceType);
        _valueSearchResult.Add("ConsentStatus", _consentStatus);
        _valueSearchResult.Add("TermServiceNote", _termServiceNote);
        _valueSearchResult.Add("ConsentDateStart", _consentDateStart);
        _valueSearchResult.Add("ConsentDateEnd", _consentDateEnd);        
        _valueSearchResult.Add("SortOrderBy", _sortOrderBy);
        _valueSearchResult.Add("SortExpression", _sortExpression);
        _valueSearchResult.Add("CurrentPage", _currentPage);
        _valueSearchResult.Add("StartRow", _startRow);
        _valueSearchResult.Add("EndRow", _endRow);
        _valueSearchResult.Add("RowPerPage", _rowPerPage);

        return _valueSearchResult;
    }
    
    public static Dictionary<string, object> SetParameterSearch(string _page, HttpContext _c, bool _setCookie)
    {
        Dictionary<string, object> _paramResult = new Dictionary<string, object>();
        StringBuilder _valueCookie = new StringBuilder();
        string _keyword = String.Empty;                
        string _degreeLevel = String.Empty;
        string _faculty = String.Empty;
        string _program = String.Empty;
        string _yearEntry = String.Empty;
        string _entranceType = String.Empty;
        string _studentStatus = String.Empty;
        string _cancelledStatus = String.Empty;        
        string _forPublicServant = String.Empty;
        string _hospital = String.Empty;
        string _hcsJoin = String.Empty;
        string _registrationForm = String.Empty;        
        string _downloadStatus = String.Empty;
        string _termServiceType = String.Empty;
        string _consentStatus = String.Empty;
        string _termServiceNote = String.Empty;
        string _consentDateStart = String.Empty;
        string _consentDateEnd = String.Empty;        
        string _sortOrderBy = String.Empty;
        string _sortExpression = String.Empty;
        int _currentPage = 1;
        int _startRow = 1;
        int _endRow = 1;
        int _rowPerPage = int.Parse(_myRowPerPageDefault);
        int _cookieError = Util.ChkCookie(_myParamSearchCookieName);
    
        if (_c != null)
        {
            _keyword = (!String.IsNullOrEmpty(_c.Request["keyword"]) ? _c.Request["keyword"] : _keyword);            
            _degreeLevel = (!String.IsNullOrEmpty(_c.Request["degreelevel"]) ? _c.Request["degreelevel"] : _degreeLevel);
            _faculty = (!String.IsNullOrEmpty(_c.Request["faculty"]) ? _c.Request["faculty"] : _faculty);
            _program = (!String.IsNullOrEmpty(_c.Request["program"]) ? _c.Request["program"] : _program);
            _yearEntry = (!String.IsNullOrEmpty(_c.Request["yearentry"]) ? _c.Request["yearentry"] : _yearEntry);
            _entranceType = (!String.IsNullOrEmpty(_c.Request["entrancetype"]) ? _c.Request["entrancetype"] : _entranceType);
            _studentStatus = (!String.IsNullOrEmpty(_c.Request["studentstatus"]) ? _c.Request["studentstatus"] : _studentStatus);
            _cancelledStatus = (!String.IsNullOrEmpty(_c.Request["cancelledStatus"]) ? _c.Request["cancelledStatus"] : _cancelledStatus);
            _forPublicServant = (!String.IsNullOrEmpty(_c.Request["forpublicservant"]) ? _c.Request["forpublicservant"] : _forPublicServant);                        
            _hospital = (!String.IsNullOrEmpty(_c.Request["hospital"]) ? _c.Request["hospital"] : _hospital);
            _hcsJoin = (!String.IsNullOrEmpty(_c.Request["hcsjoin"]) ? _c.Request["hcsjoin"] : _hcsJoin);
            _registrationForm = (!String.IsNullOrEmpty(_c.Request["registrationform"]) ? _c.Request["registrationform"] : _registrationForm);
            _downloadStatus = (!String.IsNullOrEmpty(_c.Request["downloadstatus"]) ? _c.Request["downloadstatus"] : _downloadStatus);
            _termServiceType = (!String.IsNullOrEmpty(_c.Request["termservicetype"]) ? _c.Request["termservicetype"] : _termServiceType);
            _consentStatus = (!String.IsNullOrEmpty(_c.Request["consentstatus"]) ? _c.Request["consentstatus"] : _consentStatus);
            _termServiceNote = (!String.IsNullOrEmpty(_c.Request["termservicenote"]) ? _c.Request["termservicenote"] : _termServiceNote);
            _consentDateStart = (!String.IsNullOrEmpty(_c.Request["consentdatestart"]) ? _c.Request["consentdatestart"] : _consentDateStart);
            _consentDateEnd = (!String.IsNullOrEmpty(_c.Request["consentdateend"]) ? _c.Request["consentdateend"] : _consentDateEnd);            
            _sortOrderBy = (!String.IsNullOrEmpty(_c.Request["sortorderby"]) ? _c.Request["sortorderby"] : _sortOrderBy);
            _sortExpression = (!String.IsNullOrEmpty(_c.Request["sortexpression"]) ? _c.Request["sortexpression"] : _sortExpression);
            _currentPage = (!String.IsNullOrEmpty(_c.Request["currentpage"]) ? int.Parse(_c.Request["currentpage"]) : _currentPage);
            _startRow = (!String.IsNullOrEmpty(_c.Request["startrow"]) ? int.Parse(_c.Request["startrow"]) : _startRow);
            _endRow = (!String.IsNullOrEmpty(_c.Request["endrow"]) ? int.Parse(_c.Request["endrow"]) : (!String.IsNullOrEmpty(_c.Request["rowperpage"]) ? int.Parse(_c.Request["rowperpage"]) : _rowPerPage));
            _rowPerPage = (!String.IsNullOrEmpty(_c.Request["rowperpage"]) ? int.Parse(_c.Request["rowperpage"]) : _rowPerPage);
        }
        else
        {
            Dictionary<string, object> _valueSearch = SetValueSearch(_page);
            _keyword = (string)Util.GetValueDataDictionary(_valueSearch, "Keyword", _valueSearch["Keyword"], _keyword);                
            _degreeLevel = (string)Util.GetValueDataDictionary(_valueSearch, "DegreeLevel", _valueSearch["DegreeLevel"], _faculty);
            _faculty = (string)Util.GetValueDataDictionary(_valueSearch, "Faculty", _valueSearch["Faculty"], _faculty);
            _program = (string)Util.GetValueDataDictionary(_valueSearch, "Program", _valueSearch["Program"], _program);
            _yearEntry = (string)Util.GetValueDataDictionary(_valueSearch, "YearEntry", _valueSearch["YearEntry"], _yearEntry);
            _entranceType = (string)Util.GetValueDataDictionary(_valueSearch, "EntranceType", _valueSearch["EntranceType"], _entranceType);
            _studentStatus = (string)Util.GetValueDataDictionary(_valueSearch, "StudentStatus", _valueSearch["StudentStatus"], _studentStatus);            
            _cancelledStatus = (string)Util.GetValueDataDictionary(_valueSearch, "CancelledStatus", _valueSearch["CancelledStatus"], _cancelledStatus);                
            _forPublicServant = (string)Util.GetValueDataDictionary(_valueSearch, "ForPublicServant", _valueSearch["ForPublicServant"], _forPublicServant);                
            _hospital = (string)Util.GetValueDataDictionary(_valueSearch, "Hospital", _valueSearch["Hospital"], _hospital);
            _hcsJoin = (string)Util.GetValueDataDictionary(_valueSearch, "HCSJoin", _valueSearch["HCSJoin"], _hcsJoin);
            _registrationForm = (string)Util.GetValueDataDictionary(_valueSearch, "RegistrationForm", _valueSearch["RegistrationForm"], _registrationForm);
            _downloadStatus = (string)Util.GetValueDataDictionary(_valueSearch, "DownloadStatus", _valueSearch["DownloadStatus"], _downloadStatus);
            _termServiceType = (string)Util.GetValueDataDictionary(_valueSearch, "TermServiceType", _valueSearch["TermServiceType"], _termServiceType);
            _consentStatus = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentStatus", _valueSearch["ConsentStatus"], _consentStatus);
            _termServiceNote = (string)Util.GetValueDataDictionary(_valueSearch, "TermServiceNote", _valueSearch["TermServiceNote"], _termServiceNote);
            _consentDateStart = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentDateStart", _valueSearch["ConsentDateStart"], _consentDateStart);
            _consentDateEnd = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentDateEnd", _valueSearch["ConsentDateEnd"], _consentDateEnd);                
            _sortOrderBy = (string)Util.GetValueDataDictionary(_valueSearch, "SortOrderBy", _valueSearch["SortOrderBy"], _sortOrderBy);
            _sortExpression = (string)Util.GetValueDataDictionary(_valueSearch, "SortExpression", _valueSearch["SortExpression"], _sortExpression);
            _currentPage = (int)Util.GetValueDataDictionary(_valueSearch, "CurrentPage", _valueSearch["CurrentPage"], _currentPage);
            _startRow = (int)Util.GetValueDataDictionary(_valueSearch, "StartRow", _valueSearch["StartRow"], _startRow);
            _endRow = (int)Util.GetValueDataDictionary(_valueSearch, "EndRow", _valueSearch["EndRow"], _endRow);
            _rowPerPage = (int)Util.GetValueDataDictionary(_valueSearch, "RowPerPage", _valueSearch["RowPerPage"], _rowPerPage);
        }

        if (_cookieError.Equals(0) && _setCookie.Equals(true))
        {
            HttpCookie _objCookie = Util.GetCookie(_myParamSearchCookieName);

            _objCookie.Expires = DateTime.Now.AddDays(-1D);
            HttpContext.Current.Response.Cookies.Add(_objCookie);
        }

        _paramResult.Add("Page", _page);
        _paramResult.Add("Keyword", _keyword);        
        _paramResult.Add("DegreeLevel", _degreeLevel);
        _paramResult.Add("Faculty", _faculty);
        _paramResult.Add("Program", _program);
        _paramResult.Add("YearEntry", _yearEntry);
        _paramResult.Add("EntranceType", _entranceType);
        _paramResult.Add("StudentStatus", _studentStatus);
        _paramResult.Add("CancelledStatus", _cancelledStatus);          
        _paramResult.Add("ForPublicServant", _forPublicServant);        
        _paramResult.Add("Hospital", _hospital);
        _paramResult.Add("HCSJoin", _hcsJoin);
        _paramResult.Add("RegistrationForm", _registrationForm);                
        _paramResult.Add("DownloadStatus", _downloadStatus);
        _paramResult.Add("TermServiceType", _termServiceType);
        _paramResult.Add("ConsentStatus", _consentStatus);
        _paramResult.Add("TermServiceNote", _termServiceNote);
        _paramResult.Add("ConsentDateStart", _consentDateStart);
        _paramResult.Add("ConsentDateEnd", _consentDateEnd);        
        _paramResult.Add("SortOrderBy", _sortOrderBy);
        _paramResult.Add("SortExpression", _sortExpression);
        _paramResult.Add("CurrentPage", _currentPage);
        _paramResult.Add("StartRow", _startRow);
        _paramResult.Add("EndRow", _endRow);
        _paramResult.Add("RowPerPage", _rowPerPage);

        _valueCookie.AppendFormat("Command:{0},", _page);

        if (_paramResult.ContainsKey("Keyword").Equals(true))
            _valueCookie.AppendFormat("Keyword:{0},", _paramResult["Keyword"]);

        if (_paramResult.ContainsKey("DegreeLevel").Equals(true))
            _valueCookie.AppendFormat("DegreeLevel:{0},", _paramResult["DegreeLevel"]);

        if (_paramResult.ContainsKey("Faculty").Equals(true))
            _valueCookie.AppendFormat("Faculty:{0},", _paramResult["Faculty"]);

        if (_paramResult.ContainsKey("Program").Equals(true))
            _valueCookie.AppendFormat("Program:{0},", _paramResult["Program"]);

        if (_paramResult.ContainsKey("YearEntry").Equals(true))
            _valueCookie.AppendFormat("YearEntry:{0},", _paramResult["YearEntry"]);

        if (_paramResult.ContainsKey("EntranceType").Equals(true))
            _valueCookie.AppendFormat("EntranceType:{0},", _paramResult["EntranceType"]);

        if (_paramResult.ContainsKey("StudentStatus").Equals(true))
            _valueCookie.AppendFormat("StudentStatus:{0},", _paramResult["StudentStatus"]);

        if (_paramResult.ContainsKey("CancelledStatus").Equals(true))
            _valueCookie.AppendFormat("CancelledStatus:{0},", _paramResult["CancelledStatus"]);

        if (_paramResult.ContainsKey("ForPublicServant").Equals(true))
            _valueCookie.AppendFormat("ForPublicServant:{0},", _paramResult["ForPublicServant"]);

        if (_paramResult.ContainsKey("Hospital").Equals(true))
            _valueCookie.AppendFormat("Hospital:{0},", _paramResult["Hospital"]);

        if (_paramResult.ContainsKey("HCSJoin").Equals(true))
            _valueCookie.AppendFormat("HCSJoin:{0},", _paramResult["HCSJoin"]);

        if (_paramResult.ContainsKey("RegistrationForm").Equals(true))
            _valueCookie.AppendFormat("RegistrationForm:{0},", _paramResult["RegistrationForm"]);

        if (_paramResult.ContainsKey("DownloadStatus").Equals(true))
            _valueCookie.AppendFormat("DownloadStatus:{0},", _paramResult["DownloadStatus"]);

        if (_paramResult.ContainsKey("TermServiceType").Equals(true))
            _valueCookie.AppendFormat("TermServiceType:{0},", _paramResult["TermServiceType"]);

        if (_paramResult.ContainsKey("ConsentStatus").Equals(true))
            _valueCookie.AppendFormat("ConsentStatus:{0},", _paramResult["ConsentStatus"]);

        if (_paramResult.ContainsKey("TermServiceNote").Equals(true))
            _valueCookie.AppendFormat("TermServiceNote:{0},", _paramResult["TermServiceNote"]);

        if (_paramResult.ContainsKey("ConsentDateStart").Equals(true))
            _valueCookie.AppendFormat("ConsentDateStart:{0},", _paramResult["ConsentDateStart"]);

        if (_paramResult.ContainsKey("ConsentDateEnd").Equals(true))
            _valueCookie.AppendFormat("ConsentDateEnd:{0},", _paramResult["ConsentDateEnd"]);        

        if (_paramResult.ContainsKey("SortOrderBy").Equals(true))
            _valueCookie.AppendFormat("SortOrderBy:{0},", _paramResult["SortOrderBy"]);

        if (_paramResult.ContainsKey("SortExpression").Equals(true))
            _valueCookie.AppendFormat("SortExpression:{0},", _paramResult["SortExpression"]);

        if (_paramResult.ContainsKey("CurrentPage").Equals(true))
            _valueCookie.AppendFormat("CurrentPage:{0},", _paramResult["CurrentPage"]);

        if (_paramResult.ContainsKey("StartRow").Equals(true))
            _valueCookie.AppendFormat("StartRow:{0},", _paramResult["StartRow"]);

        if (_paramResult.ContainsKey("EndRow").Equals(true))
            _valueCookie.AppendFormat("EndRow:{0},", _paramResult["EndRow"]);

        if (_paramResult.ContainsKey("RowPerPage").Equals(true))
            _valueCookie.AppendFormat("RowPerPage:{0}", _paramResult["RowPerPage"]);

        if (_setCookie.Equals(true))
            Util.SetAddCookie(_myParamSearchCookieName, _valueCookie);

        return _paramResult;
    }

    public static Dictionary<string, object> GetSearch(string _pageMain, string _pageSearch, HttpContext _c)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();
        bool _setCookie = true;

        if (_pageSearch.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN))
            _setCookie = false;

        _paramSearch = SetParameterSearch(_pageMain, _c, _setCookie);

        if (_pageSearch.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN))
            _searchResult = HCSStaffMasterDataUtil.HospitalOfHealthCareServiceUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_MASTERDATAREGISTRATIONFORM_MAIN))
            _searchResult = HCSStaffMasterDataUtil.RegistrationFormUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_MASTERDATAAGENCYREGISTERED_MAIN))
            _searchResult = HCSStaffMasterDataUtil.AgencyRegisteredUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
            _searchResult = HCSStaffDownloadRegistrationFormUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESHEALTHINFORMATION_MAIN))
            _searchResult = HCSStaffOurServicesUtil.HealthInformationUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN))
            _searchResult = HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil.ViewChartUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN))
            _searchResult = HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil.ViewTableUtil.GetSearch(_pageSearch, _paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN))
            _searchResult = HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil.ViewTableUtil.GetSearch(_pageSearch, _paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
            _searchResult = HCSStaffOurServicesUtil.TermServiceConsentUtil.GetSearch(_paramSearch);

        if (_pageSearch.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN))
            _searchResult = HCSStaffOurServicesUtil.TermServiceConsentUtil.GetSearch(_paramSearch);

        return _searchResult;
    }
   
    public static Dictionary<string, object> SetValueDataRecorded(string _page, string _id)
    {
        Dictionary<string, object> _valueDataRecordedResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        DataSet _ds = new DataSet();

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
            _ds = HCSStaffDB.GetHCSHospital(_id);

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
            _ds = HCSStaffDB.GetHCSRegistrationForm(_id);

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
            _ds = HCSStaffDB.GetHCSAgencyRegistered(_id);

        if (_ds.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
                _dataRecorded = HCSStaffMasterDataUtil.HospitalOfHealthCareServiceUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
                _dataRecorded = HCSStaffMasterDataUtil.RegistrationFormUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
                _dataRecorded = HCSStaffMasterDataUtil.AgencyRegisteredUtil.SetValueDataRecorded(_dataRecorded, _ds);
        }

        _ds.Dispose();

        if (_page.Equals(PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_HOSPITALOFHEALTHCARESERVICE), _dataRecorded);

        if (_page.Equals(PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_REGISTRATIONFORM), _dataRecorded);

        if (_page.Equals(PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_AGENCYREGISTERED), _dataRecorded);

        return _valueDataRecordedResult;               
    }

    public static DataTable SetColumnDataTable(string _page)
    {
        DataTable _dt = new DataTable();

        if (_page.Equals(PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
        {
            _dt.Columns.Add("No.");
            _dt.Columns.Add("StudentCode");
            _dt.Columns.Add("IdCard");
            _dt.Columns.Add("TitlePrefixTH");
            _dt.Columns.Add("FirstName");
            _dt.Columns.Add("MiddleName");
            _dt.Columns.Add("LastName");
            _dt.Columns.Add("TitlePrefixEN");
            _dt.Columns.Add("FirstNameEN");
            _dt.Columns.Add("MiddleNameEN");
            _dt.Columns.Add("LastNameEN");
            _dt.Columns.Add("BirthDate");
            _dt.Columns.Add("Nationality");
            _dt.Columns.Add("Faculty");
            _dt.Columns.Add("Program");
            _dt.Columns.Add("HCSJoin");
            _dt.Columns.Add("BloodType");
            _dt.Columns.Add("Weight");
            _dt.Columns.Add("Height");
            _dt.Columns.Add("BMI");
            _dt.Columns.Add("BMIDate");
            _dt.Columns.Add("Diseases");
            _dt.Columns.Add("Intolerance");
            _dt.Columns.Add("Vaccine");
            _dt.Columns.Add("TravelAbroad");
            _dt.Columns.Add("Impairments");
            _dt.Columns.Add("ImpairmentsEquipment");
            _dt.Columns.Add("ChildhoodNumber");
            _dt.Columns.Add("OccupationFather");
            _dt.Columns.Add("OccupationMother");
            _dt.Columns.Add("OccupationParent");
        }

        if (_page.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS))
        {
            _dt.Columns.Add("HealthCareServiceForm");
            _dt.Columns.Add("YearEntry");
            _dt.Columns.Add("NumberofDownload");
            _dt.Columns.Add("NumberofStudent");
        }

        if (_page.Equals(PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
        {
            _dt.Columns.Add("No.");
            _dt.Columns.Add("StudentCode");
            _dt.Columns.Add("IdCard");
            _dt.Columns.Add("TitlePrefixTH");
            _dt.Columns.Add("FirstName");
            _dt.Columns.Add("MiddleName");
            _dt.Columns.Add("LastName");
            _dt.Columns.Add("TitlePrefixEN");
            _dt.Columns.Add("FirstNameEN");
            _dt.Columns.Add("MiddleNameEN");
            _dt.Columns.Add("LastNameEN");
            _dt.Columns.Add("Faculty");
            _dt.Columns.Add("Program");
            _dt.Columns.Add("YearEntry");
            _dt.Columns.Add("AdmissionType");
            _dt.Columns.Add("StudentStatus");
            _dt.Columns.Add("HealthCareServiceForm");
            _dt.Columns.Add("LatestDateDownload");
            _dt.Columns.Add("NumberofDownload");
        }
        
        if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
        {
            _dt.Columns.Add("No.");
            _dt.Columns.Add("StudentCode");
            _dt.Columns.Add("IdCard");
            _dt.Columns.Add("TitlePrefixTH");
            _dt.Columns.Add("Fullname");
            _dt.Columns.Add("BirthDate");
            _dt.Columns.Add("Faculty");
            _dt.Columns.Add("ConsentStatus");
            _dt.Columns.Add("Hospital");
            _dt.Columns.Add("ConsentDate");
        }

        if (_page.Equals(PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
        {
            _dt.Columns.Add("MuEmailAddress");
            _dt.Columns.Add("EmailAddress");
            _dt.Columns.Add("StudentCode");
            _dt.Columns.Add("Class");
            _dt.Columns.Add("Faculty");
            _dt.Columns.Add("TitlePrefixTH");
            _dt.Columns.Add("FirstName");
            _dt.Columns.Add("LastName");
            _dt.Columns.Add("Gender");
            _dt.Columns.Add("Nationality");
            _dt.Columns.Add("StudentStatus");
            _dt.Columns.Add("ConsentStatus");
            _dt.Columns.Add("ConsentDate");
            _dt.Columns.Add("Telephone");
            _dt.Columns.Add("TelephoneParent");
        }

        return _dt;
    }
}