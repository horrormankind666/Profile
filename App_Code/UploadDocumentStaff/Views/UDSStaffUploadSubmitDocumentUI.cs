// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๑/๐๘/๒๕๕๘>
// Modify date  : <๐๖/๐๙/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class UDSStaffUploadSubmitDocumentUI
{
    private static string _idSectionMain        = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_MAIN.ToLower();
    private static string _idSectionSearch      = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_SEARCH.ToLower();
    private static string _idSectionPreview     = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_PREVIEW.ToLower();
    private static string _idSectionAddUpdate   = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_ADDUPDATE.ToLower();

    //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามส่วนที่ต้องการแสดงในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
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
            case "MAIN"         : { _html = SectionMainUI.GetMain(); break; }
            case "SEARCH"       : { _html = SectionSearchUI.GetMain(); break; }
            case "PREVIEW"      : { _html = SectionPreviewUI.GetMain(_sectionAction, _id); break; }
            case "ADDUPDATE"    : { _html = SectionAddUpdateUI.GetMain(_id); break; }
        }
        
        return _html;
    }

    public class SectionMainUI
    {
        //ฟังก์ชั่นสำหรับแสดงหน้าหาหน้าหลักในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
        public static StringBuilder GetMain()
        {
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN, _infoData);            
            Dictionary<string, object> _searchResult = new Dictionary<string, object>();
            StringBuilder _html = new StringBuilder();
            int _cookieError = Util.ChkCookie(UDSStaffUtil._myParamSearchCookieName);
            int _i = 0;
            bool _show = false;
        
            if (_cookieError.Equals(0))
            {
                HttpCookie _objCookie = Util.GetCookie(UDSStaffUtil._myParamSearchCookieName);

                if (_objCookie["Command"].Equals(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN))
                {                    
                    _show = true;
                    _searchResult = UDSStaffUploadSubmitDocumentUtil.GetSearch(UDSStaffUtil.SetParameterSearch(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN, null, true));
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
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Uploaded Date</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Submitted</div><div class='en-label'>Status</div></div></div>");
            _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Submitted Date</div></div></div>");
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

            for (_i = 0; _i < UDSStaffUploadSubmitDocumentUtil._menu.GetLength(0); _i++)
            {
                _html.AppendFormat("                            <li class='have-link'><a class='link-click link-msg' id='link-{0}' alt='{1}' href='javascript:void(0)'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>", UDSStaffUploadSubmitDocumentUtil._menu[_i, 2].ToLower(), UDSStaffUploadSubmitDocumentUtil._menu[_i, 2], UDSStaffUploadSubmitDocumentUtil._menu[_i, 0], UDSStaffUploadSubmitDocumentUtil._menu[_i, 1]);
            }

            _html.AppendLine("                              </ul>");
            _html.AppendLine("                          </div>");
            _html.AppendLine("                          <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>Click to Select Document</a></div>");
            _html.AppendLine("                      </div>");
            _html.AppendLine("                  </div>");
            _html.AppendFormat("                <input type='hidden' id='{0}-personid-hidden' value='' />", _idSectionPreview);
            _html.AppendFormat("                <div id='{0}-form' align='center'></div>", _idSectionPreview);
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("</div>");
            
            return _html;
        }

        //ฟังก์ชั่นสำหรับแสดงรายการในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
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
            string _uploadedStatus = String.Empty;
            string _uploadedDate = String.Empty;
            string _submittedStatus = String.Empty;
            string _submittedDate = String.Empty;
            string _iconSubmit = String.Empty;
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
                    _uploadedStatus     = String.Empty;
                    _uploadedDate       = String.Empty;
                    _submittedStatus    = String.Empty;
                    _submittedDate      = String.Empty;
                    _iconSubmit         = String.Empty;

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
                                _uploadedStatus     = _dr1[_documentUpload + "SavedStatus"].ToString();
                                _uploadedDate      += (!String.IsNullOrEmpty(_dr1[_documentUpload + "SavedDate"].ToString()) && _uploadedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SavedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _submittedStatus    = _dr1[_documentUpload + "SubmittedStatus"].ToString();
                                _submittedDate     += (!String.IsNullOrEmpty(_dr1[_documentUpload + "SubmittedDate"].ToString()) && _submittedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SubmittedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _iconSubmit        += ("<div class='" + _documentUpload + "-submittedstatus uploaddocument-submittedstatus " + UDSStaffUtil.GetIconSubmittedStatus(_submittedStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSUBMITTEDSTATUS.ToLower() + "'><div class='en-label'>" + UDSStaffUtil._documentUpload[_i, 3] + "</div></div>");
                            }
                        }
                        else
                            {
                                _uploadedStatus     = _dr1[_documentUpload + "SavedStatus"].ToString();
                                _uploadedDate       = (!String.IsNullOrEmpty(_dr1[_documentUpload + "SavedDate"].ToString()) && _uploadedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SavedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _submittedStatus    = _dr1[_documentUpload + "SubmittedStatus"].ToString();
                                _submittedDate      = (!String.IsNullOrEmpty(_dr1[_documentUpload + "SubmittedDate"].ToString()) && _submittedStatus.Equals("Y") ? ("<div class='th-label'>" + DateTime.Parse(_dr1[_documentUpload + "SubmittedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</div>") : "<div class='th-label'>&nbsp;</div>");
                                _iconSubmit         = ("<div class='" + _documentUpload + "-submittedstatus uploaddocument-submittedstatus " + UDSStaffUtil.GetIconSubmittedStatus(_submittedStatus) + " link-" + UDSStaffUtil.SUBJECT_SECTION_MEANINGOFSUBMITTEDSTATUS.ToLower() + "'><div class='en-label'>" + _dr1["documentUploadInitials"].ToString() + "</div></div>");
                            }
                    }

                    _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";                
                    _callFunc   = "Util.tut.getFrmPreviewDocument({" +
                                  "page:'" + UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTUREIDENTITYCARD_PREVIEW + "'," +
                                  "idMain:'" + _idSectionMain + "'," +
                                  "idPreview:'" + _idSectionPreview + "'," +
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
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'>{1}</div></div>",    _callFunc, _uploadedDate);
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg table-col-submittedstatus'>{0}</div></div>", _iconSubmit);
                    _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'>{1}</div></div>",    _callFunc, _submittedDate);
                    _html.AppendLine("  </div>");
                }

                _html.AppendLine("</div>");
            }

            return _html;
        }
    }
    
    public class SectionSearchUI
    {
        //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
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
            _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-submittedstatus"));
            _contentFrmColumnDetail[_i].Add("HighLight", false);
            _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการส่งเอกสาร</span><span class='en-label'> : Submitted Status</span>");
            _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-submittedstatus-combobox'>" + UDSStaffUI.GetComboboxSubmittedStatus(_idSectionSearch + "-submittedstatus") + "</div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("SubmittedStatus", _contentFrmColumnDetail[_i]);
            _i++;

            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
            _contentTemp.AppendLine("   <div class='contentbody-left'>");
            _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, UDSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), UDSStaffUploadSubmitDocumentUtil._sortOrderBy));
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
            _html.AppendLine(               UDSStaffUI.GetValueSearch(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN).ToString());
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
            _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["SubmittedStatus"]).ToString());
            _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
            _html.AppendLine("              </div>");
            _html.AppendLine("              <div class='contentbody-left search-section3'>");
            _html.AppendLine("                  <div class='button'>");
            _html.AppendLine("                      <div class='button-layout'>");
            _html.AppendLine("                          <div class='button-content'>");
            _html.AppendLine("                              <ul class='button-style1'>");
            _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN);
            _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN);
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
        //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าตัวอย่างเอกสารในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   เป็น string รับค่าส่วนที่ต้องการแสดง
        //2. _id        เป็น string รับค่ารหัสที่ตั้องการ
        public static StringBuilder GetMain(string _section, string _id)
        {
            StringBuilder _html = new StringBuilder();
            
            if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTUREIDENTITYCARD))
            {
                UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._subjectSectionProfilePictureIdentityCard     = UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTUREIDENTITYCARD;
                UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePictureIdentityCardPreview   = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTUREIDENTITYCARD_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionProfilePicturePreview               = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._idSectionIdentityCardPreview                 = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI._pageProfilePictureIdentityCardPreview        = UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTUREIDENTITYCARD_PREVIEW;

                _html = UDSStaffUI.PreviewDocumentUI.ProfilePictureIdentityCardUI.GetMain(_id, true, false);
            }
            
            if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT))
            {
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._subjectSectionTranscript             = UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT;
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptPreview           = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptInstitutePreview  = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptFrontsidePreview  = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._idSectionTranscriptBacksidePreview   = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE_PREVIEW.ToLower();
                UDSStaffUI.PreviewDocumentUI.TranscriptUI._pageTranscriptPreview                = UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_PREVIEW;

                _html = UDSStaffUI.PreviewDocumentUI.TranscriptUI.GetMain(_id, true, false);
            }
            
            return _html;
        }
    }

    public class SectionAddUpdateUI
    {
        //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
        //โดยมีพารามิเตอร์ดังนี้
        //1. _id    เป็น string รับค่ารหัสที่ต้องการ
        public static StringBuilder GetMain(string _id)
        {
            StringBuilder _html = new StringBuilder();
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_ADDUPDATE, _infoData);
            int _i = 0;

            _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());            
            _html.AppendLine("<div class='after-sticky'>");
            _html.AppendLine("  <div>");
            _html.AppendFormat("    <div class='sticky-left menulist' id='{0}-menu'>", _idSectionAddUpdate);
            _html.AppendLine("          <div class='menulist-layout'>");
            _html.AppendFormat("            <div class='menulist-content' id='{0}-menu-content'>", _idSectionAddUpdate);
            _html.AppendLine("                  <ul>");

            for (_i = 0; _i < 4; _i++)
            {
                _html.AppendFormat("                <li class='have-link'><a class='link-click link-msg{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>", (UDSStaffUploadSubmitDocumentUtil._menuUpload[_i, 4].Equals("active") ? " menu-active" : String.Empty), UDSStaffUploadSubmitDocumentUtil._menuUpload[_i, 6].ToLower(), UDSStaffUploadSubmitDocumentUtil._menuUpload[_i, 0], UDSStaffUploadSubmitDocumentUtil._menuUpload[_i, 1]);
            }

            _html.AppendLine("                  </ul>");
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendFormat("    <div id='{0}'>", _idSectionAddUpdate);
            _html.AppendFormat("        <div id='{0}-layout'>", _idSectionAddUpdate);
            _html.AppendFormat("            <div id='{0}-content'>", _idSectionAddUpdate);
            _html.AppendFormat("                <div class='menu-active' id='{0}'>{1}</div>",               UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE.ToLower(), StudentRecordsUI.GetMain(_id));
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>",   UDSStaffUploadSubmitDocumentUtil._menuUpload[0, 6].ToLower(), UDSStaffUploadSubmitDocumentUtil._menuUpload[0, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>",   UDSStaffUploadSubmitDocumentUtil._menuUpload[1, 6].ToLower(), UDSStaffUploadSubmitDocumentUtil._menuUpload[1, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>",   UDSStaffUploadSubmitDocumentUtil._menuUpload[2, 6].ToLower(), UDSStaffUploadSubmitDocumentUtil._menuUpload[2, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>",   UDSStaffUploadSubmitDocumentUtil._menuUpload[3, 6].ToLower(), UDSStaffUploadSubmitDocumentUtil._menuUpload[3, 7], String.Empty);
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("  </div");
            _html.AppendLine("</div");

            return _html;
        }
        
        public class StudentRecordsUI
        {
            private static string _idSectionAddUpdate = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของข้อมูลการเป็นนักศึกษาในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-personid-hidden' value='{1}' />",          _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PersonId", _dataRecorded["PersonId"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentcode-hidden' value='{1}' />",       _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentCode", _dataRecorded["StudentCode"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />",            _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Gender", _dataRecorded["Gender"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentpicture-hidden' value='{1}' />",    _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }
            
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของข้อมูลการเป็นนักศึกษาในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ตั้องการ
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[11];
                Dictionary<string, object> _valueDataRecorded = UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS];
                int _i = 0;
                
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='picture-content profilepicture-content'>");
                _contentTemp.AppendLine("   <div class='picture-watermark'></div>");
                _contentTemp.AppendLine("   <img/>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentpicture"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentPicture", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", _dataRecorded["StudentCode"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentid"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentname"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ - นามสกุล");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Full Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FullName", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["DegreeLevelNameTH"]);
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", _dataRecorded["DegreeLevelNameEN"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ระดับการศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Degree Level");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["FacultyNameTH"]);
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", Util.UppercaseFirst(_dataRecorded["FacultyNameEN"].ToString()));

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "คณะ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Faculty");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["ProgramNameTH"]);
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", Util.UppercaseFirst(_dataRecorded["ProgramNameEN"].ToString()));

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หลักสูตร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Program");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["YearEntry"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearentry"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่เข้าศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Year Entry");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("YearEntry", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["Class"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-class"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชั้นปี");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Class");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Class", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["EntranceTypeNameTH"]);
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", Util.UppercaseFirst(_dataRecorded["EntranceTypeNameEN"].ToString()));

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-entrancetypename"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ระบบการสอบเข้า");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Admission Type");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["StatusTypeNameTH"]);
                _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", Util.UppercaseFirst(_dataRecorded["StatusTypeNameEN"].ToString()));

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "สถานภาพการเป็นนักศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Student Status");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StudentStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["GraduationDate"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-graduationdate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วันที่สำเร็จการศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Graduation Date");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("GraduationDate", _contentFrmColumnDetail[_i]);
                
                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form detail' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");                
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentPicture"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentID"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["FullName"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearEntry"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["GraduationDate"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }
        
        public class OverviewUI
        {
            private static string _idSectionAddUpdate = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE.ToLower();
            
            //ฟังก์ชั่นสำหรับแสดงเนื้อหารายละเอียดของเอกสารที่นักศึกษาอัพโหลดให้กับการเพิ่มหรือแก้ไขในส่วนของผลการอัพโหลดเอกสารในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _section   เป็น string รับค่าชื่อหัวข้อที่ต้องการ
            private static Dictionary<string, Dictionary<string, object>> GetFrmDocumentOverview(string _section)
            {       
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[UDSStaffUploadSubmitDocumentUtil._documentUploadDetail.GetLength(0)];
                string _idContent = String.Empty;
                bool _show = false;
                int _i = 0;

                for (_i = 0; _i < UDSStaffUploadSubmitDocumentUtil._documentUploadDetail.GetLength(0); _i++)
                {
                    _show = false;
                    _idContent = (UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE.ToLower() + "-" + _section.ToLower());
                    _contentTemp.Clear();

                    if (_show.Equals(false) && UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("NameofInstitution"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutenameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutenameen"));
                    }

                    if (_show.Equals(false) && UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Country"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutecountrynameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutecountrynameen"));
                    }

                    if (_show.Equals(false) && UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Province"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "instituteprovincenameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "instituteprovincenameen"));
                    }

                    if (_show.Equals(false) && UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("ApprovalStatus"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='uploaddocument-approvalstatus en-label link-{0}' id='{1}'>?</div>", UDSStaffUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower(), (_idContent + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    }

                    if (_show.Equals(false) && UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Message"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='en-label' id='{0}'></div>", (_idContent + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    }

                    if (_show.Equals(false))
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID",                       _idContent);
                    _contentFrmColumnDetail[_i].Add("HighLight",                false);
                    _contentFrmColumnDetail[_i].Add("TitleTH",                  String.Empty);
                    _contentFrmColumnDetail[_i].Add("TitleEN",                  UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 0]);
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH",            String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN",            String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown",  false);
                    _contentFrmColumnDetail[_i].Add("InputContent",             _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require",                  false);
                    _contentFrmColumnDetail[_i].Add("LastRow",                  true);
                    _contentFrmColumn.Add((_section +  UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[_i, 1]), _contentFrmColumnDetail[_i]);
                }

                return _contentFrmColumn;
            }
            
            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของผลการอัพโหลดเอกสารในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW];
                string _section = String.Empty;
                string[] _keyDict = new string[16];
                int _i = 0;

                for (_i = 0; _i < UDSStaffUploadSubmitDocumentUtil._documentUpload.GetLength(0); _i++)
                {
                    _section = UDSStaffUploadSubmitDocumentUtil._documentUpload[_i, 2];
                    _keyDict[0]  = (_section + "InstituteNameTH");
                    _keyDict[1]  = (_section + "InstituteNameEN");
                    _keyDict[2]  = (_section + "InstituteCountryNameTH");
                    _keyDict[3]  = (_section + "InstituteCountryNameEN");
                    _keyDict[4]  = (_section + "InstituteProvinceNameTH");
                    _keyDict[5]  = (_section + "InstituteProvinceNameEN");
                    _keyDict[6]  = (_section + "FileDir");
                    _keyDict[7]  = (_section + "FileName");
                    _keyDict[8]  = (_section + "FullPath");
                    _keyDict[9]  = (_section + "FileType");
                    _keyDict[10] = (_section + "FileSize");
                    _keyDict[11] = (_section + "SavedDate");
                    _keyDict[12] = (_section + "SubmittedStatus");
                    _keyDict[13] = (_section + "ApprovalStatus");
                    _keyDict[14] = (_section + "ApprovalDate");
                    _keyDict[15] = (_section + "Message");

                    if (_section.Equals(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE) || _section.Equals(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
                    {
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutenameth-hidden' value='{2}' />",            _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[0], _dataRecorded[_keyDict[0]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutenameen-hidden' value='{2}' />",            _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[1], _dataRecorded[_keyDict[1]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutecountrynameth-hidden' value='{2}' />",     _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[2], _dataRecorded[_keyDict[2]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutecountrynameen-hidden' value='{2}' />",     _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[3], _dataRecorded[_keyDict[3]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}instituteprovincenameth-hidden' value='{2}' />",    _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[4], _dataRecorded[_keyDict[4]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}instituteprovincenameen-hidden' value='{2}' />",    _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[5], _dataRecorded[_keyDict[5]], Util._valueTextDefault));
                    }
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filedir-hidden' value='{2}' />",            _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[6], _dataRecorded[_keyDict[6]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filename-hidden' value='{2}' />",           _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[7], _dataRecorded[_keyDict[7]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}fullpath-hidden' value='{2}' />",           _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[8], _dataRecorded[_keyDict[8]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filetype-hidden' value='{2}' />",           _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[9], _dataRecorded[_keyDict[9]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filesize-hidden' value='{2}' />",           _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[10], _dataRecorded[_keyDict[10]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}saveddate-hidden' value='{2}' />",          _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[11], _dataRecorded[_keyDict[11]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}submittedstatus-hidden' value='{2}' />",    _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[12], _dataRecorded[_keyDict[12]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}approvalstatus-hidden' value='{2}' />",     _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[13], _dataRecorded[_keyDict[13]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}approvaldate-hidden' value='{2}' />",       _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[14], _dataRecorded[_keyDict[14]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}message-hidden' value='{2}' />",            _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[15], _dataRecorded[_keyDict[15]], Util._valueTextDefault));
                }

                return _html;
            }
            
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของผลการอัพโหลดเอกสารในส่วนของการการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {        
                StringBuilder _html = new StringBuilder();                
                StringBuilder _contentTemp = new StringBuilder();            
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                string _section = String.Empty;

                _html.AppendLine(GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE, _id)).ToString());            
                _html.AppendFormat("<div id='{0}-form'>", _idSectionAddUpdate);            
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTURE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSStaffUploadSubmitDocumentUtil._documentUpload[0, 0], UDSStaffUploadSubmitDocumentUtil._documentUpload[0, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content profilepicture-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSStaffUtil.PAGE_VIEWPROFILEPICTURE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");

                                                                _section = UDSStaffUploadSubmitDocumentUtil._documentUpload[0, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSStaffUtil.SUBJECT_SECTION_IDENTITYCARD.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSStaffUploadSubmitDocumentUtil._documentUpload[1, 0], UDSStaffUploadSubmitDocumentUtil._documentUpload[1, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content identitycard-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSStaffUtil.PAGE_VIEWIDENTITYCARD_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");

                                                                _section = UDSStaffUploadSubmitDocumentUtil._documentUpload[1, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);
                
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());                
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSStaffUploadSubmitDocumentUtil._documentUpload[2, 0], UDSStaffUploadSubmitDocumentUtil._documentUpload[2, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendFormat("                    <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptfrontside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSStaffUtil.PAGE_VIEWTRANSCRIPTFRONTSIDE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
                                                                
                                                                _section = UDSStaffUploadSubmitDocumentUtil._documentUpload[2, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSStaffUploadSubmitDocumentUtil._documentUpload[3, 0], UDSStaffUploadSubmitDocumentUtil._documentUpload[3, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptbackside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSStaffUtil.PAGE_VIEWTRANSCRIPTBACKSIDE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
                                                                
                                                                _section = UDSStaffUploadSubmitDocumentUtil._documentUpload[3, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSStaffUI.GetFrmColumn(_contentFrmColumn[_section + UDSStaffUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
                _html.AppendLine("                          </div>");            
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }            
        }
        
        //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าอัพโหลดเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   เป็น string รับค่าชื่อหัวข้อที่ต้องการ
        private static StringBuilder GetFrmUploadFile(string _section)
        {
            StringBuilder _html = new StringBuilder();

            _html.AppendFormat("<form class='uploadfile-form' id='uploadfile-{0}-form' action='UDSStaffUploadFile.aspx' enctype='multipart/form-data' target='frame-util' onSubmit='Util.startUploadFile()'>", _section.ToLower());
            _html.AppendFormat("    <input type='hidden' id='uploadfile-section' name='uploadfile-section' value='{0}' />", _section);
            _html.AppendFormat("    <input type='hidden' id='uploadfile-personid' name='uploadfile-personid' value='' />");
            _html.AppendLine("      <div class='uploadfile-content'>");
            _html.AppendFormat("        <div class='uploadfile-label en-label' id='uploadfile-{0}-label'></div>", _section.ToLower());
            _html.AppendLine("          <div class='button'>");
            _html.AppendLine("              <div class='button-layout'>");
            _html.AppendLine("                  <div class='button-content'>");
            _html.AppendLine("                      <ul class='button-style1'>");
            _html.AppendFormat("                        <li class='nomargin'><div class='uploadfile-button browse-uploadfile en-label' alt='{0}' id='browse-uploadfile-{1}'>BROWSE<input type='file' id='{1}-browse-uploadfile' name='{1}-browse-uploadfile' alt='uploadfile-{1}' /></div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='clear-uploadfile-{1}'>CLEAR</div></li>",      _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='upload-uploadfile-{1}'>UPLOAD</div></li>",    _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='save-uploadfile-{1}'>CROP & SAVE</div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='delete-uploadfile-{1}'>DELETE</div></li>",    _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='submit-uploadfile-{1}'>SUBMIT</div></li>",    _section, _section.ToLower());
            _html.AppendLine("                      </ul>");
            _html.AppendLine("                  </div>");
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("</form>");

            return _html;
        }
        
        public class ProfilePictureUI
        {
            private static string _idSectionAddUpdate = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดรูปภาพประจำตัวในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE];

                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />",           _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileDir", _dataRecorded["ProfilePictureFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />",          _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileName", _dataRecorded["ProfilePictureFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />",             _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />",             _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />",             _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureWidth", _dataRecorded["ProfilePictureWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />",            _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureHeight", _dataRecorded["ProfilePictureHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />",       _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSavedStatus", _dataRecorded["ProfilePictureSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />",   _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSubmittedStatus", _dataRecorded["ProfilePictureSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />",    _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureApprovalStatus", _dataRecorded["ProfilePictureApprovalStatus"], Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดรูปภาพประจำตัวในส่วนของการการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE, _id)).ToString());
                _html.AppendFormat("<div class='form uploaddocument-form' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");            
                _html.AppendLine("              <div class='uploaddocument-layout' align='center'>");
                _html.AppendLine("                  <div class='uploaddocument-content'>");
                _html.AppendLine("                      <div>");
                _html.AppendLine("                          <div class='nomargin picture-content profilepicture-content'>");
                _html.AppendLine("                              <div class='profilepicture-example'></div>");
                _html.AppendLine("                              <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ : </span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='picture-content profilepicture-content'>");
                _html.AppendFormat("                            <div class='picture-recommend' id='{0}-recommend'>", _idSectionAddUpdate);
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSStaffUtil._myProfilePictureWidth, UDSStaffUtil._myProfilePictureHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSStaffUtil._myProfilePictureWidth, UDSStaffUtil._myProfilePictureHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTURE));
                _html.AppendLine("                  </div>");                        
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }
        
        public class IdentityCardUI
        {
            private static string _idSectionAddUpdate = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดบัตรประจำตัวประชาชนในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD];

                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />",           _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileDir", _dataRecorded["IdentityCardFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />",          _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileName", _dataRecorded["IdentityCardFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />",             _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />",             _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />",             _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardWidth", _dataRecorded["IdentityCardWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />",            _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardHeight", _dataRecorded["IdentityCardHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />",       _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSavedStatus", _dataRecorded["IdentityCardSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />",   _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSubmittedStatus", _dataRecorded["IdentityCardSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />",    _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardApprovalStatus", _dataRecorded["IdentityCardApprovalStatus"], Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดบัตรประจำตัวประชาชนในส่วนของการการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE, _id)).ToString());
                _html.AppendFormat("<div class='form uploaddocument-form' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");            
                _html.AppendLine("              <div class='uploaddocument-layout' align='center'>");
                _html.AppendLine("                  <div class='uploaddocument-content'>");
                _html.AppendLine("                      <div>");
                _html.AppendLine("                          <div class='nomargin picture-content identitycard-content'>");
                _html.AppendLine("                              <div class='identitycard-example'></div>");
                _html.AppendLine("                              <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ : </span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='picture-content identitycard-content'>");
                _html.AppendFormat("                            <div class='picture-recommend' id='{0}-recommend'>", _idSectionAddUpdate);
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSStaffUtil._myIdentityCardWidth, UDSStaffUtil._myIdentityCardHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSStaffUtil._myIdentityCardWidth, UDSStaffUtil._myIdentityCardHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSStaffUtil.SUBJECT_SECTION_IDENTITYCARD));
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }
        
        public class TranscriptUI
        {
            private static string _idSectionAddUpdate                       = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptInstituteAddUpdate    = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptFrontsideAddUpdate    = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptBacksideAddUpdate     = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดระเบียนแสดงผลการเรียนในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder            
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT];

                _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />",  _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstituteCountry", _dataRecorded["TranscriptInstituteCountry"], Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstituteProvince", _dataRecorded["TranscriptInstituteProvince"], Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institute-hidden' value='{1}' />",         _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstitute", _dataRecorded["TranscriptInstitute"], Util._valueComboboxDefault));            
                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />",           _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideFileDir", _dataRecorded["TranscriptFrontsideFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />",          _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideFileName", _dataRecorded["TranscriptFrontsideFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />",             _idSectionTranscriptFrontsideAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />",             _idSectionTranscriptFrontsideAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />",             _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideWidth", _dataRecorded["TranscriptFrontsideWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />",            _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideHeight", _dataRecorded["TranscriptFrontsideHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />",       _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideSavedStatus", _dataRecorded["TranscriptFrontsideSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />",   _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideSubmittedStatus", _dataRecorded["TranscriptFrontsideSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />",    _idSectionTranscriptFrontsideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideApprovalStatus", _dataRecorded["TranscriptFrontsideApprovalStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />",           _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideFileDir", _dataRecorded["TranscriptBacksideFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />",          _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideFileName", _dataRecorded["TranscriptBacksideFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />",             _idSectionTranscriptBacksideAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />",             _idSectionTranscriptBacksideAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />",             _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideWidth", _dataRecorded["TranscriptBacksideWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />",            _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideHeight", _dataRecorded["TranscriptBacksideHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />",       _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideSavedStatus", _dataRecorded["TranscriptBacksideSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />",   _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideSubmittedStatus", _dataRecorded["TranscriptBacksideSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />",    _idSectionTranscriptBacksideAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideApprovalStatus", _dataRecorded["TranscriptBacksideApprovalStatus"], Util._valueTextDefault));
                
                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดระเบียนแสดงผลการเรียนในส่วนของการการอัพโหลดและส่งเอกสารให้กับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                StringBuilder _html = new StringBuilder();
                int _i = 0;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptInstituteAddUpdate + "-institutecountry"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionTranscriptInstituteAddUpdate + "-institutecountry-combobox'>" + UDSStaffUI.GetComboboxCountry(_idSectionTranscriptInstituteAddUpdate + "-institutecountry") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptInstituteAddUpdate + "-instituteprovince"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "State / Province");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionTranscriptInstituteAddUpdate + "-instituteprovince-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptInstituteAddUpdate + "-institute"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "โรงเรียน / สถาบัน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Name of Institution");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionTranscriptInstituteAddUpdate + "-institute-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Institute", _contentFrmColumnDetail[_i]);
                
                _html.AppendLine(GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE, _id)).ToString());                
                _html.AppendFormat("<div class='form uploaddocument-form' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine("              <div class='uploaddocument-layout' align='center'>");
                _html.AppendLine("                  <div class='uploaddocument-content'>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptInstituteAddUpdate);
                _html.AppendLine("                          <div class='uploaddocument-subject'>");
                _html.AppendLine("                              <ul>");
                _html.AppendLine("                                  <li><div class='th-label'>ระเบียนแสดงผลการเรียนจาก</div><div class='en-label'>Institution Transcript</div></li>");
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='form'>");
                _html.AppendLine("                              <div class='form-layout'>");
                _html.AppendLine("                                  <div class='form-content'>");
                _html.AppendLine("                                      <div class='uploaddocument-layout'>");
                _html.AppendLine(                                           UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                                           UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine(                                           UDSStaffUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
                _html.AppendLine("                                      </div>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendLine("                          <div>");
                _html.AppendLine("                              <div class='nomargin picture-content transcriptfrontside-content'>");
                _html.AppendLine("                                  <div class='transcriptfrontside-example'></div>");
                _html.AppendLine("                                  <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ : </span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='picture-content transcriptfrontside-content'>");
                _html.AppendFormat("                                <div class='picture-recommend' id='{0}-recommend'>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSStaffUtil._myTranscriptWidth, UDSStaffUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSStaffUtil._myTranscriptWidth, UDSStaffUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE));
                _html.AppendLine("                      </div>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                          <div>");
                _html.AppendLine("                              <div class='nomargin picture-content transcriptbackside-content'>");
                _html.AppendLine("                                  <div class='transcriptbackside-example'></div>");
                _html.AppendLine("                                  <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ : </span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='picture-content transcriptbackside-content'>");
                _html.AppendFormat("                                <div class='picture-recommend' id='{0}-recommend'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSStaffUtil._myTranscriptWidth, UDSStaffUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSStaffUtil._myTranscriptWidth, UDSStaffUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                
                return _html;
            }
        }
    }
}