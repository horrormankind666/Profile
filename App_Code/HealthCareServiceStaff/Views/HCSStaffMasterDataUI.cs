// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๐๗/๒๕๕๘>
// Modify date  : <๐๘/๐๗/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการจัดการข้อมูลหลัก>
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

public class HCSStaffMasterDataUI
{
    public class HospitalOfHealthCareServiceUI
    {
        private static string _idSectionMain    = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN.ToLower();
        private static string _idSectionSearch  = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_SEARCH.ToLower();
        private static string _idSectionNew     = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW.ToLower();
        private static string _idSectionEdit    = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT.ToLower();

        //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามส่วนที่ต้องการแสดงในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
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
                case "MAIN"     : { _html = SectionMainUI.GetMain(_infoLogin); break; }
                case "SEARCH"   : { _html = SectionSearchUI.GetMain(); break; }
                case "NEW"      : { _html = SectionAddUpdateUI.SectionNewUI.GetMain(); break; } 
                case "EDIT"     : { _html = SectionAddUpdateUI.SectionEditUI.GetMain(_id); break; }
            }

            return _html;
        }

        public class SectionMainUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าหลักในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN, _infoData);
                Dictionary<string, object> _searchResult = HCSStaffMasterDataUtil.HospitalOfHealthCareServiceUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", HCSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                        <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>",            double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>",   double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงรายการในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            //2. _dr        เป็น DataRow[] รับค่าชุดของข้อมูล
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
                        _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";
                        _callFunc   = "Util.gotoPage({" +
                                      "page:('index.aspx?p=" + HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT + "&id=" + _dr1["id"] + "')" +
                                      "})";                        

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, (!String.IsNullOrEmpty(_dr1["hospitalNameTH"].ToString()) ? _dr1["hospitalNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, (!String.IsNullOrEmpty(_dr1["hospitalNameEN"].ToString()) ? _dr1["hospitalNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
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
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อ</span><span class='en-label'> : ID / Name</span>");
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + HCSStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffMasterDataUtil.HospitalOfHealthCareServiceUtil._sortOrderBy));
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
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN);
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
                _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
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

        public class SectionAddUpdateUI
        {
            private static string _idSectionAddUpdate = String.Empty;
            
            public class SectionNewUI    
            {                                                    
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_NEW, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionNew;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());                    
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(null).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            public class SectionEditUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
                //โดยมีพารามิเตอร์ดังนี้
                //1. _id    เป็น string รับค่ารหัสที่ตั้องการ
                public static StringBuilder GetMain(string _id)
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionEdit;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(HCSStaffUtil.SetValueDataRecorded(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_EDIT, _id)).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้            
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + HCSStaffUtil.SUBJECT_SECTION_HOSPITALOFHEALTHCARESERVICE] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Id", _dataRecorded["Id"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-hospitalnameth-hidden' value='{1}' />",    _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "HospitalNameTH", _dataRecorded["HospitalNameTH"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-hospitalnameen-hidden' value='{1}' />",    _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "HospitalNameEN", _dataRecorded["HospitalNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />",   _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CancelledStatus", _dataRecorded["CancelledStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-id"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "รหัส");
                _contentFrmColumnDetail[_i].Add("TitleEN", "ID");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-id' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("ID", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-hospitalnameth"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อหน่วยบริการสุขภาพ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Hospital Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-hospitalnameth' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("HospitalNameTH", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-hospitalnameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อหน่วยบริการสุขภาพ ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Hospital Name ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-hospitalnameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("HospitalNameEN", _contentFrmColumnDetail[_i]);
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
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ID"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["HospitalNameTH"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["HospitalNameEN"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");  

                return _html;
            }
        }
    }

    public class RegistrationFormUI
    {
        private static string _idSectionMain    = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_MAIN.ToLower();
        private static string _idSectionSearch  = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_SEARCH.ToLower();
        private static string _idSectionNew     = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_NEW.ToLower();
        private static string _idSectionEdit    = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_EDIT.ToLower();

        //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามส่วนที่ต้องการแสดงในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
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
                case "MAIN"     : { _html = SectionMainUI.GetMain(_infoLogin); break; }
                case "SEARCH"   : { _html = SectionSearchUI.GetMain(); break; }                
                case "NEW"      : { _html = SectionAddUpdateUI.SectionNewUI.GetMain(); break; }
                case "EDIT"     : { _html = SectionAddUpdateUI.SectionEditUI.GetMain(_id); break; }
            }

            return _html;
        }

        public class SectionMainUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าหลักในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN, _infoData);
                Dictionary<string, object> _searchResult = HCSStaffMasterDataUtil.RegistrationFormUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN, null, true));
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", HCSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                        <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>",            double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>",   double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>ID</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='en-label'>Name</div><div class='en-label'>( TH )</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col4'><div class='table-col-msg'><div class='en-label'>Name</div><div class='en-label'>( EN )</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>For Public</div><div class='en-label'>Servant</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='en-label'>Order</div><div class='en-label'>Form</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงรายการในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            //2. _dr        เป็น DataRow[] รับค่าชุดของข้อมูล
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
                        _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";                        
                        _callFunc   = "Util.gotoPage({" +
                                      "page:('index.aspx?p=" + HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_EDIT + "&id=" + _dr1["id"] + "')" +
                                      "})";                        

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["id"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["id"].ToString()) ? _dr1["id"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, (!String.IsNullOrEmpty(_dr1["formNameTH"].ToString()) ? _dr1["formNameTH"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, (!String.IsNullOrEmpty(_dr1["formNameEN"].ToString()) ? _dr1["formNameEN"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["forPublicServant"].ToString()) ? _dr1["forPublicServant"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["orderForm"].ToString()) ? _dr1["orderForm"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
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
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>รหัส / ชื่อ</span><span class='en-label'> : ID / Name</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-forpublicservant"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สำหรับข้าราชการ</span><span class='en-label'>&nbsp;&nbsp;&nbsp;: For Public Servant</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-forpublicservant-combobox'>" + HCSStaffUI.GetComboboxActiveStatus(_idSectionSearch + "-forpublicservant") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ForPublicServant", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + HCSStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffMasterDataUtil.RegistrationFormUtil._sortOrderBy));
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
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN);
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
                _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Keyword"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ForPublicServant"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
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

        public class SectionAddUpdateUI
        {
            private static string _idSectionAddUpdate = String.Empty;

            public class SectionNewUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_NEW, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionNew;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(null).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            public class SectionEditUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
                //โดยมีพารามิเตอร์ดังนี้
                //1. _id    เป็น string รับค่ารหัสที่ตั้องการ
                public static StringBuilder GetMain(string _id)
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_EDIT, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionEdit;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(HCSStaffUtil.SetValueDataRecorded(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_EDIT, _id)).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้            
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + HCSStaffUtil.SUBJECT_SECTION_REGISTRATIONFORM] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Id", _dataRecorded["Id"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-formnameth-hidden' value='{1}' />",        _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FormNameTH", _dataRecorded["FormNameTH"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-formnameen-hidden' value='{1}' />",        _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FormNameEN", _dataRecorded["FormNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-forpublicservant-hidden' value='{1}' />",  _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ForPublicServant", _dataRecorded["ForPublicServant"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-orderform-hidden' value='{1}' />",         _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "OrderForm", _dataRecorded["OrderForm"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />",   _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CancelledStatus", _dataRecorded["CancelledStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-id"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "รหัส");
                _contentFrmColumnDetail[_i].Add("TitleEN", "ID");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-id' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("ID", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-formnameth"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อแบบฟอร์มบริการสุขภาพ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Form Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-formnameth' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FormNameTH", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-formnameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อแบบฟอร์มบริการสุขภาพ ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Form Name ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-formnameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FormNameEN", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='nomargin checkbox-content'>");
                _contentTemp.AppendLine("   <ul>");
                _contentTemp.AppendFormat("     <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-forpublicservant' value='Y' /></li>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <li class='checkbox-labelcol'></li>");
                _contentTemp.AppendLine("   </ul>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-forpublicservant"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "แบบฟอร์มสำหรับข้าราชการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "For Public Servant");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("ForPublicServant", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-orderform"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ลำดับแบบฟอร์ม");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Order Form");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionSearch + "-orderform-combobox'>" + HCSStaffUI.GetComboboxOrder((_idSectionAddUpdate + "-orderform"), 1, 10) + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("OrderForm", _contentFrmColumnDetail[_i]);
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
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ID"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["FormNameTH"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["FormNameEN"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ForPublicServant"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["OrderForm"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");  

                return _html;
            }
        }
    }

    public class AgencyRegisteredUI
    {
        private static string _idSectionMain    = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_MAIN.ToLower();
        private static string _idSectionSearch  = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_SEARCH.ToLower();
        private static string _idSectionNew     = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_NEW.ToLower();
        private static string _idSectionEdit    = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_EDIT.ToLower();

        //ฟังก์ชั่นสำหรับแสดงเนื้อหาตามส่วนที่ต้องการแสดงในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
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
                case "MAIN"     : { _html = SectionMainUI.GetMain(_infoLogin); break; }
                case "SEARCH"   : { _html = SectionSearchUI.GetMain(); break; }                
                case "NEW"      : { _html = SectionAddUpdateUI.SectionNewUI.GetMain(); break; }
                case "EDIT"     : { _html = SectionAddUpdateUI.SectionEditUI.GetMain(_id); break; }
            }

            return _html;
        }

        public class SectionMainUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าหลักในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN, _infoData);
                Dictionary<string, object> _searchResult = HCSStaffMasterDataUtil.AgencyRegisteredUtil.GetSearch(HCSStaffUtil.SetParameterSearch(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN, null, true));
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky main'>");
                _html.AppendFormat("    <div class='table' id='{0}-table'>", _idSectionMain);
                _html.AppendLine("          <div class='table-layout'>");
                _html.AppendLine("              <div class='table-content'>");
                _html.AppendLine("                  <div class='table-freeze sticky'>");
                _html.AppendLine("                      <div class='table-title'>");
                _html.AppendFormat("                        <div class='contentbody-left table-option table-rowperpage en-label'>{0}</div>", HCSStaffUI.GetComboboxRowPerPage(_idSectionMain + "-rowperpage"));
                _html.AppendFormat("                        <div class='contentbody-right table-recordcount en-label'>");
                _html.AppendFormat("                            <span class='recordcount-search hidden'>{0}</span>",            double.Parse(_searchResult["RecordCount"].ToString()).ToString("#,##0"));
                _html.AppendFormat("                            <span class='recordcountprimary-search th-label'>{0}</span>",   double.Parse(_searchResult["RecordCountPrimary"].ToString()).ToString("#,##0"));
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                      <div class='table-head'>");
                _html.AppendLine("                          <div class='table-row'>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='en-label'>No.</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='en-label'>Year</div><div class='en-label'>Attended</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col3'><div class='table-col-msg'><div class='en-label'>Faculty</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='en-label'>Program</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='en-label'>Hospital</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col6'><div class='table-col-msg'><div class='en-label'>Registration Form</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-dynamic table-col7'><div class='table-col-msg'><div class='en-label'>Address</div><div class='en-label'>for Delivery</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col8'><div class='table-col-msg'><div class='en-label'>Cancelled</div><div class='en-label'>Status</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col9'><div class='table-col-msg'><div class='en-label'>Create Date</div></div></div>");
                _html.AppendLine("                              <div class='table-col table-col-width-fixed table-col10'><div class='table-col-msg'><div class='en-label'>Modify Date</div></div></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='table-list'>{0}</div>", _searchResult["List"]);
                _html.AppendFormat("                <div class='table-navpage'>{0}</div>", _searchResult["NavPage"]);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงรายการในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            //2. _dr        เป็น DataRow[] รับค่าชุดของข้อมูล
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
                        _highlight  = (double.Parse(_dr1["rowNum"].ToString()) % 2) == 0 ? " highlight-style2" : " highlight-style1";                        
                        _callFunc   = "Util.gotoPage({" +
                                      "page:('index.aspx?p=" + HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT + "&id=" + _dr1["id"] + "')" +
                                      "})";                        

                        _html.AppendFormat("<div class='table-row{0}' id='table-row-id-{1}'>", _highlight, _dr1["acaProgramId"]);
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col1' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (double.Parse(_dr1["rowNum"].ToString()).ToString("#,##0")));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col2' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["yearEntry"].ToString()) ? _dr1["yearEntry"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col3' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["facultyCode"].ToString()) ? _dr1["facultyCode"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col4' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["programCode"].ToString()) ? (_dr1["programCode"].ToString() + " " + _dr1["majorCode"].ToString() + " " + _dr1["groupNum"].ToString()) : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col5' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["hcsHospitalId"].ToString()) ? _dr1["hcsHospitalId"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col6' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, (!String.IsNullOrEmpty(_dr1["hcsRegistrationFormId"].ToString()) ? _dr1["hcsRegistrationFormId"].ToString().Replace(",", ",<br />") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-dynamic table-col7' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",  _callFunc, ((!String.IsNullOrEmpty(_dr1["programAddress"].ToString()) ? _dr1["programAddress"].ToString().Replace("&", "<br />") : String.Empty) + (!String.IsNullOrEmpty(_dr1["programTelephone"].ToString()) ? ("<br />" + _dr1["programTelephone"].ToString()) : String.Empty)));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col8' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["cancelledStatus"].ToString()) ? _dr1["cancelledStatus"].ToString() : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col9' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["createDate"].ToString()) ? DateTime.Parse(_dr1["createDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendFormat("    <div class='table-col table-col-width-fixed table-col10' onclick={0}><div class='table-col-msg'><div class='th-label'>{1}</div></div></div>",    _callFunc, (!String.IsNullOrEmpty(_dr1["modifyDate"].ToString()) ? DateTime.Parse(_dr1["modifyDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty));
                        _html.AppendLine("  </div>");
                    }

                    _html.AppendLine("</div>");
                }

                return _html;
            }
        }

        public class SectionSearchUI
        {
            //ฟังก์ชั่นสำหรับแสดงเนื้อหาหน้าค้นหาในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[8];
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                int _i = 0;
                
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

                _paramSearch.Clear();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-hospital"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>หน่วยบริการสุขภาพ</span><span class='en-label'> : Hospital of Health Care Service</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-hospital-combobox'>" + HCSStaffUI.GetComboboxHospital((_idSectionSearch + "-hospital"), _paramSearch) + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Hospital", _contentFrmColumnDetail[_i]);
                _i++;

                _paramSearch.Clear();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-registrationform"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>แบบฟอร์มบริการสุขภาพ</span><span class='en-label'> : Registration Form</span>");
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
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionSearch + "-cancelledstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "<span class='th-label'>สถานะการยกเลิก</span><span class='en-label'> : Cancelled Status</span>");
                _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div class='combobox-width-dynamic' id='" + _idSectionSearch + "-cancelledstatus-combobox'>" + HCSStaffUI.GetComboboxCancelledStatus(_idSectionSearch + "-cancelledstatus") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("CancelledStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='search-sort-content'>");
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <div id='{0}-sortorderby-combobox'>{1}</div>", _idSectionSearch, HCSStaffUI.GetComboboxOrder((_idSectionSearch + "-sortorderby"), HCSStaffMasterDataUtil.AgencyRegisteredUtil._sortOrderBy));
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
                _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-search' alt='{0}'>SEARCH</div></li>", HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN);
                _contentTemp.AppendFormat("             <li><div class='click-button en-label button-undo' alt='{0}'>CLEAR</div></li>", HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN);
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
                _html.AppendLine(               HCSStaffUI.GetValueSearch(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Hospital"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["RegistrationForm"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
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

        public class SectionAddUpdateUI
        {
            private static string _idSectionAddUpdate = String.Empty;

            public class SectionNewUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
                public static StringBuilder GetMain()
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_NEW, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionNew;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(null).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            public class SectionEditUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
                //โดยมีพารามิเตอร์ดังนี้
                //1. _id    เป็น string รับค่ารหัสที่ตั้องการ
                public static StringBuilder GetMain(string _id)
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = HCSStaffUtil.GetInfoData(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionEdit;

                    _html.AppendLine(HCSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(HCSStaffUtil.SetValueDataRecorded(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_EDIT, _id)).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain().ToString());

                    return _html;
                }
            }

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้            
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + HCSStaffUtil.SUBJECT_SECTION_AGENCYREGISTERED] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-id-hidden' value='{1}' />",                _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Id", _dataRecorded["Id"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />",      _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearEntry", _dataRecorded["YearEntry"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-degreelevel-hidden' value='{1}' />",       _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "DegreeLevel", _dataRecorded["DegreeLevel"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-faculty-hidden' value='{1}' />",           _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Faculty", _dataRecorded["Faculty"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-program-hidden' value='{1}' />",           _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Program", _dataRecorded["Program"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-programaddress-hidden' value='{1}' />",    _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ProgramAddress", _dataRecorded["ProgramAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-programtelephone-hidden' value='{1}' />",  _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ProgramTelephone", _dataRecorded["ProgramTelephone"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-hospital-hidden' value='{1}' />",          _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Hospital", _dataRecorded["Hospital"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-registrationform-hidden' value='{1}' />",  _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RegistrationForm", _dataRecorded["RegistrationForm"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />",   _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CancelledStatus", _dataRecorded["CancelledStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
            public static StringBuilder GetMain()
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[10];
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _i = 0;
                int _j = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่เข้าศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Year Attended");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yearattended-combobox'>" + HCSStaffUI.GetComboboxYearAttended(_idSectionAddUpdate + "-yearattended") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-degreelevel"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วุฒิการศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Degree Level");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-degreelevel-combobox'>" + HCSStaffUI.GetComboboxDegreeLevel(_idSectionAddUpdate + "-degreelevel") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("DegreeLevel", _contentFrmColumnDetail[_i]);
                _i++;
                               
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-faculty"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "คณะ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Faculty");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-faculty-combobox'>" + HCSStaffUI.GetComboboxFaculty(_idSectionAddUpdate + "-faculty") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Faculty", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'>");
                _contentTemp.AppendLine("       <div class='list'>");
                _contentTemp.AppendLine("           <div class='list-layout'>");
                _contentTemp.AppendFormat("             <div class='list-content' id='{0}-program-list'></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หลักสูตร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Program");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;
                
                /*
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-program"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หลักสูตร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Program");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<div id='" + _idSectionAddUpdate + "-program-combobox'></div>");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Program", _contentFrmColumnDetail[_i]);
                _i++;
                */

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-hospital"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หน่วยบริการสุขภาพ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Hospital of Health Care Service");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-hospital-combobox'>" + HCSStaffUI.GetComboboxHospital((_idSectionAddUpdate + "-hospital"), _paramSearch) + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Hospital", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _ds = HCSStaffDB.GetListHCSRegistrationForm(_paramSearch);

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("<div class='checkbox-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-registrationform' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("     <li class='checkbox-labelcol'><div class='th-label'>{0} - {1}</div><div class='en-label'>{2}</div></li>", _dr["id"].ToString(), _dr["formNameTH"].ToString(), _dr["formNameEN"].ToString());
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _ds.Dispose();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-registrationform"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "แบบฟอร์มบริการสุขภาพ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Registration Form");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("RegistrationForm", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-programaddress"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ที่อยู่สำหรับจัดส่งเอกสาร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Address for Delivery");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<textarea class='textareabox' id='" + _idSectionAddUpdate + "-programaddress'></textarea>");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ProgramAddress", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-programtelephone"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์โทรศัพท์");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Telephone");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-programtelephone' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("ProgramTelephone", _contentFrmColumnDetail[_i]);
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
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Hospital"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["RegistrationForm"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ProgramAddress"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["ProgramTelephone"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");  

                return _html;
            }
        }
    }
}