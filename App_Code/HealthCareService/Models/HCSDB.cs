// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๑๒/๒๕๕๗>
// Modify date  : <๐๓/๐๓/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการจัดการข้อมูลในฐานข้อมูล>
// =============================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class HCSDB
{
    public static string _myTableTransactionLog = "hcsDownloadLog";

    //ฟังก์ชั่นสำหรับการสร้างคำสั่งเพิ่มข้อมูลในตารางที่ใช้เก็บ Log แล้วส่งค่ากลับเป็น int เพื่อแจ้งสถานะการประมวลผลว่าสำเร็จหรือไม่
    //โดยมีพารามิเตอร์ดังนี้
    //1. _studentId         เป็น string รับค่ารหัสนักศึกษา
    //2. _registrationForm  เป็น string รับค่าชื่อแบบฟอร์ม
    //3. _by                เป็น string รับค่าชื่อของผู้พิมพ์แบบฟอร์ม
    public static int InsertHCSDownloadLog(string _personId, string _registrationForm, string _by)
    {
        string _cmdText = String.Empty;
        int _error = 0;
        int _i = 0;

        try
        {
            Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetDownloadLog",
                new SqlParameter("@personId",           _personId),
                new SqlParameter("@registrationForm",   _registrationForm),
                new SqlParameter("@by",                 _by),
                new SqlParameter("@ip",                 Util.GetIP()));
        }
        catch
        {
            _error = 1;
        }

        return _error;
    }

    //ฟังก์ชั่นสำหรับดึงข้อมูลบุคคลในส่วนของข้อมูลการเป็นนักศึกษาจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _personId  เป็น string รับค่ารหัสบุคคล
    public static DataSet GetHCSStudentRecords(string _personId)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetPersonStudent",
            new SqlParameter("@userType", FinServiceLogin.USERTYPE_STUDENT),
            new SqlParameter("@personId", _personId));

        return _ds;
    }

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลแบบฟอร์มบริการสุขภาพจากฐานข้อมูล แล้วส่งค่ากลับเป็น DataSet
    //โดยมีพารามิเตอร์ดังนี้
    //1. _id    เป็น string รับค่ารหัสที่ต้องการ
    public static DataSet GetHCSRegistrationForm(string _id)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetRegistrationForm",
            new SqlParameter("@id", _id));

        return _ds;
    }
}