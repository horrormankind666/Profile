﻿// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๓/๐๖/๒๕๕๘>
// Modify date  : <๐๔/๐๕/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการจัดการระบบ>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using NUtil;

public class UDSStaffSettingUtil
{
    public class AccesstotheSystemUtil
    {
        //ฟังก์ชั่นสำหรับกำหนดค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _dataRecorded  เป็น Dictionary<string, object> รับค่าชุดข้อมูล
        //2. _ds            เป็น DataSet รับค่าชุดข้อมูล
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("StartDate",          (_dr != null && !String.IsNullOrEmpty(_dr["enStartDate"].ToString()) ? _dr["enStartDate"] : String.Empty));
            _dataRecorded.Add("StartHour",          (_dr != null && !String.IsNullOrEmpty(_dr["startDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["startDate"].ToString()).ToString("HH")).ToString() : String.Empty));
            _dataRecorded.Add("StartMinute",        (_dr != null && !String.IsNullOrEmpty(_dr["startDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["startDate"].ToString()).ToString("mm")).ToString() : String.Empty));
            _dataRecorded.Add("StartSecond",        (_dr != null && !String.IsNullOrEmpty(_dr["startDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["startDate"].ToString()).ToString("ss")).ToString() : String.Empty));
            _dataRecorded.Add("EndDate",            (_dr != null && !String.IsNullOrEmpty(_dr["enEndDate"].ToString()) ? _dr["enEndDate"] : String.Empty));
            _dataRecorded.Add("EndHour",            (_dr != null && !String.IsNullOrEmpty(_dr["endDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["endDate"].ToString()).ToString("HH")).ToString() : String.Empty));
            _dataRecorded.Add("EndMinute",          (_dr != null && !String.IsNullOrEmpty(_dr["endDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["endDate"].ToString()).ToString("mm")).ToString() : String.Empty));
            _dataRecorded.Add("EndSecond",          (_dr != null && !String.IsNullOrEmpty(_dr["endDate"].ToString()) ? int.Parse(DateTime.Parse(_dr["endDate"].ToString()).ToString("ss")).ToString() : String.Empty));
            _dataRecorded.Add("YearEntry",          (_dr != null && !String.IsNullOrEmpty(_dr["yearEntry"].ToString()) ? _dr["yearEntry"] : String.Empty));
            _dataRecorded.Add("EntranceType",       (_dr != null && !String.IsNullOrEmpty(_dr["entranceType"].ToString()) ? _dr["entranceType"] : String.Empty));
            _dataRecorded.Add("FacultyProgram",     (_dr != null && !String.IsNullOrEmpty(_dr["facultyprogram"].ToString()) ? _dr["facultyprogram"] : String.Empty));
            _dataRecorded.Add("CancelledStatus",    (_dr != null && !String.IsNullOrEmpty(_dr["cancelStatus"].ToString()) ? _dr["cancelStatus"] : String.Empty));

            return _dataRecorded;
        }
    }
}