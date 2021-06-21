/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๒/๑๑/๒๕๕๘>
Modify date : <๑๘/๐๖/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นการประมวลผลข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using NUtil;
using Ionic.Zip;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class ePFStaffProgressDataUtil
{
    public static Dictionary<string, object> SetValueProcess(HttpContext _c)
    {
        Dictionary<string, object> _valueProcessResult = new Dictionary<string, object>();
        _valueProcessResult.Add("Option", _c.Request["option"]);
        _valueProcessResult.Add("ParamSearch", _c.Request["paramsearch"]);
        _valueProcessResult.Add("Selected", _c.Request["selected"]);
        _valueProcessResult.Add("Faculty", _c.Request["faculty"]);
        _valueProcessResult.Add("Program", _c.Request["program"]);
        _valueProcessResult.Add("Class", _c.Request["class"]);
        _valueProcessResult.Add("EntranceType", _c.Request["entrancetype"]);
        _valueProcessResult.Add("StudentStatus", _c.Request["studentstatus"]);
        _valueProcessResult.Add("YearAttended", _c.Request["yearattended"]);
        _valueProcessResult.Add("AdmissionDate", _c.Request["admissiondate"]);
        _valueProcessResult.Add("GraduationDate", _c.Request["graduationdate"]);
        _valueProcessResult.Add("JoinProgramStatus", _c.Request["joinprogramstatus"]);
        _valueProcessResult.Add("StartSemester", _c.Request["startsemester"]);
        _valueProcessResult.Add("StartYear", _c.Request["startyear"]);
        _valueProcessResult.Add("EndSemester", _c.Request["endsemester"]);
        _valueProcessResult.Add("EndYear", _c.Request["endyear"]);
        _valueProcessResult.Add("ResignDate", _c.Request["resigndate"]);
        _valueProcessResult.Add("UpdateReason", _c.Request["updatereason"]);

        return _valueProcessResult;
    }    
        
    public static Dictionary<string, object> GetProcess(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        string _option = _dataProcess["Option"].ToString();
        string _valueParamSearch = _dataProcess["ParamSearch"].ToString();
        string _valueSelected = _dataProcess["Selected"].ToString();
        string _keyword = String.Empty;
        string _gender = String.Empty;
        string _degreeLevel = String.Empty;
        string _country = String.Empty;
        string _province = String.Empty;
        string _district = String.Empty;
        string _postalCode = String.Empty;
        string _cancelledStatus = String.Empty;
        string _faculty = String.Empty;
        string _program = String.Empty;
        string _yearEntry = String.Empty;
        string _yearGraduate = String.Empty;
        string _class = String.Empty;
        string _entranceType = String.Empty;
        string _studentStatus = String.Empty;
        string _studentRecordsStatus = String.Empty;
        string _distinction = String.Empty;
        string _joinProgramStatus = String.Empty;
        string _startAcademicYear = String.Empty;
        string _endAcademicYear = String.Empty;
        string _studentStatusGroup = String.Empty;
        string _nationality = String.Empty;
        string _sortOrderBy = String.Empty;
        string _sortExpression = String.Empty;
        string[] _valueArray1;
        string[] _valueArray2;
        string[] _valueSearch;
        int _i = 0;

        if (_option.Equals("selected") || _option.Equals("all"))
        {
            if (_option.Equals("selected") && !String.IsNullOrEmpty(_valueSelected))
                _keyword = _valueSelected;

            if (_option.Equals("all") && !String.IsNullOrEmpty(_valueParamSearch))
            {
                _valueArray1 = _valueParamSearch.Split(',');
                _valueSearch = new string[_valueArray1.GetLength(0)];

                for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                {
                    _valueArray2 = _valueArray1[_i].Split(':');
                    _valueSearch[_i] = _valueArray2[1];
                }

                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                {
                    _keyword = _valueSearch[0];
                    _degreeLevel = _valueSearch[1];
                    _faculty = _valueSearch[2];
                    _program = _valueSearch[3];
                    _yearEntry = _valueSearch[4];
                    _yearGraduate = _valueSearch[5];
                    _class = _valueSearch[6];
                    _entranceType = _valueSearch[7];
                    _studentStatus = _valueSearch[8];
                    _studentRecordsStatus = _valueSearch[9];
                    _distinction = _valueSearch[10];
                    _joinProgramStatus = _valueSearch[11];
                    _startAcademicYear = _valueSearch[12];
                    _endAcademicYear = _valueSearch[13];
                    _gender = _valueSearch[14];
                    _studentStatusGroup = _valueSearch[15];
                    _nationality = _valueSearch[16];
                    _sortOrderBy = _valueSearch[17];
                    _sortExpression = _valueSearch[18];
                }
            }

            _paramSearch.Add("Keyword", _keyword);
            _paramSearch.Add("Gender", _gender);
            _paramSearch.Add("DegreeLevel", _degreeLevel);
            _paramSearch.Add("Country", _country);
            _paramSearch.Add("Province", _province);
            _paramSearch.Add("District", _district);
            _paramSearch.Add("PostalCode", _postalCode);
            _paramSearch.Add("CancelledStatus", _cancelledStatus);
            _paramSearch.Add("Faculty", _faculty);
            _paramSearch.Add("Program", _program);
            _paramSearch.Add("YearEntry", _yearEntry);
            _paramSearch.Add("YearGraduate", _yearGraduate);
            _paramSearch.Add("Class", _class);
            _paramSearch.Add("EntranceType", _entranceType);
            _paramSearch.Add("StudentStatus", _studentStatus);
            _paramSearch.Add("StudentRecordsStatus", _studentRecordsStatus);
            _paramSearch.Add("Distinction", _distinction);
            _paramSearch.Add("JoinProgramStatus", _joinProgramStatus);
            _paramSearch.Add("StartAcademicYear", _startAcademicYear);
            _paramSearch.Add("EndAcademicYear", _endAcademicYear);
            _paramSearch.Add("StudentStatusGroup", _studentStatusGroup);
            _paramSearch.Add("Nationality", _nationality);
            _paramSearch.Add("SortOrderBy", _sortOrderBy);
            _paramSearch.Add("SortExpression", _sortExpression);
        }

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
            _processResult = GetProcessContent(_infoLogin, _page, _paramSearch, _dataProcess);

        return _processResult;
    }

    private static Dictionary<string, object> GetProcessContent(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _paramSearch, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        string _username = _infoLogin["Username"].ToString();
        string _option = _dataProcess["Option"].ToString();
        string _fileName = ((DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
        string _filePath = HttpContext.Current.Server.MapPath(ePFStaffUtil._myFileDownloadPath + "\\");
        string _msgTH = String.Empty;
        string _msgDetail = String.Empty;
        string _reportName = String.Empty;
        string _strTemp1 = String.Empty;
        string _strTemp2 = String.Empty;
        string _strTemp3 = String.Empty;
        string _strTemp4 = String.Empty;
        int _tbIndex = 0;
        int _saveError = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i = 0;
        int _j = 0;
        bool _error = false;
        bool _export = false;
        List<string> _studentId = new List<string>();
        List<string> _valueDetailCompleteTemp = new List<string>();
        List<string> _valueDetailComplte = new List<string>();
        List<string> _valueDetailIncomplte = new List<string>();

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS))
        {
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATEFACULTYPROGRAM + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS))       
        {
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATECLASSYEAR + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS))    
        {            
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATEENTRANCETYPE + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS))   
        {            
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATESTUDENTSTATUS + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS))
        {            
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATEADMISSIONDATE + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS))
        {            
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATEDATATOOLDDB + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS))
        {
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_STUDENTRECORDSINFORMATION + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS))
        {            
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_UPDATESTUDENTMEDICALSCHOLARSPROGRAM + _fileName);
            _msgTH = "ปรับปรุงข้อมูล";
            _tbIndex = 0;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS))
        {
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
            _reportName = ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE;
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
        {
            _fileName = (ePFStaffUtil.SUBJECT_SECTION_STUDENTRECORDSINFORMATION + _fileName).Replace("Records", "");
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
            _reportName = ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE;
        }

        DataTable _dt1 = new DataTable();
        DataTable _dt2 = new DataTable();
        DataSet _ds1 = new DataSet();
        MemoryStream _ms = new MemoryStream();

        using (ZipFile _zip = new ZipFile())
        {
            if (_option.Equals("selected"))
            {
                _tbIndex = 0;
                
                string[] _valueSelected = _paramSearch["Keyword"].ToString().Split('|');
                _dt1.Columns.Add("id");

                for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
                {
                    _dt1.Rows.Add(_valueSelected[_i]);
                }

                _ds1.Tables.Add(_dt1);
            }

            if (_option.Equals("all"))
            {
                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                    _ds1 = Util.DBUtil.GetListStudentRecords(
                        _infoLogin["Username"].ToString(),
                        _infoLogin["Userlevel"].ToString(),
                        _infoLogin["SystemGroup"].ToString(),
                        _reportName,
                        _paramSearch
                    );
            }

            if (_ds1.Tables[_tbIndex].Rows.Count > 0)
            {
                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS) |
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                    _dt2 = ePFStaffUtil.SetColumnDataTable(_page);

                _i = 0;

                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                {
                    foreach (DataRow _dr1 in _ds1.Tables[_tbIndex].Rows)
                    {
                        try
                        {
                            _error = false;
                            _export = false;
                            _saveError = 0;
                            _msgDetail = String.Empty;

                            DataSet _ds2 = Util.DBUtil.GetStudentRecords(_dr1["id"].ToString());

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {
                                DataRow _dr2 = _ds2.Tables[0].Rows[0];
                                
                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS))
                                {                        
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@faculty", _dataProcess["Faculty"]),
                                        new SqlParameter("@program", _dataProcess["Program"]),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATEFACULTYPROGRAM),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();
                                    
                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS))
                                {
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@class", _dataProcess["Class"]),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATECLASSYEAR),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();
                                    
                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS))
                                {
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@entranceType", _dataProcess["EntranceType"]),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATEENTRANCETYPE),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();

                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS))
                                {
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@studentStatus", _dataProcess["StudentStatus"]),
                                        new SqlParameter("@graduateDate", _dataProcess["GraduationDate"]),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATESTUDENTSTATUS),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();

                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS))
                                {
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@admissionDate", _dataProcess["AdmissionDate"]),
                                        new SqlParameter("@yearEntry", (!String.IsNullOrEmpty(_dataProcess["YearAttended"].ToString()) ? _dataProcess["YearAttended"] : null)),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATEADMISSIONDATE),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();

                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS))
                                {  
                                    Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdTransferStudentRecordsToMUStudent",
                                        new SqlParameter("@personId", _dr1["id"].ToString())
                                    );
                                    
                                    _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS))
                                    _export = true;

                                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                                    _export = true;

                                if (_export.Equals(true))
                                {
                                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS))
                                    {
                                        Dictionary<string, object> _dataRecordedStudentRecords = ePFStaffStudentRecordsUtil.StudentRecordsUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds2);
                                        Dictionary<string, object> _dataRecordedPersonal = ePFStaffStudentRecordsUtil.PersonalUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsPersonal(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedAddress = ePFStaffStudentRecordsUtil.AddressUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsAddress(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedEducation = ePFStaffStudentRecordsUtil.EducationUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsEducation(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedTalent = ePFStaffStudentRecordsUtil.TalentUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsActivity(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedHealthy = ePFStaffStudentRecordsUtil.HealthyUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsHealthy(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedWork = ePFStaffStudentRecordsUtil.WorkUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsWork(_dr1["id"].ToString()));
                                        Dictionary<string, object> _dataRecordedFinancial = ePFStaffStudentRecordsUtil.FinancialUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsFinancial(_dr1["id"].ToString()));
                                        
                                        DataSet _ds3 = Util.DBUtil.GetPersonRecordsFamily(_dr1["id"].ToString());

                                        Dictionary<string, object> _dataRecordedFamilyFatherPersonal = ePFStaffStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYFATHER);
                                        Dictionary<string, object> _dataRecordedFamilyFatherAddress = ePFStaffStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYFATHER);
                                        Dictionary<string, object> _dataRecordedFamilyFatherWork = ePFStaffStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYFATHER);
                                        Dictionary<string, object> _dataRecordedFamilyMotherPersonal = ePFStaffStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYMOTHER);
                                        Dictionary<string, object> _dataRecordedFamilyMotherAddress = ePFStaffStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYMOTHER);
                                        Dictionary<string, object> _dataRecordedFamilyMotherWork = ePFStaffStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYMOTHER);
                                        Dictionary<string, object> _dataRecordedFamilyParentPersonal = ePFStaffStudentRecordsUtil.FamilyUtil.PersonalUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYPARENT);
                                        Dictionary<string, object> _dataRecordedFamilyParentAddress = ePFStaffStudentRecordsUtil.FamilyUtil.AddressUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYPARENT);
                                        Dictionary<string, object> _dataRecordedFamilyParentWork = ePFStaffStudentRecordsUtil.FamilyUtil.WorkUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds3, ePFStaffUtil.SUBJECT_FAMILYPARENT);

                                        _ds3.Dispose();
                                        
                                        string _weight = String.Empty;
                                        string _height = String.Empty;
                                        string _bmi = String.Empty;
                                        string _bmiDate = String.Empty;
                                        string _country = String.Empty;
                                        string _travelDate = String.Empty;
                                        string _travelAbroad = String.Empty;
                                        string[] _bodyMassArray;
                                        string[] _bodyMassDetail = new string[4];
                                        string[] _travelAbroadArray;
                                        string[] _travelAbroadDetail = new string[2];
                                    
                                        if (!String.IsNullOrEmpty(_dataRecordedHealthy["BodyMassDetail"].ToString()))
                                        {
                                            _bodyMassArray = _dataRecordedHealthy["BodyMassDetail"].ToString().Split(';');

                                            for (_j = 0; _j < _bodyMassArray.GetLength(0); _j++)
                                            {
                                                _bodyMassDetail = _bodyMassArray[_j].Split(':');
                                                _weight += _bodyMassDetail[0];
                                                _height += _bodyMassDetail[1];
                                                _bmi += _bodyMassDetail[2];
                                                _bmiDate += (_bodyMassDetail[3].Substring(6, 4) + "-" + _bodyMassDetail[3].Substring(3, 2) + "-" + _bodyMassDetail[3].Substring(0, 2));

                                                if ((_j + 1) < _bodyMassArray.GetLength(0))
                                                {
                                                    _weight += "\r\n";
                                                    _height += "\r\n";
                                                    _bmi += "\r\n";
                                                    _bmiDate += "\r\n";
                                                }
                                            }
                                        }
                                    
                                        if (!String.IsNullOrEmpty(_dataRecordedHealthy["TravelAbroadDetail"].ToString()))
                                        {
                                            _travelAbroadArray = _dataRecordedHealthy["TravelAbroadDetail"].ToString().Split(';');

                                            for (_j = 0; _j < _travelAbroadArray.GetLength(0); _j++)
                                            {
                                                _travelAbroadDetail = _travelAbroadArray[_j].Split(',');
                                                _country = (_travelAbroadDetail[0].Split(':'))[0];
                                                _travelDate = (_travelAbroadDetail[1].Substring(6, 4) + "-" + _travelAbroadDetail[1].Substring(3, 2) + "-" + _travelAbroadDetail[1].Substring(0, 2));
                                                _travelAbroad += (_country + ", " + _travelDate);

                                                if ((_j + 1) < _travelAbroadArray.GetLength(0))
                                                    _travelAbroad += "\r\n";
                                            }
                                        }

                                        _i++;
                                        
                                        DataRow _dr3 = _dt2.NewRow();
                                                    
                                        _dr3["No."] = _i.ToString("#,##0"); 
                                        _dr3["StudentCode"] = _dataRecordedStudentRecords["StudentCode"];
                                        _dr3["TitlePrefixTH"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["TitleInitialsTH"].ToString()) ? _dataRecordedStudentRecords["TitleInitialsTH"].ToString() : _dataRecordedStudentRecords["TitleFullNameTH"].ToString());
                                        _dr3["TitlePrefixEN"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["TitleInitialsEN"].ToString()) ? _dataRecordedStudentRecords["TitleInitialsEN"].ToString() : _dataRecordedStudentRecords["TitleFullNameEN"].ToString());
                                        _dr3["FirstNameTH"] = _dataRecordedStudentRecords["FirstName"].ToString();
                                        _dr3["FirstNameEN"] = _dataRecordedStudentRecords["FirstNameEN"].ToString();
                                        _dr3["MiddleNameTH"] = _dataRecordedStudentRecords["MiddleName"].ToString();
                                        _dr3["MiddleNameEN"] = _dataRecordedStudentRecords["MiddleNameEN"].ToString();
                                        _dr3["LastNameTH"] = _dataRecordedStudentRecords["LastName"].ToString();
                                        _dr3["LastNameEN"] = _dataRecordedStudentRecords["LastNameEN"].ToString();
                                        _dr3["FullNameTH"] = Util.GetFullName(_dataRecordedStudentRecords["TitleInitialsTH"].ToString(), _dataRecordedStudentRecords["TitleFullNameTH"].ToString(), _dataRecordedStudentRecords["FirstName"].ToString(), _dataRecordedStudentRecords["MiddleName"].ToString(), _dataRecordedStudentRecords["LastName"].ToString()); 
                                        _dr3["FullNameEN"] = Util.GetFullName(_dataRecordedStudentRecords["TitleInitialsEN"].ToString(), _dataRecordedStudentRecords["TitleFullNameEN"].ToString(), _dataRecordedStudentRecords["FirstNameEN"].ToString(), _dataRecordedStudentRecords["MiddleNameEN"].ToString(), _dataRecordedStudentRecords["LastNameEN"].ToString()); 
                                        _dr3["DegreeLevel"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["DegreeLevelNameTH"].ToString()) ? _dataRecordedStudentRecords["DegreeLevelNameTH"] : _dataRecordedStudentRecords["DegreeLevelNameEN"]); 
                                        _dr3["Faculty"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["FacultyNameTH"].ToString()) ? _dataRecordedStudentRecords["FacultyNameTH"] : _dataRecordedStudentRecords["FacultyNameEN"]);
                                        _dr3["ProgramCode"] = _dataRecordedStudentRecords["ProgramCode"].ToString();
                                        _dr3["Program"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["ProgramNameTH"].ToString()) ? _dataRecordedStudentRecords["ProgramNameTH"] : _dataRecordedStudentRecords["ProgramNameEN"]); 
                                        _dr3["YearEntry"] = _dataRecordedStudentRecords["YearEntry"]; 
                                        _dr3["Class"] = _dataRecordedStudentRecords["Class"]; 
                                        _dr3["AdmissionType"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["EntranceTypeNameTH"].ToString()) ? _dataRecordedStudentRecords["EntranceTypeNameTH"] : _dataRecordedStudentRecords["EntranceTypeNameEN"]); 
                                        _dr3["StudentStatus"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["StatusTypeNameTH"].ToString()) ? _dataRecordedStudentRecords["StatusTypeNameTH"] : _dataRecordedStudentRecords["StatusTypeNameEN"]); 
                                        _dr3["AdmissionDate"] = _dataRecordedStudentRecords["AdmissionDate"]; 
                                        _dr3["GraduationDate"] = _dataRecordedStudentRecords["GraduationDate"];  
                                        _dr3["ReasonOfGraduation"] = (_dataRecordedStudentRecords["StatusGroup"].Equals("02") && !String.IsNullOrEmpty(_dataRecordedStudentRecords["UpdateReason"].ToString()) ? _dataRecordedStudentRecords["UpdateReason"].ToString().Replace("\n", "\r\n") : String.Empty);                                                                               
                                        _dr3["IdCard"] = _dataRecordedPersonal["IdCard"]; 
                                        _dr3["Gender"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["GenderFullNameTH"].ToString()) ? _dataRecordedPersonal["GenderFullNameTH"] : _dataRecordedPersonal["GenderFullNameEN"]); 
                                        /*
                                        _dr3["Alive"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["AliveTH"].ToString()) ? _dataRecordedPersonal["AliveTH"] : _dataRecordedPersonal["AliveEN"]); 
                                        */
                                        _dr3["Birthdate"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["BirthdateTH"].ToString()) ? _dataRecordedPersonal["BirthdateTH"] : _dataRecordedPersonal["BirthDateEN"]); 
                                        _dr3["Age"] = _dataRecordedPersonal["Age"]; 
                                        /*
                                        _dr3["Country"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["CountryNameTH"].ToString()) ? _dataRecordedPersonal["CountryNameTH"] : _dataRecordedPersonal["CountryNameEN"]); 
                                        */
                                        _dr3["Nationality"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["NationalityNameTH"].ToString()) ? _dataRecordedPersonal["NationalityNameTH"] : _dataRecordedPersonal["NationalityNameEN"]); 
                                        /*
                                        _dr3["Race"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["RaceNameTH"].ToString()) ? _dataRecordedPersonal["RaceNameTH"] : _dataRecordedPersonal["RaceNameEN"]); 
                                        _dr3["Religion"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["ReligionNameTH"].ToString()) ? _dataRecordedPersonal["ReligionNameTH"] : _dataRecordedPersonal["ReligionNameEN"]); 
                                        _dr3["BloodGroup"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["BloodGroupNameTH"].ToString()) ? _dataRecordedPersonal["BloodGroupNameTH"] : _dataRecordedPersonal["BloodGroupNameEN"]); 
                                        _dr3["MaritalStatus"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["MaritalStatusNameTH"].ToString()) ? _dataRecordedPersonal["MaritalStatusNameTH"] : _dataRecordedPersonal["MaritalStatusNameEN"]); 
                                        _dr3["EducationalBackgroundPerson"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["EducationalBackgroundPersonNameTH"].ToString()) ? _dataRecordedPersonal["EducationalBackgroundPersonNameTH"] : _dataRecordedPersonal["EducationalBackgroundPersonNameEN"]); 
                                        _dr3["Brotherhood"] = _dataRecordedPersonal["Brotherhood"]; 
                                        _dr3["Childhood"] = _dataRecordedPersonal["Childhood"]; 
                                        _dr3["Studyhood"] = _dataRecordedPersonal["Studyhood"]; 
                                        _dr3["EmailAddress"] = _dataRecordedPersonal["EmailAddress"]; 
                                        */
                                        _dr3["CountryPermanentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["CountryNameTHPermanentAddress"].ToString()) ? _dataRecordedAddress["CountryNameTHPermanentAddress"] : _dataRecordedAddress["CountryNameENPermanentAddress"]); 
                                        _dr3["ProvincePermanentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["ProvinceNameTHPermanentAddress"].ToString()) ? _dataRecordedAddress["ProvinceNameTHPermanentAddress"] : _dataRecordedAddress["ProvinceNameENPermanentAddress"]); 
                                        /*
                                        _dr3["DistrictPermanentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["DistrictNameTHPermanentAddress"].ToString()) ? _dataRecordedAddress["DistrictNameTHPermanentAddress"] : _dataRecordedAddress["DistrictNameENPermanentAddress"]); 
                                        _dr3["SubDistrictPermanentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["SubDistrictNameTHPermanentAddress"].ToString()) ? _dataRecordedAddress["SubDistrictNameTHPermanentAddress"] : _dataRecordedAddress["SubDistrictNameENPermanentAddress"]); 
                                        _dr3["PostalCodePermanentAddress"] = _dataRecordedAddress["PostalCodePermanentAddress"]; 
                                        _dr3["VillagePermanentAddress"] = _dataRecordedAddress["VillagePermanentAddress"]; 
                                        _dr3["AddressNumberPermanentAddress"] = _dataRecordedAddress["AddressNumberPermanentAddress"]; 
                                        _dr3["VillageNoPermanentAddress"] = _dataRecordedAddress["VillageNoPermanentAddress"]; 
                                        _dr3["LaneAlleyPermanentAddress"] = _dataRecordedAddress["LaneAlleyPermanentAddress"]; 
                                        _dr3["RoadPermanentAddress"] = _dataRecordedAddress["RoadPermanentAddress"]; 
                                        _dr3["PhoneNumberPermanentAddress"] = _dataRecordedAddress["PhoneNumberPermanentAddress"]; 
                                        _dr3["MobileNumberPermanentAddress"] = _dataRecordedAddress["MobileNumberPermanentAddress"]; 
                                        _dr3["FaxNumberPermanentAddress"] = _dataRecordedAddress["FaxNumberPermanentAddress"]; 
                                        _dr3["CountryCurrentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["CountryNameTHCurrentAddress"].ToString()) ? _dataRecordedAddress["CountryNameTHCurrentAddress"] : _dataRecordedAddress["CountryNameENCurrentAddress"]); 
                                        _dr3["ProvinceCurrentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["ProvinceNameTHCurrentAddress"].ToString()) ? _dataRecordedAddress["ProvinceNameTHCurrentAddress"] : _dataRecordedAddress["ProvinceNameENCurrentAddress"]); 
                                        _dr3["DistrictCurrentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["DistrictNameTHCurrentAddress"].ToString()) ? _dataRecordedAddress["DistrictNameTHCurrentAddress"] : _dataRecordedAddress["DistrictNameENCurrentAddress"]); 
                                        _dr3["SubDistrictCurrentAddress"] = (!String.IsNullOrEmpty(_dataRecordedAddress["SubDistrictNameTHCurrentAddress"].ToString()) ? _dataRecordedAddress["SubDistrictNameTHCurrentAddress"] : _dataRecordedAddress["SubDistrictNameENCurrentAddress"]); 
                                        _dr3["PostalCodeCurrentAddress"] = _dataRecordedAddress["PostalCodeCurrentAddress"]; 
                                        _dr3["VillageCurrentAddress"] = _dataRecordedAddress["VillageCurrentAddress"]; 
                                        _dr3["AddressNumberCurrentAddress"] = _dataRecordedAddress["AddressNumberCurrentAddress"]; 
                                        _dr3["VillageNoCurrentAddress"] = _dataRecordedAddress["VillageNoCurrentAddress"]; 
                                        _dr3["LaneAlleyCurrentAddress"] = _dataRecordedAddress["LaneAlleyCurrentAddress"]; 
                                        _dr3["RoadCurrentAddress"] = _dataRecordedAddress["RoadCurrentAddress"]; 
                                        _dr3["PhoneNumberCurrentAddress"] = _dataRecordedAddress["PhoneNumberCurrentAddress"]; 
                                        _dr3["MobileNumberCurrentAddress"] = _dataRecordedAddress["MobileNumberCurrentAddress"]; 
                                        _dr3["FaxNumberCurrentAddress"] = _dataRecordedAddress["FaxNumberCurrentAddress"]; 
                                        _dr3["InstituteNamePrimarySchool"] = _dataRecordedEducation["InstituteNamePrimarySchool"]; 
                                        _dr3["InstituteCountryPrimarySchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteCountryNameTHPrimarySchool"].ToString()) ? _dataRecordedEducation["InstituteCountryNameTHPrimarySchool"] : _dataRecordedEducation["InstituteCountryNameENPrimarySchool"]); 
                                        _dr3["InstituteProvincePrimarySchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteProvinceNameTHPrimarySchool"].ToString()) ? _dataRecordedEducation["InstituteProvinceNameTHPrimarySchool"] : _dataRecordedEducation["InstituteProvinceNameENPrimarySchool"]); 
                                        _dr3["YearAttendedPrimarySchool"] = _dataRecordedEducation["YearAttendedPrimarySchool"]; 
                                        _dr3["YearGraduatePrimarySchool"] = _dataRecordedEducation["YearGraduatePrimarySchool"]; 
                                        _dr3["GPAPrimarySchool"] = _dataRecordedEducation["GPAPrimarySchool"]; 
                                        _dr3["InstituteNameJuniorHighSchool"] = _dataRecordedEducation["InstituteNameJuniorHighSchool"]; 
                                        _dr3["InstituteCountryJuniorHighSchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteCountryNameTHJuniorHighSchool"].ToString()) ? _dataRecordedEducation["InstituteCountryNameTHJuniorHighSchool"] : _dataRecordedEducation["InstituteCountryNameENJuniorHighSchool"]); 
                                        _dr3["InstituteProvinceJuniorHighSchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteProvinceNameTHJuniorHighSchool"].ToString()) ? _dataRecordedEducation["InstituteProvinceNameTHJuniorHighSchool"] : _dataRecordedEducation["InstituteProvinceNameENJuniorHighSchool"]); 
                                        _dr3["YearAttendedJuniorHighSchool"] = _dataRecordedEducation["YearAttendedJuniorHighSchool"]; 
                                        _dr3["YearGraduateJuniorHighSchool"] = _dataRecordedEducation["YearGraduateJuniorHighSchool"]; 
                                        _dr3["GPAJuniorHighSchool"] = _dataRecordedEducation["GPAJuniorHighSchool"]; 
                                        */
                                        _dr3["InstituteNameHighSchool"]  = _dataRecordedEducation["InstituteNameHighSchool"]; 
                                        _dr3["InstituteCountryHighSchool"]  = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteCountryNameTHHighSchool"].ToString()) ? _dataRecordedEducation["InstituteCountryNameTHHighSchool"] : _dataRecordedEducation["InstituteCountryNameENHighSchool"]); 
                                        _dr3["InstituteProvinceHighSchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["InstituteProvinceNameTHHighSchool"].ToString()) ? _dataRecordedEducation["InstituteProvinceNameTHHighSchool"] : _dataRecordedEducation["InstituteProvinceNameENHighSchool"]); 
                                        _dr3["StudentIdHighSchool"] = _dataRecordedEducation["StudentIdHighSchool"];
                                        /*
                                        _strTemp1 = String.Empty;
                                        _strTemp2 = String.Empty;
                                        _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedEducation["EducationalMajorNameTHHighSchool"].ToString()) ? _dataRecordedEducation["EducationalMajorNameTHHighSchool"] : _dataRecordedEducation["EducationalMajorNameENHighSchool"]).ToString();
                                        _strTemp2 = _dataRecordedEducation["EducationalMajorOtherHighSchool"].ToString();

                                        _dr3["EducationalMajorHighSchool"] = (!String.IsNullOrEmpty(_strTemp1) ? _strTemp1 : _strTemp2); 
                                        _dr3["YearAttendedHighSchool"] = _dataRecordedEducation["YearAttendedHighSchool"]; 
                                        _dr3["YearGraduateHighSchool"] = _dataRecordedEducation["YearGraduateHighSchool"]; 
                                        */
                                        _dr3["GPAHighSchool"] = _dataRecordedEducation["GPAHighSchool"]; 
                                        /*
                                        _dr3["EducationalBackgroundHighSchool"] = (!String.IsNullOrEmpty(_dataRecordedEducation["EducationalBackgroundNameTHHighSchool"].ToString()) ? _dataRecordedEducation["EducationalBackgroundNameTHHighSchool"] : _dataRecordedEducation["EducationalBackgroundNameENHighSchool"]); 
                                        _dr3["EducationalBackground"] = (!String.IsNullOrEmpty(_dataRecordedEducation["EducationalBackgroundNameTH"].ToString()) ? _dataRecordedEducation["EducationalBackgroundNameTH"] : _dataRecordedEducation["EducationalBackgroundNameEN"]);

                                        _strTemp1 = String.Empty;
                                        _strTemp2 = String.Empty;
                                        _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedEducation["GraduateByTH"].ToString()) ? _dataRecordedEducation["GraduateByTH"] : _dataRecordedEducation["GraduateByEN"]).ToString();
                                        _strTemp2 = _dataRecordedEducation["GraduateByInstituteName"].ToString();

                                        _dr3["GraduateBy"] = (_strTemp1 + (!String.IsNullOrEmpty(_strTemp2) ? (" ( " + _strTemp2 + " )") : ""));
                                        _dr3["EntranceTime"] = (!String.IsNullOrEmpty(_dataRecordedEducation["EntranceTimeTH"].ToString()) ? _dataRecordedEducation["EntranceTimeTH"] : _dataRecordedEducation["EntranceTimeEN"]); 

                                        _strTemp1 = String.Empty;
                                        _strTemp2 = String.Empty;
                                        _strTemp3 = String.Empty;
                                        _strTemp4 = String.Empty;
                                        _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedEducation["StudentIsTH"].ToString()) ? _dataRecordedEducation["StudentIsTH"] : _dataRecordedEducation["StudentIsEN"]).ToString();
                                        _strTemp2 = _dataRecordedEducation["StudentIsUniversity"].ToString();
                                        _strTemp3 = _dataRecordedEducation["StudentIsFaculty"].ToString();
                                        _strTemp4 = _dataRecordedEducation["StudentIsProgram"].ToString();
                                        
                                        _dr3["StudentIs"] = (_strTemp1 + (!String.IsNullOrEmpty(_strTemp2 + _strTemp3 + _strTemp4) ? (" ( " + (!String.IsNullOrEmpty(_strTemp2) ? ("มหาวิทยาลัย" + _strTemp2 + " ") : "") + (!String.IsNullOrEmpty(_strTemp3) ? ("คณะ" + _strTemp3 + " ") : "") + (!String.IsNullOrEmpty(_strTemp4) ? ("หลักสูตร" + _strTemp4) : "") + " )") : ""));
                                        _dr3["EntranceType"] = (!String.IsNullOrEmpty(_dataRecordedEducation["EntranceTypeNameTH"].ToString()) ? _dataRecordedEducation["EntranceTypeNameTH"] : _dataRecordedEducation["EntranceTypeNameEN"]); 
                                        _dr3["AdmissionRanking"] = _dataRecordedEducation["AdmissionRanking"]; 
                                        _dr3["ScoresONETThai"] = _dataRecordedEducation["ScoresONETThai"]; 
                                        _dr3["ScoresONETSocialScience"] = _dataRecordedEducation["ScoresONETSocialScience"]; 
                                        _dr3["ScoresONETEnglish"] = _dataRecordedEducation["ScoresONETEnglish"]; 
                                        _dr3["ScoresONETMathematics"] = _dataRecordedEducation["ScoresONETMathematics"]; 
                                        _dr3["ScoresONETScience"] = _dataRecordedEducation["ScoresONETScience"]; 
                                        _dr3["ScoresONETHealthPhysical"] = _dataRecordedEducation["ScoresONETHealthPhysical"]; 
                                        _dr3["ScoresONETArts"] = _dataRecordedEducation["ScoresONETArts"]; 
                                        _dr3["ScoresONETOccupationTechnology"] = _dataRecordedEducation["ScoresONETOccupationTechnology"]; 
                                        _dr3["ScoresANETThai2"] = _dataRecordedEducation["ScoresANETThai2"]; 
                                        _dr3["ScoresANETSocialScience2"] = _dataRecordedEducation["ScoresANETSocialScience2"]; 
                                        _dr3["ScoresANETEnglish3"] = _dataRecordedEducation["ScoresANETEnglish3"]; 
                                        _dr3["ScoresANETMathematics2"] = _dataRecordedEducation["ScoresANETMathematics2"]; 
                                        _dr3["ScoresANETScience2"] = _dataRecordedEducation["ScoresANETScience2"]; 
                                        _dr3["ScoresGATGenaralAptitudeTest"] = _dataRecordedEducation["ScoresGATGenaralAptitudeTest"]; 
                                        _dr3["ScoresPAT1"] = _dataRecordedEducation["ScoresPAT1"]; 
                                        _dr3["ScoresPAT2"] = _dataRecordedEducation["ScoresPAT2"]; 
                                        _dr3["ScoresPAT3"] = _dataRecordedEducation["ScoresPAT3"]; 
                                        _dr3["ScoresPAT4"] = _dataRecordedEducation["ScoresPAT4"]; 
                                        _dr3["ScoresPAT5"] = _dataRecordedEducation["ScoresPAT5"]; 
                                        _dr3["ScoresPAT6"] = _dataRecordedEducation["ScoresPAT6"]; 
                                        _dr3["ScoresPAT7"] = _dataRecordedEducation["ScoresPAT7"]; 
                                        _dr3["ScoresPAT8"] = _dataRecordedEducation["ScoresPAT8"]; 
                                        _dr3["ScoresPAT9"] = _dataRecordedEducation["ScoresPAT9"]; 
                                        _dr3["ScoresPAT10"] = _dataRecordedEducation["ScoresPAT10"]; 
                                        _dr3["ScoresPAT11"] = _dataRecordedEducation["ScoresPAT11"]; 
                                        _dr3["ScoresPAT12"] = _dataRecordedEducation["ScoresPAT12"]; 
                                        */
                                        _dr3["Sportsman"] = _dataRecordedTalent["SportsmanDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["SpecialistSport"] = _dataRecordedTalent["SpecialistSportDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["SpecialistArt"] = _dataRecordedTalent["SpecialistArtDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["SpecialistTechnical"] = _dataRecordedTalent["SpecialistTechnicalDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["SpecialistOther"] = _dataRecordedTalent["SpecialistOtherDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["Activity"] = _dataRecordedTalent["ActivityDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["Reward"] = _dataRecordedTalent["RewardDetail"].ToString().Replace("\n", "\r\n"); 
                                        /*
                                        _dr3["Weight"] = _weight; 
                                        _dr3["Height"] = _height; 
                                        _dr3["BMI"] = _bmi; 
                                        _dr3["BMIDate"] = _bmiDate;
                                        _dr3["Intolerance"] = _dataRecordedHealthy["IntoleranceDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["Diseases"] = _dataRecordedHealthy["DiseasesDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["AilHistoryFamily"] = _dataRecordedHealthy["AilHistoryFamilyDetail"].ToString().Replace("\n", "\r\n"); 
                                        _dr3["TravelAbroad"] = _travelAbroad; 
                                        */
                                        _dr3["Impairments"] = (!String.IsNullOrEmpty(_dataRecordedHealthy["ImpairmentsNameTH"].ToString()) ? _dataRecordedHealthy["ImpairmentsNameTH"] : _dataRecordedHealthy["ImpairmentsNameEN"]); 
                                        _dr3["ImpairmentsEquipment"] = _dataRecordedHealthy["ImpairmentsEquipment"];
                                        _dr3["IdCardPWD"] = _dataRecordedHealthy["IdCardPWD"];
                                        _dr3["IdCardPWDIssueDate"] = (!String.IsNullOrEmpty(_dataRecordedHealthy["IdCardPWDIssueDateTH"].ToString()) ? _dataRecordedHealthy["IdCardPWDIssueDateTH"] : _dataRecordedHealthy["IdCardPWDIssueDateEN"]);
                                        _dr3["IdCardPWDExpiryDate"] = (!String.IsNullOrEmpty(_dataRecordedHealthy["IdCardPWDExpiryDateTH"].ToString()) ? _dataRecordedHealthy["IdCardPWDExpiryDateTH"] : _dataRecordedHealthy["IdCardPWDExpiryDateEN"]);
                                        /*
                                        _dr3["Occupation"] = (!String.IsNullOrEmpty(_dataRecordedWork["OccupationTH"].ToString()) ? _dataRecordedWork["OccupationTH"] : _dataRecordedWork["OccupationEN"]); 

                                        _strTemp1 = String.Empty;
                                        _strTemp2 = String.Empty;
                                        _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedWork["AgencyNameTH"].ToString()) ? _dataRecordedWork["AgencyNameTH"] : _dataRecordedWork["AgencyNameEN"]).ToString();
                                        _strTemp2 = _dataRecordedWork["AgencyOther"].ToString();

                                        _dr3["Agency"] = (!String.IsNullOrEmpty(_strTemp1) ? _strTemp1 : _strTemp2);
                                        _dr3["Workplace"] = _dataRecordedWork["Workplace"]; 
                                        _dr3["Position"] = _dataRecordedWork["Position"]; 
                                        _dr3["Telephone"] = _dataRecordedWork["Telephone"]; 
                                        _dr3["Salary"] = (!String.IsNullOrEmpty(_dataRecordedWork["Salary"].ToString()) ? double.Parse(_dataRecordedWork["Salary"].ToString()).ToString("#,##0.00") : "");
                                        */
                                        _dr3["ScholarshipFirstBachelorFrom"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["ScholarshipFirstBachelorFromTH"].ToString()) ? _dataRecordedFinancial["ScholarshipFirstBachelorFromTH"] : _dataRecordedFinancial["ScholarshipFirstBachelorFromEN"]); 
                                        _dr3["ScholarshipFirstBachelorName"] = _dataRecordedFinancial["ScholarshipFirstBachelorName"]; 
                                        _dr3["ScholarshipFirstBachelorMoney"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["ScholarshipFirstBachelorMoney"].ToString()) ? double.Parse(_dataRecordedFinancial["ScholarshipFirstBachelorMoney"].ToString()).ToString("#,##0.00") : "");
                                        _dr3["ScholarshipBachelorFrom"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["ScholarshipBachelorFromTH"].ToString()) ? _dataRecordedFinancial["ScholarshipBachelorFromTH"] : _dataRecordedFinancial["ScholarshipBachelorFromEN"]); 
                                        _dr3["ScholarshipBachelorName"] = _dataRecordedFinancial["ScholarshipBachelorName"]; 
                                        _dr3["ScholarshipBachelorMoney"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["ScholarshipBachelorMoney"].ToString()) ? double.Parse(_dataRecordedFinancial["ScholarshipBachelorMoney"].ToString()).ToString("#,##0.00") : "");
                                        _dr3["WorkDuringStudySalary"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["Salary"].ToString()) ? double.Parse(_dataRecordedFinancial["Salary"].ToString()).ToString("#,##0.00") : "");
                                        _dr3["WorkDuringStudyWorkplace"] = _dataRecordedFinancial["Workplace"]; 

                                        _strTemp1 = String.Empty;
                                        _strTemp2 = String.Empty;
                                        _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedFinancial["GotMoneyFromTH"].ToString()) ? _dataRecordedFinancial["GotMoneyFromTH"] : _dataRecordedFinancial["GotMoneyFromEN"]).ToString();
                                        _strTemp2 = _dataRecordedFinancial["GotMoneyFromOther"].ToString();

                                        _dr3["GotMoneyFrom"] = (!String.IsNullOrEmpty(_strTemp1) ? _strTemp1 : _strTemp2);
                                        _dr3["GotMoneyPerMonth"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["GotMoneyPerMonth"].ToString()) ? double.Parse(_dataRecordedFinancial["GotMoneyPerMonth"].ToString()).ToString("#,##0.00") : "");
                                        _dr3["CostPerMonth"] = (!String.IsNullOrEmpty(_dataRecordedFinancial["CostPerMonth"].ToString()) ? double.Parse(_dataRecordedFinancial["CostPerMonth"].ToString()).ToString("#,##0.00") : "");

                                        Dictionary<string, object> _dataRecordedFamilyPersonal = new Dictionary<string, object>();
                                        Dictionary<string, object> _dataRecordedFamilyAddress = new Dictionary<string, object>();
                                        Dictionary<string, object> _dataRecordedFamilyWork = new Dictionary<string, object>();
 
                                        for (_j = 0; _j < ePFStaffUtil._familyRelation.GetLength(0); _j++)
                                        {
                                            _dataRecordedFamilyPersonal.Clear();
                                            _dataRecordedFamilyAddress.Clear();
                                            _dataRecordedFamilyWork.Clear();

                                            if (ePFStaffUtil._familyRelation[_j, 0].Equals(ePFStaffUtil.SUBJECT_FAMILYFATHER))
                                            {
                                                _dataRecordedFamilyPersonal = _dataRecordedFamilyFatherPersonal;
                                                _dataRecordedFamilyAddress = _dataRecordedFamilyFatherAddress;
                                                _dataRecordedFamilyWork = _dataRecordedFamilyFatherWork;
                                            }
                                            if (ePFStaffUtil._familyRelation[_j, 0].Equals(ePFStaffUtil.SUBJECT_FAMILYMOTHER))
                                            {
                                                _dataRecordedFamilyPersonal = _dataRecordedFamilyMotherPersonal;
                                                _dataRecordedFamilyAddress = _dataRecordedFamilyMotherAddress;
                                                _dataRecordedFamilyWork = _dataRecordedFamilyMotherWork;
                                            }
                                            if (ePFStaffUtil._familyRelation[_j, 0].Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
                                            {
                                                _dataRecordedFamilyPersonal = _dataRecordedFamilyParentPersonal;
                                                _dataRecordedFamilyAddress = _dataRecordedFamilyParentAddress;
                                                _dataRecordedFamilyWork = _dataRecordedFamilyParentWork;
                                            }

                                            if (ePFStaffUtil._familyRelation[_j, 0].Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
                                                _dr3["Relationship"] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["RelationshipNameTH"].ToString()) ? _dataRecordedFamilyPersonal["RelationshipNameTH"] : _dataRecordedFamilyPersonal["RelationshipNameEN"]); 

                                            _dr3["IdCard" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyPersonal["IdCard" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["FullNameTH" + ePFStaffUtil._familyRelation[_j, 0]] = Util.GetFullName(_dataRecordedFamilyPersonal["TitleInitialsTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["TitleFullNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["FirstName" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["MiddleName" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["LastName" + ePFStaffUtil._familyRelation[_j, 0]].ToString()); 
                                            _dr3["FullNameEN" + ePFStaffUtil._familyRelation[_j, 0]] = Util.GetFullName(_dataRecordedFamilyPersonal["TitleInitialsEN" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["TitleFullNameEN" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["FirstNameEN" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["MiddleNameEN" + ePFStaffUtil._familyRelation[_j, 0]].ToString(), _dataRecordedFamilyPersonal["LastNameEN" + ePFStaffUtil._familyRelation[_j, 0]].ToString()); 
                                            _dr3["Alive" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["AliveTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["AliveTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["AliveEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            /*
                                            _dr3["Birthdate" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["BirthdateTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["BirthdateTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["BirthDateEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["Age" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyPersonal["Age" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["Country" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["CountryNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["CountryNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["CountryNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["Nationality" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["NationalityNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["NationalityNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["NationalityNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["Race" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["RaceNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["RaceNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["RaceNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["Religion" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["ReligionNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["ReligionNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["ReligionNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["BloodGroup" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["BloodGroupNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["BloodGroupNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["BloodGroupNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["MaritalStatus" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["MaritalStatusNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["MaritalStatusNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["MaritalStatusNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["EducationalBackgroundPerson" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyPersonal["EducationalBackgroundPersonNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyPersonal["EducationalBackgroundPersonNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyPersonal["EducationalBackgroundPersonNameEN" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["CountryPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["CountryNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["CountryNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["CountryNameENPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["ProvincePermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["ProvinceNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["ProvinceNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["ProvinceNameENPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["DistrictPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["DistrictNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["DistrictNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["DistrictNameENPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["SubDistrictPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["SubDistrictNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["SubDistrictNameTHPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["SubDistrictNameENPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["PostalCodePermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["PostalCodePermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["VillagePermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["VillagePermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["AddressNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["AddressNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["VillageNoPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["VillageNoPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["LaneAlleyPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["LaneAlleyPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["RoadPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["RoadPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["PhoneNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["PhoneNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["MobileNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["MobileNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["FaxNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["FaxNumberPermanentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["CountryCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["CountryNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["CountryNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["CountryNameENCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["ProvinceCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["ProvinceNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["ProvinceNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["ProvinceNameENCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["DistrictCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["DistrictNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["DistrictNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["DistrictNameENCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["SubDistrictCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyAddress["SubDistrictNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyAddress["SubDistrictNameTHCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyAddress["SubDistrictNameENCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]); 
                                            _dr3["PostalCodeCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["PostalCodeCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["VillageCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["VillageCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["AddressNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["AddressNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["VillageNoCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["VillageNoCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["LaneAlleyCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["LaneAlleyCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["RoadCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["RoadCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["PhoneNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["PhoneNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["MobileNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["MobileNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["FaxNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyAddress["FaxNumberCurrentAddress" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            */
                                            _dr3["Occupation" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyWork["OccupationTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyWork["OccupationTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyWork["OccupationEN" + ePFStaffUtil._familyRelation[_j, 0]]);
                                            /*
                                            _strTemp1 = String.Empty;
                                            _strTemp2 = String.Empty;
                                            _strTemp1 = (!String.IsNullOrEmpty(_dataRecordedFamilyWork["AgencyNameTH" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? _dataRecordedFamilyWork["AgencyNameTH" + ePFStaffUtil._familyRelation[_j, 0]] : _dataRecordedFamilyWork["AgencyNameEN" + ePFStaffUtil._familyRelation[_j, 0]]).ToString();
                                            _strTemp2 = _dataRecordedFamilyWork["AgencyOther" + ePFStaffUtil._familyRelation[_j, 0]].ToString();
                                        
                                            _dr3["Agency" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_strTemp1) ? _strTemp1 : _strTemp2);
                                            _dr3["Workplace" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyWork["Workplace" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["Position" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyWork["Position" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            _dr3["Telephone" + ePFStaffUtil._familyRelation[_j, 0]] = _dataRecordedFamilyWork["Telephone" + ePFStaffUtil._familyRelation[_j, 0]]; 
                                            */
                                            _dr3["Salary" + ePFStaffUtil._familyRelation[_j, 0]] = (!String.IsNullOrEmpty(_dataRecordedFamilyWork["Salary" + ePFStaffUtil._familyRelation[_j, 0]].ToString()) ? double.Parse(_dataRecordedFamilyWork["Salary" + ePFStaffUtil._familyRelation[_j, 0]].ToString()).ToString("#,##0.00") : "");
                                        }                                        
                                        
                                        _dt2.Rows.Add(_dr3);
                                    }

                                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                                    {
                                        Dictionary<string, object> _dataRecordedStudentRecords = ePFStaffStudentRecordsUtil.StudentRecordsUtil.SetValueDataRecorded(new Dictionary<string, object>(), _ds2);
                                        Dictionary<string, object> _dataRecordedPersonal = ePFStaffStudentRecordsUtil.PersonalUtil.SetValueDataRecorded(new Dictionary<string, object>(), Util.DBUtil.GetPersonRecordsPersonal(_dr1["id"].ToString()));

                                        _i++;
                                        
                                        DataRow _dr3 = _dt2.NewRow();

                                        _dr3["No."] = _i.ToString("#,##0"); 
                                        _dr3["StudentCode"] = _dataRecordedStudentRecords["StudentCode"]; 
                                        _dr3["FullNameTH"] = Util.GetFullName(_dataRecordedStudentRecords["TitleInitialsTH"].ToString(), _dataRecordedStudentRecords["TitleFullNameTH"].ToString(), _dataRecordedStudentRecords["FirstName"].ToString(), _dataRecordedStudentRecords["MiddleName"].ToString(), _dataRecordedStudentRecords["LastName"].ToString()); 
                                        _dr3["FullNameEN"] = Util.GetFullName(_dataRecordedStudentRecords["TitleInitialsEN"].ToString(), _dataRecordedStudentRecords["TitleFullNameEN"].ToString(), _dataRecordedStudentRecords["FirstNameEN"].ToString(), _dataRecordedStudentRecords["MiddleNameEN"].ToString(), _dataRecordedStudentRecords["LastNameEN"].ToString()); 
                                        _dr3["DegreeLevel"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["DegreeLevelNameTH"].ToString()) ? _dataRecordedStudentRecords["DegreeLevelNameTH"] : _dataRecordedStudentRecords["DegreeLevelNameEN"]); 
                                        _dr3["Faculty"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["FacultyNameTH"].ToString()) ? _dataRecordedStudentRecords["FacultyNameTH"] : _dataRecordedStudentRecords["FacultyNameEN"]); 
                                        _dr3["Program"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["ProgramNameTH"].ToString()) ? _dataRecordedStudentRecords["ProgramNameTH"] : _dataRecordedStudentRecords["ProgramNameEN"]); 
                                        _dr3["YearEntry"] = _dataRecordedStudentRecords["YearEntry"]; 
                                        _dr3["Class"] = _dataRecordedStudentRecords["Class"]; 
                                        _dr3["AdmissionType"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["EntranceTypeNameTH"].ToString()) ? _dataRecordedStudentRecords["EntranceTypeNameTH"] : _dataRecordedStudentRecords["EntranceTypeNameEN"]); 
                                        _dr3["StudentStatus"] = (!String.IsNullOrEmpty(_dataRecordedStudentRecords["StatusTypeNameTH"].ToString()) ? _dataRecordedStudentRecords["StatusTypeNameTH"] : _dataRecordedStudentRecords["StatusTypeNameEN"]); 
                                        _dr3["AdmissionDate"] = _dataRecordedStudentRecords["AdmissionDate"]; 
                                        _dr3["GraduationDate"] = _dataRecordedStudentRecords["GraduationDate"];  
                                        _dr3["ReasonOfGraduation"] = (_dataRecordedStudentRecords["StatusGroup"].Equals("02") && !String.IsNullOrEmpty(_dataRecordedStudentRecords["UpdateReason"].ToString()) ? _dataRecordedStudentRecords["UpdateReason"].ToString().Replace("\n", "\r\n") : String.Empty);                                                                               
                                        _dr3["IdCard"] = _dataRecordedPersonal["IdCard"]; 
                                        _dr3["Gender"] = (!String.IsNullOrEmpty(_dataRecordedPersonal["GenderFullNameTH"].ToString()) ? _dataRecordedPersonal["GenderFullNameTH"] : _dataRecordedPersonal["GenderFullNameEN"]); 
                                        _dr3["EmailAddress"] = _dataRecordedPersonal["EmailAddress"];

                                        _dt2.Rows.Add(_dr3);
                                    }
                                }

                                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS))
                                {
                                    DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                        new SqlParameter("@action", "UPDATE"),
                                        new SqlParameter("@personId", _dr1["id"].ToString()),
                                        new SqlParameter("@mspJoin", _dataProcess["JoinProgramStatus"]),
                                        new SqlParameter("@startSemester", _dataProcess["StartSemester"]),
                                        new SqlParameter("@startYear", _dataProcess["StartYear"]),
                                        new SqlParameter("@endSemester", _dataProcess["EndSemester"]),
                                        new SqlParameter("@endYear", _dataProcess["EndYear"]),
                                        new SqlParameter("@resignDate", _dataProcess["ResignDate"]),
                                        new SqlParameter("@updateWhat", ePFStaffUtil.SUBJECT_SECTION_UPDATESTUDENTMEDICALSCHOLARSPROGRAM),
                                        new SqlParameter("@updateReason", _dataProcess["UpdateReason"]),
                                        new SqlParameter("@by", _username),
                                        new SqlParameter("@ip", Util.GetIP())
                                    );

                                    DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                    _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                    _ds3.Dispose();

                                    if (_saveError.Equals(0))
                                        _studentId.Add((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"]);
                                    else
                                    {
                                        _error = true;
                                        _msgDetail = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"].ToString() + "-") : String.Empty) + _dr2["idCard"] + " : ปรับปรุงข้อมูลไม่เร็จ");
                                    }
                                }
                            }
                            else
                            {
                                _error = true;
                                _msgDetail = (_dr1["id"].ToString() + " : ไม่พบข้อมูล");
                            }

                            _ds2.Dispose();

                            if (_error.Equals(false))
                            {
                                _valueDetailComplte.Add(_dr1["id"].ToString());
                                _complete++;
                            }
                            else
                            {
                                _valueDetailIncomplte.Add(_msgDetail);
                                _incomplete++;
                            }   
                        }            
                        catch(Exception _ex)
                        {
                            _valueDetailIncomplte.Add(_dr1["id"].ToString() + " : ประมวลผลไม่สำเร็จ - " + _ex.Message);
                            _incomplete++;
                        }
                    }
                }

                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS))
                {
                    try
                    {
                        Dictionary<string, object> _tb1 = new Dictionary<string, object>();
                        Dictionary<string, object> _tb2 = new Dictionary<string, object>();
                        Dictionary<string, object> _tb3 = new Dictionary<string, object>();
                        Dictionary<string, object> _tb4 = new Dictionary<string, object>();

                        _tb1.Add("Index", "");
                        _tb1.Add("DataLevel", "");
                        _tb1.Add("DataId", "");
                        _tb1.Add("Id", "");
                        _tb1.Add("SeriesDataName1", "");
                        _tb1.Add("SeriesDataName2", "");
                        _tb1.Add("Value1", "");
                        _tb1.Add("Value2", "");
                        _tb1.Add("DrillDownId", "");

                        _tb2.Add("Index", "");
                        _tb2.Add("DataLevel", "");
                        _tb2.Add("DataId", "");
                        _tb2.Add("Id", "");
                        _tb2.Add("SeriesDataName1", "");
                        _tb2.Add("SeriesDataName2", "");
                        _tb2.Add("Value1", "");
                        _tb2.Add("Value2", "");
                        _tb2.Add("DrillDownId", "");

                        _tb3.Add("Index", "");
                        _tb3.Add("DataLevel", "");
                        _tb3.Add("DataId", "");
                        _tb3.Add("Id", "");
                        _tb3.Add("SeriesDataName1", "");
                        _tb3.Add("SeriesDataName2", "");
                        _tb3.Add("Value1", "");
                        _tb3.Add("Value2", "");
                        _tb3.Add("DrillDownId", "");

                        _tb4.Add("Index", "");
                        _tb4.Add("DataLevel", "");
                        _tb4.Add("DataId", "");
                        _tb4.Add("Id", "");
                        _tb4.Add("SeriesDataName1", "");
                        _tb4.Add("SeriesDataName2", "");
                        _tb4.Add("Value1", "");
                        _tb4.Add("Value2", "");
                        _tb4.Add("DrillDownId", "");

                        _tb1["Index"] = 2;
                        _tb1["DataLevel"] = "";
                        _tb1["DataId"] = "";
                        _tb1["Id"] = "";
                        _tb1["SeriesDataName1"] = "statusGroupNameTH";
                        _tb1["SeriesDataName2"] = "statusGroupNameEN";
                        _tb1["Value1"] = "countMalePeople";
                        _tb1["Value2"] = "countFemalePeople";
                        _tb1["DrillDownId"] = "drilldownId";

                        _tb2["Index"] = 3;
                        _tb2["DataLevel"] = "";
                        _tb2["DataId"] = "";
                        _tb2["Id"] = "id";
                        _tb2["SeriesDataName1"] = "yearEntry";
                        _tb2["SeriesDataName2"] = "";
                        _tb2["Value1"] = "countMalePeople";
                        _tb2["Value2"] = "countFemalePeople";
                        _tb2["DrillDownId"] = "drilldownId";

                        _tb3["Index"] = 4;
                        _tb3["DataLevel"] = "";
                        _tb3["DataId"] = "";
                        _tb3["Id"] = "id";
                        _tb3["SeriesDataName1"] = "faculty";
                        _tb3["SeriesDataName2"] = "facultyNameTH";
                        _tb3["Value1"] = "countMalePeople";
                        _tb3["Value2"] = "countFemalePeople";
                        _tb3["DrillDownId"] = "drilldownId";

                        _tb4["Index"] = 5;
                        _tb4["DataLevel"] = "";
                        _tb4["DataId"] = "";
                        _tb4["Id"] = "id";
                        _tb4["SeriesDataName1"] = "program";
                        _tb4["SeriesDataName2"] = "programNameTH";
                        _tb4["Value1"] = "countMalePeople";
                        _tb4["Value2"] = "countFemalePeople";
                        _tb4["DrillDownId"] = "drilldownId";

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);

                        _tb1["Index"] = 6;
                        _tb1["SeriesDataName1"] = "degreeLevelNameTH";
                        _tb1["SeriesDataName2"] = "degreeLevelNameEN";

                        _tb2["Index"] = 7;

                        _tb3["Index"] = 8;

                        _tb4["Index"] = 9;

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);

                        _tb1["Index"] = 10;
                        _tb1["SeriesDataName1"] = "yearEntry";
                        _tb1["SeriesDataName2"] = "";

                        _tb2["Index"] = 11;
                        _tb2["SeriesDataName1"] = "faculty";
                        _tb2["SeriesDataName2"] = "facultyNameTH";

                        _tb3["Index"] = 12;
                        _tb3["SeriesDataName1"] = "program";
                        _tb3["SeriesDataName2"] = "programNameTH";

                        _tb4["Index"] = -1;

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);

                        _tb1["Index"] = 13;
                        _tb1["SeriesDataName1"] = "stdEntranceTypeNameTH";
                        _tb1["SeriesDataName2"] = "stdEntranceTypeNameEN";

                        _tb2["Index"] = 14;
                        _tb2["SeriesDataName1"] = "yearEntry";
                        _tb2["SeriesDataName2"] = "";

                        _tb3["Index"] = 15;
                        _tb3["SeriesDataName1"] = "faculty";
                        _tb3["SeriesDataName2"] = "facultyNameTH";

                        _tb4["Index"] = 16;
                        _tb4["SeriesDataName1"] = "program";
                        _tb4["SeriesDataName2"] = "programNameTH";

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);

                        _tb1["Index"] = 17;
                        _tb1["SeriesDataName1"] = "class";
                        _tb1["SeriesDataName2"] = "";

                        _tb2["Index"] = 18;

                        _tb3["Index"] = 19;

                        _tb4["Index"] = 20;

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);

                        _tb1["Index"] = 21;
                        _tb1["SeriesDataName1"] = "isoNationalityName3Letter";
                        _tb1["SeriesDataName2"] = "";

                        _tb2["Index"] = 22;

                        _tb3["Index"] = 23;

                        _tb4["Index"] = 24;

                        _dt2 = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds1, _dt2, _tb1, _tb2, _tb3, _tb4);
                        
                        _complete = _dt2.Rows.Count;
                    }
                    catch(Exception _ex)
                    {
                        _valueDetailIncomplte.Add("ประมวลผลไม่สำเร็จ - " + _ex.Message);
                        _incomplete++;
                    }
                }
            }

            _ds1.Dispose();

            if (_complete > 0)
            {
                if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEFACULTYPROGRAM_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATECLASSYEAR_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEENTRANCETYPE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATESTUDENTSTATUS_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEADMISSIONDATE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS))
                    _zip.AddEntry("UpdateLog.txt", (_msgTH + "สำเร็จจำนวน " + _complete.ToString("#,##0") + " รายการ" + Environment.NewLine + String.Join(Environment.NewLine, _studentId.ToArray())));
                
                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                {                    
                    ExcelPackage _pk = new ExcelPackage();
                    ExcelWorksheet _ws = _pk.Workbook.Worksheets.Add("Sheet1");

                    int _maxRowCellRange = 0;
                    int _maxColCellRange = 0;
                    int _maxRowCellHeader = 0;
                    int _maxColCellHeader = 0;
                    var _cellHeader = _ws.Cells;

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS))
                    {
                        _maxRowCellRange = (_complete + 2);
                        _maxColCellRange = 77;
                        _maxRowCellHeader = 2;
                        _maxColCellHeader = 77;
                    }
                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS))
                    {
                        _maxRowCellRange = (_complete + 1);
                        _maxColCellRange = 4;
                        _maxRowCellHeader = 1;
                        _maxColCellHeader = 4;
                    }
                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                    {
                        _maxRowCellRange = (_complete + 1);
                        _maxColCellRange = _dt2.Columns.Count;
                        _maxRowCellHeader = 1;
                        _maxColCellHeader = _dt2.Columns.Count;
                    }

                    Util.SetCellExcel(_ws, _maxRowCellRange, _maxColCellRange, _maxRowCellHeader, _maxColCellHeader);
          
                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "คำนำหน้าชื่อ ( ภาษาไทย )", "TitlePrefixTH", "", "" },
                            new[] { "คำนำหน้าชื่อ ( ภาษาอังกฤษ )", "TitlePrefixEN", "", "" },
                            new[] { "ชื่อ ( ภาษาไทย )", "FirstNameTH", "", "" },
                            new[] { "ชื่อ ( ภาษาอังกฤษ )", "FirstNameEN", "", "" },
                            new[] { "ชื่อกลาง ( ภาษาไทย )", "MiddleNameTH", "", "" },
                            new[] { "ชื่อกลาง ( ภาษาอังกฤษ )", "MiddleNameEN", "", "" },
                            new[] { "นามสกุล ( ภาษาไทย )", "LastNameTH", "", "" },
                            new[] { "นามสกุล ( ภาษาอังกฤษ )", "LastNameEN", "", "" },
                            new[] { "ชื่อเต็ม ( ภาษาไทย )", "FullNameTH", "", "" },
                            new[] { "ชื่อเต็ม ( ภาษาอังกฤษ )", "FullNameEN", "", "" },
                            new[] { "ระดับการศึกษา", "DegreeLevel", "", "" },
                            new[] { "คณะ", "Faculty", "", "" },
                            new[] { "รหัสหลักสูตร", "ProgramCode", "", "" },
                            new[] { "หลักสูตร", "Program", "", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "ชั้นปี", "Class", "center", "" },
                            new[] { "ระบบการสอบเข้า", "AdmissionType", "", "" },
                            new[] { "สถานภาพการเป็นนักศึกษา", "StudentStatus", "center", "" },
                            new[] { "วันที่เข้าศึกษา", "AdmissionDate", "center", "" },
                            new[] { "วันที่สำเร็จการศึกษา", "GraduationDate", "center", "" },
                            new[] { "เหตุผลที่ออกจากการศึกษา", "ReasonOfGraduation", "", "true" },
                            new[] { "เลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง", "IdCard", "center", "" },
                            new[] { "เพศ", "Gender", "center", "" },
                            /*
                            new[] { "สถานภาพชีวิต", "Alive", "center", "" },
                            */
                            new[] { "วันเดือนปีเกิด", "Birthdate", "center", "" },
                            new[] { "อายุ ( ปี )", "Age", "center", "" },
                            /*
                            new[] { "ประเทศบ้านเกิด", "Country", "", "" },
                            */
                            new[] { "สัญชาติ", "Nationality", "center", "" },
                            new[] { "ประเทศ", "CountryPermanentAddress", "", "" },
                            new[] { "จังหวัด", "ProvincePermanentAddress", "", "" },
                            /*
                            new[] { "เชื้อชาติ", "Race", "center", "" },
                            new[] { "ศาสนา", "Religion", "center", "" },
                            new[] { "กรุ๊ปเลือด", "BloodGroup", "center", "" },
                            new[] { "สถานภาพทางการสมรส", "MaritalStatus", "center", "" },
                            new[] { "วุฒิการศึกษา", "EducationalBackgroundPerson", "", "" },
                            new[] { "จำนวนพี่น้องทั้งหมด ( รวมตัวเอง ) ( คน )", "Brotherhood", "center", "" },
                            new[] { "นักศึกษาเป็นบุตรคนที่", "Childhood", "center", "" },
                            new[] { "จำนวนพี่น้องที่กำลังศึกษาอยู่ ( รวมตัวเอง ) ( คน )", "Studyhood", "center", "" },
                            new[] { "อีเมล์", "EmailAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nประเทศ", "CountryPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nจังหวัด", "ProvincePermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nอำเภอ / เขต", "DistrictPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nตำบล / แขวง", "SubDistrictPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nรหัสไปรษณีย์", "PostalCodePermanentAddress", "center", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nหมู่บ้าน", "VillagePermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nบ้านเลขที่", "AddressNumberPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nหมู่ที่", "VillageNoPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nตรอก / ซอย", "LaneAlleyPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nถนน", "RoadPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nเบอร์โทรศัพท์บ้าน", "PhoneNumberPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nเบอร์โทรศัพท์มือถือ", "MobileNumberPermanentAddress", "", "" },
                            new[] { "ข้อมูลทีอยู่ตามทะเบียนบ้าน\nเบอร์แฟกซ์", "FaxNumberPermanentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nประเทศ", "CountryCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nจังหวัด", "ProvinceCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nอำเภอ / เขต", "DistrictCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nตำบล / แขวง", "SubDistrictCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nรหัสไปรษณีย์", "PostalCodeCurrentAddress", "center", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nหมู่บ้าน", "VillageCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nบ้านเลขที่", "AddressNumberCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nหมู่ที่", "VillageNoCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nตรอก / ซอย", "LaneAlleyCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nถนน", "RoadCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nเบอร์โทรศัพท์บ้าน", "PhoneNumberCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nเบอร์โทรศัพท์มือถือ", "MobileNumberCurrentAddress", "", "" },
                            new[] { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้\nเบอร์แฟกซ์", "FaxNumberCurrentAddress", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nชื่อสถานศึกษา", "InstituteNamePrimarySchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nประเทศ", "InstituteCountryPrimarySchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nจังหวัด", "InstituteProvincePrimarySchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nปีที่เข้าศึกษา", "YearAttendedPrimarySchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nปีที่สำเร็จการศึกษา", "YearGraduatePrimarySchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับประถม\nเกรดเฉลี่ยสะสม", "GPAPrimarySchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nชื่อสถานศึกษา", "InstituteNameJuniorHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nประเทศ", "InstituteCountryJuniorHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nจังหวัด", "InstituteProvinceJuniorHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nปีที่เข้าศึกษา", "YearAttendedJuniorHighSchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nปีที่สำเร็จการศึกษา", "YearGraduateJuniorHighSchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมต้น\nเกรดเฉลี่ยสะสม", "GPAJuniorHighSchool", "center", "" },
                            */
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nชื่อสถานศึกษา", "InstituteNameHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nประเทศ", "InstituteCountryHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nจังหวัด", "InstituteProvinceHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nเลขประจำตัวนักเรียน", "StudentIdHighSchool", "center", "" },
                            /*
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nสายการเรียน", "EducationalMajorHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nปีที่เข้าศึกษา", "YearAttendedHighSchool", "center", "" },
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nปีที่สำเร็จการศึกษา", "YearGraduateHighSchool", "center", "" },
                            */
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nเกรดเฉลี่ยสะสม", "GPAHighSchool", "center", "" },
                            /*
                            new[] { "ข้อมูลการศึกษาระดับมัธยมปลาย\nวุฒิการศึกษา", "EducationalBackgroundHighSchool", "", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nวุฒิการศึกษาขั้นสูงสุดก่อนเข้าม.มหิดล", "EducationalBackground", "", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nสำเร็จการศึกษาขั้นสูงสุดโดยวิธี", "GraduateBy", "", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nจำนวนครั้งที่สอบเข้าในระดับมหาวิทยาลัย", "EntranceTime", "center", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nการเข้าเป็นนักศึกษามหาวิทยาลัย", "StudentIs", "", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nระบบการสอบเข้า", "EntranceType", "", "" },
                            new[] { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล\nเลือก ม.มหิดลเป็นอันดับที่", "AdmissionRanking", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET ภาษาไทย", "ScoresONETThai", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET สังคมศึกษา", "ScoresONETSocialScience", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET ภาษาอังกฤษ", "ScoresONETEnglish", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET คณิตศาสตร์", "ScoresONETMathematics", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET วิทยาศาสตร์", "ScoresONETScience", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET สุขศึกษาและพลศึกษา", "ScoresONETHealthPhysical", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET ศิลปะ", "ScoresONETArts", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nO-NET การงานอาชีพและเทคโนโลยี", "ScoresONETOccupationTechnology", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nA-NET ภาษาไทย 2", "ScoresANETThai2", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nA-NET สังคมศึกษา 2", "ScoresANETSocialScience2", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nA-NET ภาษาอังกฤษ 3", "ScoresANETEnglish3", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nA-NET คณิตศาสตร์ 2", "ScoresANETMathematics2", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nA-NET วิทยาศาสตร์ 2", "ScoresANETScience2", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nGAT ความถนัดทั่วไป", "ScoresGATGenaralAptitudeTest", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 1 ความถนัดคณิตศาสตร์", "ScoresPAT1", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 2 ความถนัดวิทยาศาสตร์", "ScoresPAT2", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 3 ความถนัดวิศวกรรมศาสตร์", "ScoresPAT3", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 4 ความถนัดสถาปัตยกรรมศาสตร์", "ScoresPAT4", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 5 ความถนัดวิชาชีพครู", "ScoresPAT5", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 6 ความถนัดศิลปกรรมศาสตร์", "ScoresPAT6", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 7 ภาษาฝรั่งเศส", "ScoresPAT7", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 8 ภาษาเยอรมัน", "ScoresPAT8", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 9 ภาษาญี่ปุ่น", "ScoresPAT9", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 10 ภาษาจีน", "ScoresPAT10", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 11 ภาษาอาหรับ", "ScoresPAT11", "center", "" },
                            new[] { "ข้อมูลการศึกษาคะแนนสอบ\nPAT 12 ภาษาบาลี", "ScoresPAT12", "center", "" },
                            */              
                            new[] { "มีความพิการทาง", "Impairments", "", "" },
                            new[] { "อุปกรณ์ช่วยเหลือ", "ImpairmentsEquipment", "", "" },
                            new[] { "บัตรประจำตัวคนพิการ\nเลขประจำตัวคนพิการ", "IdCardPWD", "center", "" },
                            new[] { "บัตรประจำตัวคนพิการ\nวันออกบัตร", "IdCardPWDIssueDate", "center", "" },
                            new[] { "บัตรประจำตัวคนพิการ\nวันหมดอายุ", "IdCardPWDExpiryDate", "center", "" },
                            new[] { "ก่อนศึกษาระดับป.ตรีได้รับทุนการศึกษาจาก", "ScholarshipFirstBachelorFrom", "", "" },
                            new[] { "ก่อนศึกษาระดับป.ตรีได้รับทุนการศึกษาชื่อ", "ScholarshipFirstBachelorName", "", "" },
                            new[] { "ก่อนศึกษาระดับป.ตรีได้รับทุนการศึกษาเป็นจำนวนเงิน ( บาท / ปี )", "ScholarshipFirstBachelorMoney", "", "" },
                            new[] { "ระหว่างศึกษาระดับป.ตรีได้รับทุนการศึกษาจาก", "ScholarshipBachelorFrom", "", "" },
                            new[] { "ระหว่างศึกษาระดับป.ตรีได้รับทุนการศึกษาชื่อ", "ScholarshipBachelorName", "", "" },
                            new[] { "ระหว่างศึกษาระดับป.ตรีได้รับทุนการศึกษาเป็นจำนวนเงิน ( บาท / ปี )", "ScholarshipBachelorMoney", "", "" },
                            new[] { "ระหว่างศึกษานักศึกษาทำงานมีรายได้ประมาณ ( บาท / เดือน )", "WorkDuringStudySalary", "", "" },
                            new[] { "ระหว่างศึกษานักศึกษาทำงานที่", "WorkDuringStudyWorkplace", "", "" },
                            new[] { "ได้รับการอุปการะเงินค่าใช้จ่ายส่วนใหญ่จาก", "GotMoneyFrom", "", "" },
                            new[] { "ได้รับการอุปการะเงินค่าใช้จ่ายเดือนละ ( บาท / เดือน )", "GotMoneyPerMonth", "", "" },
                            new[] { "ค่าใช้จ่ายส่วนตัวไม่รวมค่าธรรมเนียมการศึกษา ( บาท / เดือน )", "CostPerMonth", "", "" },
                            new[] { "เคยเป็นนักกีฬา", "Sportsman", "", "true" },
                            new[] { "ความสามารถพิเศษด้านกีฬา", "SpecialistSport", "", "true" },
                            new[] { "ความสามารถพิเศษด้านศิลปะ", "SpecialistArt", "", "true" },
                            new[] { "ความสามารถพิเศษด้านวิชาการ", "SpecialistTechnical", "", "true" },
                            new[] { "ความสามารถพิเศษด้านอื่น ๆ", "SpecialistOther", "", "true" },
                            new[] { "เคยร่วมกิจกรรมของโรงเรียน", "Activity", "", "true" },
                            new[] { "เคยได้รับทุน / รางวัล", "Reward", "", "true" },
                            /*
                            new[] { "น้ำหนัก ( กก. )", "Weight", "center", "" },
                            new[] { "ส่วนสูง ( ซม. )", "Height", "center", "" },
                            new[] { "BMI", "BMI", "center", "" },
                            new[] { "BMI ข้อมูล ณ วันที่", "BMIDate", "center", "" },
                            new[] { "ประวัติแพ้ยา", "Intolerance", "", "true" },
                            new[] { "โรคประจำตัว", "Diseases", "", "true" },
                            new[] { "ประวัติการเจ็บป่วยในครอบครัว", "AilHistoryFamily", "", "true" },
                            new[] { "ประวัติเดินทางไปต่างประเทศและวันที่เดินทาง", "TravelAbroad", "", "true" },
                            new[] { "ความบกพร่อง", "Impairments", "", "" },
                            new[] { "อุปกรณ์ช่วยเหลือ", "ImpairmentsEquipment", "", "" },
                            new[] { "อาชีพ", "Occupation", "", "" },
                            new[] { "ต้นสังกัด", "Agency", "", "" },
                            new[] { "สถานที่ทำงาน", "Workplace", "", "" },
                            new[] { "ตำแหน่ง", "Position", "", "" },
                            new[] { "โทรศัพท์ที่ทำงาน", "Telephone", "", "" },
                            new[] { "รายได้เฉลี่ยต่อเดือน ( บาท )", "Salary", "", "" },
                            */
                        };

                        string _headerContent = String.Empty;

                        for (_i = 0; _i < ePFStaffUtil._familyRelation.GetLength(0); _i++)
                        {
                            if (ePFStaffUtil._familyRelation[_i, 0].Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
                            _cellContent.Add(new[] { "ความสัมพันธ์ของผู้ปกครอง", "Relationship", "center", "" });

                            _headerContent = ("ข้อมูลส่วนตัวของ" + ePFStaffUtil._familyRelation[_i, 1]);
                            _cellContent.Add(new[] { (_headerContent + "\nเลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง"), ("IdCard" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nชื่อ ( ภาษาไทย )"), ("FullNameTH" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nชื่อ ( ภาษาอังกฤษ )"), ("FullNameEN" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nสถานภาพชีวิต"), ("Alive" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            /*
                            _cellContent.Add(new[] { (_headerContent + "\nวันเดือนปีเกิด"), ("Birthdate" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nอายุ ( ปี )"), ("Age" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nประเทศบ้านเกิด"), ("Country" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nสัญชาติ"), ("Nationality" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเชื้อชาติ"), ("Race" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nศาสนา"), ("Religion" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nกรุ๊ปเลือด"), ("BloodGroup" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nสถานภาพทางการสมรส"), ("MaritalStatus" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nวุฒิการศึกษา"), ("EducationalBackgroundPerson" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
              
                            _headerContent = ("ข้อมูลทีอยู่ตามทะเบียนบ้านของ" + ePFStaffUtil._familyRelation[_i, 1]);
                            _cellContent.Add(new[] { (_headerContent + "\nประเทศ"), ("CountryPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nจังหวัด"), ("ProvincePermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nอำเภอ / เขต"), ("DistrictPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nตำบล / แขวง"), ("SubDistrictPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nรหัสไปรษณีย์"), ("PostalCodePermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nหมู่บ้าน"), ("VillagePermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nบ้านเลขที่"), ("AddressNumberPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nหมู่ที่"), ("VillageNoPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nตรอก / ซอย"), ("LaneAlleyPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nถนน"), ("RoadPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์โทรศัพท์บ้าน"), ("PhoneNumberPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์โทรศัพท์มือถือ"), ("MobileNumberPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์แฟกซ์"), ("FaxNumberPermanentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });

                            _headerContent = ("ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้ของ" + ePFStaffUtil._familyRelation[_i, 1]);
                            _cellContent.Add(new[] { (_headerContent + "\nประเทศ"), ("CountryCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nจังหวัด"), ("ProvinceCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nอำเภอ / เขต"), ("DistrictCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nตำบล / แขวง"), ("SubDistrictCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nรหัสไปรษณีย์"), ("PostalCodeCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "center", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nหมู่บ้าน"), ("VillageCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nบ้านเลขที่"), ("AddressNumberCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nหมู่ที่"), ("VillageNoCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nตรอก / ซอย"), ("LaneAlleyCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nถนน"), ("RoadCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์โทรศัพท์บ้าน"), ("PhoneNumberCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์โทรศัพท์มือถือ"), ("MobileNumberCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nเบอร์แฟกซ์"), ("FaxNumberCurrentAddress" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            */
                            _headerContent = ("ข้อมูลการทำงานของ" + ePFStaffUtil._familyRelation[_i, 1]);
                            _cellContent.Add(new[] { (_headerContent + "\nอาชีพ"), ("Occupation" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            /*
                            _cellContent.Add(new[] { (_headerContent + "\nต้นสังกัด"), ("Agency" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nสถานที่ทำงาน"), ("Workplace" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nตำแหน่ง"), ("Position" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            _cellContent.Add(new[] { (_headerContent + "\nโทรศัพท์ที่ทำงาน"), ("Telephone" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                            */
                            _cellContent.Add(new[] { (_headerContent + "\nรายได้เฉลี่ยต่อเดือน ( บาท )"), ("Salary" + ePFStaffUtil._familyRelation[_i, 0]), "", "" });
                        }

                        _cellHeader = _ws.Cells[2, 1, _maxRowCellHeader, _maxColCellHeader];
                        _cellHeader.Style.Border.Top.Style = ExcelBorderStyle.None;
                        _cellHeader.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        _i = 1;

                        foreach (object _c in _cellContent)
                        {
                            string _header = ((string[])_c)[0];
                            string[] _headerArray = _header.Split('\n');

                            _ws.Cells[1, _i].Value = _headerArray[0];
                            _ws.Cells[2, _i].Value = (_headerArray.Length > 1 ? _headerArray[1] : String.Empty);
                            _i++;
                        }

                        _ws.Cells[_maxRowCellRange, 1, _maxRowCellRange, _maxColCellRange].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS))
                    {
                        _ws.Cells[1, 1].Value = "รายการ";
                        _ws.Cells[1, 2].Value = "จำนวนนักศึกษาชาย ( คน )";
                        _ws.Cells[1, 3].Value = "จำนวนนักศึกษาหญิง ( คน )";
                        _ws.Cells[1, 4].Value = "รวมจำนวนนักศึกษา ( คน )";
                        _ws.Cells[(_maxRowCellHeader + 1), 2, _maxRowCellRange, _maxColCellRange].Style.HorizontalAlignment  = ExcelHorizontalAlignment.Right;

                        _i = (_maxRowCellHeader + 1);

                        foreach (DataRow _dr3 in _dt2.Rows)
                        {
                            int _indent = 0;
                            string _backgroundColor = String.Empty;
                            string _fontColor = String.Empty;

                            if (_dr3["OrderLevel"].Equals("ZeroLevel")) 
                            {
                                _indent = 0;
                                _backgroundColor = "#000000";
                                _fontColor = "#FFFFFF";
                            }
                                    
                            if (_dr3["OrderLevel"].Equals("FirstLevel"))
                            {
                                _indent = 3;
                                _backgroundColor = "#A6A6A6";
                                _fontColor = "#000000";
                            }

                            if (_dr3["OrderLevel"].Equals("SecondLevel"))
                            {
                                _indent = 6;
                                _backgroundColor = "#C9C9C9";
                                _fontColor = "#000000";
                            }

                            if (_dr3["OrderLevel"].Equals("ThirdLevel"))
                            {
                                _indent = 9;
                                _backgroundColor = "#EEEEEE";
                                _fontColor = "#000000";
                            }
                                    
                            if (_dr3["OrderLevel"].Equals("LastLevel"))
                            {
                                _indent = 12;
                                _backgroundColor = "#FFFFFF";
                                _fontColor = "#000000";
                            }

                            _ws.Cells[_i, 1, _i, _maxColCellRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            _ws.Cells[_i, 1, _i, _maxColCellRange].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(_backgroundColor));
                            _ws.Cells[_i, 1, _i, _maxColCellRange].Style.Font.Color.SetColor(ColorTranslator.FromHtml(_fontColor));

                            _ws.Cells[_i, 1].Style.Indent = _indent;
                            _ws.Cells[_i, 1].Value = Util.GetBlank(_dr3["ItemTH"].ToString() + (!String.IsNullOrEmpty(_dr3["ItemTH"].ToString()) && (!String.IsNullOrEmpty(_dr3["ItemEN"].ToString())) ? (" : " + _dr3["ItemEN"]) : ""), "");
                            _ws.Cells[_i, 2].Value = Util.GetBlank(_dr3["CountMalePeople"].ToString(), "");
                            _ws.Cells[_i, 3].Value = Util.GetBlank(_dr3["CountFemalePeople"].ToString(), "");
                            _ws.Cells[_i, 4].Value = Util.GetBlank(_dr3["SummaryPeople"].ToString(), "");

                            _i++;
                        }
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "ชื่อ ( ภาษาไทย )", "FullNameTH", "", "" },
                            new[] { "ชื่อ ( ภาษาอังกฤษ )", "FullNameEN", "", "" },
                            new[] { "ระดับการศึกษา", "DegreeLevel", "", "" },
                            new[] { "คณะ", "Faculty", "", "" },
                            new[] { "หลักสูตร", "Program", "", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "ชั้นปี", "Class", "center", "" },
                            new[] { "ระบบการสอบเข้า", "AdmissionType", "", "" },
                            new[] { "สถานภาพการเป็นนักศึกษา", "StudentStatus", "center", "" },
                            new[] { "วันที่เข้าศึกษา", "AdmissionDate", "center", "" },
                            new[] { "วันที่สำเร็จการศึกษา", "GraduationDate", "center", "" },
                            new[] { "เหตุผลที่ออกจากการศึกษา", "ReasonOfGraduation", "", "true" },
                            new[] { "เลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง", "IdCard", "center", "" },
                            new[] { "เพศ", "Gender", "center", "" },
                            new[] { "อีเมล์", "EmailAddress", "", "" }
                        };

                        _i = 1;

                        foreach (object _c in _cellContent)
                        {
                            string _header = ((string[])_c)[0];

                            _ws.Cells[1, _i].Value = _header;
                            _i++;
                        }

                        Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                    }

                    _ws.Cells.AutoFitColumns();

                    _pk.SaveAs(_ms);
                    _ms.Seek(0, SeekOrigin.Begin);
                    _zip.AddEntry((_fileName + ".xlsx"), _ms);
                }
            }
            
            if (_incomplete > 0)
                _zip.AddEntry("ErrorLog.txt", (_msgTH + "ไม่สำเร็จจำนวน " + _incomplete.ToString("#,##0") + " รายการ" + Environment.NewLine + String.Join(Environment.NewLine, _valueDetailIncomplte.ToArray())));

            _zip.Save(_filePath + _fileName + ".zip");
            _zip.Dispose();
        }

        _ms.Close();
        _ms.Dispose();

        _processResult.Add("Complete", _complete.ToString("#,##0"));
        _processResult.Add("Incomplete", _incomplete.ToString("#,##0"));
        _processResult.Add("DetailComplete", String.Join(",", _valueDetailComplte.ToArray()));
        _processResult.Add("DetailIncomplete", String.Join(",", _valueDetailIncomplte.ToArray()));
        _processResult.Add("DownloadFolder", ePFStaffUtil._myFileDownloadPath);
        _processResult.Add("DownloadFile", (_fileName + ".zip"));

        return _processResult;
    }
}