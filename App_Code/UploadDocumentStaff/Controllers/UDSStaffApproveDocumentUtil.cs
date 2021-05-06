// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๕/๐๖/๒๕๕๘>
// Modify date  : <๐๘/๐๗/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการอนุมัตืเอกสาร>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;

public class UDSStaffApproveDocumentUtil
{
    public static string[] _sortOrderBy = new string[]
    {
        "Student ID"/*,
        "Name",
        "Faculty",
        "Program",
        "Year Attended",
        "Submitted Date",
        "Approval Date"*/
    };
    
    public static string[,] _menu = new string[,]
    {
        {"รูปภาพประจำตัวและบัตรประจำตัวประชาชน", "Profile Picture and Identity Card", UDSStaffUtil.PAGE_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD_EDIT},
        {"ระเบียนแสดงผลการเรียน", "Transcript", UDSStaffUtil.PAGE_APPROVEDOCUMENTTRANSCRIPT_EDIT}
    };

    //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการอนุมัตืเอกสาร แล้วส่งค่ากลับเป็น Dictionary<string, object>
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
        _list               = UDSStaffApproveDocumentUI.SectionMainUI.GetList(_loginResult, _dr);
        _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN, (int)(_paramSearch["RowPerPage"]));

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