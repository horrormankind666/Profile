/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๕/๑๒/๒๕๕๗>
Modify date : <๐๗/๐๗/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไป>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;
using NExportToPDF;
using NFinServiceLogin;

public class HCSUtil
{    
    public const string SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM = "DownloadRegistrationForm";
    public const string SUBJECT_SECTION_STUDENTRECORDS = "StudentRecords";
    public const string SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS = (SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM + SUBJECT_SECTION_STUDENTRECORDS);

    public const string ID_SECTION_DOWNLOADREGISTRATIONFORM_MAIN = ("Main-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM);
    public const string ID_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN = ("Main-" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS);

    public const string PAGE_DOWNLOADREGISTRATIONFORM_MAIN = (SUBJECT_SECTION_DOWNLOADREGISTRATIONFORM + "Main");
    public const string PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN = (SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS + "Main");

    public static string _myPDFFormTemplate = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFormTemplate"].ToString();
    public static string _myPDFFontNormal = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontNormal"].ToString();
    public static string _myPDFFontBold = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontBold"].ToString();
    public static string _myPDFFontBarcode = System.Configuration.ConfigurationManager.AppSettings["hcsPDFFontBarcode"].ToString();    

    public static Dictionary<string, object> GetInfoLogin(string _page, string _id)
    {
        Dictionary<string, object> _finServiceLoginResult = FinServiceLogin.GetFinServiceLogin(FinServiceLogin.USERTYPE_STUDENT, "e-Profile");
        Dictionary<string, object> _loginResult = new Dictionary<string, object>();        
        int _systemError = Util.DBUtil.ChkSystemPermissionStudent(_finServiceLoginResult);
        int _cookieError = 0;
        int _userError = 0;
        string _personId = _finServiceLoginResult["PersonID"].ToString();
        string _studentId = _finServiceLoginResult["StudentID"].ToString();

        if (_systemError.Equals(0))
        {
            _systemError = (!String.IsNullOrEmpty(_personId) ? (HCSDB.GetHCSStudentRecords(_personId).Tables[0].Rows.Count > 0 ? 0 : 6) : 6);
        }

        switch (_systemError)
        {
            case 1:
                _cookieError = 1;
                break;
            case 2:
                _userError = 1;
                break;
            case 6:
                _userError = 2;
                break;
            case 3:
                _userError = 4;
                break;
            case 4:
                _userError = 5;
                break;
            case 5:
                _userError = 6;
                break;
        }

        _loginResult.Add("CookieError", _cookieError.ToString());
        _loginResult.Add("UserError", _userError.ToString());
        _loginResult.Add("PersonId", _personId);
        _loginResult.Add("StudentId", _studentId);

        return _loginResult;
    }

    public static Dictionary<string, object> GetPage(string _page)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin("", "");
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _pageError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        string _signinYN = String.Empty;
        string _personId = _loginResult["PersonId"].ToString();
        string _studentId = _loginResult["StudentId"].ToString();
        StringBuilder _mainContent = new StringBuilder();

        _pageError = 1;
        _signinYN = String.Empty;
        _mainContent = null;

        if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && _userError.Equals(0) ? HCSUI.HCSStaffDownloadRegistrationFormUI.GetSection(_loginResult, "MAIN", "", _personId) : null);
        }

        _pageResult.Add("Page", _page);
        _pageResult.Add("PageError", _pageError.ToString());
        _pageResult.Add("SignInYN", _signinYN);
        _pageResult.Add("CookieError", _cookieError.ToString());
        _pageResult.Add("UserError", _userError.ToString());
        _pageResult.Add("MainContent", (_mainContent != null ? _mainContent.ToString() : String.Empty));

        return _pageResult;
    }

    public static Dictionary<string, object> SetValueDataRecorded(string _page, string _id)
    {
        Dictionary<string, object> _valueDataRecordedResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        DataSet _ds = new DataSet();

        if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN)) 
            _ds = HCSDB.GetHCSStudentRecords(_id);
        
        if (_ds.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN))
                _dataRecorded = HCSStaffDownloadRegistrationFormUtil.StudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds);
        }

        _ds.Dispose();

        if (_page.Equals(PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS), _dataRecorded);
        
        return _valueDataRecordedResult;
    }

    public class HCSStaffDownloadRegistrationFormUtil
    {
        public class StudentRecordsUtil
        {
            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
            {
                DataRow _dr = null;

                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];

                _dataRecorded.Add("PersonId", (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"] : String.Empty));
                _dataRecorded.Add("StudentId", (_dr != null && !String.IsNullOrEmpty(_dr["studentId"].ToString()) ? _dr["studentId"] : String.Empty));
                _dataRecorded.Add("StudentCode", (_dr != null && !String.IsNullOrEmpty(_dr["studentCode"].ToString()) ? _dr["studentCode"] : "XXXXXXX"));
                _dataRecorded.Add("IdCard", (_dr != null && !String.IsNullOrEmpty(_dr["idCard"].ToString()) ? _dr["idCard"].ToString() : String.Empty));
                _dataRecorded.Add("TitleInitialsTH", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTH"].ToString()) ? _dr["titlePrefixInitialsTH"].ToString() : String.Empty));
                _dataRecorded.Add("TitleInitialsEN", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsEN"].ToString()) ? _dr["titlePrefixInitialsEN"].ToString() : String.Empty));
                _dataRecorded.Add("TitleFullNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTH"].ToString()) ? _dr["titlePrefixFullNameTH"].ToString() : String.Empty));
                _dataRecorded.Add("TitleFullNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameEN"].ToString()) ? _dr["titlePrefixFullNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("FirstName", (_dr != null && !String.IsNullOrEmpty(_dr["firstName"].ToString()) ? _dr["firstName"].ToString() : String.Empty));
                _dataRecorded.Add("MiddleName", (_dr != null && !String.IsNullOrEmpty(_dr["middleName"].ToString()) ? _dr["middleName"].ToString() : String.Empty));
                _dataRecorded.Add("LastName", (_dr != null && !String.IsNullOrEmpty(_dr["lastName"].ToString()) ? _dr["lastName"].ToString() : String.Empty));
                _dataRecorded.Add("FirstNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameEN"].ToString()) ? _dr["firstNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("MiddleNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameEN"].ToString()) ? _dr["middleNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("LastNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameEN"].ToString()) ? _dr["lastNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("BirthDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateTH"].ToString()) ? _dr["birthDateTH"].ToString() : String.Empty));
                _dataRecorded.Add("BirthDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateEN"].ToString()) ? _dr["birthDateEN"].ToString() : String.Empty));
                _dataRecorded.Add("FacultyCode", (_dr != null && !String.IsNullOrEmpty(_dr["facultyCode"].ToString()) ? _dr["facultyCode"].ToString() : String.Empty));
                _dataRecorded.Add("FacultyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? _dr["facultyNameTH"].ToString() : String.Empty));
                _dataRecorded.Add("FacultyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? _dr["facultyNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("ProgramCode", (_dr != null && !String.IsNullOrEmpty(_dr["programCode"].ToString()) ? _dr["programCode"].ToString() : String.Empty));
                _dataRecorded.Add("ProgramNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
                _dataRecorded.Add("ProgramNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("ProgramAddress", (_dr != null && !String.IsNullOrEmpty(_dr["programAddress"].ToString()) ? _dr["programAddress"].ToString() : String.Empty));
                _dataRecorded.Add("ProgramTelephone", (_dr != null && !String.IsNullOrEmpty(_dr["programTelephone"].ToString()) ? _dr["programTelephone"].ToString() : String.Empty));
                _dataRecorded.Add("HospitalId", (_dr != null && !String.IsNullOrEmpty(_dr["hcsHospitalId"].ToString()) ? _dr["hcsHospitalId"].ToString() : String.Empty));
                _dataRecorded.Add("HospitalNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameTH"].ToString()) ? _dr["hospitalNameTH"].ToString() : String.Empty));
                _dataRecorded.Add("HospitalNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameEN"].ToString()) ? _dr["hospitalNameEN"].ToString() : String.Empty));
                _dataRecorded.Add("CountryNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameTHPermanent"].ToString()) ? _dr["countryNameTHPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("CountryNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameENPermanent"].ToString()) ? _dr["countryNameENPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("ProvinceNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameTHPermanent"].ToString()) ? _dr["provinceNameTHPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("ProvinceNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameENPermanent"].ToString()) ? _dr["provinceNameENPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("DistrictNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameTHPermanent"].ToString()) ? _dr["districtNameTHPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("DistrictNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameENPermanent"].ToString()) ? _dr["districtNameENPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("SubDistrictNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameTHPermanent"].ToString()) ? _dr["subdistrictNameTHPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("SubDistrictNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameENPermanent"].ToString()) ? _dr["subdistrictNameENPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("PostalCodePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodePermanent"].ToString()) ? _dr["zipCodePermanent"].ToString() : String.Empty));
                _dataRecorded.Add("VillagePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["villagePermanent"].ToString()) ? _dr["villagePermanent"].ToString() : String.Empty));
                _dataRecorded.Add("HouseNoPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["noPermanent"].ToString()) ? _dr["noPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("VillageNoPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mooPermanent"].ToString()) ? _dr["mooPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("LaneAlleyPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["soiPermanent"].ToString()) ? _dr["soiPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("RoadPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["roadPermanent"].ToString()) ? _dr["roadPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("PhoneNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberPermanent"].ToString()) ? _dr["phoneNumberPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("MobileNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberPermanent"].ToString()) ? _dr["mobileNumberPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("FaxNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberPermanent"].ToString()) ? _dr["faxNumberPermanent"].ToString() : String.Empty));
                _dataRecorded.Add("CountryNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameTHCurrent"].ToString()) ? _dr["countryNameTHCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("CountryNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameENCurrent"].ToString()) ? _dr["countryNameENCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("ProvinceNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameTHCurrent"].ToString()) ? _dr["provinceNameTHCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("ProvinceNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameENCurrent"].ToString()) ? _dr["provinceNameENCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("DistrictNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameTHCurrent"].ToString()) ? _dr["districtNameTHCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("DistrictNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameENCurrent"].ToString()) ? _dr["districtNameENCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("SubDistrictNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameTHCurrent"].ToString()) ? _dr["subdistrictNameTHCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("SubDistrictNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameENCurrent"].ToString()) ? _dr["subdistrictNameENCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("PostalCodeCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeCurrent"].ToString()) ? _dr["zipCodeCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("VillageCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["villageCurrent"].ToString()) ? _dr["villageCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("HouseNoCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["noCurrent"].ToString()) ? _dr["noCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("VillageNoCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mooCurrent"].ToString()) ? _dr["mooCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("LaneAlleyCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["soiCurrent"].ToString()) ? _dr["soiCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("RoadCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["roadCurrent"].ToString()) ? _dr["roadCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("PhoneNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberCurrent"].ToString()) ? _dr["phoneNumberCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("MobileNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrent"].ToString()) ? _dr["mobileNumberCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("FaxNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberCurrent"].ToString()) ? _dr["faxNumberCurrent"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationFather"].ToString()) ? _dr["occupationFather"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameTHFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHFather"].ToString()) ? _dr["occupationNameTHFather"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENFather"].ToString()) ? _dr["occupationNameENFather"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationMother"].ToString()) ? _dr["occupationMother"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameTHMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHMother"].ToString()) ? _dr["occupationNameTHMother"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENMother"].ToString()) ? _dr["occupationNameENMother"].ToString() : String.Empty));            
                _dataRecorded.Add("OccupationParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationParent"].ToString()) ? _dr["occupationParent"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameTHParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHParent"].ToString()) ? _dr["occupationNameTHParent"].ToString() : String.Empty));
                _dataRecorded.Add("OccupationNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENParent"].ToString()) ? _dr["occupationNameENParent"].ToString() : String.Empty));

                return _dataRecorded;
            }
        }

        public static void GetRegisForm(Dictionary<string, object> _dataRecorded)
        {
            string _formName = String.Empty;
            string _address = String.Empty;
            int _error = 0;
            int _template = 0;
            int _i = 0;
            bool _download1 = false;
            bool _download2 = false;
            DataSet _ds = new DataSet();
            DataRow _dr = null;

            switch (_dataRecorded["HospitalId"].ToString())
            {
                case "RA":
                    _template = 2;
                    _formName = "RARegisForm";
                    break;
                case "SI":
                    _template = 3;
                    _formName = "SIRegisForm";
                    break;
            }

            _ds = HCSDB.GetHCSRegistrationForm(_formName);

            if (_ds.Tables[0].Rows.Count > 0)
            {
                _dr = _ds.Tables[0].Rows[0];
                _download1 = (_dr["cancelledStatus"].ToString().Equals("N") ? true : false);
            }

            _ds.Dispose();

            _ds = HCSDB.GetHCSRegistrationForm("KN003Form");

            if (_ds.Tables[0].Rows.Count > 0)
            {
                _dr = _ds.Tables[0].Rows[0];
                _download2 = (_dr["cancelledStatus"].ToString().Equals("N") ? true : false);
            }

            _ds.Dispose();

            if (_error.Equals(0) && _download1.Equals(true))
                _error = HCSDB.InsertHCSDownloadLog(_dataRecorded["PersonId"].ToString(), _formName, "Student");

            if (_error.Equals(0) && _download2.Equals(true))
                _error = HCSDB.InsertHCSDownloadLog(_dataRecorded["PersonId"].ToString(), "KN003Form", "Student");

            if (_error.Equals(0))
            {
                ExportToPDF _e = new ExportToPDF();
                _e.ExportToPDFConnect(_formName + ".pdf");
                _e.PDFConnectTemplate(_myPDFFormTemplate, "pdf");
                _e.PDFAddTemplate("pdf", 1, 1);

                if (_download1.Equals(true))
                {
                    _e.PDFAddTemplate("pdf", _template, 2);

                    _e.FillForm(_myPDFFontNormal, 11, 0, "วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd")), 18, 565, 100, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (!_dataRecorded["StudentCode"].Equals("XXXXXXX") ? Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "") : ""), 192, 572, 91, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["ProgramNameTH"].ToString(), ""), 180, 555, 106, 23);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 169, 536, 118, 23);
                    _e.FillForm(_myPDFFontBold, 16, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 18, 478, 260, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 1 ? _dataRecorded["IdCard"].ToString().Substring(0, 1) : ""), 23, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 2 ? _dataRecorded["IdCard"].ToString().Substring(1, 1) : ""), 54, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 3 ? _dataRecorded["IdCard"].ToString().Substring(2, 1) : ""), 69, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 4 ? _dataRecorded["IdCard"].ToString().Substring(3, 1) : ""), 84, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 5 ? _dataRecorded["IdCard"].ToString().Substring(4, 1) : ""), 100, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 6 ? _dataRecorded["IdCard"].ToString().Substring(5, 1) : ""), 131, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 7 ? _dataRecorded["IdCard"].ToString().Substring(6, 1) : ""), 147, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 8 ? _dataRecorded["IdCard"].ToString().Substring(7, 1) : ""), 162, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 9 ? _dataRecorded["IdCard"].ToString().Substring(8, 1) : ""), 177, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 10 ? _dataRecorded["IdCard"].ToString().Substring(9, 1) : ""), 193, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 11 ? _dataRecorded["IdCard"].ToString().Substring(10, 1) : ""), 224, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 12 ? _dataRecorded["IdCard"].ToString().Substring(11, 1) : ""), 239, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 13 ? _dataRecorded["IdCard"].ToString().Substring(12, 1) : ""), 271, 441, 8, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 72, 416, 87, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), ""), 56, 385, 48, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), ""), 123, 385, 27, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), ""), 189, 385, 93, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), ""), 33, 370, 90, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 166, 370, 117, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 56, 355, 60, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 141, 355, 56, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["PostalCodePermanentAddress"].ToString(), ""), 238, 355, 45, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["PhoneNumberPermanentAddress"].ToString(), ""), 45, 339, 95, 0);
                    _e.FillForm(_myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["MobileNumberPermanentAddress"].ToString(), ""), 185, 339, 97, 0);

                    if (!_dataRecorded["OccupationNameTHFather"].ToString().IndexOf("รับราชการ").Equals(-1) || !_dataRecorded["OccupationNameTHFather"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1) ||
                        !_dataRecorded["OccupationNameTHMother"].ToString().IndexOf("รับราชการ").Equals(-1) || !_dataRecorded["OccupationNameTHMother"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1) ||
                        !_dataRecorded["OccupationNameTHParent"].ToString().IndexOf("รับราชการ").Equals(-1) || !_dataRecorded["OccupationNameTHParent"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1))
                        _e.FillForm(_myPDFFontBold, 14, 0, "รอเปลี่ยนสิทธิอายุ 20 ปี", 18, 22, 440, 0);

                    if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["IdCard"].ToString(), "")))
                        _e.FillForm(_myPDFFontBarcode, 24, 2, "*" + _dataRecorded["IdCard"] + "*", 577, 29, 245, 0);
                }

                if (_download2.Equals(true))
                {
                    _e.PDFAddTemplate("pdf", 10, 2);

                    _e.FillForm(_myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 79, 494, 278, 0);
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["VillageCurrentAddress"].ToString(), "")) ? ("หมู่บ้าน" + _dataRecorded["VillageCurrentAddress"] + " ") : "");
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), "")) ? ("บ้านเลขที่ " + _dataRecorded["HouseNoCurrentAddress"] + " ") : "");
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), "")) ? ("หมู่ " + _dataRecorded["VillageNoCurrentAddress"]) + " " : "");
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), "")) ? ("ซอย " + _dataRecorded["LaneAlleyCurrentAddress"]) : "");
                    _e.FillForm(_myPDFFontBold, 14, 0, _address, 89, 473, 400, 0);

                    _address = String.Empty;
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), "")) ? ("ถนน" + _dataRecorded["RoadCurrentAddress"] + " ") : "");
                    _address += (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), "")) ? ("ตำบล" + _dataRecorded["SubDistrictNameTHCurrentAddress"]) : "");
                    _e.FillForm(_myPDFFontBold, 14, 0, _address, 99, 453, 258, 0);
                    _e.FillForm(_myPDFFontBold, 14, 0, (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), "")) ? ("อำเภอ" + _dataRecorded["DistrictNameTHCurrentAddress"] + "") : ""), 109, 432, 248, 0);
                    _e.FillForm(_myPDFFontBold, 14, 0, (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), "")) ? ("จังหวัด" + _dataRecorded["ProvinceNameTHCurrentAddress"] + "") : ""), 119, 412, 238, 0);

                    if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "")))
                    {
                        _e.FillForm(_myPDFFontBold, 14, 0, (_dataRecorded["PostalCodeCurrentAddress"].ToString().Length >= 1 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(0, 1) : ""), 182, 387, 8, 0);
                        _e.FillForm(_myPDFFontBold, 14, 0, (_dataRecorded["PostalCodeCurrentAddress"].ToString().Length >= 2 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(1, 1) : ""), 199, 387, 8, 0);
                        _e.FillForm(_myPDFFontBold, 14, 0, (_dataRecorded["PostalCodeCurrentAddress"].ToString().Length >= 3 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(2, 1) : ""), 216, 387, 8, 0);
                        _e.FillForm(_myPDFFontBold, 14, 0, (_dataRecorded["PostalCodeCurrentAddress"].ToString().Length >= 4 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(3, 1) : ""), 232, 387, 8, 0);
                        _e.FillForm(_myPDFFontBold, 14, 0, (_dataRecorded["PostalCodeCurrentAddress"].ToString().Length >= 5 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(4, 1) : ""), 250, 387, 8, 0);
                    }

                    if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ProgramAddress"].ToString(), "")))
                    {
                        string[] _programAddressArray = _dataRecorded["ProgramAddress"].ToString().Split('&');
                        int _col = 380;
                        int _row = 225;

                        for (_i = 0; _i < _programAddressArray.GetLength(0); _i++)
                        {
                            _e.FillForm(_myPDFFontBold, 16, 0, _programAddressArray[_i], _col, _row, 363, 0);
                            _col = _col + 10;
                            _row = _row - 22;
                        }
                    }
                }
                
                _e.ExportToPdfDisconnect();
            }
        }
    }
}