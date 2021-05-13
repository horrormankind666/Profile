/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๓/๐๗/๒๕๕๙>
Modify date : <๑๒/๐๕/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการบริการข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using NUtil;

public class ePFStaffOurServicesUI
{
    public class ExportStudentRecordsInformationUI
    {     
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_SEARCH.ToLower();
        private static string _idSectionProgress = ePFStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS.ToLower();

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
                case "PROGRESSEXPORT":
                    _html = ePFStaffUI.GetFrmProgressData(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS, _idSectionProgress);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(ePFStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(ePFStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN))
                    {
                        _show = true;
                        _searchResult = ePFStaffOurServicesUtil.ExportStudentRecordsInformationUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN, null, true));
                    }
                }

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                      <div class='contentbody-left button'>");
                _html.AppendLine("                          <div class='button-layout'>");
                _html.AppendLine("                              <div class='button-content'>");
                _html.AppendLine("                                  <ul class='button-style2'>");
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", ePFStaffUtil._selectOption[1].ToLower(), ePFStaffUtil._selectOption[1]);
                _html.AppendFormat("                                    <li><div class='click-button en-label button-export{0}' alt='{0}'>Export {1}</div></li>", ePFStaffUtil._selectOption[0].ToLower(), ePFStaffUtil._selectOption[0]);
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
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Class</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='en-label'>Graduation</div><div class='en-label'>Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='en-label'>Reason of</div><div class='en-label'>Graduation</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col14'><div class='table-col-msg'><div class='en-label'>Student Records</div><div class='en-label'>Status</div></div></div>");
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
                                    "page:('index.aspx?p=" + ePFStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                    "target:'_blank'" +
                                    "})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{0}' name='select-child' alt='select-root' value='{0}' /></div></div></div>", _dr1["id"].ToString());                                          
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["class"].ToString()) ? _dr1["class"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11' onclick={0}><div class='table-col-msg'><div class='th-label table-col-admissiondate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["admissionDate"].ToString()) ? DateTime.Parse(_dr1["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col12' onclick={0}><div class='table-col-msg'><div class='th-label table-col-graduatedate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["graduateDate"].ToString()) ? DateTime.Parse(_dr1["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='th-label {0} table-col-reasonofgraduation' alt='{1}'>{2}</div></div></div>", (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_VIEWMESSAGE.ToLower()) : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? _dr1["updateReason"].ToString() : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? "Message" : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col14' {0}><div class='table-col-msg'><div class='th-label {1}' alt='{2}'>{3}</div></div></div>", (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ("onclick=" + _callFunc) : ""), (_dr1["studentRecordsStatus"].ToString().Equals("N") ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_TOPICSSTUDENTRECORDSSTATUSNOTCOMPLETE.ToLower()) : ""), _dr1["id"], (!String.IsNullOrEmpty(_dr1["studentRecordsStatus"].ToString()) ? (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ePFStaffUtil._studentRecordsStatus[0, 2] : ePFStaffUtil._studentRecordsStatus[1, 2]) : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[11];
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + ePFStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + ePFStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yearattended-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yeargraduate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่สำเร็จการศึกษา</span><span class='en-label'> : Year Graduate</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yeargraduate-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yeargraduate") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-class"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ชั้นปี</span><span class='en-label'> : Class</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-class-combobox'>" + ePFStaffUI.GetComboboxClass(_idSectionSearch + "-class") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Class", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + ePFStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + ePFStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentrecordsstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการบันทึกระเบียนประวัตินักศึกษา</span><span class='en-label'> : Student Records Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentrecordsstatus-combobox'>" + ePFStaffUI.GetComboboxStudentRecordsStatus(_idSectionSearch + "-studentrecordsstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentRecordsStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol2'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffOurServicesUtil.ExportStudentRecordsInformationUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), ePFStaffUtil._sortExpression));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine("                  <div class='search-floatcol search-floatcol1'>");
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentRecordsStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN);
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
    }

    public class UpdateStudentMedicalScholarsProgramUI
    {     
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_SEARCH.ToLower();

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
                case "PROGRESSSAVE":
                    _html = SectionProgressUI.GetMain();
                    break;
                case "PREVIEWSAVE":
                    _html = SectionPreviewUI.GetMain();
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(ePFStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;

                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(ePFStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN))
                    {
                        _show = true;
                        _searchResult = ePFStaffOurServicesUtil.UpdateStudentMedicalScholarsProgramUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN, null, true));
                    }
                }

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                      <div class='contentbody-left button'>");
                _html.AppendLine("                          <div class='button-layout'>");
                _html.AppendLine("                              <div class='button-content'>");
                _html.AppendLine("                                  <ul class='button-style4'>");
                _html.AppendFormat("                                    <li><div class='click-button en-label button-update{0}' alt='{0}'>Update {1}</div></li>", ePFStaffUtil._selectOption[1].ToLower(), ePFStaffUtil._selectOption[1]);
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
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Class</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Join Program</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Start</div><div class='en-label'>Semester / Year</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='en-label'>End</div><div class='en-label'>Semester / Year</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='en-label'>Resign Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col14'><div class='table-col-msg'><div class='en-label'>Student Records</div><div class='en-label'>Status</div></div></div>");
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
                                    "page:('index.aspx?p=" + ePFStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                    "target:'_blank'" +
                                    "})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div><input class='checkbox select-child' type='checkbox' id='select-child-{0}' name='select-child' alt='select-root' value='{0}' /></div></div></div>", _dr1["id"].ToString());                                          
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["class"].ToString()) ? _dr1["class"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-joinprogramstatus'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["mspJoin"].ToString()) ? _dr1["mspJoin"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11' onclick={0}><div class='table-col-msg'><div class='th-label table-col-startsemesteryear'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["mspStartSemester"].ToString()) && !String.IsNullOrEmpty(_dr1["mspStartYear"].ToString()) ? (_dr1["mspStartSemester"].ToString() + " / " + _dr1["mspStartYear"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col12' onclick={0}><div class='table-col-msg'><div class='th-label table-col-endsemesteryear'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["mspEndSemester"].ToString()) && !String.IsNullOrEmpty(_dr1["mspEndYear"].ToString()) ? (_dr1["mspEndSemester"].ToString() + " / " + _dr1["mspEndYear"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col13' onclick={0}><div class='table-col-msg'><div class='th-label table-col-resigndate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["mspResignDate"].ToString()) ? _dr1["mspResignDate"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col14' {0}><div class='table-col-msg'><div class='th-label {1}' alt='{2}'>{3}</div></div></div>", (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ("onclick=" + _callFunc) : ""), (_dr1["studentRecordsStatus"].ToString().Equals("N") ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_TOPICSSTUDENTRECORDSSTATUSNOTCOMPLETE.ToLower()) : ""), _dr1["id"], (!String.IsNullOrEmpty(_dr1["studentRecordsStatus"].ToString()) ? (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ePFStaffUtil._studentRecordsStatus[0, 2] : ePFStaffUtil._studentRecordsStatus[1, 2]) : String.Empty));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + ePFStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + ePFStaffUI.GetComboboxFacultyByJoinProgram((_idSectionSearch + "-faculty"), "MedicalScholarsProgram") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-yearattended-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-class"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ชั้นปี</span><span class='en-label'> : Class</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-class-combobox'>" + ePFStaffUI.GetComboboxClass(_idSectionSearch + "-class") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Class", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + ePFStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + ePFStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentrecordsstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการบันทึกระเบียนประวัตินักศึกษา</span><span class='en-label'> : Student Records Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentrecordsstatus-combobox'>" + ePFStaffUI.GetComboboxStudentRecordsStatus(_idSectionSearch + "-studentrecordsstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentRecordsStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-joinprogramstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการเข้าโครงการ</span><span class='en-label'> : Status of Joined the Program</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-joinprogramstatus-combobox'>" + ePFStaffUI.GetComboboxJoinProgramStatus(_idSectionSearch + "-joinprogramstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("JoinProgramStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-startacademicyear"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีการศึกษาที่ไป</span><span class='en-label'> : Start Academic Year</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-startacademicyear-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-startacademicyear") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StartAcademicYear", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-endacademicyear"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีการศึกษาที่กลับ</span><span class='en-label'> : End Academic Year</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-endacademicyear-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-endacademicyear") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EndAcademicYear", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol2'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffOurServicesUtil.UpdateStudentMedicalScholarsProgramUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), ePFStaffUtil._sortExpression));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentRecordsStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["JoinProgramStatus"]).ToString());
                _html.AppendLine("                  <div class='search-floatcol search-floatcol1'>");
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["StartAcademicYear"]).ToString());
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["EndAcademicYear"]).ToString());
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN);
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

        public class SectionProgressUI
        {
            private static string _idSectionProgress = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PROGRESS.ToLower();

            public static StringBuilder GetMain()
            {                
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[9];
                DataSet _ds = new DataSet();
                int _i = 0;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='list'>");
                _contentTemp.AppendLine("   <div class='list-layout'>");
                _contentTemp.AppendLine("       <div class='list-content'></div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-student"));
                _contentFrmColumnDetail[_i].Add("HighLight", true);
                _contentFrmColumnDetail[_i].Add("TitleTH", "นักศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Student");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Student", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='checkbox-content'>");
                _contentTemp.AppendLine("   <ul>");
                _contentTemp.AppendFormat("     <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-joinprogramstatus' value='Y' /></li>", _idSectionProgress);
                _contentTemp.AppendLine("       <li class='checkbox-labelcol'></li>");
                _contentTemp.AppendLine("   </ul>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-joinprogramstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เข้าโครงการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Joined the Program");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("JoinProgramStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='semesteryear'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left' id='{0}-startsemester-combobox'>{1}</div>", _idSectionProgress, ePFStaffUI.GetComboboxSemester(_idSectionProgress + "-startsemester"));
                _contentTemp.AppendLine("   <div class='contentbody-left th-label'> / </div>");
                _contentTemp.AppendFormat(" <div class='contentbody-left' id='{0}-startyear-combobox'>{1}</div>", _idSectionProgress, ePFStaffUI.GetComboboxYearAttended(_idSectionProgress + "-startyear"));
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-startsemesteryear"));
                _contentFrmColumnDetail[_i].Add("HighLight", true);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ภาค / ปีที่ไป");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Start Semester / Year");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("StartSemesterYear", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='semesteryear'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left' id='{0}-endsemester-combobox'>{1}</div>", _idSectionProgress, ePFStaffUI.GetComboboxSemester(_idSectionProgress + "-endsemester"));
                _contentTemp.AppendLine("   <div class='contentbody-left th-label'> / </div>");
                _contentTemp.AppendFormat(" <div class='contentbody-left' id='{0}-endyear-combobox'>{1}</div>", _idSectionProgress, ePFStaffUI.GetComboboxYearAttended(_idSectionProgress + "-endyear"));
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-endsemesteryear"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ภาค / ปีที่กลับ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "End Semester / Year");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("EndSemesterYear", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-resigndate"));
                _contentFrmColumnDetail[_i].Add("HighLight", true);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วันที่ออกจากโครงการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Resign Date");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<input class='inputcalendar' type='text' id='" + _idSectionProgress + "-resigndate' readonly value='' />"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("ResignDate", _contentFrmColumnDetail[_i]);

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='progresstotal'>");
                _contentTemp.AppendFormat(" <span class='th-label' id='{0}-total'></span>", _idSectionProgress);
                _contentTemp.AppendLine("   <span class='th-label'> คน</span>");
                _contentTemp.AppendLine("   <span class='en-label'> : people</span>");
                _contentTemp.AppendLine("</div>");
                    
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-total"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ปรับปรุงข้อมูลจำนวน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Update Total of");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Total", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='progresstotal'>");
                _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalcomplete'></span>", _idSectionProgress);
                _contentTemp.AppendLine("   <span class='th-label'></span>");
                _contentTemp.AppendLine("   <span class='en-label'></span>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-totalcomplete"));
                _contentFrmColumnDetail[_i].Add("HighLight", true);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ปรับปรุงข้อมูลสำเร็จจำนวน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Update Complete Total of");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("TotalComplete", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='progresstotal'>");
                _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalincomplete'></span>", _idSectionProgress);
                _contentTemp.AppendLine("   <span class='th-label'></span>");
                _contentTemp.AppendLine("   <span class='en-label'></span>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-totalincomplete"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ปรับปรุงข้อมูลไม่สำเร็จจำนวน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Update Incomplete Total of");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("TotalIncomplete", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE</div></li>");
                _contentTemp.AppendLine("               <li><div class='click-button en-label button-undo'>CLEAR</div></li>");
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionProgress + "-save"));
                _contentFrmColumnDetail[_i].Add("HighLight", true);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Save", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='dialog-form form progress' id='{0}-form'>", _idSectionProgress);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Student"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["JoinProgramStatus"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["StartSemesterYear"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["EndSemesterYear"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["ResignDate"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class SectionPreviewUI
        {
            private static string _idSectionPreview = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_PREVIEW.ToLower();

            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendFormat("<div class='dialog-form' id='{0}-form'>", _idSectionPreview);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendFormat("            <div class='table table-previewprogress' id='{0}-table'>", _idSectionPreview);
                _html.AppendLine("                  <div class='table-layout'>");
                _html.AppendLine("                      <div class='table-content'>");
                _html.AppendLine("                          <div class='table-freeze'>");
                _html.AppendLine("                              <div class='table-title'>");
                _html.AppendLine("                                  <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendLine("                                      <span class='en-label'>Update Total of </span>");
                _html.AppendLine("                                      <span class='recordcount-search th-label'></span>");
                _html.AppendLine("                                      <span class='en-label'> people</span>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='clear'></div>");
                _html.AppendLine("                              <div class='table-head'>");
                _html.AppendLine("                                  <div class='table-row'>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='en-label'>Join Program</div><div class='en-label'>Status</div><div class='en-label'>New ( Old )</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Start</div><div class='en-label'>Semester / Year</div><div class='en-label'>New ( Old )</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>End</div><div class='en-label'>Semester / Year</div><div class='en-label'>New ( Old )</div></div></div>");
                _html.AppendLine("                                      <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Resign Date</div><div class='en-label'>&nbsp;</div><div class='en-label'>New ( Old )</div></div></div>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendFormat("                        <div class='table-list'>{0}</div>", GetList());
                _html.AppendLine("                          <div class='button'>");
                _html.AppendLine("                              <div class='button-layout'>");
                _html.AppendLine("                                  <div class='button-content'>");
                _html.AppendLine("                                      <ul class='button-style1'>");
                _html.AppendLine("                                          <li class='nomargin'><div class='click-button en-label button-submit'>SUBMIT</div></li>");
                _html.AppendLine("                                      </ul>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            public static StringBuilder GetList()
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendLine("<div class='table-grid'></div>");

                return _html;
            }
        }
    }

    public class SummaryNumberOfStudentUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENT_SEARCH.ToLower();

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
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN, _infoData);
                StringBuilder _html = new StringBuilder();
                int _i = 0;

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='tabbar sticky viewsdisplay' id='{0}-viewsdisplay'>", _idSectionMain);
                _html.AppendFormat("    <div class='tabbar-layout' id='{0}-viewsdisplay-layout'>", _idSectionMain);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-viewsdisplay-content'>", _idSectionMain);
                _html.AppendLine("              <ul>");

                for (_i = 0; _i < ePFStaffUtil._viewsDisplay.GetLength(0); _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStaffUtil._viewsDisplay[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        (_idSectionMain + ePFStaffUtil._viewsDisplay[_i, 3]).ToLower(),
                        ePFStaffUtil._viewsDisplay[_i, 0],
                        ePFStaffUtil._viewsDisplay[_i, 1]
                    );
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendFormat("<div id='{0}'>", _idSectionMain);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionMain);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionMain);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + ePFStaffUtil._viewsDisplay[0, 3]).ToLower(), ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTVIEWCHART_MAIN, ViewChartUI.SectionMainUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", (_idSectionMain + ePFStaffUtil._viewsDisplay[1, 3]).ToLower(), ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTVIEWTABLE_MAIN, String.Empty);
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[11];
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + ePFStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + ePFStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yearattended-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yeargraduate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่สำเร็จการศึกษา</span><span class='en-label'> : Year Graduate</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yeargraduate-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yeargraduate") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-class"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ชั้นปี</span><span class='en-label'> : Class</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-class-combobox'>" + ePFStaffUI.GetComboboxClass(_idSectionSearch + "-class") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Class", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + ePFStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + ePFStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentrecordsstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการบันทึกระเบียนประวัตินักศึกษา</span><span class='en-label'> : Student Records Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentrecordsstatus-combobox'>" + ePFStaffUI.GetComboboxStudentRecordsStatus(_idSectionSearch + "-studentrecordsstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentRecordsStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol2'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffOurServicesUtil.ExportStudentRecordsInformationUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), ePFStaffUtil._sortExpression));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine("                  <div class='search-floatcol search-floatcol1'>");
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentRecordsStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN);
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
            private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTVIEWCHART_MAIN.ToLower();

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
                    int _cookieError = Util.ChkCookie(ePFStaffUtil._myParamSearchCookieName);
                    bool _show = false;
                    
                    if (_cookieError.Equals(0))
                    {
                        HttpCookie _objCookie = Util.GetCookie(ePFStaffUtil._myParamSearchCookieName);
                        if (_objCookie["Command"].Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN))
                        {
                            _show = true;
                            _searchResult = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewChartUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN, null, true));
                        }
                    }
                    
                    _html.AppendFormat("<div class='chart' id='{0}-chart'>", _idSectionMain);
                    _html.AppendLine("      <div class='chart-layout'>");
                    _html.AppendLine("          <div class='chart-content'>");
                    _html.AppendLine("              <div class='chart-freeze sticky'>");
                    _html.AppendLine("                  <div class='chart-title'>");
                    _html.AppendLine("                      <div class='contentbody-left'></div>");
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
                    Dictionary<string, object> _tbChart1 = new Dictionary<string, object>();
                    Dictionary<string, object> _tbChart2 = new Dictionary<string, object>();
                    Dictionary<string, object> _tbChart3 = new Dictionary<string, object>();
                    Dictionary<string, object> _tbChart4 = new Dictionary<string, object>();
                    string _backgroundColor1 = "#FFFFFF";
                    string _backgroundColor2 = "#F1F1F1";
                    int _i = 0;
 
                    if (_ds.Tables[0].Rows.Count > 0)
                    {   
                        _paramChart.Add("RenderTo", "");
                        _paramChart.Add("BackgroundColor", "");
                        _paramChart.Add("Title", "");
                        _paramChart.Add("LegendTitle", "");
                        _paramChart.Add("Level1XAxisTitle", "");
                        _paramChart.Add("Level1YAxisTitle", "");
                        _paramChart.Add("Level2XAxisTitle", "");
                        _paramChart.Add("Level2YAxisTitle", "");
                        _paramChart.Add("Level3XAxisTitle", "");
                        _paramChart.Add("Level3YAxisTitle", "");
                        _paramChart.Add("Level4XAxisTitle", "");
                        _paramChart.Add("Level4YAxisTitle", "");

                        _tbChart1.Add("Index", "");
                        _tbChart1.Add("Id", "");
                        _tbChart1.Add("SeriesName1", "");
                        _tbChart1.Add("SeriesName2", "");
                        _tbChart1.Add("SeriesDataFormat", "");
                        _tbChart1.Add("SeriesDataName1", "");
                        _tbChart1.Add("SeriesDataName2", "");
                        _tbChart1.Add("Color1", "");
                        _tbChart1.Add("Color2", "");
                        _tbChart1.Add("Value1", "");
                        _tbChart1.Add("Value2", "");
                        _tbChart1.Add("DrillDownId", "");
                        _tbChart1.Add("DrillDownHint1", "");
                        _tbChart1.Add("DrillDownHint2", "");

                        _tbChart2.Add("Index", "");
                        _tbChart2.Add("Id", "");
                        _tbChart2.Add("SeriesName1", "");
                        _tbChart2.Add("SeriesName2", "");
                        _tbChart2.Add("SeriesDataFormat", "");
                        _tbChart2.Add("SeriesDataName1", "");
                        _tbChart2.Add("SeriesDataName2", "");
                        _tbChart2.Add("Color1", "");
                        _tbChart2.Add("Color2", "");
                        _tbChart2.Add("Value1", "");
                        _tbChart2.Add("Value2", "");
                        _tbChart2.Add("DrillDownId", "");
                        _tbChart2.Add("DrillDownHint1", "");
                        _tbChart2.Add("DrillDownHint2", "");

                        _tbChart3.Add("Index", "");
                        _tbChart3.Add("Id", "");
                        _tbChart3.Add("SeriesName1", "");
                        _tbChart3.Add("SeriesName2", "");
                        _tbChart3.Add("SeriesDataFormat", "");
                        _tbChart3.Add("SeriesDataName1", "");
                        _tbChart3.Add("SeriesDataName2", "");
                        _tbChart3.Add("Color1", "");
                        _tbChart3.Add("Color2", "");
                        _tbChart3.Add("Value1", "");
                        _tbChart3.Add("Value2", "");
                        _tbChart3.Add("DrillDownId", "");
                        _tbChart3.Add("DrillDownHint1", "");
                        _tbChart3.Add("DrillDownHint2", "");

                        _tbChart4.Add("Index", "");
                        _tbChart4.Add("Id", "");
                        _tbChart4.Add("SeriesName1", "");
                        _tbChart4.Add("SeriesName2", "");
                        _tbChart4.Add("SeriesDataFormat", "");
                        _tbChart4.Add("SeriesDataName1", "");
                        _tbChart4.Add("SeriesDataName2", "");
                        _tbChart4.Add("Color1", "");
                        _tbChart4.Add("Color2", "");
                        _tbChart4.Add("Value1", "");
                        _tbChart4.Add("Value2", "");
                        _tbChart4.Add("DrillDownId", "");
                        _tbChart4.Add("DrillDownHint1", "");
                        _tbChart4.Add("DrillDownHint2", "");

                        _html.AppendLine("<div class='chart-grid'>");

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ?_backgroundColor1 : _backgroundColor2);
                        _paramChart["Level1YAxisTitle"] = "จำนวนนักศึกษา ( คน )<br />Number of Student ( people )";
                        _paramChart["Level2YAxisTitle"] = "จำนวนนักศึกษา ( คน )<br />Number of Student ( people )";
                        _paramChart["Level3YAxisTitle"] = "จำนวนนักศึกษา ( คน )<br />Number of Student ( people )";
                        _paramChart["Level4YAxisTitle"] = "จำนวนนักศึกษา ( คน )<br />Number of Student ( people )";

                        _tbChart1["Index"] = 1;
                        _tbChart1["Id"] = "";
                        _tbChart1["SeriesName1"] = "ชาย : Male";
                        _tbChart1["SeriesName2"] = "หญิง : Female";
                        _tbChart1["SeriesDataFormat"] = "{0} : {1}";
                        _tbChart1["SeriesDataName1"] = "statusGroupNameTH";
                        _tbChart1["SeriesDataName2"] = "statusGroupNameEN";
                        _tbChart1["Color1"] = "#F8A13F";
                        _tbChart1["Color2"] = "#C0463D";
                        _tbChart1["Value1"] = "countMalePeople";
                        _tbChart1["Value2"] = "countFemalePeople";
                        _tbChart1["DrillDownId"] = "drilldownId";
                        _tbChart1["DrillDownHint1"] = "M";
                        _tbChart1["DrillDownHint2"] = "F";
                        
                        _tbChart2["Index"] = 2;
                        _tbChart2["Id"] = "id";
                        _tbChart2["SeriesName1"] = "ชาย : Male";
                        _tbChart2["SeriesName2"] = "หญิง : Female";
                        _tbChart2["SeriesDataFormat"] = "{0}";
                        _tbChart2["SeriesDataName1"] = "yearEntry";
                        _tbChart2["SeriesDataName2"] = "";
                        _tbChart2["Color1"] = "#F8A13F";
                        _tbChart2["Color2"] = "#C0463D";
                        _tbChart2["Value1"] = "countMalePeople";
                        _tbChart2["Value2"] = "countFemalePeople";
                        _tbChart2["DrillDownId"] = "drilldownId";
                        _tbChart2["DrillDownHint1"] = "M";
                        _tbChart2["DrillDownHint2"] = "F";

                        _tbChart3["Index"] = 3;
                        _tbChart3["Id"] = "id";
                        _tbChart3["SeriesName1"] = "ชาย : Male";
                        _tbChart3["SeriesName2"] = "หญิง : Female";
                        _tbChart3["SeriesDataFormat"] = "{0}";
                        _tbChart3["SeriesDataName1"] = "faculty";
                        _tbChart3["SeriesDataName2"] = "";
                        _tbChart3["Color1"] = "#F8A13F";
                        _tbChart3["Color2"] = "#C0463D";
                        _tbChart3["Value1"] = "countMalePeople";
                        _tbChart3["Value2"] = "countFemalePeople";
                        _tbChart3["DrillDownId"] = "drilldownId";
                        _tbChart3["DrillDownHint1"] = "M";
                        _tbChart3["DrillDownHint2"] = "F";

                        _tbChart4["Index"] = 4;
                        _tbChart4["Id"] = "id";
                        _tbChart4["SeriesName1"] = "ชาย : Male";
                        _tbChart4["SeriesName2"] = "หญิง : Female";
                        _tbChart4["SeriesDataFormat"] = "{0}";
                        _tbChart4["SeriesDataName1"] = "program";
                        _tbChart4["SeriesDataName2"] = "";
                        _tbChart4["Color1"] = "#F8A13F";
                        _tbChart4["Color2"] = "#C0463D";
                        _tbChart4["Value1"] = "countMalePeople";
                        _tbChart4["Value2"] = "countFemalePeople";
                        _tbChart4["DrillDownId"] = "";
                        _tbChart4["DrillDownHint1"] = "";
                        _tbChart4["DrillDownHint2"] = "";
                        
                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;
                        
                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);

                        _tbChart1["Index"] = 5;
                        _tbChart1["SeriesDataFormat"] = "{0} : {1}";
                        _tbChart1["SeriesDataName1"] = "degreeLevelNameTH";
                        _tbChart1["SeriesDataName2"] = "degreeLevelNameEN";

                        _tbChart2["Index"] = 6;

                        _tbChart3["Index"] = 7;

                        _tbChart4["Index"] = 8;

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);

                        _tbChart1["Index"] = 9;
                        _tbChart1["SeriesDataFormat"] = "{0}";
                        _tbChart1["SeriesDataName1"] = "yearEntry";
                        _tbChart1["SeriesDataName2"] = "";

                        _tbChart2["Index"] = 10;
                        _tbChart2["SeriesDataFormat"] = "{0}";
                        _tbChart2["SeriesDataName1"] = "faculty";
                        _tbChart2["SeriesDataName2"] = "";

                        _tbChart3["Index"] = 11;
                        _tbChart3["SeriesDataFormat"] = "{0}";
                        _tbChart3["SeriesDataName1"] = "program";
                        _tbChart3["SeriesDataName2"] = "";
                        _tbChart3["DrillDownId"] = "";
                        _tbChart3["DrillDownHint1"] = "";
                        _tbChart3["DrillDownHint2"] = "";

                        _tbChart4["Index"] = -1;

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);

                        _tbChart1["Index"] = 12;
                        _tbChart1["SeriesDataFormat"] = "{0} : {1}";
                        _tbChart1["SeriesDataName1"] = "stdEntranceTypeNameTH";
                        _tbChart1["SeriesDataName2"] = "perEntranceTypeId"; 

                        _tbChart2["Index"] = 13;
                        _tbChart2["SeriesDataFormat"] = "{0}";
                        _tbChart2["SeriesDataName1"] = "yearEntry";
                        _tbChart2["SeriesDataName2"] = "";

                        _tbChart3["Index"] = 14;
                        _tbChart3["SeriesDataFormat"] = "{0}";
                        _tbChart3["SeriesDataName1"] = "faculty";
                        _tbChart3["SeriesDataName2"] = "";
                        _tbChart3["DrillDownId"] = "drilldownId";
                        _tbChart3["DrillDownHint1"] = "M";
                        _tbChart3["DrillDownHint2"] = "F";

                        _tbChart4["Index"]              = 15;

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);

                        _tbChart1["Index"] = 16;
                        _tbChart1["SeriesDataFormat"] = "{0}";
                        _tbChart1["SeriesDataName1"] = "class";
                        _tbChart1["SeriesDataName2"] = ""; 

                        _tbChart2["Index"] = 17;

                        _tbChart3["Index"] = 18;

                        _tbChart4["Index"] = 19;

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
                        _html.AppendLine(GetListRow(_i).ToString());
                        _i++;

                        _paramChart["RenderTo"] = ("chart" + (_i + 1).ToString() + "-" + ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENT).ToLower();
                        _paramChart["BackgroundColor"] = ((_i % 2) == 0 ? _backgroundColor1 : _backgroundColor2);

                        _tbChart1["Index"] = 20;
                        _tbChart1["SeriesDataFormat"] = "{0}";
                        _tbChart1["SeriesDataName1"] = "isoNationalityName3Letter";
                        _tbChart1["SeriesDataName2"] = ""; 

                        _tbChart2["Index"] = 21;

                        _tbChart3["Index"] = 22;

                        _tbChart4["Index"] = 23;

                        GetChart("column", _paramChart, _ds, _tbChart1, _tbChart2, _tbChart3, _tbChart4);
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

                private static void GetChart(string _type, Dictionary<string, object> _paramChart, DataSet _ds, Dictionary<string, object> _tbChart1, Dictionary<string, object> _tbChart2, Dictionary<string, object> _tbChart3, Dictionary<string, object> _tbChart4)
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

                    List<object> _level4SeriesId = new List<object>();
                    List<object> _level4SeriesName = new List<object>();
                    List<object> _level4SeriesDataName = new List<object>();
                    List<object> _level4SeriesDataColor = new List<object>();
                    List<object> _level4SeriesDataValue = new List<object>();
                    List<object> _level4SeriesDataDrillDown = new List<object>();

                    List<object> _seriesNameTemp1 = new List<object>();
                    List<object> _seriesNameTemp2 = new List<object>();
                    List<object> _seriesNameTemp3 = new List<object>();
                    List<object> _seriesNameTemp4 = new List<object>();
                    List<object> _seriesColorTemp1 = new List<object>();
                    List<object> _seriesColorTemp2 = new List<object>();
                    List<object> _seriesColorTemp3 = new List<object>();
                    List<object> _seriesColorTemp4 = new List<object>();
                    List<object> _seriesValueTemp1 = new List<object>();
                    List<object> _seriesValueTemp2 = new List<object>();
                    List<object> _seriesValueTemp3 = new List<object>();
                    List<object> _seriesValueTemp4 = new List<object>();
                    List<object> _seriesDrillDownTemp1 = new List<object>();
                    List<object> _seriesDrillDownTemp2 = new List<object>();
                    List<object> _seriesDrillDownTemp3 = new List<object>();
                    List<object> _seriesDrillDownTemp4 = new List<object>();
                    
                    string _seriesDataName1 = String.Empty;
                    string _seriesDataName2 = String.Empty;
                    string _seriesDataName3 = String.Empty;
                    string _seriesDataName4 = String.Empty;
                    string _seriesDataDrillDown1 = String.Empty;
                    string _seriesDataDrillDown2 = String.Empty;
                    string _seriesDataDrillDown3 = String.Empty;
                    string _seriesDataDrillDown4 = String.Empty;
                    int _i = 0;

                    if (!_tbChart1["Index"].Equals(-1))
                    {
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

                            _level4SeriesId.Clear();
                            _level4SeriesName.Clear();
                            _level4SeriesDataName.Clear();
                            _level4SeriesDataColor.Clear();
                            _level4SeriesDataValue.Clear();
                            _level4SeriesDataDrillDown.Clear();
                        
                            _paramChart["Title"] = (_ds.Tables[(int)_tbChart1["Index"]].Rows[0]["titleTH"].ToString() + "<br />" + _ds.Tables[(int)_tbChart1["Index"]].Rows[0]["titleEN"].ToString());

                            for (_i = 1; _i <= 2; _i++)
                            {                            
                                _seriesNameTemp1 = new List<object>();
                                _seriesColorTemp1 = new List<object>();
                                _seriesValueTemp1 = new List<object>();
                                _seriesDrillDownTemp1 = new List<object>();

                                _level1SeriesName.Add(_tbChart1["SeriesName" + _i]);
                                _level1SeriesColor.Add(_tbChart1["Color" + _i]);

                                foreach (DataRow _dr1 in _ds.Tables[(int)_tbChart1["Index"]].Rows)
                                {
                                    _seriesDataName1 = _tbChart1["SeriesDataFormat"].ToString().Replace("{0}", _dr1[_tbChart1["SeriesDataName1"].ToString()].ToString());
                                    _seriesDataName1 = (!String.IsNullOrEmpty(_tbChart1["SeriesDataName2"].ToString()) &&!_dr1[_tbChart1["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _seriesDataName1.Replace("{1}", _dr1[_tbChart1["SeriesDataName2"].ToString()].ToString()) : _seriesDataName1.Replace(" : {1}", ""));
                                    _seriesDataDrillDown1 = (!String.IsNullOrEmpty(_tbChart1["DrillDownId"].ToString()) ? (_dr1[_tbChart1["DrillDownId"].ToString()].ToString() + _tbChart1["DrillDownHint" + _i]) : "");

                                    _seriesNameTemp1.Add(_seriesDataName1);
                                    _seriesColorTemp1.Add(_tbChart1["Color" + _i]);
                                    _seriesValueTemp1.Add(_dr1[_tbChart1["Value" + _i].ToString()]);
                                    _seriesDrillDownTemp1.Add(_seriesDataDrillDown1);

                                    if (!_tbChart2["Index"].Equals(-1))
                                    {
                                        _seriesNameTemp2 = new List<object>();
                                        _seriesColorTemp2 = new List<object>();
                                        _seriesValueTemp2 = new List<object>();
                                        _seriesDrillDownTemp2 = new List<object>(); 

                                        _level2SeriesId.Add(_seriesDataDrillDown1);
                                        _level2SeriesName.Add(_seriesDataName1 + ", " + _tbChart2["SeriesName" + _i] + " ( " + double.Parse(_dr1[_tbChart1["Value" + _i].ToString()].ToString()).ToString("#,##0") + " )");

                                        foreach (DataRow _dr2 in _ds.Tables[(int)_tbChart2["Index"]].Select(_tbChart2["Id"].ToString() + " = '" + _dr1[_tbChart1["DrillDownId"].ToString()].ToString() + "'"))
                                        {
                                            _seriesDataName2 = _tbChart2["SeriesDataFormat"].ToString().Replace("{0}", _dr2[_tbChart2["SeriesDataName1"].ToString()].ToString());
                                            _seriesDataName2 = (!String.IsNullOrEmpty(_tbChart2["SeriesDataName2"].ToString()) && !_dr2[_tbChart2["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _seriesDataName2.Replace("{1}", _dr2[_tbChart2["SeriesDataName2"].ToString()].ToString()) : _seriesDataName2.Replace(" : {1}", ""));
                                            _seriesDataDrillDown2 = (!String.IsNullOrEmpty(_tbChart2["DrillDownId"].ToString()) ? (_dr2[_tbChart2["DrillDownId"].ToString()].ToString() + _tbChart2["DrillDownHint" + _i]) : "");

                                            _seriesNameTemp2.Add(_seriesDataName2);
                                            _seriesColorTemp2.Add(_tbChart2["Color" + _i]);
                                            _seriesValueTemp2.Add(_dr2[_tbChart2["Value" + _i].ToString()]);
                                            _seriesDrillDownTemp2.Add(_seriesDataDrillDown2);

                                            if (!_tbChart3["Index"].Equals(-1))
                                            {
                                                _seriesNameTemp3 = new List<object>();
                                                _seriesColorTemp3 = new List<object>();
                                                _seriesValueTemp3 = new List<object>();
                                                _seriesDrillDownTemp3 = new List<object>();

                                                _level3SeriesId.Add(_seriesDataDrillDown2);
                                                _level3SeriesName.Add(_seriesDataName1 + ", " + _seriesDataName2 + ", " + _tbChart3["SeriesName" + _i] + " ( " + double.Parse(_dr2[_tbChart2["Value" + _i].ToString()].ToString()).ToString("#,##0") + " )");

                                                foreach (DataRow _dr3 in _ds.Tables[(int)_tbChart3["Index"]].Select(_tbChart3["Id"].ToString() + " = '" + _dr2[_tbChart2["DrillDownId"].ToString()].ToString() + "'"))
                                                {
                                                    _seriesDataName3 = _tbChart3["SeriesDataFormat"].ToString().Replace("{0}", _dr3[_tbChart3["SeriesDataName1"].ToString()].ToString());
                                                    _seriesDataName3 = (!String.IsNullOrEmpty(_tbChart3["SeriesDataName2"].ToString()) && !_dr3[_tbChart3["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _seriesDataName3.Replace("{1}", _dr3[_tbChart3["SeriesDataName2"].ToString()].ToString()) : _seriesDataName3.Replace(" : {1}", ""));
                                                    _seriesDataDrillDown3 = (!String.IsNullOrEmpty(_tbChart3["DrillDownId"].ToString()) ? (_dr3[_tbChart3["DrillDownId"].ToString()].ToString() + _tbChart3["DrillDownHint" + _i]) : "");

                                                    _seriesNameTemp3.Add(_seriesDataName3);
                                                    _seriesColorTemp3.Add(_tbChart3["Color" + _i]);
                                                    _seriesValueTemp3.Add(_dr3[_tbChart3["Value" + _i].ToString()]);
                                                    _seriesDrillDownTemp3.Add(_seriesDataDrillDown3);

                                                    if (!_tbChart4["Index"].Equals(-1))
                                                    {
                                                        _seriesNameTemp4 = new List<object>();
                                                        _seriesColorTemp4 = new List<object>();
                                                        _seriesValueTemp4 = new List<object>();
                                                        _seriesDrillDownTemp4 = new List<object>();

                                                        _level4SeriesId.Add(_seriesDataDrillDown3);
                                                        _level4SeriesName.Add(_seriesDataName1 + ", " + _seriesDataName2 + ", " + _seriesDataName3 + ", " + _tbChart4["SeriesName" + _i] + " ( " + double.Parse(_dr3[_tbChart3["Value" + _i].ToString()].ToString()).ToString("#,##0") + " )");

                                                        foreach (DataRow _dr4 in _ds.Tables[(int)_tbChart4["Index"]].Select(_tbChart4["Id"].ToString() + " = '" + _dr3[_tbChart3["DrillDownId"].ToString()].ToString() + "'"))
                                                        {
                                                            _seriesDataName4 = _tbChart4["SeriesDataFormat"].ToString().Replace("{0}", _dr4[_tbChart4["SeriesDataName1"].ToString()].ToString());
                                                            _seriesDataName4 = (!String.IsNullOrEmpty(_tbChart4["SeriesDataName2"].ToString()) && !_dr4[_tbChart4["SeriesDataName2"].ToString()].ToString().Equals("N/A") ? _seriesDataName4.Replace("{1}", _dr4[_tbChart4["SeriesDataName2"].ToString()].ToString()) : _seriesDataName4.Replace(" : {1}", ""));
                                                            _seriesDataDrillDown4 = (!String.IsNullOrEmpty(_tbChart4["DrillDownId"].ToString()) ? (_dr4[_tbChart4["DrillDownId"].ToString()].ToString() + _tbChart4["DrillDownHint" + _i]) : "");
                                            
                                                            _seriesNameTemp4.Add(_seriesDataName4);
                                                            _seriesColorTemp4.Add(_tbChart4["Color" + _i]);
                                                            _seriesValueTemp4.Add(_dr4[_tbChart4["Value" + _i].ToString()]);
                                                            _seriesDrillDownTemp4.Add(_seriesDataDrillDown4);
                                                        }
                                        
                                                        _level4SeriesDataName.Add(_seriesNameTemp4);                                        
                                                        _level4SeriesDataColor.Add(_seriesColorTemp4);
                                                        _level4SeriesDataValue.Add(_seriesValueTemp4);
                                                        _level4SeriesDataDrillDown.Add(_seriesDrillDownTemp4); 
                                                    }
                                                }

                                                _level3SeriesDataName.Add(_seriesNameTemp3);
                                                _level3SeriesDataColor.Add(_seriesColorTemp3);
                                                _level3SeriesDataValue.Add(_seriesValueTemp3);
                                                _level3SeriesDataDrillDown.Add(_seriesDrillDownTemp3);
                                            }
                                        }

                                        _level2SeriesDataName.Add(_seriesNameTemp2);
                                        _level2SeriesDataColor.Add(_seriesColorTemp2);
                                        _level2SeriesDataValue.Add(_seriesValueTemp2);
                                        _level2SeriesDataDrillDown.Add(_seriesDrillDownTemp2);
                                    }
                                }

                                _level1SeriesDataName.Add(_seriesNameTemp1);
                                _level1SeriesDataColor.Add(_seriesColorTemp1);
                                _level1SeriesDataValue.Add(_seriesValueTemp1);
                                _level1SeriesDataDrillDown.Add(_seriesDrillDownTemp1);
                            }
                        }
                    }

                    Util.ChartUtil.Type = _type;
                    Util.ChartUtil.RenderTo = _paramChart["RenderTo"].ToString().ToLower();
                    Util.ChartUtil.BackgroundColor = _paramChart["BackgroundColor"].ToString();
                    Util.ChartUtil.Title = _paramChart["Title"].ToString();
                    Util.ChartUtil.LegendTitle = _paramChart["LegendTitle"].ToString();
                    Util.ChartUtil.Level1XAxisTitle = _paramChart["Level1XAxisTitle"].ToString();
                    Util.ChartUtil.Level1YAxisTitle = _paramChart["Level1YAxisTitle"].ToString();
                    Util.ChartUtil.Level1SeriesName = _level1SeriesName;
                    Util.ChartUtil.Level1SeriesColor = _level1SeriesColor;
                    Util.ChartUtil.Level1SeriesColorByPoint =  false;
                    Util.ChartUtil.Level1SeriesDataName = _level1SeriesDataName;
                    Util.ChartUtil.Level1SeriesDataColor = _level1SeriesDataColor;
                    Util.ChartUtil.Level1SeriesDataValue = _level1SeriesDataValue;
                    Util.ChartUtil.Level1SeriesDataDrillDown = _level1SeriesDataDrillDown;
                    Util.ChartUtil.Level2XAxisTitle = _paramChart["Level2XAxisTitle"].ToString();
                    Util.ChartUtil.Level2YAxisTitle = _paramChart["Level2YAxisTitle"].ToString();
                    Util.ChartUtil.Level2SeriesId = _level2SeriesId;
                    Util.ChartUtil.Level2SeriesName = _level2SeriesName;
                    Util.ChartUtil.Level2SeriesColorByPoint = true;
                    Util.ChartUtil.Level2SeriesDataName = _level2SeriesDataName;
                    Util.ChartUtil.Level2SeriesDataColor = _level2SeriesDataColor;
                    Util.ChartUtil.Level2SeriesDataValue = _level2SeriesDataValue;
                    Util.ChartUtil.Level2SeriesDataDrillDown = _level2SeriesDataDrillDown;
                    Util.ChartUtil.Level3XAxisTitle = _paramChart["Level3XAxisTitle"].ToString();;
                    Util.ChartUtil.Level3YAxisTitle = _paramChart["Level3YAxisTitle"].ToString();;
                    Util.ChartUtil.Level3SeriesId = _level3SeriesId;
                    Util.ChartUtil.Level3SeriesName = _level3SeriesName;
                    Util.ChartUtil.Level3SeriesColorByPoint = true;
                    Util.ChartUtil.Level3SeriesDataName = _level3SeriesDataName;
                    Util.ChartUtil.Level3SeriesDataColor = _level3SeriesDataColor;
                    Util.ChartUtil.Level3SeriesDataValue  = _level3SeriesDataValue;
                    Util.ChartUtil.Level3SeriesDataDrillDown = _level3SeriesDataDrillDown;
                    Util.ChartUtil.Level4XAxisTitle = _paramChart["Level4XAxisTitle"].ToString();
                    Util.ChartUtil.Level4YAxisTitle = _paramChart["Level4YAxisTitle"].ToString();
                    Util.ChartUtil.Level4SeriesId = _level4SeriesId;
                    Util.ChartUtil.Level4SeriesName = _level4SeriesName;
                    Util.ChartUtil.Level4SeriesColorByPoint = true;
                    Util.ChartUtil.Level4SeriesDataName = _level4SeriesDataName;
                    Util.ChartUtil.Level4SeriesDataColor = _level4SeriesDataColor;
                    Util.ChartUtil.Level4SeriesDataValue = _level4SeriesDataValue;
                    Util.ChartUtil.Level4SeriesDataDrillDown = _level4SeriesDataDrillDown;
                }
            }
        }

        public class ViewTableUI
        {
            private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTVIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Main = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel2Main = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN.ToLower();
            private static string _idSectionLevel1Progress = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS.ToLower();
            private static string _idSectionLevel2Progress = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS.ToLower();

            public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
            {
                StringBuilder _html = new StringBuilder();

                switch (_section)
                {
                    case "MAIN" :
                        _html.AppendLine(SectionMainUI.GetMain(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN).ToString());
                        _html.AppendLine(SectionMainUI.GetMain(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN).ToString());
                        break;
                    case "LEVEL1PROGRESSEXPORT":
                        _html = ePFStaffUI.GetFrmProgressData(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS, _idSectionLevel1Progress);
                        break;
                    case "LEVEL2PROGRESSEXPORT":
                        _html = ePFStaffUI.GetFrmProgressData(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS, _idSectionLevel2Progress);
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
                    int _cookieError = Util.ChkCookie(ePFStaffUtil._myParamSearchCookieName);
                    string _idSection = String.Empty;
                    bool _show = false;
                    bool _sublevel = true;
                    
                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _idSection = _idSectionLevel1Main;
                        _sublevel = false;
                        
                        if (_cookieError.Equals(0))
                        {
                            HttpCookie _objCookie = Util.GetCookie(ePFStaffUtil._myParamSearchCookieName);
                            if (_objCookie["Command"].Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN))
                            {
                                _show = true;
                                _searchResult = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetSearch(_page, ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN, null, true));
                            }
                        }
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN))
                        _idSection = _idSectionLevel2Main;

                    _html.AppendFormat("<div class='table{0}' id='{1}-table'>", (_sublevel.Equals(true) ? " table-level hidden" : ""), _idSection);
                    _html.AppendLine("      <div class='table-layout'>");
                    _html.AppendLine("          <div class='table-content'>");
                    _html.AppendLine("              <div class='table-freeze sticky'>");
                    _html.AppendLine("                  <div class='table-title'>");
                    _html.AppendLine("                      <div class='contentbody-left table-subject'></div>");
                    _html.AppendLine("                      <div class='contentbody-left button'>");
                    _html.AppendLine("                          <div class='button-layout'>");
                    _html.AppendLine("                              <div class='button-content'>");
                    _html.AppendLine("                                  <ul class='button-style2'>");
                    _html.AppendFormat("                                    <li class='{0}'><div class='click-button en-label button-export{1}' alt='{1}'>Export</div></li>", (_sublevel.Equals(true) ? "" : "nomargin"), ePFStaffUtil._selectOption[0].ToLower());
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

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg'><div class='th-label'>รายการ</div><div class='en-label'>Summary of Student</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>จำนวนนักศึกษาชาย ( คน )</div><div class='en-label'>Number of Student Male ( people )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>จำนวนนักศึกษาหญิง ( คน )</div><div class='en-label'>Number of Student Female ( people )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>รวมจำนวนนักศึกษา ( คน )</div><div class='en-label'>Summary Number of Student ( people )</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN))
                    {
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Class</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Date</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Graduation</div><div class='en-label'>Date</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='en-label'>Reason of</div><div class='en-label'>Graduation</div></div></div>");
                        _html.AppendLine("                      <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='en-label'>Student Records</div><div class='en-label'>Status</div></div></div>");
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

                public static StringBuilder GetList(string _page, Dictionary<string, object> _infoLogin, DataSet _ds, DataRow[] _dr)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _tb1 = new Dictionary<string, object>();
                    Dictionary<string, object> _tb2 = new Dictionary<string, object>();
                    Dictionary<string, object> _tb3 = new Dictionary<string, object>();
                    Dictionary<string, object> _tb4 = new Dictionary<string, object>();
                    DataTable _dt = new DataTable();
                    string _seriesDataNameTH = String.Empty;
                    string _seriesDataNameEN = String.Empty;
                    string _valueLevel = String.Empty;
                    string _valueFirstLevel = String.Empty;
                    string _valueSecondLevel = String.Empty;
                    string _valueThirdLevel = String.Empty;
                    string _valueLastLevel = String.Empty;
                    string _drilldownLevel = String.Empty;
                    string _drilldownFirstLevel = String.Empty;
                    string _drilldownSecondLevel = String.Empty;
                    string _drilldownThirdLevel = String.Empty;
                    string _drilldownLastLevel = String.Empty;
                    string _highlight = String.Empty;
                    string _callFunc = String.Empty;
                    int _i = 0;

                    if (_ds.Tables[0].Rows.Count > 0)
                    {
                        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_MAIN))
                        {
                            _dt = ePFStaffUtil.SetColumnDataTable(_page);
                            
                            _tb1.Add("Index", "");
                            _tb1.Add("DataLevel", "");
                            _tb1.Add("DataId", "");
                            _tb1.Add("Id", "");
                            _tb1.Add("SeriesDataName1", "");
                            _tb1.Add("SeriesDataName2", "");
                            _tb1.Add("Value1", "");
                            _tb1.Add("Value2", "");
                            _tb1.Add("DrillDownId", "");

                            _tb2.Add("Index", "");
                            _tb2.Add("DataLevel", "");
                            _tb2.Add("DataId", "");
                            _tb2.Add("Id","");
                            _tb2.Add("SeriesDataName1", "");
                            _tb2.Add("SeriesDataName2", "");
                            _tb2.Add("Value1", "");
                            _tb2.Add("Value2", "");
                            _tb2.Add("DrillDownId", "");

                            _tb3.Add("Index", "");
                            _tb3.Add("DataLevel", "");
                            _tb3.Add("DataId", "");
                            _tb3.Add("Id", "");
                            _tb3.Add("SeriesDataName1", "");
                            _tb3.Add("SeriesDataName2", "");
                            _tb3.Add("Value1", "");
                            _tb3.Add("Value2", "");
                            _tb3.Add("DrillDownId", "");

                            _tb4.Add("Index", "");
                            _tb4.Add("DataLevel", "");
                            _tb4.Add("DataId", "");
                            _tb4.Add("Id", "");
                            _tb4.Add("SeriesDataName1", "");
                            _tb4.Add("SeriesDataName2", "");
                            _tb4.Add("Value1", "");
                            _tb4.Add("Value2", "");
                            _tb4.Add("DrillDownId", "");
                            
                            _tb1["Index"] = 2;
                            _tb1["DataLevel"] = "StudentStatus";
                            _tb1["DataId"] = "statusGroup";
                            _tb1["Id"] = "";
                            _tb1["SeriesDataName1"] = "statusGroupNameTH";
                            _tb1["SeriesDataName2"] = "statusGroupNameEN";
                            _tb1["Value1"] = "countMalePeople";
                            _tb1["Value2"] = "countFemalePeople";
                            _tb1["DrillDownId"] = "drilldownId";

                            _tb2["Index"] = 3;
                            _tb2["DataLevel"] = "StudentStatus->YearAttended";
                            _tb2["DataId"] = "yearEntry";
                            _tb2["Id"] = "id";
                            _tb2["SeriesDataName1"] = "yearEntry";
                            _tb2["SeriesDataName2"] = "";
                            _tb2["Value1"] = "countMalePeople";
                            _tb2["Value2"] = "countFemalePeople";
                            _tb2["DrillDownId"] = "drilldownId";

                            _tb3["Index"] = 4;
                            _tb3["DataLevel"] = "StudentStatus->YearAttended->Faculty";
                            _tb3["DataId"] = "facultyId";
                            _tb3["Id"] = "id";
                            _tb3["SeriesDataName1"] = "faculty";
                            _tb3["SeriesDataName2"] = "facultyNameTH";
                            _tb3["Value1"] = "countMalePeople";
                            _tb3["Value2"] = "countFemalePeople";
                            _tb3["DrillDownId"] = "drilldownId";

                            _tb4["Index"] = 5;
                            _tb4["DataLevel"] = "StudentStatus->YearAttended->Faculty->Program";
                            _tb4["DataId"] = "programId";
                            _tb4["Id"] = "id";
                            _tb4["SeriesDataName1"] = "program";
                            _tb4["SeriesDataName2"] = "programNameTH";
                            _tb4["Value1"] = "countMalePeople";
                            _tb4["Value2"] = "countFemalePeople";
                            _tb4["DrillDownId"] = "drilldownId";

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _tb1["Index"] = 6;
                            _tb1["DataLevel"] = "Degree";
                            _tb1["DataId"] = "degree";
                            _tb1["SeriesDataName1"] = "degreeLevelNameTH";
                            _tb1["SeriesDataName2"] = "degreeLevelNameEN";

                            _tb2["Index"] = 7;
                            _tb2["DataLevel"] = "Degree->YearAttended";

                            _tb3["Index"] = 8;
                            _tb3["DataLevel"] = "Degree->YearAttended->Faculty";

                            _tb4["Index"] = 9;
                            _tb4["DataLevel"] = "Degree->YearAttended->Faculty->Program";

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _tb1["Index"] = 10;
                            _tb1["DataLevel"] = "YearAttended";
                            _tb1["DataId"] = "yearEntry";
                            _tb1["SeriesDataName1"] = "yearEntry";
                            _tb1["SeriesDataName2"] = "";

                            _tb2["Index"] = 11;
                            _tb2["DataLevel"] = "YearAttended->Faculty";
                            _tb2["DataId"] = "facultyId";
                            _tb2["SeriesDataName1"] = "faculty";
                            _tb2["SeriesDataName2"] = "facultyNameTH";

                            _tb3["Index"] = 12;
                            _tb3["DataLevel"] = "YearAttended->Faculty->Program";
                            _tb3["DataId"] = "programId";
                            _tb3["SeriesDataName1"] = "program";
                            _tb3["SeriesDataName2"] = "programNameTH";

                            _tb4["Index"] = -1;

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _tb1["Index"] = 13;
                            _tb1["DataLevel"] = "AdmissionType";
                            _tb1["DataId"] = "perEntranceTypeId";
                            _tb1["SeriesDataName1"] = "stdEntranceTypeNameTH";
                            _tb1["SeriesDataName2"] = "stdEntranceTypeNameEN";

                            _tb2["Index"] = 14;
                            _tb2["DataLevel"] = "AdmissionType->YearAttended";
                            _tb2["DataId"] = "yearEntry";
                            _tb2["SeriesDataName1"] = "yearEntry";
                            _tb2["SeriesDataName2"] = "";

                            _tb3["Index"] = 15;
                            _tb3["DataLevel"] = "AdmissionType->YearAttended->Faculty";
                            _tb3["DataId"] = "facultyId";
                            _tb3["SeriesDataName1"] = "faculty";
                            _tb3["SeriesDataName2"] = "facultyNameTH";

                            _tb4["Index"] = 16;
                            _tb4["DataLevel"] = "AdmissionType->YearAttended->Faculty->Program";
                            _tb4["DataId"] = "programId";
                            _tb4["SeriesDataName1"] = "program";
                            _tb4["SeriesDataName2"] = "programNameTH";

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _tb1["Index"] = 17;
                            _tb1["DataLevel"] = "Class";
                            _tb1["DataId"] = "class";
                            _tb1["SeriesDataName1"] = "class";
                            _tb1["SeriesDataName2"] = "";

                            _tb2["Index"] = 18;
                            _tb2["DataLevel"] = "Class->YearAttended";

                            _tb3["Index"] = 19;
                            _tb3["DataLevel"] = "Class->YearAttended->Faculty";

                            _tb4["Index"] = 20;
                            _tb4["DataLevel"] = "Class->YearAttended->Faculty->Program";

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _tb1["Index"] = 21;
                            _tb1["DataLevel"] = "Nationality";
                            _tb1["DataId"] = "perNationalityId";
                            _tb1["SeriesDataName1"] = "isoNationalityName3Letter";
                            _tb1["SeriesDataName2"] = "";

                            _tb2["Index"] = 22;
                            _tb2["DataLevel"] = "Nationality->YearAttended";

                            _tb3["Index"] = 23;
                            _tb3["DataLevel"] = "Nationality->YearAttended->Faculty";

                            _tb4["Index"] = 24;
                            _tb4["DataLevel"] = "Nationality->YearAttended->Faculty->Program";

                            _dt = ePFStaffOurServicesUtil.SummaryNumberOfStudentUtil.ViewTableUtil.GetList(_ds, _dt, _tb1, _tb2, _tb3, _tb4);
                            
                            _html.AppendLine("<div class='table-grid'>");

                            foreach (DataRow _dr1 in _dt.Rows)
                            {
                                _valueLevel = (ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN + "," + (!String.IsNullOrEmpty(_dr1["OrderLevel"].ToString()) ? _dr1["OrderLevel"] : "FirstLevel") + "," + _dr1["DataLevel"]);
                                
                                if (_dr1["OrderLevel"].Equals("ZeroLevel"))
                                {
                                    _html.AppendLine("<div class='table-row zero-level'>");
                                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1'><div class='table-col-msg title-level'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></div></div>", _dr1["ItemTH"], _dr1["ItemEN"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",M," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountMalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",F," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountFemalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["SummaryPeople"]);
                                    _html.AppendLine("</div>");
                                }

                                if (_dr1["OrderLevel"].Equals("FirstLevel") || String.IsNullOrEmpty(_dr1["OrderLevel"].ToString()))
                                {
                                    _seriesDataNameTH = _dr1["ItemTH"].ToString();
                                    _seriesDataNameEN = (!String.IsNullOrEmpty(_seriesDataNameTH) && (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString())) ? (" : " + _dr1["ItemEN"]) : "");
                                    _valueFirstLevel = (_dr1["DataId"] + "," + _dr1["ItemTH"] + "," + (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString()) ? _dr1["ItemEN"] : _dr1["ItemTH"]));
                                    _drilldownFirstLevel = _dr1["DrillDownId"].ToString();

                                    _html.AppendFormat("<div class='table-row table-subrow {0}'>", (!String.IsNullOrEmpty(_dr1["OrderLevel"].ToString()) ? "first-level" : ""));
                                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1' alt='{0}' id='table-row-id-{0}'><div class='table-col-msg title-level title-level1'><div><span class='{1}'>{2}</span><span class='th-label'>{3}</span><span class='en-label'>{4}</span></div></div></div>", _drilldownFirstLevel.ToLower(), (!String.IsNullOrEmpty(_dr1["OrderLevel"].ToString()) ? "collapse" : "collapse last-collapse") , (!String.IsNullOrEmpty(_dr1["OrderLevel"].ToString()) ? "+" : "-"), _seriesDataNameTH, _seriesDataNameEN);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",M," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountMalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",F," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountFemalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["SummaryPeople"]);
                                    _html.AppendLine("  </div>");

                                    _i = 1;
                                }
                                
                                if (_dr1["OrderLevel"].Equals("SecondLevel"))
                                {
                                    _seriesDataNameTH = _dr1["ItemTH"].ToString();
                                    _seriesDataNameEN = (!String.IsNullOrEmpty(_seriesDataNameTH) && (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString())) ? (" : " + _dr1["ItemEN"]) : "");
                                    _valueSecondLevel = (_dr1["DataId"] + "," + _dr1["ItemTH"] + "," + (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString()) ? _dr1["ItemEN"] : _dr1["ItemTH"]));                                    
                                    _drilldownSecondLevel = _dr1["DrillDownId"].ToString();

                                    _html.AppendFormat("<div class='table-row table-subrow second-level {0} table-row-id-{0}'>", _drilldownFirstLevel.ToLower());
                                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1' alt='{0}' id='table-row-id-{0}'><div class='table-col-msg title-level title-level2'><div><span class='{1}'>{2}</span><span class='th-label'>{3}</span><span class='en-label'>{4}</span></div></div></div>", _drilldownSecondLevel.ToLower(), "collapse", "+", _seriesDataNameTH, _seriesDataNameEN);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",M," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountMalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",F," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountFemalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["SummaryPeople"]);
                                    _html.AppendLine("  </div>");

                                    _i = 2;
                                }
                                
                                if (_dr1["OrderLevel"].Equals("ThirdLevel"))
                                {
                                    _seriesDataNameTH = _dr1["ItemTH"].ToString();
                                    _seriesDataNameEN = (!String.IsNullOrEmpty(_seriesDataNameTH) && (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString())) ? (" : " + _dr1["ItemEN"]) : "");
                                    _valueThirdLevel = (_dr1["DataId"] + "," + _dr1["ItemTH"] + "," + (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString()) ? _dr1["ItemEN"] : _dr1["ItemTH"]));
                                    _drilldownThirdLevel = _dr1["DrillDownId"].ToString();

                                    _html.AppendFormat("<div class='table-row table-subrow third-level {0} {1} table-row-id-{1}'>", _drilldownFirstLevel.ToLower(), _drilldownSecondLevel.ToLower());
                                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1' alt='{0}' id='table-row-id-{0}'><div class='table-col-msg title-level title-level3'><div><span class='{1}'>{2}</span><span class='th-label'>{3}</span><span class='en-label'>{4}</span></div></div></div>", _drilldownThirdLevel.ToLower(), "collapse", "+", _seriesDataNameTH, _seriesDataNameEN);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",M," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountMalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",F," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountFemalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["SummaryPeople"]);
                                    _html.AppendLine("  </div>");

                                    _i = 3;
                                }
                                
                                if (_dr1["OrderLevel"].Equals("LastLevel"))
                                {
                                    _seriesDataNameTH = _dr1["ItemTH"].ToString();
                                    _seriesDataNameEN = (!String.IsNullOrEmpty(_seriesDataNameTH) && (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString())) ? (" : " + _dr1["ItemEN"]) : "");
                                    _valueLastLevel = (_dr1["DataId"] + "," + _dr1["ItemTH"] + "," + (!String.IsNullOrEmpty(_dr1["ItemEN"].ToString()) ? _dr1["ItemEN"] : _dr1["ItemTH"]));
                                    _drilldownLastLevel = _dr1["DrillDownId"].ToString();

                                    if (_i.Equals(1))
                                    {
                                        _drilldownLevel = _drilldownFirstLevel;
                                        _valueSecondLevel = _valueLastLevel;
                                        _valueLastLevel = "";
                                    }

                                    if (_i.Equals(2))
                                    {
                                        _drilldownLevel = _drilldownSecondLevel;
                                        _valueThirdLevel = _valueLastLevel;
                                        _valueLastLevel = "";
                                    }

                                    if (_i.Equals(3))
                                        _drilldownLevel  = _drilldownThirdLevel;

                                    _html.AppendFormat("<div class='table-row table-subrow last-level {0} {1} table-row-id-{2}'>", _drilldownFirstLevel.ToLower(), _drilldownSecondLevel.ToLower(), _drilldownLevel.ToLower());
                                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col1' alt='{0}' id='table-row-id-{0}'><div class='table-col-msg title-level title-level{1}'><div><span class='{2}'>{3}</span><span class='th-label'>{4}</span><span class='en-label'>{5}</span></div></div></div>", _drilldownLastLevel.ToLower(), (_i + 1), "collapse last-collapse", "-", _seriesDataNameTH, _seriesDataNameEN);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",M," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountMalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label link-click link-{0}' alt='{1}'>{2}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_SUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE.ToLower(), (_valueLevel + ",F," + _valueFirstLevel + "," + _valueSecondLevel + "," + _valueThirdLevel + "," + _valueLastLevel), _dr1["CountFemalePeople"]);
                                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["SummaryPeople"]);
                                    _html.AppendLine("  </div>");
                                }
                            }

                            _html.AppendLine("</div>");
                        }

                        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_MAIN))
                        {
                            _html.AppendLine("<div class='table-grid'>");
                            
                            foreach (DataRow _dr1 in _dr)
                            {
                                _highlight = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                                _callFunc = "Util.gotoPage({" +
                                            "page:('index.aspx?p=" + ePFStaffUtil.PAGE_STUDENTRECORDSSTUDENTCV_MAIN + "&id=" + _dr1["id"] + "')," +
                                            "target:'_blank'" +
                                            "})";

                                _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                                _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper());
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["class"].ToString()) ? _dr1["class"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-admissiondate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["admissionDate"].ToString()) ? DateTime.Parse(_dr1["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11' onclick={0}><div class='table-col-msg'><div class='th-label table-col-graduatedate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["graduateDate"].ToString()) ? DateTime.Parse(_dr1["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='th-label {0} table-col-reasonofgraduation' alt='{1}'>{2}</div></div></div>", (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_VIEWMESSAGE.ToLower()) : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? _dr1["updateReason"].ToString() : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? "Message" : String.Empty));
                                _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col13' {0}><div class='table-col-msg'><div class='th-label {1}' alt='{2}'>{3}</div></div></div>", (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ("onclick=" + _callFunc) : ""), (_dr1["studentRecordsStatus"].ToString().Equals("N") ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_TOPICSSTUDENTRECORDSSTATUSNOTCOMPLETE.ToLower()) : ""), _dr1["id"], (!String.IsNullOrEmpty(_dr1["studentRecordsStatus"].ToString()) ? (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ePFStaffUtil._studentRecordsStatus[0, 2] : ePFStaffUtil._studentRecordsStatus[1, 2]) : String.Empty));
                                _html.AppendLine("  </div>");
                            }
                            
                            _html.AppendLine("</div>");
                        }
                    }

                    return _html;
                }
            }
        }
    }

    public class TransactionLogStudentRecordsUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_SEARCH.ToLower();
        private static string _idSectionView = ePFStaffUtil.ID_SECTION_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_VIEW.ToLower();

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
                case "VIEW":
                    _html = SectionViewUI.GetMain(_id);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain()
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN, _infoData);
                Dictionary<string, object> _searchResult = new Dictionary<string, object>();
                StringBuilder _html = new StringBuilder();
                int _cookieError = Util.ChkCookie(ePFStaffUtil._myParamSearchCookieName);
                int _i = 0;
                bool _show = false;
                
                if (_cookieError.Equals(0))
                {
                    HttpCookie _objCookie = Util.GetCookie(ePFStaffUtil._myParamSearchCookieName);

                    if (_objCookie["Command"].Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN))
                    {
                        _show = true;
                        _searchResult = ePFStaffOurServicesUtil.TransactionLogStudentRecordsUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN, null, true));
                    }
                }
                
                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendLine("                      <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Class</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Graduation</div><div class='en-label'>Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='en-label'>Reason of</div><div class='en-label'>Graduation</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='en-label'>Student Records</div><div class='en-label'>Status</div></div></div>");
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
                        _callFunc = "Util.tut.tos.transactionlogstudentrecords.sectionView.getFrm({" +
                                    "id:'" + _dr1["id"] + "'" +
                                    "})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper());
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["class"].ToString()) ? _dr1["class"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label table-col-admissiondate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["admissionDate"].ToString()) ? DateTime.Parse(_dr1["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11' onclick={0}><div class='table-col-msg'><div class='th-label table-col-graduatedate'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["graduateDate"].ToString()) ? DateTime.Parse(_dr1["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='th-label {0} table-col-reasonofgraduation' alt='{1}'>{2}</div></div></div>", (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_VIEWMESSAGE.ToLower()) : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? _dr1["updateReason"].ToString() : String.Empty), (_dr1["statusGroup"].ToString().Equals("02") && !String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? "Message" : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col13' {0}><div class='table-col-msg'><div class='th-label {1}' alt='{2}'>{3}</div></div></div>", (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ("onclick=" + _callFunc) : ""), (_dr1["studentRecordsStatus"].ToString().Equals("N") ? ("link-click link-" + ePFStaffUtil.SUBJECT_SECTION_TOPICSSTUDENTRECORDSSTATUSNOTCOMPLETE.ToLower()) : ""), _dr1["id"], (!String.IsNullOrEmpty(_dr1["studentRecordsStatus"].ToString()) ? (_dr1["studentRecordsStatus"].ToString().Equals("Y") ? ePFStaffUtil._studentRecordsStatus[0, 2] : ePFStaffUtil._studentRecordsStatus[1, 2]) : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[11];
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + ePFStaffUI.GetComboboxDegreeLevel(_idSectionSearch + "-degreelevel") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-faculty-combobox'>" + ePFStaffUI.GetComboboxFaculty(_idSectionSearch + "-faculty") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yearattended-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-yeargraduate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ปีที่สำเร็จการศึกษา</span><span class='en-label'> : Year Graduate</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-yeargraduate-combobox'>" + ePFStaffUI.GetComboboxYearAttended(_idSectionSearch + "-yeargraduate") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-class"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ชั้นปี</span><span class='en-label'> : Class</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-class-combobox'>" + ePFStaffUI.GetComboboxClass(_idSectionSearch + "-class") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Class", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระบบการสอบเข้า</span><span class='en-label'> : Admission Type</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-entrancetype-combobox'>" + ePFStaffUI.GetComboboxEntranceType(_idSectionSearch + "-entrancetype") + "</div>"));
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentstatus-combobox'>" + ePFStaffUI.GetComboboxStudentStatus(_idSectionSearch + "-studentstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-studentrecordsstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการบันทึกระเบียนประวัตินักศึกษา</span><span class='en-label'> : Student Records Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-studentrecordsstatus-combobox'>" + ePFStaffUI.GetComboboxStudentRecordsStatus(_idSectionSearch + "-studentrecordsstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentRecordsStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol2'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffOurServicesUtil.ExportStudentRecordsInformationUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), ePFStaffUtil._sortExpression));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine("                  <div class='search-floatcol search-floatcol1'>");
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendFormat("                    <div class='contentbody-left'>{0}</div>", ePFStaffUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentRecordsStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN);
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

        public class SectionViewUI
        {
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                Dictionary<string, object> _valueDataRecorded = ePFStaffUtil.SetValueDataRecorded(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSSTUDENTRECORDS];
                int _i = 0;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", _dataRecorded["StudentCode"]);
        
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionView + "-studentid"));
                _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
                _contentFrmColumnDetail[_i].Add("TitleTH", "รหัสนักศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Student ID");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("StudentID", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", Util.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString()));
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", Util.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper());

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionView + "-studentname"));
                _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ - นามสกุล");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Full Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FullName", _contentFrmColumnDetail[_i]);

                _html.AppendFormat("<div class='dialog-form form detail' id='{0}-form'>", _idSectionView);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendFormat("            <input type='hidden' id='{0}-personid-hidden' value='{1}' />", _idSectionView, _id);
                _html.AppendLine("              <div>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentID"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["FullName"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='tabbar'>");
                _html.AppendLine("          <div class='tabbar-layout'>");
                _html.AppendLine("              <div class='tabbar-content'>");
                _html.AppendLine("                  <ul>");

                for (_i = 0; _i < ePFStaffUtil._personRecordsMenu.GetLength(0); _i++)
                {
                    _html.AppendFormat("                <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStaffUtil._personRecordsMenu[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        (_idSectionView + ePFStaffUtil._personRecordsMenu[_i, 3]).ToLower(),
                        ePFStaffUtil._personRecordsMenu[_i, 0],
                        ePFStaffUtil._personRecordsMenu[_i, 1]
                    );
                }

                _html.AppendLine("                  </ul>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='tabbar-form'>");
                _html.AppendLine("          <div class='tabbar-form-layout'>");
                _html.AppendLine("              <div class='tabbar-form-content'>");
                _html.AppendFormat("                <div class='tab-active' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_STUDENTRECORDS.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSSTUDENTRECORDS_VIEW, ViewTableUI.GetMain(_id, ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSSTUDENTRECORDS_VIEW));
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_PERSONAL.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSPERSONAL_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_ADDRESS.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSADDRESS_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_EDUCATION.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSEDUCATION_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_TALENT.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSTALENT_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_HEALTHY.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSHEALTHY_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_WORK.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSWORK_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_FINANCIAL.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFINANCIAL_VIEW, String.Empty);
                _html.AppendFormat("                <div class='tab-noactive' id='{0}' alt='{1}' align='center'>{2}</div>", (_idSectionView + ePFStaffUtil.SUBJECT_SECTION_FAMILY.ToLower()), ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFAMILY_VIEW, String.Empty);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }

            public class ViewTableUI
            {
                public static StringBuilder GetMain(string _id, string _page)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _searchResult = ePFStaffOurServicesUtil.TransactionLogStudentRecordsUtil.GetSearch(_id, _page);

                    _html.AppendLine("<div class='table table-width-dynamic'>");
                    _html.AppendLine("  <div class='table-layout'>");
                    _html.AppendLine("      <div class='table-content'>");
                    _html.AppendLine("          <div class='table-freeze'>");
                    _html.AppendLine("              <div class='table-title'>");
                    _html.AppendLine("                  <div class='contentbody-left'></div>");
                    _html.AppendLine("                  <div class='contentbody-right table-recordcount en-label'>");
                    _html.AppendLine("                      <span class='recordcount-search hidden'></span>");
                    _html.AppendFormat("                    <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                    _html.AppendLine("                      <span class='recordcountsecondary-search th-label'></span>");
                    _html.AppendLine("                  </div>");
                    _html.AppendLine("              </div>");
                    _html.AppendLine("              <div class='clear'></div>");
                    _html.AppendLine("              <div class='table-head'>");
                    _html.AppendLine("                  <div class='table-row'>");
                    _html.AppendLine("                      <div class='table-col table-col1'><div class='table-col-msg'><div class='en-label'>Transaction Log ID</div></div></div>");
                    _html.AppendLine("                      <div class='table-col'><div class='table-col-msg'><div class='en-label'>Created Date</div></div></div>");
                    _html.AppendLine("                      <div class='table-col'><div class='table-col-msg'><div class='en-label'>Created By</div></div></div>");
                    _html.AppendLine("                      <div class='table-col'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                    _html.AppendLine("                      <div class='table-col'><div class='table-col-msg'><div class='en-label'>Modify By</div></div></div>");


                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSSTUDENTRECORDS_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Education Level</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Program Year</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Attended</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Academic Year</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year of Course</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Class</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Admission Type</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Student Status</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Admission Date</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Graduation Date</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Graduation Year</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>MSP Join Status</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>MSP Start Semester / Year</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>MSP End Semester / Year</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>MSP Resign Date</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Regis Extra</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Picture Name</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Update Grad Date</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Update Grad By</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Update What</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Update What</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Update Reason</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSPERSONAL_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>ID Card</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Gender</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Gender</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Alive</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Date of Birth</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Nationality</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Nationality</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Race</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Race</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Religion</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Religion</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Blood Group</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Marital Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Marital Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Email Address</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Number of Siblings ( including myself )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sequence Child</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Number of Siblings Still Studying ( including myself )</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSADDRESS_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Type ( Permanent )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Type ( Permanent) </div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Permanent )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Permanent )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Permanent )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Permanent )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>District / Area ( Permanent )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>District / Area ( Permanent )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sub-district / Sub-area ( Permanent )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sub-district / Sub-area ( Permanent )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>ZIP / Postal Code ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Village ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Number ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Village No. ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Lane / Alley ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Road ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Phone Number ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Mobile Number ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Fax Number ( Permanent )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Type ( Current )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Type ( Current) </div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Current )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Current )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Current )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Current )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>District / Area ( Current )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>District / Area ( Current )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sub-district / Sub-area ( Current )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sub-district / Sub-area ( Current )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>ZIP / Postal Code ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Village ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Address Number ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Village No. ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Lane / Alley ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Road ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Phone Number ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Mobile Number ( Current )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Fax Number ( Current )</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSEDUCATION_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>School Name ( Primary School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Primary School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Primary School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Primary School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Primary School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Attended ( Primary School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Graduation ( Primary School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Grade Point Average ( GPA ) ( Primary School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>School Name ( Junior High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Junior High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( Junior High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Junior High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( Junior High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Attended ( Junior High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Graduation ( Junior High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Grade Point Average ( GPA ) ( Junior High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>School Name ( High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Country ( High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Province ( High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Students Identification Number ( High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Major ( High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Major ( High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Attended ( High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Year Graduation ( High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Grade Point Average ( GPA ) ( High School )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background ( High School )</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background ( High School )</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Educational Background</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Graduate By</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Graduate By</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Graduate By School Name</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Number of Entrance Exams Taken</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Number of Entrance Exams Taken</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Being a University Student</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Being a University Student</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Being a University Student ( University )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Being a University Student ( Faculty )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Being a University Student ( Program )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Entrance Examination System</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Entrance Examination System</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Rank Selected Mahidol University</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Thai</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Social Science</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET English</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Mathematics</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Science</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Health Education & Physical Education</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Atrs</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores O-NET Occupation & Teachnology</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores A-NET Thai 2</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores A-NET Social Science 2</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores A-NET English 3</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores A-NET Mathematics 2</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores A-NET Science 2</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores GAT Genaral Aptitude Test</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 1 Aptitude In Mathematics</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 2 Aptitude In Science</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 3 Aptitude In Engineering</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 4 Aptitude In Architecture</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 5 Aptitude In Teaching</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 6 Aptitude In Arts</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.1 French Languages</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.2 Germany Languages</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.3 Japanese Languages</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.4 Chinese Languages</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.5 Arabic Languages</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scores PAT 7.6 Bali Languages</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSTALENT_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sportsman Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sportsman Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Sportsman Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Sport Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Sport Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Sport Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Art Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Art Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Art Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Technical Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Technical Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Technical Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Other Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Other Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Specialist Other Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Activity Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Activity Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Activity Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Reward Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Reward Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Reward Detail</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSHEALTHY_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Body Mass Index ( Weight, Height, BMI, Latest Update )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Drug Allergy History Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Drug Allergy History Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Drug Allergy History Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Diseases Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Diseases Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Diseases Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Family History of Illness Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Family History of Illness Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Family History of Illness Detail</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Travel Abroad Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Travel Abroad Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Travel Abroad Detail ( Country, Date of Travel )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Health Impairments Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Health Impairments Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Health Impairments Detail</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Health Impairments Detail</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>The Equipment Used for Assistance</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSWORK_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Occupation</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Occupation</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Agency</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Agency</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Agency Other</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Workplace</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Position</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Workplace Telephone</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Income ( bath )</div></div></div>");
                    }

                    if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFINANCIAL_VIEW))
                    {
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor From</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor From</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor Name</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship First Bachelor Money ( bath / yr )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor From</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor From</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor Name</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Scholarship Bachelor Money ( bath / yr )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Worked Status</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Worked Status</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Income of Work During Study ( bath / month )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Workplace of Work During Study</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Financial Support From</div><div class='en-label'>( TH )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Financial Support From</div><div class='en-label'>( EN )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Financial Support From Other</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Received Monthly Financial Support ( bath / month )</div></div></div>");
                        _html.AppendLine("                  <div class='table-col'><div class='table-col-msg'><div class='en-label'>Personal Expense Not Including Educational Fees ( bath / month )</div></div></div>");
                    }

                    _html.AppendLine("                  </div>");
                    _html.AppendLine("              </div>");
                    _html.AppendLine("          </div>");
                    _html.AppendFormat("        <div class='table-list'>{0}</div>", _searchResult["List"]);
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");
                    _html.AppendLine("</div>");

                    return _html;
                }
                
                public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr, string _page)
                {
                    StringBuilder _html = new StringBuilder();
                    string _highlight = String.Empty;
                    string _callFunc = String.Empty;
                    int _i = 1;

                    _html.AppendLine("<div class='table-grid'>");

                    if (_dr.GetLength(0) > 0)
                    {
                        foreach (DataRow _dr1 in _dr)
                        {
                            _highlight = (_i % 2) == 0 ? " highlight-style2" : " highlight-style1";

                            _html.AppendFormat("<div class='table-row{0}'>", _highlight);
                            _html.AppendFormat("    <div class='table-col table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", _dr1["id"].ToString());
                            _html.AppendFormat("    <div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                            _html.AppendFormat("    <div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createBy"].ToString()) ? _dr1["createBy"].ToString() : String.Empty));
                            _html.AppendFormat("    <div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                            _html.AppendFormat("    <div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyBy"].ToString()) ? _dr1["modifyBy"].ToString() : String.Empty));

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSSTUDENTRECORDS_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["degree"].ToString()) ? _dr1["degree"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["programYear"].ToString()) ? _dr1["programYear"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["acaYear"].ToString()) ? _dr1["acaYear"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["courseYear"].ToString()) ? _dr1["courseYear"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["class"].ToString()) ? _dr1["class"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>", ePFStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["admissionDate"].ToString()) ? DateTime.Parse(_dr1["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["graduateDate"].ToString()) ? DateTime.Parse(_dr1["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["graduateYear"].ToString()) ? _dr1["graduateYear"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mspJoin"].ToString()) ? _dr1["mspJoin"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mspStartSemester"].ToString()) && !String.IsNullOrEmpty(_dr1["mspStartYear"].ToString()) ? (_dr1["mspStartSemester"].ToString() + " / " + _dr1["mspStartYear"].ToString()) : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mspEndSemester"].ToString()) && !String.IsNullOrEmpty(_dr1["mspEndYear"].ToString()) ? (_dr1["mspEndSemester"].ToString() + " / " + _dr1["mspEndYear"].ToString()) : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mspResignDate"].ToString()) ? _dr1["mspResignDate"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["regisExtra"].ToString()) ? _dr1["regisExtra"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["pictureName"].ToString()) ? _dr1["pictureName"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["updateGradDate"].ToString()) ? DateTime.Parse(_dr1["updateGradDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["updateGradBy"].ToString()) ? _dr1["updateGradBy"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["updateWhatTH"].ToString()) ? _dr1["updateWhatTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["updateWhatEN"].ToString()) ? _dr1["updateWhatEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["updateReason"].ToString()) ? _dr1["updateReason"].ToString() : String.Empty));
                            }
            
                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSPERSONAL_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["idCard"].ToString()) ? _dr1["idCard"].ToString() : String.Empty));                                
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", Util.GetFullName(_dr1["titlePrefixInitialsEN"].ToString(), _dr1["titlePrefixFullNameEN"].ToString(), _dr1["firstNameEN"].ToString(), _dr1["middleNameEN"].ToString(), _dr1["lastNameEN"].ToString()).ToUpper());
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderFullNameTH"].ToString()) ? _dr1["genderFullNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderFullNameEN"].ToString()) ? _dr1["genderFullNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["alive"].ToString()) ? _dr1["alive"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["birthDate"].ToString()) ? DateTime.Parse(_dr1["birthDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTH"].ToString()) ? _dr1["countryNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameEN"].ToString()) ? _dr1["countryNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["nationalityNameTH"].ToString()) ? _dr1["nationalityNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["nationalityNameEN"].ToString()) ? _dr1["nationalityNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["originNameTH"].ToString()) ? _dr1["originNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["originNameEN"].ToString()) ? _dr1["originNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["religionNameTH"].ToString()) ? _dr1["religionNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["religionNameEN"].ToString()) ? _dr1["religionNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["bloodTypeNameEN"].ToString()) ? _dr1["bloodTypeNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["maritalStatusNameTH"].ToString()) ? _dr1["maritalStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["maritalStatusNameEN"].ToString()) ? _dr1["maritalStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameTH"].ToString()) ? _dr1["educationalBackgroundNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameEN"].ToString()) ? _dr1["educationalBackgroundNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["email"].ToString()) ? _dr1["email"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["brotherhoodNumber"].ToString()) ? _dr1["brotherhoodNumber"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["childhoodNumber"].ToString()) ? _dr1["childhoodNumber"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studyhoodNumber"].ToString()) ? _dr1["studyhoodNumber"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSADDRESS_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["addressTypeTHPermanent"].ToString()) ? _dr1["addressTypeTHPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["addressTypeENPermanent"].ToString()) ? _dr1["addressTypeENPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTHPermanent"].ToString()) ? _dr1["countryNameTHPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameENPermanent"].ToString()) ? _dr1["countryNameENPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTHPermanent"].ToString()) ? _dr1["provinceNameTHPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameENPermanent"].ToString()) ? _dr1["provinceNameENPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameTHPermanent"].ToString()) ? _dr1["districtNameTHPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameENPermanent"].ToString()) ? _dr1["districtNameENPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameTHPermanent"].ToString()) ? _dr1["subdistrictNameTHPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameENPermanent"].ToString()) ? _dr1["subdistrictNameENPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["zipCodePermanent"].ToString()) ? _dr1["zipCodePermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["villagePermanent"].ToString()) ? _dr1["villagePermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["noPermanent"].ToString()) ? _dr1["noPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mooPermanent"].ToString()) ? _dr1["mooPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["soiPermanent"].ToString()) ? _dr1["soiPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["roadPermanent"].ToString()) ? _dr1["roadPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["phoneNumberPermanent"].ToString()) ? _dr1["phoneNumberPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mobileNumberPermanent"].ToString()) ? _dr1["mobileNumberPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["faxNumberPermanent"].ToString()) ? _dr1["faxNumberPermanent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["addressTypeTHCurrent"].ToString()) ? _dr1["addressTypeTHCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["addressTypeENCurrent"].ToString()) ? _dr1["addressTypeENCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTHCurrent"].ToString()) ? _dr1["countryNameTHCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameENCurrent"].ToString()) ? _dr1["countryNameENCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTHCurrent"].ToString()) ? _dr1["provinceNameTHCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameENCurrent"].ToString()) ? _dr1["provinceNameENCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameTHCurrent"].ToString()) ? _dr1["districtNameTHCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameENCurrent"].ToString()) ? _dr1["districtNameENCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameTHCurrent"].ToString()) ? _dr1["subdistrictNameTHCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameENCurrent"].ToString()) ? _dr1["subdistrictNameENCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["zipCodeCurrent"].ToString()) ? _dr1["zipCodeCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["villageCurrent"].ToString()) ? _dr1["villageCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["noCurrent"].ToString()) ? _dr1["noCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mooCurrent"].ToString()) ? _dr1["mooCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["soiCurrent"].ToString()) ? _dr1["soiCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["roadCurrent"].ToString()) ? _dr1["roadCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["phoneNumberCurrent"].ToString()) ? _dr1["phoneNumberCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["mobileNumberCurrent"].ToString()) ? _dr1["mobileNumberCurrent"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["faxNumberCurrent"].ToString()) ? _dr1["faxNumberCurrent"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSEDUCATION_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteNamePrimarySchool"].ToString()) ? _dr1["instituteNamePrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTHPrimarySchool"].ToString()) ? _dr1["countryNameTHPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameENPrimarySchool"].ToString()) ? _dr1["countryNameENPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTHPrimarySchool"].ToString()) ? _dr1["provinceNameTHPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameENPrimarySchool"].ToString()) ? _dr1["provinceNameENPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearAttendedPrimarySchool"].ToString()) ? _dr1["yearAttendedPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearGraduatePrimarySchool"].ToString()) ? _dr1["yearGraduatePrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["GPAPrimarySchool"].ToString()) ? _dr1["GPAPrimarySchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteNameJuniorHighSchool"].ToString()) ? _dr1["instituteNameJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTHJuniorHighSchool"].ToString()) ? _dr1["countryNameTHJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameENJuniorHighSchool"].ToString()) ? _dr1["countryNameENJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTHJuniorHighSchool"].ToString()) ? _dr1["provinceNameTHJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameENJuniorHighSchool"].ToString()) ? _dr1["provinceNameENJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearAttendedJuniorHighSchool"].ToString()) ? _dr1["yearAttendedJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearGraduateJuniorHighSchool"].ToString()) ? _dr1["yearGraduateJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["GPAJuniorHighSchool"].ToString()) ? _dr1["GPAJuniorHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["instituteNameHighSchool"].ToString()) ? _dr1["instituteNameHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTHHighSchool"].ToString()) ? _dr1["countryNameTHHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameENHighSchool"].ToString()) ? _dr1["countryNameENHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTHHighSchool"].ToString()) ? _dr1["provinceNameTHHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameENHighSchool"].ToString()) ? _dr1["provinceNameENHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIdHighSchool"].ToString()) ? _dr1["studentIdHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalMajorNameTHHighSchool"].ToString()) ? _dr1["educationalMajorNameTHHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalMajorNameENHighSchool"].ToString()) ? _dr1["educationalMajorNameENHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearAttendedHighSchool"].ToString()) ? _dr1["yearAttendedHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["yearGraduateHighSchool"].ToString()) ? _dr1["yearGraduateHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["GPAHighSchool"].ToString()) ? _dr1["GPAHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameTHHighSchool"].ToString()) ? _dr1["educationalBackgroundNameTHHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameENHighSchool"].ToString()) ? _dr1["educationalBackgroundNameENHighSchool"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameTH"].ToString()) ? _dr1["educationalBackgroundNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameEN"].ToString()) ? _dr1["educationalBackgroundNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["graduateByTH"].ToString()) ? _dr1["graduateByTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["graduateByEN"].ToString()) ? _dr1["graduateByEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["graduateBySchoolName"].ToString()) ? _dr1["graduateBySchoolName"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTimeTH"].ToString()) ? _dr1["entranceTimeTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTimeEN"].ToString()) ? _dr1["entranceTimeEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIsTH"].ToString()) ? _dr1["studentIsTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIsEN"].ToString()) ? _dr1["studentIsEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIsUniversity"].ToString()) ? _dr1["studentIsUniversity"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIsFaculty"].ToString()) ? _dr1["studentIsFaculty"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["studentIsProgram"].ToString()) ? _dr1["studentIsProgram"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTypeNameTH"].ToString()) ? _dr1["entranceTypeNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTypeNameEN"].ToString()) ? _dr1["entranceTypeNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["admissionRanking"].ToString()) ? _dr1["admissionRanking"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET01"].ToString()) ? _dr1["scoreONET01"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET02"].ToString()) ? _dr1["scoreONET02"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET03"].ToString()) ? _dr1["scoreONET03"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET04"].ToString()) ? _dr1["scoreONET04"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET05"].ToString()) ? _dr1["scoreONET05"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET06"].ToString()) ? _dr1["scoreONET06"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET07"].ToString()) ? _dr1["scoreONET07"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreONET08"].ToString()) ? _dr1["scoreONET08"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreANET11"].ToString()) ? _dr1["scoreANET11"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreANET12"].ToString()) ? _dr1["scoreANET12"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreANET13"].ToString()) ? _dr1["scoreANET13"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreANET14"].ToString()) ? _dr1["scoreANET14"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreANET15"].ToString()) ? _dr1["scoreANET15"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scoreGAT85"].ToString()) ? _dr1["scoreGAT85"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT71"].ToString()) ? _dr1["scorePAT71"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT72"].ToString()) ? _dr1["scorePAT72"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT73"].ToString()) ? _dr1["scorePAT73"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT74"].ToString()) ? _dr1["scorePAT74"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT75"].ToString()) ? _dr1["scorePAT75"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT76"].ToString()) ? _dr1["scorePAT76"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT77"].ToString()) ? _dr1["scorePAT77"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT78"].ToString()) ? _dr1["scorePAT78"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT79"].ToString()) ? _dr1["scorePAT79"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT80"].ToString()) ? _dr1["scorePAT80"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT81"].ToString()) ? _dr1["scorePAT81"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scorePAT82"].ToString()) ? _dr1["scorePAT82"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSTALENT_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["sportsmanStatusNameTH"].ToString()) ? _dr1["sportsmanStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["sportsmanStatusNameEN"].ToString()) ? _dr1["sportsmanStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["sportsmanDetail"].ToString()) ? _dr1["sportsmanDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistStatusNameTH"].ToString()) ? _dr1["specialistStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistStatusNameEN"].ToString()) ? _dr1["specialistStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistSportStatusNameTH"].ToString()) ? _dr1["specialistSportStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistSportStatusNameEN"].ToString()) ? _dr1["specialistSportStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistSportDetail"].ToString()) ? _dr1["specialistSportDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistArtStatusNameTH"].ToString()) ? _dr1["specialistArtStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistArtStatusNameEN"].ToString()) ? _dr1["specialistArtStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistArtDetail"].ToString()) ? _dr1["specialistArtDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistTechnicalStatusNameTH"].ToString()) ? _dr1["specialistTechnicalStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistTechnicalStatusNameEN"].ToString()) ? _dr1["specialistTechnicalStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistTechnicalDetail"].ToString()) ? _dr1["specialistTechnicalDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistOtherStatusNameTH"].ToString()) ? _dr1["specialistOtherStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistOtherStatusNameEN"].ToString()) ? _dr1["specialistOtherStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["specialistOtherDetail"].ToString()) ? _dr1["specialistOtherDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["activityStatusNameTH"].ToString()) ? _dr1["activityStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["activityStatusNameEN"].ToString()) ? _dr1["activityStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["activityDetail"].ToString()) ? _dr1["activityDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["rewardStatusNameTH"].ToString()) ? _dr1["rewardStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["rewardStatusNameEN"].ToString()) ? _dr1["rewardStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["rewardDetail"].ToString()) ? _dr1["rewardDetail"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSHEALTHY_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["bodyMassDetail"].ToString()) ? _dr1["bodyMassDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["intoleranceStatusNameTH"].ToString()) ? _dr1["intoleranceStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["intoleranceStatusNameEN"].ToString()) ? _dr1["intoleranceStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["intoleranceDetail"].ToString()) ? _dr1["intoleranceDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["diseasesStatusNameTH"].ToString()) ? _dr1["diseasesStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["diseasesStatusNameEN"].ToString()) ? _dr1["diseasesStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["diseasesDetail"].ToString()) ? _dr1["diseasesDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["ailHistoryFamilyStatusNameTH"].ToString()) ? _dr1["ailHistoryFamilyStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["ailHistoryFamilyStatusNameEN"].ToString()) ? _dr1["ailHistoryFamilyStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["ailHistoryFamilyDetail"].ToString()) ? _dr1["ailHistoryFamilyDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["travelAbroadStatusNameTH"].ToString()) ? _dr1["travelAbroadStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["travelAbroadStatusNameEN"].ToString()) ? _dr1["travelAbroadStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["travelAbroadDetail"].ToString()) ? _dr1["travelAbroadDetail"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsStatusNameTH"].ToString()) ? _dr1["impairmentsStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsStatusNameEN"].ToString()) ? _dr1["impairmentsStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsNameTH"].ToString()) ? _dr1["impairmentsNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsNameEN"].ToString()) ? _dr1["impairmentsNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsEquipment"].ToString()) ? _dr1["impairmentsEquipment"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSWORK_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["occupationTH"].ToString()) ? _dr1["occupationTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["occupationEN"].ToString()) ? _dr1["occupationEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["agencyNameTH"].ToString()) ? _dr1["agencyNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["agencyNameEN"].ToString()) ? _dr1["agencyNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["agencyOther"].ToString()) ? _dr1["agencyOther"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["workplace"].ToString()) ? _dr1["workplace"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["position"].ToString()) ? _dr1["position"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["telephone"].ToString()) ? _dr1["telephone"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["salary"].ToString()) ? _dr1["salary"].ToString() : String.Empty));
                            }

                            if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDSFINANCIAL_VIEW))
                            {
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorStatusNameTH"].ToString()) ? _dr1["scholarshipFirstBachelorStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorStatusNameEN"].ToString()) ? _dr1["scholarshipFirstBachelorStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorFromTH"].ToString()) ? _dr1["scholarshipFirstBachelorFromTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorFromEN"].ToString()) ? _dr1["scholarshipFirstBachelorFromEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorName"].ToString()) ? _dr1["scholarshipFirstBachelorName"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipFirstBachelorMoney"].ToString()) ? _dr1["scholarshipFirstBachelorMoney"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorStatusTH"].ToString()) ? _dr1["scholarshipBachelorStatusTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorStatusEN"].ToString()) ? _dr1["scholarshipBachelorStatusEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorFromTH"].ToString()) ? _dr1["scholarshipBachelorFromTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorFromEN"].ToString()) ? _dr1["scholarshipBachelorFromEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorName"].ToString()) ? _dr1["scholarshipBachelorName"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["scholarshipBachelorMoney"].ToString()) ? _dr1["scholarshipBachelorMoney"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["workedStatusNameTH"].ToString()) ? _dr1["workedStatusNameTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["workedStatusNameEN"].ToString()) ? _dr1["workedStatusNameEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["salary"].ToString()) ? _dr1["salary"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["workplace"].ToString()) ? _dr1["workplace"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["gotMoneyFromTH"].ToString()) ? _dr1["gotMoneyFromTH"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["gotMoneyFromEN"].ToString()) ? _dr1["gotMoneyFromEN"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["gotMoneyFromOther"].ToString()) ? _dr1["gotMoneyFromOther"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["gotMoneyPerMonth"].ToString()) ? _dr1["gotMoneyPerMonth"].ToString() : String.Empty));
                                _html.AppendFormat("<div class='table-col'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["costPerMonth"].ToString()) ? _dr1["costPerMonth"].ToString() : String.Empty));
                            }

                            _html.AppendLine("  </div>");
            
                            _i++;
                        }
                    }
                    
                    _html.AppendLine("</div>");

                    return _html;
                }
            }
        }
    }
}