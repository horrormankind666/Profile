/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๐/๑๑/๒๕๕๘>
Modify date : <๒๐/๑๑/๒๕๕๘>
Description : <หน้าใช้งานเกี่ยวกับการดาวน์โหลดไฟล์>
=============================================
*/

using System;
using System.Web.UI;
using NUtil;

public partial class eProfileStaffDownloadFile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _filePath = Request.QueryString["p"];
        string _fileName = Request.QueryString["f"];
        int _error = Util.ViewFile(_filePath, _fileName);

        if (!_error.Equals(0)) Response.Redirect(_filePath + "/" + _fileName);
    }
}