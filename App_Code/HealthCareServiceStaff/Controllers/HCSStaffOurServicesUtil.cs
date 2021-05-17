/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๘/๐๔/๒๕๕๙>
Modify date : <๑๔/๐๒/๒๕๖๓>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการบริการข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class HCSStaffOurServicesUtil
{
    public class HealthInformationUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*,
            "Name",
            "Program",
            "Year Attended"
            */
        };

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

            _ds = HCSStaffDB.GetListHCSStudentRecords(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                _paramSearch
            );

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = HCSStaffOurServicesUI.HealthInformationUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN, (int)(_paramSearch["RowPerPage"]));

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

    public class StatisticsDownloadHealthCareServiceFormUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*,
            "Name",
            "Faculty",
            "Program",
            "Year Attended"
            */
        };

        public class ViewChartUtil
        {
            public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();

                _ds = HCSStaffDB.GetListHCSDownloadLog(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART,
                    _paramSearch
                );

                _recordCount = _ds.Tables[2].Rows.Count;
                _recordCountPrimary = int.Parse((_ds.Tables[0].Rows[0])[0].ToString());
                _recordCountSecondary = int.Parse((_ds.Tables[1].Rows[0])[0].ToString());
                _list = HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewChartUI.SectionMainUI.GetList(_loginResult, _ds);
                
                _ds.Dispose();

                _searchResult.Add("RecordCount", _recordCount);
                _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
                _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
                _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);                
                _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
                _searchResult.Add("List", _list);
                _searchResult.Add("NavPage", new StringBuilder());

                return _searchResult;
            }
        }  

        public class ViewTableUtil
        {
            public static Dictionary<string, object> GetSearch(string _page, Dictionary<string, object> _paramSearch)
            {
                Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                DataRow[] _dr = null;
                string _reportName = String.Empty;
                int _recordCount = 0;
                int _recordCountPrimary = 0;
                int _recordCountSecondary = 0;
                int _recordCountAllPrimary = 0;
                int _recordCountAllSecondary = 0;
                StringBuilder _list = new StringBuilder();
                StringBuilder _navPage = new StringBuilder();

                if (_page == HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN)
                    _reportName = HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE;

                if (_page == HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN)
                    _reportName = HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE;

                _ds = HCSStaffDB.GetListHCSDownloadLog(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    _reportName,
                    _paramSearch
                );

                if (_reportName.Equals(HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE))
                {
                    _dr = _ds.Tables[2].Select();
                    _recordCount = _ds.Tables[2].Rows.Count;
                    _recordCountPrimary = int.Parse((_ds.Tables[0].Rows[0])[0].ToString());
                    _recordCountSecondary = int.Parse((_ds.Tables[1].Rows[0])[0].ToString());

                    if (_recordCountPrimary > 0)
                    {
                        _list.AppendLine(HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _dr).ToString());
                        _navPage.AppendLine("<div class='navpage'><div class='navpage-layout'></div></div>");
                    }
                }
                
                if (_reportName.Equals(HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE))
                {
                    _dr = _ds.Tables[2].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                    _recordCount = _ds.Tables[2].Rows.Count;
                    _recordCountPrimary = int.Parse((_ds.Tables[0].Rows[0])[0].ToString());
                    _recordCountSecondary = int.Parse((_ds.Tables[1].Rows[0])[0].ToString());

                    _list.AppendLine(HCSStaffOurServicesUI.StatisticsDownloadHealthCareServiceFormUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _dr).ToString());
                    _navPage.AppendLine(Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), _page, (int)(_paramSearch["RowPerPage"])).ToString());
                }
                
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

    public class TermServiceConsentUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID",
            "Date of Consent"
        };

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
            
            _ds = HCSStaffDB.GetListHCSStudentTermServiceConsent(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                _paramSearch
            );

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = HCSStaffOurServicesUI.TermServiceConsentUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), _paramSearch["Page"].ToString(), (int)(_paramSearch["RowPerPage"]));

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