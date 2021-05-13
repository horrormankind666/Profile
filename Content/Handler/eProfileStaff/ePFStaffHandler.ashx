<%@ WebHandler Language="C#" Class="ePFStaffHandler" %>

/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๔/๑๒/๒๕๕๗>
Modify date : <๐๙/๐๓/๒๕๖๔>
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
using NStudentService;

public class ePFStaffHandler : IHttpHandler, IRequiresSessionState
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
            case "calage":
                ShowCalAge(_c);
                break;
            case "calbmi":
                ShowCalBMI(_c);
                break;
            case "save":
                ShowSave(_c);
                break;
            case "process":
                ShowProcess(_c);
                break;
            /*
            case "transfer":
                ShowTransfer(_c);
                break;
            */
            case "image2stream":
                ShowImage2Stream(_c);
                break;
            case "image2streamnoencode":
                ShowImage2StreamNoEncode(_c);
                break;
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = ePFStaffUtil.GetPage(_page, _id);

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = ePFStaffUtil.GetForm(_form, _id);

        _json.MaxJsonLength = Int32.MaxValue;

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
            case "getprovince":
                _content = ePFStaffUI.GetComboboxProvince(_c.Request["id"], _c.Request["country"]);
                break;
            case "getdistrict":
                _content = ePFStaffUI.GetComboboxDistrict(_c.Request["id"], _c.Request["province"]);
                break;
            case "getsubdistrict": 
                _content = ePFStaffUI.GetComboboxSubdistrict(_c.Request["id"], _c.Request["district"]);
                break;
            case "getprogram": 
                _content = ePFStaffUI.GetComboboxProgram(_c.Request["id"], _c.Request["degreelevel"], _c.Request["faculty"]);
                break;
            case "getprogrambyjoinprogram": 
                _content = ePFStaffUI.GetComboboxProgramByJoinProgram(_c.Request["id"], _c.Request["degreelevel"], _c.Request["faculty"], _c.Request["joinprogram"]);
                break;
            case "gettitleprefix": 
                _content = ePFStaffUI.GetComboboxTitlePrefix(_c.Request["id"], _c.Request["gender"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_listResult));
    }

    private void ShowList(HttpContext _c)
    {
        string _cmd = _c.Request["cmd"];
        StringBuilder _content = new StringBuilder();
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _listResult = new Dictionary<string, object>();

        switch (_cmd)
        {
            case "getprogramcode":
                _content = _content.Append(ePFStaffUtil.GetProgramCode(_c.Request["program"]));
                break;
            case "getbodymassdetail":
                _content = ePFStaffStudentRecordsUI.SectionAddUpdateUI.HealthyUI.BodyMassIndexUI.GetList(_c.Request["data"]);
                break;
            case "gettravelabroaddetail":
                _content = ePFStaffStudentRecordsUI.SectionAddUpdateUI.HealthyUI.TravelAbroadUI.GetList(_c.Request["data"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

        _json.MaxJsonLength = Int32.MaxValue;

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

        _content = ePFStaffUtil.GetSearch(_pageMain, _pageSearch, _c);

        _searchResult.Add("RecordCountContent", Util.GetValueDataDictionary(_content, "RecordCount", double.Parse(_content["RecordCount"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountPrimary", double.Parse(_content["RecordCountPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountSecondary", (!_content["RecordCountSecondary"].Equals(0) ? double.Parse(_content["RecordCountSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("RecordCountAllPrimaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllPrimary", double.Parse(_content["RecordCountAllPrimary"].ToString()).ToString("#,##0"), String.Empty));
        _searchResult.Add("RecordCountAllSecondaryContent", Util.GetValueDataDictionary(_content, "RecordCountAllSecondary", (!_content["RecordCountAllSecondary"].Equals(0) ? double.Parse(_content["RecordCountAllSecondary"].ToString()).ToString("#,##0") : String.Empty), String.Empty));
        _searchResult.Add("ListContent", Util.GetValueDataDictionary(_content, "List", _content["List"].ToString(), String.Empty));
        _searchResult.Add("NavPageContent", Util.GetValueDataDictionary(_content, "NavPage", _content["NavPage"].ToString(), String.Empty));

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_searchResult));
    }

    private void ShowCalAge(HttpContext _c)
    {
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _ageResult = new Dictionary<string, object>();
        int _age = 0;

        _age = ePFStaffUtil.CalAge(_c.Request["birthdate"], Util.CurrentDate("dd/MM/yyyy"));

        _ageResult.Add("Age", _age.ToString());

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_ageResult));
    }

    private void ShowCalBMI(HttpContext _c)
    {
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _bmiResult = new Dictionary<string, object>();
        StudentService _ss = new StudentService();
        double _bmi = 0;

        _bmi = _ss.CalBMI(_c.Request["weight"], _c.Request["height"]);

        _bmiResult.Add("BMI", _bmi.ToString("#,##0.00"));
        _bmiResult.Add("Meaning", _ss.MeaningBMI(_bmi));

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_bmiResult));
    }

    private void ShowImage2Stream(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageToStream(Util.DecodeFromBase64(_c.Request["f"]), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }

    private void ShowImage2StreamNoEncode(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageToStream(Util.DecodeFromBase64(Util.EncodeToBase64(_c.Request["f"])), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }

    private void ShowSave(HttpContext _c)
    {
        string _page = _c.Request["page"];
        string _signinYN = _c.Request["signinyn"];
        string _id = _c.Request["id"];
        string _personId = String.Empty;

        Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin(_page, _id);
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

            if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSTALENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSHEALTHY_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSWORK_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFINANCIAL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE) ||
                _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
                _userError = (_studentError.Equals(0) ? _studentError : 2);
        }

        if (_save.Equals(true))
        {
            _saveResult = ePFStaffDB.ActionSave(_c, _loginResult);
            _saveError = int.Parse(_saveResult["SaveError"].ToString());
            _personId = _saveResult["PersonId"].ToString();
        }

        _saveResult.Clear();
        _saveResult.Add("CookieError", _cookieError.ToString());
        _saveResult.Add("UserError", _userError.ToString());
        _saveResult.Add("SaveError", _saveError.ToString());
        _saveResult.Add("PersonId", _personId);

        _json.MaxJsonLength = Int32.MaxValue;

        _c.Response.Write(_json.Serialize(_saveResult));
    }

    private void ShowProcess(HttpContext _c)
    {
        string _page = _c.Request["page"];
        Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin(_page, "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString());
        int _studentError = int.Parse(_loginResult["StudentError"].ToString());
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _progressDataResult = new Dictionary<string, object>();
        Dictionary<string, object> _processResult = new Dictionary<string, object>();

        if (_cookieError.Equals(0) && _userError.Equals(0))
            _progressDataResult = ePFStaffProgressDataUtil.GetProcess(_loginResult, _page, ePFStaffProgressDataUtil.SetValueProcess(_c));

        _processResult.Clear();
        _processResult.Add("CookieError", _cookieError.ToString());
        _processResult.Add("UserError", _userError.ToString());
        _processResult.Add("Complete", (_progressDataResult.ContainsKey("Complete").Equals(true) ? _progressDataResult["Complete"] : String.Empty));
        _processResult.Add("Incomplete", (_progressDataResult.ContainsKey("Incomplete").Equals(true) ? _progressDataResult["Incomplete"] : String.Empty));
        _processResult.Add("DetailComplete", (_progressDataResult.ContainsKey("DetailComplete").Equals(true) ? _progressDataResult["DetailComplete"] : String.Empty));
        _processResult.Add("DetailIncomplete", (_progressDataResult.ContainsKey("DetailIncomplete").Equals(true) ? _progressDataResult["DetailIncomplete"] : String.Empty));
        _processResult.Add("DownloadFolder", (_progressDataResult.ContainsKey("DownloadFolder").Equals(true) ? _progressDataResult["DownloadFolder"] : String.Empty));
        _processResult.Add("DownloadFile", (_progressDataResult.ContainsKey("DownloadFile").Equals(true) ? _progressDataResult["DownloadFile"] : String.Empty));

        _json.MaxJsonLength = Int32.MaxValue;

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