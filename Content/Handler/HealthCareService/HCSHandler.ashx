<%@ WebHandler Language="C#" Class="HCSHandler" %>
// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๑๒/๒๕๕๗>
// Modify date  : <๐๓/๑๑/๒๕๕๘>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นที่ถูกเรียกใช้งานจาก javascript>
// =============================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

    //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามเงื่อนไขการกระทำ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _action    เป็น string รับค่าการกระทำที่ต้องการให้แสดงเนื้อหา
    //2. _c         เป็น HttpContext รับค่าข้อมูลจาก javascript ที่เรียกใช้งาน
    private void GetContentAction(string _action, HttpContext _c)
    {
        switch (_action)
        {
            case "page" : { ShowPage(_c); break; }
        }
    }

    //ฟังก์ชั่นสำหรับแสดงหน้าเพจ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _c เป็น HttpContext รับค่าข้อมูลจาก javascript ที่เรียกใช้งาน
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