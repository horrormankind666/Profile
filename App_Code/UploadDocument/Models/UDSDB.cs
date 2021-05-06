/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๗/๐๕/๒๕๕๘>
Modify date : <๐๗/๐๖/๒๕๕๙>
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

public class UDSDB
{
    public static List<string> GetListText(string _lang, string _fileName)
    {
        List<string> _ls = File.ReadAllLines(HttpContext.Current.Server.MapPath("../../../Module/Operation/UploadDocument/Important/" + _lang + "/" + _fileName)).ToList();

        return _ls;
    }

    public static DataSet GetUDSStudentRecords(string _personId)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsGetPersonStudent",
            new SqlParameter("@personId", _personId));

        return _ds;
    }
    
    public static Dictionary<string, object> ActionSave(HttpContext _c, Dictionary<string, object> _infoLogin)
    {
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        DataSet _ds = new DataSet();
        DataRow _dr;
        string _page = _c.Request["page"];
        string _action = String.Empty;
        string _personId = _infoLogin["PersonId"].ToString();
        string _sectionAction = String.Empty;
        string _transcriptInstitute = String.Empty;
        string _fileName = String.Empty;
        string _savedStatus = String.Empty;
        string _submittedStatus = String.Empty;
        string _approvalStatus = String.Empty;
        int _saveError = 0;
        bool _actionSave = true;

        try
        {

            if (_page.Equals(UDSUtil.PAGE_UPLOADSUBMITDOCUMENT_ADDUPDATE))
            {
                if (_actionSave.Equals(true))
                {
                    _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_udsSetUploadLog",
                            new SqlParameter("@personId", _personId),
                            new SqlParameter("@section",_c.Request["section"]),
                            new SqlParameter("@sectionAction", _c.Request["sectionaction"]),                            
                            new SqlParameter("@filename", _c.Request["filename"]),
                            new SqlParameter("@transcriptInstitute", _c.Request["transcriptinstitute"]),
                            new SqlParameter("@savedStatus", _c.Request["savedstatus"]),
                            new SqlParameter("@submittedStatus", _c.Request["submittedstatus"]),
                            new SqlParameter("@approvalStatus", _c.Request["approvalstatus"]),
                            new SqlParameter("@by", _personId),
                            new SqlParameter("@ip", Util.GetIP()));
                }
            }

            if (_actionSave.Equals(true))
            {
                _dr = _ds.Tables[0].Rows[0];
                _saveError = (int.Parse(_dr[0].ToString()).Equals(1) ? 0 : 1);
            }

            _ds.Dispose();
        }
        catch
        {
            _ds.Dispose();
            _saveError = 1;
        }

        _saveResult.Add("SaveError", _saveError);

        return _saveResult;
    }
}