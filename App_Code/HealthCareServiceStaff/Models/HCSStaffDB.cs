// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๗/๐๗/๒๕๕๘>
// Modify date  : <๑๖/๐๒/๒๕๖๓>
// Description  : <คลาสใช้งานเกี่ยวกับการจัดการข้อมูลในฐานข้อมูล>
// =============================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class HCSStaffDB
{
    //public static string _myTableTransactionLog = "hcsDownloadLog";
    
    //ฟังก์ชั่นสำหรับค้นหาข้อมูลหน่วยบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSHospital(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListHospital",
            new SqlParameter("@keyword",            (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@id",                 (_paramSearch.ContainsKey("ID").Equals(true) ? _paramSearch["ID"] : String.Empty)),
            new SqlParameter("@cancelledStatus",    (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy",        (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",     (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลหน่วยบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _id    เป็น string รับค่ารหัสที่ต้องการ
    public static DataSet GetHCSHospital(string _id)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetHospital",
            new SqlParameter("@id", _id));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลแบบฟอร์มบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSRegistrationForm(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListRegistrationForm",
            new SqlParameter("@keyword",            (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@forPublicServant",   (_paramSearch.ContainsKey("ForPublicServant").Equals(true) ? _paramSearch["ForPublicServant"] : String.Empty)),
            new SqlParameter("@cancelledStatus",    (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy",        (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",     (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลแบบฟอร์มบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _id    เป็น string รับค่ารหัสที่ต้องการ
    public static DataSet GetHCSRegistrationForm(string _id)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetRegistrationForm",
            new SqlParameter("@id", _id));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSAgencyRegistered(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListAgency",
            new SqlParameter("@yearEntry",          (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),
            new SqlParameter("@degreeLevel",        (_paramSearch.ContainsKey("DegreeLevel").Equals(true) ? _paramSearch["DegreeLevel"] : String.Empty)),
            new SqlParameter("@faculty",            (_paramSearch.ContainsKey("Faculty").Equals(true) ? _paramSearch["Faculty"] : String.Empty)),
            new SqlParameter("@program",            (_paramSearch.ContainsKey("Program").Equals(true) ? _paramSearch["Program"] : String.Empty)),
            new SqlParameter("@hospital",           (_paramSearch.ContainsKey("Hospital").Equals(true) ? _paramSearch["Hospital"] : String.Empty)),
            new SqlParameter("@registrationForm",   (_paramSearch.ContainsKey("RegistrationForm").Equals(true) ? _paramSearch["RegistrationForm"] : String.Empty)),
            new SqlParameter("@cancelledStatus",    (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy",        (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",     (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _id    เป็น string รับค่ารหัสที่ต้องการ
    public static DataSet GetHCSAgencyRegistered(string _id)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetAgency",
        new SqlParameter("@id", _id));

        return _ds;
    }
    
    //ฟังก์ชั่นสำหรับค้นหาข้อมูลนักศึกษาที่ขึ้นทะเบียนสิทธิรักษาพยาบาลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _username      เป็น string รับค่าชื่อผู้ใช้่งาน
    //2. _userlevel     เป็น string รับค่าระดับผู้ใช้งาน
    //3. _systemGroup   เป็น string รับค่าชื่อระบบงาน
    //4. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSStudentRecords(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListPersonStudentWithAuthenStaff",
            new SqlParameter("@username",           _username),
            new SqlParameter("@userlevel",          _userlevel),
            new SqlParameter("@systemGroup",        _systemGroup),
            new SqlParameter("@keyword",            (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@degreeLevel",        (_paramSearch.ContainsKey("DegreeLevel").Equals(true) ? _paramSearch["DegreeLevel"] : String.Empty)),
            new SqlParameter("@faculty",            (_paramSearch.ContainsKey("Faculty").Equals(true) ? _paramSearch["Faculty"] : String.Empty)),
            new SqlParameter("@program",            (_paramSearch.ContainsKey("Program").Equals(true) ? _paramSearch["Program"] : String.Empty)),            
            new SqlParameter("@yearEntry",          (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),            
            new SqlParameter("@entranceType",       (_paramSearch.ContainsKey("EntranceType").Equals(true) ? _paramSearch["EntranceType"] : String.Empty)),
            new SqlParameter("@studentStatus",      (_paramSearch.ContainsKey("StudentStatus").Equals(true) ? _paramSearch["StudentStatus"] : String.Empty)),
            new SqlParameter("@hcsJoin",            (_paramSearch.ContainsKey("HCSJoin").Equals(true) ? _paramSearch["HCSJoin"] : String.Empty)),
            new SqlParameter("@registrationForm",   (_paramSearch.ContainsKey("RegistrationForm").Equals(true) ? _paramSearch["RegistrationForm"] : String.Empty)),
            new SqlParameter("@downloadStatus",     (_paramSearch.ContainsKey("DownloadStatus").Equals(true) ? _paramSearch["DownloadStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy",        (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",     (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลนักศึกษาที่ขึ้นทะเบียนสิทธิรักษาพยาบาลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _personId  เป็น string รับค่ารหัสบุคคล
    public static DataSet GetHCSStudentRecords(string _personId)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetPersonStudent",
            new SqlParameter("@userType", FinServiceLogin.USERTYPE_STAFF),
            new SqlParameter("@personId", _personId));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลประวัติการดาวน์โหลดแบบฟอร์มบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _username      เป็น string รับค่าชื่อผู้ใช้่งาน
    //2. _userlevel     เป็น string รับค่าระดับผู้ใช้งาน
    //3. _systemGroup   เป็น string รับค่าชื่อระบบงาน
    //4. _reportName    เป็น string รับค่าชื่อรายงาน
    //5. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSDownloadLog(string _username, string _userlevel, string _systemGroup, string _reportName, Dictionary<string, object> _paramSearch)
    {        
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListDownloadLog",
            new SqlParameter("@username",           _username),
            new SqlParameter("@userlevel",          _userlevel),
            new SqlParameter("@systemGroup",        _systemGroup),
            new SqlParameter("@reportName",         _reportName),
            new SqlParameter("@keyword",            (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@degreeLevel",        (_paramSearch.ContainsKey("DegreeLevel").Equals(true) ? _paramSearch["DegreeLevel"] : String.Empty)),
            new SqlParameter("@faculty",            (_paramSearch.ContainsKey("Faculty").Equals(true) ? _paramSearch["Faculty"] : String.Empty)),
            new SqlParameter("@program",            (_paramSearch.ContainsKey("Program").Equals(true) ? _paramSearch["Program"] : String.Empty)),            
            new SqlParameter("@yearEntry",          (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),            
            new SqlParameter("@entranceType",       (_paramSearch.ContainsKey("EntranceType").Equals(true) ? _paramSearch["EntranceType"] : String.Empty)),
            new SqlParameter("@studentStatus",      (_paramSearch.ContainsKey("StudentStatus").Equals(true) ? _paramSearch["StudentStatus"] : String.Empty)),
            new SqlParameter("@registrationForm",   (_paramSearch.ContainsKey("RegistrationForm").Equals(true) ? _paramSearch["RegistrationForm"] : String.Empty)),
            new SqlParameter("@sortOrderBy",        (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",     (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลนักศึกษาที่แสดงความยินยอมให้ข้อมูลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _username      เป็น string รับค่าชื่อผู้ใช้่งาน
    //2. _userlevel     เป็น string รับค่าระดับผู้ใช้งาน
    //3. _systemGroup   เป็น string รับค่าชื่อระบบงาน
    //4. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static DataSet GetListHCSStudentTermServiceConsent(string _username, string _userlevel, string _systemGroup, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetListPersonStudentTermServiceConsentWithAuthenStaff",
            new SqlParameter("@username",               _username),
            new SqlParameter("@userlevel",              _userlevel),
            new SqlParameter("@systemGroup",            _systemGroup),
            new SqlParameter("@keyword",                (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@facultyId",              (_paramSearch.ContainsKey("Faculty").Equals(true) ? _paramSearch["Faculty"] : String.Empty)),
            new SqlParameter("@programId",              (_paramSearch.ContainsKey("Program").Equals(true) ? _paramSearch["Program"] : String.Empty)),            
            new SqlParameter("@yearEntry",              (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),            
            new SqlParameter("@entranceTypeId",         (_paramSearch.ContainsKey("EntranceType").Equals(true) ? _paramSearch["EntranceType"] : String.Empty)),
            new SqlParameter("@studentStatusTypeId",    (_paramSearch.ContainsKey("StudentStatus").Equals(true) ? _paramSearch["StudentStatus"] : String.Empty)),
            new SqlParameter("@termServiceType",        (_paramSearch.ContainsKey("TermServiceType").Equals(true) ? _paramSearch["TermServiceType"] : String.Empty)),
            new SqlParameter("@consentStatus",          (_paramSearch.ContainsKey("ConsentStatus").Equals(true) ? _paramSearch["ConsentStatus"] : String.Empty)),
            new SqlParameter("@termServiceNote",        (_paramSearch.ContainsKey("TermServiceNote").Equals(true) ? _paramSearch["TermServiceNote"] : String.Empty)),
            new SqlParameter("@consentDateStart",       (_paramSearch.ContainsKey("ConsentDateStart").Equals(true) ? _paramSearch["ConsentDateStart"] : String.Empty)),
            new SqlParameter("@consentDateEnd",         (_paramSearch.ContainsKey("ConsentDateEnd").Equals(true) ? _paramSearch["ConsentDateEnd"] : String.Empty)),
            new SqlParameter("@sortOrderBy",            (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression",         (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty)));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลนักศึกษาที่แสดงความยินยอมให้ข้อมูลจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _personId          เป็น string รับค่ารหัสบุคคล
    //2. _termServiceType   เป็น string รับค่าชื่อเนื้อหาการแสดงความยินยอม
    public static DataSet GetHCSStudentTermServiceConsent(string _personId, string _termServiceType)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetPersonStudentTermServiceConsent",
            new SqlParameter("@personId",           _personId),
            new SqlParameter("@termServiceType",    _termServiceType));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับเพิ่มข้อมูล แก้ไขข้อมูล หรือลบข้อมูล แล้วส่งค่าเป็น Dictionary<string, object>
    //โดยมีพารามิเตอร์ดังนี้
    //1. _c         เป็น HttpContext รับค่าข้อมูลจาก javascript ที่เรียกใช้งาน    
    //2. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    public static Dictionary<string, object> ActionSave(HttpContext _c, Dictionary<string, object> _infoLogin)
    {
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        DataSet _ds = new DataSet();
        DataRow _dr;
        string _username = _infoLogin["Username"].ToString();
        string _systemGroup = _infoLogin["SystemGroup"].ToString();
        string _page = _c.Request["page"];
        string _action = String.Empty;
        string _personId = String.Empty;
        string _termDate = String.Empty;
        string _id = String.Empty;
        string[] _valueArray;
        int _i = 0;
        int _saveError = 0;
        int _actionSaveCount = 0;
        int _saveCount = 0;
        bool _actionSave = true;
        bool _chkSaveError = true;

        try
        {
            if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW) ||
                _page.Equals(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
            {
                _chkSaveError   = true;
                
                if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW))
                {
                    _action     = "INSERT";
                    _actionSave = (GetHCSHospital(_c.Request["id"]).Tables[0].Rows.Count.Equals(0) ? true : false);
                    _saveError  = (_actionSave.Equals(true) ? 0 : 2);
                }

                if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT))
                {
                    _action     = "UPDATE";
                    _actionSave = (GetHCSHospital(_c.Request["id"]).Tables[0].Rows.Count > 0 ? true : false);
                    _saveError  = (_actionSave.Equals(true) ? 0 : 3);
                }

                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetHospital",
                        new SqlParameter("@action",             _action),
                        new SqlParameter("@id",                 _c.Request["id"]),
                        new SqlParameter("@hospitalNameTH",     _c.Request["hospitalnameth"]),
                        new SqlParameter("@hospitalNameEN",     _c.Request["hospitalnameen"]),
                        new SqlParameter("@cancelledStatus",    _c.Request["cancelledstatus"]),
                        new SqlParameter("@by",                 _username),
                        new SqlParameter("@ip",                 Util.GetIP()));
                }
            }

            if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_NEW) ||
                _page.Equals(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
            {
                _chkSaveError   = true;
                
                if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_NEW))
                {
                    _action     = "INSERT";
                    _actionSave = (GetHCSRegistrationForm(_c.Request["id"]).Tables[0].Rows.Count.Equals(0) ? true : false);
                    _saveError  = (_actionSave.Equals(true) ? 0 : 2);
                }

                if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_EDIT))
                {
                    _action     = "UPDATE";
                    _actionSave = (GetHCSRegistrationForm(_c.Request["id"]).Tables[0].Rows.Count > 0 ? true : false);
                    _saveError  = (_actionSave.Equals(true) ? 0 : 3);
                }

                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetRegistrationForm",
                        new SqlParameter("@action",             _action),
                        new SqlParameter("@id",                 _c.Request["id"]),
                        new SqlParameter("@formNameTH",         _c.Request["formnameth"]),
                        new SqlParameter("@formNameEN",         _c.Request["formnameen"]),
                        new SqlParameter("@forPublicServant",   _c.Request["forpublicservant"]),
                        new SqlParameter("@orderForm",          _c.Request["orderform"]),
                        new SqlParameter("@cancelledStatus",    _c.Request["cancelledstatus"]),
                        new SqlParameter("@by",                 _username),
                        new SqlParameter("@ip",                 Util.GetIP()));
                }
            }
            
            if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_NEW) ||
                _page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
            {
                _chkSaveError   = false;
                _valueArray     = _c.Request["program"].Split(',');                

                for (_i = 0; _i < _valueArray.GetLength(0); _i++)
                {
                    _id = (_c.Request["yearentry"] + _valueArray[_i]);

                    if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_NEW))
                    {
                        _action     = "INSERT";
                        _actionSave = (GetHCSAgencyRegistered(_id).Tables[0].Rows.Count.Equals(0) ? true : false);
                    }

                    if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT))
                    {
                        _action     = "UPDATE";
                        _actionSave = (GetHCSAgencyRegistered(_id).Tables[0].Rows.Count > 0 ? true : false);
                    }
                    
                    if (_actionSave.Equals(true))
                    {
                        _actionSaveCount    = _actionSaveCount + 1;
                        _saveCount          = _saveCount + 1;
                        
                        _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetAgency",
                            new SqlParameter("@action",             _action),
                            new SqlParameter("@yearEntry",          _c.Request["yearentry"]),  
                            new SqlParameter("@program",            _valueArray[_i]),
                            new SqlParameter("@hospital",           _c.Request["hospital"]),
                            new SqlParameter("@registrationForm",   _c.Request["registrationform"]),
                            new SqlParameter("@programAddress",     _c.Request["programaddress"]),
                            new SqlParameter("@programTelephone",   _c.Request["programtelephone"]),
                            new SqlParameter("@cancelledStatus",    _c.Request["cancelledstatus"]),
                            new SqlParameter("@by",                 _username),
                            new SqlParameter("@ip",                 Util.GetIP()));

                        _dr         = _ds.Tables[0].Rows[0];
                        _saveCount  = (int.Parse(_dr[0].ToString()).Equals(1) ? (_saveCount + 1) : _saveCount);                        
                    }
                }
                
                _saveError  = (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_NEW)  ? (_actionSaveCount > 0 ? 0 : 4) : _saveError);
                _saveError  = (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT) ? (_actionSaveCount > 0 ? 0 : 5) : _saveError);
                _saveError  = (_saveError.Equals(0) ? (_saveCount > 0 ? 0 : 1) : _saveError);
            }
        
            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_EDIT) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_EDIT))
            {
                _chkSaveError = false;

                StringBuilder _xmlData = new StringBuilder();
                string _termServiceType = String.Empty;

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_EDIT))  _termServiceType = "HCS_CONSENT_REGISTRATION";
                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_EDIT))          _termServiceType = "HCS_CONSENT_OOCA";

                _xmlData.Append(
                    "<table>" +
                    "<row>" +
                    ("<studentId>" + _c.Request["studentId"] + "</studentId>") +
                    ("<termType>" + _termServiceType + "</termType>") +
                    ("<termStatus>" + _c.Request["consentStatus"] + "</termStatus>") +
                    (!String.IsNullOrEmpty(_c.Request["note"]) ? ("<note>" + _c.Request["note"] + "</note>") : String.Empty) +
                    ("<ip>" + Util.GetIP() + "</ip>") +
                    "</row>" +
                    "</table>"
                );

                _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudentTermService",
                    new SqlParameter("@xmlData", _xmlData.ToString()));
            
                _dr         = _ds.Tables[0].Rows[0];
                _saveError  = (_dr["resMsg"].ToString().Equals("success") ? 0 : 1);
                _termDate   = (!String.IsNullOrEmpty(_dr["termDate"].ToString()) ? DateTime.Parse(_dr["termDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
            }

            if (_chkSaveError.Equals(true) && _actionSave.Equals(true))
            {
                _dr         = _ds.Tables[0].Rows[0];
                _saveError  = (int.Parse(_dr[0].ToString()).Equals(1) ? 0 : 1);
            }

            _ds.Dispose();
        }
        catch
        {
            _ds.Dispose();
            _saveError = 1;
        }

        _saveResult.Add("SaveError",    _saveError);
        _saveResult.Add("PersonId",     _personId);
        _saveResult.Add("TermDate",     _termDate);

        return _saveResult;
    }
};