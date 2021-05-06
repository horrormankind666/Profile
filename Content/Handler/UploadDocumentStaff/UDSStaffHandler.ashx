<%@ WebHandler Language="C#" Class="UDSStaffHandler" %>

/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๒/๐๖/๒๕๕๘>
Modify date : <๑๘/๐๕/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นที่ถูกเรียกใช้งานจาก javascript>
=============================================
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using NUtil;

public class UDSStaffHandler : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext _context)
    {
        _context.Response.ContentType = "application/json";
        bool _error = false;

        if (_error.Equals(false))
        {
            string _action = _context.Request["action"];

            GetContentAction(_action, _context);
        }
    }

    private void GetContentAction(string _action, HttpContext _c)
    {
        switch (_action)
        {
            case "page":
                ShowPage(_c);
                break;
            case "form":
                ShowForm(_c);
                break;
            case "combobox":
                ShowCombobox(_c);
                break;
            case "search":
                ShowSearch(_c);
                break;
            case "savefile":
                ShowSaveFile(_c);
                break;
            case "removefile":
                ShowRemoveFile(_c);
                break;
            case "save":
                ShowSave(_c);
                break;
            case "process":
                ShowProcess(_c);
                break;
            case "image2stream":
                ShowImage2Stream(_c);
                break;
            case "imagefile2stream":
                ShowImageFile2Stream(_c);
                break;
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = UDSStaffUtil.GetPage(_page, _id);

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = UDSStaffUtil.GetForm(_form, _id);

        _c.Response.Write(_json.Serialize(_formResult));
    }

    private void ShowCombobox(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _listResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "getprogram":
                _content = UDSStaffUI.GetComboboxProgram(_c.Request["id"], _c.Request["degreelevel"], _c.Request["faculty"]);
                break;
            case "getprovince":
                _content = UDSStaffUI.GetComboboxProvince(_c.Request["id"], _c.Request["country"]);
                break;
            case "getudsprovince":
                _content = UDSStaffUI.GetComboboxUDSProvince(_c.Request["id"], _c.Request["country"]);
                break;
            case "getinstitute":
                _content = UDSStaffUI.GetComboboxInsititue(_c.Request["id"], _c.Request["province"]);
                break;
            case "getudsinstitute":
                _content = UDSStaffUI.GetComboboxUDSInsititue(_c.Request["id"], _c.Request["province"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

        _c.Response.Write(_json.Serialize(_listResult));
    }

    private void ShowSearch(HttpContext _c)
    {
        string _pageMain = _c.Request["pagemain"];
        string _pageSearch = _c.Request["pagesearch"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _content = new Dictionary<string, object>();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();

        _content = UDSStaffUtil.GetSearch(_pageMain, _pageSearch, _c);

        _searchResult.Add("RecordCountContent", Util.GetValueDataDictionary(_content, "RecordCount", double.Parse(_content["RecordCount"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountPrimary", double.Parse(_content["RecordCountPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountSecondary", (!_content["RecordCountSecondary"].Equals(0) ? double.Parse(_content["RecordCountSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("RecordCountAllPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllPrimary", double.Parse(_content["RecordCountAllPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountAllSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllSecondary", (!_content["RecordCountAllSecondary"].Equals(0) ? double.Parse(_content["RecordCountAllSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("ListContent", Util.GetValueDataDictionary(_content, "List", _content["List"].ToString(), String.Empty));
        _searchResult.Add("NavPageContent", Util.GetValueDataDictionary(_content, "NavPage", _content["NavPage"].ToString(), String.Empty));

        _c.Response.Write(_json.Serialize(_searchResult));
    }

    private void ShowSaveFile(HttpContext _c)
    {
        string _personId = _c.Request["personid"];
        string _section = _c.Request["section"];
        string _fileDir = _c.Request["filedir"];
        string _fileName = _c.Request["filename"];
        int _cropX = int.Parse(_c.Request["cropx"]);
        int _cropY = int.Parse(_c.Request["cropy"]);
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _savefileResult = new Dictionary<string, object>();

        _savefileResult = UDSStaffUploadSubmitDocumentUtil.CropAndSaveFile(_personId, _section, _fileDir, _fileName, _cropX, _cropY);

        _c.Response.Write(_json.Serialize(_savefileResult));
    }

    private void ShowRemoveFile(HttpContext _c)
    {
        string _fileDir = _c.Request["filedir"];
        string _fileName = _c.Request["filename"];
        int _error = 0;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _removefileResult = new Dictionary<string, object>();

        _error = Util.RemoveSingleFile(_fileDir, _fileName);

        _removefileResult.Add("Error", _error);
        _removefileResult.Add("FileDir", _fileDir);
        _removefileResult.Add("FileName", _fileName);

        _c.Response.Write(_json.Serialize(_removefileResult));
    }

    private void ShowImage2Stream(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageToStream(Util.DecodeFromBase64(_c.Request["f"]), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }

    private void ShowImageFile2Stream(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageFileToStream(Util.DecodeFromBase64(_c.Request["f"]));

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }

    private void ShowSave(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _signinYN = _c.Request["signinyn"];
        string _personId = _c.Request["personid"];
        string _profilepictureApprovalDate = String.Empty;
        string _identitycardApprovalDate = String.Empty;
        string _transcriptfrontsideApprovalDate = String.Empty;
        string _transcriptbacksideApprovalDate = String.Empty;

        Dictionary<string, object> _infoLoginResult = UDSStaffUtil.GetInfoLogin(_page, _personId);
        int _cookieError = int.Parse(_infoLoginResult["CookieError"].ToString());
        int _userError = int.Parse(_infoLoginResult["UserError"].ToString()); ;
        int _studentError = int.Parse(_infoLoginResult["StudentError"].ToString());
        int _saveError = 0;
        bool _save = false;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();

        if (_save.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
        {
            _save = true;
            _userError = (_page.Equals(UDSStaffUtil.PAGE_APPROVEDOCUMENT_EDIT) ? (_studentError.Equals(0) ? _studentError : 2) : _userError);
        }

        if (_save.Equals(true))
        {
            _saveResult = UDSStaffDB.ActionSave(_c, _infoLoginResult);
            _saveError = int.Parse(_saveResult["SaveError"].ToString());
            _personId = _saveResult["PersonId"].ToString();
            _profilepictureApprovalDate = _saveResult["ProfilePictureApprovalDate"].ToString();
            _identitycardApprovalDate = _saveResult["IdentityCardApprovalDate"].ToString();
            _transcriptfrontsideApprovalDate = _saveResult["TranscriptFrontsideApprovalDate"].ToString();
            _transcriptbacksideApprovalDate = _saveResult["TranscriptBacksideApprovalDate"].ToString();
        }

        _saveResult.Clear();
        _saveResult.Add("CookieError", _cookieError.ToString());
        _saveResult.Add("UserError", _userError.ToString());
        _saveResult.Add("SaveError", _saveError.ToString());
        _saveResult.Add("PersonId", _personId);
        _saveResult.Add("ProfilePictureApprovalDate", _profilepictureApprovalDate);
        _saveResult.Add("IdentityCardApprovalDate", _identitycardApprovalDate);
        _saveResult.Add("TranscriptFrontsideApprovalDate", _transcriptfrontsideApprovalDate);
        _saveResult.Add("TranscriptBacksideApprovalDate", _transcriptbacksideApprovalDate);


        _c.Response.Write(_json.Serialize(_saveResult));
    }

    private void ShowProcess(HttpContext _c)
    {
        string _page = _c.Request["page"];
        Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin(_page, "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _progressResult = new Dictionary<string, object>();
        Dictionary<string, object> _processResult = new Dictionary<string, object>();

        if (_cookieError.Equals(0) && _userError.Equals(0))
            _progressResult = UDSStaffProgressDataUtil.GetProcess(_loginResult, _page, UDSStaffProgressDataUtil.SetValueProcess(_c));

        _processResult.Clear();
        _processResult.Add("CookieError", _cookieError.ToString());
        _processResult.Add("UserError", _userError.ToString());
        _processResult.Add("ConnServer", (_progressResult.ContainsKey("ConnServer").Equals(true) ? (!_progressResult["ConnServer"].Equals("0") ? "2" : _progressResult["ConnServer"]) : "0"));
        _processResult.Add("Complete", (_progressResult.ContainsKey("Complete").Equals(true) ? _progressResult["Complete"] : String.Empty));
        _processResult.Add("Incomplete", (_progressResult.ContainsKey("Incomplete").Equals(true) ? _progressResult["Incomplete"] : String.Empty));
        _processResult.Add("DetailComplete", (_progressResult.ContainsKey("DetailComplete").Equals(true) ? _progressResult["DetailComplete"] : String.Empty));
        _processResult.Add("DetailIncomplete", (_progressResult.ContainsKey("DetailIncomplete").Equals(true) ? _progressResult["DetailIncomplete"] : String.Empty));
        _processResult.Add("DownloadFolder", (_progressResult.ContainsKey("DownloadFolder").Equals(true) ? _progressResult["DownloadFolder"] : String.Empty));
        _processResult.Add("DownloadFile", (_progressResult.ContainsKey("DownloadFile").Equals(true) ? _progressResult["DownloadFile"] : String.Empty));

        _c.Response.Write(_json.Serialize(_processResult));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}