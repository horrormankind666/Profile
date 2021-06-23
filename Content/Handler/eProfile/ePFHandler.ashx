<%@ WebHandler Language="C#" Class="ePFHandler" %>

 /*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๘/๐๙/๒๕๕๗>
Modify date : <๒๓/๐๖/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นที่ถูกเรียกใช้งานจาก javascript>
=============================================
*/

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using NUtil;
using NStudentService;

public class ePFHandler : IHttpHandler, IRequiresSessionState
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
            case "calage":
                ShowCalAge(_c);
                break;
            case "calbmi":
                ShowCalBMI(_c);
                break;
            case "save":
                ShowSave(_c);
                break;
            case "image2stream":
                ShowImage2Stream(_c);
                break;
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = ePFUtil.GetPage(_page);

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = ePFUtil.GetForm(_form, _id);

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
                _content = ePFUI.GetComboboxProvince(_c.Request["id"], _c.Request["country"]);
                break;
            case "getdistrict":
                _content = ePFUI.GetComboboxDistrict(_c.Request["id"], _c.Request["province"]);
                break;
            case "getsubdistrict":
                _content = ePFUI.GetComboboxSubdistrict(_c.Request["id"], _c.Request["district"]);
                break;
            case "gettitleprefix":
                _content = ePFUI.GetComboboxTitlePrefix(_c.Request["id"], _c.Request["gender"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

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
            case "getbodymassdetail":
                _content = ePFStudentRecordsUI.SectionAddUpdateUI.HealthyUI.BodyMassIndexUI.GetList(_c.Request["data"]);
                break;
            case "gettravelabroaddetail":
                _content = ePFStudentRecordsUI.SectionAddUpdateUI.HealthyUI.TravelAbroadUI.GetList(_c.Request["data"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

        _c.Response.Write(_json.Serialize(_listResult));
    }

    private void ShowCalAge(HttpContext _c)
    {
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _ageResult = new Dictionary<string, object>();

        _ageResult = ePFUtil.CalAge(_c.Request["birthdate"], Util.CurrentDate("dd/MM/yyyy"));

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

        _c.Response.Write(_json.Serialize(_bmiResult));
    }

    private void ShowImage2Stream(HttpContext _c)
    {
        MemoryStream _ms = Util.ImageProcessUtil.ImageToStream(Util.DecodeFromBase64(_c.Request["f"]), "png");

        _ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.End();
    }

    private void ShowSave(HttpContext _c)
    {
        Dictionary<string, object> _loginResult = ePFUtil.GetInfoLogin("", "");
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        int _saveError = 0;
        string _signinYN = _c.Request["signinyn"];
        string _personId = _loginResult["PersonId"].ToString();
        bool _save = false;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();

        if (_save.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
            _save = true;

        if (_save.Equals(true))
        {
            _saveResult = ePFDB.ActionSave(_c, _loginResult);
            _saveError = int.Parse(_saveResult["SaveError"].ToString());
            _personId = _saveResult["PersonId"].ToString();
        }

        _saveResult.Clear();
        _saveResult.Add("CookieError", _cookieError.ToString());
        _saveResult.Add("UserError", _userError.ToString());
        _saveResult.Add("SaveError", _saveError.ToString());
        _saveResult.Add("PersonId", _personId);

        _c.Response.Write(_json.Serialize(_saveResult));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}