/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๔/๐๘/๒๕๕๘>
Modify date : <๐๙/๐๑/๒๕๖๑>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using NUtil;
using NExportToPDF;

public class HCSStaffDownloadRegistrationFormUtil
{
    public static string[] _sortOrderBy = new string[]
    {
        "Student ID"
        /*,
        "Name",
        "Program",
        "Year Attended"
        */
    };
    
    public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
    {
        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();
        DataSet _ds = new DataSet();
        DataRow[] _dr = null;
        int _recordCount = 0;
        int _recordCountPrimary = 0;
        int _recordCountSecondary = 0;
        int _recordCountAllPrimary = 0;
        int _recordCountAllSecondary = 0; 
        StringBuilder _list = new StringBuilder();
        StringBuilder _navPage = new StringBuilder();        

        _ds = HCSStaffDB.GetListHCSStudentRecords(
            _loginResult["Username"].ToString(),
            _loginResult["Userlevel"].ToString(),
            _loginResult["SystemGroup"].ToString(),
            _paramSearch
        );
        
        _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
        _recordCount = _ds.Tables[0].Rows.Count;
        _recordCountPrimary = _ds.Tables[0].Rows.Count;
        _list = HCSStaffDownloadRegistrationFormUI.SectionMainUI.GetList(_loginResult, _dr);
        _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN, (int)(_paramSearch["RowPerPage"]));

        _ds.Dispose();

        _searchResult.Add("RecordCount", _recordCount);
        _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
        _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
        _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);
        _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
        _searchResult.Add("List", _list);
        _searchResult.Add("NavPage", _navPage);

        return _searchResult;
    }

    public class StudentRecordsUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            string _studentPicture = String.Empty;
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _studentPicture = (_dr != null && !String.IsNullOrEmpty(_dr["profilePictureName"].ToString()) ? (HCSStaffUtil._myURLPictureStudent + "/" + _dr["profilePictureName"].ToString()) : String.Empty);
            _studentPicture = (!String.IsNullOrEmpty(_studentPicture) && Util.FileSiteExist(_studentPicture) ? _studentPicture : String.Empty);

            _dataRecorded.Add("PersonId", (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"] : String.Empty));
            _dataRecorded.Add("StudentId", (_dr != null && !String.IsNullOrEmpty(_dr["studentId"].ToString()) ? _dr["studentId"] : String.Empty));
            _dataRecorded.Add("StudentCode", (_dr != null && !String.IsNullOrEmpty(_dr["studentCode"].ToString()) ? _dr["studentCode"] : "XXXXXXX"));
            _dataRecorded.Add("StudentPicture", (!String.IsNullOrEmpty(_studentPicture) ? _studentPicture : String.Empty));
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
            _dataRecorded.Add("GenderFullNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["genderFullNameTH"].ToString()) ? _dr["genderFullNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("GenderFullNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["genderFullNameEN"].ToString()) ? _dr["genderFullNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("GenderInitialsTH", (_dr != null && !String.IsNullOrEmpty(_dr["genderInitialsTH"].ToString()) ? _dr["genderInitialsTH"].ToString() : String.Empty));
            _dataRecorded.Add("GenderInitialsEN", (_dr != null && !String.IsNullOrEmpty(_dr["genderInitialsEN"].ToString()) ? _dr["genderInitialsEN"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateOfDay", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateOfDay"].ToString()) ? _dr["birthDateOfDay"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateOfMonth", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateOfMonth"].ToString()) ? _dr["birthDateOfMonth"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateOfYear", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateOfYear"].ToString()) ? _dr["birthDateOfYear"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateTH"].ToString()) ? _dr["birthDateTH"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["birthDateEN"].ToString()) ? _dr["birthDateEN"].ToString() : String.Empty));
            _dataRecorded.Add("Age", (_dr != null && !String.IsNullOrEmpty(_dr["age"].ToString()) ? _dr["age"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyCode", (_dr != null && !String.IsNullOrEmpty(_dr["facultyCode"].ToString()) ? _dr["facultyCode"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? _dr["facultyNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? _dr["facultyNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramCode", (_dr != null && !String.IsNullOrEmpty(_dr["programCode"].ToString()) ? _dr["programCode"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramAddress", (_dr != null && !String.IsNullOrEmpty(_dr["programAddress"].ToString()) ? _dr["programAddress"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramTelephone", (_dr != null && !String.IsNullOrEmpty(_dr["programTelephone"].ToString()) ? _dr["programTelephone"].ToString() : String.Empty));
            _dataRecorded.Add("Class", (_dr != null && !String.IsNullOrEmpty(_dr["class"].ToString()) ? _dr["class"].ToString() : String.Empty));
            _dataRecorded.Add("HospitalId", (_dr != null && !String.IsNullOrEmpty(_dr["hcsHospitalId"].ToString()) ? _dr["hcsHospitalId"].ToString() : String.Empty));
            _dataRecorded.Add("HospitalNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameTH"].ToString()) ? _dr["hospitalNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("HospitalNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameEN"].ToString()) ? _dr["hospitalNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("NationalityNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["nationalityNameTH"].ToString()) ? _dr["nationalityNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("NationalityNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["nationalityNameEN"].ToString()) ? _dr["nationalityNameEN"].ToString() : String.Empty));            
            _dataRecorded.Add("OriginNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["originNameTH"].ToString()) ? _dr["originNameTH"].ToString() : String.Empty));            
            _dataRecorded.Add("OriginNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["originNameEN"].ToString()) ? _dr["originNameEN"].ToString() : String.Empty));            
            _dataRecorded.Add("ReligionNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["religionNameTH"].ToString()) ? _dr["religionNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ReligionNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["religionNameEN"].ToString()) ? _dr["religionNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("BloodTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["bloodTypeNameTH"].ToString()) ? _dr["bloodTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("BloodTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["bloodTypeNameEN"].ToString()) ? _dr["bloodTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatusNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["maritalStatusNameTH"].ToString()) ? _dr["maritalStatusNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatusNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["maritalStatusNameEN"].ToString()) ? _dr["maritalStatusNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["educationalBackgroundNameTH"].ToString()) ? _dr["educationalBackgroundNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["educationalBackgroundNameEN"].ToString()) ? _dr["educationalBackgroundNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("Email", (_dr != null && !String.IsNullOrEmpty(_dr["email"].ToString()) ? _dr["email"].ToString() : String.Empty));
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
            _dataRecorded.Add("BodyMassDetail", (_dr != null && !String.IsNullOrEmpty(_dr["bodyMassDetail"].ToString()) ? _dr["bodyMassDetail"].ToString() : String.Empty));
            _dataRecorded.Add("IntoleranceStatus", (_dr != null && !String.IsNullOrEmpty(_dr["intolerance"].ToString()) ? _dr["intolerance"].ToString() : String.Empty));
            _dataRecorded.Add("IntoleranceDetail", (_dr != null && !String.IsNullOrEmpty(_dr["intoleranceDetail"].ToString()) ? _dr["intoleranceDetail"].ToString() : String.Empty));
            _dataRecorded.Add("DiseasesStatus", (_dr != null && !String.IsNullOrEmpty(_dr["diseases"].ToString()) ? _dr["diseases"].ToString() : String.Empty));
            _dataRecorded.Add("DiseasesDetail", (_dr != null && !String.IsNullOrEmpty(_dr["diseasesDetail"].ToString()) ? _dr["diseasesDetail"].ToString() : String.Empty));
            _dataRecorded.Add("AilHistoryFamilyStatus", (_dr != null && !String.IsNullOrEmpty(_dr["ailHistoryFamily"].ToString()) ? _dr["ailHistoryFamily"].ToString() : String.Empty));
            _dataRecorded.Add("AilHistoryFamilyDetail", (_dr != null && !String.IsNullOrEmpty(_dr["ailHistoryFamilyDetail"].ToString()) ? _dr["ailHistoryFamilyDetail"].ToString() : String.Empty));
            _dataRecorded.Add("TravelAbroadStatus", (_dr != null && !String.IsNullOrEmpty(_dr["travelAbroad"].ToString()) ? _dr["travelAbroad"].ToString() : String.Empty));
            _dataRecorded.Add("TravelAbroadDetail", (_dr != null && !String.IsNullOrEmpty(_dr["travelAbroadDetail"].ToString()) ? _dr["travelAbroadDetail"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsStatus", (_dr != null && !String.IsNullOrEmpty(_dr["impairments"].ToString()) ? _dr["impairments"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsDetail", (_dr != null && !String.IsNullOrEmpty(_dr["perImpairmentsId"].ToString()) ? _dr["perImpairmentsId"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsNameTH"].ToString()) ? _dr["impairmentsNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsNameEN"].ToString()) ? _dr["impairmentsNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsEquipment", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsEquipment"].ToString()) ? _dr["impairmentsEquipment"].ToString() : String.Empty));
            _dataRecorded.Add("WorkedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["workedStatus"].ToString()) ? _dr["workedStatus"].ToString() : "N"));
            _dataRecorded.Add("WorkedStatusNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["workedStatusNameTH"].ToString()) ? _dr["workedStatusNameTH"].ToString() : "ไม่ทำ"));
            _dataRecorded.Add("WorkedStatusNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["workedStatusNameEN"].ToString()) ? _dr["workedStatusNameEN"].ToString() : "Not Work"));
            _dataRecorded.Add("TitleInitialsTHFather", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTHFather"].ToString()) ? _dr["titlePrefixInitialsTHFather"].ToString() : String.Empty));
            _dataRecorded.Add("TitleInitialsENFather", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsENFather"].ToString()) ? _dr["titlePrefixInitialsENFather"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameTHFather", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTHFather"].ToString()) ? _dr["titlePrefixFullNameTHFather"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameENFather"].ToString()) ? _dr["titlePrefixFullNameENFather"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameFather", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameFather"].ToString()) ? _dr["firstNameFather"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameFather", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameFather"].ToString()) ? _dr["middleNameFather"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameFather", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameFather"].ToString()) ? _dr["lastNameFather"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameENFather"].ToString()) ? _dr["firstNameENFather"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameENFather"].ToString()) ? _dr["middleNameENFather"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameENFather"].ToString()) ? _dr["lastNameENFather"].ToString() : String.Empty));
            _dataRecorded.Add("AliveFather", (_dr != null && !String.IsNullOrEmpty(_dr["aliveFather"].ToString()) ? _dr["aliveFather"].ToString() : String.Empty));
            _dataRecorded.Add("EmailFather", (_dr != null && !String.IsNullOrEmpty(_dr["emailFather"].ToString()) ? _dr["emailFather"].ToString() : String.Empty));
            _dataRecorded.Add("MobileNumberCurrentAddressFather", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrentFather"].ToString()) ? _dr["mobileNumberCurrentFather"].ToString() : String.Empty));
            _dataRecorded.Add("TitleInitialsTHMother", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTHMother"].ToString()) ? _dr["titlePrefixInitialsTHMother"].ToString() : String.Empty));
            _dataRecorded.Add("TitleInitialsENMother", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsENMother"].ToString()) ? _dr["titlePrefixInitialsENMother"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameTHMother", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTHMother"].ToString()) ? _dr["titlePrefixFullNameTHMother"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameENMother"].ToString()) ? _dr["titlePrefixFullNameENMother"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameMother", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameMother"].ToString()) ? _dr["firstNameMother"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameMother", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameMother"].ToString()) ? _dr["middleNameMother"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameMother", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameMother"].ToString()) ? _dr["lastNameMother"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameENMother"].ToString()) ? _dr["firstNameENMother"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameENMother"].ToString()) ? _dr["middleNameENMother"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameENMother"].ToString()) ? _dr["lastNameENMother"].ToString() : String.Empty));
            _dataRecorded.Add("AliveMother", (_dr != null && !String.IsNullOrEmpty(_dr["aliveMother"].ToString()) ? _dr["aliveMother"].ToString() : String.Empty));
            _dataRecorded.Add("EmailMother", (_dr != null && !String.IsNullOrEmpty(_dr["emailMother"].ToString()) ? _dr["emailMother"].ToString() : String.Empty));
            _dataRecorded.Add("MobileNumberCurrentAddressMother", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrentMother"].ToString()) ? _dr["mobileNumberCurrentMother"].ToString() : String.Empty));
            _dataRecorded.Add("RelationshipNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["relationshipNameTH"].ToString()) ? _dr["relationshipNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("RelationshipNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["relationshipNameEN"].ToString()) ? _dr["relationshipNameEN"].ToString() : String.Empty));            
            _dataRecorded.Add("TitleInitialsTHParent", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTHParent"].ToString()) ? _dr["titlePrefixInitialsTHParent"].ToString() : String.Empty));
            _dataRecorded.Add("TitleInitialsENParent", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsENParent"].ToString()) ? _dr["titlePrefixInitialsENParent"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameTHParent", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTHParent"].ToString()) ? _dr["titlePrefixFullNameTHParent"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameENParent"].ToString()) ? _dr["titlePrefixFullNameENParent"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameParent", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameParent"].ToString()) ? _dr["firstNameParent"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameParent", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameParent"].ToString()) ? _dr["middleNameParent"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameParent", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameParent"].ToString()) ? _dr["lastNameParent"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameENParent"].ToString()) ? _dr["firstNameENParent"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameENParent"].ToString()) ? _dr["middleNameENParent"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameENParent"].ToString()) ? _dr["lastNameENParent"].ToString() : String.Empty));
            _dataRecorded.Add("EmailParent", (_dr != null && !String.IsNullOrEmpty(_dr["emailParent"].ToString()) ? _dr["emailParent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameTHCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameTHCurrentParent"].ToString()) ? _dr["countryNameTHCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameENCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameENCurrentParent"].ToString()) ? _dr["countryNameENCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameTHCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameTHCurrentParent"].ToString()) ? _dr["provinceNameTHCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameENCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["provinceNameENCurrentParent"].ToString()) ? _dr["provinceNameENCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameTHCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameTHCurrentParent"].ToString()) ? _dr["districtNameTHCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameENCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["districtNameENCurrentParent"].ToString()) ? _dr["districtNameENCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameTHCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameTHCurrentParent"].ToString()) ? _dr["subdistrictNameTHCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameENCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["subdistrictNameENCurrentParent"].ToString()) ? _dr["subdistrictNameENCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodeCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeCurrentParent"].ToString()) ? _dr["zipCodeCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("VillageCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["villageCurrentParent"].ToString()) ? _dr["villageCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("HouseNoCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["noCurrentParent"].ToString()) ? _dr["noCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("VillageNoCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["mooCurrentParent"].ToString()) ? _dr["mooCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("LaneAlleyCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["soiCurrentParent"].ToString()) ? _dr["soiCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("RoadCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["roadCurrentParent"].ToString()) ? _dr["roadCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("PhoneNumberCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberCurrentParent"].ToString()) ? _dr["phoneNumberCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("MobileNumberCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrentParent"].ToString()) ? _dr["mobileNumberCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("FaxNumberCurrentAddressParent", (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberCurrentParent"].ToString()) ? _dr["faxNumberCurrentParent"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationFather"].ToString()) ? _dr["occupationFather"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameTHFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHFather"].ToString()) ? _dr["occupationNameTHFather"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameENFather", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENFather"].ToString()) ? _dr["occupationNameENFather"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationMother"].ToString()) ? _dr["occupationMother"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameTHMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHMother"].ToString()) ? _dr["occupationNameTHMother"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameENMother", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENMother"].ToString()) ? _dr["occupationNameENMother"].ToString() : String.Empty));            
            _dataRecorded.Add("OccupationParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationParent"].ToString()) ? _dr["occupationParent"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameTHParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameTHParent"].ToString()) ? _dr["occupationNameTHParent"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationNameENParent", (_dr != null && !String.IsNullOrEmpty(_dr["occupationNameENParent"].ToString()) ? _dr["occupationNameENParent"].ToString() : String.Empty));
            _dataRecorded.Add("Welfare", (_dr != null && !String.IsNullOrEmpty(_dr["hcsWelfareId"].ToString()) ? _dr["hcsWelfareId"].ToString() : String.Empty));
            _dataRecorded.Add("WelfareNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["welfareNameTH"].ToString()) ? _dr["welfareNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("WelfareNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["welfareNameEN"].ToString()) ? _dr["welfareNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("WelfareForPublicServant", (_dr != null && !String.IsNullOrEmpty(_dr["welfareForPublicServant"].ToString()) ? _dr["welfareForPublicServant"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class GenerateRegistrationFormUtil
    {
        public void GetRegistrationForm(string _registrationForm, Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            Type _thisType = this.GetType();
            MethodInfo _theMethod = _thisType.GetMethod("Get" + _registrationForm);
            _theMethod.Invoke(this, new object[]
            {
                _dataRecorded,
                _e
            });
        }

        public void GetNHSORegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 1, 1);
            _e.PDFAddTemplate("pdf", 2, 1);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 335, 700, 203, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["ProgramNameTH"].ToString(), ""), 125, 680, 159, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["Class"].ToString(), ""), 322, 673, 52, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), ""), 440, 673, 98, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 104, 653, 196, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["IdCard"].ToString(), ""), 418, 653, 120, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 158, 634, 65, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 317, 634, 28, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), ""), 149, 614, 45, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), ""), 220, 614, 40, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), ""), 308, 614, 100, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), ""), 435, 614, 95, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 140, 595, 112, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 305, 595, 117, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 457, 595, 74, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["PostalCodePermanentAddress"].ToString(), ""), 144, 575, 72, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["PhoneNumberPermanentAddress"].ToString(), ""), 245, 575, 89, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 13, 0, Util.GetBlank(_dataRecorded["MobileNumberPermanentAddress"].ToString(), ""), 380, 575, 91, 0);

            if (_dataRecorded["HospitalId"].Equals("SI"))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, "X", 331, 524, 10, 0);

            if (_dataRecorded["HospitalId"].Equals("RA"))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, "X", 441, 524, 10, 0);

            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, "X", 220, 446, 10, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 1, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 111, 276, 174, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 1, Util.CurrentDate("dd"), 139, 237, 23, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 1, Util._longMonth[int.Parse(Util.CurrentDate("MM")) - 1, 1], 185, 237, 49, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 1, (int.Parse(Util.CurrentDate("yyyy")) + 543).ToString(), 242, 237, 33, 0);

            if (_dataRecorded["WelfareForPublicServant"].Equals("Y"))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, "รอเปลี่ยนสิทธิอายุ 20 ปี", 83, 75, 200, 0);

            if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["IdCard"].ToString(), "")))
                _e.FillForm(HCSStaffUtil._myPDFFontBarcode, 24, 2, "*" + _dataRecorded["IdCard"] + "*", 295, 40, 245, 0);
        }

        public void GetRARegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 1, 1);
            _e.PDFAddTemplate("pdf", 3, 2);
            GetRegisForm(_dataRecorded, _e);
        }

        public void GetSIRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 1, 1);
            _e.PDFAddTemplate("pdf", 4, 2);
            GetRegisForm(_dataRecorded, _e);
        }

        public static void GetRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, ("วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd"))), 722, 581, 100, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["StudentCode"].ToString().Equals("XXXXXXX") ? Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "") : ""), 217, 565, 58, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 10, 0, Util.GetBlank(_dataRecorded["ProgramNameTH"].ToString(), ""), 204, 554, 71, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 10, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 192, 539, 83, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 20, 488, 255, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 1 ? _dataRecorded["IdCard"].ToString().Substring(0, 1) : ""), 92, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 2 ? _dataRecorded["IdCard"].ToString().Substring(1, 1) : ""), 110, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 3 ? _dataRecorded["IdCard"].ToString().Substring(2, 1) : ""), 123, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 4 ? _dataRecorded["IdCard"].ToString().Substring(3, 1) : ""), 135, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 5 ? _dataRecorded["IdCard"].ToString().Substring(4, 1) : ""), 147, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 6 ? _dataRecorded["IdCard"].ToString().Substring(5, 1) : ""), 165, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 7 ? _dataRecorded["IdCard"].ToString().Substring(6, 1) : ""), 177, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 8 ? _dataRecorded["IdCard"].ToString().Substring(7, 1) : ""), 190, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 9 ? _dataRecorded["IdCard"].ToString().Substring(8, 1) : ""), 202, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 10 ? _dataRecorded["IdCard"].ToString().Substring(9, 1) : ""), 214, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 11 ? _dataRecorded["IdCard"].ToString().Substring(10, 1) : ""), 233, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 12 ? _dataRecorded["IdCard"].ToString().Substring(11, 1) : ""), 245, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 13 ? _dataRecorded["IdCard"].ToString().Substring(12, 1) : ""), 264, 470, 11, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 75, 447, 65, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), ""), 61, 424, 39, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), ""), 121, 424, 21, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), ""), 185, 424, 90, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), ""), 36, 409, 90, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 170, 409, 105, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 61, 394, 106, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 195, 394, 80, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["PostalCodePermanentAddress"].ToString(), ""), 63, 380, 42, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["PhoneNumberPermanentAddress"].ToString(), ""), 122, 380, 53, 20);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["MobileNumberPermanentAddress"].ToString(), ""), 209, 380, 66, 20);

            if (_dataRecorded["WorkedStatus"].Equals("Y"))
            {
                if (_dataRecorded["WelfareForPublicServant"].Equals("Y"))
                {
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, "X", 18, 299, 10, 0);
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, "ไม่เปลี่ยนสิทธิการรักษาพยาบาล", 65, 297, 184, 0);
                }
                if (_dataRecorded["WelfareForPublicServant"].Equals("N"))
                {
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, "X", 18, 328, 10, 0);
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, "ประกันสังคม", 91, 327, 184, 0);
                }
            }

            if (_dataRecorded["WorkedStatus"].Equals("N"))
            {
                if (_dataRecorded["WelfareForPublicServant"].Equals("Y"))
                {
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, "X", 18, 328, 10, 0);
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, "ข้าราชการ / รัฐวิสาหกิจ", 91, 327, 184, 0);
                }
                if (_dataRecorded["WelfareForPublicServant"].Equals("N"))
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 1, "X", 18, 314, 10, 0);
            }

            if (_dataRecorded["WelfareForPublicServant"].Equals("Y"))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, "รอเปลี่ยนสิทธิอายุ 20 ปี", 90, 31, 200, 0);
            
            if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["IdCard"].ToString(), "")))
                _e.FillForm(HCSStaffUtil._myPDFFontBarcode, 24, 2, "*" + _dataRecorded["IdCard"] + "*", 579, 38, 245, 0);
        }

        public void GetRAPatientRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 5, 1);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 1 ? _dataRecorded["IdCard"].ToString().Substring(0, 1) : ""), 35, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 2 ? _dataRecorded["IdCard"].ToString().Substring(1, 1) : ""), 56, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 3 ? _dataRecorded["IdCard"].ToString().Substring(2, 1) : ""), 77, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 4 ? _dataRecorded["IdCard"].ToString().Substring(3, 1) : ""), 98, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 5 ? _dataRecorded["IdCard"].ToString().Substring(4, 1) : ""), 119, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 6 ? _dataRecorded["IdCard"].ToString().Substring(5, 1) : ""), 140, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 7 ? _dataRecorded["IdCard"].ToString().Substring(6, 1) : ""), 161, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 8 ? _dataRecorded["IdCard"].ToString().Substring(7, 1) : ""), 182, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 9 ? _dataRecorded["IdCard"].ToString().Substring(8, 1) : ""), 203, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 10 ? _dataRecorded["IdCard"].ToString().Substring(9, 1) : ""), 224, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 11 ? _dataRecorded["IdCard"].ToString().Substring(10, 1) : ""), 245, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 12 ? _dataRecorded["IdCard"].ToString().Substring(11, 1) : ""), 266, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 13 ? _dataRecorded["IdCard"].ToString().Substring(12, 1) : ""), 287, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("N") ? "/" : ""), 324, 746, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("Y") ? "/" : ""), 379, 746, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(_dataRecorded["IntoleranceDetail"].ToString()) ? (_dataRecorded["IntoleranceDetail"].ToString()).Replace("\n", ", ") : ""), 314, 726, 249, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") ? "/" : ""), 83, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") ? "/" : ""), 120, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") ? "/" : ""), 154, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") ? "/" : ""), 203, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 237, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 271, 674, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), "")) ? _dataRecorded["TitleInitialsTH"].ToString() : Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), "")) : ""), 308, 673, 259, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), 110, 655, 193, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["LastName"].ToString(), ""), 338, 655, 231, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["FirstNameEN"].ToString(), ""), 138, 636, 116, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["MiddleNameEN"].ToString(), ""), 307, 636, 102, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["LastNameEN"].ToString(), ""), 451, 636, 119, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("ชาย") ? "/" : ""), 51, 618, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("หญิง") ? "/" : ""), 82, 618, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 1, Util.GetBlank(_dataRecorded["BirthDateOfDay"].ToString(), ""), 195, 617, 23, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 1, Util.GetBlank(_dataRecorded["BirthDateOfMonth"].ToString(), ""), 221, 617, 23, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 1, Util.GetBlank(_dataRecorded["BirthDateOfYear"].ToString(), ""), 243, 617, 30, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 1, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 286, 617, 37, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 381, 617, 78, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetBlank(_dataRecorded["CountryNameTHPermanentAddress"].ToString(), ""), 492, 617, 82, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") ? "/" : ""), 33, 554, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") ? "/" : ""), 33, 536, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") &&
                 !_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") ? "/" : ""), 33, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0,
                (!_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") &&
                !_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") ? Util.GetBlank(_dataRecorded["NationalityNameTH"].ToString(), "") : ""), 87, 516, 64, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") ? "/" : ""), 161, 554, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") ? "/" : ""), 161, 536, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? "/" : ""), 161, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? "/" : ""), 161, 498, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0,
                (!_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? Util.GetBlank(_dataRecorded["ReligionNameTH"].ToString(), "") : ""), 214, 497, 51, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("โสด") ? "/" : ""), 280, 554, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["MaritalStatusNameTH"].ToString().IndexOf("สมรส").Equals(-1) ? "/" : ""), 280, 536, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หย่าร้าง") ? "/" : ""), 280, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หม้าย") ? "/" : ""), 280, 498, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ประถมศึกษา").Equals(-1) ? "/" : ""), 364, 554, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("มัธยมศึกษาตอนต้น").Equals(-1) ? "/" : ""), 464, 554, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("มัธยมศึกษาตอนปลาย").Equals(-1) ? "/" : ""), 364, 536, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวช").Equals(-1) ||
                 !_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวส").Equals(-1) ||
                 !_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวท").Equals(-1) ? "/" : ""), 464, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาตรี").Equals(-1) ? "/" : ""), 364, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาโท").Equals(-1) ? "/" : ""), 464, 517, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาเอก").Equals(-1) ? "/" : ""), 364, 498, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (_dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ประถมศึกษา").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("มัธยมศึกษาตอนต้น").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("มัธยมศึกษาตอนปลาย").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวช").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวส").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปวท").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาตรี").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาโท").Equals(-1) &&
                 _dataRecorded["EducationalBackgroundNameTH"].ToString().IndexOf("ปริญญาเอก").Equals(-1) ? "/" : ""), 464, 498, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameMother"].ToString(), "")), 87, 479, 120, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameFather"].ToString(), "")), 257, 479, 129, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), ""), 115, 449, 270, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), ""), 44, 430, 35, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), ""), 95, 430, 118, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), ""), 240, 430, 147, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), ""), 76, 412, 140, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), ""), 260, 412, 125, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), ""), 58, 392, 159, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 1 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(0, 1) : ""), 286, 378, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 2 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(1, 1) : ""), 303, 378, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 3 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(2, 1) : ""), 319, 378, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 4 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(3, 1) : ""), 336, 378, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 5 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(4, 1) : ""), 352, 378, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddress"].ToString(), ""), 427, 440, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FaxNumberCurrentAddress"].ToString(), ""), 427, 421, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddress"].ToString(), ""), 427, 402, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["Email"].ToString(), ""), 427, 383, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 75, 351, 277, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RelationshipNameTH"].ToString(), ""), 407, 351, 118, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoCurrentAddressParent"].ToString(), ""), 115, 322, 270, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoCurrentAddressParent"].ToString(), ""), 44, 303, 35, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddressParent"].ToString(), ""), 95, 303, 118, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadCurrentAddressParent"].ToString(), ""), 240, 303, 146, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddressParent"].ToString(), ""), 76, 284, 140, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddressParent"].ToString(), ""), 260, 284, 125, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddressParent"].ToString(), ""), 58, 265, 159, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddressParent"].ToString(), "").Length >= 1 ? _dataRecorded["PostalCodeCurrentAddressParent"].ToString().Substring(0, 1) : ""), 286, 251, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddressParent"].ToString(), "").Length >= 2 ? _dataRecorded["PostalCodeCurrentAddressParent"].ToString().Substring(1, 1) : ""), 303, 251, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddressParent"].ToString(), "").Length >= 3 ? _dataRecorded["PostalCodeCurrentAddressParent"].ToString().Substring(2, 1) : ""), 319, 251, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddressParent"].ToString(), "").Length >= 4 ? _dataRecorded["PostalCodeCurrentAddressParent"].ToString().Substring(3, 1) : ""), 336, 251, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddressParent"].ToString(), "").Length >= 5 ? _dataRecorded["PostalCodeCurrentAddressParent"].ToString().Substring(4, 1) : ""), 352, 251, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddressParent"].ToString(), ""), 427, 313, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FaxNumberCurrentAddressParent"].ToString(), ""), 427, 293, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 427, 275, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["EmailParent"].ToString(), ""), 427, 256, 142, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, ("วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd"))), 392, 25, 180, 0);
        }

        public void GetSIPatientRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 6, 1);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 1 ? _dataRecorded["IdCard"].ToString().Substring(0, 1) : ""), 26, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 2 ? _dataRecorded["IdCard"].ToString().Substring(1, 1) : ""), 47, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 3 ? _dataRecorded["IdCard"].ToString().Substring(2, 1) : ""), 68, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 4 ? _dataRecorded["IdCard"].ToString().Substring(3, 1) : ""), 89, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 5 ? _dataRecorded["IdCard"].ToString().Substring(4, 1) : ""), 110, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 6 ? _dataRecorded["IdCard"].ToString().Substring(5, 1) : ""), 131, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 7 ? _dataRecorded["IdCard"].ToString().Substring(6, 1) : ""), 152, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 8 ? _dataRecorded["IdCard"].ToString().Substring(7, 1) : ""), 173, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 9 ? _dataRecorded["IdCard"].ToString().Substring(8, 1) : ""), 194, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 10 ? _dataRecorded["IdCard"].ToString().Substring(9, 1) : ""), 215, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 11 ? _dataRecorded["IdCard"].ToString().Substring(10, 1) : ""), 236, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 12 ? _dataRecorded["IdCard"].ToString().Substring(11, 1) : ""), 257, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 13 ? _dataRecorded["IdCard"].ToString().Substring(12, 1) : ""), 278, 727, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") ? "/" : ""), 353, 749, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") ? "/" : ""), 353, 728, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["NationalityNameTH"].ToString().Equals("อินเดีย") ? "/" : ""), 353, 708, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0,
                (!_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") &&
                 !_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") &&
                 !_dataRecorded["NationalityNameTH"].ToString().Equals("อินเดีย") ? "/" : ""), 314, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["NationalityNameTH"].ToString().Equals("ไทย") &&
                 !_dataRecorded["NationalityNameTH"].ToString().Equals("จีน") &&
                 !_dataRecorded["NationalityNameTH"].ToString().Equals("อินเดีย") ? Util.GetBlank(_dataRecorded["NationalityNameTH"].ToString(), "") : ""), 348, 686, 44, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["OriginNameTH"].ToString().Equals("ไทย") ? "/" : ""), 443, 749, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["OriginNameTH"].ToString().Equals("จีน") ? "/" : ""), 443, 728, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["OriginNameTH"].ToString().Equals("อินเดีย") ? "/" : ""), 443, 708, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0,
                (!_dataRecorded["OriginNameTH"].ToString().Equals("ไทย") &&
                 !_dataRecorded["OriginNameTH"].ToString().Equals("จีน") &&
                 !_dataRecorded["OriginNameTH"].ToString().Equals("อินเดีย") ? "/" : ""), 406, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["OriginNameTH"].ToString().Equals("ไทย") &&
                 !_dataRecorded["OriginNameTH"].ToString().Equals("จีน") &&
                 !_dataRecorded["OriginNameTH"].ToString().Equals("อินเดีย") ? Util.GetBlank(_dataRecorded["OriginNameTH"].ToString(), "") : ""), 442, 686, 44, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") ? "/" : ""), 532, 749, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") ? "/" : ""), 532, 728, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? "/" : ""), 532, 708, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0,
                (!_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? "/" : ""), 498, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["ReligionNameTH"].ToString().Equals("พุทธ") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("คริสต์") &&
                 !_dataRecorded["ReligionNameTH"].ToString().Equals("อิสลาม") ? Util.GetBlank(_dataRecorded["ReligionNameTH"].ToString(), "") : ""), 534, 686, 44, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") ? "/" : ""), 77, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") ? "/" : ""), 117, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") ? "/" : ""), 154, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") ? "/" : ""), 204, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 237, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 274, 665, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), "")) ? _dataRecorded["TitleInitialsTH"].ToString() : Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), "")) : ""), 310, 662, 259, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), 120, 656, 117, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LastName"].ToString(), ""), 275, 656, 129, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), 464, 656, 110, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName("", "", Util.GetBlank(_dataRecorded["FirstNameEN"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameEN"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameEN"].ToString(), "")), 115, 636, 460, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("ชาย") ? "/" : ""), 46, 604, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 18, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("หญิง") ? "/" : ""), 92, 604, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 196, 602, 98, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 312, 602, 44, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameFather"].ToString(), "")), 94, 593, 198, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameMother"].ToString(), "")), 378, 593, 197, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), ""), 133, 570, 95, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), ""), 241, 570, 45, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageCurrentAddress"].ToString(), ""), 317, 570, 67, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), ""), 37, 550, 154, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), ""), 216, 550, 165, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), ""), 70, 530, 120, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), ""), 238, 530, 144, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), ""), 51, 509, 170, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 1 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(0, 1) : ""), 298, 495, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 2 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(1, 1) : ""), 316, 495, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 3 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(2, 1) : ""), 333, 495, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 4 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(3, 1) : ""), 351, 495, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 5 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(4, 1) : ""), 368, 495, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddress"].ToString(), ""), 467, 570, 108, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddress"].ToString(), ""), 467, 550, 108, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FaxNumberCurrentAddress"].ToString(), ""), 467, 530, 108, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["Email"].ToString(), ""), 431, 509, 144, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 186, 485, 219, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RelationshipNameTH"].ToString(), ""), 461, 485, 74, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddressParent"].ToString(), ""), 75, 465, 109, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 251, 465, 134, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FaxNumberCurrentAddressParent"].ToString(), ""), 461, 465, 115, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, ("วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd"))), 394, 17, 180, 0);
        }

        public void GetTMPatientRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 7, 1);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["ProgramNameTH"].ToString(), ""), 480, 845, 91, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 11, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 469, 829, 103, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["StudentCode"].ToString().Equals("XXXXXXX") ? Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "") : ""), 495, 799, 77, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") ? "/" : ""), 54, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") ? "/" : ""), 92, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") ? "/" : ""), 129, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") ? "/" : ""), 177, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 212, 688, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), "")) ? _dataRecorded["TitleInitialsTH"].ToString() : Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), "")) : ""), 306, 703, 216, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 102, 684, 182, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["BirthDateOfDay"].ToString(), ""), 312, 684, 28, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util._longMonth[int.Parse(Util.GetBlank(_dataRecorded["BirthDateOfMonth"].ToString(), "")) - 1, 0], 356, 684, 60, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BirthDateOfYear"].ToString(), ""), 425, 684, 51, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 487, 684, 27, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["IdCard"].ToString(), ""), 150, 666, 108, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("โสด") ? "/" : ""), 344, 650, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (!_dataRecorded["MaritalStatusNameTH"].ToString().IndexOf("สมรส").Equals(-1) ? "/" : ""), 378, 650, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หย่าร้าง") ? "/" : ""), 419, 650, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หม้าย") ? "/" : ""), 452, 650, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("แยกกันอยู่") ? "/" : ""), 491, 650, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["NationalityNameTH"].ToString(), ""), 84, 647, 84, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ReligionNameTH"].ToString(), ""), 188, 647, 84, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 27, 0, "/", 286, 560, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 389, 570, 130, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), ""), 158, 524, 50, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), ""), 229, 524, 35, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), ""), 283, 524, 92, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), ""), 418, 524, 95, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 98, 505, 64, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 201, 505, 83, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 311, 505, 82, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PostalCodePermanentAddress"].ToString(), ""), 447, 505, 68, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), ""), 158, 486, 50, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), ""), 229, 486, 35, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), ""), 283, 486, 92, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), ""), 418, 486, 95, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), ""), 98, 467, 64, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), ""), 201, 467, 83, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), ""), 311, 467, 82, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), ""), 447, 467, 68, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddress"].ToString(), ""), 154, 440, 360, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameFather"].ToString(), "")), 141, 413, 143, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameMother"].ToString(), "")), 381, 413, 135, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 104, 375, 127, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RelationshipNameTH"].ToString(), ""), 280, 375, 57, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 415, 375, 100, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, ("วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd"))), 368, 32, 180, 0);
        }

        public void GetGJPatientRegisForm(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 8, 1);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") ? "/" : ""), 132, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") ? "/" : ""), 182, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") ? "/" : ""), 233, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") ? "/" : ""), 300, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 357, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? "/" : ""), 409, 754, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["TitleFullNameTH"].ToString().Equals("นาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นาง") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("นางสาว") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กชาย") &&
                 !_dataRecorded["TitleFullNameTH"].ToString().Equals("เด็กหญิง") ? (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), "")) ? _dataRecorded["TitleInitialsTH"].ToString() : Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), "")) : ""), 463, 768, 102, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 142, 747, 184, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("ชาย") ? "/" : ""), 399, 733, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["GenderFullNameTH"].ToString().Equals("หญิง") ? "/" : ""), 458, 733, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsEN"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameEN"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameEN"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameEN"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameEN"].ToString(), "")), 139, 727, 187, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 1 ? _dataRecorded["IdCard"].ToString().Substring(0, 1) : ""), 64, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 2 ? _dataRecorded["IdCard"].ToString().Substring(1, 1) : ""), 90, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 3 ? _dataRecorded["IdCard"].ToString().Substring(2, 1) : ""), 108, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 4 ? _dataRecorded["IdCard"].ToString().Substring(3, 1) : ""), 126, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 5 ? _dataRecorded["IdCard"].ToString().Substring(4, 1) : ""), 143, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 6 ? _dataRecorded["IdCard"].ToString().Substring(5, 1) : ""), 170, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 7 ? _dataRecorded["IdCard"].ToString().Substring(6, 1) : ""), 188, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 8 ? _dataRecorded["IdCard"].ToString().Substring(7, 1) : ""), 206, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 9 ? _dataRecorded["IdCard"].ToString().Substring(8, 1) : ""), 224, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 10 ? _dataRecorded["IdCard"].ToString().Substring(9, 1) : ""), 242, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 11 ? _dataRecorded["IdCard"].ToString().Substring(10, 1) : ""), 269, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 12 ? _dataRecorded["IdCard"].ToString().Substring(11, 1) : ""), 288, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (Util.GetBlank(_dataRecorded["IdCard"].ToString(), "").Length >= 13 ? _dataRecorded["IdCard"].ToString().Substring(12, 1) : ""), 315, 676, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("โสด") ? "/" : ""), 348, 692, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (!_dataRecorded["MaritalStatusNameTH"].ToString().IndexOf("สมรส").Equals(-1) ? "/" : ""), 417, 692, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("แยกกันอยู่") ? "/" : ""), 494, 692, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หย่าร้าง") ? "/" : ""), 348, 672, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["MaritalStatusNameTH"].ToString().Equals("หม้าย") ? "/" : ""), 417, 672, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 163, 648, 96, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 297, 648, 31, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 151, 644, 182, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameFather"].ToString(), "")), 131, 624, 202, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameMother"].ToString(), "")), 144, 604, 189, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["OriginNameTH"].ToString(), ""), 401, 663, 44, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["NationalityNameTH"].ToString(), ""), 517, 663, 48, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ReligionNameTH"].ToString(), ""), 405, 643, 40, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BloodTypeNameTH"].ToString(), ""), 524, 643, 41, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), ""), 113, 547, 102, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), ""), 315, 547, 96, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), ""), 449, 547, 116, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), ""), 105, 528, 110, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 306, 528, 105, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 486, 528, 82, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 111, 507, 104, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PostalCodePermanentAddress"].ToString(), ""), 310, 507, 101, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberPermanentAddress"].ToString(), ""), 133, 488, 82, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberPermanentAddress"].ToString(), ""), 315, 488, 96, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["Email"].ToString(), ""), 457, 488, 112, 28);

            if (_dataRecorded["HouseNoCurrentAddress"].ToString().Equals(_dataRecorded["HouseNoPermanentAddress"].ToString()) &&
                _dataRecorded["VillageNoCurrentAddress"].ToString().Equals(_dataRecorded["VillageNoPermanentAddress"].ToString()) &&
                _dataRecorded["LaneAlleyCurrentAddress"].ToString().Equals(_dataRecorded["LaneAlleyPermanentAddress"].ToString()) &&
                _dataRecorded["RoadCurrentAddress"].ToString().Equals(_dataRecorded["RoadPermanentAddress"].ToString()) &&
                _dataRecorded["SubDistrictNameTHCurrentAddress"].ToString().Equals(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString()) &&
                _dataRecorded["DistrictNameTHCurrentAddress"].ToString().Equals(_dataRecorded["DistrictNameTHPermanentAddress"].ToString()) &&
                _dataRecorded["ProvinceNameTHCurrentAddress"].ToString().Equals(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString()) &&
                _dataRecorded["PostalCodeCurrentAddress"].ToString().Equals(_dataRecorded["PostalCodePermanentAddress"].ToString()) &&
                _dataRecorded["PhoneNumberCurrentAddress"].ToString().Equals(_dataRecorded["PhoneNumberPermanentAddress"].ToString()))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, "/", 182, 454, 8, 0);
            else
            {
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, "/", 413, 454, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), ""), 113, 449, 102, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), ""), 315, 449, 96, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), ""), 449, 449, 116, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), ""), 105, 430, 110, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), ""), 306, 430, 105, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), ""), 486, 430, 82, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), ""), 111, 410, 104, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), ""), 310, 410, 101, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddress"].ToString(), ""), 486, 410, 82, 28);
            }

            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 256, 389, 313, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["RelationshipNameTH"].ToString().Equals("บิดา") ? "/" : ""), 201, 357, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["RelationshipNameTH"].ToString().Equals("มารดา") ? "/" : ""), 266, 357, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0,
                (!_dataRecorded["RelationshipNameTH"].ToString().Equals("บิดา") &&
                 !_dataRecorded["RelationshipNameTH"].ToString().Equals("มารดา") ? "/" : ""), 441, 338, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                (!_dataRecorded["RelationshipNameTH"].ToString().Equals("บิดา") &&
                !_dataRecorded["RelationshipNameTH"].ToString().Equals("มารดา") ? Util.GetBlank(_dataRecorded["RelationshipNameTH"].ToString(), "") : ""), 499, 351, 70, 28);
            
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, "/", 266, 336, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, "/", 381, 317, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddressParent"].ToString(), ""), 291, 294, 74, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 467, 294, 94, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("N") ? "/" : ""), 376, 240, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("Y") ? "/" : ""), 375, 222, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["IntoleranceDetail"].ToString(), "")) ? (_dataRecorded["IntoleranceDetail"].ToString()).Replace("\n", ", ") : ""), 373, 215, 192, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["DiseasesStatus"].ToString().Equals("N") ? "/" : ""), 375, 160, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, (_dataRecorded["DiseasesStatus"].ToString().Equals("Y") ? "/" : ""), 375, 143, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, (_dataRecorded["DiseasesStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["DiseasesDetail"].ToString(), "")) ? (_dataRecorded["DiseasesDetail"].ToString()).Replace("\n", ", ") : ""), 373, 136, 192, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, "วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd")), 381, 17, 180, 0);
        }

        public void GetKN001Form(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            bool _personalIdentity = false;
            
            _e.PDFAddTemplate("pdf", 9, 1);

            if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["StudentPicture"].ToString(), "")))
                _e.FillFormImage(0, "url", _dataRecorded["StudentPicture"].ToString(), 30, 780, 105, 123);

            if (!_dataRecorded["StudentCode"].ToString().Equals("XXXXXXX"))
            {
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(0, 1), 360, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(1, 1), 374, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(2, 1), 388, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(3, 1), 402, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(4, 1), 417, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(5, 1), 431, 789, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(6, 1), 445, 789, 8, 0);
            }

            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(0, 1), 471, 789, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(1, 1), 486, 789, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(2, 1), 498, 789, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(3, 1), 514, 789, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(4, 1), 543, 789, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 395, 717, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, Util.GetBlank(_dataRecorded["FacultyNameTH"].ToString(), ""), 427, 680, 116, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 168, 625, 260, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util.GetBlank(_dataRecorded["Age"].ToString(), ""), 452, 625, 85, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BirthDateTH"].ToString(), ""), 90, 603, 125, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["NationalityNameTH"].ToString(), ""), 250, 603, 145, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ReligionNameTH"].ToString(), ""), 426, 603, 145, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0,
                ((!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), "")) ? _dataRecorded["HouseNoCurrentAddress"].ToString() : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), "")) ? (" หมู่ " + _dataRecorded["VillageNoCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), "")) ? (" ซ." + _dataRecorded["LaneAlleyCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), "")) ? (" ถ." + _dataRecorded["RoadCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), "")) ? (" ต." + _dataRecorded["SubDistrictNameTHCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), "")) ? (" อ." + _dataRecorded["DistrictNameTHCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), "")) ? (" จ." + _dataRecorded["ProvinceNameTHCurrentAddress"].ToString()) : "")), 84, 581, 203, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["PhoneNumberCurrentAddress"].ToString(), ""), 339, 581, 90, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddress"].ToString(), ""), 488, 581, 60, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0,
                ((!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["HouseNoPermanentAddress"].ToString(), "")) ? _dataRecorded["HouseNoPermanentAddress"].ToString() : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["VillageNoPermanentAddress"].ToString(), "")) ? (" หมู่ " + _dataRecorded["VillageNoPermanentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["LaneAlleyPermanentAddress"].ToString(), "")) ? (" ซ." + _dataRecorded["LaneAlleyPermanentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["RoadPermanentAddress"].ToString(), "")) ? (" ถ." + _dataRecorded["RoadPermanentAddress"].ToString()) : "")), 108, 559, 106, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["SubDistrictNameTHPermanentAddress"].ToString(), ""), 240, 559, 83, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["DistrictNameTHPermanentAddress"].ToString(), ""), 350, 559, 80, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["ProvinceNameTHPermanentAddress"].ToString(), ""), 459, 559, 83, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHFather"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameFather"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameFather"].ToString(), "")), 65, 536, 150, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, (_dataRecorded["AliveFather"].ToString().Equals("Y") ? "X" : ""), 223, 530, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, (_dataRecorded["AliveFather"].ToString().Equals("N") ? "X" : ""), 269, 530, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressFather"].ToString(), ""), 446, 536, 96, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHMother"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameMother"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameMother"].ToString(), "")), 74, 514, 141, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, (_dataRecorded["AliveMother"].ToString().Equals("Y") ? "X" : ""), 223, 508, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, (_dataRecorded["AliveMother"].ToString().Equals("N") ? "X" : ""), 269, 508, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressMother"].ToString(), ""), 446, 514, 96, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 85, 492, 130, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["RelationshipNameTH"].ToString(), ""), 267, 492, 93, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 446, 492, 96, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTHParent"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleNameParent"].ToString(), ""), Util.GetBlank(_dataRecorded["LastNameParent"].ToString(), "")), 83, 447, 275, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["MobileNumberCurrentAddressParent"].ToString(), ""), 446, 447, 96, 28);

            if (_dataRecorded["TravelAbroadStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["TravelAbroadDetail"].ToString(), "")))
            {
                string[] _travelAbroadArray = _dataRecorded["TravelAbroadDetail"].ToString().Split(';');
                string[] _travelAbroadDetail = _travelAbroadArray[0].Split(',');

                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (_travelAbroadDetail[0].Split(':'))[0], 92, 366, 232, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, (int.Parse((_travelAbroadDetail[1].Split('/'))[0])).ToString(), 415, 367, 29, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, Util._longMonth[int.Parse((_travelAbroadDetail[1].Split('/'))[1]) - 1, 1], 465, 367, 40, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, (int.Parse((_travelAbroadDetail[1].Split('/'))[2]) + 543).ToString(), 521, 367, 30, 0);
            }

            if (_dataRecorded["ImpairmentsStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ImpairmentsDetail"].ToString(), "")))
            {
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, _dataRecorded["ImpairmentsNameTH"].ToString(), 112, 358, 141, 28);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, _dataRecorded["ImpairmentsEquipment"].ToString(), 331, 358, 138, 28);
            }

            if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["BodyMassDetail"].ToString(), "")))
            {
                string[] _bodyMassArray = _dataRecorded["BodyMassDetail"].ToString().Split(';');
                string[] _bodyMassDetail = _bodyMassArray[0].Split(':');

                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, _bodyMassDetail[0], 71, 273, 39, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 1, _bodyMassDetail[1], 171, 273, 46, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, _bodyMassDetail[2], 117, 251, 172, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0,
                    (int.Parse((_bodyMassDetail[3].Split('/'))[0]).ToString() + " " +
                     Util._longMonth[int.Parse((_bodyMassDetail[3].Split('/'))[1]) - 1, 0] + " " +
                     (int.Parse((_bodyMassDetail[3].Split('/'))[2]) + 543).ToString()), 138, 234, 117, 0);
            }

            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.GetBlank(_dataRecorded["BloodTypeNameTH"].ToString(), ""), 70, 207, 75, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, (_dataRecorded["DiseasesStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["DiseasesDetail"].ToString(), "")) ? (_dataRecorded["DiseasesDetail"].ToString()).Replace("\n", ", ") : ""), 195, 221, 102, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, (_dataRecorded["IntoleranceStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["IntoleranceDetail"].ToString(), "")) ? (_dataRecorded["IntoleranceDetail"].ToString()).Replace("\n", ", ") : ""), 108, 198, 184, 28);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 12, 0, (_dataRecorded["AilHistoryFamilyStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["AilHistoryFamilyDetail"].ToString(), "")) ? (_dataRecorded["AilHistoryFamilyDetail"].ToString()).Replace("\n", ", ") : ""), 37, 137, 254, 28);

            if (_personalIdentity.Equals(false) &&
                (!_dataRecorded["OccupationNameTHFather"].ToString().IndexOf("รับราชการ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHMother"].ToString().IndexOf("รับราชการ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHParent"].ToString().IndexOf("รับราชการ").Equals(-1)))
            {
                _personalIdentity = true;
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 323, 279, 8, 0);
            }

            if (_personalIdentity.Equals(false) &&
                (!_dataRecorded["OccupationNameTHFather"].ToString().IndexOf("พนักงานรัฐวิสาหกิจ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHMother"].ToString().IndexOf("พนักงานรัฐวิสาหกิจ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHParent"].ToString().IndexOf("พนักงานรัฐวิสาหกิจ").Equals(-1)))
            {
                _personalIdentity = true;
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 323, 233, 8, 0);
            }

            if (_personalIdentity.Equals(false) &&
                (!_dataRecorded["OccupationNameTHFather"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHMother"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1) ||
                 !_dataRecorded["OccupationNameTHParent"].ToString().IndexOf("พนักงาน / ลูกจ้าง ส่วนราชการ").Equals(-1)))
            {
                _personalIdentity = true;
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 323, 256, 8, 0);
            }

            if (_personalIdentity.Equals(false) &&
                ((!String.IsNullOrEmpty(_dataRecorded["OccupationNameTHFather"].ToString()) && _dataRecorded["OccupationNameTHFather"].ToString().IndexOf("รับราชการ").Equals(-1)) ||
                 (!String.IsNullOrEmpty(_dataRecorded["OccupationNameTHMother"].ToString()) && _dataRecorded["OccupationNameTHMother"].ToString().IndexOf("รับราชการ").Equals(-1)) ||
                 (!String.IsNullOrEmpty(_dataRecorded["OccupationNameTHParent"].ToString()) && _dataRecorded["OccupationNameTHParent"].ToString().IndexOf("รับราชการ").Equals(-1))))
            {
                _personalIdentity = true;
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 323, 190, 8, 0);
            }

            if (_dataRecorded["ImpairmentsStatus"].ToString().Equals("Y") && !String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ImpairmentsDetail"].ToString(), "")))
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 25, 0, "X", 323, 168, 8, 0);
            
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 14, 0, Util.ThaiLongDate(Util.CurrentDate("yyyy/MM/dd")), 400, 109, 103, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, "วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd")), 381, 25, 180, 0);
        }

        public void GetKN002Form(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 10, 1);

            if (!_dataRecorded["StudentCode"].ToString().Equals("XXXXXXX"))
            {
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(0, 1), 110, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(1, 1), 124, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(2, 1), 138, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(3, 1), 152, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(4, 1), 167, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(5, 1), 181, 777, 8, 0);
                _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["StudentCode"].ToString(), "").Substring(6, 1), 195, 777, 8, 0);
            }

            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(0, 1), 305, 777, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(1, 1), 320, 777, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(2, 1), 332, 777, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(3, 1), 347, 777, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, Util.GetBlank(_dataRecorded["ProgramCode"].ToString(), "").Substring(4, 1), 377, 777, 8, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontNormal, 11, 2, "วันที่พิมพ์ " + Util.ConvertDateTH(Util.CurrentDate("yyyy/MM/dd")), 376, 25, 180, 0);
        }

        public void GetKN003Form(Dictionary<string, object> _dataRecorded, ExportToPDF _e)
        {
            _e.PDFAddTemplate("pdf", 11, 2);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, Util.GetFullName(Util.GetBlank(_dataRecorded["TitleInitialsTH"].ToString(), ""), Util.GetBlank(_dataRecorded["TitleFullNameTH"].ToString(), ""), Util.GetBlank(_dataRecorded["FirstName"].ToString(), ""), Util.GetBlank(_dataRecorded["MiddleName"].ToString(), ""), Util.GetBlank(_dataRecorded["LastName"].ToString(), "")), 79, 490, 279, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0,
                ((!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["HouseNoCurrentAddress"].ToString(), "")) ? _dataRecorded["HouseNoCurrentAddress"].ToString() : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["VillageNoCurrentAddress"].ToString(), "")) ? (" หมู่ " + _dataRecorded["VillageNoCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["LaneAlleyCurrentAddress"].ToString(), "")) ? (" ซ." + _dataRecorded["LaneAlleyCurrentAddress"].ToString()) : "") +
                 (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["RoadCurrentAddress"].ToString(), "")) ? (" ถ." + _dataRecorded["RoadCurrentAddress"].ToString()) : "")), 89, 469, 400, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["SubDistrictNameTHCurrentAddress"].ToString(), "")) ? (" ต." + _dataRecorded["SubDistrictNameTHCurrentAddress"].ToString()) : ""), 99, 449, 259, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["DistrictNameTHCurrentAddress"].ToString(), "")) ? (" อ." + _dataRecorded["DistrictNameTHCurrentAddress"].ToString()) : ""), 109, 429, 249, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 15, 0, (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ProvinceNameTHCurrentAddress"].ToString(), "")) ? (" จ." + _dataRecorded["ProvinceNameTHCurrentAddress"].ToString()) : ""), 119, 408, 239, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 20, 1, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 1 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(0, 1) : ""), 180, 386, 13, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 20, 1, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 2 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(1, 1) : ""), 197, 386, 13, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 20, 1, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 3 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(2, 1) : ""), 214, 386, 13, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 20, 1, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 4 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(3, 1) : ""), 230, 386, 13, 0);
            _e.FillForm(HCSStaffUtil._myPDFFontBold, 20, 0, (Util.GetBlank(_dataRecorded["PostalCodeCurrentAddress"].ToString(), "").Length >= 5 ? _dataRecorded["PostalCodeCurrentAddress"].ToString().Substring(4, 1) : ""), 248, 386, 13, 0);

            if (!String.IsNullOrEmpty(Util.GetBlank(_dataRecorded["ProgramAddress"].ToString(), "")))
            {
                string[] _programAddressArray = _dataRecorded["ProgramAddress"].ToString().Split('&');
                int _col = 380;
                int _row = 225;

                for (int _i = 0; _i < _programAddressArray.GetLength(0); _i++)
                {
                    _e.FillForm(HCSStaffUtil._myPDFFontBold, 16, 0, _programAddressArray[_i], _col, _row, 363, 0);
                    _col = _col + 10;
                    _row = _row - 22;
                }
            }

        }
    }
}