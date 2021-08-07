/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๗/๐๗/๒๕๕๘>
Modify date : <๐๗/๐๘/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการบริการข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using NUtil;

public class UDSStaffOurServicesUI
{   
    public class DocumentStatusStudentUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENT_SEARCH.ToLower();
        
        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
            }

            return _html;
        }    

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN, _infoData);                
                StringBuilder _html = new StringBuilder();
                int _i = 0;

                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='tabbar sticky viewsdisplay' id='{0}-viewsdisplay'>", _idSectionMain);
                _html.AppendFormat("    <div class='tabbar-layout' id='{0}-viewsdisplay-layout'>", _idSectionMain);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-viewsdisplay-content'>", _idSectionMain);
                _html.AppendLine("              <ul>");

                for (_i = 0; _i < UDSStaffUtil._viewsDisplay.GetLength(0); _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (UDSStaffUtil._viewsDisplay[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        (_idSectionMain + UDSStaffUtil._viewsDisplay[_i, 3]).ToLower(),
                        UDSStaffUtil._viewsDisplay[_i, 0],
                        UDSStaffUtil._viewsDisplay[_i, 1]);
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendFormat("<div id='{0}'>", _idSectionMain);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionMain);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionMain);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + UDSStaffUtil._viewsDisplay[0, 3]).ToLower(), UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTVIEWCHART_MAIN, ViewChartUI.SectionMainUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + UDSStaffUtil._viewsDisplay[1, 3]).ToLower(), UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTVIEWTABLE_MAIN, String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");
                
                return _html;
            }
        }

        public class SectionSearchUI
        {
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[10];        
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-documentupload"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>เอกสารอัพโหลด</span><span class='en-label'> : Document Upload</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-documentupload-combobox'>" + UDSStaffUI.GetComboboxDocumentUpload(_idSectionSearch + "-documentupload") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DocumentUpload", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-approvalstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะเอกสาร</span><span class='en-label'> : Document Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-approvalstatus-combobox'>" + UDSStaffUI.GetComboboxApprovalStatus(_idSectionSearch + "-approvalstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DocumentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.DocumentStatusStudentUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DocumentUpload"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DocumentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
        
                return _html;
            }
        }

        public class ViewChartUI
        {
            private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTVIEWCHART_MAIN.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN":
                        _html = SectionMainUI.GetMain();
                        break;
                }

                return _html;
            }

            public class SectionMainUI
            {
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                    StringBuilder _html = new StringBuilder();
                    int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                    bool _show = false;
                    
                    if (_cookieError.Equals(0))
                    {
                        HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                        if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN))
                        {
                            _show = true;
                            _searchResult = UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewChartUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN, null, true));
                        }
                    }

                    _html.AppendFormat("<div class='chart' id='{0}-chart'>", _idSectionMain);
                    _html.AppendLine("      <div class='chart-layout'>");
                    _html.AppendLine("          <div class='chart-content'>");
                    _html.AppendLine("              <div class='chart-freeze sticky'>");
                    _html.AppendLine("                  <div class='chart-title'>");
                    _html.AppendFormat("                    <div class='contentbody-left'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></div>", UDSStaffUtil._submenu[7, 0], UDSStaffUtil._submenu[7, 1]);
                    _html.AppendLine("                      <div class='contentbody-right chart-recordcount en-label'>");
                    _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("                  <div class='clear'></div>");
                    _html.AppendLine("              </div>");
                    _html.AppendFormat("            <div class='chart-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }

                public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataSet _ds)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _paramChart = new Dictionary<string, object>();
                    string _backgroundColor1 = "#FFFFFF";
                    string _backgroundColor2 = "#F1F1F1";
                    int _i = 0;
 
                    if (_ds.Tables[1].Rows.Count > 0)
                    {
                        _paramChart.Add("RenderTo", null);
                        _paramChart.Add("BackgroundColor", null);
                        _paramChart.Add("Title", null);
                        _paramChart.Add("LegendTitle", ("สถานะเอกสาร : Document Status ( " + _ds.Tables[1].Rows.Count.ToString("#,##0") + " )"));
                        _paramChart.Add("Level1YAxisTitle", "");
                        _paramChart.Add("Level2YAxisTitle", "");
                        _paramChart.Add("Level3YAxisTitle", "");
                    
                        _html.AppendLine("<div class='chart-grid'>");

                        _paramChart["RenderTo"] = ("chart-" + (UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENT + "-" + UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTURE).ToLower());
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (UDSStaffUtil._documentUpload[1, 0] + "<br />" + UDSStaffUtil._documentUpload[1, 1]);
                        GetChart("pie", _paramChart, _ds, 1, 2, 3);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                    
                        _paramChart["RenderTo"] = ("chart-" + (UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENT + "-" + UDSStaffUtil.SUBJECT_SECTION_IDENTITYCARD).ToLower());
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (UDSStaffUtil._documentUpload[2, 0] + "<br />" + UDSStaffUtil._documentUpload[2, 1]);
                        GetChart("pie", _paramChart, _ds, 4, 5, 6);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart-" + (UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENT + "-" + UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE).ToLower());
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (UDSStaffUtil._documentUpload[4, 0] + "<br />" + UDSStaffUtil._documentUpload[4, 1]);
                        GetChart("pie", _paramChart, _ds, 7, 8, 9);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart-" + (UDSStaffUtil.SUBJECT_SECTION_DOCUMENTSTATUSSTUDENT + "-" + UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE).ToLower());
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (UDSStaffUtil._documentUpload[5, 0] + "<br />" + UDSStaffUtil._documentUpload[5, 1]);
                        GetChart("pie", _paramChart, _ds, 10, 11, 12);
                        _html.AppendLine(GetListRow(_i).ToString());

                        _html.AppendLine("</div>");
                    }

                    return _html;
                }

                private static StringBuilder GetListRow(int _row)
                {
                    StringBuilder _html = new StringBuilder();
                    
                    _html.AppendFormat("<div class='chart-row {0}'>", ((_row % 2) == 0 ? " highlight-style1" : " highlight-style2"));
                    _html.AppendFormat("    <div class='chart-col chart-col-width-dynamic' align='center'>{0}</div>", Util.ChartUtil.GetChart());
                    _html.AppendLine("  </div>");

                    return _html;
                }
                
                private static void GetChart(string _type, Dictionary<string, object> _paramChart, DataSet _ds, int _tbChart1, int _tbChart2, int _tbChart3)
                {
                    List<object> _level1SeriesName = new List<object>();
                    List<object> _level1SeriesColor = new List<object>();
                    List<object> _level1SeriesDataName = new List<object>();
                    List<object> _level1SeriesDataColor = new List<object>();
                    List<object> _level1SeriesDataValue = new List<object>();
                    List<object> _level1SeriesDataDrillDown = new List<object>();
                    
                    List<object> _level2SeriesId = new List<object>();
                    List<object> _level2SeriesName = new List<object>();
                    List<object> _level2SeriesDataName = new List<object>();
                    List<object> _level2SeriesDataColor = new List<object>();
                    List<object> _level2SeriesDataValue = new List<object>();
                    List<object> _level2SeriesDataDrillDown = new List<object>();

                    List<object> _level3SeriesId = new List<object>();
                    List<object> _level3SeriesName = new List<object>();
                    List<object> _level3SeriesDataName = new List<object>();
                    List<object> _level3SeriesDataColor = new List<object>();
                    List<object> _level3SeriesDataValue = new List<object>();
                    List<object> _level3SeriesDataDrillDown = new List<object>();

                    List<object> _seriesNameTemp1 = new List<object>();
                    List<object> _seriesNameTemp2 = new List<object>();
                    List<object> _seriesNameTemp3 = new List<object>();
                    List<object> _seriesColorTemp1 = new List<object>();
                    List<object> _seriesColorTemp2 = new List<object>();
                    List<object> _seriesColorTemp3 = new List<object>();
                    List<object> _seriesValueTemp1 = new List<object>();
                    List<object> _seriesValueTemp2 = new List<object>();
                    List<object> _seriesValueTemp3 = new List<object>();
                    List<object> _seriesDrillDownTemp1 = new List<object>();
                    List<object> _seriesDrillDownTemp2 = new List<object>();
                    List<object> _seriesDrillDownTemp3 = new List<object>();

                    string[] _seriesArray1 = new string[10];
                    string[] _seriesArray2 = new string[10];
                    string[] _seriesArray3 = new string[10];
                    string _seriesNameTH = String.Empty;
                    string _seriesNameEN = String.Empty;

                    if (_ds.Tables[_tbChart1].Rows.Count > 0)
                    {
                        _level1SeriesName.Clear();
                        _level1SeriesColor.Clear();
                        _level1SeriesDataName.Clear();
                        _level1SeriesDataColor.Clear();
                        _level1SeriesDataValue.Clear();
                        _level1SeriesDataDrillDown.Clear();

                        _level2SeriesId.Clear();
                        _level2SeriesName.Clear();
                        _level2SeriesDataName.Clear();
                        _level2SeriesDataColor.Clear();
                        _level2SeriesDataValue.Clear();
                        _level2SeriesDataDrillDown.Clear();

                        _level3SeriesId.Clear();
                        _level3SeriesName.Clear();
                        _level3SeriesDataName.Clear();
                        _level3SeriesDataColor.Clear();
                        _level3SeriesDataValue.Clear();
                        _level3SeriesDataDrillDown.Clear();

                        _seriesNameTemp1 = new List<object>();
                        _seriesColorTemp1 = new List<object>();
                        _seriesValueTemp1 = new List<object>();
                        _seriesDrillDownTemp1 = new List<object>();
                        
                        _level1SeriesName.Add(_paramChart["LegendTitle"]);
                        _level1SeriesColor.Add("");

                        foreach (DataRow _dr1 in _ds.Tables[_tbChart1].Rows)
                        {
                            _seriesArray1 = _dr1["series"].ToString().Split(',');
                            _seriesNameTH = ("<span style=\"display:inline-block;width:88px;\">" + _seriesArray1[1] + "</span>");
                            _seriesNameEN = _seriesArray1[2];

                            _seriesNameTemp1.Add(_seriesNameTH + " : " + _seriesNameEN);
                            _seriesColorTemp1.Add(_seriesArray1[3]);
                            _seriesValueTemp1.Add(_dr1["countPeople"]);
                            _seriesDrillDownTemp1.Add(_seriesArray1[4]);

                            _level1SeriesDataName.Add(_seriesNameTemp1);
                            _level1SeriesDataColor.Add(_seriesColorTemp1);
                            _level1SeriesDataValue.Add(_seriesValueTemp1);
                            _level1SeriesDataDrillDown.Add(_seriesDrillDownTemp1);

                            _seriesNameTemp2 = new List<object>();
                            _seriesColorTemp2 = new List<object>();
                            _seriesValueTemp2 = new List<object>();
                            _seriesDrillDownTemp2 = new List<object>(); 

                            _level2SeriesId.Add(_seriesArray1[4]);
                            _level2SeriesName.Add(_seriesArray1[1] + " : " + _seriesArray1[2] + " ( " + double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0") + " )");

                            foreach (DataRow _dr2 in _ds.Tables[_tbChart2].Select("approvalStatus = '" + _dr1["approvalStatus"] + "'"))
                            {
                                _seriesArray2 = _dr2["series"].ToString().Split(',');

                                _seriesNameTemp2.Add("<span style=\"display:inline-block;width:90px;\">ปีที่เข้าศึกษา " + _seriesArray2[1] + "</span> : Year Attended " + _seriesArray2[1]);
                                _seriesColorTemp2.Add("");
                                _seriesValueTemp2.Add(_dr2["countPeople"]);
                                _seriesDrillDownTemp2.Add(_seriesArray2[2]);

                                _seriesNameTemp3 = new List<object>();
                                _seriesColorTemp3 = new List<object>();
                                _seriesValueTemp3 = new List<object>();
                                _seriesDrillDownTemp3 = new List<object>(); 

                                _level3SeriesId.Add(_seriesArray2[2]);
                                _level3SeriesName.Add("ปีที่เข้าศึกษา " + _seriesArray2[1] + " : Year Attended " + _seriesArray2[1] + " ( " + double.Parse(_dr2["countPeople"].ToString()).ToString("#,##0") + " )");

                                foreach (DataRow _dr3 in _ds.Tables[_tbChart3].Select("approvalStatus = '" + _dr2["approvalStatus"] + "' AND yearEntry = '" + _seriesArray2[1] + "'"))
                                {
                                    _seriesArray3 = _dr3["series"].ToString().Split(',');

                                    _seriesNameTemp3.Add(_seriesArray3[2]);
                                    _seriesColorTemp3.Add("");
                                    _seriesValueTemp3.Add(_dr3["countPeople"]);
                                    _seriesDrillDownTemp3.Add("");
                                }

                                _level3SeriesDataName.Add(_seriesNameTemp3);
                                _level3SeriesDataColor.Add(_seriesColorTemp3);
                                _level3SeriesDataValue.Add(_seriesValueTemp3);
                                _level3SeriesDataDrillDown.Add(_seriesDrillDownTemp3);
                            }

                            _level2SeriesDataName.Add(_seriesNameTemp2);
                            _level2SeriesDataColor.Add(_seriesColorTemp2);
                            _level2SeriesDataValue.Add(_seriesValueTemp2);
                            _level2SeriesDataDrillDown.Add(_seriesDrillDownTemp2);
                        }

                        Util.ChartUtil.Type = _type;
                        Util.ChartUtil.RenderTo = _paramChart["RenderTo"].ToString().ToLower();
                        Util.ChartUtil.BackgroundColor = _paramChart["BackgroundColor"].ToString();
                        Util.ChartUtil.Title = _paramChart["Title"].ToString();
                        Util.ChartUtil.LegendTitle = _paramChart["LegendTitle"].ToString();
                        Util.ChartUtil.Level1XAxisTitle = "";
                        Util.ChartUtil.Level1YAxisTitle = _paramChart["Level1YAxisTitle"].ToString();
                        Util.ChartUtil.Level1SeriesName = _level1SeriesName;
                        Util.ChartUtil.Level1SeriesColor = _level1SeriesColor;
                        Util.ChartUtil.Level1SeriesColorByPoint = false;
                        Util.ChartUtil.Level1SeriesDataName = _level1SeriesDataName;
                        Util.ChartUtil.Level1SeriesDataColor = _level1SeriesDataColor;
                        Util.ChartUtil.Level1SeriesDataValue = _level1SeriesDataValue;
                        Util.ChartUtil.Level1SeriesDataDrillDown = _level1SeriesDataDrillDown;
                        Util.ChartUtil.Level2XAxisTitle = "";
                        Util.ChartUtil.Level2YAxisTitle = _paramChart["Level2YAxisTitle"].ToString();
                        Util.ChartUtil.Level2SeriesId = _level2SeriesId;
                        Util.ChartUtil.Level2SeriesName = _level2SeriesName;
                        Util.ChartUtil.Level2SeriesColorByPoint = false;
                        Util.ChartUtil.Level2SeriesDataName = _level2SeriesDataName;
                        Util.ChartUtil.Level2SeriesDataColor = _level2SeriesDataColor;
                        Util.ChartUtil.Level2SeriesDataValue = _level2SeriesDataValue;
                        Util.ChartUtil.Level2SeriesDataDrillDown = _level2SeriesDataDrillDown;
                        Util.ChartUtil.Level3XAxisTitle = "";
                        Util.ChartUtil.Level3YAxisTitle = _paramChart["Level3YAxisTitle"].ToString();
                        Util.ChartUtil.Level3SeriesId = _level3SeriesId;
                        Util.ChartUtil.Level3SeriesName = _level3SeriesName;
                        Util.ChartUtil.Level3SeriesColorByPoint = false;
                        Util.ChartUtil.Level3SeriesDataName = _level3SeriesDataName;
                        Util.ChartUtil.Level3SeriesDataColor = _level3SeriesDataColor;
                        Util.ChartUtil.Level3SeriesDataValue = _level3SeriesDataValue;
                        Util.ChartUtil.Level3SeriesDataDrillDown = _level3SeriesDataDrillDown;
                        Util.ChartUtil.Level4XAxisTitle = "";
                        Util.ChartUtil.Level4YAxisTitle = "";
                        Util.ChartUtil.Level4SeriesId = new List<object>();
                        Util.ChartUtil.Level4SeriesName = new List<object>();
                        Util.ChartUtil.Level4SeriesColorByPoint = false;
                        Util.ChartUtil.Level4SeriesDataName = new List<object>();
                        Util.ChartUtil.Level4SeriesDataColor = new List<object>();
                        Util.ChartUtil.Level4SeriesDataValue = new List<object>();
                        Util.ChartUtil.Level4SeriesDataDrillDown = new List<object>();
                    }
                }
            }
        }

        public class ViewTableUI
        {
            private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTVIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Main = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Preview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PREVIEW.ToLower();
            private static string _idSectionLevel1Progress = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN":
                        _html.AppendLine(SectionMainUI.GetMain(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN).ToString());
                        break;
                    case "PREVIEW":
                        _html = SectionPreviewUI.GetMain(_sectionAction, _id);
                        break;
                    case "LEVEL1PROGRESSEXPORT":
                        _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS, _idSectionLevel1Progress);
                        break;
                }

                return _html;
            }            

            public class SectionMainUI
            {
                public static StringBuilder GetMain(string _page)
                {
                    Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                    StringBuilder _html = new StringBuilder();
                    string _idMain = String.Empty;
                    string _idPreview = String.Empty;
                    int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);                    
                    int _i = 0;
                    bool _show = false;
                    bool _sublevel = true;

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _idMain = _idSectionLevel1Main;
                        _idPreview = _idSectionLevel1Preview;
                        _sublevel = false;
                    
                        if (_cookieError.Equals(0))
                        {
                            HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                            if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN))
                            {
                                _show = true;
                                _searchResult = UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil.GetSearch(_page, UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN, null, true));
                            }
                        }
                    }

                    _html.AppendFormat("<div class='table{0}' id='{1}-table'>", (_sublevel.Equals(true) ? " table-level hidden" : ""), _idMain);
                    _html.AppendLine("      <div class='table-layout'>");
                    _html.AppendLine("          <div class='table-content'>");
                    _html.AppendLine("              <div class='table-freeze sticky'>");
                    _html.AppendLine("                  <div class='table-title'>");

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN))
                        _html.AppendFormat("                <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", UDSStaffUI.GetComboboxRowPerPage(_idMain + "-rowperpage"));
                    else
                        _html.AppendLine("                  <div class='contentbody-left table-subject th-label'></div>");

                    _html.AppendLine("                      <div class='contentbody-left button'>");
                    _html.AppendLine("                          <div class='button-layout'>");
                    _html.AppendLine("                              <div class='button-content'>");
                    _html.AppendLine("                                  <ul class='button-style2'>");

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _html.AppendFormat("                                <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[1].ToLower(), UDSStaffUtil._selectOption[1]);
                        _html.AppendFormat("                                <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[0].ToLower(), UDSStaffUtil._selectOption[0]);
                    }

                    _html.AppendFormat("                                </ul>");
                    _html.AppendLine("                              </div>");
                    _html.AppendLine("                          </div>");
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");

                    if (_sublevel.Equals(true))
                        _html.AppendLine("                      <span class='th-label link-click link-goback'>Go Back |</span>");

                    _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendLine("                      </div>");                        
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("                  <div class='clear'></div>");
                    _html.AppendLine("                  <div class='table-head'>");
                    _html.AppendLine("                      <div class='table-row'>");

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");        
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Document Status</div></div></div>");
                    }

                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");                    
                    _html.AppendLine("              </div>");
                    _html.AppendFormat("            <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                    _html.AppendFormat("            <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");
                    _html.AppendFormat("<div class='form mainform' id='{0}-form'>", _idMain);
                    _html.AppendLine("      <div class='form-layout mainform-layout'>");
                    _html.AppendLine("          <div class='form-content mainform-content'>");
                    _html.AppendLine("              <div class='titlebar'>");
                    _html.AppendLine("                  <div class='th-label'></div>");
                    _html.AppendLine("                  <div class='en-label'></div>");
                    _html.AppendLine("              </div>");
                    _html.AppendLine("              <div class='menulist'>");
                    _html.AppendLine("                  <div class='menulist-layout'>");
                    _html.AppendLine("                      <div class='menulist-content'>");
                    _html.AppendLine("                          <ul>");

                    for (_i = 0; _i < UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil._menu.GetLength(0); _i++)
                    {
                        _html.AppendFormat("                        <li class='have-link'><a class='link-click link-msg' id='link-{0}' alt='{1}' href='javascript:void(0)'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>", UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil._menu[_i, 2].ToLower(), UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil._menu[_i, 2], UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil._menu[_i, 0], UDSStaffOurServicesUtil.DocumentStatusStudentUtil.ViewTableUtil._menu[_i, 1]);
                    }

                    _html.AppendLine("                          </ul>");
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                      <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>Click to Select Document</a></div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("              </div>");
                    _html.AppendFormat("            <input type='hidden' id='{0}-personid-hidden' value='' />", _idPreview);
                    _html.AppendFormat("            <div id='{0}-form' align='center'></div>", _idPreview);
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }

                public static StringBuilder GetList(string _page, Dictionary<string, object> _infoLogin, DataRow[] _dr)
                {
                    StringBuilder _html = new StringBuilder();
                    string _idMain = String.Empty;
                    string _idPreview = String.Empty;
                    string _highlight = String.Empty;
                    string _callFunc = String.Empty;
                    string _documentUpload = String.Empty;
                    string _approvalStatus = String.Empty;
                    string _iconApprove = String.Empty;

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _idMain = _idSectionLevel1Main;
                        _idPreview = _idSectionLevel1Preview;
                    }

                    if (_dr.GetLength(0) > 0)
                    {
                        _html.AppendLine("<div class='table-grid'>");

                        foreach (DataRow _dr1 in _dr)
                        {                            
                            _approvalStatus = String.Empty;
                            _iconApprove = String.Empty;

                            _documentUpload = UDSStaffUtil._documentUpload[1, 2].ToLower();
                            _approvalStatus = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                            _iconApprove += ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[1, 3] + "</div></div>");
                                                     
                            _documentUpload = UDSStaffUtil._documentUpload[2, 2].ToLower();
                            _approvalStatus = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                            _iconApprove += ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[2, 3] + "</div></div>");

                            _documentUpload = UDSStaffUtil._documentUpload[4, 2].ToLower();
                            _approvalStatus = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                            _iconApprove += ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[4, 3] + "</div></div>");

                            _documentUpload = UDSStaffUtil._documentUpload[5, 2].ToLower();
                            _approvalStatus = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                            _iconApprove += ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[5, 3] + "</div></div>");

                            _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";                
                            _callFunc = "Util.tut.getFrmPreviewDocument({" +
                                        "page:'" + UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD_PREVIEW + "'," +
                                        "idMain:'" + _idMain + "'," +
                                        "idPreview:'" + _idPreview + "'," +
                                        "data:'" + _dr1["id"] + "'" + 
                                        "},function(){})";

                            _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{1}' name='select-child' alt='select-root' value='{1}' /></div></div></div>", _callFunc, _dr1["id"].ToString());
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                            _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                            _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'>{0}</div></div>", _iconApprove);
                            _html.AppendLine("  </div>");
                        }

                        _html.AppendLine("</div>");
                    }

                    return _html;
                }
            }

            public class SectionPreviewUI
            {
                public static StringBuilder GetMain(string _section, string _id)
                {
                    StringBuilder _html = new StringBuilder();

                    if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD))
                    {
                        UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD;
                        UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTURE_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEIDENTITYCARD_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview = UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLEPROFILEPICTUREIDENTITYCARD_PREVIEW;

                        _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, false, false);
                    }

                    if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPT))
                    {
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._subjectSectionTranscript = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPT;
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptPreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPT_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptInstitutePreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPTINSTITUTE_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptFrontsidePreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPTFRONTSIDE_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptBacksidePreview = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPTBACKSIDE_PREVIEW.ToLower();
                        UDSStaffUI.PreviewDocumentUI.TranscriptUI._pageTranscriptPreview = UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLETRANSCRIPT_PREVIEW;

                        _html = UDSStaffUI.PreviewDocumentUI.TranscriptUI.GetMain(_id, false, false);
                    }
                                        
                    return _html;
                }
            }
        }
    }
    
    public class ExportProfilePictureApprovedUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_SEARCH.ToLower();
        private static string _idSectionPreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PREVIEW.ToLower();
        private static string _idSectionProgress = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS.ToLower();
        
        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "PREVIEW":
                    _html = SectionPreviewUI.GetMain(_sectionAction, _id);
                    break;
                case "PROGRESSEXPORT":
                    _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }
        
        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN))
                    {
                        _show = true;
                        _searchResult = UDSStaffOurServicesUtil.ExportProfilePictureApprovedUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN, null, true));
                    }
                }
                
                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", UDSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                          <div class='contentbody-left button'>");
                _html.AppendLine("                              <div class='button-layout'>");
                _html.AppendLine("                                  <div class='button-content'>");
                _html.AppendLine("                                      <ul class='button-style2'>");
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[1].ToLower(), UDSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[0].ToLower(), UDSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                    </ul>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Export Date</div><div class='en-label'>for Smart Card</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form mainform' id='{0}-form'>", _idSectionMain);
                _html.AppendLine("          <div class='form-layout mainform-layout'>");
                _html.AppendLine("              <div class='form-content mainform-content'>");
                _html.AppendLine("                  <div class='titlebar'>");
                _html.AppendLine("                      <div class='th-label'></div>");
                _html.AppendLine("                      <div class='en-label'></div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionPreview);
                _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionPreview);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;
                int _i = 0;
        
                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.tut.getFrmPreviewDocument({" +
                                    "page:'" + UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVEDPROFILEPICTURE_PREVIEW + "'," +
                                    "idMain:'" + _idSectionMain + "'," +
                                    "idPreview:'" + _idSectionPreview + "'," +
                                    "data:'" + _dr1["id"] + "'" +
                                    "},function(){})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{1}' name='select-child' alt='select-root' value='{1}' /></div></div></div>", _callFunc, _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["profilepictureExportDate"].ToString()) ? DateTime.Parse(_dr1["profilepictureExportDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[9];        
                int _i = 0;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-exportstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการส่งออกสำหรับทำบัตรนักศึกษา</span><span class='en-label'> : Export Status for Smart Card</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-exportstatus-combobox'>" + UDSStaffUI.GetComboboxExportStatus(_idSectionSearch + "-exportstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ExportStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.ExportProfilePictureApprovedUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ExportStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }
        
        public class SectionPreviewUI
        {
            public static StringBuilder GetMain(string _section, string _id)
            {
                StringBuilder _html = new StringBuilder();

                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVEDPROFILEPICTURE))
                {
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVEDPROFILEPICTURE;
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVEDPROFILEPICTURE_PREVIEW.ToLower();                                                                                                                          
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview = UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVEDPROFILEPICTURE_PREVIEW;

                    _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, false, false);
                }
                
                return _html;
            }
        }
    }

    public class ExportStudentRecordsInformationForSmartCardUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_SEARCH.ToLower();
        private static string _idSectionPreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PREVIEW.ToLower();
        private static string _idSectionProgress = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS.ToLower();
        
        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "PREVIEW":
                    _html = SectionPreviewUI.GetMain(_sectionAction, _id);
                    break;
                case "PROGRESSEXPORT":
                    _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN))
                    {
                        _show = true;
                        _searchResult = UDSStaffOurServicesUtil.ExportStudentRecordsInformationForSmartCardUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN, null, true));
                    }
                }
                
                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", UDSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                          <div class='contentbody-left button'>");
                _html.AppendLine("                              <div class='button-layout'>");
                _html.AppendLine("                                  <div class='button-content'>");
                _html.AppendLine("                                      <ul class='button-style2'>");
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[1].ToLower(), UDSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[0].ToLower(), UDSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                    </ul>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Export Date</div><div class='en-label'>for Smart Card</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form mainform' id='{0}-form'>", _idSectionMain);
                _html.AppendLine("          <div class='form-layout mainform-layout'>");
                _html.AppendLine("              <div class='form-content mainform-content'>");
                _html.AppendLine("                  <div class='titlebar'>");
                _html.AppendLine("                      <div class='th-label'></div>");
                _html.AppendLine("                      <div class='en-label'></div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionPreview);
                _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionPreview);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }
            
            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;
                int _i = 0;
        
                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.tut.getFrmPreviewDocument({" +
                                    "page:'" + UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARDPROFILEPICTURE_PREVIEW + "'," +
                                    "idMain:'" + _idSectionMain + "'," +
                                    "idPreview:'" + _idSectionPreview + "'," +
                                    "data:'" + _dr1["id"] + "'" +
                                    "},function(){})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{1}' name='select-child' alt='select-root' value='{1}' /></div></div></div>", _callFunc, _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-exportdate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["profilepictureExportDate"].ToString()) ? DateTime.Parse(_dr1["profilepictureExportDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[10];
                int _i = 0;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-approvalstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะรูปภาพประจำตัว</span><span class='en-label'> : Profile Picture Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-approvalstatus-combobox'>" + UDSStaffUI.GetComboboxProfilePictureStatus(_idSectionSearch + "-approvalstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ApprovalStatus", _contentFrmColumnDetail[_i]);
                _i++;


                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-exportstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการส่งออกสำหรับทำบัตรนักศึกษา</span><span class='en-label'> : Export Status for Smart Card</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-exportstatus-combobox'>" + UDSStaffUI.GetComboboxExportStatus(_idSectionSearch + "-exportstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ExportStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.ExportProfilePictureApprovedUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ApprovalStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ExportStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }

        public class SectionPreviewUI
        {
            public static StringBuilder GetMain(string _section, string _id)
            {
                StringBuilder _html = new StringBuilder();
                
                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARDPROFILEPICTURE))
                {
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARDPROFILEPICTURE;
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARDPROFILEPICTURE_PREVIEW.ToLower();                                                                                                                          
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview = UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARDPROFILEPICTURE_PREVIEW;

                    _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, false, false);
                }
                
                return _html;
            }
        }
    }

    public class CopyProfilePictureApprovedtotheStoreUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_SEARCH.ToLower();
        private static string _idSectionPreview = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PREVIEW.ToLower();
        private static string _idSectionProgress = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS.ToLower();

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "PREVIEW":
                    _html = SectionPreviewUI.GetMain(_sectionAction, _id);
                    break;
                case "PROGRESSCOPY":
                    _html = UDSStaffUI.GetFrmProgressCopyData(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN))
                    {
                        _show = true;
                        _searchResult = UDSStaffOurServicesUtil.CopyProfilePictureApprovedtotheStoreUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN, null, true));
                    }
                }

                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", UDSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                          <div class='contentbody-left button'>");
                _html.AppendLine("                              <div class='button-layout'>");
                _html.AppendLine("                                  <div class='button-content'>");
                _html.AppendLine("                                      <ul class='button-style2'>");
                _html.AppendFormat("                                        <li><div class='click-button en-label button-copy{0}' alt='{0}'>Copy {1}</div></li>", UDSStaffUtil._selectOption[1].ToLower(), UDSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                        <li><div class='click-button en-label button-copy{0}' alt='{0}'>Copy {1}</div></li>", UDSStaffUtil._selectOption[0].ToLower(), UDSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                    </ul>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form mainform' id='{0}-form'>", _idSectionMain);
                _html.AppendLine("          <div class='form-layout mainform-layout'>");
                _html.AppendLine("              <div class='form-content mainform-content'>");
                _html.AppendLine("                  <div class='titlebar'>");
                _html.AppendLine("                      <div class='th-label'></div>");
                _html.AppendLine("                      <div class='en-label'></div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionPreview);
                _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionPreview);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;
                int _i = 0;
        
                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.tut.getFrmPreviewDocument({" +
                                    "page:'" + UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTOREPROFILEPICTURE_PREVIEW + "'," +
                                    "idMain:'" + _idSectionMain + "'," +
                                    "idPreview:'" + _idSectionPreview + "'," +
                                    "data:'" + _dr1["id"] + "'" +
                                    "},function(){})";                     

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{1}' name='select-child' alt='select-root' value='{1}' /></div></div></div>", _callFunc, _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[8];        
                int _i = 0;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.CopyProfilePictureApprovedtotheStoreUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());                
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }

        public class SectionPreviewUI
        {
            public static StringBuilder GetMain(string _section, string _id)
            {
                StringBuilder _html = new StringBuilder();

                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTOREPROFILEPICTURE))
                {
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTOREPROFILEPICTURE;
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTOREPROFILEPICTURE_PREVIEW.ToLower();
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview = "";
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview = UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTOREPROFILEPICTURE_PREVIEW;

                    _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, false, false);
                }
                
                return _html;
            }
        }
    }

    public class AuditTranscriptApprovedUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVED_SEARCH.ToLower();

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN, _infoData);
                StringBuilder _html = new StringBuilder();
                int _i = 0;

                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='tabbar sticky viewsdisplay' id='{0}-viewsdisplay'>", _idSectionMain);
                _html.AppendFormat("    <div class='tabbar-layout' id='{0}-viewsdisplay-layout'>", _idSectionMain);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-viewsdisplay-content'>", _idSectionMain);
                _html.AppendLine("              <ul>");

                for (_i = 0; _i < UDSStaffUtil._viewsDisplay.GetLength(0); _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (UDSStaffUtil._viewsDisplay[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        (_idSectionMain + UDSStaffUtil._viewsDisplay[_i, 3]).ToLower(),
                        UDSStaffUtil._viewsDisplay[_i, 0],
                        UDSStaffUtil._viewsDisplay[_i, 1]);
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendFormat("<div id='{0}'>", _idSectionMain);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionMain);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionMain);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + UDSStaffUtil._viewsDisplay[0, 3]).ToLower(), UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDVIEWCHART_MAIN, ViewChartUI.SectionMainUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + UDSStaffUtil._viewsDisplay[1, 3]).ToLower(), UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDVIEWTABLE_MAIN, String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");

                return _html;
            }
        }

        public class SectionSearchUI
        {                        
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[13];        
                int _i = 0;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;                

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-institutecountry"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศของโรงเรียน / สถาบัน</span><span class='en-label'> : Institute of Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-institutecountry-combobox'>" + UDSStaffUI.GetComboboxUDSCountry(_idSectionSearch + "-institutecountry") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-instituteprovince"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จังหวัดของโรงเรียน / สถาบัน</span><span class='en-label'> : Institute of State / Province</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-instituteprovince-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-institute"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>โรงเรียน / สถาบัน</span><span class='en-label'> : Name of Institution</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-institute-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Institute", _contentFrmColumnDetail[_i]);
                _i++;
       
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.AuditTranscriptApprovedUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());                
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());                
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class ViewChartUI
        {
            private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDVIEWCHART_MAIN.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN":
                        _html = SectionMainUI.GetMain();
                        break;
                }

                return _html;
            }

            public class SectionMainUI
            {
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                    StringBuilder _html = new StringBuilder();
                    int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                    bool _show = false;

                    if (_cookieError.Equals(0))
                    {
                        HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                        if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN))
                        {
                            _show = true;
                            _searchResult = UDSStaffOurServicesUtil.AuditTranscriptApprovedUtil.ViewChartUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN, null, true));
                        }
                    }

                    _html.AppendFormat("<div class='chart' id='{0}-chart'>", _idSectionMain);
                    _html.AppendLine("      <div class='chart-layout'>");
                    _html.AppendLine("          <div class='chart-content'>");
                    _html.AppendLine("              <div class='chart-freeze sticky'>");
                    _html.AppendLine("                  <div class='chart-title'>");
                    _html.AppendLine("                      <div class='contentbody-left'><div class='th-label'></div><div class='en-label'></div></div>");
                    _html.AppendLine("                      <div class='contentbody-right chart-recordcount en-label'>");
                    _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("                  <div class='clear'></div>");
                    _html.AppendLine("              </div>");
                    _html.AppendFormat("            <div class='chart-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");
                   
                    return _html;
                }

                public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataSet _ds)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _paramChart = new Dictionary<string, object>();
                    string _backgroundColor1 = "#FFFFFF";
                    string _backgroundColor2 = "#F1F1F1";
                    int _i = 0;
 
                    if (_ds.Tables[0].Rows.Count > 0)
                    {   
                        _paramChart.Add("RenderTo", null);
                        _paramChart.Add("BackgroundColor", null);
                        _paramChart.Add("Title", null);
                        _paramChart.Add("LegendTitle", "จำนวน ( โรงเรียน / นักศึกษา ) : Number of ( school / student )");
                        _paramChart.Add("Level1XAxisTitle", "");
                        _paramChart.Add("Level2XAxisTitle", "ปีที่เข้าศึกษา : Year Attended");
                        
                        _html.AppendLine("<div class='chart-grid'>");

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVED).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);
                        GetChart("bar", _paramChart, _ds, 1, 2, -1);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVED).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);
                        GetChart("bar", _paramChart, _ds, 3, 4, -1);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVED).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);
                        GetChart("bar", _paramChart, _ds, 5, 6, -1);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVED).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);
                        GetChart("bar", _paramChart, _ds, 7, 8, -1);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVED).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);
                        GetChart("bar", _paramChart, _ds, 9, 10, -1);
                        _html.AppendLine(GetListRow(_i).ToString());
                        
                        _html.AppendLine("</div>");
                    }

                    return _html;
                }

                private static StringBuilder GetListRow(int _row)
                {
                    StringBuilder _html = new StringBuilder();
                    
                    _html.AppendFormat("<div class='chart-row {0}'>", ((_row % 2) == 0 ? " highlight-style1" : " highlight-style2"));
                    _html.AppendFormat("    <div class='chart-col chart-col-width-dynamic' align='center'>{0}</div>", Util.ChartUtil.GetChart());
                    _html.AppendLine("  </div>");

                    return _html;
                }

                private static void GetChart(string _type, Dictionary<string, object> _paramChart, DataSet _ds, int _tbChart1, int _tbChart2, int _tbChart3)
                {
                    List<object> _level1SeriesName = new List<object>();
                    List<object> _level1SeriesColor = new List<object>();
                    List<object> _level1SeriesDataName = new List<object>();
                    List<object> _level1SeriesDataColor = new List<object>();
                    List<object> _level1SeriesDataValue = new List<object>();
                    List<object> _level1SeriesDataDrillDown = new List<object>();

                    List<object> _level2SeriesId = new List<object>();
                    List<object> _level2SeriesName = new List<object>();
                    List<object> _level2SeriesDataName = new List<object>();
                    List<object> _level2SeriesDataColor = new List<object>();
                    List<object> _level2SeriesDataValue = new List<object>();
                    List<object> _level2SeriesDataDrillDown = new List<object>();

                    List<object> _seriesNameTemp1 = new List<object>();
                    List<object> _seriesNameTemp2 = new List<object>();
                    List<object> _seriesColorTemp1 = new List<object>();
                    List<object> _seriesColorTemp2 = new List<object>();
                    List<object> _seriesValueTemp1 = new List<object>();
                    List<object> _seriesValueTemp2 = new List<object>();
                    List<object> _seriesDrillDownTemp1 = new List<object>();
                    List<object> _seriesDrillDownTemp2 = new List<object>();
                    
                    string[] _seriesArray1 = new string[10];
                    string[] _seriesArray2 = new string[10];
                    int _i = 0;

                    if (_ds.Tables[_tbChart1].Rows.Count > 0)
                    {
                        _level1SeriesName.Clear();
                        _level1SeriesColor.Clear();
                        _level1SeriesDataName.Clear();
                        _level1SeriesDataColor.Clear();
                        _level1SeriesDataValue.Clear();
                        _level1SeriesDataDrillDown.Clear();

                        _level2SeriesId.Clear();
                        _level2SeriesName.Clear();
                        _level2SeriesDataName.Clear();
                        _level2SeriesDataColor.Clear();
                        _level2SeriesDataValue.Clear();
                        _level2SeriesDataDrillDown.Clear();

                        DataRow _dr1 = _ds.Tables[_tbChart1].Rows[0];

                        _paramChart["Title"] = _dr1["title"].ToString();

                        for(_i = 1; _i <= 2; _i++)
                        {
                            _seriesArray1 = _dr1["titleSeries" + _i].ToString().Split(',');

                            _level1SeriesName.Add(_seriesArray1[2] + " : " + _seriesArray1[3]);
                            _level1SeriesColor.Add(_seriesArray1[4]);

                            _seriesNameTemp1 = new List<object>();
                            _seriesColorTemp1 = new List<object>();
                            _seriesValueTemp1 = new List<object>();
                            _seriesDrillDownTemp1 = new List<object>();

                            _seriesNameTemp1.Add(_seriesArray1[0] + " : " + _seriesArray1[1]);
                            _seriesColorTemp1.Add(_seriesArray1[4]);
                            _seriesValueTemp1.Add(_dr1["valueSeries" + _i]);
                            _seriesDrillDownTemp1.Add(_seriesArray1[5]);

                            _level1SeriesDataName.Add(_seriesNameTemp1);
                            _level1SeriesDataColor.Add(_seriesColorTemp1);
                            _level1SeriesDataValue.Add(_seriesValueTemp1);
                            _level1SeriesDataDrillDown.Add(_seriesDrillDownTemp1);

                            _level2SeriesId.Add(_seriesArray1[5]);
                            _level2SeriesName.Add(_seriesArray1[2] + " : " + _seriesArray1[3] + " ( " + double.Parse(_dr1["valueSeries" + _i].ToString()).ToString("#,##0") + " )");
                        }

                        for (_i = 0; _i < _level2SeriesId.Count; _i++)
                        {
                            _seriesNameTemp2 = new List<object>();
                            _seriesColorTemp2 = new List<object>();
                            _seriesValueTemp2 = new List<object>();
                            _seriesDrillDownTemp2 = new List<object>();

                            foreach (DataRow _dr2 in _ds.Tables[_tbChart2].Rows)
                            {
                                _seriesNameTemp2.Add(_dr2["yearEntry"]);
                                _seriesColorTemp2.Add("");
                                _seriesValueTemp2.Add(_dr2["valueSeries" + (_i + 1)]);
                                _seriesDrillDownTemp2.Add("");
                            }

                            _level2SeriesDataName.Add(_seriesNameTemp2);
                            _level2SeriesDataColor.Add(_seriesColorTemp2);
                            _level2SeriesDataValue.Add(_seriesValueTemp2);
                            _level2SeriesDataDrillDown.Add(_seriesDrillDownTemp2);
                        }
                    }

                    Util.ChartUtil.Type = _type;
                    Util.ChartUtil.RenderTo = _paramChart["RenderTo"].ToString().ToLower();
                    Util.ChartUtil.BackgroundColor = _paramChart["BackgroundColor"].ToString();
                    Util.ChartUtil.Title = _paramChart["Title"].ToString();
                    Util.ChartUtil.LegendTitle = _paramChart["LegendTitle"].ToString();
                    Util.ChartUtil.Level1XAxisTitle = _paramChart["Level1XAxisTitle"].ToString();
                    Util.ChartUtil.Level1YAxisTitle = "";
                    Util.ChartUtil.Level1SeriesName = _level1SeriesName;
                    Util.ChartUtil.Level1SeriesColor = _level1SeriesColor;
                    Util.ChartUtil.Level1SeriesColorByPoint =  false;
                    Util.ChartUtil.Level1SeriesDataName = _level1SeriesDataName;
                    Util.ChartUtil.Level1SeriesDataColor = _level1SeriesDataColor;
                    Util.ChartUtil.Level1SeriesDataValue = _level1SeriesDataValue;
                    Util.ChartUtil.Level1SeriesDataDrillDown = _level1SeriesDataDrillDown;
                    Util.ChartUtil.Level2XAxisTitle = _paramChart["Level2XAxisTitle"].ToString();
                    Util.ChartUtil.Level2YAxisTitle = "";
                    Util.ChartUtil.Level2SeriesId = _level2SeriesId;
                    Util.ChartUtil.Level2SeriesName = _level2SeriesName;
                    Util.ChartUtil.Level2SeriesColorByPoint = true;
                    Util.ChartUtil.Level2SeriesDataName = _level2SeriesDataName;
                    Util.ChartUtil.Level2SeriesDataColor = _level2SeriesDataColor;
                    Util.ChartUtil.Level2SeriesDataValue = _level2SeriesDataValue;
                    Util.ChartUtil.Level2SeriesDataDrillDown = _level2SeriesDataDrillDown;
                    Util.ChartUtil.Level3XAxisTitle = "";
                    Util.ChartUtil.Level3YAxisTitle = "";
                    Util.ChartUtil.Level3SeriesId = new List<object>();
                    Util.ChartUtil.Level3SeriesName = new List<object>();
                    Util.ChartUtil.Level3SeriesColorByPoint = false;
                    Util.ChartUtil.Level3SeriesDataName = new List<object>();
                    Util.ChartUtil.Level3SeriesDataColor = new List<object>();
                    Util.ChartUtil.Level3SeriesDataValue = new List<object>();
                    Util.ChartUtil.Level3SeriesDataDrillDown = new List<object>();
                    Util.ChartUtil.Level4XAxisTitle = "";
                    Util.ChartUtil.Level4YAxisTitle = "";
                    Util.ChartUtil.Level4SeriesId = new List<object>();
                    Util.ChartUtil.Level4SeriesName = new List<object>();
                    Util.ChartUtil.Level4SeriesColorByPoint = false;
                    Util.ChartUtil.Level4SeriesDataName = new List<object>();
                    Util.ChartUtil.Level4SeriesDataColor = new List<object>();
                    Util.ChartUtil.Level4SeriesDataValue = new List<object>();
                    Util.ChartUtil.Level4SeriesDataDrillDown = new List<object>();
                }
            }
        }

        public class ViewTableUI
        {
            private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDVIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Main = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel21Main = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel22Main = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Progress = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS.ToLower();
            private static string _idSectionLevel21Progress = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_PROGRESS.ToLower();
            private static string _idSectionLevel22Progress = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_PROGRESS.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN" : 
                        _html.AppendLine(SectionMainUI.GetMain(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN).ToString());
                        _html.AppendLine(SectionMainUI.GetMain(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN).ToString());
                        _html.AppendLine(SectionMainUI.GetMain(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN).ToString());
                        break;
                    case "LEVEL1PROGRESSEXPORT":
                        _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_PROGRESS, _idSectionLevel1Progress);
                        break;
                    case "LEVEL21PROGRESSEXPORT":
                        _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_PROGRESS, _idSectionLevel21Progress);
                        break;
                    case "LEVEL22PROGRESSEXPORT":
                        _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_PROGRESS, _idSectionLevel22Progress);
                        break;
                }

                return _html;
            }

            public class SectionMainUI
            {
                public static StringBuilder GetMain(string _page)
                {
                    Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                    StringBuilder _html = new StringBuilder();
                    int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                    int _i = 0;
                    string _idSection = String.Empty;
                    bool _show = false;
                    bool _sublevel = true;

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN))
                    {
                        _idSection = _idSectionLevel1Main;
                        _sublevel = false;
                    
                        if (_cookieError.Equals(0))
                        {
                            HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                            if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN))
                            {
                                _show = true;
                                _searchResult = UDSStaffOurServicesUtil.AuditTranscriptApprovedUtil.ViewTableUtil.GetSearch(_page, UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN, null, true));
                            }
                        }                    
                    }

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN))
                        _idSection = _idSectionLevel21Main;

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN))
                        _idSection = _idSectionLevel22Main;

                    _html.AppendFormat("<div class='table{0}' id='{1}-table'>", (_sublevel.Equals(true) ? " table-level hidden" : ""), _idSection);
                    _html.AppendLine("      <div class='table-layout'>");
                    _html.AppendLine("          <div class='table-content'>");
                    _html.AppendLine("              <div class='table-freeze sticky'>");
                    _html.AppendLine("                  <div class='table-title'>");
                    _html.AppendLine("                      <div class='contentbody-left table-subject th-label'></div>");
                    _html.AppendLine("                      <div class='contentbody-left button'>");
                    _html.AppendLine("                          <div class='button-layout'>");
                    _html.AppendLine("                              <div class='button-content'>");
                    _html.AppendLine("                                  <ul class='button-style2'>");
                    _html.AppendFormat("                                    <li class='{0}'><div class='click-button en-label button-export{1}' alt='{1}'>Export</div></li>", (_sublevel.Equals(true) ? "" : "nomargin"), UDSStaffUtil._selectOption[0].ToLower());
                    _html.AppendFormat("                                </ul>");
                    _html.AppendLine("                              </div>");
                    _html.AppendLine("                          </div>");
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");
                    _html.AppendFormat("                        <span class='th-label link-click link-goback{0}'>Go Back |</span>", (_sublevel.Equals(true) ? "" : " hidden"));
                    _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("                  <div class='clear'></div>");
                    _html.AppendLine("                  <div class='table-head'>");
                    _html.AppendLine("                      <div class='table-row'>");

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg'><div class='th-label'>รายการ</div><div class='en-label'>Summary of the Audit Transcript</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>ปีที่เข้าศึกษา</div><div class='en-label'>Year Attended</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>จำนวน ( โรงเรียน )</div><div class='en-label'>Number of ( school )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>จำนวน ( นักศึกษา )</div><div class='en-label'>Number of ( people )</div></div></div>");

                    }

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Country</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>State / Province</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Name of Institution</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Number of ( people )</div></div></div>");
                    }

                    if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");        
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Counrty</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col9'><div class='table-col-msg'><div class='en-label'>State / Province</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col10'><div class='table-col-msg'><div class='en-label'>Name of Institution</div></div></div>");
                    }

                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("              </div>");
                    _html.AppendFormat("            <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                    _html.AppendFormat("            <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }

                public static StringBuilder GetList(string _page, Dictionary<string, object> _infoLogin, DataRow[] _dr)
                {
                    StringBuilder _html = new StringBuilder();
                    string _highlight = String.Empty;
                    string _callFunc = String.Empty;
                    int _i = 1;
                    
                    if (_dr.GetLength(0) > 0)
                    {
                        _html.AppendLine("<div class='table-grid'>");

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL1VIEWTABLE_MAIN))
                        {
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight = (_i % 2) == 0 ? " highlight-style2" : " highlight-style1";                
                            
                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"].ToString().ToLower());
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["title"].ToString());
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE.ToLower(), ((UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE + _dr1["subject"].ToString() + "Main") + "," + _dr1["yearEntry"].ToString()), (double.Parse(_dr1["countInstitute"].ToString()).ToString("#,##0")));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE.ToLower(), ((UDSStaffUtil.SUBJECT_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE + _dr1["subject"].ToString() + "Main") + "," + _dr1["yearEntry"].ToString()), (double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0")));
                                _html.AppendLine("  </div>");

                                _i++;
                            }
                        }

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_MAIN))
                        {
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";

                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"].ToString());
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0"));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteCountryCodes3LetterTranscript"].ToString()) ? _dr1["instituteCountryCodes3LetterTranscript"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteProvinceNameTranscript"].ToString()) ? _dr1["instituteProvinceNameTranscript"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteNameTranscript"].ToString()) ? _dr1["instituteNameTranscript"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0"));
                                _html.AppendLine("  </div>");
                            }                                
                        }

                        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_MAIN))
                        {
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                                _callFunc = "Util.gotoPage({" +
                                            "page:('index.aspx?p=" + UDSStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                            "target:'_blank'" +
                                            "})";

                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["instituteCountryCodes3LetterTranscript"].ToString()) ? _dr1["instituteCountryCodes3LetterTranscript"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["instituteProvinceNameTranscript"].ToString()) ? _dr1["instituteProvinceNameTranscript"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col10' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["institutelNameTranscript"].ToString()) ? _dr1["institutelNameTranscript"].ToString() : String.Empty));
                                _html.AppendLine("  </div>");
                            }
                        }

                        _html.AppendLine("</div>");
                    }

                    return _html;
                }
            }
        }
    }

    public class ExportSaveAuditTranscriptApprovedUI
    {
        private static string _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN.ToLower();
        private static string _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_SEARCH.ToLower();
        private static string _idSectionPreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_PREVIEW.ToLower();
        private static string _idSectionProgress;

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain();
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "PREVIEW":
                    _html = SectionPreviewUI.GetMain(_sectionAction, _id);
                    break;
                case "PROGRESSEXPORT":
                    _idSectionProgress = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS.ToLower();
                    _html = UDSStaffUI.GetFrmProgressExportData(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS, _idSectionProgress);
                    break;
                case "PROGRESSSAVE":
                    _idSectionProgress = UDSStaffUtil.ID_SECTION_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS.ToLower();
                    _html = UDSStaffUI.GetFrmProgressSaveData(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN))
                    {
                        _show = true;
                        _searchResult = UDSStaffOurServicesUtil.ExportSaveAuditTranscriptApprovedUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN, null, true));
                    }
                }

                _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", UDSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                          <div class='contentbody-left button'>");
                _html.AppendLine("                              <div class='button-layout'>");
                _html.AppendLine("                                  <div class='button-content'>");
                _html.AppendLine("                                      <ul class='button-style2'>");
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[1].ToLower(), UDSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                        <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", UDSStaffUtil._selectOption[0].ToLower(), UDSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                        <li><div class='click-button en-label button-save{0}' alt='{0}'>Save Result Audit</div></li>", UDSStaffUtil._selectOption[1].ToLower());
                _html.AppendFormat("                                    </ul>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Sent Date</div><div class='en-label'>Audit</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Result</div><div class='en-label'>Audit</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Received Date</div><div class='en-label'>Result Audit</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form mainform' id='{0}-form'>", _idSectionMain);
                _html.AppendLine("          <div class='form-layout mainform-layout'>");
                _html.AppendLine("              <div class='form-content mainform-content'>");
                _html.AppendLine("                  <div class='titlebar'>");
                _html.AppendLine("                      <div class='th-label'></div>");
                _html.AppendLine("                      <div class='en-label'></div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionPreview);
                _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionPreview);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;
                string _iconResultAudit = String.Empty;
                int _i = 0;            
            
        
                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _iconResultAudit = ("<div class='uploaddocument-auditedstatus uploaddocument-auditedstatus-" + (!String.IsNullOrEmpty(_dr1["transcriptResultAudit"].ToString()) ? _dr1["transcriptResultAudit"].ToString().ToLower() : "blank") + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAUDITEDSTATUS.ToLower() + "  '></div>");
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.tut.getFrmPreviewDocument({" +
                                  "page:'" + UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVEDTRANSCRIPT_PREVIEW + "'," +
                                  "idMain:'" + _idSectionMain + "'," +
                                  "idPreview:'" + _idSectionPreview + "'," +
                                  "data:'" + _dr1["id"] + "'" +
                                  "},function(){})";                     

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{1}' name='select-child' alt='select-root' value='{1}' /></div></div></div>", _callFunc, _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label table-col-sentdateaudit'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["transcriptAuditSentDate"].ToString()) ? DateTime.Parse(_dr1["transcriptAuditSentDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'>{0}</div></div>", _iconResultAudit);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11' onclick={0}><div class='table-col-msg'><div class='th-label table-col-receiveddateresultaudit'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["transcriptResultAuditReceivedDate"].ToString()) ? DateTime.Parse(_dr1["transcriptResultAuditReceivedDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }
       
        public class SectionSearchUI
        {
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[13];        
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : Student ID / Full Name</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionSearch + "-keyword' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Keyword", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วุฒิการศึกษา</span><span class='en-label'> : Degree Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + UDSStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + UDSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หลักสูตร</span><span class='en-label'> : Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่เข้าศึกษา</span><span class='en-label'> : Year Attended</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + UDSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + UDSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + UDSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-institutecountry"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศของโรงเรียน / สถาบัน</span><span class='en-label'> : Institute of Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-institutecountry-combobox'>" + UDSStaffUI.GetComboboxUDSCountry(_idSectionSearch + "-institutecountry") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-instituteprovince"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จังหวัดของโรงเรียน / สถาบัน</span><span class='en-label'> : Institute of State / Province</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-instituteprovince-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-institute"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>โรงเรียน / สถาบัน</span><span class='en-label'> : Name of Institution</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-institute-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Institute", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-date-content'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-sentdatestartaudit' readonly value='' /></div>", _idSectionSearch);
                _contentTemp.AppendLine("   <div class='contentbody-left en-label'>-</div>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-sentdateendaudit' readonly value='' /></div>", _idSectionSearch);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sentdateaudit"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วันที่ส่งระเบียนแสดงผลการเรียนตรวจสอบ</span><span class='en-label'> : Sent Date Transcript Audit</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("SentDateTranscriptAudit", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-auditedstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ผลการตรวจสอบวุฒิการศึกษา</span><span class='en-label'> : Result Transcript Audit</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-auditedstatus-combobox'>" + UDSStaffUI.GetComboboxAuditedStatus(_idSectionSearch + "-auditedstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ResultTranscriptAudit", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffOurServicesUtil.ExportSaveAuditTranscriptApprovedUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), UDSStaffUtil._sortExpression));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-sort"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จัดเรียงข้อมูล</span><span class='en-label'> : Sort</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sort", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());       
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());         
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["SentDateTranscriptAudit"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ResultTranscriptAudit"]).ToString());
                _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }

        public class SectionPreviewUI
        {
            public static StringBuilder GetMain(string _section, string _id)
            {
                StringBuilder _html = new StringBuilder();

                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVEDTRANSCRIPT))
                {
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._subjectSectionTranscript = UDSStaffUtil.SUBJECT_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVEDTRANSCRIPT;
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptPreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTTRANSCRIPTAPPROVEDSAVEAUDITTRANSCRIPT_PREVIEW.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptInstitutePreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTTRANSCRIPTAPPROVEDSAVEAUDITTRANSCRIPTINSTITUTE_PREVIEW.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptFrontsidePreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTTRANSCRIPTAPPROVEDSAVEAUDITTRANSCRIPTFRONTSIDE_PREVIEW.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptBacksidePreview = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTTRANSCRIPTAPPROVEDSAVEAUDITTRANSCRIPTBACKSIDE_PREVIEW.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._pageTranscriptPreview = UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVEDTRANSCRIPT_PREVIEW;

                    _html = UDSStaffUI.PreviewDocumentUI.TranscriptUI.GetMain(_id, false, false);
                }
                                        
                return _html;
            }
        }
    }
}