/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๓/๐๘/๒๕๕๘>
Modify date : <๐๘/๐๗/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using NUtil;

public class HCSStaffDownloadRegistrationFormUI
{
    private static string _idSectionMain = HCSStaffUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_MAIN.ToLower();
    private static string _idSectionSearch = HCSStaffUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_SEARCH.ToLower();
    private static string _idSectionProgress = HCSStaffUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_PROGRESS.ToLower();

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
            case "PROGRESSDOWNLOAD":
                _html = HCSStaffUI.GetFrmProgressDownloadData(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS, _idSectionProgress);
                break;
        }

        return _html;
    }

    public class SectionMainUI
    {
        public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
        {
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN, _infoData);
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            StringBuilder _html = new StringBuilder();
            int _cookieError = Util.ChkCookie(HCSStaffUtil._myParamSearchCookieName);
            bool _show = false;

            if (_cookieError.Equals(0))
            {
                HttpCookie _objCookie = Util.GetCookie(HCSStaffUtil._myParamSearchCookieName);

                if (_objCookie["Command"].Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
                {
                    _show = true;
                    _searchResult = HCSStaffDownloadRegistrationFormUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN, null, true));
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
            _html.AppendFormat("                                    <li><div class='click-button en-label button-download{0}' alt='{0}'>Download {1}</div></li>", HCSStaffUtil._selectOption[1].ToLower(), HCSStaffUtil._selectOption[1]);
            _html.AppendFormat("                                    <li><div class='click-button en-label button-download{0}' alt='{0}'>Download {1}</div></li>", HCSStaffUtil._selectOption[0].ToLower(), HCSStaffUtil._selectOption[0]);
            _html.AppendFormat("                                </ul>");
            _html.AppendLine("                              </div>");
            _html.AppendLine("                          </div>");
            _html.AppendLine("                      </div>");
            _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
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
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Latest Date Download</div></div></div>");
            _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Download</div><div class='en-label'>Count</div></div></div>");
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
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", HCSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label table-col-latestdatedownload'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["latestDateDownload"].ToString()) ? DateTime.Parse(_dr1["latestDateDownload"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-countdownload'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["countDownload"].ToString()) && !_dr1["countDownload"].ToString().Equals("0") ? (double.Parse(_dr1["countDownload"].ToString()).ToString("#,##0")) : String.Empty));
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

            _paramSearch.Clear();

            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-registrationform"));
            _contentFrmColumnDetail[_i].Add("HighLight", false);
            _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>แบบฟอร์มบริการสุขภาพ</span><span class='en-label'> : Health Care Service Form</span>");
            _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-registrationform-combobox'>" + HCSStaffUI.GetComboboxRegistrationForm((_idSectionSearch + "-registrationform"), _paramSearch) + "</div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("RegistrationForm", _contentFrmColumnDetail[_i]);
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
            _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-program"));
            _contentFrmColumnDetail[_i].Add("HighLight", false);
            _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล</span><span class='en-label'> : Agency Registered</span>");
            _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-program-combobox'></div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("AgencyRegistered", _contentFrmColumnDetail[_i]);
            _i++;

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
            _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-downloadstatus"));
            _contentFrmColumnDetail[_i].Add("HighLight", false);
            _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการดาว์นโหลด</span><span class='en-label'> : Download Status</span>");
            _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-downloadstatus-combobox'>" + HCSStaffUI.GetComboboxDownloadStatus(_idSectionSearch + "-downloadstatus") + "</div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("DownloadStatus", _contentFrmColumnDetail[_i]);
            _i++;
            
            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='search-sort-content'>");
            _contentTemp.AppendLine("   <div class='contentbody-left'>");
            _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffDownloadRegistrationFormUtil._sortOrderBy));
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
            _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN);
            _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN);
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
            _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN).ToString());
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["RegistrationForm"]).ToString());
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["AgencyRegistered"]).ToString());
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                        
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
            _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["DownloadStatus"]).ToString());
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