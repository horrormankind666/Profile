/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๘/๐๕/๒๕๕๘>
Modify date : <๐๗/๐๖/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการอัพโหลดเอกสารของนักศึกษา>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using NUtil;

public class UDSUploadSubmitDocumentUI
{
    private static string _idSectionMain = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_MAIN.ToLower();
    private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_ADDUPDATE.ToLower();

    public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
    {                        
        StringBuilder _html = new StringBuilder();
        
        switch (_section)
        {
            case "MAIN" :
                _html = SectionMainUI.GetMain(_id);
                break;
        }
        
        return _html;
    }

    public class SectionMainUI
    {
        public static StringBuilder GetMain(string _id)
        {
            StringBuilder _html = new StringBuilder();
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = UDSUtil.GetInfoData(UDSUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN, _infoData);
            int _i = 0;

            _html.AppendLine(UDSUI.GetInfoBar(_infoDataResult, true).ToString());                        
            _html.AppendLine("<div class='after-sticky'>");
            _html.AppendLine("  <div>");
            _html.AppendFormat("    <div class='sticky-left menulist' id='{0}-menu'>", _idSectionMain);
            _html.AppendLine("          <div class='menulist-layout'>");
            _html.AppendFormat("            <div class='menulist-content' id='{0}-menu-content'>", _idSectionMain);
            _html.AppendLine("                  <ul>");

            for (_i = 0; _i < 4; _i++)
            {
                _html.AppendFormat("                <li class='have-link'><a class='link-click link-msg{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>", (UDSUploadSubmitDocumentUtil._menuUpload[_i, 4].Equals("active") ? " menu-active" : String.Empty), UDSUploadSubmitDocumentUtil._menuUpload[_i, 6].ToLower(), UDSUploadSubmitDocumentUtil._menuUpload[_i, 0], UDSUploadSubmitDocumentUtil._menuUpload[_i, 1]);
            }

            _html.AppendLine("                  </ul>");
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendFormat("    <div id='{0}'>", _idSectionAddUpdate);
            _html.AppendFormat("        <div id='{0}-layout'>", _idSectionAddUpdate);
            _html.AppendFormat("            <div id='{0}-content'>", _idSectionAddUpdate);
            _html.AppendFormat("                <div class='menu-active' id='{0}'>{1}</div>", UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE.ToLower(), SectionAddUpdateUI.StudentRecordsUI.GetMain(_id));
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", UDSUploadSubmitDocumentUtil._menuUpload[0, 6].ToLower(), UDSUploadSubmitDocumentUtil._menuUpload[0, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", UDSUploadSubmitDocumentUtil._menuUpload[1, 6].ToLower(), UDSUploadSubmitDocumentUtil._menuUpload[1, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", UDSUploadSubmitDocumentUtil._menuUpload[2, 6].ToLower(), UDSUploadSubmitDocumentUtil._menuUpload[2, 7], String.Empty);
            _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", UDSUploadSubmitDocumentUtil._menuUpload[3, 6].ToLower(), UDSUploadSubmitDocumentUtil._menuUpload[3, 7], String.Empty);
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("  </div");
            _html.AppendLine("</div");
            
            return _html;
        }    
    }
    public class SectionAddUpdateUI
    {        
        public class StudentRecordsUI
        {
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-personid-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PersonId", _dataRecorded["PersonId"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentcode-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentCode", _dataRecorded["StudentCode"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Gender", _dataRecorded["Gender"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentpicture-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[11];
                Dictionary<string, object> _valueDataRecorded = UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS];
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
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["StudentPicture"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["StudentID"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["FullName"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["YearEntry"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(               UDSUI.GetFrmColumn(_contentFrmColumn["GraduationDate"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class OverviewUI
        {
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE.ToLower();
            
            private static Dictionary<string, Dictionary<string, object>> GetFrmDocumentOverview(string _section)
            {       
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[UDSUploadSubmitDocumentUtil._documentUploadDetail.GetLength(0)];
                string _idContent = String.Empty;
                bool _show = false;
                int _i = 0;

                for (_i = 0; _i < UDSUploadSubmitDocumentUtil._documentUploadDetail.GetLength(0); _i++)
                {
                    _show = false;
                    _idContent = (_idSectionAddUpdate+ "-" + _section.ToLower());
                    _contentTemp.Clear();

                    if (_show.Equals(false) && UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("NameofInstitution"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutenameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutenameen"));
                    }

                    if (_show.Equals(false) && UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Country"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutecountrynameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "institutecountrynameen"));
                    }

                    if (_show.Equals(false) && UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Province"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "instituteprovincenameth"));
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + "instituteprovincenameen"));
                    }

                    if (_show.Equals(false) && UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("ApprovalStatus"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='uploaddocument-approvalstatus en-label link-{0}' id='{1}'>?</div>", UDSUtil.SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS.ToLower(), (_idContent + UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    }

                    if (_show.Equals(false) && UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].Equals("Message"))
                    {
                        _show = true;
                        _contentTemp.AppendFormat("<div class='en-label' id='{0}'></div>", (_idContent + UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    }

                    if (_show.Equals(false))
                        _contentTemp.AppendFormat("<div class='th-label' id='{0}'></div>", (_idContent + UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1].ToLower()));
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", _idContent);
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("TitleEN", UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 0]);
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add((_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[_i, 1]), _contentFrmColumnDetail[_i]);
                }

                return _contentFrmColumn;
            }
            
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW];
                string _section = String.Empty;
                string[] _keyDict = new string[16];
                int _i = 0;

                for (_i = 0; _i < UDSUploadSubmitDocumentUtil._documentUpload.GetLength(0); _i++)
                {
                    _section = UDSUploadSubmitDocumentUtil._documentUpload[_i, 2];
                    _keyDict[0] = (_section + "InstituteNameTH");
                    _keyDict[1] = (_section + "InstituteNameEN");
                    _keyDict[2] = (_section + "InstituteCountryNameTH");
                    _keyDict[3] = (_section + "InstituteCountryNameEN");
                    _keyDict[4] = (_section + "InstituteProvinceNameTH");
                    _keyDict[5] = (_section + "InstituteProvinceNameEN");
                    _keyDict[6] = (_section + "FileDir");
                    _keyDict[7] = (_section + "FileName");
                    _keyDict[8] = (_section + "FullPath");
                    _keyDict[9] = (_section + "FileType");
                    _keyDict[10] = (_section + "FileSize");
                    _keyDict[11] = (_section + "SavedDate");
                    _keyDict[12] = (_section + "SubmittedStatus");
                    _keyDict[13] = (_section + "ApprovalStatus");
                    _keyDict[14] = (_section + "ApprovalDate");
                    _keyDict[15] = (_section + "Message");

                    if (_section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE) || _section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
                    {
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutenameth-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[0], _dataRecorded[_keyDict[0]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutenameen-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[1], _dataRecorded[_keyDict[1]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutecountrynameth-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[2], _dataRecorded[_keyDict[2]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}institutecountrynameen-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[3], _dataRecorded[_keyDict[3]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}instituteprovincenameth-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[4], _dataRecorded[_keyDict[4]], Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-{1}instituteprovincenameen-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[5], _dataRecorded[_keyDict[5]], Util._valueTextDefault));
                    }

                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filedir-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[6], _dataRecorded[_keyDict[6]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filename-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[7], _dataRecorded[_keyDict[7]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}fullpath-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[8], _dataRecorded[_keyDict[8]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filetype-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[9], _dataRecorded[_keyDict[9]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}filesize-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[10], _dataRecorded[_keyDict[10]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}saveddate-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[11], _dataRecorded[_keyDict[11]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}submittedstatus-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[12], _dataRecorded[_keyDict[12]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}approvalstatus-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[13], _dataRecorded[_keyDict[13]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}approvaldate-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[14], _dataRecorded[_keyDict[14]], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-{1}message-hidden' value='{2}' />", _idSectionAddUpdate, _section.ToLower(), Util.GetValueDataDictionary(_dataRecorded, _keyDict[15], _dataRecorded[_keyDict[15]], Util._valueTextDefault));
                }

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {        
                StringBuilder _html = new StringBuilder();                
                StringBuilder _contentTemp = new StringBuilder();            
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                string _section = String.Empty;

                _html.AppendLine(GetValueDataRecorded(UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE, _id)).ToString());            
                _html.AppendFormat("<div id='{0}-form'>", _idSectionAddUpdate);            
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_PROFILEPICTURE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadSubmitDocumentUtil._documentUpload[0, 0], UDSUploadSubmitDocumentUtil._documentUpload[0, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content profilepicture-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.PAGE_VIEWPROFILEPICTURE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");

                                                                _section = UDSUploadSubmitDocumentUtil._documentUpload[0, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_IDENTITYCARD.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadSubmitDocumentUtil._documentUpload[1, 0], UDSUploadSubmitDocumentUtil._documentUpload[1, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content identitycard-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.PAGE_VIEWIDENTITYCARD_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");

                                                                _section = UDSUploadSubmitDocumentUtil._documentUpload[1, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);
                
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());                
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadSubmitDocumentUtil._documentUpload[2, 0], UDSUploadSubmitDocumentUtil._documentUpload[2, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendFormat("                    <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptfrontside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.PAGE_VIEWTRANSCRIPTFRONTSIDE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
                                                                
                                                                _section = UDSUploadSubmitDocumentUtil._documentUpload[2, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadSubmitDocumentUtil._documentUpload[3, 0], UDSUploadSubmitDocumentUtil._documentUpload[3, 1]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptbackside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.PAGE_VIEWTRANSCRIPTBACKSIDE_MAIN);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
                                                                
                                                                _section = UDSUploadSubmitDocumentUtil._documentUpload[3, 2];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadSubmitDocumentUtil._documentUploadDetail[10, 1]]).ToString());
                                                                
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

        private static StringBuilder GetFrmUploadFile(string _section)
        {
            StringBuilder _html = new StringBuilder();

            _html.AppendFormat("<form class='uploadfile-form' id='uploadfile-{0}-form' action='UDSUploadFile.aspx' enctype='multipart/form-data' target='frame-util' onSubmit='Util.startUploadFile()'>", _section.ToLower());
            _html.AppendFormat("    <input type='hidden' id='uploadfile-section' name='uploadfile-section' value='{0}' />", _section);
            _html.AppendFormat("    <input type='hidden' id='uploadfile-personid' name='uploadfile-personid' value='' />");
            _html.AppendLine("      <div class='uploadfile-content'>");
            _html.AppendFormat("        <div class='uploadfile-label en-label' id='uploadfile-{0}-label'></div>", _section.ToLower());
            _html.AppendLine("          <div class='button'>");
            _html.AppendLine("              <div class='button-layout'>");
            _html.AppendLine("                  <div class='button-content'>");
            _html.AppendLine("                      <ul class='button-style1'>");
            _html.AppendFormat("                        <li class='nomargin'><div class='uploadfile-button browse-uploadfile en-label' alt='{0}' id='browse-uploadfile-{1}'>BROWSE<input type='file' id='{1}-browse-uploadfile' name='{1}-browse-uploadfile' alt='uploadfile-{1}' /></div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='clear-uploadfile-{1}'>CLEAR</div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='upload-uploadfile-{1}'>UPLOAD</div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='save-uploadfile-{1}'>CROP & SAVE</div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='delete-uploadfile-{1}'>DELETE</div></li>", _section, _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' alt='{0}' id='submit-uploadfile-{1}'>SUBMIT</div></li>", _section, _section.ToLower());
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
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE];

                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileDir", _dataRecorded["ProfilePictureFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileName", _dataRecorded["ProfilePictureFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />", _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />", _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureWidth", _dataRecorded["ProfilePictureWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureHeight", _dataRecorded["ProfilePictureHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSavedStatus", _dataRecorded["ProfilePictureSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSubmittedStatus", _dataRecorded["ProfilePictureSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureApprovalStatus", _dataRecorded["ProfilePictureApprovalStatus"], Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(GetValueDataRecorded(UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE, _id)).ToString());
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
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myProfilePictureWidth, UDSUtil._myProfilePictureHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myProfilePictureWidth, UDSUtil._myProfilePictureHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_PROFILEPICTURE));
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
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD];

                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileDir", _dataRecorded["IdentityCardFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileName", _dataRecorded["IdentityCardFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-cropx-hidden' value='{1}' />", _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-cropy-hidden' value='{1}' />", _idSectionAddUpdate, Util._valueTextDefault);
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardWidth", _dataRecorded["IdentityCardWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardHeight", _dataRecorded["IdentityCardHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSavedStatus", _dataRecorded["IdentityCardSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSubmittedStatus", _dataRecorded["IdentityCardSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardApprovalStatus", _dataRecorded["IdentityCardApprovalStatus"], Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();

                _html.AppendLine(GetValueDataRecorded(UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE, _id)).ToString());
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
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myIdentityCardWidth, UDSUtil._myIdentityCardHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myIdentityCardWidth, UDSUtil._myIdentityCardHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_IDENTITYCARD));
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
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptInstituteAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptFrontsideAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptBacksideAddUpdate = UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT];

                _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />",  _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstituteCountry", _dataRecorded["TranscriptInstituteCountry"], Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstituteProvince", _dataRecorded["TranscriptInstituteProvince"], Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institute-hidden' value='{1}' />", _idSectionTranscriptInstituteAddUpdate, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstitute", _dataRecorded["TranscriptInstitute"], Util._valueComboboxDefault));            
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

            //ฟังก์ชั่นสำหรับแสดงเนื้อหาให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดระเบียนแสดงผลการเรียนในส่วนของการการอัพโหลดและส่งเอกสารของนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionTranscriptInstituteAddUpdate + "-institutecountry-combobox'>" + UDSUI.GetComboboxCountry(_idSectionTranscriptInstituteAddUpdate + "-institutecountry") + "</div>"));
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
                
                _html.AppendLine(GetValueDataRecorded(UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE, _id)).ToString());                
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
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
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
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE));
                _html.AppendLine("                      </div>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                          <div>");
                _html.AppendLine("                              <div class='nomargin picture-content transcriptbackside-content'>");
                _html.AppendLine("                                  <div class='transcriptbackside-example'></div>");
                _html.AppendLine("                                  <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ : </span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='picture-content transcriptbackside-content'>");
                _html.AppendFormat("                                <div class='picture-recommend' id='{0}-recommend'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE));
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
    /*
    public class SectionAddUpdate
    {
        public class OverviewUI
        {
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADDOCUMENTOVERVIEW_ADDUPDATE.ToLower();
        
            //ฟังก์ชั่นสำหรับดึงค่าต่าง ๆ ในการอัพโหลดเอกสารของนักศึกษาในส่วนของผลการอัพโหลดเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลระเบียนประวัตินักศึกษา
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_OVERVIEW];
                string _section = String.Empty;
                string[] _keyDict = new string[16];
                int _i = 0;

                for (_i = 0; _i < UDSUploadDocumentUtil._subjectUpload.GetLength(0); _i++)
                {
                    _section = UDSUploadDocumentUtil._subjectUpload[_i, 1];
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

                    if (_section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE) || _section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
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

            //ฟังก์ชั่นสำหรับแสดงฟอร์มเพิ่มและปรับปรุงข้อมูลการอัพโหลดเอกสารของนักศึกษาในส่วนของผลการอัพโหลดเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {        
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();            
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object> _valueDataRecorded = UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADDOCUMENTOVERVIEW_ADDUPDATE, _id);
                string _section = String.Empty;

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());            
                _html.AppendFormat("<div id='{0}-form'>", _idSectionAddUpdate);            
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_PROFILEPICTURE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadDocumentUtil._subjectUpload[0, 2], UDSUploadDocumentUtil._subjectUpload[0, 3]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content profilepicture-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.SUBJECT_SECTION_PROFILEPICTURE);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
    
                                                                _section = UDSUploadDocumentUtil._subjectUpload[0, 1];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[10, 1]]).ToString());

                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_IDENTITYCARD.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadDocumentUtil._subjectUpload[1, 2], UDSUploadDocumentUtil._subjectUpload[1, 3]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content identitycard-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.SUBJECT_SECTION_IDENTITYCARD);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");

                                                                _section = UDSUploadDocumentUtil._subjectUpload[1, 1];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[10, 1]]).ToString());

                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");            
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadDocumentUtil._subjectUpload[2, 2], UDSUploadDocumentUtil._subjectUpload[2, 3]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendFormat("                    <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptfrontside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
            
                                                                _section = UDSUploadDocumentUtil._subjectUpload[2, 1];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[10, 1]]).ToString());
            
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendLine("                      </div>");            
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div class='form' id='{0}-{1}-form'>", _idSectionAddUpdate, UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE.ToLower());
                _html.AppendLine("          <div class='form-layout'>");
                _html.AppendLine("              <div class='form-content'>");
                _html.AppendLine("                  <div class='uploaddocument-subject'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", UDSUploadDocumentUtil._subjectUpload[3, 2], UDSUploadDocumentUtil._subjectUpload[3, 3]);
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("                  <div class='uploaddocument-layout'>");
                _html.AppendLine("                      <div class='uploaddocument-content'>");
                _html.AppendLine("                          <div class='contentbody-left picture-content transcriptbackside-content'>");
                _html.AppendFormat("                            <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE);
                _html.AppendLine("                              <div class='picture-watermark'></div>");
                _html.AppendLine("                              <img/>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='contentbody-left detaildocument-content'>");
            
                                                                _section = UDSUploadDocumentUtil._subjectUpload[3, 1];
                                                                _contentFrmColumn = GetFrmDocumentOverview(_section);

                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[0, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[1, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[2, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[3, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[4, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[5, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[6, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[7, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[8, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[9, 1]]).ToString());
                _html.AppendLine(                               UDSUI.GetFrmColumn(_contentFrmColumn[_section + UDSUploadDocumentUtil._subjectUploadDetail[10, 1]]).ToString());
            
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

        //ฟังก์ชั่นสำหรับสร้างฟอร์มอัพโหลดเอกสาร แล้วส่งค่ากลับเป็น StringBuilder
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       เป็น string รับค่าชื่อหัวข้อที่ต้องการ
        private static StringBuilder GetFrmUploadFile(string _section)
        {
            StringBuilder _html = new StringBuilder();

            _html.AppendFormat("<form class='uploadfile-form' id='uploadfile-{0}-form' action='UDSUploadFile.aspx' enctype='multipart/form-data' target='frame-util' onSubmit='UDSUtil.startUploadFile()'>", _section.ToLower());
            _html.AppendFormat("    <input type='hidden' id='uploadfile-section' name='uploadfile-section' value='{0}' />", _section);
            _html.AppendFormat("    <input type='hidden' id='uploadfile-personid' name='uploadfile-personid' value='' />");
            _html.AppendLine("      <div class='uploadfile-content'>");
            _html.AppendFormat("        <div class='uploadfile-label en-label' id='uploadfile-{0}-label'></div>", _section.ToLower());
            _html.AppendLine("          <div class='button'>");
            _html.AppendLine("              <div class='button-layout'>");
            _html.AppendLine("                  <div class='button-content'>");
            _html.AppendLine("                      <ul class='button-style1'>");
            _html.AppendFormat("                        <li class='nomargin'><div class='uploadfile-button browse-uploadfile en-label' id='browse-uploadfile-{0}'>BROWSE<input type='file' id='{0}-browse-uploadfile' name='{0}-browse-uploadfile' alt='uploadfile-{0}' /></div></li>", _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' id='clear-uploadfile-{0}'>CLEAR</div></li>", _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' id='upload-uploadfile-{0}'>UPLOAD</div></li>", _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' id='save-uploadfile-{0}'>CROP & SAVE</div></li>", _section.ToLower());
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' id='delete-uploadfile-{0}'>DELETE</div></li>", _section.ToLower());        
            _html.AppendFormat("                        <li><div class='uploadfile-button en-label' id='submit-uploadfile-{0}'>SUBMIT</div></li>", _section.ToLower());
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
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADDOCUMENTPROFILEPICTURE_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับดึงค่าต่าง ๆ ในการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดรูปภาพประจำตัว แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลการอัพโหลดเอกสารของนักศึกษา
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_PROFILEPICTURE];

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

            //ฟังก์ชั่นสำหรับแสดงฟอร์มเพิ่มและปรับปรุงข้อมูลการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดรูปภาพประจำตัว แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADDOCUMENTPROFILEPICTURE_ADDUPDATE, _id);

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());                        
                _html.AppendFormat("<div class='form uploaddocument-form' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");            
                _html.AppendLine("              <div class='uploaddocument-layout' align='center'>");
                _html.AppendLine("                  <div class='uploaddocument-content'>");
                _html.AppendLine("                      <div>");
                _html.AppendLine("                          <div class='nomargin picture-content profilepicture-content'>");
                _html.AppendLine("                              <div class='profilepicture-example'></div>");
                _html.AppendLine("                              <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ :&nbsp;&nbsp;</span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='picture-content profilepicture-content'>");
                _html.AppendFormat("                            <div class='picture-recommend' id='{0}-recommend'>", _idSectionAddUpdate);
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myProfilePictureWidth, UDSUtil._myProfilePictureHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myProfilePictureWidth, UDSUtil._myProfilePictureHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_PROFILEPICTURE));
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
            private static string _idSectionAddUpdate = UDSUtil.ID_SECTION_UPLOADDOCUMENTIDENTITYCARD_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับดึงค่าต่าง ๆ ในการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดบัตรประจำตัวประชาชน แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลการอัพโหลดเอกสารของนักศึกษา
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_IDENTITYCARD];

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

            //ฟังก์ชั่นสำหรับแสดงฟอร์มเพิ่มและปรับปรุงข้อมูลการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดบัตรประจำตัวประชาชน แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADDOCUMENTIDENTITYCARD_ADDUPDATE, _id);

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form uploaddocument-form' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");            
                _html.AppendLine("              <div class='uploaddocument-layout' align='center'>");
                _html.AppendLine("                  <div class='uploaddocument-content'>");
                _html.AppendLine("                      <div>");
                _html.AppendLine("                          <div class='nomargin picture-content identitycard-content'>");
                _html.AppendLine("                              <div class='identitycard-example'></div>");
                _html.AppendLine("                              <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ :&nbsp;&nbsp;</span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='picture-content identitycard-content'>");
                _html.AppendFormat("                            <div class='picture-recommend' id='{0}-recommend'>", _idSectionAddUpdate);
                _html.AppendFormat("                                <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myIdentityCardWidth, UDSUtil._myIdentityCardHeight);
                _html.AppendFormat("                                <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myIdentityCardWidth, UDSUtil._myIdentityCardHeight);
                _html.AppendLine("                              </div>");
                _html.AppendFormat("                            <img id='{0}-image'/>", _idSectionAddUpdate);
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendFormat("                    <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_IDENTITYCARD));
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
            private static string _idSectionAddUpdate                       = UDSUtil.ID_SECTION_UPLOADDOCUMENTTRANSCRIPT_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptInstituteAddUpdate    = UDSUtil.ID_SECTION_UPLOADDOCUMENTTRANSCRIPTINSTITUTE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptFrontsideAddUpdate    = UDSUtil.ID_SECTION_UPLOADDOCUMENTTRANSCRIPTFRONTSIDE_ADDUPDATE.ToLower();
            private static string _idSectionTranscriptBacksideAddUpdate     = UDSUtil.ID_SECTION_UPLOADDOCUMENTTRANSCRIPTBACKSIDE_ADDUPDATE.ToLower();

            //ฟังก์ชั่นสำหรับดึงค่าต่าง ๆ ในการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดระเบียนแสดงผลการเรียน แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _valueDataRecorded เป็น Dictionary<string, object> รับค่าต่าง ๆ ของข้อมูลการอัพโหลดเอกสารของนักศึกษา
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + UDSUtil.SUBJECT_SECTION_TRANSCRIPT];

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

            //ฟังก์ชั่นสำหรับแสดงฟอร์มเพิ่มและปรับปรุงข้อมูลการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดระเบียนแสดงผลการเรียน แล้วส่งค่ากลับเป็น StringBuilder
            //โดยมีพารามิเตอร์ดังนี้
            //1. _id    เป็น string รับค่ารหัสที่ต้องการ
            public static StringBuilder GetMain(string _id)
            {
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                Dictionary<string, object> _valueDataRecorded = UDSUtil.SetValueDataRecorded(UDSUtil.PAGE_UPLOADDOCUMENTTRANSCRIPT_ADDUPDATE, _id);
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
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionTranscriptInstituteAddUpdate + "-institutecountry-combobox'>" + UDSUI.GetComboboxCountry(_idSectionTranscriptInstituteAddUpdate + "-institutecountry") + "</div>"));
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
                
                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
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
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine(                                           UDSUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
                _html.AppendLine("                                      </div>");
                _html.AppendLine("                                  </div>");
                _html.AppendLine("                              </div");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                      </div>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendLine("                          <div>");
                _html.AppendLine("                              <div class='nomargin picture-content transcriptfrontside-content'>");
                _html.AppendLine("                                  <div class='transcriptfrontside-example'></div>");
                _html.AppendLine("                                  <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ :&nbsp;&nbsp;</span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='picture-content transcriptfrontside-content'>");
                _html.AppendFormat("                                <div class='picture-recommend' id='{0}-recommend'>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptFrontsideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE));
                _html.AppendLine("                      </div>");
                _html.AppendFormat("                    <div id='{0}-form'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                          <div>");
                _html.AppendLine("                              <div class='nomargin picture-content transcriptbackside-content'>");
                _html.AppendLine("                                  <div class='transcriptbackside-example'></div>");
                _html.AppendLine("                                  <div class='uploaddocument-recommend'><span class='th-label'>คำแนะนำ :&nbsp;&nbsp;</span><span class='en-label'>Recommend</span></div>");
                _html.AppendLine("                              </div>");
                _html.AppendLine("                              <div class='picture-content transcriptbackside-content'>");
                _html.AppendFormat("                                <div class='picture-recommend' id='{0}-recommend'>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendFormat("                                    <div class='th-label'>เฉพาะนามสกุล jpg, jpeg<br />ขนาด {0} x {1} พิกเซลหรือมากกว่า</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendFormat("                                    <div class='en-label'>Permitted file types jpg, jpeg<br />Size {0} x {1} pixel or more than</div>", UDSUtil._myTranscriptWidth, UDSUtil._myTranscriptHeight);
                _html.AppendLine("                                  </div>");
                _html.AppendFormat("                                <img id='{0}-image'/>", _idSectionTranscriptBacksideAddUpdate);
                _html.AppendLine("                              </div>");
                _html.AppendLine("                          </div>");
                _html.AppendLine("                          <div class='clear'></div>");
                _html.AppendFormat("                        <div>{0}</div>", GetFrmUploadFile(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE));
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
    */
}