/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๓/๐๒/๒๕๕๘>
Modify date : <๐๓/๐๓/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการจัดการข้อมูลหลัก
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class ePFStaffMasterDataUtil
{    
    public class TitlePrefixUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Initials ( TH )",
            "Full Name ( EN )",
            "Initials ( EN )", 
            "Gender",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListTitlePrefix(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.TitlePrefixUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }        
    }

    public class GenderUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Initials ( TH )",
            "Full Name ( EN )",
            "Initials ( EN )", 
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListGender(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.GenderUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class NationalityRaceUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "ISO ALPHA-2", 
            "ISO ALPHA-3",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListNationality(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.NationalityRaceUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class ReligionUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListReligion(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.ReligionUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class BloodGroupUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListBloodGroup(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.BloodGroupUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class MaritalStatusUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListMaritalStatus(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.MaritalStatusUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class FamilyRelationshipsUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Gender",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListRelationship(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.FamilyRelationshipsUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class AgencyUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListAgency(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.AgencyUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class EducationalLevelUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListEducationalLevel(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.EducationalLevelUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class EducationalBackgroundUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Educational Level ( TH )",
            "Full Name ( EN )",             
            "Educational Level ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListEducationalBackground(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.EducationalBackgroundUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class EducationalMajorUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListEducationalMajor(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.EducationalMajorUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class AdmissionTypeUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListEntranceType(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.AdmissionTypeUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class StudentStatusUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListStudentStatus(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.StudentStatusUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class CountryUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "ISO ALPHA-2", 
            "ISO ALPHA-3",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListCountry(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.CountryUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class ProvinceUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Country",
            "Full Name ( TH )",
            "Full Name ( EN )",             
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListProvince(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.ProvinceUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class DistrictUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Country",
            "Province ( TH )",             
            "Full Name ( TH )",
            "Province ( EN )",
            "Full Name ( EN )",             
            "ZIP / Postal Code",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListDistrict(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.DistrictUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class SubdistrictUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Country",
            "Province ( TH )",             
            "District / Area ( TH )",
            "Full Name ( TH )",
            "Province ( EN )",
            "District / Area ( EN )",             
            "Full Name ( EN )",             
            "ZIP / Postal Code",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListSubdistrict(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.SubdistrictUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class InstituteUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Country",
            "Province ( TH )",             
            "Full Name ( TH )",
            "Province ( EN )",
            "Full Name ( EN )",             
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListInstitute(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.InstituteUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }

        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }
      
            _dataRecorded.Add("Id", (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"].ToString() : String.Empty));
            _dataRecorded.Add("Country", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryId"].ToString()) ? _dr["plcCountryId"].ToString() : String.Empty));
            _dataRecorded.Add("Province", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceId"].ToString()) ? _dr["plcProvinceId"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["instituteNameTH"].ToString()) ? _dr["instituteNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["instituteNameEN"].ToString()) ? _dr["instituteNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("CancelledStatus", (_dr != null && !String.IsNullOrEmpty(_dr["cancelledStatus"].ToString()) ? _dr["cancelledStatus"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }
    
    public class DiseasesUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListDiseases(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.DiseasesUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
    
    public class HealthImpairmentsUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "ID",
            "Full Name ( TH )",
            "Full Name ( EN )",
            "Cancelled Status",
            "Create Date",
            "Modify Date"
        };

        public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

            _ds = Util.DBUtil.GetListImpairments(_paramSearch);

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffMasterDataUI.HealthImpairmentsUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN, (int)(_paramSearch["RowPerPage"]));

            _ds.Dispose();

            _searchResult.Add("RecordCount", _recordCount);
            _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
            _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
            _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
            _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
            _searchResult.Add("List", _list);
            _searchResult.Add("NavPage", _navPage);

            return _searchResult;
        }
    }
}