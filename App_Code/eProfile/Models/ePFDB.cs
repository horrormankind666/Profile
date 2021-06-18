/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๘/๐๙/๒๕๕๗>
Modify date : <๑๖/๐๖/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการจัดการข้อมูลในฐานข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class ePFDB
{
    public static List<string> GetListText(string _lang, string _fileName)
    {
        List<string> _ls = File.ReadAllLines(HttpContext.Current.Server.MapPath("../../../Module/Operation/eProfile/Important/" + _lang + "/" + _fileName)).ToList();

        return _ls;
    }

    public static Dictionary<string, object> ActionSave(HttpContext _c, Dictionary<string, object> _infoLogin)
    {
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        DataSet _ds = new DataSet();
        DataRow _dr;
        string _page = _c.Request["page"];
        string _action = String.Empty;
        string _personId = _infoLogin["PersonId"].ToString();
        string _personIdFather = String.Empty;
        string _personIdMother = String.Empty;
        string _personIdParent = String.Empty;
        int _recordCount = 0;
        int _saveError = 0;
        bool _actionSave = true;
        bool _chkSaveError = true;

        try
        {
            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSTALENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            {
                _personIdFather = _c.Request["personidfather"];
                _personIdMother = _c.Request["personidmother"];
                _personIdParent = _c.Request["personidparent"];

                _personId = ePFStudentRecordsUtil.GetValuePersonIdByPage(_page, _personId, _personIdFather, _personIdMother, _personIdParent);
                _actionSave = ePFStudentRecordsUtil.GetValueActionSaveStudentRecordsByPage(_page, _personIdFather, _personIdMother, _personIdParent);
            }

            if (_page.Equals(ePFUtil.PAGE_MSENT_MAIN))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetConsent",
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@consentField", _c.Request["consentField"]),
                        new SqlParameter("@actionBy", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@actionIP", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perPerson"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetPerson",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@id", _personId),
                        new SqlParameter("@idCard", _c.Request["idcard"]),
                        new SqlParameter("@idCardIssueDate", _c.Request["idcardissuedate"]),
                        new SqlParameter("@idCardExpiryDate", _c.Request["idcardexpirydate"]),
                        new SqlParameter("@titlePrefix", _c.Request["titleprefix"]),
                        new SqlParameter("@firstName", _c.Request["firstname"]),
                        new SqlParameter("@middleName", _c.Request["middlename"]),
                        new SqlParameter("@lastName", _c.Request["lastname"]),
                        new SqlParameter("@firstNameEN", _c.Request["firstnameen"]),
                        new SqlParameter("@middleNameEN", _c.Request["middlenameen"]),
                        new SqlParameter("@lastNameEN", _c.Request["lastnameen"]),
                        new SqlParameter("@gender", _c.Request["gender"]),
                        new SqlParameter("@alive", _c.Request["alive"]),
                        new SqlParameter("@birthDate", _c.Request["birthdate"]),
                        new SqlParameter("@country", _c.Request["country"]),
                        new SqlParameter("@nationality", _c.Request["nationality"]),
                        new SqlParameter("@origin", _c.Request["origin"]),
                        new SqlParameter("@religion", _c.Request["religion"]),
                        new SqlParameter("@bloodType", _c.Request["bloodtype"]),
                        new SqlParameter("@maritalStatus", _c.Request["maritalstatus"]),
                        new SqlParameter("@educationalBackground", _c.Request["educationalbackground"]),
                        new SqlParameter("@email", _c.Request["email"]),
                        new SqlParameter("@brotherhoodNumber", _c.Request["brotherhoodnumber"]),
                        new SqlParameter("@childhoodNumber", _c.Request["childhoodnumber"]),
                        new SqlParameter("@studyhoodNumber", _c.Request["studyhoodnumber"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perAddress"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetAddress",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@countryPermanent", _c.Request["countrypermanent"]),
                        new SqlParameter("@villagePermanent", _c.Request["villagepermanent"]),
                        new SqlParameter("@noPermanent", _c.Request["nopermanent"]),
                        new SqlParameter("@mooPermanent", _c.Request["moopermanent"]),
                        new SqlParameter("@soiPermanent", _c.Request["soipermanent"]),
                        new SqlParameter("@roadPermanent", _c.Request["roadpermanent"]),
                        new SqlParameter("@subdistrictPermanent", _c.Request["subdistrictpermanent"]),
                        new SqlParameter("@districtPermanent", _c.Request["districtpermanent"]),
                        new SqlParameter("@provincePermanent", _c.Request["provincepermanent"]),
                        new SqlParameter("@zipCodePermanent", _c.Request["zipcodepermanent"]),
                        new SqlParameter("@phoneNumberPermanent", _c.Request["phonenumberpermanent"]),
                        new SqlParameter("@mobileNumberPermanent", _c.Request["mobilenumberpermanent"]),
                        new SqlParameter("@faxNumberPermanent", _c.Request["faxnumberpermanent"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perAddress"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetAddress",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@countryCurrent", _c.Request["countrycurrent"]),
                        new SqlParameter("@villageCurrent", _c.Request["villagecurrent"]),
                        new SqlParameter("@noCurrent", _c.Request["nocurrent"]),
                        new SqlParameter("@mooCurrent", _c.Request["moocurrent"]),
                        new SqlParameter("@soiCurrent", _c.Request["soicurrent"]),
                        new SqlParameter("@roadCurrent", _c.Request["roadcurrent"]),
                        new SqlParameter("@subdistrictCurrent", _c.Request["subdistrictcurrent"]),
                        new SqlParameter("@districtCurrent", _c.Request["districtcurrent"]),
                        new SqlParameter("@provinceCurrent", _c.Request["provincecurrent"]),
                        new SqlParameter("@zipCodeCurrent", _c.Request["zipcodecurrent"]),
                        new SqlParameter("@phoneNumberCurrent", _c.Request["phonenumbercurrent"]),
                        new SqlParameter("@mobileNumberCurrent", _c.Request["mobilenumbercurrent"]),
                        new SqlParameter("@faxNumberCurrent", _c.Request["faxnumbercurrent"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perEducation"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEducation",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@countryPrimarySchool", _c.Request["countryprimaryschool"]),
                        new SqlParameter("@provincePrimarySchool", _c.Request["provinceprimaryschool"]),
                        new SqlParameter("@primarySchoolName", _c.Request["primaryschoolname"]),
                        new SqlParameter("@primarySchoolYearAttended", _c.Request["primaryschoolyearattended"]),
                        new SqlParameter("@primarySchoolYearGraduate", _c.Request["primaryschoolyeargraduate"]),
                        new SqlParameter("@primarySchoolGPA", _c.Request["primarySchoolgpa"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perEducation"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEducation",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@countryJuniorHighSchool", _c.Request["countryjuniorhighschool"]),
                        new SqlParameter("@provinceJuniorHighSchool", _c.Request["provincejuniorhighschool"]),
                        new SqlParameter("@juniorHighSchoolName", _c.Request["juniorhighschoolname"]),
                        new SqlParameter("@juniorHighSchoolYearAttended", _c.Request["juniorhighschoolyearattended"]),
                        new SqlParameter("@juniorHighSchoolYearGraduate", _c.Request["juniorhighschoolyeargraduate"]),
                        new SqlParameter("@juniorHighSchoolGPA", _c.Request["juniorhighschoolgpa"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perEducation"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEducation",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@countryHighSchool", _c.Request["countryhighschool"]),
                        new SqlParameter("@provinceHighSchool", _c.Request["provincehighschool"]),
                        new SqlParameter("@highSchoolName", _c.Request["highschoolname"]),
                        new SqlParameter("@highSchoolStudentId", _c.Request["highschoolstudentid"]),
                        new SqlParameter("@educationalMajorHighSchool", _c.Request["educationalmajorhighschool"]),
                        new SqlParameter("@educationalMajorOtherHighSchool", _c.Request["educationalmajorotherhighschool"]),
                        new SqlParameter("@highSchoolYearAttended", _c.Request["highschoolyearattended"]),
                        new SqlParameter("@highSchoolYearGraduate", _c.Request["highschoolyeargraduate"]),
                        new SqlParameter("@highSchoolGPA", _c.Request["highschoolgpa"]),
                        new SqlParameter("@educationalBackgroundHighSchool", _c.Request["educationalbackgroundhighschool"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perEducation"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEducation",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@educationalBackground", _c.Request["educationalbackground"]),
                        new SqlParameter("@graduateBy", _c.Request["graduateby"]),
                        new SqlParameter("@graduateBySchoolName", _c.Request["graduatebyschoolname"]),
                        new SqlParameter("@entranceTime", _c.Request["entrancetime"]),
                        new SqlParameter("@studentIs", _c.Request["studentis"]),
                        new SqlParameter("@studentIsUniversity", _c.Request["studentisuniversity"]),
                        new SqlParameter("@studentIsFaculty", _c.Request["studentisfaculty"]),
                        new SqlParameter("@studentIsProgram", _c.Request["studentisprogram"]),
                        new SqlParameter("@entranceType", _c.Request["entrancetype"]),
                        new SqlParameter("@admissionRanking", _c.Request["admissionranking"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perEducation"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEducation",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@scoreONET01", _c.Request["scoreonet01"]),
                        new SqlParameter("@scoreONET02", _c.Request["scoreonet02"]),
                        new SqlParameter("@scoreONET03", _c.Request["scoreonet03"]),
                        new SqlParameter("@scoreONET04", _c.Request["scoreonet04"]),
                        new SqlParameter("@scoreONET05", _c.Request["scoreonet05"]),
                        new SqlParameter("@scoreONET06", _c.Request["scoreonet06"]),
                        new SqlParameter("@scoreONET07", _c.Request["scoreonet07"]),
                        new SqlParameter("@scoreONET08", _c.Request["scoreonet08"]),
                        new SqlParameter("@scoreANET11", _c.Request["scoreanet11"]),
                        new SqlParameter("@scoreANET12", _c.Request["scoreanet12"]),
                        new SqlParameter("@scoreANET13", _c.Request["scoreanet13"]),
                        new SqlParameter("@scoreANET14", _c.Request["scoreanet14"]),
                        new SqlParameter("@scoreANET15", _c.Request["scoreanet15"]),
                        new SqlParameter("@scoreGAT85", _c.Request["scoregat85"]),
                        new SqlParameter("@scorePAT71", _c.Request["scorepat71"]),
                        new SqlParameter("@scorePAT72", _c.Request["scorepat72"]),
                        new SqlParameter("@scorePAT73", _c.Request["scorepat73"]),
                        new SqlParameter("@scorePAT74", _c.Request["scorepat74"]),
                        new SqlParameter("@scorePAT75", _c.Request["scorepat75"]),
                        new SqlParameter("@scorePAT76", _c.Request["scorepat76"]),
                        new SqlParameter("@scorePAT77", _c.Request["scorepat77"]),
                        new SqlParameter("@scorePAT78", _c.Request["scorepat78"]),
                        new SqlParameter("@scorePAT79", _c.Request["scorepat79"]),
                        new SqlParameter("@scorePAT80", _c.Request["scorepat80"]),
                        new SqlParameter("@scorePAT81", _c.Request["scorepat81"]),
                        new SqlParameter("@scorePAT82", _c.Request["scorepat82"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSTALENT_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perActivity"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetActivity",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@sportsmanStatus", _c.Request["sportsmanstatus"]),
                        new SqlParameter("@sportsmanDetail", _c.Request["sportsmandetail"]),
                        new SqlParameter("@specialistStatus", _c.Request["specialiststatus"]),
                        new SqlParameter("@specialistSportStatus", _c.Request["specialistsportstatus"]),
                        new SqlParameter("@specialistSportDetail", _c.Request["specialistsportdetail"]),
                        new SqlParameter("@specialistArtStatus", _c.Request["specialistartstatus"]),
                        new SqlParameter("@specialistArtDetail", _c.Request["specialistartdetail"]),
                        new SqlParameter("@specialistTechnicalStatus", _c.Request["specialisttechnicalstatus"]),
                        new SqlParameter("@specialistTechnicalDetail", _c.Request["specialisttechnicaldetail"]),
                        new SqlParameter("@specialistOtherStatus", _c.Request["specialistotherstatus"]),
                        new SqlParameter("@specialistOtherDetail", _c.Request["specialistotherdetail"]),
                        new SqlParameter("@activityStatus", _c.Request["activitystatus"]),
                        new SqlParameter("@activityDetail", _c.Request["activitydetail"]),
                        new SqlParameter("@rewardStatus", _c.Request["rewardstatus"]),
                        new SqlParameter("@rewardDetail", _c.Request["rewarddetail"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perHealthy"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetHealthy",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@bodyMassDetail", _c.Request["bodymassdetail"]),
                        new SqlParameter("@intoleranceStatus", _c.Request["intolerancestatus"]),
                        new SqlParameter("@intoleranceDetail", _c.Request["intolerancedetail"]),
                        new SqlParameter("@diseasesStatus", _c.Request["diseasesstatus"]),
                        new SqlParameter("@diseasesDetail", _c.Request["diseasesdetail"]),
                        new SqlParameter("@ailHistoryFamilyStatus", _c.Request["ailhistoryfamilystatus"]),
                        new SqlParameter("@ailHistoryFamilyDetail", _c.Request["ailhistoryfamilydetail"]),
                        new SqlParameter("@travelAbroadStatus", _c.Request["travelabroadstatus"]),
                        new SqlParameter("@travelAbroadDetail", _c.Request["travelabroaddetail"]),
                        new SqlParameter("@impairmentsStatus", _c.Request["impairmentsstatus"]),
                        new SqlParameter("@impairments", _c.Request["impairments"]),
                        new SqlParameter("@impairmentsEquipment", _c.Request["impairmentsequipment"]),
                        new SqlParameter("@idCardPWD", _c.Request["idcardpwd"]),
                        new SqlParameter("@idCardPWDIssueDate", _c.Request["idcardpwdissuedate"]),
                        new SqlParameter("@idCardPWDExpiryDate", _c.Request["idcardpwdexpirydate"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE) ||
                _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perWork"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetWork",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@occupation", _c.Request["occupation"]),
                        new SqlParameter("@agency", _c.Request["agency"]),
                        new SqlParameter("@agencyOther", _c.Request["agencyother"]),
                        new SqlParameter("@workplace", _c.Request["workplace"]),
                        new SqlParameter("@position", _c.Request["position"]),
                        new SqlParameter("@telephone", _c.Request["telephone"]),
                        new SqlParameter("@salary", _c.Request["salary"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_personId);
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perFinancial"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetFinancial",
                        new SqlParameter("@action", _action),
                        new SqlParameter("@personId", _personId),
                        new SqlParameter("@scholarshipFirstBachelor", _c.Request["scholarshipfirstbachelor"]),
                        new SqlParameter("@scholarshipFirstBachelorFrom", _c.Request["scholarshipfirstbachelorfrom"]),
                        new SqlParameter("@scholarshipFirstBachelorName", _c.Request["scholarshipfirstbachelorname"]),
                        new SqlParameter("@scholarshipFirstBachelorMoney", _c.Request["scholarshipfirstbachelormoney"]),
                        new SqlParameter("@scholarshipBachelor", _c.Request["scholarshipbachelor"]),
                        new SqlParameter("@scholarshipBachelorFrom", _c.Request["scholarshipbachelorfrom"]),
                        new SqlParameter("@scholarshipBachelorName", _c.Request["scholarshipbachelorname"]),
                        new SqlParameter("@scholarshipBachelorMoney", _c.Request["scholarshipbachelormoney"]),
                        new SqlParameter("@worked", _c.Request["worked"]),
                        new SqlParameter("@salary", _c.Request["salary"]),
                        new SqlParameter("@workplace", _c.Request["workplace"]),
                        new SqlParameter("@gotMoneyFrom", _c.Request["gotmoneyfrom"]),
                        new SqlParameter("@gotMoneyFromOther", _c.Request["gotmoneyfromother"]),
                        new SqlParameter("@gotMoneyPerMonth", _c.Request["gotmoneypermonth"]),
                        new SqlParameter("@costPerMonth", _c.Request["costpermonth"]),
                        new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                        new SqlParameter("@ip", Util.GetIP())
                    );
                }
            }

            if (_chkSaveError.Equals(true) && _actionSave.Equals(true))
            {
                _dr = _ds.Tables[0].Rows[0];
                _saveError = (int.Parse(_dr[0].ToString()).Equals(1) ? 0 : 1);

                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
                    _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
                    _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE))
                    _personId = _dr[1].ToString();
            }

            if (_saveError.Equals(0))
            {
                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
                    _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
                    _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE))
                {
                    _ds = Util.DBUtil.GetRecordCountPerson(_infoLogin["PersonId"].ToString());
                    _recordCount = (_ds.Tables[0].Rows.Count > 0 ? (int)(_ds.Tables[0].Rows[0])["perParent"] : 0);
                    _action = (_recordCount.Equals(0) ? "INSERT" : "UPDATE");
                    _ds.Dispose();

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE))
                    {
                        _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetParent",
                            new SqlParameter("@action", _action),
                            new SqlParameter("@personId", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@personIdFather", _personId),
                            new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@ip", Util.GetIP())
                        );
                    }

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE))
                    {
                        _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetParent",
                            new SqlParameter("@action", _action),
                            new SqlParameter("@personId", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@personIdMother", _personId),
                            new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@ip", Util.GetIP())
                        );
                    }

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE))
                    {
                        _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetParent",
                            new SqlParameter("@action", _action),
                            new SqlParameter("@personId", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@personIdParent", _personId),
                            new SqlParameter("@relationship", _c.Request["relationship"]),
                            new SqlParameter("@by", _infoLogin["PersonId"].ToString()),
                            new SqlParameter("@ip", Util.GetIP())
                        );
                    }

                    _dr = _ds.Tables[0].Rows[0];
                    _saveError = (int.Parse(_dr[0].ToString()).Equals(1) ? 0 : 1);
                }
            }

            _ds.Dispose();
        }
        catch
        {
            _ds.Dispose();
            _saveError = 1;
        }

        _saveResult.Add("SaveError", _saveError);
        _saveResult.Add("PersonId", _personId);

        return _saveResult;
    }

    public static void SetEventLog(Dictionary<string, object> _infoLogin, string _remark)
    {
        string _personId = _infoLogin["PersonId"].ToString();
        StringBuilder xmlData = new StringBuilder();

        try
        {
            xmlData.Append(
                "<row>" +
                ("<url>" + HttpContext.Current.Request.Url.AbsoluteUri + "</url>") +
                ("<parameters>" + HttpContext.Current.Request.Url.Query + "</parameters>") +
                "<headers></headers>" +
                ("<cookie>" + Util.GetCookie(FinServiceLogin.USERTYPE_STUDENT).Value + "</cookie>") +
                ("<deviceInfo>{\"userAgent\":\"" + HttpContext.Current.Request.UserAgent + "\"}</deviceInfo>") +
                ("<remark>" + _remark + "</remark>") +
                ("<actionBy>" + _personId + "</actionBy>") +
                ("<actionIP>" + Util.GetIP() + "</actionIP>") +
                "</row>"
            );

            Util.DBUtil.ExecuteCommandStoredProcedure("sp_perSetEvent",
                new SqlParameter("@xmlData", xmlData.ToString())
            );
        }
        catch
        {
        }
    }
}