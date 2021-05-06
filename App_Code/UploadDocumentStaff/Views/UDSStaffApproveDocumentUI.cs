// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๔/๐๖/๒๕๕๘>
// Modify date  : <๐๖/๐๙/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการอนุมัตืเอกสาร>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class UDSStaffApproveDocumentUI
{
    private static string _idSectionMain    = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_MAIN.ToLower();
    private static string _idSectionSearch  = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_SEARCH.ToLower();
    private static string _idSectionEdit    = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_EDIT.ToLower();
    
    //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามส่วนที่ต้องการแสดงในส่วนของการอนุมัติเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _infoLogin     เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    //2. _section       เป็น string รับค่าส่วนที่ต้องการแสดง
    //3. _sectionAction เป็น string รับค่าการกระทำที่เกิดขึ้นกับส่วนที่ต้องการแสดง
    //4. _id            เป็น string รับค่ารหัสที่ต้องการ
    public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
    {                        
        StringBuilder _html = new StringBuilder();

        switch (_section)
        {
            case "MAIN"     : { _html = SectionMainUI.GetMain(); break; }
            case "SEARCH"   : { _html = SectionSearchUI.GetMain(); break; }
            case "EDIT"     : { _html = SectionAddUpdateUI.SectionEditUI.GetMain(_sectionAction, _id); break; }
        }

        return _html;
    }
    
    public class SectionMainUI
    {
        //ฟังก์ชั่นสำหรับแสดงหน้าหาหน้าหลักในส่วนของการอนุมัติเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
        public static StringBuilder GetMain()
        {
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN, _infoData);            
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            StringBuilder _html = new StringBuilder();
            int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
            int _i = 0;
            bool _show = false;

            if (_cookieError.Equals(0))
            {
                HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN))
                {                    
                    _show = true;
                    _searchResult = UDSStaffApproveDocumentUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN, null, true));
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
            _html.AppendLine("                          <div class='contentbody-right table-recordcount en-label'>");
            _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>",            (_show.Equals(true) ? double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0") : String.Empty));
            _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>",   (_show.Equals(true) ? double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0") : String.Empty));
            _html.AppendLine("                          </div>");
            _html.AppendLine("                      </div>");
            _html.AppendLine("                      <div class='clear'></div>");
            _html.AppendLine("                      <div class='table-head'>");
            _html.AppendLine("                          <div class='table-row'>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>ID</div></div></div>");        
            _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Admission</div><div class='en-label'>Type</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Student</div><div class='en-label'>Status</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Submitted Date</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Approval</div><div class='en-label'>Status</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Approval Date</div></div></div>");
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
            _html.AppendLine("                  <div class='menulist'>");
            _html.AppendLine("                      <div class='menulist-layout'>");
            _html.AppendLine("                          <div class='menulist-content'>");
            _html.AppendLine("                              <ul>");

            for (_i = 0; _i < UDSStaffApproveDocumentUtil._menu.GetLength(0); _i++)
            {
                _html.AppendFormat("                            <li class='have-link'><a class='link-click link-msg' id='link-{0}' alt='{1}' href='javascript:void(0)'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>", UDSStaffApproveDocumentUtil._menu[_i, 2].ToLower(), UDSStaffApproveDocumentUtil._menu[_i, 2], UDSStaffApproveDocumentUtil._menu[_i, 0], UDSStaffApproveDocumentUtil._menu[_i, 1]);
            }

            _html.AppendLine("                              </ul>");
            _html.AppendLine("                          </div>");
            _html.AppendLine("                          <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>Click to Select Document</a></div>");
            _html.AppendLine("                      </div>");
            _html.AppendLine("                  </div>");
            _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionEdit);
            _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionEdit);
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("</div>");

            return _html;
        }
        
        //ฟังก์ชั่นสำหรับแสดงรายการในส่วนของการอนุมัติเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
        //โดยมีพารามิเตอร์ดังนี้
        //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
        //2. _dr         เป็น DataRow[] รับค่าชุดของข้อมูล
        public static StringBuilder GetList(Dictionary<string, object> _infoLogin, DataRow[] _dr)
        {
            StringBuilder _html = new StringBuilder();
            string _userlevel = _infoLogin["Userlevel"].ToString();
            string _highlight = String.Empty;
            string _callFunc = String.Empty;            
            string _documentUpload = String.Empty;
            string _submittedStatus = String.Empty;
            string _submittedDate = String.Empty;
            string _approvalStatus = String.Empty;
            string _approvalDate = String.Empty;
            string _iconApprove = String.Empty;
            bool _documentUploadDual = false;
            int _i = 0;
            int _j = 0;
            int _k = 0;
        
            if (_dr.GetLength(0) > 0)
            {
                _html.AppendLine("<div class='table-grid'>");

                foreach (DataRow _dr1 in _dr)
                {
                    _documentUpload     = _dr1["documentUpload"].ToString().ToLower();
                    _submittedStatus    = String.Empty;
                    _submittedDate      = String.Empty;
                    _approvalStatus     = String.Empty;
                    _approvalDate       = String.Empty;
                    _iconApprove        = String.Empty;

                    if (!String.IsNullOrEmpty(_documentUpload))
                    {
                        if (_documentUpload.Equals(UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTUREIDCARD.ToLower()) ||
                            _documentUpload.Equals(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPT.ToLower()))
                        {
                            _documentUploadDual = true;

                            if (_documentUpload.Equals(UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTUREIDCARD.ToLower()))
                            {
                                _j = 1;
                                _k = 2;
                            }

                            if (_documentUpload.Equals(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPT.ToLower()))
                            {
                                _j = 4;
                                _k = 5;
                            }
                        }

                        if (_documentUploadDual.Equals(true))
                        {
                            for (_i = _j; _i <= _k; _i++)
                            {                        
                                _documentUpload     = UDSStaffUtil._documentUpload[_i, 2].ToLower();
                                _submittedStatus    = _dr1[_documentUpload + "SubmittedStatus"].ToString();
                                _submittedDate     += (!String.IsNullOrEmpty(_dr1[_documentUpload + "SubmittedDate"].ToString()) && _submittedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SubmittedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _approvalStatus     = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                                _approvalDate      += (!String.IsNullOrEmpty(_dr1[_documentUpload + "ApprovalDate"].ToString()) && (_approvalStatus.Equals("Y") || _approvalStatus.Equals("N")) ? ("<div class='" + _documentUpload + "-approvaldate th-label'>" + DateTime.Parse(_dr1[_documentUpload + "ApprovalDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='" + _documentUpload + "-approvaldate th-label'>&nbsp;</div>");
                                _iconApprove       += ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[_i, 3] + "</div></div>");
                            }        
                        }
                        else
                            {
                                _submittedStatus    = _dr1[_documentUpload + "SubmittedStatus"].ToString();
                                _submittedDate      = (!String.IsNullOrEmpty(_dr1[_documentUpload + "SubmittedDate"].ToString()) && _submittedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SubmittedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _approvalStatus     = _dr1[_documentUpload + "ApprovalStatus"].ToString();
                                _approvalDate       = (!String.IsNullOrEmpty(_dr1[_documentUpload + "ApprovalDate"].ToString()) && (_approvalStatus.Equals("Y") || _approvalStatus.Equals("N")) ? ("<div class='" + _documentUpload + "-approvaldate th-label'>" + DateTime.Parse(_dr1[_documentUpload + "ApprovalDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='" + _documentUpload + "-approvaldate th-label'>&nbsp;</div>");
                                _iconApprove        = ("<div class='" + _documentUpload + "-approvalstatus uploaddocument-approvalstatus " + UDSStaffUtil.GetIconApprovalStatus(_approvalStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower() + "'><div class='en-label'>" + _dr1["documentUploadInitials"].ToString() + "</div></div>");
                            }
                    }

                    _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";                
                    _callFunc   = "Util.tut.getFrmPreviewDocument({" +
                                  "page:'" + UDSStaffUtil.PAGE_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD_EDIT + "'," +
                                  "idMain:'" + _idSectionMain + "'," +
                                  "idPreview:'" + _idSectionEdit + "'," +
                                  "data:'" + _dr1["id"] + "'" + 
                                  "},function(){})";

                    _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["studentCode"].ToString()) ? _dr1["studentCode"].ToString() : "XXXXXXX"));                
                    _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, Util.GetFullName(_dr1["titlePrefixInitialsTH"].ToString(), _dr1["titlePrefixFullNameTH"].ToString(), _dr1["firstName"].ToString(), _dr1["middleName"].ToString(), _dr1["lastName"].ToString()));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>",    UDSStaffUtil.SUBJECT_SECTION_MEANINGOFADMISSIONTYPE.ToLower(), (!String.IsNullOrEmpty(_dr1["perEntranceTypeId"].ToString()) ? _dr1["perEntranceTypeId"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label link-click link-{0}'>{1}</div></div></div>",    UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSTUDENTSTATUS.ToLower(), (!String.IsNullOrEmpty(_dr1["status"].ToString()) ? _dr1["status"].ToString() : String.Empty));
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'>{1}</div></div>",                        _callFunc, _submittedDate);
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg table-col-approvalstatus'>{0}</div></div>",           _iconApprove);
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg table-col-approvaldate'>{1}</div></div>", _callFunc, _approvalDate);
                    _html.AppendLine("  </div>");
                }

                _html.AppendLine("</div>");
            }

            return _html;
        }
    }
    
    public class SectionSearchUI
    {
        //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการอนุมัติเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
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
            _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการอนุมัติเอกสาร</span><span class='en-label'> : Approval Status</span>");
            _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-approvalstatus-combobox'>" + UDSStaffUI.GetComboboxApprovalStatus(_idSectionSearch + "-approvalstatus") + "</div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("ApprovalStatus", _contentFrmColumnDetail[_i]);
            _i++;

            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
            _contentTemp.AppendLine("   <div class='contentbody-left'>");
            _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffApproveDocumentUtil._sortOrderBy));
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
            _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN).ToString());
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
            _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ApprovalStatus"]).ToString());
            _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
            _html.AppendLine("              </div>");
            _html.AppendLine("              <div class='contentbody-left search-section3'>");
            _html.AppendLine("                  <div class='button'>");
            _html.AppendLine("                      <div class='button-layout'>");
            _html.AppendLine("                          <div class='button-content'>");
            _html.AppendLine("                              <ul class='button-style1'>");
            _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN);
            _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN);
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
    
    public class SectionAddUpdateUI
    {
        public class SectionEditUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการแก้ไขในส่วนของการการอนุมัติเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _section   เป็น string รับค่าส่วนที่ต้องการแสดง
            //2. _id        เป็น string รับค่ารหัสที่ตั้องการ
            public static StringBuilder GetMain(string _section, string _id)
            {
                StringBuilder _html = new StringBuilder();

                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD))
                {
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard     = UDSStaffUtil.SUBJECT_SECTION_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD;
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview   = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview               = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTPROFILEPICTURE_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview                 = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTIDENTITYCARD_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview        = UDSStaffUtil.PAGE_APPROVEDOCUMENTPROFILEPICTUREIDENTITYCARD_EDIT;

                    _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, false, true);
                }
                
                if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_APPROVEDOCUMENTTRANSCRIPT))
                {
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._subjectSectionTranscript             = UDSStaffUtil.SUBJECT_SECTION_APPROVEDOCUMENTTRANSCRIPT;
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptPreview           = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTTRANSCRIPT_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptInstitutePreview  = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTTRANSCRIPTINSTITUTE_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptFrontsidePreview  = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTTRANSCRIPTFRONTSIDE_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptBacksidePreview   = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENTTRANSCRIPTBACKSIDE_EDIT.ToLower();
                    UDSStaffUI.PreviewDocumentUI.TranscriptUI._pageTranscriptPreview                = UDSStaffUtil.PAGE_APPROVEDOCUMENTTRANSCRIPT_EDIT;

                    _html = UDSStaffUI.PreviewDocumentUI.TranscriptUI.GetMain(_id, false, true);
                }
                
                return _html;
            }
        }
    }
 }