/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๑๒/๒๕๕๗>
Modify date : <๐๓/๐๓/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการจัดการข้อมูลในฐานข้อมูล>
=============================================
*/

using System;
using System.Data;
using System.Data.SqlClient;
using NUtil;
using NFinServiceLogin;

public class HCSDB
{
    public static string _myTableTransactionLog = "hcsDownloadLog";

    public static int InsertHCSDownloadLog(string _personId, string _registrationForm, string _by)
    {
        string _cmdText = String.Empty;
        int _error = 0;
        int _i = 0;

        try
        {
            Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetDownloadLog",
                new SqlParameter("@personId", _personId),
                new SqlParameter("@registrationForm", _registrationForm),
                new SqlParameter("@by", _by),
                new SqlParameter("@ip", Util.GetIP())
            );
        }
        catch
        {
            _error = 1;
        }

        return _error;
    }

    public static DataSet GetHCSStudentRecords(string _personId)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetPersonStudent",
            new SqlParameter("@userType", FinServiceLogin.USERTYPE_STUDENT),
            new SqlParameter("@personId", _personId)
        );

        return _ds;
    }

    public static DataSet GetHCSRegistrationForm(string _id)
    {
        DataSet _ds = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsGetRegistrationForm",
            new SqlParameter("@id", _id)
        );

        return _ds;
    }
}