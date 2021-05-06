// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๓/๐๖/๒๕๕๘>
// Modify date  : <๒๓/๐๕/๒๕๕๙>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการจัดการระบบ>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;

public class UDSStaffSettingUI
{
    public class AccesstotheSystemUI
    {
        private static string _idSectionEdit = UDSStaffUtil.ID_SECTION_SETTINGACCESSTOTHESYSTEM_EDIT.ToLower();

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
                case "EDIT" : { _html = SectionAddUpdateUI.SectionEditUI.GetMain(_infoLogin, _id); break; }
            }

            return _html;
        }
        
        public class SectionAddUpdateUI
        {
            private static string _idSectionAddUpdate = String.Empty;

            public class SectionEditUI
            {
                //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ แล้วส่งค่ากลับเป็น StringBuilder
                //โดยมีพารามิเตอร์ดังนี้
                //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
                //2. _id        เป็น string รับค่ารหัสที่ตั้องการ
                public static StringBuilder GetMain(Dictionary<string, object> _infoLogin, string _id)
                {
                    Dictionary<string, object> _infoData = new Dictionary<string, object>();
                    Dictionary<string, object> _infoDataResult = UDSStaffUtil.GetInfoData(UDSStaffUtil.PAGE_SETTINGACCESSTOTHESYSTEM_EDIT, _infoData);
                    StringBuilder _html = new StringBuilder();

                    _idSectionAddUpdate = _idSectionEdit;

                    _html.AppendLine(UDSStaffUI.GetInfoBar(_infoDataResult, true).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(UDSStaffUtil.PAGE_SETTINGACCESSTOTHESYSTEM_EDIT, _id)).ToString());
                    _html.AppendLine(SectionAddUpdateUI.GetMain(_infoLogin).ToString());

                    return _html;
                }
            }

            //ฟังก์ชั่นสำหรับแสดงค่าต่าง ๆ ของข้อมูลที่บันทึกไว้ให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลที่บันทึกไว้
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSStaffUtil.SUBJECT_SECTION_ACCESSTOTHESYSTEM] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-startdate-hidden' value='{1}' />",         _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StartDate", _dataRecorded["StartDate"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-starthour-hidden' value='{1}' />",         _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StartHour", _dataRecorded["StartHour"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-startminute-hidden' value='{1}' />",       _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StartMinute", _dataRecorded["StartMinute"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-startsecond-hidden' value='{1}' />",       _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StartSecond", _dataRecorded["StartSecond"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-enddate-hidden' value='{1}' />",           _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EndDate", _dataRecorded["EndDate"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-endhour-hidden' value='{1}' />",           _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EndHour", _dataRecorded["EndHour"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-endminute-hidden' value='{1}' />",         _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EndMinute", _dataRecorded["EndMinute"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-endsecond-hidden' value='{1}' />",         _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EndSecond", _dataRecorded["EndSecond"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />",      _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearEntry", _dataRecorded["YearEntry"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />",      _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EntranceType", _dataRecorded["EntranceType"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-facultyprogram-hidden' value='{1}' />",    _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FacultyProgram", _dataRecorded["FacultyProgram"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />",   _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CancelledStatus", _dataRecorded["CancelledStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
            public static StringBuilder GetMain(Dictionary<string, object> _infoLogin)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                DataSet _ds1 = new DataSet();
                DataSet _ds2 = new DataSet();
                string _username = _infoLogin["Username"].ToString();
                string _systemGroup = _infoLogin["SystemGroup"].ToString();
                string _faculty = _infoLogin["Faculty"].ToString();
                string _program = _infoLogin["Program"].ToString();            
                int _i = 0;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='startenddatetime'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-startdate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <span><div id='{0}-starthour-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxHour(_idSectionAddUpdate + "-starthour"));
                _contentTemp.AppendLine("       <span class='th-label'>:</span>");
                _contentTemp.AppendFormat("     <span><div id='{0}-startminute-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxMinute(_idSectionAddUpdate + "-startminute"));
                _contentTemp.AppendLine("       <span class='th-label'>:</span>");
                _contentTemp.AppendFormat("     <span><div id='{0}-startsecond-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxSecond(_idSectionAddUpdate + "-startsecond"));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-startdatetime"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เริ่มต้นวันเวลาทำการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Set Office Hour Start DateTime");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", "dd/mm/yyyy hh:mm:ss");
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("StartDate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='startenddatetime'>");
                _contentTemp.AppendFormat(" <div class='contentbody-left'><input class='inputcalendar' type='text' id='{0}-enddate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("   <div class='contentbody-left'>");
                _contentTemp.AppendFormat("     <span><div id='{0}-endhour-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxHour(_idSectionAddUpdate + "-endhour"));
                _contentTemp.AppendLine("       <span class='th-label'>:</span>");
                _contentTemp.AppendFormat("     <span><div id='{0}-endminute-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxMinute(_idSectionAddUpdate + "-endminute"));
                _contentTemp.AppendLine("       <span class='th-label'>:</span>");
                _contentTemp.AppendFormat("     <span><div id='{0}-endsecond-combobox'>{1}</div></span>", _idSectionAddUpdate, UDSStaffUI.GetComboboxSecond(_idSectionAddUpdate + "-endsecond"));
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-enddatetime"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "สิ้นสุดวันเวลาทำการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Set Office Hour End DateTime");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", "dd/mm/yyyy hh:mm:ss");
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EndDate", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'>");
                _contentTemp.AppendLine("       <div class='list'>");
                _contentTemp.AppendLine("           <div class='list-layout'>");
                _contentTemp.AppendLine("               <div class='list-content'>");

                _ds1 = Util.DBUtil.GetListYearEntry();

                foreach (DataRow _dr in _ds1.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("               <div class='list-row'>");
                    _contentTemp.AppendLine("                   <div class='list-col'>");
                    _contentTemp.AppendLine("                       <div class='checkbox-content'>");
                    _contentTemp.AppendLine("                           <ul>");
                    _contentTemp.AppendFormat("                             <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-yearattended' value='{1}' /></li>", _idSectionAddUpdate, _dr["yearEntry"].ToString());
                    _contentTemp.AppendFormat("                             <li class='checkbox-labelcol'><div class='th-label'>{0}</div></li>", _dr["yearEntry"].ToString());
                    _contentTemp.AppendLine("                           </ul>");
                    _contentTemp.AppendLine("                       </div>");
                    _contentTemp.AppendLine("                       <div class='clear'></div>");
                    _contentTemp.AppendLine("                   </div>");
                    _contentTemp.AppendLine("               </div>");
                }

                _ds1.Dispose();

                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
            
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearattended"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เฉพาะนักศึกษาปี");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Year Attended");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'>");
                _contentTemp.AppendLine("       <div class='list'>");
                _contentTemp.AppendLine("           <div class='list-layout'>");
                _contentTemp.AppendLine("               <div class='list-content'>");
                
                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");                
                
                _ds1 = Util.DBUtil.GetListEntranceType(_paramSearch);

                foreach (DataRow _dr in _ds1.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("             <div class='list-row'>");
                    _contentTemp.AppendLine("                   <div class='list-col'>");
                    _contentTemp.AppendLine("                       <div class='checkbox-content'>");
                    _contentTemp.AppendLine("                           <ul>");
                    _contentTemp.AppendFormat("                             <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-entrancetype' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("                             <li class='checkbox-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["entranceTypeNameTH"].ToString(), _dr["entranceTypeNameEN"].ToString());
                    _contentTemp.AppendLine("                           </ul>");
                    _contentTemp.AppendLine("                       </div>");
                    _contentTemp.AppendLine("                       <div class='clear'></div>");
                    _contentTemp.AppendLine("                   </div>");
                    _contentTemp.AppendLine("               </div>");
                }

                _ds1.Dispose();

                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-entrancetype"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เฉพาะระบบการสอบเข้า");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Entrance Examination System");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'>");
                _contentTemp.AppendLine("       <div class='list'>");
                _contentTemp.AppendLine("           <div class='list-layout'>");
                _contentTemp.AppendLine("               <div class='list-content'>");

                _paramSearch.Clear();
                _paramSearch.Add("Faculty", _faculty);

                _ds1 = Util.DBUtil.GetListFaculty(_username, _systemGroup, _paramSearch);

                foreach (DataRow _dr1 in _ds1.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("               <div class='list-row'>");
                    _contentTemp.AppendLine("                   <div class='list-col'>");
                    _contentTemp.AppendLine("                       <div class='checkbox-content'>");
                    _contentTemp.AppendLine("                           <ul>");
                    _contentTemp.AppendFormat("                             <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-faculty' id='{0}-faculty{1}' value='{1}' /></li>", _idSectionAddUpdate, _dr1["facultyId"].ToString());
                    _contentTemp.AppendFormat("                             <li class='checkbox-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", (_dr1["facultyCode"].ToString() + " : " + _dr1["facultyNameTH"].ToString()), (!String.IsNullOrEmpty(_dr1["facultyNameEN"].ToString()) ? Util.UppercaseFirst(_dr1["facultyNameEN"].ToString()) : String.Empty));
                    _contentTemp.AppendLine("                           </ul>");
                    _contentTemp.AppendLine("                       </div>");
                    _contentTemp.AppendLine("                       <div class='clear'></div>");
                    _contentTemp.AppendLine("                   </div>");
                    _contentTemp.AppendLine("               </div>");

                    _paramSearch.Clear();
                    _paramSearch.Add("DegreeLevel", String.Empty);
                    _paramSearch.Add("Faculty", _dr1["facultyId"].ToString());
                    _paramSearch.Add("Program", _program);

                    _ds2 = Util.DBUtil.GetListProgram(_username, _systemGroup, _paramSearch);

                    foreach (DataRow _dr2 in _ds2.Tables[0].Rows)
                    {
                        _contentTemp.AppendFormat("         <div class='list-row program-list-row faculty-{0}'>", _dr1["facultyId"].ToString());
                        _contentTemp.AppendLine("               <div class='list-col'>");
                        _contentTemp.AppendLine("                   <div class='checkbox-content'>");
                        _contentTemp.AppendLine("                       <ul>");
                        _contentTemp.AppendFormat("                         <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}-program' value='{1}' /></li>", _idSectionAddUpdate, _dr2["programId"].ToString());
                        _contentTemp.AppendFormat("                         <li class='checkbox-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", (_dr2["programCode"].ToString() + " " + _dr2["majorCode"].ToString() + " " + _dr2["groupNum"].ToString() + " : " + _dr2["programNameTH"].ToString()), (!String.IsNullOrEmpty(_dr2["programNameEN"].ToString()) ? Util.UppercaseFirst(_dr2["programNameEN"].ToString()) : String.Empty));
                        _contentTemp.AppendLine("                       </ul>");
                        _contentTemp.AppendLine("                   </div>");
                        _contentTemp.AppendLine("                   <div class='clear'></div>");
                        _contentTemp.AppendLine("               </div>");
                        _contentTemp.AppendLine("           </div>");
                    }

                    _ds2.Dispose();
                }

                _ds1.Dispose();

                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-facultyprogram"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เฉพาะนักศึกษาคณะ / หลักสูตร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Faculty / Program");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("FacultyProgram", _contentFrmColumnDetail[_i]);
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
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["StartDate"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["EndDate"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());            
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["FacultyProgram"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["CancelledStatus"]).ToString());
                _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine("</div>");

                return _html;
            }
        }
    }
}