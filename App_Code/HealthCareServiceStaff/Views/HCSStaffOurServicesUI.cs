/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๘/๐๔/๒๕๕๙>
Modify date : <๑๘/๐๓/๒๕๖๓>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการบริการข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class HCSStaffOurServicesUI
{
    public class HealthInformationUI
    {
        private static string _idSectionMain = HCSStaffUtil.ID_SECTION_OURSERVICESHEALTHINFORMATION_MAIN.ToLower();
        private static string _idSectionSearch = HCSStaffUtil.ID_SECTION_OURSERVICESHEALTHINFORMATION_SEARCH.ToLower();
        private static string _idSectionProgress = HCSStaffUtil.ID_SECTION_OURSERVICESHEALTHINFORMATION_PROGRESS.ToLower();

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain(_infoLogin);
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "PROGRESSEXPORT":
                    _html = HCSStaffUI.GetFrmProgressExportData(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(HCSStaffUtil._myParamSearchCookieName);
                bool _show = false;
                
                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(HCSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN))
                    {
                        _show = true;
                        _searchResult = HCSStaffOurServicesUtil.HealthInformationUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN, null, true));
                    }
                }
                
                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", HCSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                      <div class='contentbody-left button'>");
                _html.AppendLine("                          <div class='button-layout'>");
                _html.AppendLine("                              <div class='button-content'>");
                _html.AppendLine("                                  <ul class='button-style2'>");
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", HCSStaffUtil._selectOption[1].ToLower(), HCSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", HCSStaffUtil._selectOption[0].ToLower(), HCSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                </ul>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                      </div>");                        
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Blood</div><div class='en-label'>Group</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Body Mass Index</div><div class='en-label'>( Weight, Height, BMI )</div></div></div>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>HCS</div><div class='en-label'>Join</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");                
                _html.AppendFormat("            <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;
                string[] _bodyMassArray;
                string[] _bodyMassDetail = new string[3];


                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.gotoPage({" +
                                    "page:('index.aspx?p=" + HCSStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                    "target:'_blank'" +
                                    "})";
                        
                        if (!String.IsNullOrEmpty(_dr1["bodyMassDetail"].ToString()))
                        {
                            _bodyMassArray = _dr1["bodyMassDetail"].ToString().Split(';');
                            _bodyMassDetail = _bodyMassArray[0].Split(':');
                        }

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{0}' name='select-child' alt='select-root' value='{0}' /></div></div></div>", _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["bloodTypeNameEN"].ToString()) ? _dr1["bloodTypeNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["bodyMassDetail"].ToString()) ? (_bodyMassDetail[0] + ", " + _bodyMassDetail[1] + ", " + _bodyMassDetail[2]) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["hcsJoin"].ToString()) ? _dr1["hcsJoin"].ToString() : String.Empty));
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
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + HCSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + HCSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + HCSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-hcsjoin"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะสิทธิขึ้นทะเบียนสิทธิรักษาพยาบาล</span><span class='en-label'> : Health Care Service Join</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-hcsjoin-combobox'>" + HCSStaffUI.GetComboboxHCSJoinStatus(_idSectionSearch + "-hcsjoin") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("HCSJoin", _contentFrmColumnDetail[_i]);
                _i++;
            
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffOurServicesUtil.HealthInformationUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), HCSStaffUtil._sortExpression));
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
                
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN);
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-search"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Search", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search sticky-left' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                        
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["HCSJoin"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Search"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>S<br />H<br />O<br />W<br /><br />L<br />E<br />S<br />S</a></div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }
    }

    public class StatisticsDownloadHealthCareServiceFormUI
    {
        private static string _idSectionMain = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN.ToLower();
        private static string _idSectionSearch = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_SEARCH.ToLower();

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
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN, _infoData);                
                StringBuilder _html = new StringBuilder();
                int _i = 0;

                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='tabbar sticky viewsdisplay' id='{0}-viewsdisplay'>", _idSectionMain);
                _html.AppendFormat("    <div class='tabbar-layout' id='{0}-viewsdisplay-layout'>", _idSectionMain);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-viewsdisplay-content'>", _idSectionMain);
                _html.AppendLine("              <ul>");
                
                for (_i = 0; _i < HCSStaffUtil._viewsDisplay.GetLength(0); _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (HCSStaffUtil._viewsDisplay[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        (_idSectionMain + HCSStaffUtil._viewsDisplay[_i, 3]).ToLower(),
                        HCSStaffUtil._viewsDisplay[_i, 0],
                        HCSStaffUtil._viewsDisplay[_i, 1]);
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendFormat("<div id='{0}'>", _idSectionMain);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionMain);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionMain);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + HCSStaffUtil._viewsDisplay[0, 3]).ToLower(), HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN, ViewChartUI.SectionMainUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + HCSStaffUtil._viewsDisplay[1, 3]).ToLower(), HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN, String.Empty);
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[8];
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + HCSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + HCSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + HCSStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + HCSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;
            
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), HCSStaffUtil._sortExpression));
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
                
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN);
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-search"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Search", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='form search sticky-left' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");
                _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());          
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Search"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>S<br />H<br />O<br />W<br /><br />L<br />E<br />S<br />S</a></div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class ViewChartUI
        {
            private static string _idSectionMain = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWCHART_MAIN.ToLower();

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
                    int _cookieError = Util.ChkCookie(HCSStaffUtil._myParamSearchCookieName);
                    bool _show = false;

                    if (_cookieError.Equals(0))
                    {
                        HttpCookie _objCookie = Util.GetCookie(HCSStaffUtil._myParamSearchCookieName);

                        if (_objCookie["Command"].Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN))
                        {
                            _show = true;
                            _searchResult = HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil.ViewChartUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN, null, true));
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
                    _html.AppendFormat("                        <span class='recordcountsecondary-search th-label'>{0}</span>", (_show.Equals(true) && !_searchResult["RecordCountSecondary"].Equals(0) ? (" ( " + double.Parse(_searchResult["RecordCountSecondary"].ToString()).ToString("#,##0") + " )") : String.Empty));
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
                    Dictionary<string, object> _tbChart1 = new Dictionary<string, object>();
                    Dictionary<string, object> _tbChart2 = new Dictionary<string, object>();
                    Dictionary<string, object> _tbChart3 = new Dictionary<string, object>();
                    string _backgroundColor1 = "#FFFFFF";
                    string _backgroundColor2 = "#F1F1F1";
                    int _i = 0;
                    
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        _paramChart.Add("RenderTo", null);
                        _paramChart.Add("BackgroundColor", null);
                        _paramChart.Add("Title", null);
                        _paramChart.Add("LegendTitle", "แบบฟอร์มบริการสุขภาพ : Health Care Service Form");
                        _paramChart.Add("Level1YAxisTitle", null);
                        _paramChart.Add("Level2YAxisTitle", null);
                        _paramChart.Add("Level3YAxisTitle", "");

                        _tbChart1.Add("Index", null);
                        _tbChart1.Add("SeriesName", null);
                        _tbChart1.Add("Color", null);
                        _tbChart1.Add("Value", null);

                        _tbChart2.Add("Index", null);
                        _tbChart2.Add("SeriesName", null);
                        _tbChart2.Add("Color", null);
                        _tbChart2.Add("Value", null);
                        
                        _tbChart3.Add("Index", null);
                        _tbChart3.Add("SeriesName", null);
                        _tbChart3.Add("Color", null);
                        _tbChart3.Add("Value", null);

                        _html.AppendLine("<div class='chart-grid'>");

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (HCSStaffUtil._submenu[5, 0] + "<br />" + HCSStaffUtil._submenu[5, 1]);
                        _paramChart["Level1YAxisTitle"] = ("จำนวนการดาวน์โหลด ( ครั้ง )<br />Number of Download ( times )");
                        _paramChart["Level2YAxisTitle"] = ("จำนวนการดาวน์โหลด ( ครั้ง )<br />Number of Download ( times )");

                        _tbChart1["Index"] = 2;
                        _tbChart1["SeriesName"] = "logForm";
                        _tbChart1["Color"] = "#FF0000";
                        _tbChart1["Value"] = "countDownload";

                        _tbChart2["Index"] = 3;
                        _tbChart2["SeriesName"] = "yearEntry";
                        _tbChart2["Color"] = "#FF0000";
                        _tbChart2["Value"] = "countDownload";

                        _tbChart3["Index"] = 4;
                        _tbChart3["SeriesName"] = "facultyCode";
                        _tbChart3["Color"] = "#FF0000";
                        _tbChart3["Value"] = "countDownload";

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Title"] = (HCSStaffUtil._submenu[6, 0] + "<br />" + HCSStaffUtil._submenu[6, 1]);
                        _paramChart["Level1YAxisTitle"] = ("จำนวนนักศึกษา ( คน )<br />Number of Stuent ( people )");
                        _paramChart["Level2YAxisTitle"] = ("จำนวนนักศึกษา ( คน )<br />Number of Stuent ( people )");

                        _tbChart1["Index"] = 2;
                        _tbChart1["SeriesName"] = "logForm";
                        _tbChart1["Color"] = "#FF0000";
                        _tbChart1["Value"] = "countPeople";

                        _tbChart2["Index"] = 3;
                        _tbChart2["SeriesName"] = "yearEntry";
                        _tbChart2["Color"] = "#FF0000";
                        _tbChart2["Value"] = "countPeople";

                        _tbChart3["Index"] = 4;
                        _tbChart3["SeriesName"] = "facultyCode";
                        _tbChart3["Color"] = "#FF0000";
                        _tbChart3["Value"] = "countPeople";

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
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

                private static void GetChart(string _type, Dictionary<string, object> _paramChart, DataSet _ds, Dictionary<string, object> _tbChart1, Dictionary<string, object> _tbChart2, Dictionary<string, object> _tbChart3)
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

                    string _seriesName1 = String.Empty;
                    string _seriesName2 = String.Empty;
                    string _seriesName3 = String.Empty;

                    if (_ds.Tables[(int)_tbChart1["Index"]].Rows.Count > 0)
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
                        _level1SeriesColor.Add(_tbChart1["Color"]);

                        foreach (DataRow _dr1 in _ds.Tables[(int)_tbChart1["Index"]].Rows)
                        {
                            _seriesName1 = _dr1[_tbChart1["SeriesName"].ToString()].ToString();

                            _seriesNameTemp1.Add(_seriesName1);
                            _seriesColorTemp1.Add(_tbChart1["Color"]);
                            _seriesValueTemp1.Add(_dr1[_tbChart1["Value"].ToString()]);
                            _seriesDrillDownTemp1.Add(_seriesName1 + "DrillDown");

                            _level1SeriesDataName.Add(_seriesNameTemp1);
                            _level1SeriesDataColor.Add(_seriesColorTemp1);
                            _level1SeriesDataValue.Add(_seriesValueTemp1);
                            _level1SeriesDataDrillDown.Add(_seriesDrillDownTemp1);

                            _seriesNameTemp2 = new List<object>();
                            _seriesColorTemp2 = new List<object>();
                            _seriesValueTemp2 = new List<object>();
                            _seriesDrillDownTemp2 = new List<object>(); 
                            
                            _level2SeriesId.Add(_seriesName1 + "DrillDown");
                            _level2SeriesName.Add("แบบฟอร์ม " + _seriesName1 + ", ปีที่เข้าศึกษา : " + _seriesName1 + ", Year Attended ( " + double.Parse(_dr1[_tbChart1["Value"].ToString()].ToString()).ToString("#,##0") + " )");

                            foreach (DataRow _dr2 in _ds.Tables[(int)_tbChart2["Index"]].Select("logForm = '" + _seriesName1 + "'"))
                            {
                                _seriesName2 = _dr2[_tbChart2["SeriesName"].ToString()].ToString();

                                _seriesNameTemp2.Add(_seriesName2);
                                _seriesColorTemp2.Add(_tbChart2["Color"]);
                                _seriesValueTemp2.Add(_dr2[_tbChart2["Value"].ToString()]);
                                _seriesDrillDownTemp2.Add(_seriesName1 + _seriesName2 + "DrillDown");
                                
                                _seriesNameTemp3 = new List<object>();
                                _seriesColorTemp3 = new List<object>();
                                _seriesValueTemp3 = new List<object>();
                                _seriesDrillDownTemp3 = new List<object>();

                                _level3SeriesId.Add(_seriesName1 + _seriesName2 + "DrillDown");
                                _level3SeriesName.Add("แบบฟอร์ม " + _seriesName1 + ", ปีที่เข้าศึกษา " + _seriesName2 + ", คณะ : " + _seriesName1 + ", Year Attended " + _seriesName2 + ", Faculty ( " + double.Parse(_dr2[_tbChart2["Value"].ToString()].ToString()).ToString("#,##0") + " )");

                                foreach (DataRow _dr3 in _ds.Tables[(int)_tbChart3["Index"]].Select("logForm = '" + _seriesName1 + "' AND yearEntry = '" + _seriesName2 + "'"))
                                {
                                    _seriesName3 = _dr3[_tbChart3["SeriesName"].ToString()].ToString();

                                    _seriesNameTemp3.Add(_seriesName3);
                                    _seriesColorTemp3.Add(_tbChart3["Color"]);
                                    _seriesValueTemp3.Add(_dr3[_tbChart3["Value"].ToString()]);
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
            private static string _idSectionMain = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMVIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Main = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel2Main = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Progress = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS.ToLower();
            private static string _idSectionLevel2Progress = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN": 
                        _html.AppendLine(SectionMainUI.GetMain(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN).ToString());
                        _html.AppendLine(SectionMainUI.GetMain(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN).ToString());
                        break;
                    case "LEVEL1PROGRESSEXPORT":
                        _html = HCSStaffUI.GetFrmProgressExportData(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS, _idSectionLevel1Progress);
                        break;
                    case "LEVEL2PROGRESSEXPORT":
                        _html = HCSStaffUI.GetFrmProgressExportData(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS, _idSectionLevel2Progress);
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
                    int _cookieError = Util.ChkCookie(HCSStaffUtil._myParamSearchCookieName);
                    string _idSection = String.Empty;
                    bool _show = false;
                    bool _sublevel = true;

                    if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN))
                    {
                        _idSection = _idSectionLevel1Main;
                        _sublevel = false;

                        if (_cookieError.Equals(0))
                        {
                            HttpCookie _objCookie = Util.GetCookie(HCSStaffUtil._myParamSearchCookieName);

                            if (_objCookie["Command"].Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN))
                            {
                                _show = true;
                                _searchResult = HCSStaffOurServicesUtil.StatisticsDownloadHealthCareServiceFormUtil.ViewTableUtil.GetSearch(_page, HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN, null, true));
                            }
                        }
                    }

                    if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN))
                        _idSection  = _idSectionLevel2Main;

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
                    _html.AppendFormat("                                    <li class='{0}'><div class='click-button en-label button-export{1}' alt='{1}'>Export</div></li>", (_sublevel.Equals(true) ? "" : "nomargin"), HCSStaffUtil._selectOption[0].ToLower());
                    _html.AppendFormat("                                </ul>");
                    _html.AppendLine("                              </div>");
                    _html.AppendLine("                          </div>");
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");
                    _html.AppendFormat("                        <span class='th-label link-click link-goback{0}'>Go Back |</span>", (_sublevel.Equals(true) ? "" : " hidden"));
                    _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                    _html.AppendFormat("                        <span class='recordcountsecondary-search th-label'>{0}</span>", (_show.Equals(true) && !_searchResult["RecordCountSecondary"].Equals(0) ? (" ( " + double.Parse(_searchResult["RecordCountSecondary"].ToString()).ToString("#,##0") + " )") : String.Empty));
                    _html.AppendLine("                      </div>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("                  <div class='clear'></div>");
                    _html.AppendLine("                  <div class='table-head'>");
                    _html.AppendLine("                      <div class='table-row'>");

                    if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg'><div class='th-label'>แบบฟอร์มบริการสุขภาพ</div><div class='en-label'>Health Care Service Form</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>ปีที่เข้าศึกษา</div><div class='en-label'>Year Attended</div></div></div>");                        
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>จำนวนการดาวน์โหลด ( ครั้ง )</div><div class='en-label'>Number of Download ( times )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>จำนวนนักศึกษาที่ดาวน์โหลด ( คน )</div><div class='en-label'>Number of Student ( people )</div></div></div>");
                    }

                    if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");        
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Latest Date Download</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Download</div><div class='en-label'>Count</div></div></div>");
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

                        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_MAIN))
                        {
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight = (_i % 2) == 0 ? " highlight-style2" : " highlight-style1";

                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"].ToString().ToLower());
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_MEANINGOFHEALTHCARESERVICEFORM.ToLower(), _dr1["logForm"].ToString());
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE.ToLower(), (HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN + "," + _dr1["logForm"] + "," + _dr1["yearEntry"]), double.Parse(_dr1["countDownload"].ToString()).ToString("#,##0"));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE.ToLower(), (HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN + "," + _dr1["logForm"] + "," + _dr1["yearEntry"]), double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0"));
                                _html.AppendLine("  </div>");

                                _i++;
                            }
                        }

                        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_MAIN))
                        {
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight = (_i % 2) == 0 ? " highlight-style2" : " highlight-style1";
                                _callFunc = "Util.gotoPage({" +
                                            "page:('index.aspx?p=" + HCSStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                            "target:'_blank'" +
                                            "})";

                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"].ToString().ToLower());
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["latestDateDownload"].ToString()) ? DateTime.Parse(_dr1["latestDateDownload"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["countDownload"].ToString()) && !_dr1["countDownload"].ToString().Equals("0") ? (double.Parse(_dr1["countDownload"].ToString()).ToString("#,##0")) : String.Empty));
                                _html.AppendLine("  </div>");

                                _i++;
                            }
                        }
   
                        _html.AppendLine("</div>");
                    }

                    return _html;
                }
            }
        }
    }
    public class TermServiceConsentUI
    {
        private static string _pageMain = String.Empty;
        private static string _pageProgress = String.Empty;
        private static string _idSectionMain = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_MAIN.ToLower();
        private static string _idSectionSearch = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_SEARCH.ToLower();        
        private static string _idSectionProgress = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_PROGRESS.ToLower();

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            if (_sectionAction.Equals(HCSStaffUtil.SUBJECT_SECTION_TERMSERVICEHCSCONSENTREGISTRATION))
            { 
                _pageMain = HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN;
                _pageProgress = HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS;
            }
            if (_sectionAction.Equals(HCSStaffUtil.SUBJECT_SECTION_TERMSERVICEHCSCONSENTOOCA))
            { 
                _pageMain = HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN;
                _pageProgress = HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS;
            }

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain(_infoLogin);
                    break;
                case "SEARCH":
                    _html = SectionSearchUI.GetMain();
                    break;
                case "DIALOG":
                    _html = SectionDialogUI.SelectHospitalUI.GetMain();
                    break;
                case "PROGRESSEXPORT":
                    _html = HCSStaffUI.GetFrmProgressExportData(_pageProgress, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(_pageMain, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(HCSStaffUtil._myParamSearchCookieName);
                string _faculty = _infoLogin["Faculty"].ToString();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                bool _show = false;
                
                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(HCSStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(_pageMain))
                    {
                        _show = true;
                        _searchResult = HCSStaffOurServicesUtil.TermServiceConsentUtil.GetSearch(HCSStaffUtil.SetParameterSearch(_pageMain, null, true));
                    }
                }
                
                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", HCSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                      <div class='contentbody-left button'>");
                _html.AppendLine("                          <div class='button-layout'>");
                _html.AppendLine("                              <div class='button-content'>");
                _html.AppendLine("                                  <ul class='button-style2'>");
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", HCSStaffUtil._selectOption[1].ToLower(), HCSStaffUtil._selectOption[1]);
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", HCSStaffUtil._selectOption[0].ToLower(), HCSStaffUtil._selectOption[0]);
                _html.AppendFormat("                                </ul>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Select All</div><div class='input-root'><input class='checkbox select-root' type='checkbox' id='select-root' name='select-root' alt='select-child' /></div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");

                if ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _faculty.Equals("MU-01"))
                    _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Consent</div><div class='en-label'>Status</div></div></div>");

                if (_pageMain.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
                    _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Hospital</div></div></div>");

                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Date of Consent</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", (_show.Equals(true) ? _searchResult["List"] : String.Empty));
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", (_show.Equals(true) ? _searchResult["NavPage"] : String.Empty));                
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");
                
                return _html;
            }

            public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
            {
                StringBuilder _html = new StringBuilder();
                string _faculty = _infoLogin["Faculty"].ToString();
                string _userlevel = _infoLogin["Userlevel"].ToString();
                string _highlight = String.Empty;
                string _callFunc = String.Empty;

                if (_dr.GetLength(0) > 0)
                {
                    _html.AppendLine("<div class='table-grid'>");

                    foreach (DataRow _dr1 in _dr)
                    {
                        _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc = "Util.gotoPage({" +
                                    "page:('index.aspx?p=" + HCSStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                    "target:'_blank'" +
                                    "})";
                        
                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{0}' name='select-child' alt='select-root' value='{0}' /></div></div></div>", _dr1["id"].ToString());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));

                        if ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER)) && _faculty.Equals("MU-01"))
                        {
                            if (!String.IsNullOrEmpty(_dr1["termStatus"].ToString()))
                                _html.AppendFormat("<div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div><label class='toggleswitch'><input type='checkbox' name='consent-status' value='{0}' data-studentid={1} data-consentstatus={2} {3} /><span class='slider'></span></label></div></div></div>", _dr1["id"].ToString(), _dr1["studentId"].ToString(), _dr1["termStatus"].ToString(), (_dr1["termStatus"].ToString().Equals("Y") ? "checked" : String.Empty));
                            else
                                _html.AppendFormat("<div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'></div></div></div>", _callFunc);
                        }

                        if (_pageMain.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
                            _html.AppendFormat("<div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label table-col-hospital'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["termNote"].ToString()) ? _dr1["termNote"].ToString() : String.Empty));

                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-termdate'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["termDate"].ToString()) ? DateTime.Parse(_dr1["termDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));

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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[10];
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>คณะ</span><span class='en-label'> : Faculty</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + HCSStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + HCSStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานภาพการเป็นนักศึกษา</span><span class='en-label'> : Student Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + HCSStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-consentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการแสดงความยินยอม</span><span class='en-label'> : Consent Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-consentstatus-combobox'>" + HCSStaffUI.GetComboboxConsentStatus(_idSectionSearch + "-consentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ConsentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                if (_pageMain.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
                {
                    _paramSearch.Clear();
                    _paramSearch.Add("ID", "RA, SI");
                    _paramSearch.Add("CancelledStatus", "N");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-hospital"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานพยาบาล</span><span class='en-label'> : Hospital</span>");
                    _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-hospital-combobox'>" + HCSStaffUI.GetComboboxHospital((_idSectionSearch + "-hospital"), _paramSearch) + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Hospital", _contentFrmColumnDetail[_i]);
                    _i++;
                }

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-date-content'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-consentdatestart' readonly value='' /></div>", _idSectionSearch);
                _contentTemp.AppendLine("   <div class='contentbody-left en-label'>-</div>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-consentdateend' readonly value='' /></div>", _idSectionSearch);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-consentdate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>วันที่แสดงความยินยอม</span><span class='en-label'> : Date of Consent</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ConsentDate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffOurServicesUtil.TermServiceConsentUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), HCSStaffUtil._sortExpression));
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
                
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", _pageMain);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", _pageMain);
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-search"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Search", _contentFrmColumnDetail[_i]);
                
                _html.AppendFormat("<div class='form search sticky-left' id='{0}-form'>", _idSectionSearch);
                _html.AppendLine("      <div class='form-layout search-layout'>");
                _html.AppendLine("          <div class='form-content search-content'>");                               
                _html.AppendLine(               HCSStaffUI.GetValueSearch(_pageMain).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());                
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ConsentStatus"]).ToString());

                if (_pageMain.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN))
                    _html.AppendLine(           HCSStaffUI.GetFrmColumn(_contentFrmColumn["Hospital"]).ToString());

                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ConsentDate"]).ToString());                
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Search"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>S<br />H<br />O<br />W<br /><br />L<br />E<br />S<br />S</a></div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class SectionDialogUI
        {
            public class SelectHospitalUI
            {
                private static string _idSectionDialog = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENTSELECTHOSPITAL_DIALOG.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    DataSet _ds = new DataSet();
                    int _i = 0;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("ID", "RA, SI");
                    _paramSearch.Add("CancelledStatus", "N");
                
                    _ds = HCSStaffDB.GetListHCSHospital(_paramSearch);

                    foreach (DataRow _dr1 in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-hospital' value='{1}' /></li>", _idSectionDialog, _dr1["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr1["hospitalNameTH"].ToString(), _dr1["hospitalNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionDialog + "-hospital"));
                    _contentFrmColumnDetail[_i].Add("HighLight", true);
                    _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Hospital", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("   </div>");
                    _contentTemp.AppendLine("</div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionDialog + "-save"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Save", _contentFrmColumnDetail[_i]);

                    _html.AppendFormat("<div class='dialog-form form' id='{0}-form'>", _idSectionDialog);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");
                    _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Hospital"]).ToString());
                    _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }
        }
    }
}