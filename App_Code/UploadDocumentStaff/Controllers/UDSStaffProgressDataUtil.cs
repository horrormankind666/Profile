// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๓/๑๑/๒๕๕๘>
// Modify date  : <๒๘/๐๖/๒๕๖๒>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นการประมวลผลข้อมูล>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using NUtil;
using Ionic.Zip;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class UDSStaffProgressDataUtil
{
    //ฟังก์ชั่นสำหรับกำหนดค่าที่ใช้สำหรับการประมวลผลข้อมูล แล้วส่งค่ากลับเป็น Dictionary<string, object>
    //โดยมีพารามิเตอร์ดังนี้
    //1. _c เป็น HttpContext รับค่าข้อมูลจาก javascript ที่เรียกใช้งาน    
    public static Dictionary<string, object> SetValueProcess(HttpContext _c)
    {
        Dictionary<string, object> _valueProcessResult = new Dictionary<string, object>();
        _valueProcessResult.Add("Option",                   _c.Request["option"]);
        _valueProcessResult.Add("ParamSearch",              _c.Request["paramsearch"]);
        _valueProcessResult.Add("Selected",                 _c.Request["selected"]);
        _valueProcessResult.Add("SentDateAudit",            _c.Request["sentdateaudit"]);
        _valueProcessResult.Add("AuditedStatus",            _c.Request["auditedstatus"]);
        _valueProcessResult.Add("ReceivedDateResultAudit",  _c.Request["receiveddateresultaudit"]);

        return _valueProcessResult;
    }

    //ฟังก์ชั่นสำหรับประมวลผลข้อมูลตามค่าที่กำหนด แล้วส่งค่ากลับเป็น Dictionary<string, object>
    //โดยมีพารามิเตอร์ดังนี้
    //1. _infoLogin     เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    //2. _page          เป็น string รับค่าชื่อหน้า
    //3. _dataProcess   เป็น Dictionary<string, object> รับค่าชุดข้อมูลที่ใช้ประมวลผลข้อมูล
    public static Dictionary<string, object> GetProcess(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        string _option = _dataProcess["Option"].ToString();
        string _valueParamSearch = _dataProcess["ParamSearch"].ToString();
        string _valueSelected = _dataProcess["Selected"].ToString();
        string _sectionAction = String.Empty;
        string _keyword = String.Empty;
        string _degreeLevel = String.Empty;
        string _faculty = String.Empty;
        string _program = String.Empty;
        string _yearEntry = String.Empty;
        string _entranceType = String.Empty;
        string _studentStatus = String.Empty;
        string _documentUpload = String.Empty;
        string _submittedStatus = String.Empty;
        string _approvalStatus = String.Empty;
        string _instituteCountry = String.Empty;
        string _instituteProvince = String.Empty;
        string _institute = String.Empty;
        string _sentDateStartAudit = String.Empty;
        string _sentDateEndAudit = String.Empty;
        string _auditedStatus = String.Empty;
        string _exportStatus = String.Empty;
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
                    _valueArray2        = _valueArray1[_i].Split(':');
                    _valueSearch[_i]    = _valueArray2[1];
                }

                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                {
                    _sectionAction      = _valueSearch[0];
                    _keyword            = _valueSearch[1];
                    _degreeLevel        = _valueSearch[2];
                    _faculty            = _valueSearch[3];
                    _program            = _valueSearch[4];
                    _yearEntry          = _valueSearch[5];
                    _entranceType       = _valueSearch[6];
                    _studentStatus      = _valueSearch[7];
                    _documentUpload     = _valueSearch[8];
                    _submittedStatus    = _valueSearch[9];
                    _approvalStatus     = _valueSearch[10];
                    _instituteCountry   = _valueSearch[11];
                    _instituteProvince  = _valueSearch[12];
                    _institute          = _valueSearch[13];
                    _sentDateStartAudit = _valueSearch[14];
                    _sentDateEndAudit   = _valueSearch[15];
                    _auditedStatus      = _valueSearch[16];
                    _exportStatus       = _valueSearch[17];
                    _sortOrderBy        = _valueSearch[18];
                    _sortExpression     = _valueSearch[19];
                }
            }

            _paramSearch.Add("SectionAction",       _sectionAction);
            _paramSearch.Add("Keyword",             _keyword);
            _paramSearch.Add("DegreeLevel",         _degreeLevel);
            _paramSearch.Add("Faculty",             _faculty);
            _paramSearch.Add("Program",             _program);
            _paramSearch.Add("YearEntry",           _yearEntry);
            _paramSearch.Add("EntranceType",        _entranceType);
            _paramSearch.Add("StudentStatus",       _studentStatus);
            _paramSearch.Add("DocumentUpload",      _documentUpload);
            _paramSearch.Add("SubmittedStatus",     _submittedStatus);
            _paramSearch.Add("ApprovalStatus",      _approvalStatus);
            _paramSearch.Add("InstituteCountry",    _instituteCountry);
            _paramSearch.Add("InstituteProvince",   _instituteProvince);
            _paramSearch.Add("Institute",           _institute);
            _paramSearch.Add("SentDateStartAudit",  _sentDateStartAudit);
            _paramSearch.Add("SentDateEndAudit",    _sentDateEndAudit);
            _paramSearch.Add("AuditedStatus",       _auditedStatus);
            _paramSearch.Add("ExportStatus",        _exportStatus);
            _paramSearch.Add("SortOrderBy",         _sortOrderBy);
            _paramSearch.Add("SortExpression",      _sortExpression);
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
            _processResult = GetProcessExport(_infoLogin, _page, _paramSearch, _dataProcess);

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
            _processResult = GetProcessCopy(_infoLogin, _page, _paramSearch, _dataProcess);
        
        return _processResult;
    }    
    
    //ฟังก์ชั่นสำหรับประมวลผลข้อมูลการส่งออกข้อมูลตามค่าที่กำหนด แล้วส่งค่ากลับเป็น Dictionary<string, object>
    //โดยมีพารามิเตอร์ดังนี้
    //1. _infoLogin     เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    //2. _page          เป็น string รับค่าชื่อหน้า
    //3. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    //4. _dataProcess   เป็น Dictionary<string, object> รับค่าชุดข้อมูลที่ใช้ประมวลผลข้อมูล
    private static Dictionary<string, object> GetProcessExport(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _paramSearch, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        string _username = _infoLogin["Username"].ToString();
        string _option = _dataProcess["Option"].ToString();
        string _fileName = ((DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
        string _filePath = HttpContext.Current.Server.MapPath(UDSStaffUtil._myFileDownloadPath + "\\");
        string _fileFullPath1 = String.Empty;
        string _fileFullPath2 = String.Empty;
        string _msgTH = String.Empty;
        string _msgDetail = String.Empty;
        string _reportName = String.Empty;
        string _subject = String.Empty;
        int _tbIndex = 0;
        int _saveError = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i = 0;
        int _j = 0;
        bool _error = false;
        bool _export = false;
        List<string> _valueDetailCompleteTemp = new List<string>();
        List<string> _valueDetailComplte = new List<string>();
        List<string> _valueDetailIncomplte = new List<string>();

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS))
        {
            _fileName   = (UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENT + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE;
            _tbIndex    = 0;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS))
        {
            _fileName   = (UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTUREAPPROVED + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = "";
            _tbIndex    = 0;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS))
        {
            _fileName   = (UDSStaffUtil.SUBJECT_SECTION_STUDENTRECORDSINFORMATIONFORSMARTCARD + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = "";
            _tbIndex    = 0;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS))
        {
            _fileName   = ("SummaryoftheAuditTranscript" + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE;
            _tbIndex    = 1;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS))
        {
            _subject    = _page.Replace(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE, "").Replace("Progress", "");
            _fileName   = ("School" + _subject + "AuditTranscript" + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = (UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE + _subject);
            _tbIndex    = 2;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS))
        {
            _subject    = _page.Replace(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE, "").Replace("Progress", "");
            _fileName   = ("Student" + _subject + "AuditTranscript" + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = (UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE + _subject);
            _tbIndex    = 2;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
        {
            _fileName   = (UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTAPPROVED + _fileName);
            _msgTH      = "ส่งออกข้อมูล";
            _reportName = "";
            _tbIndex    = 0;
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
        {
            _fileName   = (UDSStaffUtil.SUBJECT_SECTION_SAVEAUDITTRANSCRIPTAPPROVED + _fileName);
            _msgTH      = "บันทึกข้อมูล";
            _reportName = "";
            _tbIndex    = 0;
        }

        DataTable _dt1 = new DataTable();
        DataTable _dt2 = new DataTable();
        DataSet _ds1 = new DataSet();
        MemoryStream _ms1 = new MemoryStream();
        MemoryStream _ms2 = new MemoryStream();
        
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
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                    _ds1 = UDSStaffDB.GetListUDSStudentRecords(
                            _infoLogin["Username"].ToString(),
                            _infoLogin["Userlevel"].ToString(),
                            _infoLogin["SystemGroup"].ToString(),
                            _reportName,
                            _paramSearch);
            }
            
            if (_ds1.Tables[_tbIndex].Rows.Count > 0)
            {
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                    _dt2 = UDSStaffUtil.SetColumnDataTable(_page);

                _i = 0;
                
                foreach (DataRow _dr1 in _ds1.Tables[_tbIndex].Rows)
                {                
                    try
                    {
                        _error      = false;
                        _export     = false;
                        _saveError  = 0;
                        _msgDetail  = String.Empty;

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                        {
                            DataSet _ds2 = UDSStaffDB.GetUDSStudentRecords(_dr1["id"].ToString());

                            if (_ds2.Tables[0].Rows.Count > 0)
                            {
                                DataRow _dr2 = _ds2.Tables[0].Rows[0];
                                                            
                                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                                    _export         = true;

                                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS))
                                {
                                    _fileFullPath1  = (!String.IsNullOrEmpty(_dr2["profilepictureFileName"].ToString()) ? (UDSStaffUtil._myFileUploadPath + "/" + _dr2["profilepictureFileName"].ToString()) : String.Empty);
                                    _export         = (!String.IsNullOrEmpty(_fileFullPath1) && Util.FileExist(_fileFullPath1) ? true : false);
                                }

                                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
                                {                                
                                    _fileFullPath1  = (!String.IsNullOrEmpty(_dr2["transcriptfrontsideFileName"].ToString()) ? (UDSStaffUtil._myFileUploadPath + "/" + _dr2["transcriptfrontsideFileName"].ToString()) : String.Empty);    
                                    _export         = (!String.IsNullOrEmpty(_fileFullPath1) && Util.FileExist(_fileFullPath1) ? true : false);

                                    _fileFullPath2  = (_export.Equals(true) && !String.IsNullOrEmpty(_dr2["transcriptbacksideFileName"].ToString()) ? (UDSStaffUtil._myFileUploadPath + "/" + _dr2["transcriptbacksideFileName"].ToString()) : String.Empty);
                                    _export         = (_export.Equals(true) && !String.IsNullOrEmpty(_fileFullPath2) && Util.FileExist(_fileFullPath2) ? true : false);
                                }

                                if (_export.Equals(true))
                                {        
                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS))
                                    {                                        
                                        _i++;

                                        _dt2.Rows.Add(
                                            _i.ToString("#,##0"),
                                            _dr2["studentCode"],
                                            _dr2["idCard"],
                                            _dr2["titlePrefixFullNameTH"],
                                            _dr2["firstName"],
                                            _dr2["middleName"],
                                            _dr2["lastName"],
                                            _dr2["titlePrefixFullNameEN"],
                                            _dr2["firstNameEN"],
                                            _dr2["middleNameEN"],
                                            _dr2["lastNameEN"],
                                            _dr2["facultyCode"],
                                            (_dr2["programCode"] + " " + _dr2["majorCode"] + " " + _dr2["groupNum"]),
                                            _dr2["yearEntry"],
                                            _dr2["stdEntranceTypeNameTH"],
                                            _dr2["statusTypeNameTH"],
                                            _dr2["instituteCountryCodes3LetterTranscript"].ToString(),
                                            (!String.IsNullOrEmpty(_dr2["instituteProvinceNameTHTranscript"].ToString()) ? _dr2["instituteProvinceNameTHTranscript"].ToString() : _dr2["instituteProvinceNameENTranscript"].ToString()),
                                            (!String.IsNullOrEmpty(_dr2["institutelNameTHTranscript"].ToString()) ? _dr2["institutelNameTHTranscript"].ToString() : _dr2["institutelNameENTranscript"].ToString()),
                                            _dr2["highSchoolStudentId"].ToString(),
                                            _dr2["isoHighSchoolCountryCodes3Letter"].ToString(),
                                            (!String.IsNullOrEmpty(_dr2["thHighSchoolPlaceName"].ToString()) ? _dr2["thHighSchoolPlaceName"].ToString() : _dr2["enHighSchoolPlaceName"].ToString()),
                                            _dr2["highSchoolName"].ToString(),
                                            UDSStaffUtil._approvalStatus[Util.FindIndexArray2D(2, UDSStaffUtil._approvalStatus, (!String.IsNullOrEmpty(_dr2["profilepictureApprovalStatus"].ToString()) ? _dr2["profilepictureApprovalStatus"].ToString() : "S")) - 1, 0],
                                            UDSStaffUtil._approvalStatus[Util.FindIndexArray2D(2, UDSStaffUtil._approvalStatus, (!String.IsNullOrEmpty(_dr2["identitycardApprovalStatus"].ToString()) ? _dr2["identitycardApprovalStatus"].ToString() : "S")) - 1, 0],
                                            UDSStaffUtil._approvalStatus[Util.FindIndexArray2D(2, UDSStaffUtil._approvalStatus, (!String.IsNullOrEmpty(_dr2["transcriptfrontsideApprovalStatus"].ToString()) ? _dr2["transcriptfrontsideApprovalStatus"].ToString() : "S")) - 1, 0],
                                            UDSStaffUtil._approvalStatus[Util.FindIndexArray2D(2, UDSStaffUtil._approvalStatus, (!String.IsNullOrEmpty(_dr2["transcriptbacksideApprovalStatus"].ToString()) ? _dr2["transcriptbacksideApprovalStatus"].ToString() : "S")) - 1, 0]);
                                    }

                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS))
                                    {
                                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS))
                                        {
                                            DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsSetUploadLog",
                                                new SqlParameter("@personId",       _dr1["id"].ToString()),
                                                new SqlParameter("@section",        "ProfilePictureIdentityCard"),
                                                new SqlParameter("@sectionAction",  "approve"),
                                                new SqlParameter("@by",             _username),
                                                new SqlParameter("@ip",             Util.GetIP()));

                                            DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                            _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                            if (_saveError.Equals(0))
                                            {
                                                _msgDetail = (_dr1["id"].ToString() + ";" + (!String.IsNullOrEmpty(_dr3[6].ToString()) ? DateTime.Parse(_dr3[6].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));

                                                _ms1 = Util.ImageProcessUtil.ImageFileToStream(_fileFullPath1);
                                                _zip.AddEntry(((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? _dr2["studentCode"] : _dr2["idCard"]) + ".jpg"), _ms1.ToArray());
                                                _ms1.Close();
                                            }
                                            else
                                                {
                                                    _error      = true;
                                                    _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : บันทึกข้อมูลไม่สำเร็จ");
                                                }

                                            _ds3.Dispose();
                                        }

                                        if (_saveError.Equals(0))
                                        {
                                            _i++;

                                            _dt2.Rows.Add(
                                                (_dr2["isoNationalityName2Letter"].Equals("TH") ? _dr2["idCard"] : String.Empty),
                                                (_dr2["isoNationalityName2Letter"].Equals("TH") ? _dr2["titlePrefixInitialsTH"] : _dr2["titlePrefixInitialsEN"]),
                                                (_dr2["isoNationalityName2Letter"].Equals("TH") ? (_dr2["firstName"] + (!String.IsNullOrEmpty(_dr2["middleName"].ToString()) ? (" " + _dr2["middleName"]) : String.Empty)) : (_dr2["firstNameEN"] + (!String.IsNullOrEmpty(_dr2["middleNameEN"].ToString()) ? (" " + _dr2["middleNameEN"]) : String.Empty))),
                                                (_dr2["isoNationalityName2Letter"].Equals("TH") ? _dr2["lastName"] : _dr2["lastNameEN"]),
                                                (_dr2["firstNameEN"] + (!String.IsNullOrEmpty(_dr2["middleNameEN"].ToString()) ? (" " + _dr2["middleNameEN"]) : String.Empty)),
                                                _dr2["lastNameEN"],
                                                _dr2["genderInitialsEN"],
                                                (!String.IsNullOrEmpty(_dr2["perMaritalStatusId"].ToString()) ? (_dr2["maritalStatusNameTH"].Equals("โสด") ? "S" : "M") : "D"),
                                                _dr2["birthDateTH"].ToString().Replace("/", "-"),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["noPermanent"] : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["villagePermanent"] : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["mooPermanent"] : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["soiPermanent"] : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["roadPermanent"] : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? (_dr2["subdistrictNameTHPermanent"].ToString().Length >= 4 ? (_dr2["subdistrictNameTHPermanent"].ToString().Substring(0, 4).Equals("แขวง") ? _dr2["subdistrictNameTHPermanent"].ToString().Remove(0, 4) : _dr2["subdistrictNameTHPermanent"]) : _dr2["subdistrictNameTHPermanent"]) : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? (_dr2["districtNameTHPermanent"].ToString().Length >= 3 ? (_dr2["districtNameTHPermanent"].ToString().Substring(0, 3).Equals("เขต") ? _dr2["districtNameTHPermanent"].ToString().Remove(0, 3) : _dr2["districtNameTHPermanent"]) : _dr2["districtNameTHPermanent"]) : String.Empty),
                                                (_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["zipCodePermanent"] : String.Empty),
                                                _dr2["cardIssueDate"].ToString().Replace("/", "-"),
                                                _dr2["cardExpiryDate"].ToString().Replace("/", "-"),
                                                _dr2["bloodTypeNameTH"],
                                                _dr2["studentCode"],
                                                _dr2["facultyCode"],
                                                (_dr2["programCode"].ToString().Substring(0, 4) + "/" + _dr2["programCode"].ToString().Substring(4)),
                                                _dr2["barcode"],
                                                _dr2["phoneProvinceCode"],
                                                _dr2["phoneNumber"],
                                                _dr2["mobileCode"],
                                                _dr2["mobileNumber"],
                                                _dr2["email"].ToString().ToUpper(),
                                                _dr2["isoNationalityName2Letter"],
                                                (_dr2["isoNationalityName2Letter"].Equals("TH") ? "1" : "3"),
                                                (!_dr2["isoNationalityName2Letter"].Equals("TH") ? _dr2["isoCountryCodes2Letter"] : String.Empty),
                                                (!_dr2["isoNationalityName2Letter"].Equals("TH") ? _dr2["idCard"] : String.Empty),
                                                (!_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["noPermanent"] : String.Empty),
                                                (!_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["subdistrictNameENPermanent"] : String.Empty),
                                                (!_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["districtNameENPermanent"] : String.Empty),
                                                (!_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["provinceNameENPermanent"] : String.Empty),
                                                (!_dr2["isoCountryCodes2LetterPermanent"].Equals("TH") ? _dr2["zipCodePermanent"] : String.Empty),
                                                _dr2["bankAcc"],
                                                "63",
                                                "0");
                                        }
                                    }

                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS))
                                    {
                                        _i++;

                                        _dt2.Rows.Add(
                                            _i.ToString("#,##0"),
                                            _dr2["studentCode"],
                                            _dr2["idCard"],
                                            _dr2["titlePrefixFullNameTH"],
                                            _dr2["firstName"],
                                            _dr2["middleName"],
                                            _dr2["lastName"],
                                            _dr2["titlePrefixFullNameEN"],
                                            _dr2["firstNameEN"],
                                            _dr2["middleNameEN"],
                                            _dr2["lastNameEN"],
                                            _dr2["facultyCode"],
                                            (_dr2["programCode"] + " " + _dr2["majorCode"] + " " + _dr2["groupNum"]),
                                            _dr2["yearEntry"],
                                            _dr2["stdEntranceTypeNameTH"],
                                            _dr2["statusTypeNameTH"],
                                            _dr2["instituteCountryCodes3LetterTranscript"],
                                            (!String.IsNullOrEmpty(_dr2["instituteProvinceNameTHTranscript"].ToString()) ? _dr2["instituteProvinceNameTHTranscript"].ToString() : _dr2["instituteProvinceNameENTranscript"].ToString()),
                                            (!String.IsNullOrEmpty(_dr2["institutelNameTHTranscript"].ToString()) ? _dr2["institutelNameTHTranscript"].ToString() : _dr2["institutelNameENTranscript"].ToString()),
                                            _dr2["highSchoolStudentId"].ToString(),
                                            _dr2["isoHighSchoolCountryCodes3Letter"].ToString(),
                                            (!String.IsNullOrEmpty(_dr2["thHighSchoolPlaceName"].ToString()) ? _dr2["thHighSchoolPlaceName"].ToString() : _dr2["enHighSchoolPlaceName"].ToString()),
                                            _dr2["highSchoolName"].ToString());
                                    }

                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
                                    {                                        
                                        if (!String.IsNullOrEmpty(_dataProcess["SentDateAudit"].ToString()))
                                        {                                               
                                            DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsSetUploadLog",
                                                            new SqlParameter("@personId",       _dr1["id"].ToString()),
                                                            new SqlParameter("@section",        "Transcript"),
                                                            new SqlParameter("@sectionAction",  "send"),
                                                            new SqlParameter("@auditSentDate",  _dataProcess["SentDateAudit"]),
                                                            new SqlParameter("@auditSentBy",    _username),
                                                            new SqlParameter("@auditSentIP",    Util.GetIP()),
                                                            new SqlParameter("@by",             _username),
                                                            new SqlParameter("@ip",             Util.GetIP()));

                                            DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                            _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                            _ds3.Dispose();
                                        }

                                        if (_saveError.Equals(0))
                                        {
                                            _ms1 = Util.ImageProcessUtil.ImageFileToStream(_fileFullPath1);
                                            _zip.AddEntry(((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + "TranscriptFrontside.jpg"), _ms1.ToArray());
                                            _ms1.Close();

                                            _ms1 = Util.ImageProcessUtil.ImageFileToStream(_fileFullPath2);
                                            _zip.AddEntry(((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + "TranscriptBackside.jpg"), _ms1.ToArray());
                                            _ms1.Close();

                                            _i++;

                                            _dt2.Rows.Add(
                                                _i.ToString("#,##0"),
                                                _dr2["studentCode"].ToString(),
                                                Util.GetFullName(_dr2["titlePrefixFullNameTH"].ToString(), _dr2["titlePrefixInitialsTH"].ToString(), _dr2["firstName"].ToString(), _dr2["middleName"].ToString(), _dr2["lastName"].ToString()),
                                                _dr2["facultyCode"].ToString(),
                                                _dr2["programNameTH"].ToString(),
                                                _dr2["idCard"].ToString(),
                                                (!String.IsNullOrEmpty(_dr2["institutelNameTHTranscript"].ToString()) ? _dr2["institutelNameTHTranscript"].ToString() : _dr2["institutelNameENTranscript"].ToString()),
                                                (!String.IsNullOrEmpty(_dr2["instituteProvinceNameTHTranscript"].ToString()) ? _dr2["instituteProvinceNameTHTranscript"].ToString() : _dr2["instituteProvinceNameENTranscript"].ToString()),
                                                _dr2["highSchoolStudentId"].ToString(),
                                                _dataProcess["SentDateAudit"]);
                                        }
                                        else
                                            {
                                                _error      = true;
                                                _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : บันทึกข้อมูลไม่สำเร็จ");
                                            }
                                    }
                                    
                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                                    {
                                        if (!String.IsNullOrEmpty(_dr2["transcriptAuditSentDate"].ToString()))
                                        {
                                            string _d = (_dataProcess["ReceivedDateResultAudit"].ToString().Substring(3, 2) + "/" + _dataProcess["ReceivedDateResultAudit"].ToString().Substring(0, 2) + "/" + _dataProcess["ReceivedDateResultAudit"].ToString().Substring(6, 4));
                                            
                                            if (DateTime.Compare(DateTime.Parse(_dr2["transcriptAuditSentDate"].ToString()), DateTime.Parse(_d)) <= 0)
                                            {
                                                DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsSetUploadLog",
                                                                new SqlParameter("@personId",                   _dr1["id"].ToString()),
                                                                new SqlParameter("@section",                    "Transcript"),
                                                                new SqlParameter("@sectionAction",              "receive"),
                                                                new SqlParameter("@resultAudit",                _dataProcess["AuditedStatus"]),
                                                                new SqlParameter("@resultAuditReceivedDate",    _dataProcess["ReceivedDateResultAudit"]),
                                                                new SqlParameter("@resultAuditReceivedBy",      _username),
                                                                new SqlParameter("@resultAuditReceivedIP",      Util.GetIP()),
                                                                new SqlParameter("@by",                         _username),
                                                                new SqlParameter("@ip",                         Util.GetIP()));

                                                DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                                _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);

                                                _ds3.Dispose();    
                                            }
                                            else
                                                _saveError = 2;
                                        }
                                        else
                                            _saveError = 2;
                                        
                                        if (_saveError.Equals(0))
                                        {
                                            _i++;

                                            _dt2.Rows.Add(
                                                _i.ToString("#,##0"),
                                                _dr2["studentCode"].ToString(),
                                                Util.GetFullName(_dr2["titlePrefixFullNameTH"].ToString(), _dr2["titlePrefixInitialsTH"].ToString(), _dr2["firstName"].ToString(), _dr2["middleName"].ToString(), _dr2["lastName"].ToString()),
                                                _dr2["facultyCode"].ToString(),
                                                _dr2["programNameTH"].ToString(),
                                                _dr2["idCard"].ToString(),
                                                (!String.IsNullOrEmpty(_dr2["institutelNameTHTranscript"].ToString()) ? _dr2["institutelNameTHTranscript"].ToString() : _dr2["institutelNameENTranscript"].ToString()),
                                                (!String.IsNullOrEmpty(_dr2["instituteProvinceNameTHTranscript"].ToString()) ? _dr2["instituteProvinceNameTHTranscript"].ToString() : _dr2["instituteProvinceNameENTranscript"].ToString()),
                                                _dr2["highSchoolStudentId"].ToString(),
                                                DateTime.Parse(_dr2["transcriptAuditSentDate"].ToString()).ToString("dd/MM/yyyy"),
                                                _dataProcess["AuditedStatus"],
                                                _dataProcess["ReceivedDateResultAudit"]);
                                        }
                                        else
                                            {
                                                _error      = true;
                                                _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : " + (_saveError.Equals(1) ? "บันทึกข้อมูลไม่สำเร็จ" : "วันที่ส่งวุฒิการศึกษาตรวจสอบและวันที่รับผลการตรวจสอบวุฒิการศึกษาไม่ถูกต้อง"));
                                            }
                                    }
                                }
                                else
                                    {
                                        _error      = true;
                                        _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : ส่งออกข้อมูลไม่สำเร็จ");
                                    }
                            }
                            else
                                {
                                    _error      = true;
                                    _msgDetail  = (_dr1["id"].ToString() + " : ไม่พบข้อมูล");
                                }

                            _ds2.Dispose();   
                        }

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS))
                        {
                            _i++;
                            
                            _dt2.Rows.Add(
                                _i.ToString("#,##0"),
                                _dr1["title"].ToString(),
                                _dr1["yearEntry"].ToString(),
                                double.Parse(_dr1["countInstitute"].ToString()).ToString("#,##0"),
                                double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0"));
                        }

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS))
                        {
                            _i++;

                            _dt2.Rows.Add(
                                _i.ToString("#,##0"),
                                _dr1["yearEntry"].ToString(),
                                _dr1["instituteCountryCodes3LetterTranscript"].ToString(),
                                _dr1["instituteProvinceNameTranscript"].ToString(),
                                _dr1["instituteNameTranscript"].ToString(),
                                double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0"));
                        }                        

                        if (_error.Equals(false))
                        {                            
                            _valueDetailComplte.Add(String.IsNullOrEmpty(_msgDetail) ? _dr1["id"].ToString() : _msgDetail);
                            _complete++;
                        }
                        else
                            {
                                _valueDetailIncomplte.Add(_msgDetail);
                                _incomplete++;
                            }   
                    }
                    catch
                    {
                        _valueDetailIncomplte.Add(_dr1["id"].ToString() + " : ประมวลผลไม่สำเร็จ");
                        _incomplete++;
                    }
                }                
            }
            
            _ds1.Dispose();

            if (_complete > 0)
            {   
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                    _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                {
                    ExcelPackage _pk = new ExcelPackage();
                    ExcelWorksheet _ws = _pk.Workbook.Worksheets.Add("Sheet1");

                    int _maxRowCellRange    = 0;
                    int _maxColCellRange    = 0;
                    int _maxRowCellHeader   = 0;
                    int _maxColCellHeader   = 0;

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                    {
                        _maxRowCellRange    = (_complete + 1);
                        _maxColCellRange    = _dt2.Columns.Count;
                        _maxRowCellHeader   = 1;
                        _maxColCellHeader   = _dt2.Columns.Count;
                    }
                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS))
                    {
                        _maxRowCellRange    = (_complete + 1);
                        _maxColCellRange    = 58;
                        _maxRowCellHeader   = 1;
                        _maxColCellHeader   = 58;
                    }
                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS))
                    {
                        _maxRowCellRange = (_complete + 2);
                        _maxColCellRange = _dt2.Columns.Count;
                        _maxRowCellHeader = 2;
                        _maxColCellHeader = _dt2.Columns.Count;
                    }

                    Util.SetCellExcel(_ws, _maxRowCellRange, _maxColCellRange, _maxRowCellHeader, _maxColCellHeader);

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "เลขประจำตัวประชาชน", "IdCard", "center", "" },
                            new[] { "คำนำหน้าภาษาไทย", "TitlePrefixTH", "", "" },
                            new[] { "ชื่อภาษาไทย", "FirstName", "", "" },
                            new[] { "ชื่อกลางภาษาไทย", "MiddleName", "", "" },
                            new[] { "นามสกุลภาษาไทย", "LastName", "", "" },
                            new[] { "คำนำหน้าภาษาอังกฤษ", "TitlePrefixEN", "", "" },
                            new[] { "ชื่อภาษาอังกฤษ", "FirstNameEN", "", "" },
                            new[] { "ชื่อกลางภาษาอังกฤษ", "MiddleNameEN", "", "" },
                            new[] { "นามสกุลภาษาอังกฤษ", "LastNameEN", "", "" },
                            new[] { "คณะ", "Faculty", "center", "" },
                            new[] { "หลักสูตร", "Program", "center", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "ระบบการสอบเข้า", "AdmissionType", "", "" },
                            new[] { "สถานภาพการเป็นนักศึกษา", "StudentStatus", "center", "" },
                            new[] { "ประเทศของโรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteCountry", "center", "" },
                            new[] { "จังหวัดของโรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteProvince", "", "" },
                            new[] { "โรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteName", "", "" },
                            new[] { "เลขประจำตัวนักเรียนระดับมัธยมปลาย", "HighSchoolStudentId", "center", "" },
                            new[] { "ประเทศของโรงเรียนระดับมัธยมปลาย", "HighSchoolCountry", "center", "" },
                            new[] { "จังหวัดของโรงเรียนระดับมัธยมปลาย", "HighSchoolProvince", "", "" },
                            new[] { "โรงเรียนระดับมัธยมปลาย", "HighSchoolName", "", "" },
                            new[] { "สถานะเอกสารของรูปภาพประจำตัว", "ProfilePictureApprovalStatus", "center", "" },
                            new[] { "สถานะเอกสารของบัตรประจำตัวประชาชน", "IdentityCardApprovalStatus", "center", "" },
                            new[] { "สถานะเอกสารของระเบียนแสดงผลการเรียน ( ด้านหน้า )", "TranscriptFrontSideApprovalStatus", "center", "" },
                            new[] { "สถานะเอกสารของระเบียนแสดงผลการเรียน ( ด้านหลัง )", "TranscriptBackSideApprovalStatus", "center", "" }
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

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "เลขบัตรประชาชน", "IdCard", "", "" },
                            new[] { "คำนำหน้าชื่อ", "TitlePrefix", "", "" },
                            new[] { "ชื่อ", "FirstName", "", "" },
                            new[] { "นามสกุล", "LastName", "", "" },
                            new[] { "ชื่อ ( ภาษาอังกฤษ )", "FirstNameEN", "", "" },
                            new[] { "นามสกุล ( ภาษาอังกฤษ )", "LastNameEN", "", "" },
                            new[] { "รหัสเพศ", "Gender", "", "" },
                            new[] { "สถานภาพสมรส", "MaritalStatus", "", "" },
                            new[] { "วันเดือนปีเกิด", "BirthDate", "", "" },
                            new[] { "บ้านเลขที่ ( ตามบัตรประชาชน )", "NoPermanent", "", "" },
                            new[] { "ชื่อหมู่บ้าน / อาคาร", "VillagePermanent", "", "" },
                            new[] { "ชั้นที่", "", "", "" },
                            new[] { "ห้องเลขที่", "", "", "" },
                            new[] { "หมู่ที่", "MooPermanent", "", "" },
                            new[] { "ตรอก / ซอย", "SoiPermanent", "", "" },
                            new[] { "ถนน", "RoadPermanent", "", "" },
                            new[] { "ตำบล / แขวง", "SubdistrictPermanent", "", "" },
                            new[] { "อำเภอ / เขต", "DistrictPermanent", "", "" },
                            new[] { "รหัสไปรษณีย์", "ZipCodePermanent", "", "" },
                            new[] { "วันออกบัตร", "CardIssueDate", "", "" },
                            new[] { "วันบัตรหมดอายุ", "CardExpiryDate", "", "" },
                            //new[] { "กรุ๊ปเลือด", "BloodType", "", "" },
                            new[] { "เลขประจำตัวพนักงาน / นักศึกษา", "StudentCode", "", "" },
                            new[] { "รหัสคณะ / แผนก / ฝ่าย", "Faculty", "", "" },
                            new[] { "สาขา / ประเภทเจ้าหน้าที่", "Program", "", "" },
                            new[] { "เลขที่บัญชีสหกรณ์", "", "", "" },
                            new[] { "Bar Code", "Barcode", "", "" },
                            new[] { "เลขประจำตัว", "", "", "" },
                            new[] { "เลขประกันสังคม", "", "", "" },
                            new[] { "คำนำหน้าชื่อ", "", "", "" },
                            new[] { "รหัสทางไกล", "PhoneProvinceCode", "", "" },
                            new[] { "เบอร์โทร", "PhoneNumberPermanent", "", "" },
                            new[] { "ถึง", "", "", "" },
                            new[] { "ต่อ", "", "", "" },
                            new[] { "รหัสมือถือส่วนตัว", "MobileCode", "", "" },
                            new[] { "เบอร์โทรมือถือส่วนตัว", "MobileNumberPermanent", "", "" },
                            new[] { "จดหมายอิเล็คโทรนิค", "Email", "", "" },
                            new[] { "รหัสสัญชาติ", "Nationality", "", "" },
                            new[] { "ประเภทเอกสารอ้างอิง", "DocumentType", "", "" },
                            new[] { "รหัสประเทศหนังสือเดินทาง", "CountryCodePassport", "", "" },
                            new[] { "เลขที่เอกสารอ้างอิง", "PassportNumber", "", "" },
                            new[] { "เลขที่ที่อยู่ต่างประเทศ", "NoNationalityNotTH", "", "" },
                            new[] { "แขวง / ตำบล", "SubdistrictNationalityNotTH", "", "" },
                            new[] { "เขต / อำเภอ", "DistrictNationalityNotTH", "", "" },
                            new[] { "จังหวัด / รัฐ", "ProvinceNationalityNotTH", "", "" },
                            new[] { "รหัสไปรษณีย์", "ZipCodeNationalityNotTH", "", "" },
                            new[] { "เลขที่บัญชีเดิม", "BankAcc", "", "" },
                            new[] { "รหัสสาขา", "", "", "" },
                            new[] { "Reserve1", "", "", "" },
                            new[] { "Reserve2", "", "", "" },
                            new[] { "Reserve3", "", "", "" },
                            new[] { "LINE 1", "", "", "" },
                            new[] { "LINE 2", "", "", "" },
                            new[] { "LINE 3", "", "", "" },
                            new[] { "LINE 4", "", "", "" },
                            new[] { "LINE 5", "", "", "" },
                            new[] { "รหัสอาชีพ", "CareerCode", "", "" },
                            new[] { "รายได้ ( บาท )", "Income", "", "" }
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

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รายการ", "Title", "", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "จำนวน ( โรงเรียน )", "NumberofSchool", "right", "" },
                            new[] { "จำนวน ( นักศึกษา )", "NumberofPeople", "right", "" }
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

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "ประเทศ", "InstituteCountry", "center", "" },
                            new[] { "จังหวัด", "InstituteProvince", "", "" },
                            new[] { "โรงเรียน / สถาบัน", "InstitutelName", "", "" },
                            new[] { "จำนวน ( นักศึกษา )", "NumberofPeople", "right", "" }
                        };

                        string _headerTitle = _page.Replace(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE, "").Replace("Progress", "");
                        if (_headerTitle.Equals("NeedSend"))        _headerTitle = UDSStaffUtil._submenu[10, 0];
                        if (_headerTitle.Equals("Send"))            _headerTitle = UDSStaffUtil._submenu[11, 0];
                        if (_headerTitle.Equals("NotSend"))         _headerTitle = UDSStaffUtil._submenu[12, 0];
                        if (_headerTitle.Equals("SendReceive"))     _headerTitle = UDSStaffUtil._submenu[13, 0];
                        if (_headerTitle.Equals("SendNotReceive"))  _headerTitle = UDSStaffUtil._submenu[14, 0];

                        _ws.Cells[1, 1, 1, _maxColCellHeader].Merge = true;
                        _ws.Cells[1, 1].Style.HorizontalAlignment   = ExcelHorizontalAlignment.Center;
                        _ws.Cells[1, 1].Value = _headerTitle;                    

                        _i = 1;

                        foreach (object _c in _cellContent)
                        {
                            string _header = ((string[])_c)[0];

                            _ws.Cells[2, _i].Value = _header;
                            _i++;
                        }

                        Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                    }

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_PROGRESS) ||
                        _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "เลขประจำตัวประชาชน", "IdCard", "center", "" },
                            new[] { "คำนำหน้าภาษาไทย", "TitlePrefixTH", "", "" },
                            new[] { "ชื่อภาษาไทย", "FirstName", "", "" },
                            new[] { "ชื่อกลางภาษาไทย", "MiddleName", "", "" },
                            new[] { "นามสกุลภาษาไทย", "LastName", "", "" },
                            new[] { "คำนำหน้าภาษาอังกฤษ", "TitlePrefixEN", "", "" },
                            new[] { "ชื่อภาษาอังกฤษ", "FirstNameEN", "", "" },
                            new[] { "ชื่อกลางภาษาอังกฤษ", "MiddleNameEN", "", "" },
                            new[] { "นามสกุลภาษาอังกฤษ", "LastNameEN", "", "" },
                            new[] { "คณะ", "Faculty", "center", "" },
                            new[] { "หลักสูตร", "Program", "center", "" },
                            new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                            new[] { "ระบบการสอบเข้า", "AdmissionType", "", "" },
                            new[] { "สถานภาพการเป็นนักศึกษา", "StudentStatus", "center", "" },
                            new[] { "ประเทศของโรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteCountry", "center", "" },
                            new[] { "จังหวัดของโรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteProvince", "", "" },
                            new[] { "โรงเรียนตามระเบียนแสดงผลการเรียน", "InstituteName", "", "" },
                            new[] { "เลขประจำตัวนักเรียนระดับมัธยมปลาย", "HighSchoolStudentId", "center", "" },
                            new[] { "ประเทศของโรงเรียนระดับมัธยมปลาย", "HighSchoolCountry", "center", "" },
                            new[] { "จังหวัดของโรงเรียนระดับมัธยมปลาย", "HighSchoolProvince", "", "" },
                            new[] { "โรงเรียนระดับมัธยมปลาย", "HighSchoolName", "", "" }
                        };

                        string _headerTitle = _page.Replace(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE, "").Replace("Progress", "");
                        if (_headerTitle.Equals("NeedSend"))        _headerTitle = UDSStaffUtil._submenu[15, 0];
                        if (_headerTitle.Equals("Send"))            _headerTitle = UDSStaffUtil._submenu[16, 0];
                        if (_headerTitle.Equals("NotSend"))         _headerTitle = UDSStaffUtil._submenu[17, 0];
                        if (_headerTitle.Equals("SendReceive"))     _headerTitle = UDSStaffUtil._submenu[18, 0];
                        if (_headerTitle.Equals("SendNotReceive"))  _headerTitle = UDSStaffUtil._submenu[19, 0];

                        _ws.Cells[1, 1, 1, _maxColCellHeader].Merge = true;
                        _ws.Cells[1, 1].Style.HorizontalAlignment   = ExcelHorizontalAlignment.Center;
                        _ws.Cells[1, 1].Value = _headerTitle;                    

                        _i = 1;

                        foreach (object _c in _cellContent)
                        {
                            string _header = ((string[])_c)[0];

                            _ws.Cells[2, _i].Value = _header;
                            _i++;
                        }

                        Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                    }

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "ชื่อ - นามสกุล", "FullName", "", "" },
                            new[] { "คณะ", "Faculty", "center", "" },
                            new[] { "หลักสูตร", "Program", "center", "" },
                            new[] { "เลขประจำตัวประชาชน", "IdCard", "center", "" },
                            new[] { "โรงเรียนเดิม", "InstituteName", "", "" },
                            new[] { "จังหวัดของโรงเรียน", "InstituteProvince", "", "" },
                            new[] { "เลขประจำตัวนักเรียน", "HighSchoolStudentId", "center", "" },
                            new[] { "วันที่ส่งวุฒิการศึกษาตรวจสอบ", "SentDateAudit", "center", "" }
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

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
                    {
                        List<object> _cellContent = new List<object>
                        {
                            new[] { "ลำดับ", "No.", "center", "" },
                            new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                            new[] { "ชื่อ - นามสกุล", "FullName", "", "" },
                            new[] { "คณะ", "Faculty", "center", "" },
                            new[] { "หลักสูตร", "Program", "center", "" },
                            new[] { "เลขประจำตัวประชาชน", "IdCard", "center", "" },
                            new[] { "โรงเรียนเดิม", "InstituteName", "", "" },
                            new[] { "จังหวัดของโรงเรียน", "InstituteProvince", "", "" },
                            new[] { "เลขประจำตัวนักเรียน", "HighSchoolStudentId", "center", "" },
                            new[] { "วันที่ส่งวุฒิการศึกษาตรวจสอบ", "SentDateAudit", "center", "" },
                            new[] { "ผลการตรวจสอบวุฒิการศึกษา", "AuditedStatus", "center", "" },
                            new[] { "วันที่รับผลการตรวจสอบวุฒิการศึกษา", "ReceivedDateResultAudit", "center", "" }
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

                    _pk.SaveAs(_ms2);
                    _ms2.Seek(0, SeekOrigin.Begin);
                    _zip.AddEntry((_fileName + ".xlsx"), _ms2);
                }
            }

            if (_incomplete > 0)
                _zip.AddEntry("ErrorLog.txt", (_msgTH + "ไม่สำเร็จจำนวน " + _incomplete.ToString("#,##0") + " รายการ" + Environment.NewLine + String.Join(Environment.NewLine, _valueDetailIncomplte.ToArray())));
            
            _zip.Save(_filePath + _fileName + ".zip");
            _zip.Dispose();
        }

        _ms2.Close();
        _ms2.Dispose();

        _processResult.Add("Complete",          _complete.ToString("#,##0"));
        _processResult.Add("Incomplete",        _incomplete.ToString("#,##0"));
        _processResult.Add("DetailComplete",    String.Join(",", _valueDetailComplte.ToArray()));
        _processResult.Add("DetailIncomplete",  String.Join(",", _valueDetailIncomplte.ToArray()));
        _processResult.Add("DownloadFolder",    UDSStaffUtil._myFileDownloadPath);
        _processResult.Add("DownloadFile",      (_fileName + ".zip"));

        return _processResult;
    }

    //ฟังก์ชั่นสำหรับประมวลผลข้อมูลการคัดลอกข้อมูลตามค่าที่กำหนด แล้วส่งค่ากลับเป็น Dictionary<string, object>
    //โดยมีพารามิเตอร์ดังนี้
    //1. _infoLogin     เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    //2. _page          เป็น string รับค่าชื่อหน้า
    //3. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    //4. _dataProcess   เป็น Dictionary<string, object> รับค่าชุดข้อมูลที่ใช้ประมวลผลข้อมูล
    private static Dictionary<string, object> GetProcessCopy(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _paramSearch, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        string _username = _infoLogin["Username"].ToString();
        string _option = _dataProcess["Option"].ToString();
        string _fileName = ((DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
        string _filePath = HttpContext.Current.Server.MapPath(UDSStaffUtil._myFileDownloadPath + "\\");
        string _fileFullPath = String.Empty;
        string _msgTH = String.Empty;
        string _msgDetail = String.Empty;
        string _reportName = String.Empty;
        string _folderEncode = String.Empty;
        string _fileEncode = String.Empty;
        int _tbIndex = 0;
        int _error = 0;
        int _connServer = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i = 0;
        bool _copy = false;
        List<string> _valueDetailCompleteTemp = new List<string>();
        List<string> _valueDetailComplte = new List<string>();
        List<string> _valueDetailIncomplte = new List<string>();

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
        {
            _fileName   = ("CopyFile" + UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTUREAPPROVED + _fileName);
            _msgTH      = "คัดลอกข้อมูล";
            _reportName = "";
            _tbIndex    = 0;
        }

        using (ZipFile _zip = new ZipFile())
        {                                
            //_connServer = Util.ConnectServerToServer(UDSStaffUtil._mySiteLocalPictureStudent, "", "", UDSStaffUtil._mySiteServerPictureStudent, "cccbd", "46900000");
                    
            if (_connServer.Equals(0))
            {                        
                DataTable _dt1 = new DataTable();
                DataSet _ds1 = new DataSet();

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
                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
                        _ds1 = UDSStaffDB.GetListUDSStudentRecords(
                                _infoLogin["Username"].ToString(),
                                _infoLogin["Userlevel"].ToString(),
                                _infoLogin["SystemGroup"].ToString(),
                                _reportName,
                                _paramSearch);
                }

                if (_ds1.Tables[_tbIndex].Rows.Count > 0)
                {                
                    foreach (DataRow _dr1 in _ds1.Tables[_tbIndex].Rows)
                    {                
                        try
                        {
                            _error  = 0;
                            _copy   = false;

                            if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
                            {
                                DataSet _ds2 = UDSStaffDB.GetUDSStudentRecords(_dr1["id"].ToString());

                                if (_ds2.Tables[0].Rows.Count > 0)
                                {
                                    DataRow _dr2 = _ds2.Tables[0].Rows[0];

                                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
                                    {
                                        _fileFullPath   = (!String.IsNullOrEmpty(_dr2["profilepictureFileName"].ToString()) ? (UDSStaffUtil._myFileUploadPath + "/" + _dr2["profilepictureFileName"].ToString()) : String.Empty);
                                        _copy           = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? true : false);
                                    }

                                    if (_copy.Equals(true))
                                    {
                                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
                                        {
                                            _fileEncode     = (Util.EncodeToMD5(_dr2["studentCode"].ToString()) + ".jpg");
                                            _folderEncode   = Util.GetFolderNameFromStudentId(_dr2["studentCode"].ToString());
                                            //_error        = Util.CopyFileServerToServer(UDSStaffUtil._mySiteLocalPictureStudent, _dr2["profilepictureFileName"].ToString(), UDSStaffUtil._mySiteServerPictureStudent, (_folderEncode + "\\" + _fileEncode));
                                            _error          = Util.CopyFileServerToServer("D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument", _dr2["profilepictureFileName"].ToString(), "D:\\ProfilePicture", (_folderEncode + "\\" + _fileEncode));
                                            
                                            if (_error.Equals(0))
                                            {
                                                _msgDetail = (_dr2["studentCode"] + "-" + _dr2["idCard"] + " => Folder Name : " + _folderEncode + ", File Name : " + _fileEncode);

                                                Util.DBUtil.ExecuteCommandStoredProcedure("sp_stdSetStudent",
                                                    new SqlParameter("@action",         "UPDATE"),
                                                    new SqlParameter("@personId",       _dr1["id"].ToString()),
                                                    new SqlParameter("@pictureName",    (_folderEncode + "/" + _fileEncode)),    
                                                    new SqlParameter("@by",             _username),
                                                    new SqlParameter("@ip",             Util.GetIP()));
                                            }
                                            else
                                                {
                                                    _copy       = false;
                                                    _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : บันทึกข้อมูลไม่สำเร็จ");
                                                }
                                        }
                                    }
                                    else
                                        {
                                            _copy       = false;
                                            _msgDetail  = ((!String.IsNullOrEmpty(_dr2["studentCode"].ToString()) ? (_dr2["studentCode"] + "-") : String.Empty) + _dr2["idCard"] + " : คัดลอกข้อมูลไม่สำเร็จ");
                                        }
                                }
                                else
                                    {
                                        _copy       = false;
                                        _msgDetail  = (_dr1["id"].ToString() + " : ไม่พบข้อมูล");
                                    }

                                _ds2.Dispose();
                            }

                            if (_copy.Equals(true))
                            {
                                _valueDetailComplte.Add(_msgDetail);                        
                                _complete++;
                            }
                            else
                                {
                                    _valueDetailIncomplte.Add(_msgDetail);
                                    _incomplete++;
                                }   
                        }
                        catch
                        {   
                            _valueDetailIncomplte.Add(_dr1["id"].ToString() + " : ประมวลผลไม่สำเร็จ");
                            _incomplete++;
                        }
                    }
                }

                _ds1.Dispose();

                if (_complete > 0)
                    _zip.AddEntry("Log.txt", ("คัดลอกไฟล์สำเร็จจำนวน " + _complete.ToString("#,##0") + " รายการ" + Environment.NewLine + String.Join(Environment.NewLine, _valueDetailComplte.ToArray())));

                if (_incomplete > 0)
                    _zip.AddEntry("ErrorLog.txt", ("คัดลอกไฟล์ไม่สำเร็จจำนวน " + _incomplete.ToString("#,##0") + " รายการ" + Environment.NewLine + String.Join(Environment.NewLine, _valueDetailIncomplte.ToArray())));

                _zip.Save(_filePath + _fileName + ".zip");
                _zip.Dispose();
            }
        }
        
        _processResult.Add("ConnServer",        _connServer.ToString());
        _processResult.Add("Complete",          _complete.ToString("#,##0"));
        _processResult.Add("Incomplete",        _incomplete.ToString("#,##0"));
        _processResult.Add("DetailComplete",    String.Join(",", _valueDetailComplte.ToArray()));
        _processResult.Add("DetailIncomplete",  String.Join(",", _valueDetailIncomplte.ToArray()));
        _processResult.Add("DownloadFolder",    UDSStaffUtil._myFileDownloadPath);
        _processResult.Add("DownloadFile",      (_fileName + ".zip"));

        return _processResult;
    }
}