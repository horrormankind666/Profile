/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๓/๐๗/๒๕๕๙>
Modify date : <๐๓/๐๓/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการบริการข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class ePFStaffOurServicesUtil
{
    public class ExportStudentRecordsInformationUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*
            "Name",
            "Faculty",
            "Program",
            "Year Attended"
            */
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

            _ds = Util.DBUtil.GetListStudentRecords(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                "",
                _paramSearch
            );

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffOurServicesUI.ExportStudentRecordsInformationUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN, (int)(_paramSearch["RowPerPage"]));

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

    public class UpdateStudentDistinctionProgramUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*
            "Name",
            "Faculty",
            "Program",
            "Year Attended"
            */
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

            _ds = Util.DBUtil.GetListStudentRecords(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                "",
                _paramSearch
            );

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffOurServicesUI.UpdateStudentDistinctionProgramUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTDISTINCTIONPROGRAM_MAIN, (int)(_paramSearch["RowPerPage"]));

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

    public class SummaryNumberOfStudentUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*
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

                _ds = Util.DBUtil.GetListStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTVIEWCHART,
                    _paramSearch
                );

                _recordCount = _ds.Tables[0].Rows.Count;
                _recordCountPrimary = _ds.Tables[0].Rows.Count;
                _list = ePFStaffOurServicesUI.SummaryNumberOfStudentUI.ViewChartUI.SectionMainUI.GetList(_loginResult, _ds);

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
                Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
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

                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN))
                    _reportName = ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE;

                if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN))
                    _reportName = ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE;

                _ds = Util.DBUtil.GetListStudentRecords(
                    _loginResult["Username"].ToString(),
                    _loginResult["Userlevel"].ToString(),
                    _loginResult["SystemGroup"].ToString(),
                    _reportName,
                    _paramSearch
                );

                if (_reportName.Equals(ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE))
                {
                    _recordCount = _ds.Tables[0].Rows.Count;
                    _recordCountPrimary = _ds.Tables[0].Rows.Count;

                    if (_recordCountPrimary > 0)
                    {                                                
                        _list.AppendLine(ePFStaffOurServicesUI.SummaryNumberOfStudentUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _ds, null).ToString());
                        _navPage.AppendLine("<div class='navpage'><div class='navpage-layout'></div></div>");
                    } 
                }

                if (_reportName.Equals(ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE))
                {
                    _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
                    _recordCount = _ds.Tables[0].Rows.Count;
                    _recordCountPrimary = _ds.Tables[0].Rows.Count;

                    _list.AppendLine(ePFStaffOurServicesUI.SummaryNumberOfStudentUI.ViewTableUI.SectionMainUI.GetList(_page, _loginResult, _ds, _dr).ToString());
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

            public static DataTable GetList(DataSet _ds, DataTable _dt, Dictionary<string, object> _tb1, Dictionary<string, object> _tb2, Dictionary<string, object> _tb3, Dictionary<string, object> _tb4)
            {
                DataRow _dr;
                string _totalMale = String.Empty;
                string _totalFemale = String.Empty;
                string _summary = String.Empty;
                                        
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    if (_ds.Tables[1].Rows.Count.Equals(1))
                    {
                        if (_ds.Tables[1].Rows[0]["perGenderId"].Equals("01"))
                        {
                            _totalMale = double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString()).ToString("#,##0");
                            _totalFemale = "0";
                            _summary = (double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString()) + 0).ToString("#,##0");
                        }

                        if (_ds.Tables[1].Rows[0]["perGenderId"].Equals("02"))
                        {
                            _totalMale = "0";
                            _totalFemale = double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString()).ToString("#,##0");
                            _summary = (0 + double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString())).ToString("#,##0");
                        }
                    }
                    else
                    {
                        _totalMale = double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString()).ToString("#,##0");
                        _totalFemale = double.Parse(_ds.Tables[1].Rows[1]["countPeople"].ToString()).ToString("#,##0");
                        _summary = (double.Parse(_ds.Tables[1].Rows[0]["countPeople"].ToString()) + double.Parse(_ds.Tables[1].Rows[1]["countPeople"].ToString())).ToString("#,##0");
                    }
                }

                if (!_tb1["Index"].Equals(-1))
                {
                    if (_ds.Tables[(int)_tb1["Index"]].Rows.Count > 0)
                    {
                        _dr = _dt.NewRow();

                        _dr["OrderLevel"] = "ZeroLevel";
                        _dr["DataLevel"] = "";
                        _dr["DataId"] = "";
                        _dr["ItemTH"] = _ds.Tables[(int)_tb1["Index"]].Rows[0]["titleTH"].ToString();
                        _dr["ItemEN"] = _ds.Tables[(int)_tb1["Index"]].Rows[0]["titleEN"].ToString();
                        _dr["CountMalePeople"] = _totalMale;
                        _dr["CountFemalePeople"] = _totalFemale;
                        _dr["SummaryPeople"] = _summary;
                        _dr["DrillDownId"] = "";

                        _dt.Rows.Add(_dr);
                
                        foreach (DataRow _dr1 in _ds.Tables[(int)_tb1["Index"]].Rows)
                        {
                            _dr = _dt.NewRow();

                            _dr["OrderLevel"] = (!_tb2["Index"].Equals(-1) ? "FirstLevel" : "");
                            _dr["DataLevel"] = _tb1["DataLevel"];
                            _dr["DataId"] = (!String.IsNullOrEmpty(_tb1["DataId"].ToString()) ? _dr1[_tb1["DataId"].ToString()].ToString() : "");
                            _dr["ItemTH"] = (!String.IsNullOrEmpty(_tb1["SeriesDataName1"].ToString()) ? _dr1[_tb1["SeriesDataName1"].ToString()].ToString() : "");
                            _dr["ItemEN"] = (!String.IsNullOrEmpty(_tb1["SeriesDataName2"].ToString()) && !_dr1[_tb1["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _dr1[_tb1["SeriesDataName2"].ToString()].ToString() : "");
                            _dr["CountMalePeople"] = double.Parse(_dr1[_tb1["Value1"].ToString()].ToString()).ToString("#,##0");
                            _dr["CountFemalePeople"] = double.Parse(_dr1[_tb1["Value2"].ToString()].ToString()).ToString("#,##0");
                            _dr["SummaryPeople"] = (double.Parse(_dr1[_tb1["Value1"].ToString()].ToString()) + double.Parse(_dr1[_tb1["Value2"].ToString()].ToString())).ToString("#,##0");
                            _dr["DrillDownId"] = (!String.IsNullOrEmpty(_tb1["DrillDownId"].ToString()) ? _dr1[_tb1["DrillDownId"].ToString()].ToString() : "");;

                            _dt.Rows.Add(_dr);
                    
                            if (!_tb2["Index"].Equals(-1))
                            {
                                foreach (DataRow _dr2 in _ds.Tables[(int)_tb2["Index"]].Select(_tb2["Id"].ToString() + " = '" + _dr1[_tb1["DrillDownId"].ToString()].ToString() + "'"))
                                {
                                    _dr = _dt.NewRow();

                                    _dr["OrderLevel"] = (!_tb3["Index"].Equals(-1) ? "SecondLevel" : "LastLevel");
                                    _dr["DataLevel"] = _tb2["DataLevel"];
                                    _dr["DataId"] = (!String.IsNullOrEmpty(_tb2["DataId"].ToString()) ? _dr2[_tb2["DataId"].ToString()].ToString() : "");
                                    _dr["ItemTH"] = (!String.IsNullOrEmpty(_tb2["SeriesDataName1"].ToString()) ? _dr2[_tb2["SeriesDataName1"].ToString()].ToString() : "");
                                    _dr["ItemEN"] = (!String.IsNullOrEmpty(_tb2["SeriesDataName2"].ToString()) && !_dr2[_tb2["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _dr2[_tb2["SeriesDataName2"].ToString()].ToString() : "");
                                    _dr["CountMalePeople"] = double.Parse(_dr2[_tb2["Value1"].ToString()].ToString()).ToString("#,##0");
                                    _dr["CountFemalePeople"] = double.Parse(_dr2[_tb2["Value2"].ToString()].ToString()).ToString("#,##0");
                                    _dr["SummaryPeople"] = (double.Parse(_dr2[_tb2["Value1"].ToString()].ToString()) + double.Parse(_dr2[_tb2["Value2"].ToString()].ToString())).ToString("#,##0");
                                    _dr["DrillDownId"] = (!String.IsNullOrEmpty(_tb2["DrillDownId"].ToString()) ? _dr2[_tb2["DrillDownId"].ToString()].ToString() : "");;

                                    _dt.Rows.Add(_dr);

                                    if (!_tb3["Index"].Equals(-1))
                                    {
                                        foreach (DataRow _dr3 in _ds.Tables[(int)_tb3["Index"]].Select(_tb3["Id"].ToString() + " = '" + _dr2[_tb2["DrillDownId"].ToString()].ToString() + "'"))
                                        {                            
                                            _dr = _dt.NewRow();

                                            _dr["OrderLevel"] = (!_tb4["Index"].Equals(-1) ? "ThirdLevel" : "LastLevel");
                                            _dr["DataLevel"] = _tb3["DataLevel"];
                                            _dr["DataId"] = (!String.IsNullOrEmpty(_tb3["DataId"].ToString()) ? _dr3[_tb3["DataId"].ToString()].ToString() : "");
                                            _dr["ItemTH"] = (!String.IsNullOrEmpty(_tb3["SeriesDataName1"].ToString()) ? _dr3[_tb3["SeriesDataName1"].ToString()].ToString() : "");
                                            _dr["ItemEN"] = (!String.IsNullOrEmpty(_tb3["SeriesDataName2"].ToString()) && !_dr3[_tb3["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _dr3[_tb3["SeriesDataName2"].ToString()].ToString() : "");
                                            _dr["CountMalePeople"] = double.Parse(_dr3[_tb3["Value1"].ToString()].ToString()).ToString("#,##0");
                                            _dr["CountFemalePeople"] = double.Parse(_dr3[_tb3["Value2"].ToString()].ToString()).ToString("#,##0");
                                            _dr["SummaryPeople"] = (double.Parse(_dr3[_tb3["Value1"].ToString()].ToString()) + double.Parse(_dr3[_tb3["Value2"].ToString()].ToString())).ToString("#,##0");
                                            _dr["DrillDownId"] = (!String.IsNullOrEmpty(_tb3["DrillDownId"].ToString()) ? _dr3[_tb3["DrillDownId"].ToString()].ToString() : "");;

                                            _dt.Rows.Add(_dr);

                                            if (!_tb4["Index"].Equals(-1))
                                            {
                                                foreach (DataRow _dr4 in _ds.Tables[(int)_tb4["Index"]].Select(_tb4["Id"].ToString() + " = '" + _dr3[_tb3["DrillDownId"].ToString()].ToString() + "'"))
                                                {
                                                    _dr = _dt.NewRow();

                                                    _dr["OrderLevel"] = "LastLevel";
                                                    _dr["DataLevel"] = _tb4["DataLevel"];
                                                    _dr["DataId"] = (!String.IsNullOrEmpty(_tb4["DataId"].ToString()) ? _dr4[_tb4["DataId"].ToString()].ToString() : "");
                                                    _dr["ItemTH"] = (!String.IsNullOrEmpty(_tb4["SeriesDataName1"].ToString()) ? _dr4[_tb4["SeriesDataName1"].ToString()].ToString() : "");
                                                    _dr["ItemEN"] = (!String.IsNullOrEmpty(_tb4["SeriesDataName2"].ToString()) && !_dr4[_tb4["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _dr4[_tb4["SeriesDataName2"].ToString()].ToString() : "");
                                                    _dr["CountMalePeople"] = double.Parse(_dr4[_tb4["Value1"].ToString()].ToString()).ToString("#,##0");
                                                    _dr["CountFemalePeople"] = double.Parse(_dr4[_tb4["Value2"].ToString()].ToString()).ToString("#,##0");
                                                    _dr["SummaryPeople"] = (double.Parse(_dr4[_tb4["Value1"].ToString()].ToString()) + double.Parse(_dr4[_tb4["Value2"].ToString()].ToString())).ToString("#,##0");
                                                    _dr["DrillDownId"] = (!String.IsNullOrEmpty(_tb4["DrillDownId"].ToString()) ? _dr4[_tb4["DrillDownId"].ToString()].ToString() : ""); ;

                                                    _dt.Rows.Add(_dr);
                                                }
                                            }
                                        }
                                    }
                                }
                            }                    
                        }
                    }
                }        

                return _dt;
            }
        }
    }

    public class TransactionLogStudentRecordsUtil
    {
        public static string[] _sortOrderBy = new string[]
        {
            "Student ID"
            /*
            "Name",
            "Faculty",
            "Program",
            "Year Attended"
            */
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

            _ds = Util.DBUtil.GetListStudentRecords(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                "",
                _paramSearch
            );

            _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffOurServicesUI.TransactionLogStudentRecordsUI.SectionMainUI.GetList(_loginResult, _dr);
            _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN, (int)(_paramSearch["RowPerPage"]));

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

        public static Dictionary<string, object> GetSearch(string _id, string _page)
        {
            Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
            Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
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

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSSTUDENTRECORDS_VIEW))
                _reportName = ePFStaffUtil.SUBJECT_SECTION_STUDENTRECORDS;

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSPERSONAL_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_PERSONAL);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSADDRESS_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_ADDRESS);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSEDUCATION_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_EDUCATION);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSTALENT_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_TALENT);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSHEALTHY_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_HEALTHY);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSWORK_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_WORK);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFINANCIAL_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_FINANCIAL);

            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFAMILY_VIEW))
                _reportName = (ePFStaffUtil.SUBJECT_SECTION_PERSONRECORDS + ePFStaffUtil.SUBJECT_SECTION_FAMILY);
            
            _paramSearch.Add("PersonId", _id);

            _ds = Util.DBUtil.GetListTransactionLog(
                _loginResult["Username"].ToString(),
                _loginResult["Userlevel"].ToString(),
                _loginResult["SystemGroup"].ToString(),
                _reportName,
                _paramSearch
            );

            _dr = _ds.Tables[0].Select();
            _recordCount = _ds.Tables[0].Rows.Count;
            _recordCountPrimary = _ds.Tables[0].Rows.Count;
            _list = ePFStaffOurServicesUI.TransactionLogStudentRecordsUI.SectionViewUI.ViewTableUI.GetList(_loginResult, _dr, _page);

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