// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๐๗/๐๗/๒๕๕๘>
// Modify date  : <๑๓/๐๙/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการบริการข้อมูล>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;

public class UDSStaffOurServicesUtil
{
    public class DocumentStatusStudentUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };

        public class ViewChartUtil
        {
            //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของสถานะเอกสารของนักศึกษามุมมองแผนภูมิ แล้วส่งค่ากลับเป็น Dictionary<string, object>
            //โดยมีพารามิเตอร์ดังนี้
            //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();

                _ds = UDSStaffDB.GetListUDSStudentRecords(
                        _loginResult["Username"].ToString(),
                        _loginResult["Userlevel"].ToString(),
                        _loginResult["SystemGroup"].ToString(),
                        UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENTVIEWCHART,
                        _paramSearch);

                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _list               = UDSStaffOurServicesUI.DocumentStatusStudentUI.ViewChartUI.SectionMainUI.GetList(_loginResult, _ds);

                _ds.Dispose();

                _searchResult.Add("RecordCount",                _recordCount);
                _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
                _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
                _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
                _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
                _searchResult.Add("List",                       _list);
                _searchResult.Add("NavPage",                    new StringBuilder());

                return _searchResult;
            }
        }  
        
        public class ViewTableUtil
        {
            public static string[,] _menu = new string[,]
            {
                {"รูปภาพประจำตัวและบัตรประจำตัวประชาชน", "Profile Picture and Identity Card", UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD_PREVIEW},
                {"ระเบียนแสดงผลการเรียน", "Transcript", UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPT_PREVIEW}
            };

            //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของสถานะเอกสารของนักศึกษามุมมองตาราง แล้วส่งค่ากลับเป็น Dictionary<string, object>
            //โดยมีพารามิเตอร์ดังนี้
            //1. _page          เป็น string รับค่าชื่อหน้า
            //2. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
            public static Dictionary<string, object> GetSearch(string _page, Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _reportName = String.Empty;
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();

                if (_page == UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN) _reportName = UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE;

                _ds = UDSStaffDB.GetListUDSStudentRecords(
                        _loginResult["Username"].ToString(),
                        _loginResult["Userlevel"].ToString(),
                        _loginResult["SystemGroup"].ToString(),
                        _reportName,
                        _paramSearch);

                if (_reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE))
                {
                    _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                    _recordCount        = _ds.Tables[0].Rows.Count;
                    _recordCountPrimary = _ds.Tables[0].Rows.Count;

                    _list.AppendLine(UDSStaffOurServicesUI.DocumentStatusStudentUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _dr).ToString());
                    _navPage.AppendLine(Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), _page, (int)(_paramSearch["RowPerPage"])).ToString());
                }
                                
                _ds.Dispose();

                _searchResult.Add("RecordCount",                _recordCount);
                _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
                _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
                _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
                _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
                _searchResult.Add("List",                       _list);
                _searchResult.Add("NavPage",                    _navPage);

                return _searchResult;
            }
        }  
    }

    public class ExportProfilePictureApprovedUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };
        
        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการส่งออกรูปภาพประจำตัวที่ผ่านการอนุมัติ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
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

            _ds = UDSStaffDB.GetListUDSStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    "",
                    _paramSearch);

            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = UDSStaffOurServicesUI.ExportProfilePictureApprovedUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }
    }

    public class ExportStudentRecordsInformationForSmartCardUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
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

            _ds = UDSStaffDB.GetListUDSStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    "",
                    _paramSearch);

            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = UDSStaffOurServicesUI.ExportStudentRecordsInformationForSmartCardUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }
    }

    public class CopyProfilePictureApprovedtotheStoreUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการคัดลอกรูปภาพประจำตัวที่ผ่านการอนุมัติไปยังที่เก็บรูป แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
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

                    
            _ds = UDSStaffDB.GetListUDSStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    "",
                    _paramSearch);

            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = UDSStaffOurServicesUI.CopyProfilePictureApprovedtotheStoreUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }
    }

    public class AuditTranscriptApprovedUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };

        public class ViewChartUtil
        {
            //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัดมุมมองแผนภูมิ แล้วส่งค่ากลับเป็น Dictionary<string, object>
            //โดยมีพารามิเตอร์ดังนี้
            //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;                
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();

                _ds = UDSStaffDB.GetListUDSStudentRecords(
                        _loginResult["Username"].ToString(),
                        _loginResult["Userlevel"].ToString(),
                        _loginResult["SystemGroup"].ToString(),
                        UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDVIEWCHART,
                        _paramSearch);
                
                _recordCount        = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _list                   = UDSStaffOurServicesUI.AuditTranscriptApprovedUI.ViewChartUI.SectionMainUI.GetList(_loginResult, _ds);
                
                _ds.Dispose();

                _searchResult.Add("RecordCount",                _recordCount);
                _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
                _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
                _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
                _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
                _searchResult.Add("List",                       _list);
                _searchResult.Add("NavPage",                    new StringBuilder());

                return _searchResult;
            }
        } 
 
        public class ViewTableUtil
        {
            //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัดมุมมองตาราง แล้วส่งค่ากลับเป็น Dictionary<string, object>
            //โดยมีพารามิเตอร์ดังนี้
            //1. _page          เป็น string รับค่าชื่อหน้า
            //2. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
            public static Dictionary<string, object> GetSearch(string _page, Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _reportName = String.Empty;
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();

                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN))                 _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND_MAIN))        _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND_MAIN))        _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND_MAIN))            _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND_MAIN))            _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND_MAIN))         _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND_MAIN))         _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE_MAIN))     _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE_MAIN))     _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE_MAIN))  _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE;
                if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE_MAIN))  _reportName = UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE;

                _ds = UDSStaffDB.GetListUDSStudentRecords(
                        _loginResult["Username"].ToString(),
                        _loginResult["Userlevel"].ToString(),
                        _loginResult["SystemGroup"].ToString(),
                        _reportName,
                        _paramSearch);

                if (_reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE))
                {
                    _dr                 = _ds.Tables[1].Select();
                    _recordCount        = _ds.Tables[0].Rows.Count;
                    _recordCountPrimary = _ds.Tables[0].Rows.Count;

                    if (_recordCountPrimary > 0)
                    {                                                
                        _list.AppendLine(UDSStaffOurServicesUI.AuditTranscriptApprovedUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _dr).ToString());
                        _navPage.AppendLine("<div class='navpage'><div class='navpage-layout'></div></div>");
                    }
                }

                if (_reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENEEDSEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLENOTSEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDRECEIVE) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLESENDNOTRECEIVE))
                {
                    _dr                     = _ds.Tables[2].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                    _recordCount            = _ds.Tables[2].Rows.Count;
                    _recordCountPrimary     = _ds.Tables[2].Rows.Count;

                    _list.AppendLine(UDSStaffOurServicesUI.AuditTranscriptApprovedUI.ViewTableUI.SectionMainUI.GetList(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN, _loginResult, _dr).ToString());
                    _navPage.AppendLine(Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), _page, (int)(_paramSearch["RowPerPage"])).ToString());
                }

                if (_reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENEEDSEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLENOTSEND) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDRECEIVE) ||
                    _reportName.Equals(UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLESENDNOTRECEIVE))
                {
                    _dr                     = _ds.Tables[2].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                    _recordCount            = _ds.Tables[2].Rows.Count;
                    _recordCountPrimary     = _ds.Tables[2].Rows.Count;

                    _list.AppendLine(UDSStaffOurServicesUI.AuditTranscriptApprovedUI.ViewTableUI.SectionMainUI.GetList(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN, _loginResult, _dr).ToString());
                    _navPage.AppendLine(Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), _page, (int)(_paramSearch["RowPerPage"])).ToString());
                }
                
                _ds.Dispose();

                _searchResult.Add("RecordCount",                _recordCount);
                _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
                _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
                _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
                _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
                _searchResult.Add("List",                       _list);
                _searchResult.Add("NavPage",                    _navPage);

                return _searchResult;
            }
        }
    }

    public class ExportSaveAuditTranscriptApprovedUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"/*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"*/
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการส่งออกระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {           
            Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
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

            _ds = UDSStaffDB.GetListUDSStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    "",
                    _paramSearch);

            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = UDSStaffOurServicesUI.ExportSaveAuditTranscriptApprovedUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }
    }
}