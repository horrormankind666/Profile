<%@ WebHandler Language="C#" Class="UDSHandler" %>

/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๗/๐๕/๒๕๕๘>
Modify date : <๑๕/๐๗/๒๕๖๔>
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
using NFinServiceLogin;

public class UDSHandler : IHttpHandler, IRequiresSessionState
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
            case "savefile":
                ShowSaveFile(_c);
                break;
            case "removefile":
                ShowRemoveFile(_c);
                break;
            case "save":
                ShowSave(_c);
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
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = UDSUtil.GetPage(_page);

        _c.Response.Write(_json.Serialize(_pageResult));
    }

    private void ShowForm(HttpContext _c)
    {
        string _form = _c.Request["form"];
        string _id = _c.Request["id"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();

        _formResult = UDSUtil.GetForm(_form, _id);

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
                _content = UDSUI.GetComboboxProvince(_c.Request["id"], _c.Request["country"]);
                break;
            case "getinstitute":
                _content = UDSUI.GetComboboxInsititue(_c.Request["id"], _c.Request["province"]);
                break;
        }

        _listResult.Add("Content", _content.ToString());

        _c.Response.Write(_json.Serialize(_listResult));
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

        _savefileResult = UDSUploadSubmitDocumentUtil.CropAndSaveFile(_personId, _section, _fileDir, _fileName, _cropX, _cropY);

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
        Dictionary<string, object> _infoLoginResult = UDSUtil.GetInfoLogin("", "");
        int _cookieError = int.Parse(_infoLoginResult["CookieError"].ToString());
        int _userError = int.Parse(_infoLoginResult["UserError"].ToString()); ;
        int _saveError = 0;
        string _signinYN = _c.Request["signinyn"];
        string _page = _c.Request["page"];
        string _personId = _infoLoginResult["PersonId"].ToString();
        bool _save = false;
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _saveResult = new Dictionary<string, object>();

        if (_save.Equals(false) && _signinYN.Equals("Y") && _cookieError.Equals(0) && _userError.Equals(0))
            _save = true;

        if (_save.Equals(true))
        {
            if (_page.Equals(UDSUtil.PAGE_PROFILEPICTUREWEBCAM_MAIN))
            {
                string _remark = _c.Request["remark"];
                string _cookie = (Util.GetCookie(FinServiceLogin.USERTYPE_STUDENT) != null ? Util.GetCookie(FinServiceLogin.USERTYPE_STUDENT).Value : String.Empty);

                Util.DBUtil.SetEventLog(
                    (HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/Infinity/" + UDSUtil.SUBJECT_SECTION_PROFILEPICTUREWEBCAM),
                    String.Empty,
                    _cookie,
                    ("ProfilePictureWebcam => " + _remark),
                    _personId
                );
            }
            else
            {
                _saveResult = UDSDB.ActionSave(_c, _infoLoginResult);
                _saveError = int.Parse(_saveResult["SaveError"].ToString());
            }
        }

        _saveResult.Clear();
        _saveResult.Add("CookieError", _cookieError.ToString());
        _saveResult.Add("UserError", _userError.ToString());
        _saveResult.Add("SaveError", _saveError.ToString());

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