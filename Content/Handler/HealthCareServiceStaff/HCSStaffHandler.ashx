<%@ WebHandler Language="C#" Class="HCSStaffHandler" %>

/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๐๗/๒๕๕๘>
Modify date : <๒๔/๐๕/๒๕๖๒>
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

public class HCSStaffHandler : IHttpHandler, IRequiresSessionState
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
            case "list":
                ShowList(_c);
                break;
            case "search":
                ShowSearch(_c);
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
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = HCSStaffUtil.GetPage(_page, _id);

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = HCSStaffUtil.GetForm(_form, _id);

        _c.Response.Write(_json.Serialize(_formResult));
    }    
        
    private void ShowCombobox(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _comboboxResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "getprogram":
                _content = HCSStaffUI.GetComboboxProgram(_c.Request["id"], _c.Request["degreelevel"], _c.Request["faculty"]);
                break;
            case "getagencyregistered":
                _content = HCSStaffUI.GetComboboxAgencyRegistered(_c.Request["id"], _c.Request["yearentry"], _c.Request["registrationform"]);
                break;
        }

        _comboboxResult.Add("Content", _content.ToString());

        _c.Response.Write(_json.Serialize(_comboboxResult));        
    }
    
    private void ShowList(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _listResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "getprogram":
                _content = HCSStaffUI.GetListProgram(_c.Request["idCheckbox"], _c.Request["degreelevel"], _c.Request["faculty"], _c.Request["program"]);
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

        _content = HCSStaffUtil.GetSearch(_pageMain, _pageSearch, _c);

        _searchResult.Add("RecordCountContent", Util.GetValueDataDictionary(_content, "RecordCount", double.Parse(_content["RecordCount"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountPrimary", double.Parse(_content["RecordCountPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountSecondary", (!_content["RecordCountSecondary"].Equals(0) ? double.Parse(_content["RecordCountSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("RecordCountAllPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllPrimary", double.Parse(_content["RecordCountAllPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountAllSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllSecondary", (!_content["RecordCountAllSecondary"].Equals(0) ? double.Parse(_content["RecordCountAllSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("ListContent", Util.GetValueDataDictionary(_content, "List", _content["List"].ToString(), String.Empty));
        _searchResult.Add("NavPageContent", Util.GetValueDataDictionary(_content, "NavPage", _content["NavPage"].ToString(), String.Empty));

        _c.Response.Write(_json.Serialize(_searchResult));
    }
    
    private void ShowSave(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _signinYN = _c.Request["signinyn"];
        string _id = _c.Request["id"];
        string _personId = String.Empty;
        string _termDate = String.Empty;

        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin(_page, _id);
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());
        int _saveError = 0;
        bool _save = false;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();
        
        if (_save.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
        {
            _save = true;
            _userError = (_studentError.Equals(0) ? _studentError : 2);
        }
        
        if (_save.Equals(true))
        {
            _saveResult = HCSStaffDB.ActionSave(_c, _loginResult);
            _saveError = int.Parse(_saveResult["SaveError"].ToString());
            _personId = _saveResult["PersonId"].ToString();
            _termDate = _saveResult["TermDate"].ToString();
        }        

        _saveResult.Clear();
        _saveResult.Add("CookieError", _cookieError.ToString());
        _saveResult.Add("UserError", _userError.ToString());
        _saveResult.Add("SaveError", _saveError.ToString());
        _saveResult.Add("PersonId", _personId);
        _saveResult.Add("TermDate", _termDate);
        
        _c.Response.Write(_json.Serialize(_saveResult));
    }
    
    private void ShowProcess(HttpContext _c)
    {
        string _page = _c.Request["page"];
        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin(_page, "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _progressResult = new Dictionary<string, object>();
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        
        if (_cookieError.Equals(0) && _userError.Equals(0))
            _progressResult = HCSStaffProgressDataUtil.GetProcess(_loginResult, _page, HCSStaffProgressDataUtil.SetValueProcess(_c));

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

    private void ShowImage2Stream(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageToStream(Util.DecodeFromBase64(_c.Request["f"]), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }
        
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}