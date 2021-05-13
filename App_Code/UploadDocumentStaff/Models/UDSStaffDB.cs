/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๓/๐๖/๒๕๕๘>
Modify date : <๑๒/๐๗/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการจัดการข้อมูลในฐานข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using NUtil;

public class UDSStaffDB
{
    public static List<string> GetListText(string _lang, string _fileName)
    {
        List<string> _ls = File.ReadAllLines(HttpContext.Current.Server.MapPath("../../../Module/Operation/UploadDocumentStaff/Important/" + _lang + "/" + _fileName)).ToList();

        return _ls;
    }
    
    public static DataSet GetListUDSStudentRecords(string _username, string _userlevel, string _systemGroup, string _reportName, Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetListPersonStudentWithAuthenStaff",
            new SqlParameter("@username", _username),
            new SqlParameter("@userlevel", _userlevel),
            new SqlParameter("@systemGroup", _systemGroup),
            new SqlParameter("@sectionAction", (_paramSearch.ContainsKey("SectionAction").Equals(true) ? _paramSearch["SectionAction"] : String.Empty)),
            new SqlParameter("@reportName", _reportName),
            new SqlParameter("@keyword", (_paramSearch.ContainsKey("Keyword").Equals(true) ? _paramSearch["Keyword"] : String.Empty)),
            new SqlParameter("@degreeLevel", (_paramSearch.ContainsKey("DegreeLevel").Equals(true) ? _paramSearch["DegreeLevel"] : String.Empty)),
            new SqlParameter("@faculty", (_paramSearch.ContainsKey("Faculty").Equals(true) ? _paramSearch["Faculty"] : String.Empty)),
            new SqlParameter("@program", (_paramSearch.ContainsKey("Program").Equals(true) ? _paramSearch["Program"] : String.Empty)),
            new SqlParameter("@yearEntry", (_paramSearch.ContainsKey("YearEntry").Equals(true) ? _paramSearch["YearEntry"] : String.Empty)),
            new SqlParameter("@entranceType", (_paramSearch.ContainsKey("EntranceType").Equals(true) ? _paramSearch["EntranceType"] : String.Empty)),
            new SqlParameter("@studentStatus", (_paramSearch.ContainsKey("StudentStatus").Equals(true) ? _paramSearch["StudentStatus"] : String.Empty)),
            new SqlParameter("@documentUpload", (_paramSearch.ContainsKey("DocumentUpload").Equals(true) ? _paramSearch["DocumentUpload"] : String.Empty)),
            new SqlParameter("@submittedStatus", (_paramSearch.ContainsKey("SubmittedStatus").Equals(true) ? _paramSearch["SubmittedStatus"] : String.Empty)),
            new SqlParameter("@approvalStatus", (_paramSearch.ContainsKey("ApprovalStatus").Equals(true) ? _paramSearch["ApprovalStatus"] : String.Empty)),
            new SqlParameter("@instituteCountry", (_paramSearch.ContainsKey("InstituteCountry").Equals(true) ? _paramSearch["InstituteCountry"] : String.Empty)),
            new SqlParameter("@instituteProvince", (_paramSearch.ContainsKey("InstituteProvince").Equals(true) ? _paramSearch["InstituteProvince"] : String.Empty)),
            new SqlParameter("@institute", (_paramSearch.ContainsKey("Institute").Equals(true) ? _paramSearch["Institute"] : String.Empty)),
            new SqlParameter("@sentDateStartAudit", (_paramSearch.ContainsKey("SentDateStartAudit").Equals(true) ? _paramSearch["SentDateStartAudit"] : String.Empty)),
            new SqlParameter("@sentDateEndAudit", (_paramSearch.ContainsKey("SentDateEndAudit").Equals(true) ? _paramSearch["SentDateEndAudit"] : String.Empty)),
            new SqlParameter("@auditedStatus", (_paramSearch.ContainsKey("AuditedStatus").Equals(true) ? _paramSearch["AuditedStatus"] : String.Empty)),
            new SqlParameter("@exportStatus", (_paramSearch.ContainsKey("ExportStatus").Equals(true) ? _paramSearch["ExportStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy", (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression", (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty))
        );

        return _ds;
    }

    public static DataSet GetUDSStudentRecords(string _personId)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetPersonStudent",
            new SqlParameter("@personId", _personId));

        return _ds;
    }

    public static DataSet GetListUDSCountry(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetListCountry",
            new SqlParameter("@cancelledStatus", (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy", (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression", (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty))
        );

        return _ds;
    }

    public static DataSet GetListUDSProvince(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetListProvince",
            new SqlParameter("@country", (_paramSearch.ContainsKey("Country").Equals(true) ? _paramSearch["Country"] : String.Empty)),
            new SqlParameter("@cancelledStatus", (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy", (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression", (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty))
        );

        return _ds;
    }

    public static DataSet GetListUDSInstitute(Dictionary<string, object> _paramSearch)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetListInstitute",
            new SqlParameter("@country", (_paramSearch.ContainsKey("Country").Equals(true) ? _paramSearch["Country"] : String.Empty)),
            new SqlParameter("@province", (_paramSearch.ContainsKey("Province").Equals(true) ? _paramSearch["Province"] : String.Empty)),
            new SqlParameter("@cancelledStatus", (_paramSearch.ContainsKey("CancelledStatus").Equals(true) ? _paramSearch["CancelledStatus"] : String.Empty)),
            new SqlParameter("@sortOrderBy", (_paramSearch.ContainsKey("SortOrderBy").Equals(true) ? _paramSearch["SortOrderBy"] : String.Empty)),
            new SqlParameter("@sortExpression", (_paramSearch.ContainsKey("SortExpression").Equals(true) ? _paramSearch["SortExpression"] : String.Empty))
        );

        return _ds;
    }

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
        string _id = String.Empty;
        string _profilepictureApprovalDate = String.Empty;
		string _identitycardApprovalDate = String.Empty;
	    string _transcriptfrontsideApprovalDate = String.Empty;
        string _transcriptbacksideApprovalDate = String.Empty;
        int _saveError = 0;
        bool _actionSave = true;
        bool _chkSaveError = true;

        try
        {
            if (_page.Equals(UDSStaffUtil.PAGE_SETTINGACCESSTOTHESYSTEM_EDIT))
            {
                if (_actionSave.Equals(true))
                {                    
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_sysSetDateEvent",
                        new SqlParameter("@action", "UPDATE"),
                        new SqlParameter("@sysName", _systemGroup),
                        new SqlParameter("@sysEvent", _systemGroup),
                        new SqlParameter("@startDate", _c.Request["startdate"]),
                        new SqlParameter("@startTime", _c.Request["starttime"]),
                        new SqlParameter("@endDate", _c.Request["enddate"]),
                        new SqlParameter("@endTime", _c.Request["endtime"]),
                        new SqlParameter("@yearEntry", _c.Request["yearentry"]),
                        new SqlParameter("@entranceType", _c.Request["entrancetype"]),
                        new SqlParameter("@facultyprogram", _c.Request["facultyprogram"]),
                        new SqlParameter("@cancel", _c.Request["cancelledstatus"]),
                        new SqlParameter("@by", _username)
                    );
                }
            }
            
            if (_page.Equals(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_ADDUPDATE) ||
                _page.Equals(UDSStaffUtil.PAGE_APPROVEDOCUMENT_EDIT))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsSetUploadLog",
                        new SqlParameter("@personId", _c.Request["personid"]),
                        new SqlParameter("@section", _c.Request["section"]),
                        new SqlParameter("@sectionAction", _c.Request["sectionaction"]),
                        new SqlParameter("@filename", _c.Request["filename"]),
                        new SqlParameter("@transcriptInstitute", _c.Request["transcriptinstitute"]),
                        new SqlParameter("@savedStatus", _c.Request["savedstatus"]),
                        new SqlParameter("@submittedStatus", _c.Request["submittedstatus"]),
                        new SqlParameter("@approvalStatus", _c.Request["approvalstatus"]),
                        new SqlParameter("@approvalBy", _username),
                        new SqlParameter("@approvalIP", Util.GetIP()),
                        new SqlParameter("@message", _c.Request["message"]),
                        new SqlParameter("@by", _username),
                        new SqlParameter("@ip", Util.GetIP()));
                }
            }
            
            if (_chkSaveError.Equals(true) && _actionSave.Equals(true))
            {
                _dr = _ds.Tables[0].Rows[0];
                _saveError = (int.Parse(_dr[0].ToString()).Equals(1) ? 0 : 1);
                
                if (_page.Equals(UDSStaffUtil.PAGE_APPROVEDOCUMENT_EDIT))
                {
                    _profilepictureApprovalDate = (!String.IsNullOrEmpty(_dr[2].ToString()) ? DateTime.Parse(_dr[2].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
                    _identitycardApprovalDate = (!String.IsNullOrEmpty(_dr[3].ToString()) ? DateTime.Parse(_dr[3].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
                    _transcriptfrontsideApprovalDate = (!String.IsNullOrEmpty(_dr[4].ToString()) ? DateTime.Parse(_dr[4].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
                    _transcriptbacksideApprovalDate = (!String.IsNullOrEmpty(_dr[5].ToString()) ? DateTime.Parse(_dr[5].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
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
        _saveResult.Add("ProfilePictureApprovalDate", _profilepictureApprovalDate);
        _saveResult.Add("IdentityCardApprovalDate", _identitycardApprovalDate);
        _saveResult.Add("TranscriptFrontsideApprovalDate", _transcriptfrontsideApprovalDate);
        _saveResult.Add("TranscriptBacksideApprovalDate", _transcriptbacksideApprovalDate);

        return _saveResult;
    }
}