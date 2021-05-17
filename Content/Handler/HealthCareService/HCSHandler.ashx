<%@ WebHandler Language="C#" Class="HCSHandler" %>

/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๑๒/๒๕๕๗>
Modify date : <๐๓/๑๑/๒๕๕๘>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นที่ถูกเรียกใช้งานจาก javascript>
=============================================
*/

using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

public class HCSHandler : IHttpHandler, IRequiresSessionState
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
        }
    }

    private void ShowPage(HttpContext _c)
    {
        string _page = _c.Request["page"];
        JavaScriptSerializer _json = new JavaScriptSerializer();
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();

        _pageResult = HCSUtil.GetPage(_page);

        _c.Response.Write(_json.Serialize(_pageResult));
    }
        
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}