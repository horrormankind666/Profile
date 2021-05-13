// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๗/๐๗/๒๕๕๘>
// Modify date  : <๐๘/๐๗/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการจัดการข้อมูลหลัก
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;

public class HCSStaffMasterDataUtil
{
    public class HospitalOfHealthCareServiceUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Name ( TH )",
            "Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            DataSet _ds = new DataSet();
            DataRow[] _dr = null;
            int _recordCount = 0;
            int _recordCountPrimary = 0;
            int _recordCountSecondary = 0;
            int _recordCountAllPrimary = 0;
            int _recordCountAllSecondary = 0; 
            StringBuilder _list = new StringBuilder();
            StringBuilder _navPage = new StringBuilder();

            _ds = HCSStaffDB.GetListHCSHospital(_paramSearch);

            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = HCSStaffMasterDataUI.HospitalOfHealthCareServiceUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }

        //ฟังก์ชั่นสำหรับกำหนดค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _dataRecorded  เป็น Dictionary<string, object> รับค่าชุดข้อมูล
        //2. _ds            เป็น DataSet รับค่าชุดข้อมูล
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }
      
            _dataRecorded.Add("Id",                 (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"].ToString() : String.Empty));
            _dataRecorded.Add("HospitalNameTH",     (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameTH"].ToString()) ? _dr["hospitalNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("HospitalNameEN",     (_dr != null && !String.IsNullOrEmpty(_dr["hospitalNameEN"].ToString()) ? _dr["hospitalNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("CancelledStatus",    (_dr != null && !String.IsNullOrEmpty(_dr["cancelledStatus"].ToString()) ? _dr["cancelledStatus"].ToString() : String.Empty));
           
            return _dataRecorded;
        }
    }    
    
    public class RegistrationFormUtil
    {
        public static string[] _sortOrderBy = new string[]
        {            
            "ID",
            "Name ( TH )",
            "Name ( EN )",
            "For Public Servant",
            "Order Form",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            DataSet _ds = new DataSet();
            DataRow[] _dr = null;
            int _recordCount = 0;
            int _recordCountPrimary = 0;
            int _recordCountSecondary = 0;
            int _recordCountAllPrimary = 0;
            int _recordCountAllSecondary = 0; 
            StringBuilder _list = new StringBuilder();
            StringBuilder _navPage = new StringBuilder();

            _ds = HCSStaffDB.GetListHCSRegistrationForm(_paramSearch);
            
            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = HCSStaffMasterDataUI.RegistrationFormUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }

        //ฟังก์ชั่นสำหรับกำหนดค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _dataRecorded  เป็น Dictionary<string, object> รับค่าชุดข้อมูล
        //2. _ds            เป็น DataSet รับค่าชุดข้อมูล
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }
      
            _dataRecorded.Add("Id",                 (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"].ToString() : String.Empty));
            _dataRecorded.Add("FormNameTH",         (_dr != null && !String.IsNullOrEmpty(_dr["formNameTH"].ToString()) ? _dr["formNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("FormNameEN",         (_dr != null && !String.IsNullOrEmpty(_dr["formNameEN"].ToString()) ? _dr["formNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ForPublicServant",   (_dr != null && !String.IsNullOrEmpty(_dr["forPublicServant"].ToString()) ? _dr["forPublicServant"].ToString() : String.Empty));
            _dataRecorded.Add("OrderForm",          (_dr != null && !String.IsNullOrEmpty(_dr["orderForm"].ToString()) ? _dr["orderForm"].ToString() : String.Empty));
            _dataRecorded.Add("CancelledStatus",    (_dr != null && !String.IsNullOrEmpty(_dr["cancelledStatus"].ToString()) ? _dr["cancelledStatus"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class AgencyRegisteredUtil
    {
        public static string[] _sortOrderBy = new string[]
        {            
            "Year Attended",
            "Program",
            "Hospital",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        //ฟังก์ชั่นสำหรับแสดงข้อมูลจากการค้นหาข้อมูลตามเงื่อนไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            DataSet _ds = new DataSet();
            DataRow[] _dr = null;
            int _recordCount = 0;
            int _recordCountPrimary = 0;
            int _recordCountSecondary = 0;
            int _recordCountAllPrimary = 0;
            int _recordCountAllSecondary = 0;
            StringBuilder _list = new StringBuilder();
            StringBuilder _navPage = new StringBuilder();

            _ds = HCSStaffDB.GetListHCSAgencyRegistered(_paramSearch);
            
            _dr                 = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount        = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list               = HCSStaffMasterDataUI.AgencyRegisteredUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage            = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount",                _recordCount);
            _searchResult.Add("RecordCountPrimary",         _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary",       _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary",      _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary",    _recordCountAllSecondary);
            _searchResult.Add("List",                       _list);
            _searchResult.Add("NavPage",                    _navPage);

            return _searchResult;
        }

        //ฟังก์ชั่นสำหรับกำหนดค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น Dictionary<string, object>
        //โดยมีพารามิเตอร์ดังนี้
        //1. _dataRecorded  เป็น Dictionary<string, object> รับค่าชุดข้อมูล
        //2. _ds            เป็น DataSet รับค่าชุดข้อมูล
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }

            _dataRecorded.Add("Id",                 (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"].ToString() : String.Empty));
            _dataRecorded.Add("YearEntry",          (_dr != null && !String.IsNullOrEmpty(_dr["yearEntry"].ToString()) ? _dr["yearEntry"].ToString() : String.Empty));
            _dataRecorded.Add("DegreeLevel",        (_dr != null && !String.IsNullOrEmpty(_dr["degreeLevel"].ToString()) ? _dr["degreeLevel"].ToString() : String.Empty));
            _dataRecorded.Add("Faculty",            (_dr != null && !String.IsNullOrEmpty(_dr["facultyId"].ToString()) ? _dr["facultyId"].ToString() : String.Empty));
            _dataRecorded.Add("Program",            (_dr != null && !String.IsNullOrEmpty(_dr["acaProgramId"].ToString()) ? _dr["acaProgramId"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramAddress",     (_dr != null && !String.IsNullOrEmpty(_dr["programAddress"].ToString()) ? _dr["programAddress"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramTelephone",   (_dr != null && !String.IsNullOrEmpty(_dr["programTelephone"].ToString()) ? _dr["programTelephone"].ToString() : String.Empty));
            _dataRecorded.Add("Hospital",           (_dr != null && !String.IsNullOrEmpty(_dr["hcsHospitalId"].ToString()) ? _dr["hcsHospitalId"].ToString() : String.Empty));
            _dataRecorded.Add("RegistrationForm",   (_dr != null && !String.IsNullOrEmpty(_dr["hcsRegistrationFormId"].ToString()) ? _dr["hcsRegistrationFormId"].ToString() : String.Empty));
            _dataRecorded.Add("CancelledStatus",    (_dr != null && !String.IsNullOrEmpty(_dr["cancelledStatus"].ToString()) ? _dr["cancelledStatus"].ToString() : String.Empty));                   
			
            return _dataRecorded;
        }
    }    
}