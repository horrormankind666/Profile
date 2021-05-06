/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๓/๐๒/๒๕๕๘>
Modify date : <๐๓/๐๓/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการจัดการข้อมูลหลัก>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class ePFStaffMasterDataUI
{   
    public class TitlePrefixUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATATITLEPREFIX_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATATITLEPREFIX_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.TitlePrefixUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN, null, true));
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());                
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Initials</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Initials</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Gender</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["titlePrefixFullNameTH"].ToString()) ? _dr1["titlePrefixFullNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["titlePrefixInitialsTH"].ToString()) ? _dr1["titlePrefixInitialsTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["titlePrefixFullNameEN"].ToString()) ? _dr1["titlePrefixFullNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["titlePrefixInitialsEN"].ToString()) ? _dr1["titlePrefixInitialsEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderInitialsEN"].ToString()) ? _dr1["genderInitialsEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[4];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม / ชื่อย่อ</span><span class='en-label'> : ID / Full Name / Initials</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-gender"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>เพศ</span><span class='en-label'> : Gender</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-gender-combobox'>" + ePFStaffUI.GetComboboxGender(_idSectionSearch + "-gender") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Gender", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.TitlePrefixUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Gender"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN);
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

    public class GenderUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAGENDER_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAGENDER_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.GenderUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());       
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Initials</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Initials</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderFullNameTH"].ToString()) ? _dr1["genderFullNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderInitialsTH"].ToString()) ? _dr1["genderInitialsTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderFullNameEN"].ToString()) ? _dr1["genderFullNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderInitialsEN"].ToString()) ? _dr1["genderInitialsEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม / ชื่อย่อ</span><span class='en-label'> : ID / Full Name / Initials</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.GenderUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN);
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

    public class NationalityRaceUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATANATIONALITYRACE_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATANATIONALITYRACE_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.NationalityRaceUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");                
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>ISO ALPHA-2</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>ISO ALPHA-3</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["nationalityNameTH"].ToString()) ? _dr1["nationalityNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["nationalityNameEN"].ToString()) ? _dr1["nationalityNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes2Letter"].ToString()) ? _dr1["isoCountryCodes2Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.NationalityRaceUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN);
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

    public class ReligionUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATARELIGION_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATARELIGION_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.ReligionUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["religionNameTH"].ToString()) ? _dr1["religionNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["religionNameEN"].ToString()) ? _dr1["religionNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.ReligionUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN);
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

    public class BloodGroupUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATABLOODGROUP_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATABLOODGROUP_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.BloodGroupUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["bloodTypeNameTH"].ToString()) ? _dr1["bloodTypeNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["bloodTypeNameEN"].ToString()) ? _dr1["bloodTypeNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.BloodGroupUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN);
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

    public class MaritalStatusUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAMARITALSTATUS_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAMARITALSTATUS_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.MaritalStatusUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["maritalStatusNameTH"].ToString()) ? _dr1["maritalStatusNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["maritalStatusNameEN"].ToString()) ? _dr1["maritalStatusNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.MaritalStatusUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN);
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

    public class FamilyRelationshipsUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAFAMILYRELATIONSHIPS_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAFAMILYRELATIONSHIPS_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.FamilyRelationshipsUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Gender</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["relationshipNameTH"].ToString()) ? _dr1["relationshipNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["relationshipNameEN"].ToString()) ? _dr1["relationshipNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["genderInitialsEN"].ToString()) ? _dr1["genderInitialsEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[4];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-gender"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>เพศ</span><span class='en-label'> : Gender</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-gender-combobox'>" + ePFStaffUI.GetComboboxGender(_idSectionSearch + "-gender") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Gender", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.FamilyRelationshipsUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Gender"]).ToString());                
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN);
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

    public class AgencyUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAAGENCY_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAAGENCY_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.AgencyUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["agencyNameTH"].ToString()) ? _dr1["agencyNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["agencyNameEN"].ToString()) ? _dr1["agencyNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.AgencyUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN);
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

    public class EducationalLevelUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALLEVEL_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALLEVEL_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.EducationalLevelUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalLevelNameTH"].ToString()) ? _dr1["educationalLevelNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalLevelNameEN"].ToString()) ? _dr1["educationalLevelNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.EducationalLevelUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN);
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

    public class EducationalBackgroundUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALBACKGROUND_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALBACKGROUND_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.EducationalBackgroundUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Educational Level</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Educational Level</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameTH"].ToString()) ? _dr1["educationalBackgroundNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalLevelNameTH"].ToString()) ? _dr1["educationalLevelNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalBackgroundNameEN"].ToString()) ? _dr1["educationalBackgroundNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalLevelNameEN"].ToString()) ? _dr1["educationalLevelNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[4];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ระดับการศึกษา</span><span class='en-label'> : Educational Level</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-degreelevel-combobox'>" + ePFStaffUI.GetComboboxEducationalLevel(_idSectionSearch + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EducationalLevel", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.EducationalBackgroundUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["EducationalLevel"]).ToString());                
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                              
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN);
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

    public class EducationalMajorUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALMAJOR_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALMAJOR_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.EducationalMajorUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalMajorNameTH"].ToString()) ? _dr1["educationalMajorNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["educationalMajorNameEN"].ToString()) ? _dr1["educationalMajorNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.EducationalMajorUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                              
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN);
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

    public class AdmissionTypeUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAADMISSIONTYPE_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAADMISSIONTYPE_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.AdmissionTypeUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTypeNameTH"].ToString()) ? _dr1["entranceTypeNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["entranceTypeNameEN"].ToString()) ? _dr1["entranceTypeNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.AdmissionTypeUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                              
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN);
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

    public class StudentStatusUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATASTUDENTSTATUS_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATASTUDENTSTATUS_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.StudentStatusUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["statusTypeNameTH"].ToString()) ? _dr1["statusTypeNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["statusTypeNameEN"].ToString()) ? _dr1["statusTypeNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createdDate"].ToString()) ? DateTime.Parse(_dr1["createdDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", String.Empty);
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.StudentStatusUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                              
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN);
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

    public class CountryUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATACOUNTRY_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATACOUNTRY_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.CountryUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>ISO ALPHA-2</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>ISO ALPHA-3</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameTH"].ToString()) ? _dr1["countryNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["countryNameEN"].ToString()) ? _dr1["countryNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes2Letter"].ToString()) ? _dr1["isoCountryCodes2Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.CountryUtil._sortOrderBy));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("   <div id='{0}-sortexpression-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortexpression"), ePFStaffUtil._sortExpression));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                              
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN);
                _html.AppendLine("                              </ul>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      /div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }
    }

    public class ProvinceUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAPROVINCE_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAPROVINCE_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.ProvinceUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Country</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTH"].ToString()) ? _dr1["provinceNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameEN"].ToString()) ? _dr1["provinceNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[4];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศ</span><span class='en-label'> : Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-country-combobox'>" + ePFStaffUI.GetComboboxCountry(_idSectionSearch + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.ProvinceUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                     
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN);
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

    public class DistrictUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATADISTRICT_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATADISTRICT_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.DistrictUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Country</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>ZIP /</div><div class='en-label'>Postal Code</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTH"].ToString()) ? _dr1["provinceNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameTH"].ToString()) ? _dr1["districtNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameEN"].ToString()) ? _dr1["provinceNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameEN"].ToString()) ? _dr1["districtNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["zipCode"].ToString()) ? _dr1["zipCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศ</span><span class='en-label'> : Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-country-combobox'>" + ePFStaffUI.GetComboboxCountry(_idSectionSearch + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-province"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จังหวัด</span><span class='en-label'> : Province</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-province-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.DistrictUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                     
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN);
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

    public class SubdistrictUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATASUBDISTRICT_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATASUBDISTRICT_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.SubdistrictUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());    
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");                
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Country</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>District / Area</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col8'><div class='table-col-msg'><div class='en-label'>District / Area</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col9'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>ZIP /</div><div class='en-label'>Postal Code</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameTH"].ToString()) ? _dr1["provinceNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameTH"].ToString()) ? _dr1["districtNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameTH"].ToString()) ? _dr1["subdistrictNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["provinceNameEN"].ToString()) ? _dr1["provinceNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col8'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["districtNameEN"].ToString()) ? _dr1["districtNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col9'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["subdistrictNameEN"].ToString()) ? _dr1["subdistrictNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["zipCode"].ToString()) ? _dr1["zipCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col11'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col12'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col13'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[6];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศ</span><span class='en-label'> : Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-country-combobox'>" + ePFStaffUI.GetComboboxCountry(_idSectionSearch + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-province"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จังหวัด</span><span class='en-label'> : Province</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-province-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-district"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>อำเภอ / เขต</span><span class='en-label'> : District / Area</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-district-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("District", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.SubdistrictUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["District"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                     
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN);
                _html.AppendFormat("                                li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN);
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

    public class InstituteUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_SEARCH.ToLower();
        private static string _idSectionNew = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_NEW.ToLower();
        private static string _idSectionEdit = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_EDIT.ToLower();

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
                case "NEW":
                    _html = SectionAddUpdateUI.SectionNewUI.GetMain();
                    break;
                case "EDIT":
                    _html = SectionAddUpdateUI.SectionEditUI.GetMain(_id);
                    break;
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.InstituteUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN, null, true));
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());                
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Country</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col5'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Province</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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
                                    "page:('index.aspx?p=" + ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_EDIT + "&id=" + _dr1["id"] + "')" +
                                    "})";

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["isoCountryCodes3Letter"].ToString()) ? _dr1["isoCountryCodes3Letter"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["provinceNameTH"].ToString()) ? _dr1["provinceNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["institutelNameTH"].ToString()) ? _dr1["institutelNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["provinceNameEN"].ToString()) ? _dr1["provinceNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["institutelNameEN"].ToString()) ? _dr1["institutelNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>", _callFunc, (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>ประเทศ</span><span class='en-label'> : Country</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-country-combobox'>" + ePFStaffUI.GetComboboxCountry(_idSectionSearch + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-province"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>จังหวัด</span><span class='en-label'> : Province</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-province-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.InstituteUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                     
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN);
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
            private static string _idSectionAddUpdate = String.Empty;

            public class SectionNewUI
            {
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_NEW, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionNew;

                    _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(null).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            public class SectionEditUI
            {
                public static StringBuilder GetMain(string _id)
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_EDIT, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionEdit;

                    _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(ePFStaffUtil.SetValueDataRecorded(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_EDIT, _id)).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFStaffUtil.SUBJECT_SECTION_INSTITUTE] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Id", _dataRecorded["Id"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Country", _dataRecorded["Country"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Province", _dataRecorded["Province"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institutenameth-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteNameTH", _dataRecorded["InstituteNameTH"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institutenameen-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteNameEN", _dataRecorded["InstituteNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CancelledStatus", _dataRecorded["CancelledStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[6];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-country-combobox'>" + ePFStaffUI.GetComboboxCountry(_idSectionAddUpdate + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-province"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "State / Province");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-province-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutenameth"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อโรงเรียน / สถาบัน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Name of Institution");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-institutenameth' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("InstituteNameTH", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutenameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อโรงเรียน / สถาบัน ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Name of Institution ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-institutenameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("InstituteNameEN", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='nomargin checkbox-content'>");
                _contentTemp.AppendLine("   <ul>");
                _contentTemp.AppendFormat("     <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-cancelledstatus' value='Y' /></li>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <li class='checkbox-labelcol'></li>");
                _contentTemp.AppendLine("   </ul>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ยกเลิก");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Cancel");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-save"));
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
                
                _html.AppendLine("<div class='after-sticky'>");
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["InstituteNameTH"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["InstituteNameEN"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");  

                return _html;
            }
        }
    }

    public class DiseasesUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATADISEASES_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATADISEASES_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.DiseasesUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN, null, true));
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());                
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["diseasesNameTH"].ToString()) ? _dr1["diseasesNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["diseasesNameEN"].ToString()) ? _dr1["diseasesNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.DiseasesUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                    
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN);
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

    public class HealthImpairmentsUI
    {
        private static string _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAHEALTHIMPAIRMENTS_MAIN.ToLower();
        private static string _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAHEALTHIMPAIRMENTS_SEARCH.ToLower();

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
            }

            return _html;
        }

        public class SectionMainUI
        {
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFStaffUtil.GetInfoData(ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN, _infoData);
                Dictionary<string, object> _searchResult = ePFStaffMasterDataUtil.HealthImpairmentsUtil.GetSearch(ePFStaffUtil.SetParameterSearch(ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN, null, true));
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(ePFStaffUI.GetInfoBar(_infoDataResult, true).ToString());                
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("<div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("      <div class='table-layout'>");
                _html.AppendLine("          <div class='table-content'>");
                _html.AppendLine("              <div class='table-freeze sticky'>");
                _html.AppendLine("                  <div class='table-title'>");
                _html.AppendFormat("                    <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", ePFStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                    <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                        <span class='recordcount-search hidden'>{0}</span>", double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                        <span class='recordcountprimary-search th-label'>{0}</span>", double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='clear'></div>");
                _html.AppendLine("                  <div class='table-head'>");
                _html.AppendLine("                      <div class='table-row'>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( TH )</div></div></div>");                
                _html.AppendLine("                          <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Full Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                          <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("            <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
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

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsNameTH"].ToString()) ? _dr1["impairmentsNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["impairmentsNameEN"].ToString()) ? _dr1["impairmentsNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>{0}</div></div></div>", (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
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
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-keyword"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อเต็ม</span><span class='en-label'> : ID / Full Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + ePFStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-floatcol search-floatcol1'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, ePFStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), ePFStaffMasterDataUtil.HealthImpairmentsUtil._sortOrderBy));
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
                _html.AppendLine(               ePFStaffUI.GetValueSearch(ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN).ToString());
                _html.AppendLine("              <div class='contentbody-left search-section1'>");
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());                
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());         
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section2'>");                                    
                _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Sort"]).ToString());
                _html.AppendLine("              </div>");
                _html.AppendLine("              <div class='contentbody-left search-section3'>");
                _html.AppendLine("                  <div class='button'>");
                _html.AppendLine("                      <div class='button-layout'>");
                _html.AppendLine("                          <div class='button-content'>");
                _html.AppendLine("                              <ul class='button-style1'>");
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN);
                _html.AppendFormat("                                <li class='nomargin'><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN);
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
}